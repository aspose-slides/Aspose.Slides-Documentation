---
title: "مجوزدهی"
type: docs
weight: 50
url: /fa/jasperreports/licensing/
description: "بیاموزید که نسخه ارزیابی Aspose.Slides برای JasperReports چه چیزی را به فایل‌های صادرشده اضافه می‌کند و چگونه یک لایسنس را در JasperReports و JasperReports Server اعمال کنید."
---
{{% alert color="info" title="توجه" %}}

Aspose.Slides برای JasperReports به صورت ارزیابی رایگان و بدون محدودیت زمانی از [صفحه دانلود](https://releases.aspose.com/slides/jasperreport/) در دسترس است. نسخه‌های ارزیابی و دارای لایسنس محصول همان دانلود هستند.

وقتی از ارزیابی راضی شدید، [یک لایسنس خریداری کنید](https://purchase.aspose.com/pricing/slides/jasperreports/). اطمینان حاصل کنید که شرایط اشتراک را درک کرده و با آن موافقید.

لایسنس پس از پرداخت سفارش از صفحه سفارش به‌صورت دانلود در دسترس است. لایسنس یک فایل XML متن باز، به‌صورت دیجیتالی امضا شده است که شامل اطلاعاتی مانند نام مشتری، محصول خریداری شده و نوع لایسنس می‌باشد. به هیچ وجه محتویات فایل لایسنس را تغییر ندهید: این کار لایسنس را باطل می‌کند.

لایسنس را روی رایانه خود دانلود کنید و به پوشه مناسب کپی کنید (برای مثال پوشهٔ برنامه شما یا **JasperReports\lib**).

{{% /alert %}}

## **محدودیت نسخه ارزیابی**
نسخهٔ ارزیابی Aspose.Slides برای JasperReports (بدون تعیین لایسنس) هر صفحهٔ گزارش را صادر می‌کند، اما یک واترمارک ارزیابی در مرکز هر اسلاید یا صفحه، در هر چهار فرمت خروجی (PPT، PPTX، PDF و HTML) قرار می‌دهد، همان‌طور که در شکل زیر نشان داده شده است. برای جزئیات بیشتر به [Evaluate Aspose.Slides](/slides/fa/jasperreports/evaluate-aspose-slides/) مراجعه کنید.

![واترمارک ارزیابی در مرکز یک اسلاید صادر شده](evaluation_watermark.png)

## **اعمال لایسنس**
روش‌های متعددی برای اعمال لایسنس وجود دارد، بسته به این‌که در JasperReports یا JasperServer کار می‌کنید.

### **اعمال لایسنس برای JasperReports**
متد `setLicense` از کلاس `License` را با یک جریان (stream) که فایل لایسنس را می‌خواند، فراخوانی کنید، همانند Aspose.Slides برای جاوا:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // یک شیء جریان شامل فایل لایسنس ایجاد کنید.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // یک نمونه از کلاس License ایجاد کنید.
            License license = new License();

            // لایسنس را از طریق شیء جریان تنظیم کنید.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

یا مسیر فایل لایسنس را به پارامتر `ASExporterParameters.PPT_LICENSE` در خروجی‌گر (exporter) پاس دهید. در این قطعه کد، `jasperPrint` یک گزارش پر شده است، همانند [اولین خروجی شما](/slides/fa/jasperreports/#your-first-export):

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **اعمال لایسنس روی JasperServer**
ویژگی `licenseFile` از bean `pptExportParameters` در *applicationContext.xml* را روی مسیر فایل لایسنس تنظیم کنید، همان‌طور که در [یکپارچگی با JasperServer](/slides/fa/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license) نشان داده شده است.