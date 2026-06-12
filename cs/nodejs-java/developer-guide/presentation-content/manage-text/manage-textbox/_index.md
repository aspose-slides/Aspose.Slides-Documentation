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
description: "Aspose.Slides pro Node.js usnadňuje vytváření, úpravu a klonování textových polí v souborech PowerPoint a OpenDocument, čímž zlepšuje automatizaci vašich prezentací."
---
## **Úvod**

Texty na snímcích jsou obvykle umístěny v textových polích nebo tvarech. Proto musíte pro přidání textu na snímek nejprve přidat textové pole a poté vložit text do tohoto pole. Aspose.Slides pro Node.js přes Java poskytuje třídu [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape), která umožňuje přidat tvar obsahující text.

{{% alert title="Info" color="info" %}}
Aspose.Slides také poskytuje třídu [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape), která umožňuje přidávat tvary na snímky. Nicméně ne všechny tvary přidané pomocí třídy `Shape` mohou obsahovat text. Tvary přidané pomocí třídy [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape) však mohou text obsahovat.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Proto při práci s tvarem, ke kterému chcete přidat text, může být vhodné zkontrolovat a potvrdit, že byl přetypován na třídu `AutoShape`. Teprve poté budete moci pracovat s [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrame), což je vlastnost třídy `AutoShape`. Viz část [Update Text](https://docs.aspose.com/slides/cs/nodejs-java/manage-textbox/#update-text) na této stránce.
{{% /alert %}}

## **Vytvoření textového pole na snímku**

Pro vytvoření textového pole na snímku postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte odkaz na první snímek v nově vytvořené prezentaci. 
3. Přidejte objekt [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape) s [ShapeType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) nastaveným na `Rectangle` na zadané pozici na snímku a získejte odkaz na nově přidaný objekt `AutoShape`.
4. Přidejte vlastnost `TextFrame` k objektu `AutoShape`, která bude obsahovat text. V níže uvedeném příkladu jsme přidali tento text: *Aspose TextBox*
5. Nakonec zapište soubor PPTX pomocí objektu `Presentation`. 

Tento JavaScriptový kód – implementace výše uvedených kroků – ukazuje, jak přidat text na snímek:

```javascript
// Vytvoří instanci Presentation
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek v prezentaci
    var sld = pres.getSlides().get_Item(0);
    // Přidá AutoShape s typem nastaveným na Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Přidá TextFrame do obdélníku
    ashp.addTextFrame(" ");
    // Přistupuje k textovému rámci
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

## **Kontrola, zda je tvar textovým polem**

Aspose.Slides poskytuje metodu [isTextBox](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/#isTextBox) ze třídy [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/), která vám umožní prozkoumat tvary a identifikovat textová pole.

![Text box and shape](istextbox.png)

Tento JavaScriptový kód ukazuje, jak zkontrolovat, zda byl tvar vytvořen jako textové pole:

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Všimněte si, že pokud jednoduše přidáte autoshape pomocí metody `addAutoShape` ze třídy [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/), metoda `isTextBox` této autoshape vrátí `false`. Nicméně po přidání textu do autoshape pomocí metody `addTextFrame` nebo `setText` vrátí vlastnost `isTextBox` hodnotu `true`.

```javascript
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

## **Přidání sloupce do textového pole**

Aspose.Slides poskytuje metody [setColumnCount](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) a [setColumnSpacing](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat), které vám umožní přidávat sloupce do textových polí. Můžete určit počet sloupců v textovém poli a nastavit mezeru v bodech mezi sloupci.

Tento kód v JavaScriptu ukazuje popsanou operaci: 

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek v prezentaci
    var slide = pres.getSlides().get_Item(0);
    // Přidá AutoShape s typem nastaveným na Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Přidá TextFrame do obdélníku
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

## **Přidání sloupce do textového rámce**

Aspose.Slides pro Node.js přes Java poskytuje metodu [setColumnCount](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrameFormat), která umožňuje přidávat sloupce do textových rámců. Prostřednictvím této vlastnosti můžete zadat požadovaný počet sloupců v textovém rámci.

Tento JavaScriptový kód ukazuje, jak přidat sloupec do textového rámce:

```javascript
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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

Tento JavaScriptový kód ukazuje operaci, při které je aktualizován nebo změněn veškerý text v prezentaci:

```javascript
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

Pro přidání textového pole obsahujícího odkaz postupujte podle těchto kroků:

1. Vytvořte instanci třídy `Presentation`. 
2. Získejte odkaz na první snímek v nově vytvořené prezentaci. 
3. Přidejte objekt `AutoShape` s `ShapeType` nastaveným na `Rectangle` na zadané pozici na snímku a získejte odkaz na nově přidaný objekt AutoShape.
4. Přidejte `TextFrame` k objektu `AutoShape`, který bude obsahovat *Aspose TextBox* jako výchozí text. 
5. Vytvořte instanci třídy `HyperlinkManager`. 
6. Přiřaďte objekt `HyperlinkManager` k vlastnosti [HyperlinkClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) spojené s požadovanou částí `TextFrame`.
7. Nakonec zapište soubor PPTX pomocí objektu `Presentation`. 

Tento JavaScriptový kód – implementace výše uvedených kroků – ukazuje, jak přidat textové pole s hyperodkazem na snímek:

```javascript
// Vytvoří instanci třídy Presentation, která představuje PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek v prezentaci
    var slide = pres.getSlides().get_Item(0);
    // Přidá objekt AutoShape s typem nastaveným na Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Přetypuje tvar na AutoShape
    var pptxAutoShape = shape;
    // Přistupuje k vlastnosti ITextFrame spojené s AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Přidá text do rámce
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

Zástupce [placeholder](/slides/cs/nodejs-java/manage-placeholder/) dědí styl/pozici z [masteru](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/) a může být přepsán na [rozvrzích](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/), zatímco běžné textové pole je nezávislý objekt na konkrétním snímku a nemění se při změně rozvržení.

**Jak mohu provést hromadnou náhradu textu v celé prezentaci, aniž bych zasahoval do textu v grafech, tabulkách a SmartArt?**

Omezte iteraci pouze na auto-tvary, které mají textové rámce, a vyloučte vložené objekty ([grafy](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/), [tabulky](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartart/)) tím, že projdete jejich kolekce odděleně nebo přeskočíte tyto typy objektů.