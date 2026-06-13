---
title: مرور محصول
type: docs
weight: 10
url: /fa/jasperreports/product-overview/
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **به Aspose.Slides for JasperReports خوش آمدید!**

Aspose.Slides for JasperReports یک کتابخانه است که به‌طور خاص برای توسعه‌دهندگانی طراحی و توسعه یافته است که نیاز به صادرات آسان گزارش‌ها از JasperReports به فرمت‌های Microsoft PowerPoint Presentation (PPT) و Microsoft PowerPoint Show (PPS) در برنامه‌های Java خود دارند. تمام ویژگی‌های گزارش با دقت بالایی به ارائه‌های Microsoft PowerPoint تبدیل می‌شوند. Aspose.Slides for JasperReports از JasperReports نسخه 5 به بالا پشتیبانی می‌کند.

## **توضیح محصول**
JasperReports و JasperServer قابلیت داخلی برای صادرات گزارش‌ها به ارائه‌های Microsoft PowerPoint ندارند، اما Aspose.Slides for JasperReports به شما دسترسی به دو فرمت صادراتی اضافی می‌دهد:

- PPT – ارائه PowerPoint از طریق Aspose.Slides
- PPS – نمایش PowerPoint از طریق Aspose.Slides
- PPTX – ارائه PowerPoint از طریق Aspose.Slides
- PPSX – نمایش PowerPoint از طریق Aspose.Slides

Aspose.Slides for JasperReports به‌صورت داخلی از کتابخانه‌های 100٪ خالص Java ما به نام Aspose.Slides for Java و Aspose.Metafiles for Java استفاده می‌کند، که کتابخانه‌های سطح جهانی برای پردازش ارائه‌های سمت سرور و متافایل‌ها هستند.

Aspose.Slides for JasperReports امکان صادرات هر گزارشی را به فرمت PPT یا PPS فراهم می‌کند.

### **مثال خروجی**
کلاس ASPptExporter کلاس ASAbstractExporter را گسترش می‌دهد بنابراین می‌توان آن را به همان شیوه‌ای که سایر صادرکننده‌های استاندارد استفاده می‌شوند، به کار برد. این مثال کوتاه کد معمول و تصویر صفحه‌ای از گزارشی که در MS PowerPoint مشاهده می‌شود را نشان می‌دهد. مثال‌های تفصیلی را می‌توان در گزارش‌های نمایشی ارائه‌شده یافت.

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**ارائه تولید‌شده با دموی JasperReports xmldatasource**

![ارائه تولید‌شده با JasperReports](product-overview_2.png)