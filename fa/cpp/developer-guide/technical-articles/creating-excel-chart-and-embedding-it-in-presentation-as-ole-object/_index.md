---
title: ایجاد نمودارهای Excel و جاسازی آنها در ارائه‌ها به‌عنوان اشیای OLE
type: docs
weight: 40
url: /fa/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- نمودار Excel
- جاسازی نمودار
- شی OLE
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یک نمودار Excel را با Aspose.Cells برای C++ ایجاد کنید و کتاب‌کار را در یک ارائه PowerPoint با Aspose.Slides جاسازی کنید، به همراه پیش‌نمایش نمودار."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه یک نمودار ستونی Excel را با Aspose.Cells for C++ ایجاد کرده و کتاب کار آن را در یک ارائه PowerPoint با Aspose.Slides for C++ جاسازی کنید. کتاب کار جاسازی‌شده هم داده‌های منبع و هم نمودار را شامل می‌شود. یک پیش‌نمایش PNG جداگانه نمودار را روی اسلاید قبل از فعال شدن شی OLE نمایش می‌دهد.

نتیجه یک شی Excel جاسازی‌شده است، نه یک نمودار بومی PowerPoint. ویرایش کتاب کار از طریق OLE به یک برنامه دسکتاپی که از فعال‌سازی OLE پشتیبانی کند و نصب Excel سازگار نیاز دارد.

## **پیش‌نیازها**

پروژه C++ خود را با هدرها و کتابخانه‌های Aspose.Cells for C++ و Aspose.Slides for C++ پیکربندی کنید. کد مثال را در نقطه ورودی برنامه‌تان قرار دهید، با اعلان‌های include در سطح فایل. برای تولید ارائه با این کتابخانه‌ها نیاز به Microsoft Office نیست.

هیچ فایل ورودی‌ای مورد نیاز نیست: مثال داده‌ها و نمودار را در حافظه ایجاد می‌کند، سپس `OutputChart.pptx` را در پوشه کاری فعلی می‌نویسد. هنگام اجرا خارج از حالت ارزیابی، مجوزهای هر دو محصول را اعمال کنید.

## **نحوه عملکرد جاسازی**

1. یک کتاب کار با یک کاربرگ داده و یک صفحه نمودار ایجاد کنید.
1. صفحه نمودار را فعال کنید تا کتاب کار روی نمودار باز شود.
1. محدوده نمایش OLE کتاب کار را تنظیم کنید و نمودار را به PNG رندر کنید.
1. کتاب کار را به‌صورت XLSX در حافظه ذخیره کنید و آن بایت‌ها را در یک اسلاید جاسازی کنید.
1. PNG را به‌عنوان پیش‌نمایش شی OLE اختصاص دهید و ارائه را به‌صورت PPTX ذخیره کنید.

محدوده نمایش کتاب کار و چارچوب روی اسلاید نقش‌های متفاوتی دارند. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) شاخص‌های ردیف و ستون شروع/پایان را به‌صورت صفر‑محور می‌گیرد. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) به‌جای آن ردیف بالایی، ستون چپ، ردیف پایینی و ستون راست را دریافت می‌کند. مثال از شاخص ردیف 55 و ستون 25 به‌عنوان مرزهای پایین‑راست استفاده می‌کند؛ این مقادیر انتخاب‌های چیدمان هستند، نه تعداد ردیف‌ها یا ستون‌های داده.

چارچوب اسلاید از واحد نقطه استفاده می‌کند. مثال آن را درون اسلاید قرار می‌دهد و وسط‌چین می‌کند در حالی که نسبت تصویر PNG را حفظ می‌کند، به‌جای کشیدن پیش‌نمایش برای پر کردن اسلاید.

## **ایجاد و جاسازی نمودار**

مثال کامل زیر `DataSheet` را با چهار ردیف و پنج ستون از مقادیر پر می‌کند. هر ردیف تبدیل به یک سری نمودار می‌شود. `ChartSheet` قبل از ذخیره کتاب کار به‌عنوان شیت فعال انتخاب می‌شود.

کتاب کار به‌طور صریح به‌صورت XLSX ذخیره می‌شود، به‌طوری که پسوند `xlsx` به‌کار رفته در [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) مطابق باشد. PNG از یک جریان درون‑حافظه‌ای بارگذاری می‌شود بدون تبدیل به بیت‌مپ میانی. Aspose.Cells بردارهای بایت را برمی‌گرداند که مثال آن‌ها را به نوع آرایه‌ای که Aspose.Slides می‌پذیرد کپی می‌کند. قبل از استفاده از اشیاء Aspose.Cells آن‌ها را مقداردهی اولیه کنید و پس از نابودی آن‌ها منابع را آزاد کنید. اختصاص آن از طریق [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) جایگزین جای‌دار پیش‌فرض OLE می‌شود.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Initialize Cells before creating any of its objects.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // پیش‌نمایش نمودار را رندر کنید و کتاب‌کار قابل ویرایش را به‌صورت جداگانه سریالیزه کنید.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // بافرهای Cells را به نوع آرایه‌ای که Slides استفاده می‌کند کپی کنید.
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // پیش‌نمایش را درون اسلاید قرار دهید بدون تغییر نسبت طول‑به‑عرض آن.
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// پس از نابودی تمام اشیاء Cells، منابع Cells را آزاد کنید.
Aspose::Cells::Cleanup();
```

## **نتیجه مورد انتظار**

`OutputChart.pptx` شامل یک اسلاید با یک کتاب کار Excel جاسازی‌شده و پیش‌نمایش یک نمودار است. کتاب کار شامل داده‌های اصلی و یک نمودار ستونی با چهار سری است. پیش‌نمایش در وسط اسلاید قرار گرفته و نسبت‌های خود را حفظ می‌کند.

![نمودار ستونی Excel که به عنوان پیش‌نمایش یک کتاب کار جاسازی‌شده نمایش داده شده است](excel-chart-ole-preview.png)

در یک محیط دسکتاپ PowerPoint سازگار که Excel در دسترس باشد، برای فعال‌سازی و ویرایش کتاب کار جاسازی‌شده روی شی دوبار کلیک کنید. فعال‌سازی و ویرایش به پشتیبانی OLE برنامه میزبان و تنظیمات امنیتی آن بستگی دارد.

## **سؤال‌های متداول**

**چرا تصویر پیش‌نمایش لازم است؟**  
کتاب کار جاسازی‌شده و پیش‌نمایش اسلاید آن محتواهای جداگانه‌ای هستند. یک تصویر نمودار فراهم کنید تا اسلاید به جای جای‌دار پیش‌فرض «EMBEDDED OLE OBJECT» نمودار را نشان دهد. ببینید [مشکل پیش‌نمایش شی هنگام افزودن OleObjectFrame](/slides/fa/cpp/object-preview-issue-when-adding-oleobjectframe/).

**آیا پیش‌نمایش به‌صورت خودکار هنگام تغییر کتاب کار در کد به‌روز می‌شود؟**  
پیش‌نمایش را به‌عنوان یک تصویر ثابت در نظر بگیرید. هنگام به‌روزرسانی داده‌های کتاب کار برنامه‌نویسی، تصویر نمودار را دوباره تولید کنید و پیش‌نمایش و داده‌های کتاب کار جاسازی‌شده را جایگزین کنید.

**آیا می‌توانم به‌جای XLSX از XLS استفاده کنم؟**  
بله. کتاب کار را در قالب XLS ذخیره کنید و از پسوند `xls` به‌عنوان پسوند دادهٔ جاسازی‌شده استفاده کنید. پسوند باید با قالب واقعی کتاب کار مطابقت داشته باشد؛ فقط تغییر پسوند داده‌ها را تبدیل نمی‌کند.

**چرا ممکن است شی پس از فعال‌سازی اندازه‌اش تغییر کند؟**  
برنامه میزبان می‌تواند نمایش شی OLE را هنگام فعال‌سازی کتاب کار به‌روزرسانی کند. هر دو محدوده نمایش OLE کتاب کار و ابعاد چارچوب اسلاید مهم هستند. ببینید [راه‌حل عملی برای تغییر اندازه نمودار در PPTX](/slides/fa/cpp/working-solution-for-chart-resizing-in-pptx/).

## **بخش‌های مرتبط**

- [راه‌حل عملی برای تغییر اندازه نمودار در PPTX](/slides/fa/cpp/working-solution-for-chart-resizing-in-pptx/)
- [مشکل پیش‌نمایش شی هنگام افزودن OleObjectFrame](/slides/fa/cpp/object-preview-issue-when-adding-oleobjectframe/)