---
title: 在 C++ 中為 PowerPoint 文字添加動畫
linktitle: 動畫文字
type: docs
weight: 60
url: /zh-hant/cpp/animated-text/
keywords:
- 動畫文字
- 文字動畫
- 動畫段落
- 段落動畫
- 動畫效果
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 與 OpenDocument 簡報中建立動態動畫文字，提供易於遵循且最佳化的 C++ 程式碼範例。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中對文字逐段套用動畫效果，以及如何取得已指派給文字框中段落的效果。重點在於用於新增段落層級動畫和檢查簡報中現有段落動畫效果的 API 方法。

## **將動畫效果套用到段落**

我們在 [**Sequence**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.sequence) 與 [**ISequence**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.i_sequence) 類別中加入了 [**AddEffect()**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) 方法。此方法允許您對單一段落加入動畫效果。以下範例程式碼示範如何對單一段落加入動畫效果：

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

## **取得段落的動畫效果**

您可能想了解已加入段落的動畫效果，例如在某個情況下，您想取得段落的動畫效果以便套用到另一個段落或圖形。

Aspose.Slides for C++ 允許您取得文字框（圖形）中所有段落所套用的動畫效果。以下範例程式碼示範如何取得段落中的動畫效果：

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

## **常見問題**

**文字動畫與投影片轉場有何不同？它們可以同時使用嗎？**

文字動畫控制物件在投影片上的時間行為，而[transitions](/slides/zh-hant/cpp/slide-transition/)控制投影片之間的切換方式。兩者互相獨立，但可同時使用；播放順序由動畫時間軸與轉場設定共同決定。

**匯出為 PDF 或影像時，文字動畫會保留嗎？**

不會。PDF 與點陣圖為靜態檔案，僅顯示投影片的單一狀態，沒有動態效果。若需保留動態效果，請使用[video](/slides/zh-hant/cpp/convert-powerpoint-to-video/)或[HTML](/slides/zh-hant/cpp/export-to-html5/)匯出。

**文字動畫在版面配置和投影片母片中會起作用嗎？**

套用於版面配置/母片物件的效果會被繼承至投影片，但其時間與與投影片層級動畫的互動取決於投影片最終的時間序列。