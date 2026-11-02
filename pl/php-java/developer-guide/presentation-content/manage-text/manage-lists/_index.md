---
title: Zarządzanie listami punktowanymi i numerowanymi w prezentacjach przy użyciu PHP
linktitle: Zarządzaj listami
type: docs
weight: 60
url: /pl/php-java/manage-lists/
keywords:
- wypunktowanie
- lista punktowana
- lista numerowana
- symbol wypunktowania
- obrazkowe wypunktowanie
- niestandardowe wypunktowanie
- lista wielopoziomowa
- utwórz wypunktowanie
- dodaj wypunktowanie
- dodaj listę
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować listy punktowane, obrazkowe, wielopoziomowe oraz numerowane w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP poprzez Java."
---
## **Przegląd**

Aspose.Slides for PHP via Java umożliwia tworzenie i formatowanie list punktowanych i numerowanych w prezentacjach PowerPoint i OpenDocument. Element listy to akapit, którego ustawienia wypunktowania są kontrolowane poprzez format akapitu.

Użyj metody [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat), aby uzyskać dostęp do ustawień list na poziomie akapitu. Głównym punktem wejścia jest [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet), który zwraca obiekt [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/). Za pomocą tego obiektu możesz ustawić typ wypunktowania, symbol, obraz, kolor, rozmiar, styl numeracji oraz numer początkowy.

Ten artykuł pokazuje, jak:

- utworzyć listę punktowaną z własnym symbolem
- utworzyć wypunktowanie obrazkowe
- utworzyć listę wielopoziomową, ustawiając głębokość akapitu
- utworzyć listę numerowaną
- sprawdzić i zmienić formatowanie listy w istniejącej prezentacji
- odczytać rzeczywiste znaczniki i numery listy wraz z tekstem akapitu

## **Utworzenie listy punktowanej**

Aby utworzyć listę punktowaną, dodaj obiekty [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) do [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) i ustaw [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) na [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Symbol). Następnie możesz ustawić [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar), [BulletFormat::getColor](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getColor) i [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight), aby kontrolować wygląd wypunktowania.

Poniższy kod PHP demonstruje, jak utworzyć listę punktowaną na slajdzie:

```php
use aspose\slides\BulletType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Wypunktowania symboliczne](symbol_bullets.png)

## **Utworzenie listy numerowanej**

Używaj list numerowanych, gdy kolejność elementów ma znaczenie. Ustaw [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) na [BulletType::Numbered](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Numbered). Możesz także wybrać format numeracji za pomocą [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) lub ustawić [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith), gdy lista ma zaczynać się od wartości innej niż 1.

Poniższy kod PHP pokazuje, jak utworzyć listę numerowaną na slajdzie:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Wypunktowania numerowane](numbered_bullets.png)

## **Utworzenie wypunktowania obrazkowego**

Aspose.Slides umożliwia zastąpienie standardowego symbolu wypunktowania obrazem. Wypunktowania obrazkowe najlepiej działają z prostymi obrazami, które pozostają czytelne w małym rozmiarze, takimi jak ikony lub małe przeźroczyste pliki PNG.

{{% alert color="info" title="Note" %}}
Idealnie, jeśli planujesz zastąpić standardowy symbol wypunktowania obrazem, najlepiej wybrać prostą grafikę o przezroczystym tle. Takie obrazy dobrze sprawdzają się jako niestandardowe symbole wypunktowań.
{{% /alert %}}

Pamiętaj, że obraz zostanie przeskalowany do bardzo małego rozmiaru. Z tego powodu zdecydowanie zalecamy wybranie obrazu, który pozostaje wyraźny i wizualnie skuteczny jako wypunktowanie w liście.

Aby utworzyć wypunktowanie obrazkowe, dodaj obraz do [Presentation::getImages](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getImages) i przypisz zwrócony obiekt [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) do [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture). Ustaw [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) na [BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture) przed przypisaniem obrazu.

Powiedzmy, że mamy plik „image.png”:

![Obraz dla wypunktowań](picture_for_bullets.png)

Poniższy kod PHP pokazuje, jak utworzyć wypunktowania obrazkowe na slajdzie:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Wypunktowania obrazkowe](picture_bullets.png)

## **Utworzenie listy wielopoziomowej**

Użyj [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth), aby umieścić elementy listy na różnych poziomach. Poziom 0 to poziom najwyższy, poziom 1 jest zagnieżdżony pod nim i tak dalej.

Poniższy kod PHP pokazuje, jak utworzyć wielopoziomową listę punktowaną:

```php
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Lista wielopoziomowa](multilevel_list.png)

## **Zmiana istniejącej listy**

Aby zmienić formatowanie listy w istniejącej prezentacji, uzyskaj dostęp do docelowego akapitu i zaktualizuj jego ustawienia [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet). Te same właściwości używane do tworzenia list mogą być użyte do sprawdzania lub modyfikowania list załadowanych z pliku PPT, PPTX lub ODP.

Poniższy kod PHP zmienia pierwszy akapit w ramce tekstowej, aby używał stylu listy numerowanej:

```php
use aspose\slides\BulletType;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Odczytywanie rzeczywistych wartości wypunktowań**

Podczas wyodrębniania zawartości prezentacji należy zachować znaczniki listy obok tekstu akapitu. Wywołaj [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getEffective) i uzyskaj dostęp do [ParagraphFormatEffectiveData::getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) aby otrzymać efektywny format wypunktowania. Sprawdź jego [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) przed odczytaniem [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--).

Dla list numerowanych rozróżnij te trzy wartości:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) określa format, np. liczby arabskie zakończone kropką lub małe litery zakończone kropką.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) określa numer początkowy dla grupy numerowanych akapitów.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) zwraca sformatowany znacznik dla konkretnego akapitu. Na przykład drugi element w liście rozpoczynającej się od 5 zwróci `6.`.

Zachowaj [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDepth) przy każdym akapicie, aby utrzymać jego poziom zagnieżdżenia. Rzeczywisty znacznik nie koduje pełnej hierarchii: element zagnieżdżony może zwrócić `c.` zamiast połączonej etykiety takiej jak `6.c.`.

Poniższy przykład samodzielnie tworzy listy, zapisuje je do prezentacji i ponownie ładuje prezentację, aby zgłosić tekst, głębokość, typ wypunktowania i rzeczywistą wartość każdego akapitu. Niewielki niebieski znacznik obrazkowy jest tworzony z wbudowanego SVG.

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 440, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20, 660, 400);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    // Utwórz znacznik obrazkowy bez zewnętrznego pliku obrazu.
    $svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    $bulletImage = $presentation->getImages()->addImage($svg);

    $black = new Java("java.awt.Color", 0, 0, 0);
    $addParagraph = function ($text, $depth, $type, $start, $style) use ($textFrame, $bulletImage, $black) {
        $paragraph = new Paragraph();
        $paragraph->setText($text);

        $format = $paragraph->getParagraphFormat();
        $format->setDepth($depth);
        $format->setMarginLeft(30 + $depth * 40);
        $format->setIndent(-28);
        $format->setSpaceAfter(8);
        $format->getDefaultPortionFormat()->setFontHeight(22);
        $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $format->getBullet()->setType($type);
        $format->getBullet()->setBulletHardColor(NullableBool::True);
        $format->getBullet()->getColor()->setColor($black);
        if ($type == BulletType::Numbered) {
            $format->getBullet()->setNumberedBulletStyle($style);
            $format->getBullet()->setNumberedBulletStartWith($start);
        } else if ($type == BulletType::Symbol) {
            $format->getBullet()->setChar("\u{2022}");
        } else if ($type == BulletType::Picture) {
            $format->getBullet()->getPicture()->setImage($bulletImage);
        }

        $textFrame->getParagraphs()->add($paragraph);
    };

    $addParagraph("First item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Second item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Next nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Deep item", 2, BulletType::Numbered, 4, NumberedBulletStyle::BulletRomanLCPeriod);
    $addParagraph("Back to top level", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Symbol marker", 0, BulletType::Symbol, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("No bullet", 0, BulletType::None, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Picture marker", 0, BulletType::Picture, 1, NumberedBulletStyle::BulletArabicPeriod);
    $presentation->save("actual_bullet_values.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    $loadedShape = $loadedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Text | Depth | Type | Actual value\n";
    $paragraphs = $loadedShape->getTextFrame()->getParagraphs();
    for ($i = 0; $i < java_values($paragraphs->getCount()); $i++) {
        $paragraph = $paragraphs->get_Item($i);
        $bullet = $paragraph->getParagraphFormat()->getEffective()->getBullet();
        switch (java_values($bullet->getType())) {
            case BulletType::Numbered:
            case BulletType::Symbol:
                $marker = $bullet->getActualBulletValue();
                break;
            case BulletType::None:
                $marker = "null (no bullet)";
                break;
            case BulletType::Picture:
                $marker = "null (image required)";
                break;
            default:
                $marker = "unsupported bullet type";
                break;
        }
        $typeNames = [BulletType::Numbered => "Numbered", BulletType::Symbol => "Symbol", BulletType::None => "None", BulletType::Picture => "Picture"];
        $typeName = $typeNames[java_values($bullet->getType())] ?? "Unknown";
        echo $paragraph->getText() . " | " . $paragraph->getParagraphFormat()->getDepth() . " | " . $typeName . " | " . $marker . "\n";
    }
} finally {
    $loadedPresentation->dispose();
}
```

Poniżej pokazano źródłowe listy.

![Listy zaczynające się od 5, zagnieżdżone pozycje literowe i rzymskie, znacznik symboliczny, akapit bez wypunktowania oraz niebieski znacznik obrazkowy](actual_bullet_values.png)

Raport zgadza się ze znacznikami wyświetlanymi w PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Dla [BulletType::None i BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/), [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) zwraca `null`, a nie pusty ciąg. Obsłuż te typy oddzielnie: pierwszy nie posiada znacznika, natomiast drugi wymaga osobnego wyodrębnienia obrazu wypunktowania. Wypunktowanie obrazkowe nie może być odtworzone wyłącznie przez wyodrębnienie tekstowego znacznika.

## **FAQ**

**Czy listy punktowane i numerowane mogą być eksportowane do PDF lub obrazów?**

Tak. Aspose.Slides zachowuje formatowanie list, gdy docelowy format obsługuje odpowiednie układy tekstu i funkcje wypunktowań.

**Czy mogę edytować listy w istniejących prezentacjach?**

Tak. Załaduj prezentację, uzyskaj dostęp do docelowego akapitu, sprawdź lub zaktualizuj jego ustawienia [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) i zapisz prezentację.

**Czy listy mogą zawierać tekst niełaciński?**

Tak. Tekst elementów listy może zawierać znaki Unicode, więc możesz tworzyć listy w prezentacjach wielojęzycznych. Upewnij się, że czcionki użyte w prezentacji obsługują potrzebne znaki.