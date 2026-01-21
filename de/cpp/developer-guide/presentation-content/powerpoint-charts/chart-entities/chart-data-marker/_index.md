---
title: Chart-Datenmarker in Präsentationen mit C++ verwalten
linktitle: Datenmarker
type: docs
url: /de/cpp/chart-data-marker/
keywords:
- Diagramm
- Datenpunkt
- Marker
- Markeroptionen
- Markergröße
- Fülltyp
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Chart-Datenmarker in Aspose.Slides für C++ anpassen und damit die Wirkung von Präsentationen in PPT- und PPTX-Formaten mit klaren C++-Codebeispielen steigern."
---

## **Diagramm-Marker festlegen**
Aspose.Slides für C++ bietet eine einfache API, um die Markierung von Diagrammserien automatisch festzulegen. In der folgenden Funktion erhält jede Diagrammserie automatisch ein unterschiedliches Standardsymbol für die Markierung.

Das nachstehende Code‑Beispiel zeigt, wie man die Markierung von Diagrammserien automatisch festlegt.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}


## **Diagramm-Marker‑Optionen festlegen**
Die Marker können für Datenpunkte eines Diagramms innerhalb einer bestimmten Serie festgelegt werden. Um Diagramm‑Marker‑Optionen festzulegen, befolgen Sie bitte die nachstehenden Schritte:

- Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
- Erstellen des Standarddiagramms.
- Bild festlegen.
- Erste Diagrammserie auswählen.
- Neuen Datenpunkt hinzufügen.
- Präsentation auf die Festplatte schreiben.

Im nachstehenden Beispiel haben wir die Diagramm‑Marker‑Optionen auf Ebene der Datenpunkte festgelegt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}


## **Diagramm-Marker auf Ebene der Serien-Datenpunkte festlegen**
Jetzt können die Marker für Datenpunkte eines Diagramms innerhalb einer bestimmten Serie festgelegt werden. Um Diagramm‑Marker‑Optionen zu setzen, befolgen Sie bitte die nachstehenden Schritte:

- Instanziieren Sie die Presentation‑Klasse.
- Erstellen des Standarddiagramms.
- Bild festlegen.
- Erste Diagrammserie auswählen.
- Neuen Datenpunkt hinzufügen.
- Präsentation auf die Festplatte schreiben.

Im nachstehenden Beispiel haben wir die Diagramm‑Marker‑Optionen auf Datenpunktebene festgelegt.
```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instanzieren Sie die Presentation-Klasse, die die PPTX-Datei repräsentiert
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Greifen Sie auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Diagramm mit Standarddaten hinzufügen
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Index des Diagrammdatenblatts festlegen
int defaultWorksheetIndex = 0;

// Das Diagrammdaten-Arbeitsblatt abrufen
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Standardgenerierte Serien und Kategorien löschen
chart->get_ChartData()->get_Series()->Clear();

// Jetzt eine neue Serie hinzufügen
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Bild abrufen
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Bild zur Bildersammlung der Präsentation hinzufügen
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Neuen Punkt (1:3) dort hinzufügen.
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


## **Farbe auf Datenpunkte anwenden**
Sie können mithilfe von Aspose.Slides für C++ Farbe auf Datenpunkte in einem Diagramm anwenden. Die Klassen [IChartDataPointLevelsManager](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) und **[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/)** wurden hinzugefügt, um Zugriff auf die Eigenschaften von Datenpunkt‑Ebenen zu erhalten. Dieser Artikel zeigt, wie Sie auf Datenpunkte in einem Diagramm zugreifen und Farbe anwenden können.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**Welche Markerformen sind standardmäßig verfügbar?**

Standardformen sind verfügbar (Kreis, Quadrat, Raute, Dreieck usw.); die Liste wird durch die Aufzählung [MarkerStyleType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/markerstyletype/) definiert. Wenn Sie eine nicht‑standardmäßige Form benötigen, verwenden Sie einen Marker mit Bildfüllung, um benutzerdefinierte Visualisierungen zu emulieren.

**Werden Marker beim Export eines Diagramms in ein Bild oder SVG beibehalten?**

Ja. Beim Rendern von Diagrammen in [Rasterformate](/slides/de/cpp/convert-powerpoint-to-png/) oder beim Speichern von [Formen als SVG](/slides/de/cpp/render-a-slide-as-an-svg-image/) behalten Marker ihr Aussehen und ihre Einstellungen bei, einschließlich Größe, Füllung und Kontur.