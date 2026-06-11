---
title: Hantera tabellceller i presentationer med Java
linktitle: Hantera celler
type: docs
weight: 30
url: /sv/java/manage-cells/
keywords:
- tabellcell
- sammanfoga celler
- ta bort ram
- dela cell
- bild i cell
- bakgrundsfärg
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Hantera tabellceller i PowerPoint med Aspose.Slides för Java utan ansträngning. Bli skicklig på att snabbt komma åt, ändra och formatera celler för sömlös bildspelsautomatisering."
---
## **Översikt**

Aspose.Slides låter dig komma åt och ändra tabellceller i PowerPoint-presentationer. Den här artikeln förklarar hur du identifierar sammanslagna tabellceller, tar bort cellramar, arbetar med cellnumrering efter sammanslagning eller delning av celler, ändrar en cells bakgrundsfärg och lägger till en bild i en tabellcell. Exemplen visar hur du skapar eller öppnar en presentation, hämtar en tabell från en bild, uppdaterar cellformatering via cellens egenskaper och sparar den modifierade presentationen som en PPTX‑fil.

## **Identifiera en sammanslagen tabellcell**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta tabellen från den första bilden. 
3. Iterera genom tabellens rader och kolumner för att hitta sammanslagna celler.
4. Skriv ut ett meddelande när sammanslagna celler hittas.

Den här Java‑koden visar hur du identifierar sammanslagna tabellceller i en presentation:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // antar att Slide#0.Shape#0 är en tabell
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ta bort tabellcellramar**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index. 
3. Definiera en array av kolumner med bredd.
4. Definiera en array av rader med höjd.
5. Lägg till en tabell på bilden via metoden [addTable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Iterera genom varje cell för att rensa de övre, nedre, högra och vänstra ramarna.
7. Spara den ändrade presentationen som en PPTX‑fil.

Den här Java‑koden visar hur du tar bort ramarna från tabellceller:

```java
// Instansierar Presentation-klassen som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Definierar kolumner med bredder och rader med höjder
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Lägger till tabellform på bilden
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ställer in kantformat för varje cell
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // Skriver PPTX-filen till disk
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numrering i sammanslagna celler**

Om vi slår ihop 2 par celler (1, 1) × (2, 1) och (1, 2) × (2, 2) blir den resulterande tabellen numrerad. Den här Java‑koden demonstrerar processen:

```java
// Instansierar Presentation-klass som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Definierar kolumner med bredder och rader med höjder
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Lägger till ett tabellobjekt på bilden
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ställer in kantformat för varje cell
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Slår ihop celler (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Slår ihop celler (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Vi slår sedan ihop cellerna ytterligare genom att slå samman (1, 1) och (1, 2). Resultatet är en tabell som innehåller en stor sammanslagen cell i mitten: 

```java
// Instansierar Presentation-klassen som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Definierar kolumner med bredder och rader med höjder
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Lägger till ett tabellobjekt på bilden
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ställer in kantformat för varje cell
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
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
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numrering i en delad cell**
I tidigare exempel, när tabellceller slogs ihop, ändrades inte numreringen eller siffersystemet i de andra cellerna. 

Denna gång tar vi en vanlig tabell (en tabell utan sammanslagna celler) och försöker sedan dela cell (1,1) för att få en speciell tabell. Du kanske vill uppmärksamma tabellens numrering, som kan uppfattas som märklig. Men så numererar Microsoft PowerPoint tabellceller och Aspose.Slides gör samma sak. 

Den här Java‑koden demonstrerar den process vi beskrev:

```java
// Instansierar Presentation-klassen som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Definierar kolumner med bredder och rader med höjder
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Lägger till en tabellform på bilden
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ställer in kantformat för varje cell
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
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
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ändra tabellcellens bakgrundsfärg**

Den här Java‑koden visar hur du ändrar en tabellcells bakgrundsfärg:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // skapa en ny tabell
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // sätt bakgrundsfärgen för en cell 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Lägg till en bild i en tabellcell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Definiera en array av kolumner med bredd.
4. Definiera en array av rader med höjd.
5. Lägg till en tabell på bilden via metoden [AddTable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Skapa ett `Images`‑objekt för att lagra bildfilen.
7. Lägg till bilden `IImage` i `IPPImage`‑objektet.
8. Ställ in `FillFormat` för tabellcellen till `Picture`.
9. Lägg till bilden i tabellens första cell.
10. Spara den ändrade presentationen som en PPTX‑fil

Den här Java‑koden visar hur du placerar en bild i en tabellcell när du skapar en tabell:

```java
// Instansierar Presentation-klassen som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden
    ISlide islide = pres.getSlides().get_Item(0);

    // Definierar kolumner med bredder och rader med höjder
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Lägger till en tabellform på bilden
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Skapa ett IPPImage-objekt med bildfilen
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Lägger till bilden i den första tabellcellen
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Sparar PPTX-filen till disk
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan jag ange olika linjetjocklekar och stilar för olika sidor av en enda cell?**

Ja. [top](https://reference.aspose.com/slides/sv/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/sv/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/sv/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/sv/java/com.aspose.slides/cellformat/#getBorderRight--) ramar har separata egenskaper, så tjocklek och stil för varje sida kan skilja sig åt. Detta följer logiskt av kontrollen för kant per sida för en cell som demonstreras i artikeln.

**Vad händer med bilden om jag ändrar kolumn-/radstorleken efter att jag har ställt in en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/sv/java/com.aspose.slides/picturefillmode/) (stretch/tile). Vid sträckning anpassas bilden till den nya cellen; vid upprepning beräknas rutorna om. Artikeln nämner bildvisningslägen i en cell.

**Kan jag tilldela en hyperlänk till allt innehåll i en cell?**

[Hyperlinks](/slides/sv/java/manage-hyperlinks/) sätts på text‑(portion)‑nivå inne i cellens textruta eller på hela tabellens/figurens nivå. I praktiken tilldelar du länken till en del eller till all text i cellen.

**Kan jag ange olika teckensnitt i en enda cell?**

Ja. En cells textruta stöder [portions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/) (körningar) med oberoende formatering—teckensnittsfamilj, stil, storlek och färg.