---
title: Zarządzanie polami tekstowymi w prezentacjach PowerPoint w PHP
linktitle: Pola tekstowe
type: docs
weight: 52
url: /pl/php-java/text-fields/
keywords:
- pole tekstowe
- tekst automatyczny
- numer slajdu
- data i godzina
- nagłówek
- stopka
- fragment tekstu
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Twórz, przeglądaj, modyfikuj i usuwaj pola tekstowe w prezentacjach PowerPoint przy użyciu Aspose.Slides dla PHP poprzez Java. Zachowuj formatowanie i weryfikuj zapisane pliki PPTX i PPT."
---
## **Przegląd**

Paragraf tekstowy składa się z fragmentów. Zwykły [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/) zawiera dosłowny tekst; fragment pola posiada także [Field](https://reference.aspose.com/slides/pl/php-java/aspose.slides/field/), którego typ określa automatycznie aktualizowaną wartość, taką jak numer slajdu lub data. Dwa fragmenty mogą wyświetlać te same znaki, ale tylko jeden zawiera pole.

Użyj [Portion::getField](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/#getField) aby je odróżnić: dla zwykłego tekstu jest `null`. [Portion::addField](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/#addField) konwertuje istniejący fragment na pole. Przechowuj etykietę i jej dynamiczną wartość w osobnych fragmentach, aby konwersja wartości nie zastąpiła również etykiety.

Ten przewodnik opisuje pola w tekście, ich formatowanie oraz zapisywanie ich w formatach PPTX i PPT. Informacje o ramkach tekstowych i paragrafach znajdziesz w [Zarządzanie tekstem](/slides/pl/php-java/manage-text/).

## **Utwórz pole numeru slajdu**

Poniższy kompletny przykład tworzy pole tekstowe zawierające dosłowną etykietę `Slide ` oraz automatycznie aktualizowany numer. Ustawia rozmiar, grubość i kolor liczby przed dodaniem pola, a następnie otwiera ponownie zapisany plik prezentacji i sprawdza typ pola, tekst oraz formatowanie. Nie jest wymagany żaden plik wejściowy.

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Nowa prezentacja rozpoczyna się od numeru slajdu 1, więc tekst to `Slide 1`, a oba sprawdzenia wypisują `true`. Numer pozostaje polem po ponownym otwarciu; nie jest to dosłowny `1`. Indeksy w weryfikacji odnoszą się do kształtu i fragmentów utworzonych w tym przykładzie.

## **Wybierz typ pola**

[FieldType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fieldtype/) udostępnia następujące metody umożliwiające uzyskanie predefiniowanych wartości. Przekaż odpowiednią wartość do [addField](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/#addField).

| Metoda | Cel |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fieldtype/#getSlideNumber) | Obecny numer slajdu. |
| [getDateTime](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fieldtype/#getDateTime) | Data/godzina w domyślnym formacie aplikacji renderującej. |
| [getDateTime1](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fieldtype/#getDateTime9) | Predefiniowane formaty daty lub połączonych dat/godzin. |
| [getDateTime10](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fieldtype/#getDateTime13) | Predefiniowane formaty czasu, z opcjami sekund i zegarem 12‑godzinnym. |
| [getHeader](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fieldtype/#getHeader) | Pole nagłówka; zobacz ograniczenia placeholdera i formatu poniżej. |
| [getFooter](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fieldtype/#getFooter) | Pole stopki. |

Na przykład [getDateTime3](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fieldtype/#getDateTime3) reprezentuje dzień, pełną nazwę miesiąca i rok w języku angielskim. Są to predefiniowane formaty pól, a nie dowolne łańcuchy formatu daty PHP. Język ustawiony za pomocą [setLanguageId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setLanguageId) oraz aplikacja przetwarzająca prezentację mogą wpłynąć na wyświetlany wynik.

## **Utwórz pole z wewnętrznego łańcucha**

Przeciążenie metodą przyjmujące łańcuch w [addField](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/#addField) akceptuje wewnętrzny identyfikator pola. Użyj go, gdy chcesz zachować identyfikator dostarczony przez inną aplikację, która nie ma predefiniowanej wartości. Możesz także skonstruować [FieldType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fieldtype/#FieldType) na podstawie tego identyfikatora. [FieldType::getInternalString](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fieldtype/#getInternalString) udostępnia ten identyfikator do inspekcji.

Ten przykład przechowuje specyficzne dla aplikacji pole `custom-report-id` z tekstem zastępczym `Report-042`. Identyfikator nie rejestruje obliczenia: Aspose.Slides nie generuje identyfikatorów raportów dla nieznanego typu. Aplikacja rozumiejąca ten identyfikator musi dostarczyć jego znaczenie i aktualizować wartość.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Po tym cyklu PPTX typ to `custom-report-id`, a tekst to `Report-042`. Przekazanie łańcucha takiego jak `Y-m-d` nazwałoby typ pola; nie skonfigurowałoby to własnego formatu daty. Dla stałej daty w dowolnym formacie użyj zwykłego tekstu.

## **Sprawdź, zmodyfikuj i usuń pola daty/godziny**

Zmień istniejące pole za pomocą [Field::setType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/field/#setType). Sprawdź, czy pole istnieje, zanim odczytasz jego typ. Aby zatrzymać automatyczne aktualizacje, wywołaj [Portion::removeField](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/#removeField). Dzięki temu fragment i jego bieżący tekst pozostają, a powiązanie z polem zostaje usunięte. Jeśli potrzebujesz konkretnej stałej wartości, przypisz ten tekst po usunięciu pola.

Dla ustawień API związanych z przetwarzaniem pól daty/godziny zobacz [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#setCurrentDateTime). Poniższy przykład używa wyraźnej daty zatwierdzenia przy konwersji pola na zwykły tekst.

Pobierz [sample.pptx](sample.pptx) i umieść go w katalogu roboczym JavaBridge lub przekaż jego pełną ścieżkę do konstruktora prezentacji. Zawiera dwa nazwane kształty tekstowe, `UpdatedAt` i `ApprovedDate`, każdy z polem daty/godziny oraz zwykłe etykiety tekstowe. Następny przykład przegląda kształty tekstowe najwyższego poziomu na zwykłych slajdach. Zmienia pola daty/godziny na format długiej daty i ustawia je kursywą, zachowując pozostałe formatowanie. Tylko pola w `ApprovedDate` stają się stałym tekstem.

Próbka rozpoznaje wbudowane wewnętrzne identyfikatory `datetime` oraz `datetime1`‑`datetime13`. Grupy, tabele, notatki, układy i mastery wymagają przeglądania ich własnych kontenerów tekstowych i nie są objęte zakresem tego przykładu.

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Po ponownym otwarciu `UpdatedAt` ma typ `datetime3` i pozostaje dynamiczny. `ApprovedDate` nie ma pola i zawiera `05 April 2030`. Oba fragmenty daty są kursywą, a ich pierwotny rozmiar czcionki, pogrubienie i kolor pozostają niezmienione. Zwykłe etykiety tekstowe pozostają bez zmian. Weryfikacja odczytuje pierwszy fragment dwóch znanych kształtów w dostarczonej próbce.

## **Zachowaj formatowanie tekstu**

Pracuj z istniejącym fragmentem przy dodawaniu pola, zmianie jego typu lub usuwaniu. Operacje te zachowują formatowanie fragmentu. Użyj [Portion::getPortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/#getPortionFormat), aby zmienić tylko wymagane właściwości, tak jak w przykładach zmieniających kolor lub kursywę.

Unikaj odtworzenia całej ramki tekstowej tylko po to, aby zaktualizować jedno pole: może to spowodować utratę pierwotnych granic fragmentów i ich indywidualnego formatowania. Rozróżniaj także formatowanie ustawione explicite od formatowania dziedziczonego z paragrafu, układu lub motywu. Zobacz [Formatowanie tekstu](/slides/pl/php-java/text-formatting/) po więcej opcji formatowania.

## **Pola i placeholdery nagłówka/stopki**

Pole jest częścią fragmentu tekstowego. Placeholder to kształt z rolą w prezentacji, taką jak stopka lub numer slajdu. Dodanie pola do zwykłego pola tekstowego nie zamienia tego kształtu w placeholder.

Menedżery nagłówka i stopki kontrolują tekst placeholdera oraz jego widoczność na slajdach, układach i masterach, w tym propagację do slajdów zależnych. Pole liczby w niestandardowym polu tekstowym może więc być przydatne, nawet jeśli nie używasz placeholdera numeru slajdu. Zmiana widoczności placeholdera nie usuwa pola z niezwiązanego pola tekstowego.

Predefiniowane typy nagłówka i stopki nie tworzą odpowiadających im placeholderów ani nie dostarczają ich zawartości. W szczególności zwykły slajd PowerPoint nie ma placeholdera nagłówka; nagłówki należą do stron notatek i materiałów rozdawczych. Nie zakładaj, że pole nagłówka lub stopki w dowolnym kształcie automatycznie otrzyma tekst skonfigurowany poprzez manager placeholderów. Dla tego scenariusza zobacz [Nagłówki i stopki w prezentacji](/slides/pl/php-java/presentation-header-and-footer/).

## **Ograniczenia PPTX i PPT**

Sprawdź zarówno typ pola, jak i wynikowy tekst po zapisaniu i ponownym otwarciu. Zachowanie identyfikatora nie dowodzi, że aplikacja potrafi obliczyć lub wyświetlić jego wartość.

| Format | Zachowanie pola i ograniczenia |
|---|---|
| PPTX | Przechowuje wewnętrzne identyfikatory pól wraz z ich tekstem. W testach „round‑trip” predefiniowane typy oraz użyty powyżej identyfikator niestandardowy przetrwały zapis i otwarcie. Nieznany typ niestandardowy zachował tekst zastępczy; nie uzyskał logiki automatycznego obliczania. Inna aplikacja może traktować nieobsługiwane identyfikatory inaczej. |
| PPT | Używa starszych reprezentacji pól i ma bardziej ograniczoną kompatybilność. W testach „round‑trip” pola numeru slajdu oraz predefiniowane pola daty/godziny przetrwały zapis i otwarcie. Niestandardowe pole w zwykłym polu tekstowym slajdu otwarto ponownie z identyfikatorem, ale z `*` jako tekstem; pole nagłówka w tym samym kontekście również dało `*`. Nie polegaj na tym, że pola niestandardowe lub nieobsługiwane konteksty pól zachowają widoczny tekst. |

Aby uzyskać przenośny, stały wynik, przekształć nieobsługiwane pola w zwykły tekst i jawnie przypisz pożądaną wartość przed zapisaniem. Dzięki temu zachowasz wybrany tekst, ale celowo zatrzymasz automatyczne aktualizacje. Przetestuj także docelową aplikację, jeśli jej własne przeliczanie pól jest częścią Twojego procesu pracy.

## **FAQ**

**Jak mogę określić, czy wyświetlona liczba lub data jest polem?**

Sprawdź [Portion::getField](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/#getField). Nie‑nullowa wartość oznacza pole; sam wyświetlony tekst nie pozwala tego określić.

**Czy usunięcie pola usuwa jego tekst lub formatowanie?**

Nie. [removeField](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/#removeField) konwertuje istniejący fragment na zwykły tekst. Przypisz explicite wartość po usunięciu, jeśli potrzebujesz określonej zamrożonej daty lub tekstu zapasowego.

**Czy wewnętrzny łańcuch może definiować nowy format daty lub formułę?**

Nie. Określa typ pola. Nieznany identyfikator nie dostarcza evaluatora ani wzorca formatu daty PHP. Użyj obsługiwanego predefiniowanego typu lub sformatuj wartość samodzielnie jako zwykły tekst.

**Dlaczego sprawdzać prezentację ponownie po jej zapisaniu?**

Identyfikatory pól, wyliczony tekst i formatowanie to oddzielne elementy do weryfikacji. Konwersja formatu może zmienić widoczny wynik, nawet jeśli identyfikator pola nadal istnieje.