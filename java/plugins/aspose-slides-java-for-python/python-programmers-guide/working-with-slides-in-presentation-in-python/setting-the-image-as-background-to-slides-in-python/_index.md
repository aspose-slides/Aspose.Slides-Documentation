---
title: Setting the Image as Background to Slides in Python
type: docs
weight: 110
url: /java/setting-the-image-as-background-to-slides-in-python/
---

## **Aspose.Slides - Setting the Image as Background to Slides**
To Set the Image as Background to Slides using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 # Instantiate Presentation class that represents the presentation file

pres = self.Presentation

\# Set the background with Image

backgroundType = self.BackgroundType

fillType = self.FillType

pictureFillMode = self.PictureFillMode

pres.getSlides().get_Item(0).getBackground().setType(backgroundType.OwnBackground)

pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(fillType.Picture)

pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(pictureFillMode.Stretch)

\# Set the picture

imgx = pres.getImages().addImage(self.FileInputStream(self.File(self.dataDir + 'night.jpg')))

\# Image imgx = pres.getImages().addImage(image)

\# Add image to presentation's images collection

pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(imgx)

\# Saving the presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "ContentBG_Image.pptx", save_format.Pptx)

print "Set image as background, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
