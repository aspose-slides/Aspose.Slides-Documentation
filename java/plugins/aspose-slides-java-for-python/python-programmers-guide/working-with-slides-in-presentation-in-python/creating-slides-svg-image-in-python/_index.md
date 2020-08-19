---
title: Creating Slides SVG Image in Python
type: docs
weight: 50
url: /java/creating-slides-svg-image-in-python/
---

## **Aspose.Slides - Creating Slides SVG Image**
To Create Slides Thumbnail Image using Aspose.Slides Java for Python. Here you can see example code.

**Python Code**

```

 # Instantiate Presentation class that represents the presentation file

pres = self.Presentation

pres = pres(self.dataDir + 'Aspose.pptx')

\# Getting last slide index

last_slide_position = pres.getSlides().size()

#Iterating through every presentation slide and generating SVG image

i = 0

while (i < last_slide_position):

    # Accessing Slides

    slide = pres.getSlides().get_Item(i)

    # Getting and saving the slide SVG image

    slide.writeAsSvg(self.FileOutputStream(self.dataDir + "SvgImage#i.svg"))

    i+=1

print "Created SVG images, please check output files."

```
## **Download Running Code**
Download **Creating Slides SVG Image (Aspose.Slides)** from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
