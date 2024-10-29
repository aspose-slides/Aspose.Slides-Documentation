---
title: استيراد العرض التقديمي
type: docs
weight: 60
url: /ar/java/import-presentation/
keywords: "استيراد باوربوينت، PDF إلى عرض تقديمي، PDF إلى PPTX، PDF إلى PPT، جافا، Aspose.Slides لجافا"
description: "استيراد العرض التقديمي من PDF. تحويل PDF إلى باوربوينت"
---

باستخدام [**Aspose.Slides لجافا**](https://products.aspose.com/slides/java/)، يمكنك استيراد العروض التقديمية من الملفات بتنسيقات أخرى. يوفر Aspose.Slides فئة [SlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/) للسماح لك باستيراد العروض التقديمية من PDF، ومستندات HTML، إلخ.

## **استيراد باوربوينت من PDF**

في هذه الحالة، ستحصل على تحويل PDF إلى عرض تقديمي باوربوينت.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/) .
2. استدعِ طريقة [addFromPdf()](https://reference.aspose.com/slides/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) ومرر ملف PDF.
3. استخدم طريقة [save()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بتنسيق باوربوينت.

يظهر هذا الكود بلغة جافا عملية تحويل PDF إلى باوربوينت:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="نصيحة" color="primary" %}} 

قد ترغب في الاطلاع على تطبيق **Aspose المجاني** [PDF إلى باوربوينت](https://products.aspose.app/slides/import/pdf-to-powerpoint) لأنه تطبيق مباشر للعملية الموضحة هنا. 

{{% /alert %}} 

## **استيراد باوربوينت من HTML**

في هذه الحالة، ستحصل على تحويل مستند HTML إلى عرض تقديمي باوربوينت.

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/) .
2. استدعِ طريقة [addFromHtml()](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) ومرر ملف PDF.
3. استخدم طريقة [save()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بتنسيق باوربوينت.

يظهر هذا الكود بلغة جافا عملية تحويل HTML إلى باوربوينت: 

```java
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

{{% alert title="ملاحظة" color="warning" %}} 

يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى تنسيقات ملفات شائعة أخرى: 

* [HTML إلى صورة](https://products.aspose.com/slides/java/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/java/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/java/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/java/conversion/html-to-tiff/)

{{% /alert %}}