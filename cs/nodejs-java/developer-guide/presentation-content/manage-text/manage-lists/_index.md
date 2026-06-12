---
title: Správa odrážkových a číslovaných seznamů v prezentacích pomocí JavaScriptu
linktitle: Správa seznamů
type: docs
weight: 60
url: /cs/nodejs-java/manage-lists/
keywords:
- odrážka
- odrážkový seznam
- číslovaný seznam
- symbolická odrážka
- obrázková odrážka
- vlastní odrážka
- vícestupňový seznam
- vytvořit odrážku
- přidat odrážku
- přidat seznam
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se vytvářet a formátovat odrážkové, obrázkové, vícestupňové a číslované seznamy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js via Java."
---
## **Přehled**

Aspose.Slides for Node.js via Java vám umožňuje vytvářet a formátovat odrážkové a číslované seznamy v prezentacích PowerPoint a OpenDocument. Položka seznamu je odstavec, jehož nastavení odrážky je řízeno formátem odstavce.

Použijte třídu [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/) pro přístup k nastavením seznamu na úrovni odstavce. Hlavní vstupní bod je `Paragraph.getParagraphFormat().getBullet()`, který vrací objekt [BulletFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bulletformat/). S tímto objektem můžete nastavit typ odrážky, symbol, obrázek, barvu, velikost, styl číslování a počáteční číslo.

Tento článek ukazuje, jak:

- vytvořit odrážkový seznam s vlastním symbolem
- vytvořit obrázkovou odrážku
- vytvořit vícestupňový seznam nastavením hloubky odstavce
- vytvořit číslovaný seznam
- prozkoumat a změnit formátování seznamu v existující prezentaci

## **Vytvoření odrážkového seznamu**

Chcete-li vytvořit odrážkový seznam, přidejte objekty [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/) do [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) a nastavte `BulletFormat.setType` na [BulletType.Symbol](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bullettype/). Poté můžete nastavit `BulletFormat.setChar`, `BulletFormat.getColor` a `BulletFormat.setHeight` pro řízení vzhledu odrážky.

Následující JavaScript kód demonstruje, jak vytvořit odrážkový seznam na snímku:

```javascript
function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Symbolické odrážky](symbol_bullets.png)

## **Vytvoření číslovaného seznamu**

Používejte číslované seznamy, když je pořadí položek důležité. Nastavte `BulletFormat.setType` na [BulletType.Numbered](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bullettype/). Můžete také zvolit formát číslování pomocí `BulletFormat.setNumberedBulletStyle` nebo nastavit `BulletFormat.setNumberedBulletStartWith`, pokud má seznam začít od hodnoty jiného než 1.

Následující JavaScript kód ukazuje, jak vytvořit číslovaný seznam na snímku:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Číslované odrážky](numbered_bullets.png)

## **Vytvoření obrázkové odrážky**

Aspose.Slides vám umožňuje nahradit běžný symbol odrážky obrázkem. Obrázkové odrážky fungují nejlépe s jednoduchými obrázky, které zůstávají čitelné v malé velikosti, například ikony nebo malé průhledné PNG soubory.

{{% alert color="primary" %}}
Ideálně, pokud plánujete nahradit běžný symbol odrážky obrázkem, je nejlepší zvolit jednoduchou grafiku s průhledným pozadím. Takové obrázky dobře fungují jako vlastní symboly odrážek.
{{% /alert %}}

Pro vytvoření obrázkové odrážky přidejte obrázek do [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) pomocí `Presentation.getImages().addImage` a přiřaďte vrácený objekt [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) do `BulletFormat.getPicture().setImage`. Před přiřazením obrázku nastavte `BulletFormat.setType` na [BulletType.Picture](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bullettype/).

Předpokládejme, že máme soubor "image.png":

![Obrázek pro odrážky](picture_for_bullets.png)

Následující JavaScript kód ukazuje, jak vytvořit obrázkové odrážky na snímku:

```javascript
function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

Výsledek:

![Obrázkové odrážky](picture_bullets.png)

## **Vytvoření vícestupňového seznamu**

Použijte `ParagraphFormat.setDepth` k umístění položek seznamu na různé úrovně. Úroveň 0 je nejvyšší úroveň, úroveň 1 je pod ní vnořená a tak dál.

Následující JavaScript kód ukazuje, jak vytvořit vícestupňový odrážkový seznam:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Vícestupňový seznam](multilevel_list.png)

## **Změna existujícího seznamu**

Chcete-li změnit formátování seznamu v existující prezentaci, přistupujte k cílovému odstavci a aktualizujte jeho nastavení `ParagraphFormat.getBullet`. Stejné vlastnosti použité k vytvoření seznamů lze použít k prozkoumání nebo úpravě seznamů načtených ze souboru PPT, PPTX nebo ODP.

```javascript
const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Lze odrážkové a číslované seznamy exportovat do PDF nebo obrázků?**

Ano. Aspose.Slides zachovává formátování seznamu, pokud cílový formát podporuje odpovídající rozvržení textu a funkce odrážek.

**Mohu upravovat seznamy v existujících prezentacích?**

Ano. Načtěte prezentaci, přistupte k cílovému odstavci, prohlédněte nebo aktualizujte jeho nastavení `ParagraphFormat.getBullet` a uložte prezentaci.

**Mohou seznamy obsahovat text mimo latinku?**

Ano. Text položek seznamu může obsahovat Unicode znaky, takže můžete vytvářet seznamy v vícejazyčných prezentacích. Ujistěte se, že písma použité v prezentaci podporují požadované znaky.