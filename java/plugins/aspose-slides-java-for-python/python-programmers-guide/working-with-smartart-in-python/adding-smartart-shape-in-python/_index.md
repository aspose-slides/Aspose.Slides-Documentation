---
title: Adding SmartArt shape in Python
type: docs
weight: 10
url: /java/adding-smartart-shape-in-python/
---

## **Aspose.Slides - Adding SmartArt shape**
To Add SmartArt shape document using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 # Create an instance of Presentation class

pres = self.Presentation()

\# Get the first slide

slide = pres.getSlides().get_Item(0)

\# Add Smart Art Shape

smartArtLayoutType = self.SmartArtLayoutType

smart = slide.getShapes().addSmartArt(0, 0, 400, 400, smartArtLayoutType.BasicBlockList)

\# Write the presentation as a PPTX file

saveFormat = self.SaveFormat

pres.save(self.dataDir + "SimpleSmartArt.pptx", saveFormat.Pptx)

print "Created smartart shape, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
