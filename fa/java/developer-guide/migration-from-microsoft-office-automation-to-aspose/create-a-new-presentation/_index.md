---
title: ایجاد ارائه‌های جدید با استفاده از VSTO و Aspose.Slides برای Java
linktitle: ایجاد ارائه جدید
type: docs
weight: 10
url: /fa/java/create-a-new-presentation/
keywords:
- ایجاد ارائه
- ارائه جدید
- مهاجرت
- VSTO
- اتوماسیون آفیس
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "از اتوماسیون Microsoft Office به Aspose.Slides برای Java مهاجرت کنید و ارائه‌های جدید PowerPoint (PPT، PPTX) را در Java با کد تمیز و قابل اعتماد ایجاد کنید."
---
{{% alert color="info" %}} 

VSTO برای این منظور توسعه یافت که به توسعه‌دهندگان امکان ساخت برنامه‌هایی را بدهد که بتوانند داخل Microsoft Office اجرا شوند. VSTO مبتنی بر COM است اما داخل یک شیء .NET بسته‌بندی شده است تا در برنامه‌های .NET قابل استفاده باشد. VSTO به پشتیبانی چارچوب .NET و همچنین زمان اجرا پایه CLR مایکروسافت آفیس نیاز دارد. اگرچه می‌تواند برای ساخت افزونه‌های Microsoft Office استفاده شود، استفاده از آن به عنوان یک مؤلفه سمت سرور تقریباً غیرممکن است. همچنین مشکلات جدی در استقرار دارد.

Aspose.Slides برای Java یک مؤلفه است که می‌تواند ارائه‌های Microsoft PowerPoint را همانند VSTO دستکاری کند، اما مزایای متعددی دارد:

- Aspose.Slides فقط شامل کد مدیریت‌شده است و نیازی به نصب زمان اجرا Microsoft Office ندارد.
- می‌تواند به عنوان یک مؤلفه سمت مشتری یا به عنوان یک مؤلفه سمت سرور استفاده شود.
- استقرار آسان است زیرا Aspose.Slides در یک فایل jar واحد قرار دارد.

{{% /alert %}} 
## **ایجاد یک ارائه**
در زیر دو مثال کد آورده شده است که نشان می‌دهند چگونه می‌توان از VSTO و Aspose.Slides برای Java برای رسیدن به هدف یکسان استفاده کرد. مثال اول [VSTO](/slides/fa/java/create-a-new-presentation/); مثال دوم [the second example](/slides/fa/java/create-a-new-presentation/) از Aspose.Slides استفاده می‌کند.
### **مثال VSTO**
**خروجی VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **مثال Aspose.Slides برای Java**
**خروجی Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}