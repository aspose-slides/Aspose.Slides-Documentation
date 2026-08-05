---
title: Diagram adatjelölők kezelése prezentációkban C++-al
linktitle: Adatjelölő
type: docs
url: /hu/cpp/chart-data-marker/
keywords:
- diagram
- adatpont
- jelölő
- jelölő beállítások
- jelölőméret
- kitöltés típusa
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan szabhatja testre a diagram adatjelölőket az Aspose.Slides for C++-ban, ezáltal növelve a prezentáció hatását a PPT és PPTX formátumokban, egyértelmű C++ kódpéldákkal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet dolgozni a diagram adatjelölőkkel az Aspose.Slides-ben. Megmutatja, hogyan kell diagramot létrehozni, elérni egy sorozatot és annak adatpontjait, képpillanat kitöltést alkalmazni a jelölőkre adatpont szinten, a jelölő méretét beállítani, és a frissített bemutatót elmenteni. Továbbá megjegyzi, hogy a szabványos jelölőalakok a `MarkerStyleType` felsorolásban érhetők el, és hogy a jelölő megjelenése megmarad a diagramok raster formátumokba vagy SVG-be exportálása során.

## **Diagram jelölők beállítása**
Az Aspose.Slides for C++ egyszerű API-t biztosít a diagram sorozat jelölőjének automatikus beállításához. A következő funkcióban minden diagram sorozat automatikusan különböző alapértelmezett jelölőszimbólumot kap.

Az alábbi kódrészlet megmutatja, hogyan lehet automatikusan beállítani a diagram sorozat jelölőjét.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Diagram jelölő beállítások**
A jelölőket be lehet állítani egy adott sorozaton belüli diagram adatpontokra. A diagram jelölő beállításainak módosításához kövesse az alábbi lépéseket:

- Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályt.
- Hozzon létre egy alapértelmezett diagramot.
- Állítsa be a képet.
- Vegye az első diagram sorozatot.
- Adjon hozzá egy új adatpontot.
- Írja a prezentációt a lemezre.

Az alábbi példában a diagram jelölő beállításait adatpont szinten állítottuk be.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Diagram jelölők beállítása a sorozat adatpont szintjén**
Mostantól a jelölőket be lehet állítani egy adott sorozaton belüli diagram adatpontokra. A diagram jelölő beállításainak módosításához kövesse az alábbi lépéseket:

- Hozzon létre egy Presentation osztályt.
- Hozzon létre egy alapértelmezett diagramot.
- Állítsa be a képet.
- Vegye az első diagram sorozatot.
- Adjon hozzá egy új adatpontot.
- Írja a prezentációt a lemezre.

Az alábbi példában a diagram jelölő beállításait adatpont szinten állítottuk be.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantiate Presentation class that represents PPTX file
//Access first slide
// Add diagramot alapértelmezett adatokkal
// a diagram adatlap indexének beállítása
// a diagram adatlap munkalapjának lekérése
// az alapértelmezett generált sorozatok és kategóriák törlése
// Most egy új sorozat hozzáadása
// A kép lekérése
// Kép hozzáadása a prezentáció képgyűjteményéhez
// Új pont hozzáadása (1:3) itt.

SharedPtr<Presentation> pres = MakeObject<Presentation>();
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);
int defaultWorksheetIndex = 0;
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Clear();
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);
image->Dispose();
image2->Dispose();
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
series->get_Marker()->set_Size(15);
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **Szín alkalmazása adatpontokra**
Színt alkalmazhat a diagram adatpontjaira az Aspose.Slides for C++ használatával. A [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) és **[IChartDataPointLevel](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointlevel/)** osztályok hozzá lettek adva, hogy hozzáférjenek az adatpont szintek tulajdonságaihoz. Ez a cikk bemutatja, hogyan érheti el és alkalmazhat színt a diagram adatpontjaira.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **GYIK**

**Milyen jelölőalakok érhetők el alapból?**

A szabványos alakok elérhetők (kör, négyzet, rombusz, háromszög stb.); a lista a [MarkerStyleType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/markerstyletype/) felsorolásban van meghatározva. Ha nem szabványos alakra van szüksége, használjon képpel kitöltött jelölőt a saját vizuálok megjelenítéséhez.

**A jelölők megmaradnak a diagram kép vagy SVG formátumba exportálásakor?**

Igen. A diagramok [raster formats](/slides/hu/cpp/convert-powerpoint-to-png/) formátumba történő renderelésekor vagy a [shapes as SVG](/slides/hu/cpp/render-a-slide-as-an-svg-image/) mentésekor a jelölők megtartják megjelenésüket és beállításaikat, beleértve a méretet, a kitöltést és a körvonalat.