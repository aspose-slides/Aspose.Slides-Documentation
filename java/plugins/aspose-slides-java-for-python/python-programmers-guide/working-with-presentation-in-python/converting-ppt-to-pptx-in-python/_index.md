---
title: Converting PPT to PPTX in Python
type: docs
weight: 10
url: /java/converting-ppt-to-pptx-in-python/
---

## **Aspose.Slides - Converting PPT to PPTX**
To Convert PPT to PPTX document using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

```

 # Instantiate a Presentation object that represents a PPTX file

pres= self.Presentation

pres = pres(self.dataDir + "Presentation1.pptx")

\# Saving the PPTX presentation to PPTX format

save_format = self.SaveFormat

pres.save(self.dataDir + "Aspose.pptx", save_format.Pptx)

print "Document has been converted, please check the output file."

```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
