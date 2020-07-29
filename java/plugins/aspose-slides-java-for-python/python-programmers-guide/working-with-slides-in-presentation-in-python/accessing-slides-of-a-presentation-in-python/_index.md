---
title: Accessing Slides of a Presentation in Python
type: docs
weight: 10
url: /java/accessing-slides-of-a-presentation-in-python/
---

## **Aspose.Slides - Accessing Slides of a Presentation**
To Convert Presentation to HTML using Aspose.Slides Java for Python. Here you can see example code.

**Python Code**

{{< highlight python >}}

 def get_slide_by_index(self):

\# Instantiate Presentation class that represents the presentation file

pres = self.Presentation(self.dataDir + 'Aspose.pptx')

\# Accessing a slide using its slide index

slide = pres.getSlides().get_Item(0)

print "Slide: "

print slide

def get_slide_by_id(self):

\# Instantiate Presentation class that represents the presentation file

pres = self.Presentation

pres = pres(self.dataDir + 'Aspose.pptx')

\# Getting Slide ID

id = pres.getSlides().get_Item(0).getSlideId()

\# Accessing Slide by ID

slide = pres.getSlideById(id)

print "Slide: "

print slide

{{< /highlight >}}
## **Download Running Code**
Download **Accessing Slides of a Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
