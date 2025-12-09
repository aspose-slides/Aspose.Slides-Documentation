---
title: Animate PowerPoint Text in C++
linktitle: Animated Text
type: docs
weight: 60
url: /cpp/animated-text/
keywords:
- animated text
- text animation
- animated paragraph
- paragraph animation
- animation effect
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Create dynamic animated text in PowerPoint and OpenDocument presentations using Aspose.Slides for C++, with easy-to-follow, optimized C++ code examples."
---

## **Add Animation Effects to Paragraphs**

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


## **Get Animation Effects for Paragraphs**

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

## **FAQ**

**How do text animations differ from slide transitions, and can they be combined?**

Text animations control object behavior over time on a slide, while [transitions](/slides/cpp/slide-transition/) control how slides change. They’re independent and can be used together; playback order is governed by the animation timeline and the transition settings.

**Are text animations preserved when exporting to PDF or images?**

No. PDF and raster images are static, so you’ll see a single state of the slide without motion. To keep movement, use [video](/slides/cpp/convert-powerpoint-to-video/) or [HTML](/slides/cpp/export-to-html5/) export.

**Do text animations work in layouts and the slide master?**

Effects applied to layout/master objects are inherited by slides, but their timing and interaction with slide-level animations depend on the final sequence on the slide.
