---
title: Converting Presentation with Notes in Python
type: docs
weight: 60
url: /java/converting-presentation-with-notes-in-python/
---

## **Aspose.Slides - Converting Presentation with Notes**
To Convert Presentation with Notes using Aspose.Slides Java for Python. Here you can see example code.

**Python Code**

{{< highlight java >}}

 # Instantiate a Presentation object that represents a PPTX file

def convert_to_tiff_notes(self):

\# Instantiate a Presentation object that represents a PPTX file

pres=self.Presentation

pres = pres(self.dataDir + "Aspose.pptx")

\# Saving the presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "Notes.tiff", save_format.TiffNotes)

print "Document has been converted, please check the output file."


def convert_to_pdf_notes(self):

\# Instantiate a Presentation object that represents a PPTX file

pres = self.Presentation

pres = pres(self.dataDir + "Aspose.pptx")

\# Saving the presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "Notes.pdf", save_format.pdf)

print "Document has been converted, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download **Converting Presentation with Notes (Aspose.Slides)** from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
