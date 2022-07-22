---
title: Manage Paragraph
type: docs
weight: 40
url: /python-net/manage-paragraph/
keywords: "Add paragraphs, Manage paragraphs, Paragraph indent, Paragraph properties, HTML text, Export paragraph text, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Create and manage Paragraph, its text, its indent, and properties in PowerPoint presentations in Python"
---

## **Multiple Paragraphs having Multiple Portions**
An ITextFame object can have one or more Paragraphs (every paragraph is created through a carriage return), that is a collection of IParagraph objects. Furthermore, an IParagraph object can have one or more Portions (a collection of IPortion objects. An IPortion object manages text and its formatting properties. So, it means that IParagraph object has capacity to handle text with different formatting properties through its underlying IPortion objects.
Please follow the steps below to add TextFrame having 3 paragraphs and 3 portions for each paragraph using Aspose.Slides for Python via .NET :

- Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
- Obtain the reference of a slide by using its Index.
- Add an IAutoShape of Rectangle type to the slide.
- Access the ITextFrame associated with the IAutoShape.
- Create two IParagraph objects and add it to the IParagraphs collection of the ITextFrame.
- Create three IPortion objects for each new IParagraph (two Portion objects for default Paragraph) and add each IPortion object to the IPortions collection of each IParagraph.
- Set some text for each Portion.
- Apply the desired formatting features to each Portion using different formatting properties exposed by IPortion object.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate a Presentation class that represents a PPTX file
with slides.Presentation() as pres:
    # Accessing first slide
    slide = pres.slides[0]

    # Add an AutoShape of Rectangle type
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Access TextFrame of the AutoShape
    tf = ashp.text_frame

    # Create Paragraphs and Portions with different text formats
    para0 = tf.paragraphs[0]
    port01 = slides.Portion()
    port02 = slides.Portion()
    para0.portions.add(port01)
    para0.portions.add(port02)

    para1 = slides.Paragraph()
    tf.paragraphs.add(para1)
    port10 = slides.Portion()
    port11 = slides.Portion()
    port12 = slides.Portion()
    para1.portions.add(port10)
    para1.portions.add(port11)
    para1.portions.add(port12)

    para2 = slides.Paragraph()
    tf.paragraphs.add(para2)
    port20 = slides.Portion()
    port21 = slides.Portion()
    port22 = slides.Portion()
    para2.portions.add(port20)
    para2.portions.add(port21)
    para2.portions.add(port22)

    for i in range(3):
        for j in range(3):
            tf.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                tf.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                tf.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                tf.paragraphs[i].portions[j].portion_format.font_bold = 1
                tf.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                tf.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                tf.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                tf.paragraphs[i].portions[j].portion_format.font_italic = 1
                tf.paragraphs[i].portions[j].portion_format.font_height = 18

    # Write PPTX to Disk
    pres.save("multiParaPort_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Paragraph Bullets in PPTX**
This topic is also the part of the topic series of managing text paragraphs. This page will illustrate how we can manage paragraph bullets. Bullets are more useful where something is to be described in steps. Moreover, text looks well organized with the use of bullets. Bulleted paragraphs are always easier to read and understand. We will see how developers can use this small yet powerful feature of Aspose.Slides for Python via .NET. Please follow the steps below to manage the paragraph bullets using Aspose.Slides for Python via .NET:

- Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
- Access the desired slide in slide collection using ISlide object.
- Add an autoshape in a selected slide.
- Access the TextFrame of the added shape.
- Remove the default paragraph in the TextFrame.
- Create the first paragraph instance using Paragraph class.
- Set the bullet type of the paragraph.
- Set the bullet type to Symbol and set the bullet character.
- Set the Paragraph Text.
- Set the Paragraph Indent to set the bullet.
- Set the Color of Bullet.
- Set the Height of Bullets.
- Add the created paragraph in TextFrame paragraph collection.
- Add the second paragraph and repeat the process given in steps 7 to 13.
- Save the presentation.

The implementation of the above steps is given below.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Creating a presenation instance
with slides.Presentation() as pres:
    # Accessing the first slide
    slide = pres.slides[0]

    # Adding and accessing Autoshape
    aShp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accessing the text frame of created autoshape
    txtFrm = aShp.text_frame

    # Removing the default exisiting paragraph
    txtFrm.paragraphs.remove_at(0)

    # Creating a paragraph
    para = slides.Paragraph()

    # Setting paragraph bullet style and symbol
    para.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para.paragraph_format.bullet.char = chr(8226)

    # Setting paragraph text
    para.text = "Welcome to Aspose.Slides"

    # Setting bullet indent
    para.paragraph_format.indent = 25

    # Setting bullet color
    para.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    para.paragraph_format.bullet.color.color = draw.Color.black
    para.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Setting bullet Height
    para.paragraph_format.bullet.height = 100

    # Adding Paragraph to text frame
    txtFrm.paragraphs.add(para)

    # Creating second paragraph
    para2 = slides.Paragraph()

    # Setting paragraph bullet type and style
    para2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    para2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Adding paragraph text
    para2.text = "This is numbered bullet"

    # Setting bullet indent
    para2.paragraph_format.indent = 25

    para2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    para2.paragraph_format.bullet.color.color = draw.Color.black
    para2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Setting bullet Height
    para2.paragraph_format.bullet.height = 100

    # Adding Paragraph to text frame
    txtFrm.paragraphs.add(para2)


    #Writing the presentation as a PPTX file
    pres.save("bullet_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Paragraph Picture Bullets in PPTX**
This topic is also the part of the topic series of managing text in paragraphs. This page will illustrate how we can manage paragraph picture bullets. Picture bullets are more useful where something is to be described in steps. Moreover, text looks well organized with the use of bullets. Bulleted paragraphs are always easier to read and understand. We will see how developers can use this small yet powerful feature of Aspose.Slides for Python via .NET. Please follow the steps below to manage the paragraph picture bullets using Aspose.Slides for Python via .NET:

- Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
- Access the desired slide in slide collection using ISlide object.
- Add an autoshape in a selected slide.
- Access the TextFrame of the added shape.
- Remove the default paragraph in the TextFrame.
- Create the first paragraph instance using Paragraph class.
- Load Image from disc in IPPImage.
- Set the bullet type to Picture and set the image.
- Set the Paragraph Text.
- Set the Paragraph Indent to set the bullet.
- Set the Color of Bullet.
- Set the Height of Bullets.
- Add the created paragraph in TextFrame paragraph collection.
- Add the second paragraph and repeat the process given in the previous steps.
- Save the presentation.

The implementation of the above steps is given below.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Accessing the first slide
    slide = presentation.slides[0]

    # Instantiate the image for bullets
    image = draw.Bitmap(path + "bullets.png")
    ippxImage = presentation.images.add_image(image)

    # Adding and accessing Autoshape
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accessing the text frame of created autoshape
    textFrame = autoShape.text_frame

    # Removing the default exisiting paragraph
    textFrame.paragraphs.remove_at(0)

    # Creating new paragraph
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Setting paragraph bullet style and image
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = ippxImage

    # Setting Bullet Height
    paragraph.paragraph_format.bullet.height = 100

    # Adding Paragraph to text frame
    textFrame.paragraphs.add(paragraph)

    # Writing the presentation as a PPTX file
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", slides.export.SaveFormat.PPTX)
    # Writing the presentation as a PPT file
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", slides.export.SaveFormat.PPT)
```


## **Multilevel Bullets**
This topic is also the part of the topic series of managing text in paragraphs. This page will illustrate that how we can manage paragraphs with multilevel bullets. Please follow the steps below to manage the multilevel bullets using Aspose.Slides for Python via .NET:

- Create an instance of [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class.
- Access the desired slide in slide collection using ISlide object.
- Add an autoshape in selected slide.
- Access the TextFrame of the added shape.
- Remove the default paragraph in the TextFrame.
- Create the first paragraph instance using Paragraph class and with depth set to 0.
- Create the second paragraph instance using Paragraph class and with depth set to 1.
- Create the third paragraph instance using Paragraph class and with depth set to 2.
- Create the fourth paragraph instance using Paragraph class and with depth set to 3.
- Add the created paragraphs in TextFrame paragraph collection.
- Save the presentation.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Creating a presenation instance
with slides.Presentation() as pres:
    # Accessing the first slide
    slide = pres.slides[0]
    
    # Adding and accessing Autoshape
    aShp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accessing the text frame of created autoshape
    text = aShp.add_text_frame("")
    
    #clearing default paragraph
    text.paragraphs.clear()

    #Adding first paragraph
    para1 = slides.Paragraph()
    para1.text = "Content"
    para1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para1.paragraph_format.bullet.char = chr(8226)
    para1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    #Setting bullet level
    para1.paragraph_format.depth = 0

    #Adding second paragraph
    para2 = slides.Paragraph()
    para2.text = "Second Level"
    para2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para2.paragraph_format.bullet.char = '-'
    para2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    #Setting bullet level
    para2.paragraph_format.depth = 1

    #Adding third paragraph
    para3 = slides.Paragraph()
    para3.text = "Third Level"
    para3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para3.paragraph_format.bullet.char = chr(8226)
    para3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    #Setting bullet level
    para3.paragraph_format.depth = 2

    #Adding fourth paragraph
    para4 = slides.Paragraph()
    para4.text = "Fourth Level"
    para4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para4.paragraph_format.bullet.char = '-'
    para4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    #Setting bullet level
    para4.paragraph_format.depth = 3

    #Adding paragraphs to collection
    text.paragraphs.add(para1)
    text.paragraphs.add(para2)
    text.paragraphs.add(para3)
    text.paragraphs.add(para4)

    #Writing the presentation as a PPTX file
    pres.save("MultilevelBullet.pptx", slides.export.SaveFormat.PPTX)
```


## **Paragraph with Custom Numbered List**
Aspose.Slides for Python via .NET provides a simple API to manage paragraphs with custom numbers formatting. For this purpose, **NumberedBulletStartWith** property has been added to **IBulletFormat.** To add a custom number list in a paragraph, please follow the steps below:

- Create an instance of [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class.
- Access the desired slide in slide collection using ISlide object.
- Add an autoshape in selected slide.
- Access the TextFrame of the added shape.
- Remove the default paragraph in the TextFrame.
- Create the first paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 2
- Create the second paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 3
- Create the third paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 7
- Add the created paragraphs in TextFrame paragraph collection.
- Save the presentation.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accessing the text frame of created autoshape
    textFrame = shape.text_frame

    # Removing the default exisiting paragraph
    textFrame.paragraphs.remove_at(0)

    # First list
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    textFrame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    textFrame.paragraphs.add(paragraph2)


    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    textFrame.paragraphs.add(paragraph5)

    presentation.save("SetCustomBulletsNumber-slides.pptx", slides.export.SaveFormat.PPTX)
```




## **Paragraph Indent**
This page will illustrate how we can manage paragraph indent. We will see how developers can use this feature of Aspose.Slides for Python via .NET. Please follow the steps below to manage the paragraph indent using Aspose.Slides for Python via .NET:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Obtain the reference of a slide by using its Position.
1. Add a Rectangle shape in the slide.
1. Add a TextFrame with three Paragraphs in the Rectangle.
1. Hide the Lines of the Rectangle.
1. Set indent of each Paragraph using its BulletOffset property.
1. Write the modified presentation as a PPT file.

The implementation of the above steps is given below.

```py
import aspose.slides as slides

# Instantiate Presentation Class
with slides.Presentation() as pres:

    # Get first slide
    sld = pres.slides[0]

    # Add a Rectangle Shape
    rect = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 150)

    # Add TextFrame to the Rectangle
    tf = rect.add_text_frame("This is first line \rThis is second line \rThis is third line")

    # Set the text to fit the shape
    tf.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Hide the lines of the Rectangle
    rect.line_format.fill_format.fill_type = slides.FillType.SOLID

    # Get first Paragraph in the TextFrame and set its Indent
    para1 = tf.paragraphs[0]
    # Setting paragraph bullet style and symbol
    para1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para1.paragraph_format.bullet.char = chr(8226)
    para1.paragraph_format.alignment = slides.TextAlignment.LEFT

    para1.paragraph_format.depth = 2
    para1.paragraph_format.indent = 30

    # Get second Paragraph in the TextFrame and set its Indent
    para2 = tf.paragraphs[1]
    para2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para2.paragraph_format.bullet.char = chr(8226)
    para2.paragraph_format.alignment = slides.TextAlignment.LEFT
    para2.paragraph_format.depth = 2
    para2.paragraph_format.indent = 40

    # Get third Paragraph in the TextFrame and set its Indent
    para3 = tf.paragraphs[2]
    para3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para3.paragraph_format.bullet.char = chr(8226)
    para3.paragraph_format.alignment = slides.TextAlignment.LEFT
    para3.paragraph_format.depth = 2
    para3.paragraph_format.indent = 50

    #Write the Presentation to disk
    pres.save("InOutDent_out.pptx", slides.export.SaveFormat.PPTX)
```


## **End Paragraph Run Properties for Paragraph**
This page will illustrate how we can manage end paragraph run properties. We will see how developers can use this feature of Aspose.Slides for Python via .NET. Please follow the steps below to manage the End paragraph Run Properties using Aspose.Slides for Python via .NET:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Obtain the reference of a slide by using its Position.
1. Add a Rectangle shape in the slide.
1. Add a TextFrame with two Paragraphs in the Rectangle.
1. Set Font Height and Font type of paragraphs.
1. Set End properties of paragraphs.
1. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
	shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	para1 = slides.Paragraph()
	para1.portions.add(slides.Portion("Sample text"))

	para2 = slides.Paragraph()
	para2.portions.add(slides.Portion("Sample text 2"))
	endParagraphPortionFormat = slides.PortionFormat()
	endParagraphPortionFormat.font_height = 48
	endParagraphPortionFormat.latin_font = slides.FontData("Times New Roman")
	para2.end_paragraph_portion_format = endParagraphPortionFormat

	shape.text_frame.paragraphs.add(para1)
	shape.text_frame.paragraphs.add(para2)

	pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```




## **Import HTML Text in Paragraphs**
This topic is also part of a series of topics about managing text paragraphs. Aspose.Slides for Python via .NET has enhanced support for adding HTML text or saving paragraphs text to HTML. This article shows how to manage paragraphs to use HTML data and shows how developers can use this small yet powerful feature. To manage paragraph bullets using Aspose.Slides for Python via .NET:

- Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
- Access the desired slide in slide collection using the ISlide object.
- Add an autoshape to the selected slide.
- Add and access the ITextFrame of the added shape.
- Remove the default paragraph in the ITextFrame.
- Read the source HTML file in a TextReader.
- Create the first paragraph instance using the Paragraph class.
- Add the HTML file content in the read TextReader to the TextFrame's ParagraphCollection.
- Save the presentation.

```py
import aspose.slides as slides

# Create Empty presentation instance# Create Empty presentation instance
with slides.Presentation() as pres:
    # Acesss the default first slide of presentation
    slide = pres.slides[0]

    # Adding the AutoShape to accomodate the HTML content
    ashape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, pres.slide_size.size.width - 20, pres.slide_size.size.height - 10)

    ashape.fill_format.fill_type = slides.FillType.NO_FILL

    # Adding text frame to the shape
    ashape.add_text_frame("")

    # Clearing all paragraphs in added text frame
    ashape.text_frame.paragraphs.clear()

    # Loading the HTML file using stream reader
    with open(path + "file.html", "rt") as tr:
        # Adding text from HTML stream reader in text frame
        ashape.text_frame.paragraphs.add_from_html(tr.read())

    # Saving Presentation
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Export Paragraphs Text to HTML**
Please follow the steps below to see how to export the paragraph text to HTML using Aspose.Slides for Python via .NET:

- Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the desired presentation.
- Access the desired slide into the slide collection using ISlide object.
- Access the desired shape for which text need to be exported to HTML.
- Access the TextFrame of the accessed shape.
- Create an instance of StreamWriter and add the new HTML file.
- Export the desired number of paragraphs data by providing starting index to the StreamWriter.
  The implementation of the above steps is given below.

```py
import aspose.slides as slides

# Load the presentation file
with slides.Presentation(path + "ExportingHTMLText.pptx") as pres:
    # Acesss the default first slide of presentation
    slide = pres.slides[0]

    # Desired index
    index = 0

    # Accessing the added shape
    ashape = slide.shapes[index]

    with open("output_out.html", "w") as sw:
        # Writing Paragraphs data to HTML by providing paragraph starting index, total paragraphs to be copied
        sw.write(ashape.text_frame.paragraphs.export_to_html(0, ashape.text_frame.paragraphs.count, None))
```

