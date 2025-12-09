---
title: ".NET でフォールバック フォント コレクションを構成する"
linktitle: "フォールバック フォント コレクション"
type: docs
weight: 20
url: /ja/net/create-fallback-fonts-collection/
keywords:
- フォールバック フォント
- フォールバック ルール
- フォント コレクション
- フォント の構成
- フォント の設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でフォールバック フォント コレクションを設定し、PowerPoint および OpenDocument のプレゼンテーションでテキストを一貫して鮮明に保ちます。"
---

## **フォールバック ルールの適用**

[FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) に整理でき、[IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection) インターフェイスを実装しています。コレクションからルールを追加または削除できます。

このコレクションは、[FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager) クラスの[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)プロパティに割り当てることができます。FontsManager はプレゼンテーション全体のフォントを管理します。詳しくは[About FontsManager and FontsLoader](/slides/ja/net/about-fontsmanager-and-fontsloader/)をご覧ください。

各[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)には、独自の FontsManager クラスのインスタンスを持つ[FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager)プロパティがあります。

以下は、特定のプレゼンテーションの FontsManager にフォールバック フォント ルールコレクションを作成して割り当てる例です：
```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```


FontsManager がフォールバック フォント コレクションで初期化されると、プレゼンテーションのレンダリング中にフォールバック フォントが適用されます。

{{% alert color="primary" %}} 
詳細は [Render Presentation with Fallback Font](/slides/ja/net/render-presentation-with-fallback-font/) をご覧ください。
{{% /alert %}}

## **よくある質問**

**私のフォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされず、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらのオブジェクト内のテキストにも同じ字形置換メカニズムが使用されます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントはご自身で追加・使用していただき、自己責任で管理してください。

**欠損フォントの置換/サブスティテューションと欠損字形のフォールバックは併用できますか？**

はい。これらは同じフォント解決パイプラインの独立した段階であり、まずエンジンがフォントの有無を解決（[replacement](/slides/ja/net/font-replacement/)/[substitution](/slides/ja/net/font-substitution/)）し、次にフォールバックが利用可能なフォント内の欠損字形を補填します。