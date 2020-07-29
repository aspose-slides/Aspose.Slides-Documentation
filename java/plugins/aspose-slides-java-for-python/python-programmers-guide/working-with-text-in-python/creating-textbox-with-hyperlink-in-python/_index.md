---
title: Creating TextBox with Hyperlink in Python
type: docs
weight: 30
url: /java/creating-textbox-with-hyperlink-in-python/
---

## **Aspose.Slides - Creating TextBox with Hyperlink**
Creating TextBox with Hyperlink using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 pres = self.Presentation()

\# Get the first slide

sld = pres.getSlides().get_Item(0)

\# Add autoshape of rectangle type

shapeType = self.ShapeType

pptxShape = sld.getShapes().addAutoShape(shapeType.Rectangle, 150, 150, 150, 50)

\# Cast the shape to AutoShape

pptxAutoShape = pptxShape

\# Access ITextFrame associated with the AutoShape

pptxAutoShape.addTextFrame("")

text_frame = pptxAutoShape.getTextFrame()

\# Add some text to the frame

text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides")

#Set Hyperlink for the portion text

hypman = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager()

hypman.setExternalHyperlinkClick("http://www.aspose.com")

\# Write the presentation as a PPTX file

save_format = self.SaveFormat

pres.save(self.dataDir + "hLinkPPTX.pptx", save_format.Pptx)

print "Created TextBox with Hyperlink, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
