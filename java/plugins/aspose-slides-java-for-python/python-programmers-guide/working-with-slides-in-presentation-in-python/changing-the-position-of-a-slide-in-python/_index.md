---
title: Changing the Position of a Slide in Python
type: docs
weight: 30
url: /java/changing-the-position-of-a-slide-in-python/
---

## **Aspose.Slides - Changing the Position of a Slide**
To Change the Position of a Slide using Aspose.Slides Java for Python. Here you can see example code.

**Python Code**

{{< highlight python >}}



\# Instantiate Presentation class that represents the presentation file

pres = self.Presentation(self.dataDir + 'Aspose.pptx')

\# Get the slide whose position is to be changed

slide = pres.getSlides().get_Item(0)

\# Set the self.position for the slide

slide.setSlideNumber(1)

\# Saving the presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "Aspose_Position.pptx", save_format.Pptx)

print "Changes slide position, please check the output file."

```
## **Download Running Code**
Download **Changing the Position of a Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
