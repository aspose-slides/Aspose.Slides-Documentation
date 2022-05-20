---
title: Connector
type: docs
weight: 10
url: /net/connector/
keywords: "Connect shapes, connectors, PowerPoint shapes, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Connect PowerPoint shapes in C# or .NET"
---

A PowerPoint connector is a special line that connects or links two shapes together and stays attached to shapes even when they are moved or repositioned on a given slide. 

Connectors are typically connected to *connection dots* (green dots), which exist on all shapes by default. Connection dots appear when a cursor comes close to them.

Adjustment points (orange dots), which exist only on certain connectors, are used to modify connectors' positions and shapes.

## **Types of Connectors**

In PowerPoint, you can use straight, elbow (angled), and curved connectors. 

Aspose.Slides provides these connectors:

| Connector                      | Image                                                        | Number of adjustment points |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Connect Shapes Using Connectors**

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Get a slide's reference through its index.
1. Add two [AutoShape](https://apireference.aspose.com/slides/net/aspose.slides/autoshape) to the slide using the `AddAutoShape` method exposed by the `Shapes` object.
1. Add a connector using the `AddConnector` method exposed by the `Shapes` object by defining the connector type.
1. Connect the shapes using the connector. 
1. Call the `Reroute` method to apply the shortest connection path.
1. Save the presentation. 

This C# code shows you how to add a connector (a bent connector) between two shapes (an ellipse and rectangle):

```c#
// Instantiates a presentation class that represents a PPTX file
using (Presentation input = new Presentation())
{                
    // Accesses the shapes collection for a specific slide
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Adds an Ellipse autoshape
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Adds a Rectangle autoshape
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Adds a connector shape to the slide shape collection
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Connects the shapes using the connector
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Call reroute that sets the automatic shortest path between shapes
    connector.Reroute();

    // Saves the presenation
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

The `Connector.Reroute` method reroutes a connector and forces it to take the shortest possible path between shapes. To achieve its goal, the method may change the `StartShapeConnectionSiteIndex` and `EndShapeConnectionSiteIndex` points. 

{{% /alert %}} 

## **Specify Connection Dot**
If you want a connector to link two shapes using specific dots on the shapes, you have to specify your preferred connection dots this way:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Get a slide's reference through its index.
1. Add two [AutoShape](https://apireference.aspose.com/slides/net/aspose.slides/autoshape) to the slide using the `AddAutoShape` method exposed by the `Shapes` object.
1. Add a connector using the `AddConnector` method exposed by the `Shapes` object by defining the connector type.
1. Connect the shapes using the connector. 
1. Set your preferred connection dots on the shapes. 
1. Save the presentation.

This C# code demonstrates an operation

```c#
// Instantiates a presentation class that represents a PPTX file
using (Presentation presentation = new Presentation())
{
    // Accesses the shapes collection for a specific slide
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Adds a connector shape to the slide's shape collection
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Add an Ellipse autoshape
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Add a Rectangle autoshape
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Connects the shapes using the connector
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Sets the preferred connection dot index on the Ellipse shape
    uint wantedIndex = 6;

    // Checks whether the preferred index is less than the maximum site index count
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Sets the preferred connection dot on the Ellipse autoshape
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Saves the presentation
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **Adjust Connector Point**

You can adjust an existing connector through its adjustment points. Only connectors with adjustment points can be altered in this manner. See the table under **[Types of connectors.](/slides/net/connector/#types-of-connectors)** 

### **Simple Case**

Consider a case where a connector between two shapes (A and B) passes through a third shape (C):

![connector-obstruction](connector-obstruction.png)

Code:

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

To avoid the third shape, we can adjust the connector by moving its vertical line to the left this way:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **Other Cases** 

To perform more complicated adjustments, you have to take these things into account:

* A connector's adjustable point is strongly linked to a formula that calculates and determines its position. So changes to the point's location may alter the connector's shape.
* A connector's adjustment points are defined in a strict order in an array. The adjustment points are numbered from a connector's start point to its end.
* The number of adjustment points a connector has is obtained from its width and height based on certain formulas.
* For calculations that determine the coordinates of a connector's adjustment points, you have to take the connector's rotation and its reflection into account. **Note** that the rotation angle for all connectors shown under **[Types of connectors](/slides/net/connector/#types-of-connectors)** is 0.

## **Find Angle of Connector Lines**
1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Get a slide's reference through its index.
1. Access the connector line shape.
1. Use the line width, height, shape frame height, and shape frame width to calculate the angle.

This C# code demonstrates an operation in which we calculated the angle for a connector line shape:

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

