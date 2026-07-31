---
title: Zarządzanie znacznikami danych wykresu w prezentacjach przy użyciu C++
linktitle: Znacznik danych
type: docs
url: /pl/cpp/chart-data-marker/
keywords:
- wykres
- punkt danych
- znacznik
- opcje znacznika
- rozmiar znacznika
- typ wypełnienia
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak dostosować znaczniki danych wykresu w Aspose.Slides dla C++, zwiększając wpływ prezentacji w formatach PPT i PPTX przy użyciu przejrzystych przykładów kodu C++."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować ze znacznikami danych wykresu w Aspose.Slides. Pokazuje, jak utworzyć wykres, uzyskać dostęp do serii i jej punktów danych, zastosować wypełnienie obrazem do znaczników na poziomie punktu danych, dostosować rozmiar znacznika oraz zapisać zaktualizowaną prezentację. Zawiera również informację, że standardowe kształty znaczników są dostępne poprzez wyliczenie `MarkerStyleType`, a wygląd znacznika jest zachowywany podczas eksportowania wykresów do formatów rastrowych lub SVG.

## **Ustaw znaczniki wykresu**
Aspose.Slides dla C++ udostępnia prosty interfejs API do automatycznego ustawiania znacznika serii wykresu. W poniższej funkcji każda seria wykresu otrzyma automatycznie inny domyślny symbol znacznika.

Poniższy przykład kodu pokazuje, jak automatycznie ustawić znacznik serii wykresu.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Ustaw opcje znacznika wykresu**
Znaczniki mogą być ustawiane na punktach danych wykresu w obrębie konkretnej serii. Aby ustawić opcje znacznika wykresu, postępuj zgodnie z poniższymi krokami:
- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
- Utwórz domyślny wykres.
- Ustaw obraz.
- Pobierz pierwszą serię wykresu.
- Dodaj nowy punkt danych.
- Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy opcje znacznika wykresu na poziomie punktów danych.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Ustaw znaczniki wykresu na poziomie punktu danych serii**
Teraz znaczniki mogą być ustawiane na punktach danych wykresu w obrębie konkretnej serii. Aby ustawić opcje znacznika wykresu, postępuj zgodnie z poniższymi krokami:
- Utwórz instancję klasy Presentation.
- Utwórz domyślny wykres.
- Ustaw obraz.
- Pobierz pierwszą serię wykresu.
- Dodaj nowy punkt danych.
- Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy opcje znacznika wykresu na poziomie punktów danych.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantiate Presentation class that represents PPTX file
//Utwórz instancję klasy Presentation reprezentującej plik PPTX

//Access first slide
//Uzyskaj dostęp do pierwszego slajdu

// Add chart with default data
// Dodaj wykres z domyślnymi danymi

// Setting the index of chart data sheet
// Ustawianie indeksu arkusza danych wykresu

// Getting the chart data worksheet
// Pobieranie arkusza danych wykresu

// Delete default generated series and categories
// Usuń domyślnie wygenerowane serie i kategorie

// Now, Adding a new series
// Teraz, dodawanie nowej serii

SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Get the picture
// Pobierz obraz
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Add image to presentation's images collection
// Dodaj obraz do kolekcji obrazów prezentacji
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Add new point (1:3) there.
 // Dodaj nowy punkt (1:3) tutaj.
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
// Zmiana znacznika serii wykresu
series->get_Marker()->set_Size(15);

// Write the presentation file to disk
// Zapisz plik prezentacji na dysku
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **Zastosuj kolor do punktów danych**
Możesz zastosować kolor do punktów danych w wykresie przy użyciu Aspose.Slides dla C++. Dodano klasy [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) oraz **[IChartDataPointLevel](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapointlevel/)**, które umożliwiają dostęp do właściwości poziomów punktów danych. Ten artykuł pokazuje, jak uzyskać dostęp i zastosować kolor do punktów danych w wykresie.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**Jakie kształty znaczników są dostępne od razu?**

Standardowe kształty są dostępne (koło, kwadrat, romb, trójkąt itd.); lista jest zdefiniowana przez wyliczenie [MarkerStyleType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/markerstyletype/). Jeśli potrzebujesz niestandardowego kształtu, użyj znacznika z wypełnieniem obrazem, aby emulować własne elementy wizualne.

**Czy znaczniki są zachowywane przy eksportowaniu wykresu do obrazu lub SVG?**

Tak. Podczas renderowania wykresów do [formatów rastrowych](/slides/pl/cpp/convert-powerpoint-to-png/) lub zapisywania [kształtów jako SVG](/slides/pl/cpp/render-a-slide-as-an-svg-image/), znaczniki zachowują swój wygląd i ustawienia, w tym rozmiar, wypełnienie i obrys.