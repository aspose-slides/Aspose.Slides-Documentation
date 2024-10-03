---
title: Animated Text
type: docs
weight: 60
url: /cpp/animated-text/
keywords: "Animated text in PowerPoint"
description: "Animated text in PowerPoint presentation with Aspose.Slides"
---

## Adding Animation Effects to Paragraphs

We added the [**AddEffect()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) method to the [**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) and [**ISequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_sequence) classes. This method allows you to add animation effects to a single paragraph. This sample code shows you how to add an animation effect to a single paragraph:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// select paragraph to add effect
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// add Fly animation effect to selected paragraph
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```


## Getting the Animation Effects in Paragraphs

You may decide to find out the animation effects added to a paragraph for example, in one scenario, you want to get the animation effects in a paragraph because you plan to apply those effects to another paragraph or shape.

Aspose.Slides for C++ allows you to get all the animation effects applied to paragraphs contained in a text frame (shape). This sample code shows you how to get the animation effects in a paragraph:

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
