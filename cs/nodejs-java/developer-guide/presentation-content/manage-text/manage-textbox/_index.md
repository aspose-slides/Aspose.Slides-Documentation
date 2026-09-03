---
title: Správa textových polí v prezentacích pomocí JavaScriptu
linktitle: Spravovat textové pole
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
- přidat textový sloupec
- přidat hypertextový odkaz
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: Vytvářejte, identifikujte, formátujte a aktualizujte textová pole v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js přes Java.
---
## **Úvod**

V Aspose.Slides pro Node.js přes Java je text snímku uložen v textových rámcích, které patří k tvarům. Třída [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) představuje nejběžnější tvar nesoucí text a zpřístupňuje svůj text prostřednictvím metody [AutoShape.getTextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
Každý automatický tvar je odvozen od [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/), ale ne každý tvar je automatický tvar nebo podporuje textový rámec. Při zpracování existující prezentace zkontrolujte, že tvar je instancí [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) před tím, než k jeho textu přistoupíte.
{{% /alert %}}

## **Vytvoření textového pole na snímku**

Pro vytvoření textového pole přidejte automatický tvar na snímek, přidejte text do jeho textového rámce a uložte prezentaci. Následující příklad vytváří obdélníkové textové pole:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Souřadnice a rozměry předávané metodě [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/#addAutoShape) jsou měřeny v bodech. [AutoShape.addTextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/#addTextFrame) inicializuje textový rámec dodaným textem.

## **Kontrola, zda je tvar textovým polem**

Použijte metodu [AutoShape.isTextBox](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/#isTextBox) k určení, zda je automatický tvar považován za textové pole. To je užitečné, když prezentace obsahuje jak textové, tak čistě grafické automatické tvary.

![Textové pole a tvar](istextbox.png)

Následující příklad kontroluje každý automatický tvar v prezentaci:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Nově přidaný automatický tvar není považován za textové pole, dokud neobsahuje ne‑prázdný text. Text můžete dodat pomocí [AutoShape.addTextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/#addTextFrame) nebo [TextFrame.setText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#setText). Přidání nebo přiřazení prázdného řetězce způsobí, že [AutoShape.isTextBox](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/#isTextBox) vrátí `false`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

První dvě volání vypíšou `true`; poslední dvě vypíšou `false`.

## **Nalezení tvaru, který vlastní textový rámec**

Obecný kód pro zpracování textu může získat objekt [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) aniž by věděl, který objekt prezentace jej obsahuje. Použijte jen‑čtenou metodu [TextFrame.getParentShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getParentShape) k navigaci zpět na vlastnící [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/).

Pro textový rámec vlastněný automatickým tvarem nebo jiným tvarem nesoucím text vrací [TextFrame.getParentShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getParentShape) vlastníka a [TextFrame.getParentCell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getParentCell) vrací `null`. Před přístupem zkontrolujte vrácenou hodnotu. Pro identifikaci jak vlastníků tvarů, tak buněk tabulky, včetně tvarů spojených s uzly SmartArt, viz [Search and Replace Text](/slides/cs/nodejs-java/search-and-replace-text/).

## **Přidání sloupců do textového pole**

Metoda [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setColumnCount) rozdělí textový rámec do sloupců, zatímco [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) nastaví mezery mezi sloupci v bodech. Obě nastavení patří do [TextFrameFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/) a lze je změnit přes textový rámec existujícího textového pole. Text se přetéká mezi sloupci uvnitř stejného tvaru; nepřechází do jiného tvaru.

Následující příklad vytváří trojsloupcové textové pole s 10 body mezi sloupci, uloží prezentaci a načte zpět uložená nastavení z výstupního souboru:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Extrahování textu z jednotlivých sloupců**

Použijte [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#splitTextByColumns) k získání textu přiřazeného každému vizuálnímu sloupci v existujícím textovém rámci. Metoda vrací jeden řetězec pro každý sloupec ve sloupcově orientovaném pořadí čtení. Jednosloupcový textový rámec vytvoří pole s jedním prvkem a prázdný sloupec je reprezentován prázdným řetězcem. Řetězce obsahují pouze prostý text; formátování na úrovni částí není zachováno.

Toto je užitečné, když potřebujete:

- Extrahovat text při zachování jeho sloupcově orientovaného pořadí čtení.
- Indexovat nebo porovnat obsah snímků s více sloupci.
- Exportovat každý sloupec do samostatného souboru, databázového pole nebo jiného cíle.
- Zkontrolovat, jak je text přeuspořádán po změně počtu sloupců pomocí [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setColumnCount), mezery pomocí [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing), fontu nebo velikosti textového rámce.

Metoda hlásí text rozdělený v aktuálním [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/); automaticky nepřetéká mezi samostatnými tvary nebo textovými poli. Distribuce sloupců může záviset na dostupných fontech a dalších nastaveních rozvržení textu, proto se ujistěte, že požadované fonty jsou k dispozici, když jsou důsledné výsledky důležité.

Následující příklad načte prezentaci, najde první auto‑tvar s více sloupci a textovým rámcem, přečte jeho nastavený počet sloupců a zapíše text z každého sloupce do samostatného souboru. Tvary, které neposkytují textový rámec, jsou přeskočeny.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Aktualizace textu**

Pro aktualizaci textu v celé prezentaci iterujte přes snímky a tvary, vybírejte automatické tvary a poté upravujte jejich textové části. Práce na úrovni částí vám umožní měnit jak text, tak formátování znaků.

Následující příklad nahrazuje každé výskyt `years` s `months` v textu automatických tvarů a každou ovlivněnou část zvýrazní tučně:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Toto procházení aktualizuje text jen v automatických tvarech. Text uložený v tabulkách, diagramech, SmartArt nebo seskupených tvarech vyžaduje procházení jejich vlastních kolekcí.

## **Přidání textového pole s hyperlinkem**

Hyperlink lze přiřadit konkrétní textové části, takže pouze tento text funguje jako klikací odkaz. Použijte [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) k přiřazení části k externí URL.

Následující příklad vytvoří propojený text a uloží jej do prezentace:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jaký je rozdíl mezi textovým polem a textovým zástupcem na hlavním nebo rozložení snímku?**

[Placeholder](/slides/cs/nodejs-java/manage-placeholder/) může zdědit svou pozici a formátování z [master slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/) nebo [layout slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/). Běžné textové pole je samostatný tvar na snímku, kde bylo vytvořeno, a nezískává chování zástupce při změně rozložení.

**Jak mohu nahradit text, aniž bych změnil text v diagramech, tabulkách nebo SmartArt?**

Omezte procházení na tvary, které jsou instancemi [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/), jak je ukázáno v příkladu Aktualizace textu. Diagramy, tabulky a SmartArt ukládají text ve svých vlastních modelových strukturách, takže nejsou tímto cyklem upraveny.