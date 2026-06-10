---
title: Képkockák hozzáadása animációval VSTO és Aspose.Slides for .NET használatával
linktitle: Képkockák animációval
type: docs
weight: 60
url: /hu/net/adding-picture-frame-with-animation/
keywords:
- képkocka
- kép hozzáadása
- kép beszúrása
- animált kép
- animált kép
- migráció
- VSTO
- Office automatizálás
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Migráljon a Microsoft Office automatizálásból az Aspose.Slides for .NET-re, és animálja a képkockákat a PowerPoint (PPT, PPTX) diákon tiszta C# kóddal."
---
{{% alert color="primary" %}} 

A képkockákat a Microsoft PowerPoint alakzataira vagy képeire alkalmazzák, hogy a prezentációban képeket keretezzék. Ez a cikk bemutatja, hogyan lehet programozott módon képkockát létrehozni és animációt alkalmazni rá, először a [VSTO 2008](/slides/hu/net/adding-picture-frame-with-animation/) és aztán a [Aspose.Slides for .NET](/slides/hu/net/adding-picture-frame-with-animation/) segítségével. Először megmutatjuk, hogyan kell keretet és animációt alkalmazni a VSTO 2008 használatával. Ezután bemutatjuk, hogyan hajthatók végre ugyanazok a lépések az Aspose.Slides for .NET használatával.

{{% /alert %}} 
## **Képkockák hozzáadása animációval**
Az alábbi kódrészletek egy prezentációt hoznak létre egy diával, egy képet képkockával adnak hozzá, és animációt alkalmaznak rá.
### **VSTO 2008 példa**
A VSTO 2008 használatával kövesse az alábbi lépéseket:

1. Hozzon létre egy prezentációt.
1. Adjon hozzá egy üres diát.
1. Adjon egy képalakzatot a diához.
1. Alkalmazzon animációt a képre.
1. Írja a prezentációt a lemezre.

**A VSTO-val létrehozott kimeneti prezentáció** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Üres prezentáció létrehozása
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Üres dia hozzáadása
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Képkocka hozzáadása
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Animáció alkalmazása a képkockán
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Prezentáció mentése
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET példa**
Az Aspose.Slides for .NET használatával hajtsa végre a következő lépéseket:

1. Hozzon létre egy prezentációt.
1. Lépjen az első diára.
1. Adjon egy képet a picture collection-hez.
1. Adjon egy képalakzatot a diához.
1. Alkalmazzon animációt a képre.
1. Írja a prezentációt a lemezre.

**Az Aspose.Slides-szel létrehozott kimeneti prezentáció** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
// Üres prezentáció létrehozása
using (Presentation pres = new Presentation())
{
    // Első dia elérése
    ISlide slide = pres.Slides[0];

    // Kép hozzáadása a prezentáció képgyűjteményéhez
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Képkocka hozzáadása, amelynek magassága és szélessége megegyezik a kép magasságával és szélességével
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // A dia fő animációs szekvenciájának lekérése
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Balról repülés animációs effektus hozzáadása a képkockához
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Prezentáció mentése
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```