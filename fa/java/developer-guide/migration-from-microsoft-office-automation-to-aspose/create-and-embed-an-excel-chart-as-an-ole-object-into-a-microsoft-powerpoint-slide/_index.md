---
title: ایجاد و جاسازی نمودارهای اکسل به عنوان اشیاء OLE با استفاده از VSTO و Aspose.Slides برای Java
linktitle: ایجاد و جاسازی نمودارهای اکسل به عنوان اشیاء OLE
type: docs
weight: 60
url: /fa/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- ایجاد نمودار
- جاسازی نمودار اکسل
- شی OLE
- مهاجرت
- VSTO
- اتوماسیون Office
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "از اتوماسیون Microsoft Office به Aspose.Slides برای Java مهاجرت کنید و نمودارهای اکسل را به عنوان اشیاء OLE در اسلایدهای PowerPoint (PPT، PPTX) با Java جاسازی کنید."
---
{{% alert color="info" %}} 

نمودارها نمایش‌های بصری داده‌های شما هستند و به طور گسترده‌ای در اسلایدهای ارائه استفاده می‌شوند. این مقاله کد لازم برای ایجاد و جاسازی یک نمودار اکسل به عنوان یک شی OLE در اسلاید PowerPoint را به‌صورت برنامه‌نویسی نشان می‌دهد با استفاده از [VSTO](/slides/fa/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) و [Aspose.Slides for Java](/slides/fa/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **ایجاد و جاسازی یک نمودار اکسل**
دو مثال کد زیر طولانی و جزئیات‌دار هستند زیرا کاری که توصیف می‌کنند پیچیده است. شما یک workbook مایکروسافت اکسل ایجاد می‌کنید، یک نمودار می‌سازید و سپس ارائهٔ Microsoft PowerPoint را که نمودار درون آن جاسازی می‌شود ایجاد می‌کنید. اشیای OLE شامل پیوندهایی به سند اصلی هستند به‌طوری که کاربری که روی فایل جاسازی‌شده دو بار کلیک کند، فایل و برنامهٔ آن را اجرا می‌کند.
### **مثال VSTO**
با استفاده از VSTO، مراحل زیر انجام می‌شود:

1. یک نمونه از شیء Microsoft Excel ApplicationClass ایجاد کنید.
1. یک workbook جدید با یک sheet درون آن ایجاد کنید.
1. نمودار را به sheet اضافه کنید.
1. workbook را ذخیره کنید.
1. workbook اکسل حاوی worksheet با داده‌های نمودار را باز کنید.
1. مجموعه ChartObjects را برای sheet دریافت کنید.
1. نموداری که باید کپی شود را دریافت کنید.
1. یک ارائه Microsoft PowerPoint ایجاد کنید.
1. یک اسلاید خالی به ارائه اضافه کنید.
1. نمودار را از worksheet اکسل به کلیپ‌بورد کپی کنید.
1. نمودار را در ارائه PowerPoint بچسبانید.
1. نمودار را بر روی اسلاید موقعیت‌دهی کنید.
1. ارائه را ذخیره کنید.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **مثال Aspose.Slides for Java**
با استفاده از Aspose.Slides برای .NET، مراحل زیر انجام می‌شود:

1. یک workbook با استفاده از Aspose.Cells برای Java ایجاد کنید.
1. یک نمودار Microsoft Excel ایجاد کنید.
1. اندازه OLE نمودار اکسل را تنظیم کنید.
1. یک تصویر از نمودار دریافت کنید.
1. نمودار اکسل را به عنوان یک شی OLE درون ارائه PPTX با استفاده از Aspose.Slides برای Java جاسازی کنید.
1. تصویر شی تغییر یافته را با تصویری که در مرحله 3 به‌دست آمده است جایگزین کنید تا مشکل شی تغییر یافته برطرف شود.
1. ارائه خروجی را به‌صورت فرمت PPTX بر روی دیسک بنویسید.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}