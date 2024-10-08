---
title: Hinzufügen eines Bilderrahmens mit Animation in VSTO und Aspose.Slides
type: docs
weight: 20
url: /de/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---

Die folgenden Codebeispiele erstellen eine Präsentation mit einer Folie, fügen ein Bild mit einem Bilderrahmen hinzu und wenden Animationen darauf an.
## **VSTO**
Verwenden Sie VSTO und führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Präsentation.
1. Fügen Sie eine leere Folie hinzu.
1. Fügen Sie der Folie eine Bildform hinzu.
1. Wenden Sie eine Animation auf das Bild an.
1. Schreiben Sie die Präsentation auf die Festplatte.

``` csharp

 //Erstellen einer leeren Präsentation

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Fügen Sie eine leere Folie hinzu

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Fügen Sie den Bilderrahmen hinzu

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Wenden Sie eine Animation auf den Bilderrahmen an

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Speichern der Präsentation

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Aspose.Slides**
Verwenden Sie Aspose.Slides für .NET und führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Präsentation.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Bild zu einer Bildersammlung hinzu.
1. Fügen Sie der Folie eine Bildform hinzu.
1. Wenden Sie eine Animation auf das Bild an.
1. Schreiben Sie die Präsentation auf die Festplatte.

``` csharp

 //Erstellen einer leeren Präsentation

Presentation pres = new Presentation();

//Zugriff auf die erste Folie

Slide slide = pres.GetSlideByPosition(1);

//Hinzufügen des Bildobjekts zur Bildersammlung der Präsentation

Picture pic = new Picture(pres, "pic.jpeg");

//Nachdem das Bildobjekt hinzugefügt wurde, wird das Bild mit einer einzigartigen Bild-ID versehen

int picId = pres.Pictures.Add(pic);

//Fügen Sie den Bilderrahmen hinzu

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//Wenden Sie eine Animation auf den Bilderrahmen an

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//Speichern der Präsentation

pres.Write("AsposeAnim.ppt");

``` 
## **Beispielcode herunterladen**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772946)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Adding%20Picture%20Frame%20with%20Animation%20\(Aspose.Slides\).zip)