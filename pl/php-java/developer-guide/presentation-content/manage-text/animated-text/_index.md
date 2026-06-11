---
title: Animowanie tekstu PowerPoint w PHP
linktitle: Animowany tekst
type: docs
weight: 60
url: /pl/php-java/animated-text/
keywords:
- animowany tekst
- animacja tekstu
- animowany akapit
- animacja akapitu
- efekt animacji
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Twórz dynamiczny animowany tekst w prezentacjach PowerPoint i OpenDocument, używając Aspose.Slides for PHP via Java, z łatwymi do śledzenia, zoptymalizowanymi przykładami kodu."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z animowanym tekstem w Aspose.Slides, stosując efekty animacji do poszczególnych akapitów oraz pobierając efekty już przypisane do akapitów w ramce tekstowej. Skupia się na metodach API używanych do dodawania animacji na poziomie akapitu oraz przeglądania istniejących efektów animacji akapitów w prezentacji.

## **Dodawanie efektów animacji do akapitów**

Dodaliśmy metodę [**addEffect()**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) do klasy [**Sequence**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Sequence). Metoda ta umożliwia dodanie efektów animacji do jednego akapitu. Poniższy przykładowy kod pokazuje, jak dodać efekt animacji do pojedynczego akapitu:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # wybierz akapit, aby dodać efekt
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # dodaj efekt animacji Fly do wybranego akapitu
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Pobieranie efektów animacji akapitów**

Możesz chcieć dowiedzieć się, jakie efekty animacji zostały dodane do akapitu — na przykład w jednej sytuacji chcesz pobrać efekty animacji w akapicie, ponieważ planujesz zastosować je w innym akapicie lub obiekcie.  

Aspose.Slides for PHP via Java umożliwia pobranie wszystkich efektów animacji zastosowanych do akapitów znajdujących się w ramce tekstowej (kształcie). Poniższy przykładowy kod pokazuje, jak uzyskać efekty animacji w akapicie:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **FAQ**

**Jak animacje tekstu różnią się od przejść slajdów i czy można je łączyć?**  

Animacje tekstu kontrolują zachowanie obiektu w czasie na slajdzie, podczas gdy [przejścia](/slides/pl/php-java/slide-transition/) sterują zmianą slajdów. Są niezależne i mogą być używane jednocześnie; kolejność odtwarzania jest określana przez oś czasu animacji oraz ustawienia przejść.

**Czy animacje tekstu są zachowywane przy eksporcie do PDF lub obrazów?**  

Nie. PDF i obrazy rastrowe są statyczne, więc zobaczysz pojedynczy stan slajdu bez ruchu. Aby zachować animację, użyj eksportu do [wideo](/slides/pl/php-java/convert-powerpoint-to-video/) lub [HTML](/slides/pl/php-java/export-to-html5/).

**Czy animacje tekstu działają w układach i w szablonie slajdu (masterze)?**  

Efekty zastosowane do obiektów układu/mastera są dziedziczone przez slajdy, ale ich synchronizacja i interakcja z animacjami na poziomie slajdu zależą od ostatecznej kolejności na slajdzie.