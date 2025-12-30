---
title: Folien zu Präsentationen in PHP hinzufügen
linktitle: Folie hinzufügen
type: docs
weight: 10
url: /de/php-java/add-slide-to-presentation/
keywords:
- Folie hinzufügen
- Folie erstellen
- leere Folie
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Fügen Sie Ihrer PowerPoint- und OpenDocument-Präsentation mithilfe von Aspose.Slides für PHP via Java ganz einfach Folien hinzu – nahtlose, effiziente Folieneinfügung in Sekunden."
---

## **Eine Folie zu einer Präsentation hinzufügen**
{{% alert color="primary" %}} 
Bevor wir über das Hinzufügen von Folien zu den Präsentationsdateien sprechen, lassen Sie uns einige Fakten über die Folien diskutieren. Jede PowerPoint-Präsentationsdatei enthält eine **Master-/Layout**-Folie und weitere **Normal**-Folien. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides für PHP via Java nicht unterstützt werden. Jede Folie hat eine eindeutige Id und alle Normal-Folien sind in einer Reihenfolge angeordnet, die durch den nullbasierten Index festgelegt wird.
{{% /alert %}} 

Aspose.Slides für PHP via Java ermöglicht Entwicklern das Hinzufügen leerer Folien zu ihrer Präsentation. Um eine leere Folie in der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection), indem Sie eine Referenz auf die Eigenschaft [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) (Sammlung von Inhalts-Slide-Objekten) setzen, die vom [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Objekt bereitgestellt wird.
- Fügen Sie der Präsentation am Ende der Inhalts-Folien-Sammlung eine leere Folie hinzu, indem Sie die Methoden [**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) aufrufen, die vom Objekt [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) bereitgestellt werden.
- Arbeiten Sie mit der neu hinzugefügten leeren Folie.
- Schreiben Sie schließlich die Präsentationsdatei mit dem [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Objekt.
```php
  # Instanziiere die Presentation-Klasse, die die Präsentationsdatei repräsentiert
  $pres = new Presentation();
  try {
    # Instanziiere die SlideCollection-Klasse
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Füge eine leere Folie zur Slides-Sammlung hinzu
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Führe einige Arbeiten mit der neu hinzugefügten Folie aus
    # Speichere die PPTX-Datei auf dem Datenträger
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **FAQ**

**Kann ich eine neue Folie an einer bestimmten Position einfügen, nicht nur am Ende?**

Ja. Die Bibliothek unterstützt Folien-Sammlungen und die [insert](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertclone/)-Operationen, sodass Sie eine Folie am gewünschten Index hinzufügen können, nicht nur am Ende.

**Werden beim Hinzufügen einer Folie basierend auf einem Layout das Theme/Styles beibehalten?**

Ja. Ein Layout erbt die Formatierung von seinem Master, und die neue Folie erbt vom ausgewählten Layout und dessen zugehörigem Master.

**Welche Folie ist in einer neuen „leeren“ Präsentation vorhanden, bevor Folien hinzugefügt werden?**

Eine neu erstellte Präsentation enthält bereits eine leere Folie mit Index null. Das ist bei der Berechnung von Einfüge-Indizes zu beachten.

**Wie wähle ich das „richtige“ Layout für eine neue Folie, wenn der Master viele Optionen hat?**

Wählen Sie im Allgemeinen das [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/)-Objekt, das der erforderlichen Struktur entspricht ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/php-java/aspose.slides/slidelayouttype/)). Wenn ein solches Layout fehlt, können Sie es dem Master [zum Master hinzufügen](/slides/de/php-java/slide-layout/) und anschließend verwenden.