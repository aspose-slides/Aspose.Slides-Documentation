---
title: Setting Fill Format for SmartArt Node in Python
type: docs
weight: 20
url: /java/setting-fill-format-for-smartart-node-in-python/
---

## **Aspose.Slides - Setting Fill Format for SmartArt Node**
To Set Fill Format for SmartArt Node using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

```

 # Create an instance of Presentation class

pres = self.Presentation()

\# Get the first slide

slide = pres.getSlides().get_Item(0)

\# Adding SmartArt shape and nodes

smartArtLayoutType = self.SmartArtLayoutType

chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, smartArtLayoutType.ClosedChevronProcess)

node = chevron.getAllNodes().addNode()

node.getTextFrame().setText("Some text")

\# Setting node fill color

color = self.Color

fillType = self.FillType

item = node.getShapes().get_Item(0)

item.getFillFormat().setFillType(fillType.Solid)

item.getFillFormat().getSolidFillColor().setColor(color.RED)

\# Write the presentation as a PPTX file

saveFormat = self.SaveFormat

pres.save(dataDir + "FillFormat.pptx", saveFormat.Pptx)

print "Set fill format for smartart node, please check the output file."

```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
