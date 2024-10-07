---
title: Schriftart ersetzen - PowerPoint Java API
linktitle: Schriftart ersetzen
type: docs
weight: 60
url: /androidjava/font-replacement/
description: Erfahren Sie, wie Sie Schriftarten mit der expliziten Ersetzungsfunktion in PowerPoint mit der Java-API ersetzen können.
---

Wenn Sie Ihre Meinung über die Verwendung einer Schriftart ändern, können Sie diese Schriftart durch eine andere ersetzen. Alle Instanzen der alten Schriftart werden durch die neue Schriftart ersetzt.

Aspose.Slides ermöglicht es Ihnen, eine Schriftart auf diese Weise zu ersetzen:

1. Laden Sie die relevante Präsentation.
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart.
4. Ersetzen Sie die Schriftart.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code demonstriert das Ersetzen von Schriftarten:

```java
// Lädt eine Präsentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Lädt die Quellschriftart, die ersetzt werden soll
    IFontData sourceFont = new FontData("Arial");
    
    // Lädt die neue Schriftart
    IFontData destFont = new FontData("Times New Roman");
    
    // Ersetzt die Schriftarten
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Speichert die Präsentation
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Hinweis" color="warning" %}} 

Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen passiert (zum Beispiel, wenn eine Schriftart nicht zugänglich ist), siehe [**Schriftartsubstitution**](/slides/androidjava/font-substitution/).

{{% /alert %}}