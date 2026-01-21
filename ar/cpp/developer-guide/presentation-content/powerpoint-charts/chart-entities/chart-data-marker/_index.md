---
title: إدارة علامات بيانات المخطط في العروض التقديمية باستخدام C++
linktitle: علامة البيانات
type: docs
url: /ar/cpp/chart-data-marker/
keywords:
- مخطط
- نقطة بيانات
- علامة
- خيارات العلامة
- حجم العلامة
- نوع الملء
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية تخصيص علامات بيانات المخططات في Aspose.Slides للغة C++، مما يعزز تأثير العروض التقديمية عبر صيغ PPT و PPTX مع أمثلة واضحة لكود C++."
---

## **تعيين علامات المخطط**
توفر Aspose.Slides للغة C++ واجهة برمجة تطبيقات بسيطة لتعيين علامة سلسلة المخطط تلقائيًا. في الميزة التالية، ستحصل كل سلسلة مخطط على رمز علامة افتراضي مختلف تلقائيًا.

يظهر مثال الشيفرة أدناه كيفية تعيين علامة سلسلة المخطط تلقائيًا.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **تعيين خيارات علامة المخطط**
يمكن تعيين العلامات على نقاط البيانات في المخطط داخل سلسلة معينة. لتعيين خيارات علامة المخطط، يرجى اتباع الخطوات التالية:

- إنشاء كائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
- إنشاء المخطط الافتراضي.
- تعيين الصورة.
- أخذ أول سلسلة مخطط.
- إضافة نقطة بيانات جديدة.
- كتابة العرض التقديمي إلى القرص.

في المثال الموضح أدناه، قمنا بتعيين خيارات علامة المخطط على مستوى نقاط البيانات.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **تعيين علامات المخطط على مستوى نقاط بيانات السلسلة**
الآن، يمكن تعيين العلامات على نقاط البيانات في المخطط داخل سلسلة معينة. لتعيين خيارات علامة المخطط، يرجى اتباع الخطوات التالية:

- إنشاء كائن Presentation.
- إنشاء المخطط الافتراضي.
- تعيين الصورة.
- أخذ أول سلسلة مخطط.
- إضافة نقطة بيانات جديدة.
- كتابة العرض التقديمي إلى القرص.

في المثال الموضح أدناه، قمنا بتعيين خيارات علامة المخطط على مستوى نقاط البيانات.
```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//إنشاء كائن Presentation الذي يمثل ملف PPTX
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//الوصول إلى الشريحة الأولى
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// إضافة مخطط بالبيانات الافتراضية
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// تعيين فهرس ورقة بيانات المخطط
int defaultWorksheetIndex = 0;

// الحصول على ورقة عمل بيانات المخطط
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
chart->get_ChartData()->get_Series()->Clear();

// الآن، إضافة سلسلة جديدة
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// الحصول على الصورة
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// إضافة الصورة إلى مجموعة صور العرض التقديمي
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// إضافة نقطة جديدة (1:3) هناك.
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


## **تطبيق لون على نقاط البيانات**
يمكنك تطبيق لون على نقاط البيانات في المخطط باستخدام Aspose.Slides للغة C++. تم إضافة الفئتين [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) و **[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/)** لتمكين الوصول إلى خصائص مستويات نقاط البيانات. توضح هذه المقالة كيفية الوصول إلى نقاط البيانات وتطبيق لون عليها في المخطط.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**ما هي أشكال العلامات المتوفرة افتراضيًا؟**

تتوفر أشكال قياسية (دائرة، مربع، معين، مثلث، إلخ)؛ يتم تعريف القائمة بواسطة تعداد [MarkerStyleType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/markerstyletype/). إذا كنت بحاجة إلى شكل غير قياسي، يمكنك استخدام علامة بملء صورة لمحاكاة التصاميم المخصصة.

**هل تُحافظ العلامات على شكلها عند تصدير المخطط إلى صورة أو SVG؟**

نعم. عند تصيير المخططات إلى [صيغ نقطية](/slides/ar/cpp/convert-powerpoint-to-png/) أو حفظ [الأشكال كملفات SVG](/slides/ar/cpp/render-a-slide-as-an-svg-image/)، تحتفظ العلامات بمظهرها وإعداداتها، بما في ذلك الحجم والملء والحد الخارجي.