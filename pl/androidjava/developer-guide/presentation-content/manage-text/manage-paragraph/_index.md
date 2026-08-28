---
title: Zarządzaj akapitami tekstu PowerPoint na Androidzie
linktitle: Zarządzaj akapitem
type: docs
weight: 40
url: /pl/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
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
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować akapity, fragmenty, wypunktowania, listy numerowane, wcięcia, treść HTML oraz obrazy akapitów przy użyciu Aspose.Slides dla Androida w Java."
---
## **Przegląd**

Aspose.Slides for Android via Java reprezentuje tekst jako hierarchię ramek tekstowych, akapitów i fragmentów:

* [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/) reprezentuje kontener tekstu w kształcie i zapewnia dostęp do jego kolekcji akapitów.
* [IParagraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraph/) reprezentuje jeden akapit w ramce tekstowej i zapewnia dostęp do jego fragmentów oraz formatowania na poziomie akapitu.
* [IPortion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportion/) reprezentuje fragment tekstu w obrębie akapitu. Każdy fragment może mieć własny tekst i formatowanie na poziomie znaków.

Akapit może więc zawierać tekst z różnymi czcionkami, kolorami, rozmiarami i innym formatowaniem, używając wielu fragmentów.

## **Tworzenie i formatowanie akapitów**

### **Tworzenie akapitów z wieloma fragmentami**

Poniższe kroki tworzą ramkę tekstową z trzema akapitami, z których każdy zawiera trzy fragmenty:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu poprzez jego indeks.
3. Dodaj prostokątny [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
4. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/) kształtu.
5. Użyj domyślnego akapitu i dodaj dwa kolejne obiekty [IParagraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraph/) do ramki tekstowej.
6. Dodaj wystarczającą liczbę obiektów [IPortion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportion/) dla każdego akapitu, aby zawierały po trzy fragmenty. Domyślny akapit już zawiera jeden pusty fragment.
7. Ustaw tekst każdego fragmentu.
8. Zastosuj formatowanie na poziomie znaków przy pomocy [IPortion.getPortionFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportion/#getPortionFormat--).
9. Zapisz zmodyfikowaną prezentację.

Ten przykład Android via Java implementuje powyższe kroki:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Tworzenie listy wypunktowanej lub numerowanej**

Punkty i numeracja ułatwiają przeglądanie powiązanych elementów. W Aspose.Slides ustawienia listy definiowane są za pomocą [IBulletFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu poprzez jego indeks.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do wybranego slajdu.
4. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/).
5. Usuń domyślny akapit z ramki tekstowej.
6. Utwórz [Paragraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/paragraph/) dla symbolu wypunktowania.
7. Ustaw [IBulletFormat.setType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/#setType-int-) na [BulletType.Symbol](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/bullettype/) i określ znak wypunktowania.
8. Ustaw tekst akapitu, wcięcie, kolor wypunktowania oraz wysokość wypunktowania.
9. Dodaj akapit do ramki tekstowej.
10. Utwórz drugi akapit i ustaw [IBulletFormat.setType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/#setType-int-) na [BulletType.Numbered](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/bullettype/).
11. Skonfiguruj styl numerowanego wypunktowania i dodaj akapit do ramki tekstowej.
12. Zapisz prezentację.

Ten przykład Android via Java tworzy symbol wypunktowania oraz numerowane wypunktowanie:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Użycie wypunktowań graficznych**

Wypunktowania graficzne pozwalają użyć własnego obrazu zamiast symbolu lub numeru.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu poprzez jego indeks.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) i uzyskaj dostęp do jego [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/).
4. Usuń domyślny akapit z ramki tekstowej.
5. Załaduj obraz wypunktowania i dodaj go do kolekcji obrazów prezentacji jako [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/).
6. Utwórz [Paragraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/paragraph/) i ustaw jego tekst.
7. Ustaw [IBulletFormat.setType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/#setType-int-) na [BulletType.Picture](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/bullettype/).
8. Przypisz obraz poprzez [IBulletFormat.getPicture](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/#getPicture--) i ustaw wysokość wypunktowania.
9. Dodaj akapit do ramki tekstowej.
10. Zapisz zmodyfikowaną prezentację.

Ten przykład Android via Java tworzy wypunktowanie graficzne:

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

### **Tworzenie listy wielopoziomowej**

Ustaw [IParagraphFormat.setDepth](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) aby umieścić akapity na różnych poziomach listy. Poziom najwyższy ma głębokość `0`.

1. Utwórz [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i uzyskaj dostęp do slajdu.
2. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) i usuń domyślny akapit z jego ramki tekstowej.
3. Utwórz cztery akapity i skonfiguruj ich symbole wypunktowania.
4. Ustaw ich wartości [IParagraphFormat.setDepth](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) na `0`, `1`, `2` i `3`.
5. Dodaj akapity do ramki tekstowej i zapisz prezentację.

Ten przykład Android via Java tworzy czteropoziomową listę wypunktowaną:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Rozpoczęcie numerowanych elementów listy od własnych wartości**

Użyj [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) aby ustawić początkowy numer wyświetlany dla numerowanego akapitu.

1. Utwórz [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
2. Usuń domyślny akapit z ramki tekstowej kształtu.
3. Utwórz trzy numerowane akapity.
4. Ustaw [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) na `2`, `3` i `7` dla kolejnych akapitów.
5. Dodaj akapity do ramki tekstowej i zapisz prezentację.

Ten przykład Android via Java przypisuje własny początkowy numer każdemu akapitowi:

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

Użyj [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) aby kontrolować wcięcie pierwszej linii akapitu. Metoda ta przesuwa tylko pierwszą linię względem lewego marginesu akapitu. Dodatnia wartość przesuwa pierwszą linię w prawo, podczas gdy pozostałe linie pozostają wyrównane do ciała akapitu.

Użyj [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) gdy potrzebujesz przesunąć cały akapit. Użyj [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) gdy potrzebujesz przesunąć tylko pierwszą linię.

Poniższy przykład tworzy kilka akapitów i stosuje różne wartości [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) aby pokazać, jak wcięcie pierwszej linii wpływa na układ akapitu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątny [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
4. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/) kształtu i usuń domyślny akapit.
5. Utwórz kilka akapitów i ustaw różne wartości [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) dla nich.
6. Dodaj akapity do ramki tekstowej.
7. Zapisz zmodyfikowaną prezentację.

Ten kod pokazuje, jak ustawić wcięcie akapitu:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Wcięcie wiszące to układ akapitu, w którym pierwsza linia zaczyna się po lewej stronie pozostałych linii. W Aspose.Slides tworzysz ten efekt przy pomocy [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Przekaż ujemną wartość, aby przesunąć pierwszą linię w lewo względem ciała akapitu.

W praktyce [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) definiuje lewą pozycję ciała akapitu, a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) definiuje pozycję pierwszej linii względem tego marginesu. Aby stworzyć wcięcie wiszące, przekaż dodatnią wartość do `setMarginLeft` i ujemną wartość do `setIndent`.

To formatowanie jest przydatne w bibliografiach, odniesieniach, wpisach słownika i innych akapitach, w których zwinięte linie muszą być wyrównane pod ciałem akapitu, a nie pod pierwszym znakiem pierwszej linii.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątny [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
4. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/) i usuń domyślny akapit.
5. Utwórz akapity i przekaż dodatnią wartość do [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) dla każdego akapitu.
6. Przekaż ujemną wartość do [IParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) aby uzyskać efekt wcięcia wiszącego.
7. Dodaj akapity do ramki tekstowej.
8. Zapisz zmodyfikowaną prezentację.

Ten kod pokazuje, jak ustawić wcięcie wiszące dla akapitu:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Ustawienie właściwości końcowych akapitu**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) kontroluje formatowanie znaku końca akapitu. Poniższy przykład przypisuje rozmiar czcionki i czcionkę łacińską do znaku końca drugiego akapitu:

1. Załaduj [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i uzyskaj dostęp do slajdu.
2. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) i wyczyść jego domyślny akapit.
3. Utwórz dwa akapity i dodaj do nich fragmenty tekstu.
4. Utwórz [PortionFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/portionformat/) dla znaku końca drugiego akapitu.
5. Ustaw [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) oraz [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Przypisz format przy pomocy [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) i zapisz prezentację.

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

## **Import i eksport zawartości akapitu**

### **Import tekstu HTML do akapitów**

Użyj [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) aby przekształcić znacznik HTML w akapity i fragmenty w ramce tekstowej.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do slajdu i dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/).
3. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/) i wyczyść jego domyślny akapit.
4. Odczytaj plik źródłowy HTML.
5. Przekaż ciąg HTML do [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Zapisz zmodyfikowaną prezentację.

Ten przykład Android via Java importuje HTML do ramki tekstowej:

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

### **Eksport tekstu akapitu do HTML**

Użyj [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) aby wyeksportować wybrany zakres akapitów jako HTML.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i załaduj żądaną prezentację.
2. Uzyskaj dostęp do slajdu i znajdź [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) zawierający tekst.
3. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/).
4. Wywołaj [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) z indeksem początkowego akapitu i liczbą akapitów do wyeksportowania.
5. Zapisz zwrócony ciąg HTML do pliku.

Ten przykład Android via Java eksportuje wszystkie akapity z pierwszego kształtu tekstowego:

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

[IParagraph.getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraph/#getImage--) renderuje pojedynczy akapit bezpośrednio i zwraca [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/). Zapisz wynik do pliku lub strumienia przy użyciu [IImage.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Nie musisz renderować zawierającego go kształtu ani ręcznie przycinać bitmapy.

[IParagraph.getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraph/#getImage--) może zwrócić `null`, jeśli akapit nie zostanie znaleziony w kolekcji rodzica, nie ma prawidłowych granic renderowania lub nie może być renderowany. Sprawdź wynik przed zapisem i zwolnij zwrócony obraz po użyciu.

#### **Renderowanie akapitu w domyślnej skali**

Załóżmy, że mamy plik prezentacji o nazwie sample.pptx z jedną slajdą, w której pierwszy kształt to pole tekstowe zawierające trzy akapity.

![Pole tekstowe z trzema akapitami](paragraph_to_image_input.png)

Poniższy przykład renderuje drugi akapit w zwykłym polu tekstowym w domyślnej skali i zapisuje zwrócony obraz w formacie PNG. Blok `finally` zapewnia prawidłowe zwolnienie obrazu.

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

Użyj przeciążenia [IParagraph.getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) przyjmującego parametry `float scaleX` i `float scaleY`, aby ustawić czynniki skali poziomej i pionowej. Poniższy przykład tworzy tabelę, renderuje akapit w jej pierwszej komórce przy dwukrotnym domyślnym szerokości i wysokości oraz zapisuje wynik jako obraz PNG.

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

Czynnik skali `1` zachowuje tę oś w domyślnym rozmiarze pikselowym. Na przykład `2` dla obu czynników tworzy obraz, którego szerokość i wysokość są w przybliżeniu dwa razy większe niż domyślne wymiary, co daje cztery razy więcej pikseli. Większe czynniki zazwyczaj dają ostrzejszy tekst przy powiększaniu lub wyjściu wysokiej rozdzielczości, ale zwiększają także zużycie pamięci i rozmiar pliku. Czynniki poniżej `1` generują mniejsze obrazy z mniejszą ilością szczegółów. Używaj równych czynników, aby zachować proporcje akapitu; różne czynniki poziome i pionowe rozciągają wynik niezależnie.

Renderowanie całego kształtu przy pomocy [IShape.getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getImage--) pozostaje przydatne, gdy wyjście musi zawierać wypełnienie, obramowanie lub inne konteksty wizualne kształtu. Dla obrazu zawierającego tylko akapit, użyj [IParagraph.getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Czy mogę całkowicie wyłączyć zawijanie linii w ramce tekstowej?**

Tak. Ustaw [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) aby wyłączyć zawijanie, dzięki czemu linie nie będą łamane przy krawędziach ramki tekstowej.

**Jak uzyskać dokładne granice akapitu na slajdzie?**

Użyj [IParagraph.getRect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraph/#getRect--) aby uzyskać prostokąt graniczny akapitu. [IPortion.getRect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportion/#getRect--) dostarcza granice poszczególnych fragmentów.

**Gdzie kontrolowane jest wyrównanie akapitu (lewe, prawe, wyśrodkowane lub wyjustowanie)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) jest ustawieniem na poziomie akapitu i ma zastosowanie do całego akapitu, niezależnie od formatowania poszczególnych fragmentów.

**Czy mogę ustawić język korekty dla części akapitu?**

Tak. Ustaw [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) dla poszczególnych fragmentów, tak aby jeden akapit mógł zawierać tekst w wielu językach.