---
title: Diagram adat sorozatok kezelése prezentációkban C++ használatával
linktitle: Adatsorok
type: docs
url: /hu/cpp/chart-series/
keywords:
  - diagram sorozat
  - sorozat átfedés
  - sorozat szín
  - kategória szín
  - sorozat név
  - adatpont
  - sorozat hézag
  - PowerPoint
  - prezentáció
  - C++
  - Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a diagram sorozatokat C++ nyelven PowerPoint (PPT/PPTX) esetén gyakorlati kódrészletekkel és legjobb gyakorlatokkal, hogy javítsa adatprezentációit."
---
## **Áttekintés**

Ez a cikk leírja a [ChartSeries](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts.chartseries/) szerepét az Aspose.Slides-ben, kiemelve, hogy az adatok hogyan vannak felépítve és megjelenítve a prezentációkban. Ezek az objektumok alapvető elemeket biztosítanak, amelyek meghatározzák az egyes adatpontkészleteket, kategóriákat és a diagram megjelenési paramétereit. A [ChartSeries](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts.chartseries/) használatával a fejlesztők zökkenőmentesen integrálhatják az alapul szolgáló adatforrásokat, és teljes irányítást tarthatnak a megjelenítés felett, ami dinamikus, adatvezérelt prezentációkat eredményez, amelyek világosan közvetítik az elemzéseket és következtetéseket.

A sorozat egy sor vagy oszlop számból áll, amely egy diagramon ábrázolva van.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Az adat sorozat átfedésének beállítása**

Az [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) metódussal megadhatja, hogy a sávok és oszlopok mennyire fedjék egymást egy 2D diagramon (tartomány: -100‑tól 100‑ig). Ez a tulajdonság az összes sorozatra érvényes a szülő sorozatcsoportban: ez a megfelelő csoporttulajdonság vetítése.

Használja a `get_ParentSeriesGroup()::set_Overlap()` metódust az `Overlap` kívánt értékének beállításához. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Adjon hozzá egy csoportosított oszlopdiagramot egy diára.
1. Hozzáférés az első diagram sorozathoz.
1. Hozzáférés a diagram sorozat `ParentSeriesGroup` tulajdonságához, és állítsa be a sorozat kívánt átfedési értékét.
1. Írja a módosított prezentációt egy PPTX fájlba.

Ez a C++ kód bemutatja, hogyan állítható be a diagram sorozat átfedése:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Diagram hozzáadása
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // A sorozat átfedésének beállítása
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// A prezentáció fájljának mentése lemezre
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Az adat sorozat színének módosítása**

Az Aspose.Slides for C++ lehetővé teszi a sorozat színének megváltoztatását a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Adj hozzá egy diagramot a diára.
1. Hozzáférés a színt módosítani kívánt sorozathoz. 
1. Állítsa be a kívánt kitöltéstípust és kitöltőszínt.
1. Mentse a módosított prezentációt.

Ez a C++ kód bemutatja, hogyan változtatható meg egy sorozat színe:

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Az adat sorozat kategória színének módosítása**

Az Aspose.Slides for C++ lehetővé teszi a sorozatkategória színének megváltoztatását a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Adj hozzá egy diagramot a diára.
1. Hozzáférés a színt módosítani kívánt sorozatkategóriához.
1. Állítsa be a kívánt kitöltéstípust és kitöltőszínt.
1. Mentse a módosított prezentációt.

Ez a C++ kód bemutatja, hogyan módosítható egy sorozatkategória színe:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Az adat sorozat nevének módosítása** 

Alapértelmezés szerint a diagram jelmagyarázatának nevei a megfelelő oszlop vagy sor feletti cellák tartalma.

Példánkban (mintakép) 

* az oszlopok a *Series 1, Series 2* és *Series 3*;
* a sorok a *Category 1, Category 2, Category 3* és *Category 4*.

Az Aspose.Slides for C++ lehetővé teszi a sorozat nevének frissítését vagy módosítását a diagram adataiban és a jelmagyarázatban. 

Ez a C++ kód bemutatja, hogyan változtatható meg egy sorozat neve a diagram adatainak `ChartDataWorkbook` részén:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Ez a C++ kód bemutatja, hogyan módosítható egy sorozat neve a jelmagyarázatban a `Series` segítségével:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **Az adat sorozat kitöltőszínének beállítása**

Az Aspose.Slides for C++ lehetővé teszi a diagram sorozatok automatikus kitöltőszínének beállítását a rajzterületen a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Szerezze meg a dia hivatkozását indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típus szerint (az alábbi példában a `ChartType::ClusteredColumn` típust használtuk).
1. Hozzáférés a diagram sorozathoz, és állítsa be a kitöltőszínt Automatikusra.
1. Mentse a prezentációt egy PPTX fájlba.

Ez a C++ kód bemutatja, hogyan állítható be az automatikus kitöltőszín egy diagram sorozathoz:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Létrehoz egy csoportosított oszlopdiagramot
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Beállítja a sorozat kitöltési formátumát automatikusra
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// A prezentáció fájlját lemezre menti
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Az adat sorozat invertált kitöltőszínének beállítása**

Az Aspose.Slides lehetővé teszi az invertált kitöltőszín beállítását a diagram sorozatokhoz a rajzterületen a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Szerezze meg a dia hivatkozását indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típus szerint (az alábbi példában a `ChartType::ClusteredColumn` típust használtuk).
1. Hozzáférés a diagram sorozathoz, és állítsa be a kitöltőszínt invertáltra.
1. Mentse a prezentációt egy PPTX fájlba.

Ez a C++ kód bemutatja a műveletet:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Adds new series and categories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the first chart series and populates its series data.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```

## **Invertált kitöltőszín beállítása diagram sorozathoz**

Az Aspose.Slides lehetővé teszi az invertálás beállítását a `IChartDataPoint::set_InvertIfNegative()` és `ChartDataPoint.set_InvertIfNegative()` metódusok segítségével. Ha egy invertálás be van állítva a metódusokkal, az adatpont megfordítja színeit, amikor negatív értéket kap. 

Ez a C++ kód bemutatja a műveletet:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **Specifikus adatpont értékek törlése**

Az Aspose.Slides for C++ lehetővé teszi a specifikus diagram sorozat `DataPoints` adatainak törlését a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
2. Szerezze meg egy dia hivatkozását az indexe alapján.
3. Szerezze meg egy diagram hivatkozását az indexe alapján.
4. Iteráljon végig a diagram összes `DataPoints` elemén, és állítsa be az `XValue` és `YValue` értékeket nullára.
5. Törölje az összes `DataPoints`-et a specifikus diagram sorozatban.
6. Írja a módosított prezentációt egy PPTX fájlba.

Ez a C++ kód bemutatja a műveletet:

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **Az adat sorozat hézagszélességének beállítása**

Az Aspose.Slides for C++ lehetővé teszi egy sorozat hézagszélességének beállítását a **`set_GapWidth()`** metóduson keresztül a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Hozzáférés az első diához.
1. Diagram hozzáadása alapértelmezett adatokkal.
1. Hozzáférés bármely diagram sorozathoz.
1. Állítsa be a `GapWidth` tulajdonságot.
1. Írja a módosított prezentációt egy PPTX fájlba.

Ez a C++ kód bemutatja, hogyan állítható be egy sorozat hézagszélessége:

```cpp
// Üres prezentáció létrehozása
auto presentation = System::MakeObject<Presentation>();

// Hozzáférés a prezentáció első diájához
auto slide = presentation->get_Slides()->idx_get(0);

// Diagram hozzáadása alapértelmezett adatokkal
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Beállítja a diagram adatlap indexét
int32_t worksheetIndex = 0;

// A diagram adatlapjának lekérése
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Sorozatok hozzáadása
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Kategóriák hozzáadása
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Kiválasztja a második diagram sorozatot
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Kitölti a sorozat adatait
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Beállítja a GapWidth értékét
series->get_ParentSeriesGroup()->set_GapWidth(50);

// A prezentáció mentése lemezre
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Van korlát arra, hogy egy diagram hány sorozatot tartalmazhat?**

Az Aspose.Slides nem határoz meg fix felső határt a hozzáadott sorozatok számára. A gyakorlati határt a diagram olvashatósága és az alkalmazás rendelkezésre álló memóriája határozza meg.

**Mi a teendő, ha a klaszter belüli oszlopok túl közel vagy túl messze vannak egymástól?**

Állítsa be a hézagszélességet az adott sorozathoz (vagy annak szülő sorozatcsoportjához). Az érték növelése növeli az oszlopok közötti távolságot, míg csökkentése közelebb hozza őket egymáshoz.