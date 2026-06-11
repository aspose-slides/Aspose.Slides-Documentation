---
title: Zarządzanie akapitami tekstu PowerPoint w JavaScript
linktitle: Zarządzaj akapitem
type: docs
weight: 40
url: /pl/nodejs-java/manage-paragraph/
keywords:
- dodaj tekst
- dodaj akapit
- zarządzaj tekstem
- zarządzaj akapitem
- zarządzaj wypunktowaniem
- wcięcie akapitu
- wcięcie zwisające
- wypunktowanie akapitu
- lista numerowana
- lista punktowana
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Opanuj formatowanie akapitów za pomocą Aspose.Slides dla Node.js w Java—optymalizuj wyrównanie, odstępy i styl w prezentacjach PPT, PPTX i ODP w JavaScript."
---
## **Wprowadzenie**

Aspose.Slides zapewnia wszystkie klasy i klasy, których potrzebujesz do pracy z tekstami, akapitami i fragmentami PowerPoint w języku Java.

* Aspose.Slides udostępnia klasę [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) umożliwiającą dodawanie obiektów reprezentujących akapit. Obiekt `TextFame` może mieć jeden lub wiele akapitów (każdy akapit jest tworzony poprzez znak powrotu karetki).
* Aspose.Slides udostępnia klasę [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) umożliwiającą dodawanie obiektów reprezentujących fragmenty. Obiekt `Paragraph` może mieć jeden lub wiele fragmentów (kolekcja obiektów fragmentu tekstu).
* Aspose.Slides udostępnia klasę [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/) umożliwiającą dodawanie obiektów reprezentujących teksty i ich właściwości formatowania.

Obiekt `Paragraph` jest w stanie obsługiwać teksty o różnych właściwościach formatowania za pośrednictwem swoich wewnętrznych obiektów `Portion`.

## **Dodaj wiele akapitów zawierających wiele fragmentów**

Poniższe kroki pokazują, jak dodać ramkę tekstową zawierającą 3 akapity, a każdy akapit zawierający 3 fragmenty:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj odniesienie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj prostokątny [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Pobierz obiekt `ITextFrame` powiązany z [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/).
5. Utwórz dwa obiekty [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) i dodaj je do kolekcji `IParagraphs` klasy [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/).
6. Utwórz trzy obiekty [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/) dla każdego nowego `Paragraph` (dwa obiekty `Portion` dla domyślnego akapitu) i dodaj każdy obiekt `Portion` do kolekcji `IPortion` każdego `Paragraph`.
7. Ustaw tekst dla każdego fragmentu.
8. Zastosuj preferowane funkcje formatowania do każdego fragmentu, używając właściwości formatowania udostępnionych przez obiekt `Portion`.
9. Zapisz zmodyfikowaną prezentację.

```javascript
// Utwórz obiekt klasy Presentation reprezentujący plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Dostęp do pierwszego slajdu
    var slide = pres.getSlides().get_Item(0);
    // Dodaj AutoShape typu Prostokąt
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Uzyskaj dostęp do TextFrame auto‑kształtu
    var tf = ashp.getTextFrame();
    // Utwórz akapity i fragmenty o różnych formatach tekstu
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // Zapisz PPTX na dysk
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zarządzanie punktorami akapitu**

Listy punktowane pomagają szybko i efektywnie organizować oraz prezentować informacje. Akapity z punktorami są zawsze łatwiejsze do odczytania i zrozumienia.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj odniesienie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do wybranego slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) auto‑kształtu.
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszą instancję akapitu używając klasy [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/).
7. Ustaw `Type` punktora na `Symbol` i określ znak punktora.
8. Ustaw `Text` akapitu.
9. Ustaw `Indent` akapitu dla punktora.
10. Ustaw kolor punktora.
11. Ustaw wysokość punktora.
12. Dodaj nowy akapit do kolekcji akapitów `TextFrame`.
13. Dodaj drugi akapit i powtórz proces opisany w krokach od 7 do 13.
14. Zapisz prezentację.

```javascript
// Tworzy obiekt klasy Presentation reprezentujący plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var slide = pres.getSlides().get_Item(0);
    // Dodaje i uzyskuje dostęp do AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Uzyskuje dostęp do ramki tekstowej auto‑kształtu
    var txtFrm = aShp.getTextFrame();
    // Usuwa domyślny akapit
    txtFrm.getParagraphs().removeAt(0);
    // Tworzy akapit
    var para = new aspose.slides.Paragraph();
    // Ustawia styl i znak punktora akapitu
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Ustawia tekst akapitu
    para.setText("Welcome to Aspose.Slides");
    // Ustawia wcięcie punktora
    para.getParagraphFormat().setIndent(25);
    // Ustawia kolor punktora
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // ustaw IsBulletHardColor na true, aby użyć własnego koloru punktora
    // Ustawia wysokość punktora
    para.getParagraphFormat().getBullet().setHeight(100);
    // Dodaje akapit do ramki tekstowej
    txtFrm.getParagraphs().add(para);
    // Tworzy drugi akapit
    var para2 = new aspose.slides.Paragraph();
    // Ustawia typ i styl punktora akapitu
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Dodaje tekst akapitu
    para2.setText("This is numbered bullet");
    // Ustawia wcięcie punktora
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // ustaw IsBulletHardColor na true, aby użyć własnego koloru punktora
    // Ustawia wysokość punktora
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Dodaje akapit do ramki tekstowej
    txtFrm.getParagraphs().add(para2);
    // Zapisuje zmodyfikowaną prezentację
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zarządzanie punktorami obrazkowymi**

Listy punktowane pomagają szybko i efektywnie organizować oraz prezentować informacje. Akapity z obrazkowymi punktorami są łatwe do odczytania i zrozumienia.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj odniesienie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) auto‑kształtu.
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszą instancję akapitu używając klasy [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/).
7. Wczytaj obraz do [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/).
8. Ustaw typ punktora na [Picture](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) i określ obraz.
9. Ustaw `Text` akapitu.
10. Ustaw `Indent` akapitu dla punktora.
11. Ustaw kolor punktora.
12. Ustaw wysokość punktora.
13. Dodaj nowy akapit do kolekcji akapitów `TextFrame`.
14. Dodaj drugi akapit i powtórz proces opisany w poprzednich krokach.
15. Zapisz zmodyfikowaną prezentację.

```javascript
// Tworzy obiekt klasy Presentation, który reprezentuje plik PPTX
var presentation = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var slide = presentation.getSlides().get_Item(0);
    // Tworzy obraz dla punktorów
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Dodaje i uzyskuje dostęp do AutoShape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Uzyskuje dostęp do ramki tekstowej auto‑kształtu
    var textFrame = autoShape.getTextFrame();
    // Usuwa domyślny akapit
    textFrame.getParagraphs().removeAt(0);
    // Tworzy nowy akapit
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Ustawia styl punktora akapitu i obraz
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Ustawia wysokość punktora
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Dodaje akapit do ramki tekstowej
    textFrame.getParagraphs().add(paragraph);
    // Zapisuje prezentację jako plik PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Zapisuje prezentację jako plik PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Zarządzanie punktorami wielopoziomowymi**

Listy punktowane pomagają szybko i efektywnie organizować oraz prezentować informacje. Wielopoziomowe punktor są łatwe do odczytania i zrozumienia.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj odniesienie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) w nowym slajdzie.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) auto‑kształtu.
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszą instancję akapitu przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) i ustaw głębokość na 0.
7. Utwórz drugą instancję akapitu przy użyciu klasy `Paragraph` i ustaw głębokość na 1.
8. Utwórz trzecią instancję akapitu przy użyciu klasy `Paragraph` i ustaw głębokość na 2.
9. Utwórz czwartą instancję akapitu przy użyciu klasy `Paragraph` i ustaw głębokość na 3.
10. Dodaj nowe akapity do kolekcji akapitów `TextFrame`.
11. Zapisz zmodyfikowaną prezentację.

```javascript
// Tworzy obiekt klasy Presentation reprezentujący plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var slide = pres.getSlides().get_Item(0);
    // Dodaje i uzyskuje dostęp do AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Uzyskuje dostęp do ramki tekstowej utworzonego AutoShape
    var text = aShp.addTextFrame("");
    // Czyści domyślny akapit
    text.getParagraphs().clear();
    // Dodaje pierwszy akapit
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Ustawia poziom punktora
    para1.getParagraphFormat().setDepth(0);
    // Dodaje drugi akapit
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Ustawia poziom punktora
    para2.getParagraphFormat().setDepth(1);
    // Dodaje trzeci akapit
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Ustawia poziom punktora
    para3.getParagraphFormat().setDepth(2);
    // Dodaje czwarty akapit
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Ustawia poziom punktora
    para4.getParagraphFormat().setDepth(3);
    // Dodaje akapity do kolekcji
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // Zapisuje prezentację jako plik PPTX
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zarządzanie akapitem z niestandardową listą numerowaną**

Klasa [BulletFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bulletformat/) udostępnia właściwość [NumberedBulletStartWith](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) oraz inne, które pozwalają zarządzać akapitami z własnym numerowaniem lub formatowaniem.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do slajdu zawierającego akapit.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) auto‑kształtu.
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszą instancję akapitu przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) i ustaw [NumberedBulletStartWith](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) na 2.
7. Utwórz drugą instancję akapitu przy użyciu klasy `Paragraph` i ustaw `NumberedBulletStartWith` na 3.
8. Utwórz trzecią instancję akapitu przy użyciu klasy `Paragraph` i ustaw `NumberedBulletStartWith` na 7.
9. Dodaj nowe akapity do kolekcji akapitów `TextFrame`.
10. Zapisz zmodyfikowaną prezentację.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Uzyskuje dostęp do ramki tekstowej utworzonego auto‑kształtu
    var textFrame = shape.getTextFrame();
    // Usuwa domyślny istniejący akapit
    textFrame.getParagraphs().removeAt(0);
    // Pierwsza lista
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Ustaw wcięcie pierwszej linii dla akapitu**

Użyj metody [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/), aby kontrolować wcięcie pierwszej linii akapitu. Metoda ta przesuwa wyłącznie pierwszą linię względem lewego marginesu akapitu. Dodatnia wartość przesuwa pierwszą linię w prawo, a pozostałe linie pozostają wyrównane do treści akapitu.

Użyj [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setmarginleft/), gdy potrzebujesz przesunąć cały akapit. Użyj [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/), gdy chcesz przesunąć tylko pierwszą linię.

Poniższy przykład tworzy kilka akapitów i stosuje różne wartości wcięcia, aby pokazać, jak wcięcie pierwszej linii wpływa na układ akapitu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątny [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Dodaj pusty [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) do kształtu i usuń domyślny akapit.
5. Utwórz kilka akapitów i ustaw różne wartości [Indent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/) dla nich.
6. Dodaj akapity do ramki tekstowej.
7. Zapisz zmodyfikowaną prezentację.

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Wynik:

![Wcięcie pierwszej linii akapitów](first_line_indent.png)

## **Ustaw wcięcie zwisające dla akapitu**

Wcięcie zwisające to układ akapitu, w którym pierwsza linia zaczyna się po lewo od pozostałych linii. W Aspose.Slides efekt ten uzyskuje się metodą [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/). Ustaw wcięcie na wartość ujemną, aby przesunąć pierwszą linię w lewo względem treści akapitu.

W praktyce [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) definiuje lewą pozycję treści akapitu, a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/) określa pozycję pierwszej linii względem tego marginesu. Aby utworzyć wcięcie zwisające, ustaw dodatnią wartość `MarginLeft` i ujemną wartość `Indent`.

To formatowanie jest przydatne przy bibliografiach, odnośnikach, hasłach słownikowych i innych akapitach, w których zawijane linie muszą być wyrównane pod treścią akapitu, a nie pod pierwszym znakiem pierwszej linii.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątny [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Dodaj pusty [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) do kształtu i usuń domyślny akapit.
5. Utwórz akapity i ustaw dodatnią wartość [MarginLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) dla każdego akapitu.
6. Ustaw ujemną wartość [Indent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/) aby uzyskać efekt wcięcia zwisającego.
7. Dodaj akapity do ramki tekstowej.
8. Zapisz zmodyfikowaną prezentację.

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Wynik:

![Wcięcie zwisające akapitów](hanging_indent.png)

## **Zarządzanie właściwościami końcowego uruchomienia akapitu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu zawierającego akapit poprzez jego pozycję.
1. Dodaj prostokątny [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Dodaj [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) z dwoma akapitami do prostokąta.
1. Ustaw `FontHeight` i typ czcionki dla akapitów.
1. Ustaw właściwości End dla akapitów.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Importowanie tekstu HTML do akapitów**

Aspose.Slides zapewnia rozszerzone wsparcie dla importowania tekstu HTML do akapitów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj odniesienie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Dodaj i uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) auto‑kształtu.
5. Usuń domyślny akapit w `TextFrame`.
6. Odczytaj źródłowy plik HTML przy użyciu TextReader.
7. Utwórz pierwszą instancję akapitu przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/).
8. Dodaj zawartość pliku HTML odczytaną z TextReader do [ParagraphCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphcollection/) ramki tekstowej.
9. Zapisz zmodyfikowaną prezentację.

```javascript
// Utwórz pustą instancję prezentacji
var pres = new aspose.slides.Presentation();
try {
    // Uzyskaj dostęp do domyślnego pierwszego slajdu prezentacji
    var slide = pres.getSlides().get_Item(0);
    // Dodawanie AutoShape, aby pomieścić treść HTML
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Dodawanie ramki tekstowej do kształtu
    ashape.addTextFrame("");
    // Usuwanie wszystkich akapitów w dodanej ramce tekstowej
    ashape.getTextFrame().getParagraphs().clear();
    // Wczytywanie pliku HTML przy użyciu stream readera
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Dodawanie tekstu z HTML stream readera do ramki tekstowej
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Zapisywanie prezentacji
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Eksportowanie tekstu akapitów do HTML**

Aspose.Slides zapewnia rozszerzone wsparcie dla eksportowania tekstów (zawartych w akapitach) do HTML.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i wczytaj żądaną prezentację.
2. Uzyskaj odniesienie do odpowiedniego slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do kształtu zawierającego tekst, który zostanie wyeksportowany do HTML.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) kształtu.
5. Utwórz instancję `StreamWriter` i dodaj nowy plik HTML.
6. Podaj indeks początkowy do StreamWriter i wyeksportuj wybrane akapity.

```javascript
// Wczytaj plik prezentacji
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Uzyskaj dostęp do domyślnego pierwszego slajdu prezentacji
    var slide = pres.getSlides().get_Item(0);
    // Żądany indeks
    var index = 0;
    // Uzyskiwanie dostępu do dodanego kształtu
    var ashape = slide.getShapes().get_Item(index);
    // Tworzenie wyjściowego pliku HTML
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Eksportowanie pierwszego akapitu jako HTML
    // Zapisywanie danych akapitów do HTML, podając indeks początkowego akapitu oraz liczbę akapitów do skopiowania
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zapis akapitu jako obrazu**

W tej sekcji przedstawiamy dwa przykłady demonstrujące, jak zapisać akapit tekstowy, reprezentowany przez klasę [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/), jako obraz. Oba przykłady obejmują uzyskanie obrazu kształtu zawierającego akapit przy użyciu metod `getImage` z klasy [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/), obliczenie granic akapitu w ramach kształtu oraz eksportowanie go jako obrazu bitmapowego. Podejścia te umożliwiają wyodrębnienie konkretnych fragmentów tekstu z prezentacji PowerPoint i zapisanie ich jako oddzielnych obrazów, co może być przydatne w różnych scenariuszach.

Załóżmy, że mamy plik prezentacji o nazwie sample.pptx z jednym slajdem, gdzie pierwszy kształt to pole tekstowe zawierające trzy akapity.

![Pole tekstowe z trzema akapitami](paragraph_to_image_input.png)

**Przykład 1**

W tym przykładzie uzyskujemy drugi akapit jako obraz. W tym celu wyodrębniamy obraz kształtu z pierwszego slajdu prezentacji, a następnie obliczamy granice drugiego akapitu w ramce tekstowej kształtu. Akapit zostaje następnie narysowany na nowym obrazie bitmapowym, który jest zapisywany w formacie PNG. Metoda ta jest szczególnie przydatna, gdy trzeba zapisać konkretny akapit jako oddzielny obraz, zachowując dokładne wymiary i formatowanie tekstu.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Zapisz kształt w pamięci jako bitmapę.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Utwórz bitmapę kształtu z pamięci.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Oblicz granice drugiego akapitu.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Oblicz współrzędne i rozmiar obrazu wyjściowego (minimalny rozmiar - 1x1 piksel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Przytnij bitmapę kształtu, aby uzyskać wyłącznie bitmapę akapitu.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Wynik:

![Obraz akapitu](paragraph_to_image_output.png)

**Przykład 2**

W tym przykładzie rozszerzamy poprzednie podejście, dodając współczynniki skalowania do obrazu akapitu. Kształt jest wyodrębniany z prezentacji i zapisywany jako obraz ze współczynnikiem skalowania równym `2`. Dzięki temu uzyskuje się wyższą rozdzielczość przy eksporcie akapitu. Granice akapitu są następnie obliczane z uwzględnieniem skali. Skalowanie może być szczególnie użyteczne, gdy potrzebny jest bardziej szczegółowy obraz, np. do wysokiej jakości materiałów drukowanych.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Zapisz kształt w pamięci jako bitmapę ze skalowaniem.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Utwórz bitmapę kształtu z pamięci.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Oblicz granice drugiego akapitu.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Oblicz współrzędne i rozmiar obrazu wyjściowego (minimalny rozmiar - 1x1 piksel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Przytnij bitmapę kształtu, aby uzyskać wyłącznie bitmapę akapitu.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Czy mogę całkowicie wyłączyć łamanie linii w ramce tekstowej?**

Tak. Użyj ustawienia zawijania tekstu ramki ([setWrapText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/setwraptext/)), aby wyłączyć zawijanie, dzięki czemu linie nie będą łamane przy krawędziach ramki.

**Jak mogę uzyskać dokładne granice akapitu na slajdzie?**

Możesz pobrać prostokąt otaczający akapit (a nawet pojedynczy fragment), aby poznać jego precyzyjne położenie i rozmiar na slajdzie.

**Gdzie kontrolowane jest wyrównanie akapitu (lewe/prawe/środkowe/wyjustowane)?**

[setAlignment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setalignment/) jest metodą ustawiającą wyrównanie na poziomie akapitu w [ParagraphFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/); dotyczy całego akapitu, niezależnie od formatowania poszczególnych fragmentów.

**Czy mogę ustawić język sprawdzania pisowni tylko dla części akapitu (np. jednego słowa)?**

Tak. Język jest ustawiany na poziomie fragmentu ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), więc w jednym akapicie mogą współistnieć różne języki.