---
title: Anpassa datapunkter i Treemap- och Sunburst-diagram på Android
linktitle: Datapunkter i Treemap- och Sunburst-diagram
type: docs
url: /sv/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap-diagram
- sunburst-diagram
- hierarkiskt diagram
- datapunkt
- dataetikett
- grenfärg
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du skapar hierarkiska data och anpassar nivåer, etiketter och färger i Treemap- och Sunburst-diagram med Aspose.Slides för Android via Java."
---
## **Översikt**

Treemap‑ och Sunburst‑diagram visar samma typ av hierarkiska data, men de använder olika layouter. En Treemap ritar hierarkin som inbäddade rektanglar vars områden representerar lövvärden. En Sunburst ritar den som koncentriska ringar: övergripande grupper ligger nära centrum och lövkategorierna är på den yttre ringen.

I Aspose.Slides för Android via Java är varje numeriskt värde ett [IChartDataPoint](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatapoint/). Dess [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--)‑metod ger åtkomst till lövet och dess överordnade grupper. Den här artikeln förklarar den kartläggningen och visar hur man skapar och formaterar båda diagramtyperna från samma exempeldata.

![Ett Treemap‑diagram med Consumer‑ och Business‑grenar](treemap-hierarchy.png)

![Ett Sunburst‑diagram med samma Consumer‑ och Business‑hierarki](sunburst-hierarchy.png)

## **Förstå kategorier, datapunkter och nivåer**

Exemplet som används nedan har tre kategorinivåer och en numerisk serie:

| Gren | Stam | Blad | Intäkt |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Varje rad skapar en lövkategori och en datapunkt. Kategorigrupperingsnivåerna beskriver sökvägen från det lövet till dess föräldrar. För den första raden är sökvägen `Consumer > Computers > Laptops`.

Indexen som returneras av [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) löper från lövet och uppåt:

| `getDataPointLevels()` index | Logisk nivå | Treemap‑representation | Sunburst‑representation |
| ---: | --- | --- | --- |
| `0` | Löv | Värderektangel | Segment i yttre ring |
| `1` | Stam | Föräldrarektangel eller rubrik | Segment i mellersta ring |
| `2` | Gren | Toppnivårektangel eller rubrik | Segment i inre ring |

Denna ordning är densamma för båda diagramtyperna även om deras visuella layouter skiljer sig. Ett föräldrasegment delas av flera löv. För att formatera det, använd motsvarande nivå från den första datapunkten i den gruppen. Till exempel börjar `Consumer`‑grenen med `Laptops`‑punkten, medan `Software`‑stammen börjar med `Licenses`‑punkten. Att hålla referenser till dessa punkter är tydligare och säkrare än att använda oförklarliga uttryck som `dataPoints.get_Item(0)` eller `dataPoints.get_Item(6)`.

## **Skapa och anpassa båda diagramtyperna**

Följande kompletta exempel skapar ett Treemap på den första bilden och ett Sunburst på den andra bilden. Det bygger hierarkin, visar värdet för `Tablets`, applicerar fasta färger på utvalda nivåer, formaterar en grenetikett och sparar presentationen.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Lägg till lövkategorierna. Ett grupperingsobjekt sätts endast när en ny grupp påbörjas;
        // de följande kategorierna förblir i den gruppen tills ett annat objekt sätts.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // Visa kategori och värde på Tablets‑bladet.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formatera Consumer‑grenen via det första bladet i den grenen.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Formatera Software‑stammen via det första bladet i den stammen.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout påverkar Treemap‑föräldraetiketter; Sunburst använder ringsegment.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kategoricellerna och värdecellerna använder samma kalkylarksrad, så deras samlingspositioner förblir justerade. När du arbetar med ett befintligt diagram istället för att skapa ett, inspektera först kategoriraderna och lagra namngivna referenser till datapunkterna och nivåerna du avser att formatera.

## **Beteende och praktiska överväganden**

### **Treemap‑ och Sunburst‑skillnader**

- En Treemap använder område för att kommunicera värde och inbäddade rektanglar för att kommunicera hierarki. Metoden [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) styr hur föräldraetiketter visas i denna diagramtyp.
- En Sunburst använder vinkel för att kommunicera värde och ringdjup för att kommunicera hierarki. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) styr inte dess ringetiketter.
- Båda diagramtyperna använder samma kategorigrupperingsnivåer och samma löv‑till‑förälder‑ordning som returneras av [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), så kod för databyggande och nivåformatering kan delas.
- Föräldravärden beräknas från deras nedärvda löv. Lägg inte till separata numeriska punkter för grenar eller stammar.

### **Sortering och segmentordning**

Diagramlayoutmotorn avgör den slutliga placeringen av rektanglar och ringsegment. Ordna relaterade kategorirader tillsammans innan du lägger till dem, men förlita dig inte på en specifik rektangelposition eller startvinkel. Om sekvensen bär betydelse, inkludera den i etiketterna eller använd en diagramtyp med en explicit kategoriväxel.

### **Tema och fasta färger**

Oformaterade diagramnivåer ärver färger från presentations‑temat. Exemplet använder explicita RGB‑fyllningar för förutsägbart resultat. Om diagrammet ska följa temaförändringar, använd schemafärger i stället för fasta RGB‑värden och undvik att åsidosätta varje nivå. Kontrollera också etikettkontrast efter att du ändrat en gren‑ eller stam‑fyllning.

### **Etiketter och tillgängligt utrymme**

PowerPoint kan dölja eller trunkera etiketter när ett segment är för litet. Att öka diagramstorleken, förkorta kategorinamnen eller visa färre etikettfält ger oftast ett tydligare resultat. En etikett kan kombinera kategorinamn, serienamn och värde via [IDataLabelFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idatalabelformat/), men om du aktiverar alla fält blir hierarkiska diagram svåra att läsa.

### **Export och rendering**

Att spara till PPTX behåller diagrammet redigerbart. När Aspose.Slides renderar presentationen till PDF eller bild, renderas de stödda fyllningarna och etikettinställningarna med diagrammet. Teckensnittsbyte och små skillnader i tillgängligt layoututrymme kan ändra radbrytning eller etikettens synlighet, så installera de nödvändiga teckensnitten och verifiera viktiga exportmål.

## **Vanliga frågor**

**Varför påverkar ändring av en föräldranivå flera löv?**

En gren eller stam är ett delat visuellt segment. Dess [IChartDataPointLevel](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdatapointlevel/) kan nås via ett efterkommer‑löv, men formateringen tillhör det delade föräldrasegmentet snarare än endast det lövet.

**Varför saknas en dataetikett?**

Aktivera först de nödvändiga fälten på etikettens [IDataLabelFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idatalabelformat/)‑objekt. Kontrollera sedan om segmentet har tillräckligt med utrymme. Treemap‑föräldra‑etikettlayout, diagramdimensioner, etikettlängd, teckenstorlek och antalet aktiverade fält påverkar alla om en etikett kan visas.

**Kan jag ange exakt ordning eller koordinater för segmenten?**

Du kan kontrollera radordningen i källan och hålla varje grupp sammanhängande, men du kan inte tilldela exakta Treemap‑rektanglar eller Sunburst‑vinklar. Diagramlayoutmotorn beräknar dem utifrån hierarkin, värdena och tillgängligt utrymme.

**Varför ändras färgerna efter att presentations‑temat har ändrats?**

Temabaserade fyllningar är avsedda att följa presentationens palett. Applicera explicita RGB‑färger på de nivåer som måste vara fasta, eller behåll schemafärger när anpassning till ett nytt tema föredras.

**Kommer anpassad formatering att behållas i PDF- och bildexport?**

Ja, stödda diagramfyllningar och etikettinställningar inkluderas vid rendering. För konsekventa resultat på olika system, gör de nödvändiga teckensnitten tillgängliga och testa den slutgiltiga exportstorleken eftersom etikettpassning är layout‑beroende.

## **Se även**

- [Skapa Treemap‑diagram](/slides/sv/androidjava/create-chart/#create-tree-map-charts)
- [Skapa Sunburst‑diagram](/slides/sv/androidjava/create-chart/#create-sunburst-charts)
- [Exportera presentations‑diagram](/slides/sv/androidjava/export-chart/)
- [Hantera presentations‑teman](/slides/sv/androidjava/presentation-theme/)