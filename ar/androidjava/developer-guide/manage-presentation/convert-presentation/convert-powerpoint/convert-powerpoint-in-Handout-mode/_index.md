---
title: تحويل عروض PowerPoint في وضع النشرة على Android
linktitle: وضع النشرة
type: docs
weight: 150
url: /ar/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- وضع النشرة
- نشرة
- PPT
- PPTX
- PowerPoint
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "تحويل العروض التقديمية إلى نشرات باستخدام Java. تحديد عدد الشرائح لكل صفحة، الحفاظ على الملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides لنظام Android، مع مثال شفرة. جرّبه مجانًا."
---

## **تصدير وضع النشرات**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى صيغ متعددة، بما في ذلك إنشاء نشرات للطباعة في وضع النشرات. يتيح لك هذا الوضع تكوين طريقة ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تفعيل هذا الوضع عن طريق تعيين طريقة `setSlidesLayoutOptions` في واجهات [IPdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipdfoptions/)، [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/)، [IHtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihtmloptions/)، و[ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) .

لتكوين وضع النشرات، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handoutlayoutingoptions/) الذي يحدد عدد الشرائح التي توضع على صفحة واحدة وغيرها من معلمات العرض.

فيما يلي مثال على الكود يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع النشرات.
```java
// تحميل عرض تقديمي.
Presentation presentation = new Presentation("sample.pptx");
try {
	// تعيين خيارات التصدير.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 شرائح على صفحة واحدة أفقياً
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // طباعة أرقام الشرائح
	slidesLayoutOptions.setPrintFrameSlide(true);                     // طباعة إطار حول الشرائح
	slidesLayoutOptions.setPrintComments(false);                      // لا تعليقات

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// تصدير العرض التقديمي إلى PDF باستخدام التخطيط المختار.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```


{{% alert color="warning" %}} 
ضع في اعتبارك أن طريقة `setSlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند التصيير كصور.
{{% /alert %}} 

## **الأسئلة الشائعة**

**ما هو الحد الأقصى لعدد مصغرات الشرائح في كل صفحة في وضع النشرات؟**

تدعم Aspose.Slides [presets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) حتى 9 مصغرات لكل صفحة مع ترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح في كل صفحة؟**

لا. يتم التحكم في عدد وترتيب المصغرات بدقة بواسطة فئة [HandoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/)؛ لا تُدعم التخطيطات العشوائية.

**هل يمكنني تضمين الشرائح المخفية في ناتج النشرة؟**

نعم. فعّل الشرائح المخفية باستخدام طريقة `setShowHiddenSlides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/htmloptions/)، أو [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/).