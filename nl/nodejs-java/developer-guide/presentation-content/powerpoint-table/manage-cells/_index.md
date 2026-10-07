---
title: Beheer tabelcellen in presentaties met JavaScript
linktitle: Beheer cellen
type: docs
weight: 30
url: /nl/nodejs-java/manage-cells/
keywords:
- tabelcel
- cellen samenvoegen
- rand verwijderen
- cel splitsen
- afbeelding in cel
- achtergrondkleur
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer PowerPoint-tabelcellen in JavaScript: identificeer samengevoegde cellen, verwijder randen, splits cellen en stel achtergrondkleuren en afbeeldingen in met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aspose.Slides stelt u in staat om tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe u samengevoegde tabelcellen kunt identificeren, randen van cellen kunt verwijderen, kunt werken met celnummering na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen en een afbeelding in een tabelcel kunt toevoegen. De voorbeelden laten zien hoe u een presentatie kunt maken of openen, een tabel van een dia kunt krijgen, de celopmaak via cel­eigenschappen kunt bijwerken en de gewijzigde presentatie kunt opslaan als een PPTX‑bestand.

Aspose.Slides gebruikt nulgebaseerde indexen om tabelcellen te benaderen in de volgorde `(column, row)`.

## **Een samengevoegde tabelcel identificeren**

Het voorbeeld opent een bestaande presentatie en benadert de eerste vorm op de eerste dia als een tabel. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een tabel is. Vervolgens loopt het door alle rijen en kolommen en gebruikt [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) om cellen in samengevoegde regio’s te identificeren. Voor elke overeenkomst drukt het de celcoördinaten af in de volgorde `row;column`, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), en de startcoördinaten van de regio, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) en [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Tabelcelranden verwijderen**

Maak een [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) aan en voeg een tabel toe aan de eerste dia met [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/). De kolombreedtes, rijhoogtes en de positie van de tabel worden opgegeven in punten. Het voorbeeld stelt alle vier de celranden in op [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), waardoor ze onzichtbaar worden.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabelcellen samenvoegen**

Gebruik [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) om een rechthoekig bereik van tabelcellen samen te voegen tot één cel. Geef de cellen op in de linkerboven‑ en rechteronderhoek van het bereik. Het laatste argument bepaalt of het samenvoegen cellen buiten het opgegeven bereik mag omvatten; `false` houdt het samenvoegen binnen dat bereik.

Het voorbeeld maakt een 4‑bij‑4 tabel met kolommen en rijen van 70 punten, en voegt vervolgens de vier centrale cellen van `(1, 1)` tot en met `(2, 2)` samen. De resulterende cel beslaat twee kolommen en twee rijen, terwijl het onderliggende raster van de tabel vier kolommen en vier rijen behoudt. Om de inhoud of opmaak van de samengevoegde cel te benaderen, gebruikt u de linkerboven‑positie: `table.get_Item(1, 1)` in dit voorbeeld. De andere posities in het samengevoegde bereik blijven deel van het tabelraster, zodat de indexen van cellen buiten het bereik niet veranderen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabelcellen splitsen**

Het samenvoegen van cellen in het vorige voorbeeld behoudt het raster van de tabel. Het splitsen van een cel kan een nieuwe rasterkolom introduceren en de kolomindexen van de cellen rechts daarvan wijzigen. Aspose.Slides volgt het tabelrastermodel van PowerPoint.

Dit voorbeeld maakt een 4‑bij‑4 tabel met kolommen en rijen van 70 punten en roept [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) aan op cel `(1, 1)`. De helft van de breedte van 70 punten wordt doorgegeven om twee cellen van gelijke breedte te creëren.

Na deze splitsing worden de twee helften benaderd als `table.get_Item(1, 1)` en `table.get_Item(2, 1)`. Het tabelraster heeft nu vijf kolommen: cellen die oorspronkelijk in kolommen 2 en 3 stonden, verplaatsen respectievelijk naar kolommen 3 en 4. Rij‑indexen blijven ongewijzigd. Gebruik deze bijgewerkte kolomindexen bij het benaderen van cellen na de splitsing.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Samengevoegde cellen splitsen op rij‑ of kolom‑span**

Om samengevoegde sjablooncellen voor gegevensinvoer voor te bereiden, gebruikt u [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) om langs een bestaande rijdrempel te splitsen, of [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) om langs een koldrempel te splitsen.

Het argument `index` telt rijen in het bovenste deel of kolommen in het linker deel van de splitsing; het is relatief ten opzichte van de samengevoegde regio:

- Rijsplitsing: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Kolomsplitsing: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

Het voorbeeld gaat ervan uit dat een presentatie een tabel bevat als de eerste vorm op de eerste dia, met `(1, 2)` en `(1, 3)` verticaal samengevoegd. Vanuit de onderste positie gebruikt het [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) en [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) om de oorsprong te vinden en controleert beide spans. `splitByRowSpan(1)` scheidt vervolgens rijen 2 en 3 voor productnamen. Voor een horizontale tweekoloms‑samenvoeging gebruikt u in plaats daarvan `splitByColSpan(1)`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // Haal de resulterende cellen op uit de tabel na het splitsen.
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Het tabelraster en de omliggende cel‑indexen blijven ongewijzigd. Haal de resulterende cellen op via hun coördinaten; beide hebben een span van 1 en [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) geeft `false` terug. Grotere regio’s kunnen na één splitsing gedeeltelijk samengevoegd blijven.

De oorspronkelijke tekst en opmaak blijven in de boven‑ (of linker‑)cel; de nieuwe cel is leeg maar erft de celopmaak zoals vulling, randen en marges. Vul de cellen na het splitsen en stel eventuele gewenste tekstopmaak expliciet in.

De opgeslagen presentatie bevat aparte “Product A”‑ en “Product B”‑cellen met de oorspronkelijke celopmaak behouden. Zie de [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) voor details.

## **De achtergrondkleur van de tabelcel wijzigen**

Dit voorbeeld maakt een tabel met kolommen van 150 punten en rijen van 50 punten. Het gebruikt [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) om een effen vulling te selecteren en stelt de kleur die wordt geretourneerd door [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) in op rood voor cel `(2, 3)`, in de derde kolom en vierde rij.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een afbeelding in een tabelcel toevoegen**

Plaats de invoerafbeelding in de werkmap voordat u dit voorbeeld uitvoert. Het laadt de afbeelding met [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) en voegt deze toe aan de afbeeldingenverzameling van de presentatie met [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/). Vervolgens wijst het de afbeelding toe aan de picture‑vulling van cel `(0, 0)`, de eerste cel in de tabel.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) strekt de afbeelding uit zodat ze de cel vult, waardoor mogelijk de beeldverhouding wordt aangepast. Kolombreedtes en rijhoogtes zijn in punten. De geladen afbeelding wordt in een `finally`‑blok vrijgegeven nadat deze aan de presentatie is toegevoegd.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan ik verschillende lijndiktes en -stijlen instellen voor verschillende zijden van één cel?**

Ja. De [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke zijde kan verschillen.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rij‑grootte wijzig nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Bij stretching past de afbeelding zich aan de nieuwe cel aan; bij tiling worden de tegels opnieuw berekend.

**Kan ik een hyperlink toewijzen aan de volledige inhoud van een cel?**

[Hyperlinks](/slides/nl/nodejs-java/manage-hyperlinks/) worden ingesteld op tekst (portion)‑niveau binnen het tekstframe van de cel of op het niveau van de volledige tabel/vorm. In de praktijk kent u de link toe aan een portion of aan alle tekst in de cel.

**Kan ik verschillende lettertypen instellen binnen één cel?**

Ja. Het tekstframe van een cel ondersteunt [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (runs) met onafhankelijke opmaak—lettertypefamilie, stijl, grootte en kleur.