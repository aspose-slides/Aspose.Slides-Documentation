---
title: Diagram adatsorok kezelése prezentációkban C++-ban
linktitle: Adatsorok
type: docs
url: /hu/cpp/chart-series/
keywords:
- diagram adatsorok
- sor átfedés
- sor színe
- kategória színe
- sor neve
- adatpont
- sor hézag
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan kezelje a diagram sorokat C++-ban a PowerPoint (PPT/PPTX) számára, gyakorlati kódpéldákkal és legjobb gyakorlatokkal, hogy javítsa adatprezentációit."
---
## **Áttekintés**

Ez a cikk leírja a [ChartSeries](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartseries/) szerepét az Aspose.Slides-ban, kiemelve, hogyan szerveződik és jelenik meg az adat a prezentációkban. Ezek a objektumok biztosítják az alapvető elemeket, amelyek meghatározzák az egyes adatpontok, kategóriák és megjelenési paraméterek halmazait egy diagramon. A [ChartSeries](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartseries/) használatával a fejlesztők zökkenőmentesen integrálhatják a háttéradatforrásokat, és teljes irányítást gyakorolhatnak az információ megjelenítése felett, ami dinamikus, adatalapú prezentációkat eredményez, amelyek egyértelműen közvetítik a betekintéseket és az elemzéseket.

A sor egy sor vagy oszlop szám, amelyet egy diagramon ábrázolunk.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Az adat sor átfedésének beállítása**

Az [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) metódussal megadhatja, hogy a sávok és oszlopok milyen mértékben fedjék át egymást egy 2D diagramon (tartomány: -100‑tól 100‑ig). Ez a tulajdonság a szülő sorcsoport összes sorára vonatkozik: ez a megfelelő csoporttulajdonság projekciója.

Használja a `get_ParentSeriesGroup()::set_Overlap()` metódust az `Overlap` kívánt értékének beállításához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Adjon hozzá egy csoportosított oszlopdiagramot egy diára.
1. Érje el az első diagram sort.
1. Érje el a diagram sor `ParentSeriesGroup`‑ját, és állítsa be a sor kívánt átfedési értékét.
1. Írja a módosított prezentációt egy PPTX fájlba.

Ez a C++ kód megmutatja, hogyan állítható be egy diagram sor átfedése:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Diagram hozzáadása
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Beállítja a sor átfedését
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Writes the presentation file to disk
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Az adat sor színének módosítása**

Az Aspose.Slides for C++ lehetővé teszi a sor színének módosítását a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Adjon hozzá egy diagramot a diára.
1. Érje el azt a sorot, amelynek a színét módosítani kívánja.
1. Állítsa be a kívánt kitöltéstípust és kitöltőszínt.
1. Mentse el a módosított prezentációt.

Ez a C++ kód megmutatja, hogyan módosítható egy sor színe:

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

## **Az adat sor kategória színének módosítása**

Az Aspose.Slides for C++ lehetővé teszi egy sorkategória színének módosítását a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Adjon hozzá egy diagramot a diára.
1. Érje el azt a sorkategóriát, amelynek a színét módosítani kívánja.
1. Állítsa be a kívánt kitöltéstípust és kitöltőszínt.
1. Mentse el a módosított prezentációt.

Ez a C++ kód megmutatja, hogyan módosítható egy sorkategória színe:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Az adat sor nevének módosítása**

Alapértelmezés szerint egy diagram legendanevei a minden oszlop vagy sor feletti cellák tartalma.

A példánkban (mintaképen),

* az oszlopok: *Series 1, Series 2,* és *Series 3*;
* a sorok: *Category 1, Category 2, Category 3,* és *Category 4.*

Az Aspose.Slides for C++ lehetővé teszi egy sor nevének frissítését vagy módosítását a diagram adataiban és a legendában.

Ez a C++ kód megmutatja, hogyan változtatható meg egy sor neve a `ChartDataWorkbook` diagramadatban:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Ez a C++ kód megmutatja, hogyan változtatható meg egy sor neve a legendában a `Series` segítségével:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **Az adat sor kitöltőszínének beállítása**

Az Aspose.Slides for C++ lehetővé teszi a diagram sorok automatikus kitöltőszínének beállítását a plot területen a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Szerezze meg a dia hivatkozását indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típus szerint (az alábbi példában a `ChartType::ClusteredColumn` típust használtuk).
1. Érje el a diagram sort, és állítsa a kitöltőszínt Automatikusra.
1. Mentse el a prezentációt egy PPTX fájlba.

Ez a C++ kód megmutatja, hogyan állítható be a diagram sor automatikus kitöltőszíne:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Létrehoz egy csoportosított oszlopdiagramot
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Beállítja a sor kitöltési formátumát automatikusra
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// A prezentáció fájlt lemezre írja
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Az adat sor invertált kitöltőszíneinek beállítása**

Az Aspose.Slides lehetővé teszi az invertált kitöltőszín beállítását a diagram soroknál a `IChartDataPoint::set_InvertIfNegative()` és a `ChartDataPoint.set_InvertIfNegative()` metódusokon keresztül. Amikor egy invertálás van beállítva a metódusokkal, a adatpont inverzálja színeit negatív érték esetén.

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

// Új sorok és kategóriák hozzáadása
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Az első diagram sorát veszi, és feltölti a sor adataival.
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

## **Invertált kitöltőszín beállítása egy diagram sorhoz**

Az Aspose.Slides lehetővé teszi az invertált kitöltőszín beállítását a diagram soroknál a `IChartDataPoint::set_InvertIfNegative()` és a `ChartDataPoint.set_InvertIfNegative()` metódusokon keresztül. Amikor egy invertálás van beállítva a metódusokkal, a adatpont inverzálja színeit negatív érték esetén.

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

## **Megadott adatpont értékek törlése**

Az Aspose.Slides for C++ lehetővé teszi a `DataPoints` adatainak törlését egy konkrét diagram sorra a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
2. Szerezze meg a dia hivatkozását indexe alapján.
3. Szerezze meg a diagram hivatkozását indexe alapján.
4. Iteráljon végig a diagram összes `DataPoints` elemén, és állítsa az `XValue` és `YValue` értékeket nullára.
5. Törölje az összes `DataPoints` elemet a megadott diagram sorhoz.
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

## **Az adat sor hézag szélességének beállítása**

Az Aspose.Slides for C++ lehetővé teszi egy sor `GapWidth` beállítását a **`set_GapWidth()`** metóduson keresztül a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Érje el az első diát.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal.
1. Érje el bármelyik diagram sort.
1. Állítsa be a `GapWidth` tulajdonságot.
1. Írja a módosított prezentációt egy PPTX fájlba.

Ez a C++ kód megmutatja, hogyan állítható be egy sor Hézag Szélessége:

```cpp
// Létrehozza az üres prezentációt 
auto presentation = System::MakeObject<Presentation>();

// Eléri a prezentáció első diáját
auto slide = presentation->get_Slides()->idx_get(0);

// Diagramot ad hozzá alapértelmezett adatokkal
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Beállítja a diagram adatlapjának indexét
int32_t worksheetIndex = 0;

// Lekéri a diagram adatlapját
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Sorokat ad hozzá
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Kategóriákat ad hozzá
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// A második diagram sort veszi
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Feltölti a sor adatait
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Beállítja a GapWidth értékét
series->get_ParentSeriesGroup()->set_GapWidth(50);

// A prezentációt lemezre menti
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Van korláta annak, hogy egy diagram hány sorral rendelkezhet?**

Az Aspose.Slides nem szab meg fix felső határt a sorok számát illetően. A gyakorlati korlát a diagram olvashatóságában és az alkalmazás rendelkezésére álló memóriában rejlik.

**Mi van, ha a csoporton belüli oszlopok túl közel vagy túl messze vannak egymástól?**

Állítsa be a sor (vagy annak szülő sorcsoportja) hézag szélességét. Az érték növelése megnöveli a oszlopok közti távolságot, a csökkentése közelebb hozza őket.