---
title: استيراد العروض التقديمية من PDF أو HTML في JavaScript
linktitle: استيراد عرض تقديمي
type: docs
weight: 60
url: /ar/nodejs-java/import-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "استيراد مستندات PDF وHTML إلى عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js لمعالجة شرائح سلسة وعالية الأداء."
---

باستخدام [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/)، يمكنك استيراد العروض التقديمية من ملفات بصيغ أخرى. توفر Aspose.Slides الفئة [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) لتمكينك من استيراد العروض من ملفات PDF، مستندات HTML، وما إلى ذلك.

## **استيراد PowerPoint من PDF**

في هذه الحالة، يمكنك تحويل ملف PDF إلى عرض PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/).
2. استدعاء الطريقة [addFromPdf()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) وتمرير ملف PDF.
3. استخدام الطريقة [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بصيغة PowerPoint.

هذا الكود JavaScript يوضح عملية تحويل PDF إلى PowerPoint:
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


{{% alert  title="Tip" color="primary" %}} 
قد ترغب في تجربة تطبيق الويب **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) لأنه تنفيذ مباشر للعملية الموضحة هنا.
{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، يمكنك تحويل مستند HTML إلى عرض PowerPoint.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/).
2. استدعاء الطريقة [addFromHtml()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) وتمرير ملف HTML.
3. استخدام الطريقة [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بصيغة PowerPoint.

هذا الكود JavaScript يوضح عملية تحويل HTML إلى PowerPoint:
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


## **الأسئلة الشائعة**

**هل يتم الحفاظ على الجداول عند استيراد PDF، وهل يمكن تحسين اكتشافها؟**

يمكن اكتشاف الجداول أثناء الاستيراد؛ تتضمن الفئة [PdfImportOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/) الطريقة [setDetectTables](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) التي تمكّن من التعرف على الجداول. وتعتمد الفعالية على بنية ملف PDF.