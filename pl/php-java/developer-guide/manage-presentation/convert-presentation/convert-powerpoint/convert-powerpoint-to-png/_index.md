---
title: Konwertuj slajdy PowerPoint do PNG w PHP
linktitle: PowerPoint do PNG
type: docs
weight: 30
url: /pl/php-java/convert-powerpoint-to-png/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do PNG
- prezentacja do PNG
- slajd do PNG
- PPT do PNG
- PPTX do PNG
- zapisz PPT jako PNG
- zapisz PPTX jako PNG
- eksportuj PPT do PNG
- eksportuj PPTX do PNG
- PHP
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint na wysokiej jakości obrazy PNG szybko przy użyciu Aspose.Slides dla PHP poprzez Java, zapewniając precyzyjne, zautomatyzowane wyniki."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na obrazy PNG przy użyciu Aspose.Slides. Pokazuje, jak ładować pliki prezentacji w formatach takich jak PPT, PPTX i ODP, renderować slajdy jako obrazy oraz zapisywać wyniki w formacie PNG.

Artykuł również demonstruje, jak dostosować generowane obrazy PNG, ustawiając wartości skali lub określając żądaną szerokość i wysokość.

## **Konwertuj PowerPoint do PNG**

Wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Pobierz obiekt slajdu z kolekcji [Presentation.getSlides()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getSlides) w klasie [Slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/).
3. Użyj metody [Slide.getImage()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getImage), aby uzyskać miniaturę każdego slajdu.
4. Użyj metody [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/#save), aby zapisać miniaturę slajdu w formacie PNG.

Ten kod PHP pokazuje, jak przekonwertować prezentację PowerPoint na PNG:

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Konwertuj PowerPoint do PNG z niestandardowymi wymiarami**

Jeśli chcesz uzyskać pliki PNG o określonej skali, możesz ustawić wartości `desiredX` i `desiredY`, które określają wymiary wynikowej miniatury. 

Ten kod demonstruje opisaną operację:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Konwertuj PowerPoint do PNG o niestandardowym rozmiarze**

Jeśli chcesz uzyskać pliki PNG o określonym rozmiarze, możesz przekazać preferowane argumenty `width` i `height` dla `ImageSize`. 

Ten kod pokazuje, jak przekonwertować PowerPoint na PNG, określając rozmiar obrazów: 

```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Jak mogę wyeksportować tylko konkretny kształt (np. wykres lub obraz) zamiast całego slajdu?**

Aspose.Slides obsługuje [generowanie miniatur dla poszczególnych kształtów](/slides/pl/php-java/create-shape-thumbnails/); możesz wyrenderować kształt do obrazu PNG.

**Czy konwersja równoległa jest obsługiwana na serwerze?**

Tak, ale [nie udostępniaj](/slides/pl/php-java/multithreading/) jednej instancji prezentacji między wątkami. Użyj osobnej instancji dla każdego wątku lub procesu.

**Jakie są ograniczenia wersji próbnej przy eksporcie do PNG?**

Tryb ewaluacyjny dodaje znak wodny do wyjściowych obrazów i wymusza [inne ograniczenia](/slides/pl/php-java/licensing/) aż do zastosowania licencji.