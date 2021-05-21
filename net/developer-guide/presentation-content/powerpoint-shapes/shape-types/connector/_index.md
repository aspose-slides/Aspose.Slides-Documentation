---
title: Connector
type: docs
weight: 10
url: /net/connector/
---

## **Connect Shapes Using Connectors**
In order to add a connector shape for joining two shapes. Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Add two add AutoShape's in selected slide using AddAutoShape method exposed by Shapes object.
1. Add Connector using AddConnector method exposed by Shapes object by defining Connector Type.
1. Join the added shape using connectors.
1. Call Reroute() method to create shortest automatic connection path.
1. Write the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) as a PPTX file.
   In the example given below, we have added a connector between two shapes.

```c#
// The path to the documents directory.                    
string dataDir = RunExamples.GetDataDir_Shapes();
            
// Instantiate Presentation class that represents the PPTX file
using (Presentation input = new Presentation())
{                
    // Accessing shapes collection for selected slide
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Add autoshape Ellipse
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Add autoshape Rectangle
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Adding connector shape to slide shape collection
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Joining Shapes to connectors
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Call reroute to set the automatic shortest path between shapes
    connector.Reroute();

    // Saving presenation
    input.Save(dataDir + "Connecting shapes using connectors_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

Method IConnector.Reroute() reroutes connector so that it take the shortest possible path between the shapes it connect. To do this, the Reroute() method may change the StartShapeConnectionSiteIndex and EndShapeConnectionSiteIndex.

{{% /alert %}} 

## **Use Desired Connection Site**
In order to add a connector shape for joining two shapes. Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Add two add AutoShape's in selected slide using AddAutoShape method exposed by Shapes object.
1. Add Connector using AddConnector method exposed by Shapes object by defining Connector Type.
1. Join the added shape using connectors.
1. Setting the desired connection site on shape for connector.
1. Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

```c#
// The path to the documents directory.                    
string dataDir = RunExamples.GetDataDir_Shapes();

// Instantiate Presentation class that represents the PPTX file
using (Presentation presentation = new Presentation())
{
    // Accessing shapes collection for selected slide
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Adding connector shape to slide shape collection
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Add autoshape Ellipse
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Add autoshape Rectangle
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Joining Shapes to connectors
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Setting the desired connection site index of Ellipse shape for connector to get connected
    uint wantedIndex = 6;

    // Checking if desired index is less than maximum site index count
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Setting the desired connection site for connector on Ellipse
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Save presentation
    presentation.Save(dataDir + "Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```



## **Find Angle of Connector Lines**
In order to calculate the angle for connector line, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the presentation.
1. Obtain the reference of a slide by using its Index.
1. Access the Connector Line shape.
1. Use the line width, height, shape frame height and shape frame width to calculate the angle.
   In the example given below, we have calculated the angle for connector line shape in slide.

```c#
public static void Run()
{
    // The path to the documents directory.
    string dataDir = RunExamples.GetDataDir_Shapes();

    Presentation pres = new Presentation(dataDir + "ConnectorLineAngle.pptx");
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

