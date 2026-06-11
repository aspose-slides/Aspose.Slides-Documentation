---
title: Zarządzaj listami wypunktowanymi i numerowanymi w prezentacjach przy użyciu PHP
linktitle: Zarządzaj listami
type: docs
weight: 60
url: /pl/php-java/manage-lists/
keywords:
- wypunktowanie
- lista wypunktowana
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
description: "Dowiedz się, jak tworzyć i formatować listy wypunktowane, obrazkowe, wielopoziomowe i numerowane w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for PHP via Java."
---
## **Przegląd**

Aspose.Slides for PHP via Java umożliwia tworzenie i formatowanie list wypunktowanych i numerowanych w prezentacjach PowerPoint oraz OpenDocument. Element listy to akapit, którego ustawienia wypunktowania są kontrolowane za pomocą formatu akapitu.

Użyj metody [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/#getParagraphFormat--) aby uzyskać dostęp do ustawień listy na poziomie akapitu. Głównym punktem wejścia jest [ParagraphFormat.getBullet](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#getBullet--) który zwraca obiekt [BulletFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/). Za jego pomocą możesz ustawić typ wypunktowania, symbol, obraz, kolor, rozmiar, styl numeracji oraz numer początkowy.

Ten artykuł pokazuje, jak:

- utworzyć listę wypunktowaną z niestandardowym symbolem
- utworzyć wypunktowanie obrazkowe
- utworzyć listę wielopoziomową, ustawiając głębokość akapitu
- utworzyć listę numerowaną
- przeglądać i zmieniać formatowanie listy w istniejącej prezentacji

## **Utworzyć listę wypunktowaną**

Aby utworzyć listę wypunktowaną, dodaj obiekty [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/) do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) i ustaw [BulletFormat.setType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/#setType-int-) na [BulletType.Symbol](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bullettype/#Symbol). Następnie możesz ustawić [BulletFormat.setChar](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/#setChar-char-), [BulletFormat.getColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/#getColor--) oraz [BulletFormat.setHeight](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/#setHeight-float-) aby kontrolować wygląd wypunktowania.

Poniższy kod PHP demonstruje, jak utworzyć listę wypunktowaną na slajdzie:

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Wynik:

![Symbole wypunktowań](symbol_bullets.png)

## **Utworzyć listę numerowaną**

Używaj list numerowanych, gdy kolejność elementów ma znaczenie. Ustaw [BulletFormat.setType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/#setType-int-) na [BulletType.Numbered](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bullettype/#Numbered). Możesz także wybrać format numeracji za pomocą [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) lub ustawić [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-), gdy lista ma zaczynać się od wartości innej niż 1.

Poniższy kod PHP pokazuje, jak utworzyć listę numerowaną na slajdzie:

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Wynik:

![Wypunktowanie numerowane](numbered_bullets.png)

## **Utworzyć wypunktowanie obrazkowe**

Aspose.Slides pozwala zamienić standardowy symbol wypunktowania na obraz. Obrazkowe wypunktowania działają najlepiej z prostymi grafikami, które pozostają czytelne w małym rozmiarze, takimi jak ikony lub małe przezroczyste pliki PNG.

{{% alert color="primary" %}}
Idealnie, jeśli planujesz zastąpić standardowy symbol wypunktowania obrazem, najlepiej wybrać prostą grafikę z przezroczystym tłem. Takie obrazy sprawdzają się dobrze jako niestandardowe symbole wypunktowania.
{{% /alert %}}

Miej na uwadze, że obraz zostanie przeskalowany do bardzo małego rozmiaru. Z tego powodu zdecydowanie zalecamy wybranie obrazu, który pozostaje wyraźny i wizualnie skuteczny, gdy jest używany jako wypunktowanie w liście.

Aby utworzyć wypunktowanie obrazkowe, dodaj obraz do [Presentation.getImages](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getImages--) i przypisz zwrócony obiekt [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) do [BulletFormat.getPicture](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/#getPicture--). Ustaw [BulletFormat.setType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/#setType-int-) na [BulletType.Picture](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bullettype/#Picture) przed przypisaniem obrazu.

Załóżmy, że mamy plik „image.png”:

![Obraz dla wypunktowań](picture_for_bullets.png)

Poniższy kod PHP pokazuje, jak utworzyć obrazkowe wypunktowania na slajdzie:

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Wynik:

![Wypunktowanie obrazkowe](picture_bullets.png)

## **Utworzyć listę wielopoziomową**

Użyj [ParagraphFormat.setDepth](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#setDepth-short-) aby umieścić elementy listy na różnych poziomach. Poziom 0 to poziom główny, poziom 1 jest zagnieżdżony pod nim, i tak dalej.

Poniższy kod PHP pokazuje, jak utworzyć wielopoziomową listę wypunktowaną:

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Wynik:

![Lista wielopoziomowa](multilevel_list.png)

## **Zmienić istniejącą listę**

Aby zmienić formatowanie listy w istniejącej prezentacji, uzyskaj dostęp do docelowego akapitu i zaktualizuj jego ustawienia [ParagraphFormat.getBullet](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#getBullet--). Te same właściwości używane do tworzenia list mogą być użyte do przeglądania lub modyfikacji list wczytanych z pliku PPT, PPTX lub ODP.

Poniższy kod PHP zmienia pierwszy akapit w ramce tekstowej, aby używał stylu listy numerowanej:

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Czy listy wypunktowane i numerowane mogą być eksportowane do PDF lub obrazów?**

Tak. Aspose.Slides zachowuje formatowanie list, gdy docelowy format obsługuje odpowiednie układy tekstu i funkcje wypunktowania.

**Czy mogę edytować listy w istniejących prezentacjach?**

Tak. Załaduj prezentację, uzyskaj dostęp do docelowego akapitu, przeglądaj lub zaktualizuj jego ustawienia [ParagraphFormat.getBullet](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/#getBullet--) i zapisz prezentację.

**Czy listy mogą zawierać tekst niełaciński?**

Tak. Tekst elementów listy może zawierać znaki Unicode, więc możesz tworzyć listy w prezentacjach wielojęzycznych. Upewnij się, że czcionki użyte w prezentacji obsługują potrzebne znaki.