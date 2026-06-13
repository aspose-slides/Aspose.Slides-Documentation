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
- Aspose.Slides for C++
description: "راه‌حل عملی برای تغییر اندازه کاربرگ در ارائه‌های PowerPoint با استفاده از C++"
---
{{% alert color="primary" %}}

مشاهده شده است که کاربرگ‌های Excel که به‌عنوان اشیاء OLE در یک ارائه PowerPoint از طریق مؤلفه‌های Aspose جاسازی می‌شوند، پس از اولین فعال‌سازی به مقیاسی نامشخص تغییر اندازه می‌دهند. این رفتار اختلاف بصری قابل توجهی بین وضعیت پیش و پس از فعال‌سازی شی OLE در ارائه ایجاد می‌کند. ما این موضوع را به‑تفصیل بررسی کرده و راه‌حلی ارائه دادیم که در این مقاله پوشش داده شده است.

{{% /alert %}}

## **پیش‌زمینه**

در مقاله [Manage OLE](/slides/fa/cpp/manage-ole/) توضیح دادیم چگونه یک فریم OLE را به یک ارائه PowerPoint با استفاده از Aspose.Slides for C++ اضافه کنیم. برای رفع [مشکل پیش‌نمایش شی](/slides/fa/cpp/object-preview-issue-when-adding-oleobjectframe/) تصویری از ناحیه انتخاب‌شده کاربرگ را به فریم شی OLE اختصاص دادیم. در ارائه خروجی، هنگامی که فریم شی OLE که تصویر کاربرگ را نمایش می‌دهد دو بار کلیک می‌شود، کتاب‌کار Excel فعال می‌شود. کاربران می‌توانند تغییرات دلخواه را در کتاب‌کار واقعی Excel اعمال کنند و سپس با کلیک خارج از کتاب‌کار فعال‌شده به اسلاید بازگردند. اندازه فریم شی OLE هنگام بازگشت کاربر به اسلاید تغییر خواهد کرد. عامل تغییر اندازه بسته به اندازه فریم شی OLE و کتاب‌کار Excel جاسازی‌شده متفاوت است.

## **دلیل تغییر اندازه**

از آنجا که کتاب‌کار Excel دارای اندازه پنجره خاص خود است، سعی می‌کند هنگام اولین فعال‌سازی اندازه اولیه خود را حفظ کند. از سوی دیگر، فریم شی OLE دارای اندازه خاص خود است. بر اساس گفته مایکروسافت، وقتی کتاب‌کار Excel فعال می‌شود، Excel و PowerPoint برای اطمینان از حفظ نسبت‌های صحیح در طی فرایند جاسازی، درباره اندازه مذاکره می‌کنند. تغییر اندازه بر پایه تفاوت‌های بین اندازه پنجره Excel و اندازه و موقعیت فریم شی OLE انجام می‌شود.

## **راه‌حل عملی**

دو راه‌حل ممکن برای جلوگیری از تأثیر تغییر اندازه وجود دارد.

- مقیاس‌گذاری اندازه فریم OLE در ارائه PowerPoint برای انطباق با ارتفاع و عرض تعداد دلخواه ردیف‌ها و ستون‌ها در فریم OLE.
- ثابت نگه داشتن اندازه فریم OLE و مقیاس‌گذاری اندازه ردیف‌ها و ستون‌های مشارکت‌کننده برای متناسب شدن با اندازه فریم OLE انتخاب‌شده.

### **مقیاس‌گذاری اندازه فریم OLE**

در این روش، نحوه تنظیم اندازه فریم OLE کتاب‌کار Excel جاسازی‌شده برای مطابقت با اندازه تجمعی ردیف‌ها و ستون‌های مشارکتی در کاربرگ Excel را می‌آموزیم.

فرض کنید یک شیت الگو Excel داریم و می‌خواهیم آن را به عنوان فریم OLE به یک ارائه اضافه کنیم. در این سناریو، ابتدا اندازه فریم شی OLE بر پایه مجموع ارتفاع ردیف‌ها و عرض ستون‌های مشارکتی در کتاب‌کار محاسبه می‌شود. سپس اندازه فریم OLE را به این مقدار محاسبه‌شده تنظیم می‌کنیم. برای جلوگیری از پیام قرمز «EMBEDDED OLE OBJECT» برای فریم OLE در PowerPoint، همچنین تصویری از نواحی مورد نظر ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و آن را به عنوان تصویر فریم OLE تنظیم می‌کنیم.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// تنظیم اندازه نمایش هنگام استفاده از فایل کتاب کار به عنوان شی OLE در PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// دریافت عرض و ارتفاع تصویر OLE به واحد نقطه.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// ما نیاز داریم که از کتاب کار تغییر یافته استفاده کنیم.
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

### **مقیاس‌گذاری اندازه بازه سلول‌ها**

در این روش، نحوه مقیاس‌گذاری ارتفاع ردیف‌های مشارکتی و عرض ستون‌های مشارکتی برای مطابقت با یک اندازه سفارشی فریم OLE را می‌آموزیم.

فرض کنید یک شیت الگو Excel داریم و می‌خواهیم آن را به عنوان فریم OLE به یک ارائه اضافه کنیم. در این سناریو، اندازه فریم OLE را تنظیم می‌کنیم و اندازه ردیف‌ها و ستون‌هایی که در ناحیه فریم OLE مشارکت دارند، مقیاس می‌دهیم. سپس کتاب‌کار را به یک استریم ذخیره می‌کنیم تا تغییرات اعمال شوند و آن را به آرایه بایت تبدیل می‌کنیم تا به فریم OLE اضافه شود. برای جلوگیری از پیام قرمز «EMBEDDED OLE OBJECT» برای فریم OLE در PowerPoint، همچنین تصویری از نواحی مورد نظر ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و آن را به عنوان تصویر فریم OLE تنظیم می‌کنیم.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// تنظیم اندازه نمایش هنگام استفاده از فایل کتاب‌کار به‌عنوان شی OLE در PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// مقیاس‌گذاری بازه سلول‌ها برای متناسب شدن با اندازه فریم.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// ما نیاز داریم که از کتاب‌کار تغییر یافته استفاده کنیم.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// افزودن تصویر OLE به منابع ارائه.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
/// <param name="width">عرض مورد انتظار بازه سلول‌ها به واحد نقطه.</param>
/// <param name="height">ارتفاع مورد انتظار بازه سلول‌ها به واحد نقطه.</param>
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

{{% alert color="primary" %}}

دو روش برای رفع مشکل تغییر اندازه کاربرگ وجود دارد. انتخاب روش مناسب بستگی به الزامات خاص و مورد استفاده دارد. هر دو روش به‌طور یکسان عمل می‌کنند، چه ارائه‌ها از یک الگو ساخته شوند و چه از ابتدا. علاوه بر این، در این راه‌حل محدودیتی برای اندازه فریم شی OLE وجود ندارد.

{{% /alert %}}

## **سوالات متداول**

**چرا یک کاربرگ Excel جاسازی‌شده هنگام اولین فعال‌سازی در PowerPoint اندازه‌اش تغییر می‌کند؟**

این به این دلیل است که Excel سعی می‌کند اندازه اولیه پنجره خود را حفظ کند، در حالی که فریم شی OLE در PowerPoint ابعاد خاص خود را دارد. PowerPoint و Excel درباره اندازه مذاکره می‌کنند تا نسبت‌ها حفظ شوند، که می‌تواند منجر به تغییر اندازه شود.

**آیا می‌توان این مشکل تغییر اندازه را به‌طور کامل جلوگیری کرد؟**

بله. با مقیاس‌گذاری فریم OLE برای متناسب شدن با اندازه بازه سلول‌های Excel یا مقیاس‌گذاری بازه سلول‌ها برای متناسب شدن با اندازه دلخواه فریم OLE، می‌توانید از تغییر اندازه ناخواسته جلوگیری کنید.

**کدام روش مقیاس‌گذاری را باید انتخاب کنم، مقیاس‌گذاری فریم OLE یا مقیاس‌گذاری بازه سلول‌ها؟**

اگر می‌خواهید اندازه ردیف و ستون‌های اصلی Excel را حفظ کنید، **مقیاس‌گذاری فریم OLE** را انتخاب کنید. اگر می‌خواهید اندازه ثابت برای فریم OLE در ارائه داشته باشید، **مقیاس‌گذاری بازه سلول‌ها** را انتخاب کنید.

**آیا این راه‌حل‌ها در صورتی که ارائه من براساس یک الگو باشد کار می‌کند؟**

بله. هر دو راه‌حل برای ارائه‌های ساخته‌شده از الگوها و همچنین از ابتدا کار می‌کنند.

**آیا محدودیتی برای اندازه فریم OLE هنگام استفاده از این روش‌ها وجود دارد؟**

خیر. می‌توانید فریم شی OLE را به هر اندازه‌ای تنظیم کنید، به‌شرط این‌که مقیاس را به‌درستی تنظیم کنید.

**آیا راهی برای حذف متن جایگزین «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟**

بله. با گرفتن یک تصویر از بازه سلول هدف Excel و تنظیم آن به‌عنوان تصویر جایگزین فریم OLE، می‌توانید تصویر پیش‌نمایش سفارشی را به‌جای متن پیش‌فرض نمایش دهید.

## **مقالات مرتبط**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/fa/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)