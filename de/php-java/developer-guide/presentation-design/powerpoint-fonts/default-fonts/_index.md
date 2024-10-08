---
title: Standard-Schriften - PowerPoint Java API
linktitle: Standard-Schriften
type: docs
weight: 30
url: /de/php-java/default-font/
description: Die PowerPoint Java API ermöglicht es Ihnen, die Standardschriftart für das Rendern der Präsentation in PDF, XPS oder Thumbnails festzulegen. Dieser Artikel zeigt, wie Sie die StandardRegular Schriftart und die StandardAsian Schriftart als Standard-Schriftarten definieren.
---


## **Verwendung von Standard-Schriften zum Rendern von Präsentationen**
Aspose.Slides ermöglicht es Ihnen, die Standardschriftart für das Rendern der Präsentation in PDF, XPS oder Thumbnails festzulegen. Dieser Artikel zeigt, wie Sie die StandardRegular Schriftart und die StandardAsian Schriftart als Standard-Schriftarten definieren. Bitte folgen Sie den folgenden Schritten, um Schriftarten aus externen Verzeichnissen mithilfe von Aspose.Slides für PHP über die Java API zu laden:

1. Erstellen Sie eine Instanz von [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions).
2. [Setzen Sie die StandardRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) auf Ihre gewünschte Schriftart. Im folgenden Beispiel habe ich Wingdings verwendet.
3. [Setzen Sie die StandardAsianFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) auf Ihre gewünschte Schriftart. Ich habe in folgendem Beispiel Wingdings verwendet.
4. Laden Sie die Präsentation mithilfe von Presentation und den Ladeoptionen.
5. Generieren Sie nun das Folien-Thumbnails, PDF und XPS, um die Ergebnisse zu überprüfen.

Die Implementierung des obigen steht unten.

```php
  # Verwenden Sie Ladeoptionen, um die Standard-Regular- und Asian-Schriftarten zu definieren
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Laden Sie die Präsentation
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Generieren Sie das Folien-Thumbnails
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # Speichern Sie das Bild auf der Festplatte.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Generieren Sie PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # Generieren Sie XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```