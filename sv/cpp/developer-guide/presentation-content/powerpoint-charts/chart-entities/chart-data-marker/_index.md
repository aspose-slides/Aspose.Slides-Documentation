---
title: Hantera diagramdatamarkörer i presentationer med C++
linktitle: Datamarkör
type: docs
url: /sv/cpp/chart-data-marker/
keywords:
- diagram
- datapunkt
- markör
- marköralternativ
- markörstorlek
- fyllningstyp
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du anpassar diagramdatamarkörer i Aspose.Slides för C++ och ökar presentationens effekt i PPT- och PPTX-format med tydliga C++-kodexempel."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramdatamarkörer i Aspose.Slides. Den visar hur man skapar ett diagram, får åtkomst till en serie och dess datapunkter, använder bildfyllningar på markörer på datapunktsnivå, justerar markörstorlek och sparar den uppdaterade presentationen. Den nämner också att standardmarkörformer finns tillgängliga via uppräkningen `MarkerStyleType` och att markörens utseende bevaras när diagram exporteras till rasterformat eller SVG.

## **Ställ in diagrammarkörer**
Aspose.Slides för C++ erbjuder ett enkelt API för att automatiskt ange diagramseriens markör. I följande exempel får varje diagramserie automatiskt en annan standardmarkörsymbol.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Ange alternativ för diagrammarkörer**
Markörerna kan anges på diagramdatapunkter inom en viss serie. Följ stegen nedan för att ange diagrammarköralternativ:

- Instansiera [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) klass.
- Skapa standarddiagrammet.
- Ange bilden.
- Hämta den första diagramserien.
- Lägg till en ny datapunkt.
- Skriv presentationen till disk.

I exemplet nedan har vi angett diagrammarköralternativen på datapunktsnivå.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Ställ in diagrammarkörer på seriedatapunktsnivå**
Nu kan markörerna anges på diagramdatapunkter inom en viss serie. Följ stegen nedan för att ange diagrammarköralternativ:

- Instansiera Presentation-klass.
- Skapa standarddiagrammet.
- Ange bilden.
- Hämta den första diagramserien.
- Lägg till en ny datapunkt.
- Skriv presentationen till disk.

I exemplet nedan har vi angett diagrammarköralternativen på datapunktsnivå.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instansiera Presentation-klass som representerar PPTX-fil
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Kom åt första bilden
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Lägg till diagram med standarddata
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Setting the index of chart data sheet
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Delete default generated series and categories
chart->get_ChartData()->get_Series()->Clear();

// Now, Adding a new series
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Get the picture
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Add image to presentation's images collection
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Add new point (1:3) there.
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
series->get_Marker()->set_Size(15);

// Write the presentation file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **Applicera en färg på datapunkter**
Du kan applicera färg på datapunkter i diagrammet med Aspose.Slides för C++. Klasserna **[IChartDataPointLevelsManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/)** och **[IChartDataPointLevel](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapointlevel/)** har lagts till för att ge åtkomst till egenskaperna för datapunktsnivåer. Denna artikel visar hur du kan komma åt och applicera färg på datapunkter i ett diagram.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**Vilka markörformer finns tillgängliga direkt?**

Standardformer är tillgängliga (cirkel, fyrkant, diamant, triangel osv.); listan definieras av [MarkerStyleType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/markerstyletype/). Om du behöver en icke‑standardform, använd en markör med bildfyllning för att efterlikna anpassade visuella element.

**Behåller markörerna sitt utseende när ett diagram exporteras till en bild eller SVG?**

Ja. Vid rendering av diagram till [raster formats](/slides/sv/cpp/convert-powerpoint-to-png/) eller vid sparande av [shapes as SVG](/slides/sv/cpp/render-a-slide-as-an-svg-image/), behåller markörerna sitt utseende och sina inställningar, inklusive storlek, fyllning och kontur.