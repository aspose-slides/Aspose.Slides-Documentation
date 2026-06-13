---
title: ایجاد نمودارهای Excel و جاسازی آنها به عنوان اشیاء OLE در ارائه‌ها
type: docs
weight: 40
url: /fa/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- نمودار Excel
- جاسازی نمودار
- شیء OLE
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "ایجاد نمودارهای Excel و جاسازی آنها به عنوان اشیاء OLE در ارائه‌های PowerPoint و OpenDocument با C++. راهنمای گام به گام همراه با نمونه‌های کد."
---
## **پیش‌زمینه**

در PowerPoint، استفاده از نمودارهای قابل ویرایش برای نمایش گرافیکی داده‌ها یک روش رایج است. Aspose از ایجاد نمودارهای Excel با Aspose.Cells for C++ پشتیبانی می‌کند و این نمودارها می‌توانند به عنوان اشیاء OLE در اسلایدهای PowerPoint از طریق Aspose.Slides for C++ جاسازی شوند. این مقاله مراحل لازم را شرح می‌دهد و نمونه‌های کد C++ برای ایجاد یک نمودار Excel و جاسازی آن به عنوان شیء OLE در یک ارائه PowerPoint با استفاده از Aspose.Cells و Aspose.Slides ارائه می‌کند.

## **مراحل مورد نیاز**

دنبالهٔ زیر برای ایجاد و جاسازی یک نمودار Excel به عنوان شیء OLE در یک اسلاید PowerPoint لازم است:

1. ایجاد یک نمودار Excel با استفاده از Aspose.Cells.
1. تنظیم اندازهٔ OLE نمودار Excel با استفاده از Aspose.Cells.
1. دریافت تصویر نمودار Excel با Aspose.Cells.
1. جاسازی نمودار Excel به عنوان شیء OLE در ارائه PPTX با استفاده از Aspose.Slides.
1. جایگزینی تصویر «EMBEDDED OLE OBJECT» با تصویری که در گام 3 به دست آمده است تا مشکل[مشکل پیش‌نمایش شیء](/slides/fa/cpp/object-preview-issue-when-adding-oleobjectframe/) رفع شود.
1. ذخیرهٔ ارائه در دیسک با فرمت PPTX.

## **پیاده‌سازی مراحل مورد نیاز**

پیاده‌سازی C++ مراحل فوق به صورت زیر است:

```cpp
// مرحله - 1: ایجاد نمودار Excel با استفاده از Aspose.Cells.
// ---------------------------------------------------
// ایجاد یک کتاب کار.
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// افزودن یک نمودار Excel.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// مرحله - 2: تنظیم اندازه OLE نمودار با استفاده از Aspose.Cells.
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// مرحله - 3: دریافت تصویر نمودار با Aspose.Cells.
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// ذخیره کتاب کار در یک جریان.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// مرحله - 4 و 5
// ==============
 // مرحله - 4: جاسازی نمودار به عنوان شیء OLE داخل یک ارائه .ppt با استفاده از Aspose.Slides.
// ------------------------------------------------------------------------------------------
// مرحله - 5: جایگزینی تصویر "EMBEDDED OLE OBJECT" با تصویری که در گام 3 به دست آمده است تا مشکل پیش‌نمایش شیء را برطرف کند.
// --------------------------------------------------------------------------------------------------------------------
 // ایجاد یک ارائه.
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
 // افزودن کتاب کار به اسلاید.
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// مرحله - 6: ذخیره ارائه خروجی در دیسک.
// -----------------------------------------------
presentation->Save(u"OutputChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

```cpp
void AddExcelChartInPresentation(System::SharedPtr<Presentation> presentation, System::SharedPtr<ISlide> slide, 
                                 System::SharedPtr<System::IO::Stream> workbookStream, 
                                 intrusive_ptr<Aspose::Cells::Systems::Drawing::Bitmap> chartImage)
{
    float oleWidth = presentation->get_SlideSize()->get_Size().get_Width();
    float oleHeight = presentation->get_SlideSize()->get_Size().get_Height();
    int32_t x = 0;
    System::ArrayPtr<uint8_t> oleData = System::MakeArray<uint8_t>(workbookStream->get_Length(), 0);
    workbookStream->set_Position(0);
    workbookStream->Read(oleData, 0, oleData->get_Length());

    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(oleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oleFrame;
    oleFrame = slide->get_Shapes()->AddOleObjectFrame(static_cast<float>(x), 0.0f, oleWidth, oleHeight, dataInfo);

    intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
    chartImage->Save(cellsOutputStream, Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetBmp());

    auto slidesImage = Images::FromStream(ToSlidesMemoryStream(cellsOutputStream));
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(slidesImage));
}
```

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
int32_t AddExcelChartInWorkbook(intrusive_ptr<Aspose::Cells::IWorkbook> workbook, int32_t chartRows, int32_t chartCols)
{
    // یک آرایه از نام‌های سلول.
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // یک آرایه از داده‌های سلول.
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // اضافه کردن یک برگه کاری جدید برای پر کردن سلول‌ها با داده.
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // پر کردن برگه داده با داده‌ها.
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // اضافه کردن یک برگه نمودار.
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // اضافه کردن یک نمودار به برگه نمودار با سری داده‌ها از برگه داده.
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // تنظیم برگه نمودار به عنوان برگه فعال.
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

ارائه‌ای که با روش فوق ایجاد می‌شود شامل نمودار Excel به عنوان شیء OLE است که می‌تواند با دوبار کلیک بر روی قاب شیء OLE فعال شود.

## **نتیجه‌گیری**

با استفاده از Aspose.Cells for C++ همراه با Aspose.Slides for C++ می‌توان هر نمودار Excel پشتیبانی‌شده توسط Aspose.Cells را ایجاد و نمودار را به عنوان شیء OLE در اسلاید PowerPoint جاسازی کرد. اندازهٔ OLE نمودار Excel نیز می‌تواند تعریف شود. کاربران نهایی سپس می‌توانند نمودار Excel را همانند هر شیء OLE دیگری ویرایش کنند.

## **بخش‌های مرتبط**

- [راه‌حل عملی برای تغییر اندازهٔ نمودار در PPTX](/slides/fa/cpp/working-solution-for-chart-resizing-in-pptx/)
- [مشکل پیش‌نمایش شیء هنگام افزودن OleObjectFrame](/slides/fa/cpp/object-preview-issue-when-adding-oleobjectframe/)