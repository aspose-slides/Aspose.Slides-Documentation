---
title: Manage Bullet and Numbered Lists
type: docs
weight: 60
url: /net/manage-bullet-and-numbered-lists
keywords: "Bullets, Bullet lists, Numbers, Numbered lists, Picture bullets, multilevel bullets, PowerPoint Presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Create bullet and numbered lists in PowerPoint presentation in C# or .NET"
---

In **Microsoft PowerPoint**, you can create bullet and numbered lists the same way you do in Word and other text editors. **Aspose.Slides for .NET** also allows you to use bullets and numbers in slides in your presentations. 

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

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Access the slide (in which you want to add a bullet list) in slide collection through the [ISlide](https://apireference.aspose.com/slides/net/aspose.slides/islide/methods/index) object.
3. Add an [AutoShape](https://apireference.aspose.com/slides/net/aspose.slides/autoshape) in the selected slide.
4. Access the [TextFrame](https://apireference.aspose.com/slides/net/aspose.slides/textframe) of the added shape.
5. Remove the default paragraph in the [TextFrame]().
6. Create the first paragraph instance using the [Paragraph](https://apireference.aspose.com/slides/net/aspose.slides/paragraph) class.
8. Set the bullet type to Symbol and then set the bullet character.
9. Set the Paragraph Text.
10. Set the Paragraph Indent to set the bullet.
11. Set the Color of the Bullet.
12. Set the Height of the Bullet.
13. Add the created paragraph in the [TextFrame](https://apireference.aspose.com/slides/net/aspose.slides/textframe) paragraph collection.
14. Add the second paragraph and repeat steps 7-12.
15. Save the presentation.

This sample code in C#—an implementation of the steps above—shows you to create a bullet list in a slide:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.Red;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = "My text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

 

## Creating Picture Bullets

Aspose.Slides for .NET allows you to change the bullets on bullet lists. You get to replace the bullets with custom symbols or images. If you want to add visual interest to a list or draw even more attention to entries on a list, you can use your own image as the bullet. 

 {{% alert color="primary" %}} 

Ideally, if you intend to replace the regular bullet symbol with a picture, you may want to select a simple graphics image with a transparent background. Such images work best as custom bullet symbols. 

In any case, the image you choose will be reduced to a very small size, so we strongly recommend you select an image that looks good (as a replacement for the bullet symbol) in a list. 

{{% /alert %}} 

To create a picture bullet, go through these steps:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Access the desired slide in slide collection using the [ISlide](https://apireference.aspose.com/slides/net/aspose.slides/islide/methods/index) object.
3. Add an [AutoShape](https://apireference.aspose.com/slides/net/aspose.slides/autoshape) in the selected slide.
4. Access the [TextFrame](https://apireference.aspose.com/slides/net/aspose.slides/textframe) of the added shape.
5. Remove the default paragraph in the [TextFrame](https://apireference.aspose.com/slides/net/aspose.slides/textframe).
6. Create the first paragraph instance using the [Paragraph](https://apireference.aspose.com/slides/net/aspose.slides/paragraph) class.
7. Load Image from disk and add it to [Presentation.Images](https://apireference.aspose.com/slides/net/aspose.slides/presentation/properties/images) and then use the [IPPImage](https://apireference.aspose.com/slides/net/aspose.slides/ippimage) instance that was returned from the [AddImage](https://apireference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index) method.
8. Set the bullet type to Picture and then set the image.
9. Set the Paragraph Text.
10. Set the Paragraph Indent to set the bullet.
11. Set the Color of Bullet.
12. Set the Height of Bullets.
13. Add the created paragraph in the [TextFrame](https://apireference.aspose.com/slides/net/aspose.slides/textframe) paragraph collection.
14. Add the second paragraph and repeat steps 7-13.
15. Save the presentation.

 This C# code shows you to create a picture bullet in a slide:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = "My text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

 

## Creating Multilevel Bullets

To create a bullet list that contains items on different levels—additional lists under the main bullet list—go through these steps:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Access the desired slide in slide collection using the [ISlide](https://apireference.aspose.com/slides/net/aspose.slides/islide/methods/index) object.
3. Add an [AutoShape](https://apireference.aspose.com/slides/net/aspose.slides/autoshape) in the selected slide.
4. Access the [TextFrame](https://apireference.aspose.com/slides/net/aspose.slides/textframe) of the added shape.
5. Remove the default paragraph in the [TextFrame](https://apireference.aspose.com/slides/net/aspose.slides/textframe).
6. Create the first paragraph instance using the [Paragraph](https://apireference.aspose.com/slides/net/aspose.slides/paragraph) class and with depth set to 0.
7. Create the second paragraph instance using the Paragraph class and the depth set to 1.
8. Create the third paragraph instance using the Paragraph class and the depth set to 2.
9. Create the fourth paragraph instance using the Paragraph class and the depth set to 3.
10. Add the created paragraphs in the [TextFrame](https://apireference.aspose.com/slides/net/aspose.slides/textframe) paragraph collection.
11. Save the presentation.

This code, which is an implementation of the steps above, shows you how to create a multilevel bullet list in C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 300, 300);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Depth = 0;
    paragraph.Text = "My text Depth 0";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Depth = 0;
    paragraph2.Text = "My text Depth 1";
    textFrame.Paragraphs.Add(paragraph2);
    
    Paragraph paragraph3 = new Paragraph();
    paragraph3.ParagraphFormat.Depth = 2;
    paragraph3.Text = "My text Depth 2";
    textFrame.Paragraphs.Add(paragraph3);
    
    Paragraph paragraph4 = new Paragraph();
    paragraph4.ParagraphFormat.Depth = 3;
    paragraph4.Text = "My text Depth 3";
    textFrame.Paragraphs.Add(paragraph4);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

 

## Creating Numbers

 This C# code shows you how to create a numbered list in a slide:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph.Text = "My text 1";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph2.Text = "My text 2";
    textFrame.Paragraphs.Add(paragraph2);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```



