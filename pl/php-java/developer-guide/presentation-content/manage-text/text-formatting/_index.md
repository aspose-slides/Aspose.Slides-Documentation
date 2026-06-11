---
title: Formatowanie tekstu prezentacji w PHP
linktitle: Formatowanie tekstu
type: docs
weight: 50
url: /pl/php-java/text-formatting/
keywords:
- podświetlanie tekstu
- wyrażenie regularne
- wyrównanie akapitu
- styl tekstu
- tło tekstu
- przezroczystość tekstu
- odstępy między znakami
- właściwości czcionki
- rodzina czcionek
- obrót tekstu
- kąt obrotu
- ramka tekstowa
- odstęp między wierszami
- właściwość autofit
- kotwica ramki tekstowej
- tabulacja tekstu
- język domyślny
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Formatuj i stylizuj tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP poprzez Java. Dostosuj czcionki, kolory, wyrównanie i wiele innych."
---
## **Przegląd**

Ten artykuł pokazuje, jak formatować tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP za pośrednictwem Java. Omówiono podświetlanie, kolory tła, przezroczystość, odstępy między znakami, właściwości czcionki, obrót, odstępy akapitów, zachowanie autofit, kotwiczenie tekstu, tabulatory i ustawienia języka.

W poniższych przykładach użyjemy pliku o nazwie "sample.pptx", który zawiera pojedyncze pole tekstowe na pierwszym slajdzie z następującym tekstem:

![Przykładowy tekst](sample_text.png)

## **Podświetlanie tekstu**

Użyj metody [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/)`::highlightText`, gdy potrzebujesz podświetlić tekst pasujący do określonego wzorca w ramce tekstowej. Metoda stosuje kolor podświetlenia do pasujących fragmentów tekstu i może być użyta z [TextHighlightingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/texthighlightingoptions/), aby kontrolować sposób wyszukiwania, na przykład aby dopasować tylko całe słowa.

Poniższy przykład kodu podświetla wszystkie wystąpienia znaków **"try"** i następnie podświetla tylko pełne słowo **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    // Pobierz pierwszy kształt z pierwszego slajdu.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // Podświetl słowo "try" w kształcie.
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // Podświetl słowo "to" w kształcie.
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Podświetlony tekst](highlighted_text.png)

## **Podświetlanie tekstu przy użyciu wyrażeń regularnych**

Metoda [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/)`::highlightRegex` podświetla dopasowania tekstu znalezione przez wyrażenie regularne.

Poniższy przykład kodu podświetla wszystkie słowa zawierające **siedem lub więcej znaków**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Podświetl wszystkie słowa o siedmiu lub więcej znakach.
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Podświetlony tekst przy użyciu wyrażenia regularnego](highlighted_text_using_regex.png)

## **Ustawienie koloru tła tekstu**

Użyj domyślnego formatu części w [ParagraphFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/), aby ustawić domyślny kolor podświetlenia dla akapitu, lub użyj [PortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portionformat/) dla pojedynczych części tekstu.

Poniższy przykład kodu pokazuje, jak ustawić kolor tła dla **całego akapitu**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Ustaw kolor podświetlenia dla całego akapitu.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Szary akapit](gray_paragraph.png)

Poniższy przykład kodu demonstruje, jak ustawić kolor tła dla **części tekstu z pogrubioną czcionką**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Ustaw kolor podświetlenia dla części tekstu.
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Szare części tekstu](gray_text_portions.png)

## **Wyrównywanie akapitów tekstu**

Użyj metody [ParagraphFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/)`::setAlignment`, aby ustawić wyrównanie akapitu w ramce tekstowej. Wartość może być wyśrodkowana, wyrównana do lewej, do prawej, justowana itp.

Poniższy przykład kodu pokazuje, jak wyrównać akapit do **środka**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Ustaw wyrównanie akapitu do środka.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Wyrównany akapit](aligned_paragraph.png)

## **Ustawienie przezroczystości tekstu**

Przezroczystość tekstu jest kontrolowana przez składnik alfa koloru przypisanego do formatu wypełnienia [PortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portionformat/). W poniższych przykładach `alpha = 50` jest wartością kanału alfa ARGB w skali 0‑255, a nie procentem przezroczystości.

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **całego akapitu**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Ustaw kolor wypełnienia tekstu na kolor przezroczysty.
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Przezroczysty akapit](transparent_paragraph.png)

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **części tekstu z pogrubioną czcionką**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Ustaw przezroczystość części tekstu.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Przezroczyste części tekstu](transparent_text_portions.png)

## **Ustawienie odstępu między znakami w tekście**

Użyj metody [BasePortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/)`::setSpacing`, aby rozszerzyć lub zmniejszyć odstęp między znakami w polu tekstowym.

Poniższy kod PHP pokazuje, jak rozszerzyć odstęp między znakami w **całym akapicie**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Uwaga: użyj wartości ujemnych, aby zmniejszyć odstęp między znakami.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Rozszerz odstęp między znakami.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Odstęp między znakami w akapicie](character_spacing_in_paragraph.png)

Poniższy przykład kodu pokazuje, jak rozszerzyć odstęp między znakami w **częściach tekstu z pogrubioną czcionką**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Uwaga: użyj wartości ujemnych, aby zmniejszyć odstęp między znakami.
            $portion->getPortionFormat()->setSpacing(3); // Rozszerz odstęp między znakami.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Odstęp między znakami w częściach tekstu](character_spacing_in_text_portions.png)

### **Wyłączenie kerningu dla określonych czcionek**

W niektórych przypadkach tekst renderowany przez Aspose.Slides może wyglądać nieco ściślej niż ten sam tekst wyświetlany w PowerPoint. Może się tak zdarzyć, ponieważ PowerPoint może ignorować dane kerningu dla niektórych czcionek, nawet jeśli czcionka zawiera prawidłowe informacje o kerningu i kerning jest włączony w ustawieniach PowerPoint.

Aby uzyskać wynik bardziej zbliżony do PowerPoint w takich sytuacjach, możesz wyłączyć kerning dla części tekstu używających dotkniętej czcionki. Ustaw metodę [BasePortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize` na wartość znacząco większą niż rzeczywisty rozmiar czcionki:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

To ustawienie zapobiega stosowaniu kerningu do pasujących części tekstu i może pomóc wyrównać renderowanie Aspose.Slides z wyjściem wizualnym PowerPoint dla czcionek dotkniętych tym specyficznym zachowaniem PowerPoint.

## **Zarządzanie właściwościami czcionki tekstu**

Właściwości czcionki można ustawić na poziomie akapitu poprzez domyślny format części w [ParagraphFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/), lub na poszczególnych częściach poprzez [PortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portionformat/).

Poniższy kod ustawia czcionkę i styl tekstu dla całego akapitu: stosuje rozmiar czcionki, pogrubienie, kursywę, kropkowane podkreślenie oraz czcionkę Times New Roman do wszystkich części w akapicie.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // Ustaw właściwości czcionki dla akapitu.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont(new FontData("Times New Roman"));

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Właściwości czcionki dla akapitu](font_properties_for_paragraph.png)

Poniższy przykład kodu stosuje podobne właściwości do **części tekstu z pogrubioną czcionką**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Ustaw właściwości czcionki dla części tekstu.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont(new FontData("Times New Roman"));
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Właściwości czcionki dla części tekstu](font_properties_for_text_portions.png)

## **Ustawienie obrotu tekstu**

Użyj metody [TextFrameFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/)`::setTextVerticalType`, aby ustawić predefiniowaną orientację tekstu wewnątrz kształtu.

Poniższy przykład kodu ustawia orientację tekstu w kształcie na `Vertical270`, co obraca tekst **o 90 stopni przeciwnie do ruchu wskazówek zegara**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Obrót tekstu](text_rotation.png)

## **Ustawienie własnego obrotu dla ramek tekstowych**

Użyj metody [TextFrameFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/)`::setRotationAngle`, aby ustawić własny kąt obrotu dla [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/).

Poniższy przykład kodu obraca ramkę tekstową o 3 stopnie zgodnie z ruchem wskazówek zegara w obrębie kształtu:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Własny obrót tekstu](custom_text_rotation.png)

## **Ustawienie odstępu między wierszami w akapitach**

Aspose.Slides udostępnia metody [ParagraphFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`, `ParagraphFormat::setSpaceBefore` oraz `ParagraphFormat::setSpaceWithin`, aby kontrolować odstępy akapitów. Metody te stosuje się w następujący sposób:

* Użyj wartości dodatniej, aby określić odstęp jako procent wysokości wiersza.  
* Użyj wartości ujemnej, aby określić odstęp w punktach.

Poniższy przykład kodu pokazuje, jak określić odstęp wierszy w akapicie:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Odstęp wierszy w akapicie](line_spacing.png)

## **Ustawienie typu autofitu dla ramek tekstowych**

Metoda [TextFrameFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/)`::setAutofitType` określa, jak tekst zachowuje się, gdy przekracza granice swojego kontenera. Użyj jej, aby kontrolować, czy tekst ma się zmniejszać, przelatywać poza obszar albo automatycznie zmieniać rozmiar kształtu.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ustawienie kotwicy dla ramek tekstowych**

Metoda [TextFrameFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/)`::setAnchoringType` definiuje, jak tekst jest rozmieszczony pionowo wewnątrz kształtu, na przykład u góry, w środku lub na dole.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ustawienie tabulacji tekstu**

Użyj metody [ParagraphFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize` oraz jej kolekcji tabulacji, aby skonfigurować tabulatory w akapicie.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Tabulatory w akapicie](paragraph_tabs.png)

## **Ustawienie języka korekty**

Aspose.Slides udostępnia metodę [BasePortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/)`::setLanguageId`, która pozwala ustawić język korekty dla części tekstu. Język korekty określa język używany do sprawdzania pisowni i gramatyki w PowerPoint.

Poniższy przykład kodu pokazuje, jak ustawić język korekty dla części tekstu:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Ustaw identyfikator języka korekty.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ustawienie języka domyślnego**

Użyj metody [LoadOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage`, aby zdefiniować domyślny język dla tekstu tworzonego podczas ładowania lub tworzenia prezentacji.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj nowy prostokątny kształt z tekstem.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Sprawdź język pierwszej części tekstu.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Ustawienie domyślnego stylu tekstu**

Aby zastosować domyślne formatowanie tekstu na poziomie prezentacji, użyj domyślnego stylu tekstu obiektu [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).

Poniższy przykład kodu pokazuje, jak ustawić domyślną pogrubioną czcionkę o rozmiarze 14 pt dla całego tekstu we wszystkich slajdach nowej prezentacji.

```php
$presentation = new Presentation();
try {
    // Pobierz format akapitu najwyższego poziomu.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Wyodrębnianie tekstu z efektem wielkich liter**

W PowerPoint zastosowanie efektu **All Caps** powoduje wyświetlanie tekstu wielkimi literami na slajdzie, nawet jeśli został on wprowadzony małymi literami. Gdy pobierasz taką część tekstu za pomocą Aspose.Slides, biblioteka zwraca tekst dokładnie tak, jak został wprowadzony. Aby uzyskać wyświetlany tekst, sprawdź [TextCapType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textcaptype/) i przekształć zwrócony ciąg do wielkich liter, gdy wartość to `All`.

Załóżmy, że mamy następujące pole tekstowe na pierwszym slajdzie pliku sample2.pptx.

![Efekt All Caps](all_caps_effect.png)

Poniższy przykład kodu pokazuje, jak wyodrębnić tekst z zastosowanym efektem **All Caps**:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($textPortion->getText());
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

Wyjście:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Jak zmodyfikować tekst w tabeli na slajdzie?**

Aby zmodyfikować tekst w tabeli na slajdzie, użyj [Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/table/). Przejdź przez komórki i zaktualizuj każdą z nich poprzez ramkę tekstową [Cell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cell/) oraz formatowanie akapitu za pomocą [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/)'s paragraph format.

**Jak zastosować gradientowy kolor do tekstu w slajdzie PowerPoint?**

Aby zastosować gradientowy kolor do tekstu, użyj formatu wypełnienia [PortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portionformat/). Ustaw typ wypełnienia [FillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/) na [FillType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/filltype/) `Gradient` i skonfiguruj przystanki gradientu, kierunek oraz przezroczystość.