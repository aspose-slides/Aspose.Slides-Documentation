---
title: Adding Line Shape to Slide in Python
type: docs
weight: 20
url: /java/adding-line-shape-to-slide-in-python/
---

## **Aspose.Slides - Adding Line Shape to Slide**
To Add Line Shape to Slide using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 def add_plain_line(self):

\# Create an instance of Presentation class

pres = self.Presentation()

\# Get the first slide

sld = pres.getSlides().get_Item(0)

\# Add an autoshape of type line

shapeType = self.ShapeType

sld.getShapes().addAutoShape(shapeType.Line, 50, 150, 300, 0)

\# Write the presentation as a PPTX file

save_format = self.SaveFormat()

pres.save(self.dataDir + "LineShape.pptx", save_format.Pptx)

print "Added plain line to slide, please check the output file."

def add_arrow_line(self):

\# Create an instance of Presentation class

pres = self.Presentation()

\# Get the first slide

sld = pres.getSlides().get_Item(0)

\# Add an autoshape of type line

shapeType = self.ShapeType()

shp = sld.getShapes().addAutoShape(shapeType.Line, 50, 150, 300, 0)

\# Apply some formatting on the line

lineStyle = self.LineStyle()

shp.getLineFormat().setStyle(lineStyle.ThickBetweenThin)

shp.getLineFormat().setWidth(10)

lineDashStyle = self.LineDashStyle()

shp.getLineFormat().setDashStyle(lineDashStyle.DashDot)

lineArrowheadLength = self.LineArrowheadLength()

lineArrowheadStyle = self.LineArrowheadStyle()

fillType = self.FillType()

color = self.Color()

presetColor = self.PresetColor()

shp.getLineFormat().setBeginArrowheadLength(lineArrowheadLength.Short)

shp.getLineFormat().setBeginArrowheadStyle(lineArrowheadStyle.Oval)

shp.getLineFormat().setEndArrowheadLength(lineArrowheadLength.Long)

shp.getLineFormat().setEndArrowheadStyle(lineArrowheadStyle.Triangle)

shp.getLineFormat().getFillFormat().setFillType(fillType.Solid)

shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(self.Color(presetColor.Maroon))

\# Write the presentation as a PPTX file

save_format = self.SaveFormat()

pres.save(self.dataDir + "ArrowShape.pptx", save_format.Pptx)

print "Added arrow shape line to slide, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
