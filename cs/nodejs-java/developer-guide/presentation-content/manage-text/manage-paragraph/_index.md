---
title: Spravovat textové odstavce PowerPointu v JavaScriptu
linktitle: Spravovat odstavec
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
- zavěšené odsazení
- odrážka odstavce
- číslovaný seznam
- odrážkový seznam
- vlastnosti odstavce
- import HTML
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
description: "Zjistěte, jak vytvářet a formátovat odstavce, části, odrážky, číslované seznamy, odsazení, HTML obsah a obrázky odstavců pomocí Aspose.Slides pro Node.js prostřednictvím Javy."
---
## **Přehled**

Aspose.Slides pro Node.js prostřednictvím Java představuje text jako hierarchii textových rámců, odstavců a částí:

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) představuje kontejner textu ve tvaru a poskytuje přístup k jeho kolekci odstavců.
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) představuje jeden odstavec v textovém rámci a poskytuje přístup k jeho částem a formátování na úrovni odstavce.
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) představuje úsek textu v rámci odstavce. Každá část může mít své vlastní textové a znakové formátování.

Odstavec tak může obsahovat text s různými písmy, barvami, velikostmi a dalším formátováním pomocí více částí.

## **Vytvoření a formátování odstavců**

Vytvářejte odstavce v textovém rámci tvaru a pomocí částí formátujte jednotlivé úseky textu. Tato sekce ukazuje, jak zkombinovat více částí v každém odstavci a použít různé barvy, velikosti písma a styly.

### **Vytvořit odstavce s více částmi**

Následující JavaScriptový příklad vytváří tři odstavce, z nichž každý obsahuje tři úseky textu ve sbírce vrácené metodou [Paragraph.getPortions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getportions/). Znovu používá výchozí odstavec a jeho prázdnou část, poté přidává zbývající odstavce a části. Formátování se aplikuje pomocí [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/): první část v každém odstavci je červená, tučná a 15 bodů; druhá je modrá, kurzíva a 18 bodů. Třetí část zachovává výchozí formátování:

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

## **Vytvoření odrážkových a číslovaných seznamů**

Organizujte text odstavců do seznamů se symboly, čísly nebo vlastními obrázky. Příklady v této sekci pokrývají formátování odrážek, víceúrovňové seznamy a vlastní počáteční čísla.

### **Vytvořit odrážkový nebo číslovaný seznam**

Odrážky a číslování usnadňují prohlížení souvisejících položek. V Aspose.Slides se nastavení seznamu definuje pomocí [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/).

Tento JavaScriptový příklad přidává symbolickou odrážku a číslovanou položku do stejného textového rámce. [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) vybírá typ odrážky, zatímco [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) poskytuje symbol a [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstyle/) vybírá styl číslování. Obě položky používají černé odrážky s výškou 100 % a odsazením odstavce 25 bodů:

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

### **Použít obrázkové odrážky**

Obrázkové odrážky vám umožní použít vlastní obrázek místo symbolu nebo čísla.

Tento JavaScriptový příklad načte `image.png` z pracovního adresáře aplikace, přidá obrázek do kolekce obrázků prezentace jako [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) a použije jej jako odrážku odstavce. Volá [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) pro použití obrázkové odrážky a přiřadí obrázek pomocí [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/). [BulletFormat.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setheight/) je nastaven na 100 % pro velikost odrážky relativně k textu odstavce:

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

### **Vytvořit víceúrovňový seznam**

Nastavte [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) pro umístění odstavců na různé úrovně seznamu. Nejvyšší úroveň má hloubku `0`.

Tento JavaScriptový příklad přiřazuje hodnoty [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) od 0 do 3 čtyřem odstavcům, čímž vytváří hierarchii v rámci jednoho textového rámce. Každý odstavec používá symbolickou odrážku, přičemž [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) střídavě používá kulatou odrážku a spojovník pro rozlišení sousedních úrovní:

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

### **Začít číslovat položky seznamu vlastními hodnotami**

Použijte [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) pro nastavení počátečního čísla zobrazovaného u číslovaného odstavce.

Tento JavaScriptový příklad nastavuje [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) pro použití číslování u tří odstavců a přiřazuje hodnoty [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 2, 3 a 7. Počáteční hodnota je konfigurována samostatně pro každý odstavec, což umožňuje, aby se zobrazovaná čísla přeskočila:

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

Upravujte okraje a odsazení odstavců pro kontrolu polohy první řádky a zalomených řádků. Můžete také formátovat koncový znak odstavce odděleně od viditelných částí textu.

### **Nastavit odsazení první řádky**

Použijte metodu [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) pro kontrolu odsazení první řádky odstavce. Toto nastavení posouvá jen první řádek vzhledem k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco zbývající řádky zůstanou zarovnané k tělu odstavce.

Použijte [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) když potřebujete posunout celý odstavec. Použijte [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) když potřebujete posunout jen první řádek.

Následující příklad dává třem odstavcům stejný [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 20 bodů a hodnoty [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) 0, 20 a 40 bodů. První řádky začínají postupně většími posuny, zatímco zalomené řádky si zachovávají stejný levý okraj:

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

### **Nastavit zavěšené odsazení**

Zavěšené odsazení je rozvržení odstavce, ve kterém první řádek začíná vlevo od zbývajících řádků. V Aspose.Slides vytvoříte tento efekt pomocí metody [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/). Nastavte odsazení na zápornou hodnotu, aby se první řádek posunul vlevo vzhledem k tělu odstavce.

V praxi [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) určuje levý polohu těla odstavce a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) určuje polohu první řádky relativně k tomuto okraji. Pro vytvoření zavěšeného odsazení nastavte kladný levý okraj a záporné odsazení.

Toto formátování je užitečné pro bibliografie, odkazy, glosářové položky a další odstavce, kde musí být zalomené řádky zarovnány pod tělo odstavce, nikoli pod první znak první řádky.

Následující JavaScriptový příklad spojuje hodnoty [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 40 a 60 bodů s hodnotami [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) –20 a –30 bodů. V každém odstavci první řádek začíná vlevo od zalomených řádků; druhý odstavec má hlubší zavěšené odsazení:

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

![Zavěšené odsazení odstavců](hanging_indent.png)

### **Nastavit vlastnosti koncového úseku odstavce**

Metoda [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) řídí formátování koncového znaku odstavce. Následující příklad vytváří [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) s [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) nastaveným na 48 bodů a [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) nastaveným na Times New Roman. Tento formát přiřadí k koncovému znaku druhého odstavce, přičemž viditelné textové části zůstávají nezměněny:

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

## **Počítání vykreslených řádků**

Pro pravidla odstavců, která ovlivňují automatické zalamování a interpunkci na konci řádků, viz [Control Line Breaking](/slides/cs/nodejs-java/text-formatting/#control-line-breaking) a [Control Hanging Punctuation](/slides/cs/nodejs-java/text-formatting/#control-hanging-punctuation).

Použijte [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) k získání počtu řádků, které odstavec zabírá po rozvržení textu, včetně automatického zalamování. Toto je užitečné při kontrole délky textu a rozvržení v šablonách prezentací.

Odstavec je položka v [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/getparagraphs/), a může zabírat několik vykreslených řádků. Výslovný zalomení řádku v odstavci vynutí nový řádek bez vytvoření dalšího odstavce. Automatické zalamování vytváří řádky na základě dostupné šířky, aniž by do textu vkládalo výslovné znaky zalomení. Počítání odstavců nebo znaků zalomení proto nedává počet vykreslených řádků.

Následující příklad vytváří textový tvar, počítá jeho řádky, zužuje tvar a pak nahrazuje text kratším řetězcem. Příklad zapíná zalamování pomocí [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) a vypíná automatické přizpůsobení pomocí [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setautofittype/), aby šířka tvaru řídila zalamování bez automatického zmenšování textu nebo změny velikosti tvaru. Každé měření používá [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount). Rozměry tvaru jsou v bodech. Nakonec příklad přidá další odstavec a sečte počty řádků napříč textovým rámcem.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    console.log("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    console.log("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    console.log("Shorter text: " + paragraph.getLinesCount());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    let totalLineCount = 0;
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const currentParagraph = textFrame.getParagraphs().get_Item(i);
        totalLineCount += currentParagraph.getLinesCount();
    }
    console.log("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

S tímto textem a těmito rozměry zužování tvaru zvyšuje počet řádků, zatímco nahrazení textu krátkým řetězcem jej snižuje. Přesné počty se mohou lišit podle dostupnosti písma a jeho nahrazení, velikosti písma, okrajů, odsazení, zalamování a nastavení automatického přizpůsobení. Používejte písma a nastavení rozvržení určená pro cílové prostředí při kontrole šablony.

Samotný počet řádků neurčuje, zda text překračuje svůj kontejner. Dostupná výška, výšky řádků, mezery mezi odstavci a řádky a chování automatického přizpůsobení také hrají roli; i jediný řádek může přesáhnout dostupnou šířku, když je zalamování vypnuto.

## **Import a export obsahu odstavců**

Použijte HTML pro vložení textu do prezentace nebo exportujte existující odstavce pro použití mimo ni. Tato sekce také ukazuje, jak vykreslit jednotlivé odstavce jako obrázky, včetně odstavců v buňkách tabulek.

### **Importovat HTML text do odstavců**

Použijte [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) k převodu HTML značek na odstavce a části v textovém rámci.

Tento JavaScriptový příklad čte HTML ze souboru `file.html` v pracovním adresáři aplikace a předává značky metodě [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/). Vymaže výchozí odstavec textového rámce, aby rámec obsahoval jen importovaný obsah. Obdélníkový tvar ponechává na každé straně snímku okraj 10 bodů:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = fs.readFileSync("file.html", "utf8");
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Exportovat text odstavce do HTML**

Použijte [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) k exportu vybraného rozsahu odstavců jako HTML. Při opětovném použití textu prezentace na webové stránce můžete chtít zachovat místní důraz bez přenosu fontu, velikosti nebo stylu textového pole prezentace. Nastavte [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/settextinheritancelimit/) pro kontrolu, jak daleko exportér následuje dědičnost formátování.

Stáhněte [vzorkovou prezentaci](text-inheritance.pptx) a umístěte ji do pracovního adresáře aplikace. Její první snímek obsahuje jeden textový tvar s textem „Inherited text; explicit red 18pt“. Vstup úmyslně používá několik úrovní formátování:

- Výchozí styl textu prezentace poskytuje písmo Calibri a velikost 28 pt.
- Styl textu první úrovně textového rámce poskytuje modrý text a kurzívu.
- Odstavec explicitně nastavuje tučný text.
- Druhá část, „explicit red 18pt“, explicitně nastavuje červený text a velikost 18 pt.

Následující úplný příklad exportuje stejné odstavce třikrát. Předává [TextToHtmlConversionOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/) metodě exportu a zapisuje každý výsledek jako samostatný UTF‑8 HTML soubor:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("text-inheritance.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();

            const modes = [aspose.slides.TextInheritanceLimit.All, aspose.slides.TextInheritanceLimit.TextBox, aspose.slides.TextInheritanceLimit.ParagraphOnly];
            const fileNames = ["All.html", "TextBox.html", "ParagraphOnly.html"];

            for (let i = 0; i < modes.length; i++) {
                const options = new aspose.slides.TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                const html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                fs.writeFileSync(fileNames[i], html, "utf8");
            }
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

Generované HTML obsahuje následující CSS pro první část, „Inherited text; “. Tabulka uvádí relevantní deklarace; ostatní vygenerované vlastnosti jsou pro přehlednost vynechány.

| Výstup | Relevantní CSS pro první část | Vzhled |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Modrý, tučný, kurzíva text o velikosti 28 pt v písmu Calibri, pokud je toto písmo k dispozici. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Modrý, tučný, kurzíva text; okolní stránka nebo prohlížeč poskytuje rodinu písma a velikost. |
| `ParagraphOnly.html` | `font-weight:bold` | Tučný text; okolní stránka nebo prohlížeč poskytuje rodinu písma, velikost, barvu a kurzívu. |

Druhá část zachovává `color:#ff0000`, `font-size:18pt` a `font-weight:bold` ve všech třech výstupech. Také zachovává kurzívu ve výstupech `All` a `TextBox`, ale ne v `ParagraphOnly`. Omezení dědičnosti tedy neodstraňuje formátování explicitně přiřazené odstavci nebo části.

Otevřete soubory ve stejném prohlížeči pro jejich porovnání. V dvou omezených režimech jsou vynechané CSS vlastnosti řešeny styly cílové stránky nebo výchozími hodnotami prohlížeče, takže výsledný vzhled závisí na tom, kde je HTML použito.

### **Vykreslit odstavec jako obrázek**

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) vykresluje jednotlivý odstavec přímo a vrací [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/). Výsledek uložte do souboru nebo proudu pomocí [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Nemusíte vykreslovat celý tvar nebo ručně ořezávat bitmapu.

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) může vrátit `null`, pokud odstavec nelze najít v nadřazené kolekci, nemá platné vykreslovací ohraničení nebo jej nelze vykreslit. Zkontrolujte výsledek před uložením a po použití uvolněte vrácený obrázek.

#### **Vykreslit odstavec ve výchozím měřítku**

Příklad vytváří prezentaci s jedním snímkem, jehož první tvar je textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

Následující příklad vybírá druhý odstavec s indexem 1 a volá [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) bez parametrů měřítka. Kontroluje, že tvar obsahuje požadovaný odstavec a že vykreslení vrátí obrázek, před voláním [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) jej uloží ve formátu PNG. Blok `finally` po použití uvolní obrázek.

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

#### **Vykreslit odstavec v buňce tabulky se škálováním**

Použijte přetížení [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage), které přijímá parametry `scaleX` a `scaleY` pro nastavení horizontálního a vertikálního měřítka. Následující příklad vytváří tabulku, vykresluje odstavec v její první buňce dvakrát ve výchozí šířce i výšce a výsledek uloží jako PNG obrázek.

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

Měřítkový faktor `1` zachovává danou osu v její výchozí velikosti pixelů. Například `2` pro oba faktory vytvoří obrázek, jehož šířka i výška jsou přibližně dvojnásobek výchozích rozměrů, což dává čtyřnásobek pixelů. Větší faktory obecně poskytují ostřejší text pro přiblížení nebo výstup ve vysokém rozlišení, ale také zvyšují spotřebu paměti a velikost souboru. Faktory pod `1` vytvářejí menší obrázky s menší detailností. Použijte stejné faktory pro zachování poměru stran odstavce; různé horizontální a vertikální faktory roztačí výstup nezávisle.

Vykreslení celého tvaru pomocí [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) zůstává užitečné, když výstup musí zahrnovat výplň, okraj nebo jiný vizuální kontext tvaru. Pro obrázek pouze odstavce použijte [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage).

## **Často kladené otázky**

**Mohu zcela zakázat zalamování řádků uvnitř textového rámce?**

Ano. Nastavte [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) pro vypnutí zalamování, aby řádky neřezaly na okrajích textového rámce.

**Jak mohu získat přesné souřadnice konkrétního odstavce na snímku?**

Použijte [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/) k získání ohraničujícího obdélníku odstavce. [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getrect/) poskytuje ohraničení jednotlivé části.

**Kde se řídí zarovnání odstavce (vlevo, vpravo, na střed nebo do bloku)?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) je nastavení na úrovni odstavce a platí pro celý odstavec bez ohledu na formátování jednotlivých částí.

Pro vertikální zarovnání částí s různými velikostmi písma v každém řádku viz [Align Fonts Within a Line](/slides/cs/nodejs-java/text-formatting/#align-fonts-within-a-line).

**Mohu nastavit jazyk korektury pro část odstavce?**

Ano. Nastavte [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) pro jednotlivé části, takže jeden odstavec může obsahovat text v několika jazycích.