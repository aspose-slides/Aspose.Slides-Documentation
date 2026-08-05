---
title: Anpassa datapunkter i Treemap- och Sunburst-diagram i C++
linktitle: Datapunkter i Treemap- och Sunburst-diagram
type: docs
url: /sv/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap-diagram
- sunburst-diagram
- hierarkiskt diagram
- datapunkt
- datapunktetikett
- grenfärg
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du skapar hierarkisk data och anpassar nivåer, etiketter och färger i Treemap- och Sunburst-diagram med Aspose.Slides för C++."
---
## **Översikt**

Treemap‑ och Sunburst‑diagram visar samma typ av hierarkisk data, men de använder olika layouter. En Treemap ritar hierarkin som nästlade rektanglar vars område representerar lövvärden. En Sunburst ritar den som koncentriska ringar: top‑nivågrupper är nära centrum, och lövkategorier är på den yttre ringen.

I Aspose.Slides för C++ är varje numeriskt värde en [IChartDataPoint](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapoint/). Dess [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/)‑metod ger åtkomst till lövet och dess föräldragrupper. Denna artikel förklarar den mappningen och visar hur man skapar och formaterar båda diagramtyperna från samma exempeldata.

![Ett Treemap‑diagram med Consumer och Business‑grenar](treemap-hierarchy.png)

![Ett Sunburst‑diagram med samma Consumer och Business‑hierarki](sunburst-hierarchy.png)

## **Förstå kategorier, datapunkter och nivåer**

Exemplet nedan har tre kategori‑nivåer och en numerisk serie:

| Gren | Stam | Löv | Intäkt |
| --- | --- | --- | ---: |
| Konsument | Datorer | Bärbara | 12 |
| Konsument | Datorer | Stationära | 8 |
| Konsument | Mobil | Telefoner | 15 |
| Konsument | Mobil | Surfplattor | 6 |
| Företag | Tjänster | Konsultation | 10 |
| Företag | Tjänster | Support | 7 |
| Företag | Programvara | Licenser | 11 |
| Företag | Programvara | Prenumerationer | 14 |

Varje rad skapar en lövkategori och en datapunkt. Kategorigrupperingsnivåerna beskriver sökvägen från det lövet till dess föräldrar. För den första raden är sökvägen `Consumer > Computers > Laptops`.

Indexen som returneras av [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) löper från lövet uppåt:

| `get_DataPointLevels()`‑index | Logisk nivå | Treemap‑representation | Sunburst‑representation |
| ---: | --- | --- | --- |
| `0` | Löv | Värderektangel | Segment i ytterring |
| `1` | Stam | Föräldrarektangel eller rubrik | Segment i mellarring |
| `2` | Gren | Rektangel eller rubrik på top‑nivå | Segment i innerring |

Denna ordning är densamma för båda diagramtyperna även om deras visuella layouter skiljer sig. Ett föräldrasegment delas av flera löv. För att formatera det använder du motsvarande nivå för den första datapunkten i den gruppen. Till exempel börjar gren `Consumer` med datapunkten `Laptops`, medan stam `Software` börjar med datapunkten `Licenses`. Att hålla referenser till dessa punkter är tydligare och säkrare än att använda obegripliga uttryck som `dataPoints->idx_get(0)` eller `dataPoints->idx_get(6)`.

## **Skapa och anpassa båda diagramtyperna**

Följande kompletta exempel skapar en Treemap på den första bilden och en Sunburst på den andra bilden. Det bygger hierarkin, visar värdet för `Tablets`, använder fasta färger på valda nivåer, formaterar en grenetikett och sparar presentationen.

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

    // Lägg till lövkategorierna. Ett grupperingselement sätts endast när en ny grupp påbörjas;
    // följande kategorier förblir i den gruppen tills ett annat element sätts.
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

    // Visa kategori och värde på lövet Tablets.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Formatera Consumer-grenen via det första lövet i den grenen.
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

    // Formatera Software-stammen via det första lövet i den stammen.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout påverkar föräldraetiketterna i Treemap; Sunburst använder ringsegment.
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

Kategoricellerna och värdecellerna använder samma arbetsbladsrad, så deras samlingspositioner förblir anpassade. När du arbetar med ett befintligt diagram istället för att skapa ett, inspektera först kategoriraderna och lagra namnreferenser till de datapunkter och nivåer du avser att formatera.

## **Beteende och praktiska överväganden**

### **Treemap‑ och Sunburst‑skillnader**

- En Treemap använder område för att kommunicera värde och nästlade rektanglar för att kommunicera hierarki. Metoden [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) styr hur föräldraetiketter visas i denna diagramtyp.
- En Sunburst använder vinkel för att kommunicera värde och ringdjup för att kommunicera hierarki. [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) styr inte dess ringetiketter.
- Båda diagramtyperna använder samma kategorigrupperingsnivåer och samma löv‑till‑förälder‑ordning som returneras av [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/), så kod för data‑byggnad och nivå‑formatering kan delas.
- Föräldravärden beräknas från deras underordnade löv. Lägg inte till separata numeriska punkter för grenar eller stammar.

### **Sortering och segmentordning**

Diagramlayoutmotorn bestämmer den slutgiltiga placeringen av rektanglar och ringsegment. Arrangera relaterade kategorirader tillsammans innan du lägger till dem, men förlita dig inte på en specifik rektangelposition eller startvinkel. Om sekvensen har betydelse, inkludera den i etiketterna eller använd en diagramtyp med en explicit kategori‑axel.

### **Tema och fasta färger**

Ej formaterade diagramnivåer ärver färger från presentationens tema. Exemplet använder explicita RGB‑fyllningar för förutsägbara resultat. Om diagrammet ska följa temaförändringar, använd schemafärger i stället för fasta RGB‑värden och undvik att åsidosätta varje nivå. Kontrollera också etikettkontrast efter att ha ändrat en gren‑ eller stamfyllning.

### **Etiketter och tillgängligt utrymme**

PowerPoint kan dölja eller trunkera etiketter när ett segment är för litet. Att öka diagrammets storlek, förkorta kategorinamnen eller visa färre etikettfält ger vanligtvis ett tydligare resultat. En etikett kan kombinera kategorinamnet, serienamnet och värdet via [IDataLabelFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/idatalabelformat/), men att aktivera alla fält gör ofta hierarkiska diagram svåra att läsa.

### **Export och rendering**

Att spara som PPTX behåller diagrammet redigerbart. När Aspose.Slides renderar presentationen till PDF eller en bild, renderas de stödjade fyllningarna och etikettinställningarna med diagrammet. Teckensnittssubstitution och små skillnader i tillgängligt layoututrymme kan ändra radbrytning eller etikettens synlighet, så installera de erforderliga teckensnitten och verifiera viktiga exportmål.

## **Vanliga frågor**

**Varför påverkar en ändring på en föräldranivå flera löv?**

En gren eller stam är ett delat visuellt segment. Dess [IChartDataPointLevel](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapointlevel/) kan nås via ett underordnat löv, men formateringen tillhör det delade föräldrasegmentet snarare än bara det lövet.

**Varför saknas en datalabel?**

Aktivera först de erforderliga fälten på etikettens [IDataLabelFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/idatalabelformat/)-objekt. Kontrollera sedan om segmentet har tillräckligt med utrymme. Treemap‑föräldraetikettlayout, diagramdimensioner, etikettlängd, teckensnittsstorlek och antalet aktiverade fält påverkar alla om en etikett kan visas.

**Kan jag ange exakt ordning eller koordinater för segmenten?**

Du kan kontrollera källradens ordning och hålla varje grupp sammanhängande, men du kan inte tilldela exakta Treemap‑rektanglar eller Sunburst‑vinklar. Diagramlayoutmotorn beräknar dem från hierarkin, värdena och tillgängligt utrymme.

**Varför ändras färgerna efter att presentationstemat har ändrats?**

Temabaserade fyllningar är avsedda att följa presentationens palett. Applicera explicita RGB‑färger på de nivåer som måste vara fasta, eller behåll schemafärger när anpassning till ett nytt tema föredras.

**Behålls anpassad formatering i PDF‑ och bildexport?**

Ja, stödjade diagramfyllningar och etikettinställningar inkluderas vid rendering. För konsekventa resultat på olika system, gör de erforderliga teckensnitten tillgängliga och testa den slutgiltiga exportens storlek eftersom etikettpassning beror på layouten.

## **Se även**

- [Skapa Treemap‑diagram](/slides/sv/cpp/create-chart/#create-tree-map-charts)
- [Skapa Sunburst‑diagram](/slides/sv/cpp/create-chart/#create-sunburst-charts)
- [Exportera presentationsdiagram](/slides/sv/cpp/export-chart/)
- [Hantera presentationsteman](/slides/sv/cpp/presentation-theme/)