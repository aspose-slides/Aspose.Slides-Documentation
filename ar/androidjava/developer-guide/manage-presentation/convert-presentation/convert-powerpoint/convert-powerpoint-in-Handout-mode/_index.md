---
title: تحويل عروض PowerPoint في وضع النشرة على Android
linktitle: وضع النشرة
type: docs
weight: 150
url: /ar/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- وضع النشرة
- نشرة
- PPT
- PPTX
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تحويل العروض إلى نشرات في Java. تحديد عدد الشرائح لكل صفحة، الحفاظ على الملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides لأندرويد، مع كود أمثلة. جرّبه مجانًا."
---
## **المقدمة**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى صيغ مختلفة، بما في ذلك إنشاء نشرات للطباعة في وضع Handout. يتيح لك هذا الوضع تكوين كيفية ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تمكين هذا الوضع عن طريق ضبط طريقة `setSlidesLayoutOptions` في واجهات [IPdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipdfoptions/)، [IRenderingOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/irenderingoptions/)، [IHtmlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihtmloptions/)، و[ITiffOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itiffoptions/).

لتعيين أبعاد صفحة النشرة واتجاهها قبل التصدير،参见 [Notes Page Size](/slides/ar/androidjava/notes-size/).

## **تصدير وضع النشرة**

لتكوين وضع Handout، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/handoutlayoutingoptions/) الذي يحدد عدد الشرائح التي توضع على صفحة واحدة وغيرها من معلمات العرض.

فيما يلي مثال على التعليمات البرمجية يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع Handout.

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

	// تصدير العرض إلى PDF باستخدام التخطيط المختار.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
ضع في اعتبارك أن طريقة `setSlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند العرض كصور.
{{% /alert %}} 

## **الأسئلة الشائعة**

**ما هو الحد الأقصى لعدد صور المصغرات للشرائح لكل صفحة في وضع النشرة؟**

يدعم Aspose.Slides [presets](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/handouttype/) حتى 9 مصغرات للشرائح لكل صفحة بترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح لكل صفحة؟**

لا. عدد وترتيب المصغرات يتحكم فيهما بدقة فئة [HandoutType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/handouttype/)؛ لا يتم دعم تخطيطات عشوائية.

**هل يمكنني تضمين الشرائح المخفية في ناتج النشرة؟**

نعم. قم بتمكين الشرائح المخفية باستخدام طريقة `setShowHiddenSlides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/htmloptions/)، أو [TiffOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/).