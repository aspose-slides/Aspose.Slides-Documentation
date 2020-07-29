---
title: Converting Presentation to PDF in Python
type: docs
weight: 30
url: /java/converting-presentation-to-pdf-in-python/
---

## **Aspose.Slides - Converting Presentation to PDF**
To Convert Presentation to HTML using Aspose.Slides Java for Python. Here you can see example code.

**Python Code**

{{< highlight java >}}



\# Instantiate a Presentation object that represents a PPTX file

pres = self.Presentation(self.dataDir + "Aspose.pptx")

\# Saving the PPTX presentation to Pdf format

save_format = self.SaveFormat

pres.save(self.dataDir + "Aspose.pdf", save_format.Pdf)

print "Document has been converted, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download **Converting Presentation to PDF (Aspose.Slides)** from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
