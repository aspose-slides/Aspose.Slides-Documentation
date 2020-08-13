---
title: Adding Slides to Presentation in Python
type: docs
weight: 20
url: /java/adding-slides-to-presentation-in-python/
---

## **Aspose.Slides - Adding Slides to Presentation**
To Convert Presentation to HTML using Aspose.Slides Java for Python. Here you can see example code.

**Python Code**

``` java

 def main(self):

\# Instantiate Presentation class that represents the presentation file

pres = self.Presentation()

\# Instantiate SlideCollection calss

slides = pres.getSlides()

i = 0

while (i < pres.getLayoutSlides().size()):

   # Add an empty slide to the Slides collection

   slides.addEmptySlide(pres.getLayoutSlides().get_Item(i))

   i+=1

#Do some work on the newly added slide

\# Saving the presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "EmptySlide.pptx", save_format.Pptx)

```
## **Download Running Code**
Download **Adding Slides to Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
