---
title: Standard-Schriftart - PowerPoint C# API
linktitle: Standard-Schriftart
type: docs
weight: 30
url: /de/net/default-font/
keywords:
- schriftart
- standard-schriftart
- präsentation rendern
- PowerPoint
- präsentation
- C#
- Csharp
- Aspose.Slides for .NET
description: Die PowerPoint C# API ermöglicht das Festlegen der Standardschriftart für das Rendern von Präsentationen zu PDF, XPS oder Miniaturbildern.
---

## **Standard-Schriftarten für die Darstellung von Präsentationen**
Aspose.Slides ermöglicht das Festlegen der Standardschriftart für die Darstellung der Präsentation als PDF, XPS oder Miniaturbilder. Dieser Artikel zeigt, wie man DefaultRegularFont und DefaultAsianFont definiert, um sie als Standardschriftarten zu verwenden. Bitte folgen Sie den nachstehenden Schritten, um Schriftarten aus externen Verzeichnissen mit der Aspose.Slides für .NET API zu laden:

1. Erstellen Sie eine Instanz von LoadOptions.
2. Setzen Sie DefaultRegularFont auf die gewünschte Schriftart. Im folgenden Beispiel habe ich Wingdings verwendet.
3. Setzen Sie DefaultAsianFont auf die gewünschte Schriftart. Ich habe im folgenden Beispiel Wingdings verwendet.
4. Laden Sie die Präsentation mit Presentation und den festgelegten Ladeoptionen.
5. Erzeugen Sie nun das Folien-Miniaturbild, PDF und XPS, um die Ergebnisse zu überprüfen.

Die Implementierung des oben Genannten ist unten dargestellt.
```c#
// Verwenden Sie die Ladeoptionen, um Standard-Schriftarten für reguläre und asiatische Zeichen festzulegen
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

**Was genau beeinflussen DefaultRegularFont und DefaultAsianFont—nur den Export oder auch Miniaturbilder, PDF, XPS, HTML und SVG?**

Sie sind Teil der Rendering‑Pipeline für alle unterstützten Ausgaben. Dazu gehören Folien‑Miniaturbilder, [PDF](/slides/de/net/convert-powerpoint-to-pdf/), [XPS](/slides/de/net/convert-powerpoint-to-xps/), [Rasterbilder](/slides/de/net/convert-powerpoint-to-png/), [HTML](/slides/de/net/convert-powerpoint-to-html/), und [SVG](/slides/de/net/render-a-slide-as-an-svg-image/), da Aspose.Slides dieselbe Layout‑ und Glyph‑Auflösungslogik für diese Ziele verwendet.

**Werden Standardschriftarten angewendet, wenn man einfach ein PPTX liest und speichert, ohne zu rendern?**

Nein. Standardschriftarten sind relevant, wenn Text gemessen und gezeichnet werden muss. Ein einfaches Öffnen‑und‑Speichern einer Präsentation ändert weder die gespeicherten Schriftlauf‑Informationen noch die Dateistruktur. Standardschriftarten kommen bei Vorgängen zum Einsatz, die Text rendern oder umfließen.

**Wenn ich eigene Schriftordner hinzufüge oder Schriftarten aus dem Speicher bereitstelle, werden sie bei der Auswahl der Standardschriftarten berücksichtigt?**

Ja. [Benutzerdefinierte Schriftquellen](/slides/de/net/custom-font/) erweitern den Katalog verfügbarer Familien und Glyphen, die die Engine nutzen kann. Standardschriftarten und alle [Fallback‑Regeln](/slides/de/net/fallback-font/) werden zunächst gegen diese Quellen aufgelöst, wodurch auf Servern und in Containern eine zuverlässigere Abdeckung gewährleistet wird.

**Werden Standardschriftarten Textmetriken (Kerning, Vorwärtswerte) und damit Zeilenumbrüche und Textumfluss beeinflussen?**

Ja. Das Ändern der Schriftart verändert die Glyphenmetriken und kann Zeilenumbrüche, Umfluss und Paginierung beim Rendern beeinflussen. Für Layout‑Stabilität sollten Sie [die Originalschriftarten einbetten](/slides/de/net/embedded-font/) oder metrisch kompatible Standard‑ und Fallback‑Familien auswählen.

**Gibt es irgendeinen Nutzen, Standardschriftarten festzulegen, wenn alle in der Präsentation verwendeten Schriftarten eingebettet sind?**

Oft ist dies nicht nötig, da [eingebettete Schriftarten](/slides/de/net/embedded-font/) bereits ein konsistentes Erscheinungsbild gewährleisten. Standardschriftarten sind jedoch als Sicherheitsnetz für Zeichen nützlich, die nicht im eingebetteten Subset enthalten sind, oder wenn eine Datei eingebetteten und nicht eingebetteten Text kombiniert.