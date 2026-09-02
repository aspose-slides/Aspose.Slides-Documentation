---
title: Adatpontok testreszabása Treemap és Sunburst diagramokban C++-ban
linktitle: Adatpontok Treemap és Sunburst diagramokban
type: docs
url: /hu/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap diagram
- sunburst diagram
- hierarchikus diagram
- adatpont
- adatcímke
- ág színe
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre hierarchikus adatokat, és testreszabhatja a szinteket, címkéket és színeket Treemap és Sunburst diagramokban az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

A Treemap és a Sunburst diagramok ugyanazt a hierarchikus adatot jelenítik meg, de különböző elrendezéseket használnak. A Treemap a hierarchiát egymásba ágyazott téglalapokként rajzolja, amelyek területe a levélértékeket jelenti. A Sunburst a hierarchiát koncentrikus körökkel ábrázolja: a legfelső szintű csoportok a közép közelében vannak, a levélkategóriák pedig a külső körön.

Az Aspose.Slides for C++-ben minden numerikus érték egy [IChartDataPoint](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/). Az [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) metódusa hozzáférést biztosít a levélhez és annak szülőcsoportjaihoz. Ez a cikk bemutatja ezt a leképezést, és megmutatja, hogyan hozhatók létre és formázhatók mindkét diagramtípus ugyanabból a mintaadatból.

![Treemap diagram a Fogyasztó és Üzleti ágakkal](treemap-hierarchy.png)

![Sunburst diagram ugyanazzal a Fogyasztó és Üzleti hierarchiával](sunburst-hierarchy.png)

## **Kategóriák, adatpontok és szintek megértése**

Az alább használt minta három kategóriaszintet és egy numerikus sorozatot tartalmaz:

| Ágazat | Ág | Levél | Bevétel |
| --- | --- | --- | ---: |
| Fogyasztó | Számítógépek | Laptopok | 12 |
| Fogyasztó | Számítógépek | Asztali gépek | 8 |
| Fogyasztó | Mobil | Telefonok | 15 |
| Fogyasztó | Mobil | Tabletták | 6 |
| Üzleti | Szolgáltatások | Tanácsadás | 10 |
| Üzleti | Szolgáltatások | Támogatás | 7 |
| Üzleti | Szoftver | Licenc | 11 |
| Üzleti | Szoftver | Előfizetések | 14 |

Minden sor egy levélkategóriát és egy adatpontot hoz létre. A kategória csoportosítási szintek leírják az útvonalat a levél és a szülői elemei között. Az első sor esetén az útvonal: `Fogyasztó > Számítógépek > Laptopok`.

Az [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) által visszaadott indexek a levélről felfelé haladnak:

| `get_DataPointLevels()` index | Logikai szint | Treemap ábrázolás | Sunburst ábrázolás |
| ---: | --- | --- | --- |
| `0` | Levél | Érték téglalap | Külső kör szegmens |
| `1` | Ág | Szülő téglalap vagy fejléc | Középső kör szegmens |
| `2` | Ágazat | Legfelső téglalap vagy fejléc | Belső kör szegmens |

Ez a sorrend mindkét diagramtípusnál ugyanaz, bár a vizuális elrendezésük eltér. Egy szülő szegmenst több levél oszt meg. Formázásához használja az adott csoport első adatpontjának megfelelő szintjét. Például a `Fogyasztó` ágazat a `Laptopok` ponttal kezdődik, míg a `Szoftver` ág a `Licenc` ponttal. Az ilyen referenciák tárolása egyértelműbb és biztonságosabb, mint a `dataPoints->idx_get(0)` vagy `dataPoints->idx_get(6)` kifejezések használata.

## **Mindkét diagramtípus létrehozása és testreszabása**

Az alábbi teljes példa az első dián egy Treemap-et, a második dián pedig egy Sunburst-ot hoz létre. Felépíti a hierarchiát, megjeleníti a `Tabletták` értékét, rögzített színeket alkalmaz a kiválasztott szintekre, formáz egy ágazatcímkét, és elmenti a prezentációt.

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

    // Add the leaf categories. A grouping item is set only when a new group begins;
    // the following categories remain in that group until another item is set.
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

    // Show the category and value on the Tablets leaf.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Format the Consumer branch through the first leaf in that branch.
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

    // Format the Software stem through the first leaf in that stem.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout affects Treemap parent labels; Sunburst uses ring segments.
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

A kategória cellák és az érték cellák ugyanazon munkalap sorra hivatkoznak, így a gyűjteményük pozíciója összhangban marad. Ha egy már létező diagramot szeretne módosítani, először vizsgálja meg a kategóriasorokat, és tárolja a formázni kívánt adatpontok és szintek nevű hivatkozásait.

## **Viselkedés és gyakorlati megfontolások**

### **Treemap és Sunburst különbségek**

- A Treemap területet használ az érték közvetítésére, és egymásba ágyazott téglalapokkal a hierarchiát. A [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) metódus szabályozza, hogyan jelennek meg a szülőcímkék ebben a diagramtípusban.
- A Sunburst szöget használ az érték közvetítésére, a gyűrűmélységet a hierarchiáért. Az [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) **nem** szabályozza a gyűrűcímkéket.
- Mindkét diagramtípus ugyanazt a kategória csoportosítási szintet és a [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) által visszaadott levél‑szülő sorrendet használja, így az adatépítő és szint‑formázó kód megosztható.
- A szülői értékeket a leszármazott levelek alapján számítják ki. Ne adjon hozzá külön numerikus pontokat ágazatokhoz vagy ágakhoz.

### **Rendezés és szegmens sorrend**

A diagramelrendező motor határozza meg a téglalapok és gyűrűszegmensek végső helyzetét. Helyezze a kapcsolódó kategóriasorokat egymás mellé, mielőtt hozzáadná őket, de ne támaszkodjon egy konkrét téglalappozícióra vagy kezdő szögre. Ha a sorrend jelentéssel bír, tüntesse fel a címkékben, vagy használjon olyan diagramtípust, amelynek kifejezett kategória‑tengelye van.

### **Téma és rögzített színek**

A formázatlan diagramszintek a prezentáció téma színeit öröklik. A példa kifejezett RGB kitöltéseket használ a kiszámítható kimenet érdekében. Ha a diagramnak a téma változásaival kell együtt változnia, használjon sémaszín‑értékeket a rögzített RGB helyett, és kerülje el minden szint felülírását. Emellett ellenőrizze a címke kontrasztját, ha egy ágazat vagy ág kitöltését módosítja.

### **Címkék és elérhető hely**

A PowerPoint elrejtheti vagy rövidítheti a címkéket, ha egy szegmens túl kicsi. A diagram méretének növelése, a kategórianév rövidítése vagy a megjelenített címkefieldszám csökkentése általában tisztább eredményt ad. Egy címke kombinálhatja a kategórianév, a sorozatnév és az érték megjelenítését a [IDataLabelFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/idatalabelformat/) segítségével, de minden mező engedélyezése gyakran nehezíti a hierarchikus diagramok olvashatóságát.

### **Exportálás és renderelés**

A PPTX formátumba mentés a diagram szerkeszthető maradását biztosítja. Amikor az Aspose.Slides a prezentációt PDF‑re vagy képre rendereli, a támogatott kitöltések és címke‑beállítások a diagrammal együtt kerülnek megjelenítésre. Betűtípus‑helyettesítés és a rendelkezésre álló elrendezési hely kis különbségei megváltoztathatják a sortörést vagy a címke láthatóságát, ezért telepítse a szükséges betűtípusokat, és ellenőrizze a fontos exportcélokat.

## **GYIK**

**Miért befolyásolja egy szülő szint módosítása több levelet?**  
Egy ágazat vagy ág megosztott vizuális szegmens. Az [IChartDataPointLevel](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointlevel/) elérhető egy leszármazott levélön keresztül, de a formázás a megosztott szülő szegmensre vonatkozik, nem csak az adott levélre.

**Miért hiányzik egy adatcímke?**  
Először engedélyezze a szükséges mezőket a címke [IDataLabelFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/idatalabelformat/) objektumán. Ezután ellenőrizze, hogy a szegmensnek van‑e elegendő helye. A Treemap szülő‑címkelayout, a diagram méretei, a címke hossza, a betűméret és az engedélyezett mezők száma mind befolyásolják, hogy megjeleníthető‑e a címke.

**Beállíthatom a szegmensek pontos sorrendjét vagy koordinátáit?**  
Irányíthatja a forrás‑sorok sorrendjét és biztosíthatja, hogy minden csoport összefüggő legyen, de nem adhat meg pontos Treemap téglalapokat vagy Sunburst szögeket. A diagramelrendező motor ezeket a hierarchiából, az értékekből és a rendelkezésre álló helyből számolja ki.

**Miért változnak a színek a prezentáció téma módosítása után?**  
A téma‑alapú kitöltések a prezentáció palettáját követik. Alkalmazzon kifejezett RGB‑színeket a rögzítendő szintekre, vagy tartsa meg a sémaszíneket, ha a téma‑váltásra való alkalmazkodás a cél.

**Megmarad a saját formázás PDF‑ és képexportoknál?**  
Igen, a támogatott diagram‑kitöltések és címke‑beállítások a renderelés során belekerülnek. A konzisztens eredmény érdekében tegye elérhetővé a szükséges betűtípusokat, és tesztelje a végleges exportméretet, mivel a címke‑illeszkedés az elrendezéstől függ.

## **Kapcsolódó anyagok**

- [Create Treemap charts](/slides/hu/cpp/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/hu/cpp/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/hu/cpp/export-chart/)
- [Manage presentation themes](/slides/hu/cpp/presentation-theme/)