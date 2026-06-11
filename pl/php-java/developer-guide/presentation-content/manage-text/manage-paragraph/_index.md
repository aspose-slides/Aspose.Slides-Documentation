---
title: Zarządzanie akapitami tekstu PowerPoint w PHP
linktitle: Zarządzaj akapitem
type: docs
weight: 40
url: /pl/php-java/manage-paragraph/
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
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Opanuj formatowanie akapitów przy użyciu Aspose.Slides dla PHP poprzez Java — optymalizuj wyrównanie, odstępy i styl w prezentacjach PPT, PPTX i ODP."
---
## **Wprowadzenie**

Aspose.Slides udostępnia wszystkie klasy niezbędne do pracy z tekstami, akapitami i fragmentami w programie PowerPoint.

* Aspose.Slides udostępnia klasę [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) pozwalającą dodać obiekty reprezentujące akapit. Obiekt `TextFame` może mieć jeden lub wiele akapitów (każdy akapit tworzony jest przez znak powrotu karetki).
* Aspose.Slides udostępnia klasę [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/) pozwalającą dodać obiekty reprezentujące fragmenty. Obiekt `Paragraph` może mieć jeden lub wiele fragmentów (kolekcja obiektów `Portion`).
* Aspose.Slides udostępnia klasę [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/) pozwalającą dodać obiekty reprezentujące teksty oraz ich właściwości formatowania.

Obiekt `Paragraph` jest w stanie obsługiwać teksty o różnych właściwościach formatowania za pośrednictwem swoich podległych obiektów `Portion`.

## **Dodawanie wielu akapitów zawierających wiele fragmentów**

Poniższe kroki pokazują, jak dodać ramkę tekstową zawierającą 3 akapity, a każdy akapit zawierający 3 fragmenty:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj prostokątną [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
4. Pobierz ITextFrame powiązany z [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/).
5. Utwórz dwa obiekty [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/), a następnie dodaj je do kolekcji akapitów [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/).
6. Utwórz trzy obiekty [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/) dla każdego nowego `Paragraph` (dwa obiekty `Portion` dla domyślnego akapitu) i dodaj każdy obiekt `Portion` do kolekcji fragmentów odpowiedniego `Paragraph`.
7. Ustaw nieco tekstu dla każdego fragmentu.
8. Zastosuj wybrane właściwości formatowania do każdego fragmentu, używając właściwości formatowania udostępnionych przez obiekt `Portion`.
9. Zapisz zmodyfikowaną prezentację.

```php
# Utwórz instancję klasy Presentation reprezentującej plik PPTX
$pres = new Presentation();
try {
    # Dostęp do pierwszego slajdu
    $slide = $pres->getSlides()->get_Item(0);
    # Dodaj AutoShape typu Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Pobierz TextFrame AutoShape
    $tf = $ashp->getTextFrame();
    # Utwórz akapity i fragmenty o różnych formatach tekstu
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # Zapisz PPTX na dysku
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Zarządzanie wypunktowaniem akapitów**

Listy wypunktowane pomagają szybko i skutecznie organizować oraz prezentować informacje. Akapity z wypunktowaniem są zawsze łatwiejsze do odczytania i zrozumienia.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do wybranego slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) autoshape.
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszą instancję akapitu przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/).
7. Ustaw właściwość `Type` wypunktowania akapitu na `Symbol` i określ znak wypunktowania.
8. Ustaw `Text` akapitu.
9. Ustaw `Indent` akapitu dla wypunktowania.
10. Ustaw kolor wypunktowania.
11. Ustaw wysokość wypunktowania.
12. Dodaj nowy akapit do kolekcji akapitów `TextFrame`.
13. Dodaj drugi akapit i powtórz proces opisany w krokach od 7 do 13.
14. Zapisz prezentację.

```php
# Tworzy instancję klasy Presentation reprezentującej plik PPTX
$pres = new Presentation();
try {
    # Dostęp do pierwszego slajdu
    $slide = $pres->getSlides()->get_Item(0);
    # Dodaje i uzyskuje dostęp do Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Uzyskuje dostęp do ramki tekstowej autoshape
    $txtFrm = $aShp->getTextFrame();
    # Usuwa domyślny akapit
    $txtFrm->getParagraphs()->removeAt(0);
    # Tworzy akapit
    $para = new Paragraph();
    # Ustawia styl i symbol wypunktowania akapitu
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Ustawia tekst akapitu
    $para->setText("Welcome to Aspose.Slides");
    # Ustawia wcięcie wypunktowania
    $para->getParagraphFormat()->setIndent(25);
    # Ustawia kolor wypunktowania
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True); // ustaw IsBulletHardColor na true, aby użyć własnego koloru wypunktowania

    # Ustawia wysokość wypunktowania
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Dodaje akapit do ramki tekstowej
    $txtFrm->getParagraphs()->add($para);
    # Tworzy drugi akapit
    $para2 = new Paragraph();
    # Ustawia typ i styl wypunktowania akapitu
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Dodaje tekst akapitu
    $para2->setText("This is numbered bullet");
    # Ustawia wcięcie wypunktowania
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True); // ustaw IsBulletHardColor na true, aby użyć własnego koloru wypunktowania

    # Ustawia wysokość wypunktowania
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Dodaje akapit do ramki tekstowej
    $txtFrm->getParagraphs()->add($para2);
    # Zapisuje zmodyfikowaną prezentację
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Zarządzanie wypunktowaniem obrazkowym**

Listy wypunktowane pomagają szybko i skutecznie organizować oraz prezentować informacje. Akapity z obrazkami są łatwe do odczytania i zrozumienia.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) autoshape.
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszą instancję akapitu przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/).
7. Wczytaj obraz do [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/).
8. Ustaw typ wypunktowania na [Picture](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bullettype/#Picture) i określ obraz.
9. Ustaw `Text` akapitu.
10. Ustaw `Indent` akapitu dla wypunktowania.
11. Ustaw kolor wypunktowania.
12. Ustaw wysokość wypunktowania.
13. Dodaj nowy akapit do kolekcji akapitów `TextFrame`.
14. Dodaj drugi akapit i powtórz proces na podstawie poprzednich kroków.
15. Zapisz zmodyfikowaną prezentację.

```php
# Tworzy instancję klasy Presentation reprezentującej plik PPTX
$presentation = new Presentation();
try {
    # Uzyskuje dostęp do pierwszego slajdu
    $slide = $presentation->getSlides()->get_Item(0);
    # Tworzy obraz dla wypunktowań
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Dodaje i uzyskuje dostęp do AutoShape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Uzyskuje dostęp do ramki tekstowej autoshape
    $textFrame = $autoShape->getTextFrame();
    # Usuwa domyślny akapit
    $textFrame->getParagraphs()->removeAt(0);
    # Tworzy nowy akapit
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Ustawia styl wypunktowania akapitu i obraz
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Ustawia wysokość wypunktowania
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Dodaje akapit do ramki tekstowej
    $textFrame->getParagraphs()->add($paragraph);
    # Zapisuje prezentację jako plik PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Zapisuje prezentację jako plik PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Zarządzanie wypunktowaniem wielopoziomowym**

Listy wypunktowane pomagają szybko i skutecznie organizować oraz prezentować informacje. Wypunktowanie wielopoziomowe jest łatwe do odczytania i zrozumienia.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) na nowym slajdzie.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) autoshape.
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszą instancję akapitu przy pomocy klasy [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/) i ustaw głębokość na 0.
7. Utwórz drugą instancję akapitu przy pomocy klasy `Paragraph` i ustaw głębokość na 1.
8. Utwórz trzecią instancję akapitu przy pomocy klasy `Paragraph` i ustaw głębokość na 2.
9. Utwórz czwartą instancję akapitu przy pomocy klasy `Paragraph` i ustaw głębokość na 3.
10. Dodaj nowe akapity do kolekcji akapitów `TextFrame`.
11. Zapisz zmodyfikowaną prezentację.

```php
# Tworzy instancję klasy Presentation reprezentującej plik PPTX
$pres = new Presentation();
try {
    # Uzyskuje dostęp do pierwszego slajdu
    $slide = $pres->getSlides()->get_Item(0);
    # Dodaje i uzyskuje dostęp do AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Uzyskuje dostęp do ramki tekstowej utworzonego AutoShape
    $text = $aShp->addTextFrame("");
    # Czyści domyślny akapit
    $text->getParagraphs()->clear();
    # Dodaje pierwszy akapit
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Ustawia poziom wypunktowania
    $para1->getParagraphFormat()->setDepth(0);
    # Dodaje drugi akapit
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Ustawia poziom wypunktowania
    $para2->getParagraphFormat()->setDepth(1);
    # Dodaje trzeci akapit
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Ustawia poziom wypunktowania
    $para3->getParagraphFormat()->setDepth(2);
    # Dodaje czwarty akapit
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Ustawia poziom wypunktowania
    $para4->getParagraphFormat()->setDepth(3);
    # Dodaje akapity do kolekcji
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # Zapisuje prezentację jako plik PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Zarządzanie akapitem z niestandardową listą numerowaną**

Klasa [BulletFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/) udostępnia metodę [setNumberedBulletStartWith](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) oraz inne, które pozwalają zarządzać akapitami z niestandardowym numerowaniem lub formatowaniem.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do slajdu zawierającego akapit.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) autoshape.
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszą instancję akapitu przy pomocy klasy [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/) i ustaw [NumberedBulletStartWith](https://reference.aspose.com/slides/pl/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) na 2.
7. Utwórz drugą instancję akapitu przy pomocy klasy `Paragraph` i ustaw `NumberedBulletStartWith` na 3.
8. Utwórz trzecią instancję akapitu przy pomocy klasy `Paragraph` i ustaw `NumberedBulletStartWith` na 7.
9. Dodaj nowe akapity do kolekcji akapitów `TextFrame`.
10. Zapisz zmodyfikowaną prezentację.

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Uzyskuje dostęp do ramki tekstowej utworzonego autoshape
    $textFrame = $shape->getTextFrame();
    # Usuwa domyślny istniejący akapit
    $textFrame->getParagraphs()->removeAt(0);
    # Pierwsza lista
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Ustaw wcięcie pierwszej linii akapitu**

Użyj metody [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setindent/) aby kontrolować wcięcie pierwszej linii akapitu. Metoda ta przesuwa tylko pierwszą linię względem lewego marginesu akapitu. Wartość dodatnia przesuwa pierwszą linię w prawo, natomiast pozostałe linie pozostają wyrównane do treści akapitu.

Użyj [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setmarginleft/) gdy potrzebujesz przesunąć cały akapit. Użyj [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setindent/) gdy musisz przesunąć tylko pierwszą linię.

Poniższy przykład tworzy kilka akapitów i stosuje różne wartości wcięcia, aby zademonstrować, jak wcięcie pierwszej linii wpływa na układ akapitu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątną [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
4. Dodaj pusty [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) do kształtu i usuń domyślny akapit.
5. Utwórz kilka akapitów i ustaw różne wartości [Indent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setindent/) dla nich.
6. Dodaj akapity do ramki tekstowej.
7. Zapisz zmodyfikowaną prezentację.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
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

![Wcięcie pierwszej linii akapitów](first_line_indent.png)

## **Ustaw wcięcie wiszące dla akapitu**

Wcięcie wiszące to układ akapitu, w którym pierwsza linia zaczyna się po lewej stronie pozostałych linii. W Aspose.Slides tworzysz ten efekt za pomocą metody [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setindent/). Ustaw wcięcie na wartość ujemną, aby przesunąć pierwszą linię w lewo względem treści akapitu.

W praktyce [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setmarginleft/) określa lewą pozycję treści akapitu, a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setindent/) definiuje pozycję pierwszej linii względem tego marginesu. Aby utworzyć wcięcie wiszące, ustaw dodatnią wartość `MarginLeft` i ujemną wartość `Indent`.

To formatowanie jest przydatne w bibliografiach, odniesieniach, hasłach słownika i innych akapitach, w których wiersze podzielone muszą być wyrównane pod treścią akapitu, a nie pod pierwszym znakiem pierwszej linii.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątną [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
4. Dodaj pusty [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) do kształtu i usuń domyślny akapit.
5. Utwórz akapity i ustaw dodatnią wartość [MarginLeft](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setmarginleft/) dla każdego akapitu.
6. Ustaw ujemną wartość [Indent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setindent/) aby uzyskać efekt wcięcia wiszącego.
7. Dodaj akapity do ramki tekstowej.
8. Zapisz zmodyfikowaną prezentację.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
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

![Wcięcie wiszące akapitów](hanging_indent.png)

## **Zarządzanie właściwościami końcowymi akapitu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu zawierającego akapit poprzez jego pozycję.
3. Dodaj prostokątny [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
4. Dodaj [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) z dwoma akapitami do prostokąta.
5. Ustaw wysokość czcionki oraz typ czcionki dla akapitów.
6. Ustaw właściwości End dla akapitów.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Importowanie tekstu HTML do akapitów**

Aspose.Slides zapewnia rozszerzone wsparcie dla importowania tekstu HTML do akapitów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) do slajdu.
4. Dodaj i uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) autoshape.
5. Usuń domyślny akapit w `TextFrame`.
6. Odczytaj źródłowy plik HTML przy użyciu TextReader.
7. Utwórz pierwszą instancję akapitu przy pomocy klasy [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/).
8. Dodaj zawartość pliku HTML odczytaną z TextReader do [ParagraphCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphcollection/) ramki tekstowej.
9. Zapisz zmodyfikowaną prezentację.

```php
# Utwórz pustą instancję prezentacji
$pres = new Presentation();
try {
    # Uzyskaj dostęp do domyślnego pierwszego slajdu prezentacji
    $slide = $pres->getSlides()->get_Item(0);
    # Dodaj AutoShape, aby pomieścić treść HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Dodaj ramkę tekstową do kształtu
    $ashape->addTextFrame("");
    # Wyczyść wszystkie akapity w dodanej ramce tekstowej
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Wczytywanie pliku HTML przy użyciu StreamReader
    $tr = new StreamReader("file.html");
    # Dodaj tekst z czytnika strumienia HTML do ramki tekstowej
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Zapisywanie prezentacji
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Eksportowanie tekstu akapitu do HTML**

Aspose.Slides zapewnia rozszerzone wsparcie dla eksportowania tekstów (zawartych w akapitach) do HTML.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i wczytaj żądaną prezentację.
2. Uzyskaj dostęp do odpowiedniego slajdu.
3. Uzyskaj dostęp do kształtu zawierającego tekst, który ma być wyeksportowany do HTML.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) kształtu.
5. Utwórz instancję `StreamWriter` i dodaj nowy plik HTML.
6. Podaj początkowy indeks do `StreamWriter` i wyeksportuj wybrane akapity.

```php
# Załaduj plik prezentacji
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Uzyskaj dostęp do domyślnego pierwszego slajdu prezentacji
    $slide = $pres->getSlides()->get_Item(0);
    # Żądany indeks
    $index = 0;
    # Dostęp do dodanego kształtu
    $ashape = $slide->getShapes()->get_Item($index);
    # Tworzenie pliku wyjściowego HTML
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Wyodrębnianie pierwszego akapitu jako HTML
    # Zapisywanie danych akapitów do HTML, podając indeks początkowy akapitu i liczbę akapitów do skopiowania
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Zapis akapitu jako obrazu**

W tej sekcji przedstawimy dwa przykłady demonstrujące, jak zapisać akapit tekstowy, reprezentowany przez klasę [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/), jako obraz. Oba przykłady obejmują pobranie obrazu kształtu zawierającego akapit przy użyciu metod `getImage` z klasy [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/), obliczenie granic akapitu w kształcie oraz wyeksportowanie go jako obrazu bitmapowego. Te podejścia umożliwiają wyodrębnienie konkretnych części tekstu z prezentacji PowerPoint i zapisanie ich jako oddzielne obrazy, co może być przydatne w różnych scenariuszach.

Załóżmy, że mamy plik prezentacji o nazwie sample.pptx z jednym slajdem, na którym pierwszy kształt jest polem tekstowym zawierającym trzy akapity.

![Pole tekstowe z trzema akapitami](paragraph_to_image_input.png)

**Przykład 1**

W tym przykładzie uzyskujemy drugi akapit jako obraz. Aby to zrobić, wyodrębniamy obraz kształtu z pierwszego slajdu prezentacji, a następnie obliczamy granice drugiego akapitu w ramce tekstowej kształtu. Akapit jest następnie rysowany na nowym obrazie bitmapowym, który jest zapisywany w formacie PNG. Metoda ta jest szczególnie przydatna, gdy trzeba zapisać konkretny akapit jako oddzielny obraz, zachowując dokładne wymiary i formatowanie tekstu.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Zapisz kształt w pamięci jako bitmapę.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Utwórz bitmapę kształtu z pamięci.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Oblicz granice drugiego akapitu.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Oblicz współrzędne i rozmiar obrazu wyjściowego (minimalny rozmiar - 1x1 piksel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Przytnij bitmapę kształtu, aby uzyskać tylko bitmapę akapitu.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

![Obraz akapitu](paragraph_to_image_output.png)

**Przykład 2**

W tym przykładzie rozszerzamy poprzednie podejście, dodając współczynniki skalowania do obrazu akapitu. Kształt jest wyodrębniany z prezentacji i zapisywany jako obraz ze współczynnikiem skalowania `2`. Pozwala to uzyskać wyjście o wyższej rozdzielczości przy eksportowaniu akapitu. Granice akapitu są następnie obliczane z uwzględnieniem skali. Skalowanie może być szczególnie przydatne, gdy potrzebny jest bardziej szczegółowy obraz, na przykład do zastosowań w wysokiej jakości materiałach drukowanych.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Zapisz kształt w pamięci jako bitmapę ze skalowaniem.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Utwórz bitmapę kształtu z pamięci.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Oblicz granice drugiego akapitu.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Oblicz współrzędne i rozmiar obrazu wyjściowego (minimalny rozmiar - 1x1 piksel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Przytnij bitmapę kształtu, aby uzyskać tylko bitmapę akapitu.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Czy mogę całkowicie wyłączyć zawijanie wierszy w ramce tekstowej?**

Tak. Użyj ustawienia zawijania ramki tekstowej ([setWrapText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/setwraptext/)), aby wyłączyć zawijanie, dzięki czemu wiersze nie będą łamane przy krawędziach ramki.

**Jak mogę uzyskać dokładne granice konkretnego akapitu na slajdzie?**

Możesz pobrać prostokąt ograniczający akapit (a nawet pojedynczy fragment), aby poznać jego dokładną pozycję i rozmiar na slajdzie.

**Gdzie sterowane jest wyrównanie akapitu (lewo/prawo/środek/wyjustowanie)?**

[Alignment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setalignment/) jest ustawieniem na poziomie akapitu w [ParagraphFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/); ma zastosowanie do całego akapitu, niezależnie od formatowania poszczególnych fragmentów.

**Czy mogę ustawić język sprawdzania pisowni tylko dla części akapitu (np. jednego słowa)?**

Tak. Język jest ustawiany na poziomie fragmentu ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setLanguageId)), więc w jednym akapicie mogą współistnieć różne języki.