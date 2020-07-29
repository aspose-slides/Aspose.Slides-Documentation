---
title: Replacing Text in a Placeholder in Python
type: docs
weight: 70
url: /java/replacing-text-in-a-placeholder-in-python/
---

## **Aspose.Slides - Replacing Text in a Placeholder**
To Convert Presentation to HTML using Aspose.Slides Java for Python. Here you can see example code.

**Python Code**

{{< highlight java >}}

 # Create an instance of Presentation class

pres = self.Presentation(self.dataDir + 'Welcome.pptx')

\# Get the first slide

sld = pres.getSlides().get_Item(0)

\# Change the text of each placeholder

shp = sld.getShapes().get_Item(0)

shp.getTextFrame().setText("This is Placeholder")

\# Write the presentation as a PPTX file

save_format = self.SaveFormat

pres.save(self.dataDir + "Welcome_PH.pptx", save_format.Pptx)

print "Replaced text, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download **Replacing Text in a Placeholder (Aspose.Slides)** from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
