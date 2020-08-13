---
title: Converting Presentation to TIFF in Python
type: docs
weight: 40
url: /java/converting-presentation-to-tiff-in-python/
---

## **Aspose.Slides - Converting Presentation to TIFF**
To Convert Presentation to TIFF using Aspose.Slides Java for Python. Here you can see example code.

**Python Code**

{{< highlight python >}}

 def convert_with_default_size(self):

pres = self.Presentation

pres = pres(self.dataDir + "Aspose.pptx")

\# Saving the PPTX presentation to Tiff format

save_format = self.SaveFormat

pres.save(self.dataDir + "Aspose.tiff", save_format.Tiff)

print "Document has been converted, please check the output file."

def convert_with_custom_size(self):

\# Instantiate a Presentation object that represents a PPTX file

pres= self.Presentation

pres = pres(self.dataDir + "Aspose.pptx")

\# Instantiate the TiffOptions class

opts = self.TiffOptions()

\# Setting compression type

tiff_compression_types = self.TiffCompressionTypes

opts.setCompressionType (tiff_compression_types.Default)

#Setting image DPI

opts.setDpiX(200)

opts.setDpiY(100)

\# Set Image Size

opts.setImageSize(self.Dimension(1728, 1078))

\# Save the presentation to TIFF with specified image size

save_format = self.SaveFormat

pres.save(self.dataDir + "Aspose-Custom-Size.tiff", save_format.Tiff,opts)

print "Document has been converted, please check the output file."

```
## **Download Running Code**
Download **Converting Presentation to TIFF (Aspose.Slides)** from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
