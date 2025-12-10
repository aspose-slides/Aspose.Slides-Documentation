---
title: "استخراج النص المتقدم من العروض التقديمية في C++"
linktitle: "استخراج النص"
type: docs
weight: 90
url: /ar/cpp/extract-text-from-presentation/
keywords:
- "استخراج النص"
- "استخراج النص من الشريحة"
- "استخراج النص من العرض التقديمي"
- "استخراج النص من PowerPoint"
- "استخراج النص من OpenDocument"
- "استخراج النص من PPT"
- "استخراج النص من PPTX"
- "استخراج النص من ODP"
- "استرجاع النص"
- "استرجاع النص من الشريحة"
- "استرجاع النص من العرض التقديمي"
- "استرجاع النص من PowerPoint"
- "استرجاع النص من OpenDocument"
- "استرجاع النص من PPT"
- "استرجاع النص من PPTX"
- "استرجاع النص من ODP"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "C++"
- "Aspose.Slides"
description: "قم باستخراج النص بسرعة من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---

{{% alert color="primary" %}} 
ليس من غير المألوف أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، تحتاج إلى استخراج النص من جميع الأشكال في جميع الشرائح في العرض التقديمي. توضح هذه المقالة طريقة استخراج النص من عروض Microsoft PowerPoint PPTX باستخدام Aspose.Slides. يمكن استخراج النص بالطرق التالية:

- [استخراج النص من شريحة واحدة](/slides/ar/cpp/extracting-text-from-the-presentation/)
- [استخراج النص باستخدام الطريقة GetAllTextBoxes](/slides/ar/cpp/extracting-text-from-the-presentation/)
- [استخراج النص المصنف والسريع](/slides/ar/cpp/extracting-text-from-the-presentation/)
{{% /alert %}} 
## **استخراج النص من شريحة**
تقدم Aspose.Slides للـ C++ مساحة الأسماء Aspose.Slides.Util التي تتضمن فئة SlideUtil. تعرض هذه الفئة عددًا من الطرق الساكنة المتعددة التحميل لاستخراج النص الكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض PPTX، استخدم الطريقة الساكنة المتعددة التحميل [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a97da94e3fc5230cdfc0e30b444c127df) التي توفرها فئة SlideUtil. تقبل هذه الطريقة كائن Slide كمعامل.
عند التنفيذ، تقوم طريقة Slide بمسح النص الكامل من الشريحة التي تم تمريرها كمعامل وتعيد مصفوفة من كائنات TextFrame. هذا يعني أن أي تنسيق نصي مرتبط بالنص متاح. القطعة البرمجية التالية تستخرج كل النص في الشريحة الأولى من العرض التقديمي:
``` cpp
// مسار دليل المستندات.
System::String dataDir = GetDataPath();

// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// التكرار عبر مصفوفة TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// التكرار عبر الفقرات في ITextFrame الحالي
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// التكرار عبر المقاطع في IParagraph الحالي
		for (const auto& port : para->get_Portions())
		{
			// عرض النص في المقطع الحالي
			Console::WriteLine(port->get_Text());

			// عرض ارتفاع الخط للنص
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// عرض اسم الخط للنص
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```


## **استخراج النص من عرض تقديمي**
لمسح النص من العرض التقديمي بالكامل، استخدم الطريقة الساكنة [GetAllTextFrames](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a5a0aebdc520e5258c8a1f665fdb8be12) التي توفرها فئة SlideUtil. تأخذ هذه الطريقة معاملين:

1. أولاً، كائن Presentation يمثل عرض PPTX الذي يتم استخراج النص منه.
2. ثانياً، قيمة Boolean تحدد ما إذا كان يجب تضمين الشريحة الرئيسة عند مسح النص من العرض التقديمي.
   تُعيد الطريقة مصفوفة من كائنات TextFrame، مع معلومات تنسيق النص. الكود أدناه يمسح النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسة.
``` cpp
// مسار دليل المستندات.
System::String dataDir = GetDataPath();

// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// التكرار عبر مصفوفة TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// التكرار عبر الفقرات في ITextFrame الحالي
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// التكرار عبر المقاطع في IParagraph الحالي
		for (const auto& port : para->get_Portions())
		{
			// عرض النص في المقطع الحالي
			Console::WriteLine(port->get_Text());

			// عرض ارتفاع الخط للنص
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// عرض اسم الخط للنص
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```


## **استخراج النص المصنف والسريع**
تم إضافة الطريقة الساكنة الجديدة GetPresentationText إلى فئة Presentation. هناك تحميلان (overloads) لهذه الطريقة:
``` cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode) override
 
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode) override
```


وسيط الـ enum TextExtractionArrangingMode يشير إلى الوضع الذي ينظم إخراج نتيجة النص ويمكن تعيينه إلى القيم التالية:
Unarranged - النص الخام دون مراعاة موضعه على الشريحة
Arranged - يتم وضع النص بنفس الترتيب كما هو على الشريحة

يمكن استخدام وضع Unarranged عندما تكون السرعة حرجة، فهو أسرع من وضع Arranged.

يمثل PresentationText النص الخام المستخرج من العرض التقديمي. يحتوي على طريقة get_SlidesText() من مساحة الأسماء Aspose.Slides.Util والتي تُعيد مصفوفة من كائنات ISlideText. كل كائن يمثل النص على الشريحة المقابلة. كائنات ISlideText لديها الطرق التالية:

get_Text() - النص على أشكال الشريحة.  
get_MasterText() - النص على أشكال الصفحة الرئيسة لهذه الشريحة.  
get_LayoutText() - النص على أشكال صفحة التخطيط لهذه الشريحة.  
get_NotesText() - النص على أشكال صفحة الملاحظات لهذه الشريحة.

هناك أيضًا فئة SlideText التي تنفذ واجهة ISlideText.

يمكن استخدام API الجديد كالتالي:
``` cpp
auto text = System::MakeObject<PresentationFactory>()->GetPresentationText(u"presentation.ppt", TextExtractionArrangingMode::Unarranged);
Console::WriteLine(text->get_SlidesText()[0]->get_Text());
Console::WriteLine(text->get_SlidesText()[0]->get_LayoutText());
Console::WriteLine(text->get_SlidesText()[0]->get_MasterText());
Console::WriteLine(text->get_SlidesText()[0]->get_NotesText());
```


## **الأسئلة الشائعة**

**ما مدى سرعة معالجة Aspose.Slides للعرض التقديمي الكبير أثناء استخراج النص؟**  
تم تحسين Aspose.Slides للأداء العالي ويعالج العروض التقديمية الكبيرة بكفاءة، مما يجعله مناسبًا للمعالجة في الوقت الفعلي أو المعالجة الجماعية.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والرسوم البيانية داخل العروض التقديمية؟**  
نعم، يدعم Aspose.Slides استخراج النص من الجداول والرسوم البيانية وغيرها من عناصر الشريحة المعقدة بالكامل، مما يتيح لك الوصول إلى جميع المحتويات النصية وتحليلها بسهولة.

**هل أحتاج إلى ترخيص خاص من Aspose.Slides لاستخراج النص من العروض التقديمية؟**  
يمكنك استخراج النص باستخدام النسخة التجريبية المجانية من Aspose.Slides، رغم أنها ستخضع لبعض القيود مثل معالجة عدد محدود من الشرائح فقط. للحصول على استخدام غير محدود وتعامل مع عروض تقديمية أكبر، يُنصح بشراء ترخيص كامل.