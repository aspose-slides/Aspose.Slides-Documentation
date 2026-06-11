---
title: Lägga till bildram med animation i VSTO och Aspose.Slides
type: docs
weight: 20
url: /sv/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---
Kodexemplen nedan skapar en presentation med en bild, lägger till en bild med en bildram och tillämpar animation på den.
## **VSTO**
Med VSTO, följ dessa steg:

1. Skapa en presentation.
1. Lägg till en tom bild.
1. Lägg till en bildform på bilden.
1. Tillämpa animation på bilden.
1. Spara presentationen till disk.

``` csharp

 //Skapar tom presentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Lägg till en tom bild
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Lägg till bildram
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Applicerar animation på bildramen
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Sparar presentation
pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
``` 
## **Aspose.Slides**
Med Aspose.Slides för .NET, utför följande steg:

1. Skapa en presentation.
1. Öppna den första bilden.
1. Lägg till en bild i en bildsamling.
1. Lägg till en bildform på bilden.
1. Tillämpa animation på bilden.
1. Spara presentationen till disk.

``` csharp

 //Skapar tom presentation
Presentation pres = new Presentation();

//Kommer åt den första bilden
Slide slide = pres.GetSlideByPosition(1);

//Lägger till bildobjektet i bildsamlingen för presentationen
Picture pic = new Picture(pres, "pic.jpeg");

//Efter att bildobjektet har lagts till får bilden ett unikt bild-ID
int picId = pres.Pictures.Add(pic);

//Lägger till bildram
Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//Applicerar animation på bildramen
PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//Sparar presentation
pres.Write("AsposeAnim.ppt");
``` 
## **Ladda ner exempel på kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)