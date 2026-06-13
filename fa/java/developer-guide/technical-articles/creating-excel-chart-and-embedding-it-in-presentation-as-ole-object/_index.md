---
title: ایجاد نمودارهای اکسل و جاسازی آن‌ها در ارائه‌ها به‌عنوان اشیای OLE
type: docs
weight: 30
url: /fa/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- نمودار اکسل
- جاسازی نمودار
- شی OLE
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "نمودارهای اکسل را ایجاد کنید و آن‌ها را به‌عنوان اشیای OLE در ارائه‌های پاورپوینت و OpenDocument با جاوا جاسازی کنید. راهنمای گام‌به‌گام با نمونه‌های کد."
---
## **پیش‌زمینه**

در پاورپوینت، استفاده از نمودارهای قابل ویرایش برای نمایش داده‌ها به صورت گرافیکی یک روش رایج است. Aspose امکان ایجاد نمودارهای اکسل با Aspose.Cells برای جاوا را فراهم می‌کند و این نمودارها می‌توانند به‌عنوان اشیای OLE در اسلایدهای پاورپوینت از طریق Aspose.Slides برای جاوا جاسازی شوند. این مقاله مراحل لازم را پوشش می‌دهد و نمونه‌های کد جاوا برای ایجاد یک نمودار اکسل و جاسازی آن به‌عنوان شی OLE در یک ارائه پاورپوینت با استفاده از Aspose.Cells و Aspose.Slides ارائه می‌دهد.

## **مراحل مورد نیاز**

دنباله مراحل زیر برای ایجاد و جاسازی یک نمودار اکسل به‌عنوان شی OLE در یک اسلاید پاورپوینت مورد نیاز است:

1. ایجاد یک نمودار اکسل با استفاده از Aspose.Cells.
1. تنظیم اندازه OLE نمودار اکسل با استفاده از Aspose.Cells.
1. دریافت تصویر نمودار اکسل با Aspose.Cells.
1. جاسازی نمودار اکسل به‌عنوان شی OLE در یک ارائه PPTX با استفاده از Aspose.Slides.
1. جایگزینی تصویر «EMBEDDED OLE OBJECT» با تصویری که در گام 3 بدست آمده است تا مشکل [مشکل پیش‌نمایش شی](/slides/fa/java/object-preview-issue-when-adding-oleobjectframe/) برطرف شود.
1. ذخیره ارائه در دیسک با فرمت PPTX.

## **پیاده‌سازی مراحل مورد نیاز**

پیاده‌سازی جاوا برای مراحل فوق به شکل زیر است:

```java
// یک کتاب‌کار ایجاد کنید.
Workbook workbook = new Workbook();

// یک نمودار اکسل اضافه کنید.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// اندازه OLE نمودار را تنظیم کنید.
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// تصویر نمودار را دریافت کنید و در یک جریان ذخیره کنید.
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// کتاب‌کار را در یک جریان ذخیره کنید.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// یک ارائه ایجاد کنید.
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// کتاب‌کار را به یک اسلاید اضافه کنید.
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// ارائه را بر روی دیسک ذخیره کنید.
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // یک شی LoadOptions از نوع EXCEL_97_TO_2003 ایجاد کنید.
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // آرایه‌ای از نام‌های سلول.
    String[] cellNames = new String[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // آرایه‌ای از داده‌های سلول.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // یک شیت جدید اضافه کنید تا سلول‌ها را با داده‌ها پر کنید.
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // شیت داده را با داده‌ها پر کنید.
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // یک شیت نمودار اضافه کنید.
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // یک نمودار به شیت نمودار اضافه کنید با سری داده‌ها از شیت داده.
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // شیت نمودار را به عنوان شیت فعال تنظیم کنید.
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

ارائه‌ای که توسط روش فوق ایجاد می‌شود، حاوی نمودار اکسل به‌عنوان شی OLE است که می‌تواند با دوبار کلیک روی فریم شی OLE فعال شود.

## **نتیجه‌گیری**

با استفاده از Aspose.Cells برای جاوا به همراه Aspose.Slides برای جاوا، می‌توان هر نمودار اکسیلی که توسط Aspose.Cells پشتیبانی می‌شود را ایجاد کرد و آن را به‌عنوان شی OLE در یک اسلاید پاورپوینت جاسازی نمود. همچنین می‌توان اندازه OLE نمودار اکسل را تعریف کرد. کاربران نهایی سپس می‌توانند نمودار اکسل را همانند هر شی OLE دیگری ویرایش کنند.

## **بخش‌های مرتبط**

- [راه‌حل کارآمد برای تغییر اندازه نمودار در PPTX](/slides/fa/java/working-solution-for-chart-resizing-in-pptx/)
- [مشکل پیش‌نمایش شی هنگام افزودن OleObjectFrame](/slides/fa/java/object-preview-issue-when-adding-oleobjectframe/)
- [به‌روزرسانی خودکار اشیای OLE با استفاده از افزودنی PowerPoint](/slides/fa/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)