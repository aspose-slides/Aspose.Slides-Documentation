---
title: Správa textových odstavců PowerPointu v Javě
linktitle: Spravovat odstavec
type: docs
weight: 40
url: /cs/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- přidat text
- přidat odstavec
- spravovat text
- spravovat odstavec
- spravovat odrážku
- odsazení odstavce
- zavěšené odsazení
- odrážka odstavce
- číslovaný seznam
- odrážkový seznam
- vlastnosti odstavce
- importovat HTML
- text do HTML
- odstavec do HTML
- odstavec na obrázek
- text na obrázek
- exportovat odstavec
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, jak pomocí Aspose.Slides pro Javu vytvářet a formátovat odstavce, úseky, odrážky, číslované seznamy, odsazení, HTML obsah a obrázky odstavců."
---
## **Přehled**

Aspose.Slides for Java reprezentuje text jako hierarchii textových rámců, odstavců a úseků:

* [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) představuje kontejner textu v tvaru a poskytuje přístup ke kolekci odstavců.
* [IParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/) představuje jeden odstavec v textovém rámci a poskytuje přístup k úsekům a formátování na úrovni odstavce.
* [IPortion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/) představuje úsek textu v odstavci. Každý úsek může mít vlastní text a formátování na úrovni znaků.

Odstavec tak může obsahovat text s různými písmy, barvami, velikostmi a dalším formátováním pomocí více úseků.

## **Vytvoření a formátování odstavců**

### **Vytvoření odstavců s více úseky**

Následující kroky vytvoří textový rámec se třemi odstavci, z nichž každý obsahuje tři úseky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Přistupte k požadovanému snímku pomocí jeho indexu.
3. Přidejte obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na snímek.
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) tvého tvaru.
5. Použijte výchozí odstavec a přidejte dva další objekty [IParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/) do textového rámce.
6. Přidejte dostatek objektů [IPortion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/) tak, aby každý odstavec obsahoval tři úseky. Výchozí odstavec již obsahuje jeden prázdný úsek.
7. Nastavte text každého úseku.
8. Použijte formátování na úrovni znaků pomocí [IPortion.getPortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/#getPortionFormat--).
9. Uložte upravenou prezentaci.

Tento Java příklad implementuje kroky:

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


## **Vytvoření odrážkových a číslovaných seznamů**

### **Vytvoření odrážkového nebo číslovaného seznamu**

Odrážky a číslování usnadňují přehlednost souvisejících položek. V Aspose.Slides jsou nastavení seznamu definována pomocí [IBulletFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Přistupte k požadovanému snímku pomocí jeho indexu.
3. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na vybraný snímek.
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) tvaru.
5. Odstraňte výchozí odstavec z textového rámce.
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/) pro symbolickou odrážku.
7. Nastavte [IBulletFormat.setType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setType-int-) na [BulletType.Symbol](https://reference.aspose.com/slides/cs/java/com.aspose.slides/bullettype/) a uveďte znak odrážky.
8. Nastavte text odstavce, odsazení, barvu odrážky a výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Vytvořte druhý odstavec a nastavte [IBulletFormat.setType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setType-int-) na [BulletType.Numbered](https://reference.aspose.com/slides/cs/java/com.aspose.slides/bullettype/).
11. Nakonfigurujte styl číslované odrážky a přidejte odstavec do textového rámce.
12. Uložte prezentaci.

Tento Java příklad vytváří symbolickou a číslovanou odrážku:

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


### **Použití obrázkových odrážek**

Obrázkové odrážky vám umožní použít vlastní obrázek místo symbolu nebo čísla.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Přistupte k požadovanému snímku pomocí jeho indexu.
3. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) a získejte jeho [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/).
4. Odstraňte výchozí odstavec z textového rámce.
5. Načtěte obrázek odrážky a přidejte jej do kolekce obrázků prezentace jako [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/).
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/) a nastavte jeho text.
7. Nastavte [IBulletFormat.setType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setType-int-) na [BulletType.Picture](https://reference.aspose.com/slides/cs/java/com.aspose.slides/bullettype/).
8. Přiřaďte obrázek pomocí [IBulletFormat.getPicture](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#getPicture--) a nastavte výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Uložte upravenou prezentaci.

Tento Java příklad vytváří obrázkovou odrážku:

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


### **Vytvoření vícestupňového seznamu**

Nastavte [IParagraphFormat.setDepth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setDepth-short-) pro umístění odstavců na různé úrovně seznamu. Nejvyšší úroveň má hloubku `0`.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a přistupte k snímku.
2. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) a vymažte výchozí odstavec z jeho textového rámce.
3. Vytvořte čtyři odstavce a nakonfigurujte jejich symboly odrážek.
4. Nastavte jejich hodnoty [IParagraphFormat.setDepth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setDepth-short-) na `0`, `1`, `2` a `3`.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

Tento Java příklad vytváří čtyřúrovňový odrážkový seznam:

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


### **Zahájení číslovaných položek seznamu vlastními hodnotami**

Použijte [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) pro nastavení počátečního čísla zobrazeného u číslovaného odstavce.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a přidejte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na snímek.
2. Vymažte výchozí odstavec z textového rámce tvaru.
3. Vytvořte tři číslované odstavce.
4. Nastavte [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) na `2`, `3` a `7` pro příslušné odstavce.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

Tento Java příklad přiřazuje vlastní počáteční číslo každému odstavci:

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

## **Řízení rozložení odstavce a koncových vlastností**

### **Nastavení odsazení první řádky**

Použijte [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) pro řízení odsazení první řádky odstavce. Tato metoda posouvá jen první řádek relativně k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco ostatní řádky zůstávají zarovnané ke tělu odstavce.

Použijte [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) pokud potřebujete posunout celý odstavec. Použijte [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) pokud chcete posunout jen první řádek.

Následující příklad vytváří několik odstavců a používá různé hodnoty [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) k ukázce, jak odsazení první řádky ovlivňuje rozložení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Přistupte k cílovému snímku.
3. Přidejte obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na snímek.
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) tvaru a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte pro ně různé hodnoty [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-).
6. Přidejte odstavce do textového rámce.
7. Uložte upravenou prezentaci.

Tento kód ukazuje, jak nastavit odsazení odstavce:

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

Výsledek:

![Odsazení první řádky odstavců](first_line_indent.png)

### **Nastavení zavěšeného odsazení**

Zavěšené odsazení je rozložení odstavce, kde první řádek začíná vlevo od ostatních řádků. V Aspose.Slides vytvoříte tento efekt pomocí [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Předáním záporné hodnoty posunete první řádek doleva vůči tělu odstavce.

V praxi [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) určuje levý okraj těla odstavce a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) určuje pozici první řádky relativně k tomuto okraji. Pro vytvoření zavěšeného odsazení dejte kladnou hodnotu metodě `setMarginLeft` a zápornou hodnotu metodě `setIndent`.

Toto formátování je užitečné pro bibliografie, odkazy, glosáře a další odstavce, kde mají řádky zabalit pod tělo odstavce místo pod první znak první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Přistupte k cílovému snímku.
3. Přidejte obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na snímek.
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) tvaru a odstraňte výchozí odstavec.
5. Vytvořte odstavce a dejte kladnou hodnotu [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) pro každý odstavec.
6. Předáním záporné hodnoty [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) vytvoříte efekt zavěšeného odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

Tento kód ukazuje, jak nastavit zavěšené odsazení odstavce:

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

Výsledek:

![Zavěšené odsazení odstavců](hanging_indent.png)

### **Nastavení koncových vlastností běhu odstavce**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) řídí formátování koncového znaku odstavce. Následující příklad přiřadí velikost písma a latinské písmo ke koncovému znaku druhého odstavce:

1. Načtěte [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a přistupte k snímku.
2. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) a vymažte jeho výchozí odstavec.
3. Vytvořte dva odstavce a přidejte k nim textové úseky.
4. Vytvořte [PortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portionformat/) pro koncový znak druhého odstavce.
5. Nastavte [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) a [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Přiřaďte formát pomocí [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) a uložte prezentaci.

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


## **Import a export obsahu odstavce**

### **Import HTML textu do odstavců**

Použijte [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) pro převod HTML značkování na odstavce a úseky v textovém rámci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Přistupte k snímku a přidejte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).
3. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) tvaru a vymažte jeho výchozí odstavec.
4. Načtěte zdrojový HTML soubor.
5. Předávejte HTML řetězec metodě [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Uložte upravenou prezentaci.

Tento Java příklad importuje HTML do textového rámce:

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


### **Export textu odstavce do HTML**

Použijte [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) pro export vybraného rozsahu odstavců jako HTML.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a načtěte požadovanou prezentaci.
2. Přistupte k snímku a najděte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/), který obsahuje text.
3. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) tvaru.
4. Zavolejte [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) s indexem počátečního odstavce a počtem odstavců k exportu.
5. Zapište vrácený HTML řetězec do souboru.

Tento Java příklad exportuje všechny odstavce z prvního textového tvaru:

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

### **Vykreslení odstavce jako obrázku**

[IParagraph.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/#getImage--) vykreslí jednotlivý odstavec přímo a vrátí [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/). Výsledek uložte do souboru nebo proudu pomocí [IImage.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Není nutné vykreslovat celý tvar nebo ručně ořezávat bitmapu.

[IParagraph.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/#getImage--) může vrátit `null`, pokud odstavec nelze najít v nadřazené kolekci, nemá platné vykreslovací hranice nebo jej nelze vykreslit. Zkontrolujte výsledek před uložením a po použití uvolněte vrácený obrázek.

#### **Vykreslení odstavce ve výchozím měřítku**

Předpokládejme, že máme soubor prezentace nazvaný sample.pptx s jedním snímkem, kde je první tvar textovým polem obsahujícím tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

Následující příklad vykreslí druhý odstavec v běžném textovém tvaru ve výchozím měřítku a uloží vrácený obrázek ve formátu PNG. Blok `finally` zajistí, že obrázek bude řádně uvolněn.

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

Výsledek:

![Obrázek odstavce](paragraph_to_image_output.png)

#### **Vykreslení odstavce v buňce tabulky se škálováním**

Použijte přetíženou metodu [IParagraph.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/#getImage-float-float-) přijímající parametry `float scaleX` a `float scaleY` pro nastavení horizontálního a vertikálního škálovacího faktoru. Následující příklad vytvoří tabulku, vykreslí odstavec v její první buňce dvakrát šířky a výšky výchozího měřítka a uloží výsledek jako PNG obrázek.

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

Škálovací faktor `1` zachová výchozí velikost pixelu podél dané osy. Například `2` pro oba faktory vytvoří obrázek, jehož šířka i výška jsou přibližně dvojnásobné oproti výchozím rozměrům, což vede ke čtyřnásobnému počtu pixelů. Větší faktory obecně poskytují ostřejší text pro zvětšování nebo výstup ve vysokém rozlišení, ale také zvyšují spotřebu paměti a velikost souboru. Faktory pod `1` produkují menší obrázky s nižší úrovní detailu. Použijte stejné faktory pro zachování poměru stran odstavce; různé horizontální a vertikální faktory roztačí výstup nezávisle.

Vykreslování celého tvaru pomocí [IShape.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getImage--) je užitečné, když výstup musí zahrnovat výplň, okraj nebo jiný vizuální kontext tvaru. Pro obrázek pouze s odstavcem použijte [IParagraph.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/#getImage--).

## **Často kladené otázky**

**Mohu zcela zakázat zalamování řádků uvnitř textového rámce?**

Ano. Nastavením [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) zakážete zalamování, takže řádky se nebudou lámat na okrajích textového rámce.

**Jak mohu získat přesné ohraničení odstavce na snímku?**

Použijte [IParagraph.getRect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/#getRect--) pro získání ohraničujícího obdélníku odstavce. [IPortion.getRect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/#getRect--) poskytuje ohraničení jednotlivého úseku.

**Kde se řídí zarovnání odstavce (vlevo, vpravo, na střed nebo do bloku)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) je nastavení na úrovni odstavce a vztahuje se na celý odstavec bez ohledu na formátování jednotlivých úseků.

**Mohu nastavit jazyk kontroly pravopisu pro část odstavce?**

Ano. Nastavte [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) pro jednotlivé úseky, takže jeden odstavec může obsahovat text v několika jazycích.