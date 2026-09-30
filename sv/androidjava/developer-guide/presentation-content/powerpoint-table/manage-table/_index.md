---
title: Hantera presentationstabeller på Android
linktitle: Hantera tabell
type: docs
weight: 10
url: /sv/androidjava/manage-table/
keywords:
- lägga till tabell
- skapa tabell
- komma åt tabell
- bildförhållande
- justera text
- textformatering
- tabellstil
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Skapa och redigera tabeller i PowerPoint-bilder med Aspose.Slides för Android. Upptäck enkla Java-kodexempel för att effektivisera dina tabellarbetsflöden."
---
## **Introduktion**

Tabeller i PowerPoint organiserar information i rader och kolumner, vilket gör det enklare att läsa och jämföra värden.

Aspose.Slides tillhandahåller klassen [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) , gränssnittet [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) , klassen [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) , gränssnittet [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) och andra typer för att låta dig skapa, uppdatera och hantera tabeller i presentationer.

## **Skapa en tabell från grunden**

Skapa en tabell genom att ange dess position, kolumnbredder och radhöjder. Efter att ha lagt till den på en bild kan du formatera cellramar, slå ihop celler och infoga text.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Hämta en referens till bilden med dess index.
3. Definiera en array med kolumnbredder i punkter.
4. Definiera en array med radhöjder i punkter.
5. Lägg till ett [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/)-objekt på bilden via metoden [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Iterera genom varje [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) för att applicera formatering på de övre, nedre, högra och vänstra ramarna.
7. Slå ihop de två första cellerna i tabellens första rad.
8. Åtkomst till den sammanslagna cellen via dess [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--)‑metod.
9. Ange texten i den sammanslagna cellen.
10. Spara den ändrade presentationen.

Exemplet nedan skapar en tabell med tre kolumner och fem rader vid (100, 50) punkter. Det applicerar röda ramar med en bredd på 5 punkter, slår ihop de två första cellerna i den första raden och sparar resultatet som `table.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Numrering i en standardtabell**

I en standardtabell är cellindex nollbaserade och använder ordningen (kolumn, rad). Den första cellen har index (0, 0).

Till exempel numreras cellerna i en tabell med 4 kolumner och 4 rader på följande sätt:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Detta exempel skapar 4 × 4‑tabellen som illustreras ovan, med kolumnbredder och radhöjder på 70 punkter samt röda cellramar med en bredd på 5 punkter. Koordinaterna visar cellindex; exemplet lämnar cellerna tomma och sparar tabellen som `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Åtkomst till en befintlig tabell**

Tabeller lagras i en bilds formkolektion. Iterera genom formerna för att hitta en tabell, använd sedan [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/)‑gränssnittet för att läsa eller uppdatera dess celler.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Hämta en referens till bilden som innehåller tabellen via dess index.
3. Iterera genom [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)-objekten och stoppa när en tabell hittas. Om bilden innehåller flera tabeller, använd [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) för att identifiera den du behöver.
4. Uppdatera texten i målcell.
5. Spara den ändrade presentationen.

Exemplet nedan öppnar `UpdateExistingTable.pptx` och hittar den första tabellen på den första bilden. Det anger cellen i kolumn 0, rad 1 till `New` och sparar resultatet som `table1_out.pptx`. Inmatningen måste innehålla minst en bild, och den första tabellen på den bilden måste ha minst en kolumn och två rader.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

För att ändra storlek på en rad i en befintlig tabell och förstå varför dess faktiska höjd kan överstiga det begärda minimumet, se [Kontrollera radhöjd](/slides/sv/androidjava/manage-rows-and-columns/#control-row-height).

## **Hitta cellen som äger en textram**

När generisk textbearbetningskod mottar ett [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) från en tabell, använd metoden [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) för att hämta den ägande [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/). För ett tabell‑cell‑textram returnerar [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) ägaren och [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) returnerar `null`, även om tabellen själv är en form.

Cellkoordinaterna är tillgängliga via de skrivskyddade metoderna [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) och [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--). [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) ger också skrivskyddad navigation: den returnerar ägaren men förändrar inte ägarskapet. Kontrollera alltid den returnerade cellen för `null` innan du använder den.

För ett komplett exempel som identifierar tabell‑cell‑ och form‑ägare, inklusive former kopplade till SmartArt‑noder, se [Sök och ersätt text](/slides/sv/androidjava/search-and-replace-text/).

## **Justera text i en tabell**

Du kan kontrollera vertikal förankring och textriktning för enskilda tabellceller. Exemplet i detta avsnitt centrerar text i den första cellen och roterar den 270 grader.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Hämta en referens till bilden med dess index.
3. Lägg till ett [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/)-objekt på bilden.
4. Åtkomst till ett [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)-objekt från tabellen.
5. Åtkomst till det första [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) och ange dess text och färg.
6. Ställ in cellens vertikala förankring och textriktning med [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) och [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-).
7. Spara den ändrade presentationen.

Detta exempel skapar en 4 × 4‑tabell med kolumnbredder på 120 punkter och radhöjder på 100 punkter. Det formaterar texten i cell (0, 0), lägger till värden i de återstående cellerna i den första raden och sparar resultatet som `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in textformatering på tabellnivå**

Använd [setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) för att applicera textformatering på alla celler i en tabell. Dess överlagringar accepterar formatering för del, paragraf och textram, så du kan ange dessa egenskaper utan att iterera genom enskilda celler.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Hämta en referens till bilden med dess index.
3. Åtkomst till ett [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/)-objekt från bilden.
4. Ställ in teckenstorleken med [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) för texten.
5. Ställ in paragrafjustering och högermarginal med [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) och [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Ställ in textriktning med [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Spara den ändrade presentationen.

Exemplet nedan öppnar `table.pptx`, som måste innehålla minst en bild med en tabell som sin första form. Det anger teckenstorleken till 25 punkter, högerjusterar paragrafer med en högermarginal på 20 punkter och gör texten vertikal. Den formaterade presentationen sparas som `result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hämta tabellstilsegenskaper**

Använd [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) för att läsa en tabells förinställda stil och [setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) för att tilldela den. Detta exempel tillämpar [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) på en tabell, skriver ut det förinställda värdet och tilldelar samma förinställning till en andra tabell. Båda tabellerna sparas i `table-style.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lås bildförhållandet för en tabell**

En tabells bildförhållande är förhållandet mellan dess bredd och höjd. Använd [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) för att låsa detta förhållande för en tabell.

Exemplet nedan öppnar `pres.pptx`, som måste innehålla minst en bild med en tabell som sin första form. Det skriver ut det aktuella låstillståndet, aktiverar låsningen av bildförhållandet, skriver ut det uppdaterade tillståndet (`true`) och sparar resultatet som `pres-out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan jag aktivera läsriktning från höger till vänster (RTL) för en hel tabell och texten i dess celler?**

Ja. Tabellen exponerar en [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-)‑metod, och stycken har [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Genom att använda båda säkerställs korrekt RTL‑ordning och rendering i cellerna.

**Hur kan jag förhindra att användare flyttar eller ändrar storlek på en tabell i den slutliga filen?**

Använd [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) för att inaktivera flytt, storleksändring, urval osv. Dessa lås gäller även för tabeller.

**Stöds det att infoga en bild i en cell som bakgrund?**

Ja. Du kan ange en [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) för en cell; bilden täcker cellområdet enligt valt läge (sträcka eller mosaik).