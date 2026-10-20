---
title: ایجاد نمودارهای Excel و جاسازی آن‌ها در ارائه‌ها به‌عنوان اشیای OLE
type: docs
weight: 30
url: /fa/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- نمودار Excel
- جاسازی نمودار
- شی OLE
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یک نمودار Excel را با Aspose.Cells for Android via Java ایجاد کنید و کتاب‌کار را در یک ارائه PowerPoint با Aspose.Slides for Android via Java جاسازی کنید، به‌همراه پیش‌نمایش نمودار."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه یک نمودار ستونی Excel را با Aspose.Cells for Android via Java ایجاد کرده و دفتر کار آن را در یک ارائه PowerPoint با Aspose.Slides for Android via Java جاسازی کنید. دفتر کار جاسازی‌شده شامل داده‌های منبع و نمودار می‌باشد. یک تصویر PNG جداگانه پیش‌نمایش، نمودار را بر اسلاید قبل از فعال شدن شی OLE نمایش می‌دهد.

نتیجه یک شیء Excel جاسازی‌شده است، نه یک نمودار بومی PowerPoint. ویرایش دفتر کار از طریق OLE به یک برنامه دسکتاپی نیاز دارد که از فعال‌سازی OLE پشتیبانی کند و یک نصب سازگار Excel داشته باشد.

## **پیش‌نیازها**

Aspose.Cells for Android via Java و Aspose.Slides for Android via Java را به وابستگی‌های پروژه خود اضافه کنید. از یک Activity اندروید فراخوانی `ExcelChartEmbedding.createPresentation(getFilesDir())` کنید. برای تولید ارائه با این کتابخانه‌ها نیازی به Microsoft Office ندارید.

فایل ورودی نیاز نیست: مثال داده‌ها و نمودار را در حافظه ایجاد می‌کند، سپس `OutputChart.pptx` را در پوشه فایل‌های داخلی برنامه می‌نویسد. هنگام اجرا خارج از حالت ارزیابی، برای هر دو محصول لایسنس اعمال کنید.

## **نحوه کار جاسازی**

1. یک کاربرگ با یک شیت داده و یک شیت نمودار ایجاد کنید.  
1. شیت نمودار را فعال کنید تا کاربرگ هنگام باز شدن روی نمودار قرار بگیرد.  
1. محدوده نمایش OLE کاربرگ را تنظیم کنید و نمودار را به PNG رندر کنید.  
1. کاربرگ را به صورت XLSX در حافظه ذخیره کنید و آن بایت‌ها را در یک اسلاید جاسازی کنید.  
1. PNG را به‌عنوان پیش‌نمایش شی OLE اختصاص دهید و ارائه را به صورت PPTX ذخیره کنید.

محدوده نمایش کاربرگ و قاب اسلاید نقش‌های متفاوتی دارند. `[setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-)` اندیس‌های ردیف و ستون آغاز/پایان را به‌صورت صفر‑پایه می‌گیرد. `[ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-)` به‌جای آن ردیف بالایی، ستون چپ، ردیف پایینی و ستون راست را می‌گیرد. مثال از اندیس ردیف 55 و اندیس ستون 25 به‌عنوان مرز پایین‑راست استفاده می‌کند؛ این مقادیر تنها انتخاب‌های چیدمان هستند، نه تعداد ردیف‌ها یا ستون‌های داده.

قاب اسلاید بر حسب نقطه محاسبه می‌شود. مثال آن را درون اسلاید قرار می‌دهد و در وسط اسلاید می‌چیند در حالی که نسبت عرض‑به‑ارتفاع PNG حفظ می‌شود، نه این که پیش‌نمایش را تا پر کردن اسلاید کشیده کند.

## **ایجاد و جاسازی نمودار**

مثال کامل زیر `DataSheet` را با چهار ردیف و پنج ستون مقدار پر می‌کند. هر ردیف تبدیل به یک سری نمودار می‌شود. قبل از ذخیره کاربرگ، `ChartSheet` به‌عنوان شیت فعال انتخاب می‌شود.

کاربرگ به‌صورت صریح به‌عنوان XLSX ذخیره می‌شود، مطابق با افزونه `xlsx` که به ‌`[OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/)` پاس داده می‌شود. PNG مستقیماً از بایت‌های آن بارگذاری می‌شود بدون تبدیل به بیت‌مپ میانی. اختصاص آن از طریق `[getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--)` جایگزین پیش‌فرض مکان‌گیر OLE می‌شود.

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
import java.io.File;

public class ExcelChartEmbedding {
    public static void createPresentation(File filesDirectory) {
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

                // پیش‌نمایش نمودار را رندر کنید و کتاب‌کار قابل ویرایش را به‌صورت جداگانه سریالیزه کنید.
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

                        // پیش‌نمایش را درون اسلاید جای دهید بدون تغییر نسبت عرض‑به‑ارتفاع.
                        double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                        float frameWidth = (float) (chartImage.getWidth() * scale);
                        float frameHeight = (float) (chartImage.getHeight() * scale);
                        float frameX = (float) ((slideWidth - frameWidth) / 2);
                        float frameY = (float) ((slideHeight - frameHeight) / 2);

                        OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                        IPPImage previewImage = presentation.getImages().addImage(chartImage);
                        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                        File outputFile = new File(filesDirectory, "OutputChart.pptx");
                        presentation.save(outputFile.getAbsolutePath(), Pptx);
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
    }
}
```

## **نتیجه مورد انتظار**

`OutputChart.pptx` شامل یک اسلاید با یک کتاب‌کار Excel جاسازی‌شده و پیش‌نمایش نمودار است. کتاب‌کار شامل داده‌های اصلی و یک نمودار ستونی با چهار سری است. پیش‌نمایش در مرکز اسلاید قرار گرفته و نسبت‌های خود را حفظ می‌کند.

![نمودار ستونی Excel که به‌عنوان پیش‌نمایش کتاب‌کار جاسازی‌شده نمایش داده شده است](excel-chart-ole-preview.png)

در محیط دسکتاپ PowerPoint سازگار که Excel در دسترس باشد، برای فعال‌سازی و ویرایش کتاب‌کار جاسازی‌شده، روی شیء دوبار کلیک کنید. فعال‌سازی و ویرایش بستگی به پشتیبانی OLE برنامه میزبان و تنظیمات امنیتی آن دارد.

## **سؤال‌های متداول**

**چرا تصویر پیش‌نمایش لازم است؟**

کتاب‌کار جاسازی‌شده و پیش‌نمایش اسلاید آن محتواهای جداگانه‌ای هستند. یک تصویر نمودار فراهم کنید تا اسلاید به‌جای مکان‌گیر پیش‌فرض «EMBEDDED OLE OBJECT»، نمودار را نشان دهد. به [مشکل پیش‌نمایش شی هنگام افزودن OleObjectFrame](/slides/fa/androidjava/object-preview-issue-when-adding-oleobjectframe/) مراجعه کنید.

**آیا پیش‌نمایش به‌صورت خودکار هنگام تغییر کتاب‌کار در کد به‌روز می‌شود؟**

پیش‌نمایش را به‌عنوان یک snapshot در نظر بگیرید. هنگام به‌روزرسانی داده‌های کتاب‌کار به‌صورت برنامه‌نویسی، تصویر نمودار را دوباره تولید کنید و پیش‌نمایش را همانند داده‌های کتاب‌کار جاسازی‌شده جایگزین کنید.

**آیا می‌توانم به‌جای XLSX از XLS استفاده کنم؟**

بله. کتاب‌کار را در قالب XLS ذخیره کنید و از `xls` به‌عنوان افزونه داده‌های جاسازی‌شده استفاده کنید. افزونه باید با فرمت واقعی کتاب‌کار مطابقت داشته باشد؛ تنها تغییر افزونه باعث تبدیل داده نمی‌شود.

**چرا ممکن است شی پس از فعال‌سازی اندازه‌اش تغییر کند؟**

برنامه میزبان می‌تواند ارائه شی OLE را هنگام فعال‌سازی کتاب‌کار به‌روزرسانی کند. محدوده نمایش OLE کتاب‌کار و ابعاد قاب اسلاید هر دو مهم هستند. به [راه‌حل کاری برای تغییر اندازه شیت](/slides/fa/androidjava/working-solution-for-worksheet-resizing/) مراجعه کنید.

## **بخش‌های مرتبط**

- [راه‌حل کاری برای تغییر اندازه شیت](/slides/fa/androidjava/working-solution-for-worksheet-resizing/)
- [مشکل پیش‌نمایش شی هنگام افزودن OleObjectFrame](/slides/fa/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [مدیریت OLE](/slides/fa/androidjava/manage-ole/)