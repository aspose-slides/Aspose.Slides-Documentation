---
title: Standard-Schriftarten in Präsentationen mit Python anpassen
linktitle: Standard-Schriftart
type: docs
weight: 30
url: /de/python-net/default-font/
keywords:
- Standard-Schriftart
- Reguläre Schriftart
- Normale Schriftart
- Asiatische Schriftart
- PDF-Export
- XPS-Export
- Bildexport
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Legen Sie Standard-Schriftarten in Aspose.Slides für Python fest, um eine korrekte Konvertierung von PowerPoint (PPT, PPTX) und OpenDocument (ODP) zu PDF, XPS und Bildern sicherzustellen."
---

## **Verwendung von Standardschriften für das Rendern von Präsentationen**
Aspose.Slides ermöglicht das Festlegen der Standardschrift für das Rendern der Präsentation in PDF, XPS oder Miniaturansichten. Dieser Artikel zeigt, wie man DefaultRegularFont und DefaultAsianFont als Standardschriften definiert. Bitte folgen Sie den nachstehenden Schritten, um Schriftarten aus externen Verzeichnissen mit Aspose.Slides für Python via .NET‑API zu laden:

1. Erstellen Sie eine Instanz von LoadOptions.  
2. Setzen Sie DefaultRegularFont auf die gewünschte Schriftart. Im folgenden Beispiel habe ich Wingdings verwendet.  
3. Setzen Sie DefaultAsianFont auf die gewünschte Schriftart. Ich habe Wingdings im folgenden Beispiel verwendet.  
4. Laden Sie die Präsentation mit Presentation und den festgelegten Ladeoptionen.  
5. Erzeugen Sie nun die Folien‑Miniatur, PDF und XPS, um die Ergebnisse zu überprüfen.

```py
import aspose.slides as slides

# Verwenden Sie Ladeoptionen, um die Standard‑schriftarten (Regulär und Asiatisch) festzulegen# Verwenden Sie Ladeoptionen, um die Standard‑schriftarten (Regulär und Asiatisch) festzulegen
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Laden Sie die Präsentation
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Erzeugen Sie die Folien‑Miniatur
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # PDF generieren
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # XPS generieren
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```


## **FAQ**

**Was genau beeinflussen default_regular_font und default_asian_font – nur den Export oder auch Miniaturansichten, PDF, XPS, HTML und SVG?**

Sie wirken in der Rendering‑Pipeline für alle unterstützten Ausgaben mit. Dazu gehören Folien‑Miniaturansichten, [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/de/python-net/convert-powerpoint-to-xps/), [Rasterbilder](/slides/de/python-net/convert-powerpoint-to-png/), [HTML](/slides/de/python-net/convert-powerpoint-to-html/), und [SVG](/slides/de/python-net/render-a-slide-as-an-svg-image/), weil Aspose.Slides dieselbe Layout‑ und Glyphen‑Auflösungslogik für diese Ziele verwendet.

**Werden Standardschriften auch angewendet, wenn man einfach ein PPTX liest und speichert, ohne zu rendern?**

Nein. Standardschriften sind relevant, wenn Text gemessen und gezeichnet werden muss. Ein einfaches Öffnen‑und‑Speichern einer Präsentation ändert die gespeicherten Schriftlauf‑Informationen oder die Dateistruktur nicht. Standardschriften kommen bei Vorgängen zum Einsatz, die Text rendern oder neu layouten.

**Wenn ich eigene Schriftordner hinzufüge oder Schriftarten aus dem Speicher bereitstelle, werden sie bei der Auswahl der Standardschriften berücksichtigt?**

Ja. [Benutzerdefinierte Schriftquellen](/slides/de/python-net/custom-font/) erweitern den Katalog verfügbarer Familien und Glyphen, die die Engine nutzen kann. Standardschriften und alle [Fallback‑Regeln](/slides/de/python-net/fallback-font/) werden zunächst gegen diese Quellen aufgelöst, was zu einer zuverlässigeren Abdeckung auf Servern und in Containern führt.

**Beeinflussen Standardschriften die Textmetriken (Kerning, Vorstufen) und damit Zeilenumbrüche und Textumbruch?**

Ja. Das Ändern der Schriftart ändert die Glyphenmetriken und kann während des Renderns Zeilenumbrüche, Textumbruch und Seiteneinteilung verändern. Für Layout‑Stabilität sollten Sie [die Originalschriftarten einbetten](/slides/de/python-net/embedded-font/) oder metrisch kompatible Standard‑ und Fallback‑Familien wählen.

**Gibt es einen Sinn, Standardschriften festzulegen, wenn alle in der Präsentation verwendeten Schriftarten eingebettet sind?**

Oft ist das nicht nötig, weil [eingebettete Schriftarten](/slides/de/python-net/embedded-font/) bereits ein konsistentes Erscheinungsbild gewährleisten. Standardschriften dienen jedoch weiterhin als Sicherheitsnetz für Zeichen, die nicht im eingebetteten Subset enthalten sind, oder wenn eine Datei eingebetteten und nicht eingebetteten Text mischt.