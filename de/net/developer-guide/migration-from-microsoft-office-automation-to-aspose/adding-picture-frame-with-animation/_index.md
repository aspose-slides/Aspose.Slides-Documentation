---
title: Hinzufügen von Bildrahmen mit Animation mit VSTO und Aspose.Slides für .NET
linktitle: Bildrahmen mit Animation
type: docs
weight: 60
url: /de/net/adding-picture-frame-with-animation/
keywords:
- Bildrahmen
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
description: "Migrieren Sie von Microsoft Office-Automatisierung zu Aspose.Slides für .NET und animieren Sie Bildrahmen in PowerPoint-Folien (PPT, PPTX) mit sauberem C#-Code."
---

{{% alert color="primary" %}} 

Bildrahmen werden in Microsoft PowerPoint auf Formen oder Bilder angewendet, um Bilder in einer Präsentation zu rahmen. Dieser Artikel zeigt, wie man programmgesteuert einen Bildrahmen erstellt und Animationen darauf anwendet, zunächst mit [VSTO 2008](/slides/de/net/adding-picture-frame-with-animation/) und dann mit [Aspose.Slides for .NET](/slides/de/net/adding-picture-frame-with-animation/). Zuerst zeigen wir, wie man mit VSTO 2008 einen Rahmen und eine Animation anwendet. Anschließend zeigen wir, wie man dieselben Schritte mit Aspose.Slides for .NET ausführt.

{{% /alert %}} 
## **Hinzufügen von Bildrahmen mit Animation**
Die folgenden Codebeispiele erstellen eine Präsentation mit einer Folie, fügen ein Bild mit einem Bildrahmen hinzu und wenden Animationen darauf an.
### **VSTO 2008 Beispiel**
Verwenden Sie VSTO 2008 und führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Präsentation.
1. Fügen Sie eine leere Folie hinzu.
1. Fügen Sie der Folie ein Bildobjekt hinzu.
1. Wenden Sie eine Animation auf das Bild an.
1. Schreiben Sie die Präsentation auf die Festplatte.

**Die erzeugte Ausgabepräsentation, erstellt mit VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)
```c#
//Erstellen einer leeren Präsentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Hinzufügen einer leeren Folie
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Bildrahmen hinzufügen
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Animation auf Bildrahmen anwenden
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Präsentation speichern
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Aspose.Slides für .NET Beispiel**
Verwenden Sie Aspose.Slides für .NET und führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Präsentation.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Bild zu einer Bildsammlung hinzu.
1. Fügen Sie der Folie ein Bildobjekt hinzu.
1. Wenden Sie eine Animation auf das Bild an.
1. Schreiben Sie die Präsentation auf die Festplatte.

**Die erzeugte Ausgabepräsentation, erstellt mit Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)
```c#
// Erstelle eine leere Präsentation
using (Presentation pres = new Presentation())
{
    // Greife auf die erste Folie zu
    ISlide slide = pres.Slides[0];

    // Füge ein Bild zur Bildsammlung der Präsentation hinzu
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Füge einen Bildrahmen hinzu, dessen Höhe und Breite der Höhe und Breite des Bildes entsprechen
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Hole die Hauptanimationssequenz der Folie
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Füge den Fliegen‑von‑links‑Effekt zum Bildrahmen hinzu
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Speichere die Präsentation
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```
