---
title: Beheer rijen en kolommen in PowerPoint‑tabellen met JavaScript
linktitle: Rijen en kolommen
type: docs
weight: 20
url: /nl/nodejs-java/manage-rows-and-columns/
keywords:
- tabelrij
- tabelkolom
- eerste rij
- tabelkop
- rij klonen
- kolom klonen
- rij kopiëren
- kolom kopiëren
- rij verwijderen
- kolom verwijderen
- tekstopmaak rij
- tekstopmaak kolom
- tabelstijl
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer tabelrijen en -kolommen in PowerPoint met JavaScript en Aspose.Slides voor Node.js via Java en versnel het bewerken van presentaties en het bijwerken van gegevens."
---
## **Introductie**

Aspose.Slides for Node.js via Java laat u de tabelstructuur en -opmaak in PowerPoint‑presentaties beheren via de [Tabel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/)‑klasse. U kunt een koprij aanwijzen, rijen en kolommen klonen of verwijderen, en tekstopmaak toepassen op een volledige rij of kolom.

Dit artikel legt deze bewerkingen uit met JavaScript‑voorbeelden. Het toont ook hoe u een stijl‑preset van een tabel kunt ophalen zodat u die opnieuw kunt gebruiken. Rij‑ en kolomindexen zijn nul‑gebaseerd.

## **Rijhoogte regelen**

Gebruik [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) om de minimale hoogte van een rij in punten in te stellen. Het is een ondergrens, geen vaste hoogte. [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) geeft de werkelijke hoogte terug. Toegang tot de rij krijg u via [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--).

Het voorbeeld laadt [row-height-input.pptx](row-height-input.pptx), dat een tabel bevat als eerste vorm op de eerste dia. De eerste rij begint op 70 punt. De cellen gebruiken 18‑punt Arial‑tekst, tekstomloop en 6‑punt boven‑ en onder‑marges; de langere tekst in de tweede kolom loopt over meerdere regels. Het voorbeeld verhoogt het minimum naar 100 punt, verlaagt het vervolgens naar 20 punt, drukt na elke wijziging de werkelijke hoogte af en slaat beide resultaten op.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Met de meegeleverde presentatie voegt het verhogen van het minimum extra ruimte toe aan de rij. Het verlagen ervan verwijdert die extra ruimte, maar de werkelijke hoogte blijft groter dan 20 punt omdat de tekst en cel‑marges meer ruimte nodig hebben. Alleen het minimum verlagen kan de rij niet onder de door de inhoud vereiste ruimte duwen.

Verschillende factoren beïnvloeden de werkelijke hoogte:

- **Tekst en lettergrootte:** langere tekst, expliciete regeleinden of een groter lettertype kunnen meer verticale ruimte vragen.
- **Omloop en kolombreedte:** met omloop ingeschakeld kan het verkleinen van de kolom‑breedte met [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) meer regels opleveren. Een bredere kolom kan de benodigde verticale ruimte verminderen.
- **Cel‑marges:** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) en [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) voegen verticale ruimte toe. [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) en [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) verkleinen de beschikbare breedte voor tekst en kunnen extra omloop veroorzaken.

Voor deze tabel zonder samengevoegde cellen bepaalt de cel die de meeste verticale ruimte nodig heeft de inhoud‑gedreven ondergrens voor de gehele rij. Om de rij korter te maken, moet u mogelijk de tekst inkorten, de lettergrootte of marges verminderen, of een kolom breder maken.

De afbeeldingen hieronder tonen dezelfde tabel op dezelfde schaal. In de geïllustreerde resultaten waren de werkelijke hoogtes 70, 100 en 55,2 punt: de laatste rij bleef hoger dan het minimum van 20 punt. Exacte tekstmetingen kunnen variëren afhankelijk van de lettertypen die in uw omgeving beschikbaar zijn. Download de opgeslagen resultaten: [verhoogd minimum](row-height-increased.pptx) en [verlaagd minimum](row-height-decreased.pptx).

| Origineel: minimum 70 pt, werkelijke 70 pt | Verhoogd: minimum 100 pt, werkelijke 100 pt | Verlaagd: minimum 20 pt, werkelijke 55,2 pt |
| --- | --- | --- |
| ![Originele tabel met een eerste rij van 70 punt.](row-height-before.png) | ![Tabel na het verhogen van het minimum van de eerste rij naar 100 punt.](row-height-increased.png) | ![Tabel na het verlagen van het minimum van de eerste rij naar 20 punt; ingekorte tekst houdt de rij hoger dan het minimum.](row-height-decreased.png) |

## **De eerste rij als koptekst instellen**

Gebruik de [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-)‑methode om de eerste rij te markeren voor koptekst‑opmaak. Het uiterlijk hangt af van de tabelstijl die op de tabel is toegepast.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑klasse.
2. Toegang tot de eerste dia.
3. Toegang tot de tabel die als eerste vorm op de dia is opgeslagen.
4. Schakel koptekst‑opmaak in voor de eerste rij.
5. Sla de gewijzigde presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als eerste vorm op de eerste dia. Het schakelt koptekst‑opmaak in voor de eerste rij en slaat `First_row_header.pptx` op.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een tabelrij of -kolom klonen**

Kloon rijen of kolommen om hun inhoud en opmaak opnieuw te gebruiken. U kunt een kopie aan het einde van de tabel toevoegen of deze op een specifieke positie invoegen.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑klasse.
2. Toegang tot de eerste dia.
3. Definieer de kolombreedtes en rijhoogtes.
4. Voeg een tabel toe met de [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---)‑methode.
5. Kloon de benodigde rijen.
6. Kloon de benodigde kolommen.
7. Sla de gewijzigde presentatie op.

Het voorbeeld vereist `Test.pptx` met minstens één dia. Het maakt een tabel met drie kolommen en vijf rijen, met afmetingen opgegeven in punten. Het voegt kopieën van de eerste rij en kolom toe, en voegt vervolgens kopieën van de tweede rij en kolom in op index 3 (de vierde positie). De resulterende tabel heeft zeven rijen en vijf kolommen. Het argument `false` schakelt klonen in aangrenzende samengevoegde rijen of kolommen uit; deze tabel heeft geen samengevoegde cellen.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een rij of kolom uit een tabel verwijderen**

Verwijder rijen of kolommen die niet meer nodig zijn in een tabel. Het verwijderen van een item verschuift de indexen van de rijen of kolommen die erop volgen.

1. Maak een presentatie met de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑klasse.
2. Toegang tot de eerste dia.
3. Definieer de kolombreedtes en rijhoogtes.
4. Voeg een tabel toe met de [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---)‑methode.
5. Verwijder de tweede rij en tweede kolom.
6. Sla de gewijzigde presentatie op.

Dit voorbeeld maakt een tabel van drie bij drie en verwijdert de rij en kolom op index 1, waardoor een tabel van twee bij twee overblijft in `TestTable_out.pptx`. De afmetingen zijn in punten. Het argument `false` schakelt het verwijderen van aangrenzende samengevoegde rijen of kolommen uit; deze tabel heeft geen samengevoegde cellen.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tekstopmaak instellen op rijniveau van de tabel**

Pas tekstopmaak toe op een volledige rij zodat de cellen consistent blijven. U kunt lettertype‑eigenschappen, alineavormgeving en tekstrichting instellen zonder elke cel afzonderlijk te formatteren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑klasse.
2. Toegang tot de tabel op de eerste dia.
3. Gebruik [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) voor de eerste rij.
4. Gebruik [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) en [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) voor de eerste rij.
5. Gebruik [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) voor de tweede rij.
6. Sla de gewijzigde presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als eerste vorm op de eerste dia en minstens twee rijen. Het past 25‑punt tekst, rechts‑uitlijning en een marge van 20 punt rechts op de eerste rij toe, waarna verticale tekst in de tweede rij wordt ingesteld.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tekstopmaak instellen op kolomniveau van de tabel**

Pas tekstopmaak toe op een volledige kolom zodat de cellen consistent blijven. U kunt lettertype‑eigenschappen, alineavormgeving en tekstrichting instellen zonder elke cel afzonderlijk te formatteren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑klasse.
2. Toegang tot de tabel op de eerste dia.
3. Gebruik [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) voor de eerste kolom.
4. Gebruik [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) en [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) voor de eerste kolom.
5. Gebruik [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) voor de tweede kolom.
6. Sla de gewijzigde presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als eerste vorm op de eerste dia en minstens twee kolommen. Het past 25‑punt tekst, rechts‑uitlijning en een marge van 20 punt rechts op de eerste kolom toe, waarna verticale tekst in de tweede kolom wordt ingesteld.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabelstijl‑eigenschappen ophalen**

Gebruik de [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--)‑methode om de preset die op een tabel is toegepast op te halen en die op een andere tabel opnieuw te gebruiken. Dit identificeert de preset in plaats van individuele cel‑opmaakoverschrijvingen.

Het voorbeeld maakt een tabel, past [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1) toe, en leest de preset terug. Het drukt de gehele getalwaarde van `DarkStyle1` af en slaat de tabel op in `table.pptx`.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan ik PowerPoint‑thema’s/‑stijlen toepassen op een tabel die al bestaat?**

Ja. De tabel erft het thema van de dia/layout/master, en u kunt nog steeds opvullingen, randen en tekstkleuren overschrijven bovenop dat thema.

**Kan ik tabelrijen sorteren zoals in Excel?**

Nee, Aspose.Slides‑tabellen hebben geen ingebouwde sortering of filters. Sorteer uw gegevens eerst in het geheugen en vul vervolgens de tabelrijen in die volgorde opnieuw.

**Kan ik gestreepte (banded) kolommen hebben terwijl ik aangepaste kleuren behoud op specifieke cellen?**

Ja. Schakel gestreepte kolommen in en overschrijf vervolgens specifieke cellen met lokale opmaak; opmaak op celniveau heeft voorrang boven de tabelstijl.