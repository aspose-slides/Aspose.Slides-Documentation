---
title: Converting Presentation to HTML in Python
type: docs
weight: 20
url: /java/converting-presentation-to-html-in-python/
---

## **Aspose.Slides - Converting To HTML**
To Convert Presentation to HTML using Aspose.Slides Java for Python. Here you can see example code.

**Python Code**

``` java

 # Instantiate a Presentation object that represents a PPTX file

pres=self.Presentation

pres = pres(self.dataDir + "Aspose.pptx")

html_opt = self.HtmlOptions()

html_formatter = self.HtmlFormatter

html_opt.setHtmlFormatter(html_formatter.createDocumentFormatter("",False))

\# Saving the presentation to HTML format

save_format = self.SaveFormat

pres.save(self.dataDir + "Aspose.html", save_format.Html, html_opt)

print "Document has been converted, please check the output file."

```
## **Download Running Code**
Download **Converting To Html (Aspose.Slides)** from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
