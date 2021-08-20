---
title: Manage Hyperlinks
type: docs
weight: 20
url: /net/manage-hyperlinks/

---

A hyperlink is a reference to an object or data or a place in something. These are common hyperlinks in PowerPoint Presentations:

* Links to websites inside texts, shapes, or media
* Links to files inside texts, shapes, or media
* Links to slides
* Links to emails

Aspose.Slides for .NET allows you to perform many tasks involving hyperlinks in presentations. 

## **Adding URL Hyperlinks**

### **Adding URL Hyperlinks to Texts**

This C# code shows you how to add a website hyperlink to a text:

```c#
using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: File Format APIs");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

### **Adding URL Hyperlinks to Shapes or Frames**

This sample code in C# shows you how to add a website hyperlink to a shape:

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```



### **Adding URL Hyperlinks to Media**

Aspose.Slides allows you to add hyperlinks to images, audio, and video files. 

This sample code shows you how to add a hyperlink to an image:

```c#
using (Presentation pres = new Presentation())
{
    // add image to presentation
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // create picture frame on slide 1 based on previously added image
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

 

This sample code shows you how to add a hyperlink to an audio file:

```c#
using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

 

This sample code shows you how to add a hyperlink to a video:

``` csharp
using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```



## **Adding File Hyperlinks**

### **Adding File Links to Texts**

 

### **Adding File Links to Media**

 

### **Adding File Links to Shapes and Frames**

 

{{%  alert  title="TIP"  color="primary"  %}} 

You may want to see *[Manage OLE](https://docs.aspose.com/slides/net/manage-ole/)*.

{{% /alert %}}







## **Adding Slide Hyperlinks**











## **Using Hyperlinks to Create Table of Contents**

Since hyperlinks allow you to add references to objects or places, you can use them to create a table of contents. 

This sample code shows you how to create a table of contents with hyperlinks:

```c#
using (var presentation = new Presentation())
{
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

    var contentTable = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.FillFormat.FillType = FillType.NoFill;
    contentTable.LineFormat.FillFormat.FillType = FillType.NoFill;
    contentTable.TextFrame.Paragraphs.Clear();

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    paragraph.Text = "Title of slide 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "Page 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```



## **Adding Email Hyperlinks**

~~Confirm that we support this function—find out it works similarly to the addition of URL hyperlinks to texts.~~  

 





## **Getting the Details in Hyperlinks**







## **Formatting Hyperlinks**

~~What other formatting options?~~

### **Color**

With the [ColorSource](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/colorsource) property in the [IHyperlink](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink) interface, you can set the color for hyperlinks and also get the color information from hyperlinks. The feature was first introduced in PowerPoint 2019, so changes involving the property do not apply to older PowerPoint versions.

This sample code demonstrates an operation where hyperlinks with different colors got added to the same slide:

```c#
using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("This is a sample of colored hyperlink.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("This is a sample of usual hyperlink.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```



## **Removing Hyperlinks in Presentations**

### **Removing Hyperlinks from Texts**

This C# code shows you how to remove the hyperlink from a text in a presentation slide:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
            {
                foreach (IPortion portion in paragraph.Portions)
                {
                    portion.PortionFormat.HyperlinkManager.RemoveHyperlinkClick();
                }
            }
        }
    }
    
    pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
```

 

### **Removing Hyperlinks from Shapes or Frames**

This C# code shows you how to remove the hyperlink from a shape in a presentation slide: 

``` csharp
using (Presentation pres = new Presentation("demo.pptx")) 
{ 
   ISlide slide = pres.Slides[0]; 
   foreach (IShape shape in slide.Shapes) 
     { 
       shape.HyperlinkManager.RemoveHyperlinkClick(); 
     } 
   pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx); 
}
```

### **Removing Hyperlinks from Media**

 








## **Mutable Hyperlink**

[Hyperlink](https://apireference.aspose.com/net/slides/aspose.slides/hyperlink) class changed to be mutable. Now it is possible to change values of the following properties which were read-only before:

- [IHyperlink.TargetFrame](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/highlightclick)
- [IHyperlink.StopSoundOnClick](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/stopsoundonclick)

The code snippet below shows adding a hyperlink to the slide and editing its tooltip later:

```c#
using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: File Format APIs");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```




## **Supported Properties in IHyperlinkQueries**

The IHyperlinkQueries class can be accessed from the presentation, slide and text frame that the hyperlink is defined for.

- [IPresentation.HyperlinkQueries](https://apireference.aspose.com/net/slides/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://apireference.aspose.com/net/slides/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://apireference.aspose.com/net/slides/aspose.slides/itextframe/properties/hyperlinkqueries)

The IHyperlinkQueries class supports the following methods and properties.

- [IHyperlinkQueries.GetHyperlinkClicks();](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

