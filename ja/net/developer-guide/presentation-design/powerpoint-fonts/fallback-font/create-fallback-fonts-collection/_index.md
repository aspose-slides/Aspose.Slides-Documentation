---
title: .NET でフォールバックフォントコレクションを構成する
linktitle: フォールバックフォントコレクション
type: docs
weight: 20
url: /ja/net/create-fallback-fonts-collection/
keywords:
- フォールバックフォント
- フォールバックルール
- フォントコレクション
- フォントの構成
- フォントの設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides でフォールバックフォントコレクションを設定し、PowerPoint および OpenDocument プレゼンテーションでテキストを一貫性があり鮮明に保ちます。"
---

## **フォールバック ルールの適用**

FontFallBackRule クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) に整理できます。このコレクションは[IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection) インターフェイスを実装しています。コレクションからルールを追加または削除することが可能です。

次に、このコレクションを[FontFallBackRulesCollection ](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) プロパティに、[FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager) クラスのインスタンスとして割り当てることができます。FontsManager はプレゼンテーション全体のフォントを管理します。

各[Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) には、[FontsManager ](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager) プロパティがあり、FontsManager クラスの独自インスタンスが保持されます。

以下は、フォールバック フォント ルール コレクションを作成し、特定のプレゼンテーションの FontsManager に割り当てる例です:  
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
フォールバック フォントでプレゼンテーションをレンダリングする方法の詳細は、[フォールバック フォントでプレゼンテーションをレンダリング](/slides/ja/net/render-presentation-with-fallback-font/) をご覧ください。 
{{% /alert %}}

## **よくある質問**

**私のフォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされないため、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらのオブジェクト内のテキストすべてに同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリと共にフォントを配布していますか？**

いいえ。フォントはご自身で追加・使用していただき、すべてご自身の責任で管理してください。

**欠落したフォントの置換/サブスティテューションと、欠落したグリフのフォールバックを併用できますか？**

はい。これらは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの利用可能性を解決し（[replacement](/slides/ja/net/font-replacement/)/[substitution](/slides/ja/net/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠落したグリフのギャップを埋めます。