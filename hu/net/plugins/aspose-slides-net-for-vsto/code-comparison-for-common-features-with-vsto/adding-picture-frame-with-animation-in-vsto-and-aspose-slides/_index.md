---
title: Képkocka hozzáadása animációval VSTO-ban és az Aspose.Slides-ben
type: docs
weight: 20
url: /hu/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---
Az alábbi kódminták egy bemutatót hoznak létre egy diával, egy képet képkockával adnak hozzá, és animációt alkalmaznak rá.
## **VSTO**
A VSTO használatával kövesse az alábbi lépéseket:

1. Hozzon létre egy bemutatót.
1. Adjon hozzá egy üres diát.
1. Adjon hozzá egy képalakzatot a diára.
1. Alkalmazzon animációt a képre.
1. Írja ki a bemutatót a lemezre.

``` csharp

 //Üres prezentáció létrehozása
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Üres dia hozzáadása
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Képkocka hozzáadása
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Animáció alkalmazása a képkockára
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Prezentáció mentése
pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);
``` 
## **Aspose.Slides**
Az Aspose.Slides for .NET használatával hajtsa végre az alábbi lépéseket:

1. Hozzon létre egy bemutatót.
1. Érje el az első diát.
1. Adjon hozzá egy képet a képgyűjteményhez.
1. Adjon hozzá egy képalakzatot a diára.
1. Alkalmazzon animációt a képre.
1. Írja ki a bemutatót a lemezre.

``` csharp

 //Üres prezentáció létrehozása
Presentation pres = new Presentation();

//Első dia elérése
Slide slide = pres.GetSlideByPosition(1);

//Képobjektum hozzáadása a prezentáció képek gyűjteményéhez
Picture pic = new Picture(pres, "pic.jpeg");

//Miután a képobjektum hozzá lett adva, a kép egy egyedi képazonosítót kap
int picId = pres.Pictures.Add(pic);

//Képkocka hozzáadása
Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//Animáció alkalmazása a képkockára
PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//Prezentáció mentése
pres.Write("AsposeAnim.ppt");

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)