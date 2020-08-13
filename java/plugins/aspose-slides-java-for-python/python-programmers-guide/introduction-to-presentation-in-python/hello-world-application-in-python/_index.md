---
title: Hello World Application in Python
type: docs
weight: 10
url: /java/hello-world-application-in-python/
---

## **Aspose.Slides - Hello World**
To create Hello World document using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 # Instantiate Presentation

pres = self.Presentation()

\# Get the first slide

slide = pres.getSlides().get_Item(0)

\# Add an AutoShape of Rectangle type

shape_type = self.ShapeType

ashp = slide.getShapes().AddAutoShape(shape_type.Rectangle, 150, 75, 150, 50)

\# Add ITextFrame to the Rectangle

ashp.addTextFrame("Hello World")

\# Change the text color to Black (which is White by default)

fill_type = self.FillType

color = self.Color

ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getFillFormat().setFillType(fill_type.Solid)

ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getFillFormat().getSolidFillColor().setColor(color.BLACK)

\# Change the line color of the rectangle to White

ashp.getShapeStyle().getLineColor().setColor(color.WHITE)

\# Remove any fill formatting in the shape

ashp.getFillFormat().setFillType(fill_type.NoFill)

\# Save the presentation to disk

save_format = self.SaveFormat

pres.save(self.dataDir + "HelloWorld.pptx", save_format.Pptx)

print "Document has been saved, please check the output file."

```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
