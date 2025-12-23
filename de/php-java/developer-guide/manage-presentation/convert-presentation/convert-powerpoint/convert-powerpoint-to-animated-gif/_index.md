---
title: PowerPoint-Präsentationen zu animierten GIFs in PHP konvertieren
linktitle: PowerPoint zu GIF
type: docs
weight: 65
url: /de/php-java/convert-powerpoint-to-animated-gif/
keywords:
- animiertes GIF
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu GIF
- Präsentation zu GIF
- Folie zu GIF
- PPT zu GIF
- PPTX zu GIF
- PPT als GIF speichern
- PPTX als GIF speichern
- PPT als GIF exportieren
- PPTX als GIF exportieren
- Standardeinstellungen
- benutzerdefinierte Einstellungen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Konvertieren Sie PowerPoint-Präsentationen (PPT, PPTX) mühelos in animierte GIFs mit Aspose.Slides für PHP über Java. Schnelle, hochqualitative Ergebnisse."
---

## **Präsentationen mit Standardeinstellungen in animiertes GIF konvertieren**

Dieser Beispielcode zeigt, wie Sie eine Präsentation mit Standard‑Einstellungen in ein animiertes GIF konvertieren:
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


Das animierte GIF wird mit den Standard‑Parametern erstellt. 

{{%  alert  title="TIP"  color="primary"  %}} 

Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die Klasse [GifOptions](https://reference.aspose.com/slides/php-java/aspose.slides/GifOptions) verwenden. Siehe den Beispielcode unten.

{{% /alert %}} 

## **Präsentationen mit benutzerdefinierten Einstellungen in animiertes GIF konvertieren**
Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in ein animiertes GIF konvertieren:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// die Größe des resultierenden GIFs

    $gifOptions->setDefaultDelay(2000);// wie lange jede Folie angezeigt wird, bis sie zur nächsten wechselt

    $gifOptions->setTransitionFps(35);// FPS erhöhen für bessere Übergangsanimationsqualität

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Info" color="info" %}}

Vielleicht möchten Sie den KOSTENLOSEN [Text-to-GIF](https://products.aspose.app/slides/text-to-gif)-Konverter von Aspose ausprobieren. 

{{% /alert %}}

## **FAQ**

**Was ist, wenn die in der Präsentation verwendeten Schriftarten nicht auf dem System installiert sind?**

Installieren Sie die fehlenden Schriftarten oder [konfigurieren Sie Ersatz‑Schriftarten](/slides/de/php-java/powerpoint-fonts/). Aspose.Slides ersetzt sie, jedoch kann das Aussehen abweichen. Für Brand‑Consistenz sollten die benötigten Schriftarten immer explizit verfügbar sein.

**Kann ich ein Wasserzeichen auf die GIF‑Frames legen?**

Ja. [Fügen Sie ein halbtransparentes Objekt/Logo](/slides/de/php-java/watermark/) zur Master‑Folien oder zu einzelnen Folien vor dem Export hinzu — das Wasserzeichen erscheint in jedem Frame.