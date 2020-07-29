---
title: Converting Presentation to XPS in Python
type: docs
weight: 50
url: /java/converting-presentation-to-xps-in-python/
---

## **Aspose.Slides - Converting Presentation to XPS**
To Convert Presentation to XPS using Aspose.Slides Java for Python. Here you can see example code.

**Python Code**

{{< highlight java >}}

 def convert_with_default_size(self):

\# Instantiate a Presentation object that represents a PPTX file

pres=self.Presentation

pres = pres(self.dataDir + "Aspose.pptx")

\# Saving the presentation to XPS format

save_format = self.SaveFormat

pres.save(self.dataDir + "Aspose.xps", save_format.Xps)

print "Document has been converted, please check the output file."

def convert_with_custom_size(self):

\# Instantiate a Presentation object that represents a PPTX file

pres = self.Presentation(self.dataDir + "Aspose.pptx")

\# Instantiate the TiffOptions class

opts = self.XpsOptions()

\# Save MetaFiles as PNG

opts.SaveMetafilesAsPng = True

\# Save the presentation to TIFF with specified image size

save_format = self.SaveFormat

pres.save(self.dataDir + "Aspose-Custom-Size.xps", save_format.Xps, opts)

print "Document has been converted, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download **Converting Presentation to XPS (Aspose.Slides)** from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
