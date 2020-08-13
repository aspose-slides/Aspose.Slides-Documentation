---
title: Managing the Hyperlinks in Presentation in Python
type: docs
weight: 80
url: /java/managing-the-hyperlinks-in-presentation-in-python/
---

## **Aspose.Slides - Managing the Hyperlinks in Presentation**
To Manage the Hyperlinks in Presentation using Aspose.Slides Java for Python. Here you can see example code.

**Python Code**

{{< highlight python >}}

 # Instantiate Presentation class that represents the presentation file

pres = self.Presentation

pres = pres(self.dataDir + 'Aspose.pptx')

\# Removing the hyperlinks from presentation

pres.getHyperlinkQueries().removeAllHyperlinks()

\# Saving the presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "Hyperlinks.pptx", save_format.Pptx)

print "Removed hyperlinks successfully, please check the output file."

```
## **Download Running Code**
Download **Managing the Hyperlinks in Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
