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
- اندازه نشانگر
- نوع پرکردن
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه نشانگرهای دادهٔ نمودار را در Aspose.Slides برای C++ سفارشی کنید و با مثال‌های واضح کد C++، تأثیر ارائه را در فرمت‌های PPT و PPTX افزایش دهید."
---
## **نمای کلی**

این مقاله نحوه کار با نشانگرهای دادهٔ نمودار در Aspose.Slides را توضیح می‌دهد. در آن نشان داده می‌شود که چگونه یک نمودار ایجاد کنید، به یک سری و نقاط دادهٔ آن دسترسی پیدا کنید، پرکردن تصویر را به نشانگرها در سطح نقطهٔ داده اعمال کنید، اندازهٔ نشانگر را تنظیم کنید و ارائهٔ به‌روزرسانی‌شده را ذخیره کنید. همچنین ذکر شده است که شکل‌های استاندارد نشانگر از طریق شمارش‌گر `MarkerStyleType` در دسترس هستند و ظاهر نشانگر هنگام خروجی گرفتن نمودارها به فرمت‌های رستر یا SVG حفظ می‌شود.

## **تنظیم نشانگرهای نمودار**
Aspose.Slides برای C++ یک API ساده برای تنظیم خودکار نشانگرهای سری‌های نمودار فراهم می‌کند. در ویژگی زیر، هر سری نمودار به‌طور خودکار نماد پیش‌فرض مختلفی دریافت می‌کند.

مثال کد زیر نشان می‌دهد که چگونه نشانگرهای سری نمودار را به‌صورت خودکار تنظیم کنید.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **تنظیم گزینه‌های نشانگر نمودار**
نشانگرها می‌توانند بر روی نقاط دادهٔ نمودار در یک سری خاص تنظیم شوند. برای تنظیم گزینه‌های نشانگر نمودار، لطفاً مراحل زیر را دنبال کنید:

- نمونه‌سازی کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) .
- ایجاد نمودار پیش‌فرض.
- تنظیم تصویر.
- دریافت اولین سری نمودار.
- افزودن یک نقطه دادهٔ جدید.
- نوشتن ارائه بر روی دیسک.

در مثال زیر، ما گزینه‌های نشانگر نمودار را در سطح نقاط داده تنظیم کرده‌ایم.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **تنظیم نشانگرهای نمودار در سطح نقاط دادهٔ سری**
اکنون، نشانگرها می‌توانند بر روی نقاط دادهٔ نمودار در یک سری خاص تنظیم شوند. برای تنظیم گزینه‌های نشانگر نمودار، لطفاً مراحل زیر را دنبال کنید:

- نمونه‌سازی کلاس Presentation.
- ایجاد نمودار پیش‌فرض.
- تنظیم تصویر.
- دریافت اولین سری نمودار.
- افزودن یک نقطه دادهٔ جدید.
- نوشتن ارائه بر روی دیسک.

در مثال زیر، ما گزینه‌های نشانگر نمودار را در سطح نقاط داده تنظیم کرده‌ایم.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantiate Presentation class that represents PPTX file
//نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است

//Access first slide
//دسترسی به اولین اسلاید

// Add chart with default data
// افزودن نمودار با داده‌های پیش‌فرض

// Setting the index of chart data sheet
// تنظیم ایندکس شیت دادهٔ نمودار

// Getting the chart data worksheet
// دریافت کاربرگ دادهٔ نمودار

// Delete default generated series and categories
// حذف سری‌ها و دسته‌بندی‌های پیش‌فرض تولید شده

// Now, Adding a new series
// حالا، افزودن یک سری جدید

SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Get the picture
// دریافت تصویر
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Add image to presentation's images collection
// افزودن تصویر به مجموعهٔ تصاویر ارائه
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Add new point (1:3) there.
 // افزودن نقطهٔ جدید (1:3) در آنجا.
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
شما می‌توانید با استفاده از Aspose.Slides برای C++ به نقاط دادهٔ نمودار رنگ اعمال کنید. کلاس‌های [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) و **[IChartDataPointLevel](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointlevel/)** برای دسترسی به ویژگی‌های سطوح نقطهٔ داده اضافه شده‌اند. این مقاله نشان می‌دهد که چگونه می‌توانید به نقاط داده دسترسی پیدا کنید و رنگ را به آن‌ها اعمال کنید.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **سوالات متداول**

**کدام شکل‌های نشانگر به‌صورت پیش‌فرض در دسترس هستند؟**

شکل‌های استاندارد در دسترس هستند (دایره، مربع، الماس، مثلث و غیره)؛ این فهرست توسط شمارش‌گر [MarkerStyleType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/markerstyletype/) تعریف شده است. اگر به شکل غیر استاندارد نیاز دارید، می‌توانید از یک نشانگر با پرکردن تصویر برای شبیه‌سازی عناصر سفارشی استفاده کنید.

**آیا نشانگرها هنگام خروجی‌گیری نمودار به تصویر یا SVG حفظ می‌شوند؟**

بله. هنگام رندر کردن نمودارها به [فرمت‌های رستر](/slides/fa/cpp/convert-powerpoint-to-png/) یا ذخیرهٔ [اشکال به صورت SVG](/slides/fa/cpp/render-a-slide-as-an-svg-image/)، نشانگرها ظاهر و تنظیمات خود از جمله اندازه، پرکردن و خطوط حاشیه را حفظ می‌کنند.