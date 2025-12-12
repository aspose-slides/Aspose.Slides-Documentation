---
title: تحويل عروض PowerPoint إلى وضع النشرة على Android
linktitle: وضع النشرة
type: docs
weight: 150
url: /ar/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض
- وضع النشرة
- نشرة
- PPT
- PPTX
- PowerPoint
- عرض
- Android
- Java
- Aspose.Slides
description: "تحويل العروض إلى نشرات في Java. تحديد عدد الشرائح في الصفحة، الاحتفاظ بالملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides لـ Android، مع كود مثال. جرّبه مجانًا."
---

## **تصدير وضع النشرات**
توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى صيغ مختلفة، بما في ذلك إنشاء النشرات للطباعة في وضع Handout. يتيح لك هذا الوضع تكوين كيفية ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تمكين هذا الوضع عن طريق ضبط طريقة `setSlidesLayoutOptions` في واجهات [IPdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipdfoptions/),[IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/),[IHtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihtmloptions/),و[ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) .
لتكوين وضع Handout، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handoutlayoutingoptions/) الذي يحدد عدد الشرائح الموضوعة على صفحة واحدة وغيرها من معلمات العرض.
فيما يلي مثال على الشيفرة يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع Handout.
```java
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

	// تصدير العرض إلى PDF باستخدام التخطيط المختار.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
ضع في اعتبارك أن طريقة `setSlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند عرضها كصور. 
{{% /alert %}} 
## **الأسئلة الشائعة**
**ما هو الحد الأقصى لعدد مصغرات الشرائح في كل صفحة في وضع Handout؟**  
يدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) حتى 9 مصغرات في كل صفحة مع ترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).  

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح في كل صفحة؟**  
لا. يتم التحكم في عدد وترتيب المصغرات بدقة بواسطة الفئة [HandoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/)؛ ولا يتم دعم التخطيطات العشوائية.  

**هل يمكنني تضمين الشرائح المخفية في ناتج Handout؟**  
نعم. فعل الشرائح المخفية باستخدام طريقة `setShowHiddenSlides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/),[HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/htmloptions/), أو [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/).