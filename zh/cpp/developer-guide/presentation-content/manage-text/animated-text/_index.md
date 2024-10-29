---
title: 动画文本
type: docs
weight: 60
url: /zh/cpp/animated-text/
keywords: "PowerPoint中的动画文本"
description: "使用Aspose.Slides在PowerPoint演示文稿中添加动画文本"
---

## 向段落添加动画效果

我们在 [**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) 和 [**ISequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_sequence) 类中添加了 [**AddEffect()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) 方法。此方法允许您为单个段落添加动画效果。以下示例代码演示了如何为单个段落添加动画效果：

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// 选择段落以添加效果
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// 向选定段落添加飞入动画效果
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```


## 获取段落中的动画效果

您可能决定找出添加到段落中的动画效果，例如，在某种情况下，您想要获取段落中的动画效果，因为您计划将这些效果应用于另一个段落或形状。

Aspose.Slides for C++ 允许您获取应用于文本框（形状）中段落的所有动画效果。以下示例代码演示了如何获取段落中的动画效果：

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
		Console::WriteLine(String(u"段落 \"") + paragraph->get_Text() + u"\" 有 " + ObjectExt::ToString(effects[0]->get_Type()) + u" 效果。");
	}
}
```