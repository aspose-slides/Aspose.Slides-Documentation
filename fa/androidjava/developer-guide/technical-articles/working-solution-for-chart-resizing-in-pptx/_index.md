---
title: راه‌حل عملی برای تغییر اندازه نمودار در PPTX
type: docs
weight: 40
url: /fa/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغییر اندازه نمودار
- نمودار اکسل
- شیء OLE
- جاسازی نمودار
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "رفع تغییر اندازه ناخواسته نمودار در PPTX هنگام استفاده از اشیاء OLE اکسل جاسازی‌شده با Aspose.Slides برای Android از طریق Java. تنظیم ابعاد ثابت نمودار برای حفظ سازگاری اندازه‌های نمودار و فریم OLE."
---
## **بررسی کلی**

نمودارهای اکسل که به‌عنوان اشیای OLE در ارائه‌های PowerPoint با استفاده از مؤلفه‌های Aspose جاسازی می‌شوند، پس از اولین فعال‌سازی می‌توانند اندازه‌شان تغییر کند. این می‌تواند باعث ایجاد تفاوت آشکاری در ظاهر نمودار قبل و بعد از فعال‌سازی شود. این مقاله توضیح می‌دهد چرا تغییر اندازه رخ می‌دهد و نشان می‌دهد چگونه با مطابقت ابعاد ثابت نمودار با فریم OLE می‌توان از آن جلوگیری کرد.

در [ایجاد نمودارهای اکسل و قرار دادن آنها به عنوان اشیاء OLE در ارائه‌ها](/slides/fa/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، ما نحوهٔ ایجاد یک نمودار اکسل با Aspose.Cells برای Android از طریق Java و جاسازی آن در یک ارائه PowerPoint با استفاده از Aspose.Slides برای Android از طریق Java را توضیح دادیم. برای رفع [object preview issue](/slides/fa/androidjava/object-preview-issue-when-adding-oleobjectframe/)، تصویر نمودار را به فریم شیء OLE نمودار اختصاص دادیم. در ارائه خروجی، هنگامی که فریم شیء OLE که تصویر نمودار را نشان می‌دهد دوبار کلیک شود، نمودار اکسل فعال می‌شود. کاربران می‌توانند کتاب‌کار اکسل جاسازی‌شده را ویرایش کنند و سپس با کلیک خارج از کتاب‌کار فعال، به اسلاید بازگردند. اندازهٔ فریم شیء OLE زمانی که کاربر به اسلاید برمی‌گردد تغییر می‌کند و ضریب تغییر اندازه بسته به اندازه‌های اصلی هر دو فریم شیء OLE و کتاب‌کار اکسل جاسازی‌شده متفاوت است.

## **دلیل تغییر اندازه**

کتاب‌کار اکسل جاسازی‌شده دارای ابعاد پنجرهٔ خود است که اکسل سعی می‌کند هنگام اولین فعال‌سازی آن را حفظ کند. فریم OLE روی اسلاید به‌صورت مستقل ابعاد تعریف‌شده‌ای دارد. وقتی کتاب‌کار اکسل فعال می‌شود، اکسل و PowerPoint برای حفظ نسبت‌ها، اندازهٔ شیء را مذاکره می‌کنند. تفاوت بین پنجرهٔ کتاب‌کار و فریم OLE می‌تواند منجر به تغییر اندازه شیء شود.

## **راه‌حل عملی**

اندازهٔ نمودار را با فریم OLE روی اسلاید مطابقت دهید و ابعاد نمودار را مستقل از پنجرهٔ کتاب‌کار نگه دارید. این راه‌حل برای یک ارائهٔ جدید یا یک قالب موجود کار می‌کند.

این مثال به Aspose.Cells برای Android از طریق Java و Aspose.Slides برای Android از طریق Java نیاز دارد. یک نمودار ستونی ساده روی یک صفحهٔ نمودار فعال ایجاد می‌کند و کتاب‌کار را در قالب XLS جاسازی می‌کند. از یک Activity اندروید فراخوانی `FixedChartSize.createPresentation(getFilesDir())` کنید تا خروجی در پوشهٔ فایل‌های داخلی برنامه ذخیره شود. فعال‌سازی OLE به PowerPoint دسکتاپ و نصب سازگار Excel نیاز دارد. تصویری پیش‌نمایش برای نمودار اختصاص داده نمی‌شود؛ نمودار زمانی که شیء OLE در PowerPoint فعال می‌شود قابل مشاهده می‌شود.

این مثال یک ارائهٔ جدید با فریم OLE به ابعاد 9.5 × 4 اینچ ایجاد می‌کند که 0.5 اینچ از لبهٔ چپ و 1 اینچ از بالا موقعیت دارد. مختصات و ابعاد اسلاید بر حسب نقطه (72 نقطه در هر اینچ) هستند. برای یک ارائهٔ موجود، به [استفاده از قالب](#use-a-template) مراجعه کنید.

## **تنظیم اندازه ثابت نمودار**

Set [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) to false so that the chart dimensions are independent of the workbook window. Set the [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) dimensions through [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) and [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), converting points to pixels using 96 pixels per inch: a frame measuring 684 × 288 points corresponds to a chart measuring 912 × 384 pixels. Set [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) to the CUSTOM value of [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). The example embeds the workbook with [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) and saves a presentation with a 9.5 × 4-inch OLE frame.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
            Workbook workbook = new Workbook();
            try {
                Worksheet dataSheet = workbook.getWorksheets().get(0);
                dataSheet.setName("Data");
                dataSheet.getCells().get("A1").putValue(10);
                dataSheet.getCells().get("A2").putValue(20);

                int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
                Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
                int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
                Chart chart = chartSheet.getCharts().get(chartIndex);
                chart.getNSeries().add("Data!A1:A2", true);
                workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

                Presentation presentation = new Presentation();
                try {
                    ISlide slide = presentation.getSlides().get_Item(0);

                    // مختصات و ابعاد اسلاید بر حسب نقطه هستند (۷۲ نقطه در هر اینچ).
                    float width = 684f; // 9.5 اینچ.
                    float height = 288f; // 4 اینچ.

                    chart.setSizeWithWindow(false);
                    // نقطه‌ها را به پیکسل‌های نمودار تبدیل کنید با استفاده از ۹۶ پیکسل در هر اینچ.
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```

## **استفاده از قالب**

منطق اندازه‌گیری برای یک ارائهٔ موجود همانند است. برای تطبیق مثال:

1. قالب ارائه را بارگذاری کنید به‌جای ایجاد یک ارائهٔ خالی.
2. بررسی کنید که اسلاید اول حداقل شامل سه شکل باشد، سپس شکل با ایندکس 2 را به‌عنوان جای‌نگهدار استفاده کنید.
3. عرض و ارتفاع فریم را از آن شکل بگیرید به‌جای استفاده از مقدارهای ثابت 684 و 288. محاسبات اندازه‌گیری را بدون تغییر نگه دارید.
4. فریم OLE را در موقعیت جای‌نگهدار اضافه کنید به‌جای مختصات ثابت 36 و 72.
5. قبل از ذخیرهٔ ارائه، جای‌نگهدار را حذف کنید.

## **سوالات متداول**

**چرا نمودار اکسل جاسازی‌شده من پس از فعال‌سازی در PowerPoint اندازهٔ خود را تغییر می‌دهد؟**

این رخ می‌دهد زیرا اکسل سعی می‌کند هنگام اولین فعال‌سازی، اندازهٔ اصلی پنجرهٔ خود را بازیابی کند، در حالی که فریم شیء OLE در PowerPoint ابعاد جداگانه‌ای دارد. PowerPoint و اکسل برای حفظ نسبت عرض/ارتفاع مذاکره می‌کنند که می‌تواند منجر به تغییر اندازه شود.

**چگونه می‌توانم ابعاد نمودار و فریم OLE را ثابت نگه دارم؟**

ابعاد ثابت نمودار را طوری تنظیم کنید که با فریم OLE مطابقت داشته باشد و قبل از جاسازی کتاب‌کار، اندازهٔ چاپ سفارشی نمودار را استفاده کنید. مثال بالا تنظیمات مورد نیاز و تبدیل واحدها را نشان می‌دهد.

**آیا مطابقت اندازهٔ پنجرهٔ کتاب‌کار کافی است؟**

فقط مطابقت اندازهٔ پنجرهٔ کتاب‌کار به‌تنهایی به‌طور قابل اعتماد از تغییر اندازه فریم OLE پس از فعال‌سازی جلوگیری نمی‌کند. همان‌طور که در مثال نشان داده شده، از ابعاد ثابت نمودار استفاده کنید.

**آیا این راه‌حل برای ارائه‌های مبتنی بر قالب و ارائه‌های جدید کار می‌کند؟**

بله. برای یک قالب، از ابعاد و موقعیت جای‌نگهدار استفاده کنید. برای یک ارائهٔ جدید، مستقیماً ابعاد و موقعیت فریم را مشخص کنید.

**آیا می‌توانم این مثال را با نمودارهای ایجاد شده در برنامه‌های دیگر صفحه‌گستار استفاده کنم؟**

این مثال از کتاب‌کار اکسل ایجاد شده با Aspose.Cells استفاده می‌کند و رفتار فعال‌سازی برای برنامه‌های دیگر صفحه‌گستار را نشان نمی‌دهد.

## **بخش‌های مرتبط**

- [ایجاد نمودارهای اکسل و قرار دادن آنها به عنوان اشیاء OLE در ارائه‌ها](/slides/fa/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)