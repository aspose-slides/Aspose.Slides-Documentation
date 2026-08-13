---
title: "راه‌حل عملی برای تغییر اندازه برگه کاری"
type: docs
weight: 130
url: /fa/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- "تصویر پیش‌نمایش"
- "تغییر اندازه تصویر"
- Excel
- "برگه کاری"
- PowerPoint
- "ارائه"
- C++
- "Aspose.Slides برای C++"
description: "راه‌حل عملی برای تغییر اندازه برگه کاری در ارائه‌های PowerPoint با استفاده از C++"
---
{{% alert color="info" %}}

مشاهده شده است که برگه‌های Excel که به‌عنوان اشیای OLE در یک ارائه PowerPoint از طریق اجزای Aspose جاسازی می‌شوند، پس از اولین فعال‌سازی به مقیاسی نامشخص تغییر اندازه می‌دهند. این رفتار باعث تفاوت بصری واضحی بین حالت پیش از فعال‌سازی و پس از فعال‌سازی شی OLE در ارائه می‌شود. ما این مشکل را به‌ طور جزئی بررسی کرده و راه‌حلی ارائه داده‌ایم که در این مقاله پوشش داده شده است.

{{% /alert %}}

## **پیش‌زمینه**

در مقاله [مدیریت OLE](/slides/fa/cpp/manage-ole/)، توضیح دادیم چگونه یک فریم OLE را به یک ارائه PowerPoint با استفاده از Aspose.Slides for C++ اضافه کنیم. برای رفع [مسئله پیش‌نمایش شی](/slides/fa/cpp/object-preview-issue-when-adding-oleobjectframe/)، تصویری از ناحیه برگه انتخاب‌شده را به فریم شی OLE اختصاص دادیم. در ارائه خروجی، هنگامی که بر روی فریم شی OLE که تصویر برگه را نمایش می‌دهد دوبار کلیک می‌کنید، کتاب‌کار Excel فعال می‌شود. کاربران نهایی می‌توانند تغییرات دلخواه خود را در کتاب‌کار واقعی انجام دهند و سپس با کلیک خارج از کتاب‌کار فعال‌شده به اسلاید بازگردند. اندازه فریم شی OLE هنگام بازگشت کاربر به اسلاید تغییر خواهد کرد. ضریب تغییر اندازه بسته به اندازه فریم شی OLE و کتاب‌کار Excel جاسازی‌شده متفاوت است.

## **دلیل تغییر اندازه**

از آنجا که کتاب‌کار Excel اندازه پنجره خاص خود را دارد، سعی می‌کند هنگام اولین فعال‌سازی اندازه اصلی خود را حفظ کند. از سوی دیگر، فریم شی OLE نیز اندازه خاص خود را دارد. طبق گفته مایکروسافت، هنگام فعال‌سازی کتاب‌کار Excel، Excel و PowerPoint برای اطمینان از حفظ نسبت‌های صحیح در فرآیند جاسازی، اندازه را مذاکره می‌کنند. تغییر اندازه بر اساس تفاوت بین اندازه پنجره Excel و اندازه و موقعیت فریم شی OLE رخ می‌دهد.

## **راه‌حل عملی**

دو راه‌حل ممکن برای جلوگیری از اثر تغییر اندازه وجود دارد.

- مقیاس‌بندی اندازه فریم OLE در ارائه PowerPoint به‌طوری که با ارتفاع و عرض تعداد ردیف‌ها و ستون‌های موردنظر در فریم OLE مطابقت داشته باشد.
- ثابت نگه داشتن اندازه فریم OLE و مقیاس‌بندی اندازه ردیف‌ها و ستون‌های مشارکت‌کننده تا در چارچوب اندازه فریم OLE انتخاب‌شده جای بگیرند.

### **مقیاس‌بندی اندازه فریم OLE**

در این روش، می‌آموزیم چگونه اندازه فریم OLE کتاب‌کار Excel جاسازی‌شده را طوری تنظیم کنیم که مطابق با اندازه تجمعی ردیف‌ها و ستون‌های مشارکت‌کننده در برگه Excel باشد.

فرض کنید یک شیت الگو Excel داریم و می‌خواهیم آن را به‌عنوان فریم OLE به یک ارائه اضافه کنیم. در این حالت، ابتدا اندازه فریم شی OLE بر اساس مجموع ارتفاع ردیف‌ها و عرض ستون‌های مشارکت‌کننده در کتاب‌کار محاسبه می‌شود. سپس اندازه فریم OLE را به این مقدار محاسبه‌شده تنظیم می‌کنیم. برای رفع پیام قرمز «EMBEDDED OLE OBJECT» برای فریم OLE در PowerPoint، تصویری از بخش‌های موردنظر ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و به‌عنوان تصویر فریم OLE تنظیم می‌کنیم.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// تنظیم اندازه نمایش هنگام استفاده از فایل کتاب‌کار به‌عنوان شی OLE در PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// دریافت عرض و ارتفاع تصویر OLE به واحد پوینت.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// ما نیاز داریم از کتاب‌کار اصلاح‌شده استفاده کنیم.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// افزودن تصویر OLE به منابع ارائه.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// ایجاد فریم شی OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"
using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **مقیاس‌بندی اندازه محدوده سلولی**

در این روش، می‌آموزیم چگونه ارتفاع ردیف‌های مشارکت‌کننده و عرض ستون‌های مشارکت‌کننده را طوری مقیاس‌بندی کنیم که با یک اندازه سفارشی فریم OLE منطبق شوند.

فرض کنید یک شیت الگو Excel داریم و می‌خواهیم آن را به‌عنوان فریم OLE به یک ارائه اضافه کنیم. در این حالت، اندازه فریم OLE را تنظیم می‌کنیم و اندازه ردیف‌ها و ستون‌های مشارکت‌کننده در ناحیه فریم OLE را مقیاس‌بندی می‌کنیم. سپس کتاب‌کار را به یک جریان ذخیره می‌کنیم تا تغییرات اعمال شوند و آن را به آرایه بایت تبدیل می‌کنیم تا به فریم OLE اضافه شود. برای رفع پیام قرمز «EMBEDDED OLE OBJECT» برای فریم OLE در PowerPoint، تصویری از بخش‌های موردنظر ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و به‌عنوان تصویر فریم OLE تنظیم می‌کنیم.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// تنظیم اندازه نمایش زمانی که فایل کتاب‌کار به‌عنوان شی OLE در PowerPoint استفاده می‌شود.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// مقیاس‌بندی محدوده سلولی برای تطبیق با اندازه فریم.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// ما باید از کتاب‌کار اصلاح‌شده استفاده کنیم.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// افزودن تصویر OLE به منابع ارائه.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// ایجاد فریم شی OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">عرض مورد انتظار محدوده سلولی بر حسب پوینت.</param>
/// <param name="height">ارتفاع مورد انتظار محدوده سلولی بر حسب پوینت.</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"
using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **نتیجه‌گیری**

{{% alert color="info" %}}

دو رویکرد برای رفع مشکل تغییر اندازه برگه وجود دارد. انتخاب رویکرد مناسب بستگی به نیازها و موارد استفاده خاص دارد. هر دو رویکرد به‌طور یکسان کار می‌کنند، چه ارائه‌ها از یک الگو ساخته شوند و چه از صفر. علاوه بر این، در این راه‌حل هیچ محدودیتی برای اندازه فریم شی OLE وجود ندارد.

{{% /alert %}}

## **سؤالات متداول**

### چرا یک برگه Excel جاسازی‌شده هنگام اولین فعال‌سازی در PowerPoint اندازه‌اش تغییر می‌کند؟

این به این دلیل است که Excel سعی می‌کند اندازهٔ اصلی پنجرهٔ خود را هنگام فعال‌سازی حفظ کند، در حالی که فریم شی OLE در PowerPoint ابعاد جداگانه‌ای دارد. PowerPoint و Excel برای حفظ نسبت ابعاد، اندازه را مذاکره می‌کنند که می‌تواند منجر به تغییر اندازه شود.

### آیا می‌توان این مشکل تغییر اندازه را به‌ طور کامل جلوگیری کرد؟

بله. با مقیاس‌بندی فریم OLE به‌طوری که با اندازه محدوده سلولی Excel منطبق شود یا مقیاس‌بندی محدوده سلولی به‌طوری که با اندازه دلخواه فریم OLE سازگار شود، می‌توانید از تغییر اندازه ناخواسته جلوگیری کنید.

### کدام روش مقیاس‌بندی را باید انتخاب کنم، مقیاس‌بندی فریم OLE یا مقیاس‌بندی محدوده سلولی؟

اگر می‌خواهید اندازهٔ ردیف‌ها و ستون‌های اصلی Excel حفظ شود، **مقیاس‌بندی فریم OLE** را انتخاب کنید. اگر نیاز به یک اندازه ثابت برای فریم OLE در ارائه دارید، **مقیاس‌بندی محدوده سلولی** را انتخاب کنید.

### آیا این راه‌حل‌ها در صورتی که ارائه من بر پایه یک الگو باشد کار می‌کنند؟

بله. هر دو راه‌حل برای ارائه‌های ساخته‌شده از الگوها و همچنین از صفر کار می‌کنند.

### آیا محدودیتی برای اندازه فریم OLE هنگام استفاده از این روش‌ها وجود دارد؟

خیر. می‌توانید فریم شی OLE را به هر اندازه‌ای تنظیم کنید، به شرط آنکه مقیاس را به‌درستی تنظیم کنید.

### آیا راهی برای اجتناب از متن جای‌گیر «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟

بله. با گرفتن اسنپ‌شات از محدوده سلولی هدف Excel و تنظیم آن به‌عنوان تصویر جای‌گیر فریم OLE، می‌توانید یک تصویر پیش‌نمایش سفارشی به‌جای متن پیش‌فرض نمایش دهید.

## **مقالات مرتبط**

[ایجاد نمودار Excel و جاسازی آن در یک ارائه به‌عنوان شی OLE](/slides/fa/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)