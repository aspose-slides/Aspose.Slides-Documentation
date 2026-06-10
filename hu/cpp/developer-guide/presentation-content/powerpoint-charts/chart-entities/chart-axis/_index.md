---
title: "Diagram tengelyek testreszabása prezentációkban C++ használatával"
linktitle: "Diagramtengely"
type: docs
url: /hu/cpp/chart-axis/
keywords:
- diagramtengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságai
- maximális érték
- minimális érték
- tengely vonal
- dátumformátum
- tengelycím
- tengely helyzete
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan használhatja az Aspose.Slides for C++-t a diagramtengelyek testreszabásához PowerPoint prezentációkban jelentésekhez és vizualizációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet személyre szabni a diagramtengelyeket az Aspose.Slides-ban. Megmutatja, hogyan lehet lekérni a tényleges tengelyértékeket, hogyan lehet adatot cserélni a tengelyek között, hogyan lehet elrejteni a függőleges vagy vízszintes tengelyt vonaldiagramoknál, hogyan lehet módosítani a kategória tengely típusát, hogyan lehet beállítani a dátumformátumot a kategória tengely értékeihez, hogyan lehet forgatni a tengelycímkét, hogyan lehet beállítani a tengely helyzetét, és hogyan lehet egységcímkét megjeleníteni az érték tengelyen.

## **A függőleges tengely maximális értékeinek lekérése**
Az Aspose.Slides for C++ lehetővé teszi a függőleges tengely minimális és maximális értékeinek lekérését. Kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
2. Hozzáférjen az első diára.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal.
4. Szerezze meg a tényleges maximális értéket a tengelyen.
5. Szerezze meg a tényleges minimális értéket a tengelyen.
6. Szerezze meg a tényleges fő egységet a tengelyen.
7. Szerezze meg a tényleges alsegységet a tengelyen.
8. Szerezze meg a tényleges fő egység skáláját a tengelyen.
9. Szerezze meg a tényleges alsegység skáláját a tengelyen.

Ez a minta kód – a fenti lépések megvalósítása – megmutatja, hogyan lehet a szükséges értékeket C++-ban lekérni:

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
Az Aspose.Slides lehetővé teszi az adatok gyors cseréjét a tengelyek között – a függőleges tengelyen (y-tengely) megjelenő adatok átkerülnek a vízszintes tengelyre (x-tengely) és fordítva.

Ez a C++ kód bemutatja, hogyan hajtható végre az adatcsere a diagram tengelyei között:

``` cpp
// Létrehozza az üres prezentációt
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Sorok és oszlopok felcserélése
chart->get_ChartData()->SwitchRowColumn();

// Elmenti a prezentációt
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **A függőleges tengely letiltása vonaldiagramoknál**

Ez a C++ kód megmutatja, hogyan lehet elrejteni a függőleges tengelyt egy vonaldiagramnál:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **A vízszintes tengely letiltása vonaldiagramoknál**

Ez a kód megmutatja, hogyan lehet elrejteni a vízszintes tengelyt egy vonaldiagramnál:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Kategória tengely módosítása**

A **set_CategoryAxisType()** metódussal megadhatja a kívánt kategória tengely típusát (**date** vagy **text**). Ez a C++ kód demonstrálja a műveletet:

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

## **Dátumformátum beállítása a kategória tengely értékeihez**
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

## **Tengelycím forgatási szögének beállítása**
Az Aspose.Slides for C++ lehetővé teszi a diagramtengely címének forgatási szögének beállítását. Ez a C++ kód demonstrálja a műveletet:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Tengely pozíció beállítása kategória vagy érték tengelyen**
Az Aspose.Slides for C++ lehetővé teszi a tengely pozíciójának beállítását egy kategória vagy érték tengelyen. Ez a C++ kód megmutatja, hogyan hajtható végre a feladat:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Egységcímke megjelenítésének engedélyezése diagram érték tengelyen**
Az Aspose.Slides for C++ lehetővé teszi egy diagram konfigurálását úgy, hogy egységcímkét jelenítsen meg a diagram érték tengelyén. Ez a C++ kód demonstrálja a műveletet:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Hogyan állíthatom be azt az értéket, ahol az egyik tengely metszi a másikat (tengelymetszet)?**

A tengelyek rendelkeznek egy [crossing setting](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/axis/set_crosstype/): választhat, hogy a nullánál, a legnagyobb kategóriánál/értéknél vagy egy konkrét numerikus értéknél metszi. Ez hasznos az X-tengely feljebb vagy lejjebb helyezéséhez, illetve egy alapvonal hangsúlyozásához.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez képest (közeli, külső, belső)?**

Állítsa be a [label position](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/axis/set_majortickmark/) értékét "cross", "outside" vagy "inside" értékre. Ez befolyásolja az olvashatóságot és segít helyet megtakarítani, különösen kis diagramok esetén.