---
title: تحويل عروض PowerPoint التقديمية إلى وضع النشرة باستخدام Java
linktitle: وضع النشرة
type: docs
weight: 150
url: /ar/java/convert-powerpoint-in-handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- وضع النشرة
- نشرة
- PPT
- PPTX
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحويل العروض التقديمية إلى نشرات باستخدام Java. ضبط عدد الشرائح في كل صفحة، الحفاظ على الملاحظات، تصدير إلى PDF أو صور باستخدام Aspose.Slides، مع مثال كود Java. جرّبه مجانًا."
---
## **مقدمة**

تتيح لك Aspose.Slides تحويل العروض التقديمية إلى صيغ إخراج تدعم وضع النشرة. في هذا الوضع، يتم ترتيب عدة شرائح على صفحة واحدة، وهو مفيد لطباعة مواد العرض للمؤتمرات والندوات وغيرها من الفعاليات المماثلة.

يتم تكوين وضع النشرة عبر الطريقة `setSlidesLayoutOptions`، والتي تتوفر في [IPdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipdfoptions/)، [IRenderingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/irenderingoptions/)، [IHtmlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ihtmloptions/)، و[ITiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itiffoptions/). لتعريف تخطيط النشرة، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/handoutlayoutingoptions/) .

## **تصدير وضع النشرة**

لتصدير عرض تقديمي في وضع النشرة، اضبط الطريقة `setSlidesLayoutOptions` لخيارات التصدير المستهدفة وعيّن مثيلًا من [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/handoutlayoutingoptions/) يحدد عدد الشرائح في الصفحة والمعلمات العرضية ذات الصلة.

فيما يلي مثال على الكود يُظهر كيفية تحويل عرض تقديمي إلى PDF في وضع النشرة.

```java
// تحميل عرض تقديمي.
Presentation presentation = new Presentation("sample.pptx");
try {
    // ضبط خيارات التصدير.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 شرائح على صفحة واحدة أفقيًا
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // طباعة أرقام الشرائح
    slidesLayoutOptions.setPrintFrameSlide(true);                     // طباعة إطار حول الشرائح
    slidesLayoutOptions.setPrintComments(false);                      // لا تعليقات

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // تصدير العرض التقديمي إلى PDF مع التخطيط المختار.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
تذكّر أن الطريقة `setSlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند التجسيد كصور.
{{% /alert %}} 

## **الأسئلة الشائعة**

**ما هو الحد الأقصى لعدد مصغرات الشرائح في الصفحة في وضع النشرة؟**

تدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/ar/java/com.aspose.slides/handouttype/) حتى 9 مصغرات لكل صفحة مع ترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح في الصفحة؟**

لا. يتم التحكم في عدد وترتيب المصغرات بدقة بواسطة فئة [HandoutType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/handouttype/)؛ ولا يتم دعم التخطيطات العشوائية.

**هل يمكنني تضمين الشرائح المخفية في إخراج النشرة؟**

نعم. قم بتمكين الشرائح المخفية باستخدام الطريقة `setShowHiddenSlides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/htmloptions/)، أو [TiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/).