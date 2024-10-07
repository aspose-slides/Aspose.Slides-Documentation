---
title: Hinzufügen eines Bilderrahmens mit Animation
type: docs
weight: 60
url: /net/adding-picture-frame-with-animation/
---

{{% alert color="primary" %}} 

Bilderahmen werden in Microsoft PowerPoint auf Formen oder Bilder angewendet, um Bilder in einer Präsentation zu rahmen. Dieser Artikel zeigt, wie man programmgesteuert einen Bilderrahmen erstellt und Animation darauf anwendet, zunächst mit [VSTO 2008](/slides/net/adding-picture-frame-with-animation/) und dann mit [Aspose.Slides für .NET](/slides/net/adding-picture-frame-with-animation/). Zuerst zeigen wir Ihnen, wie Sie einen Rahmen und eine Animation mit VSTO 2008 anwenden. Dann zeigen wir Ihnen, wie Sie die gleichen Schritte mit Aspose.Slides für .NET ausführen.

{{% /alert %}} 
## **Hinzugefügt Bilderrahmen mit Animation**
Die folgenden Codebeispiele erstellen eine Präsentation mit einer Folie, fügen ein Bild mit einem Bilderrahmen hinzu und wenden Animation darauf an.
### **VSTO 2008 Beispiel**
Verwenden Sie VSTO 2008 und führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Präsentation.
1. Fügen Sie eine leere Folie hinzu.
1. Fügen Sie eine Bilderform zur Folie hinzu.
1. Wenden Sie Animation auf das Bild an.
1. Schreiben Sie die Präsentation auf die Festplatte.

**Die ausgegebene Präsentation, erstellt mit VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Erstellen einer leeren Präsentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Fügen Sie eine leere Folie hinzu
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Bilderahmen hinzufügen
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Anwenden von Animationen auf den Bilderrahmen
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Präsentation speichern
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides für .NET Beispiel**
Verwenden Sie Aspose.Slides für .NET und führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Präsentation.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Bild zu einer Bildersammlung hinzu.
1. Fügen Sie eine Bilderform zur Folie hinzu.
1. Wenden Sie Animation auf das Bild an.
1. Schreiben Sie die Präsentation auf die Festplatte.

**Die ausgegebene Präsentation, erstellt mit Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
// Erstellen einer leeren Präsentation
using (Presentation pres = new Presentation())
{
    // Zugriff auf die erste Folie
    ISlide slide = pres.Slides[0];

    // Fügen Sie ein Bild zur Bildersammlung der Präsentation hinzu
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Fügen Sie einen Bilderrahmen hinzu, dessen Höhe und Breite der Höhe und Breite des Bildes entsprechen
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Holen Sie sich die Hauptanimationssequenz der Folie
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Fügen Sie den Fly from Left Animations-Effekt zum Bilderrahmen hinzu
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Speichern Sie die Präsentation
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```