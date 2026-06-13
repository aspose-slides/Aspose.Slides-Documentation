---
title: سفارشی‌سازی نمودارهای سه‌بعدی در ارائه‌ها با استفاده از С++
linktitle: نمودار سه‌بعدی
type: docs
url: /fa/cpp/3d-chart/
keywords:
- نمودار سه‌بعدی
- چرخش
- عمق
- پاورپوینت
- ارائه
- С++
- Aspose.Slides
description: "بیاموزید چگونه نمودارهای 3‑بعدی را در Aspose.Slides برای С++ ایجاد و سفارشی کنید، با پشتیبانی از فایل‌های PPT و PPTX—امروز ارائه‌های خود را ارتقاء دهید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه یک نمودار سه‌بعدی را در Aspose.Slides با تنظیمات `Rotation3D` مانند `RotationX`، `RotationY`، `DepthPercents` و `RightAngleAxes` سفارشی کنید. مراحل ایجاد یک ارائه، افزودن نمودار سه‌بعدی با داده‌های پیش‌فرض، اعمال تنظیمات نمای سه‌بعدی مورد نیاز و ذخیره ارائه تغییر یافته به صورت فایل PPTX را نشان می‌دهد.

## **تنظیم ویژگی‌های RotationX، RotationY و DepthPercents یک نمودار سه‌بعدی**
Aspose.Slides for C++ یک API ساده برای تنظیم این ویژگی‌ها فراهم می‌کند. این مقاله به شما کمک می‌کند تا ویژگی‌های مختلفی مانند چرخش X، Y و **DepthPercents** و غیره را تنظیم کنید. کد نمونه تنظیم ویژگی‌های فوق را اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. به اسلاید اول دسترسی پیدا کنید.
1. نمودار را با داده‌های پیش‌فرض اضافه کنید.
1. ویژگی‌های Rotation3D را تنظیم کنید.
1. ارائه تغییر یافته را به یک فایل PPTX بنویسید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **سؤالات متداول**

**کدام نوع نمودارها حالت سه‌بعدی را در Aspose.Slides پشتیبانی می‌کنند؟**

Aspose.Slides انواع سه‌بعدی نمودارهای ستونی را پشتیبانی می‌کند، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D، به همراه انواع سه‌بعدی مرتبط که از طریق شمارش‌گر [ChartType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/charttype/) در دسترس هستند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/charttype/) را در مرجع API نسخه نصب شده خود بررسی کنید.

**آیا می‌توانم تصویر نقطه‌ای (رستر) از یک نمودار سه‌بعدی برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید نمودار را از طریق [chart API](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/getimage/) به تصویر تبدیل کنید یا کل اسلاید را به فرمت‌های PNG یا JPEG رندر کنید [/slides/fa/cpp/convert-powerpoint-to-png/]. این کار زمانی مفید است که به پیش‌نمایش پیکسل‌دقیق نیاز دارید یا می‌خواهید نمودار را بدون نیاز به PowerPoint در اسناد، داشبوردها یا صفحات وب جاسازی کنید.

**عملکرد ساخت و رندر نمودارهای سه‌بعدی بزرگ چقدر است؟**

عملکرد بستگی به حجم داده و پیچیدگی بصری دارد. برای بهترین نتایج، اثرات سه‌بعدی را به حداقل برسانید، از بافت‌های سنگین بر روی دیوارها و نواحی نمودار خودداری کنید، در صورت امکان تعداد نقاط داده در هر سری را محدود کنید و خروجی را با اندازه‌، وضوح و ابعاد مناسب برای نمایش یا چاپ هدف رندر کنید.