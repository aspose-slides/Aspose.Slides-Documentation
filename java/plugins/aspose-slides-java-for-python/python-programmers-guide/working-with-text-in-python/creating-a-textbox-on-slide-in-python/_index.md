---
title: Creating a TextBox on Slide in Python
type: docs
weight: 20
url: /java/creating-a-textbox-on-slide-in-python/
---

## **Aspose.Slides - Creating a TextBox on Slide**
To create a TextBox on Slide using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 def create_textbox(self):

\# Create an instance of Presentation class

pres = self.Presentation

\# Get the first slide

sld = pres.getSlides().get_Item(0)

\# Add autoshape of rectangle type

shapeType = self.ShapeType

shp = sld.getShapes().addAutoShape(shapeType.Rectangle, 150, 75, 150, 50)

\# Add TextFrame to the Rectangle

shp.addTextFrame(" ")

\# Accessing the text frame

txt_frame = shp.getTextFrame()

\# Create the Paragraph object for text frame

para = txt_frame.getParagraphs().get_Item(0)

\# Create Portion object for paragraph

portion = para.getPortions().get_Item(0)

\# Set Text

portion.setText("Aspose TextBox")

\# Write the presentation as a PPTX file

save_format = self.SaveFormat

pres.save(self.dataDir + "TextBox.pptx", save_format.Pptx)

print "Created TextBox, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
