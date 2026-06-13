---
title: بهینه‌سازی محاسبات نمودار برای ارائه‌ها در C++
linktitle: محاسبات نمودار
type: docs
weight: 50
url: /fa/cpp/chart-calculations/
keywords:
- محاسبات نمودار
- عناصر نمودار
- موقعیت عنصر
- موقعیت واقعی
- عنصر فرزند
- عنصر والد
- مقدارهای نمودار
- مقدار واقعی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "محاسبه‌های نمودار، به‌روزرسانی داده‌ها و کنترل دقت را در Aspose.Slides برای C++ برای PPT و PPTX درک کنید، همراه با مثال‌های عملی کد C++."
---
## **نمای کلی**

Aspose.Slides APIهایی برای کار با محاسبات نمودار و داده‌های طرح‌بندی در ارائه‌ها فراهم می‌کند. این مقاله نشان می‌دهد چگونه مقادیر واقعی عناصر نمودار، از جمله موقعیت و اندازه واقعی عناصری که IActualLayout را پیاده‌سازی می‌کنند و مقادیر واقعی محورهای نمودار را به‌دست آورید. همچنین توضیح می‌دهد که این مقادیر پس از اعتبارسنجی طرح‌بندی نمودار پر می‌شوند.

علاوه بر این، مقاله نشان می‌دهد چگونه موقعیت واقعی عناصر والد نمودار را دریافت کنید و چگونه اجزای نمودار مانند عنوان، محورها، legend و خطوط شبکه را مخفی کنید. این مثال‌ها به شما کمک می‌کنند اطلاعات طرح‌بندی نمودار را بررسی کرده و نمایش اجزای نمودار را در ارائه‌های PowerPoint به‌صورت برنامه‌نویسی کنترل کنید.

## **محاسبه مقادیر واقعی عناصر نمودار**
Aspose.Slides for C++ یک API ساده برای دریافت این ویژگی‌ها ارائه می‌دهد. این به شما کمک می‌کند تا مقادیر واقعی عناصر نمودار را محاسبه کنید. مقادیر واقعی شامل موقعیت عناصری است که رابط IActualLayout را پیاده‌سازی می‌کنند (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) و مقادیر واقعی محورهای نمودار (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// ذخیره ارائه
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **محاسبه موقعیت واقعی عناصر والد نمودار**
Aspose.Slides for C++ یک API ساده برای دریافت این ویژگی‌ها ارائه می‌دهد. متدهای IActualLayout اطلاعاتی درباره موقعیت واقعی عنصر والد نمودار فراهم می‌کنند. قبل از پر کردن ویژگی‌ها با مقادیر واقعی، لازم است متد IChart::ValidateChartLayout() را فراخوانی کنید.

``` cpp
// ایجاد ارائه خالی
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **مخفی کردن عناصر نمودار**
این بخش به شما کمک می‌کند تا بفهمید چگونه اطلاعاتی را از نمودار مخفی کنید. با استفاده از Aspose.Slides for C++ می‌توانید **Title, Vertical Axis, Horizontal Axis** و **Grid Lines** را از نمودار مخفی کنید. مثال کد زیر نشان می‌دهد چگونه از این ویژگی‌ها استفاده کنید.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **تنظیم دامنه داده برای نمودار**
Aspose.Slides for C++ ساده‌ترین API را برای تنظیم دامنه داده یک نمودار به‌صورت آسان فراهم کرده است. برای تنظیم دامنه داده برای نمودار:

- یک نمونه از کلاس Presentation حاوی نمودار را باز کنید.
- با استفاده از Index آن، مرجع اسلاید را به‌دست آورید.
- تمام اشکال را مرور کنید تا نمودار موردنظر را پیدا کنید.
- به داده‌های نمودار دسترسی پیدا کنید و دامنه را تنظیم کنید.
- ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

مثال‌های کد زیر نشان می‌دهند چگونه یک نمودار را به‌روز کنید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **پرسش‌های متداول**

**آیا کتاب‌کارهای Excel خارجی می‌توانند به‌عنوان منبع داده استفاده شوند و این چگونه بر محاسبه مجدد تأثیر می‌گذارد؟**

بله. یک نمودار می‌تواند به یک کتاب‌کار خارجی ارجاع دهد: هنگامی که منبع خارجی را متصل یا تازه‑سازی می‌کنید، فرمول‌ها و مقادیر از آن کتاب‌کار گرفته می‌شود و نمودار در عملیات باز/ویرایش به‌روزرسانی‌ها را منعکس می‌کند. API به شما امکان می‌دهد مسیر کتاب‌کار خارجی را [specify the external workbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) مشخص کنید و داده‌های مرتبط را مدیریت کنید.

**آیا می‌توانم خطوط روند را بدون پیاده‌سازی رگرسیون خودمحاسبه کنم و نمایش دهم؟**

بله. [Trendlines](/slides/fa/cpp/trend-line/) (خطی، نمایی و غیره) توسط Aspose.Slides اضافه و به‌روزرسانی می‌شوند؛ پارامترهای آن‌ها به‌صورت خودکار از داده‌های سری محاسبه می‌شوند، بنابراین نیازی به پیاده‌سازی محاسبات خود ندارید.

**اگر یک ارائه چندین نمودار با لینک‌های خارجی داشته باشد، آیا می‌توانم کنترل کنم که هر نمودار از کدام کتاب‌کار خارجی برای مقادیر محاسبه‌شده استفاده کند؟**

بله. هر نمودار می‌تواند به [external workbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) خود اشاره کند، یا می‌توانید برای هر نمودار به‌صورت مستقل یک کتاب‌کار خارجی را ایجاد/جایگزین کنید.