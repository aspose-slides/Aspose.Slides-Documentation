---
title: Cloning Slides in Presentation in Python
type: docs
weight: 40
url: /java/cloning-slides-in-presentation-in-python/
---

## **Aspose.Slides - Cloning Slides in Presentation**
To Clone Slides in Presentation using Aspose.Slides Java for Python. Here you can see example code.

**Python Code**

{{< highlight python >}}

 def clone_to_end_of_presentation(self):

\# Instantiate Presentation class that represents the presentation file

pres = self.Presentation(self.dataDir + 'Aspose.pptx')

\# Clone the desired slide to the end of the collection of slides in the same presentation

slides = pres.getSlides()

slides.addClone(pres.getSlides().get_Item(0))

\# Saving the presentation file

save_format = self.SaveFormat

pres.save(self.dataDir + "Aspose_Cloned.pptx", save_format.Pptx)

print "Slide has been cloned, please check the output file." 

def clone_to_aonther_position(self):

\# Instantiate Presentation class that represents the presentation file

pres = self.Presentation(self.dataDir + 'Aspose.pptx')

\# Clone the desired slide to the end of the collection of slides in the same presentation

slides = pres.getSlides()

\# Clone the desired slide to the specified index in the same presentation

slides.insertClone(1, pres.getSlides().get_Item(0))

\# Saving the presentation file

save_format = self.SaveFormat

pres.save(self.dataDir + "Aspose_Cloned.pptx", save_format.Pptx)

print "Slide has been cloned, please check the output file." 

def clone_to_other_presentation_at_end_of_existing_slide(self):

\# Instantiate Presentation class that represents the presentation file

src_pres = self.Presentation(self.dataDir + 'Aspose.pptx')

\# Instantiate Presentation class for destination PPTX (where slide is to be cloned)

dest_pres = self.Presentation()

\# Clone the desired slide from the source presentation to the end of the collection of slides in destination presentation

slds = dest_pres.getSlides()

slds.addClone(src_pres.getSlides().get_Item(0))

\# Saving the presentation file

save_format = self.SaveFormat

dest_pres.save(self.dataDir + "Aspose_dest2.pptx", save_format.Pptx)

print "Slide has been cloned, please check the output file."


{{< /highlight >}}
## **Download Running Code**
Download **Cloning Slides in Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
