---
title: Standard-Schriften - PowerPoint Java API
linktitle: Standard-Schriften
type: docs
weight: 30
url: /de/androidjava/default-font/
description: PowerPoint Java API ermöglicht es Ihnen, die Standardschriftart für das Rendern der Präsentation in PDF, XPS oder Thumbnails festzulegen. Dieser Artikel zeigt, wie Sie die DefaultRegular-Schriftart und die DefaultAsian-Schriftart als Standardschriftarten definieren können.
---

## **Verwenden von Standardschriftarten für das Rendern der Präsentation**
Aspose.Slides ermöglicht es Ihnen, die Standardschriftart für das Rendern der Präsentation in PDF, XPS oder Thumbnails festzulegen. Dieser Artikel zeigt, wie Sie die DefaultRegular-Schriftart und die DefaultAsian-Schriftart definieren können, um sie als Standardschriftarten zu verwenden. Bitte befolgen Sie die folgenden Schritte, um Schriftarten aus externen Verzeichnissen mit Aspose.Slides für Android über die Java API zu laden:

1. Erstellen Sie eine Instanz von [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions).
1. [Setzen Sie die DefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) auf Ihre gewünschte Schriftart. Im folgenden Beispiel habe ich Wingdings verwendet.
1. [Setzen Sie die DefaultAsianFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) auf Ihre gewünschte Schriftart. Ich habe in folgendem Beispiel Wingdings verwendet.
1. Laden Sie die Präsentation unter Verwendung von Presentation und setzen Sie die Ladeoptionen.
1. Generieren Sie nun das Folien-Thumbnails, PDF und XPS, um die Ergebnisse zu überprüfen.

Die Implementierung des Obigen ist unten angegeben.

```java
// Verwenden Sie Ladeoptionen, um die Standard-Regular- und Asienschriftarten zu definieren
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Laden Sie die Präsentation
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Generieren Sie das Folien-Thumbnails
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // Speichern Sie das Bild auf der Festplatte.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Generieren Sie PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Generieren Sie XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```