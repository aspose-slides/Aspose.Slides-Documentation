---
title: سفارشی‌سازی جداول داده‌های نمودار در ارائه‌ها با استفاده از C++
linktitle: جدول داده
type: docs
url: /fa/cpp/chart-data-table/
keywords:
- داده‌های نمودار
- جدول داده
- خصوصیات قلم
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "قلم‌ها، حاشیه‌ها و کلیدهای افسانه‌ای جدول داده‌های نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای C++ سفارشی کنید."
---
## **نمای کلی**

Aspose.Slides for C++ به شما امکان می‌دهد جدول داده‌های یک نمودار را نمایش داده و قالب‌بندی متن، حاشیه‌ها و کلیدهای افسانه‌ای آن را سفارشی کنید. این مقاله توضیح می‌دهد چگونه جدول را فعال کنید، متن آن را قالب‌بندی کنید، هر نوع حاشیه را کنترل کنید و کلیدهای افسانه‌ای را نمایش یا مخفی کنید. مثال‌ها نمودارهای پیکربندی‌شده را در فایل‌های PPTX ذخیره می‌کنند.

## **تنظیم خصوصیات فونت**

برای نمایش جدول داده‌های یک نمودار، مقدار `true` را به [IChart::set_HasDataTable](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/set_hasdatatable/) بدهید. از [IChart::get_ChartDataTable](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/get_chartdatatable/) برای دسترسی به جدول و پیکربندی قالب‌بندی متن استفاده کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بارگذاری کنید.
1. یک نمودار ستونی خوشه‌ای به اسلاید اول اضافه کنید.
1. جدول داده‌های نمودار را فعال کنید.
1. متن توپر را با [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/set_fontbold/) فعال کنید و برای متن 20 پوینت مقدار `20` را به [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/set_fontheight/) بدهید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال زیر فرض می‌کند فایل `test.pptx` در پوشهٔ کاری موجود باشد و حداقل یک اسلاید داشته باشد. این مثال یک نمودار با داده‌های پیش‌فرض در موقعیت (50, 50) با عرض 600 پوینت و ارتفاع 400 پوینت اضافه می‌کند. فایل `output.pptx` ذخیره‌شده شامل نموداری با جدول داده‌های فعال و تنظیمات فونت مشخص‌شده است.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **سفارشی‌سازی حاشیه‌های جدول داده‌ها**

جدول را با [IChart::set_HasDataTable](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/set_hasdatatable/) فعال کنید و از طریق [IChart::get_ChartDataTable](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/get_chartdatatable/) به آن دسترسی داشته باشید. می‌توانید سه نوع حاشیه را به‌صورت مستقل کنترل کنید:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) حاشیه‌های افقی سلول‌ها را کنترل می‌کند.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) حاشیه‌های عمودی سلول‌ها را کنترل می‌کند.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) حاشیهٔ بیرونی جدول را کنترل می‌کند.

برای نمایش حاشیه‌ها مقدار `true` و برای مخفی کردن آن‌ها مقدار `false` را به هر setter بدهید. مثال زیر یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض ایجاد می‌کند، حاشیه‌های افقی و بیرونی را نمایش می‌دهد و حاشیه‌های عمودی را مخفی می‌کند. نیازی به فایل ورودی نیست. موقعیت و اندازهٔ نمودار بر حسب پوینت تعیین شده‌اند.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

مقایسهٔ زیر از همان داده‌های نمودار و تنظیم کلید افسانه‌ای در چهار حالت استفاده می‌کند. از حالت تمام حاشیه‌ها فعال شروع می‌شود؛ هر گونه باقی‌مانده تنها یک تنظیم حاشیه را غیرفعال می‌کند. حالت پایین‑چپ تنظیمات حاشیه‌ای مثال را مطابقت می‌دهد.

![نمودارهای جدول داده‌ها با تمام حاشیه‌ها فعال، بدون حاشیه افقی، بدون حاشیه عمودی و بدون حاشیه بیرونی](data-table-borders.png)

## **نمایش یا مخفی کردن کلیدهای افسانه‌ای**

کلیدهای افسانه‌ای نشانگرهای رنگی کوچکی هستند که در کنار نام سری‌ها در جدول داده‌ها قرار می‌گیرند. این کلیدها به خوانندگان کمک می‌کنند تا هر ردیف جدول را با یک سری نمودار مطابقت دهند. برای نمایش این نشانگرها مقدار `true` را به [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) بدهید؛ برای مخفی کردن آن‌ها مقدار `false` را بدهید.

افسانهٔ جداگانهٔ نمودار توسط [IChart::set_HasLegend](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/set_haslegend/) کنترل می‌شود. این تنظیمات مستقل هستند: مخفی کردن افسانهٔ جداگانه کلیدهای داخل جدول داده‌ها را مخفی نمی‌کند و مخفی کردن کلیدهای جدول افسانهٔ جداگانه را مخفی نمی‌سازد.

مثال زیر یک نمودار با داده‌های پیش‌فرض ایجاد می‌کند، جدول داده‌های آن را فعال می‌سازد و کلیدهای افسانه‌ای داخل آن را نشان می‌دهد در حالی که افسانهٔ جداگانه مخفی است. تمام حاشیه‌های جدول به‌صورت صریح فعال هستند. نیازی به ارائهٔ ورودی نیست. برای مخفی کردن فقط کلیدهای جدول، مقدار `false` را به [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) بدهید.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

مقایسهٔ زیر همان جدول را با کلیدهای افسانه‌ای فعال و غیرفعال نشان می‌دهد. تمام حاشیه‌ها فعال می‌مانند و افسانهٔ جداگانهٔ نمودار در هر دو حالت مخفی است.

![نمودارهای جدول داده‌ها با کلیدهای افسانه‌ای نشان داده شده در سمت چپ و مخفی شده در سمت راست](data-table-legend-keys.png)

## **پرسش‌های متداول**

**آیا می‌توانم کلیدهای افسانه‌ای را در جدول داده‌های یک نمودار نمایش دهم؟**

بله. مقدار `true` را به [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) بدهید تا کلیدهای افسانه‌ای نشان داده شوند یا مقدار `false` بدهید تا مخفی شوند.

**آیا جدول داده‌ها هنگام صادر کردن ارائه به PDF، HTML یا تصویر حفظ می‌شود؟**

بله. Aspose.Slides هنگام صادر کردن به [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/)، [HTML](/slides/fa/cpp/convert-powerpoint-to-html/) یا [images](/slides/fa/cpp/convert-powerpoint-to-png/) نمودار و جدول داده‌های نمایش داده‌شده را به عنوان بخشی از اسلاید رندر می‌کند.

**آیا می‌توانم با جداول داده در نمودارهایی که از یک الگو بارگذاری شده‌اند کار کنم؟**

بله. برای یک نمودار بارگذاری‌شده از یک ارائه یا الگوی موجود، از [IChart::get_HasDataTable](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/get_hasdatatable/) برای بررسی اینکه آیا جدول داده‌ها نمایش داده می‌شود استفاده کنید و با [IChart::set_HasDataTable](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/set_hasdatatable/) برای تغییر وضعیت نمایش آن.

**چگونه می‌توانم نمودارهایی که جدول داده فعال دارد پیدا کنم؟**

در هر اسلاید از اشکال عبور کنید، نمودارها را شناسایی کنید و نتیجهٔ [IChart::get_HasDataTable](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/get_hasdatatable/) آن‌ها را بررسی کنید. مقدار `true` نشان می‌دهد جدول داده فعال است.