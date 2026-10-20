---
title: ایجاد نمودارهای Excel و جاسازی آن‌ها در ارائه‌ها به عنوان اشیاء OLE
type: docs
weight: 30
url: /fa/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- نمودار Excel
- جاسازی نمودار
- شی OLE
- PowerPoint
- ارائه
- جاوا
- Aspose.Slides
description: "یک نمودار Excel را با Aspose.Cells برای Java ایجاد کنید و کتاب‌کار را در یک ارائه PowerPoint با Aspose.Slides جاسازی کنید، به‌همراه پیش‌نمایش نمودار."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه یک نمودار ستونی Excel را با Aspose.Cells برای Java ایجاد کنید و کتاب‌کار آن را در یک ارائه PowerPoint با Aspose.Slides برای Java جاسازی کنید. کتاب‌کار جاسازی‌شده شامل داده‌های منبع و نمودار است. یک پیش‌نمایش PNG جداگانه نمودار را بر روی اسلاید قبل از فعال‌سازی شی OLE نمایش می‌دهد.

نتیجه یک شیء Excel جاسازی‌شده است، نه یک نمودار بومی PowerPoint. ویرایش کتاب‌کار از طریق OLE به یک برنامه دسکتاپ که از فعال‌سازی OLE پشتیبانی می‌کند و نصب‌ای سازگار از Excel نیاز دارد.

## **پیش‌نیازها**

Aspose.Cells برای Java و Aspose.Slides برای Java را به وابستگی‌های پروژه خود اضافه کنید. مثال را داخل یک متد Java اجرا کنید. برای تولید ارائه با این کتابخانه‌ها نیازی به Microsoft Office نیست.

فایل ورودی نیاز نیست: مثال داده‌ها و نمودار را در حافظه ایجاد می‌کند، سپس `OutputChart.pptx` را در پوشه کاری فعلی می‌نویسد. هنگام اجرا خارج از حالت ارزیابی، مجوزهای هر دو محصول را اعمال کنید.

## **نحوه کار جاسازی**

1. یک کتاب‌کار با یک ورق داده و یک ورق نمودار ایجاد کنید.  
1. ورق نمودار را فعال کنید تا کتاب‌کار روی نمودار باز شود.  
1. بازه نمایش OLE کتاب‌کار را تنظیم کنید و نمودار را به PNG رندر کنید.  
1. کتاب‌کار را به شکل XLSX در حافظه ذخیره کنید و بایت‌های آن را در یک اسلاید جاسازی کنید.  
1. PNG را به عنوان پیش‌نمایش شی OLE اختصاص دهید و ارائه را به شکل PPTX ذخیره کنید.

بازه نمایش کتاب‌کار و قاب اسلاید نقش‌های متفاوتی دارند. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) اندیس‌های شروع/پایان ردیف و ستون را به صورت صفر‑محور می‌گیرد. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) به‌جای آن ردیف بالایی، ستون چپ، ردیف پایینی و ستون راست را می‌گیرد. مثال از اندیس ردیف 55 و اندیس ستون 25 به عنوان مرزهای پایین‑راست استفاده می‌کند؛ این مقادیر انتخاب‌های چیدمان هستند، نه تعداد ردیف یا ستون داده‌ها.

قاب اسلاید از واحد نقطه استفاده می‌کند. مثال آن را در داخل اسلاید قرار می‌دهد و در وسط می‌کند در حالی که نسبت تصویر PNG را حفظ می‌کند، نه اینکه پیش‌نمایش را برای پر کردن اسلاید کش دهد.

## **ایجاد و جاسازی نمودار**

مثال کامل زیر `DataSheet` را با چهار ردیف و پنج ستون مقادیر پر می‌کند. هر ردیف تبدیل به یک سری نمودار می‌شود. `ChartSheet` قبل از ذخیره کتاب‌کار به عنوان ورق فعال انتخاب می‌شود.

کتاب‌کار به‌صراحت به شکل XLSX ذخیره می‌شود، مطابقت با پسوند `xlsx` که به [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/) منتقل می‌شود. PNG مستقیماً از بایت‌های خود بدون تبدیل به bitmap میانی بارگذاری می‌شود. اختصاص آن از طریق [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) جایگزین پیش‌فرض OLE می‌شود.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;

try {
    Workbook workbook = new Workbook();
    try {
        Worksheet dataSheet = workbook.getWorksheets().get(0);
        dataSheet.setName("DataSheet");

        int[][] values = {
            { 67, 44, 46, 43, 24 },
            { 86, 64, 97, 29, 40 },
            { 68, 89, 78, 69, 38 },
            { 91, 48, 60, 26, 25 }
        };

        for (int row = 0; row < values.length; row++) {
            for (int column = 0; column < values[row].length; column++) {
                dataSheet.getCells().get(row, column).putValue(values[row][column]);
            }
        }

        int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
        Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
        chartSheet.setName("ChartSheet");

        int lastChartRow = 55;
        int lastChartColumn = 25;
        int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
        Chart chart = chartSheet.getCharts().get(chartIndex);
        for (int row = 1; row <= values.length; row++) {
            chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
        }

        workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
        workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

        // رندر پیش‌نمایش نمودار و سریال‌سازی کتاب‌کار قابل ویرایش به‌صورت جداگانه.
        ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
        imageOptions.setImageType(ImageType.PNG);
        ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
        chart.toImage(chartImageStream, imageOptions);
        byte[] chartImageBytes = chartImageStream.toByteArray();

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, XLSX);
        byte[] workbookBytes = workbookStream.toByteArray();

        IImage chartImage = Images.fromData(chartImageBytes);
        try {
            Presentation presentation = new Presentation();
            try {
                ISlide slide = presentation.getSlides().get_Item(0);
                double slideWidth = presentation.getSlideSize().getSize().getWidth();
                double slideHeight = presentation.getSlideSize().getSize().getHeight();

                // پیش‌نمایش را در اسلاید جا می‌گیرد بدون تغییر نسبت ابعاد.
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
            } finally {
                presentation.dispose();
            }
        } finally {
            chartImage.dispose();
        }
    } finally {
        workbook.dispose();
    }
} catch (Exception exception) {
    System.err.println("Could not create the presentation: " + exception.getMessage());
}
```

## **نتیجه انتظار**

`OutputChart.pptx` شامل یک اسلاید با یک کتاب‌کار Excel جاسازی‌شده و پیش‌نمایش نمودار است. کتاب‌کار شامل داده‌های اصلی و یک نمودار ستونی با چهار سری است. پیش‌نمایش در وسط اسلاید قرار دارد و نسبت‌های خود را حفظ می‌کند.

![نمودار ستونی Excel که به‌عنوان پیش‌نمایش یک کتاب‌کار جاسازی‌شده نمایش داده می‌شود](excel-chart-ole-preview.png)

در محیط دسکتاپ PowerPoint سازگار که Excel نیز در دسترس باشد، برای فعال‌سازی و ویرایش کتاب‌کار جاسازی‌شده دوبار کلیک کنید. فعال‌سازی و ویرایش بستگی به پشتیبانی OLE برنامه میزبانی و تنظیمات امنیتی دارد.

## **پرسش‌های متداول**

**چرا تصویر پیش‌نمایش لازم است؟**

کتاب‌کار جاسازی‌شده و پیش‌نمایش اسلاید آن محتواهای جداگانه‌ای هستند. یک تصویر نمودار فراهم کنید تا اسلاید به‌جای نگهدارنده پیش‌فرض «EMBEDDED OLE OBJECT» نمودار را نمایش دهد. ببینید [مشکل پیش‌نمایش شی هنگام افزودن OleObjectFrame](/slides/fa/java/object-preview-issue-when-adding-oleobjectframe/).

**آیا پیش‌نمایش به‌صورت خودکار هنگام تغییر کتاب‌کار در کد به‌روز می‌شود؟**

پیش‌نمایش را به‌عنوان یک تصویر ثابت در نظر بگیرید. هنگامی که داده‌های کتاب‌کار را برنامه‌نویسی به‌روزرسانی می‌کنید، تصویر نمودار را دوباره تولید کنید و هم پیش‌نمایش و هم داده‌های کتاب‌کار جاسازی‌شده را جایگزین کنید.

**آیا می‌توانم به جای XLSX از XLS استفاده کنم؟**

بله. کتاب‌کار را به شکل XLS ذخیره کنید و از پسوند `xls` به‌عنوان پسوند داده‌های جاسازی‌شده استفاده کنید. پسوند باید با فرمت واقعی کتاب‌کار مطابقت داشته باشد؛ تغییر تنها پسوند داده‌ها را تبدیل نمی‌کند.

**چرا ممکن است پس از فعال‌سازی اندازه شی تغییر کند؟**

برنامه میزبانی می‌تواند ارائه شی OLE را هنگام فعال‌سازی کتاب‌کار به‌روزرسانی کند. بازه نمایش OLE کتاب‌کار و ابعاد قاب اسلاید هر دو مهم هستند. ببینید [راه‌حل کار برای تغییر اندازه نمودار در PPTX](/slides/fa/java/working-solution-for-chart-resizing-in-pptx/).

## **بخش‌های مرتبط**

- [راه‌حل کار برای تغییر اندازه نمودار در PPTX](/slides/fa/java/working-solution-for-chart-resizing-in-pptx/)
- [مشکل پیش‌نمایش شی هنگام افزودن OleObjectFrame](/slides/fa/java/object-preview-issue-when-adding-oleobjectframe/)
- [به‌روزرسانی خودکار اشیای OLE با استفاده از افزودنی PowerPoint](/slides/fa/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)