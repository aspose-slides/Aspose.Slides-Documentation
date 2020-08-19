---
title: Formatting Lines of the Shapes in Python
type: docs
weight: 90
url: /java/formatting-lines-of-the-shapes-in-python/
---

## **Aspose.Slides - Formatting Lines of the Shapes**
To Format Lines of the Shapes using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

```

 def format_lines(self):

\# Create an instance of Presentation class

pres = self.Presentation()

\# Get the first slide

sld = pres.getSlides().get_Item(0)

\# Add autoshape of rectangle type

shapeType = self.ShapeType

shp = sld.getShapes().addAutoShape(shapeType.Rectangle, 50, 150, 75, 150)

\# Set the fill color of the rectangle shape

fillType = self.FillType()

color = self.Color()

shp.getFillFormat().setFillType(fillType.Solid)

shp.getFillFormat().getSolidFillColor().setColor(color.WHITE)

\# Apply some formatting on the line of the rectangle

lineStyle = self.LineStyle()

shp.getLineFormat().setStyle(lineStyle.ThickThin)

shp.getLineFormat().setWidth(7)

lineDashStyle = self.LineDashStyle()

shp.getLineFormat().setDashStyle(lineDashStyle.Dash)

\# set the color of the line of rectangle

shp.getLineFormat().getFillFormat().setFillType(fillType.Solid)

shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(color.BLUE)

\# Write the presentation as a PPTX file

save_format = self.SaveFormat()

pres.save(self.dataDir + "RectShpLn.pptx", save_format.Pptx)

print "Formatted lines, please check the output file."

def format_join_styles(self):

\# Create an instance of Presentation class

pres = self.Presentation()

\# Get the first slide

sld = pres.getSlides().get_Item(0)

\# Add three autoshapes of rectangle type

shape_type = self.ShapeType()

shp1 = sld.getShapes().addAutoShape(shape_type.Rectangle, 50, 100, 150, 75)

shp2 = sld.getShapes().addAutoShape(shape_type.Rectangle, 300, 100, 150, 75)

shp3 = sld.getShapes().addAutoShape(shape_type.Rectangle, 50, 250, 150, 75)

\# Set the fill color of the rectangle shape

fill_type = self.FillType()

color = self.Color()

shp1.getFillFormat().setFillType(fill_type.Solid)

shp1.getFillFormat().getSolidFillColor().setColor(color.BLACK)

shp2.getFillFormat().setFillType(fill_type.Solid)

shp2.getFillFormat().getSolidFillColor().setColor(color.BLACK)

shp3.getFillFormat().setFillType(fill_type.Solid)

shp3.getFillFormat().getSolidFillColor().setColor(color.BLACK)

\# Set the line width

shp1.getLineFormat().setWidth(15)

shp2.getLineFormat().setWidth(15)

shp3.getLineFormat().setWidth (15)

\# Set the color of the line of rectangle

shp1.getLineFormat().getFillFormat().setFillType(fill_type.Solid)

shp1.getLineFormat().getFillFormat().getSolidFillColor().setColor(color.BLUE)

shp2.getLineFormat().getFillFormat().setFillType(fill_type.Solid)

shp2.getLineFormat().getFillFormat().getSolidFillColor().setColor(color.BLUE)

shp3.getLineFormat().getFillFormat().setFillType(fill_type.Solid)

shp3.getLineFormat().getFillFormat().getSolidFillColor().setColor(color.BLUE)

\# Set the Join Style

line_join_style = self.LineJoinStyle()

shp1.getLineFormat().setJoinStyle(line_join_style.Miter)

shp2.getLineFormat().setJoinStyle(line_join_style.Bevel)

shp3.getLineFormat().setJoinStyle(line_join_style.Round)

\# Add text to each rectangle

shp1.getTextFrame().setText ("This is Miter Join Style")

shp2.getTextFrame().setText( "This is Bevel Join Style")

shp3.getTextFrame().setText ("This is Round Join Style")

\# Write the presentation as a PPTX file

save_format = self.SaveFormat()

pres.save(self.dataDir + "RectShpLnJoin.pptx", save_format.Pptx)

print "Formatted join styles, please check the output file."

```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
