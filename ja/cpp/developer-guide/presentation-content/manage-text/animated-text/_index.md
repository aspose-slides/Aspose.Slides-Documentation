---
title: アニメーションテキスト
type: docs
weight: 60
url: /cpp/animated-text/
keywords: "PowerPointのアニメーションテキスト"
description: "Aspose.Slidesを使用したPowerPointプレゼンテーションのアニメーションテキスト"
---

## 段落へのアニメーション効果の追加

[**AddEffect()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f)メソッドを[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence)および[**ISequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_sequence)クラスに追加しました。このメソッドを使用すると、単一の段落にアニメーション効果を追加できます。このサンプルコードでは、単一の段落にアニメーション効果を追加する方法を示しています。

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// 効果を追加する段落を選択
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// 選択した段落にFlyアニメーション効果を追加
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```


## 段落におけるアニメーション効果の取得

例えばシナリオの一つとして、段落に追加されたアニメーション効果を確認したい場合があります。それは、他の段落や形状にその効果を適用するつもりだからです。

Aspose.Slides for C++は、テキストフレーム（形状）に含まれる段落に適用されたすべてのアニメーション効果を取得することを可能にします。このサンプルコードでは、段落におけるアニメーション効果を取得する方法を示しています。

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
		Console::WriteLine(String(u"段落 \"") + paragraph->get_Text() + u"\" には " + ObjectExt::ToString(effects[0]->get_Type()) + u" 効果があります。");
	}
}
```