---
title: Standard Schriftart - PowerPoint C# API
linktitle: Standard Schriftart
type: docs
weight: 30
url: /net/default-font/
keywords: 
- schriftart
- standard schriftart
- präsentation rendern
- PowerPoint
- präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: Die PowerPoint C# API ermöglicht es Ihnen, die Standard Schriftart für das Rendern von Präsentationen als PDF, XPS oder Thumbnails festzulegen.
---

## **Verwendung von Standard Schriftarten für das Rendern von Präsentationen**
Aspose.Slides ermöglicht es Ihnen, die Standard Schriftart für das Rendern der Präsentation als PDF, XPS oder Thumbnails festzulegen. Dieser Artikel zeigt, wie Sie DefaultRegular Font und DefaultAsian Font als Standard Schriftarten definieren. Bitte befolgen Sie die folgenden Schritte, um Schriftarten aus externen Verzeichnissen mit der Aspose.Slides für .NET API zu laden:

1. Erstellen Sie eine Instanz von LoadOptions.
1. Setzen Sie die DefaultRegularFont auf Ihre gewünschte Schriftart. Im folgenden Beispiel habe ich Wingdings verwendet.
1. Setzen Sie die DefaultAsianFont auf Ihre gewünschte Schriftart. Ich habe Wingdings im folgenden Beispiel verwendet.
1. Laden Sie die Präsentation mit Presentation und dem Setzen der Ladeoptionen.
1. Generieren Sie nun das Folien-Thumnail, PDF und XPS, um die Ergebnisse zu überprüfen.

Die Implementierung des Obigen ist unten angegeben.

```c#
// Verwenden Sie die Ladeoptionen, um die Standard regulären und asiatischen Schriftarten anzugeben
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