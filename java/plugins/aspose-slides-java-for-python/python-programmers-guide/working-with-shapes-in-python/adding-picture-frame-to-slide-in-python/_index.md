---
title: Adding Picture Frame to Slide in Python
type: docs
weight: 30
url: /java/adding-picture-frame-to-slide-in-python/
---

## **Aspose.Slides - Add Picture Frame to Slide**
To Add Picture Frame to Slide using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 # Create an instance of Presentation class

pres = self.Presentation

\# Get the first slide

sId = pres.getSlides(1)

\# Instantiate the Image class

imgx = pres.getImages().addImage(self.FileInputStream(self.File(self.dataDir + "aspose-logo.jpg")))

\# Add Picture Frame with height and width equivalent of Picture

shapeType = self.ShapeType

sId.getShapes().addPictureFrame(shapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx)

\# Write the presentation as a PPTX file

save_format = self.SaveFormat

pres.save(self.dataDir + "RectPicFrame.pptx", save_format.Pptx)

print "Added picture frame to slide, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
