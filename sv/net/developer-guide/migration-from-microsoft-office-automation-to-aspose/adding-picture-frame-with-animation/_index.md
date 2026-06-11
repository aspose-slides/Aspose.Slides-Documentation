---
title: Lägga till bildramar med animation med VSTO och Aspose.Slides för .NET
linktitle: Bildramar med animation
type: docs
weight: 60
url: /sv/net/adding-picture-frame-with-animation/
keywords:
- bildram
- lägg till bild
- lägg till bild
- bild med animation
- bild med animation
- migrering
- VSTO
- Office-automatisering
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Migrera från Microsoft Office-automatisering till Aspose.Slides för .NET och animera bildramar i PowerPoint (PPT, PPTX) med ren C#-kod."
---
{{% alert color="primary" %}} 

Bildramar appliceras på former eller bilder i Microsoft PowerPoint för att rama in bilder i en presentation. Denna artikel visar hur man skapar en bildram och applicerar animation på den programatiskt genom först [VSTO 2008](/slides/sv/net/adding-picture-frame-with-animation/) och sedan [Aspose.Slides for .NET](/slides/sv/net/adding-picture-frame-with-animation/). Först visar vi hur du applicerar en ram och animation med VSTO 2008. Därefter visar vi hur du utför samma steg med Aspose.Slides for .NET.

{{% /alert %}} 
## **Lägga till bildramar med animation**
Kodexemplen nedan skapar en presentation med en bild, lägger till en bild med en bildram och tillämpar animation på den.
### **VSTO 2008-exempel**
Med VSTO 2008, följ följande steg:

1. Skapa en presentation.
1. Lägg till en tom bild.
1. Lägg till en bildform till bilden.
1. Tillämpa animation på bilden.
1. Skriv presentationen till disk.

**Den resulterande presentationen, skapad med VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Skapa en tom presentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Lägg till ett tomt bildblad
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Lägg till bildram
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Applicera animation på bildram
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Spara presentation
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET-exempel**
Med Aspose.Slides for .NET, utför följande steg:

1. Skapa en presentation.
1. Hämta den första bilden.
1. Lägg till en bild i en bildsamling.
1. Lägg till en bildform till bilden.
1. Tillämpa animation på bilden.
1. Skriv presentationen till disk.

**Den resulterande presentationen, skapad med Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
// Skapa en tom presentation
using (Presentation pres = new Presentation())
{
    // Hämta det första bildbladet
    ISlide slide = pres.Slides[0];

    // Lägg till en bild i presentationens bildsamling
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Lägg till en bildram vars höjd och bredd matchar bildens höjd och bredd
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Hämta bildspelets huvudanimationssekvens för bildbladet
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Lägg till Fly from Left-animeringseffekten på bildramen
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Spara presentationen
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```