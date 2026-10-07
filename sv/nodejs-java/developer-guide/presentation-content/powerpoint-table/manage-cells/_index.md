---
title: Hantera tabellceller i presentationer med JavaScript
linktitle: Hantera celler
type: docs
weight: 30
url: /sv/nodejs-java/manage-cells/
keywords:
- tabellcell
- slå ihop celler
- ta bort kant
- dela cell
- bild i cell
- bakgrundsfärg
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera PowerPoint-tabellceller i JavaScript: identifiera sammanslagna celler, ta bort kanter, dela celler samt ange bakgrundsfärger och bilder med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Aspose.Slides låter dig komma åt och ändra tabellceller i PowerPoint‑presentationer. Denna artikel förklarar hur du identifierar sammanslagna tabellceller, tar bort cellkanter, arbetar med cellnumrering efter sammanslagning eller delning av celler, ändrar en cells bakgrundsfärg och lägger till en bild i en tabellcell. Exemplen visar hur du skapar eller öppnar en presentation, hämtar en tabell från en bild, uppdaterar cellformatering via cell‑egenskaper och sparar den ändrade presentationen som en PPTX‑fil.

Aspose.Slides använder nollbaserade index för att komma åt tabellceller i ordning **(kolumn, rad)**.

## **Identifiera en sammanslagen tabellcell**

Exemplet öppnar en befintlig presentation och får den första formen på den första bilden som en tabell. Det förutsätter att bilden och formen finns och att formen är en tabell. Därefter itererar det genom alla rader och kolumner och använder [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) för att identifiera celler i sammanslagna områden. För varje matchning skriver det ut cellkoordinaterna i formatet `rad;kolumn`, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/) och regionens startkoordinater, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) och [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

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

## **Ta bort tabellcellkanter**

Skapa en [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) och lägg till en tabell på dess första bild med [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/). Kolumnbredder, radhöjder och tabellens position anges i punkter. Exemplet sätter alla fyra cellkanter till [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), vilket gör dem osynliga.

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

## **Slå samman tabellceller**

Använd [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) för att kombinera ett rektangulärt område av tabellceller till en cell. Specificera cellerna i det övre vänstra och det nedre högra hörnet av området. Det sista argumentet styr om sammanslagningen får omfatta celler utanför det specificerade området; `false` håller sammanslagningen inom det området.

Exemplet skapar en 4×4‑tabell med 70‑punkts kolumner och rader, och slår sedan ihop de fyra centrala cellerna från `(1, 1)` till `(2, 2)`. Den resulterande cellen sträcker sig över två kolumner och två rader, medan tabellens underliggande rutnät behåller fyra kolumner och fyra rader. För att komma åt den sammanslagna cellens innehåll eller formatering, använd dess övre‑vänstra position: `table.get_Item(1, 1)` i detta exempel. De andra positionerna i det sammanslagna området förblir en del av tabellrutnätet, så indexen för celler utanför området ändras inte.

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

## **Dela tabellceller**

Att slå ihop celler i föregående exempel bevarar tabellens rutnät. Att dela en cell kan införa en ny rutnätskolumn och ändra kolumnindex för celler till höger om den. Aspose.Slides följer PowerPoints tabellrutnätmodell.

Detta exempel skapar en 4×4‑tabell med 70‑punkts kolumner och rader och anropar [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) på cell `(1, 1)`. Hälften av cellens 70‑punkts bredd skickas för att skapa två lika breda celler.

Efter denna delning nås de två halvorna som `table.get_Item(1, 1)` och `table.get_Item(2, 1)`. Tabellrutnätet har nu fem kolumner: celler som ursprungligen var i kolumn 2 och 3 flyttas till kolumn 3 respektive 4. Radindex förblir oförändrade. Använd dessa uppdaterade kolumnindex när du hämtar celler efter delningen.

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

### **Dela sammanslagna celler efter rad‑ eller kolumnspann**

För att förbereda sammanslagna mallceller för datafyllning, använd [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) för att dela längs en befintlig radgräns, eller [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) för att dela längs en kolumngräns.

`index`‑argumentet räknar rader i den övre delen eller kolumner i den vänstra delen av delningen; det är relativt till det sammanslagna området:

- Raddelning: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Kolumndelning: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

Exemplet förutsätter att en presentation har en tabell som den första formen på den första bilden, med `(1, 2)` och `(1, 3)` sammanslagna vertikalt. Med start från den lägre positionen använder det [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) och [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) för att lokalisera ursprunget och kontrollerar båda spannarna. `splitByRowSpan(1)` separerar sedan raderna 2 och 3 för produktnamn. För en horisontell två‑kolumns‑sammanslagning, använd `splitByColSpan(1)` istället.

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

        // Hämta de resulterande cellerna från tabellen efter delning.
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

Tabellrutnätet och omgivande cellindex förblir oförändrade. Hämta de resulterande cellerna via deras koordinater; här har båda spann på 1 och [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) returnerar `false`. Större områden kan förbli delvis sammanslagna efter en delning.

Den ursprungliga texten och dess formatering finns kvar i den övre (eller vänstra) cellen; den nya cellen är tom men ärver cellformatering såsom fyllning, kanter och marginaler. Fyll i cellerna efter delning och ange eventuell nödvändig textformatering explicit.

Den sparade presentationen innehåller separata celler “Product A” och “Product B” med mallens cellformatering bevarad. Se [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) för detaljer.

## **Ändra tabellcellens bakgrundsfärg**

Detta exempel skapar en tabell med 150‑punkts kolumner och 50‑punkts rader. Det använder [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) för att välja en solid fyllning och sätter färgen som returneras av [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) till röd för cell `(2, 3)`, i den tredje kolumnen och fjärde raden.

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

## **Lägg till en bild i en tabellcell**

Placera inmatningsbilden i arbetskatalogen innan du kör detta exempel. Det laddar bilden med [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) och lägger till den i presentationens bildsamling med [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/). Därefter tilldelas bilden bildfyllningen för cell `(0, 0)`, den första cellen i tabellen.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) sträcker bilden för att fylla cellen, vilket kan ändra bildens bildförhållande. Kolumnbredder och radhöjder anges i punkter. Den laddade bilden disponeras i ett `finally`‑block efter att den lagts till i presentationen.

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

**Kan jag ange olika linjetjocklekar och stilar för olika sidor av en enskild cell?**

Ja. [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) kanter har separata egenskaper, så tjocklek och stil för varje sida kan skilja sig.

**Vad händer med bilden om jag ändrar kolumn‑/radstorleken efter att ha satt en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Vid stretching anpassas bilden till den nya cellen; vid tiling beräknas brickorna om.

**Kan jag tilldela en hyperlänk till allt innehåll i en cell?**

[Hyperlinks](/slides/sv/nodejs-java/manage-hyperlinks/) sätts på text‑ (portion)‑nivå inuti cellens textruta eller på hela tabell‑/formnivå. I praktiken tilldelar du länken till en portion eller till all text i cellen.

**Kan jag ange olika teckensnitt inom en enda cell?**

Ja. En cells textruta stöder [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (körningar) med oberoende formatering — teckensnitt, stil, storlek och färg.