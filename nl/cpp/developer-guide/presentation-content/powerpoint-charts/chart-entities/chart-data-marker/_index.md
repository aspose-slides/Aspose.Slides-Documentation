---
title: Beheer grafiekdatamarkers in presentaties met C++
linktitle: Datamarker
type: docs
url: /nl/cpp/chart-data-marker/
keywords:
- grafiek
- gegevenspunt
- marker
- markeropties
- markergrootte
- vultype
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u grafiekdatamarkers kunt aanpassen in Aspose.Slides voor C++, waardoor de impact van presentaties in PPT- en PPTX-formaat wordt vergroot met duidelijke C++-codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiekdatamarkers werkt in Aspose.Slides. Het toont hoe u een grafiek maakt, een serie en de gegevenspunten ervan benadert, afbeeldingsvullingen toepast op markers op het niveau van gegevenspunten, de markerafmeting aanpast en de bijgewerkte presentatie opslaat. Het vermeldt ook dat standaard marker‑vormen beschikbaar zijn via de `MarkerStyleType`‑enumeratie en dat de weergave van markers behouden blijft bij het exporteren van grafieken naar rasterformaten of SVG.

## **Grafiek‑markers instellen**
Aspose.Slides for C++ biedt een eenvoudige API om automatisch de marker van een grafiekserie in te stellen. In de volgende functie krijgt elke grafiekserie automatisch een ander standaardmarkersymbool.

De onderstaande code‑voorbeeld laat zien hoe u de marker van een grafiekserie automatisch instelt.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Grafiek‑markeropties instellen**
De markers kunnen op gegevenspunten van een bepaalde serie in een grafiek worden ingesteld. Om grafiek‑markeropties in te stellen, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
- Maak de standaardgrafiek aan.
- Stel de afbeelding in.
- Neem de eerste grafiekserie.
- Voeg een nieuw gegevenspunt toe.
- Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we de grafiek‑markeropties op het niveau van gegevenspunten ingesteld.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Grafiek‑markers op het niveau van seriedata‑punten instellen**
Nu kunnen de markers op gegevenspunten van een bepaalde serie in een grafiek worden ingesteld. Om grafiek‑markeropties in te stellen, volgt u de onderstaande stappen:

- Maak een instantie van de Presentation‑klasse.
- Maak de standaardgrafiek aan.
- Stel de afbeelding in.
- Neem de eerste grafiekserie.
- Voeg een nieuw gegevenspunt toe.
- Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we de grafiek‑markeropties op het niveau van gegevenspunten ingesteld.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantie van de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Toegang tot de eerste dia
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Voeg een grafiek toe met standaardgegevens
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Instellen van de index van het gegevensblad van de grafiek
int defaultWorksheetIndex = 0;

// Ophalen van het gegevensblad van de grafiek
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Verwijderen van standaard gegenereerde series en categorieën
chart->get_ChartData()->get_Series()->Clear();

// Nu een nieuwe serie toevoegen
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Haal de afbeelding op
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Voeg de afbeelding toe aan de collectie afbeeldingen van de presentatie
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Voeg hier een nieuw punt (1:3) toe.
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

## **Kleur toepassen op gegevenspunten**
U kunt kleur toepassen op gegevenspunten in de grafiek met Aspose.Slides for C++. De klassen [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) en **[IChartDataPointLevel](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapointlevel/)** zijn toegevoegd om toegang te krijgen tot de eigenschappen van gegevenspunt‑niveaus. Dit artikel toont hoe u kleur kunt benaderen en toepassen op gegevenspunten in een grafiek.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**Welke marker‑vormen zijn er standaard beschikbaar?**

Standaardvormen zijn beschikbaar (cirkel, vierkant, ruit, driehoek, enz.); de lijst wordt gedefinieerd door de [MarkerStyleType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/markerstyletype/)‑enumeratie. Als u een niet‑standaardvorm nodig hebt, gebruikt u een marker met een afbeelding‑vulling om aangepaste visuals te emuleren.

**Worden markers behouden bij het exporteren van een grafiek naar een afbeelding of SVG?**

Ja. Bij het renderen van grafieken naar [raster formats](/slides/nl/cpp/convert-powerpoint-to-png/) of het opslaan van [shapes as SVG](/slides/nl/cpp/render-a-slide-as-an-svg-image/), behouden markers hun uiterlijk en instellingen, inclusief grootte, vulling en omtrek.