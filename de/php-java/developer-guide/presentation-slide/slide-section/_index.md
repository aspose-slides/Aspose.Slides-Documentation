---
title: Abschnitt Folie
type: docs
weight: 90
url: /php-java/slide-section/
---

Mit Aspose.Slides für PHP über Java können Sie eine PowerPoint-Präsentation in Abschnitte organisieren. Sie können Abschnitte erstellen, die spezifische Folien enthalten.

Möglicherweise möchten Sie Abschnitte erstellen und diese verwenden, um Folien in einer Präsentation in logische Teile zu organisieren oder zu unterteilen in diesen Situationen:

- Wenn Sie an einer großen Präsentation mit anderen Personen oder einem Team arbeiten und bestimmte Folien einem Kollegen oder einigen Teammitgliedern zuweisen müssen.
- Wenn Sie es mit einer Präsentation zu tun haben, die viele Folien enthält, und es Ihnen schwerfällt, den Inhalt gleichzeitig zu verwalten oder zu bearbeiten.

Idealerweise sollten Sie einen Abschnitt erstellen, der ähnliche Folien enthält – die Folien haben etwas gemeinsam oder können basierend auf einer Regel in einer Gruppe existieren – und dem Abschnitt einen Namen geben, der die darin enthaltenen Folien beschreibt.

## Abschnitte in Präsentationen erstellen

Um einen Abschnitt hinzuzufügen, der Folien in einer Präsentation beherbergt, bietet Aspose.Slides für PHP über Java die Methode [addSection()](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-), die es Ihnen ermöglicht, den Namen des Abschnitts anzugeben, den Sie erstellen möchten, und die Folie, von der der Abschnitt beginnt.

Dieser Beispielcode zeigt Ihnen, wie Sie einen Abschnitt in einer Präsentation erstellen:

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Abschnitt 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Abschnitt 2", $newSlide3);// section1 wird bei newSlide2 enden und danach wird section2 beginnen

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Letzter leerer Abschnitt");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Die Namen von Abschnitten ändern

Nachdem Sie einen Abschnitt in einer PowerPoint-Präsentation erstellt haben, möchten Sie möglicherweise seinen Namen ändern.

Dieser Beispielcode zeigt Ihnen, wie Sie den Namen eines Abschnitts in einer Präsentation mit Aspose.Slides ändern:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("Mein Abschnitt");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```