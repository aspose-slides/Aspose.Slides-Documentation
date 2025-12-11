---
title: استيراد عروض تقديمية من PDF أو HTML على Android
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
description: "استيراد مستندات PDF و HTML إلى عروض PowerPoint و OpenDocument في Java باستخدام Aspose.Slides لنظام Android، لضمان معالجة شرائح سلسة وعالية الأداء."
---

باستخدام [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/)، يمكنك استيراد العروض التقديمية من ملفات بصيغ أخرى. يوفر Aspose.Slides الفئة [SlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) للسماح لك باستيراد العروض التقديمية من ملفات PDF ووثائق HTML، وما إلى ذلك.

## **استيراد PowerPoint من PDF**

في هذه الحالة، ستحول ملف PDF إلى عرض تقديمي بصيغة PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/).
2. استدعاء الطريقة [addFromPdf()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) وتمرير ملف PDF.
3. استخدام الطريقة [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بصيغة PowerPoint.

يوضح هذا كود Java عملية التحويل من PDF إلى PowerPoint:
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
قد ترغب في تجربة تطبيق الويب **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) لأنه يعد تنفيذًا حيا للعملية الموضحة هنا. 
{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، ستحول مستند HTML إلى عرض تقديمي بصيغة PowerPoint.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/).
2. استدعاء الطريقة [addFromHtml()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) وتمرير ملف PDF.
3. استخدام الطريقة [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بصيغة PowerPoint.

يوضح هذا كود Java عملية التحويل من HTML إلى PowerPoint: 
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


## **الأسئلة الشائعة**

**هل يتم الحفاظ على الجداول عند استيراد PDF، وهل يمكن تحسين اكتشافها؟**

يمكن اكتشاف الجداول أثناء الاستيراد؛ تحتوي الفئة [PdfImportOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfimportoptions/) على الطريقة [setDetectTables](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) التي تمكّن من التعرف على الجداول. تعتمد الفعالية على بنية ملف PDF.

{{% alert title="Note" color="warning" %}} 
يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى تنسيقات ملفات شائعة أخرى: 

* [HTML إلى صورة](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}