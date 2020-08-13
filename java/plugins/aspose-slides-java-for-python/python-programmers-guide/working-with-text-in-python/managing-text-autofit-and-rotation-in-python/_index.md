---
title: Managing Text Autofit and Rotation in Python
type: docs
weight: 50
url: /java/managing-text-autofit-and-rotation-in-python/
---

## **Aspose.Slides - Managing Text Autofit and Rotation**
To Manage Text Autofit and Rotation using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 def set_autofittype_of_text(self):



\# Create an instance of Presentation class

pres = self.Presentation

\# Get the first slide

slide = pres.getSlides().get_Item(0)

\# Add an AutoShape of Rectangle type

shapeType=ShapeType

ashp = slide.getShapes().addAutoShape(shapeType.Rectangle, 150, 75, 350, 350)

\# Add TextFrame to the Rectangle

fillType = self.FillType

ashp.addTextFrame(" ")

ashp.getFillFormat().setFillType(fillType.NoFill)

\# Accessing the text frame

txt_frame = ashp.getTextFrame()

\# Setting text autofit type

textAutofitType=TextAutofitType

txt_frame.getTextFrameFormat().setAutofitType(textAutofitType.Shape)

\# Create the Paragraph object for text frame

para = txt_frame.getParagraphs().get_Item(0)

\# Create Portion object for paragraph

color = self.Color

portion = para.getPortions().get_Item(0)

portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.")

portion.getPortionFormat().getFillFormat().setFillType(fillType.Solid)

portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(color.BLACK)

\# Write the presentation as a PPTX file

save_format = self.SaveFormat

pres.save(self.dataDir + "formatText.pptx", save_format.Pptx)

print "Set autofittype of text, please check the output file."



def set_anchor_of_text(self):

\# Create an instance of Presentation class

pres = self.Presentation

\# Get the first slide

slide = pres.getSlides().get_Item(0)

\# Add an AutoShape of Rectangle type

shapeType=ShapeType

ashp = slide.getShapes().addAutoShape(shapeType.Rectangle, 150, 75, 350, 350)

\# Add TextFrame to the Rectangle

fillType = self.FillType

ashp.addTextFrame(" ")

ashp.getFillFormat().setFillType(fillType.NoFill)

\# Accessing the text frame

txt_frame = ashp.getTextFrame()

\# Setting text anchoring to bottom

textAnchorType=TextAnchorType

txt_frame.getTextFrameFormat().setAnchoringType(textAnchorType.Bottom)

\# Create the Paragraph object for text frame

para = txt_frame.getParagraphs().get_Item(0)

\# Create Portion object for paragraph

color = self.Color

portion = para.getPortions().get_Item(0)

portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.")

portion.getPortionFormat().getFillFormat().setFillType(fillType.Solid)

portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(color.BLACK)

\# Write the presentation as a PPTX file

save_format = self.SaveFormat

pres.save(self.dataDir + "AnchorText.pptx", save_format.Pptx)

print "Set anchor of text, please check the output file."



def rotate_text(self):

\# Create an instance of Presentation class

pres = Presentation()

\# Get the first slide

slide = pres.getSlides().get_Item(0)

\# Add an AutoShape of Rectangle type

shapeType=ShapeType

ashp = slide.getShapes().addAutoShape(shapeType.Rectangle, 150, 75, 350, 350)

\# Add TextFrame to the Rectangle

fillType=FillType

ashp.addTextFrame(" ")

ashp.getFillFormat().setFillType(fillType.NoFill)

\# Accessing the text frame

txt_frame = ashp.getTextFrame()

\# Setting text Vertical type

textVerticalType=TextVerticalType

txt_frame.getTextFrameFormat().setTextVerticalType(textVerticalType.Vertical270)

\# Create the Paragraph object for text frame

para = txt_frame.getParagraphs().get_Item(0)

\# Create Portion object for paragraph

portion = para.getPortions().get_Item(0)

color=Color

portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.")

portion.getPortionFormat().getFillFormat().setFillType(fillType.Solid)

portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(color.BLACK)

\# Write the presentation as a PPTX file

save_format = self.SaveFormat

pres.save(self.dataDir + "VerticleText.pptx", save_format.Pptx)

print "Done with text rotation, please check the output file."


```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
