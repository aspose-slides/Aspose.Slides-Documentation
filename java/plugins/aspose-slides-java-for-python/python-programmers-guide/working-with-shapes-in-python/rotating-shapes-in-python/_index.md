---
title: Rotating Shapes in Python
type: docs
weight: 100
url: /java/rotating-shapes-in-python/
---

## **Aspose.Slides - Rotating Shapes**
To Rotate Shapes using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 # Create an instance of Presentation class

pres = self.Presentation

\# Get the first slide

sld = pres.getSlides().get_Item(0)

\# Add autoshape of rectangle type

shapeType = self.ShapeType

shp = sld.getShapes().addAutoShape(shapeType.Rectangle, 50, 150, 75, 150)

\# Rotate the shape to 90 degree

shp.setRotation(90)

\# Write the presentation as a PPTX file

save_format = self.SaveFormat()

pres.save(self.dataDir + "RectShpRot.pptx", save_format.Pptx)

print "Rotated shape, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
