---
title: نص متحرك
type: docs
weight: 60
url: /ar/cpp/animated-text/
keywords: "نص متحرك في PowerPoint"
description: "نص متحرك في عرض PowerPoint باستخدام Aspose.Slides"
---

## إضافة تأثيرات الحركة إلى الفقرات

لقد أضفنا [**AddEffect()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) لطريقة في [**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) و [**ISequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_sequence) classes. هذه الطريقة تسمح لك بإضافة تأثيرات الحركة إلى فقرة واحدة. هذا الكود المثال يبين لك كيفية إضافة تأثير حركة إلى فقرة واحدة:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// حدد الفقرة لإضافة تأثير
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// إضافة تأثير حركة طيران إلى الفقرة المحددة
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```


## الحصول على تأثيرات الحركة في الفقرات

يمكنك اتخاذ قرار لمعرفة تأثيرات الحركة المضافة إلى فقرة معينة، على سبيل المثال، في سيناريو واحد، ترغب في الحصول على تأثيرات الحركة في فقرة لأنك تخطط لتطبيق تلك التأثيرات على فقرة أو شكل آخر.

Aspose.Slides لـ C++ يتيح لك الحصول على جميع تأثيرات الحركة المطبقة على الفقرات الموجودة في إطار نص (شكل). هذا الكود المثال يبين لك كيفية الحصول على تأثيرات الحركة في فقرة:

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
		Console::WriteLine(String(u"الفقرة \"") + paragraph->get_Text() + u"\" لديها تأثير " + ObjectExt::ToString(effects[0]->get_Type()) + u".");
	}
}
```