---
title: Standard-Präsentationsschriftarten in .NET angeben
linktitle: Standard-Schriftart
type: docs
weight: 30
url: /de/net/default-font/
keywords:
- Standard-Schriftart
- Reguläre Schriftart
- Normale Schriftart
- Asiatische Schriftart
- PDF-Export
- XPS-Export
- Bild-Export
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Legen Sie Standard-Schriftarten in Aspose.Slides für .NET fest, um eine ordnungsgemäße Konvertierung von PowerPoint (PPT, PPTX) und OpenDocument (ODP) nach PDF, XPS und Bildern zu gewährleisten."
---

## **Verwendung von Standardschriften zum Rendern von Präsentationen**
Aspose.Slides ermöglicht das Festlegen der Standardschrift für das Rendern der Präsentation zu PDF, XPS oder Miniaturansichten. Dieser Artikel zeigt, wie man DefaultRegularFont und DefaultAsianFont definiert, um sie als Standardschriften zu verwenden. Bitte folgen Sie den untenstehenden Schritten, um Schriften aus externen Verzeichnissen mit der Aspose.Slides für .NET API zu laden:

1. Erstellen Sie eine Instanz von LoadOptions.
1. Setzen Sie den DefaultRegularFont auf die gewünschte Schrift. Im folgenden Beispiel habe ich Wingdings verwendet.
1. Setzen Sie den DefaultAsianFont auf die gewünschte Schrift. Im folgenden Beispiel habe ich Wingdings verwendet.
1. Laden Sie die Präsentation mit Presentation und den festgelegten Ladeoptionen.
1. Erzeugen Sie nun die Folien‑Miniatur, das PDF und XPS, um die Ergebnisse zu überprüfen.

Die Implementierung des oben Genannten ist unten angegeben.
```c#
// Verwenden Sie die Ladeoptionen, um die Standard‑Schriftarten für reguläre und asiatische Texte festzulegen
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

Sie nehmen an der Rendering‑Pipeline für alle unterstützten Ausgaben teil. Dies umfasst Folien‑Miniaturansichten, [PDF](/slides/de/net/convert-powerpoint-to-pdf/), [XPS](/slides/de/net/convert-powerpoint-to-xps/), [Rasterbilder](/slides/de/net/convert-powerpoint-to-png/), [HTML](/slides/de/net/convert-powerpoint-to-html/), und [SVG](/slides/de/net/render-a-slide-as-an-svg-image/), da Aspose.Slides dieselbe Layout‑ und Glyph‑Auflösungslogik für diese Ziele verwendet.

**Werden Standardschriften angewendet, wenn man einfach ein PPTX liest und speichert, ohne zu rendern?**

Nein. Standardschriften sind relevant, wenn Text gemessen und gezeichnet werden muss. Ein reines Öffnen‑und‑Speichern einer Präsentation ändert weder die gespeicherten Schriftläufe noch die Dateistruktur. Standardschriften kommen bei Vorgängen zum Tragen, die Text rendern oder neu fließen lassen.

**Wenn ich eigene Schriftordner hinzufüge oder Schriften aus dem Speicher bereitstelle, werden sie bei der Auswahl der Standardschriften berücksichtigt?**

Ja. [Benutzerdefinierte Schriftquellen](/slides/de/net/custom-font/) erweitern den Katalog der verfügbaren Schriftfamilien und Glyphen, die die Engine nutzen kann. Standardschriften und alle [Fallback‑Regeln](/slides/de/net/fallback-font/) werden zuerst anhand dieser Quellen aufgelöst, was auf Servern und in Containern für eine zuverlässigere Abdeckung sorgt.

**Beeinflussen Standardschriften Textmetriken (Kerning, Vorstufen) und damit Zeilenumbrüche und Textumbruch?**

Ja. Das Ändern der Schriftart ändert die Glyphmetriken und kann während des Renderns Zeilenumbrüche, Umbrüche und die Seitennummerierung verändern. Für Layout‑Stabilität sollten Sie [die Originalschriften einbetten](/slides/de/net/embedded-font/) oder metrisch kompatible Standard‑ und Fallback‑Familien auswählen.

**Gibt es einen Grund, Standardschriften festzulegen, wenn alle in der Präsentation verwendeten Schriften eingebettet sind?**

Oft ist das nicht nötig, da [eingebettete Schriften](/slides/de/net/embedded-font/) bereits ein konsistentes Erscheinungsbild gewährleisten. Standardschriften sind dennoch nützlich als Sicherheitsnetz für Zeichen, die vom eingebetteten Teil nicht abgedeckt werden, oder wenn eine Datei eingebetteten und nicht eingebetteten Text mischt.