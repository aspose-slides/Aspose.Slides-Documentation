---
title: تحويل عروض PowerPoint إلى وضع Handout في جافا
linktitle: وضع Handout
type: docs
weight: 150
url: /ar/java/convert-powerpoint-in-Handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- وضع النسخة المطبوعة
- نسخة مطبوعة
- PPT
- PPTX
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحويل العروض التقديمية إلى نسخ مطبوعة في جافا. ضبط عدد الشرائح في الصفحة، الحفاظ على الملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides، مع مثال كود جافا. جرّبه مجانًا."
---

Aspose.Slides توفر القدرة على تحويل العروض التقديمية إلى صيغ متعددة، بما في ذلك إنشاء نسخ مطبوعّة في وضع Handout. يتيح هذا الوضع تكوين عدد الشرائح التي تظهر على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تفعيل هذا الوضع عن طريق ضبط طريقة `setSlidesLayoutOptions` في واجهات [IPdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ipdfoptions/)، [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/irenderingoptions/)، [IHtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ihtmloptions/)، و[ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/itiffoptions/).

لتكوين وضع Handout، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/handoutlayoutingoptions/) الذي يحدد عدد الشرائح التي توضع على صفحة واحدة وغيرها من معلمات العرض.

فيما يلي مثال على الشيفرة يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع Handout.
```java
// تحميل عرض تقديمي.
Presentation presentation = new Presentation("sample.pptx");
try {
    // تعيين خيارات التصدير.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 شرائح على صفحة واحدة أفقياً
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // طباعة أرقام الشرائح
    slidesLayoutOptions.setPrintFrameSlide(true);                     // طباعة إطار حول الشرائح
    slidesLayoutOptions.setPrintComments(false);                      // بدون تعليقات

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // تصدير العرض التقديمي إلى PDF باستخدام التخطيط المختار.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```


{{% alert color="warning" %}} 
ضع في اعتبارك أن طريقة `setSlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند التصيّر كصور.
{{% /alert %}}