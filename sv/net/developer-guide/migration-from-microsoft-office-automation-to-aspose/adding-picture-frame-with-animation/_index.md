---
title: Lägga till bildramar med animering med VSTO och Aspose.Slides för .NET
linktitle: Bildramar med animering
type: docs
weight: 60
url: /sv/net/adding-picture-frame-with-animation/
keywords:
- bildram
- lägga till bild
- lägga till bild
- bild med animering
- bild med animering
- migration
- VSTO
- Office-automatisering
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Migrera från Microsoft Office-automatisering till Aspose.Slides för .NET och animera bildramar i PowerPoint (PPT, PPTX)-bilder med ren C#-kod."
---
{{% alert color="info" %}} 

Bildramar tillämpas på former eller bilder i Microsoft PowerPoint för att rama in bilder i en presentation. Den här artikeln visar hur man skapar en bildram och applicerar animering på den programatiskt med först [VSTO 2008](/slides/sv/net/adding-picture-frame-with-animation/) och sedan [Aspose.Slides for .NET](/slides/sv/net/adding-picture-frame-with-animation/). Först visar vi hur du applicerar en ram och animering med VSTO 2008. Därefter visar vi hur du utför samma steg med Aspose.Slides for .NET.

{{% /alert %}} 
## **Lägga till bildramar med animering**
The code samples below create a presentation with a slide, add an image with a picture frame and applies animation to it.
### **VSTO 2008‑exempel**
Using VSTO 2008, take the following steps:

1. Skapa en presentation.
1. Lägg till en tom bild.
1. Lägg till en bildform på bilden.
1. Applicera animering på bilden.
1. Skriv presentationen till disk.

**Den resulterande presentationen, skapad med VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Skapar tom presentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Lägg till en tom bild
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Lägg till bildram
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Applicerar animering på bildram
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Sparar presentation
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET‑exempel**
Using Aspose.Slides for .NET, perform the following steps:

1. Skapa en presentation.
1. Kom åt den första bilden.
1. Lägg till en bild i en bildsamling.
1. Lägg till en bildform på bilden.
1. Applicera animering på bilden.
1. Skriv presentationen till disk.

**Den resulterande presentationen, skapad med Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Skapa en tom presentation
using (Presentation pres = new Presentation())
{
    // Kom åt den första bilden
    ISlide slide = pres.Slides[0];

    // Lägg till en bild i presentationens bildsamling
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Lägg till en bildram vars höjd och bredd matchar bildens höjd och bredd
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Hämta huvudanimationssekvensen för bilden
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Lägg till Fly från vänster-animeringseffekt på bildramen
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Spara presentationen
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```