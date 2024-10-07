---
title: PowerPoint in Word konvertieren
type: docs
weight: 110
url: /php-java/convert-powerpoint-to-word/
keywords: "PowerPoint konvertieren, PPT, PPTX, Präsentation, Word, DOCX, DOC, PPTX in DOCX, PPT in DOC, PPTX in DOC, PPT in DOCX, Java, java, Aspose.Slides"
description: "Konvertieren Sie PowerPoint-Präsentationen in Word"
---

Wenn Sie planen, Textinhalte oder Informationen aus einer Präsentation (PPT oder PPTX) auf neue Weise zu nutzen, profitieren Sie möglicherweise davon, die Präsentation in Word (DOC oder DOCX) zu konvertieren.

* Im Vergleich zu Microsoft PowerPoint ist die Microsoft Word-App besser mit Tools oder Funktionen für Inhalte ausgestattet.
* Neben den Bearbeitungsfunktionen in Word können Sie auch von verbesserten Funktionen zur Zusammenarbeit, zum Drucken und zum Teilen profitieren.

{{% alert color="primary" %}} 

Sie möchten vielleicht unseren [**Online-Konverter von Präsentationen zu Word**](https://products.aspose.app/slides/conversion/ppt-to-word) ausprobieren, um zu sehen, was Sie aus der Arbeit mit Textinhalten aus Folien gewinnen könnten.

{{% /alert %}} 

## **Aspose.Slides und Aspose.Words**

Um eine PowerPoint-Datei (PPTX oder PPT) in Word (DOCX oder DOC) zu konvertieren, benötigen Sie sowohl [Aspose.Slides für PHP über Java](https://products.aspose.com/slides/php-java/) als auch [Aspose.Words für Java](https://products.aspose.com/words/php-java/).

Als eigenständige API bietet [Aspose.Slides](https://products.aspose.app/slides) für Java Funktionen, mit denen Sie Texte aus Präsentationen extrahieren können.

[Aspose.Words](https://docs.aspose.com/words/php-java/) ist eine fortschrittliche Dokumentenverarbeitungs-API, die es Anwendungen ermöglicht, Dateien zu generieren, zu modifizieren, zu konvertieren, zu rendern, zu drucken und andere Aufgaben mit Dokumenten auszuführen, ohne Microsoft Word zu nutzen.

## **PowerPoint in Word konvertieren**

1. Laden Sie die Bibliotheken [Aspose.Slides für PHP über Java](https://downloads.aspose.com/slides/java) und [Aspose.Words für Java](https://downloads.aspose.com/words/java) herunter.
2. Fügen Sie *aspose-slides-x.x-jdk16.jar* und *aspose-words-x.x-jdk16.jar* zu Ihrem CLASSPATH hinzu.
3. Verwenden Sie diesen Code-Ausschnitt, um die PowerPoint-Präsentation in Word zu konvertieren:

```php
  $pres = new Presentation($inputPres);
  try {
    $doc = new Document();
    $builder = new DocumentBuilder($doc);
    foreach($pres->getSlides() as $slide) {
      # generiert und fügt das Folienbild ein
      $bitmap = $slide->getThumbnail(1, 1);
      $builder->insertImage($bitmap);
      # fügt den Text der Folie ein
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $builder->writeln($shape->getTextFrame()->getText());
        }
      }
      $builder->insertBreak(BreakType::PAGE_BREAK);
    }
    $doc->save($outputDoc);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```