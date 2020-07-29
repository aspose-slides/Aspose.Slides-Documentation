---
title: Adding an Image in Table Cell in Python
type: docs
weight: 10
url: /java/adding-an-image-in-table-cell-in-python/
---

## **Aspose.Slides - Adding an Image in Table Cell**
To Add an Image in Table Cell using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 pres = self.Presentation()

\# Get the first slide

sld = pres.getSlides().get_Item(0)

\# Define co lumns with widths and rows with heights

dbl_cols = [150,150,150,150]

dbl_rows = [100,100,100,100,90]

\# Add table shape to slide

tbl = sld.getShapes().addTable(50, 50, dbl_cols, dbl_rows)

\# Creating a Buffered Image object to hold the image file

imageIO = ImageIO()

image = imageIO.read(File(dataDir + "aspose-logo.jpg"))

imgx1 = pres.getImages().addImage(image)

fillType=FillType()

pictureFillMode=PictureFillMode()

tbl.get_Item(0,0).getFillFormat().setFillType(fillType.Picture)

tbl.get_Item(0,0).getFillFormat().getPictureFillFormat().setPictureFillMode(pictureFillMode.Stretch)

tbl.get_Item(0,0).getFillFormat().getPictureFillFormat().getPicture().setImage(imgx1)

\# Write the presentation as a PPTX file

save_format = SaveFormat

pres.save(self.dataDir + "AddImage.pptx", save_format.Pptx)

print "Added image, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
