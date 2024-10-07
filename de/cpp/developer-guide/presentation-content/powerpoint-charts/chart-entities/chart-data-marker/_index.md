---
title: Diagramm Datenmarker
type: docs
url: /cpp/chart-data-marker/
---

## **Diagrammmarker Setzen**
Aspose.Slides für C++ bietet eine einfache API, um den Diagrammserienmarker automatisch festzulegen. In der folgenden Funktion erhält jede Diagrammserie automatisch ein unterschiedliches Standardsymbol für den Marker.

Das folgende Codebeispiel zeigt, wie man den Diagrammserienmarker automatisch festlegt.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Diagrammmarker-Optionen Setzen**
Die Marker können an Diagrammdatenpunkten innerhalb einer bestimmten Serie festgelegt werden. Um die Optionen für Diagrammmarker festzulegen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
- Erstellen Sie das Standarddiagramm.
- Setzen Sie das Bild.
- Nehmen Sie die erste Diagrammserie.
- Fügen Sie einen neuen Datenpunkt hinzu.
- Schreiben Sie eine Präsentation auf die Festplatte.

Im folgenden Beispiel haben wir die Diagrammmarker-Optionen auf Ebene der Datenpunkte festgelegt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Diagrammmarker auf Ebene der Serien-Datenpunkte Setzen**
Jetzt können die Marker an Diagrammdatenpunkten innerhalb einer bestimmten Serie festgelegt werden. Um die Optionen für Diagrammmarker festzulegen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie die Präsentationsklasse.
- Erstellen Sie das Standarddiagramm.
- Setzen Sie das Bild.
- Nehmen Sie die erste Diagrammserie.
- Fügen Sie einen neuen Datenpunkt hinzu.
- Schreiben Sie eine Präsentation auf die Festplatte.

Im folgenden Beispiel haben wir die Diagrammmarker-Optionen auf Ebene der Datenpunkte festgelegt.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instanziieren Sie die Präsentationsklasse, die die PPTX-Datei darstellt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Zugriff auf die erste Folie
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Fügen Sie ein Diagramm mit Standarddaten hinzu
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Festlegen des Index des Diagrammdatenblatts
int defaultWorksheetIndex = 0;

// Abrufen des Diagrammdatenarbeitsblatts
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Löschen der standardmäßig generierten Serien und Kategorien
chart->get_ChartData()->get_Series()->Clear();

// Jetzt, Hinzufügen einer neuen Serie
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Serie 1")), chart->get_Type());

// Holen Sie sich das Bild
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Bild zur Bildersammlung der Präsentation hinzufügen
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Neuen Punkt (1:3) hinzufügen.
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

// Ändern des Diagrammserienmarkers
series->get_Marker()->set_Size(15);

// Schreiben Sie die Präsentationsdatei auf die Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **Farbe auf Datenpunkte Anwenden**
Sie können Farbe auf Datenpunkte im Diagramm anwenden, indem Sie Aspose.Slides für C++ verwenden. [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager) und **[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level)** Klassen wurden hinzugefügt, um Zugriff auf die Eigenschaften von Datenpunkt-Ebenen zu erhalten. Dieser Artikel zeigt, wie Sie auf die Datenpunkte zugreifen und Farbe darauf anwenden können.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}