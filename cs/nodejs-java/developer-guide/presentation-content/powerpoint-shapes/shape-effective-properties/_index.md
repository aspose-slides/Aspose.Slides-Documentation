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
description: "Objevte, jak Aspose.Slides pro Node.js prostřednictvím Java vypočítává a aplikuje efektivní vlastnosti tvarů pro přesné vykreslování v PowerPointu."
---
## **Přehled**

Toto téma vysvětluje rozdíl mezi **lokálními** a **efektivními** vlastnostmi. Lokální hodnoty jsou hodnoty, které jsou nastaveny přímo na určité úrovni formátování, například:

1. Vlastnosti úseku na snímku.
1. Textové styly prototypu tvaru na rozložení nebo hlavním snímku, pokud má tvar textového rámce úseku takový styl.
1. Globální nastavení textu v prezentaci.

Lokální hodnoty mohou být na jakékoli úrovni definovány nebo vynechány. Když Aspose.Slides potřebuje finální formátování "jak je vykresleno", rozřeší řetězec dědičnosti a vrátí **efektivní** hodnoty. Můžete je získat voláním metody `getEffective` na objektu lokálního formátu.

Následující příklad ukazuje, jak získat efektivní hodnoty. Předpokládá, že první tvar na prvním snímku je [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) s textovým rámcem a alespoň jedním úsekem.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Efektivní formátovací data představují aktuální vypočítané formátování po aplikaci dědičnosti. V současné implementaci mohou být některé objekty efektivních dat interně uloženy v cache. Opětovné volání `getEffective` po změně nadřazeného nebo zděděného formátování může vyčistit cache a dříve získaný objekt již nemusí reprezentovat předchozí stav. Pokud potřebujete efektivní hodnoty zachovat pro pozdější použití, zkopírujte požadované vlastnosti, například výšku písma, barvu výplně, styl písma nebo zarovnání, do svého vlastního datového objektu.
{{% /alert %}}

## **Získání efektivních vlastností kamery**

Aspose.Slides vám umožňuje získat efektivní vlastnosti kamery. Objekt dat efektivní kamery obsahuje neměnné vlastnosti kamery a je zpřístupněn prostřednictvím efektivních hodnot vrácených pro [ThreeDFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/).

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti kamery. Předpokládá, že první tvar na prvním snímku má 3D formátování.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Získání efektivních vlastností Light Rig**

Aspose.Slides vám umožňuje získat efektivní vlastnosti Light Rig. Objekt dat efektivního Light Rig obsahuje neměnné vlastnosti Light Rig a je zpřístupněn prostřednictvím efektivních hodnot vrácených pro [ThreeDFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/).

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti Light Rig. Předpokládá, že první tvar na prvním snímku má 3D formátování.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Získání efektivních vlastností zkoseného tvaru**

Aspose.Slides vám umožňuje získat efektivní vlastnosti zkosení tvaru. Objekt dat efektivního zkosení tvaru obsahuje neměnné vlastnosti reliéfu povrchu tvaru a je zpřístupněn prostřednictvím efektivních hodnot vrácených pro [ThreeDFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/).

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti horního zkosení tvaru. Předpokládá, že první tvar na prvním snímku má 3D formátování.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Získání efektivních vlastností textového rámce**

Pomocí Aspose.Slides můžete získat efektivní vlastnosti textového rámce. Vrácený objekt efektivních dat obsahuje vlastnosti formátování textového rámce.

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti formátování textového rámce. Předpokládá, že první tvar na prvním snímku je [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) s textovým rámcem.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Získání efektivních vlastností textového stylu**

Pomocí Aspose.Slides můžete získat efektivní vlastnosti textového stylu. Vrácený objekt efektivních dat obsahuje vlastnosti textového stylu.

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti textového stylu. Předpokládá, že první tvar na prvním snímku je [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) s textovým rámcem.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Získání efektivní hodnoty výšky písma**

Pomocí Aspose.Slides můžete získat efektivní výšku písma. Následující kód ukazuje, jak se efektivní výška písma úseku mění po nastavení lokálních hodnot výšky písma na různých úrovních struktury prezentace.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **Získání efektivního formátu výplně pro tabulku**

Pomocí Aspose.Slides můžete získat efektivní formátování výplně pro různé části tabulky. Vrácený objekt efektivních dat obsahuje vlastnosti formátování výplně. Formátování buňky má vyšší prioritu než formátování řádku, formátování řádku má vyšší prioritu než formátování sloupce a formátování sloupce má vyšší prioritu než formátování celé tabulky.

Výsledkem je, že efektivní vlastnosti formátování buňky jsou použity při kreslení buňky tabulky. Následující ukázkový kód ukazuje, jak získat efektivní formátování výplně pro různé části tabulky. Předpokládá, že první tvar na prvním snímku je [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/table/).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Vrací `getEffective` snímek?**

Ne vždy. Efektivní data představují vypočítané formátování po aplikaci dědičnosti, ale některé objekty efektivních dat mohou být interně ukládány v cache. Následné volání `getEffective` může přepočítat formátování a obnovit cache, takže dříve získaný objekt by neměl být považován za trvalý snímek.

**Kdy bych měl znovu načíst efektivní vlastnosti?**

Volání `getEffective` znovu po změně lokálního formátování, nadřazených stylů, formátování rozložení, formátování hlavního snímku nebo výchozích hodnot na úrovni prezentace. Další volání přehodnotí hierarchii formátování a vrátí aktuální efektivní výsledek.

**Ovlivní změna nebo odstranění rozložení/hlavního snímku efektivní vlastnosti, které již byly získány?**

Ano, ale změna se projeví při dalším volání `getEffective`. Pokud je změněn nebo odstraněn zdroj nadřazeného formátování, dříve získaná efektivní data mohou být zastaralá. Po opětovném volání `getEffective` Aspose.Slides znovu vyhodnotí strom formátování a výsledná písma, barvy, velikosti nebo jiné hodnoty se mohou změnit.

**Mohu měnit hodnoty prostřednictvím objektů efektivních dat?**

Ne. Objektům efektivních dat jsou exposované vypočítané hodnoty. Změny provádějte v lokálních objektech formátování a poté znovu získávejte efektivní hodnoty.

**Co se stane, pokud není vlastnost nastavena na úrovni tvaru, ani v rozložení/hlavním snímku, ani v globálním nastavení?**

Efektivní hodnota je určena výchozím mechanismem, který zahrnuje výchozí hodnoty PowerPointu a Aspose.Slides. Tato vyřešená hodnota se stane součástí aktuálních efektivních dat.

**Z efektivní hodnoty písma mohu zjistit, která úroveň poskytla velikost nebo typ písma?**

Ne přímo. Efektivní data vracejí konečnou hodnotu. Pro určení zdroje zkontrolujte lokální hodnoty v úseku, odstavci, textovém rámci a stylech textu na úrovních rozložení, hlavního snímku a prezentace, abyste zjistili, kde se objeví první explicitní definice.

**Proč se efektivní hodnoty někdy jeví jako identické s lokálními?**

Protože lokální hodnota se ukázala jako konečná (nebyla potřeba žádná vyšší úroveň dědičnosti). V takových případech se efektivní hodnota shoduje s lokální.

**Kdy bych měl používat efektivní vlastnosti a kdy pracovat jen s lokálními?**

Používejte efektivní data, když potřebujete výsledek „jak je vykresleno“ po aplikaci veškeré dědičnosti, například pro zarovnání barev, odsazení nebo velikostí. Pokud potřebujete tyto hodnoty zachovat bez ohledu na pozdější změny formátování, zkopírujte požadované vlastnosti do vlastního objektu. Pokud potřebujete změnit formátování na konkrétní úrovni, upravte lokální vlastnosti a poté, je‑li to potřeba, znovu načtěte efektivní data pro ověření výsledku.