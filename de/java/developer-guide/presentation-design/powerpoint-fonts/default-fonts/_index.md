---
title: Standard Schriftarten - PowerPoint Java API
linktitle: Standard Schriftarten
type: docs
weight: 30
url: /java/default-font/
description: Die PowerPoint Java API ermöglicht es Ihnen, die Standardschriftart für das Rendern der Präsentation in PDF, XPS oder Miniaturansichten festzulegen. Dieser Artikel zeigt, wie Sie die StandardRegular Schriftart und die StandardAsian Schriftart als Standardschriftarten definieren können.
---


## **Verwendung von Standard Schriftarten zum Rendern von Präsentationen**
Aspose.Slides ermöglicht es Ihnen, die Standardschriftart für das Rendern der Präsentation in PDF, XPS oder Miniaturansichten festzulegen. Dieser Artikel zeigt, wie Sie die StandardRegular Schriftart und die StandardAsian Schriftart als Standardschriftarten definieren können. Bitte folgen Sie den folgenden Schritten, um Schriftarten aus externen Verzeichnissen mit der Aspose.Slides für Java API zu laden:

1. Erstellen Sie eine Instanz von [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions).
1. [Setzen Sie die DefaultRegularFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) auf Ihre gewünschte Schriftart. Im folgenden Beispiel habe ich Wingdings verwendet.
1. [Setzen Sie die DefaultAsianFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) auf Ihre gewünschte Schriftart. Ich habe in folgendem Beispiel Wingdings verwendet.
1. Laden Sie die Präsentation mit Presentation und den Ladeoptionen.
1. Generieren Sie nun die Miniaturansicht der Folie, PDF und XPS, um die Ergebnisse zu überprüfen.

Die Implementierung des Obigen ist unten dargestellt.

```java
// Verwenden Sie Ladeoptionen, um die Standard Schriftarten für Regular und Asian zu definieren
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Laden Sie die Präsentation
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Generieren Sie die Miniaturansicht der Folie
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