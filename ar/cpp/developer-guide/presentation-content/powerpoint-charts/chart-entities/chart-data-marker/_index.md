---
title: "إدارة علامات بيانات المخطط في العروض التقديمية باستخدام C++"
linktitle: "علامة البيانات"
type: docs
url: /ar/cpp/chart-data-marker/
keywords:
- مخطط
- نقطة بيانات
- علامة
- خيارات العلامة
- حجم العلامة
- نوع التعبئة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية تخصيص علامات بيانات المخطط في Aspose.Slides للغات C++، مما يعزز تأثير العروض التقديمية عبر صيغ PPT و PPTX مع أمثلة شاملة وواضحة بلغة C++."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع علامات بيانات المخطط في Aspose.Slides. توضح كيفية إنشاء مخطط، الوصول إلى سلسلة ونقاط البيانات الخاصة بها، تطبيق تعبئة صورة على العلامات على مستوى نقطة البيانات، ضبط حجم العلامة، وحفظ العرض التقديمي المحدث. كما تشير إلى أن أشكال العلامات القياسية متوفرة من خلال تعداد `MarkerStyleType` وأن مظهر العلامة يُحافظ عليه عند تصدير المخططات إلى صيغ نقطية أو SVG.

## **تعيين علامات المخطط**
توفر Aspose.Slides للغة C++ واجهة برمجة تطبيقات بسيطة لتعيين علامة سلسلة المخطط تلقائيًا. في الميزة التالية، سيتلقى كل سلسلة مخطط رمز علامة افتراضي مختلف تلقائيًا.

يعرض مثال الكود أدناه كيفية تعيين علامة سلسلة المخطط تلقائيًا.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **تعيين خيارات علامة المخطط**
يمكن تعيين العلامات على نقاط بيانات المخطط داخل سلسلة معينة. لتعيين خيارات علامة المخطط، يرجى اتباع الخطوات أدناه:

- إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
- إنشاء المخطط الافتراضي.
- تعيين الصورة.
- أخذ السلسلة الأولى في المخطط.
- إضافة نقطة بيانات جديدة.
- كتابة العرض التقديمي إلى القرص.

في المثال المقدم أدناه، قمنا بتعيين خيارات علامة المخطط على مستوى نقاط البيانات.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **تعيين علامات المخطط على مستوى نقاط بيانات السلسلة**
الآن يمكن تعيين العلامات على نقاط بيانات المخطط داخل سلسلة معينة. لتعيين خيارات علامة المخطط، يرجى اتباع الخطوات أدناه:

- إنشاء كائن Presentation.
- إنشاء المخطط الافتراضي.
- تعيين الصورة.
- أخذ السلسلة الأولى في المخطط.
- إضافة نقطة بيانات جديدة.
- كتابة العرض التقديمي إلى القرص.

في المثال المقدم أدناه، قمنا بتعيين خيارات علامة المخطط على مستوى نقاط البيانات.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//الوصول إلى الشريحة الأولى
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

//إضافة مخطط ببيانات افتراضية
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

//تعيين فهرس ورقة بيانات المخطط
int defaultWorksheetIndex = 0;

//الحصول على ورقة عمل بيانات المخطط
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

//حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
chart->get_ChartData()->get_Series()->Clear();

//الآن، إضافة سلسلة جديدة
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

//جلب الصورة
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

//إضافة الصورة إلى مجموعة صور العرض التقديمي
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

//إضافة نقطة جديدة (1:3) هناك.
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

//تغيير علامة سلسلة المخطط
series->get_Marker()->set_Size(15);

//كتابة ملف العرض التقديمي إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **تطبيق لون على نقاط البيانات**
يمكنك تطبيق لون على نقاط البيانات في المخطط باستخدام Aspose.Slides للغة C++. تمت إضافة الفصول [IChartDataPointLevelsManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) و **[IChartDataPointLevel](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatapointlevel/)** للحصول على إمكانية الوصول إلى خصائص مستويات نقاط البيانات. توضح هذه المقالة كيفية الوصول إلى نقاط البيانات وتطبيق لون عليها في المخطط.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **الأسئلة المتكررة**

**ما هي أشكال العلامات المتوفرة مباشرة؟**

الأشكال القياسية متوفرة (دائرة، مربع، ماسي، مثلث، إلخ)؛ القائمة معرفة بواسطة تعداد [MarkerStyleType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/markerstyletype/). إذا كنت بحاجة إلى شكل غير قياسي، استخدم علامة بتعبئة صورة لمحاكاة تصاميم مخصصة.

**هل يتم الحفاظ على العلامات عند تصدير المخطط إلى صورة أو SVG؟**

نعم. عند تحويل المخططات إلى [raster formats](/slides/ar/cpp/convert-powerpoint-to-png/) أو حفظ [shapes as SVG](/slides/ar/cpp/render-a-slide-as-an-svg-image/)، تحتفظ العلامات بمظهرها وإعداداتها، بما في ذلك الحجم، التعبئة، والحد الخارجي.