---
title: Finding a Shape in a Slide in Python
type: docs
weight: 80
url: /java/finding-a-shape-in-a-slide-in-python/
---

## **Aspose.Slides - Finding a Shape in a Slide**
To Convert Presentation to HTML using Aspose.Slides Java for Python. Here you can see example code.

**Python Code**

``` java

 def main(self):

\# Create an instance of Presentation class

pres=self.Presentation

pres = pres(self.dataDir + 'Aspose.pptx')

\# Get the first slide

slide = pres.getSlides().get_Item(0)

shape = self.find_shape(slide)

print "Shape: " 

print shape

def find_shape(self,alttext):

#Iterating through all shapes inside the slide

i = 0

pres=self.Presentation()

slide = pres.getSlides().get_Item(0)

while (i < slide.getShapes().size()):

   # If the alternative text of the slide matches with the required one then return the shape

   if (slide.getShapes().get_Item(i).getAlternativeText() == alttext):

       return slide.getShapes().get_Item(i)

   i+=1

return None

```
## **Download Running Code**
Download **Finding a Shape in a Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
