---
title: اعمال فرمول‌های کاربرگ نمودار در ارائه‌ها با استفاده از C++
linktitle: فرمول‌های کاربرگ
type: docs
weight: 70
url: /fa/cpp/chart-worksheet-formulas/
keywords:
- صفحه‌گسترده نمودار
- کاربرگ نمودار
- فرمول نمودار
- فرمول کاربرگ
- فرمول صفحه‌گسترده
- دفتر کار داده‌های نمودار
- محاسبه فرمول
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
description: "فرمول‌های سبک Excel را در کاربرگ‌های نمودار Aspose.Slides برای C++ اعمال کنید، مقادیر را دوباره محاسبه کنید و نتایج را در نمودارهای PowerPoint استفاده کنید."
---
## **نمای کلی**

نمودارهای PowerPoint معمولاً داده‌های منبع خود را در یک کاربرگ جاسازی‌شده ذخیره می‑کنند. در Aspose.Slides برای C++ می‌توانید از طریق کتاب‌کار داده‌های نمودار به آن کاربرگ دسترسی پیدا کنید، مقادیر ورودی را بنویسید، فرمول‌ها را به سلول‌ها اختصاص دهید، فرمول‌های پشتیبانی‌شده را محاسبه کنید و از سلول‌های محاسبه‌شده به عنوان داده‌های نمودار استفاده کنید.

این مقاله جریان کاری کامل فرمول‌ها را شرح می‌دهد: ایجاد یک نمودار، پر کردن کاربرگ آن، اختصاص فرمول‌های سبک A1 یا R1C1، بازمحاسبه آن‌ها، خواندن مقادیر محاسبه‌شده، اتصال این سلول‌ها به یک سری نمودار و ذخیره ارائه. همچنین نحو فرمول‌های پشتیبانی‌شده، زیرمجموعه توابع داخلی، مقادیر کش‌شده، فرمول‌های غیرپشتیبانی‌شده و خطاهای مخصوص‌به‑جدولی را توصیف می‌کند.

## **کاربرگ‌های نمودار و فرمول‌ها**

یک کاربرگ نمودار شامل دسته‌بندها، نام‌های سری و مقادیری است که توسط یک نمودار استفاده می‌شوند. در PowerPoint می‌توانید کاربرگ را با باز کردن ویرایشگر داده‌های نمودار بررسی کنید:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

در Aspose.Slides، کاربرگ از طریق رابط [IChartDataWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/) در دسترس قرار می‌گیرد. برای فرمول‌های سبک A1 از [IChartDataCell::set_Formula](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/set_formula/) و برای فرمول‌های سبک R1C1 از [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) استفاده کنید. پس از تغییر سلول‌های ورودی یا فرمول‌ها، برای بازمحاسبه فرمول‌های پشتیبانی‌شده و به‌روزرسانی مقادیر سلول‌های مربوطه، متد [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) را فراخوانی کنید.

یک سلول محاسبه‌شده همچنان نتیجه خود را از طریق [IChartDataCell::get_Value](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/get_value/) ارائه می‌دهد. این مهم است وقتی که نیاز دارید نتیجه یک فرمول را در کد بررسی کنید یا سلول را به عنوان یک نقطه دادهٔ نمودار استفاده کنید.

## **ایجاد نمودار و محاسبه فرمول‌های کاربرگ**

مثال زیر یک جریان کاری انتها‑به‑انتها را نشان می‌دهد. این مثال یک نمودار ستون خوشه‌ای ایجاد می‌کند، داده‌های نمونه را پاک می‌کند، مقادیر درآمد و هزینهٔ فصلی را می‌نویسد، سود را با فرمول‌ها محاسبه می‌کند، نتایج را می‌خواند، سلول‌های محاسبه‌شده را به عنوان مقادیر نمودار استفاده می‌کند و ارائه را ذخیره می‌نماید.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
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

نقاط دادهٔ نمودار به `D2:D4` ارجاع می‌دهند، بنابراین نمودار از مقادیر سود محاسبه‌شده استفاده می‌کند. در این جریان کاری هیچ فراخوانی جداگانه‌ای برای به‌روزرسانی نمودار وجود ندارد: ابتدا کتاب‌کار را بازمحاسبه کنید، سپس از داده‌های نمودار که به سلول‌های محاسبه‌شده اشاره دارند استفاده کنید یا آن را ذخیره نمایید.

## **استفاده از فرمول‌های سبک A1**

نظام A1 ستون‌ها را با حروف و ردیف‌ها را با عدد شناسایی می‌کند. عبارات سبک A1 را از طریق [IChartDataCell::set_Formula](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/set_formula/) اختصاص دهید.

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

اشکال مرجع متداول A1 عبارتند از:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `A2` | `$A$2` | `A$2`, `$A2` |
| ردیف | `2:2` | `$2:$2` | — |
| ستون | `A:A` | `$A:$A` | — |
| بازه | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

مرجع‌های نسبی می‌توانند هنگام جابجا یا کپی شدن فرمول توسط یک برنامهٔ صفحه‌گسترده تغییر کنند. مراجع مطلق هر دو مختصات را ثابت نگه می‌دارند، در حالی که مراجع ترکیبی فقط یک ردیف یا یک ستون را ثابت می‌کنند.

## **استفاده از فرمول‌های سبک R1C1**

نظام R1C1 ردیف‌ها و ستون‌ها را به‌صورت عددی شناسایی می‌کند. مراجع نسبی از افست‌ها در کروشه‌ها استفاده می‌کنند. این نحو را از طریق [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) اختصاص دهید.

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

اشکال مرجع متداول R1C1 عبارتند از:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| ردیف | `R[2]` | `R2` | — |
| ستون | `C[3]` | `C3` | — |
| بازه | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

به عنوان مثال، در سلول `D2`، `RC[-2]` به سلولی در همان ردیف دو ستون به سمت چپ (`B2`) اشاره می‌کند.

## **ثابت‌ها و عملگرهای فرمول**

ارزیاب فرمول داخلی مقادیر منطقی، مقادیر عددی، رشته‌ها، مقادیر خطای صفحه‌گسترده، عملگرهای حسابی و عملگرهای مقایسه‌ای را پشتیبانی می‌کند.

### **ثابت‌ها و مقدارهای ثابت**

| نوع | مثال‌ها | نکات |
|---|---|---|
| منطقی | `TRUE`, `FALSE` | می‌توانند مستقیماً در عبارات منطقی مانند `A2=TRUE` استفاده شوند. |
| عددی | `1`, `0.5`, `.3`, `1E-2` | نوشتار اعشاری و علمی پشتیبانی می‌شود. |
| رشته | `"abc"`, `"2/3/2020 12:00"` | مقدارهای متنی داخل فرمول با نقل قول‌های دوگانه محصور می‌شوند. |
| نتیجهٔ خطا | `#DIV/0!`, `#N/A`, `#REF!` | یک فرمول معتبر می‌تواند به‌جای یک نتیجهٔ عادی، مقدار خطای صفحه‌گسترده برگرداند. |

این مثال چند نوع ثابت مختلف را به کار می‌برد:

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
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **عملگرهای حسابی**

| عملگر | معنای آن | مثال |
|---|---|---|
| `+` | جمع یا علامت مثبت تک‌تایی | `2+3` |
| `-` | تفریق یا منفی | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | تقسیم | `2/3` |
| `%` | درصد | `30%` |
| `^` | توان | `2^3` |

برای واضح کردن ترتیب ارزیابی از پرانتز استفاده کنید؛ برای مثال `(A2+B2)*C2`.

### **عملگرهای مقایسه‌ای**

عبارات مقایسه‌ای مقادیر منطقی باز می‌گردانند.

| عملگر | معنای آن | مثال |
|---|---|---|
| `=` | برابر | `A2=3` |
| `<>` | نامساوی | `A2<>3` |
| `>` | بزرگ‌تر | `A2>3` |
| `>=` | بزرگ‌تر یا برابر | `A2>=3` |
| `<` | کوچک‌تر | `A2<3` |
| `<=` | کوچک‌تر یا برابر | `A2<=3` |

## **توابع پیش‌تعریف‌شدهٔ پشتیبانی‌شده**

Aspose.Slides یک ارزیاب فرمول داخلی برای کاربرگ‌های نمودار دارد، اما این ارزیاب یک موتور کامل محاسبهٔ Excel نیست. مجموعهٔ مستند توابع محدود به توابع زیر است. فرض نکنید که هر تابع دلخواه Excel می‌تواند توسط [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) بازمحاسبه شود.

| تابع | هدف یا شکل پشتیبانی‌شده | مثال |
|---|---|---|
| `ABS` | مقدار مطلق | `ABS(A2)` |
| `AVERAGE` | میانگین حسابی | `AVERAGE(B2:B5)` |
| `CEILING` | گرد کردن عدد به سمت بالا به مضرب | `CEILING(A2,5)` |
| `CHOOSE` | انتخاب مقدار بر پایهٔ اندیس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | اتصال مقادیر متنی | `CONCAT(A2,B2)` |
| `CONCATENATE` | اتصال مقادیر متنی | `CONCATENATE(A2," ",B2)` |
| `DATE` | ایجاد مقدار تاریخ با استفاده از سیستم تاریخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | بازگرداندن تعداد روزهای بین دو تاریخ | `DAYS(B2,A2)` |
| `FIND` | یافتن یک متن داخل متن دیگر | `FIND("-",A2)` |
| `FINDB` | جستجوی متن بر پایه بایت | `FINDB("a",A2)` |
| `IF` | نتیجهٔ شرطی | `IF(A2>0,A2,0)` |
| `INDEX` | فرم مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | فرم برداری | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | فرم برداری | `MATCH(A2,B2:B5,0)` |
| `MAX` | بیشینه مقدار | `MAX(B2:B5)` |
| `SUM` | مجموع مقادیر | `SUM(B2:B5)` |
| `VLOOKUP` | جستجوی عمودی | `VLOOKUP(A2,B2:D10,3,FALSE)` |

محدودیت‌های نشان‌داده‌شده در جدول مهم هستند: `INDEX` به صورت فرم مرجع مستند شده، در حالی که `LOOKUP` و `MATCH` به صورت فرم‌های برداری مستند هستند. `DATE` از سیستم تاریخ 1900 استفاده می‌کند. ویژگی‌ها و توابعی که در اینجا فهرست نشده‌اند باید به‌عنوان غیرپشتیبانی‌شده توسط ارزیاب فرمول Aspose.Slides در نظر گرفته شوند مگر این‌که به‌صورت جداگانه مستند شوند.

## **بازمحاسبه و مقادیر کش‌شده**

فایل‌های صفحه‌گسترده معمولاً هم فرمول و هم آخرین مقدار محاسبه‌شدهٔ آن را ذخیره می‌کنند. بنابراین Aspose.Slides می‌تواند هنگام بارگذاری ارائه، مقدار کش‌شده را از طریق [IChartDataCell::get_Value](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/get_value/) بخواند، مشروط بر این‌که دادهٔ مربوط به نمودار تغییر نکرده باشد.

پس از تغییر سلول‌های ورودی یا فرمول‌ها، به نتیجهٔ کش‌شدهٔ قدیمی اعتماد نکنید. قبل از خواندن مقادیر محاسبه‌شده یا ذخیرهٔ داده‌های نموداری که به آن‌ها وابسته‌اند، متد [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) را فراخوانی کنید.

برای فرمول‌های خارج از زیرمجموعهٔ پشتیبانی‌شده، ممکن است Aspose.Slides نتواند فرمول را تجزیه یا وابستگی‌های آن را مشخص کند. اگر کتاب‌کار تغییر یافته باشد، مقدار کش‌شدهٔ قبلی دیگر قابل اطمینان نیست. در این حالت، خواندن مقدار سلولی که دارای دادهٔ غیرپشتیبانی‌شده است می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) را ایجاد کند.

اگر نمودار شما به توابع Excel وابسته است که Aspose.Slides ارزیابی نمی‌کند، آن فرمول‌ها را با یک موتور صفحه‌گستردهٔ پشتیبانی‌کننده محاسبه کنید و مقادیر حاصل را به کتاب‌کار نمودار بنویسید. از جایگزینی فرمول‌های غیرپشتیبانی‌شده با مقادیر تخمینی خودداری کنید.

## **مدیریت خطاهای فرمول**

دو نوع مشکل مختلف برای تشخیص وجود دارد.

یک فرمول می‌تواند معتبر باشد ولی نتیجهٔ خطای صفحه‌گسترده‌ای مانند `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` یا `#VALUE!` تولید کند. در این صورت توکن خطا یک نتیجهٔ سلولی است و می‌تواند از طریق [IChartDataCell::get_Value](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/get_value/) برگردانده شود.

یک فرمول همچنین می‌تواند در مرحلهٔ تجزیه، ارجاع، وابستگی یا سطح داده‌های پشتیبانی‌شده شکست بخورد. Aspose.Slides برای این موارد استثناهای مخصوص صفحه‌گسترده فراهم می‌کند: [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fa/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fa/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) و [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

وقتی فرمول‌ها از قالب‌ها یا ورودی کاربر می‌آیند، این استثناها را در اطراف بازمحاسبه و دسترسی به مقدار مدیریت کنید:

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
    // مدیریت یک فرمول نامعتبر.
}
catch (CellInvalidReferenceException&)
{
    // مدیریت یک ارجاع سلولی نامعتبر.
}
catch (CellCircularReferenceException&)
{
    // مدیریت یک ارجاع دوری.
}
catch (CellUnsupportedDataException&)
{
    // مدیریت داده‌های صفحه‌گستردهٔ غیرپشتیبانی‌شده.
}
```

## **محدودیت‌های عملی**

پشتیبانی از فرمول در کاربرگ‌های نمودار برای یک زیرمجموعهٔ تعریف‌شده از محاسبات صفحه‌گسترده هدف‌گذاری شده است و نه برای سازگاری کامل با Excel. این محدودیت‌ها را هنگام طراحی یک گردش کار گزارش‌گیری در نظر بگیرید:

- فقط از ثابت‌ها، عملگرها، مراجع و توابع مستند شده‌ای که نیاز به بازمحاسبهٔ فرمول توسط Aspose.Slides دارید استفاده کنید.
- پس از تغییر سلول‌هایی که نتایج فرمول به آن‌ها وابسته است، بازمحاسبه کنید.
- مقادیر کش‌شدهٔ ارائه‌های بارگذاری‌شده را به‌عنوان «عکس‌لحظه‌ای» در نظر بگیرید، نه به‌عنوان جایگزین بازمحاسبه پس از ویرایش.
- قبل از اتکای کامل به مقادیر محاسبه‌شده، فرمول‌های موجود در قالب‌های فعلی را تست کنید، به‌ویژه اگر از توابعی خارج از فهرست مستند شده استفاده می‌کنند.
- برای فرمول‌هایی که به یک موتور محاسبهٔ کامل صفحه‌گسترده نیاز دارند، آن‌ها را به‌صورت خارجی محاسبه کنید و سپس کتاب‌کار نمودار را با مقادیر نهایی به‌روز کنید.

## **پرسش‌های متداول**

**差异 `set_Formula` 与 `set_R1C1Formula` چیست؟**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/set_formula/) یک عبارت سبک A1 مانند `B2‑C2` ذخیره می‌کند. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) یک عبارت سبک R1C1 مانند `RC[-2]-RC[-1]` ذخیره می‌کند. نوشتاری را انتخاب کنید که با نحوهٔ تولید یا کپی فرمول‌های شما بیشترین تطابق را دارد.

**آیا پس از محاسبه باید خود سلول یا مقدار آن را بخوانم؟**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) یک `IChartDataCell` برمی‌گرداند. برای دریافت نتیجهٔ محاسبه‌شده، پس از بازمحاسبه مقدار [IChartDataCell::get_Value](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/get_value/) آن سلول را بخوانید.

**چه زمانی باید `CalculateFormulas` را فراخوانی کنم؟**

پس از تغییر مقادیر ورودی یا فرمول‌ها و قبل از اینکه به نتایج محاسبه‌شده وابسته باشید، متد [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) را صدا بزنید. این کار مقادیر فرمول‌های پشتیبانی‌شده توسط ارزیاب داخلی را به‌روز می‌کند.

**آیا Aspose.Slides همهٔ توابع Excel را پشتیبانی می‌کند؟**

خیر. ارزیاب داخلی فقط زیرمجموعهٔ مستند شده‌ای از توابع را پشتیبانی می‌کند. توابعی که خارج از این زیرمجموعه هستند نباید انتظار داشته باشید که به درستی بازمحاسبه شوند. اگر سازگاری کامل با فرمول‌های Excel لازم است، محاسبه را با یک موتور صفحه‌گستردهٔ مناسب انجام دهید و مقادیر نهایی را به کتاب‌کار نمودار بنویسید.

**اگر یک ارائهٔ بارگذاری‌شده شامل یک فرمول غیرپشتیبانی‌شده باشد چه می‌شود؟**

اگر دادهٔ نمودار تغییر نکرده باشد، ممکن است کتاب‌کار هنوز مقدار کش‌شدهٔ قبلی را داشته باشد. پس از تغییر داده‌های مرتبط، آن مقدار کش‌شده ممکن است دیگر معتبر نباشد. دسترسی به سلولی که فرمول آن قابل پردازش نیست می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) را ایجاد کند.

**آیا مقادیر خطای فرمول همان استثناهای C++ هستند؟**

خیر. مقدارهایی مانند `#DIV/0!` یک مقدار صفحه‌گسترده هستند که توسط یک محاسبهٔ معتبر تولید می‌شوند. استثناهایی مانند [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) یا [CellCircularReferenceException](https://reference.aspose.com/slides/fa/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) نشان می‌دهند که فرمول نمی‌تواند به‌صورت عادی پردازش شود.

**آیا هنگام تغییر یک سلول فرمولی، نمودار به‌صورت خودکار به‌روز می‌شود؟**

سری‌های نمودار می‌توانند به سلول‌های کتاب‌کار ارجاع دهند. ابتدا کتاب‌کار را بازمحاسبه کنید، سپس ارائه را ذخیره یا رندر کنید. اگر نقاط دادهٔ نمودار به سلول‌های محاسبه‌شده ارجاع دهند، نمودار از مقادیر به‌روز شدهٔ این سلول‌ها استفاده می‌کند؛ نیازی به فراخوانی جداگانه‌ای برای به‌روزرسانی نمودار در این جریان کاری نیست.

**آیا نمودارها می‌توانند از یک کتاب‌کار Excel خارجی استفاده کنند؟**

بله، داده‌های نمودار می‌توانند از طریق API داده‌های نمودار به یک کتاب‌کار خارجی تنظیم شوند. با این حال، جریان کاری محاسبهٔ فرمولی که در این مقاله توضیح داده شده مربوط به کتاب‌کار دادهٔ نمودار و زیرمجموعهٔ فرمولی ارزیابی‌شده توسط Aspose.Slides است. فرض نکنید که [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) بازمحاسبهٔ کامل فرمول‌های دلخواه در یک فایل XLSX خارجی را انجام می‌دهد.

**آیا می‌توانم از فرمول‌هایی استفاده کنم که به کاربرگ یا کتاب‌کار دیگری ارجاع می‌دهند؟**

مراجع سبک Excel می‌توانند در کتاب‌کارهای نمودار وجود داشته باشند، اما ارزیابی فرمول به‌وسیلهٔ پارسر و مجموعهٔ توابع پشتیبانی‌شده محدود است. اگر یک مرجع چندبرگه‌ای یا خارجی ضروری است، دقیقاً آن فرمول را با نسخهٔ هدف Aspose.Slides خود اعتبارسنجی کنید. برای گردش کارهایی که نیاز به سازگاری گستردهٔ مراجع Excel دارند، کتاب‌کار را به‌صورت خارجی محاسبه کنید و مقادیر حل‌شده را به دادهٔ نمودار بنویسید.

**آیا رشته‌های فرمول باید با `=` شروع شوند؟**

نمونه‌های API Aspose.Slides عبارات را بدون یک `=` ابتدایی مانند `B2-C2` یا `SUM(B2:B5)` اختصاص می‌دهند. استفاده از این شکل باعث می‌شود فرمول‌های تولیدشده با مثال‌های مستند API هماهنگ بمانند.