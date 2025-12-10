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
- تأثير الحركة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء نص متحرك ديناميكي في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET، مع أمثلة كود C# سهلة المتابعة ومُحسّنة."
---

## **إضافة تأثيرات الحركة إلى الفقرات**

أضفنا الطريقة [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) إلى الفئتين [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) و[**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence). تتيح لك هذه الطريقة إضافة تأثيرات الحركة إلى فقرة واحدة. يوضح لك هذا المثال البرمجي كيفية إضافة تأثير حركة إلى فقرة واحدة:
```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // تحديد الفقرة لإضافة تأثير
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // إضافة تأثير الطيران للفقرة المحددة
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```


## **الحصول على تأثيرات الحركة للفقرات**

قد ترغب في معرفة تأثيرات الحركة المضافة إلى فقرة—على سبيل المثال، في أحد السيناريوهات، تريد الحصول على تأثيرات الحركة في فقرة لأنك تخطط لتطبيق هذه التأثيرات على فقرة أو شكل آخر.

يسمح لك Aspose.Slides for .NET بالحصول على جميع تأثيرات الحركة المطبقة على الفقرات الموجودة داخل إطار نص (شكل). يوضح لك هذا المثال البرمجي كيفية الحصول على تأثيرات الحركة في فقرة:
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

**كيف تختلف تحريك النص عن انتقالات الشريحة، وهل يمكن دمجهما؟**

تحكم تحريكات النص سلوك الكائن بمرور الوقت على الشريحة، بينما تتحكم [transitions](/slides/ar/net/slide-transition/) في كيفية تغير الشرائح. هما مستقلان ويمكن استخدامهما معًا؛ يتم تحديد ترتيب التشغيل بواسطة جدول زمني للتحريك وإعدادات الانتقال.

**هل يتم الحفاظ على تحريكات النص عند التصدير إلى PDF أو الصور؟**

لا. ملفات PDF والصور النقطية ثابتة، لذلك ستظهر حالة واحدة من الشريحة بدون حركة. للحفاظ على الحركة، استخدم تصدير [video](/slides/ar/net/convert-powerpoint-to-video/) أو [HTML](/slides/ar/net/export-to-html5/).

**هل تعمل تحريكات النص في التخطيطات ورئيس الشريحة؟**

التأثيرات المطبقة على كائنات التخطيط/الرئيس تُورّث إلى الشرائح، ولكن توقيتها وتفاعلها مع تحريكات مستوى الشريحة يعتمد على التسلسل النهائي في الشريحة.