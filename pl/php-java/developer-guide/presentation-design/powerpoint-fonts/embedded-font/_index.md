---
title: Osadzanie czcionek w prezentacjach przy użyciu PHP
linktitle: Osadzanie czcionki
type: docs
weight: 40
url: /pl/php-java/embedded-font/
keywords:
- dodaj czcionkę
- osadź czcionkę
- osadzanie czcionek
- pobierz osadzoną czcionkę
- dodaj osadzoną czcionkę
- usuń osadzoną czcionkę
- kompresuj osadzoną czcionkę
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Osadź czcionki TrueType w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP via Java, zapewniając dokładne renderowanie na wszystkich platformach."
---
## **Wprowadzenie**

**Czcionki osadzone w PowerPoint** są przydatne, kiedy chcesz, aby Twoja prezentacja wyświetlała się prawidłowo na każdym systemie lub urządzeniu. Jeśli użyłeś czcionki zewnętrznej lub niestandardowej, ponieważ byłeś kreatywny w swojej pracy, masz jeszcze więcej powodów, aby osadzić tę czcionkę. W przeciwnym razie (bez osadzonych czcionek) teksty lub liczby na slajdach, układ, stylizacja itp. mogą się zmienić lub zamienić w nieczytelne prostokąty. 

Klasy [FontsManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FontsManager), [FontData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontdata/) oraz [Compress](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/) zawierają większość metod potrzebnych do pracy z osadzonymi czcionkami w prezentacjach PowerPoint.

## **Pobieranie i usuwanie osadzonych czcionek**

Aspose.Slides udostępnia metodę [getEmbeddedFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) (udostępnioną przez klasę [FontsManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FontsManager)), aby umożliwić pobranie (lub sprawdzenie) czcionek osadzonych w prezentacji. Aby usunąć czcionki, używana jest metoda [removeEmbeddedFont](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) (udostępniona przez tę samą klasę).

Ten kod PHP pokazuje, jak pobrać i usunąć osadzone czcionki z prezentacji:

```php
  # Tworzy obiekt Presentation, który reprezentuje plik prezentacji
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Renderuje slajd zawierający ramkę tekstową używającą osadzonej czcionki "FunSized"
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Zapisuje obraz na dysku w formacie JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Pobiera wszystkie osadzone czcionki
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Znajduje czcionkę "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # Usuwa czcionkę "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # Renderuje prezentację; "Calibri" czcionka zostaje zastąpiona istniejącą
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Zapisuje obraz na dysku w formacie JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Zapisuje prezentację bez osadzonej czcionki "Calibri" na dysku
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dodawanie osadzonych czcionek**

Korzystając z klasy [EmbedFontCharacters](https://reference.aspose.com/slides/pl/php-java/aspose.slides/embedfontcharacters/) oraz dwóch przeciążeń metody [addEmbeddedFont](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/#addEmbeddedFont), możesz wybrać preferowaną zasadę (osadzania), aby osadzić czcionki w prezentacji. Ten kod PHP pokazuje, jak osadzić i dodać czcionki do prezentacji:

```php
  # Ładuje prezentację
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # Zapisuje prezentację na dysku
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kompresja osadzonych czcionek**

Aby umożliwić kompresję czcionek osadzonych w prezentacji i zmniejszyć rozmiar pliku, Aspose.Slides udostępnia metodę [compressEmbeddedFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/#compressEmbeddedFonts) (udostępnioną przez klasę [Compress](https://reference.aspose.com/slides/pl/php-java/aspose.slides/compress/)).

Ten kod PHP pokazuje, jak skompresować osadzone czcionki PowerPoint:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Jak mogę stwierdzić, że konkretna czcionka w prezentacji zostanie nadal podmieniona podczas renderowania pomimo osadzenia?**

Sprawdź [substitution information](/slides/pl/php-java/font-substitution/) w menedżerze czcionek oraz [fallback/substitution rules](/slides/pl/php-java/fallback-font/): jeśli czcionka jest niedostępna lub ograniczona, zostanie użyta czcionka zapasowa.

**Czy warto osadzać czcionki „systemowe”, takie jak Arial/Calibri?**

Zazwyczaj nie — są prawie zawsze dostępne. Jednak w celu pełnej przenośności w „cienkich” środowiskach (Docker, serwer Linux bez wstępnie zainstalowanych czcionek) osadzanie czcionek systemowych może wyeliminować ryzyko nieoczekiwanej podmiany.