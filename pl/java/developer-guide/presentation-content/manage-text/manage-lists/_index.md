---
title: Zarządzanie listami wypunktowanymi i numerowanymi w prezentacjach w Javie
linktitle: Zarządzanie listami
type: docs
weight: 60
url: /pl/java/manage-lists/
keywords:
- punktor
- lista wypunktowana
- lista numerowana
- symbolowy punktor
- punktor obrazkowy
- niestandardowy punktor
- lista wielopoziomowa
- tworzenie punktora
- dodawanie punktora
- dodawanie listy
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować listy wypunktowane, obrazkowe, wielopoziomowe oraz numerowane w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Javy."
---
## **Przegląd**

Aspose.Slides for Java umożliwia tworzenie i formatowanie list wypunktowanych i numerowanych w prezentacjach PowerPoint i OpenDocument. Element listy to akapit, którego ustawienia punktora są kontrolowane poprzez formatowanie akapitu.

Użyj metody [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) aby uzyskać dostęp do ustawień listy na poziomie akapitu. Głównym punktem wejścia jest [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--), które zwraca obiekt [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/). Dzięki temu obiektowi możesz ustawić typ punktora, symbol, obraz, kolor, rozmiar, styl numeracji oraz numer początkowy.

Ten artykuł pokazuje, jak:

- utworzyć listę wypunktowaną ze własnym symbolem
- utworzyć punktor obrazkowy
- utworzyć listę wielopoziomową ustawiając głębokość akapitu
- utworzyć listę numerowaną
- sprawdzić i zmienić formatowanie listy w istniejącej prezentacji
- odczytać rzeczywiste znaczniki list i numery wraz z tekstem akapitu

## **Utworzenie listy wypunktowanej**

Aby utworzyć listę wypunktowaną, dodaj obiekty [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) do [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) i ustaw [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) na [BulletType.Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Symbol). Następnie możesz ustawić [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getColor--) oraz [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) aby kontrolować wygląd punktora.

Poniższy kod Java pokazuje, jak utworzyć listę wypunktowaną na slajdzie:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Symbole wypunktowania](symbol_bullets.png)

## **Utworzenie listy numerowanej**

Używaj list numerowanych, gdy kolejność elementów ma znaczenie. Ustaw [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) na [BulletType.Numbered](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Numbered). Możesz także wybrać format numeracji za pomocą [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) lub ustawić [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) gdy lista ma rozpoczynać się od wartości innej niż 1.

Poniższy kod Java pokazuje, jak utworzyć listę numerowaną na slajdzie:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Numerowane wypunktowania](numbered_bullets.png)

## **Utworzenie punktora obrazkowego**

Aspose.Slides pozwala zastąpić standardowy symbol punktora obrazem. Punktory obrazkowe działają najlepiej z prostymi grafikami, które pozostają czytelne w małym rozmiarze, takimi jak ikony lub małe przezroczyste pliki PNG.

{{% alert color="info" title="Note" %}}
Idealnie, jeśli planujesz zastąpić standardowy symbol punktora obrazem, najlepiej wybrać prostą grafikę z przezroczystym tłem. Takie obrazy dobrze sprawdzają się jako własne symbole punktora.

Pamiętaj, że obraz zostanie skalowany do bardzo małego rozmiaru. Z tego powodu zdecydowanie zalecamy wybranie obrazu, który pozostaje wyraźny i wizualnie efektywny, gdy jest używany jako punktor w liście.
{{% /alert %}}

Aby utworzyć punktor obrazkowy, dodaj obraz do [Presentation.getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--) i przypisz zwrócony obiekt obrazu do [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--). Ustaw [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) na [BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Picture) przed przypisaniem obrazu.

Załóżmy, że mamy "image.png":

![Obraz dla wypunktowań](picture_for_bullets.png)

Poniższy kod Java pokazuje, jak utworzyć punkty obrazkowe na slajdzie:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Punkty obrazkowe](picture_bullets.png)

## **Utworzenie listy wielopoziomowej**

Użyj [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) aby umieścić elementy listy na różnych poziomach. Poziom 0 jest poziomem najwyższym, poziom 1 jest zagnieżdżony pod nim i tak dalej.

Poniższy kod Java pokazuje, jak utworzyć wielopoziomową listę wypunktowaną:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Lista wielopoziomowa](multilevel_list.png)

## **Zmiana istniejącej listy**

Aby zmienić formatowanie listy w istniejącej prezentacji, uzyskaj dostęp do docelowego akapitu i zaktualizuj jego ustawienia [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--). Te same właściwości użyte do tworzenia list mogą być użyte do inspekcji lub modyfikacji list wczytanych z pliku PPT, PPTX lub ODP.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Odczytać rzeczywiste wartości punktora**

Podczas wyodrębniania zawartości prezentacji zachowaj znaczniki listy obok tekstu akapitu. Wywołaj [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--) i uzyskaj [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) aby otrzymać efektywny format punktora. Sprawdź jego [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) przed odczytaniem [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--).

Dla list numerowanych rozróżnij te trzy wartości:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) określa format, np. arabskie cyfry zakończone kropką lub małe litery zakończone kropką.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) podaje numer początkowy dla grupy numerowanych akapitów.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) zwraca sformatowany znacznik dla konkretnego akapitu. Na przykład drugi element listy zaczynającej się od 5 zwróci `6.`.

Zachowaj [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDepth--) przy każdym akapicie, aby utrzymać jego poziom zagnieżdżenia. Rzeczywisty znacznik nie koduje pełnej hierarchii: element zagnieżdżony może zwrócić `c.` zamiast połączonej etykiety takiej jak `6.c.`.

Poniższy przykład samodzielny tworzy listy, zapisuje je do prezentacji i ponownie wczytuje prezentację, aby zgłosić tekst, głębokość, typ punktora i rzeczywistą wartość każdego akapitu. Mały niebieski znacznik obrazkowy jest tworzony z wbudowanego SVG.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Utwórz znacznik obrazkowy bez zewnętrznego pliku obrazu.
    SvgImage svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    IPPImage bulletImage = presentation.getImages().addImage(svg);

    class ListBuilder {
        void addParagraph(String text, short depth, byte type, short start, byte style) {
            Paragraph paragraph = new Paragraph();
            paragraph.setText(text);

            IParagraphFormat format = paragraph.getParagraphFormat();
            format.setDepth(depth);
            format.setMarginLeft(30 + depth * 40);
            format.setIndent(-28);
            format.setSpaceAfter(8);
            format.getDefaultPortionFormat().setFontHeight(22);
            format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
            format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
            format.getBullet().setType(type);
            format.getBullet().setBulletHardColor(NullableBool.True);
            format.getBullet().getColor().setColor(Color.BLACK);
            if (type == BulletType.Numbered) {
                format.getBullet().setNumberedBulletStyle(style);
                format.getBullet().setNumberedBulletStartWith(start);
            } else if (type == BulletType.Symbol) {
                format.getBullet().setChar('\u2022');
            } else if (type == BulletType.Picture) {
                format.getBullet().getPicture().setImage(bulletImage);
            }

            textFrame.getParagraphs().add(paragraph);
        }
    }

    ListBuilder list = new ListBuilder();
    list.addParagraph("First item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Second item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Next nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Deep item", (short) 2, BulletType.Numbered, (short) 4, NumberedBulletStyle.BulletRomanLCPeriod);
    list.addParagraph("Back to top level", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Symbol marker", (short) 0, BulletType.Symbol, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("No bullet", (short) 0, BulletType.None, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Picture marker", (short) 0, BulletType.Picture, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    IAutoShape loadedShape = (IAutoShape) loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Text | Depth | Type | Actual value");
    for (IParagraph paragraph : loadedShape.getTextFrame().getParagraphs()) {
        IBulletFormatEffectiveData bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        String marker;
        switch (bullet.getType()) {
            case BulletType.Numbered:
            case BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        String typeName = BulletType.getName(BulletType.class, bullet.getType());
        System.out.println(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

Źródłowe listy są przedstawione poniżej.

![Listy zaczynające się od 5, zagnieżdżone elementy literowe i rzymskie, znacznik symboliczny, akapit bez punktora oraz niebieski znacznik obrazkowy](actual_bullet_values.png)

Raport odpowiada znacznikom wyświetlanym w PowerPoint:

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

Dla [BulletType.None i BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/), [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) zwraca `null`, a nie pusty ciąg. Obsłuż te typy osobno: pierwszy nie ma znacznika, natomiast drugi wymaga osobnego wyodrębnienia obrazu punktora. Punktor obrazkowy nie może być odtworzony wyłącznie przez wyodrębnienie znacznika tekstowego.

## **FAQ**

**Czy listy wypunktowane i numerowane mogą być eksportowane do PDF lub obrazów?**

Tak. Aspose.Slides zachowuje formatowanie list, gdy format docelowy obsługuje odpowiednie rozmieszczenie tekstu i funkcje punktora.

**Czy mogę edytować listy w istniejących prezentacjach?**

Tak. Wczytaj prezentację, uzyskaj dostęp do docelowego akapitu, sprawdź lub zaktualizuj jego ustawienia [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) i zapisz prezentację.

**Czy listy mogą zawierać tekst niełaciński?**

Tak. Tekst elementów listy może zawierać znaki Unicode, więc możesz tworzyć listy w wielojęzycznych prezentacjach. Upewnij się, że użyte w prezentacji czcionki obsługują potrzebne znaki.