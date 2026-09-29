---
title: Hantera diagramarböcker i presentationer på Android
linktitle: Diagramarbok
type: docs
weight: 70
url: /sv/androidjava/chart-workbook/
keywords:
- diagramarbok
- diagramdata
- arbetsbokscell
- datamärkning
- kalkylblad
- datakälla
- extern arbetsbok
- extern data
- diagramcache
- arbetsboksåterställning
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Upptäck Aspose.Slides för Android via Java: hantera enkelt diagramarböcker i PowerPoint- och OpenDocument-format för att förenkla dina presentationsdata."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur man läser och skriver diagramdata via arbetsbokströmmar, använder arbetsboksceller som diagramdatamärkningar, får åtkomst till kalkylbladscollectioner och anger datakälltyp för diagramvärden. Den täcker också hur man arbetar med externa arbetsböcker som diagramdatakällor. Exemplen visar hur man skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkat till ett diagram och redigerar diagramdata när arbetsboken är tillgänglig. För arbetsboksceller som representerar saknad data, se [Control the Display of Empty Cells](/slides/sv/androidjava/chart-series/) för skillnaden mellan en tom cell och noll, samt en linjediagramjämförelse av de tillgängliga visningslägena.

## **Inkludera data från dolda rader och kolumner**

Använd [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) för att styra om ett diagram ritar data från dolda kalkylbladsrader och -kolumner. Ställ in det på `true` för att endast rita synliga celler, eller på `false` för att inkludera både synliga och dolda celler. Denna inställning styr diagramritning; den döljer eller visar inte kalkylbladsrader eller -kolumner.

Ladda ner [hidden-source-data.pptx](hidden-source-data.pptx) och placera den i arbetskatalogen. Dess första bild innehåller ett stapeldiagram som den första formen. Det inbäddade kalkylbladet, `Sheet1`, innehåller följande källintervall, `A1:C4`. Rad 3 och kolumn C är dolda, men deras celler innehåller fortfarande värden.

| Kalkylbladsrad | A: Månad | B: Detaljhandel | C: Partihandel (dold kolumn) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (dold rad) | Februari | 40 | 60 |
| 4 | Mars | 20 | 50 |

Få åtkomst till källcellerna via [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) och läs [IChartDataCell.isHidden](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) för att inspektera deras dolda status. Denna metod rapporterar den dolda statusen utan att ändra den. I den här filen är B2 synlig, B3 tillhör den dolda raden och C2 tillhör den dolda kolumnen; exemplet skriver ut `false`, `true` och `true` respektive.

För detta exempel, uppdatera diagramdata efter att du ändrat ritinställningen: behåll den inbäddade arbetsboken med [readWorkbookStream](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) och läs in den igen med [writeWorkbookStream](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-). När du inkluderar alla celler, använd även [setRange](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) för att återställa hela intervallet, inklusive den dolda februari-kategorin. Att bara ändra flaggan räcker inte för att uppdatera detta exempelns cachade diagramdata och kategorimärkningar.

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
                // Återställ det kompletta källintervallet, inklusive dolda kategorier.
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

Exemplet sparar `hidden_cells_true.pptx` med endast de synliga Detaljhandelsvärdena (10 och 20), och `hidden_cells_false.pptx` med alla sex värden. Bilderna nedan visar de två ritlägena. Rad 3 och kolumn C förblir dolda i båda inbäddade arbetsböckerna.

| Endast synliga celler (`true`) | Alla celler (`false`) |
| --- | --- |
| ![Endast synliga celler: Detaljhandelsvärden 10 och 20 för Januari och Mars.](hidden_cells_True.png) | ![Alla celler: Detaljhandels- och Partihandelsvärden för Januari, Februari och Mars.](hidden_cells_False.png) |

En dold cell som innehåller ett värde skiljer sig från en tom cell. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) styr hur saknade värden visas; den inkluderar eller exkluderar inte dold källdata. Se [Control the Display of Empty Cells](/slides/sv/androidjava/chart-series/#control-the-display-of-empty-cells) för ett exempel.

## **Läsa och skriva diagramdata från en arbetsbok**

Aspose.Slides för Android via Java tillhandahåller metoderna [readWorkbookStream](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) och [writeWorkbookStream](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) som låter dig läsa och skriva diagramdatabokar (innehållande diagramdata redigerad med Aspose.Cells). **Obs** att diagramdata måste vara organiserad på samma sätt eller ha en struktur som liknar källan.

Detta exempel öppnar `chart.pptx`, som måste innehålla ett diagram som den första formen på den första bilden. Det läser den inbäddade arbetsboken till en byte-array, rensar befintliga serier och kategorier och skriver tillbaka samma arbetsbok. Ändringarna finns kvar i minnet; exemplet sparar inte presentationen.

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

När du ersätter en inbäddad arbetsbok med en modifierad behåller diagrammet sina ursprungliga serie- och kategorisamlingar. Denna mismatch kan få [IChart.validateChartLayout](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichart/#validateChartLayout--) att misslyckas med ett index‑out‑of‑range‑fel. Rensa de befintliga serierna och kategorierna innan du skriver tillbaka den uppdaterade arbetsboken till diagrammet. Detta exempel kräver `chart.pptx` med ett diagram som den första formen på den första bilden. Kommentaren markerar var arbetsboksredigering skulle ske; det körbara exemplet skriver tillbaka den ursprungliga arbetsboken och validerar layouten i minnet.

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

        // Ändra arbetsbokens byte här, till exempel med Aspose.Cells.

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

Att rensa samlingarna tar bort föråldrade datareferenser innan arbetsboken skrivs tillbaka. Bygg om eventuella nödvändiga serie‑ och kategorikartläggningar för den uppdaterade arbetsboken innan du använder diagrammet.

## **Ange en arbetsbokscell som diagramdatamärkning**

Du kan använda text från arbetsboksceller som diagramdatamärkningar. Följande steg visar hur man länkar märkningarna i ett bubbeldiagram till celler i dess datarbok.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Få åtkomst till den första bilden via dess nollbaserade index.
3. Lägg till ett bubbeldiagram med standarddata.
4. Få åtkomst till diagramserierna.
5. Ange arbetsbokscellen som en datamärkning.
6. Spara presentationen.

Detta exempel öppnar `chart2.pptx`, som måste innehålla minst en bild, och lägger till ett bubbeldiagram med standarddata. Det använder cellerna A10:A12 på kalkylblad 0 för de första tre märkningarna i den första serien, aktiverar märkningar från celler och sparar resultatet till `resultchart.pptx`.

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

## **Hantera kalkylblad**

Metoden [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) ger åtkomst till kalkylbladen i en diagramarbetsbok. Detta exempel skapar ett cirkeldiagram med standarddata och skriver ut varje kalkylbladsnamn till konsolen.

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

## **Ange datakälltyp**

Detta exempel skapar ett 3D‑stapeldiagram med standarddata och anger två serienamn med olika datakällor. Det första namnet använder en strängliteral; det andra använder cell C1 på kalkylblad 0. Enumet [DataSourceType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/datasourcetype/) väljer källan för varje namn. Resultatet sparas till `pres.pptx`.

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

Aspose.Slides stödjer inte Excel‑binärarbetsboken (.xlsb) som kan inbäddas i vissa diagram. Du kan använda metoden [getEmbeddedWorkbookType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) på [IChartData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/) tillsammans med enumet [WorkbookType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/workbooktype/) för att upptäcka ej stödda format och hoppa över de diagrammen. Detta exempel undersöker formerna på den första bilden i `sample.pptx`, ignorerar former som inte är diagram och skriver ut ett diagnostiskt meddelande för varje diagram med en inbäddad .xlsb‑arbetsbok.

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

        // Läs eller ändra stödjda diagramarbokdata här.
    }
} finally {
    presentation.dispose();
}
```

## **Extern arbetsbok**

Aspose.Slides stödjer att använda externa arbetsböcker som datakälla för diagram.

### **Skapa en extern arbetsbok**

Använd [readWorkbookStream](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) och [setExternalWorkbook](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) för att exportera en inbäddad diagramarbetsbok till en fil och länka diagrammet till den externa arbetsboken.

Detta exempel skapar ett cirkeldiagram med standarddata, skriver dess arbetsbok till `externalWorkbook1.xlsx` och slutför filskrivningen innan filen tilldelas som diagrammets datakälla. Det sparar den länkade presentationen till `externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Ange en extern arbetsbok**

Med metoden [setExternalWorkbook](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan också användas för att uppdatera sökvägen till den externa arbetsboken (om den senare har flyttats).

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan du ändå använda sådana arbetsböcker som en extern datakälla. Om en relativ sökväg för en extern arbetsbok anges, konverteras den automatiskt till en fullständig sökväg.

Detta exempel kräver `externalWorkbook.xlsx` i arbetskatalogen. Dess kalkylblad med namn `Sheet1` måste innehålla ett serienamn i B1, kategorinamn i A2:A4 och numeriska värden i B2:B4. Exemplet skapar ett cirkeldiagram, länkar arbetsboken och använder [setRange](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) för att mappa A1:B4 till en serie och tre kategorier. Det sparar resultatet till `Presentation_with_externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`updateChartData`‑parametern för [setExternalWorkbook](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) styr om arbetsboken laddas.

* När `updateChartData` är `false` uppdateras endast arbetsbokens sökväg. Diagramdata laddas inte eller uppdateras från målarbetsboken, så arbetsboken kan vara otillgänglig.
* När `updateChartData` är `true` uppdateras diagramdata från målarbetsboken.

Följande exempel tilldelar en platshållar‑URL med `updateChartData` satt till `false`. Det behåller cirkeldiagrammets standarddata och sparar presentationen utan att ladda den otillgängliga arbetsboken.

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

### **Hämta den externa datakällans arbetsbokssökväg för ett diagram**

För att identifiera arbetsboken som är länkad till ett diagram, kontrollera först om diagrammet använder en extern datakälla. Om så är fallet kan du hämta arbetsbokssökvägen genom att följa dessa steg.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Få åtkomst till den första bilden via dess nollbaserade index.
3. Kontrollera att den första formen är ett diagram.
4. Läs diagrammets datakälltyp.
5. Om källan är en extern arbetsbok, läs dess sökväg.

Detta exempel öppnar `externalWorkbook.pptx`, som skapades i föregående exempel, och undersöker den första formen på den första bilden. Om den är ett diagram länkat till en extern arbetsbok, skriver exemplet ut [getExternalWorkbookPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) till konsolen. Det sparar sedan en kopia av presentationen till `Result.pptx`.

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

Du kan redigera data i externa arbetsböcker på samma sätt som du gör ändringar i innehållet i interna arbetsböcker. När en extern arbetsbok inte kan laddas kastas ett undantag.

Detta exempel kräver `presentation.pptx` med ett diagram som den första formen på den första bilden och en åtkomlig extern arbetsbok. Det sätter det cellbaserade värdet för den första datapunkten i den första serien till 100 och sparar presentationen till `presentation_out.pptx`. Att redigera cellvärden kan uppdatera den länkade externa XLSX‑filen, så använd en kopia om du behöver bevara den ursprungliga arbetsboken.

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

### **Återskapa en arbetsbok från diagramcachen**

Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig kan Aspose.Slides rekonstruera diagramarbetsboken från de data som cachas i presentationen. Skapa [LoadOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/), anropa [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) och sätt [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) till `true` innan presentationen öppnas.

Följande Java‑exempel öppnar `presentation.pptx`, där den första formen på den första bilden måste vara ett diagram som refererar till en otillgänglig extern arbetsbok, och får åtkomst till de återställda data via [IChart.getChartData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichart/#getChartData--) och [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // Läs eller ändra de återställda arbetsboksdata här.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Om den externa arbetsboken är otillgänglig och återställning är inaktiverad kastar Aspose.Slides ett undantag. Aktivera återställning endast när det är acceptabelt att använda de cachade diagramdata som en reservlösning, eftersom cachen kanske inte innehåller ändringar som gjorts i den externa arbetsboken efter att presentationen senast uppdaterades.

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller en inbäddad arbetsbok?**

Ja. Ett diagram har en [data source type](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) och en [path to an external workbook](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Presentationen lagrar den absoluta sökvägen i PPTX‑filen, så att flytta arbetsboken kan kräva att länken uppdateras.

**Kan jag använda arbetsböcker som finns på nätverksresurser/delade mappar?**

Ja, sådana arbetsböcker kan användas som en extern datakälla. Att redigera fjärrarbetsböcker direkt från Aspose.Slides stöds dock inte – de kan endast användas som källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**

Presentationen lagrar en [link to the external file](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Att redigera cellbaserade diagramdata kan också uppdatera den länkade lokala XLSX‑filen. Använd en kopia av arbetsboken om originalet måste förbli oförändrat.

**Vad ska jag göra om den externa filen är skyddad med lösenord?**

Aspose.Slides accepterar inte ett lösenord vid länkning. Ett vanligt tillvägagångssätt är att ta bort skyddet i förväg eller förbereda en avkrypterad kopia (t.ex. med [Aspose.Cells](https://reference.aspose.com/cells/java/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil, kommer en uppdatering av filen att återspeglas i varje diagram nästa gång data laddas.