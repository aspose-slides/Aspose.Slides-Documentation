---
title: Zarządzanie akapitami tekstowymi PowerPoint w Javie
linktitle: Zarządzaj akapitem
type: docs
weight: 40
url: /pl/java/manage-paragraph/
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
- Java
- Aspose.Slides
description: "Mistrzowskie formatowanie akapitów z Aspose.Slides dla Javy — optymalizuj wyrównanie, odstępy i styl w prezentacjach PPT, PPTX i ODP w Javie."
---
## **Wprowadzenie**

Aspose.Slides zapewnia wszystkie interfejsy i klasy niezbędne do pracy z tekstami, akapitami i fragmentami PowerPoint w języku Java.

* Aspose.Slides udostępnia interfejs [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) umożliwiający dodawanie obiektów reprezentujących akapit. Obiekt `ITextFame` może mieć jeden lub wiele akapitów (każdy akapit tworzony jest poprzez znak powrotu karetki).
* Aspose.Slides udostępnia interfejs [IParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraph/) umożliwiający dodawanie obiektów reprezentujących fragmenty. Obiekt `IParagraph` może mieć jeden lub wiele fragmentów (kolekcja obiektów iPortions).
* Aspose.Slides udostępnia interfejs [IPortion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/) umożliwiający dodawanie obiektów reprezentujących teksty i ich właściwości formatowania. 

Obiekt `IParagraph` jest w stanie obsługiwać teksty z różnymi właściwościami formatowania poprzez znajdujące się pod nim obiekty `IPortion`.

## **Dodaj wiele akapitów zawierających wiele fragmentów**

Te kroki pokazują, jak dodać ramkę tekstową zawierającą 3 akapity, a każdy akapit zawierający 3 fragmenty:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj prostokątny [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
4. Pobierz ITextFrame powiązany z [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/).
5. Utwórz dwa obiekty [IParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraph/) i dodaj je do kolekcji `IParagraphs` [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/).
6. Utwórz trzy obiekty [IPortion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/) dla każdego nowego `IParagraph` (dwa obiekty Portion dla domyślnego akapitu) i dodaj każdy obiekt `IPortion` do kolekcji IPortion każdego `IParagraph`.
7. Ustaw tekst dla każdego fragmentu.
8. Zastosuj wybrane funkcje formatowania do każdego fragmentu, używając właściwości formatowania udostępnionych przez obiekt `IPortion`.
9. Zapisz zmodyfikowaną prezentację.

```java
// Utwórz klasę Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Uzyskiwanie pierwszego slajdu
    ISlide slide = pres.getSlides().get_Item(0);

    // Dodaj AutoShape typu Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Uzyskaj TextFrame AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Utwórz akapity i fragmenty o różnych formatach tekstu
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    //    Zapisz PPTX na dysku
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zarządzanie wypunktowaniem akapitu**

Listy wypunktowane pomagają szybko i efektywnie organizować oraz prezentować informacje. Akapity z wypunktowaniem są zawsze łatwiejsze do odczytania i zrozumienia.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [autokształt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do wybranego slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) autokształtu. 
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszy akapit przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/paragraph/).
7. Ustaw `Type` wypunktowania dla akapitu na `Symbol` i określ znak wypunktowania.
8. Ustaw `Text` akapitu.
9. Ustaw `Indent` akapitu dla wypunktowania.
10. Ustaw kolor wypunktowania.
11. Ustaw wysokość wypunktowania.
12. Dodaj nowy akapit do kolekcji akapitów `TextFrame`.
13. Dodaj drugi akapit i powtórz proces opisany w krokach 7‑13.
14. Zapisz prezentację.

```java
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Dodaje i uzyskuje dostęp do Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Uzyskuje dostęp do ramki tekstowej autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Usuwa domyślny akapit
    txtFrm.getParagraphs().removeAt(0);

    // Tworzy akapit
    Paragraph para = new Paragraph();

    // Ustawia styl wypunktowania akapitu i symbol
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Ustawia tekst akapitu
    para.setText("Welcome to Aspose.Slides");

    // Ustawia wcięcie wypunktowania
    para.getParagraphFormat().setIndent(25);

    // Ustawia kolor wypunktowania
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // ustaw IsBulletHardColor na true, aby użyć własnego koloru wypunktowania

    // Ustawia wysokość wypunktowania
    para.getParagraphFormat().getBullet().setHeight(100);

    // Dodaje akapit do ramki tekstowej
    txtFrm.getParagraphs().add(para);

    // Tworzy drugi akapit
    Paragraph para2 = new Paragraph();

    // Ustawia typ i styl wypunktowania akapitu
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Dodaje tekst akapitu
    para2.setText("This is numbered bullet");

    // Ustawia wcięcie wypunktowania
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // ustaw IsBulletHardColor na true, aby użyć własnego koloru wypunktowania

    // Ustawia wysokość wypunktowania
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Dodaje akapit do ramki tekstowej
    txtFrm.getParagraphs().add(para2);
    
    // Zapisuje zmodyfikowaną prezentację
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zarządzanie wypunktowaniem obrazkowym**

Listy wypunktowane pomagają szybko i efektywnie organizować oraz prezentować informacje. Akapity z obrazkami są łatwe do odczytania i zrozumienia.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [autokształt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) autokształtu. 
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszy akapit przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/paragraph/).
7. Załaduj obraz w [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/).
8. Ustaw typ wypunktowania na [Picture](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/) i przypisz obraz.
9. Ustaw `Text` akapitu.
10. Ustaw `Indent` akapitu dla wypunktowania.
11. Ustaw kolor wypunktowania.
12. Ustaw wysokość wypunktowania.
13. Dodaj nowy akapit do kolekcji akapitów `TextFrame`.
14. Dodaj drugi akapit i powtórz proces opisany w poprzednich krokach.
15. Zapisz zmodyfikowaną prezentację.

```java
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
Presentation presentation = new Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tworzy obraz dla wypunktowań
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Dodaje i uzyskuje dostęp do Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Uzyskuje dostęp do ramki tekstowej autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Usuwa domyślny akapit
    textFrame.getParagraphs().removeAt(0);

    // Tworzy nowy akapit
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Ustawia styl wypunktowania akapitu i obraz
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Ustawia wysokość wypunktowania
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Dodaje akapit do ramki tekstowej
    textFrame.getParagraphs().add(paragraph);

    // Zapisuje prezentację jako plik PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Zapisuje prezentację jako plik PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Zarządzanie wielopoziomowym wypunktowaniem**

Listy wypunktowane pomagają szybko i efektywnie organizować oraz prezentować informacje. Wielopoziomowe wypunktowania są łatwe do odczytania i zrozumienia.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [autokształt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) w nowym slajdzie.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) autokształtu. 
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszy akapit przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/paragraph/) i ustaw głębokość na 0.
7. Utwórz drugi akapit przy użyciu klasy `Paragraph`, ustawiając głębokość na 1.
8. Utwórz trzeci akapit przy użyciu klasy `Paragraph`, ustawiając głębokość na 2.
9. Utwórz czwarty akapit przy użyciu klasy `Paragraph`, ustawiając głębokość na 3.
10. Dodaj nowe akapity do kolekcji akapitów `TextFrame`.
11. Zapisz zmodyfikowaną prezentację.

```java
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide slide = pres.getSlides().get_Item(0);

    // Dodaje i uzyskuje dostęp do Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Uzyskuje dostęp do ramki tekstowej utworzonego autoshape
    ITextFrame text = aShp.addTextFrame("");

    // Czyści domyślny akapit
    text.getParagraphs().clear();

    // Dodaje pierwszy akapit
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Ustawia poziom wypunktowania
    para1.getParagraphFormat().setDepth((short)0);

    // Dodaje drugi akapit
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Ustawia poziom wypunktowania
    para2.getParagraphFormat().setDepth((short)1);

    // Dodaje trzeci akapit
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Ustawia poziom wypunktowania
    para3.getParagraphFormat().setDepth((short)2);

    // Dodaje czwarty akapit
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Ustawia poziom wypunktowania
    para4.getParagraphFormat().setDepth((short)3);

    // Dodaje akapity do kolekcji
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Zapisuje prezentację jako plik PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zarządzanie akapitem z niestandardową listą numerowaną**

Interfejs [IBulletFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibulletformat/) udostępnia własność [NumberedBulletStartWith](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) oraz inne, które pozwalają zarządzać akapitami z niestandardowym numerowaniem lub formatowaniem. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do slajdu zawierającego akapit.
3. Dodaj [autokształt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) autokształtu.
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszy akapit przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/paragraph/) i ustaw [NumberedBulletStartWith](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) na 2.
7. Utwórz drugi akapit przy użyciu klasy `Paragraph` i ustaw `NumberedBulletStartWith` na 3.
8. Utwórz trzeci akapit przy użyciu klasy `Paragraph` i ustaw `NumberedBulletStartWith` na 7.
9. Dodaj nowe akapity do kolekcji akapitów `TextFrame`.
10. Zapisz zmodyfikowaną prezentację.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Uzyskuje dostęp do ramki tekstowej utworzonego autoshape
    ITextFrame textFrame = shape.getTextFrame();

    // Usuwa domyślny istniejący akapit
    textFrame.getParagraphs().removeAt(0);

    // Pierwsza lista
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ustaw wcięcie pierwszej linii dla akapitu**

Użyj metody [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) aby kontrolować wcięcie pierwszej linii akapitu. Metoda ta przesuwa tylko pierwszą linię względem lewego marginesu akapitu. Dodatnia wartość przesuwa pierwszą linię w prawo, natomiast pozostałe linie pozostają wyrównane do ciała akapitu.

Użyj [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) gdy potrzebujesz przesunąć cały akapit. Użyj [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) gdy chcesz przesunąć tylko pierwszą linię.

Poniższy przykład tworzy kilka akapitów i stosuje różne wartości wcięć, aby pokazać, jak wcięcie pierwszej linii wpływa na układ akapitu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątny [AutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/autoshape/) do slajdu.
4. Dodaj pusty [TextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textframe/) do kształtu i usuń domyślny akapit.
5. Utwórz kilka akapitów i ustaw różne wartości [Indent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) dla nich.
6. Dodaj akapity do ramki tekstowej.
7. Zapisz zmodyfikowaną prezentację.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Wynik:

![Wcięcie pierwszej linii akapitów](first_line_indent.png)

## **Ustaw wcięcie wiszące dla akapitu**

Wcięcie wiszące to układ akapitu, w którym pierwsza linia zaczyna się bardziej po lewej niż pozostałe linie. W Aspose.Slides efekt ten uzyskuje się metodą [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Ustaw wcięcie na wartość ujemną, aby przesunąć pierwszą linię w lewo względem ciała akapitu.

W praktyce [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) definiuje lewą pozycję ciała akapitu, a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) określa pozycję pierwszej linii względem tego marginesu. Aby utworzyć wcięcie wiszące, ustaw dodatnią wartość `MarginLeft` i ujemną wartość `Indent`.

To formatowanie jest przydatne w bibliografiach, odnośnikach, hasłach słownika i innych akapitach, w których zawijane linie muszą być wyrównane pod ciałem akapitu, a nie pod pierwszym znakiem pierwszej linii.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątny [AutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/autoshape/) do slajdu.
4. Dodaj pusty [TextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textframe/) do kształtu i usuń domyślny akapit.
5. Utwórz akapity i ustaw dodatnią wartość [MarginLeft](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) dla każdego akapitu.
6. Ustaw ujemną wartość [Indent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) aby uzyskać efekt wcięcia wiszącego.
7. Dodaj akapity do ramki tekstowej.
8. Zapisz zmodyfikowaną prezentację.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Wynik:

![Wcięcie wiszące akapitów](hanging_indent.png)

## **Zarządzanie właściwościami końcowego uruchomienia akapitu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu zawierającego akapit według jego pozycji.
1. Dodaj prostokątny [autokształt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
1. Dodaj [TextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) z dwoma akapitami do prostokąta.
1. Ustaw `FontHeight` oraz typ czcionki dla akapitów.
1. Ustaw właściwości End dla akapitów.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Importowanie tekstu HTML do akapitów**

Aspose.Slides zapewnia rozszerzone wsparcie dla importowania tekstu HTML do akapitów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [autokształt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
4. Dodaj i uzyskaj dostęp do `autokształtu` [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/).
5. Usuń domyślny akapit w `ITextFrame`.
6. Odczytaj źródłowy plik HTML w obiekcie TextReader.
7. Utwórz pierwszy akapit przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/paragraph/).
8. Dodaj zawartość pliku HTML z odczytanego TextReadera do [ParagraphCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/paragraphcollection/) ramki tekstowej.
9. Zapisz zmodyfikowaną prezentację.

```java
// Utwórz pustą instancję prezentacji
Presentation pres = new Presentation();
try {
    // Uzyskaj dostęp do domyślnego pierwszego slajdu prezentacji
    ISlide slide = pres.getSlides().get_Item(0);

    // Dodaj AutoShape, aby pomieścić treść HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Dodaj ramkę tekstową do kształtu
    ashape.addTextFrame("");

    // Wyczyść wszystkie akapity w dodanej ramce tekstowej
    ashape.getTextFrame().getParagraphs().clear();

    // Ładowanie pliku HTML przy użyciu StreamReader
    TextReader tr = new StreamReader("file.html");

    // Dodawanie tekstu z czytnika strumienia HTML do ramki tekstowej
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Zapisz prezentację
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eksportowanie tekstu akapitu do HTML**

Aspose.Slides zapewnia rozszerzone wsparcie dla eksportowania tekstów (zawartych w akapitach) do HTML.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i wczytaj żądaną prezentację.
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do kształtu zawierającego tekst, który ma zostać wyeksportowany do HTML.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textframe/) kształtu.
5. Utwórz instancję `StreamWriter` i dodaj nowy plik HTML.
6. Podaj indeks początkowy do StreamWriter i wyeksportuj wybrane akapity.

```java
// Wczytaj plik prezentacji
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Uzyskaj dostęp do domyślnego pierwszego slajdu prezentacji
    ISlide slide = pres.getSlides().get_Item(0);

    // Żądany indeks
    int index = 0;

    // Uzyskiwanie dostępu do dodanego kształtu
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Tworzenie wyjściowego pliku HTML
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Wyodrębnianie pierwszego akapitu jako HTML
    // Zapisywanie danych akapitów do HTML, podając indeks początkowego akapitu i łączną liczbę akapitów do skopiowania
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zapisz akapit jako obraz**

W tej sekcji przedstawimy dwa przykłady demonstrujące, jak zapisać akapit tekstowy, reprezentowany przez interfejs [IParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraph/), jako obraz. Oba przykłady obejmują uzyskanie obrazu kształtu zawierającego akapit przy użyciu metod `getImage` z interfejsu [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/), obliczenie granic akapitu w obrębie kształtu oraz wyeksportowanie go jako bitmapy. Te podejścia pozwalają wyodrębnić konkretne fragmenty tekstu z prezentacji PowerPoint i zapisać je jako osobne obrazy, co może być przydatne w różnych scenariuszach.

Załóżmy, że mamy plik prezentacji o nazwie sample.pptx z jednym slajdem, na którym pierwszy kształt jest polem tekstowym zawierającym trzy akapity.

![Pole tekstowe z trzema akapitami](paragraph_to_image_input.png)

**Przykład 1**

W tym przykładzie uzyskujemy drugi akapit jako obraz. W tym celu wyodrębniamy obraz kształtu z pierwszego slajdu prezentacji, a następnie obliczamy granice drugiego akapitu w ramce tekstowej kształtu. Akapit jest następnie rysowany na nowym obrazie bitmapowym, który jest zapisywany w formacie PNG. Metoda ta jest szczególnie przydatna, gdy trzeba zapisać konkretny akapit jako oddzielny obraz, zachowując dokładne wymiary i formatowanie tekstu.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Zapisz kształt w pamięci jako bitmapę.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Utwórz bitmapę kształtu z pamięci.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Oblicz granice drugiego akapitu.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // Oblicz współrzędne i rozmiar wyjściowego obrazu (minimalny rozmiar - 1x1 piksel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Przytnij bitmapę kształtu, aby uzyskać wyłącznie bitmapę akapitu.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Wynik:

![Obraz akapitu](paragraph_to_image_output.png)

**Przykład 2**

W tym przykładzie rozszerzamy poprzednie podejście, dodając współczynniki skalowania do obrazu akapitu. Kształt jest wyodrębniany z prezentacji i zapisywany jako obraz ze współczynnikiem skalowania `2`. Pozwala to uzyskać wyższą rozdzielczość przy eksporcie akapitu. Granice akapitu są następnie obliczane z uwzględnieniem skali. Skalowanie może być szczególnie przydatne, gdy potrzebny jest bardziej szczegółowy obraz, np. do wysokiej jakości materiałów drukowanych.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Zapisz kształt w pamięci jako bitmapę ze skalowaniem.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Utwórz bitmapę kształtu z pamięci.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Oblicz granice drugiego akapitu.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Oblicz współrzędne i rozmiar obrazu wyjściowego (minimalny rozmiar - 1x1 piksel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Przytnij bitmapę kształtu, aby uzyskać jedynie bitmapę akapitu.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Czy mogę całkowicie wyłączyć zawijanie wierszy w ramce tekstowej?**

Tak. Użyj ustawienia zawijania ramki tekstowej ([setWrapText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textframeformat/#setWrapText-byte-)), aby wyłączyć zawijanie, dzięki czemu linie nie będą łamane przy krawędziach ramki.

**Jak mogę uzyskać dokładne granice akapitu na slajdzie?**

Możesz pobrać prostokąt otaczający akapit (a nawet pojedynczy fragment), aby znać jego dokładną pozycję i rozmiar na slajdzie.

**Gdzie kontrolowane jest wyrównanie akapitu (lewo/prawo/środek/wyjustowanie)?**

[Alignment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/paragraphformat/#setAlignment-int-) jest ustawieniem na poziomie akapitu w [ParagraphFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/paragraphformat/); ma zastosowanie do całego akapitu, niezależnie od formatowania poszczególnych fragmentów.

**Czy mogę ustawić język sprawdzania pisowni tylko dla części akapitu (np. jednego słowa)?**

Tak. Język jest ustawiany na poziomie fragmentu ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), więc w jednym akapicie mogą współistnieć różne języki.