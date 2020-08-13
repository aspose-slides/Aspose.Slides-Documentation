---
title: Removing Slides from a Presentation in Python
type: docs
weight: 90
url: /java/removing-slides-from-a-presentation-in-python/
---

## **Aspose.Slides - Removing Slides from a Presentation**
To Remove Slides from a Presentation using Aspose.Slides Java for Python. Here you can see example code.

**Python Code**

{{< highlight python >}}

 def remove_slide_by_index(self):

\# Instantiate Presentation class that represents the presentation file

pres = self.Presentation(self.dataDir + 'Aspose.pptx')

\# Accessing a slide using its slide index

slide = pres.getSlides().get_Item(0)

\# Removing a slide using its reference

pres.getSlides().remove(slide)

\# Saving the presentation file

save_format = self.SaveFormat

pres.save(self.dataDir + "Modified.pptx", save_format.Pptx)

print "Removed slide by Index, please check the output file."

def remove_slide_by_id(self):

\# Instantiate Presentation class that represents the presentation file

pres = self.Presentation(self.dataDir + 'Aspose.pptx')

\# Removing a slide using its slide index

pres.getSlides().removeAt(0)

\# Saving the presentation file

save_format = self.SaveFormat

pres.save(self.dataDir + "Modified.pptx", save_format.Pptx)

print "Removed slide by ID, please check the output file."

```
## **Download Running Code**
Download **Removing Slides from a Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
