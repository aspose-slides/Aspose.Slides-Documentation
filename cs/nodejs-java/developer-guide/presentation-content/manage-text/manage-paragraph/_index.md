---
title: Správa textových odstavců PowerPointu v JavaScriptu
linktitle: Spravovat odstavec
type: docs
weight: 40
url: /cs/nodejs-java/manage-paragraph/
keywords:
- přidat text
- přidat odstavec
- spravovat text
- spravovat odstavec
- spravovat odrážku
- odsazení odstavce
- závěsné odsazení
- odrážka odstavce
- číslovaný seznam
- seznam s odrážkami
- vlastnosti odstavce
- importovat HTML
- text do HTML
- odstavec do HTML
- odstavec na obrázek
- text na obrázek
- exportovat odstavec
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Ovládněte formátování odstavců pomocí Aspose.Slides pro Node.js v Javě - optimalizujte zarovnání, rozestupy a styl v prezentacích PPT, PPTX a ODP v JavaScriptu."
---
## **Úvod**

Aspose.Slides poskytuje všechny třídy, které potřebujete pro práci s texty, odstavci a částmi v PowerPointu v jazyce Java.

* Aspose.Slides poskytuje třídu [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) umožňující přidávat objekty představující odstavec. Objekt `TextFame` může mít jeden nebo více odstavců (každý odstavec se vytvoří pomocí návratu řádku).
* Aspose.Slides poskytuje třídu [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/) umožňující přidávat objekty představující části. Objekt `Paragraph` může mít jednu nebo více částí (kolekci objektů textových částí).
* Aspose.Slides poskytuje třídu [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/) umožňující přidávat objekty představující texty a jejich formátovací vlastnosti.

Objekt `Paragraph` je schopen zpracovávat texty s různými formátovacími vlastnostmi prostřednictvím svých podřízených objektů `Portion`.

## **Přidání více odstavců obsahujících více částí**

Tyto kroky ukazují, jak přidat textové pole obsahující 3 odstavce a každý odstavec obsahující 3 části:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
4. Získejte ITextFrame spojený s [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/).
5. Vytvořte dva objekty [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/) a přidejte je do kolekce `IParagraphs` třídy [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/).
6. Vytvořte tři objekty [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/) pro každý nový `Paragraph` (dvě objekty Portion pro výchozí odstavec) a přidejte každý objekt `Portion` do kolekce IPortion příslušného `Paragraph`.
7. Nastavte nějaký text pro každou část.
8. Použijte požadované formátovací prvky na každou část pomocí formátovacích vlastností poskytovaných objektem `Portion`.
9. Uložte upravenou prezentaci.

```javascript
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přístup k prvnímu snímku
    var slide = pres.getSlides().get_Item(0);
    // Přidejte AutoShape typu Obdélník
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Získejte TextFrame AutoShape
    var tf = ashp.getTextFrame();
    // Vytvořte odstavce a části s různými formáty textu
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // Uložte PPTX na disk
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Správa odrážek odstavců**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Odstavce s odrážkami jsou vždy snadnější ke čtení a pochopení.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na vybraný snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/).
7. Nastavte typ odrážky `Type` odstavce na `Symbol` a nastavte znak odrážky.
8. Nastavte `Text` odstavce.
9. Nastavte `Indent` odstavce pro odrážku.
10. Nastavte barvu odrážky.
11. Nastavte výšku odrážky.
12. Přidejte nový odstavec do kolekce odstavců `TextFrame`.
13. Přidejte druhý odstavec a opakujte proces uvedený v krocích 7 až 13.
14. Uložte prezentaci.

```javascript
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přistupuje k prvnímu snímku
    var slide = pres.getSlides().get_Item(0);
    // Přidá a získá Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Získá textový rámec autoshape
    var txtFrm = aShp.getTextFrame();
    // Odstraní výchozí odstavec
    txtFrm.getParagraphs().removeAt(0);
    // Vytvoří odstavec
    var para = new aspose.slides.Paragraph();
    // Nastaví styl odrážky odstavce a symbol
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Nastaví text odstavce
    para.setText("Welcome to Aspose.Slides");
    // Nastaví odsazení odrážky
    para.getParagraphFormat().setIndent(25);
    // Nastaví barvu odrážky
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// nastavit IsBulletHardColor na true k použití vlastní barvy odrážky
    // Nastaví výšku odrážky
    para.getParagraphFormat().getBullet().setHeight(100);
    // Přidá odstavec do textového rámce
    txtFrm.getParagraphs().add(para);
    // Vytvoří druhý odstavec
    var para2 = new aspose.slides.Paragraph();
    // Nastaví typ odrážky odstavce a styl
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Přidá text odstavce
    para2.setText("This is numbered bullet");
    // Nastaví odsazení odrážky
    para2.getParagraphFormat().setIndent(25);
    // Nastaví barvu odrážky
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// nastavit IsBulletHardColor na true k použití vlastní barvy odrážky
    // Nastaví výšku odrážky
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Přidá odstavec do textového rámce
    txtFrm.getParagraphs().add(para2);
    // Uloží upravenou prezentaci
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Správa obrázkových odrážek**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Odstavce s obrázkovými odrážkami jsou snadno čitelné a pochopitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/).
7. Načtěte obrázek pomocí [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/).
8. Nastavte typ odrážky na [Picture](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) a nastavte obrázek.
9. Nastavte `Text` odstavce.
10. Nastavte `Indent` odstavce pro odrážku.
11. Nastavte barvu odrážky.
12. Nastavte výšku odrážky.
13. Přidejte nový odstavec do kolekce odstavců `TextFrame`.
14. Přidejte druhý odstavec a opakujte proces podle předchozích kroků.
15. Uložte upravenou prezentaci.

```javascript
// Instancuje třídu Presentation, která představuje soubor PPTX
var presentation = new aspose.slides.Presentation();
try {
    // Získá první snímek
    var slide = presentation.getSlides().get_Item(0);
    // Instancuje obrázek pro odrážky
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Přidá a získá Autoshape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Získá textový rámec autoshape
    var textFrame = autoShape.getTextFrame();
    // Odstraní výchozí odstavec
    textFrame.getParagraphs().removeAt(0);
    // Vytvoří nový odstavec
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Nastaví styl odrážky odstavce a obrázek
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Nastaví výšku odrážky
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Přidá odstavec do textového rámce
    textFrame.getParagraphs().add(paragraph);
    // Uloží prezentaci jako soubor PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Uloží prezentaci jako soubor PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Správa víceúrovňových odrážek**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Víceúrovňové odrážky jsou snadno čitelné a pochopitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) v novém snímku.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/) a nastavte hloubku na 0.
7. Vytvořte druhý odstavec pomocí třídy `Paragraph` a nastavte hloubku na 1.
8. Vytvořte třetí odstavec pomocí třídy `Paragraph` a nastavte hloubku na 2.
9. Vytvořte čtvrtý odstavec pomocí třídy `Paragraph` a nastavte hloubku na 3.
10. Přidejte nové odstavce do kolekce odstavců `TextFrame`.
11. Uložte upravenou prezentaci.

```javascript
// Instancuje třídu Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek
    var slide = pres.getSlides().get_Item(0);
    // Přidá a získá Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Získá textový rámec vytvořeného autoshape
    var text = aShp.addTextFrame("");
    // Vyčistí výchozí odstavec
    text.getParagraphs().clear();
    // Přidá první odstavec
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Nastaví úroveň odrážky
    para1.getParagraphFormat().setDepth(0);
    // Přidá druhý odstavec
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Nastaví úroveň odrážky
    para2.getParagraphFormat().setDepth(1);
    // Přidá třetí odstavec
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Nastaví úroveň odrážky
    para3.getParagraphFormat().setDepth(2);
    // Přidá čtvrtý odstavec
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Nastaví úroveň odrážky
    para4.getParagraphFormat().setDepth(3);
    // Přidá odstavce do kolekce
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // Uloží prezentaci jako soubor PPTX
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Správa odstavce s vlastním číslovaným seznamem**

Třída [BulletFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bulletformat/) poskytuje vlastnost [NumberedBulletStartWith](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) a další, které umožňují spravovat odstavce s vlastním číslováním nebo formátováním.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek obsahující odstavec.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/) a nastavte [NumberedBulletStartWith](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) na 2.
7. Vytvořte druhý odstavec pomocí třídy `Paragraph` a nastavte `NumberedBulletStartWith` na 3.
8. Vytvořte třetí odstavec pomocí třídy `Paragraph` a nastavte `NumberedBulletStartWith` na 7.
9. Přidejte nové odstavce do kolekce odstavců `TextFrame`.
10. Uložte upravenou prezentaci.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Získá textový rámec vytvořeného autoshape
    var textFrame = shape.getTextFrame();
    // Odstraní výchozí existující odstavec
    textFrame.getParagraphs().removeAt(0);
    // První seznam
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Nastavení odsazení první řádky odstavce**

Použijte metodu [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setindent/) k řízení odsazení první řádky odstavce. Tato metoda posune pouze první řádek vzhledem k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco zbylé řádky zůstanou zarovnány k tělu odstavce.

Použijte [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setmarginleft/), když potřebujete posunout celý odstavec. Použijte [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setindent/), když potřebujete posunout jen první řádek.

Níže uvedený příklad vytváří několik odstavců a aplikuje různé hodnoty odsazení, aby ukázal, jak odsazení první řádky ovlivňuje rozvržení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
4. Přidejte k tvaru prázdný [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte pro ně různé hodnoty [Indent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setindent/).
6. Přidejte odstavce do textového rámce.
7. Uložte upravenou prezentaci.

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

![Odsazení první řádky odstavců](first_line_indent.png)

## **Nastavení závěsného odsazení pro odstavec**

Závěsné odsazení je rozvržení odstavce, při kterém první řádek začíná vlevo od zbývajících řádků. V Aspose.Slides vytvoříte tento efekt pomocí metody [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setindent/). Nastavte odsazení na zápornou hodnotu, aby se první řádek posunul vlevo vzhledem k tělu odstavce.

V praxi [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) určuje levou pozici těla odstavce a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setindent/) určuje pozici prvního řádku vzhledem k tomuto okraji. Pro vytvoření závěsného odsazení nastavte kladnou hodnotu `MarginLeft` a zápornou hodnotu `Indent`.

Toto formátování je užitečné pro bibliografie, odkazy, položky glosáře a další odstavce, kde musí zalomené řádky být zarovnány pod tělo odstavce místo pod první znak první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
4. Přidejte k tvaru prázdný [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) a odstraňte výchozí odstavec.
5. Vytvořte odstavce a nastavte pro každý odstavec kladnou hodnotu [MarginLeft](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setmarginleft/).
6. Nastavte zápornou hodnotu [Indent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setindent/) pro vytvoření efektu závěsného odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

![Závěsné odsazení odstavců](hanging_indent.png)

## **Správa koncových vlastností běhu odstavce pro odstavec**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek obsahující odstavec pomocí jeho pozice.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
4. Přidejte [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) se dvěma odstavci do obdélníku.
5. Nastavte `FontHeight` a typ písma pro odstavce.
6. Nastavte koncové (End) vlastnosti pro odstavce.
7. Zapište upravenou prezentaci jako soubor PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Import HTML textu do odstavců**

Aspose.Slides poskytuje rozšířenou podporu pro importování HTML textu do odstavců.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
4. Přidejte a získejte [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Načtěte zdrojový HTML soubor v TextReaderu.
7. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/).
8. Přidejte obsah HTML souboru z načteného TextReaderu do [ParagraphCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphcollection/) TextFrame.
9. Uložte upravenou prezentaci.

```javascript
// Vytvořte prázdnou instanci prezentace
var pres = new aspose.slides.Presentation();
try {
    // Přístup k výchozímu prvnímu snímku prezentace
    var slide = pres.getSlides().get_Item(0);
    // Přidání AutoShape, aby pojmula HTML obsah
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Přidání textového rámce do tvaru
    ashape.addTextFrame("");
    // Vyprázdnění všech odstavců v přidaném textovém rámci
    ashape.getTextFrame().getParagraphs().clear();
    // Načtení HTML souboru pomocí stream readeru
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Přidání textu z HTML stream readeru do textového rámce
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Ukládání prezentace
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Export textu odstavců do HTML**

Aspose.Slides poskytuje rozšířenou podporu pro exportování textů (obsažených v odstavcích) do HTML.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a načtěte požadovanou prezentaci.
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Získejte tvar obsahující text, který bude exportován do HTML.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) tvaru.
5. Vytvořte instanci `StreamWriter` a přidejte nový HTML soubor.
6. Zadejte počáteční index do StreamWriteru a exportujte požadované odstavce.

```javascript
// Načtěte soubor prezentace
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Přístup k výchozímu prvnímu snímku prezentace
    var slide = pres.getSlides().get_Item(0);
    // Požadovaný index
    var index = 0;
    // Přístup k přidanému tvaru
    var ashape = slide.getShapes().get_Item(index);
    // Vytvoření výstupního HTML souboru
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Extrahování prvního odstavce jako HTML
    // Zápis dat odstavců do HTML zadáním počátečního indexu odstavce a celkového počtu odstavců ke zkopírování
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Uložení odstavce jako obrázku**

V tomto oddíle prozkoumáme dva příklady, které ukazují, jak uložit textový odstavec reprezentovaný třídou [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/) jako obrázek. Oba příklady zahrnují získání obrázku tvaru obsahujícího odstavec pomocí metod `getImage` ze třídy [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/), výpočet ohraničení odstavce uvnitř tvaru a export jako bitmapového obrázku. Tyto přístupy vám umožní extrahovat konkrétní části textu z prezentací PowerPoint a uložit je jako samostatné obrázky, což může být užitečné v různých scénářích.

Předpokládejme, že máme soubor prezentace nazvaný sample.pptx s jedním snímkem, kde je první tvar textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

**Příklad 1**

V tomto příkladu získáme druhý odstavec jako obrázek. K tomu nejprve extrahujeme obrázek tvaru z prvního snímku prezentace a následně vypočítáme ohraničení druhého odstavce v textovém rámci tvaru. Odstavec je pak překreslen na nový bitmapový obrázek, který je uložen ve formátu PNG. Tento postup je užitečný, když potřebujete uložit konkrétní odstavec jako samostatný obrázek při zachování přesných rozměrů a formátování textu.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Uložte tvar v paměti jako bitmapu.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Vytvořte bitmapu tvaru z paměti.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Vypočítejte ohraničení druhého odstavce.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Vypočítejte souřadnice a velikost výstupního obrázku (minimální velikost - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Ořízněte bitmapu tvaru, aby obsahovala pouze bitmapu odstavce.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

![Obrázek odstavce](paragraph_to_image_output.png)

**Příklad 2**

V tomto příkladu rozšíříme předchozí přístup přidáním škálovacích faktorů k obrázku odstavce. Tvar je extrahován z prezentace a uložen jako obrázek se škálovacím faktorem `2`. To umožňuje výstup s vyšším rozlišením při exportu odstavce. Ohraničení odstavce je poté vypočítáno s ohledem na škálu. Škálování může být užitečné, když je potřeba detailnější obrázek, například pro použití ve vysoce kvalitních tištěných materiálech.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Uložte tvar v paměti jako bitmapu se škálováním.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Vytvořte bitmapu tvaru z paměti.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Vypočítejte ohraničení druhého odstavce.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Vypočítejte souřadnice a velikost výstupního obrázku (minimální velikost - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Ořízněte bitmapu tvaru, aby obsahovala pouze bitmapu odstavce.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Často kladené otázky**

**Mohu zcela zakázat zalamování řádků uvnitř textového rámce?**

Ano. Použijte nastavení zalamování textového rámce ([setWrapText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/setwraptext/)), abyste vypnuli zalamování, takže řádky se nebudou lámat na okrajích rámce.

**Jak mohu získat přesné souřadnice konkrétního odstavce na snímku?**

Můžete získat ohraničující obdélník odstavce (a dokonce i jedné části), abyste znali jeho přesnou polohu a velikost na snímku.

**Kde se řídí zarovnání odstavce (levé/pravé/na střed/zarovnané)?**

[setAlignment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/setalignment/) je metoda pro nastavení na úrovni odstavce v [ParagraphFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/); vztahuje se na celý odstavec bez ohledu na formátování jednotlivých částí.

**Mohu nastavit jazyk pravopisu jen pro část odstavce (např. pro jedno slovo)?**

Ano. Jazyk se nastavuje na úrovni části ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), takže v jednom odstavci mohou koexistovat různé jazyky.