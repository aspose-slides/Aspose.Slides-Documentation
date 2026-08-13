---
title: Získání efektivních vlastností tvaru z prezentací v JavaScriptu
linktitle: Efektivní vlastnosti
type: docs
weight: 50
url: /cs/nodejs-java/shape-effective-properties/
keywords:
- vlastnosti tvaru
- vlastnosti kamery
- světelný rig
- zkosený tvar
- textový rámec
- textový styl
- výška písma
- formát výplně
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Zjistěte, jak používat Aspose.Slides pro Node.js prostřednictvím Javy k rozlišení místního, zděděného a efektivního formátování tvarů v prezentacích PowerPoint."
---
## **Pochopte místní, zděděné a efektivní vlastnosti**

Formátování PowerPointu může pocházet z několika míst. Hodnota uložená přímo na objektu je jeho **místní hodnota**. Pokud tato hodnota není nastavena, PowerPoint se podívá na zdroje formátování nadřazené, jako je výchozí nastavení odstavce, textový styl, rozvržení nebo hlavní snímek, motiv nebo výchozí nastavení na úrovni prezentace. Tyto hodnoty jsou **zděděné hodnoty**. Hodnota, která zůstane po vyřešení celé hierarchie, je **efektivní hodnota** — hodnota použitá k vykreslení objektu.

Například část textu nemusí definovat vlastní výšku písma. Její místní [getFontHeight](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portionformat/#getFontHeight) hodnota je pak `NaN`, což znamená „není zde nastavena“. Část může zdědit výšku ze svého odstavce, výchozího textového stylu prezentace nebo jiného použitelného zdroje. Volání [getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portionformat/#getEffective) na formátu části vrátí konečnou vyřešenou výšku.

- Přečtěte nebo změňte místní formátovací objekt, například [PortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portionformat/), pokud potřebujete řídit, kde je hodnota definována.
- Přečtěte [efektivní data vrácená metodou PortionFormat.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portionformat/#getEffective), pokud potřebujete konečný vykreslený výsledek. Efektivní data jsou pouze pro čtení.

Před spuštěním příkladů [nainstalujte Aspose.Slides pro Node.js prostřednictvím Javy](/slides/cs/nodejs-java/installation/).

## **Porovnejte místní, zděděné a efektivní hodnoty**

Následující úplný příklad vytvoří tvar a použije výšky písma na úrovních prezentace, odstavce a části. Každý krok vypíše hodnoty definované na těchto úrovních a výslednou efektivní hodnotu pro stejnou část textu. Také ukazuje, proč je nutné po změnách formátování znovu načíst efektivní data.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // Přečtěte efektivní data po předchozích změnách.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // Definujte zděděné hodnoty na dvou různých úrovních.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // Místní hodnota v části přepíše obě zděděné hodnoty.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // Změna zděděné hodnoty nepřepíše existující místní hodnotu.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // Vymažte místní hodnotu. Část nyní znovu dědí od odstavce.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // Vymažte hodnotu odstavce. Výchozí nastavení prezentace nyní poskytuje výsledek.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Priorita v tomto příkladu je místní formátování části, poté formátování odstavce a nakonec výchozí nastavení prezentace. Ostatní objekty mohou mít odlišné řetězce dědičnosti, ale princip je stejný: konkrétnější explicitní hodnota vítězí a [getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portionformat/#getEffective) vrací finální výsledek.

## **Získejte efektivní vlastnosti textu**

Formátování textu je rozděleno mezi několik objektů:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#getEffective) řeší vlastnosti textového rámce, jako jsou okraje, ukotvení, automatické přizpůsobení a vertikální směr textu.
- [TextStyle.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textstyle/#getEffective) řeší formátování odstavců pro každou úroveň textového stylu.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#getEffective) řeší vlastnosti odstavců, jako jsou zarovnání, odsazení a odrážky.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portionformat/#getEffective) řeší vlastnosti znaků, jako jsou výška písma, typ písma, barva, tučné a kurzíva.

Pro další příklad musí soubor `text-formatting.pptx` obsahovat alespoň jeden snímek a jednu [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) s neprázdným textovým rámcem. AutoShape může být umístěna na libovolném místě ve sbírce tvarů; kód hledá vhodný objekt a před použitím jej ověří.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **Získejte efektivní 3D vlastnosti**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getEffective) vrací jeden objekt efektivních dat, který seskupuje všechna vyřešená 3D nastavení. Jeho metody [getCamera](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getBevelTop) a [getBevelBottom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getBevelBottom) zpřístupňují odpovídající efektivní data. Čtení těchto souvisejících nastavení najednou usnadňuje pochopení konečného 3D vzhledu tvaru.

Pro tento příklad musí soubor `shape-3d.pptx` obsahovat alespoň jeden tvar na prvním snímku. Pokud chcete, aby výstup obsahoval jiné hodnoty než výchozí, aplikujte na tento tvar 3D kameru, osvětlení nebo nastavení zkosení.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **Získejte efektivní formátování tabulky**

Formátování tabulky může pocházet ze stylu tabulky a z formátů aplikovaných na celou tabulku, sloupec, řádek nebo jednotlivou buňku. V případě konfliktů mezi explicitně definovanými výplněmi je priorita: buňka, řádek, sloupec a nakonec celá tabulka. Efektivní formát buňky je konečný formát použitý k vykreslení této buňky.

Pro tento příklad musí soubor `table-formatting.pptx` obsahovat alespoň jednu tabulku na prvním snímku. Tabulka musí mít alespoň jeden řádek a jeden sloupec. Kód hledá [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/table/) místo předpokladu, že `getShapes().get_Item(0)` je tabulka.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

Pokud potřebujete barvu místo pouhého typu výplně, nejprve zkontrolujte efektivní [getFillType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/#getFillType), a poté použijte metodu odpovídající tomuto typu — například [getSolidFillColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) pro plnou výplň.

## **Znovu načtěte efektivní data po změnách**

Efektivní data popisují hierarchii formátování v okamžiku, kdy jsou vyřešena. Po změně čehokoli, co může v této hierarchii participovat, zavolejte `getEffective` znovu, včetně:

- místní formátování objektu;
- výchozích nastavení odstavce nebo textového rámce;
- stylu tabulky, tabulky, sloupce, řádku nebo formátu buňky;
- formátování rozvržení nebo hlavního snímku;
- dat motivu nebo výchozího nastavení na úrovni prezentace;
- rozvržení nebo hlavního snímku přiřazeného ke snímku.

Neukládejte objekt efektivních dat jako trvalý snímek. Aspose.Slides může interně kešovat některá efektivní data a pozdější volání `getEffective` může tato data obnovit. Pokud potřebujete porovnat hodnoty před a po změně, zkopírujte skalární hodnoty, které potřebujete — například výšku písma, barvu, zarovnání nebo šířku zkosení — do svých vlastních proměnných před provedením změny.

Pro změnu hodnoty aktualizujte příslušný místní formátovací objekt a poté zavolejte `getEffective`, abyste výsledek ověřili. Objektů efektivních dat jsou samy o sobě pouze pro čtení.

## **FAQ**

**Jak mohu zjistit, která úroveň dodala efektivní hodnotu?**

Efektivní data obsahují konečnou hodnotu, nikoli její zdroj. Prohlédněte si příslušné místní objekty od nejspecifičtější úrovně směrem ven. Pro text to může zahrnovat část, odstavec, textový rámec, rozvržení, hlavní snímek, motiv a výchozí nastavení prezentace. Nedefinované hodnoty jako `NaN` nebo `null` naznačují, že hledání pokračuje na další úroveň.

**Co se stane, když žádná úroveň nedefinuje vlastnost?**

Aspose.Slides vyřeší odpovídající výchozí hodnotu PowerPointu nebo knihovny. Tato vyřešená hodnota se objeví v efektivních datech, i když ji žádný místní objekt explicitně nedefinuje.

**Proč je efektivní hodnota někdy stejná jako místní hodnota?**

Místní hodnota vyhrála v dědickém výpočtu. To je očekávané, když je vlastnost explicitně nastavena na objektu a žádné konkrétnější pravidlo ji nepřepíše.

**Kdy bych měl použít místní data místo efektivních dat?**

Použijte místní data k inspekci nebo úpravě konkrétní úrovně formátování. Použijte efektivní data, když potřebujete konečný vzhled po aplikaci dědičnosti, pravidel motivu a použitelných stylů. [Úplný příklad srovnání](#compare-local-inherited-and-effective-values) ukazuje obojí ve stejném pracovním postupu.