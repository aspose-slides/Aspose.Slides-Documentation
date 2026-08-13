---
title: Afbeeldingskaders toevoegen met animatie met VSTO en Aspose.Slides voor .NET
linktitle: Afbeeldingskaders met animatie
type: docs
weight: 60
url: /nl/net/adding-picture-frame-with-animation/
keywords:
- afbeeldingskader
- afbeelding toevoegen
- afbeelding toevoegen
- afbeelding met animatie
- afbeelding met animatie
- migratie
- VSTO
- Office-automatisering
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Migreer van Microsoft Office-automatisering naar Aspose.Slides voor .NET en animeer afbeeldingskaders in PowerPoint (PPT, PPTX) dia's met nette C#-code."
---
{{% alert color="info" %}} 

Afbeeldingskaders worden toegepast op vormen of afbeeldingen in Microsoft PowerPoint om afbeeldingen in een presentatie te omkaderen. Dit artikel laat zien hoe u programmatisch een afbeeldingskader kunt maken en er animatie op kunt toepassen, eerst met [VSTO 2008](/slides/nl/net/adding-picture-frame-with-animation/) en daarna met [Aspose.Slides for .NET](/slides/nl/net/adding-picture-frame-with-animation/). Eerst laten we zien hoe u een kader en animatie toepast met VSTO 2008. Daarna laten we zien hoe u dezelfde stappen uitvoert met Aspose.Slides for .NET.

{{% /alert %}} 
## **Afbeeldingskaders toevoegen met animatie**
De codevoorbeelden hieronder maken een presentatie met een dia, voegen een afbeelding met een afbeeldingskader toe en passen er animatie op toe.
### **VSTO 2008‑voorbeeld**
Met VSTO 2008, volg de volgende stappen:

1. Maak een presentatie.
1. Voeg een lege dia toe.
1. Voeg een afbeeldingsvorm toe aan de dia.
1. Pas animatie toe op de afbeelding.
1. Schrijf de presentatie naar schijf.

**De uitvoer‑presentatie, gemaakt met VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Lege presentatie maken
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Lege dia toevoegen
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Afbeeldingskader toevoegen
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Animatie toepassen op het afbeeldingskader
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Presentatie opslaan
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides voor .NET‑voorbeeld**
Met Aspose.Slides voor .NET, voer de volgende stappen uit:

1. Maak een presentatie.
1. Open de eerste dia.
1. Voeg een afbeelding toe aan een afbeeldingsverzameling.
1. Voeg een afbeeldingsvorm toe aan de dia.
1. Pas animatie toe op de afbeelding.
1. Schrijf de presentatie naar schijf.

**De uitvoer‑presentatie, gemaakt met Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Lege presentatie maken
using (Presentation pres = new Presentation())
{
    // Open de eerste dia
    ISlide slide = pres.Slides[0];

    // Afbeelding toevoegen aan de afbeeldingencollectie van de presentatie
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Afbeeldingskader toevoegen waarvan de hoogte en breedte overeenkomen met die van de afbeelding
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Hoofdanimatiesequentie van de dia ophalen
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Fly‑van‑links‑animatie‑effect toevoegen aan het afbeeldingskader
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Presentatie opslaan
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```