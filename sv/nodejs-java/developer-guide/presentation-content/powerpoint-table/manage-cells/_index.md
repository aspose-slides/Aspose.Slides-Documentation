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
description: "Hantera tabellceller i PowerPoint med Aspose.Slides för Node.js. Bli expert på att snabbt komma åt, modifiera och formatera celler för sömlös bildautomation."
---
## **Översikt**

Aspose.Slides låter dig komma åt och ändra tabellceller i PowerPoint-presentationer. Den här artikeln förklarar hur du identifierar sammanslagna tabellceller, tar bort cellkanter, arbetar med cellnumrering efter sammanslagning eller delning av celler, ändrar en cells bakgrundsfärg och lägger till en bild i en tabellcell. Exemplen visar hur du skapar eller öppnar en presentation, hämtar en tabell från en bild, uppdaterar cellformatering via cellegenskaper och sparar den ändrade presentationen som en PPTX-fil.

## **Identifiera sammanslagen tabellcell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta tabellen från den första bilden.
3. Iterera genom tabellens rader och kolumner för att hitta sammanslagna celler.
4. Skriv ut ett meddelande när sammanslagna celler hittas.

Denna JavaScript‑kod visar hur du identifierar sammanslagna tabellceller i en presentation:

```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// antar att Slide#0.Shape#0 är en tabell
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ta bort kantlinjer för tabellceller**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Definiera en array av kolumner med bredd.
4. Definiera en array av rader med höjd.
5. Lägg till en tabell på bilden via metoden [addTable](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Iterera genom varje cell för att rensa de övre, nedre, högra och vänstra kanterna.
7. Spara den ändrade presentationen som en PPTX-fil.

Denna JavaScript‑kod visar hur du tar bort kanterna från tabellceller:

```javascript
// Instansierar Presentation-klassen som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Åtkommer den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Definierar kolumner med bredder och rader med höjder
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Lägger till tabellform till bilden
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Sätter kantformatet för varje cell
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // Skriver PPTX-filen till disk
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nummerering i sammanslagna celler**

Om vi sammanslår 2 par celler (1, 1) x (2, 1) och (1, 2) x (2, 2) kommer den resulterande tabellen att numreras. Denna JavaScript‑kod demonstrerar processen:

```javascript
// Instansierar Presentation-klassen som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Definierar kolumner med bredder och rader med höjder
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Lägger till en tabellform på bilden
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Anger kantformatet för varje cell
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Slår ihop celler (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Slår ihop celler (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Vi sammanslår sedan cellerna ytterligare genom att slå ihop (1, 1) och (1, 2). Resultatet är en tabell som innehåller en stor sammanslagen cell i mitten:

```javascript
// Instansierar Presentation-klassen som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Definierar kolumner med bredder och rader med höjder
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Lägger till en tabellform på bilden
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Anger kantformatet för varje cell
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Slår ihop celler (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Slår ihop celler (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Slår ihop celler (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // Skriver PPTX-filen till disk
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nummerering i delade celler**

I tidigare exempel, när tabellceller sammanslogs, ändrades inte numreringen eller talssystemet i övriga celler.

Denna gång tar vi en vanlig tabell (en tabell utan sammanslagna celler) och försöker sedan dela cell (1,1) för att få en speciell tabell. Du bör uppmärksamma tabellens numrering, som kan uppfattas som märklig. Detta är dock så Microsoft PowerPoint numrerar tabellceller och Aspose.Slides gör samma sak.

Denna JavaScript‑kod demonstrerar den beskrivna processen:

```javascript
// Instansierar Presentation-klassen som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Definierar kolumner med bredder och rader med höjder
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Lägger till en tabellform på bilden
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Anger kantformatet för varje cell
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Slår ihop celler (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Slår ihop celler (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Delar cell (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // Skriver PPTX-filen till disk
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ändra bakgrundsfärg för tabellcell**

Denna JavaScript‑kod visar hur du ändrar en tabellcells bakgrundsfärg:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // skapa en ny tabell
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // sätt bakgrundsfärgen för en cell
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Lägg till bild i tabellcell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Definiera en array av kolumner med bredd.
4. Definiera en array av rader med höjd.
5. Lägg till en tabell på bilden via metoden [addTable](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Skapa ett `Images`‑objekt för att hålla bildfilen.
7. Lägg till `IImage`‑bilden i `PPImage`‑objektet.
8. Ställ in `FillFormat` för tabellcellen till `Picture`.
9. Lägg till bilden i tabellens första cell.
10. Spara den ändrade presentationen som en PPTX‑fil

Denna JavaScript‑kod visar hur du placerar en bild i en tabellcell när du skapar en tabell:

```javascript
// Instansierar Presentation-klassen som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden
    var islide = pres.getSlides().get_Item(0);
    // Definierar kolumner med bredder och rader med höjder
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // Lägger till en tabellform på bilden
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // Skapar ett PPImage-objekt med bildfilen
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Lägger till bilden i den första tabellcellen
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Sparar PPTX-filen till disk
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Kan jag ange olika linjetjocklekar och -stilar för olika sidor av en enskild cell?**

Ja. Kanterna [top](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cellformat/getborderright/) har separata egenskaper, så tjocklek och stil för varje sida kan skilja sig åt. Detta följer logiskt från den per‑sida kantkontrollen för en cell som demonstrerades i artikeln.

**Vad händer med bilden om jag ändrar kolumn-/radstorlek efter att ha ställt in en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Vid stretch justeras bilden till den nya cellen; vid tile beräknas mosaiken om. Artikeln nämner bildvisningslägen i en cell.

**Kan jag tilldela en hyperlänk till allt innehåll i en cell?**

[Hyperlinks](/slides/sv/nodejs-java/manage-hyperlinks/) sätts på textraden (portion) i cellens textram eller på hela tabellen/formen. I praktiken tilldelar du länken till en del eller till all text i cellen.

**Kan jag ange olika teckensnitt i en enda cell?**

Ja. En cells textram stödjer [portions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/) (körningar) med oberoende formatering — teckensnittsfamilj, stil, storlek och färg.