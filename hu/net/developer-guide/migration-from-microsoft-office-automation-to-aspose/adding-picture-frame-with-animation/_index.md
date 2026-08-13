---
title: Képkeretek hozzáadása animációval VSTO és Aspose.Slides for .NET használatával
linktitle: Képkeretek animációval
type: docs
weight: 60
url: /hu/net/adding-picture-frame-with-animation/
keywords:
- képkeret
- kép hozzáadása
- kép beszúrása
- animált kép
- kép animációval
- migráció
- VSTO
- Office automatizálás
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Válts Microsoft Office automatizálásról Aspose.Slides for .NET-re, és animáld a képkereteket a PowerPoint (PPT, PPTX) diákon tiszta C# kóddal."
---
{{% alert color="info" %}} 

A képkereteket alakzatokra vagy képekre alkalmazzák a Microsoft PowerPoint programban, hogy keretet adjanak a bemutatóban lévő képeknek. Ez a cikk bemutatja, hogyan hozhatsz létre képkeretet, és hogyan alkalmazhatsz animációt programozottan először a [VSTO 2008](/slides/hu/net/adding-picture-frame-with-animation/), majd az [Aspose.Slides for .NET](/slides/hu/net/adding-picture-frame-with-animation/) használatával. Először megmutatjuk, hogyan alkalmazz keretet és animációt a VSTO 2008 segítségével. Ezután bemutatjuk, hogyan végezheted el ugyanazokat a lépéseket az Aspose.Slides for .NET használatával.

{{% /alert %}} 
## **Képkeretek hozzáadása animációval**
Az alábbi kópminták egy diát tartalmazó prezentációt hoznak létre, képet adnak hozzá képkeretben, és animációt alkalmaznak rá.
### **VSTO 2008 példa**
A VSTO 2008 használatához kövesd az alábbi lépéseket:

1. Hozz létre egy prezentációt.
1. Adj hozzá egy üres diát.
1. Adj egy kép alakzatot a diához.
1. Alkalmazz animációt a képre.
1. Írd a prezentációt a lemezre.

**A VSTO-val létrehozott kimeneti prezentáció** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Üres prezentáció létrehozása
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Üres dia hozzáadása
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Képkeret hozzáadása
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Animáció alkalmazása a képkeretre
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Prezentáció mentése
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET példa**
Az Aspose.Slides for .NET használatához hajtsd végre a következő lépéseket:

1. Hozz létre egy prezentációt.
1. Érj el az első diát.
1. Adj egy képet a PictureCollection-hez.
1. Adj egy kép alakzatot a diához.
1. Alkalmazz animációt a képre.
1. Írd a prezentációt a lemezre.

**Az Aspose.Slides-szel létrehozott kimeneti prezentáció** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Üres prezentáció létrehozása
using (Presentation pres = new Presentation())
{
    // Az első dia elérése
    ISlide slide = pres.Slides[0];

    // Kép hozzáadása a prezentáció képgyűjteményéhez
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Képkeret hozzáadása, amelynek magassága és szélessége megegyezik a kép magasságával és szélességével
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // A dia fő animációs sorozatának lekérése
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // A 'Fly from Left' animációs effektus hozzáadása a képkerethez
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // A prezentáció mentése
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```