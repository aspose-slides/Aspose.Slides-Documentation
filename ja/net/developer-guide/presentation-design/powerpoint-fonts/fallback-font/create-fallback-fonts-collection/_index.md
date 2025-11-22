---
title: フォールバック フォント コレクションの作成
type: docs
weight: 20
url: /ja/net/create-fallback-fonts-collection/
keywords: "フォールバック フォント コレクション, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint のフォールバック フォント コレクション（C# または .NET）"
---

## **フォールバック ルールの適用**

[FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) に整理でき、これは [IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection) インターフェイスを実装しています。コレクションからルールを追加または削除することが可能です。

次に、このコレクションは[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) プロパティに[FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager) クラスに割り当てることができます。FontsManager はプレゼンテーション全体のフォントを管理します。 詳細は[FontsManager と FontsLoader について](/slides/ja/net/about-fontsmanager-and-fontsloader/)をご覧ください。

各[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) には、独自の FontsManager クラスのインスタンスを持つ[FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager) プロパティがあります。

以下は、特定のプレゼンテーションの FontsManager にフォールバック フォント ルール コレクションを作成して割り当てる例です:  
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
さらに、[フォールバック フォントでプレゼンテーションをレンダリングする](/slides/ja/net/render-presentation-with-fallback-font/) 方法をご覧ください。  
{{% /alert %}}

## **よくある質問**

**フォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされず、PowerPoint の UI には表示されません。

**SmartArt、WordArt、チャート、テーブル内のテキストにもフォールバックは適用されますか？**

はい。これらのオブジェクト内のすべてのテキストに同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリと共にフォントを配布していますか？**

いいえ。フォントはご自身で追加・使用していただくもので、責任はご自身にあります。

**欠落フォントの置換/サブスティテューションと、欠落グリフのフォールバックは同時に使用できますか？**

はい。これらは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの利用可能性を解決し（[replacement](/slides/ja/net/font-replacement/)/[substitution](/slides/ja/net/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠落グリフを補填します。