---
title: Správa textových polí v prezentacích pomocí JavaScriptu
linktitle: Správa textového pole
type: docs
weight: 20
url: /cs/nodejs-java/manage-textbox/
keywords:
- textové pole
- textový rámec
- přidat text
- aktualizovat text
- vytvořit textové pole
- zkontrolovat textové pole
- přidat sloupec textu
- přidat hyperodkaz
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides pro Node.js usnadňuje vytváření, úpravu a klonování textových polí v souborech PowerPoint a OpenDocument, což zvyšuje automatizaci vašich prezentací."
---
## **Úvod**

Texty na snímcích jsou obvykle obsaženy v textových polích nebo tvarech. Proto pro přidání textu na snímek musíte přidat textové pole a poté vložit text do tohoto pole. Aspose.Slides pro Node.js prostřednictvím Javy poskytuje třídu [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape) která umožňuje přidat tvar obsahující text.

{{% alert title="Info" color="info" %}}

Aspose.Slides také poskytuje třídu [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape) která umožňuje přidávat tvary na snímky. Nicméně ne všechny tvary přidané pomocí třídy `Shape` mohou obsahovat text. Tvary přidané pomocí třídy [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape) však mohou text obsahovat.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Proto, když pracujete s tvarem, ke kterému chcete přidat text, můžete chtít zkontrolovat a potvrdit, že byl převeden pomocí třídy `AutoShape`. Teprve pak budete moci pracovat s [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrame), což je vlastnost pod `AutoShape`. Viz sekce [Update Text](https://docs.aspose.com/slides/cs/nodejs-java/manage-textbox/#update-text) na této stránce.

{{% /alert %}}

## **Vytvoření textového pole na snímku**

Pro vytvoření textového pole na snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte odkaz na první snímek v nově vytvořené prezentaci. 
3. Přidejte objekt [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape) s [ShapeType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) nastaveným na `Rectangle` na určené pozici na snímku a získejte odkaz na nově přidaný objekt `AutoShape`.
4. Přidejte k objektu `AutoShape` vlastnost `TextFrame`, která bude obsahovat text. V níže uvedeném příkladu jsme přidali tento text: *Aspose TextBox*
5. Nakonec zapište soubor PPTX pomocí objektu `Presentation`. 

Tento JavaScriptový kód — implementace výše uvedených kroků — ukazuje, jak přidat text na snímek:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Vytvoří instanci Presentation
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek v prezentaci
    var sld = pres.getSlides().get_Item(0);
    // Přidá AutoShape s typem nastaveným na Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Přidá TextFrame k obdélníku
    ashp.addTextFrame(" ");
    // Přistoupí k textovému rámci
    var txtFrame = ashp.getTextFrame();
    // Vytvoří objekt Paragraph pro textový rámec
    var para = txtFrame.getParagraphs().get_Item(0);
    // Vytvoří objekt Portion pro odstavec
    var portion = para.getPortions().get_Item(0);
    // Nastaví text
    portion.setText("Aspose TextBox");
    // Uloží prezentaci na disk
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kontrola tvaru textového pole**

Aspose.Slides poskytuje metodu [isTextBox](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/#isTextBox) ze třídy [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) která vám umožní prozkoumat tvary a identifikovat textová pole.

![Text box and shape](istextbox.png)

Tento JavaScriptový kód ukazuje, jak zkontrolovat, zda byl tvar vytvořen jako textové pole:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Všimněte si, že pokud jednoduše přidáte autoshape pomocí metody `addAutoShape` ze třídy [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/), metoda `isTextBox` tohoto autoshape vrátí `false`. Po přidání textu do autoshape pomocí metody `addTextFrame` nebo `setText` však vlastnost `isTextBox` vrátí `true`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() vrací false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() vrací true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() vrací false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() vrací true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() vrací false
shape3.addTextFrame("");
// shape3.isTextBox() vrací false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() vrací false
shape4.getTextFrame().setText("");
// shape4.isTextBox() vrací false
```

## **Nalezení tvaru, který vlastní TextFrame**

V obecném kódu pro zpracování textu můžete získat [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) aniž byste věděli, který objekt prezentace jej obsahuje. Použijte metodu [TextFrame.getParentShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getParentShape--) , abyste se vrátili k vlastnímu [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/).

Pro textový rámec, který patří k [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) nebo jinému tvaru obsahujícímu text, [TextFrame.getParentShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getParentShape--) vrací vlastníka a [TextFrame.getParentCell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getParentCell--) vrací `null`. Obě metody poskytují pouze čtecí navigaci, takže jejich volání nemění vlastnictví. Vždy před přístupem k tvaru zkontrolujte, zda vrácená hodnota není `null`.

Pro kompletní příklad, který identifikuje vlastníky tvarů a buněk tabulky, včetně tvarů spojených s uzly SmartArt, viz [Search and Replace Text](/slides/cs/nodejs-java/search-and-replace-text/).

## **Přidání sloupce do textového pole**

Aspose.Slides poskytuje metody [setColumnCount](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) a [setColumnSpacing](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat) , které umožňují přidávat sloupce do textových polí. Můžete určit počet sloupců v textovém poli a nastavit mezeru mezi sloupci v bodech.

Tento kód v JavaScriptu demonstruje popsanou operaci: 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek v prezentaci
    var slide = pres.getSlides().get_Item(0);
    // Přidá AutoShape s typem nastaveným na Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Přidá TextFrame k obdélníku
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // Získá formát textu TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Určuje počet sloupců v TextFrame
    format.setColumnCount(3);
    // Určuje mezery mezi sloupci
    format.setColumnSpacing(10);
    // Uloží prezentaci
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přidání sloupce do TextFrame**

Aspose.Slides pro Node.js prostřednictvím Javy poskytuje metodu [setColumnCount](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat) , která umožňuje přidávat sloupce v textových rámcích. Pomocí této vlastnosti můžete určit požadovaný počet sloupců v textovém rámci.

Tento JavaScriptový kód ukazuje, jak přidat sloupec do textového rámce:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // Mezera mezi sloupci nebyla nikdy nastavena, takže je hlášena jako NaN.
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aktualizace textu**

Aspose.Slides vám umožňuje změnit nebo aktualizovat text obsažený v textovém poli nebo veškerý text v prezentaci. 

Tento JavaScriptový kód demonstruje operaci, při které je aktualizován nebo změněn veškerý text v prezentaci:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Kontroluje, zda tvar podporuje textový rámec (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Prochází odstavce v textovém rámci
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Prochází každou část v odstavci
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Mění text
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Mění formátování
                    }
                }
            }
        }
    }
    // Uloží upravenou prezentaci
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přidání textového pole s hyperodkazem** 

Můžete vložit odkaz do textového pole. Když je textové pole kliknuto, uživatelé jsou přesměrováni na otevření odkazu. 

Pro přidání textového pole obsahujícího odkaz postupujte podle následujících kroků:

1. Vytvořte instanci třídy `Presentation`. 
2. Získejte odkaz na první snímek v nově vytvořené prezentaci. 
3. Přidejte objekt `AutoShape` s `ShapeType` nastaveným na `Rectangle` na určené pozici na snímku a získejte odkaz na nově přidaný objekt AutoShape.
4. Přidejte `TextFrame` k objektu `AutoShape` a nastavte text jeho první části. V níže uvedeném příkladu jsme použili tento text: *Aspose.Slides*
5. Získejte `HyperlinkManager` této části prostřednictvím jejího `PortionFormat`.
6. Zavolejte `setExternalHyperlinkClick` na `HyperlinkManager`, abyste připojili odkaz k části.
7. Nakonec zapište soubor PPTX pomocí objektu `Presentation`. 

Tento JavaScriptový kód — implementace výše uvedených kroků — ukazuje, jak přidat textové pole s hyperodkazem na snímek:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Vytvoří instanci třídy Presentation, která představuje PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek v prezentaci
    var slide = pres.getSlides().get_Item(0);
    // Přidá objekt AutoShape s typem nastaveným na Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Přetypuje tvar na AutoShape
    var pptxAutoShape = shape;
    // Přistoupí k vlastnosti ITextFrame spojené s AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Přidá nějaký text do rámce
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Nastaví hyperodkaz pro text části
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Uloží PPTX prezentaci
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Jaký je rozdíl mezi textovým polem a textovým zástupcem při práci s hlavními snímky?**

Zástupce ([placeholder](/slides/cs/nodejs-java/manage-placeholder/)) dědí styl/pozici z [masteru](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/) a lze jej přepsat v [rozvrzích](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/), zatímco běžné textové pole je nezávislý objekt na konkrétním snímku a při změně rozvržení se nemění.

**Jak mohu provést hromadnou náhradu textu v celé prezentaci, aniž bych měnil text uvnitř grafů, tabulek a SmartArt?**

Omezte iteraci na auto-tvary, které mají textové rámce, a vyloučte vložené objekty ([grafy](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/), [tabulky](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartart/)) tím, že budete procházet jejich kolekce samostatně nebo tyto typy objektů přeskočíte.