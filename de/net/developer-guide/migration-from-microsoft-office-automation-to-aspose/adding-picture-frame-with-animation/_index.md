---
title: Bildrahmen mit Animation hinzufügen mit VSTO und Aspose.Slides für .NET
linktitle: Bildrahmen mit Animation
type: docs
weight: 60
url: /de/net/adding-picture-frame-with-animation/
keywords:
- Bildrahmen
- Bild hinzufügen
- Bild einfügen
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
description: "Migrieren Sie von Microsoft Office-Automatisierung zu Aspose.Slides für .NET und animieren Sie Bildrahmen in PowerPoint (PPT, PPTX)-Folien mit sauberem C#-Code."
---
{{% alert color="info" %}} 

Bildrahmen werden auf Formen oder Bilder in Microsoft PowerPoint angewendet, um Bilder in einer Präsentation zu umrahmen. Dieser Artikel zeigt, wie ein Bildrahmen erstellt und programmgesteuert mit Animation versehen wird, zunächst mit [VSTO 2008](/slides/de/net/adding-picture-frame-with-animation/) und anschließend mit [Aspose.Slides for .NET](/slides/de/net/adding-picture-frame-with-animation/). Zuerst zeigen wir, wie man mit VSTO 2008 einen Rahmen und eine Animation anwendet. Anschließend zeigen wir, wie dieselben Schritte mit Aspose.Slides for .NET durchgeführt werden.

{{% /alert %}} 
## **Hinzufügen von Bildrahmen mit Animation**
Die nachstehenden Codebeispiele erstellen eine Präsentation mit einer Folie, fügen ein Bild mit einem Bildrahmen hinzu und wenden eine Animation darauf an.
### **VSTO 2008 Beispiel**
Mit VSTO 2008 führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Präsentation.
1. Fügen Sie eine leere Folie hinzu.
1. Fügen Sie der Folie eine Bildform hinzu.
1. Wenden Sie eine Animation auf das Bild an.
1. Schreiben Sie die Präsentation auf die Festplatte.

**Die Ausgabepäsentation, erstellt mit VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Leere Präsentation erstellen
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Leere Folie hinzufügen
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


### **Aspose.Slides for .NET Beispiel**
Mit Aspose.Slides for .NET führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Präsentation.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Bild zu einer Bildsammlung hinzu.
1. Fügen Sie der Folie eine Bildform hinzu.
1. Wenden Sie eine Animation auf das Bild an.
1. Schreiben Sie die Präsentation auf die Festplatte.

**Die Ausgabepäsentation, erstellt mit Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Leere Präsentation erstellen
using (Presentation pres = new Presentation())
{
    // Auf die erste Folie zugreifen
    ISlide slide = pres.Slides[0];

    // Bild zur Bildsammlung der Präsentation hinzufügen
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Bildrahmen hinzufügen, dessen Höhe und Breite der Höhe und Breite des Bildes entsprechen
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Hauptanimationssequenz der Folie abrufen
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Fly-from-Left-Animationseffekt zum Bildrahmen hinzufügen
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Präsentation speichern
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```