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
description: "Fügen Sie Ihren PowerPoint- und OpenDocument‑Präsentationen ganz einfach Folien hinzu, indem Sie Aspose.Slides für PHP via Java verwenden – nahtloses, effizientes Einfügen von Folien in Sekundenschnelle."
---

## **Folie zu einer Präsentation hinzufügen**
{{% alert color="primary" %}} 

Bevor wir über das Hinzufügen von Folien zu den Präsentationsdateien sprechen, lassen Sie uns einige Fakten zu den Folien erläutern. Jede PowerPoint‑Präsentationsdatei enthält eine **Master‑/Layout‑**Folie und weitere **Normale** Folien. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides for PHP via Java nicht unterstützt werden. Jede Folie besitzt eine eindeutige Id und alle normalen Folien werden in einer Reihenfolge angeordnet, die durch den nullbasierten Index angegeben wird.

{{% /alert %}} 

Aspose.Slides for PHP via Java ermöglicht Entwicklern das Hinzufügen leerer Folien zu ihrer Präsentation. Um eine leere Folie in der Präsentation hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
- Rufen Sie das Objekt [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) ab, indem Sie die Methode [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) (Sammlung von Inhalts‑Slide‑Objekten) verwenden, die vom [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Objekt bereitgestellt wird.
- Fügen Sie der Präsentation am Ende der Inhalts‑Slide‑Sammlung eine leere Folie hinzu, indem Sie die Methode [**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addEmptySlide) auf dem [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/)‑Objekt aufrufen.
- Arbeiten Sie mit der neu hinzugefügten leeren Folie.
- Schreiben Sie schließlich die Präsentationsdatei mithilfe des [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Objekts.
```php
  # Instanziiere die Presentation-Klasse, die die Präsentationsdatei darstellt
  $pres = new Presentation();
  try {
    # Instanziiere die SlideCollection-Klasse
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Füge der Slides-Sammlung eine leere Folie hinzu
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Führe einige Arbeiten mit der neu hinzugefügten Folie aus
    # Speichere die PPTX-Datei auf der Festplatte
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **FAQ**

**Kann ich eine neue Folie an einer bestimmten Position einfügen, nicht nur am Ende?**

Ja. Die Bibliothek unterstützt Folien‑Sammlungen sowie die [insert](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertclone/)‑Operationen, sodass Sie eine Folie an dem gewünschten Index einfügen können, nicht nur am Ende.

**Werden die Design‑/Stile beibehalten, wenn man eine Folie basierend auf einem Layout hinzufügt?**

Ja. Ein Layout übernimmt die Formatierung von seinem Master, und die neue Folie übernimmt die des ausgewählten Layouts sowie dessen zugehörigen Masters.

**Welche Folie ist in einer neuen „leeren“ Präsentation vorhanden, bevor Folien hinzugefügt werden?**

Eine neu erstellte Präsentation enthält bereits eine leere Folie mit dem Index Null. Das ist wichtig zu berücksichtigen, wenn Einfüge‑Indizes berechnet werden.

**Wie wähle ich das „richtige“ Layout für eine neue Folie, wenn der Master viele Optionen hat?**

Wählen Sie in der Regel das [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) , das der gewünschten Struktur entspricht ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/php-java/aspose.slides/slidelayouttype/)). Wenn ein solches Layout fehlt, können Sie [add it to the master](/slides/de/php-java/slide-layout/) hinzufügen und anschließend verwenden.