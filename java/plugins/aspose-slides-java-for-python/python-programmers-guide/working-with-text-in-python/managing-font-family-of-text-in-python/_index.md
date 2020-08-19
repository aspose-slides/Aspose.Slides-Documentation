---
title: Managing Font Family of Text in Python
type: docs
weight: 40
url: /java/managing-font-family-of-text-in-python/
---

## **Aspose.Slides - Managing Font Family of Text**
To Manage Font Family of Text using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

```

 def font_properties(self):

\# Create an instance of Presentation class

pres = self.Presentation(self.dataDir + 'Welcome.pptx')

\# Get the first slide

slide = pres.getSlides().get_Item(0)

\# Accessing the first and second placeholder in the slide and typecasting it as AutoShape

tf1 = slide.getShapes().get_Item(0).getTextFrame()

tf2 = slide.getShapes().get_Item(1).getTextFrame()

\# Accessing the first Paragraph

para1 = tf1.getParagraphs().get_Item(0)

para2 = tf2.getParagraphs().get_Item(0)

\# Accessing the first portion

port1 = para1.getPortions().get_Item(0)

port2 = para2.getPortions().get_Item(0)

\# Define fonts

fd1 = self.FontData("Elephant")

fd2 = self.FontData("Castellar")

\# Assign fonts to portion

port1.getPortionFormat().setLatinFont(fd1)

port2.getPortionFormat().setLatinFont(fd2)

\# Set font to Bold

nullableBool = self.NullableBool

port1.getPortionFormat().setFontBold(nullableBool.True)

port2.getPortionFormat().setFontBold(nullableBool.True)

\# Set font to Italic

port1.getPortionFormat().setFontItalic(nullableBool.True)

port2.getPortionFormat().setFontItalic(nullableBool.True)

\# Set font color

fillType = self.FillType

color = self.Color

port1.getPortionFormat().getFillFormat().setFillType(fillType.Solid)

port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(color.BLUE)

port2.getPortionFormat().getFillFormat().setFillType(fillType.Solid)

port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(color.GREEN)

\# Write the presentation as a PPTX file

save_format = self.SaveFormat

pres.save(self.dataDir + "WelcomeFont.pptx", save_format.Pptx)

print "Done with font properties, please check the output file."



def font_family_of_text(self):

\# Create an instance of Presentation class

pres = self.Presentation()

\# Get the first slide

sld = pres.getSlides().get_Item(0)

\# Add an AutoShape of Rectangle type

shapeType = self.ShapeType

ashp = sld.getShapes().addAutoShape(shapeType.Rectangle, 50, 50, 200, 50)

\# Remove any fill style associated with the AutoShape

fillType=FillType

ashp.getFillFormat().setFillType(fillType.NoFill)

\# Access the TextFrame associated with the AutoShape

tf = ashp.getTextFrame()

tf.setText("Aspose TextBox")

\# Access the Portion associated with the TextFrame

port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0)

\# Set the Font for the Portion

port.getPortionFormat().setLatinFont(FontData("Times New Roman"))

\# Set Bold property of the Font

nullableBool=NullableBool

port.getPortionFormat().setFontBold(nullableBool.True)

\# Set Italic property of the Font

port.getPortionFormat().setFontItalic(nullableBool.True)

\# Set Underline property of the Font

textUnderlineType=TextUnderlineType

port.getPortionFormat().setFontUnderline(textUnderlineType.Single)

\# Set the Height of the Font

port.getPortionFormat().setFontHeight(25)

\# Set the color of the Font

color = self.Color

port.getPortionFormat().getFillFormat().setFillType(fillType.Solid)

port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(color.BLUE)

\# Write the presentation as a PPTX file

save_format = self.SaveFormat

pres.save(self.dataDir + "FontFamilyOfText.pptx", save_format.Pptx)

print "Done with font family for text, please check the output file."





def set_default_font_for_rendering(dataDir):

\# Use load options to define the default regualr and asian fonts

loadFormat = LoadFormat

lo = LoadOptions(loadFormat.Auto)

lo.setDefaultRegularFont("Wingdings")

lo.setDefaultAsianFont("Wingdings")

\# Create an instance of Presentation class

pres = Presentation(self.dataDir + 'input.pptx')

\# Generate PDF

save_format = self.SaveFormat

pres.save(self.dataDir + "output.pdf", save_format.Pdf)

print "Done with font family for text, please check the output file."

```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
