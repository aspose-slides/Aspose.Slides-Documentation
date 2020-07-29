---
title: Managing Slides Transitions in Python
type: docs
weight: 70
url: /java/managing-slides-transitions-in-python/
---

## **Aspose.Slides - Managing Slides Transitions**
To Manage Slides Transitions using Aspose.Slides Java for Python. Here you can see example code.

**Python Code**

{{< highlight python >}}

 # Instantiate Presentation class that represents the presentation file

pres = self.Presentation(self.dataDir + 'Aspose.pptx')

transition_type = self.TransitionType

\# Apply circle type transition on slide 1

pres.getSlides().get_Item(0).getSlideShowTransition().setType(transition_type.Circle)

\# Apply comb type transition on slide 2

pres.getSlides().get_Item(0).getSlideShowTransition().setType(transition_type.Comb)

\# Saving the presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "SimpleTransition.pptx", save_format.Pptx)

print "Done with simple transition, please check the output file." 

{{< /highlight >}}
## **Download Running Code**
Download **Managing Slides Transitions (Aspose.Slides)** from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
