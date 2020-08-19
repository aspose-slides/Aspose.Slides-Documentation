---
title: Working With Slide Size and Layout in Python
type: docs
weight: 120
url: /java/working-with-slide-size-and-layout-in-python/
---

## **Aspose.Slides - Working With Slide Size and Layout**
To Work With Slide Size and Layout using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

```

 def set_size_and_type(self):

\# Instantiate Presentation class that represents the presentation file

pres = self.Presentation(self.dataDir + 'Aspose.pptx')

aux_pres = self.Presentation()

slide = pres.getSlides().get_Item(0)

\# Set the slide size of generated presentations to that of source

aux_pres.getSlideSize().setType(pres.getSlideSize().getType())

aux_pres.getSlideSize().setSize(pres.getSlideSize().getSize())

\# Clone required slide

aux_pres.getSlides().addClone(pres.getSlides().get_Item(0))

aux_pres.getSlides().removeAt(0)

\# Saving the presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "Slide_Size_Type.pptx", save_format.Pptx)

print "Set slide size and type, please check the output file."

def set_page_size_for_slides(self):

\# Instantiate Presentation class that represents the presentation file

pres = self.Presentation()

\# Set SlideSize.Type Property

slideSizeType = self.SlideSizeType

pres.getSlideSize().setType(slideSizeType.A4Paper)

\# Set different properties of slides Options

opts = self.slidesOptions

opts.setSufficientResolution(600)

\# Saving the presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "Export.slides", save_format.slides, opts)

print "Set page size for slides, please check the output file."

```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
