---
title: 在 C++ 中为 PowerPoint 文本添加动画
linktitle: 动画文本
type: docs
weight: 60
url: /zh/cpp/animated-text/
keywords:
- 动画文本
- 文本动画
- 动画段落
- 段落动画
- 动画效果
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 演示文稿中创建动态动画文本，提供易于遵循、已优化的 C++ 代码示例。"
---

## **向段落添加动画效果**

我们向 [**AddEffect()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) 方法添加到了 [**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) 和 [**ISequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_sequence) 类中。此方法允许您向单个段落添加动画效果。以下示例代码演示如何向单个段落添加动画效果：
``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// 选择要添加效果的段落
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// 为选定的段落添加 Fly 动画效果
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```



## **获取段落的动画效果**

您可能想要查找已添加到段落的动画效果，例如，在某些场景中，您想获取段落中的动画效果，以便将这些效果应用到另一个段落或形状。

Aspose.Slides for C++ 允许您获取文本框（形状）中段落所应用的所有动画效果。以下示例代码演示如何获取段落中的动画效果：
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

**文本动画与幻灯片切换有何不同，是否可以组合使用？**

文本动画控制对象在幻灯片上的随时间行为，而 [transitions](/slides/zh/cpp/slide-transition/) 控制幻灯片之间的切换方式。两者相互独立，但可以一起使用；播放顺序由动画时间轴和切换设置共同决定。

**在导出为 PDF 或图像时，文本动画会被保留吗？**

不会。PDF 和光栅图像是静态的，您只能看到幻灯片的单一状态而没有动画。若需保留运动，请使用 [video](/slides/zh/cpp/convert-powerpoint-to-video/) 或 [HTML](/slides/zh/cpp/export-to-html5/) 导出。

**文本动画在布局和幻灯片母版中有效吗？**

应用于布局/母版对象的效果会被幻灯片继承，但它们的时间安排和与幻灯片级别动画的交互取决于幻灯片上最终的动画序列。