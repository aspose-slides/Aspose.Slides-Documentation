---
title: Beheer presentatietabellen in JavaScript
linktitle: Beheer tabel
type: docs
weight: 10
url: /nl/nodejs-java/manage-table/
keywords:
- tabel toevoegen
- tabel maken
- toegang tot tabel
- beeldverhouding
- tekst uitlijnen
- tekstopmaak
- tabelstijl
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak en bewerk tabellen in PowerPoint-dia's met JavaScript en Aspose.Slides voor Node.js. Ontdek eenvoudige code-voorbeelden om uw tabelwerkstromen te stroomlijnen."
---
## **Inleiding**

Tabellen in PowerPoint organiseren informatie in rijen en kolommen, waardoor het makkelijker wordt om waarden te lezen en te vergelijken.

Aspose.Slides biedt de [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) klasse, [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) klasse, en andere types om u in staat te stellen tabellen in presentaties te maken, bij te werken en te beheren.

## **Een tabel vanaf nul maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) klasse.
2. Haal een referentie naar de dia op via de index.
3. Definieer een array van kolombreedtes in punten.
4. Definieer een array van rijhoogtes in punten.
5. Voeg een [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) object toe aan de dia via de [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-) methode.
6. Itereer door elke [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) om opmaak toe te passen op de boven-, onder-, rechts- en linkerranden.
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.
8. Benader de samengevoegde cel via de [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) methode.
9. Stel de tekst in de samengevoegde cel in.
10. Sla de aangepaste presentatie op.

Het voorbeeld hieronder maakt een tabel met drie kolommen en vijf rijen op (100, 50) punten. Het past rode randen toe met een breedte van 5 punten, voegt de eerste twee cellen in de eerste rij samen, en slaat het resultaat op als `table.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nummering in een standaardtabel**

In een standaardtabel zijn celindices nul‑gebaseerd en gebruiken ze de volgorde (kolom, rij). De eerste cel heeft index (0, 0).

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden op deze manier genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dit voorbeeld maakt de bovenstaande 4 × 4 tabel, met kolombreedtes en rijhoogtes van 70 punten en rode celranden met een breedte van 5 punten. De coördinaten illustreren celindices; het voorbeeld laat de cellen leeg en slaat de tabel op als `StandardTables_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Toegang tot een bestaande tabel**

Tabellen worden opgeslagen in de vormverzameling van een dia. Doorloop de vormen om een tabel te vinden, en gebruik vervolgens de [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) klasse om de cellen te lezen of bij te werken.

1. Laad de presentatie met behulp van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) klasse.
2. Haal een referentie naar de dia die de tabel bevat op via de index.
3. Itereer door de [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) objecten en stop wanneer een tabel wordt gevonden. Als de dia meerdere tabellen bevat, gebruik [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) om de gewenste tabel te identificeren.
4. Werk de tekst in de doelcel bij.
5. Sla de aangepaste presentatie op.

Het voorbeeld hieronder opent `UpdateExistingTable.pptx` en vindt de eerste tabel op de eerste dia. Het stelt de cel in kolom 0, rij 1 in op `New` en slaat het resultaat op als `table1_out.pptx`. De invoer moet minstens één dia bevatten, en de eerste tabel op die dia moet minstens één kolom en twee rijen hebben.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Zie [Rijhoogte beheren](/slides/nl/nodejs-java/manage-rows-and-columns/#control-row-height) om een rij in een bestaande tabel te verkleinen en te begrijpen waarom de werkelijke hoogte de gevraagde minimumhoogte kan overschrijden.

## **Zoek de cel die een tekstframe bezit**

Wanneer generieke tekstverwerkingscode een [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) van een tabel ontvangt, gebruik dan de [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) methode om de eigenaar‑[Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) op te halen. Voor een tabel‑cel tekstframe retourneert [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) de eigenaar en retourneert [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) `null`, hoewel de tabel zelf een vorm is.

De celcoördinaten zijn beschikbaar via de alleen‑lezen [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) en [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) methoden. [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) biedt ook alleen‑lezen navigatie: het retourneert de eigenaar maar wijzigt geen eigendom. Controleer altijd of de geretourneerde cel `null` is voordat u deze gebruikt.

Voor een volledig voorbeeld dat tabel‑cel en vorm‑eigenaars identificeert, inclusief vormen die bij SmartArt‑knopen horen, zie [Zoeken en vervangen van tekst](/slides/nl/nodejs-java/search-and-replace-text/).

## **Tekst uitlijnen in een tabel**

U kunt de verticale verankering en tekstrichting van individuele tabelcellen regelen. Het voorbeeld in deze sectie centreert de tekst in de eerste cel en roteert deze met 270 graden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) klasse.
2. Haal een referentie naar de dia op via de index.
3. Voeg een [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) object toe aan de dia.
4. Benader een [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) object uit de tabel.
5. Benader de eerste [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) en stel de tekst en kleur in.
6. Stel de verticale verankering en tekstrichting van de cel in met behulp van [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) en [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-).
7. Sla de aangepaste presentatie op.

Dit voorbeeld maakt een 4 × 4 tabel met kolombreedtes van 120 punten en rijhoogtes van 100 punten. Het formatteert de tekst in cel (0, 0), voegt waarden toe aan de resterende cellen in de eerste rij, en slaat het resultaat op als `Vertical_Align_Text_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tekstopmaak instellen op tabelniveau**

Gebruik [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) om tekstopmaak toe te passen op alle cellen in een tabel. De overloads accepteren opmaak voor portion, paragraph en text frame, zodat u deze eigenschappen kunt instellen zonder door individuele cellen te itereren.

1. Laad de presentatie met behulp van de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) klasse.
2. Haal een referentie naar de dia op via de index.
3. Benader een [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) object uit de dia.
4. Stel de lettergrootte in met behulp van [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) voor de tekst.
5. Stel de alinea‑uitlijning en de rechtermarge in met [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) en [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Stel de tekstrichting in met [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Sla de aangepaste presentatie op.

Het voorbeeld hieronder opent `table.pptx`, die minstens één dia moet bevatten met een tabel als eerste vorm. Het stelt de lettergrootte in op 25 punten, uitlijnt alinea's rechts met een rechtermarge van 20 punten, en maakt de tekst verticaal. De opgemaakte presentatie wordt opgeslagen als `result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabelstijl‑eigenschappen ophalen**

Gebruik [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) om de vooraf ingestelde stijl van een tabel te lezen en [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) om deze toe te wijzen. Dit voorbeeld past [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) toe op één tabel, print de preset‑waarde, en kent dezelfde preset toe aan een tweede tabel. Beide tabellen worden opgeslagen in `table-style.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verhouding van een tabel vergrendelen**

De beeldverhouding van een tabel is de verhouding tussen breedte en hoogte. Gebruik [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) om deze verhouding voor een tabel te vergrendelen.

Het voorbeeld hieronder opent `pres.pptx`, die minstens één dia moet bevatten met een tabel als eerste vorm. Het print de huidige vergrendelingsstatus, schakelt de vergrendeling van de beeldverhouding in, print de bijgewerkte status (`true`), en slaat het resultaat op als `pres-out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan ik rechts‑naar‑links (RTL) leesrichting inschakelen voor een volledige tabel en de tekst in de cellen?**

Ja. De tabel biedt een [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-) methode, en alinea's hebben [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-). Door beide te gebruiken wordt de juiste RTL‑volgorde en weergave binnen cellen gegarandeerd.

**Hoe kan ik voorkomen dat gebruikers een tabel in het uiteindelijke bestand verplaatsen of de grootte wijzigen?**

Gebruik [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) om verplaatsen, wijzigen van grootte, selectie, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding als achtergrond in een cel ondersteund?**

Ja. U kunt een [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) voor een cel instellen; de afbeelding bedekt het celgebied volgens de gekozen modus (uitrekken of tegel).