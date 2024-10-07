---
title: PowerPoint in animiertes GIF umwandeln
type: docs
weight: 65
url: /php-java/convert-powerpoint-to-animated-gif/
keywords: "PowerPoint in animiertes GIF umwandeln, PPT in GIF, PPTX in GIF"
description: "PowerPoint in animiertes GIF umwandeln: PPT in GIF, PPTX in GIF, mit der Aspose.Slides API."
---

## Präsentationen in animiertes GIF mit den Standardeinstellungen umwandeln ##

Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation mit den Standardeinstellungen in animiertes GIF umwandeln:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Das animierte GIF wird mit den Standardparametern erstellt.

{{%  alert  title="TIPP"  color="primary"  %}} 

Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die [GifOptions](https://reference.aspose.com/slides/php-java/aspose.slides/GifOptions) Klasse verwenden. Siehe den Beispielcode unten.

{{% /alert %}} 

## Präsentationen in animiertes GIF mit benutzerdefinierten Einstellungen umwandeln ##
Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in animiertes GIF umwandeln:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// die Größe des resultierenden GIF

    $gifOptions->setDefaultDelay(2000);// wie lange jede Folie angezeigt wird, bevor zur nächsten gewechselt wird

    $gifOptions->setTransitionFps(35);// FPS erhöhen, um die Qualität der Übergangsanimation zu verbessern

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}

Sie möchten vielleicht den kostenlosen [Text zu GIF](https://products.aspose.app/slides/text-to-gif) Konverter ausprobieren, der von Aspose entwickelt wurde.

{{% /alert %}}