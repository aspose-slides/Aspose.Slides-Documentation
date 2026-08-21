---
title: اعمال فرمول‌های برگه کاری نمودار در ارائه‌ها با استفاده از C++
linktitle: فرمول‌های برگه کاری
type: docs
weight: 70
url: /fa/cpp/chart-worksheet-formulas/
keywords:
- نمودار صفحه‌گسترده
- برگه کاری نمودار
- فرمول نمودار
- فرمول برگه کاری
- فرمول صفحه‌گسترده
- کتاب‌کار داده‌های نمودار
- محاسبه فرمول
- فرهنگ مورد ترجیح
- فرمول مخصوص به فرهنگ
- DBCS
- ثابت منطقی
- ثابت عددی
- ثابت رشته‌ای
- ثابت خطا
- عملگر حسابی
- عملگر مقایسه‌ای
- سبک A1
- سبک R1C1
- تابع پیش‌تعریف‌شده
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "فرمول‌های سبک Excel را در برگه‌های کاری نمودار Aspose.Slides برای C++ اعمال کنید، مقادیر را دوباره محاسبه کنید و نتایج را در نمودارهای PowerPoint استفاده کنید."
---
## **بررسی کلی**

نمودارهای PowerPoint معمولاً داده‌های منبع خود را در یک برگه کاری تعبیه‌شده ذخیره می‌کنند. در Aspose.Slides برای C++ می‌توانید از طریق کتاب‌کار داده‌های نمودار به این برگه کاری دسترسی پیدا کنید، مقادیر ورودی را بنویسید، فرمول‌ها را به سلول‌ها اختصاص دهید، فرمول‌های پشتیبانی‌شده را محاسبه کنید و از سلول‌های محاسبه‌شده به عنوان داده‌های نمودار استفاده کنید.

این مقاله جریان کامل کار با فرمول‌ها را توضیح می‌دهد: ایجاد یک نمودار، پر کردن برگه کاری آن، اختصاص فرمول‌های سبک A1 یا R1C1، بازمحاسبهٔ آن‌ها، خواندن مقادیر محاسبه‌شده، اتصال این سلول‌ها به یک سری نمودار، و ذخیرهٔ ارائه. همچنین نحوهٔ نوشتن سینتکس فرمول‌های پشتیبانی‌شده، زیرمجموعهٔ توابع داخلی، مقادیر کش‌شده، فرمول‌های پشتیبانی‌نشده و خطاهای مخصوص به صفحه‌گسترده را شرح می‌دهد.

## **برگه‌های کاری نمودار و فرمول‌ها**

یک برگه کاری نمودار شامل دسته‌ها، نام‌های سری و مقادیری است که توسط نمودار استفاده می‌شوند. در PowerPoint می‌توانید با باز کردن ویرایشگر دادهٔ نمودار، برگه کاری را بررسی کنید:

![نمودار PowerPoint با برگه کاری تعبیه‌شده باز که داده‌های دسته و سری را نشان می‌دهد](chart-worksheet-formulas_1.png)

در Aspose.Slides، برگه کاری از طریق رابط [IChartDataWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/) در دسترس است. برای فرمول‌های سبک A1 از [IChartDataCell::set_Formula](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/set_formula/) و برای فرمول‌های سبک R1C1 از [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) استفاده کنید. پس از تغییر سلول‌های ورودی یا فرمول‌ها، برای بازمحاسبهٔ فرمول‌های پشتیبانی‌شده و به‌روزرسانی مقادیر سلول‌های مربوطه، متد [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) را فراخوانی کنید.

یک سلول محاسبه‌شده همچنان نتیجهٔ خود را از طریق [IChartDataCell::get_Value](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/get_value/) باز می‌گرداند. این مورد زمانی مهم است که نیاز به بازرسی نتیجهٔ فرمول در کد یا استفاده از سلول به عنوان نقطهٔ دادهٔ نمودار دارید.

## **ایجاد نمودار و محاسبهٔ فرمول‌های برگه کاری**

مثال زیر یک جریان کاری کامل انتها‑به‑انتها را نشان می‌دهد. یک نمودار ستونی خوشه‌ای می‌سازد، داده‌های نمونه را پاک می‌کند، مقادیر درآمد و هزینهٔ فصلی را می‌نویسد، سود را با فرمول‌ها محاسبه می‌کند، نتایج را می‌خواند، سلول‌های محاسبه‌شده را به عنوان مقادیر نمودار استفاده می‌کند و ارائه را ذخیره می‌کند.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IDataLabelCollection.h>
#include <DOM/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

نقاط دادهٔ نمودار به `D2:D4` ارجاع می‌دهند، بنابراین نمودار از مقادیر سود محاسبه‌شده استفاده می‌کند. در این جریان کاری هیچ فراخوانی جداگانه‌ای برای تازه‑سازی نمودار وجود ندارد: ابتدا کتاب‌کار را بازمحاسبه کنید، سپس داده‌های نمودار را که به سلول‌های محاسبه‌شده اشاره دارند، استفاده یا ذخیره کنید.

## **استفاده از فرمول‌های سبک A1**

نمادگذاری A1 ستون‌ها را با حروف و ردیف‌ها را با اعداد شناسایی می‌کند. عبارات سبک A1 را از طریق [IChartDataCell::set_Formula](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/set_formula/) اختصاص دهید.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

فرم‌های مرجع رایج A1 عبارتند از:

| مرجع | نسبی | مطلق | مختلط |
|---|---|---|---|
| سلول | `A2` | `$A$2` | `A$2`, `$A2` |
| ردیف | `2:2` | `$2:$2` | — |
| ستون | `A:A` | `$A:$A` | — |
| بازه | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

ارجاع‌های نسبی می‌توانند هنگام جابجا یا کپی کردن فرمول توسط برنامهٔ صفحه‌گسترده تغییر کنند. ارجاع‌های مطلق هر دو مختصات را ثابت نگه می‌دارند، در حالی‌که ارجاع‌های مختلط فقط ردیف یا ستون را ثابت می‌کنند.

## **استفاده از فرمول‌های سبک R1C1**

نمادگذاری R1C1 ردیف‌ها و ستون‌ها را به صورت عددی شناسایی می‌کند. ارجاع‌های نسبی از افست‌ها در براکت‌های مربعی استفاده می‌شوند. این سینتکس را از طریق [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) اختصاص دهید.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

فرم‌های مرجع رایج R1C1 عبارتند از:

| مرجع | نسبی | مطلق | مختلط |
|---|---|---|---|
| سلول | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| ردیف | `R[2]` | `R2` | — |
| ستون | `C[3]` | `C3` | — |
| بازه | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

به عنوان مثال، در سلول `D2`، `RC[-2]` به سلول همان ردیف دو ستون به سمت چپ (`B2`) اشاره می‌کند.

## **ثابت‌ها و عملگرهای فرمول**

ارزیاب فرمول داخلی مقادیر منطقی، عددی، رشته‌ای، مقادیر خطای صفحه‌گسترده، عملگرهای حسابی و عملگرهای مقایسه‌ای را پشتیبانی می‌کند.

### **ثابت‌ها و مقدارهای اولیه**

| نوع | مثال‌ها | نکات |
|---|---|---|
| منطقی | `TRUE`, `FALSE` | می‌توانند مستقیماً در عبارات منطقی مانند `A2=TRUE` استفاده شوند. |
| عددی | `1`, `0.5`, `.3`, `1E-2` | نوشتارهای عادی و علمی پشتیبانی می‌شوند. |
| رشته | `"abc"`, `"2/3/2020 12:00"` | مقدارهای متنی داخل فرمول بین علامت نقل‌قول دوتایی قرار می‌گیرند. |
| نتیجهٔ خطا | `#DIV/0!`, `#N/A`, `#REF!` | یک فرمول صحیح می‌تواند به جای نتیجهٔ عادی، مقدار خطای صفحه‌گسترده تولید کند. |

این مثال چندین نوع ثابت را به کار می‌برد:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // نادرست
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // خطای تقسیم بر صفر
```

### **عملگرهای حسابی**

| عملگر | معنی | مثال |
|---|---|---|
| `+` | جمع یا مثبت یکنواخت | `2+3` |
| `-` | تفریق یا منفی یکنواخت | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | تقسیم | `2/3` |
| `%` | درصد | `30%` |
| `^` | توان | `2^3` |

برای صریح کردن ترتیب ارزیابی از پرانتز استفاده کنید، برای مثال `(A2+B2)*C2`.

### **عملگرهای مقایسه‌ای**

عبارات مقایسه‌ای مقادیر منطقی بازمی‌گردانند.

| عملگر | معنی | مثال |
|---|---|---|
| `=` | مساوی | `A2=3` |
| `<>` | نامساوی | `A2<>3` |
| `>` | بزرگ‌تر | `A2>3` |
| `>=` | بزرگ‌تر یا مساوی | `A2>=3` |
| `<` | کوچکتر | `A2<3` |
| `<=` | کوچکتر یا مساوی | `A2<=3` |

## **توابع پیش‌تعریف‌شدهٔ پشتیبانی‌شده**

Aspose.Slides یک ارزیاب فرمول داخلی برای برگه‌های کاری نمودار دارد، ولی این یک موتور محاسبهٔ کامل Excel نیست. مجموعهٔ توابع مستند شده به توابع زیر محدود شده است. فرض نکنید هر تابع Excel می‌تواند توسط [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) بازمحاسبه شود.

| تابع | هدف یا فرم پشتیبانی‌شده | مثال |
|---|---|---|
| `ABS` | مقدار مطلق | `ABS(A2)` |
| `AVERAGE` | میانگین حسابی | `AVERAGE(B2:B5)` |
| `CEILING` | گرد کردن عدد به سمت بالا تا مضرب | `CEILING(A2,5)` |
| `CHOOSE` | انتخاب مقدار بر اساس ایندکس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | اتصال مقادیر متنی | `CONCAT(A2,B2)` |
| `CONCATENATE` | اتصال مقادیر متنی | `CONCATENATE(A2," ",B2)` |
| `DATE` | ایجاد مقدار تاریخ با استفاده از سیستم تاریخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | بازگرداندن تعداد روزها بین دو تاریخ | `DAYS(B2,A2)` |
| `FIND` | یافتن یک مقدار متنی داخل مقدار دیگر | `FIND("-",A2)` |
| `FINDB` | جستجوی بایت‑محور متن | `FINDB("a",A2)` |
| `IF` | نتیجهٔ شرطی | `IF(A2>0,A2,0)` |
| `INDEX` | فرم مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | فرم برداری | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | فرم برداری | `MATCH(A2,B2:B5,0)` |
| `MAX` | حداکثر مقدار | `MAX(B2:B5)` |
| `SUM` | جمع مقادیر | `SUM(B2:B5)` |
| `VLOOKUP` | جستجوی عمودی | `VLOOKUP(A2,B2:D10,3,FALSE)` |

محدودیت‌های نشان داده شده در جدول مهم هستند: `INDEX` به صورت فرم مرجع مستند شده، در حالی‌که `LOOKUP` و `MATCH` به صورت فرم‌های برداری مستند هستند. `DATE` از سیستم تاریخ 1900 استفاده می‌کند. ویژگی‌ها و توابعی که در اینجا فهرست نشده‌اند، باید به عنوان غیرقابل پشتیبانی توسط ارزیاب فرمول Aspose.Slides شناخته شوند مگر اینکه به‌طور جداگانه مستند شوند.

## **محاسبهٔ فرمول‌ها با فرهنگ‌پیش‌فرض**

برخی از توابع کتاب‌کار نمودار متن را بر اساس قوانین مخصوص به فرهنگ‌ّها تفسیر می‌کنند. این موضوع به‌ویژه برای توابعی که برای زبان‌های دارای مجموعه‌حروف دوتایی (DBCS) طراحی شده‌اند، اهمیت دارد. برای محاسبهٔ صحیح چنین فرمول‌هایی، ابتدا یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/) ایجاد کنید، از طریق [LoadOptions::set_SpreadsheetOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) گزینهٔ [ISpreadsheetOptions::set_PreferredCulture](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ispreadsheetoptions/set_preferredculture/) را تنظیم کنید و سپس ارائه را بارگذاری کنید.

مثال زیر فرهنگ ژاپنی را انتخاب می‌کند، ارائه‌ای را با گزینه‌های بارگذاری پیکربندی‌شده باز می‌کند و برای هر کتاب‌کار نمودار متد [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) را فراخوانی می‌کند:

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/globalization/culture_info.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;
using namespace System::Globalization;

auto japaneseCulture = CultureInfo::GetCultureInfo(u"ja-JP");

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_PreferredCulture(japaneseCulture);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<IChart>(shape))
        {
            auto chart = ExplicitCast<IChart>(shape);
            chart->get_ChartData()->get_ChartDataWorkbook()->CalculateFormulas();
        }
    }
}
```

فرهنگ پیش‌فرض بخشی از پیکربندی بارگذاری ارائه است، بنابراین پیش از ساخت شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) آن را تعیین کنید. از فرهنگی استفاده کنید که توسط فرمول‌های کتاب‌کار انتظار می‌رود؛ برای مثال برای قوانین محاسبهٔ DBCS ژاپنی `ja-JP` را بکار ببرید.

## **بازمحاسبه و مقادیر کش‌شده**

فایل‌های صفحه‌گسترده معمولاً هم فرمول و هم آخرین مقدار محاسبه‌شدهٔ آن را ذخیره می‌کنند. بنابراین Aspose.Slides می‌تواند مقدار کش‌شده را از [IChartDataCell::get_Value](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/get_value/) بخواند وقتی ارائه بارگذاری می‌شود و دادهٔ نمودار مرتبط تغییر نگرفته باشد.

پس از تغییر سلول‌های ورودی یا فرمول‌ها، به مقدار کش‌شدهٔ قدیمی تکیه نکنید. قبل از خواندن مقادیر محاسبه‌شده یا ذخیرهٔ داده‌های نموداری که به آن‌ها وابسته‌اند، متد [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) را فراخوانی کنید.

برای فرمول‌های خارج از زیرمجموعهٔ پشتیبانی‌شده، ممکن است Aspose.Slides نتواند فرمول را تجزیه یا وابستگی‌های آن را تعیین کند. اگر کتاب‌کار اصلاح شده باشد، مقدار کش‌شدهٔ قبلی دیگر قابل اعتماد نیست. در این وضعیت، خواندن مقدار سلولی که دادهٔ پشتیبانی‌نشده دارد می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) را تولید کند.

اگر نمودار شما به توابع Excel وابسته است که Aspose.Slides آن‌ها را ارزیابی نمی‌کند، آن فرمول‌ها را با یک موتور صفحه‌گسترده که آن‌ها را پشتیبانی می‌کند محاسبه کرده و مقادیر حاصل را به کتاب‌کار نمودار بنویسید. از جایگزینی فرمول‌های پشتیبانی‌نشده با مقادیر تخمین‌زده خودداری کنید.

## **مدیریت خطاهای فرمول**

دو نوع مشکل متفاوت وجود دارد.

یک فرمول می‌تواند صحیح باشد اما نتیجهٔ خطای صفحه‌گسترده مانند `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` یا `#VALUE!` تولید کند. در این حالت توکن خطا همان نتیجهٔ سلول است و می‌تواند از طریق [IChartDataCell::get_Value](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/get_value/) بازگردانده شود.

یک فرمول می‌تواند در سطح تجزیه، مرجع، وابستگی یا داده‌های پشتیبانی‌شده شکست بخورد. Aspose.Slides برای این موارد استثنای‌های مخصوص صفحه‌گسترده‌ای فراهم می‌کند: [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/)، [CellInvalidReferenceException](https://reference.aspose.com/slides/fa/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/)، [CellCircularReferenceException](https://reference.aspose.com/slides/fa/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) و [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

هنگام دریافت فرمول‌ها از قالب‌ها یا ورودی کاربر، این استثنائات را در اطراف بازمحاسبه و دسترسی به مقدار مدیریت کنید:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // پردازش فرمول نامعتبر.
}
catch (CellInvalidReferenceException&)
{
    // پردازش ارجاع سلول نامعتبر.
}
catch (CellCircularReferenceException&)
{
    // پردازش ارجاع دایره‌ای.
}
catch (CellUnsupportedDataException&)
{
    // پردازش داده‌های صفحه‌گستردهٔ پشتیبانی‌نشده.
}
```

## **محدودیت‌های عملی**

پشتیبانی از فرمول در برگه‌های کاری نمودار برای یک زیرمجموعهٔ تعریف‌شده از محاسبات صفحه‌گسترده است و برای سازگاری کامل با Excel هدف‌گذاری نشده است. هنگام طراحی یک گردش کار گزارش‌دهی این محدودیت‌ها را در نظر بگیرید:

- فقط از ثابت‌ها، عملگرها، مراجع و توابع مستند شده‌ای که نیاز به بازمحاسبه توسط Aspose.Slides دارید استفاده کنید.
- پس از تغییر سلول‌هایی که نتایج فرمول به آن‌ها وابسته است، بازمحاسبه کنید.
- مقادیر کش‌شدهٔ ارائه‌های بارگذاری‌شده را به عنوان «عکس‌برداری» در نظر بگیرید، نه به‌عنوان جایگزینی برای بازمحاسبه پس از ویرایش.
- قبل از اعتماد به مقادیر محاسبه‌شدهٔ قالب‌های موجود، فرمول‌ها را تست کنید، به‌ویژه اگر از توابع خارج از لیست مستند شده استفاده می‌کنند.
- برای فرمول‌هایی که نیاز به یک موتور محاسبهٔ کامل صفحه‌گسترده دارند، آن‌ها را به‌صورت خارجی محاسبه کنید و سپس کتاب‌کار نمودار را با مقادیر نهایی به‌روز نمایید.

## **سوالات متداول**

**تفاوت `set_Formula` و `set_R1C1Formula` چیست؟**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/set_formula/) یک عبارت سبک A1 مثل `B2-C2` را ذخیره می‌کند. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) یک عبارت سبک R1C1 مثل `RC[-2]-RC[-1]` را ذخیره می‌کند. نوشتار مناسب را بر وفقۀ نحوهٔ تولید یا کپی فرمول‌های خود انتخاب کنید.

**آیا پس از محاسبه باید خود سلول یا مقدار آن را بخوانم؟**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) یک `IChartDataCell` بر می‌گرداند. برای به دست آوردن نتیجهٔ محاسبه‌شده، پس از بازمحاسبه مقدار آن سلول را از طریق [IChartDataCell::get_Value](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/get_value/) بخوانید.

**چه زمانی باید `CalculateFormulas` را فراخوانی کنم؟**

پس از تغییر مقادیر ورودی یا فرمول‌ها و پیش از وابستگی به نتایج محاسبه‌شده، متد [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) را فراخوانی کنید. این کار مقادیر فرمول‌های پشتیبانی‌شده توسط ارزیاب داخلی را به‌روز می‌کند.

**آیا Aspose.Slides همه توابع Excel را پشتیبانی می‌کند؟**

خیر. ارزیاب داخلی فقط یک زیرمجموعهٔ مستند شده از توابع را پشتیبانی می‌کند. توابع خارج از این زیرمجموعه نباید به‌عنوان قابل بازمحاسبه تلقی شوند. اگر سازگاری کامل با فرمول‌های Excel لازم است، محاسبه را با یک موتور صفحه‌گسترده مناسب انجام داده و مقادیر نهایی را در کتاب‌کار نمودار بنویسید.

**اگر ارائه بارگذاری‌شده حاوی فرمول پشتیبانی‌نشده باشد چه می‌شود؟**

اگر داده‌های نمودار تغییر نکرده باشد، ممکن است کتاب‌کار هنوز مقدار کش‌شدهٔ قبلی را داشته باشد. پس از تغییر داده‌های مرتبط، آن مقدار کش‌شده ممکن است دیگر معتبر نباشد. دسترسی به سلولی که فرمول آن قابل پردازش نیست می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) را ایجاد کند.

**آیا مقادیر خطای فرمول همان استثنای C++ هستند؟**

نه. مقادیری مانند `#DIV/0!` یک مقدار صفحه‌گسترده هستند که توسط یک محاسبهٔ معتبر تولید می‌شوند. استثنای‌هایی مانند [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) یا [CellCircularReferenceException](https://reference.aspose.com/slides/fa/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) نشان می‌دهند که فرمول به‌طور عادی قابل پردازش نیست.

**آیا تغییر یک سلول فرمول باعث به‌روزرسانی خودکار نمودار می‌شود؟**

سری‌های نمودار می‌توانند به سلول‌های کتاب‌کار ارجاع دهند. ابتدا کتاب‌کار را بازمحاسبه کنید، سپس ارائه را ذخیره یا رندر کنید. اگر نقاط دادهٔ نمودار به سلول‌های محاسبه‌شده ارجاع داشته باشند، نمودار از مقادیر به‌روز شدهٔ آن‌ها استفاده می‌کند؛ نیازی به روش جداگانه‌ای برای تازه‑سازی نمودار در این جریان کاری نیست.

**آیا نمودارها می‌توانند از یک کتاب‌کار Excel خارجی استفاده کنند؟**

بله، داده‌های نمودار می‌توانند از طریق API داده‌های نمودار برای استفاده از یک کتاب‌کار خارجی پیکربندی شوند. با این حال، جریان کاری محاسبهٔ فرمول توضیح‌داده‌شده در این مقاله مربوط به کتاب‌کار دادهٔ نمودار و زیرمجموعهٔ فرمولی است که توسط Aspose.Slides ارزیابی می‌شود. فرض نکنید که [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) بازمحاسبهٔ کامل فرمول‌های دلخواه را در یک فایل XLSX خارجی فراهم می‌کند.

**آیا می‌توانم از فرمول‌هایی استفاده کنم که به برگه کاری یا کتاب‌کار دیگری ارجاع می‌دهند؟**

مرجع‌های سبک Excel ممکن است در کتاب‌کارهای نمودار وجود داشته باشند، اما ارزیابی فرمول توسط تجزیه‌کننده و مجموعهٔ توابع پشتیبانی‌شده محدود است. اگر ارجاع متقابل یا خارجی ضروری است، دقیقاً همان فرمول را با نسخهٔ هدف Aspose.Slides خود اعتبارسنجی کنید. برای گردش کارهایی که نیاز به سازگاری گستردهٔ ارجاع Excel دارند، کتاب‌کار را به‌صورت خارجی محاسبه کنید و مقادیر حل‌شده را به دادهٔ نمودار بازنویسی کنید.

**آیا رشته‌های فرمول باید با `=` شروع شوند؟**

نمونه‌های API Aspose.Slides عبارات مثل `B2-C2` یا `SUM(B2:B5)` را بدون `=` پیشوندی اختصاص می‌دهند. استفاده از این شکل باعث می‌شود فرمول‌های تولیدشده با نمونه‌های مستند API سازگار باشند.