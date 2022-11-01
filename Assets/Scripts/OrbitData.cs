using UnityEngine;

[System.Serializable]
public struct OrbitData
{
    public int index;
    public double mass;
    public Vector3d velocity;
    public Vector3d position;
    public Vector3d nextAcceleration;

    public OrbitData(int index, double mass, Vector3d velocity, Vector3d position)
    {
        this.index = index;
        this.mass = mass;
        this.velocity = velocity;
        this.position = position;
        this.nextAcceleration = Vector3d.zero;
    }

    public void CalculateGravitationalAcceleration(OrbitData[] orbitData)
    {
        Vector3d acceleration = Vector3d.zero;
        for (int i = 0; i < orbitData.Length; i++)
        {
            if (i == index) { continue; }

            Vector3d r = (orbitData[i].position - position);

            acceleration += (r * (Constant.G * orbitData[i].mass)) / (r.magnitude * r.magnitude * r.magnitude);
        }
        nextAcceleration = acceleration;
    }

    public void AddForce(double time, Integrator integrator)
    {
        if (integrator == Integrator.None)
        {
            velocity += nextAcceleration * time;
            position += velocity * time;
        }
        else if (integrator == Integrator.RK4)
        {

        }
        else if (integrator == Integrator.RKDP45)
        {
        }
    }
}