---
title: Präsentationen komprimieren
description: Reduzieren Sie die Größe von Präsentationen, indem Sie Bilder komprimieren und ungenutzte Inhalte entfernen.
type: docs
url: /de/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operationen
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Übersicht**

Komprimieren Sie Bilder, entfernen Sie beschnittene Bildbereiche, wenn sie nicht mehr benötigt werden, und wählen Sie die Komprimierungseinstellungen für die Präsentation vor dem Speichern. Das ist nützlich für Decks mit großen Fotos oder wiederholten Medien. Die eingesparte Menge hängt vom Inhalt und den von Ihnen gewählten Einstellungen ab.

## **Verwendungsbeispiel**

Dieses C#‑Beispiel lädt `input.pptx`, komprimiert die Präsentation und speichert sie als `compressed.pptx`.

Verwenden Sie Aspose.Slides für .NET 26.11 oder höher. Weitere Informationen zur Einrichtung finden Sie unter [Installieren Sie Aspose.Slides für .NET](/slides/de/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

<!-- visual-explanation:compress-presentations:start -->
[![Gleichmäßig skalierte Bilddarstellungen vor und nach der Komprimierung, gefolgt von gemessenen PPTX‑Dateigrößenbalken und gespeicherten Bildabmessungen.](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*Gemessen an einer synthetischen Detailgitter‑Vorrichtung: 584.030 → 128.323 Byte. Beide Darstellungen verwenden dieselbe Skalierung und einen 252 × 336‑Punkt‑Rahmen. Die Komprimierung entfernt die beschnittenen Ränder und reduziert das gespeicherte Bild auf 525 × 700 Pixel; die Einsparungen hängen vom Eingabebild ab.*  
<!-- visual-explanation:compress-presentations:end -->

## **FAQ**

### **Ist dies ein einzelner Optimierungsschalter für die gesamte Datei?**

Aspose.Slides für .NET 26.11 fügt [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/) hinzu, das das Entfernen unbenutzter Layouts/Master, das Subsetting eingebetteter Schriftarten und die 150‑DPI‑Bildkomprimierung kombiniert. Es entfernt dauerhaft beschnittene Bildbereiche. Für die Verarbeitung nur von Bildern verwenden Sie [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); für feinere Kontrolle siehe das [Beispiel zur Bildkompression einzelner Bilder](/slides/de/net/examples/optimization-batch/compression/). Seit Version 26.11 ist derselbe Aufruf für die gesamte Präsentation auch in Java, Node.js über Java, Python über .NET und C++ verfügbar. Das Beispiel und die Links auf dieser Seite beziehen sich auf .NET.

### **Ändert die Bildkomprimierung bearbeitbaren Text oder Diagramme?**

Die Bildkomprimierung wirkt sich nur auf Bilddaten aus, nicht auf bearbeitbaren Text oder Diagrammdaten. Überprüfen Sie die Bilder, da das Ändern der Größe oder eine erneute Komprimierung deren Details verringern kann.

### **Wie sollte ich eine Auflösung für Präsentationsbilder wählen?**

Wählen Sie ein Ziel basierend auf der angezeigten Bildgröße und der beabsichtigten Bildschirm‑ oder Druckverwendung. Behalten Sie bei großen Bildschirmen, Druck und detaillierten Diagrammen mehr Auflösung und vergleichen Sie das gerenderte Ergebnis, bevor Sie das Original verwerfen.

## **Anleitungen**

- [Gesamte Präsentation in .NET komprimieren](/slides/de/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Bildverwaltung in Präsentationen in .NET optimieren](/slides/de/net/image/)

Verwandte Funktion: [Entfernen nicht verwendeter Master, Layouts und Medien](/slides/de/features/remove-unused-content/).

## Ausführbare .NET‑Beispiele

- [Präsentationsgröße reduzieren](/slides/de/net/examples/optimization-batch/compression/)