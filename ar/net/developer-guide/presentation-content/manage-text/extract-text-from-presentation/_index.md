---
title: استخراج النص من العرض التقديمي
type: docs
weight: 90
url: /ar/net/extract-text-from-presentation/
keywords: "استخراج النص من الشريحة, استخراج النص من PowerPoint, C#, Csharp, Aspose.Slides لـ .NET"
description: "استخراج النص من الشريحة أو العرض التقديمي PowerPoint باستخدام C# أو .NET"
---

{{% alert color="primary" %}}

ليس من غير المألوف أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، تحتاج إلى استخراج النص من جميع الأشكال في جميع الشرائح في العرض التقديمي. تشرح هذه المقالة كيفية استخراج النص من عروض Microsoft PowerPoint PPTX باستخدام Aspose.Slides. يمكن استخراج النص بطرق التالية:

- [استخراج النص من شريحة واحدة](/slides/ar/net/extracting-text-from-the-presentation/)
- [استخراج النص باستخدام طريقة GetAllTextBoxes](/slides/ar/net/extracting-text-from-the-presentation/)
- [استخراج النص بشكل منظم وسريع](/slides/ar/net/extracting-text-from-the-presentation/)

{{% /alert %}}
## **استخراج النص من الشريحة**
توفر Aspose.Slides لـ .NET مساحة الأسماء Aspose.Slides.Util والتي تشمل فئة SlideUtil. تعرض هذه الفئة عددًا من الطرق الثابتة المزدوجة لاستخراج النص الكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض PPTX، 
استخدم طريقة [GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextboxes) الثابتة المزدوجة التي تعرضها فئة SlideUtil. تقبل هذه الطريقة كائن الشريحة كمعامل.
عند التنفيذ، تقوم طريقة الشريحة بمسح النص الكامل من الشريحة الممررة كمعامل وتُرجع مصفوفة من كائنات TextFrame. هذا يعني أن أي تنسيق نص مرتبط بالنص متاح. يقوم النص البرمجي التالي باستخراج جميع النصوص على الشريحة الأولى من العرض التقديمي:

```c#
//إنشاء كائن فئة Presentation الذي يمثل ملف PPTX
Presentation pptxPresentation = new Presentation("demo.pptx");

//الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//التكرار عبر مصفوفة TextFrames
for (int i = 0; i < textFramesPPTX.Length; i++)
{
	//التكرار عبر الفقرات في ITextFrame الحالي
	foreach (IParagraph para in textFramesPPTX[i].Paragraphs)
	{
		//التكرار عبر الأجزاء في IParagraph الحالي
		foreach (IPortion port in para.Portions)
		{
			//عرض النص في الجزء الحالي
			Console.WriteLine(port.Text);

			//عرض ارتفاع الخط للنص
			Console.WriteLine(port.PortionFormat.FontHeight);

			//عرض اسم الخط للنص
			if (port.PortionFormat.LatinFont != null)
				Console.WriteLine(port.PortionFormat.LatinFont.FontName);
		}
	}
}
```




## **استخراج النص من العرض التقديمي**
لمسح النص من العرض التقديمي الكامل، استخدم 
 [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextframes) الطريقة الثابتة التي تعلنها فئة SlideUtil. تأخذ هذه الطريقة معاملين:

1. أولاً، كائن Presentation يمثل عرض PPTX الذي يتم استخراج النص منه.
1. ثانياً، قيمة Boolean تحدد ما إذا كان يجب تضمين الشريحة الرئيسية عند مسح النص من العرض التقديمي.
   تُرجع الطريقة مصفوفة من كائنات TextFrame، مكتملة بمعلومات تنسيق النص. يقوم الكود أدناه بمسح النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية.

```c#
//إنشاء كائن فئة Presentation الذي يمثل ملف PPTX
Presentation pptxPresentation = new Presentation("demo.pptx");

//الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//التكرار عبر مصفوفة TextFrames
for (int i = 0; i < textFramesPPTX.Length; i++)

	//التكرار عبر الفقرات في ITextFrame الحالي
	foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

		//التكرار عبر الأجزاء في IParagraph الحالي
		foreach (IPortion port in para.Portions)
		{
			//عرض النص في الجزء الحالي
			Console.WriteLine(port.Text);

			//عرض ارتفاع الخط للنص
			Console.WriteLine(port.PortionFormat.FontHeight);

			//عرض اسم الخط للنص
			if (port.PortionFormat.LatinFont != null)
				Console.WriteLine(port.PortionFormat.LatinFont.FontName);
		}
```




## **استخراج النص بشكل منظم وسريع**
تمت إضافة الطريقة الثابتة الجديدة GetPresentationText إلى كائن Presentation. هناك نوعان من التحميل الزائد لهذه الطريقة:

```csharp
PresentationText GetPresentationText(Stream stream)
PresentationText GetPresentationText(Stream stream, ExtractionMode mode)
```

تشير قيمة إدخال نوع ExtractionMode إلى الوضع لتنظيم ناتج النص ويمكن تعيينها إلى القيم التالية:
غير منظم - النص الخام دون أن يؤخذ في الاعتبار موضعه في الشريحة
منظم - يتم وضع النص بالترتيب نفسه كما هو على الشريحة

يمكن استخدام الوضع غير المنظم عندما تكون السرعة حاسمة، فهو أسرع من الوضع المنظم.

يمثل PresentationText النص الخام المستخرج من العرض التقديمي. يحتوي على خاصية SlidesText من مساحة أسماء Aspose.Slides.Util التي تُرجع مصفوفة من كائنات ISlideText. يمثل كل كائن النص على الشريحة المقابلة. تحتوي كائنات ISlideText على الخصائص التالية:

ISlideText.Text - النص على أشكال الشريحة
ISlideText.MasterText - النص على أشكال الصفحة الرئيسية لهذه الشريحة
ISlideText.LayoutText - النص على أشكال صفحة التخطيط لهذه الشريحة
ISlideText.NotesText - النص على أشكال صفحة الملاحظات لهذه الشريحة

هناك أيضًا فئة SlideText التي تنفذ واجهة ISlideText.

يمكن استخدام واجهة برمجة التطبيقات الجديدة هكذا:

```c#
IPresentationText text1 = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);
```