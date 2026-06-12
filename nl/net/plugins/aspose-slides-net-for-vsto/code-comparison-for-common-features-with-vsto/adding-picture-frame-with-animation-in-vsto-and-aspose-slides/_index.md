---
title: Beeldframe toevoegen met animatie in VSTO en Aspose.Slides
type: docs
weight: 20
url: /nl/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---
De onderstaande codevoorbeelden maken een presentatie met een dia, voegen een afbeelding met een beeldlijst toe en passen hier animatie op toe.
## **VSTO**
Met VSTO voert u de volgende stappen uit:

1. Maak een presentatie.
1. Voeg een lege dia toe.
1. Voeg een afbeeldingvorm toe aan de dia.
1. Pas animatie toe op de afbeelding.
1. Schrijf de presentatie naar schijf.

``` csharp

 //Lege presentatie aanmaken
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Voeg een lege dia toe
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);
//Voeg een afbeeldingframe toe
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);
//Animatie toepassen op afbeeldingframe
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;
//Presentatie opslaan
pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
``` 
## **Aspose.Slides**
Met Aspose.Slides voor .NET voert u de volgende stappen uit:

1. Maak een presentatie.
1. Open de eerste dia.
1. Voeg een afbeelding toe aan een beeldverzameling.
1. Voeg een afbeeldingvorm toe aan de dia.
1. Pas animatie toe op de afbeelding.
1. Schrijf de presentatie naar schijf.

``` csharp

 //Lege presentatie aanmaken
Presentation pres = new Presentation();

//Toegang tot de eerste dia
Slide slide = pres.GetSlideByPosition(1);

//Toevoegen van het afbeeldingobject aan de afbeeldingenverzameling van de presentatie
Picture pic = new Picture(pres, "pic.jpeg");

//Nadat het afbeeldingobject is toegevoegd, krijgt de afbeelding een uniek afbeelding‑Id
int picId = pres.Pictures.Add(pic);

//Toevoegen van een afbeeldingframe
Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//Animatie toepassen op afbeeldingframe
PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//Presentatie opslaan
pres.Write("AsposeAnim.ppt");
``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)