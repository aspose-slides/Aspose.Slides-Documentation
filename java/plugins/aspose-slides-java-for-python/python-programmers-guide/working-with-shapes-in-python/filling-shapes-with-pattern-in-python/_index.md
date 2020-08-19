---
title: Filling Shapes with Pattern in Python
type: docs
weight: 50
url: /java/filling-shapes-with-pattern-in-python/
---

## **Aspose.Slides - Filling Shapes with Pattern**
To Fill Shapes with Pattern using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

```

 # Create an instance of Presentation class

pres = self.Presentation()

\# Get the first slide

sld = pres.getSlides().get_Item(0)

\# Add autoshape of rectangle type

shapeType = self.ShapeType

shp = sld.getShapes().addAutoShape(shapeType.Rectangle, 50, 150, 75, 150)

\# Set the fill type to Pattern

fillType = self.FillType()

shp.getFillFormat().setFillType(fillType.Pattern)

\# Set the pattern style

patternStyle = self.PatternStyle()

shp.getFillFormat().getPatternFormat().setPatternStyle(patternStyle.Trellis)

\# Set the pattern back and fore colors

color = self.Color()

shp.getFillFormat().getPatternFormat().getBackColor().setColor(color.LIGHT_GRAY)

shp.getFillFormat().getPatternFormat().getForeColor().setColor(color.YELLOW)

\# Write the presentation as a PPTX file

save_format = self.SaveFormat()

pres.save(self.dataDir + "RectShpPatt.pptx", save_format.Pptx)

print "Filled shapes with Pattern, please check the output file."

```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
