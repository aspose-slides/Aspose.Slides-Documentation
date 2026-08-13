---
title: استيراد عروض تقديمية من PDF أو HTML في Java
linktitle: استيراد عرض تقديمي
type: docs
weight: 60
url: /ar/java/import-presentation/
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
- Java
- Aspose.Slides
description: "استيراد مستندات PDF وHTML بسهولة إلى عروض PowerPoint وOpenDocument في Java باستخدام Aspose.Slides لمعالجة الشرائح بأداء عالٍ وسلس."
---
## **المقدمة**

باستخدام Aspose.Slides، يمكنك استيراد العروض التقديمية من ملفات بصيغ أخرى. يقدم Aspose.Slides فئة [SlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidecollection/) التي تسمح لك باستيراد العروض التقديمية من مستندات PDF وHTML.

## **استيراد PowerPoint من PDF**

في هذه الحالة، ستحول ملف PDF إلى عرض PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/) .
2. استدعي الطريقة [addFromPdf()](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) ومرّر ملف PDF.
3. استخدم الطريقة [save()](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بتنسيق PowerPoint.

يظهر هذا الكود Java عملية التحويل من PDF إلى PowerPoint:

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

{{% alert  title="Tip" color="info" %}} 

قد ترغب في تجربة تطبيق الويب **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/ar/import/pdf-to-powerpoint) لأنه تنفيذ حي للعملية الموضحة هنا. 

{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، ستحول مستند HTML إلى عرض PowerPoint.

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/) .
2. استدعي الطريقة [addFromHtml()](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) ومرّر تدفقًا يحتوي مستند HTML.
3. استخدم الطريقة [save()](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#save-java.lang.String-int-) لحفظ الملف بتنسيق PowerPoint.

يظهر هذا الكود Java عملية التحويل من HTML إلى PowerPoint: 

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

## **الأسئلة الشائعة**

### هل يتم الحفاظ على الجداول عند استيراد PDF، وهل يمكن تحسين كشفها؟

يمكن كشف الجداول أثناء الاستيراد؛ يحتوي [PdfImportOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfimportoptions/) على طريقة [setDetectTables](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) التي تمكن من التعرف على الجداول. تعتمد الفعالية على بنية ملف PDF.

{{% alert title="Note" color="warning" %}} 

يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى صيغ ملفات شائعة أخرى: 

* [HTML to image](https://products.aspose.com/slides/ar/java/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/ar/java/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/ar/java/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/ar/java/conversion/html-to-tiff/)

{{% /alert %}}