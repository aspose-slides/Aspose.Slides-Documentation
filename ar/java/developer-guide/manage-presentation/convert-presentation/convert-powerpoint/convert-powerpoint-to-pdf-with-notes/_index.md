---
title: تحويل PowerPoint إلى PDF مع الملاحظات
type: docs
weight: 50
url: /java/convert-powerpoint-to-pdf-with-notes/
keywords: "تحويل PowerPoint إلى PDF مع الملاحظات في جافا"
description: "تحويل PowerPoint إلى PDF مع الملاحظات في جافا"
---

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**
يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند PDF مع ملاحظات بحجم شريحة مخصص. حيث يساوي كل بوصة 72.

```java
// إنشاء كائن Presentation يمثل ملف العرض التقديمي
Presentation presIn = new Presentation("SelectedSlides.pptx");
Presentation presOut = new Presentation();
try {
    ISlide slide = presIn.getSlides().get_Item(0);
    presOut.getSlides().insertClone(0, slide);
    
    // إعداد نوع وحجم الشريحة
    presOut.getSlideSize().setSize(612F, 792F,SlideSizeScaleType.EnsureFit);
        
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);

    presOut.save("PDF-SelectedSlide.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presIn != null) presIn.dispose();
    if (presOut != null) presOut.dispose();
}
```

## **تحويل PowerPoint إلى PDF في عرض شريحة الملاحظات**
يمكن استخدام طريقة [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) المعرضة من فئة [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) لتحويل العرض التقديمي بالكامل إلى PDF في عرض شريحة الملاحظات. تُحدث مقاطع الشفرات أدناه العرض التقديمي النموذجي إلى PDF في عرض شريحة الملاحظات.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);

    pres.save(resourcesOutputPath+"PDF-Notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على محول Aspose [PowerPoint إلى PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) أو [PPT إلى PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}} 