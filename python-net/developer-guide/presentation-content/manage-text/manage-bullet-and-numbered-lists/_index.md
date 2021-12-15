---
title: Manage Bullet and Numbered Lists
type: docs
weight: 70
url: /python-net/manage-bullet-and-numbered-lists/
keywords: "Bullets, Bullet lists, Numbers, Numbered lists, Picture bullets, multilevel bullets, PowerPoint Presentation, Python, Aspose.Slides for Python via .NET"
description: "Create bullet and numbered lists in PowerPoint presentation in Python"
---

In **Microsoft PowerPoint**, you can create bullet and numbered lists the same way you do in Word and other text editors. **Aspose.Slides for Python via .NET** also allows you to use bullets and numbers in slides in your presentations. 

### Why Use Bullet Lists?

Bullet lists help you to organize and present information quickly and efficiently. 

**Bullet List Example**

In most cases, a bullet list serves these three main functions:

- draws your readers or viewers attention to important information
- allows your readers or viewers to scan for key points easily
- communicates and delivers important details efficiently.

### Why Use Numbered Lists?

Numbered lists also help in organizing and presenting information. Ideally, you should use numbers (in place of bullets) when the order of the entries (for example, *step 1, step 2*, etc.) is important or when an entry has to be referenced (for example, *see step 3*).

**Numbered List Example**

This is a summary of the steps (step 1 to step 15) in the **Creating Bullets** procedure below:

1. Create an instance of the presentation class. 
2. Perform several tasks (step 3 to step 14).
3. Save the presentation. 

## Creating Bullets 

To create a bullet list, through these steps:

1. Create an instance of the [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class.
2. Access the slide (in which you want to add a bullet list) in slide collection through the [ISlide](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/islide/) object.
3. Add an [AutoShape](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/autoshape/) in the selected slide.
4. Access the [text_frame](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/textframe/) of the added shape.
5. Remove the default paragraph in the [text_frame]().
6. Create the first paragraph instance using the [Paragraph](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/paragraph/) class.
8. Set the bullet type to Symbol and then set the bullet character.
9. Set the Paragraph Text.
10. Set the Paragraph Indent to set the bullet.
11. Set the Color of the Bullet.
12. Set the Height of the Bullet.
13. Add the created paragraph in the [text_frame](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/textframe/) paragraph collection.
14. Add the second paragraph and repeat steps 7-12.
15. Save the presentation.

This sample code in Python—an implementation of the steps above—shows you to create a bullet list in a slide:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1
    paragraph.paragraph_format.bullet.color.color = draw.Color.red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = "My text"

    textFrame.paragraphs.add(paragraph)
    
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

 

## Creating Picture Bullets

Aspose.Slides for Python via .NET allows you to change the bullets on bullet lists. You get to replace the bullets with custom symbols or images. If you want to add visual interest to a list or draw even more attention to entries on a list, you can use your own image as the bullet. 

 {{% alert color="primary" %}} 

Ideally, if you intend to replace the regular bullet symbol with a picture, you may want to select a simple graphics image with a transparent background. Such images work best as custom bullet symbols. 

In any case, the image you choose will be reduced to a very small size, so we strongly recommend you select an image that looks good (as a replacement for the bullet symbol) in a list. 

{{% /alert %}} 

To create a picture bullet, go through these steps:

1. Create an instance of the [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class.
2. Access the desired slide in slide collection using the [ISlide](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/islide/) object.
3. Add an [add_auto_shape](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/autoshape/) in the selected slide.
4. Access the [text_frame](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/textframe/) of the added shape.
5. Remove the default paragraph in the [text_frame](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/textframe/).
6. Create the first paragraph instance using the [Paragraph](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/paragraph/) class.
7. Load Image from disk and add it to [Presentation.images](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) and then use the [IPPImage](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/ippimage/) instance that was returned from the [add_image](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/imagecollection/) method.
8. Set the bullet type to Picture and then set the image.
9. Set the Paragraph Text.
10. Set the Paragraph Indent to set the bullet.
11. Set the Color of Bullet.
12. Set the Height of Bullets.
13. Add the created paragraph in the [text_frame](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/textframe/) paragraph collection.
14. Add the second paragraph and repeat steps 7-13.
15. Save the presentation.

 This Python code shows you to create a picture bullet in a slide:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = "My text"

    textFrame.paragraphs.add(paragraph)
    
    pres.save("pres-bullets.pptx", slides.export.SaveFormat.PPTX)
```

 

## Creating Multilevel Bullets

To create a bullet list that contains items on different levels—additional lists under the main bullet list—go through these steps:

1. Create an instance of the [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class.
2. Access the desired slide in slide collection using the [ISlide](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/islide/) object.
3. Add an [auto_shape](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/autoshape/) in the selected slide.
4. Access the [text_frame](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/textframe/) of the added shape.
5. Remove the default paragraph in the [text_frame](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/textframe/).
6. Create the first paragraph instance using the [Paragraph](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/paragraph/) class and with depth set to 0.
7. Create the second paragraph instance using the Paragraph class and the depth set to 1.
8. Create the third paragraph instance using the Paragraph class and the depth set to 2.
9. Create the fourth paragraph instance using the Paragraph class and the depth set to 3.
10. Add the created paragraphs in the [text_frame](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/textframe/) paragraph collection.
11. Save the presentation.

This code, which is an implementation of the steps above, shows you how to create a multilevel bullet list in Python:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 300, 300)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.depth = 0
    paragraph.text = "My text Depth 0"
    textFrame.paragraphs.add(paragraph)
    
    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 0
    paragraph2.text = "My text Depth 1"
    textFrame.paragraphs.add(paragraph2)
    
    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text Depth 2"
    textFrame.paragraphs.add(paragraph3)
    
    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text Depth 3"
    textFrame.paragraphs.add(paragraph4)
    
    pres.save("pres-bullets2.pptx", slides.export.SaveFormat.PPTX)
```

 

## Creating Numbers

 This Python code shows you how to create a numbered list in a slide:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.text = "My text 1"
    textFrame.paragraphs.add(paragraph)
    
    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "My text 2"
    textFrame.paragraphs.add(paragraph2)
    
    pres.save("pres-bullets3.pptx", slides.export.SaveFormat.PPTX)
```



