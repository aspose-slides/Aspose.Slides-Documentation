---
title: "وارد کردن ارائه‌ها از PDF یا HTML در Android"
linktitle: "وارد کردن ارائه"
type: docs
weight: 60
url: /fa/androidjava/import-presentation/
keywords:
- "وارد کردن ارائه"
- "وارد کردن اسلاید"
- "وارد کردن PDF"
- "وارد کردن HTML"
- "PDF به ارائه"
- "PDF به PPT"
- "PDF به PPTX"
- "PDF به ODP"
- "HTML به ارائه"
- "HTML به PPT"
- "HTML به PPTX"
- "HTML به ODP"
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "اسناد PDF و HTML را به ارائه‌های PowerPoint و OpenDocument در Java با Aspose.Slides برای Android وارد کنید تا پردازش اسلایدهای یکپارچه و با عملکرد بالا فراهم شود."
---
## **مقدمه**

با استفاده از [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/fa/androidjava/)، می‌توانید ارائه‌ها را از فایل‌های با فرمت‌های دیگر وارد کنید. Aspose.Slides کلاس [SlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidecollection/) را فراهم می‌کند تا بتوانید ارائه‌ها را از PDF‌ها، اسناد HTML و غیره وارد کنید.

## **وارد کردن PowerPoint از PDF**

در این حالت، می‌توانید یک PDF را به یک ارائه PowerPoint تبدیل کنید.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/) ایجاد کنید.
2. متد [addFromPdf()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) را فراخوانی کنید و فایل PDF را به آن پاس دهید.
3. از متد [save()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) برای ذخیره فایل در فرمت PowerPoint استفاده کنید.

این کد Java عملیات تبدیل PDF به PowerPoint را نشان می‌دهد:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="نکته" color="info" %}} 
ممکن است بخواهید برنامه وب **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/fa/import/pdf-to-powerpoint) را بررسی کنید، زیرا این یک پیاده‌سازی زنده از فرایند توضیح داده شده در اینجا است. 
{{% /alert %}} 

## **وارد کردن PowerPoint از HTML**

در این حالت، می‌توانید یک سند HTML را به یک ارائه PowerPoint تبدیل کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/) ایجاد کنید.
2. متد [addFromHtml()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) را فراخوانی کنید و یک جریان (stream) حاوی سند HTML را به آن پاس دهید.
3. از متد [save()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) برای ذخیره فایل در فرمت PowerPoint استفاده کنید.

این کد Java عملیات تبدیل HTML به PowerPoint را نشان می‌دهد: 

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **سوالات متداول**

### آیا جداول هنگام وارد کردن PDF حفظ می‌شوند و آیا می‌توان تشخیص آن‌ها را بهبود داد؟

جداول می‌توانند در هنگام وارد کردن شناسایی شوند؛ [PdfImportOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfimportoptions/) شامل متد [setDetectTables](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) است که تشخیص جدول را فعال می‌کند. کارایی بستگی به ساختار PDF دارد.