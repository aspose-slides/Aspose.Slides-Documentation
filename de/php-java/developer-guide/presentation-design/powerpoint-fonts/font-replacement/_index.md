---
title: Schriftart ersetzen - PowerPoint Java API
linktitle: Schriftart ersetzen
type: docs
weight: 60
url: /de/php-java/font-replacement/
description: Erfahren Sie, wie Sie Schriftarten mit der expliziten Ersetzungsmethode in PowerPoint unter Verwendung der Java API ersetzen können.
---

Wenn Sie Ihre Meinung über die Verwendung einer Schriftart ändern, können Sie diese Schriftart durch eine andere ersetzen. Alle Instanzen der alten Schriftart werden durch die neue Schriftart ersetzt.

Aspose.Slides ermöglicht es Ihnen, eine Schriftart auf diese Weise zu ersetzen:

1. Laden Sie die relevante Präsentation.
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart.
4. Ersetzen Sie die Schriftart.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code demonstriert die Ersetzung von Schriftarten:

```php
  # Lädt eine Präsentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Lädt die Quellschriftart, die ersetzt werden soll
    $sourceFont = new FontData("Arial");
    # Lädt die neue Schriftart
    $destFont = new FontData("Times New Roman");
    # Ersetzt die Schriftarten
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Speichert die Präsentation
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Hinweis" color="warning" %}} 

Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen geschieht (wenn eine Schriftart beispielsweise nicht zugänglich ist), siehe [**Schriftartsubstitution**](/slides/de/php-java/font-substitution/).

{{% /alert %}}