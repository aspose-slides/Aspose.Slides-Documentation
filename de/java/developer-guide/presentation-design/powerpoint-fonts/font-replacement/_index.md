---
title: Schriftartenersetzung - PowerPoint Java API
linktitle: Schriftartenersetzung
type: docs
weight: 60
url: /de/java/font-replacement/
description: Erfahren Sie, wie Sie Schriftarten mit der expliziten Ersetzungs-methode in PowerPoint mithilfe der Java API ersetzen.
---

Wenn Sie Ihre Meinung zu einer Schriftart ändern, können Sie diese Schriftart durch eine andere ersetzen. Alle Instanzen der alten Schriftart werden durch die neue Schriftart ersetzt.

Aspose.Slides ermöglicht es Ihnen, eine Schriftart auf folgende Weise zu ersetzen:

1. Laden Sie die entsprechende Präsentation.
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart.
4. Ersetzen Sie die Schriftart.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code demonstriert die Schriftartenersetzung:

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

Um Regeln festzulegen, die bestimmen, was in bestimmten Bedingungen passiert (wenn eine Schriftart beispielsweise nicht zugegriffen werden kann), siehe [**Schriftartsubstitution**](/slides/de/java/font-substitution/). 

{{% /alert %}}