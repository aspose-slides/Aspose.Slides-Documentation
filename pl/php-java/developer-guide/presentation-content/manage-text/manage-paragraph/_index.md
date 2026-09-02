---
title: Zarządzanie akapitami tekstu PowerPoint w PHP
linktitle: Zarządzanie akapitem
type: docs
weight: 40
url: /pl/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
  - dodaj tekst
  - dodaj akapit
  - zarządzaj tekstem
  - zarządzaj akapitem
  - zarządzaj wypunktowaniem
  - wcięcie akapitu
  - wcięcie wiszące
  - wypunktowanie akapitu
  - lista numerowana
  - lista wypunktowana
  - właściwości akapitu
  - importuj HTML
  - tekst do HTML
  - akapit do HTML
  - akapit do obrazu
  - tekst do obrazu
  - eksportuj akapit
  - PowerPoint
  - prezentacja
  - PHP
  - Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować akapity, fragmenty, wypunktowania, listy numerowane, wcięcia, treść HTML oraz obrazy akapitów przy użyciu Aspose.Slides dla PHP via Java."
---
## **Przegląd**

Aspose.Slides for PHP via Java reprezentuje tekst jako hierarchię ramki tekstowej, akapitów i fragmentów:

* [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) reprezentuje kontener tekstu w kształcie i zapewnia dostęp do jego kolekcji akapitów.
* [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/) reprezentuje jeden akapit w ramce tekstowej i zapewnia dostęp do jego fragmentów oraz formatowania na poziomie akapitu.
* [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/) reprezentuje fragment tekstu w obrębie akapitu. Każdy fragment może mieć własny tekst i formatowanie znakowe.

Akapit może więc zawierać tekst o różnych czcionkach, kolorach, rozmiarach i innych właściwościach formatowania, używając wielu fragmentów.

## **Tworzenie i formatowanie akapitów**

### **Tworzenie akapitów z wieloma fragmentami**

Poniższe kroki tworzą ramkę tekstową z trzema akapitami, z których każdy zawiera trzy fragmenty:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu poprzez jego indeks.
3. Dodaj prostokątną [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) kształtu.
5. Użyj domyślnego akapitu i dodaj dwa kolejne obiekty [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/) do ramki tekstowej.
6. Dodaj wystarczającą liczbę obiektów [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/) tak, aby każdy akapit zawierał trzy fragmenty. Domyślny akapit już zawiera jeden pusty fragment.
7. Ustaw tekst każdego fragmentu.
8. Zastosuj formatowanie znakowe za pomocą [Portion::getPortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/#getPortionFormat--).
9. Zapisz zmodyfikowaną prezentację.

Ten przykład w PHP realizuje powyższe kroki:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tworzenie list wypunktowanych i numerowanych**

### **Tworzenie listy wypunktowanej lub numerowanej**

Punkty i numeracja ułatwiają przeglądanie powiązanych elementów. W Aspose.Slides ustawienia listy definiuje się za pomocą [BulletFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu poprzez jego indeks.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do wybranego slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) kształtu.
5. Usuń domyślny akapit z ramki tekstowej.
6. Utwórz [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/) dla symbolu wypunktowania.
7. Ustaw [BulletFormat::setType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/#setType-int-) na [BulletType::Symbol](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bullettype/) i określ znak wypunktowania.
8. Ustaw tekst akapitu, wcięcie, kolor wypunktowania i wysokość wypunktowania.
9. Dodaj akapit do ramki tekstowej.
10. Utwórz drugi akapit i ustaw [BulletFormat::setType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/#setType-int-) na [BulletType::Numbered](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bullettype/).
11. Skonfiguruj styl numerowanego wypunktowania i dodaj akapit do ramki tekstowej.
12. Zapisz prezentację.

Ten przykład w PHP tworzy wypunktowanie symboliczne oraz numerowane:

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Użycie wypunktowań graficznych**

Wypunktowania graficzne pozwalają użyć własnego obrazu zamiast symbolu lub liczby.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu poprzez jego indeks.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) i uzyskaj dostęp do jego [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/).
4. Usuń domyślny akapit z ramki tekstowej.
5. Załaduj obraz wypunktowania i dodaj go do kolekcji obrazów prezentacji jako [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/).
6. Utwórz [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/) i ustaw jego tekst.
7. Ustaw [BulletFormat::setType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/#setType-int-) na [BulletType::Picture](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bullettype/).
8. Przypisz obraz za pomocą [BulletFormat::getPicture](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/#getPicture--) i ustaw wysokość wypunktowania.
9. Dodaj akapit do ramki tekstowej.
10. Zapisz zmodyfikowaną prezentację.

Ten przykład w PHP tworzy wypunktowanie graficzne:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **Tworzenie listy wielopoziomowej**

Ustaw [ParagraphFormat::setDepth](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#setDepth-short-) aby umieścić akapity na różnych poziomach listy. Najwyższy poziom ma głębokość `0`.

1. Utwórz [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i uzyskaj dostęp do slajdu.
2. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) i usuń domyślny akapit z jego ramki tekstowej.
3. Utwórz cztery akapity i skonfiguruj ich symbole wypunktowania.
4. Ustaw ich wartości [ParagraphFormat::setDepth](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#setDepth-short-) na `0`, `1`, `2` i `3`.
5. Dodaj akapity do ramki tekstowej i zapisz prezentację.

Ten przykład w PHP tworzy listę wypunktowaną czteropoziomową:

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Rozpoczęcie numeracji listy od wartości niestandardowych**

Użyj [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) aby ustawić początkowy numer wyświetlany dla numerowanego akapitu.

1. Utwórz [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
2. Usuń domyślny akapit z ramki tekstowej kształtu.
3. Utwórz trzy numerowane akapity.
4. Ustaw [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) na `2`, `3` i `7` dla odpowiednich akapitów.
5. Dodaj akapity do ramki tekstowej i zapisz prezentację.

Ten przykład w PHP przypisuje niestandardowy numer początkowy do każdego akapitu:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kontrola układu akapitu i właściwości końcowych**

### **Ustawienie wcięcia pierwszej linii**

Użyj [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#setIndent-float-) aby kontrolować wcięcie pierwszej linii akapitu. Metoda ta przesuwa tylko pierwszą linię względem lewego marginesu akapitu. Dodatnia wartość przesuwa pierwszą linię w prawo, natomiast pozostałe linie pozostają wyrównane do ciała akapitu.

Użyj [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) gdy potrzebujesz przesunąć cały akapit. Użyj [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#setIndent-float-) gdy potrzebujesz przesunąć tylko pierwszą linię.

Poniższy przykład tworzy kilka akapitów i stosuje różne wartości [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#setIndent-float-) w celu pokazania, jak wcięcie pierwszej linii wpływa na układ akapitu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątną [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) kształtu i usuń domyślny akapit.
5. Utwórz kilka akapitów i ustaw różne wartości [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#setIndent-float-) dla nich.
6. Dodaj akapity do ramki tekstowej.
7. Zapisz zmodyfikowaną prezentację.

Ten kod w PHP pokazuje, jak ustawić wcięcie akapitu:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![The first-line indent of the paragraphs](first_line_indent.png)

### **Ustawienie wcięcia wiszącego**

Wcięcie wiszące to układ akapitu, w którym pierwsza linia zaczyna się po lewej stronie pozostałych linii. W Aspose.Slides tworzysz ten efekt przy pomocy [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#setIndent-float-). Przekaż wartość ujemną, aby przesunąć pierwszą linię w lewo względem ciała akapitu.

W praktyce [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) określa lewą pozycję ciała akapitu, a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#setIndent-float-) określa pozycję pierwszej linii względem tego marginesu. Aby utworzyć wcięcie wiszące, podaj dodatnią wartość do `setMarginLeft` i ujemną wartość do `setIndent`.

To formatowanie jest przydatne w bibliografiach, odnośnikach, hasłach słownika i innych akapitach, w których zawijane linie muszą być wyrównane pod ciałem akapitu, a nie pod pierwszym znakiem pierwszej linii.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątną [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) kształtu i usuń domyślny akapit.
5. Utwórz akapity i podaj dodatnią wartość do [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) dla każdego akapitu.
6. Przekaż ujemną wartość do [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#setIndent-float-) aby uzyskać efekt wcięcia wiszącego.
7. Dodaj akapity do ramki tekstowej.
8. Zapisz zmodyfikowaną prezentację.

Ten kod w PHP pokazuje, jak ustawić wcięcie wiszące dla akapitu:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![The hanging indent of the paragraphs](hanging_indent.png)

### **Ustawienie właściwości końcowych akapitu**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) kontroluje formatowanie znaku końcowego akapitu. Poniższy przykład w PHP przypisuje rozmiar czcionki i czcionkę łacińską do znaku końcowego drugiego akapitu:

1. Załaduj [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i uzyskaj dostęp do slajdu.
2. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) i wyczyść jego domyślny akapit.
3. Utwórz dwa akapity i dodaj do nich fragmenty tekstu.
4. Utwórz [PortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portionformat/) dla znaku końcowego drugiego akapitu.
5. Ustaw [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) i [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Przypisz format za pomocą [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) i zapisz prezentację.

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Import i eksport zawartości akapitu**

### **Import tekstu HTML do akapitów**

Użyj [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) aby przekształcić znacznik HTML w akapity i fragmenty w ramce tekstowej.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do slajdu i dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/).
3. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) kształtu i usuń jego domyślny akapit.
4. Odczytaj źródłowy plik HTML.
5. Przekaż ciąg HTML do [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Zapisz zmodyfikowaną prezentację.

Ten przykład w PHP importuje HTML do ramki tekstowej:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **Eksport tekstu akapitu do HTML**

Użyj [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) aby wyeksportować wybrany zakres akapitów jako HTML.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i załaduj wymaganą prezentację.
2. Uzyskaj dostęp do slajdu i znajdź [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) zawierający tekst.
3. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) kształtu.
4. Wywołaj [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) z indeksem początkowym akapitu oraz liczbą akapitów do wyeksportowania.
5. Zapisz zwrócony ciąg HTML do pliku.

Ten przykład w PHP eksportuje wszystkie akapity z pierwszego kształtu tekstowego:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **Renderowanie akapitu jako obrazu**

[Paragraph::getImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/#getImage--) renderuje pojedynczy akapit bezpośrednio i zwraca [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/). Zapisz wynik do pliku lub strumienia przy pomocy [IImage::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/#save-java.lang.String-int-). Nie musisz renderować całego kształtu ani ręcznie przycinać bitmapy.

[Paragraph::getImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/#getImage--) może zwrócić `null`, jeśli akapit nie zostanie odnaleziony w kolekcji nadrzędnej, nie ma prawidłowych granic renderowania lub nie może być renderowany. Sprawdź wynik przed zapisem i zwolnij zwrócony obraz po użyciu.

#### **Renderowanie akapitu w domyślnej skali**

Załóżmy, że mamy plik prezentacji o nazwie sample.pptx z jednym slajdem, w którym pierwszy kształt jest polem tekstowym zawierającym trzy akapity.

![The text box with three paragraphs](paragraph_to_image_input.png)

Poniższy przykład w PHP renderuje drugi akapit w zwykłym polu tekstowym w domyślnej skali i zapisuje zwrócony obraz w formacie PNG. Blok `finally` zapewnia prawidłowe zwolnienie obrazu.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

Wynik:

![The paragraph image](paragraph_to_image_output.png)

#### **Renderowanie akapitu w komórce tabeli ze skalowaniem**

Użyj przeciążenia [Paragraph::getImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/#getImage-float-float-) przyjmującego parametry `$scaleX` i `$scaleY`, aby ustawić współczynniki skali poziomej i pionowej. Poniższy przykład w PHP tworzy tabelę, renderuje akapit w jej pierwszej komórce przy dwukrotnej szerokości i wysokości względem domyślnej, i zapisuje wynik jako obraz PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

Współczynnik skali `1` pozostawia tę oś w domyślnym rozmiarze pikselowym. Na przykład `2` dla obu współczynników powoduje, że obraz ma szerokość i wysokość około dwukrotnie większe niż domyślne wymiary, co daje czterokrotnie więcej pikseli. Większe współczynniki zazwyczaj zwiększają ostrość tekstu przy powiększaniu lub wyjściu o wysokiej rozdzielczości, ale także zwiększają zużycie pamięci i rozmiar pliku. Współczynniki poniżej `1` tworzą mniejsze obrazy z mniejszą ilością detali. Używaj równych współczynników, aby zachować proporcje akapitu; różne współczynniki poziome i pionowe rozciągają obraz niezależnie.

Renderowanie całego kształtu przy pomocy [Shape::getImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getImage--) pozostaje przydatne, gdy wynik musi obejmować wypełnienie, obramowanie lub inny kontekst wizualny kształtu. Dla obrazu tylko akapitu użyj [Paragraph::getImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/#getImage--).

## **FAQ**

**Czy mogę całkowicie wyłączyć łamanie wierszy wewnątrz ramki tekstowej?**

Tak. Ustaw [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/#setWrapText-byte-) aby wyłączyć zawijanie, tak aby linie nie łamały się przy krawędziach ramki tekstowej.

**Jak uzyskać dokładne granice na slajdzie określonego akapitu?**

Użyj [Paragraph::getRect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/#getRect--) aby pobrać prostokąt otaczający akapit. [Portion::getRect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/#getRect--) podaje granice pojedynczego fragmentu.

**Gdzie kontrolowane jest wyrównanie akapitu (lewe, prawe, wyśrodkowane lub wyjustowane)?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#setAlignment-int-) jest ustawieniem na poziomie akapitu i ma zastosowanie do całego akapitu, niezależnie od formatowania poszczególnych fragmentów.

**Czy mogę ustawić język korekty dla części akapitu?**

Tak. Ustaw [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) dla poszczególnych fragmentów, aby jeden akapit mógł zawierać tekst w wielu językach.