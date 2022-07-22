---
title: Connector
type: docs
weight: 10
url: /python-net/connector/
keywords: "Connect shapes, connectors, PowerPoint shapes, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Connect PowerPoint shapes in Python"
---

## **Connect Shapes Using Connectors**
In order to add a connector shape for joining two shapes. Please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Obtain the reference of a slide by using its Index.
1. Add two add AutoShape's in selected slide using AddAutoShape method exposed by Shapes object.
1. Add Connector using AddConnector method exposed by Shapes object by defining Connector Type.
1. Join the added shape using connectors.
1. Call Reroute() method to create shortest automatic connection path.
1. Write the `Presentation` as a PPTX file.
   In the example given below, we have added a connector between two shapes.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents the PPTX file
with slides.Presentation() as input:
    # Accessing shapes collection for selected slide
    shapes = input.slides[0].shapes

    # Add autoshape Ellipse
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # Add autoshape Rectangle
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 300, 100, 100)

    # Adding connector shape to slide shape collection
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Joining shapes to connectors
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Call reroute to set the automatic shortest path between shapes
    connector.reroute()

    # Saving presenation
    input.save("Connecting shapes using connectors_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

Method IConnector.Reroute() reroutes connector so that it take the shortest possible path between the shapes it connect. To do this, the Reroute() method may change the StartShapeConnectionSiteIndex and EndShapeConnectionSiteIndex.

{{% /alert %}} 

## **Use Desired Connection Site**
In order to add a connector shape for joining two shapes. Please follow the steps below:

1. Create an instance of `Presentation` class.
1. Obtain the reference of a slide by using its Index.
1. Add two add AutoShape's in selected slide using AddAutoShape method exposed by Shapes object.
1. Add Connector using AddConnector method exposed by Shapes object by defining Connector Type.
1. Join the added shape using connectors.
1. Setting the desired connection site on shape for connector.
1. Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents the PPTX file
with slides.Presentation() as presentation:
    # Accessing shapes collection for selected slide
    shapes = presentation.slides[0].shapes

    # Adding connector shape to slide shape collection
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Add autoshape Ellipse
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # Add autoshape Rectangle
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 100, 100)

    # Joining shapes to connectors
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Setting the desired connection site index of Ellipse shape for connector to get connected
    wantedIndex = 6

    # Checking if desired index is less than maximum site index count
    if  ellipse.connection_site_count > wantedIndex:
        # Setting the desired connection site for connector on Ellipse
        connector.start_shape_connection_site_index = wantedIndex

    # save presentation
    presentation.save("Connecting_Shape_on_desired_connection_site_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Find Angle of Connector Lines**
In order to calculate the angle for connector line, please follow the steps below:

1. Create an instance of `Presentation` class and load the presentation.
1. Obtain the reference of a slide by using its Index.
1. Access the Connector Line shape.
1. Use the line width, height, shape frame height and shape frame width to calculate the angle.
   In the example given below, we have calculated the angle for connector line shape in slide.

```py
import aspose.slides as slides
import math

def get_direction(w, h, flipH, flipV):
    endLineX = w * (-1 if flipH else 1)
    endLineY = h * (-1 if flipV else 1)
    endYAxisX = 0
    endYAxisY = h
    angle = math.atan2(endYAxisY, endYAxisX) - math.atan2(endLineY, endLineX)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation(path + "ConnectorLineAngle.pptx") as pres:
    slide = pres.slides[0]
    for i in range(len(slide.shapes)):
        dir = 0.0
        shape = slide.shapes[i]
        if (type(shape) is slides.AutoShape):
            if shape.shape_type == slides.ShapeType.LINE:
                dir = get_direction(shape.width, shape.Height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            dir = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)

        print(dir)
```

