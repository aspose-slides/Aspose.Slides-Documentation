---
title: Přidání rámečků obrázků s animací pomocí VSTO a Aspose.Slides pro .NET
linktitle: Rámečky obrázků s animací
type: docs
weight: 60
url: /cs/net/adding-picture-frame-with-animation/
keywords:
- rámeček obrázku
- přidat obrázek
- přidat obrázek
- obrázek s animací
- obrázek s animací
- migrace
- VSTO
- automatizace Office
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Migrace z automatizace Microsoft Office na Aspose.Slides pro .NET a animování rámečků obrázků v snímcích PowerPoint (PPT, PPTX) pomocí čistého kódu v C#."
---
{{% alert color="primary" %}} 

Rámečky obrázků se aplikují na tvary nebo obrázky v Microsoft PowerPointu, aby v prezentaci rámečkovaly obrázky. Tento článek ukazuje, jak programově vytvořit rámeček obrázku a aplikovat na něj animaci, nejprve pomocí [VSTO 2008](/slides/cs/net/adding-picture-frame-with-animation/) a poté pomocí [Aspose.Slides for .NET](/slides/cs/net/adding-picture-frame-with-animation/). Nejprve vám ukážeme, jak pomocí VSTO 2008 aplikovat rámeček a animaci. Poté vám ukážeme, jak provést stejné kroky pomocí Aspose.Slides for .NET.

{{% /alert %}} 
## **Přidání rámečků obrázků s animací**
Níže uvedené ukázky kódu vytvoří prezentaci s jedním snímkem, přidají obrázek s rámečkem a použijí na něj animaci.
### **Příklad VSTO 2008**
Pomocí VSTO 2008 proveďte následující kroky:

1. Vytvořte prezentaci.
1. Přidejte prázdný snímek.
1. Přidejte na snímek tvar obrázku.
1. Aplikujte na obrázek animaci.
1. Uložte prezentaci na disk.

**Výstupní prezentace vytvořená pomocí VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Vytvoření prázdné prezentace
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Přidat prázdný snímek
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Přidat rámeček obrázku
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Aplikace animace na rámeček obrázku
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Ukládání prezentace
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Příklad Aspose.Slides pro .NET**
Pomocí Aspose.Slides pro .NET proveďte následující kroky:

1. Vytvořte prezentaci.
1. Získejte první snímek.
1. Přidejte obrázek do kolekce obrázků.
1. Přidejte na snímek tvar obrázku.
1. Aplikujte na obrázek animaci.
1. Uložte prezentaci na disk.

**Výstupní prezentace vytvořená pomocí Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
// Vytvoření prázdné prezentace
using (Presentation pres = new Presentation())
{
    // Přístup k prvnímu snímku
    ISlide slide = pres.Slides[0];

    // Přidat obrázek do kolekce obrázků prezentace
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Přidat rámeček obrázku, jehož výška a šířka odpovídají výšce a šířce obrázku
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Získat hlavní sekvenci animace snímku
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Přidat efekt animace Let zleva k rámečku obrázku
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Uložit prezentaci
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```