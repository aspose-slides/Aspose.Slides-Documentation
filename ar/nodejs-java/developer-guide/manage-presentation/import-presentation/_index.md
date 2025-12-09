---
title: استيراد عرض تقديمي
type: docs
weight: 60
url: /ar/nodejs-java/import-presentation/
keywords: "استيراد PowerPoint, PDF إلى عرض تقديمي, PDF إلى PPTX, PDF إلى PPT, Java, Aspose.Slides for Node.js via Java"
description: "استيراد عرض تقديمي PowerPoint من PDF. تحويل PDF إلى PowerPoint"
---

باستخدام [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/)، يمكنك استيراد العروض التقديمية من ملفات بصيغ أخرى. توفر Aspose.Slides الفئة [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) للسماح لك باستيراد العروض التقديمية من ملفات PDF، ومستندات HTML، وغيرها.

## **استيراد PowerPoint من PDF**

في هذه الحالة، ستحول ملف PDF إلى عرض تقديمي PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/) .
2. استدعِ الطريقة [addFromPdf()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) ومرّر ملف PDF.
3. استخدم الطريقة [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بصيغة PowerPoint.

يوضح هذا الشيفرة JavaScript عملية التحويل من PDF إلى PowerPoint:
```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="نصيحة" color="primary" %}} 

قد ترغب في تجربة تطبيق الويب **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) لأنه تنفيذ حي للعملية الموضحة هنا. 

{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، ستحول مستند HTML إلى عرض تقديمي PowerPoint.

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/) .
2. استدعِ الطريقة [addFromHtml()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) ومرّر ملف HTML.
3. استخدم الطريقة [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بصيغة PowerPoint.

يوضح هذا الشيفرة JavaScript عملية التحويل من HTML إلى PowerPoint:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var htmlStream = java.newInstanceSync("java.io.FileInputStream", "page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) {
            htmlStream.close();
        }
    }
    presentation.save("MyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **الأسئلة المتكررة**

**هل يتم حفظ الجداول عند استيراد PDF، وهل يمكن تحسين اكتشافها؟**

يمكن اكتشاف الجداول أثناء الاستيراد؛ تضم فئة [PdfImportOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/) طريقة [setDetectTables](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) التي تُفعّل التعرف على الجداول. تعتمد الفعالية على بنية ملف PDF.

{{% alert title="ملاحظة" color="warning" %}} 

يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى صيغ ملفات شائعة أخرى: 

* [HTML إلى صورة](https://products.aspose.com/slides/nodejs-java/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/nodejs-java/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/nodejs-java/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/nodejs-java/conversion/html-to-tiff/)

{{% /alert %}}