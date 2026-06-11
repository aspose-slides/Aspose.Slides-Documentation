---
title: Dodawanie ramki obrazu z animacją w VSTO i Aspose.Slides
type: docs
weight: 20
url: /pl/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---
Poniższe przykłady kodu tworzą prezentację ze slajdem, dodają obraz z ramką zdjęcia i stosują do niego animację.
## **VSTO**
Korzystając z VSTO, wykonaj następujące kroki:

1. Utwórz prezentację.
1. Dodaj pusty slajd.
1. Dodaj kształt obrazu do slajdu.
1. Zastosuj animację do obrazu.
1. Zapisz prezentację na dysku.

``` csharp

 //Tworzenie pustej prezentacji
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Dodaj pusty slajd
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);
//Dodaj ramkę obrazu
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);
//Stosowanie animacji na ramce obrazu
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;
//Zapisywanie prezentacji
pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
``` 
## **Aspose.Slides**
Korzystając z Aspose.Slides dla .NET, wykonaj następujące kroki:

1. Utwórz prezentację.
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj obraz do kolekcji obrazów.
1. Dodaj kształt obrazu do slajdu.
1. Zastosuj animację do obrazu.
1. Zapisz prezentację na dysku.

``` csharp

 //Tworzenie pustej prezentacji
Presentation pres = new Presentation();
//Uzyskiwanie pierwszego slajdu
Slide slide = pres.GetSlideByPosition(1);
//Dodawanie obiektu obrazu do kolekcji obrazów prezentacji
Picture pic = new Picture(pres, "pic.jpeg");
//Po dodaniu obiektu obrazu, obraz otrzymuje unikalny identyfikator
int picId = pres.Pictures.Add(pic);
//Dodawanie ramki obrazu
Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);
//Stosowanie animacji na ramce obrazu
PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;
//Zapisywanie prezentacji
pres.Write("AsposeAnim.ppt");
``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)