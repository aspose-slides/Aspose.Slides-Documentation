---
title: Zarządzanie akapitami tekstu PowerPoint w Javie
linktitle: Zarządzaj akapitem
type: docs
weight: 40
url: /pl/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
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
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować akapity, fragmenty, wypunktowania, listy numerowane, wcięcia, treść HTML oraz obrazy akapitów za pomocą Aspose.Slides dla Javy."
---
## **Przegląd**

Aspose.Slides for Java przedstawia tekst jako hierarchię ramek tekstowych, akapitów i fragmentów:

* [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) reprezentuje kontener tekstowy w kształcie i zapewnia dostęp do jego kolekcji akapitów.
* [IParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraph/) reprezentuje jeden akapit w ramce tekstowej i zapewnia dostęp do jego fragmentów oraz formatowania na poziomie akapitu.
* [IPortion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/) reprezentuje fragment tekstu w akapicie. Każdy fragment może mieć własny tekst i formatowanie na poziomie znaków.

Akapit może więc zawierać tekst o różnych czcionkach, kolorach, rozmiarach i innych formatowaniach, korzystając z wielu fragmentów.

## **Utworzenie i formatowanie akapitów**

### **Utworzenie akapitów z wieloma fragmentami**

Poniższe kroki tworzą ramkę tekstową z trzema akapitami, z których każdy zawiera trzy fragmenty:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj prostokątny [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
4. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) kształtu.
5. Użyj domyślnego akapitu i dodaj dwa kolejne obiekty [IParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraph/) do ramki tekstowej.
6. Dodaj wystarczającą liczbę obiektów [IPortion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/) , aby każdy akapit zawierał trzy fragmenty. Domyślny akapit już zawiera jeden pusty fragment.
7. Ustaw tekst każdego fragmentu.
8. Zastosuj formatowanie na poziomie znaków za pomocą [IPortion.getPortionFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/#getPortionFormat--).
9. Zapisz zmodyfikowaną prezentację.

Ten przykład w języku Java implementuje powyższe kroki:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tworzenie list wypunktowanych i numerowanych**

### **Utworzenie listy wypunktowanej lub numerowanej**

Punkty i numerowanie ułatwiają przeglądanie powiązanych elementów. W Aspose.Slides ustawienia listy są definiowane za pomocą [IBulletFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibulletformat/).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do wybranego slajdu.
4. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) kształtu.
5. Usuń domyślny akapit z ramki tekstowej.
6. Utwórz [Paragraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/paragraph/) dla symbolu wypunktowania.
7. Ustaw [IBulletFormat.setType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibulletformat/#setType-int-) na [BulletType.Symbol](https://reference.aspose.com/slides/pl/java/com.aspose.slides/bullettype/) i określ znak wypunktowania.
8. Ustaw tekst akapitu, wcięcie, kolor wypunktowania i wysokość wypunktowania.
9. Dodaj akapit do ramki tekstowej.
10. Utwórz drugi akapit i ustaw [IBulletFormat.setType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibulletformat/#setType-int-) na [BulletType.Numbered](https://reference.aspose.com/slides/pl/java/com.aspose.slides/bullettype/).
11. Skonfiguruj styl numerowanego wypunktowania i dodaj akapit do ramki tekstowej.
12. Zapisz prezentację.

Ten przykład w języku Java tworzy symbol wypunktowania oraz numerowane wypunktowanie:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Użycie wypunktowania obrazkowego**

Wypunktowanie obrazkowe pozwala używać własnego obrazu zamiast symbolu lub liczby.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) i uzyskaj dostęp do jego [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/).
4. Usuń domyślny akapit z ramki tekstowej.
5. Załaduj obraz wypunktowania i dodaj go do kolekcji obrazów prezentacji jako [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/).
6. Utwórz [Paragraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/paragraph/) i ustaw jego tekst.
7. Ustaw [IBulletFormat.setType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibulletformat/#setType-int-) na [BulletType.Picture](https://reference.aspose.com/slides/pl/java/com.aspose.slides/bullettype/).
8. Przypisz obraz za pomocą [IBulletFormat.getPicture](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibulletformat/#getPicture--) i ustaw wysokość wypunktowania.
9. Dodaj akapit do ramki tekstowej.
10. Zapisz zmodyfikowaną prezentację.

Ten przykład w języku Java tworzy wypunktowanie obrazkowe:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Utworzenie listy wielopoziomowej**

Ustaw [IParagraphFormat.setDepth](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setDepth-short-) , aby umieścić akapity na różnych poziomach listy. Poziom najwyższy ma głębokość `0`.

1. Utwórz [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i uzyskaj dostęp do slajdu.
2. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) i usuń domyślny akapit z jego ramki tekstowej.
3. Utwórz cztery akapity i skonfiguruj ich symbole wypunktowania.
4. Ustaw ich wartości [IParagraphFormat.setDepth](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setDepth-short-) na `0`, `1`, `2` i `3`.
5. Dodaj akapity do ramki tekstowej i zapisz prezentację.

Ten przykład w języku Java tworzy czteropoziomową listę wypunktowaną:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Rozpoczęcie numerowanych elementów listy od niestandardowych wartości**

Użyj [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) , aby ustawić początkową liczbę wyświetlaną dla numerowanego akapitu.

1. Utwórz [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
2. Usuń domyślny akapit z ramki tekstowej kształtu.
3. Utwórz trzy numerowane akapity.
4. Ustaw [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) na `2`, `3` i `7` dla kolejnych akapitów.
5. Dodaj akapity do ramki tekstowej i zapisz prezentację.

Ten przykład w języku Java przypisuje niestandardowy numer początkowy do każdego akapitu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kontrola układu akapitu i właściwości końcowych**

### **Ustawienie wcięcia pierwszej linii**

Użyj [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) , aby kontrolować wcięcie pierwszej linii akapitu. Metoda ta przesuwa tylko pierwszą linię względem lewego marginesu akapitu. Dodatnia wartość przesuwa pierwszą linię w prawo, natomiast pozostałe linie pozostają wyrównane do treści akapitu.

Użyj [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) , gdy potrzebujesz przesunąć cały akapit. Użyj [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) , gdy potrzebujesz przesunąć tylko pierwszą linię.

Poniższy przykład tworzy kilka akapitów i stosuje różne wartości [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) , aby pokazać, jak wcięcie pierwszej linii wpływa na układ akapitu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątny [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
4. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) kształtu i usuń domyślny akapit.
5. Utwórz kilka akapitów i ustaw różne wartości [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) dla nich.
6. Dodaj akapity do ramki tekstowej.
7. Zapisz zmodyfikowaną prezentację.

Ten kod pokazuje, jak ustawić wcięcie akapitu:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Wcięcie pierwszej linii akapitów](first_line_indent.png)

### **Ustawienie wcięcia wiszącego**

Wcięcie wiszące to układ akapitu, w którym pierwsza linia zaczyna się po lewej stronie pozostałych wierszy. W Aspose.Slides efekt ten uzyskuje się za pomocą [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Przekaż ujemną wartość, aby przesunąć pierwszą linię w lewo względem treści akapitu.

W praktyce [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) definiuje lewą pozycję treści akapitu, a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) pozycję pierwszej linii względem tego marginesu. Aby uzyskać wcięcie wiszące, przekaż dodatnią wartość do `setMarginLeft` i ujemną wartość do `setIndent`.

To formatowanie jest przydatne w bibliografiach, odnośnikach, hasłach słownika i innych akapitach, w których kolejne wiersze muszą być wyrównane pod treścią akapitu, a nie pod pierwszym znakiem pierwszej linii.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) .
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątny [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
4. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) kształtu i usuń domyślny akapit.
5. Utwórz akapity i przekaż dodatnią wartość do [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) dla każdego akapitu.
6. Przekaż ujemną wartość do [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) , aby uzyskać efekt wcięcia wiszącego.
7. Dodaj akapity do ramki tekstowej.
8. Zapisz zmodyfikowaną prezentację.

Ten kod pokazuje, jak ustawić wcięcie wiszące dla akapitu:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Wcięcie wiszące akapitów](hanging_indent.png)

### **Ustawienie właściwości końcowego fragmentu akapitu**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) kontroluje formatowanie znaku końcowego akapitu. Poniższy przykład przypisuje rozmiar czcionki i czcionkę łacińską do znaku końcowego drugiego akapitu:

1. Załaduj [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i uzyskaj dostęp do slajdu.
2. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) i usuń jego domyślny akapit.
3. Utwórz dwa akapity i dodaj do nich fragmenty tekstu.
4. Utwórz [PortionFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/portionformat/) dla znaku końcowego drugiego akapitu.
5. Ustaw [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) i [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Przypisz format przy pomocy [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) i zapisz prezentację.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Import i eksport treści akapitu**

### **Importowanie tekstu HTML do akapitów**

Użyj [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/pl/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) , aby przekonwertować znacznik HTML na akapity i fragmenty w ramce tekstowej.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) .
2. Uzyskaj dostęp do slajdu i dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) .
3. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) kształtu i usuń domyślny akapit.
4. Odczytaj źródłowy plik HTML.
5. Przekaż ciąg HTML do [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/pl/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) .
6. Zapisz zmodyfikowaną prezentację.

Ten przykład w języku Java importuje HTML do ramki tekstowej:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Eksportowanie tekstu akapitu do HTML**

Użyj [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/pl/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) , aby wyeksportować wybrany zakres akapitów jako HTML.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i wczytaj żądaną prezentację.
2. Uzyskaj dostęp do slajdu i znajdź [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) zawierający tekst.
3. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) kształtu.
4. Wywołaj [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/pl/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) z indeksem początkowego akapitu i liczbą akapitów do eksportu.
5. Zapisz zwrócony ciąg HTML do pliku.

Ten przykład w języku Java eksportuje wszystkie akapity z pierwszego kształtu tekstowego:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Renderowanie akapitu jako obrazu**

[IParagraph.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraph/#getImage--) renderuje pojedynczy akapit bezpośrednio i zwraca [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/). Zapisz wynik do pliku lub strumienia przy użyciu [IImage.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Nie musisz renderować całego kształtu ani ręcznie przycinać bitmapy.

[IParagraph.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraph/#getImage--) może zwrócić `null`, jeśli akapit nie zostanie odnaleziony w kolekcji nadrzędnej, nie ma prawidłowych granic renderowania lub nie może zostać wyrenderowany. Sprawdź wynik przed zapisem i zwolnij zwrócony obraz po użyciu.

#### **Renderowanie akapitu w domyślnej skali**

Załóżmy, że mamy plik prezentacji o nazwie sample.pptx z jednym slajdem, w którym pierwszy kształt jest polem tekstowym zawierającym trzy akapity.

![Pole tekstowe z trzema akapitami](paragraph_to_image_input.png)

Poniższy przykład renderuje drugi akapit w zwykłym kształcie tekstowym w domyślnej skali i zapisuje zwrócony obraz w formacie PNG. Blok `finally` zapewnia prawidłowe zwolnienie obrazu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Wynik:

![Obraz akapitu](paragraph_to_image_output.png)

#### **Renderowanie akapitu w komórce tabeli ze skalowaniem**

Użyj przeciążenia [IParagraph.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraph/#getImage-float-float-) , które przyjmuje parametry `float scaleX` i `float scaleY`, aby ustawić współczynniki skali poziomej i pionowej. Poniższy przykład tworzy tabelę, renderuje akapit w jej pierwszej komórce dwukrotnie zwiększając domyślną szerokość i wysokość, i zapisuje wynik jako obraz PNG.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Współczynnik skali `1` zachowuje dany wymiar w domyślnym rozmiarze pikseli. Na przykład `2` dla obu współczynników daje obraz, którego szerokość i wysokość są w przybliżeniu dwukrotnością domyślnych wymiarów, co skutkuje czterokrotną liczbą pikseli. Większe współczynniki zwykle dają ostrzejszy tekst przy powiększaniu lub wyjściu wysokiej rozdzielczości, ale zwiększają zużycie pamięci i rozmiar pliku. Współczynniki poniżej `1` tworzą mniejsze obrazy o mniejszej szczegółowości. Używaj równych współczynników, aby zachować proporcje akapitu; różne współczynniki poziome i pionowe rozciągają wynik niezależnie.

Renderowanie całego kształtu przy użyciu [IShape.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getImage--) pozostaje przydatne, gdy wyjście ma obejmować wypełnienie, obramowanie lub inne elementy wizualne kształtu. Dla obrazu zawierającego wyłącznie akapit, użyj [IParagraph.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraph/#getImage--) .

## **FAQ**

**Czy mogę całkowicie wyłączyć zawijanie wierszy wewnątrz ramki tekstowej?**

Tak. Ustaw [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) , aby wyłączyć zawijanie, dzięki czemu wiersze nie będą łamane przy krawędziach ramki tekstowej.

**Jak mogę uzyskać dokładne granice na slajdzie konkretnego akapitu?**

Użyj [IParagraph.getRect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraph/#getRect--) , aby pobrać prostokąt otaczający akapit. [IPortion.getRect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/#getRect--) dostarcza granice pojedynczego fragmentu.

**Gdzie kontrolowane jest wyrównanie akapitu (lewy, prawy, środek lub wyjustowanie)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) jest ustawieniem na poziomie akapitu i ma zastosowanie do całego akapitu, niezależnie od formatowania poszczególnych fragmentów.

**Czy mogę ustawić język korekty dla części akapitu?**

Tak. Ustaw [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) dla poszczególnych fragmentów, aby jeden akapit mógł zawierać tekst w wielu językach.