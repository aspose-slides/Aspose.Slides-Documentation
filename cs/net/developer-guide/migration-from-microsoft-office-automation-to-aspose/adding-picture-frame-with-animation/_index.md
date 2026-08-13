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
description: "Přesuňte se z automatizace Microsoft Office na Aspose.Slides pro .NET a animujte rámečky obrázků v slidech PowerPointu (PPT, PPTX) pomocí čistého C# kódu."
---
{{% alert color="info" %}} 

Rámce obrázků se používají na tvary nebo obrázky v programu Microsoft PowerPoint k ohraničení obrázků v prezentaci. Tento článek ukazuje, jak programově vytvořit rámec obrázku a použít na něj animaci, nejprve pomocí [VSTO 2008](/slides/cs/net/adding-picture-frame-with-animation/) a poté [Aspose.Slides for .NET](/slides/cs/net/adding-picture-frame-with-animation/). Nejprve vám ukážeme, jak pomocí VSTO 2008 aplikovat rámec a animaci. Poté vám ukážeme, jak provést stejné kroky pomocí Aspose.Slides for .NET.

{{% /alert %}} 
## **Adding Picture Frames with Animation**
Níže uvedené ukázky kódu vytvoří prezentaci se snímkem, přidají obrázek s rámcem a použijí na něj animaci.
### **VSTO 2008 Example**
Pomocí VSTO 2008 proveďte následující kroky:

1. Vytvořte prezentaci.
1. Přidejte prázdný snímek.
1. Přidejte tvar obrázku na snímek.
1. Aplikujte animaci na obrázek.
1. Uložte prezentaci na disk.

**The output presentation, created with VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Vytvoření prázdné prezentace
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Přidání prázdného snímku
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Přidání rámečku obrázku
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Aplikace animace na rámeček obrázku
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Ukládání prezentace
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET Example**
Pomocí Aspose.Slides for .NET proveďte následující kroky:

1. Vytvořte prezentaci.
1. Přístup k prvnímu snímku.
1. Přidejte obrázek do kolekce obrázků.
1. Přidejte tvar obrázku na snímek.
1. Aplikujte animaci na obrázek.
1. Uložte prezentaci na disk.

**The output presentation, created with Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Vytvoření prázdné prezentace
using (Presentation pres = new Presentation())
{
    // Přístup k prvnímu snímku
    ISlide slide = pres.Slides[0];

    // Přidání obrázku do kolekce obrázků prezentace
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Přidání rámečku obrázku, jehož výška a šířka odpovídají výšce a šířce obrázku
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Získání hlavní sekvence animací snímku
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Přidání efektu animace Přesun zleva k rámečku obrázku
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Uložení prezentace
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```