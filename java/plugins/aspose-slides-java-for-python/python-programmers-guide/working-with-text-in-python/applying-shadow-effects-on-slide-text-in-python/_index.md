---
title: Applying Shadow Effects on Slide Text in Python
type: docs
weight: 10
url: /java/applying-shadow-effects-on-slide-text-in-python/
---

## **Aspose.Slides - Applying Shadow Effects on Slide Text**
To Apply Shadow Effects on Slide Text using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 # Create an instance of Presentation class

pres = self.Presentation

\# Get the first slide

slide = pres.getSlides().get_Item(0)

\# Add an AutoShape of Rectangle type

shapeType=ShapeType

shp = slide.getShapes().addAutoShape(shapeType.Rectangle, 150, 75, 150, 50)

\# Add TextFrame to the Rectangle

shp.addTextFrame("Aspose TextBox")

\# Disable shape fill in case we want to get shadow of text

fillType = self.FillType

shp.getFillFormat().setFillType(fillType.NoFill)

\# Add outer shadow and set all necessary parameters

shp.getEffectFormat().enableOuterShadowEffect()

shadow = shp.getEffectFormat().getOuterShadowEffect()

shadow.setBlurRadius(4.0)

shadow.setDirection(45)

shadow.setDistance(3)

rectangleAlignment=RectangleAlignment

color = self.Color

shadow.setRectangleAlign(rectangleAlignment.TopLeft)

shadow.getShadowColor().setColor(color.black)

\# Write the presentation as a PPTX file

save_format = self.SaveFormat

pres.save(self.dataDir + "OutShadow.pptx", save_format.Pptx)

print "Applied shadow effects on text, please check the output file."

```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
