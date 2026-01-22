---
title: استيراد العروض التقديمية من PDF أو HTML على Android
linktitle: استيراد عرض تقديمي
type: docs
weight: 60
url: /ar/androidjava/import-presentation/
keywords:
- استيراد عرض تقديمي
- استيراد شريحة
- استيراد PDF
- استيراد HTML
- PDF إلى عرض تقديمي
- PDF إلى PPT
- PDF إلى PPTX
- PDF إلى ODP
- HTML إلى عرض تقديمي
- HTML إلى PPT
- HTML إلى PPTX
- HTML إلى ODP
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "استيراد مستندات PDF وHTML إلى عروض PowerPoint وOpenDocument في Java باستخدام Aspose.Slides لنظام Android لمعالجة الشرائح بسلاسة وذات أداء عالي."
---

باستخدام [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/)، يمكنك استيراد العروض التقديمية من ملفات بصيغ أخرى. توفر Aspose.Slides الفئة [SlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) للسماح لك باستيراد العروض من ملفات PDF، مستندات HTML، إلخ.

## **استيراد PowerPoint من PDF**

في هذه الحالة، يمكنك تحويل PDF إلى عرض تقديمي PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/).
2. استدعاء طريقة [addFromPdf()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) وتمرير ملف PDF.
3. استخدام طريقة [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بصيغة PowerPoint.

يوضح هذا الشيفرة Java عملية تحويل PDF إلى PowerPoint:
```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert  title="Tip" color="primary" %}} 
قد ترغب في تجربة تطبيق الويب **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) لأنه تنفيذ مباشر للعملية الموضحة هنا. 
{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، يمكنك تحويل مستند HTML إلى عرض تقديمي PowerPoint.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/).
2. استدعاء طريقة [addFromHtml()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) وتمرير ملف PDF.
3. استخدام طريقة [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بصيغة PowerPoint.

يوضح هذا الشيفرة Java عملية تحويل HTML إلى PowerPoint: 
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


## **الأسئلة المتكررة**

**هل يتم الحفاظ على الجداول عند استيراد PDF، وهل يمكن تحسين اكتشافها؟**

يمكن اكتشاف الجداول أثناء الاستيراد؛ يحتوي [PdfImportOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfimportoptions/) على طريقة [setDetectTables](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) التي تفعيل التعرف على الجداول. تعتمد الفعالية على بنية ملف PDF.