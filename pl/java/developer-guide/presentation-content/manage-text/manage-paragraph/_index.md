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
- import HTML
- tekst do HTML
- akapit do HTML
- akapit do obrazu
- tekst do obrazu
- eksport akapitu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować akapity, fragmenty, wypunktowania, listy numerowane, wcięcia, treść HTML oraz obrazy akapitów przy użyciu Aspose.Slides dla Javy."
---
## **Przegląd**

Aspose.Slides for Java reprezentuje tekst jako hierarchię ramek tekstowych, akapitów i fragmentów:

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) reprezentuje kontener tekstowy w kształcie i zapewnia dostęp do jego kolekcji akapitów.
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) reprezentuje pojedynczy akapit w ramce tekstowej oraz zapewnia dostęp do jego fragmentów i formatowania na poziomie akapitu.
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) reprezentuje fragment tekstu w obrębie akapitu. Każdy fragment może mieć własny tekst i formatowanie znakowe.

Akapit może więc zawierać tekst o różnych czcionkach, kolorach, rozmiarach i innych formatach, korzystając z wielu fragmentów.

## **Tworzenie i formatowanie akapitów**

Twórz akapity w ramce tekstowej kształtu i używaj fragmentów do formatowania poszczególnych fragmentów tekstu. Ta sekcja pokazuje, jak łączyć wiele fragmentów w każdym akapicie oraz stosować różne kolory, rozmiary czcionek i style.

### **Tworzenie akapitów z wieloma fragmentami**

Poniższy przykład w Javie tworzy trzy akapity, z których każdy zawiera trzy fragmenty tekstu w kolekcji zwróconej przez [IParagraph.getPortions](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getPortions--) . Ponownie używa domyślnego akapitu i jego pustego fragmentu, a następnie dodaje pozostałe akapity i fragmenty. Formatowanie jest stosowane za pomocą [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--) : pierwszy fragment w każdym akapicie jest czerwony, pogrubiony i ma 15 punktów; drugi jest niebieski, pochylony i ma 18 punktów. Trzeci fragment zachowuje domyślne formatowanie:

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

Organizuj tekst akapitów w listy przy użyciu symboli, liczb lub własnych obrazów. Przykłady w tej sekcji obejmują formatowanie wypunktowań, listy wielopoziomowe i własne liczby początkowe.

### **Tworzenie listy wypunktowanej lub numerowanej**

Wypunktowania i numeracje ułatwiają skanowanie powiązanych elementów. W Aspose.Slides ustawienia listy są definiowane poprzez [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/).

Ten przykład w Javie dodaje symbol wypunktowania oraz element numerowany do tej samej ramki tekstowej. [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) wybiera typ wypunktowania, [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) dostarcza symbol, a [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) wybiera styl numeracji. Oba elementy używają czarnych wypunktowań o wysokości 100 % i wcięciu akapitu równym 25 punktów:

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

### **Użycie wypunktowań graficznych**

Wypunktowania graficzne pozwalają użyć własnego obrazu zamiast symbolu lub liczby.

Ten przykład w Javie dodaje obraz do kolekcji obrazów prezentacji jako [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) i używa go jako wypunktowanie akapitu. Wywołuje [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) aby użyć wypunktowania graficznego oraz przypisuje obraz przez [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--). [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) jest ustawione na 100 % aby skalować wypunktowanie względem tekstu akapitu:

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

Ustaw [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) aby umieścić akapity na różnych poziomach listy. Najwyższy poziom ma głębokość `0`.

Ten przykład w Javie przypisuje wartości [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) od 0 do 3 czterem akapitom, tworząc hierarchię w jednej ramce tekstowej. Każdy akapit używa symbolu wypunktowania, a [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) przełącza się między okrągłym wypunktowaniem a myślnikiem, aby odróżnić sąsiadujące poziomy:

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

### **Rozpoczęcie numerowanych elementów listy od własnych wartości**

Użyj [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) aby ustawić początkowy numer wyświetlany dla numerowanego akapitu.

Ten przykład w Javie ustawia [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) na numerację dla trzech akapitów i przypisuje wartości [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) równe 2, 3 i 7. Wartość początkowa jest konfigurowana oddzielnie dla każdego akapitu, co pozwala na pomijanie numerów:

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

Reguluj marginesy i wcięcia akapitu, aby kontrolować położenie pierwszej linii i linii łamanych. Możesz także formatować znak końcowy akapitu osobno od widocznych fragmentów tekstu.

### **Ustawienie wcięcia pierwszej linii**

Użyj metody [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) aby kontrolować wcięcie pierwszej linii akapitu. Ustawienie to przesuwa tylko pierwszą linię względem lewego marginesu akapitu. Dodatnia wartość przesuwa pierwszą linię w prawo, podczas gdy pozostałe linie pozostają wyrównane do ciała akapitu.

Użyj [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) gdy potrzebujesz przesunąć cały akapit. Użyj [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) gdy potrzebujesz przesunąć tylko pierwszą linię.

Poniższy przykład nadaje trzem akapitom taki sam [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) równy 20 punktów oraz wartości [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) równe 0, 20 i 40 punktów. Pierwsze linie zaczynają się przy kolejno większych przesunięciach, podczas gdy linie łamane zachowują ten sam lewy margines:

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

Wcięcie wiszące to układ akapitu, w którym pierwsza linia zaczyna się po lewej stronie pozostałych linii. W Aspose.Slides tworzysz ten efekt przy pomocy właściwości [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Ustaw `Indent` na wartość ujemną, aby przesunąć pierwszą linię w lewo względem ciała akapitu.

W praktyce [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) definiuje lewą pozycję ciała akapitu, a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) określa pozycję pierwszej linii względem tego marginesu. Aby uzyskać wcięcie wiszące, ustaw dodatnią wartość `MarginLeft` i ujemną wartość `Indent`.

To formatowanie jest przydatne w bibliografiach, odnośnikach, hasłach słownikowych i innych akapitach, w których linie łamane muszą być wyrównane pod ciałem akapitu, a nie pod pierwszym znakiem pierwszej linii.

Poniższy przykład w Javie łączy wartości [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) równe 40 i 60 punktów z wartościami [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) równymi -20 i -30 punktów. W każdym akapicie pierwsza linia zaczyna się po lewej stronie linii łamanych; drugi akapit ma głębsze wcięcie wiszące:

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

### **Ustawienie właściwości końcowych akapitu**

Metoda [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) kontroluje formatowanie znaku końcowego akapitu. Poniższy przykład tworzy obiekt [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) z [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) ustawionym na 48 punktów oraz [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) ustawionym na Times New Roman. Przypisuje ten format do znaku końcowego drugiego akapitu, pozostawiając niezmienione widoczne fragmenty tekstu:

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

## **Zliczanie renderowanych linii**

Dla reguł akapitu wpływających na automatyczne łamanie i interpunkcję na końcach linii, zobacz [Control Line Breaking](/slides/pl/java/text-formatting/#control-line-breaking) oraz [Control Hanging Punctuation](/slides/pl/java/text-formatting/#control-hanging-punctuation).

Użyj [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) aby policzyć linie zajmowane przez akapit po ułożeniu tekstu, w tym automatyczne łamanie. Jest to przydatne przy sprawdzaniu długości tekstu i układu w szablonach prezentacji.

Akapit jest jednym elementem w [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--), i może zajmować kilka renderowanych linii. Jawny podział linii w akapicie wymusza nową linię bez tworzenia nowego akapitu. Automatyczne łamanie tworzy linie na podstawie dostępnej szerokości, nie wstawiając jawnych znaków podziału do tekstu. Dlatego liczenie akapitów lub znaków podziału nie daje liczby renderowanych linii.

Poniższy przykład tworzy kształt tekstowy, zlicza jego linie, zmniejsza kształt, a następnie zastępuje tekst krótszym ciągiem. Przykład włącza łamanie za pomocą [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) i wyłącza autofit za pomocą [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-), tak aby szerokość kształtu kontrolowała łamanie bez automatycznego zmniejszania tekstu ani zmiany rozmiaru kształtu. Każdy pomiar używa [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--). Wymiary kształtu podawane są w punktach. Na końcu przykład dodaje kolejny akapit i sumuje liczbę linii w całej ramce tekstowej:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Przy tym tekście i tych wymiarach, zwężenie kształtu zwiększa liczbę linii, natomiast zastąpienie tekstu krótkim ciągiem ją zmniejsza. Dokładne liczby mogą się różnić w zależności od dostępności czcionek i ich substytucji, rozmiaru czcionki, marginesów, wcięć, łamania i ustawień autofitu. Używaj czcionek i ustawień układu przeznaczonych dla docelowego środowiska przy sprawdzaniu szablonu.

Liczba linii sama w sobie nie określa, czy tekst wykracza poza swój pojemnik. Ważne są też dostępna wysokość, wysokość linii, odstępy akapitów i linii oraz zachowanie autofitu; nawet pojedyncza linia może przekroczyć dostępną szerokość, jeśli łamanie jest wyłączone.

## **Import i eksport zawartości akapitów**

Użyj HTML, aby wprowadzić tekst do prezentacji lub wyeksportować istniejące akapity do użycia poza nią. Ta sekcja pokazuje także, jak renderować poszczególne akapity jako obrazy, w tym akapity w komórkach tabel.

### **Importowanie tekstu HTML do akapitów**

Użyj [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) aby przekształcić znacznik HTML w akapity i fragmenty w ramce tekstowej.

Ten przykład w Javie odczytuje HTML z pliku i przekazuje znacznik do [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-). Czyści domyślny akapit ramki tekstowej, tak aby ramka zawierała wyłącznie zaimportowaną treść. Prostokątny kształt pozostawia margines 10 punktów po każdej stronie slajdu:

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

Użyj [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) aby wyeksportować wybrany zakres akapitów jako HTML. Gdy ponownie używasz tekstu prezentacji na stronie internetowej, możesz chcieć zachować lokalne wyróżnienia bez przenoszenia czcionek, rozmiarów czy stylów pola tekstowego. Ustaw [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) aby kontrolować, jak daleko eksporter podąża za dziedziczeniem formatowania.

Pobierz [przykładową prezentację](text-inheritance.pptx) i umieść ją w katalogu roboczym aplikacji. Jej pierwszy slajd zawiera jedną ramkę tekstową z tekstem „Inherited text; explicit red 18pt”. Wejście celowo używa kilku poziomów formatowania:

- Domyślny styl tekstu prezentacji dostarcza czcionkę Calibri o rozmiarze 28 pt.
- Styl tekstu pierwszego poziomu ramki tekstowej dostarcza niebieski tekst i kursywę.
- Akapit wyraźnie ustawia pogrubiony tekst.
- Drugi fragment, „explicit red 18pt”, wyraźnie ustawia czerwony kolor i rozmiar 18 pt.

Poniższy kompletny przykład eksportuje te same akapity trzy razy. Przekazuje [TextToHtmlConversionOptions](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/) do metody eksportu i zapisuje każdy wynik jako oddzielny plik HTML w kodowaniu UTF‑8:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
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

Wygenerowany HTML zawiera następujący CSS dla pierwszego fragmentu, „Inherited text; ”. Tabela wymienia istotne deklaracje; inne wygenerowane właściwości zostały pominięte dla przejrzystości.

| Wynik | Odpowiedni CSS dla pierwszego fragmentu | Wygląd |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Niebieski, pogrubiony, kursywa w 28 pt w Calibri, jeśli czcionka jest dostępna. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Niebieski, pogrubiony, kursywa; otaczająca strona lub przeglądarka dostarcza rodzinę czcionki i rozmiar. |
| `ParagraphOnly.html` | `font-weight:bold` | Pogrubiony tekst; otaczająca strona lub przeglądarka dostarcza rodzinę czcionki, rozmiar, kolor i styl kursywy. |

Drugi fragment zachowuje `color:#ff0000`, `font-size:18pt` i `font-weight:bold` we wszystkich trzech wyjściach. Zachowuje także kursywę w `All` i `TextBox`, ale nie w `ParagraphOnly`. Ograniczenie dziedziczenia nie usuwa więc formatowania przypisanego explicite do akapitu lub fragmentu.

Otwórz pliki w tej samej przeglądarce, aby je porównać. W dwóch trybach ograniczonych pominięte właściwości CSS są rozwiązywane przez style docelowej strony lub domyślne ustawienia przeglądarki, więc ostateczny wygląd zależy od miejsca, w którym HTML jest używany.

### **Renderowanie akapitu jako obrazu**

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) renderuje pojedynczy akapit bezpośrednio i zwraca [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/). Zapisz wynik do pliku lub strumienia przy użyciu [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Nie musisz renderować całego kształtu ani ręcznie przycinać bitmapy.

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) może zwrócić `null`, jeśli akapit nie zostanie znaleziony w kolekcji nadrzędnej, nie ma prawidłowych granic renderowania lub nie może zostać wyrenderowany. Sprawdź wynik przed zapisem i zwolnij zwrócony obraz po użyciu.

#### **Renderowanie akapitu w domyślnej skali**

Przykład używa prezentacji z jednym slajdem, którego pierwszy kształt to pole tekstowe zawierające trzy akapity.

![Pole tekstowe z trzema akapitami](paragraph_to_image_input.png)

Poniższy przykład wybiera drugi akapit o indeksie 1 i wywołuje [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) bez parametrów skali. Sprawdza, czy kształt zawiera wymagany akapit i czy renderowanie zwróciło obraz, zanim wywoła [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) w formacie PNG. W bloku `finally` obraz jest zwalniany po użyciu.

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

Użyj przeciążenia [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-) przyjmującego parametry `float scaleX` i `float scaleY`, aby ustawić czynniki skali poziomej i pionowej. Poniższy przykład tworzy tabelę, renderuje akapit w jej pierwszej komórce przy podwojeniu domyślnej szerokości i wysokości oraz zapisuje wynik jako obraz PNG.

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

Czynnik skali równy `1` zachowuje domyślny rozmiar w pikselach na danej osi. Na przykład `2` dla obu czynników daje obraz, którego szerokość i wysokość są przybliżone do dwukrotności domyślnych wymiarów, co daje cztery razy więcej pikseli. Większe czynniki zazwyczaj dają ostrzejszy tekst przy powiększaniu lub wyjściu wysokiej rozdzielczości, ale zwiększają zużycie pamięci i rozmiar pliku. Czynniki poniżej `1` tworzą mniejsze obrazy z mniejszą szczegółowością. Używaj równych czynników, aby zachować proporcje akapitu; różne czynniki poziome i pionowe rozciągają wyjście niezależnie.

Renderowanie całego kształtu przy użyciu [IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) pozostaje przydatne, gdy wyjście musi zawierać wypełnienie, obramowanie lub inny kontekst wizualny kształtu. Dla obrazu wyłącznie akapitu użyj [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Czy mogę całkowicie wyłączyć łamanie linii w ramce tekstowej?**

Tak. Ustaw [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) aby wyłączyć łamanie, dzięki czemu linie nie będą się łamały na krawędziach ramki tekstowej.

**Jak mogę uzyskać dokładne granice na slajdzie konkretnego akapitu?**

Użyj [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) aby pobrać prostokąt ograniczający akapit. [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) dostarcza granice pojedynczego fragmentu.

**Gdzie kontrolowane jest wyrównanie akapitu (lewo, prawo, środek lub justowanie)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) jest ustawieniem na poziomie akapitu i ma zastosowanie do całego akapitu, niezależnie od formatowania poszczególnych fragmentów.

Aby pionowo wyrównać fragmenty o różnych rozmiarach czcionek w każdej linii, zobacz [Align Fonts Within a Line](/slides/pl/java/text-formatting/#align-fonts-within-a-line).

**Czy mogę ustawić język korekty dla części akapitu?**

Tak. Ustaw [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) dla poszczególnych fragmentów, aby jeden akapit mógł zawierać tekst w wielu językach.