---
title: ایجاد و جاسازی نمودارهای اکسل به‌عنوان اشیاء OLE با استفاده از VSTO و Aspose.Slides برای جاوا
linktitle: ایجاد و جاسازی نمودارهای اکسل به‌عنوان اشیاء OLE
type: docs
weight: 60
url: /fa/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- ایجاد نمودار
- جاسازی نمودار اکسل
- شیء OLE
- مهاجرت
- VSTO
- اتوماسیون Office
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "از اتوماسیون Microsoft Office به Aspose.Slides برای جاوا مهاجرت کنید و نمودارهای اکسل را به‌عنوان اشیاء OLE در اسلایدهای PowerPoint (PPT، PPTX) در جاوا جاسازی کنید."
---
{{% alert color="primary" %}} 

نمودارها نمایش‌های تصویری از داده‌های شما هستند و به‌طور گسترده‌ای در اسلایدهای ارائه استفاده می‌شوند. این مقاله کد لازم برای ایجاد و جاسازی یک نمودار اکسل به‌عنوان شیء OLE در اسلاید PowerPoint را به‌صورت برنامه‌نویسی با استفاده از [VSTO](/slides/fa/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) و [Aspose.Slides for Java](/slides/fa/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) نشان می‌دهد.

{{% /alert %}} 
## **ایجاد و جاسازی یک نمودار اکسل**
دو مثال کد زیر طولانی و جزئی هستند چون کاری که توصیف می‌کنند پیچیده است. شما یک کتاب‌کار Microsoft Excel ایجاد می‌کنید، یک نمودار می‌سازید و سپس ارائه Microsoft PowerPoint را می‌سازید که نمودار را در آن جاسازی می‌کنید. اشیاء OLE شامل لینک‌هایی به سند اصلی هستند، به‌طوری که کاربری که روی فایل جاسازی‌شده دوبار کلیک می‌کند، فایل و برنامه‌اش را اجرا می‌کند.
### **مثال VSTO**
با استفاده از VSTO، مراحل زیر انجام می‌شود:

1. یک نمونه از شیء Microsoft Excel ApplicationClass ایجاد کنید.
1. یک کتاب‌کار جدید با یک شیت در آن بسازید.
1. یک نمودار به شیت اضافه کنید.
1. کتاب‌کار را ذخیره کنید.
1. کتاب‌کار Excel حاوی شیت با داده‌های نمودار را باز کنید.
1. مجموعه ChartObjects را برای شیت دریافت کنید.
1. نمودار مورد نظر برای کپی کردن را دریافت کنید.
1. یک ارائه Microsoft PowerPoint ایجاد کنید.
1. یک اسلاید خالی به ارائه اضافه کنید.
1. نمودار را از شیت Excel به کلیپ‌بورد کپی کنید.
1. نمودار را در ارائه PowerPoint چسباندن کنید.
1. موقعیت نمودار را روی اسلاید تنظیم کنید.
1. ارائه را ذخیره کنید.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **مثال Aspose.Slides for Java**
با استفاده از Aspose.Slides for .NET، مراحل زیر انجام می‌شود:

1. یک کتاب‌کار با استفاده از Aspose.Cells for Java ایجاد کنید.
1. یک نمودار Microsoft Excel ایجاد کنید.
1. اندازه OLE نمودار اکسل را تنظیم کنید.
1. تصویر نمودار را دریافت کنید.
1. نمودار اکسل را به‌عنوان شیء OLE در ارائه PPTX داخل Aspose.Slides for Java جاسازی کنید.
1. تصویر تغییر یافته شیء را با تصویری که در گام 3 به‌دست آمده است، جایگزین کنید تا مشکل تغییر شیء برطرف شود.
1. ارائه خروجی را در فرمت PPTX بر روی دیسک بنویسید.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}