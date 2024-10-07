---
title: استخراج النص من العرض التقديمي
type: docs
weight: 90
url: /cpp/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

ليس من غير المألوف أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، تحتاج إلى استخراج النص من جميع الأشكال على جميع الشرائح في العرض التقديمي. تشرح هذه المقالة كيفية استخراج النص من عروض Microsoft PowerPoint PPTX باستخدام Aspose.Slides. يمكن استخراج النص بطرق التالية:

- [استخراج النص من شريحة واحدة](/slides/cpp/extracting-text-from-the-presentation/)
- [استخراج النص باستخدام طريقة GetAllTextBoxes](/slides/cpp/extracting-text-from-the-presentation/)
- [استخراج النص بشكل منظم وسريع](/slides/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **استخراج النص من الشريحة**
توفر Aspose.Slides لـ C++ مساحة الأسماء Aspose.Slides.Util التي تتضمن فئة SlideUtil. تعرض هذه الفئة عددًا من الطرق الثابتة المتعددة التحميل لاستخراج النص بالكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي بصيغة PPTX، استخدم الطريقة الثابتة المتعددة التحميل [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a97da94e3fc5230cdfc0e30b444c127df) التي تعرضها فئة SlideUtil. تأخذ هذه الطريقة كائن الشريحة كمعامل.
عند التنفيذ، تقوم طريقة الشريحة بفحص النص بالكامل من الشريحة المرسلة كمعامل وتعيد مصفوفة من كائنات TextFrame. وهذا يعني أن أي تنسيق نصي مرتبط بالنص متاح. الجزء التالي من الشيفرة يستخرج جميع النصوص من الشريحة الأولى للعرض التقديمي:

``` cpp
// مسار دليل الوثائق.
System::String dataDir = GetDataPath();

// إنشاء فئة Presentation التي تمثل ملف PPTX
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// حلقة عبر مصفوفة TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// حلقة عبر الفقرات في ITextFrame الحالي
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// حلقة عبر الأجزاء في IParagraph الحالي
		for (const auto& port : para->get_Portions())
		{
			// عرض النص في الجزء الحالي
			Console::WriteLine(port->get_Text());

			// عرض ارتفاع خط النص
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// عرض اسم خط النص
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```

## **استخراج النص من العرض التقديمي**
لفحص النص من العرض التقديمي بالكامل، استخدم الطريقة الثابتة [GetAllTextFrames](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a5a0aebdc520e5258c8a1f665fdb8be12) التي تعرضها فئة SlideUtil. تأخذ هذه الطريقة معاملين:

1. أولاً، كائن Presentation يمثل عرض PPTX الذي يتم استخراج النص منه.
2. ثانيًا، قيمة Boolean تحدد ما إذا كان يجب تضمين شريحة الماستر عند فحص النص من العرض التقديمي.
   تعيد الطريقة مصفوفة من كائنات TextFrame، مكتملة بمعلومات تنسيق النص. الشيفرة أدناه تفحص النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك شرائح الماستر.

``` cpp
// مسار دليل الوثائق.
System::String dataDir = GetDataPath();

// إنشاء فئة Presentation التي تمثل ملف PPTX
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// حلقة عبر مصفوفة TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// حلقة عبر الفقرات في ITextFrame الحالي
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// حلقة عبر الأجزاء في IParagraph الحالي
		for (const auto& port : para->get_Portions())
		{
			// عرض النص في الجزء الحالي
			Console::WriteLine(port->get_Text());

			// عرض ارتفاع خط النص
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// عرض اسم خط النص
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```

## **استخراج النص بشكل منظم وسريع**
تمت إضافة الطريقة الثابتة الجديدة GetPresentationText إلى فئة Presentation. هناك تحميلان لهذه الطريقة:

``` cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode) override
 
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode) override
```

تشير قيمة المكافئ TextExtractionArrangingMode إلى الوضع لتنظيم مخرجات نتيجة النص ويمكن تعيينها على القيم التالية:  
غير منظم - النص الخام دون اعتبار للموقع على الشريحة  
منظم - النص يتم وضعه بنفس ترتيب الشريحة

يمكن استخدام الوضع غير المنظم عندما تكون السرعة حرجة، فهو أسرع من الوضع المنظم.

يمثل PresentationText النص الخام المستخرج من العرض التقديمي. يحتوي على طريقة get_SlidesText() من مساحة أسماء Aspose.Slides.Util والتي تعيد مصفوفة من كائنات ISlideText. يمثل كل كائن النص على الشريحة المقابلة. تحتوي كائنات ISlideText على الطرق التالية:

get_Text() - النص الموجود على أشكال الشريحة.  
get_MasterText() - النص الموجود على أشكال الصفحة الرئيسية لهذه الشريحة.  
get_LayoutText() - النص الموجود على أشكال صفحة التخطيط لهذه الشريحة.  
get_NotesText() - النص الموجود على أشكال صفحة الملاحظات لهذه الشريحة.

هناك أيضًا فئة SlideText التي تنفذ واجهة ISlideText.

يمكن استخدام واجهة برمجة التطبيقات الجديدة بهذه الطريقة:

``` cpp
auto text = System::MakeObject<PresentationFactory>()->GetPresentationText(u"presentation.ppt", TextExtractionArrangingMode::Unarranged);
Console::WriteLine(text->get_SlidesText()[0]->get_Text());
Console::WriteLine(text->get_SlidesText()[0]->get_LayoutText());
Console::WriteLine(text->get_SlidesText()[0]->get_MasterText());
Console::WriteLine(text->get_SlidesText()[0]->get_NotesText());
```