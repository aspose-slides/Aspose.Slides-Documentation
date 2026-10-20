---
title: راه‌حل عملی برای تغییر اندازه کاربرگ
type: docs
weight: 130
url: /fa/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- تصویر پیش‌نمایش
- تغییر اندازه تصویر
- Excel
- کاربرگ
- PowerPoint
- ارائه
- C++
- Aspose.Slides برای C++
description: "راه‌حل عملی برای تغییر اندازه کاربرگ در ارائه‌های PowerPoint با استفاده از C++"
---
{{% alert color="info" title="Note" %}}
ورق‌های Excel که به‌عنوان اشیای OLE در یک ارائه PowerPoint با استفاده از اجزای Aspose جاسازی می‌شوند، ممکن است پس از اولین فعال‌سازی به‌طور غیرمنتظره‌ای اندازه خود را تغییر دهند. این رفتار اختلاف بصری واضحی بین شی OLE قبل و بعد از فعال‌سازی ایجاد می‌کند. این مقاله به توضیح مشکل می‌پردازد و دو روش برای رفع آن توصیف می‌کند.
{{% /alert %}}

## **پس‌زمینه**
در مقاله [Manage OLE](/slides/fa/cpp/manage-ole/)، نحوه افزودن یک فریم OLE به یک ارائه PowerPoint با استفاده از Aspose.Slides for C++ را توضیح دادیم. برای رفع [object preview issue](/slides/fa/cpp/object-preview-issue-when-adding-oleobjectframe/)، یک تصویر از ناحیه انتخاب‌شده کاربرگ را به فریم شی OLE اختصاص دادیم. در ارائه خروجی، وقتی بر روی فریم شی OLE که تصویر کاربرگ را نشان می‌دهد دوبار کلیک کنید، کتاب‌کار Excel فعال می‌شود. کاربران نهایی می‌توانند هر تغییر دلخواهی را در کتاب‌کار واقعی اعمال کرده و سپس با کلیک کردن خارج از کتاب‌کار فعال‌شده به اسلاید بازگردند. اندازه فریم شی OLE هنگام بازگشت کاربر به اسلاید تغییر می‌کند. عامل تغییر اندازه بسته به اندازه فریم شی OLE و کتاب‌کار Excel جاسازی‌شده متفاوت خواهد بود.

## **دلیل تغییر اندازه**
از آنجا که کتاب‌کار Excel دارای اندازه پنجره جداگانه‌ای است، سعی می‌کند پس از اولین فعال‌سازی اندازه اصلی خود را حفظ کند. از سوی دیگر فریم شی OLE دارای اندازه خود است. مطابق گفته مایکروسافت، وقتی کتاب‌کار Excel فعال می‌شود، Excel و PowerPoint برای اطمینان از حفظ نسبت‌های صحیح، اندازه را مذاکره می‌کنند؛ این فرایند بخشی از فرآیند جاسازی است. تغییر اندازه بر پایه تفاوت بین اندازه پنجره Excel و اندازه و موقعیت فریم شی OLE انجام می‌شود.

## **راه‌حل عملی**
دو راه‌حل ممکن برای جلوگیری از اثر تغییر اندازه وجود دارد.

- مقیاس‌بندی فریم OLE در ارائه PowerPoint به‌گونه‌ای که با کل ارتفاع و عرض ردیف‌ها و ستون‌های انتخاب‌شده مطابقت داشته باشد.
- ثابت نگه داشتن اندازه فریم OLE و مقیاس‌بندی ردیف‌ها و ستون‌های انتخاب‌شده برای جا شدن در آن.

### **مقیاس‌گذاری اندازه فریم OLE**
این رویکرد اندازه فریم OLE را طوری تنظیم می‌کند که با کل ارتفاع و عرض ردیف‌ها و ستون‌های انتخاب‌شده در کاربرگ Excel جاسازی‌شده مطابقت داشته باشد.

مثال یک کتاب‌کار Excel موجود را بارگذاری می‌کند و اولین ۱۰ ردیف و ۱۳ ستون از اولین کاربرگ آن را با استفاده از اندیس‌های صفر-پایه انتخاب می‌کند. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) محدوده نمایش داده‌شده را تعریف می‌کند. پیش‌نمایش با ۹۶ DPI رندر می‌شود و ابعاد پیکسل آن با استفاده از ۷۲ پوینت در اینچ به پوینت تبدیل می‌شود. [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) کتاب‌کار تغییر یافته را در یک فریم با این ابعاد جاسازی می‌کند. پیش‌نمایش از طریق [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) برای جایگزینی متن نگهدارنده «EMBEDDED OLE OBJECT» در ارائه ذخیره‌شده اختصاص داده می‌شود.

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

// اندازه نمایش داده‌شده را زمانی که فایل کاربرگ به‌عنوان شی OLE در PowerPoint استفاده می‌شود تنظیم کنید.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// عرض و ارتفاع تصویر OLE را بر حسب پوینت دریافت کنید.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// ما باید از کاربرگ اصلاح‌شده استفاده کنیم.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// تصویر OLE را به منابع ارائه اضافه کنید.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// فریم شی OLE را ایجاد کنید.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

کمک‌کننده پیش‌نمایش از [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) برای انتخاب محدوده استفاده می‌کند و حاشیه‌ها، سرصفحه‌ها و پاصفحه‌ها را حذف می‌نماید. با فعال‌سازی [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/)، [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) محدوده را به‌صورت تصویر PNG رندر می‌کند. این کمک‌کننده داده‌های تصویر رندر شده را در یک جریان حافظه جدید که در ابتدای آن موقعیت‌گذاری شده است، کپی می‌کند تا در ارائه استفاده شود.

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

### **مقیاس‌گذاری اندازه بازه سلول**
این رویکرد ارتفاع ردیف‌های انتخاب‌شده و عرض ستون‌های انتخاب‌شده را طوری مقیاس می‌بندد که با یک فریم OLE سفارشی مطابقت داشته باشد.

مثال یک کتاب‌کار Excel موجود را بارگذاری می‌کند و اولین ۱۰ ردیف و ۱۳ ستون از اولین کاربرگ آن را با استفاده از اندیس‌های صفر-پایه انتخاب می‌کند. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) محدوده نمایش داده‌شده را تعریف می‌کند و کمک‌کننده زیر آن محدوده را برای جا شدن در فریمی به عرض ۴۰۰ پوینت و ارتفاع ۱۰۰ پوینت مقیاس می‌بندد. پس از ذخیره کتاب‌کار اصلاح‌شده به‌صورت آرایه بایت، [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) آن را با اندازه مشخص شده جاسازی می‌کند. یک پیش‌نمایش رندر‌شده با ۹۶ DPI از طریق [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) اختصاص داده می‌شود، بنابراین ارائه ذخیره‌شده به‌جای متن نگهدارنده پیش‌فرض، سلول‌های انتخاب‌شده را نشان می‌دهد.

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

// اندازه نمایش داده‌شده را زمانی که فایل کاربرگ به عنوان شی OLE در PowerPoint استفاده می‌شود تنظیم کنید.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// محدوده سلول‌ها را برای متناسب شدن با اندازه فریم مقیاس‌بندی کنید.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// ما باید از کاربرگ اصلاح‌شده استفاده کنیم.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// تصویر OLE را به منابع ارائه اضافه کنید.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// فریم شی OLE را ایجاد کنید.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

کمک‌کننده مقیاس‌گذاری نسبت‌های عرض و ارتفاع جداگانه برای محدوده انتخاب‌شده محاسبه می‌کند، عرض نسبی ستون‌ها و ارتفاع نسبی ردیف‌ها را حفظ می‌نماید. ابعاد محاسبه‌شده را از پوینت به اینچ تبدیل می‌کند و سپس با [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) و [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/) اعمال می‌کند. محدوده انتخاب‌شده باید عرض و ارتفاع غیرصفر داشته باشد.

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">عرض مورد انتظار بازه سلول‌ها بر حسب پوینت.</param>
/// <param name="height">ارتفاع مورد انتظار بازه سلول‌ها بر حسب پوینت.</param>
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

این کمک‌کننده پیش‌نمایش بازه مقیاس‌گذاری‌شده را با استفاده از [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) رندر می‌کند. از [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) برای محدود کردن چاپ به آن بازه استفاده می‌کند، حاشیه‌ها، سرصفحه‌ها و پاصفحه‌ها را حذف می‌کند و یک جریان PNG که در ابتدای آن موقعیت‌گذاری شده است را برمی‌گرداند.

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
{{% alert color="info" title="Note" %}}
دو رویکرد برای رفع مشکل تغییر اندازه کاربرگ وجود دارد. رویکردی را که بیشترین مطابقت را با نیازها و مورد استفاده شما دارد انتخاب کنید. هر دو رویکرد به‌یک شکل عمل می‌کنند، چه ارائه‌ها از یک الگو ساخته شوند و چه از صفر. علاوه بر این، هیچ محدودیتی برای اندازه فریم شی OLE در این راه‌حل وجود ندارد.
{{% /alert %}}

## **سوالات متداول**
**چرا یک کاربرگ Excel جاسازی‌شده هنگام اولین فعال‌سازی در PowerPoint اندازه‌اش تغییر می‌کند؟**  
این به این دلیل است که Excel سعی می‌کند اندازه اصلی پنجره خود را هنگام فعال‌سازی حفظ کند، در حالی که فریم شی OLE در PowerPoint دارای ابعاد خاص خود است. PowerPoint و Excel برای حفظ نسبت طول و عرض مذاکره می‌کنند که می‌تواند منجر به تغییر اندازه شود.

**آیا می‌توان این مشکل تغییر اندازه را به‌طور کامل جلوگیری کرد؟**  
بله. با مقیاس‌بندی فریم OLE به‌گونه‌ای که با اندازه بازه سلولی Excel مطابقت داشته باشد یا مقیاس‌بندی بازه سلول به‌گونه‌ای که با اندازه دلخواه فریم OLE جا شود، می‌توانید از تغییر اندازه ناخواسته جلوگیری کنید.

**کدام روش مقیاس‌بندی را باید انتخاب کنم، مقیاس‌بندی فریم OLE یا مقیاس‌بندی بازه سلولی؟**  
اگر می‌خواهید اندازه‌های اصلی ردیف و ستون‌های Excel را حفظ کنید، **مقیاس‌بندی فریم OLE** را انتخاب کنید. اگر به دنبال اندازه ثابت برای فریم OLE در ارائه خود هستید، **مقیاس‌بندی بازه سلولی** را انتخاب کنید.

**آیا این راه‌حل‌ها در صورتی که ارائه من براساس یک الگو باشد کار می‌کنند؟**  
بله. هر دو راه‌حل برای ارائه‌های ایجادشده از الگوها و همچنین از صفر کار می‌کنند.

**آیا محدودیتی برای اندازه فریم OLE هنگام استفاده از این روش‌ها وجود دارد؟**  
نه. می‌توانید فریم شی OLE را به هر اندازه‌ای تنظیم کنید، به‌شرط آنکه مقیاس‌بندی را به‌درستی انجام دهید.

**آیا راهی برای حذف متن نگهدارنده «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟**  
بله. با گرفتن یک اسنپ‌شات از بازه سلولی هدف Excel و تنظیم آن به‌عنوان تصویر نگهدارنده فریم OLE، می‌توانید یک تصویر پیش‌نمایش سفارشی به‌جای متن پیش‌فرض نمایش دهید.

## **مقالات مرتبط**
[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/fa/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)