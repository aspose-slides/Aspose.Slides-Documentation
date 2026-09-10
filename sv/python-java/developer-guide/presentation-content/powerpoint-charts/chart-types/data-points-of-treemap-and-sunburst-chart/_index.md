---
title: Anpassa datapunkter i Treemap- och Sunburst-diagram i Python
linktitle: Datapunkter i Treemap- och Sunburst-diagram
type: docs
url: /sv/python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap-diagram
- sunburst-diagram
- hierarkiskt diagram
- datapunkt
- datapunktetikett
- grenfärg
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du skapar hierarkisk data och anpassar nivåer, etiketter och färger i Treemap- och Sunburst-diagram med Aspose.Slides för Python via Java."
---
## **Översikt**

Treemap‑ och Sunburst‑diagram visar samma typ av hierarkisk data, men de använder olika layouter. En Treemap ritar hierarkin som nästlade rektanglar vars områden representerar lövvärden. En Sunburst ritar den som koncentriska ringar: toppnivågrupperna ligger nära centrum och lövkategorierna finns på den yttre ringen.

I Aspose.Slides för Python via Java är varje numeriskt värde ett [ChartDataPoint](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatapoint/). Dess [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatapoint/#getDataPointLevels)‑metod ger åtkomst till lövet och dess föräldragrupper. Den här artikeln förklarar den mappningen och visar hur man skapar och formaterar båda diagramtyperna från samma exempeldata.

![Ett Treemap‑diagram med Consumer‑ och Business‑grenar](treemap-hierarchy.png)

![Ett Sunburst‑diagram med samma Consumer‑ och Business‑hierarki](sunburst-hierarchy.png)

## **Förstå kategorier, datapunkter och nivåer**

Exemplet som används nedan har tre kategorinivåer och en numerisk serie:

| Gren | Stam | Löv | Intäkt |
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

De index som returneras av [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) löper från lövet uppåt:

| `getDataPointLevels()`‑index | Logisk nivå | Treemap‑representation | Sunburst‑representation |
| ---: | --- | --- | --- |
| `0` | Löv | Värderektangel | Yttre‑ringsegment |
| `1` | Stam | Föräldrarektangel eller rubrik | Mellan‑ringsegment |
| `2` | Gren | Toppnivårektangel eller rubrik | Inre‑ringsegment |

Denna ordning är densamma för båda diagramtyperna även om deras visuella layouter skiljer sig. Ett föräldrasegment delas av flera löv. För att formatera det, använd motsvarande nivå på den första datapunkten i den gruppen. Till exempel börjar `Consumer`‑grenen med `Laptops`‑punkten, medan `Software`‑stammen börjar med `Licenses`‑punkten. Att hålla referenser till dessa punkter är tydligare och säkrare än att använda oklara uttryck som `data_points.get_Item(0)` eller `data_points.get_Item(6)`.

## **Skapa och anpassa båda diagramtyperna**

Det följande kompletta exemplet skapar ett Treemap på den första bilden och ett Sunburst på den andra bilden. Det bygger hierarkin, visar värdet för `Tablets`, applicerar fasta färger på utvalda nivåer, formaterar en grenetikett och sparar presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # Lägg till lövkategorierna. Ett grupperingsobjekt sätts endast när en ny grupp påbörjas; följande kategorier förblir i den gruppen tills ett annat objekt sätts.
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # Visa kategori och värde på Tablets-lövet.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # Formatera Consumer-grenen via det första lövet i den grenen.
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # Formatera Software-stammen via det första lövet i den stammen.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout påverkar Treemap-föräldraetiketter; Sunburst använder ringsegment.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kategoricellerna och värdecellerna använder samma kalkylarksrad, så deras samlingspositioner förblir justerade. När du arbetar med ett befintligt diagram snarare än att skapa ett, inspektera först kategoriraderna och lagra namngivna referenser till de datapunkter och nivåer du avser att formatera.

## **Beteende och praktiska överväganden**

### **Treemap‑ och Sunburst‑skillnader**

- En Treemap använder område för att kommunicera värde och nästlade rektanglar för att kommunicera hierarki. Metoden [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartseries/#setParentLabelLayout) styr hur föräldraetiketter visas i denna diagramtyp.
- En Sunburst använder vinkel för att kommunicera värde och ringdjup för att kommunicera hierarki. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartseries/#setParentLabelLayout) styr inte dess ringetiketter.
- Båda diagramtyperna använder samma kategorigrupperingsnivåer och samma löv‑till‑förälder‑ordning som returneras av [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatapoint/#getDataPointLevels), så kod för data‑byggnad och nivå‑formatering kan delas.
- Föräldravärden beräknas från deras underordnade löv. Lägg inte till separata numeriska punkter för grenar eller stammar.

### **Sortering och segmentordning**

Diagramlayoutmotorn bestämmer den slutgiltiga placeringen av rektanglar och ringsegment. Ordna relaterade kategorirader tillsammans innan de läggs till, men förlita dig inte på en specifik rektangelposition eller startvinkel. Om sekvensen har betydelse, inkludera den i etiketterna eller använd en diagramtyp med en explicit kategori‑axel.

### **Tema och fasta färger**

Oformaterade diagramnivåer ärver färger från presentationens tema. Exemplet använder explicita RGB‑utfyllnader för förutsägbart resultat. Om diagrammet ska följa temaförändringar, använd schemes‑färger i stället för fasta RGB‑värden och undvik att åsidosätta varje nivå. Kontrollera även etikettkontrast efter att en gren‑ eller stamfyllnad ändrats.

### **Etiketter och tillgängligt utrymme**

PowerPoint kan dölja eller trunkera etiketter när ett segment är för litet. Att öka diagrammets storlek, förkorta kategorinamnen eller visa färre etikettfält ger vanligtvis ett tydligare resultat. En etikett kan kombinera kategorinamnet, seriernamnet och värdet via [DataLabelFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/datalabelformat/), men att aktivera alla fält gör ofta hierarkiska diagram svåra att läsa.

### **Export och rendering**

Att spara till PPTX behåller diagrammet redigerbart. När Aspose.Slides renderar presentationen till PDF eller en bild, återges de stödjade fyllningarna och etikettinställningarna tillsammans med diagrammet. Teckensnittssubstitution och små skillnader i tillgängligt layoututrymme kan ändra radbrytning eller etikettens synlighet, så installera de erforderliga teckensnitten och verifiera viktiga exportmål.

## **FAQ**

**Varför påverkar en förändring av en föräldranivå flera löv?**

En gren eller stam är ett delat visuellt segment. Dess [ChartDataPointLevel](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatapointlevel/) kan nås genom ett underordnat löv, men formateringen tillhör det delade föräldrasegmentet snarare än endast det lövet.

**Varför saknas en datapunktsetikett?**

Aktivera först de nödvändiga fälten på etikettens [DataLabelFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/datalabelformat/)-objekt. Kontrollera sedan om segmentet har tillräckligt med utrymme. Treemap‑föräldra‑etikettslayout, diagramdimensioner, etikettlängd, teckenstorlek och antalet aktiverade fält påverkar alla om en etikett kan visas.

**Kan jag ange exakt ordning eller koordinater för segmenten?**

Du kan styra källradens ordning och hålla varje grupp sammanhängande, men du kan inte tilldela exakta Treemap‑rektanglar eller Sunburst‑vinklar. Diagramlayoutmotorn beräknar dem utifrån hierarkin, värdena och tillgängligt utrymme.

**Varför ändras färger efter att presentationstemat har förändrats?**

Tema‑baserade fyllningar är avsedda att följa presentationens färgpalett. Applicera explicita RGB‑färger på de nivåer som måste förbli fasta, eller behåll schemes‑färger när anpassning till ett nytt tema föredras.

**Kommer anpassad formatering att bevaras i PDF‑ och bildexport?**

Ja, stödjade diagramfyllningar och etikettinställningar inkluderas under rendering. För konsekventa resultat på olika system, gör nödvändiga teckensnitt tillgängliga och testa den slutgiltiga exportstorleken eftersom etikettpassning är layout‑beroende.

## **Se även**

- [Skapa Treemap‑diagram](/slides/sv/python-java/create-chart/#create-tree-map-charts)
- [Skapa Sunburst‑diagram](/slides/sv/python-java/create-chart/#create-sunburst-charts)
- [Exportera presentationsdiagram](/slides/sv/python-java/export-chart/)
- [Hantera presentationsteman](/slides/sv/python-java/presentation-theme/)