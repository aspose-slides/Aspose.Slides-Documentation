---
title: "Zarządzanie akapitami tekstu PowerPoint na Androidzie"
linktitle: "Zarządzaj akapitem"
type: docs
weight: 40
url: /pl/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
- "dodaj tekst"
- "dodaj akapit"
- "zarządzaj tekstem"
- "zarządzaj akapitem"
- "zarządzaj wypunktowaniem"
- "wcięcie akapitu"
- "wcięcie wiszące"
- "wypunktowanie akapitu"
- "lista numerowana"
- "lista wypunktowana"
- "właściwości akapitu"
- "import HTML"
- "tekst do HTML"
- "akapit do HTML"
- "akapit do obrazu"
- "tekst do obrazu"
- "eksport akapitu"
- "PowerPoint"
- "prezentacja"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Dowiedz się, jak tworzyć i formatować akapity, fragmenty, wypunktowania, listy numerowane, wcięcia, treść HTML oraz obrazy akapitów przy użyciu Aspose.Slides dla Androida w Javie."
---
## **Przegląd**

Aspose.Slides for Android via Java reprezentuje tekst jako hierarchię ramek tekstowych, akapitów i fragmentów:

* [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) reprezentuje kontener tekstowy w kształcie i zapewnia dostęp do jego kolekcji akapitów.
* [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) reprezentuje jeden akapit w ramce tekstowej i zapewnia dostęp do jego fragmentów oraz formatowania na poziomie akapitu.
* [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) reprezentuje fragment tekstu w akapicie. Każdy fragment może mieć własny tekst i formatowanie na poziomie znaków.

Akapit może więc zawierać tekst o różnych czcionkach, kolorach, rozmiarach i innych formatach, używając wielu fragmentów.

## **Tworzenie i formatowanie akapitów**

Twórz akapity w ramce tekstowej kształtu i używaj fragmentów do formatowania pojedynczych fragmentów tekstu. Ten rozdział pokazuje, jak łączyć wiele fragmentów w każdym akapicie oraz stosować różne kolory, rozmiary czcionek i style.

### **Tworzenie akapitów z wieloma fragmentami**

Poniższy przykład Android via Java tworzy trzy akapity, każdy zawierający trzy fragmenty tekstu w kolekcji zwracanej przez [IParagraph.getPortions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getPortions--). Ponownie używa domyślnego akapitu i jego pustego fragmentu, a następnie dodaje pozostałe akapity i fragmenty. Formatowanie jest stosowane za pomocą [IPortion.getPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getPortionFormat--): pierwszy fragment w każdym akapicie jest czerwony, pogrubiony i ma 15 punktów; drugi jest niebieski, kursywa i ma 18 punktów. Trzeci fragment zachowuje domyślne formatowanie:

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

Organizuj tekst akapitu w listy za pomocą symboli, liczb lub własnych obrazów. Przykłady w tej sekcji obejmują formatowanie wypunktowania, listy wielopoziomowe i niestandardowe wartości początkowe numeracji.

### **Tworzenie listy wypunktowanej lub numerowanej**

Wypunktowanie i numerowanie ułatwiają przeglądanie powiązanych elementów. W Aspose.Slides ustawienia listy są definiowane za pomocą [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/).

Ten przykład Android via Java dodaje symbol wypunktowania i element numerowany do tej samej ramki tekstowej. [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) wybiera typ wypunktowania, natomiast [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) podaje symbol, a [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) wybiera styl numeracji. Oba elementy używają czarnych wypunktowań o wysokości 100% i wcięcia akapitu wynoszącego 25 punktów:

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

### **Użycie wypunktowania obrazkowego**

Wypunktowanie obrazkowe pozwala używać własnego obrazu zamiast symbolu lub liczby.

Ten przykład Android via Java dodaje obraz do kolekcji obrazów prezentacji jako [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) i używa go jako wypunktowania akapitu. Wywołuje [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) , aby użyć wypunktowania obrazkowego i przypisuje obraz za pomocą [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--). [IBulletFormat.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) jest ustawione na 100%, aby rozmiar wypunktowania był proporcjonalny do tekstu akapitu:

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

Ustaw [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) , aby umieścić akapity na różnych poziomach listy. Najwyższy poziom ma głębokość `0`.

Ten przykład Android via Java przypisuje wartości [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) od 0 do 3 czterem akapitom, tworząc hierarchię w jednej ramce tekstowej. Każdy akapit używa symbolicznego wypunktowania, przy czym [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) naprzemiennie stosuje okrągłe wypunktowanie i myślnik, aby odróżnić sąsiadujące poziomy:

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

### **Rozpoczęcie elementów listy numerowanej od wartości niestandardowych**

Użyj [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) , aby ustawić początkowy numer wyświetlany dla numerowanego akapitu.

Ten przykład Android via Java ustawia [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) , aby używać numeracji dla trzech akapitów i przypisuje wartości [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 2, 3 i 7. Wartość początkowa jest konfigurowana osobno dla każdego akapitu, co pozwala pomijać numery:

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

Reguluj marginesy i wcięcia akapitu, aby kontrolować położenie pierwszej linii oraz linii łamanych. Możesz także formatować znak końcowego akapitu oddzielnie od widocznych fragmentów tekstu.

### **Ustawienie wcięcia pierwszej linii**

Użyj metody [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) , aby kontrolować wcięcie pierwszej linii akapitu. To ustawienie przesuwa tylko pierwszą linię względem lewego marginesu akapitu. Wartość dodatnia przesuwa pierwszą linię w prawo, podczas gdy pozostałe linie pozostają wyrównane do treści akapitu.

Użyj [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) , gdy potrzebujesz przesunąć cały akapit. Użyj [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) , gdy potrzebujesz przesunąć tylko pierwszą linię.

Poniższy przykład nadaje trzem akapitom taki sam [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 20 punktów oraz wartości [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 0, 20 i 40 punktów. Pierwsze linie zaczynają się kolejno od większych przesunięć, podczas gdy linie łamane zachowują ten sam lewy margines:

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

Wcięcie wiszące to układ akapitu, w którym pierwsza linia zaczyna się po lewej stronie pozostałych linii. W Aspose.Slides efekt ten uzyskuje się za pomocą właściwości [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) . Ustaw `Indent` na wartość ujemną, aby przesunąć pierwszą linię w lewo względem treści akapitu.

W praktyce [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) określa lewą pozycję treści akapitu, a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) określa pozycję pierwszej linii względem tego marginesu. Aby utworzyć wcięcie wiszące, ustaw dodatnią wartość `MarginLeft` i ujemną wartość `Indent`.

To formatowanie jest przydatne w bibliografiach, odnośnikach, hasłach słownika i innych akapitach, gdzie linie łamane muszą być wyrównane pod treścią akapitu, a nie pod pierwszym znakiem pierwszej linii.

Poniższy przykład Android via Java łączy wartości [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 40 i 60 punktów z wartościami [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) -20 i -30 punktów. W każdym akapicie pierwsza linia zaczyna się po lewej stronie linii łamanych; drugi akapit ma głębsze wcięcie wiszące:

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

### **Ustawienie właściwości końcowego fragmentu akapitu**

Metoda [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) kontroluje formatowanie znaku końcowego akapitu. Poniższy przykład tworzy [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) z [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) ustawionym na 48 punktów oraz [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) ustawionym na Times New Roman. Przypisuje ten format do znaku końcowego drugiego akapitu, pozostawiając niezmienione widoczne fragmenty tekstu:

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

Aby zapoznać się z regułami akapitu wpływającymi na automatyczne łamanie i interpunkcję na końcach linii, zobacz [Kontrola łamania linii](/slides/pl/androidjava/text-formatting/#control-line-breaking) i [Kontrola interpunkcji wiszącej](/slides/pl/androidjava/text-formatting/#control-hanging-punctuation).

Użyj [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) , aby policzyć linie zajmowane przez akapit po rozmieszczeniu tekstu, włączając automatyczne łamanie. Jest to przydatne przy sprawdzaniu długości tekstu i układu w szablonach prezentacji.

Akapit jest jednym elementem w [ITextFrame.getParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParagraphs--) i może zajmować kilka renderowanych linii. Jawny podział linii w akapicie wymusza nową linię bez tworzenia kolejnego akapitu. Automatyczne łamanie tworzy linie w oparciu o dostępną szerokość, nie wstawiając jawnych podziałów linii w tekście. Dlatego liczenie akapitów lub znaków podziału linii nie daje liczby renderowanych linii.

Poniższy przykład tworzy kształt tekstowy, liczy jego linie, zwęża kształt, a następnie zastępuje tekst krótszym ciągiem. Przykład włącza łamanie za pomocą [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) i wyłącza autofit za pomocą [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) , aby szerokość kształtu kontrolowała łamanie bez automatycznego zmniejszania tekstu lub rozmiaru kształtu. Każdy pomiar używa [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) . Wymiary kształtu są podane w punktach. Na końcu przykład dodaje kolejny akapit i sumuje liczbę linii w całej ramce tekstowej.

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

Przy tym tekście i tych wymiarach, zwężanie kształtu zwiększa liczbę linii, podczas gdy zastąpienie tekstu krótkim ciągiem ją zmniejsza. Dokładne liczby mogą się różnić w zależności od dostępności i substytucji czcionek, rozmiaru czcionki, marginesów, wcięć, łamania i ustawień autofitu. Używaj czcionek i ustawień układu przeznaczonych dla docelowego środowiska przy sprawdzaniu szablonu.

Liczba linii sama w sobie nie określa, czy tekst przekracza swój kontener. Ważna jest dostępna wysokość, wysokość linii, odstępy między akapitami i liniami oraz zachowanie autofitu; nawet pojedyncza linia może przekroczyć dostępną szerokość przy wyłączonym łamaniu.

## **Importowanie i eksportowanie treści akapitu**

Użyj HTML, aby wprowadzić tekst do prezentacji lub wyeksportować istniejące akapity do użycia poza nią. Ta sekcja pokazuje także, jak renderować pojedyncze akapity jako obrazy, w tym akapity w komórkach tabel.

### **Importowanie tekstu HTML do akapitów**

Użyj [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) , aby przekształcić znacznik HTML w akapity i fragmenty w ramce tekstowej.

Ten przykład Android via Java odczytuje HTML z pliku i przekazuje znacznik do [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) . Czyści domyślny akapit ramki tekstowej, tak aby ramka zawierała tylko zaimportowaną treść. Prostokątny kształt pozostawia margines 10 punktów po każdej stronie slajdu:

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

Użyj [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) , aby wyeksportować wybrany zakres akapitów jako HTML. Podczas ponownego użycia tekstu prezentacji na stronie internetowej, być może zechcesz zachować lokalne wyróżnienia bez przenoszenia czcionki, rozmiaru czy stylów pola tekstowego z prezentacji. Ustaw [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) , aby kontrolować, jak daleko eksporter podąża za dziedziczeniem formatowania.

Pobierz [przykładową prezentację](text-inheritance.pptx) i umieść ją w katalogu roboczym aplikacji. Jej pierwszy slajd zawiera jedną formę tekstową z tekstem "Inherited text; explicit red 18pt". Wejście celowo używa kilku poziomów formatowania:

- Domyślny styl tekstu prezentacji dostarcza czcionkę Calibri i rozmiar 28 pt.
- Styl tekstu pierwszego poziomu ramki tekstowej zapewnia niebieski tekst i kursywę.
- Akapit wyraźnie ustawia pogrubiony tekst.
- Drugi fragment, "explicit red 18pt", wyraźnie ustawia czerwony tekst i rozmiar 18 pt.

Poniższy kompletny przykład eksportuje te same akapity trzykrotnie. Przekazuje [TextToHtmlConversionOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/) do metody eksportu i zapisuje każdy wynik jako osobny plik HTML w kodowaniu UTF-8:

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

Wygenerowany HTML zawiera następujący CSS dla pierwszego fragmentu, "Inherited text; ". Tabela wymienia odpowiednie deklaracje; inne wygenerowane właściwości są pominięte dla przejrzystości.

| Wyjście | Odpowiedni CSS dla pierwszego fragmentu | Wygląd |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Niebieski, pogrubiony, pochyły tekst o rozmiarze 28 pt w czcionce Calibri, jeśli ta czcionka jest dostępna. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Niebieski, pogrubiony, pochyły tekst; otaczająca strona lub przeglądarka dostarcza rodzinę czcionki i rozmiar. |
| `ParagraphOnly.html` | `font-weight:bold` | Pogrubiony tekst; otaczająca strona lub przeglądarka dostarcza rodzinę czcionki, rozmiar, kolor i styl kursywy. |

Drugi fragment zachowuje `color:#ff0000`, `font-size:18pt` i `font-weight:bold` we wszystkich trzech wyjściach. Zachowuje także kursywę w `All` i `TextBox`, ale nie w `ParagraphOnly`. Ograniczenie dziedziczenia nie usuwa więc formatowania wyraźnie przypisanego akapitowi lub fragmentowi.

Otwórz pliki w tej samej przeglądarce, aby je porównać. W dwóch trybach ograniczonych pominięte właściwości CSS są rozwiązywane przez style strony docelowej lub domyślne ustawienia przeglądarki, więc ostateczny wygląd zależy od miejsca użycia HTML.

### **Renderowanie akapitu jako obrazu**

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) renderuje pojedynczy akapit bezpośrednio i zwraca [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/). Zapisz wynik do pliku lub strumienia za pomocą [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) . Nie musisz renderować zawierającego kształtu ani ręcznie przycinać bitmapy.

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) może zwrócić `null`, jeśli akapit nie zostanie znaleziony w swojej kolekcji nadrzędnej, nie ma prawidłowych granic renderowania lub nie może być renderowany. Sprawdź wynik przed zapisaniem i zwolnij zwrócony obraz po użyciu.

#### **Renderowanie akapitu w domyślnej skali**

Przykład używa prezentacji z jednym slajdem, którego pierwszy kształt to pole tekstowe zawierające trzy akapity.

![Pole tekstowe z trzema akapitami](paragraph_to_image_input.png)

Poniższy przykład wybiera drugi akapit o indeksie 1 i wywołuje [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) bez parametrów skali. Sprawdza, czy kształt zawiera wymagany akapit i czy renderowanie zwraca obraz przed wywołaniem [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) w celu zapisania go w formacie PNG. Blok `finally` zwalnia obraz po użyciu.

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

Użyj przeciążenia [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) , które przyjmuje parametry `float scaleX` i `float scaleY`, aby ustawić współczynniki skali poziomej i pionowej. Poniższy przykład tworzy tabelę, renderuje akapit w jej pierwszej komórce przy dwukrotnej szerokości i wysokości względem domyślnej, i zapisuje wynik jako obraz PNG.

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

Współczynnik skali `1` utrzymuje tę oś w domyślnym rozmiarze pikseli. Na przykład `2` dla obu współczynników powoduje, że obraz ma szerokość i wysokość około dwa razy większe niż domyślne wymiary, co daje czterokrotnie więcej pikseli. Większe współczynniki zazwyczaj dają ostrzejszy tekst przy powiększaniu lub wyjściu o wysokiej rozdzielczości, ale zwiększają zużycie pamięci i rozmiar pliku. Współczynniki poniżej `1` tworzą mniejsze obrazy o mniejszej szczegółowości. Używaj równych współczynników, aby zachować proporcje akapitu; różne współczynniki poziome i pionowe rozciągają wynik niezależnie.

Renderowanie całego kształtu za pomocą [IShape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getImage--) pozostaje przydatne, gdy wynik musi zawierać wypełnienie, obramowanie lub inne elementy wizualne kształtu. Dla obrazu zawierającego tylko akapit, użyj [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Czy mogę całkowicie wyłączyć łamanie linii w ramce tekstowej?**

Tak. Ustaw [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) , aby wyłączyć łamanie, dzięki czemu linie nie będą dzielone na krawędziach ramki tekstowej.

**Jak mogę uzyskać dokładne granice konkretnego akapitu na slajdzie?**

Użyj [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getRect--) , aby pobrać prostokąt otaczający akapit. [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getRect--) zapewnia granice pojedynczego fragmentu.

**Gdzie kontrolowane jest wyrównanie akapitu (do lewej, prawej, wyśrodkowane lub wyjustowane)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) jest ustawieniem na poziomie akapitu i ma zastosowanie do całego akapitu, bez względu na formatowanie poszczególnych fragmentów. Aby wyrównać pionowo fragmenty o różnych rozmiarach czcionki w każdej linii, zobacz [Wyrównywanie czcionek w linii](/slides/pl/androidjava/text-formatting/#align-fonts-within-a-line).

**Czy mogę ustawić język korekty dla części akapitu?**

Tak. Ustaw [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) dla poszczególnych fragmentów, aby jeden akapit mógł zawierać tekst w kilku językach.