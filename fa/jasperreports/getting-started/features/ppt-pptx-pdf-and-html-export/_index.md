---  
title: صادرات PPT، PPTX، PDF و HTML  
type: docs  
weight: 20  
url: /fa/jasperreports/ppt-pptx-pdf-and-html-export/  
description: "صادرکننده Aspose.Slides برای JasperReports را برای خروجی PPT، PPTX، PDF یا HTML انتخاب کنید، یک گزارش پر شده را با آن صادر کنید، و فونت‌های گزارش را به فونت‌های ارائه نقشه‌گذاری کنید."  
---
## **صادرکننده‌ها**

Aspose.Slides برای JasperReports چهار صادرکننده به JasperReports اضافه می‌کند. هر یک گزارش پر شده (`JasperPrint`) را می‌گیرد و هر صفحه گزارش را به‌صورت اسلاید در PPT و PPTX، به‌صورت صفحه در PDF، و به‌صورت تصویر SVG در یک فایل HTML صادر می‌کند.

| فرمت خروجی | کلاس صادرکننده |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

کلاس‌ها در بسته `com.aspose.slides.jasperreports` موجود در فایل jar کتابخانه قرار دارند و از Microsoft PowerPoint استفاده نمی‌کنند. گزارش و فایل خروجی را با استفاده از `setParameter` و `JRExporterParameter` (که JasperReports آن را منسوخ اعلام کرده) به یک صادرکننده پاس می‌دهید؛ صادرکننده‌ها پیکربندی جدید `setExporterInput` و `setExporterOutput` را قبول نمی‌کنند.

## **صادرات یک گزارش به چهار فرمت**

برنامه زیر بر پایه پروژهٔ [Your first export](/slides/fa/jasperreports/#your-first-export) ساخته شده است. یک بار *hello.jrxml* را کامپایل و پر می‌کند، سپس گزارش پر شده را به‌تدریج به هر صادرکننده می‌سپارد. آن را به عنوان *src/main/java/ExportAllFormats.java* در آن پروژه ذخیره کنید:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASAbstractExporter;
import com.aspose.slides.jasperreports.ASHtmlExporter;
import com.aspose.slides.jasperreports.ASPdfExporter;
import com.aspose.slides.jasperreports.ASPptExporter;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRException;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class ExportAllFormats {
    public static void main(String[] args) throws Exception {
        // گزارش را یک بار کامپایل و پر کنید.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // گزارش پر شدهٔ یکسان را با هر صادرکننده صادر کنید.
        export(new ASPptExporter(), jasperPrint, "hello.ppt");
        export(new ASPptxExporter(), jasperPrint, "hello.pptx");
        export(new ASPdfExporter(), jasperPrint, "hello.pdf");
        export(new ASHtmlExporter(), jasperPrint, "hello.html");
    }

    private static void export(ASAbstractExporter exporter, JasperPrint jasperPrint, String outputFileName) throws JRException {
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, outputFileName);
        exporter.exportReport();
    }
}
```

از پوشهٔ پروژه آن را اجرا کنید:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

برنامه *hello.ppt*، *hello.pptx*، *hello.pdf* و *hello.html* را در پوشهٔ پروژه ذخیره می‌کند. متد کمکی `ASAbstractExporter`، کلاس پایهٔ چهار صادرکننده، را می‌گیرد. بدون داشتن لایسنس، هر فایل خروجی دارای واترمارک ارزیابی است — برای جزئیات به [Evaluate Aspose.Slides](/slides/fa/jasperreports/evaluate-aspose-slides/) مراجعه کنید.

![یک گزارش صادرشده به یک ارائه بدون لایسنس](ppt-pptx-pdf-and-html-export_1.png)

## **نقشه‌گذاری فونت‌ها**

صادرکننده‌های PPT و PPTX نام‌های فونت‌های طراحی گزارش را بدون تغییر در ارائه می‌نویسند. وقتی یک عنصر متنی هیچ فونتی نام‌گذاری نکند، JasperReports از فونت پیش‌فرض خود، `SansSerif`، استفاده می‌کند که یک نام فونت منطقی جاوا است نه یک فونت نصب‌شده. برای جایگزینی این نام‌ها، یک نقشه از نام‌های فونت گزارش به نام‌های فونتی که می‌خواهید در ارائه استفاده شود، در پارامتر `ASExporterParameters.PPT_FONT_MAP` بفرستید. کلیدها باید دقیقاً با نام‌های فونت در گزارش مطابقت داشته باشند، شامل حروف بزرگ و کوچک. هر مقدار باید فونتی باشد که جاوا در ماشینی که عملیات صادر کردن انجام می‌شود پیدا می‌کند؛ صادرکننده‌ها ورودی‌ای را که جاوا نتواند فونت آن را پیدا کند نادیده می‌گیرد.

این برنامه را به عنوان *src/main/java/MapFonts.java* در همان پروژه ذخیره کنید. این برنامه *hello.jrxml* را به PPTX صادر می‌کند و `SansSerif` را با Arial جایگزین می‌کند:

```java
import java.util.HashMap;
import java.util.Map;

import com.aspose.slides.jasperreports.ASExporterParameters;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class MapFonts {
    public static void main(String[] args) throws Exception {
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // نام فونت گزارش را به نام فونتی که باید در ارائه نوشته شود، نگاشت کنید.
        Map<String, String> fontMap = new HashMap<String, String>();
        fontMap.put("SansSerif", "Arial");

        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello-arial.pptx");
        exporter.setParameter(ASExporterParameters.PPT_FONT_MAP, fontMap);
        exporter.exportReport();
    }
}
```

از پوشهٔ پروژه آن را اجرا کنید:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

در فایل ذخیره‌شده *hello-arial.pptx*، متن گزارش از Arial به‌جای `SansSerif` استفاده می‌کند. در ماشینی که جاوا Arial را پیدا نکند (مثلاً در یک سیستم لینوکسی بدون این فونت)، متن همچنان `SansSerif` باقی می‌ماند. در JasperReports Server، همان نقشه را از طریق ویژگی `fontMap` در شیء پارامترهای خروجی تنظیم کنید — برای جزئیات به [Integration with JasperServer](/slides/fa/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license) مراجعه کنید.