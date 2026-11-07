---
title: Präsentationen komprimieren
description: Reduzieren Sie die Präsentationsgröße mit Bildkompression und speichern Sie Einstellungen.
type: docs
url: /de/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **Übersicht**

Komprimieren Sie Bilder, entfernen Sie zugeschnittene Bildbereiche, wenn sie nicht mehr benötigt werden, und wählen Sie Kompressionseinstellungen für die Präsentation vor dem Speichern. Dies ist nützlich für Präsentationen mit großen Fotos oder wiederholten Medien. Die eingesparte Menge hängt vom Inhalt und den von Ihnen gewählten Einstellungen ab.

## **Verwendungsbeispiel**

Dieses C#‑Beispiel verwendet Aspose.Slides für .NET. Es erzeugt sichtbar ein 1600 × 900 Pixel großes Farbverlauf‑PNG, fügt es in einen kleinen Bildrahmen ein und speichert *before.pptx*. Anschließend komprimiert es das Bild auf eine Zielauflösung von 96 DPI und speichert *compressed.pptx*. Vergleichen Sie beide Dateigrößen und Vorschaubilder: Die Einsparungen hängen vom Eingabebild und der angezeigten Größe ab.

Für die Einrichtung siehe [Aspose.Slides für .NET installieren](/slides/de/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **FAQ**

### **Ist dies ein einziger Optimierungsschalter für die gesamte Datei?**

Aspose.Slides für .NET 26.11 fügt [Compress.CompressPresentation](/slides/de/net/low-code-presentation-operations/#compress-the-whole-presentation) hinzu, das das Entfernen ungenutzter Layouts/Master, das Subsetting eingebetteter Schriftarten und die 150‑DPI‑Bildkompression kombiniert. Es entfernt dauerhaft zugeschnittene Bildbereiche. Für die reine Bildverarbeitung verwenden Sie Compress.CompressImages; für feinere Kontrolle behalten Sie den oben beschriebenen pro‑Bild‑Arbeitsablauf bei. Diese neuen Hilfsfunktionen sind spezifisch für die genannte .NET‑Version; prüfen Sie die entsprechende Anleitung für andere SDKs.

### **Verändert die Bildkompression bearbeitbaren Text oder Diagramme?**

Die Bildkompression zielt auf Bilddaten, nicht auf bearbeitbaren Text oder Diagrammdaten. Überprüfen Sie die Bilder, da eine Größenänderung oder Neukompression deren Details reduzieren kann.

### **Wie sollte ich eine Auflösung für Präsentationsbilder wählen?**

Wählen Sie ein Ziel basierend auf der angezeigten Bildgröße und dem geplanten Einsatz auf Bildschirmen oder im Druck. Behalten Sie für große Displays, Drucke und detailreiche Diagramme mehr Auflösung bei und vergleichen Sie das gerenderte Ergebnis, bevor Sie das Original verwerfen.

## **Anleitungen**

- [Optimieren der Bildverwaltung in Präsentationen in .NET](/slides/de/net/image/)

Verwandte Funktion: [Entfernen ungenutzter Master, Layouts und Medien](/slides/de/features/remove-unused-content/).

## Ausführbare .NET‑Beispiele

- [Präsentationsgröße reduzieren](/slides/de/net/examples/optimization-batch/compression/)