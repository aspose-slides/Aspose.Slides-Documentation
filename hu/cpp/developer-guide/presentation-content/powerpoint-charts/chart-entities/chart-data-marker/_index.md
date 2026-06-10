---
title: Diagram adatjelölők kezelése prezentációkban C++ használatával
linktitle: Adatjelölő
type: docs
url: /hu/cpp/chart-data-marker/
keywords:
- diagram
- adatpont
- jelölő
- jelölő beállítások
- jelölő méret
- kitöltés típusa
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan testreszabhatja a diagram adatjelölőket az Aspose.Slides for C++-ban, növelve a prezentáció hatását a PPT és PPTX formátumokban, világos C++ kódrészletekkel."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhat a diagram adatjelölőkkel az Aspose.Slides-ben. Bemutatja, hogyan hozhat létre diagramot, érhet el egy sorozatot és annak adatpontjait, hogyan alkalmazhat képtöltéseket a jelölőkre adatpont szinten, hogyan állíthatja be a jelölő méretét, és hogyan mentheti el a frissített prezentációt. Továbbá megjegyzi, hogy a szabványos jelölő alakzatok a `MarkerStyleType` felsorolásban érhetők el, és a jelölő megjelenése megmarad, amikor diagramot exportál raster formátumokba vagy SVG-be.

## **Diagram jelölők beállítása**
Az Aspose.Slides for C++ egyszerű API-t biztosít a diagram sorozat jelölőjének automatikus beállításához. A következő funkcióban minden diagram sorozat automatikusan különböző alapértelmezett jelölőszimbólumot kap.

Az alábbi kódrészlet bemutatja, hogyan állítható be a diagram sorozat jelölője automatikusan.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Diagram jelölő beállításainak megadása**
A jelölők beállíthatók egy adott sorozaton belüli diagram adatpontokra. A diagram jelölő opcióinak beállításához kövesse az alábbi lépéseket:

- Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályt.
- A alapértelmezett diagram létrehozása.
- A kép beállítása.
- Az első diagram sorozat kiválasztása.
- Új adatpont hozzáadása.
- A prezentáció írása a lemezre.

Az alább bemutatott példában a diagram jelölő beállításait adatpont szinten állítottuk be.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Diagram jelölők beállítása a sorozat adatpont szintjén**
Hozzá lehet rendelni a jelölőket egy adott sorozaton belüli diagram adatpontokhoz. A diagram jelölő opcióinak beállításához kövesse az alábbi lépéseket:

- Példányosítsa a Presentation osztályt.
- A alapértelmezett diagram létrehozása.
- A kép beállítása.
- Az első diagram sorozat kiválasztása.
- Új adatpont hozzáadása.
- A prezentáció írása a lemezre.

Az alább bemutatott példában a diagram jelölő beállításait adatpont szinten állítottuk be.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantiate Presentation class that represents PPTX file
//Példányosítsa a Presentation osztályt, amely a PPTX fájlt képviseli
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Access first slide
//Az első dia elérése
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Add chart with default data
// Alapértelmezett adatokkal rendelkező diagram hozzáadása
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Setting the index of chart data sheet
// A diagram adatlap indexének beállítása
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
// A diagram adatlapjának lekérdezése
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Delete default generated series and categories
// Az alapértelmezés szerint létrehozott sorozatok és kategóriák törlése
chart->get_ChartData()->get_Series()->Clear();

// Now, Adding a new series
// Most, új sorozat hozzáadása
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Get the picture
// A kép lekérése
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Add image to presentation's images collection
// Kép hozzáadása a prezentáció képgyűjteményéhez
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Add new point (1:3) there.
 // Új pont (1:3) hozzáadása ott.
SharedPtr<IChartDataPoint> point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

// Changing the chart series marker
// A diagram sorozat jelölőjének módosítása
series->get_Marker()->set_Size(15);

// Write the presentation file to disk
// A prezentáció fájl írása a lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **Szín alkalmazása adatpontokra**
A diagram adatpontjaira színt alkalmazhat az Aspose.Slides for C++ használatával. A [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) és **[IChartDataPointLevel](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointlevel/)** osztályok hozzá lettek adva, hogy hozzáférést biztosítsanak az adatpont szintek tulajdonságaihoz. Ez a cikk bemutatja, hogyan férhet hozzá és alkalmazhat színt a diagram adatpontjaira.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **GYIK**

**Mely jelölő formák állnak rendelkezésre alapértelmezés szerint?**

A szabványos formák elérhetők (kör, négyszög, rombusz, háromszög stb.); a lista a [MarkerStyleType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/markerstyletype/) felsorolásban van meghatározva. Ha nem szabványos formára van szüksége, használjon képtöltéses jelölőt a saját egyedi vizuálok szimulálásához.

**Megmaradnak a jelölők, amikor diagramot exportál képre vagy SVG-re?**

Igen. Amikor diagramokat renderel [raszteres formátumokba](/slides/hu/cpp/convert-powerpoint-to-png/) vagy [alakzatokat SVG-ként menti](/slides/hu/cpp/render-a-slide-as-an-svg-image/), a jelölők megtartják megjelenésüket és beállításaikat, beleértve a méretet, a kitöltést és a körvonalat.