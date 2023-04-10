namespace Shapes {
  public abstract class Shape {
    public abstract double Area();
    public abstract double Perimeter();
  }
  public class Triangle : Shape{
    public double sideA {
      get{return sideA;}
      set{if (value > 0) {sideA = value;}}
    }
    public double sideB {
      get{return sideB;}
      set{if (value > 0) {sideB = value;}}
    }
    public double sideC {
      get{return sideC;}
      set{if (value > 0) {sideC = value;}}
    }

    public Triangle(double sideA, double sideB, double sideC) {
      
      string errorMessage = "Every side of the triangle must be a positive, non-negative number. Received a `{0}`";
      if (sideA !> 0) {throw new ArgumentException(string.Format(errorMessage, sideA.ToString()));}
      if (sideB !> 0) {throw new ArgumentException(string.Format(errorMessage, sideB.ToString()));}
      if (sideC !> 0) {throw new ArgumentException(string.Format(errorMessage, sideC.ToString()));}

      this.sideA = sideA;
      this.sideB = sideB;
      this.sideC = sideC;
    }

    public override double Area() {
      
      double semiPerimeter = this.Perimeter() / 2;
      
      return Math.Sqrt(
        semiPerimeter
        * (semiPerimeter - this.sideA)
        * (semiPerimeter - this.sideB)
        * (semiPerimeter - this.sideC)
      );
    }

    public override double Perimeter() {
      return this.sideA
        + this.sideB
        + this.sideC;
    }
  }

  public class Polygon : Shape {

    // https://en.wikipedia.org/wiki/Regular_polygon

    private double _faceLength;
    public double faceLength {
      get{return _faceLength;}
      set{if (value > 0) {_faceLength = value;}}
    }
    private double _faces;
    public double faces {
      get{return _faces;}
      set{if (value >= 3) {_faces = value;}}
    }

    public Polygon(double sideLength, int faces) {
      
      if (sideLength <= 0) {
        throw new ArgumentException($"Side length must be a positive, non-zero number. Received `{sideLength}`");
      }
      if (faces < 3) {
        throw new ArgumentException($"The regular polygon must have at least 3 faces. Received `{faces}`");
      }

      this._faceLength = sideLength;
      this._faces = faces;
    }


    public override double Area() {

      // https://en.wikipedia.org/wiki/Regular_polygon#Area

      double cosComponent = Math.Cos(Math.PI / this._faces);
      double sinComponent = Math.Sin(Math.PI / this._faces);
      double cotComponent = cosComponent / sinComponent;

      return (this._faces/4) * Math.Pow(this._faceLength, 2) * cotComponent;
    }

    public override double Perimeter() {

      return this._faceLength * this._faces;
    }
  }
}