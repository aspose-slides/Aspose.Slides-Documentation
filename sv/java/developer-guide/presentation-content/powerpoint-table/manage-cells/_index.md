---
title: Hantera tabellceller i presentationer med Java
linktitle: Hantera celler
type: docs
weight: 30
url: /sv/java/manage-cells/
keywords:
- tabellcell
- sammanslå celler
- ta bort ram
- dela cell
- bild i cell
- bakgrundsfärg
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Hantera PowerPoint-tabellceller i Java: identifiera sammanslagna celler, ta bort ramar, dela celler och sätt bakgrundsfärger samt bilder med Aspose.Slides för Java."
---
## **Översikt**

Aspose.Slides låter dig komma åt och ändra tabellceller i PowerPoint-presentationer. Den här artikeln förklarar hur du identifierar sammanslagna tabellceller, tar bort cellramar, arbetar med cellnumrering efter sammanslagning eller delning av celler, ändrar en cells bakgrundsfärg och lägger till en bild i en tabellcell. Exemplen visar hur du skapar eller öppnar en presentation, hämtar en tabell från en bild, uppdaterar cellformatering via cellegenskaper och sparar den ändrade presentationen som en PPTX‑fil.

Aspose.Slides använder nollbaserade index för att komma åt tabellceller i ordningen `(column, row)`.

## **Identifiera en sammanslagen tabellcell**

Exemplet öppnar en befintlig presentation och får åtkomst till den första formen på den första bilden som en tabell. Det förutsätter att bilden och formen finns och att formen är en tabell. Därefter itererar det genom alla rader och kolumner och använder [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) för att identifiera celler i sammanslagna områden. För varje träff skriver det ut cellens koordinater i `row;column`‑ordning, [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--), och områdets startkoordinater, [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) och [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--).

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

## **Ta bort tabellcellramar**

Skapa en [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) och lägg till en tabell på dess första bild med [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Kolumnbredder, radhöjder och tabellens position anges i punkt. Exemplet sätter alla fyra cellramar till [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/), vilket gör dem osynliga.

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

## **Lägg till diagonala cellramar**

Använd [getBorderDiagonalDown](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalDown--) för att rita en linje från det övre vänstra hörnet till det nedre högra, och [getBorderDiagonalUp](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalUp--) för att rita en linje från det nedre vänstra hörnet till det övre högra. En diagonal kan markera ett hörnuttryck; båda diagonalerna kan bilda ett X för att markera att en cell inte är tillämplig.

Varje diagonal är ett [ILineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/). I dess [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) använder du [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) för att välja [FillType.Solid](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) och välja en färg via [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--). Ställ in linjens bredd i punkt med [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-).

Exemplet skapar tre celler i en rad: en röd diagonal nedåt, en blå diagonal uppåt och båda diagonalerna. Det lämnar de övre, nedre, vänstra och högra cellramarna oförändrade.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

En diagonal är en formateringsegenskap, inte en celluppdelning. Varje cell behåller en enda textruta, som nås via [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--); områdena på vardera sidan av en diagonal kan inte redigeras separat.

Den sparade tabellen, renderad i Microsoft PowerPoint:

![Tre tabellceller som visar en röd diagonal från övre vänstra till nedre högra, en blå diagonal från nedre vänstra till övre högra, och båda diagonalerna som bildar ett X.](diagonal-cell-borders.png)

*Från vänster till höger: nedåtriktad diagonal (röd, 3 pt), uppåtriktad diagonal (blå, 5 pt) och båda diagonalerna.*

## **Sammanfoga tabellceller**

Använd [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) för att kombinera ett rektangulärt område av tabellceller till en cell. Ange cellerna i det övre vänstra och nedre högra hörnet av området. Det sista argumentet styr om sammanslagningen får inkludera celler utanför det angivna området; `false` håller sammanslagningen inom det området.

Exemplet skapar en 4×4‑tabell med 70‑punkt kolumner och rader, och sammanslår sedan de fyra centrala cellerna från `(1, 1)` till `(2, 2)`. Den resulterande cellen spänner över två kolumner och två rader, medan tabellens underliggande rutnät behåller fyra kolumner och fyra rader. För att komma åt den sammanslagna cellens innehåll eller formatering, använd dess övre vänstra position: `table.get_Item(1, 1)` i detta exempel. De andra positionerna i det sammanslagna området förblir en del av tabellrutnätet, så indexen för celler utanför området ändras inte.

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

Sammanslagning av celler i det föregående exemplet bevarar tabellens rutnät. Att dela en cell kan introducera en ny rutnätskolumn och ändra kolumnindex för cellerna till höger om den. Aspose.Slides följer PowerPoints tabellrutnätsmodell.

Detta exempel skapar en 4×4‑tabell med 70‑punkts kolumner och rader och anropar [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) på cell `(1, 1)`. Halva cellens 70‑punkts bredd skickas för att skapa två lika breda celler.

Efter denna delning nås de två halvorna som `table.get_Item(1, 1)` och `table.get_Item(2, 1)`. Tabellrutnätet har nu fem kolumner: celler som ursprungligen var i kolumn 2 och 3 flyttas till kolumn 3 respektive 4. Radrubriker förblir oförändrade. Använd dessa uppdaterade kolumnindex när du får åtkomst till celler efter delningen.

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

<!-- visual-explanation:manage-cells:start -->
[![En icke‑sammanfogad 70‑punkts cell delas i två 35‑punkts celler, vilket lägger till en femte rutnätskolumn och förskjuter indexen till höger.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Bredddelningen påverkar cell (1, 1), med nollbaserade (column, row)-index. Andra rader behåller en cell som sträcker sig över båda nya kolumnpositionerna.*
<!-- visual-explanation:manage-cells:end -->

### **Dela sammanslagna celler efter rad‑ eller kolumnspann**

För att förbereda sammanslagna mallceller för datainmatning, använd [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) för att dela längs en befintlig radgräns, eller [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) för att dela längs en kolumngräns.

`index`‑argumentet räknar rader i den övre delen eller kolumner i den vänstra delen av delningen; det är relativt till det sammanslagna området:

- Raddelning: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- Kolumndelning: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

Exemplet förutsätter att en presentation har en tabell som den första formen på den första bilden, med `(1, 2)` och `(1, 3)` sammanslagna vertikalt. Med start från den lägre positionen använder det [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) och [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) för att hitta ursprunget och kontrollerar båda spannen. `splitByRowSpan(1)` delar sedan raderna 2 och 3 för produktnamn. För en horisontell två‑kolumnssammanslagning, använd `splitByColSpan(1)` istället.

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

Tabellrutnätet och omgivande cellindex förblir oförändrade. Hämta de resulterande cellerna via deras koordinater; här har båda en spann på 1 och [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) skriver ut `false`. Större områden kan förbli delvis sammanslagna efter en delning.

Den ursprungliga texten och dess formatering förblir i den övre (eller vänstra) cellen; den nya cellen är tom men ärver cellformatering såsom fyllning, ramar och marginaler. Fyll i cellerna efter delning och ange eventuell nödvändig textformatering explicit.

Den sparade presentationen innehåller separata “Product A” och “Product B”-celler med mallens cellformatering bevarad. Se [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) för detaljer.

### **Dela en cell vid en specifik höjd**

[splitByHeight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByHeight-double-) tar höjden på den övre delen i punkt. [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) tar antalet befintliga rutnätsrader i den övre delen. För att centrera en 40‑punkts cell i den högra kolumnen, subtrahera 40 från cellens faktiska höjd och dela det återstående utrymmet lika ovan och nedanför den.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };
    
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Den första delningen lägger till en rutnätsrad och lämnar de nedre 90 punkterna i cell `(1, 1)`. Den andra delningen delar den cellen i en 40‑punkts mittcell och en 50‑punkts bottencell. Den högra kolumnen har nu tre celler med höjderna 50, 40 och 50 punkt från topp till botten. Den vänstra cellen sträcker sig över alla tre rader och behåller sin ursprungliga höjd på 140 punkt.

![Den vänstra cellen sträcker sig över hela tabellens höjd bredvid tre celler med Mitt i centrum.](split-by-height.png)

## **Ändra tabellcellens bakgrundsfärg**

Detta exempel skapar en tabell med 150‑punkt kolumner och 50‑punkt rader. Det använder [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) för att välja en solid fyllning och sätter färgen som returneras av [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) till röd för cell `(2, 3)`, i den tredje kolumnen och fjärde raden.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Sätt in inmatningsbilden i arbetskatalogen innan du kör detta exempel. Den laddar bilden med [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) och lägger till den i presentationens bildsamling med [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Den tilldelar sedan bilden till bildfyllningen för cell `(0, 0)`, den första cellen i tabellen.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) sträcker bilden för att fylla cellen, vilket kan ändra bildförhållandet. Kolumnbredder och radhöjder anges i punkt. Den inlästa bilden frigörs i ett `finally`‑block efter att den har lagts till i presentationen.

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

## **Vanliga frågor**

**Kan jag ange olika linjetjocklekar och stilar för olika sidor av en enskild cell?**

Ja. [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) ramarna har separata egenskaper, så tjocklek och stil för varje sida kan skilja sig.

**Vad händer med bilden om jag ändrar kolumn‑/radrstorleken efter att ha ställt in en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/). Vid sträckning anpassas bilden till den nya cellen; vid plattläggning (tiling) beräknas plattorna om.

**Kan jag tilldela en hyperlänk till allt innehåll i en cell?**

[Hyperlinks](/slides/sv/java/manage-hyperlinks/) sätts på textnivå (portion) i cellens textruta eller på hela tabellens/figurens nivå. I praktiken tilldelar du länken till en portion eller till all text i cellen.

**Kan jag ange olika typsnitt inom en enda cell?**

Ja. En cells textram stödjer [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (runs) med oberoende formatering — typsnittsfamilj, stil, storlek och färg.