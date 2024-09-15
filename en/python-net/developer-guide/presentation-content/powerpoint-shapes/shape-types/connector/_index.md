---
title: Connector
type: docs
weight: 10
url: /python-net/connector/
keywords: "Connect shapes, connectors, PowerPoint shapes, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Connect PowerPoint shapes in Python"
---

A PowerPoint connector is a special line that connects or links two shapes together and stays attached to shapes even when they are moved or repositioned on a given slide. 

Connectors are typically connected to *connection dots* (green dots), which exist on all shapes by default. Connection dots appear when a cursor comes close to them.

*Adjustment points* (orange dots), which exist only on certain connectors, are used to modify connectors' positions and shapes.

## **Types of Connectors**

In PowerPoint, you can use straight, elbow (angled), and curved connectors. 

Aspose.Slides provides these connectors:

| Connector                      | Image                                                        | Number of adjustment points |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.LINE`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BENT_CONNECTOR2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BENT_CONNECTOR3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BENT_CONNECTOR4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BENT_CONNECTOR5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CURVED_CONNECTOR2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CURVED_CONNECTOR3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CURVED_CONNECTOR4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CURVED_CONNECTOR5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Connect Shapes Using Connectors**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a slide's reference through its index.
1. Add two [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) to the slide using the `add_auto_shape` method exposed by the `Shapes` object.
1. Add a connector using the `add_auto_shape` method exposed by the `Shapes` object by defining the connector type.
1. Connect the shapes using the connector. 
1. Call the `reroute` method to apply the shortest connection path.
1. Save the presentation. 

This Python code shows you how to add a connector (a bent connector) between two shapes (an ellipse and rectangle):

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a PPTX file
with slides.Presentation() as input:
    # Accesses the shapes collection for a specific slide
    shapes = input.slides[0].shapes

    # Adds an Ellipse autoshape
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # Adds a Rectangle autoshape
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 300, 100, 100)

    # Adds a connector shape to the slide shape collection
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Connects the shapes using the connector
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Calls reroute that sets the automatic shortest path between shapes
    connector.reroute()

    # Saves the presentation
    input.save("Connecting shapes using connectors_out.pptx", slides.export.SaveFormat.PPTX)

```

{{%  alert title="NOTE"  color="warning"   %}} 

The `connector.reroute` method reroutes a connector and forces it to take the shortest possible path between shapes. To achieve its aim, the method may change the `start_shape_connection_site_index` and `end_shape_connection_site_index` points. 

{{% /alert %}} 

## **Specify Connection Dot**

If you want a connector to link two shapes using specific dots on the shapes, you have to specify your preferred connection dots this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a slide's reference through its index.
1. Add two [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) to the slide using the `add_auto_shape` method exposed by the `Shapes` object.
1. Add a connector using the `add_connector` method exposed by the `Shapes` object by defining the connector type.
1. Connect the shapes using the connector. 
1. Set your preferred connection dots on the shapes. 
1. Save the presentation.

This Python code demonstrates an operation where a preferred connection dot is specified:

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a PPTX file
with slides.Presentation() as presentation:
    # Accesses the shapes collection for a specific slide
    shapes = presentation.slides[0].shapes

    # Adds a connector shape to the slide's shape collection
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Add an Ellipse autoshape
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # Add a Rectangle autoshape
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 100, 100)

    # Connects the shapes using the connector
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Sets the preferred connection dot index on the Ellipse shape
    wantedIndex = 6

    # Checks whether the preferred index is less than the maximum site index count
    if  ellipse.connection_site_count > wantedIndex:
        # Sets the preferred connection dot on the Ellipse autoshape
        connector.start_shape_connection_site_index = wantedIndex

    # Saves the presentation
    presentation.save("Connecting_Shape_on_desired_connection_site_out.pptx", slides.export.SaveFormat.PPTX)

```

## **Adjust Connector Point**

You can adjust an existing connector through its adjustment points. Only connectors with adjustment points can be altered in this manner. See the table under **[Types of connectors.](/slides/python-net/connector/#types-of-connectors)** 

#### **Simple Case**

Consider a case where a connector between two shapes (A and B) passes through a third shape (C):

![connector-obstruction](connector-obstruction.png)

Code:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    sld = pres.slides[0]
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shapeFrom = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shapeTo = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shapeFrom
    connector.end_shape_connected_to = shapeTo
    connector.start_shape_connection_site_index = 2
```

To avoid or bypass the third shape, we can adjust the connector by moving its vertical line to the left this way:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```python
    adj2 = connector.adjustments[1]
    adj2.raw_value += 10000
```

### **Complex Cases** 

To perform more complicated adjustments, you have to take these things into account:

* A connector's adjustable point is strongly linked to a formula that calculates and determines its position. So changes to the point's location may alter the connector's shape.
* A connector's adjustment points are defined in a strict order in an array. The adjustment points are numbered from a connector's start point to its end.
* Adjustment point values reflect the percentage of a connector shape's width/height. 
  * The shape is bounded by the connector's start and end points multiplied by 1000. 
  * The first point, second point, and third point defines the percentage from the width, the percentage from the height, and the percentage from the width (again) respectively.
* For calculations that determine the coordinates of a connector's adjustment points, you have to take the connector's rotation and its reflection into account. **Note** that the rotation angle for all connectors shown under **[Types of connectors](/slides/python-net/connector/#types-of-connectors)** is 0.

#### **Case 1**

Consider a case where two text frame objects are linked together through a connector:

![connector-shape-complex](connector-shape-complex.png)

Code:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiates a presentation class that represents a PPTX file
with slides.Presentation() as pres:
    # Gets the first slide in the presentation
    sld = pres.slides[0]
    # Adds shapes that will be joined together through a connector
    shapeFrom = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shapeFrom.text_frame.text = "From"
    shapeTo = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shapeTo.text_frame.text = "To"
    # Adds a connector
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Specifies the connector's direction
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Specifies the connector's color
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Specifies the thickness of the connector's line
    connector.line_format.width = 3

    # Links the shapes together with the connector
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shapeTo
    connector.end_shape_connection_site_index = 2

    # Gets adjustment points for the connector
    adjValue_0 = connector.adjustments[0]
    adjValue_1 = connector.adjustments[1]
```

**Adjustment**

We can change the connector's adjustment point values by increasing the corresponding width and height percentage by 20% and 200%, respectively:

```python
    # Changes the values of the adjustment points
    adjValue_0.raw_value += 20000
    adjValue_1.raw_value += 200000
```

The result:

![connector-adjusted-1](connector-adjusted-1.png)

To define a model that allows us determine the coordinates and the shape of individual parts of the connector, let's create a shape that corresponds to the horizontal component of the connector at the connector.adjustments[0] point:

```python
    # Draw the vertical component of the connector

    x = connector.x + connector.width * adjValue_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjValue_1.raw_value / 100000
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

The result:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Case 2**

In **Case 1**, we demonstrated a simple connector adjustment operation using basic principles. In normal situations, you have to take the connector rotation and its display (which are set by the connector.rotation, connector.frame.flip_h, and connector.frame.flip_v) into account. We will now demonstrate the process.

First, let's add a new text frame object (**To 1**) to the slide (for connection purposes) and create a new (green) connector that connects it to the objects we already created.

```python
    # Creates a new binding object
    shapeTo_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shapeTo_1.text_frame.text = "To 1"
    # Creates a new connector
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    # Connects objects using the newly created connector
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shapeTo_1
    connector.end_shape_connection_site_index = 3
    # Gets the connector adjustment points
    adjValue_0 = connector.adjustments[0]
    adjValue_1 = connector.adjustments[1]
    # Changes the values of the adjustment points 
    adjValue_0.raw_value += 20000
    adjValue_1.raw_value += 200000
```

The result:

![connector-adjusted-3](connector-adjusted-3.png)

Second, let's create a shape that will correspond to the horizonal component of the connector that passes through the new connector's adjustment point connector.adjustments[0]. We will use the values from the connector data for connector.rotation, connector.frame.flip_h, and connector.frame.flip_v and apply the popular coordinate conversion formula for rotation round a given point x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In our case, the object's angle of rotation is 90 degrees and the connector is displayed vertically, so this is the corresponding code:

```python
    # Saves the connector coordinates
    x = connector.x
    y = connector.y
    # Corrects the connector coordinates in case it appears
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Takes in the adjustment point value as the coordinate
    x += connector.width * adjValue_0.raw_value / 100000
    
    #  Converts the coordinates since Sin(90) = 1 and Cos(90) = 0
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Determines the width of the horizontal component using the second adjustment point value
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

The result:

![connector-adjusted-4](connector-adjusted-4.png)

We demonstrated calculations involving simple adjustments and complicated adjustment points (adjustment points with rotation angles). Using the knowledge acquired, you can develop your own model (or write a code) to get a `GraphicsPath` object or even set a connector's adjustment point values based on specific slide coordinates.

## **Find Angle of Connector Lines**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a slide's reference through its index.
1. Access the connector line shape.
1. Use the line width, height, shape frame height, and shape frame width to calculate the angle.

This Python code demonstrates an operation in which we calculated the angle for a connector line shape:

```python
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