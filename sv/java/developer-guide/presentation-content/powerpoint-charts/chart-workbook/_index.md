---
title: Hantera diagramarböcker i presentationer med Java
linktitle: Diagramarbok
type: docs
weight: 70
url: /sv/java/chart-workbook/
keywords:
- diagramarbok
- diagramdata
- arbetsbokscell
- datamärkning
- arbetsblad
- datakälla
- extern arbetsbok
- extern data
- diagramcache
- arbetsboksåterställning
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Upptäck Aspose.Slides för Java: hantera enkelt diagramarböcker i PowerPoint- och OpenDocument-format för att effektivisera dina presentationsdata."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur man läser och skriver diagramdata via arbetsbokströmmar, använder arbetsboks-celler som diagramdatamärkningar, får åtkomst till arbetsbladssamlingar och specificerar datakälltyp för diagramvärden.

Den behandlar också arbete med externa arbetsböcker som diagramdatakällor. Exemplen demonstrerar hur man skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkad till ett diagram och redigerar diagramdata när arbetsboken är tillgänglig.

För arbetsboks-celler som representerar saknad data, se [Styr visning av tomma celler](/slides/sv/java/chart-series/) för skillnaden mellan en tom cell och noll, samt en linjediagramjämförelse av de tillgängliga visningslägena.

## **Inkludera data från dolda rader och kolumner**

Använd [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) för att styra om ett diagram plottar data från dolda arbetsbladsrader och -kolumner. Ställ in den på `true` för att plotta endast synliga celler, eller `false` för att inkludera både synliga och dolda celler. Denna inställning styr diagrammets plottering; den döljer eller visar inte arbetsbladsrader eller -kolumner.

[Sample presentation](hidden-source-data.pptx) innehåller ett stapeldiagram som det första objektet på första bilden. Det inbäddade arbetsbladet, `Sheet1`, innehåller följande källintervall, `A1:C4`. Rad 3 och kolumn C är dolda, men deras celler innehåller fortfarande värden.

| Arbetsbladsrad | A: Månad | B: Detaljhandel | C: Partihandel (dold kolumn) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (dold rad) | Februari | 40 | 60 |
| 4 | Mars | 20 | 50 |

Få åtkomst till källceller via [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) och läs [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) för att inspektera deras dolda status. Denna metod rapporterar den dolda statusen utan att ändra den. I den här filen är B2 synlig, B3 tillhör den dolda raden och C2 tillhör den dolda kolumnen; exemplet skriver ut `false`, `true` och `true` respektive.

För detta exempel, uppdatera diagramdata efter att plottningsinställningen ändrats: behåll den inbäddade arbetsboken med [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) och läs in den igen med [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). När alla celler inkluderas, använd också [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) för att återställa hela intervallet, inklusive den dolda februari-kategorin. Att bara ändra flaggan är otillräckligt för att uppdatera detta exempelens cachade diagramdata och kategorimärkningar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Uppdatera diagramdata från den inbäddade arbetsboken.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Återställ hela källintervallet, inklusive dolda kategorier.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Exemplet sparar två versioner av presentationen: en med endast de synliga detaljhandelsvärdena (10 och 20) och en med alla sex värden. Bilderna nedan illustrerar de två plottningslägena. Rad 3 och kolumn C förblir dolda i båda inbäddade arbetsböckerna.

| Endast synliga celler (`true`) | Alla celler (`false`) |
| --- | --- |
| ![Endast synliga celler: Detaljhandelsvärden 10 och 20 för Januari och Mars.](hidden_cells_True.png) | ![Alla celler: Detaljhandel och Partihandel för Januari, Februari och Mars.](hidden_cells_False.png) |

En dold cell som innehåller ett värde skiljer sig från en tom cell. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) styr hur saknade värden visas; den inkluderar eller exkluderar inte dolda källdata. Se [Styr visning av tomma celler](/slides/sv/java/chart-series/#control-the-display-of-empty-cells) för ett exempel.

## **Hämta ett diagramdatas intervall**

Innan du uppdaterar arbetsboksdata i en befintlig presentation, inspektera källintervallen för att identifiera vilka arbetsblads-celler varje diagram använder. Metoden [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) returnerar det aktuella dataintervallet som en arbetsblads-kvalificerad formel, t.ex. `Sheet1!$A$1:$D$5`. Här är `Sheet1` arbetsbladsnamnet, `!` separerar det från cellintervallet, och `$A$1:$D$5` identifierar cellerna A1 till D5, inklusive. Dollartecknen indikerar absoluta rad- och kolumnreferenser.

Metoden läser det aktuella intervallet utan att ändra diagrammet eller dess arbetsbok. Om diagrammet inte använder en arbetsbok som datakälla kastar den `InvalidOperationException`. För mer information, se [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/).

Detta exempel öppnar en presentation och kontrollerar formerna direkt på varje bild för diagram. Det skriver ut varje diagramnamn och källintervall. Om ett diagram inte använder en arbetsbok skriver det ett meddelande och fortsätter till nästa diagram.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Läsa och skriva diagramdata från en arbetsbok**

Aspose.Slides for Java tillhandahåller metoderna [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) och [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) som låter dig läsa och skriva diagramdataarbetsböcker (innehållande diagramdata redigerade med Aspose.Cells). **Obs** att diagramdata måste vara organiserad på samma sätt eller ha en liknande struktur som källan.

Detta exempel använder en presentation med ett diagram som det första objektet på första bilden. Det läser den inbäddade arbetsboken till en bytearray, rensar befintliga serier och kategorier och skriver tillbaka samma arbetsbok. Ändringarna finns kvar i minnet; exemplet sparar inte presentationen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Validera diagramlayout efter arbetsboksändring**

När du ersätter en inbäddad arbetsbok med en modifierad behåller diagrammet sina ursprungliga serie- och kategorisamlingar. Denna mismatch kan få [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) att misslyckas med ett index-out-of-range‑fel. Rensa befintliga serier och kategorier innan du skriver tillbaka den uppdaterade arbetsboken till diagrammet. Detta exempel använder ett diagram som är det första objektet på den första bilden. Kommentarerna markerar var arbetsboksredigering skulle ske; det körbara exemplet skriver tillbaka den ursprungliga arbetsboken och validerar layouten i minnet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // Modifiera arbetsbokens byte här, till exempel med Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Att rensa samlingarna tar bort föråldrade datareferenser innan arbetsboken skrivs tillbaka. Återskapa eventuella nödvändiga serie‑ och kategorikartläggningar för den uppdaterade arbetsboken innan du använder diagrammet.

## **Ange en arbetsboks-cell som diagramdatamärkning**

Du kan använda text från arbetsboks-celler som diagramdatamärkningar.

Detta exempel lägger till ett bubbel‑diagram med standarddata till första bilden i en befintlig presentation. Det använder cellerna A10:A12 på arbetsblad 0 för de tre första märkningarna i den första serien, aktiverar märkningar från celler och sparar den uppdaterade presentationen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hantera arbetsblad**

Metoden [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) ger åtkomst till arbetsbladen i en diagramarbetsbok. Detta exempel skapar ett paj‑diagram med standarddata och skriver ut varje arbetsblads namn till konsolen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Specificera datakälltyp**

Detta exempel skapar ett 3D‑stapeldiagram med standarddata och anger två serienamn med olika datakällor. Det första namnet använder en stränglitteral; det andra använder cell C1 på arbetsblad 0. Uppräkningen [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) väljer källan för varje namn. Exemplet sparar presentationen med de uppdaterade serienamnen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Detektera ej stödda inbäddade arbetsboksformat**

Aspose.Slides stödjer inte det binära Excel‑arbetsboksformatet (.xlsb) som kan vara inbäddat i vissa diagram. Du kan använda metoden [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) på [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) för att upptäcka ej stödda format och hoppa över de diagrammen. Detta exempel inspekterar formerna på första bilden i en befintlig presentation, hoppar över icke‑diagramformer och skriver ut ett diagnostiskt meddelande för varje diagram med en inbäddad .xlsb‑arbetsbok.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Läs eller ändra stödd diagramarboksdata här.
    }
} finally {
    presentation.dispose();
}
```

## **Extern arbetsbok**

Aspose.Slides stöder användning av externa arbetsböcker som datakälla för diagram.

### **Skapa en extern arbetsbok**

Använd [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) och [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) för att exportera en inbäddad diagramarbetsbok till en fil och länka diagrammet till den externa arbetsboken.

Detta exempel skapar ett paj‑diagram med standarddata och exporterar dess arbetsbok. Det slutför filskrivningen innan den tilldelar den externa arbetsboken som diagrammets datakälla, och sparar sedan den länkade presentationen.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Ange en extern arbetsbok**

Med metoden [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan också användas för att uppdatera en sökväg till den externa arbetsboken (om den senare har flyttats).

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan du fortfarande använda sådana arbetsböcker som en extern datakälla. Om en relativ sökväg för en extern arbetsbok anges, konverteras den automatiskt till en fullständig sökväg.

Detta exempel använder en extern arbetsbok vars arbetsblad med namn `Sheet1` innehåller ett serienamn i B1, kategorinamn i A2:A4 och numeriska värden i B2:B4. Exemplet skapar ett paj‑diagram, länkar arbetsboken och använder [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) för att mappa A1:B4 till en serie och tre kategorier. Det sparar presentationen med det länkade diagrammet.

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Parametern `updateChartData` för [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) styr om arbetsboken laddas.

* När `updateChartData` är `false` uppdateras endast arbetsbokens sökväg. Diagramdata laddas inte från målarbetsboken, så arbetsboken kan vara otillgänglig.
* När `updateChartData` är `true` uppdateras diagramdata från målarboken.

Följande exempel tilldelar en platshållar‑URL med `updateChartData` satt till `false`. Det behåller paj‑diagrammets standarddata och sparar presentationen utan att ladda den otillgängliga arbetsboken.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Hämta den externa datakällans arbetsboksökväg för ett diagram**

För att identifiera arbetsboken som är länkad till ett diagram, kontrollera om diagrammet använder en extern datakälla och hämta dess arbetsboksökväg.

Detta exempel inspekterar den första formen på den första bilden i en presentation med en länkad extern arbetsbok. Om det är ett diagram som är länkat till en extern arbetsbok skriver exemplet ut [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) till konsolen. Därefter sparas en kopia av presentationen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Redigera diagramdata**

Du kan redigera data i externa arbetsböcker på samma sätt som du ändrar innehållet i interna arbetsböcker. När en extern arbetsbok inte kan laddas kastas ett undantag.

Detta exempel använder ett diagram som är den första formen på den första bilden och som är länkat till en åtkomlig extern arbetsbok. Det sätter cell‑bakade värdet för den första datapunkten i den första serien till 100 och sparar den uppdaterade presentationen. Att redigera cellvärden kan uppdatera den länkade externa XLSX‑filen, så använd en kopia om du måste bevara den ursprungliga arbetsboken.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Återställ en arbetsbok från diagramcachen**

Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig, kan Aspose.Slides rekonstruera diagramarbetsboken från den data som cachats i presentationen. Skapa [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/), anropa [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), och sätt [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) till `true` innan du öppnar presentationen.

Följande Java‑exempel återställer arbetsboksdata för ett diagram som är den första formen på den första bilden och refererar en otillgänglig extern arbetsbok. Det får åtkomst till den återställda datan via [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) och [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Läs eller modifiera den återställda arbetsboksdata här.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Om den externa arbetsboken är otillgänglig och återställning är inaktiverad kastar Aspose.Slides ett undantag. Aktivera återställning endast när användning av den cachade diagramdatan är ett acceptabelt alternativ, eftersom cachen kanske inte innehåller ändringar som gjorts i den externa arbetsboken efter att presentationen senast uppdaterades.

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller inbäddad arbetsbok?**

Ja. Ett diagram har en [datakälltyp](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) och en [sökväg till en extern arbetsbok](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); om källan är en extern arbetsbok kan du läsa hela sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Presentationen lagrar den absoluta sökvägen i PPTX‑filen, så att flytta arbetsboken kan kräva att länken uppdateras.

**Kan jag använda arbetsböcker som finns på nätverksresurser/delade mappar?**

Ja, sådana arbetsböcker kan användas som en extern datakälla. Att redigera fjärrarbetsböcker direkt från Aspose.Slides stöds dock inte – de kan bara användas som källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**

Presentationen lagrar en [länk till den externa filen](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Att redigera cell‑bakade diagramdata kan också uppdatera den länkade lokala XLSX‑filen. Använd en kopia av arbetsboken om originalet måste förbli oförändrat.

**Vad ska jag göra om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inget lösenord vid länkning. En vanlig metod är att avlägsna skyddet i förväg eller förbereda en dekrypterad kopia (t.ex. med [Aspose.Cells](https://reference.aspose.com/cells/java/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av den filen att återspeglas i varje diagram nästa gång data laddas.