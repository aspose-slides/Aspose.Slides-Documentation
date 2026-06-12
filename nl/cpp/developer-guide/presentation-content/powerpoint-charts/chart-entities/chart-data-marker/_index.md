---
title: Beheer diagramdatamarkers in presentaties met C++
linktitle: Datamarker
type: docs
url: /nl/cpp/chart-data-marker/
keywords:
- diagram
- datumpunt
- marker
- markeropties
- markergrootte
- vultype
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u diagramdatamarkers kunt aanpassen in Aspose.Slides voor C++, waardoor de impact van uw presentatie wordt vergroot in PPT- en PPTX-formaten met duidelijke C++-codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u met diagramdatamarkers in Aspose.Slides werkt. Het laat zien hoe u een diagram maakt, een serie en de datapunten ervan benadert, afbeeldingvullingen toepast op markers op het niveau van datapunten, de markergrootte aanpast, en de bijgewerkte presentatie opslaat. Het vermeldt ook dat standaardmarker‑vormen beschikbaar zijn via de `MarkerStyleType`‑enumeratie en dat de weergave van markers behouden blijft bij het exporteren van diagrammen naar rasterformaten of SVG.

## **Diagrammarkers instellen**

Aspose.Slides for C++ biedt een eenvoudige API om de diagramserie‑marker automatisch in te stellen. In de volgende functie krijgt elke diagramserie automatisch een ander standaardmarkersymbool.

De onderstaande codevoorbeeld toont hoe u de diagramserie‑marker automatisch instelt.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Opties voor diagrammarkers instellen**

De markers kunnen ingesteld worden op diagramdatapunten binnen een specifieke serie. Om diagrammarker‑opties in te stellen, volg de onderstaande stappen:

- Instantieer de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
- Maak het standaarddiagram.
- Stel de afbeelding in.
- Neem de eerste diagramserie.
- Voeg een nieuw datumpunt toe.
- Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we de diagrammarker‑opties op het niveau van datapunten ingesteld.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Diagrammarkers instellen op het niveau van seriedatapunten**

Nu kunnen de markers ingesteld worden op diagramdatapunten binnen een specifieke serie. Om diagrammarker‑opties in te stellen, volg de onderstaande stappen:

- Instantieer de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
- Maak het standaarddiagram.
- Stel de afbeelding in.
- Neem de eerste diagramserie.
- Voeg een nieuw datumpunt toe.
- Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we de diagrammarker‑opties op het niveau van datapunten ingesteld.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantieer de Presentation-klasse die een PPTX-bestand voorstelt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Toegang tot de eerste dia
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Voeg een diagram toe met standaardgegevens
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Instellen van de index van het datablad van het diagram
int defaultWorksheetIndex = 0;

// Ophalen van het werkblad met diagramgegevens
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Verwijder de standaardgegenereerde series en categorieën
chart->get_ChartData()->get_Series()->Clear();

// Nu wordt een nieuwe serie toegevoegd
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Haal de afbeelding op
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Voeg afbeelding toe aan de afbeeldingen-collectie van de presentatie
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

## **Kleur toepassen op datapunten**

U kunt kleur toepassen op datapunten in het diagram met Aspose.Slides for C++. De klassen [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) en **[IChartDataPointLevel](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapointlevel/)** zijn toegevoegd om toegang te krijgen tot de eigenschappen van datapunten‑niveaus. Dit artikel laat zien hoe u toegang krijgt tot en kleur toepast op datapunten in een diagram.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**Welke marker‑vormen zijn standaard beschikbaar?**

Standaardvormen zijn beschikbaar (cirkel, vierkant, ruit, driehoek, enz.); de lijst wordt gedefinieerd door de [MarkerStyleType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/markerstyletype/)‑enumeratie. Als u een niet‑standaard vorm nodig hebt, gebruik dan een marker met een afbeeldingvulling om aangepaste visuals te realiseren.

**Worden markers behouden bij het exporteren van een diagram naar een afbeelding of SVG?**

Ja. Bij het renderen van diagrammen naar [rasterformaten](/slides/nl/cpp/convert-powerpoint-to-png/) of het opslaan van [vormen als SVG](/slides/nl/cpp/render-a-slide-as-an-svg-image/), behouden markers hun weergave en instellingen, inclusief grootte, vulling en omtrek.