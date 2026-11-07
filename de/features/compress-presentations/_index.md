---
title: Präsentationen komprimieren
description: Reduzieren Sie die Größe von Präsentationen durch Komprimieren von Bildern und Entfernen nicht verwendeter Inhalte.
type: docs
url: /de/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: Operationen
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Übersicht**

Komprimieren Sie Bilder, entfernen Sie beschnittene Bildbereiche, wenn sie nicht mehr benötigt werden, und wählen Sie die Komprimierungseinstellungen der Präsentation vor dem Speichern. Dies ist nützlich für Präsentationen mit großen Fotos oder wiederholten Medien. Der eingesparte Betrag hängt vom Inhalt und den von Ihnen gewählten Einstellungen ab.

## **Anwendungsbeispiel**

Dieses C#-Beispiel lädt `input.pptx`, komprimiert die Präsentation und speichert sie als `compressed.pptx`.

Verwenden Sie Aspose.Slides für .NET 26.11 oder höher. Weitere Informationen zur Einrichtung finden Sie unter [Install Aspose.Slides for .NET](/slides/de/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Ist dies ein einzelner Optimierungsschalter für die gesamte Datei?**

Aspose.Slides für .NET 26.11 fügt [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/) hinzu, das das Entfernen ungenutzter Layouts/Master, das Subsetten eingebetteter Schriftarten und die 150‑DPI‑Bildkomprimierung kombiniert. Es entfernt beschnittene Bildbereiche dauerhaft. Für die reine Bildverarbeitung verwenden Sie [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); für feinere Steuerung siehe das [individual-picture compression example](/slides/de/net/examples/optimization-batch/compression/). Diese neuen Helfer sind spezifisch für die genannte .NET‑Version; prüfen Sie die entsprechende Anleitung für andere SDKs.

### **Ändert die Bildkomprimierung bearbeitbaren Text oder Diagramme?**

Die Bildkomprimierung richtet sich ausschließlich an Bilddaten, nicht an bearbeitbaren Text oder Diagrammdaten. Überprüfen Sie die Bilder, da Größenänderungen oder erneute Komprimierung deren Details reduzieren können.

### **Wie sollte ich eine Auflösung für Präsentationsbilder wählen?**

Wählen Sie ein Ziel basierend auf der angezeigten Bildgröße und dem beabsichtigten Einsatz für Bildschirm oder Druck. Behalten Sie mehr Auflösung für große Displays, Druck und detaillierte Diagramme bei und vergleichen Sie das gerenderte Ergebnis, bevor Sie das Original verwerfen.

## **Leitfäden**

- [Compress the Whole Presentation in .NET](/slides/de/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Optimize Image Management in Presentations in .NET](/slides/de/net/image/)

Related feature: [Remove unused masters, layouts and media](/slides/de/features/remove-unused-content/).

## Ausführbare .NET-Beispiele

- [Reduce Presentation Size](/slides/de/net/examples/optimization-batch/compression/)