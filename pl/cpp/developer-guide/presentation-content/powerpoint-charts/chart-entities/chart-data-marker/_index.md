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
description: "Dowiedz się, jak dostosować znaczniki danych wykresu w Aspose.Slides dla C++, zwiększając efektywność prezentacji w formatach PPT i PPTX dzięki przejrzystym przykładom kodu w C++."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować ze znacznikami danych wykresu w Aspose.Slides. Pokazuje, jak utworzyć wykres, uzyskać dostęp do serii i jej punktów danych, zastosować wypełnienia obrazem do znaczników na poziomie punktu danych, dostosować rozmiar znacznika oraz zapisać zaktualizowaną prezentację. Zaznacza również, że standardowe kształty znaczników są dostępne poprzez wyliczenie `MarkerStyleType` oraz że wygląd znacznika jest zachowywany przy eksportowaniu wykresów do formatów rastrowych lub SVG.

## **Ustaw znaczniki wykresu**
Aspose.Slides for C++ udostępnia prosty interfejs API umożliwiający automatyczne ustawienie znacznika serii wykresu. W kolejnej funkcji każda seria wykresu otrzyma automatycznie inny domyślny symbol znacznika.

Poniższy przykład kodu pokazuje, jak automatycznie ustawić znacznik serii wykresu.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Ustaw opcje znaczników wykresu**
Znaczniki można ustawiać na punktach danych wykresu w obrębie konkretnej serii. Aby ustawić opcje znaczników wykresu, postępuj zgodnie z poniższymi krokami:

- Tworzenie instancji klasy [Prezentacja](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
- Tworzenie domyślnego wykresu.
- Ustaw obraz.
- Pobierz pierwszą serię wykresu.
- Dodaj nowy punkt danych.
- Zapisz prezentację na dysku.

W podanym poniżej przykładzie ustawiliśmy opcje znaczników wykresu na poziomie punktów danych.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Ustaw znaczniki wykresu na poziomie punktu danych serii**
Teraz znaczniki można ustawiać na punktach danych wykresu w obrębie konkretnej serii. Aby ustawić opcje znaczników wykresu, postępuj zgodnie z poniższymi krokami:

- Tworzenie instancji klasy Prezentacja.
- Tworzenie domyślnego wykresu.
- Ustaw obraz.
- Pobierz pierwszą serię wykresu.
- Dodaj nowy punkt danych.
- Zapisz prezentację na dysku.

W podanym poniżej przykładzie ustawiliśmy opcje znaczników wykresu na poziomie punktów danych.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Zainstancjuj klasę Presentation reprezentującą plik PPTX
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Uzyskaj dostęp do pierwszego slajdu
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Dodaj wykres z domyślnymi danymi
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

## **Zastosuj kolor do punktów danych**
Możesz zastosować kolor do punktów danych w wykresie przy użyciu Aspose.Slides for C++. Dodano klasy **IChartDataPointLevelsManager**([https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/)) i **[IChartDataPointLevel](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapointlevel/)**, które umożliwiają dostęp do właściwości poziomów punktów danych. Ten artykuł pokazuje, jak uzyskać dostęp i zastosować kolor do punktów danych w wykresie.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**Jakie kształty znaczników są dostępne od razu?**

Dostępne są standardowe kształty (koło, kwadrat, romb, trójkat itd.); lista jest zdefiniowana przez wyliczenie [MarkerStyleType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/markerstyletype/). Jeśli potrzebujesz niestandardowego kształtu, użyj znacznika z wypełnieniem obrazem, aby emulować własną grafikę.

**Czy znaczniki są zachowywane przy eksportowaniu wykresu do obrazu lub SVG?**

Tak. Podczas renderowania wykresów do [formatów rastrowych](/slides/pl/cpp/convert-powerpoint-to-png/) lub zapisywania [kształtów jako SVG](/slides/pl/cpp/render-a-slide-as-an-svg-image/), znaczniki zachowują swój wygląd i ustawienia, w tym rozmiar, wypełnienie i obrys.