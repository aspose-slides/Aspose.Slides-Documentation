---
title: Bilderrahmen mit Animation hinzufügen mit VSTO und Aspose.Slides für .NET
linktitle: Bilderrahmen mit Animation
type: docs
weight: 60
url: /de/net/adding-picture-frame-with-animation/
keywords:
- Bilderrahmen
- Bild hinzufügen
- Bild hinzufügen
- Bild mit Animation
- Bild mit Animation
- Migration
- VSTO
- Office-Automatisierung
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Wechseln Sie von der Microsoft Office-Automatisierung zu Aspose.Slides für .NET und animieren Sie Bilderrahmen in PowerPoint (PPT, PPTX)-Folien mit sauberem C#-Code."
---

{{% alert color="primary" %}} 
Bilderrahmen werden in Microsoft PowerPoint auf Formen oder Bilder angewendet, um Bilder in einer Präsentation zu rahmen. Dieser Artikel zeigt, wie man programmgesteuert einen Bilderrahmen erstellt und darauf eine Animation anwendet, zuerst mit [VSTO 2008](/slides/de/net/adding-picture-frame-with-animation/) und dann mit [Aspose.Slides for .NET](/slides/de/net/adding-picture-frame-with-animation/). Zuerst zeigen wir, wie man mit VSTO 2008 einen Rahmen und eine Animation anwendet. Anschließend zeigen wir, wie man dieselben Schritte mit Aspose.Slides for .NET ausführt.
{{% /alert %}} 
## **Hinzufügen von Bilderrahmen mit Animation**
Die nachstehenden Codebeispiele erstellen eine Präsentation mit einer Folie, fügen ein Bild mit einem Bilderrahmen hinzu und wenden darauf eine Animation an.
### **VSTO 2008 Beispiel**
Verwenden Sie VSTO 2008 und führen Sie die folgenden Schritte aus:
1. Erstellen Sie eine Präsentation.
1. Fügen Sie eine leere Folie hinzu.
1. Fügen Sie der Folie ein Bild-Shape hinzu.
1. Wenden Sie eine Animation auf das Bild an.
1. Speichern Sie die Präsentation auf dem Datenträger.

**Die Ergebnispräsentation, erstellt mit VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)
```c#
//Leere Präsentation erstellen
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Füge eine leere Folie hinzu
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Füge Bilderrahmen hinzu
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Animation auf den Bilderrahmen anwenden
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Präsentation speichern
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Aspose.Slides for .NET Beispiel**
Verwenden Sie Aspose.Slides for .NET und führen Sie die folgenden Schritte aus:
1. Erstellen Sie eine Präsentation.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Bild zu einer Bilderkollektion hinzu.
1. Fügen Sie der Folie ein Bild-Shape hinzu.
1. Wenden Sie eine Animation auf das Bild an.
1. Speichern Sie die Präsentation auf dem Datenträger.

**Die Ergebnispräsentation, erstellt mit Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)
```c#
// Leere Präsentation erstellen
using (Presentation pres = new Presentation())
{
    // Zugriff auf die erste Folie
    ISlide slide = pres.Slides[0];

    // Bild zur Bildsammlung der Präsentation hinzufügen
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Bildrahmen hinzufügen, dessen Höhe und Breite der des Bildes entsprechen
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Hauptanimationssequenz der Folie abrufen
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Flug von links-Animationseffekt zum Bildrahmen hinzufügen
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Präsentation speichern
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```
