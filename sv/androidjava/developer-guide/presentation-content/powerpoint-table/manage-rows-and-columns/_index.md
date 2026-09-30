---
title: Hantera rader och kolumner i PowerPoint-tabeller på Android
linktitle: Rader och kolumner
type: docs
weight: 20
url: /sv/androidjava/manage-rows-and-columns/
keywords:
- tabellrad
- tabellkolumn
- första rad
- tabellrubrik
- klona rad
- klona kolumn
- kopiera rad
- kopiera kolumn
- ta bort rad
- ta bort kolumn
- radtextformatering
- kolumntextformatering
- tabellstil
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Hantera tabellrader och -kolumner i PowerPoint med Aspose.Slides för Android via Java och snabba upp redigering av presentationer samt datauppdateringar."
---
## **Introduktion**

Aspose.Slides for Android via Java låter dig hantera tabellstruktur och formatering i PowerPoint‑presentationer via klassen [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) och gränssnittet [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Du kan ange en rubrikrad, klona eller ta bort rader och kolumner samt tillämpa textformatering på en hel rad eller kolumn.

Denna artikel förklarar dessa operationer med Java‑exempel. Den visar också hur du hämtar ett tabellstils‑preset så att du kan återanvända det. Tabellrad‑ och kolumnindex är nollbaserade.

## **Styr radens höjd**

Använd [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) för att ange en rads minsta höjd i punkter. Det är en lägre gräns, inte en fast höjd. [IRow.getHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#getHeight--) returnerar den faktiska höjden. Få åtkomst till raden via [ITable.getRows](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getRows--).

Exemplet laddar [row-height-input.pptx](row-height-input.pptx), som har en tabell som den första formen på den första bilden. Den första raden börjar på 70 punkter. Cellerna använder 18‑punkts Arial‑text, radbrytning och 6‑punkts marginaler högst och längst ner; den längre texten i den andra kolumnen radbryts på flera rader. Exemplet ökar minimum till 100 punkter, minskar sedan till 20 punkter, skriver ut den faktiska höjden efter varje förändring och sparar båda resultaten.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Med den medföljande presentationen lägger ökning av minimum till extra utrymme i raden. Minskning tar bort det extra utrymmet, men den faktiska höjden förblir större än 20 punkter eftersom texten och cellmarginalerna kräver mer utrymme. Att bara minska minimum kan inte tvinga raden under det utrymme som dess innehåll kräver.

Flera faktorer påverkar den faktiska höjden:

- **Text och teckenstorlek:** längre text, explicita radbrytningar eller en större teckenstorlek kan kräva mer vertikalt utrymme.
- **Radbrytning och kolumnbredd:** med radbrytning aktiverad kan minskning av kolumnbredden med [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) producera fler rader. En bredare kolumn kan minska det vertikala utrymmet som behövs.
- **Cellmarginaler:** [ICell.setMarginTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginTop-double-) och [ICell.setMarginBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginBottom-double-) lägger till vertikalt utrymme. [ICell.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginLeft-double-) och [ICell.setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginRight-double-) minskar bredden tillgänglig för text och kan orsaka ytterligare radbrytning.

För den här tabellen utan sammanslagna celler avgör den cell som kräver mest vertikalt utrymme den innehållsdrivna lägre gränsen för hela raden. För att göra raden kortare kan du även behöva förkorta texten, minska teckenstorleken eller marginalerna, eller bredda en kolumn.

Bilderna nedan visar samma tabell i samma skala. I de illustrerade resultaten var de faktiska höjderna 70, 100 och 55.2 punkter: den sista raden förblev högre än dess 20‑punkts minimum. Exakta textmått kan variera beroende på vilka teckensnitt som finns i din miljö. Ladda ner de sparade resultaten: [increased minimum](row-height-increased.pptx) och [decreased minimum](row-height-decreased.pptx).

| Original: minimum 70 pt, actual 70 pt | Increased: minimum 100 pt, actual 100 pt | Decreased: minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![Originaltabell med en första rad på 70 punkter.](row-height-before.png) | ![Tabell efter att ha ökat minimihöjden för första raden till 100 punkter.](row-height-increased.png) | ![Tabell efter att ha minskat minimihöjden för första raden till 20 punkter; radbrytande text håller raden högre än minimum.](row-height-decreased.png) |

## **Ange första raden som rubrik**

Använd metoden [setFirstRow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setFirstRow-boolean-) för att markera den första raden för rubrikformatering. Dess utseende beror på den tabellstil som tillämpas på tabellen.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Hämta den första bilden.
3. Hämta tabellen som är lagrad som den första formen på bilden.
4. Aktivera rubrikformatering för dess första rad.
5. Spara den ändrade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden. Det aktiverar rubrikformatering för den första raden och sparar `First_row_header.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Klona en tabellrad eller -kolumn**

Kopiera rader eller kolumner för att återanvända deras innehåll och formatering. Du kan lägga till en kopia i slutet av tabellen eller infoga den på en specifik position.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Hämta den första bilden.
3. Definiera kolumnbredder och radhöjder.
4. Lägg till en tabell med metoden [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Klona de behövda raderna.
6. Klona de behövda kolumnerna.
7. Spara den ändrade presentationen.

Exemplet kräver `Test.pptx` med minst en bild. Det skapar en tabell med tre kolumner och fem rader, med dimensioner angivna i punkter. Det lägger till kopior av den första raden och kolumnen, och infogar sedan kopior av den andra raden och kolumnen på index 3 (den fjärde positionen). Den resulterande tabellen har sju rader och fem kolumner. Argumentet `false` inaktiverar kloning till intilliggande sammanslagna rader eller kolumner; den här tabellen har inga sammanslagna celler.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ta bort en rad eller kolumn från en tabell**

Ta bort rader eller kolumner som inte längre behövs i en tabell. När ett objekt tas bort flyttas indexen för de rader eller kolumner som följer efter.

1. Skapa en presentation med klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Hämta den första bilden.
3. Definiera kolumnbredder och radhöjder.
4. Lägg till en tabell med metoden [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Ta bort den andra raden och den andra kolumnen.
6. Spara den ändrade presentationen.

Detta exempel skapar en tre‑gånger‑tre tabell och tar bort raden och kolumnen på index 1, vilket lämnar en två‑gånger‑två tabell i `TestTable_out.pptx`. Dimensionerna är i punkter. Argumentet `false` inaktiverar borttagning av intilliggande sammanslagna rader eller kolumner; den här tabellen har inga sammanslagna celler.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ange textformatering på radnivå i tabellen**

Använd textformatering på en hel rad för att hålla dess celler konsekventa. Du kan ange teckensegenskaper, styckeformatering och textriktning utan att formatera varje cell individuellt.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Hämta tabellen på den första bilden.
3. Använd [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) för den första raden.
4. Använd [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) och [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) för den första raden.
5. Använd [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) för den andra raden.
6. Spara den ändrade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden och minst två rader. Det använder 25‑punkts text, högerjustering och ett 20‑punkts högermarginal i stycket för den första raden, och ställer sedan in vertikal text i den andra raden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ange textformatering på kolumnnivå i tabellen**

Använd textformatering på en hel kolumn för att hålla dess celler konsekventa. Du kan ange teckensegenskaper, styckeformatering och textriktning utan att formatera varje cell individuellt.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Hämta tabellen på den första bilden.
3. Använd [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) för den första kolumnen.
4. Använd [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) och [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) för den första kolumnen.
5. Använd [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) för den andra kolumnen.
6. Spara den ändrade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden och minst två kolumner. Det använder 25‑punkts text, högerjustering och ett 20‑punkts högermarginal i stycket för den första kolumnen, och sätter sedan vertikal text i den andra kolumnen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hämta tabellstilsegenskaper**

Använd metoden [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) för att hämta den förinställning som tillämpats på en tabell och återanvända den på en annan tabell. Detta identifierar förinställningen snarare än enskilda cellers formatöverskrivningar.

Exemplet skapar en tabell, tillämpar [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/#DarkStyle1) och läser tillbaka förinställningen. Det skriver ut heltalsvärdet som motsvarar `DarkStyle1` och sparar tabellen i `table.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan jag tillämpa PowerPoint‑teman/stilar på en tabell som redan skapats?**

Ja. Tabellen ärver slide/layout/master‑temat och du kan fortfarande åsidosätta fyllningar, kanter och textfärger ovanpå det temat.

**Kan jag sortera tabellrader som i Excel?**

Nej, Aspose.Slides‑tabeller har ingen inbyggd sortering eller filter. Sortera dina data i minnet först, och fyll sedan tabellraderna i den ordningen.

**Kan jag ha bandade (randiga) kolumner samtidigt som jag behåller anpassade färger på specifika celler?**

Ja. Aktivera bandade kolumner, och åsidosätt sedan specifika celler med lokal formatering; formatering på cellnivå har företräde framför tabellstilen.