---
title: تحريك نص PowerPoint في .NET
linktitle: نص متحرك
type: docs
weight: 60
url: /ar/net/animated-text/
keywords:
- نص متحرك
- تحريك النص
- فقرة متحركة
- تحريك الفقرة
- تأثير الرسوم المتحركة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء نص متحرك ديناميكي في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET، مع أمثلة شفرة C# سهلة المتابعة ومُحسّنة."
---

## **إضافة تأثيرات الرسوم المتحركة إلى الفقرات**

أضفنا الطريقة [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) إلى الفئات [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) و[**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence). تسمح لك هذه الطريقة بإضافة تأثيرات الرسوم المتحركة إلى فقرة واحدة. يوضح لك رمز العينة كيفية إضافة تأثير رسومي إلى فقرة واحدة:
```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // اختر الفقرة لإضافة التأثير
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // أضف تأثير التحليق للفقرة المحددة
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```


## **الحصول على تأثيرات الرسوم المتحركة في الفقرات**

قد تقرر معرفة تأثيرات الرسوم المتحركة المضافة إلى فقرة — على سبيل المثال، في سيناريو ما، قد تريد الحصول على تأثيرات الرسوم المتحركة في فقرة لأنك تنوي تطبيق هذه التأثيرات على فقرة أو شكل آخر.

تتيح لك Aspose.Slides for .NET الحصول على جميع تأثيرات الرسوم المتحركة المطبقة على الفقرات الموجودة داخل إطار نص (شكل). يوضح لك رمز العينة كيفية الحصول على تأثيرات الرسوم المتحركة في فقرة:
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


## **الأسئلة الشائعة**

**كيف تختلف الرسوم المتحركة للنص عن انتقالات الشرائح، وهل يمكن دمجهما؟**

تتحكم الرسوم المتحركة للنص في سلوك الكائن على مدار الوقت داخل الشريحة، بينما تتحكم [الانتقالات](/slides/ar/net/slide-transition/) في كيفية تغيير الشرائح. هما مستقلان ويمكن استخدامهما معًا؛ يتم تحديد ترتيب التشغيل بواسطة جدول توقيت الرسوم المتحركة وإعدادات الانتقال.

**هل يتم الحفاظ على الرسوم المتحركة للنص عند التصدير إلى PDF أو الصور؟**

لا. ملفات PDF والصور النقطية ثابتة، لذلك سترى حالة واحدة فقط من الشريحة بدون حركة. للحفاظ على الحركة، استخدم تصدير [فيديو](/slides/ar/net/convert-powerpoint-to-video/) أو [HTML](/slides/ar/net/export-to-html5/).

**هل تعمل الرسوم المتحركة للنص في التخطيطات وماستر الشريحة؟**

التأثيرات المطبقة على كائنات التخطيط/الماستر تُورّث إلى الشرائح، لكن توقيتها وتفاعلها مع الرسوم المتحركة على مستوى الشريحة يعتمد على التسلسل النهائي في الشريحة.