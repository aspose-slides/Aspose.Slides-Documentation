---
title: Anpassa datapunkter i Treemap- och Sunburst-diagram i Java
linktitle: Datapunkter i Treemap- och Sunburst-diagram
type: docs
url: /sv/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap-diagram
- Sunburst-diagram
- hierarkiskt diagram
- datapunkt
- datapunktetikett
- grenfärg
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du skapar hierarkisk data och anpassar nivåer, etiketter och färger i Treemap- och Sunburst-diagram med Aspose.Slides för Java."
---
## **Översikt**

Treemap- och Sunburst-diagram visar samma typ av hierarkisk data, men de använder olika layouter. En Treemap ritar hierarkin som inbäddade rektanglar vars områden representerar bladvärden. En Sunburst ritar den som koncentriska ringar: toppnivågrupperna är nära centrum och bladkategorierna är på den yttre ringen.

I Aspose.Slides för Java är varje numeriskt värde ett [IChartDataPoint](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatapoint/). Dess [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--)‑metod ger tillgång till bladet och dess föräldragrupp. Denna artikel förklarar den mappningen och visar hur man skapar och formaterar båda diagramtyperna från samma exempeldata.

![Ett Treemap-diagram med konsument- och affärsgrenar](treemap-hierarchy.png)

![Ett Sunburst-diagram med samma konsument- och affärshierarki](sunburst-hierarchy.png)

## **Förstå kategorier, datapunkter och nivåer**

Exemplet nedan har tre kategorinivåer och en numerisk serie:

| Gren | Stam | Blad | Intäkt |
| --- | --- | --- | ---: |
| Konsument | Datorer | Bärbara | 12 |
| Konsument | Datorer | Stationära | 8 |
| Konsument | Mobil | Telefoner | 15 |
| Konsument | Mobil | Surfplattor | 6 |
| Företag | Tjänster | Konsulttjänster | 10 |
| Företag | Tjänster | Stöd | 7 |
| Företag | Programvara | Licenser | 11 |
| Företag | Programvara | Prenumerationer | 14 |

Varje rad skapar en bladkategori och en datapunkt. Kategorigrupperingsnivåerna beskriver sökvägen från det bladet till dess föräldrar. För den första raden är sökvägen `Consumer > Computers > Laptops`.

Indexen som returneras av [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) löper från bladet uppåt:

| `getDataPointLevels()`‑index | Logisk nivå | Treemap‑representation | Sunburst‑representation |
| ---: | --- | --- | --- |
| `0` | Blad | Värderektangel | Yttre ringsegment |
| `1` | Stam | Föräldrarektangel eller rubrik | Mellanringsegment |
| `2` | Gren | Toppnivårektangel eller rubrik | Innerringsegment |

Denna ordning är densamma för båda diagramtyperna även om deras visuella layouter skiljer sig. Ett föräldrasegment delas av flera blad. För att formatera det, använd motsvarande nivå av den första datapunkten i gruppen. Till exempel börjar `Consumer`‑grenen med `Laptops`‑punkten, medan `Software`‑stammen börjar med `Licenses`‑punkten. Att hålla referenser till dessa punkter är tydligare och säkrare än att använda oförklarade uttryck som `dataPoints.get_Item(0)` eller `dataPoints.get_Item(6)`.

## **Skapa och anpassa båda diagramtyperna**

Följande kompletta exempel skapar en Treemap på den första bilden och en Sunburst på den andra bilden. Det bygger hierarkin, visar värdet för `Tablets`, applicerar fasta färger på utvalda nivåer, formaterar en grenetikett och sparar presentationen.

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

        // Lägg till bladdkategorierna. En grupperingselement sätts endast när en ny grupp börjar;
        // följande kategorier förblir i den gruppen tills ett annat element sätts.
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

        // Visa kategorin och värdet på Tablets-bladet.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formatera Consumer-grenen genom det första bladet i den grenen.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Formatera Software-stammen genom det första bladet i den stammen.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
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

### **Treemap- och Sunburst-skillnader**

- En Treemap använder area för att kommunicera värde och inbäddade rektanglar för att kommunicera hierarki. Metoden [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) styr hur föräldraetiketter visas i denna diagramtyp.
- En Sunburst använder vinkel för att kommunicera värde och ringdjup för att kommunicera hierarki. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) kontrollerar inte dess ringetiketter.
- Båda diagramtyperna använder samma kategorigrupperingsnivåer och samma blad‑till‑förälder‑ordning som returneras av [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), så koddelen för data‑byggnad och nivå‑formatering kan delas.
- Föräldravärden beräknas från deras efterföljande blad. Lägg inte till separata numeriska punkter för grenar eller stammar.

### **Sortering och segmentordning**

Diagrammets layoutmotor bestämmer den slutgiltiga placeringen av rektanglar och ringsegment. Ordna relaterade kategorirader tillsammans innan du lägger till dem, men förlita dig inte på en specifik rektangelposition eller startvinkel. Om sekvensen har betydelse, inkludera den i etiketterna eller använd en diagramtyp med en explicit kategorialax.

### **Tema och fasta färger**

Oformaterade diagramnivåer ärver färger från presentationens tema. Exemplet använder explicita RGB‑fyllningar för förutsägbart resultat. Om diagrammet ska följa temaförändringar, använd färgscheman istället för fasta RGB‑värden och undvik att åsidosätta varje nivå. Kontrollera också etikettkontrast efter att en gren‑ eller stamfärg har ändrats.

### **Etiketter och tillgängligt utrymme**

PowerPoint kan dölja eller trunkera etiketter när ett segment är för litet. Att öka diagrammets storlek, förkorta kategorinamn eller visa färre etikettfält ger vanligtvis ett tydligare resultat. En etikett kan kombinera kategorinamn, serienamn och värde via [IDataLabelFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idatalabelformat/), men att aktivera alla fält gör ofta hierarkiska diagram svåra att läsa.

### **Export och rendering**

Att spara som PPTX behåller diagrammet redigerbart. När Aspose.Slides renderar presentationen till PDF eller bild, renderas de stödjade fyllningarna och etikettinställningarna med diagrammet. Teckensnittssubstitution och små skillnader i tillgängligt layoututrymme kan ändra radbrytning eller etikettens synlighet, så installera de erforderliga teckensnitten och verifiera viktiga exportmål.

## **Vanliga frågor**

**Varför påverkar ändring av en föräldranivå flera blad?**

En gren eller stam är ett delat visuellt segment. Dess [IChartDataPointLevel](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatapointlevel/) kan nås via ett efterföljande blad, men formateringen tillhör det delade föräldrasegmentet snarare än bara det bladet.

**Varför saknas en datapunktetikett?**

Aktivera först de önskade fälten på etikettens [IDataLabelFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idatalabelformat/)-objekt. Kontrollera sedan om segmentet har tillräckligt med utrymme. Treemap‑föräldraetikett‑layout, diagramdimensioner, etiketternas längd, teckensnittsstorlek och antalet aktiverade fält påverkar alla om en etikett kan visas.

**Kan jag ange exakt ordning eller koordinater för segmenten?**

Du kan kontrollera källradordningen och hålla varje grupp sammanhängande, men du kan inte tilldela exakta Treemap‑rektanglar eller Sunburst‑vinklar. Layoutmotorn beräknar dem utifrån hierarkin, värdena och tillgängligt utrymme.

**Varför ändras färgerna efter att presentationstemat har ändrats?**

Temabaserade fyllningar är avsedda att följa presentationens färgpalett. Applicera explicita RGB‑färger på de nivåer som måste förbli fasta, eller behåll färgscheman när anpassning till ett nytt tema föredras.

**Kommer anpassad formatering att bevaras i PDF- och bildexport?**

Ja, stödjade diagramfyllningar och etikettinställningar inkluderas vid rendering. För konsistenta resultat på olika system, gör de nödvändiga teckensnitten tillgängliga och testa den slutgiltiga exportstorleken eftersom etikett‑passning är layout‑beroende.

## **Se även**

- [Skapa Treemap-diagram](/slides/sv/java/create-chart/#create-tree-map-charts)
- [Skapa Sunburst-diagram](/slides/sv/java/create-chart/#create-sunburst-charts)
- [Exportera presentationsdiagram](/slides/sv/java/export-chart/)
- [Hantera presentationsteman](/slides/sv/java/presentation-theme/)