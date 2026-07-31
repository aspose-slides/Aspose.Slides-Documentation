---
title: تحويل عروض PowerPoint إلى وضع النسخة المطبوعة على Android
linktitle: وضع النسخة المطبوعة
type: docs
weight: 150
url: /ar/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض
- وضع النسخة المطبوعة
- نسخة مطبوعة
- PPT
- PPTX
- PowerPoint
- عرض
- Android
- Java
- Aspose.Slides
description: "تحويل العروض إلى نسخ مطبوعة في Java. ضبط عدد الشرائح لكل صفحة، الاحتفاظ بالملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides لأجهزة Android، مع مثال شفرة. جرّبه مجانًا."
---
## **مقدمة**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى صيغ مختلفة، بما في ذلك إنشاء نسخ مطبوعة للطباعة في وضع النسخة المطبوعة. يتيح لك هذا الوضع تكوين كيفية ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تفعيل هذا الوضع عن طريق تحديد طريقة `setSlidesLayoutOptions` في واجهات [IPdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihtmloptions/), و[ITiffOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiffoptions/) .

## **تصدير وضع النسخة المطبوعة**

لتكوين وضع النسخة المطبوعة، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/handoutlayoutingoptions/) الذي يحدد عدد الشرائح التي تُوضع على صفحة واحدة ومعلمات العرض الأخرى.

فيما يلي مثال على الشيفرة يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع النسخة المطبوعة.

```java
// تحميل عرض تقديمي.
Presentation presentation = new Presentation("sample.pptx");
try {
	// تحديد خيارات التصدير.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 شرائح على صفحة واحدة أفقيًا
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // طباعة أرقام الشرائح
	slidesLayoutOptions.setPrintFrameSlide(true);                     // طباعة إطار حول الشرائح
	slidesLayoutOptions.setPrintComments(false);                      // بدون تعليقات

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// تصدير العرض إلى PDF باستخدام التخطيط المختار.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
خذ في الاعتبار أن طريقة `setSlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند التصيير كصور. 
{{% /alert %}} 

## **الأسئلة المتكررة**

**ما هو أقصى عدد من صور الشرائح المصغرة في كل صفحة في وضع النسخة المطبوعة؟**

يدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/handouttype/) حتى 9 صور مصغرة لكل صفحة بترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح في كل صفحة؟**

لا. يتم التحكم في عدد وترتيب الصور المصغرة بدقة بواسطة الفئة [HandoutType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/handouttype/)؛ لا يتم دعم التخطيطات العشوائية.

**هل يمكنني تضمين الشرائح المخفية في ناتج النسخة المطبوعة؟**

نعم. فعّل الشرائح المخفية باستخدام طريقة `setShowHiddenSlides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/htmloptions/), أو [TiffOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/).