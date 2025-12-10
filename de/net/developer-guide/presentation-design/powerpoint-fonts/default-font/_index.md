---
title: Standard-Schriften für Präsentationen in .NET festlegen
linktitle: Standard-Schrift
type: docs
weight: 30
url: /de/net/default-font/
keywords:
- Standard-Schrift
- Reguläre Schrift
- Normale Schrift
- Asiatische Schrift
- PDF-Export
- XPS-Export
- Bildexport
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Standard-Schriften in Aspose.Slides für .NET festlegen, um eine korrekte Konvertierung von PowerPoint (PPT, PPTX) und OpenDocument (ODP) nach PDF, XPS und Bildern zu gewährleisten."
---

## **Standard-Schriften für die Darstellung einer Präsentation verwenden**
Aspose.Slides ermöglicht das Festlegen der Standardschrift für die Darstellung der Präsentation als PDF, XPS oder Miniaturbilder. Dieser Artikel zeigt, wie DefaultRegularFont und DefaultAsianFont als Standardschriften definiert werden. Bitte folgen Sie den nachstehenden Schritten, um Schriften aus externen Verzeichnissen mit der Aspose.Slides für .NET API zu laden:

1. Erstellen Sie eine Instanz von LoadOptions.
1. Setzen Sie den DefaultRegularFont auf die gewünschte Schrift. Im folgenden Beispiel habe ich Wingdings verwendet.
1. Setzen Sie den DefaultAsianFont auf die gewünschte Schrift. Ich habe Wingdings im nachfolgenden Beispiel verwendet.
1. Laden Sie die Präsentation mit Presentation und den Ladeoptionen.
1. Generieren Sie nun das Folien‑Miniaturbild, PDF und XPS, um die Ergebnisse zu überprüfen.

Die Implementierung des oben Gesagten ist unten dargestellt.
```c#
// Verwenden Sie die Ladeoptionen, um die Standard-Schriftart für reguläre und asiatische Schriften festzulegen
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```


## **FAQ**

**Was genau beeinflussen DefaultRegularFont und DefaultAsianFont – nur den Export oder auch Miniaturansichten, PDF, XPS, HTML und SVG?**

Sie nehmen an der Rendering-Pipeline für alle unterstützten Ausgaben teil. Das umfasst Folien‑Miniaturansichten, [PDF](/slides/de/net/convert-powerpoint-to-pdf/), [XPS](/slides/de/net/convert-powerpoint-to-xps/), [Raster‑Bilder](/slides/de/net/convert-powerpoint-to-png/), [HTML](/slides/de/net/convert-powerpoint-to-html/), und [SVG](/slides/de/net/render-a-slide-as-an-svg-image/), weil Aspose.Slides dieselbe Layout‑ und Glyph‑Auflösungslogik für diese Ziele verwendet.

**Werden Standardschriften angewendet, wenn man einfach ein PPTX einliest und speichert, ohne zu rendern?**

Nein. Standardschriften sind relevant, wenn Text gemessen und gezeichnet werden muss. Ein reines Öffnen‑und‑Speichern einer Präsentation ändert weder die gespeicherten Schriftlauf‑Runs noch die Dateistruktur. Standardschriften kommen bei Vorgängen zum Tragen, die Text rendern oder umfließen lassen.

**Wenn ich eigene Schriftordner hinzufüge oder Schriften aus dem Speicher bereitstelle, werden sie bei der Auswahl der Standardschriften berücksichtigt?**

Ja. [Custom font sources](/slides/de/net/custom-font/) erweitern den Katalog verfügbarer Familien und Glyphen, die die Engine nutzen kann. Default‑Schriften und jede [fallback rules](/slides/de/net/fallback-font/) werden zuerst gegen diese Quellen aufgelöst, was auf Servern und in Containern für zuverlässigere Abdeckung sorgt.

**Beeinflussen Standardschriften die Textmetriken (Kerning, Advances) und damit Zeilenumbrüche und Zeilenumbruch?**

Ja. Das Ändern der Schrift ändert Glyph‑Metriken und kann Zeilenumbrüche, Zeilenumbruch und Seitennummerierung während des Renderings beeinflussen. Für Layout‑Stabilität sollten Sie [embed the original fonts](/slides/de/net/embedded-font/) oder metrisch kompatible Standard‑ und Fallback‑Familien wählen.

**Gibt es einen Sinn, Standardschriften zu setzen, wenn alle in der Präsentation verwendeten Schriften eingebettet sind?**

Oft ist das nicht nötig, weil [embedded fonts](/slides/de/net/embedded-font/) bereits ein konsistentes Erscheinungsbild gewährleisten. Standardschriften helfen dennoch als Sicherheitsnetz für Zeichen, die nicht vom eingebetteten Subset abgedeckt sind, oder wenn eine Datei eingebetteten und nicht eingebetteten Text mischt.