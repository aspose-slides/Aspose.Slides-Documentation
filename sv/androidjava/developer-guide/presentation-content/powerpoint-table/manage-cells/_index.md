---
title: Hantera tabellceller i presentationer på Android
linktitle: Hantera celler
type: docs
weight: 30
url: /sv/androidjava/manage-cells/
keywords:
- tabellcell
- slå samman celler
- ta bort kant
- dela cell
- bild i cell
- bakgrundsfärg
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Hantera PowerPoint-tabellceller på Android: identifiera sammanslagna celler, ta bort kanter, dela celler och sätt bakgrundsfärger och bilder med Aspose.Slides för Android via Java."
---
## **Översikt**

Aspose.Slides låter dig komma åt och ändra tabellceller i PowerPoint-presentationer. Den här artikeln förklarar hur man identifierar sammanslagna tabellceller, tar bort cellkanter, arbetar med cellnumrering efter sammanslagning eller delning av celler, ändrar en cells bakgrundsfärg och lägger till en bild i en tabellcell. Exemplen visar hur man skapar eller öppnar en presentation, hämtar en tabell från en bild, uppdaterar cellformatering via cellegenskaper och sparar den ändrade presentationen som en PPTX-fil.

Aspose.Slides använder nollbaserade index för att komma åt tabellceller i ordningen `(column, row)`.

## **Identifiera en sammanslagen tabellcell**

Exemplet öppnar en befintlig presentation och får åtkomst till den första formen på den första bilden som en tabell. Det förutsätter att bilden och formen finns och att formen är en tabell. Därefter itererar det genom alla rader och kolumner och använder [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) för att identifiera celler i sammanslagna områden. För varje matchning skriver det ut cellkoordinaterna i ordningen `row;column`, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), och områdets startkoordinater, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) och [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ta bort tabellcellkanter**

Skapa en [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) och lägg till en tabell på dess första bild med [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Kolumnbredder, radhöjder och tabellens position anges i punkter. Exemplet sätter alla fyra cellkanter till [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), vilket gör dem osynliga.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sammanfoga tabellceller**

Använd [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) för att kombinera ett rektangulärt område av tabellceller till en cell. Specificera cellerna i det övre vänstra och nedre högra hörnet av området. Det sista argumentet styr om sammanslagningen får inkludera celler utanför det angivna området; `false` håller sammanslagningen inom det området.

Exemplet skapar en 4×4-tabell med 70‑punkts kolumner och rader, och sammanslår sedan de fyra centrala cellerna från `(1, 1)` till `(2, 2)`. Den resulterande cellen spänner över två kolumner och två rader, medan tabellens underliggande rutnät behåller fyra kolumner och fyra rader. För att komma åt den sammanslagna cellens innehåll eller formatering, använd dess övre vänstra position: `table.get_Item(1, 1)` i detta exempel. De andra positionerna i det sammanslagna området förblir en del av tabellrutnätet, så indexen för celler utanför området ändras inte.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dela tabellceller**

Att sammanslå celler i föregående exempel bevarar tabellens rutnät. Att dela en cell kan introducera en ny rutnätskolumn och ändra kolumnindexen för cellerna till höger om den. Aspose.Slides följer PowerPoints tabellrutnätsmodell.

Detta exempel skapar en 4×4-tabell med 70‑punkts kolumner och rader och anropar [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) på cell `(1, 1)`. Hälften av cellens 70‑punkts bredd skickas för att skapa två lika breda celler.

Efter denna delning nås de två halvorna som `table.get_Item(1, 1)` och `table.get_Item(2, 1)`. Tabellrutnätet har nu fem kolumner: celler som ursprungligen var i kolumn 2 och 3 flyttas till kolumn 3 respektive 4. Radräkningarna förblir oförändrade. Använd dessa uppdaterade kolumnindex när du kommer åt celler efter delningen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Dela sammanslagna celler efter rad- eller kolumnspann**

För att förbereda sammanslagna mallceller för datainmatning, använd [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) för att dela längs en befintlig radgräns, eller [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) för att dela längs en kolumngräns.

`index`-argumentet räknar rader i den övre delen eller kolumner i den vänstra delen av delningen; det är relativt till det sammanslagna området:

- Raddelning: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Kolumndelning: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

Exemplet förutsätter att en presentation har en tabell som den första formen på den första bilden, med `(1, 2)` och `(1, 3)` sammanslagna vertikalt. Med start från den nedre positionen använder det [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) och [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) för att lokalisera ursprunget och kontrollerar båda spannen. `splitByRowSpan(1)` separerar sedan raderna 2 och 3 för produktnamn. För en horisontell tvåkolumnssammanslagning, använd `splitByColSpan(1)` istället.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // Hämta de resulterande cellerna från tabellen efter delning.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Tabellrutnätet och omkringliggande cellindex förblir oförändrade. Hämta de resulterande cellerna med deras koordinater; här har båda spännvidder på 1 och [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) skriver ut `false`. Större områden kan förbli delvis sammanslagna efter en delning.

Den ursprungliga texten och dess formatering kvarstår i den övre (eller vänstra) cellen; den nya cellen är tom men ärver cellformatering såsom fyllning, kanter och marginaler. Fyll i cellerna efter delning och ange eventuell nödvändig textformatering explicit.

Den sparade presentationen innehåller separata "Product A"- och "Product B"-celler med mallens cellformatering bevarad. Se [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) för detaljer.

## **Ändra tabellcellens bakgrundsfärg**

Detta exempel skapar en tabell med 150‑punkts kolumner och 50‑punkts rader. Det använder [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) för att välja en solid fyllning och sätter färgen som returneras av [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) till röd för cell `(2, 3)`, i den tredje kolumnen och fjärde raden.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lägg till en bild i en tabellcell**

Placera inmatningsbilden i arbetskatalogen innan du kör detta exempel. Den läser in bilden med [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) och lägger till den i presentationens bildsamling med [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Därefter tilldelas bilden som bildfyllning för cell `(0, 0)`, den första cellen i tabellen.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) sträcker bilden för att fylla cellen, vilket kan ändra dess bildförhållande. Kolumnbredder och radhöjder är i punkter. Den inlästa bilden frigörs i en `finally`-block efter att den har lagts till i presentationen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan jag ange olika linjetjocklekar och stilar för de olika sidorna av en enskild cell?**

Ja. [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) kanterna har separata egenskaper, så tjockleken och stilen för varje sida kan vara olika.

**Vad händer med bilden om jag ändrar kolumn-/radstorleken efter att ha ställt in en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/). Vid streching anpassas bilden till den nya cellen; vid tiling beräknas brickorna om.

**Kan jag tilldela en hyperlänk till allt innehåll i en cell?**

[Hyperlinks](/slides/sv/androidjava/manage-hyperlinks/) sätts på textraden (portion) nivå inne i cellens textruta eller på hela tabellens/formens nivå. I praktiken tilldelar du länken till en del eller till all text i cellen.

**Kan jag ange olika teckensnitt inom en enda cell?**

Ja. En cells textruta stödjer [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (körningar) med oberoende formatering—teckensnittsfamilj, stil, storlek och färg.