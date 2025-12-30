---
title: Slide-Abschnitte in Präsentationen mit PHP verwalten
linktitle: Slide-Abschnitt
type: docs
weight: 90
url: /de/php-java/slide-section/
keywords:
- Abschnitt erstellen
- Abschnitt hinzufügen
- Abschnitt bearbeiten
- Abschnitt ändern
- Abschnittname
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Vereinfachen Sie Slide-Abschnitte in PowerPoint und OpenDocument mit Aspose.Slides für PHP via Java – teilen, umbenennen und neu anordnen, um PPTX- und ODP-Workflows zu optimieren."
---

Mit Aspose.Slides für PHP via Java können Sie eine PowerPoint‑Präsentation in Abschnitte gliedern. Sie können Abschnitte erstellen, die bestimmte Folien enthalten.

Sie möchten möglicherweise Abschnitte erstellen und sie verwenden, um Folien in einer Präsentation in logische Teile zu gliedern oder zu trennen, in folgenden Situationen:

- Wenn Sie an einer großen Präsentation mit anderen Personen oder einem Team arbeiten – und bestimmte Folien einem Kollegen oder einigen Teammitgliedern zuweisen müssen. 
- Wenn Sie eine Präsentation mit vielen Folien bearbeiten – und Schwierigkeiten haben, deren Inhalt auf einmal zu verwalten oder zu bearbeiten.

Idealerweise sollten Sie einen Abschnitt erstellen, der ähnliche Folien enthält – die Folien haben etwas Gemeinsames oder können anhand einer Regel in einer Gruppe zusammengefasst werden – und dem Abschnitt einen Namen geben, der die darin enthaltenen Folien beschreibt. 

## **Abschnitte in Präsentationen erstellen**

Um einen Abschnitt hinzuzufügen, der Folien in einer Präsentation enthält, stellt Aspose.Slides für PHP via Java die Methode [addSection()](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) bereit, mit der Sie den Namen des zu erstellenden Abschnitts und die Folie angeben können, bei der der Abschnitt beginnt.

Dieses Beispiel zeigt, wie Sie einen Abschnitt in einer Präsentation erstellen:
```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 wird bei newSlide2 beendet und danach startet section2

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Namen von Abschnitten ändern**

Nachdem Sie einen Abschnitt in einer PowerPoint‑Präsentation erstellt haben, können Sie beschließen, dessen Namen zu ändern. 

Dieses Beispiel zeigt, wie Sie den Namen eines Abschnitts in einer Präsentation mit Aspose.Slides ändern:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Werden Abschnitte beim Speichern im PPT‑Format (PowerPoint 97–2003) erhalten?**

Nein. Das PPT‑Format unterstützt keine Abschnitts‑Metadaten, sodass die Abschnitts‑Gruppierung beim Speichern als .ppt verloren geht.

**Kann ein ganzer Abschnitt „ausgeblendet“ werden?**

Nein. Nur einzelne Folien können ausgeblendet werden. Ein Abschnitt als Einheit besitzt keinen „ausgeblendet“-Zustand.

**Kann ich schnell einen Abschnitt anhand einer Folie finden und umgekehrt die erste Folie eines Abschnitts?**

Ja. Ein Abschnitt ist eindeutig durch seine Startfolie definiert; anhand einer Folie können Sie bestimmen, zu welchem Abschnitt sie gehört, und für einen Abschnitt können Sie seine erste Folie abrufen.