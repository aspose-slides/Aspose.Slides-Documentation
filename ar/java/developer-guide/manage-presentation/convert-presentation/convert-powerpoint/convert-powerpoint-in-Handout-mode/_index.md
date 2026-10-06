---
title: تحويل عروض PowerPoint إلى وضع النشرة باستخدام Java
linktitle: وضع النشرة
type: docs
weight: 150
url: /ar/java/convert-powerpoint-in-handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض
- وضع النشرة
- نشرة
- PPT
- PPTX
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "قم بتحويل العروض إلى نشرة في Java. اضبط عدد الشرائح في الصفحة، احتفظ بالملاحظات، صدّر إلى PDF أو صور باستخدام Aspose.Slides، مع كود Java مثال. جرّبه مجانًا."
---
## **المقدمة**

Aspose.Slides يسمح لك بتحويل العروض التقديمية إلى صيغ إخراج تدعم وضع النشرة. في هذا الوضع، يتم ترتيب عدة شرائح على صفحة واحدة، وهو مفيد لطباعة مواد العرض للمؤتمرات والندوات والفعاليات المماثلة.

يتم تكوين وضع النشرة عبر الطريقة `setSlidesLayoutOptions`، المتاحة في [IPdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipdfoptions/)، [IRenderingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/irenderingoptions/)، [IHtmlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ihtmloptions/)، و[ITiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiffoptions/). لتحديد تخطيط النشرة، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/handoutlayoutingoptions/).

لتعيين أبعاد الصفحة وتوجيهها قبل التصدير، راجع [Notes Page Size](/slides/ar/java/notes-size/).

## **تصدير وضع النشرة**

لتصدير عرض تقديمي بوضع النشرة، قم بتعيين الطريقة `setSlidesLayoutOptions` لخيارات التصدير المستهدفة وعيّن كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/handoutlayoutingoptions/) يحدد عدد الشرائح في كل صفحة ومعلمات العرض ذات الصلة.

فيما يلي مثال على الكود يوضح كيفية تحويل عرض تقديمي إلى PDF بوضع النشرة.

```java
import com.aspose.slides.*;

// تحميل عرض تقديمي.
Presentation presentation = new Presentation("sample.pptx");
try {
    // تعيين خيارات التصدير.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 شرائح على صفحة واحدة أفقيًا
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // طباعة أرقام الشرائح
    slidesLayoutOptions.setPrintFrameSlide(true);                     // طباعة إطار حول الشرائح
    slidesLayoutOptions.setPrintComments(false);                      // لا تعليقات

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // تصدير العرض التقديمي إلى PDF بالتخطيط المختار.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" title="Warning" %}}
ضع في اعتبارك أن الطريقة `setSlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند التصيير كصور.
{{% /alert %}} 

## **الأسئلة المتكررة**

**ما هو الحد الأقصى لعدد صور الشرائح المصغرة في كل صفحة بوضع النشرة؟**

يدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/ar/java/com.aspose.slides/handouttype/) حتى 9 صور مصغرة في الصفحة مع ترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تحديد شبكة مخصصة، مثل 5 أو 8 شرائح في الصفحة؟**

لا. يتم التحكم في عدد وترتيب الصور المصغرة بدقة بواسطة الفئة [HandoutType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/handouttype/)، ولا يتم دعم تخطيطات عشوائية.

**هل يمكنني تضمين الشرائح المخفية في مخرجات النشرة؟**

نعم. فعِّل الشرائح المخفية باستخدام الطريقة `setShowHiddenSlides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/htmloptions/)، أو [TiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/).