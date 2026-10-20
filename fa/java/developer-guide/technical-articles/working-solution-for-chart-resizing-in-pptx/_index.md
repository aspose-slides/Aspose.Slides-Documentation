---
title: راه‌حل عملی برای تغییر اندازه نمودار در PPTX
type: docs
weight: 40
url: /fa/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغییر اندازه نمودار
- نمودار Excel
- شی OLE
- جاسازی نمودار
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "رفع تغییر اندازه ناخواسته نمودار در PPTX هنگام استفاده از اشیای OLE Excel جاسازی‌شده با Aspose.Slides برای Java. تنظیم ابعاد ثابت نمودار برای حفظ سازگاری اندازه‌های نمودار و چارچوب OLE."
---
## **پیش‌زمینه**

نمودارهای Excel که به عنوان اشیای OLE در ارائه‌های PowerPoint با استفاده از مؤلفه‌های Aspose جاسازی می‌شوند، ممکن است پس از اولین فعال‌سازی اندازه خود را تغییر دهند. این می‌تواند تفاوت قابل‌توجهی در ظاهر نمودار قبل و پس از فعال‌سازی ایجاد کند. این مقاله دلیل بروز تغییر اندازه را توضیح می‌دهد و نشان می‌دهد چگونه با مطابقت ابعاد ثابت نمودار با چارچوب OLE از آن جلوگیری کنیم.

در [ایجاد نمودارهای Excel و جاسازی آنها به عنوان اشیای OLE در ارائه‌ها](/slides/fa/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، نحوه ایجاد یک نمودار Excel با Aspose.Cells for Java و جاسازی آن در یک ارائه PowerPoint با Aspose.Slides for Java را توضیح دادیم. برای رفع [مشکل پیش‌نمایش شی](/slides/fa/java/object-preview-issue-when-adding-oleobjectframe/)، تصویر نمودار را به چارچوب شی OLE نمودار اختصاص دادیم. در ارائه خروجی، وقتی چارچوب شی OLE که تصویر نمودار را نشان می‌دهد را دو بار کلیک می‌کنید، نمودار Excel فعال می‌شود. کاربران می‌توانند کتاب‌کار Excel جاسازی‌شده را ویرایش کنند و سپس با کلیک خارج از کتاب‌کار فعال شده به اسلاید بازگردند. اندازه چارچوب شی OLE هنگام بازگشت کاربر به اسلاید تغییر می‌کند و ضریب تغییر اندازه بسته به اندازه‌های اولیه هر دو چارچوب شی OLE و کتاب‌کار Excel جاسازی‌شده متفاوت است.

## **دلیل تغییر اندازه**

کتاب‌کار Excel جاسازی‌شده ابعاد پنجره خودش را دارد که Excel سعی می‌کند هنگام اولین فعال‌سازی شی آن را حفظ کند. چارچوب OLE روی اسلاید ابعاد مستقلی دارد. وقتی کتاب‌کار Excel فعال می‌شود، Excel و PowerPoint برای حفظ نسبت‌های ابعاد شی، اندازهٔ آن را تنظیم می‌کنند. تفاوت بین پنجره کتاب‌کار و چارچوب OLE بنابراین می‌تواند باعث تغییر اندازه شی شود.

## **راه‌حل عملی**

اندازه نمودار را با چارچوب OLE روی اسلاید مطابقت دهید و ابعاد نمودار را مستقل از پنجره کتاب‌کار نگه دارید. این راه‌حل برای یک ارائهٔ جدید یا یک قالب موجود کار می‌کند.

این مثال به Aspose.Cells for Java و Aspose.Slides for Java نیاز دارد. یک نمودار ستونی ساده بر روی یک شیت نمودار فعال ایجاد می‌کند و کتاب‌کار را در قالب XLS جاسازی می‌نماید. هیچ تصویر پیش‌نمایش نموداری اختصاص داده نمی‌شود؛ نمودار زمانی که شی OLE در PowerPoint فعال می‌شود، قابل مشاهده می‌گردد.

مثال یک ارائهٔ جدید با چارچوب OLE به اندازهٔ 9.5 × 4 اینچ ایجاد می‌کند که 0.5 اینچ از لبهٔ چپ و 1 اینچ از بالا موقعیت دارد. مختصات و ابعاد اسلاید بر حسب نقطه‌اند (72 نقطه در هر اینچ). برای یک ارائهٔ موجود، به [استفاده از قالب](#use-a-template) مراجعه کنید.

## **تنظیم اندازه ثابت نمودار**

Set [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) to false so that the chart dimensions are independent of the workbook window. Set the [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) dimensions through [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) and [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), converting points to pixels using 96 pixels per inch: a frame measuring 684 × 288 points corresponds to a chart measuring 912 × 384 pixels. Set [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) to the CUSTOM value of [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). The example embeds the workbook with [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) and saves a presentation with a 9.5 × 4-inch OLE frame.

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

        // مختصات و ابعاد اسلاید بر حسب نقطه‌اند (۷۲ نقطه در هر اینچ).
        float width = 684f; // 9.5 اینچ.
        float height = 288f; // 4 اینچ.

        chart.setSizeWithWindow(false);
        // تبدیل نقطه‌ها به پیکسل‌های نمودار با استفاده از ۹۶ پیکسل در هر اینچ.
        chart.getChartObject().setWidth((int)(width / 72f * 96f));
        chart.getChartObject().setHeight((int)(height / 72f * 96f));
        chart.setPrintSize(PrintSizeType.CUSTOM);

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
        slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **استفاده از قالب**

منطق اندازه‑گیری برای یک ارائهٔ موجود نیز یکسان است. برای تطبیق مثال:

1. قالب ارائه را بارگذاری کنید به جای ایجاد یک ارائهٔ خالی.  
2. اطمینان حاصل کنید که اسلاید اول حداقل شامل سه شکل باشد، سپس شکل با نمایهٔ 2 را به عنوان جای‌گیر استفاده کنید.  
3. عرض و ارتفاع چارچوب را از آن شکل بگیرید به جای استفاده از مقادیر ثابت 684 و 288. محاسبات اندازه‌گیری را همان‌طور که هستند نگه دارید.  
4. چارچوب OLE را در موقعیت جای‌گیر اضافه کنید به جای مختصات ثابت 36 و 72.  
5. قبل از ذخیرهٔ ارائه، جای‌گیر را حذف کنید.

## **سوالات متداول**

**چرا نمودار Excel جاسازی‌شده من پس از فعال‌سازی در PowerPoint اندازه خود را تغییر می‌دهد؟**

این به این دلیل است که Excel سعی می‌کند اندازهٔ اصلی پنجره را هنگام اولین فعال‌سازی بازگرداند، در حالی که چارچوب شی OLE در PowerPoint ابعاد مستقلی دارد. PowerPoint و Excel برای حفظ نسبت ابعاد، اندازه را تنظیم می‌کنند که می‌تواند منجر به تغییر اندازه شود.

**چگونه می‌توانم اندازه‌های نمودار و چارچوب OLE را سازگار نگه دارم؟**

اندازه‌های ثابت نمودار را طوری تنظیم کنید که با چارچوب OLE مطابقت داشته باشند و قبل از جاسازی کتاب‌کار، یک اندازه چاپ سفارشی برای نمودار تعیین کنید. مثال بالا تنظیمات لازم و تبدیل واحدها را نشان می‌دهد.

**آیا مطابقت اندازه پنجره کتاب‌کار کافی است؟**

تنها مطابقت اندازه پنجره کتاب‌کار به‌ طور قابل‌اعتمادی تغییر اندازهٔ چارچوب OLE پس از فعال‌سازی را جلوگیری نمی‌کند. از ابعاد ثابت نمودار همان‌طور که در مثال نشان داده شده است، استفاده کنید.

**آیا این راه‌حل برای ارائه‌های مبتنی بر قالب و ارائه‌های جدید هر دو کار می‌کند؟**

بله. برای یک قالب، از ابعاد و موقعیت جای‌گیر استفاده کنید. برای یک ارائهٔ جدید، مستقیماً ابعاد و موقعیت چارچوب را مشخص کنید.

**آیا می‌توانم این مثال را با نمودارهای ایجادشده در برنامه‌های صفحه‑گسترده دیگر استفاده کنم؟**

این مثال از یک کتاب‌کار Excel ایجادشده با Aspose.Cells استفاده می‌کند و رفتار فعال‌سازی را برای برنامه‌های صفحه‑گسترده دیگر نشان نمی‌دهد.

## **بخش‌های مرتبط**

- [ایجاد نمودارهای Excel و جاسازی آنها به عنوان اشیای OLE در ارائه‌ها](/slides/fa/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)