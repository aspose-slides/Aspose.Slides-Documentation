---
title: Správa textových odstavců PowerPointu v Java
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
  - visící odsazení
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
description: "Naučte se, jak pomocí Aspose.Slides pro Java vytvářet a formátovat odstavce, části, odrážky, číslované seznamy, odsazení, HTML obsah a obrázky odstavců."
---
## **Přehled**

Aspose.Slides for Java představuje text jako hierarchii textových rámců, odstavců a částí:

* [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) představuje kontejner textu ve tvaru a poskytuje přístup k jeho kolekci odstavců.
* [IParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/) představuje jeden odstavec v textovém rámci a poskytuje přístup k jeho částem a formátování na úrovni odstavce.
* [IPortion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/) představuje úsek textu v odstavci. Každá část může mít vlastní text a formátování na úrovni znaků.

Odstavec tak může obsahovat text s různými fonty, barvami, velikostmi a dalším formátováním pomocí více částí.

## **Vytváření a formátování odstavců**

### **Vytvoření odstavců s více částmi**

Následující kroky vytvoří textový rámec se třemi odstavci, z nichž každý obsahuje tři části:

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte požadovaný snímek pomocí jeho indexu.
3. Přidejte obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na snímek.
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) tvaru.
5. Použijte výchozí odstavec a přidejte dva další objekty [IParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/) do textového rámce.
6. Přidejte dostatek objektů [IPortion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/) , aby každý odstavec obsahoval tři části. Výchozí odstavec již obsahuje jednu prázdnou část.
7. Nastavte text každé části.
8. Použijte formátování na úrovni znaků prostřednictvím [IPortion.getPortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/#getPortionFormat--).
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

Odrážky a číslování usnadňují skenování souvisejících položek. V Aspose.Slides jsou nastavení seznamu definována pomocí [IBulletFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/).

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte požadovaný snímek pomocí jeho indexu.
3. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na vybraný snímek.
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/).
5. Odstraňte výchozí odstavec z textového rámce.
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/) pro symbolickou odrážku.
7. Nastavte [IBulletFormat.setType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setType-int-) na [BulletType.Symbol](https://reference.aspose.com/slides/cs/java/com.aspose.slides/bullettype/) a určete znak odrážky.
8. Nastavte text odstavce, odsazení, barvu odrážky a výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Vytvořte druhý odstavec a nastavte [IBulletFormat.setType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setType-int-) na [BulletType.Numbered](https://reference.aspose.com/slides/cs/java/com.aspose.slides/bullettype/).
11. Nastavte styl číslované odrážky a přidejte odstavec do textového rámce.
12. Uložte prezentaci.

Tento Java příklad vytvoří symbolickou odrážku a číslovanou odrážku:

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

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte požadovaný snímek pomocí jeho indexu.
3. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) a získejte jeho [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/).
4. Odstraňte výchozí odstavec z textového rámce.
5. Načtěte obrázek odrážky a přidejte jej do kolekce obrázků prezentace jako [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/).
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/) a nastavte jeho text.
7. Nastavte [IBulletFormat.setType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setType-int-) na [BulletType.Picture](https://reference.aspose.com/slides/cs/java/com.aspose.slides/bullettype/).
8. Přiřaďte obrázek pomocí [IBulletFormat.getPicture](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#getPicture--) a nastavte výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Uložte upravenou prezentaci.

Tento Java příklad vytvoří obrázkovou odrážku:

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

### **Vytvoření víceúrovňového seznamu**

Nastavte [IParagraphFormat.setDepth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setDepth-short-) , aby se odstavce umístily na různé úrovně seznamu. Nejvyšší úroveň má hloubku `0`.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a získejte snímek.
2. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) a vymažte výchozí odstavec z jeho textového rámce.
3. Vytvořte čtyři odstavce a nakonfigurujte jejich symboly odrážek.
4. Nastavte jejich hodnoty [IParagraphFormat.setDepth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setDepth-short-) na `0`, `1`, `2` a `3`.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

Tento Java příklad vytvoří čtyřúrovňový odrážkový seznam:

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

### **Zahájení číslovaných položek seznamu na vlastní hodnoty**

Použijte [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) , abyste nastavili počáteční číslo zobrazené pro číslovaný odstavec.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a přidejte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na snímek.
2. Vymažte výchozí odstavec z textového rámce tvaru.
3. Vytvořte tři číslované odstavce.
4. Nastavte [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) na `2`, `3` a `7` pro příslušné odstavce.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

Tento Java příklad přiřadí vlastní počáteční číslo každému odstavci:

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

Použijte [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) , abyste ovládali odsazení první řádky odstavce. Tato metoda posouvá jen první řádek vzhledem k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco zbylé řádky zůstávají zarovnané k tělu odstavce.

Použijte [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) , když potřebujete přesunout celý odstavec. Použijte [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) , když potřebujete přesunout jen první řádek.

Níže uvedený příklad vytvoří několik odstavců a použije různé hodnoty [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) , aby ukázal, jak odsazení první řádky ovlivňuje rozložení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na snímek.
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) tvaru a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte pro ně různé hodnoty [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) .
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

![The first-line indent of the paragraphs](first_line_indent.png)

### **Nastavení visícího odsazení**

Visící odsazení je rozvržení odstavce, ve kterém první řádek začíná vlevo od zbylých řádků. V Aspose.Slides tento efekt vytvoříte pomocí [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Přiřaďte zápornou hodnotu, aby se první řádek posunul vlevo vzhledem k tělu odstavce.

V praxi [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) určuje levý pozic těla odstavce a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) určuje pozici první řádky vzhledem k tomu okraji. Pro vytvoření visícího odsazení přiřaďte kladnou hodnotu metodě `setMarginLeft` a zápornou hodnotu metodě `setIndent`.

Toto formátování je užitečné pro bibliografie, odkazy, položky glosáře a další odstavce, kde musí zlomky řádků být zarovnány pod tělo odstavce místo pod první znak první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na snímek.
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) tvaru a odstraňte výchozí odstavec.
5. Vytvořte odstavce a pro každý odstavec přiřaďte kladnou hodnotu metodě [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) .
6. Přiřaďte zápornou hodnotu metodě [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) , aby se vytvořil efekt visícího odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

Tento kód ukazuje, jak nastavit visící odsazení pro odstavec:

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

![The hanging indent of the paragraphs](hanging_indent.png)

### **Nastavení koncových vlastností spuštění odstavce**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) řídí formátování koncového značení odstavce. Následující příklad přiřadí velikost písma a latinský font ke koncovému znaku druhého odstavce:

1. Načtěte [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a získejte snímek.
2. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) a vymažte jeho výchozí odstavec.
3. Vytvořte dva odstavce a přidejte k nim textové části.
4. Vytvořte [PortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portionformat/) pro koncové označení druhého odstavce.
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

## **Počítání vykreslených řádků**

Použijte [IParagraph.getLinesCount](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/#getLinesCount--) , abyste spočítali řádky obsazené odstavcem po rozmístění textu, včetně automatického zalamování. To je užitečné při kontrole délky textu a rozvržení v šablonách prezentací.

Odstavec je jedna položka v [ITextFrame.getParagraphs](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#getParagraphs--) , a může zabírat několik vykreslených řádků. Explicitní zalomení řádky v odstavci vynutí nový řádek bez vytvoření dalšího odstavce. Automatické zalamování vytváří řádky na základě dostupné šířky, aniž by vkládalo explicitní zalomení řádky do textu. Počítání odstavců nebo znaků pro zalomení řádky tedy neposkytuje počet vykreslených řádků.

Následující příklad vytvoří textový tvar, spočítá jeho řádky, zúží tvar a poté nahradí text kratším řetězcem. Zalamování je povoleno a automatické přizpůsobení je vypnuto, aby šířka tvaru řídila zalamování, aniž by se text automaticky zmenšoval nebo tvar měnil. Rozměry tvaru jsou v bodech. Nakonec příklad přidá další odstavec a sečte počty řádků v textovém rámci.

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

S tímto textem a těmito rozměry zúžení tvaru zvýší počet řádků, zatímco nahrazení textu krátkým řetězcem jej sníží. Přesné počty se mohou lišit podle dostupnosti a nahrazení fontů, velikosti písma, okrajů, odsazení, zalamování a nastavení automatického přizpůsobení. Používejte fonty a nastavení rozvržení určené pro cílové prostředí při kontrole šablony.

Počet řádků sám o sobě neurčuje, zda text přesahuje svůj kontejner. Důležité jsou také dostupná výška, výšky řádků, odstavec a řádkové rozestupy a chování automatického přizpůsobení; i jediný řádek může překročit dostupnou šířku, když je zalamování vypnuto.

## **Import a export obsahu odstavců**

### **Import HTML textu do odstavců**

Použijte [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) , abyste převáděli HTML značky na odstavce a části v textovém rámci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte snímek a přidejte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) .
3. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) tvaru a vymažte jeho výchozí odstavec.
4. Přečtěte zdrojový soubor HTML.
5. Předávejte řetězec HTML metodě [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) .
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

Použijte [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) , abyste exportovali vybraný rozsah odstavců jako HTML.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a načtěte požadovanou prezentaci.
2. Získejte snímek a najděte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) , který obsahuje text.
3. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) .
4. Zavolejte [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) s indexem počátečního odstavce a počtem odstavců k exportu.
5. Zapište vrácený řetězec HTML do souboru.

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

[IParagraph.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/#getImage--) vykreslí jednotlivý odstavec přímo a vrátí [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/). Výsledek uložte do souboru nebo proudu pomocí [IImage.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Nemusíte vykreslovat obsahující tvar ani ručně ořezávat bitmapu.

[IParagraph.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/#getImage-float-float-) může vrátit `null`, pokud odstavec nelze najít v nadřazené kolekci, nemá platné vykreslovací ohraničení nebo nelze vykreslit. Zkontrolujte výsledek před uložením a po použití uvolněte vrácený obrázek.

#### **Vykreslení odstavce v výchozím měřítku**

Předpokládejme, že máme soubor prezentace nazvaný sample.pptx s jedním snímkem, kde je první tvar textové pole obsahující tři odstavce.

![The text box with three paragraphs](paragraph_to_image_input.png)

Následující příklad vykreslí druhý odstavec v běžném textovém tvaru ve výchozím měřítku a uloží vrácený obrázek ve formátu PNG. Blok `finally` zajistí správné uvolnění obrázku.

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

![The paragraph image](paragraph_to_image_output.png)

#### **Vykreslení odstavce v buňce tabulky se škálováním**

Použijte přetížení [IParagraph.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/#getImage-float-float-) , které přijímá parametry `float scaleX` a `float scaleY` pro nastavení horizontálního a vertikálního měřítka. Následující příklad vytvoří tabulku, vykreslí odstavec v její první buňce dvakrát ve výchozí šířce a výšce a výsledek uloží jako PNG obrázek.

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

Měřítkový faktor `1` zachovává tuto osu v její výchozí velikosti pixelu. Například `2` pro oba faktory vytvoří obrázek, jehož šířka a výška jsou přibližně dvakrát větší než výchozí rozměry, což vede k čtyřnásobku pixelů. Větší faktory obecně poskytují ostřejší text pro zoom nebo výstup ve vysokém rozlišení, ale také zvyšují nároky na paměť a velikost souboru. Faktory pod `1` vytvářejí menší obrázky s méně podrobným zobrazením. Používejte stejné faktory, aby se zachoval poměr stran odstavce; různé horizontální a vertikální faktory roztažením ovlivňují výstup nezávisle.

Vykreslení celého tvaru pomocí [IShape.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getImage--) je užitečné, když výstup musí obsahovat výplň, okraj nebo jiný vizuální kontext tvaru. Pro obrázek jen s odstavcem použijte [IParagraph.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/#getImage--).

## **Často kladené otázky**

**Mohu zcela zakázat zalamování řádků uvnitř textového rámce?**

Ano. Nastavte [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) na zakázání zalamování, aby řádky nepadaly na okrajích textového rámce.

**Jak mohu získat přesné ohraničení konkrétního odstavce na snímku?**

Použijte [IParagraph.getRect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/#getRect--) , abyste získali ohraničující obdélník odstavce. [IPortion.getRect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/#getRect--) poskytuje ohraničení jednotlivé části.

**Kde se řídí zarovnání odstavce (vlevo, vpravo, na střed nebo do bloku)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) je nastavení na úrovni odstavce a vztahuje se na celý odstavec bez ohledu na formátování jednotlivých částí.

**Mohu nastavit jazyk pro kontrolu pravopisu pro část odstavce?**

Ano. Nastavte [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) pro jednotlivé části, takže jeden odstavec může obsahovat text v několika jazycích.