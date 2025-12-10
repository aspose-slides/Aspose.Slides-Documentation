---
title: تحريك نص PowerPoint في C++
linktitle: نص متحرك
type: docs
weight: 60
url: /ar/cpp/animated-text/
keywords:
- نص متحرك
- رسوم متحركة للنص
- فقرة متحركة
- رسوم متحركة للفقرة
- تأثير الرسوم المتحركة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء نص متحرك ديناميكي في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++، مع أمثلة كود C++ مُحسّنة وسهلة المتابعة."
---

## **إضافة تأثيرات الرسوم المتحركة إلى الفقرات**

أضفنا طريقة [**AddEffect()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) إلى الفئتين [**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) و[**ISequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_sequence). تتيح لك هذه الطريقة إضافة تأثيرات الرسوم المتحركة إلى فقرة واحدة. يُظهر لك رمز العينة هذا كيفية إضافة تأثير رسوم متحركة إلى فقرة واحدة:
``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// تحديد الفقرة لإضافة تأثير
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// إضافة تأثير التحليق إلى الفقرة المحددة
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```


## **الحصول على تأثيرات الرسوم المتحركة للفقرات**

قد تحتاج إلى معرفة التأثيرات المضافة إلى فقرة؛ على سبيل المثال، قد ترغب في الحصول على تأثيرات الرسوم المتحركة في فقرة لأنك تخطط لتطبيق هذه التأثيرات على فقرة أو شكل آخر.

تمكنك Aspose.Slides for C++ من الحصول على جميع تأثيرات الرسوم المتحركة المطبقة على الفقرات الموجودة في إطار نص (شكل). يُظهر لك رمز العينة هذا كيفية الحصول على تأثيرات الرسوم المتحركة في فقرة:
``` cpp
String dataDir = GetDataPath();
auto pres = System::MakeObject<Presentation>(dataDir + u"Test.pptx");

auto sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(1));

for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
{
	auto effects = sequence->GetEffectsByParagraph(paragraph);

	if (effects->get_Length() > 0)
	{
		Console::WriteLine(String(u"Paragraph \"") + paragraph->get_Text() + u"\" has " + ObjectExt::ToString(effects[0]->get_Type()) + u" effect.");
	}
}
```


## **الأسئلة الشائعة**

**كيف تختلف الرسوم المتحركة للنص عن انتقالات الشرائح، وهل يمكن دمجهما؟**

تتحكم الرسوم المتحركة للنص في سلوك الكائن بمرور الوقت على الشريحة، بينما [transitions](/slides/ar/cpp/slide-transition/) تتحكم في كيفية تغير الشرائح. هما مستقلان ويمكن استخدامهما معًا؛ يتم تحديد ترتيب التشغيل بواسطة جدول زمني للرسوم المتحركة وإعدادات الانتقال.

**هل يتم الاحتفاظ بالرسوم المتحركة للنص عند التصدير إلى PDF أو صور؟**

لا. ملفات PDF والصور النقطية ثابتة، لذلك ستظهر حالة واحدة فقط للشفرة دون حركة. للحفاظ على الحركة، استخدم تصدير [video](/slides/ar/cpp/convert-powerpoint-to-video/) أو [HTML](/slides/ar/cpp/export-to-html5/).

**هل تعمل الرسوم المتحركة للنص في التخطيطات وماستر الشريحة؟**

التأثيرات التي تُطبق على كائنات التخطيط/ماستر تُورّث إلى الشرائح، لكن توقيتها وتفاعله مع الرسوم المتحركة على مستوى الشريحة يعتمد على التسلسل النهائي في الشريحة.