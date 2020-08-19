---
title: Creating Slides Thumbnail Image in Python
type: docs
weight: 60
url: /java/creating-slides-thumbnail-image-in-python/
---

## **Aspose.Slides - Creating Slides Thumbnail Image**
To Create Slides Thumbnail Image using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

```

 def create_thumbnail(self):

\# Instantiate Presentation class that represents the presentation file

pres=self.Presentation

pres = pres(self.dataDir + 'Aspose.pptx')

\# Access the first slide

slide = pres.getSlides().get_Item(0)

\# Create a full scale image

image = slide.getThumbnail()

\# Save the image to disk in JPEG format

imageIO = self.ImageIO()

imageIO.write(image, "jpeg", self.File(self.dataDir + "ContentBG_tnail.jpg"))

print "Created thumbnail, please check the output file."

def create_thumbnail_custom_size(self):

\# Instantiate Presentation class that represents the presentation file

pres=self.Presentation()

pres = pres(self.dataDir + 'Aspose.pptx')

\# Access the first slide

slide = pres.getSlides().get_Item(0)

\# User defined dimension

desired_x = 1200

desired_y = 800

\# Getting scaled value  of X and Y

scale_x = (1.0 / pres.getSlideSize().getSize().getWidth()) * desired_x

scale_y = (1.0 / pres.getSlideSize().getSize().getHeight()) * desired_y

\# Create a full scale image

image = slide.getThumbnail(scale_x, scale_y)

\# Save the image to disk in JPEG format

imageIO = self.ImageIO()

imageIO.write(image, "jpeg", self.File(self.dataDir + "ContentBG_tnail.jpg"))

print "Created thumbnail with custom size, please check the output file."

def create_thumbnail_in_notes_slides_view(self):

\# Instantiate Presentation class that represents the presentation file

pres=self.Presentation()

pres = pres(self.dataDir + 'Aspose.pptx')

\# Access the first slide

slide = pres.getSlides().get_Item(0)

\# User defined dimension

desired_x = 1200

desired_y = 800

\# Getting scaled value  of X and Y

scale_x = (1.0 / pres.getSlideSize().getSize().getWidth()) * desired_x

scale_y = (1.0 / pres.getSlideSize().getSize().getHeight()) * desired_y

\# Create a full scale image

image = slide.getNotesSlide().getThumbnail(scale_x, scale_y)

\# Save the image to disk in JPEG format

imageIO = self.ImageIO()

imageIO.write(image, "jpeg", self.File(self.dataDir + "ContentBG_tnail.jpg"))

print "Created thumbnail in notes slides view, please check the output file."

def create_thumbnail_of_user_defined_window(self):

\# Instantiate Presentation class that represents the presentation file

pres=self.Presentation()

pres = pres(self.dataDir + 'Aspose.pptx')

\# Access the first slide

slide = pres.getSlides().get_Item(0)

\# Create a full scale image

image = slide.getThumbnail(1,1)

\# Getting the image of desired window inside generated slide thumnbnail

\# BufferedImage window = image.getSubimage(windowX, windowY, windowsWidth, windowHeight)

window_image = image.getSubimage(100, 100, 200, 200)

\# Save the image to disk in JPEG format

imageIO = self.ImageIO()

imageIO.write(image, "jpeg", self.File(self.dataDir + "ContentBG_tnail.jpg"))

print "Created thumbnail of user defined window, please check the output file."

```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
