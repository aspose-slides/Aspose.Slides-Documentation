---
title: مدیریت نشانگرهای دادهٔ نمودار در ارائه‌ها با استفاده از C++
linktitle: نشانگر داده
type: docs
url: /fa/cpp/chart-data-marker/
keywords:
- نمودار
- نقطه داده
- نشانگر
- گزینه‌های نشانگر
- اندازهٔ نشانگر
- نوع پرکننده
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "بیاموزید چگونه نشانگرهای دادهٔ نمودار را در Aspose.Slides برای C++ سفارشی کنید تا تاثیر ارائه‌ها در فرمت‌های PPT و PPTX را با مثال‌های واضح کد C++ افزایش دهید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با نشانگرهای دادهٔ نمودار در Aspose.Slides کار کنید. در آن نشان داده می‌شود چگونه یک نمودار ایجاد کنید، به یک سری و نقاط دادهٔ آن دسترسی پیدا کنید، پرکنندهٔ تصویر را به نشانگرها در سطح نقطهٔ داده اعمال کنید، اندازهٔ نشانگر را تنظیم کنید و ارائهٔ به‑روز شده را ذخیره کنید. همچنین اشاره می‌شود که اشکال استاندارد نشانگرها از طریق شمارش‌گر `MarkerStyleType` در دسترس هستند و ظاهر نشانگر هنگام خروجی گرفتن نمودارها به فرمت‌های رستر یا SVG حفظ می‌شود.

## **تنظیم نشانگرهای نمودار**
Aspose.Slides for C++ یک API ساده برای تنظیم خودکار نشانگرهای سری‌های نمودار فراهم می‌کند. در ویژگی زیر، هر سری نمودار به‌طور خودکار نماد پیش‌فرض متفاوتی دریافت می‌کند.

کد زیر نشان می‌دهد چگونه نشانگرهای سری نمودار را به‌صورت خودکار تنظیم کنید.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **تنظیم گزینه‌های نشانگر نمودار**
نشانگرها می‌توانند در نقاط دادهٔ یک سری خاص تنظیم شوند. برای تنظیم گزینه‌های نشانگر نمودار، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
- نمودار پیش‌فرض را ایجاد کنید.
- تصویر را تنظیم کنید.
- اولین سری نمودار را انتخاب کنید.
- یک نقطه دادهٔ جدید اضافه کنید.
- ارائه را روی دیسک بنویسید.

در مثال زیر، گزینه‌های نشانگر نمودار را در سطح نقاط داده تنظیم کرده‌ایم.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **تنظیم نشانگرهای نمودار در سطح نقطه داده‌ی سری**
اکنون می‌توان نشانگرها را در نقاط دادهٔ یک سری خاص تنظیم کرد. برای تنظیم گزینه‌های نشانگر نمودار، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید.
- نمودار پیش‌فرض را ایجاد کنید.
- تصویر را تنظیم کنید.
- اولین سری نمودار را انتخاب کنید.
- یک نقطه دادهٔ جدید اضافه کنید.
- ارائه را روی دیسک بنویسید.

در مثال زیر، گزینه‌های نشانگر نمودار را در سطح نقاط داده تنظیم کرده‌ایم.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantiate Presentation class that represents PPTX file
//دسترسی به اولین اسلاید
// Add chart with default data
// Setting the index of chart data sheet
// Getting the chart data worksheet
// Delete default generated series and categories
// Now, Adding a new series
// Get the picture
// Add image to presentation's images collection
// Add new point (1:3) there.
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

## **اعمال رنگ به نقاط داده**
می‌توانید با استفاده از Aspose.Slides for C++ به نقاط دادهٔ نمودار رنگ اعمال کنید. کلاس‌های **[IChartDataPointLevelsManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/)** و **[IChartDataPointLevel](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointlevel/)** برای دسترسی به ویژگی‌های سطوح نقاط داده اضافه شده‌اند. این مقاله نشان می‌دهد چگونه به نقاط داده دسترسی پیدا کنید و به آن‌ها رنگ اعمال کنید.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**کدام اشکال نشانگر به‌صورت پیش‌فرض موجود است؟**

اشکال استاندارد (دایره، مربع، الماس، مثلث و غیره) در دسترس هستند؛ لیست آن توسط شمارش‌گر [MarkerStyleType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/markerstyletype/) تعریف شده است. اگر به شکل غیراستاندارد نیاز دارید، می‌توانید از نشانگری با پرکنندهٔ تصویر استفاده کنید تا جلوهٔ سفارشی شبیه‌سازی شود.

**آیا نشانگرها هنگام خروجی گرفتن نمودار به تصویر یا SVG حفظ می‌شوند؟**

بله. هنگام رندر نمودارها به [فرمت‌های رستر](/slides/fa/cpp/convert-powerpoint-to-png/) یا ذخیرهٔ [اشکال به‌صورت SVG](/slides/fa/cpp/render-a-slide-as-an-svg-image/)، نشانگرها ظاهر و تنظیمات خود شامل اندازه، پرکننده و کادر را حفظ می‌کنند.