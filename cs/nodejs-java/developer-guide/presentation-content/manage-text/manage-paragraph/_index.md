---
title: Správa textových odstavců PowerPoint v JavaScriptu
linktitle: Správa odstavce
type: docs
weight: 40
url: /cs/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
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
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Naučte se, jak vytvářet a formátovat odstavce, části, odrážky, číslované seznamy, odsazení, HTML obsah a obrázky odstavců pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Aspose.Slides for Node.js via Java představuje text jako hierarchii textových rámců, odstavců a částí:

* [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) představuje kontejner textu ve tvaru a poskytuje přístup k jeho kolekci odstavců.
* [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/) představuje jeden odstavec v textovém rámci a poskytuje přístup k jeho částem a formátování na úrovni odstavce.
* [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/) představuje úsek textu v odstavci. Každá část může mít vlastní text a formátování na úrovni znaků.

Odstavec tak může obsahovat text s různými fonty, barvami, velikostmi a dalším formátováním pomocí více částí.

## **Vytváření a formátování odstavců**

### **Vytváření odstavců s více částmi**

Následující kroky vytvoří textový rámec se třemi odstavci, z nichž každý obsahuje tři části:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Přistupte k požadovanému snímku podle jeho indexu.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
4. Přistupte k [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) tvaru.
5. Použijte výchozí odstavec a přidejte dva další objekty [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/) do textového rámce.
6. Přidejte dostatek objektů [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/) tak, aby každý odstavec obsahoval tři části. Výchozí odstavec již obsahuje jednu prázdnou část.
7. Nastavte text každé části.
8. Použijte formátování na úrovni znaků pomocí [Portion.getPortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/getportionformat/).
9. Uložte upravenou prezentaci.

Tento JavaScriptový příklad implementuje kroky:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vytváření odrážkových a číslovaných seznamů**

### **Vytvoření odrážkového nebo číslovaného seznamu**

Odrážky a číslování usnadňují přehlednost souvisejících položek. V Aspose.Slides jsou nastavení seznamu definována pomocí [BulletFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bulletformat/).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Přistupte k požadovanému snímku podle jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na vybraný snímek.
4. Přistupte k [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) tvaru.
5. Odeberte výchozí odstavec z textového rámce.
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/) pro symbolickou odrážku.
7. Nastavte [BulletFormat.setType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bulletformat/settype/) na [BulletType.Symbol](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bullettype/) a zadejte znak odrážky.
8. Nastavte text odstavce, odsazení, barvu odrážky a výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Vytvořte druhý odstavec a nastavte [BulletFormat.setType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bulletformat/settype/) na [BulletType.Numbered](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bullettype/).
11. Nakonfigurujte styl číslované odrážky a přidejte odstavec do textového rámce.
12. Uložte prezentaci.

Tento JavaScriptový příklad vytváří symbolickou odrážku a číslovanou odrážku:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Použití obrázkových odrážek**

Obrázkové odrážky umožňují použít vlastní obrázek místo symbolu nebo čísla.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Přistupte k požadovanému snímku podle jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) a přistupte k jeho [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/).
4. Odeberte výchozí odstavec z textového rámce.
5. Načtěte obrázek odrážky a přidejte jej do kolekce obrázků prezentace jako [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/).
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/) a nastavte jeho text.
7. Nastavte [BulletFormat.setType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bulletformat/settype/) na [BulletType.Picture](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bullettype/).
8. Přiřaďte obrázek pomocí [BulletFormat.getPicture](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bulletformat/getpicture/) a nastavte výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Uložte upravenou prezentaci.

Tento JavaScriptový příklad vytváří obrázkovou odrážku:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Vytvoření víceúrovňového seznamu**

Nastavte [ParagraphFormat.setDepth](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setdepth/) pro umístění odstavců na různé úrovně seznamu. Nejvyšší úroveň má hloubku `0`.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a přistupte k snímku.
2. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) a vymažte výchozí odstavec z jeho textového rámce.
3. Vytvořte čtyři odstavce a nakonfigurujte jejich symboly odrážek.
4. Nastavte jejich hodnoty [ParagraphFormat.setDepth](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setdepth/) na `0`, `1`, `2` a `3`.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

Tento JavaScriptový příklad vytváří čtyřúrovňový odrážkový seznam:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Zahájení číslovaných položek seznamu vlastními hodnotami**

Použijte [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) pro nastavení počátečního čísla zobrazeného pro číslovaný odstavec.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
2. Vymažte výchozí odstavec z textového rámce tvaru.
3. Vytvořte tři číslované odstavce.
4. Nastavte [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) na `2`, `3` a `7` pro příslušné odstavce.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

Tento JavaScriptový příklad přiřazuje vlastní počáteční číslo každému odstavci:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Řízení rozvržení odstavce a koncových vlastností**

### **Nastavení odsazení první řádky**

Použijte [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setindent/) pro řízení odsazení první řádky odstavce. Tato metoda posouvá pouze první řádek relativně k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco zbylé řádky zůstanou zarovnané k tělu odstavce.

Použijte [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) pokud potřebujete posunout celý odstavec. Použijte [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setindent/) pokud potřebujete posunout jen první řádek.

Níže uvedený příklad vytvoří několik odstavců a použije různé hodnoty [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setindent/) k demonstraci, jak odsazení první řádky ovlivňuje rozvržení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Přistupte k cílovému snímku.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
4. Přistupte k [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) tvaru a odeberte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte pro ně různé hodnoty [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setindent/).
6. Přidejte odstavce do textového rámce.
7. Uložte upravenou prezentaci.

Tento kód ukazuje, jak nastavit odsazení odstavce:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Odsazení první řádky odstavců](first_line_indent.png)

### **Nastavení visícího odsazení**

Visící odsazení je rozvržení odstavce, ve kterém první řádek začíná vlevo od zbytku řádků. V Aspose.Slides tohoto efektu dosáhnete pomocí [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setindent/). Zadejte zápornou hodnotu pro posunutí první řádky doleva relativně k tělu odstavce.

V praxi [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) určuje levou pozici těla odstavce a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setindent/) určuje pozici první řádky relativně k tomu okraji. Pro vytvoření visícího odsazení dejte kladnou hodnotu `setMarginLeft` a zápornou hodnotu `setIndent`.

Toto formátování je užitečné pro bibliografie, odkazy, položky glosáře a jiné odstavce, kde musí být zabalené řádky zarovnány pod tělo odstavce, nikoli pod první znak první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Přistupte k cílovému snímku.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
4. Přistupte k [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) tvaru a odeberte výchozí odstavec.
5. Vytvořte odstavce a pro každý zadejte kladnou hodnotu [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setmarginleft/).
6. Zadejte zápornou hodnotu [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setindent/) pro vytvoření efektu visícího odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

Tento kód ukazuje, jak nastavit visící odsazení pro odstavec:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Visící odsazení odstavců](hanging_indent.png)

### **Nastavení koncových vlastností běhu odstavce**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) řídí formátování koncového znaku odstavce. Následující příklad přiřadí velikost písma a latinský font koncovému znaku druhého odstavce:

1. Vytvořte nebo načtěte [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a přistupte k snímku.
2. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) a vymažte jeho výchozí odstavec.
3. Vytvořte dva odstavce a přidejte k nim textové části.
4. Vytvořte [PortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portionformat/) pro koncový znak druhého odstavce.
5. Nastavte [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) a [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setLatinFont).
6. Přiřaďte formát pomocí [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) a uložte prezentaci.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Import a export obsahu odstavců**

### **Import HTML textu do odstavců**

Použijte [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) pro převod HTML značek na odstavce a části v textovém rámci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Přistupte k snímku a přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/).
3. Přistupte k [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) tvaru a vymažte jeho výchozí odstavec.
4. Definujte nebo načtěte zdrojový HTML řetězec.
5. Předávejte HTML řetězec metodě [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
6. Uložte upravenou prezentaci.

Tento JavaScriptový příklad importuje HTML do textového rámce:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Export textu odstavce do HTML**

Použijte [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) pro export vybraného rozsahu odstavců jako HTML.

1. Vytvořte nebo načtěte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Přistupte k snímku a najděte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/), který obsahuje text.
3. Přistupte k [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) tvaru.
4. Zavolejte [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) s počátečním indexem odstavce a počtem odstavců k exportu.
5. Zapište vrácený HTML řetězec do souboru.

Tento samostatný JavaScriptový příklad vytvoří textový tvar a exportuje všechny jeho odstavce:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Vykreslení odstavce jako obrázku**

[Paragraph.getImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/#getImage) vykreslí jednotlivý odstavec přímo a vrátí [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/). Výsledek uložte do souboru pomocí [IImage.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/#save). Není nutné vykreslovat obsahující tvar nebo ručně ořezávat bitmapu.

[Paragraph.getImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/#getImage) může vrátit `null`, pokud odstavec nelze najít v jeho nadřazené kolekci, nemá platné oblasti renderování nebo jej nelze vykreslit. Ověřte výsledek před uložením a po použití uvolněte vrácený obrázek.

#### **Vykreslení odstavce v výchozím měřítku**

Následující textové pole obsahuje tři odstavce:

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

Následující příklad vykreslí druhý odstavec v běžném textovém tvaru ve výchozím měřítku a uloží získaný obrázek ve formátu PNG. Blok `finally` zajišťuje správné uvolnění obrázku.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Výsledek:

![Obrázek odstavce](paragraph_to_image_output.png)

#### **Vykreslení odstavce v buňce tabulky se škálováním**

Použijte přetížení [Paragraph.getImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/#getImage), které přijímá parametry `scaleX` a `scaleY` pro nastavení horizontálního a vertikálního měřítka. Následující příklad vytvoří tabulku, vykreslí odstavec v její první buňce dvojnásobně v šířce i výšce a uloží výsledek jako PNG obrázek.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Faktor měřítka `1` zachová výchozí velikost v pixelech. Např. faktor `2` pro oba osy vytvoří obrázek, jehož šířka a výška jsou přibližně dvojnásobné, což dává čtyřnásobek pixelů. Větší faktory obecně poskytují ostřejší text pro přiblížení nebo výstup ve vysokém rozlišení, ale také zvyšují spotřebu paměti a velikost souboru. Faktory pod `1` vytvářejí menší obrázky s méně podrobným zobrazením. Použijte stejné faktory pro zachování poměru stran odstavce; různé horizontální a vertikální faktory roztaží výstup nezávisle.

Vykreslení celého tvaru pomocí [Shape.getImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getImage) zůstává užitečné, když výstup musí zahrnovat výplň, okraj nebo jiný vizuální kontext tvaru. Pro obrázek pouze odstavce použijte [Paragraph.getImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/#getImage).

## **Často kladené otázky**

**Mohu zcela zakázat zalamování řádků uvnitř textového rámce?**

Ano. Nastavte [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/setwraptext/) na zakázání zalamování, aby řádky neřezaly na okrajích textového rámce.

**Jak získat přesné rozměry konkrétního odstavce na snímku?**

Použijte [Paragraph.getRect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/getrect/) pro získání ohraničujícího obdélníku odstavce. [Portion.getRect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/#getRect) poskytuje rozměry jednotlivé části.

**Kde se řídí zarovnání odstavce (vlevo, vpravo, na střed nebo do bloku)?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setalignment/) je nastavení na úrovni odstavce a platí pro celý odstavec bez ohledu na formátování jednotlivých částí.

**Mohu nastavit jazyk kontroly pravopisu pro část odstavce?**

Ano. Nastavte [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) pro jednotlivé části, takže jeden odstavec může obsahovat text v několika jazycích.