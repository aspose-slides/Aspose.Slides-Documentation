---
title: Setting Default Zoom Value for Presentation in Python
type: docs
weight: 80
url: /java/setting-default-zoom-value-for-presentation-in-python/
---

## **Aspose.Slides - Setting Default Zoom Value for Presentation**
To Convert Presentation to HTML using Aspose.Slides Java for Python. Here you can see example code.

**Python Code**

{{< highlight java >}}

 pres = self.Presentation()

pres.getViewProperties().getNotesViewProperties().setScale(50)

\# Save the presentation as a PPTX file

save_format = self.SaveFormat

pres.save(self.dataDir + "Zoom.pptx", save_format.Pptx)

print "Set zoom value, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download **Setting Default Zoom Value for Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
