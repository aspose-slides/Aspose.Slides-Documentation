---
title: Porównaj slajdy prezentacji w PHP
linktitle: Porównaj slajdy
type: docs
weight: 50
url: /pl/php-java/compare-slides/
keywords:
- porównaj slajdy
- porównanie slajdów
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Programowo porównuj prezentacje PowerPoint i OpenDocument za pomocą Aspose.Slides dla PHP poprzez Java. Szybko identyfikuj różnice między slajdami w kodzie."
---
## **Wprowadzenie**

Aspose.Slides umożliwia porównywanie slajdów, slajdów układu i slajdów wzorca przy użyciu metody `equals` udostępnionej przez klasę `BaseSlide`. Metoda ta zwraca `true`, gdy porównywane slajdy są identyczne pod względem struktury i statycznej zawartości.

## **Porównaj dwa slajdy**

Metoda Equals została dodana do klasy [BaseSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/BaseSlide). Zwraca ona true dla slajdów/układów i slajdów/wzorców, które są identyczne pod względem struktury i statycznej zawartości.

Dwa slajdy są równe, jeśli wszystkie kształty, style, teksty, animacje i inne ustawienia itp. są identyczne. Porównanie nie uwzględnia unikalnych identyfikatorów, np. SlideId, ani dynamicznej zawartości, np. bieżącej wartości daty w miejscu przechowywania daty.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```

## **FAQ**

**Czy fakt, że slajd jest ukryty, wpływa na porównanie samych slajdów?**

[Ukryty status](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/gethidden/) jest właściwością prezentacji/odtwarzania, a nie treścią wizualną. Równość dwóch konkretnych slajdów jest określana na podstawie ich struktury i statycznej zawartości; sam fakt, że slajd jest ukryty, nie sprawia, że slajdy są różne.

**Czy hiperłącza i ich parametry są brane pod uwagę?**

Tak. Hiperłącza są częścią statycznej zawartości slajdu. Jeśli adres URL lub akcja hiperłącza różni się, jest to zazwyczaj traktowane jako różnica w treści statycznej.

**Jeśli wykres odwołuje się do zewnętrznego pliku Excel, czy zawartość tego pliku będzie brana pod uwagę?**

Nie. Porównanie odbywa się na podstawie samych slajdów. Zewnętrzne źródła danych zazwyczaj nie są odczytywane w czasie porównywania; uwzględniane jest tylko to, co znajduje się w strukturze i stanie statycznym slajdu.