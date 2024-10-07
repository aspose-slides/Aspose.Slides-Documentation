---
title: ODP in PPTX umwandeln
type: docs
weight: 10
url: /php-java/convert-odp-to-pptx/
---

## **ODP in PPTX/PPT-Präsentation umwandeln**
Aspose.Slides für PHP über Java bietet die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse, die eine Präsentationsdatei darstellt. Die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse kann nun auch über den [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) Konstruktor auf ODP zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie eine ODP-Präsentation in eine PPTX-Präsentation umgewandelt werden kann.

```php
// Öffne die ODP-Datei
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # Speichern der ODP-Präsentation im PPTX-Format
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Live-Beispiel**
Sie können die [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Web-App besuchen, die mit der **Aspose.Slides API** erstellt wurde. Die App zeigt, wie die Umwandlung von ODP in PPTX mit der Aspose.Slides API umgesetzt werden kann.