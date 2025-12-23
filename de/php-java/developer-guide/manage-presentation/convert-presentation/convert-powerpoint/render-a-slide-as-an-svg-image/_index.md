---
title: Präsentationsfolien in PHP als SVG-Bilder rendern
linktitle: Folie zu SVG
type: docs
weight: 50
url: /de/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint zu SVG
- Präsentation zu SVG
- Folie zu SVG
- PPT zu SVG
- PPTX zu SVG
- PPT speichern als SVG
- PPTX speichern als SVG
- PPT exportieren zu SVG
- PPTX exportieren zu SVG
- Folie rendern
- Folie konvertieren
- Folie exportieren
- Vektorbild
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Folien mit Aspose.Slides für PHP via Java als SVG-Bilder rendern. Hochwertige Visualisierungen mit einfachen Codebeispielen."
---

## **SVG-Format**

SVG—ein Akronym für Scalable Vector Graphics—ist ein gängiger Grafiktyp oder -format zum Rendern zweidimensionaler Bilder. SVG speichert Bilder als Vektoren in XML mit Details, die ihr Verhalten oder Aussehen definieren.

SVG ist eines der wenigen Bildformate, das in diesen Punkten sehr hohe Standards erfüllt: Skalierbarkeit, Interaktivität, Leistung, Barrierefreiheit, Programmierbarkeit und weitere. Aus diesen Gründen wird es häufig in der Webentwicklung eingesetzt.

Sie wollen SVG‑Dateien verwenden, wenn Sie

- **Ihre Präsentation in einem *sehr großen Format* drucken.** SVG‑Bilder können auf jede Auflösung oder jedes Niveau skaliert werden. Sie können SVG‑Bilder beliebig oft ohne Qualitätsverlust vergrößern.
- **Diagramme und Grafiken aus Ihren Folien in *verschiedenen Medien oder Plattformen* verwenden.** Die meisten Leser können SVG‑Dateien interpretieren.
- **die *kleinstmöglichen Bildgrößen* nutzen.** SVG‑Dateien sind im Allgemeinen kleiner als ihre hochauflösenden Gegenstücke in anderen Formaten, insbesondere in bitmapbasierten Formaten (JPEG oder PNG).

## **Folie als SVG-Bild rendern**

Aspose.Slides für PHP via Java ermöglicht Ihnen, Folien in Ihren Präsentationen als SVG‑Bilder zu exportieren. Befolgen Sie diese Schritte, um SVG‑Bilder zu erzeugen:

1. Erstellen Sie eine Instanz der Klasse Presentation.
2. Durchlaufen Sie alle Folien in der Präsentation.
3. Schreiben Sie jede Folie in eine eigene SVG‑Datei über FileOutputStream.

{{% alert color="primary" %}} 

Vielleicht möchten Sie unsere [kostenlose Webanwendung](https://products.aspose.app/slides/conversion/ppt-to-svg) ausprobieren, in der wir die PPT‑zu‑SVG‑Konvertierungsfunktion von Aspose.Slides für PHP via Java implementiert haben.

{{% /alert %}} 

Dieser Beispielcode zeigt, wie Sie PPT mit Aspose.Slides in SVG konvertieren:
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


## **FAQ**

**Warum kann das resultierende SVG in verschiedenen Browsern unterschiedlich aussehen?**

Die Unterstützung bestimmter SVG‑Funktionen wird von den Browser‑Engines unterschiedlich implementiert. Die Parameter von [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) helfen, Inkompatibilitäten auszugleichen.

**Ist es möglich, nicht nur Folien, sondern auch einzelne Formen als SVG zu exportieren?**

Ja. Jede [Form kann als separates SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) gespeichert werden, was für Symbole, Piktogramme und die Wiederverwendung von Grafiken praktisch ist.

**Können mehrere Folien zu einem einzigen SVG (Strip/Dokument) kombiniert werden?**

Das Standardszenario ist Folie → SVG. Das Kombinieren mehrerer Folien zu einer einzigen SVG‑Leinwand ist ein Nachbearbeitungsschritt, der auf Anwendungsebene durchgeführt wird.