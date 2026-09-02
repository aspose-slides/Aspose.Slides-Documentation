---
title: Pas datapunten aan in Treemap- en Sunburst-diagrammen in C++
linktitle: Datapunten in Treemap- en Sunburst-diagrammen
type: docs
url: /nl/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap-diagram
- sunburst-diagram
- hiërarchisch diagram
- datapunt
- datalabel
- tak-kleur
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe je hiërarchische gegevens maakt en niveaus, labels en kleuren aanpast in Treemap- en Sunburst-diagrammen met Aspose.Slides voor C++."
---
## **Overzicht**

Treemap- en Sunburst-diagrammen tonen hetzelfde type hiërarchische gegevens, maar ze gebruiken verschillende indelingen. Een Treemap tekent de hiërarchie als geneste rechthoeken waarvan de gebieden de bladwaarden vertegenwoordigen. Een Sunburst tekent het als concentrische ringen: groepen op hoogste niveau staan dicht bij het centrum, en bladcategorieën bevinden zich op de buitenste ring.

In Aspose.Slides for C++ is elke numerieke waarde een [IChartDataPoint](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapoint/). Zijn [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/)-methode biedt toegang tot het blad en de bovenliggende groepen. Dit artikel legt die koppeling uit en laat zien hoe beide diagramtypes te maken en op te maken met dezelfde voorbeeldgegevens.

![Een Treemap-diagram met Consumer- en Business-vertakkingen](treemap-hierarchy.png)

![Een Sunburst-diagram met dezelfde Consumer- en Business-hiërarchie](sunburst-hierarchy.png)

## **Begrijp Categorieën, Datapunten en Niveaus**

Het onderstaande voorbeeld bevat drie categorieniveaus en één numerieke serie:

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

Elke rij maakt één bladcategorie en één datapunten aan. De categoriegroeperingsniveaus beschrijven het pad van dat blad naar zijn bovenliggende elementen. Voor de eerste rij is het pad `Consumer > Computers > Laptops`.

De indexen die door [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) worden geretourneerd, lopen van het blad omhoog:

| `get_DataPointLevels()` index | Logisch niveau | Treemap-weergave | Sunburst-weergave |
| ---: | --- | --- | --- |
| `0` | Blad | Waarde‑rechthoek | Segment buitenste ring |
| `1` | Stam | Bovenliggende rechthoek of koptekst | Segment middelste ring |
| `2` | Tak | Bovenliggende rechthoek of koptekst | Segment binnenste ring |

Deze volgorde is hetzelfde voor beide diagramtypes, ook al verschillen hun visuele indelingen. Een bovenliggend segment wordt gedeeld door meerdere bladeren. Om het op te maken, gebruik je het overeenkomstige niveau van het eerste datapunten in die groep. Bijvoorbeeld, de `Consumer`‑tak begint met het `Laptops`‑punt, terwijl de `Software`‑stam begint met het `Licenses`‑punt. Referenties naar die punten bijhouden is duidelijker en veiliger dan onverklaarde uitdrukkingen zoals `dataPoints->idx_get(0)` of `dataPoints->idx_get(6)` te gebruiken.

## **Maak en Pas beide Diagramtypes Aan**

Het onderstaande volledige voorbeeld maakt een Treemap op de eerste dia en een Sunburst op de tweede dia. Het bouwt de hiërarchie, toont de waarde voor `Tablets`, past vaste kleuren toe op geselecteerde niveaus, formatteert een tak‑label en slaat de presentatie op.

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // Voeg de bladcategorieën toe. Een groepeerelement wordt alleen ingesteld wanneer een nieuwe groep begint;
    // de volgende categorieën blijven in die groep totdat een ander element wordt ingesteld.
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // Toon de categorie en de waarde op het blad Tablets.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Formatteer de Consumer tak via het eerste blad in die tak.
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // Formatteer de Software stam via het eerste blad in die stam.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout beïnvloedt de bovenliggende labels in Treemap; Sunburst gebruikt ringsegmenten.
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

De categorie‑cellen en waardecellen gebruiken dezelfde werkblad‑rij, zodat hun verzameling‑posities uitgelijnd blijven. Wanneer je met een bestaand diagram werkt in plaats van er een nieuw te maken, inspecteer dan eerst de categorie‑rijen en sla benoemde referenties op naar de datapunten en niveaus die je wilt opmaken.

## **Gedrag en Praktische Overwegingen**

### **Verschillen tussen Treemap en Sunburst**

- Een Treemap gebruikt oppervlakte om een waarde weer te geven en geneste rechthoeken om de hiërarchie te communiceren. De [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/)-methode bepaalt hoe bovenliggende labels verschijnen in dit diagramtype.
- Een Sunburst gebruikt hoek om een waarde weer te geven en ringdiepte om de hiërarchie te communiceren. De [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) bepaalt haar ring‑labels niet.
- Beide diagramtypes gebruiken dezelfde categoriegroeperingsniveaus en dezelfde blad‑naar‑bovenliggend‑volgorde die door [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) wordt geretourneerd, zodat de code voor het opbouwen van gegevens en het opmaken van niveaus kan worden gedeeld.
- Bovenliggende waarden worden berekend uit hun afgeleide bladeren. Voeg geen afzonderlijke numerieke punten toe voor takken of stammen.

### **Sorteren en Segmentvolgorde**

De diagram‑layoutengine bepaalt de uiteindelijke plaatsing van rechthoeken en ringsegmenten. Groepeer gerelateerde categorie‑rijen voordat je ze toevoegt, maar vertrouw niet op een specifieke rechthoek‑positie of starthoek. Als de volgorde betekenis heeft, neem die dan op in de labels of gebruik een diagramtype met een expliciete categorisch-assen.

### **Thema en Vaste Kleuren**

Niet‑opgemaakte diagramniveaus erven kleuren van het presentatiethema. Het voorbeeld gebruikt expliciete RGB‑vullingen voor voorspelbare output. Als het diagram thema‑veranderingen moet volgen, gebruik dan themakleuren in plaats van vaste RGB‑waarden en vermijd het overschrijven van elk niveau. Controleer ook het label‑contrast nadat je een tak‑ of stam‑vulling hebt aangepast.

### **Labels en Beschikbare Ruimte**

PowerPoint kan labels verbergen of afkappen wanneer een segment te klein is. Het vergroten van het diagram, het inkorten van categorienamen of het tonen van minder label‑velden levert doorgaans een duidelijker resultaat op. Een label kan de categorienaam, serienaam en waarde combineren via [IDataLabelFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/idatalabelformat/), maar het inschakelen van elk veld maakt hiërarchische diagrammen vaak moeilijk leesbaar.

### **Export en Rendering**

Opslaan als PPTX houdt het diagram bewerkbaar. Wanneer Aspose.Slides de presentatie naar PDF of een afbeelding rendert, worden de ondersteunde vullingen en label‑instellingen met het diagram gerenderd. Font‑substitutie en kleine verschillen in beschikbare layout‑ruimte kunnen regelafbreking of label‑zichtbaarheid wijzigen, dus installeer de benodigde lettertypen en verifieer belangrijke exportdoelen.

## **FAQ**

**Waarom heeft het wijzigen van een bovenliggend niveau effect op meerdere bladeren?**

Een tak of stam is een gedeeld visueel segment. Zijn [IChartDataPointLevel](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapointlevel/) kan worden bereikt via een afgeleid blad, maar de opmaak behoort tot het gedeelde bovenliggende segment in plaats van alleen tot dat blad.

**Waarom ontbreekt een datalabel?**

Schakel eerst de vereiste velden in op het label‑object **[IDataLabelFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/idatalabelformat/)**. Controleer daarna of het segment voldoende ruimte heeft. Treemap‑bovenliggende‑label‑layout, diagram‑afmetingen, label‑lengte, lettergrootte en het aantal ingeschakelde velden beïnvloeden allemaal of een label kan worden weergegeven.

**Kan ik de exacte volgorde of coördinaten van segmenten instellen?**

Je kunt de bron‑rijvolgorde regelen en elke groep aaneengesloten houden, maar je kunt geen exacte Treemap‑rechthoeken of Sunburst‑hoeken toewijzen. De diagram‑layoutengine berekent ze op basis van de hiërarchie, waarden en beschikbare ruimte.

**Waarom veranderen kleuren na een wijziging van het presentatiethema?**

Thema‑gebaseerde vullingen volgen het presentatiepalet. Pas expliciete RGB‑kleuren toe op de niveaus die vast moeten blijven, of behoud themakleuren wanneer het aanpassen aan een nieuw thema de voorkeur heeft.

**Wordt aangepaste opmaak behouden bij PDF‑ en afbeeldingsexport?**

Ja, ondersteunde diagramvullingen en label‑instellingen worden meegenomen tijdens het renderen. Zorg voor de vereiste lettertypen en test de uiteindelijke exportgrootte, want label‑passing is afhankelijk van de layout.

## **Zie Ook**

- [Maak Treemap-diagrammen](/slides/nl/cpp/create-chart/#create-tree-map-charts)
- [Maak Sunburst-diagrammen](/slides/nl/cpp/create-chart/#create-sunburst-charts)
- [Export presentatie‑diagrammen](/slides/nl/cpp/export-chart/)
- [Beheer presentatiethema’s](/slides/nl/cpp/presentation-theme/)