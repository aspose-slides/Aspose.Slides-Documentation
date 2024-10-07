---
title: استيراد العرض التقديمي
type: docs
weight: 60
url: /androidjava/import-presentation/
keywords: "استيراد PowerPoint، PDF إلى عرض تقديمي، PDF إلى PPTX، PDF إلى PPT، Java، Aspose.Slides لـ Android عبر Java"
description: "استيراد عرض تقديمي PowerPoint من PDF. تحويل PDF إلى PowerPoint"
---

باستخدام [**Aspose.Slides لـ Android عبر Java**](https://products.aspose.com/slides/androidjava/)، يمكنك استيراد العروض التقديمية من الملفات بصيغ أخرى. توفر Aspose.Slides فئة [SlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) للسماح لك باستيراد العروض التقديمية من PDF، مستندات HTML، إلخ.

## **استيراد PowerPoint من PDF**

في هذه الحالة، يمكنك تحويل PDF إلى عرض تقديمي PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/).
2. استدعي طريقة [addFromPdf()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) ومرر ملف PDF.
3. استخدم طريقة [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بصيغة PowerPoint.

هذا الرمز بلغة Java يوضح عملية تحويل PDF إلى PowerPoint:

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

قد ترغب في الاطلاع على تطبيق الويب **Aspose المجاني** [PDF إلى PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) لأنه تطبيق مباشر للعملية الموصوفة هنا. 

{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، يمكنك تحويل مستند HTML إلى عرض تقديمي PowerPoint.

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/).
2. استدعي طريقة [addFromHtml()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) ومرر ملف HTML.
3. استخدم طريقة [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بصيغة PowerPoint.

هذا الرمز بلغة Java يوضح عملية تحويل HTML إلى PowerPoint:

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

يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى صيغ ملفات شعبية أخرى: 

* [HTML إلى صورة](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}