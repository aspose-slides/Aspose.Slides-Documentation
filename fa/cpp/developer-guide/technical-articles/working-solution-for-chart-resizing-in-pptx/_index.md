---
title: راه‌حل عملی برای تغییر اندازه نمودار در PPTX
type: docs
weight: 60
url: /fa/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغییر اندازه نمودار
- نمودار اکسل
- شیء OLE
- جاسازی نمودار
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "رفع تغییر اندازه غیرمنتظره نمودار در فایل PPTX هنگام استفاده از اشیاء OLE اکسل جاسازی‌شده با Aspose.Slides برای C++. تنظیم ابعاد ثابت نمودار برای حفظ سازگاری اندازه‌های نمودار و فریم OLE."
---
## **پس‌زمینه**

نمودارهای اکسل که به عنوان اشیاء OLE در ارائه‌های PowerPoint با استفاده از اجزای Aspose جاسازی می‌شوند، ممکن است پس از اولین فعال‌سازی اندازه‌شان تغییر کند. این می‌تواند اختلاف قابل‌توجهی در ظاهر نمودار قبل و بعد از فعال‌سازی ایجاد کند. این مقاله توضیح می‌دهد چرا تغییر اندازه رخ می‌دهد و نشان می‌دهد چگونه می‌توان با تطبیق ابعاد ثابت نمودار با فریم OLE از آن جلوگیری کرد.

در [ایجاد نمودارهای اکسل و جاسازی آن‌ها به صورت اشیاء OLE در ارائه‌ها](/slides/fa/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) ما توضیح دادیم که چگونه یک نمودار اکسل را با Aspose.Cells for C++ ایجاد و آن را با Aspose.Slides for C++ در یک ارائه PowerPoint جاسازی کنیم. برای رفع [مشکل پیش‌نمایش شیء](/slides/fa/cpp/object-preview-issue-when-adding-oleobjectframe/) ما تصویر نمودار را به فریم OLE شیء اختصاص دادیم. در ارائه خروجی، وقتی فریم OLE که تصویر نمودار را نمایش می‌دهد دوبار کلیک می‌شود، نمودار اکسل فعال می‌شود. کاربران می‌توانند کتاب کار جاسازی‌شده را ویرایش کنند و سپس با کلیک خارج از کتاب کار فعال‌شده به اسلاید برگردند. اندازه فریم OLE هنگام بازگشت کاربر به اسلاید تغییر می‌کند و عامل تغییر اندازه بسته به اندازه‌های اولیه هر دو فریم OLE و کتاب کار جاسازی‌شده متفاوت است.

## **دلیل تغییر اندازه**

کتاب کار اکسل جاسازی‌شده ابعاد پنجره خود را دارد که اکسل سعی می‌کند هنگام اولین فعال‌سازی شیء آن را حفظ کند. فریم OLE روی اسلاید ابعاد مستقلی دارد. وقتی کتاب کار اکسل فعال می‌شود، اکسل و PowerPoint اندازه شیء را برای حفظ نسبت‌ها در فرآیند جاسازی مذاکره می‌کنند. تفاوت بین پنجره کتاب کار و فریم OLE می‌تواند منجر به تغییر اندازه شیء شود.

## **راه‌حل عملی**

ابعاد نمودار را با فریم OLE روی اسلاید تطبیق دهید و ابعاد نمودار را مستقل از پنجره کتاب کار نگه دارید. این راه‌حل برای یک ارائه جدید یا یک قالب موجود کار می‌کند.

مثال نیاز به Aspose.Cells for C++ و Aspose.Slides for C++ دارد. این مثال یک نمودار ستونی ساده بر روی یک شیت نمودار فعال ایجاد کرده و کتاب کار را در قالب XLS جاساز می‌کند. هیچ تصویر پیش‌نمایش نموداری اختصاص داده نمی‌شود؛ نمودار زمانی که شیء OLE در PowerPoint فعال می‌شود قابل مشاهده می‌شود.

کد مثال را در نقطه ورودی برنامه خود قرار دهید و اعلان‌های include را در سطح فایل بنویسید. Aspose.Cells را قبل از ایجاد اشیاء آن مقداردهی اولیه کنید و پس از نابودی آن اشیاء منابع را آزاد کنید. مثال بردار بایتی کتاب کار برگشتی از Aspose.Cells را به نوع آرایه‌ای که Aspose.Slides می‌پذیرد، کپی می‌کند.

مثال یک ارائه جدید با فریم OLE به اندازه 9.5 × 4 اینچ ایجاد می‌کند که 0.5 اینچ از لبه چپ و 1 اینچ از بالا موقعیت دارد. مختصات و ابعاد اسلاید بر حسب پوینت (72 پوینت در هر اینچ) هستند. برای ارائه موجود، به [استفاده از قالب](#use-a-template) مراجعه کنید.

## **تنظیم اندازه ثابت نمودار**

Set [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) را روی false تنظیم کنید تا ابعاد نمودار مستقل از پنجره کتاب کار باشد. ابعاد [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) را از طریق [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) و [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/) تنظیم کنید و پوینت‌ها را با استفاده از 96 پیکسل در هر اینچ به پیکسل تبدیل کنید: فریمی با اندازه 684 × 288 پوینت معادل نموداری با اندازه 912 × 384 پیکسل است. [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) را به مقدار Custom از [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/) تنظیم کنید. مثال کتاب کار را با [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) جاسازی می‌کند و یک ارائه با فریم OLE به اندازه 9.5 × 4 اینچ ذخیره می‌کند.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // مختصات و ابعاد اسلاید بر حسب پوینت هستند (۷۲ پوینت در هر اینچ).
    auto width = 684.f; // 9.5 اینچ.
    auto height = 288.f; // 4 اینچ.

    chart.SetSizeWithWindow(false);
    // تبدیل پوینت‌ها به پیکسل‌های نمودار با استفاده از ۹۶ پیکسل در هر اینچ.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // بردار بایت‌های Cells را به نوع آرایه‌ای که Slides می‌پذیرد کپی کنید.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **استفاده از قالب**

منطق اندازه‌گیری برای یک ارائه موجود همانند است. برای تطبیق مثال:

1. قالب ارائه را بارگذاری کنید به جای ایجاد یک ارائه خالی.
2. بررسی کنید که اسلاید اول حداقل سه شکل داشته باشد، سپس شکل با شاخص 2 را به عنوان نگهدارنده استفاده کنید.
3. عرض و ارتفاع فریم را از آن شکل بگیرید به جای استفاده از مقادیر ثابت 684 و 288. محاسبات اندازه‌گیری را بدون تغییر نگه دارید.
4. فریم OLE را در موقعیت نگهدارنده اضافه کنید به جای مختصات ثابت 36 و 72.
5. قبل از ذخیره ارائه، نگهدارنده را حذف کنید.

## **سوالات متداول**

**چرا نمودار اکسل جاسازی‌شده من پس از فعال‌سازی در PowerPoint اندازه‌اش تغییر می‌کند؟**

این به این دلیل است که اکسل سعی می‌کند اندازه اصلی پنجره را هنگام اولین فعال‌سازی بازگرداند، در حالی که فریم OLE در PowerPoint ابعاد مستقلی دارد. PowerPoint و اکسل برای حفظ نسبت ابعاد مذاکره می‌کنند که می‌تواند منجر به تغییر اندازه شود.

**چگونه می‌توانم اندازه‌های نمودار و فریم OLE را سازگار نگه دارم؟**

ابعاد ثابت نمودار که با فریم OLE مطابقت دارد تنظیم کنید و قبل از جاسازی کتاب کار، اندازه چاپ سفارشی نمودار را اعمال کنید. مثال بالا تنظیمات لازم و تبدیل واحدها را نشان می‌دهد.

**آیا مطابقت اندازه پنجره کتاب کار کافی است؟**

فقط مطابقت اندازه پنجره کتاب کار به‌طور قابل‌اعتمادی از تغییر اندازه فریم OLE پس از فعال‌سازی جلوگیری نمی‌کند. از ابعاد ثابت نمودار همان‌طور که در مثال نشان داده شده استفاده کنید.

**آیا این راه‌حل برای ارائه‌های مبتنی بر قالب و ارائه‌های جدید کار می‌کند؟**

بله. برای قالب، از ابعاد و موقعیت نگهدارنده استفاده کنید. برای ارائه جدید، ابعاد و موقعیت فریم را مستقیماً مشخص کنید.

**آیا می‌توانم از این مثال با نمودارهای ساخته‌شده در برنامه‌های صفحه‌گسترده دیگر استفاده کنم؟**

این مثال از یک کتاب کار اکسل ایجاد‌شده با Aspose.Cells استفاده می‌کند و رفتار فعال‌سازی برنامه‌های صفحه‌گسترده دیگر را نشان نمی‌دهد.

## **بخش‌های مرتبط**

- [ایجاد نمودارهای اکسل و جاسازی آن‌ها به صورت اشیاء OLE در ارائه‌ها](/slides/fa/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)