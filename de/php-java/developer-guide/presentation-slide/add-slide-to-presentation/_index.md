---
title: Folie zur Präsentation hinzufügen
type: docs
weight: 10
url: /php-java/add-slide-to-presentation/
---

## **Folie zur Präsentation hinzufügen**
{{% alert color="primary" %}} 

Bevor wir über das Hinzufügen von Folien zu den Präsentationsdateien sprechen, lassen Sie uns einige Fakten über die Folien diskutieren. Jede PowerPoint-Präsentationsdatei enthält eine **Master / Layout**-Folie und andere **Normale** Folien. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides für PHP über Java nicht unterstützt werden. Jede Folie hat eine eindeutige ID und alle normalen Folien sind in einer Reihenfolge angeordnet, die durch den nullbasierten Index angegeben ist.

{{% /alert %}} 

Aspose.Slides für PHP über Java ermöglicht es Entwicklern, leere Folien zu ihrer Präsentation hinzuzufügen. Um eine leere Folie in die Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
- Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) Klasse, indem Sie eine Referenz zur [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) (Sammlung von Inhalt Folienobjekten) Eigenschaft festlegen, die vom [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Objekt bereitgestellt wird.
- Fügen Sie eine leere Folie am Ende der Sammlung der Inhaltsfolien hinzu, indem Sie die von [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) Objekt bereitgestellten [**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) Methoden aufrufen.
- Führen Sie einige Arbeiten mit der neu hinzugefügten leeren Folie durch.
- Schreiben Sie schließlich die Präsentationsdatei unter Verwendung des [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Objekts.

```php
  # Instanziieren Sie die Präsentationsklasse, die die Präsentationsdatei darstellt
  $pres = new Presentation();
  try {
    # Instanziieren Sie die SlideCollection-Klasse
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Fügen Sie eine leere Folie zur Folienkollektion hinzu
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Führen Sie einige Arbeiten an der neu hinzugefügten Folie durch
    # Speichern Sie die PPTX-Datei auf der Festplatte
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```