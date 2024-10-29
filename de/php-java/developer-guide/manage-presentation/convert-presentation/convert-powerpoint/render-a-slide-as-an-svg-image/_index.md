---
title: Eine Folie als SVG-Bild rendern
type: docs
weight: 50
url: /de/php-java/render-a-slide-as-an-svg-image/
---

SVG—eine Abkürzung für Scalable Vector Graphics—ist ein Standardgrafiktyp oder -format, das verwendet wird, um zweidimensionale Bilder zu rendern. SVG speichert Bilder als Vektoren in XML mit Details, die ihr Verhalten oder Aussehen definieren.

SVG ist eines der wenigen Formate für Bilder, das sehr hohe Standards in diesen Bereichen erfüllt: Skalierbarkeit, Interaktivität, Leistung, Barrierefreiheit, Programmierbarkeit und andere. Aus diesen Gründen wird es häufig in der Webentwicklung eingesetzt.

Sie möchten möglicherweise SVG-Dateien verwenden, wenn Sie

- **Ihre Präsentation in einem *sehr großen Format* drucken möchten.** SVG-Bilder können auf jede Auflösung oder jedes Level skaliert werden. Sie können SVG-Bilder so oft wie nötig in der Größe ändern, ohne die Qualität zu opfern.
- **Diagramme und Grafiken aus Ihren Folien in *verschiedenen Medien oder Plattformen* verwenden möchten.** Die meisten Leser können SVG-Dateien interpretieren.
- **die *kleinsten möglichen Bildgrößen* verwenden möchten.** SVG-Dateien sind im Allgemeinen kleiner als ihre hochauflösenden Pendants in anderen Formaten, insbesondere in bitmapbasierten Formaten (JPEG oder PNG).

Aspose.Slides für PHP über Java ermöglicht es Ihnen, Folien in Ihren Präsentationen als SVG-Bilder zu exportieren. Gehen Sie die folgenden Schritte durch, um SVG-Bilder zu generieren:

1. Erstellen Sie eine Instanz der Presentation-Klasse.
2. Iterieren Sie durch alle Folien in der Präsentation.
3. Schreiben Sie jede Folie in ihre eigene SVG-Datei über FileOutputStream.

{{% alert color="primary" %}} 

Sie möchten vielleicht unsere [kostenlose Webanwendung](https://products.aspose.app/slides/conversion/ppt-to-svg) ausprobieren, in der wir die PPT-zu-SVG-Konvertierungsfunktion aus Aspose.Slides für PHP über Java implementiert haben.

{{% /alert %}} 

Dieser Beispielcode zeigt Ihnen, wie Sie PPT in SVG mit Aspose.Slides umwandeln:

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $fileStream = new Java("java.io.FileOutputStream", "slide-" . $index . ".svg");
      try {
        $slide->writeAsSvg($fileStream);
      } finally {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```