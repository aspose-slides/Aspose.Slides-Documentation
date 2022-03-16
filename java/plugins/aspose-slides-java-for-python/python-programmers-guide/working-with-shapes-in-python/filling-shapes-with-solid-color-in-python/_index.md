---
title: Fill PowerPoint Slide Shapes with Solid Color in Python
linktitle: Filling Shapes with Solid Color in Python
type: docs
weight: 70
url: /java/filling-shapes-with-solid-color-in-python/
---

## **Aspose.Slides - Filling Shapes with Solid Color**
Fill Shapes with Solid Color using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

```

 # Create an instance of Presentation class

pres = self.Presentation()

\# Get the first slide

sld = pres.getSlides().get_Item(0)

\# Add autoshape of rectangle type

shapeType = self.ShapeType()

shp = sld.getShapes().addAutoShape(shapeType.Rectangle, 50, 150, 75, 150)

\# Set the fill type to Picture

fillType = self.FillType()

shp.getFillFormat().setFillType(fillType.Picture)

\# Set the picture fill mode

pictureFillMode = self.PictureFillMode()

shp.getFillFormat().getPictureFillFormat().setPictureFillMode(pictureFillMode.Tile)

\# Set the picture

imgx = pres.getImages().addImage(self.FileInprinttream(self.File(self.dataDir + "night.jpg")))

shp.getFillFormat().getPictureFillFormat().getPicture().setImage(imgx)

\# Write the presentation as a PPTX file

save_format = self.SaveFormat()

pres.save(self.dataDir + "RectShpPic.pptx", save_format.Pptx)

print "Filled shapes with Picture, please check the output file."

```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
