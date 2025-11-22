---
title: نص متحرك
type: docs
weight: 60
url: /ar/net/animated-text/
keywords: "نص متحرك, تأثيرات الرسوم المتحركة, عرض بوربوينت, C#, Csharp, Aspose.Slides for .NET"
description: "إضافة نص متحرك وتأثيرات إلى عرض بوربوينت بلغة C# أو .NET"
---

## **إضافة تأثيرات الرسوم المتحركة إلى الفقرات**

أضفنا طريقة [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) إلى الفئات [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) و[**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence). تسمح لك هذه الطريقة بإضافة تأثيرات الرسوم المتحركة إلى فقرة واحدة. يوضح لك هذا المثال البرمجي كيفية إضافة تأثير رسوم متحركة إلى فقرة واحدة:
```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // اختر الفقرة لإضافة التأثير
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // أضف تأثير حركة الطيران إلى الفقرة المحددة
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```


## **الحصول على تأثيرات الرسوم المتحركة في الفقرات**

قد ترغب في معرفة تأثيرات الرسوم المتحركة المضافة إلى فقرة — على سبيل المثال، في أحد السيناريوهات، تريد الحصول على تأثيرات الرسوم المتحركة في فقرة لأنك تخطط لتطبيق تلك التأثيرات على فقرة أو شكل آخر.

يتيح لك Aspose.Slides for .NET الحصول على جميع تأثيرات الرسوم المتحركة المطبقة على الفقرات الموجودة داخل إطار نص (شكل). يوضح لك هذا المثال البرمجي كيفية الحصول على تأثيرات الرسوم المتحركة في فقرة:
```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```


## **الأسئلة المتكررة**

**كيف تختلف رسوم النص المتحركة عن انتقالات الشرائح، وهل يمكن دمجها؟**

تتحكم رسوم النص المتحركة في سلوك الكائن بمرور الوقت على الشريحة، بينما تتحكم [الانتقالات](/slides/ar/net/slide-transition/) في طريقة تغير الشرائح. إنهما مستقلان ويمكن استخدامهما معًا؛ يتم التحكم في ترتيب التشغيل بواسطة جدول توقيت الرسوم المتحركة وإعدادات الانتقال.

**هل يتم الحفاظ على رسوم النص المتحركة عند التصدير إلى PDF أو الصور؟**

لا. ملفات PDF والصور النقطية ثابتة، لذلك سترى حالة واحدة من الشريحة بدون حركة. للحفاظ على الحركة، استخدم تصدير [فيديو](/slides/ar/net/convert-powerpoint-to-video/) أو [HTML](/slides/ar/net/export-to-html5/).

**هل تعمل رسوم النص المتحركة في التخطيطات وماستر الشريحة؟**

تُورّث التأثيرات المطبقة على كائنات التخطيط/الماستر إلى الشرائح، لكن توقيتها وتفاعلها مع الرسوم المتحركة على مستوى الشريحة يعتمد على التسلسل النهائي في الشريحة.