---
title: Diagram tengelyek testreszabása prezentációkban C++ használatával
linktitle: Diagram tengely
type: docs
url: /hu/cpp/chart-axis/
keywords:
- diagram tengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságok
- maximális érték
- minimális érték
- tengely vonal
- dátum formátum
- tengely cím
- tengely pozíció
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for C++-t a diagram tengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk számára."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides-ban. Megmutatja, hogyan lehet lekérdezni a tényleges tengelyértékeket, adatokat cserélni a tengelyek között, elrejteni a függőleges vagy vízszintes tengelyt vonaldiagramoknál, megváltoztatni a kategória tengely típusát, beállítani a dátumformátumot a kategória tengely értékekhez, elforgatni egy tengelycímkét, megadni a tengely pozícióját, és megjeleníteni egy egységcímkét az értéktengelyen.

## **A függőleges tengely maximális értékeinek lekérése**
Az Aspose.Slides for C++ lehetővé teszi a minimális és maximális értékek lekérését egy függőleges tengelyen. Kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Nyissa meg az első diát.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal.
1. Szerezze meg a tényleges maximális értéket a tengelyen.
1. Szerezze meg a tényleges minimális értéket a tengelyen.
1. Szerezze meg a tényleges főegységet a tengelyen.
1. Szerezze meg a tényleges alsegységet a tengelyen.
1. Szerezze meg a tényleges főegység skálát a tengelyen.
1. Szerezze meg a tényleges alsegység skálát a tengelyen.

Ez a mintakód – amely a fenti lépéseket valósítja meg – megmutatja, hogyan lehet lekérni a szükséges értékeket C++-ban:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// Elmenti a prezentációt
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **Adatok cseréje a tengelyek között**
Az Aspose.Slides lehetővé teszi az adatok gyors cseréjét a tengelyek között – a függőleges tengelyen (y-tengely) lévő adat áthelyeződik a vízszintes tengelyre (x-tengely), és vissza.

Ez a C++ kód megmutatja, hogyan hajtható végre az adatcsere feladat a diagram tengelyei között:

``` cpp
// Üres prezentációt hoz létre
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Sorokat és oszlopokat cserél
chart->get_ChartData()->SwitchRowColumn();

// Elmenti a prezentációt
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **A függőleges tengely letiltása vonaldiagramoknál**
Ez a C++ kód megmutatja, hogyan lehet elrejteni a függőleges tengelyt egy vonaldiagramon:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **A vízszintes tengely letiltása vonaldiagramoknál**
Ez a kód megmutatja, hogyan lehet elrejteni a vízszintes tengelyt egy vonaldiagramon:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Kategória tengely módosítása**
A **set_CategoryAxisType()** metódus segítségével megadhatja a kívánt kategória tengely típusát (**date** vagy **text**). Ez a C++ kód demonstrálja a műveletet:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **A kategória tengely értékek dátumformátumának beállítása**
Az Aspose.Slides for C++ lehetővé teszi a dátumformátum beállítását egy kategória tengely értékéhez. A műveletet ez a C++ kód mutatja be:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **A tengelycím elforgatási szögének beállítása**
Az Aspose.Slides for C++ lehetővé teszi a diagram tengelycím elforgatási szögének beállítását. Ez a C++ kód demonstrálja a műveletet:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **A tengely pozíciójának beállítása kategória vagy értéktengelyen**
Az Aspose.Slides for C++ lehetővé teszi a tengelypozíció beállítását egy kategória vagy értéktengelyen. Ez a C++ kód bemutatja, hogyan hajtható végre a feladat:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Az egységcímke megjelenítésének engedélyezése a diagram értéktengelyen**
Az Aspose.Slides for C++ lehetővé teszi, hogy a diagram értéktengelyén egységcímkét jelenítsen meg. Ez a C++ kód demonstrálja a műveletet:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Hogyan állíthatom be azt az értéket, ahol egy tengely keresztezi a másikat (tengelykereszteződés)?**

A tengelyek [kereszteződés beállítást](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/axis/set_crosstype/) kínálnak: választhat, hogy a nullánál, a maximális kategóriánál/értéknél vagy egy konkrét numerikus értéknél keressek át. Ez hasznos az X-tengely fel vagy le mozgatásához, illetve egy referenciavonal hangsúlyozásához.

**Hogyan pozícionálhatom a jelölőcímkéket a tengelyhez viszonyítva (oldal mellett, kívül, belül)?**

Állítsa a [címke pozíciót](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/axis/set_majortickmark/) "cross", "outside" vagy "inside" értékre. Ez befolyásolja az olvashatóságot és segít helyet takarítani, különösen kis diagramok esetén.