---
title: PowerPoint in TIFF mit Notizen konvertieren
type: docs
weight: 100
url: /de/php-java/convert-powerpoint-to-tiff-with-notes/
keywords: "PowerPoint in TIFF mit Notizen konvertieren"
description: "PowerPoint in TIFF mit Notizen in Aspose.Slides konvertieren."
---

## **PPT(X) im Notizen-Folien-Layout in TIFF konvertieren**
Die [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse kann verwendet werden, um die gesamte Präsentation im Notizen-Folien-Layout in TIFF zu konvertieren. Die folgenden Codebeispiele aktualisieren die Beispielpräsentation zu TIFF-Bildern im Notizen-Folien-Layout, wie unten gezeigt:

```php
//Erstellen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("demo.pptx");
  try {
    $opts = new TiffOptions();
    $opts->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Speichern der Präsentation als TIFF-Notizen
    $pres->save("Tiff-Notizen.tiff", SaveFormat::Tiff, $opts);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Die obigen Codebeispiele aktualisieren die Beispielpräsentation zu TIFF-Bildern im Notizen-Folien-Layout, wie unten gezeigt:

|**Die Quellpräsentationsansicht mit Foliennotizen**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**Das generierte TIFF-Bild im Notizen-Folien-Layout**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="Tipp" color="primary" %}}

Sie möchten vielleicht den Aspose [KOSTENLOSEN PowerPoint zu Poster-Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) ausprobieren.

{{% /alert %}}