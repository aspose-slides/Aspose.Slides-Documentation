---
title: Aanpassen van gegevenspunten in Treemap‑ en Sunburst‑diagrammen op Android
linktitle: Gegevenspunten in Treemap‑ en Sunburst‑diagrammen
type: docs
url: /nl/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap diagram
- sunburst diagram
- hiërarchisch diagram
- gegevenspunt
- databelabel
- takkleur
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe je hiërarchische gegevens maakt en niveaus, labels en kleuren aanpast in Treemap‑ en Sunburst‑diagrammen met Aspose.Slides for Android via Java."
---
## **Overzicht**

Treemap‑ en Sunburst‑diagrammen geven dezelfde soort hiërarchische gegevens weer, maar gebruiken verschillende indelingen. Een Treemap tekent de hiërarchie als geneste rechthoeken waarvan de oppervlakte de bladwaarden vertegenwoordigt. Een Sunburst tekent het als concentrische ringen: groepen van het hoogste niveau staan dicht bij het centrum en bladcategorieën bevinden zich op de buitenste ring.

In Aspose.Slides for Android via Java is elke numerieke waarde een [IChartDataPoint](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/). De [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--)‑methode biedt toegang tot het blad en zijn bovenliggende groepen. Dit artikel legt die koppeling uit en toont hoe beide diagramtypen te maken en op te maken vanuit dezelfde voorbeeldgegevens.

![Een Treemap-diagram met Consumer- en Business-takken](treemap-hierarchy.png)

![Een Sunburst-diagram met dezelfde Consumer- en Business-hiërarchie](sunburst-hierarchy.png)

## **Begrijp categorieën, gegevenspunten en niveaus**

De hieronder gebruikte voorbeeldset heeft drie categorieniveaus en één numerieke serie:

| Tak | Stam | Blad | Omzet |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Elke rij creëert één blad‑categorie en één gegevenspunt. De categoriegroeperingsniveaus beschrijven het pad van dat blad naar zijn bovenliggende groepen. Voor de eerste rij is het pad `Consumer > Computers > Laptops`.

De indexen die worden geretourneerd door [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) lopen van het blad naar boven:

| `getDataPointLevels()` index | Logisch niveau | Treemap‑weergave | Sunburst‑weergave |
| ---: | --- | --- | --- |
| `0` | Blad | Waarde‑rechthoek | Segment van buitenste ring |
| `1` | Stam | Bovenliggende rechthoek of kop | Segment van middelste ring |
| `2` | Tak | Bovenliggende rechthoek of kop | Segment van binnenste ring |

Deze volgorde is voor beide diagramtypen hetzelfde, ook al verschillen hun visuele indelingen. Een bovenliggend segment wordt gedeeld door meerdere bladeren. Om het op te maken, gebruik je het overeenkomstige niveau van het eerste gegevenspunt in die groep. Bijvoorbeeld, de `Consumer`‑tak begint met het `Laptops`‑punt, terwijl de `Software`‑stam begint met het `Licenses`‑punt. Het bijhouden van referenties naar die punten is duidelijker en veiliger dan onverklaarde uitdrukkingen zoals `dataPoints.get_Item(0)` of `dataPoints.get_Item(6)`.

## **Maak en pas beide diagramtypen aan**

Het volgende complete voorbeeld maakt een Treemap op de eerste dia en een Sunburst op de tweede dia. Het bouwt de hiërarchie, toont de waarde voor `Tablets`, past vaste kleuren toe op geselecteerde niveaus, formatteert een tak­label en slaat de presentatie op.

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

        // Voeg de bladcategorieën toe. Een groepeeritem wordt alleen ingesteld wanneer een nieuwe groep begint;
        // de volgende categorieën blijven in die groep totdat een ander item wordt ingesteld.
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

        // Toon de categorie en de waarde op het Tablets-blad.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formateer de Consumer‑tak via het eerste blad in die tak.
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

        // Formateer de Software‑stam via het eerste blad in die stam.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout beïnvloedt Treemap‑bovenliggende labels; Sunburst gebruikt ringsegmenten.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De categoriecellen en waardecellen gebruiken dezelfde werkblad‑rij, zodat hun verzamelingsposities uitgelijnd blijven. Wanneer je werkt met een bestaand diagram in plaats van er een te maken, inspecteer dan eerst de categorierijen en sla benoemde referenties op naar de gegevenspunten en niveaus die je wilt opmaken.

## **Gedrag en praktische overwegingen**

### **Verschillen tussen Treemap en Sunburst**

- Een Treemap gebruikt oppervlakte om waarde te communiceren en geneste rechthoeken om hiërarchie te communiceren. De [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-)‑methode bepaalt hoe bovenliggende labels in dit diagramtype verschijnen.
- Een Sunburst gebruikt hoek om waarde te communiceren en ringdiepte om hiërarchie te communiceren. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) bepaalt niet de ringlabels.
- Beide diagramtypen gebruiken dezelfde categoriegroeperingsniveaus en dezelfde blad‑naar‑bovenliggende‑volgorde die door [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) wordt geretourneerd, zodat de code voor gegevensopbouw en niveau‑opmaak kan worden gedeeld.
- Bovenliggende waarden worden berekend uit hun afstammende bladeren. Voeg geen aparte numerieke punten toe voor takken of stammen.

### **Sorteren en segmentvolgorde**

De diagram‑lay‑engine bepaalt de uiteindelijke plaatsing van rechthoeken en ringsegmenten. Groepeer gerelateerde categorierijen voordat je ze toevoegt, maar vertrouw niet op een specifieke rechthoek‑positie of starthoek. Als de volgorde betekenis heeft, neem die dan op in de labels of gebruik een diagramtype met een expliciete categorische as.

### **Thema en vaste kleuren**

Niet‑opgemaakte diagram‑niveaus erven kleuren van het presentatiethema. Het voorbeeld gebruikt expliciete RGB‑vullingen voor voorspelbare uitvoer. Als het diagram thema‑wijzigingen moet volgen, gebruik dan schemakleuren in plaats van vaste RGB‑waarden en vermijd het overschrijven van elk niveau. Controleer ook het label‑contrast nadat je een tak‑ of stam‑vulling wijzigt.

### **Labels en beschikbare ruimte**

PowerPoint kan labels verbergen of afkorten wanneer een segment te klein is. Het vergroten van de diagramgrootte, inkorten van categorienamen of minder labelvelden tonen levert meestal een duidelijker resultaat op. Een label kan de categorienaam, serienaam en waarde combineren via [IDataLabelFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idatalabelformat/), maar het inschakelen van elk veld maakt hiërarchische diagrammen vaak moeilijk leesbaar.

### **Exporteren en renderen**

Opslaan als PPTX behoudt het bewerkbare diagram. Wanneer Aspose.Slides de presentatie rendert naar PDF of een afbeelding, worden de ondersteunde vullingen en labelinstellingen met het diagram gerenderd. Font‑substitutie en kleine verschillen in beschikbare lay‑ruimte kunnen regel‑omslag of label‑zichtbaarheid wijzigen, dus installeer de vereiste lettertypen en controleer belangrijke export‑doelen.

## **FAQ**

**Waarom beïnvloedt het wijzigen van een bovenliggend niveau meerdere bladeren?**

Een tak of stam is een gedeeld visueel segment. De [IChartDataPointLevel](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatapointlevel/) kan worden bereikt via een afstammend blad, maar de opmaak behoort tot het gedeelde bovenliggende segment en niet alleen tot dat blad.

**Waarom ontbreekt een datalabel?**

Schakel eerst de benodigde velden in op het [IDataLabelFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idatalabelformat/)‑object van het label. Controleer daarna of het segment voldoende ruimte heeft. De lay‑out van Treemap‑bovenliggende labels, diagramafmetingen, label‑lengte, lettergrootte en het aantal ingeschakelde velden beïnvloeden allemaal of een label kan worden weergegeven.

**Kan ik de exacte volgorde of coördinaten van segmenten bepalen?**

Je kunt de bron‑rijvolgorde sturen en elke groep aaneengesloten houden, maar je kunt geen exacte Treemap‑rechthoeken of Sunburst‑hoeken toewijzen. De lay‑engine berekent ze op basis van de hiërarchie, waarden en beschikbare ruimte.

**Waarom veranderen kleuren na een thema‑wijziging van de presentatie?**

Thema‑gebaseerde vullingen volgen het presentatierechterschema. Pas expliciete RGB‑kleuren toe op de niveaus die vast moeten blijven, of behoud schemakleuren wanneer aanpassing aan een nieuw thema gewenst is.

**Wordt aangepaste opmaak behouden bij PDF‑ en afbeeldingsexport?**

Ja, ondersteunde diagram‑vullingen en labelinstellingen worden meegenomen tijdens het renderen. Zorg voor de benodigde lettertypen en test de uiteindelijke exportgrootte, want label‑passing is lay‑afhankelijk.

## **Zie ook**

- [Create Treemap charts](/slides/nl/androidjava/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/nl/androidjava/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/nl/androidjava/export-chart/)
- [Manage presentation themes](/slides/nl/androidjava/presentation-theme/)