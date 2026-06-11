---
title: Zarządzaj placeholderami prezentacji w PHP
linktitle: Zarządzaj placeholderami
type: docs
weight: 10
url: /pl/php-java/manage-placeholder/
keywords:
- symbol zastępczy
- symbol zastępczy tekstu
- symbol zastępczy obrazu
- symbol zastępczy wykresu
- tekst podpowiedzi
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Bez wysiłku zarządzaj placeholderami w Aspose.Slides dla PHP via Java: zastąp tekst, dostosuj podpowiedzi i ustaw przezroczystość obrazu w PowerPoint i OpenDocument."
---
## **Omówienie**

Aspose.Slides umożliwia programowe zarządzanie placeholderami w prezentacjach. Ten artykuł wyjaśnia, jak znajdować placeholdery na slajdach i zmieniać ich tekst, ustawiać własny tekst podpowiedzi dla układów placeholderów oraz regulować przezroczystość obrazu używanego jako tło placeholdera. Zawiera także krótkie FAQ, które wyjaśnia różnicę między bazowymi placeholderami a lokalnymi kształtami, opisuje, jak zmiany placeholderów można stosować poprzez układy lub mastery, oraz wskazuje zarządzanie placeholderami nagłówka i stopki.

## **Zmienianie tekstu w placeholderze**
Używając [Aspose.Slides for PHP via Java](/slides/pl/php-java/), możesz znajdować i modyfikować placeholdery na slajdach w prezentacjach. Aspose.Slides pozwala na wprowadzanie zmian w tekście placeholdera.

**Wymaganie wstępne**: Potrzebujesz prezentacji zawierającej placeholder. Taki plik możesz utworzyć w standardowej aplikacji Microsoft PowerPoint.

Oto jak użyć Aspose.Slides do zastąpienia tekstu w placeholderze w tej prezentacji:

1. Utwórz instancję klasy [`Presentation`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) i przekaż do niej prezentację jako argument.
2. Pobierz odwołanie do slajdu za pośrednictwem jego indeksu.
3. Przejdź przez wszystkie kształty, aby znaleźć placeholder.
4. Rzutuj kształt placeholdera na [`AutoShape`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/AutoShape) i zmień tekst przy użyciu [`TextFrame`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/TextFrame) powiązanego z [`AutoShape`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/AutoShape).
5. Zapisz zmodyfikowaną prezentację.

Ten kod PHP pokazuje, jak zmienić tekst w placeholderze:

```php
  # Tworzy instancję klasy Presentation
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Uzyskuje dostęp do pierwszego slajdu
    $sld = $pres->getSlides()->get_Item(0);
    # Przegląda kształty w poszukiwaniu placeholdera
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Zmienia tekst w każdym placeholderze
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # Zapisuje prezentację na dysku
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustawianie tekstu podpowiedzi w placeholderze**
Standardowe i gotowe układy zawierają teksty podpowiedzi placeholderów, takie jak ***Click to add a title*** lub ***Click to add a subtitle***. Korzystając z Aspose.Slides, możesz wstawić własne teksty podpowiedzi do układów placeholderów.

Ten kod PHP pokazuje, jak ustawić tekst podpowiedzi w placeholderze:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Iteruje po slajdzie
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint wyświetla "Kliknij, aby dodać tytuł"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // Dodaje podtytuł
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustawianie przezroczystości obrazu w placeholderze**

Aspose.Slides umożliwia ustawienie przezroczystości obrazu tła w placeholderze tekstowym. Regulując przezroczystość obrazu w takim ramach, możesz podkreślić tekst lub sam obraz (w zależności od kolorów tekstu i obrazu).

Ten kod PHP pokazuje, jak ustawić przezroczystość tła obrazu (wewnątrz kształtu):

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Czym jest bazowy placeholder i czym różni się od lokalnego kształtu na slajdzie?**

Bazowy placeholder jest oryginalnym kształtem w układzie lub masterze, z którego dziedziczy kształt slajdu — typ, pozycja i niektóre formatowania pochodzą z niego. Lokalny kształt jest niezależny; jeśli nie ma bazowego placeholdera, dziedziczenie nie ma zastosowania.

**Jak zaktualizować wszystkie tytuły lub podpisy w całej prezentacji bez iteracji po każdym slajdzie?**

Edytuj odpowiedni placeholder w układzie lub masterze. Slajdy oparte na tych układach/masterze automatycznie odziedziczą zmianę.

**Jak kontrolować standardowe placeholdery nagłówka/stopki — datę i godzinę, numer slajdu oraz tekst stopki?**

Użyj menedżerów HeaderFooter w odpowiednim zakresie (zwykłe slajdy, układy, master, notatki/ulotki), aby włączyć lub wyłączyć te placeholdery oraz ustawić ich zawartość.