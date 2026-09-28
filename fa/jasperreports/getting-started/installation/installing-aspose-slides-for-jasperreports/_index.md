---
title: نصب Aspose.Slides برای JasperReports
type: docs
weight: 40
url: /fa/jasperreports/installing-aspose-slides-for-jasperreports/
description: "جاروهای Aspose.Slides برای JasperReports که با نسخهٔ JasperReports شما مطابقت دارند را انتخاب کنید و آن‌ها را به JasperReports، یک پروژه Maven یا JasperReports Server اضافه کنید."
---
## **جاروهای مورد نیاز برای نسخه JasperReports خود را انتخاب کنید**

Aspose.Slides for JasperReports به‌صورت یک فایل ZIP در [صفحه دانلود](https://releases.aspose.com/slides/jasperreport/) توزیع می‌شود. پوشه *lib* آن یک زیرپوشه برای هر بازهٔ نسخهٔ JasperReports دارد. جاروها را از زیرپوشه‌ای بردارید که نسخهٔ JasperReports شما را پوشش می‌دهد:

| نسخه JasperReports | زیرپوشه‌ی *lib* |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

زیرپوشه‌ای برای JasperReports 6.17.0 یا نسخه‌های بعدی، از جمله JasperReports 7، وجود ندارد. زیرپوشهٔ *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* هیچ جارویی ندارد، فقط یک یادآوری وجود دارد که پشتیبانی از این نسخه‌ها در Aspose.Slides for JasperReports 17.6 پایان یافته است.

هر زیرپوشه دو جاروفایل دارد؛ *xx.x* در نام آن‌ها نشان‌دهندهٔ نسخهٔ محصول است:

- *aspose.slides.jasperreports.library-xx.x.jar* شامل صادرکننده‌های JasperReports Library (`ASPptExporter`، `ASPptxExporter`، `ASPdfExporter` و `ASHtmlExporter`) و کلاس `License` است.
- *aspose.slides.jasperreports.server-xx.x.jar* شامل عملیات صادرات برای JasperReports Server است. این فایل بر پایهٔ جاروی کتابخانه ساخته شده، بنابراین سرور همیشه هر دو جاروفایل را از یک زیرپوشهٔ یکسان نیاز دارد.

## **جاروی کتابخانه را به JasperReports یا برنامهٔ خود اضافه کنید**

*aspose.slides.jasperreports.library-xx.x.jar* را از زیرپوشهٔ متناظر به پوشهٔ *lib* JasperReports یا به مسیر کلاس‌پث برنامهٔ خود کپی کنید. سپس برنامهٔ شما می‌تواند صادرکننده‌ها را از طریق کد ایجاد کند.

{{% alert color="info" title="توجه" %}}
در لینوکس، JasperReports به fontconfig و حداقل یک قلم نصب‌شده برای پر کردن گزارش نیاز دارد. بدون قلم‌ها، پر کردن گزارش با خطای «Error initializing graphic environment» ناموفق می‌شود.
{{% /alert %}}

## **جاروی کتابخانه را به یک پروژهٔ Maven اضافه کنید**

این جاروفایل در فایل ZIP آمده و از مخزن Maven در دسترس نیست. برای استفاده در ساخت Maven، آن را در مخزن محلی Maven خود نصب کنید. برای نسخه 26.6، این فرمان را در پوشه‌ای که جاروفایل را دارد اجرا کنید:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

سپس آن را به وابستگی‌ها در *pom.xml* اضافه کنید، به‌همراه نسخهٔ JasperReports که زیرپوشهٔ جاروفایل آن را پوشش می‌دهد:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

شناسه‌های گروه و آر artifact همان‌هایی هستند که در فرمان نصب انتخاب می‌کنید؛ فقط باید هم‌خوانی داشته باشند. یک پروژهٔ کامل که از JasperReports 6.16.0 استفاده می‌کند در [Your first export](/slides/fa/jasperreports/#your-first-export) موجود است.

## **جاروفایل‌ها را به JasperReports Server اضافه کنید**

هر دو جاروفایل را از زیرپوشهٔ متناظر به پوشهٔ *WEB-INF/lib* برنامهٔ وب JasperReports Server کپی کنید، سپس صادرکننده‌ها را همان‌طور که در [Integration with JasperServer](/slides/fa/jasperreports/integration-with-jasperserver/) توضیح داده شده است، ثبت کنید.