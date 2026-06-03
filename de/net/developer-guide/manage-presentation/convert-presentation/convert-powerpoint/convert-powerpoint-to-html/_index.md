---
title: PowerPoint-Präsentationen in .NET zu HTML konvertieren
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/net/convert-powerpoint-to-html/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu HTML
- Präsentation zu HTML
- Folie zu HTML
- PPT zu HTML
- PPTX zu HTML
- PowerPoint als HTML speichern
- Präsentation als HTML speichern
- Folie als HTML speichern
- PPT als HTML speichern
- PPTX als HTML speichern
- PPT nach HTML exportieren
- PPTX nach HTML exportieren
- .NET
- C#
- Aspose.Slides
description: "PowerPoint-Präsentationen in .NET zu HTML konvertieren. Verwenden Sie Aspose.Slides, um PPT- und PPTX-Dateien, ausgewählte Folien, Notizen, Schriftarten, Bilder, SVG und Medien zu exportieren."
---
## **Übersicht**

Aspose.Slides für .NET kann PowerPoint‑Präsentationen als HTML speichern, ohne Microsoft PowerPoint zu benötigen. Die grundlegende Konvertierung besteht aus einem einzelnen Laden einer [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) und einem Aufruf von [Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/) mit [SaveFormat](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/). Verwenden Sie [HtmlOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/htmloptions/), wenn Sie das exportierte Layout, Schriftarten, Bilder, Notizen, Kommentare, SVG‑Ausgabe oder verknüpfte Ressourcen steuern müssen.

Dieser Leitfaden konzentriert sich auf praktische HTML‑Export‑Szenarien:

- Exportieren einer gesamten Präsentation oder ausgewählter Folien.
- Erzeugen von HTML mit festem Layout, responsive Layout oder auf SVG basierend.
- Einbinden von Rednernotizen und Kommentaren.
- Steuern der Bildqualität und der zugeschnittenen Bilddaten.
- Einbetten von Schriftarten oder getrenntes Speichern von Schriftdateien.
- Auswählen, wie externe Ressourcen und Mediendidateien geschrieben und referenziert werden.

Standardmäßig erzeugt der HTML‑Export ein eigenständiges HTML‑Dokument, in dem die meisten Ressourcen eingebettet sind. Das ist praktisch, um eine einzige Datei zu teilen, kann jedoch die Ausgabedatei vergrößern. Für die Web‑Veröffentlichung sollten Sie externe Ressourcen, eine niedrigere Bild‑DPI und das Einbetten nur jener Schriftarten in Betracht ziehen, die in der Zielumgebung nicht zuverlässig verfügbar sind.

## **Konvertieren einer Präsentation in HTML**

Um eine Präsentation nach HTML zu exportieren, laden Sie sie mit [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) und speichern Sie sie mit [SaveFormat.Html](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/).

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

Dieses Beispiel schreibt eine HTML‑Datei. Das Präsentationsobjekt wird durch die `using`‑Deklaration verworfen, wodurch Datei‑Handles und Rendering‑Ressourcen nach dem Export freigegeben werden.

## **Verwenden von HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/htmloptions/) ist die zentrale Konfigurationsklasse für den HTML‑Export. Häufige Einstellungen umfassen:

- `SlidesLayoutOptions`: fügt Notizen, Kommentare, Handzettel oder andere Layout‑Informationen hinzu.
- `HtmlFormatter`: ändert die HTML‑Dokumentenstruktur oder delegiert die Formatierung an einen Controller.
- `SlideImageFormat`: ändert die Darstellung der Folien, zum Beispiel als SVG.
- `PicturesCompression`: steuert Bild‑DPI und Ausgabengröße.
- `DeletePicturesCroppedAreas`: behält oder entfernt zugeschnittene Bilddaten.
- `SvgResponsiveLayout`: lässt exportierten SVG‑Inhalt an seinen Container anpassen.
- `ShowHiddenSlides`: schließt ausgeblendete Folien ein, wenn erforderlich.

Die folgenden Abschnitte zeigen die gängigsten Optionen einzeln, sodass Sie nur die Kombinationen auswählen können, die Ihr Workflow benötigt.

## **Ausgewählte Folien zu HTML konvertieren**

Die [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/)‑Überladung, die Foliennummern akzeptiert, verwendet 1‑basierte Folienpositionen. Die nachfolgende Schleife speichert jede Folie in einer separaten HTML‑Datei.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

Verwenden Sie dieses Muster