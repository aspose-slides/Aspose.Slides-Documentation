---
title: Schriftart ersetzen - PowerPoint C# API
linktitle: Schriftart ersetzen
type: docs
weight: 60
url: /de/net/font-replacement/
keywords: "Schriftart, Schriftart ersetzen, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: Mit der C# PowerPoint API können Sie eine Schriftart explizit durch eine andere Schriftart in der Präsentation ersetzen.
---

Wenn Sie Ihre Meinung über die Verwendung einer Schriftart ändern, können Sie diese Schriftart durch eine andere ersetzen. Alle Instanzen der alten Schriftart werden durch die neue Schriftart ersetzt.

Aspose.Slides ermöglicht es Ihnen, eine Schriftart auf diese Weise zu ersetzen:

1. Laden Sie die relevante Präsentation.
2. Laden Sie die zu ersetzende Schriftart.
3. Laden Sie die neue Schriftart.
4. Ersetzen Sie die Schriftart.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code demonstriert die Schriftart-Ersetzung:

```c#
// Lädt eine Präsentation
Presentation presentation = new Presentation("Fonts.pptx");

// Lädt die Quellschriftart, die ersetzt wird
IFontData sourceFont = new FontData("Arial");

// Lädt die neue Schriftart
IFontData destFont = new FontData("Times New Roman");

// Ersetzt die Schriftarten
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Speichert die Präsentation
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="Hinweis" color="warning" %}} 

Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen passiert (wenn eine Schriftart beispielsweise nicht zugänglich ist), siehe [**Schriftartsubstitution**](/slides/de/net/font-substitution/). 

{{% /alert %}}