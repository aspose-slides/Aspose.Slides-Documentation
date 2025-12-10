---
title: C++ で PowerPoint テキストをアニメーション化
linktitle: アニメーション化されたテキスト
type: docs
weight: 60
url: /ja/cpp/animated-text/
keywords:
- アニメーションテキスト
- テキストアニメーション
- アニメーション段落
- 段落アニメーション
- アニメーション効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーションで動的なアニメーションテキストを作成し、わかりやすく最適化された C++ コード例を提供します。"
---

## **段落へのアニメーション効果の追加**

私たちは [**AddEffect()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) メソッドを [**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) および [**ISequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_sequence) クラスに追加しました。このメソッドを使用すると、単一の段落にアニメーション効果を追加できます。このサンプルコードは、単一の段落にアニメーション効果を追加する方法を示しています。
``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// 効果を追加する段落を選択
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// 選択された段落に Fly アニメーション効果を追加
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```


## **段落のアニメーション効果の取得**

たとえば、別の段落やシェイプに適用することを計画している場合など、段落に追加されたアニメーション効果を取得したいと考えることがあります。Aspose.Slides for C++ を使用すると、テキスト フレーム（シェイプ）内の段落に適用されたすべてのアニメーション効果を取得できます。このサンプルコードは、段落内のアニメーション効果を取得する方法を示しています。
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

**テキスト アニメーションはスライド遷移とどう違い、組み合わせることはできますか？**

テキスト アニメーションはスライド上のオブジェクトの動作を時間軸で制御し、[transitions](/slides/ja/cpp/slide-transition/) はスライドの切り替え方法を制御します。これらは独立しており、一緒に使用できます。再生順序はアニメーションのタイムラインと遷移設定によって決まります。

**PDF や画像にエクスポートする際にテキスト アニメーションは維持されますか？**

いいえ。PDF およびラスタ画像は静的であるため、スライドの単一の状態が表示され、動きはありません。動きを保持したい場合は、[video](/slides/ja/cpp/convert-powerpoint-to-video/) または [HTML](/slides/ja/cpp/export-to-html5/) エクスポートを使用してください。

**レイアウトやスライドマスターでもテキスト アニメーションは機能しますか？**

レイアウト/マスター オブジェクトに適用された効果はスライドに継承されますが、タイミングやスライド単位のアニメーションとの相互作用は、スライド上の最終的なシーケンスに依存します。