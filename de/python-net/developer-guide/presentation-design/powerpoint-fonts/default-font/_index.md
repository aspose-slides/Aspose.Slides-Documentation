---
title: Standard-Schriften in Präsentationen mit Python anpassen
linktitle: Standard-Schriftart
type: docs
weight: 30
url: /de/python-net/default-font/
keywords:
- Standardschriftart
- normale Schriftart
- normale Schriftart
- asiatische Schriftart
- PDF-Export
- XPS-Export
- Bildexport
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Standard-Schriften in Aspose.Slides für Python festlegen, um eine korrekte Konvertierung von PowerPoint (PPT, PPTX) und OpenDocument (ODP) zu PDF, XPS und Bildern sicherzustellen."
---

## **Verwendung von Standard-Schriften beim Rendern von Präsentationen**
Aspose.Slides ermöglicht das Festlegen der Standardschrift für das Rendern einer Präsentation zu PDF, XPS oder Miniaturbildern. Dieser Artikel zeigt, wie DefaultRegularFont und DefaultAsianFont als Standardschriften definiert werden. Bitte folgen Sie den nachstehenden Schritten, um Schriften aus externen Verzeichnissen zu laden, indem Sie Aspose.Slides für Python über die .NET‑API verwenden:

1. Erstellen Sie eine Instanz von LoadOptions.
2. Setzen Sie DefaultRegularFont auf die gewünschte Schrift. Im folgenden Beispiel habe ich Wingdings verwendet.
3. Setzen Sie DefaultAsianFont auf die gewünschte Schrift. In diesem Beispiel habe ich Wingdings verwendet.
4. Laden Sie die Präsentation mit Presentation und den angegebenen Ladevorgängen.
5. Erzeugen Sie nun das Folien‑Thumbnail, PDF und XPS, um die Ergebnisse zu überprüfen.

Die Implementierung des oben Gesagten wird unten gezeigt.

```py
import aspose.slides as slides

# Verwenden Sie Ladeoptionen, um die Standard‑reguläre und -asiatische Schrift festzulegen# Verwenden Sie Ladeoptionen, um die Standard‑reguläre und -asiatische Schrift festzulegen
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Laden Sie die Präsentation
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Folien‑Thumbnail generieren
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # PDF generieren
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # XPS generieren
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **FAQ**

**Was genau beeinflussen default_regular_font und default_asian_font – nur den Export oder auch Thumbnails, PDF, XPS, HTML und SVG?**

Sie sind Teil der Rendering‑Pipeline für alle unterstützten Ausgaben. Dazu gehören Folien‑Thumbnails, [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/de/python-net/convert-powerpoint-to-xps/), [Rasterbilder](/slides/de/python-net/convert-powerpoint-to-png/), [HTML](/slides/de/python-net/convert-powerpoint-to-html/), und [SVG](/slides/de/python-net/render-a-slide-as-an-svg-image/), weil Aspose.Slides dieselbe Layout‑ und Glyph‑Auflösungslogik für diese Ziele verwendet.

**Werden Standardschriften angewendet, wenn man ein PPTX nur liest und speichert, ohne zu rendern?**

Nein. Standardschriften sind relevant, wenn Text gemessen und gezeichnet werden muss. Ein einfaches Öffnen‑und‑Speichern einer Präsentation ändert weder die gespeicherten Schriftlauf‑Informationen noch die Dateistruktur. Standardschriften werden bei Vorgängen, die Text rendern oder umfließen lassen, verwendet.

**Wenn ich eigene Schriftordner hinzufüge oder Schriften aus dem Speicher bereitstelle, werden sie bei der Auswahl der Standardschriften berücksichtigt?**

Ja. [Benutzerdefinierte Schriftquellen](/slides/de/python-net/custom-font/) erweitern den Katalog verfügbarer Familien und Glyphen, die die Engine nutzen kann. Standardschriften und alle [Fallback‑Regeln](/slides/de/python-net/fallback-font/) werden zuerst gegen diese Quellen aufgelöst, was zu einer zuverlässigeren Abdeckung auf Servern und in Containern führt.

**Beeinflussen Standardschriften die Textmetriken (Kerning, Vorstufen) und damit Zeilenumbrüche und Umbruch?**

Ja. Das Ändern der Schriftart ändert die Glyphen‑Metriken und kann Zeilenumbrüche, Umbruch und Seitennummerierung beim Rendern beeinflussen. Für Layout‑Stabilität sollten Sie [die Originalschriften einbetten](/slides/de/python-net/embedded-font/) oder metrisch kompatible Standard‑ und Fallback‑Familien auswählen.

**Gibt es einen Grund, Standardschriften festzulegen, wenn alle in der Präsentation verwendeten Schriften eingebettet sind?**

Oft ist es nicht nötig, da [eingebettete Schriften](/slides/de/python-net/embedded-font/) bereits ein konsistentes Erscheinungsbild gewährleisten. Standardschriften dienen dennoch als Sicherheitsnetz für Zeichen, die nicht vom eingebetteten Subset abgedeckt sind, oder wenn eine Datei eingebetteten und nicht eingebetteten Text kombiniert.