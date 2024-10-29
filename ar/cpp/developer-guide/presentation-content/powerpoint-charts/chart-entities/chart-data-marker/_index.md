---
title: علامة بيانات الرسم البياني
type: docs
url: /ar/cpp/chart-data-marker/
---

## **تعيين علامة الرسم البياني**
يقدم Aspose.Slides لـ C++ واجهة برمجة تطبيقات بسيطة لتعيين علامة سلسلة الرسم البياني تلقائيًا. في الميزة التالية، ستحصل كل سلسلة رسم بياني على رمز علامة افتراضي مختلف تلقائيًا.

يوضح مثال الكود أدناه كيفية تعيين علامة سلسلة الرسم البياني تلقائيًا.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}


## **تعيين خيارات علامة الرسم البياني**
يمكن تعيين العلامات على نقاط بيانات الرسم البياني داخل سلسلة معينة. لتعيين خيارات علامة الرسم البياني، يرجى اتباع الخطوات أدناه:

- إنشاء [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- إنشاء الرسم البياني الافتراضي.
- تعيين الصورة.
- أخذ أول سلسلة رسم بياني.
- إضافة نقطة بيانات جديدة.
- كتابة العرض إلى القرص.

في المثال المعطى أدناه، قمنا بتعيين خيارات علامة الرسم البياني على مستوى نقاط البيانات.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}


## **تعيين علامة الرسم البياني على مستوى نقطة بيانات السلسلة**
الآن، يمكن تعيين العلامات على نقاط بيانات الرسم البياني داخل سلسلة معينة. لتعيين خيارات علامة الرسم البياني، يرجى اتباع الخطوات أدناه:

- إنشاء Presentation class.
- إنشاء الرسم البياني الافتراضي.
- تعيين الصورة.
- أخذ أول سلسلة رسم بياني.
- إضافة نقطة بيانات جديدة.
- كتابة العرض إلى القرص.

في المثال المعطى أدناه، قمنا بتعيين خيارات علامة الرسم البياني على مستوى نقاط البيانات.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantiate Presentation class that represents PPTX file
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Access first slide
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Add chart with default data
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

## **تطبيق اللون على نقاط البيانات**
يمكنك تطبيق اللون على نقاط البيانات في الرسم البياني باستخدام Aspose.Slides لـ C++. تم إضافة **[IChartDataPointLevelsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager)** و **[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level)** classes للوصول إلى خصائص مستويات نقاط البيانات. توضح هذه المقالة كيفية الوصول إلى نقاط البيانات وتطبيق اللون عليها في الرسم البياني.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}