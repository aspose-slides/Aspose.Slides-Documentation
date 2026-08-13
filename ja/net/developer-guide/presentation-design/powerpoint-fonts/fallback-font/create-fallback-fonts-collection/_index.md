---
title: .NET のフォールバック フォント コレクションを構成する
linktitle: フォールバック フォント コレクション
type: docs
weight: 20
url: /ja/net/create-fallback-fonts-collection/
keywords:
- フォールバック フォント
- フォールバック ルール
- フォント コレクション
- フォントの構成
- フォントの設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "PowerPoint および OpenDocument のプレゼンテーションでテキストの一貫性と鮮明さを保つために、Aspose.Slides for .NET でフォールバック フォント コレクションを設定します。"
---
## **概要**

Aspose.Slides では、プレゼンテーションのフォールバック フォント ルールのコレクションを構成できます。各フォールバック ルールは `FontFallBackRule` クラスで表され、`IFontFallBackRulesCollection` インターフェイスを実装する `FontFallBackRulesCollection` に追加できます。

コレクションを作成したら、プレゼンテーションの `FontsManager` の `FontFallBackRulesCollection` プロパティに割り当てます。`FontsManager` はプレゼンテーション全体のフォントを管理し、各 `Presentation` インスタンスは独自の `FontsManager` を持ちます。

`FontsManager` がフォールバック フォント コレクションで初期化されると、指定されたフォールバック フォントがプレゼンテーションのレンダリング時に適用されます。

## **フォールバック ルールの適用**

[FontFallBackRule](https://reference.aspose.com/slides/ja/net/aspose.slides/FontFallBackRule) クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/fontfallbackrulescollection) に整理でき、これは[IFontFallBackRulesCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/ifontfallbackrulescollection) インターフェイスを実装しています。コレクションからルールを追加または削除することが可能です。

その後、このコレクションを[FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)プロパティに割り当てて、[FontsManager](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsmanager) クラスに設定します。FontsManager はプレゼンテーション全体のフォントを管理します。

各[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation)には、独自のインスタンスを持つ[FontsManager](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/properties/fontsmanager)プロパティがあります。

以下は、フォールバック フォント ルール コレクションを作成し、特定のプレゼンテーションの FontsManager に割り当てる例です：

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

FontsManager がフォールバック フォント コレクションで初期化されると、レンダリング時にフォールバック フォントが適用されます。

{{% alert color="info" %}} 
[フォールバック フォントでプレゼンテーションをレンダリング](/slides/ja/net/render-presentation-with-fallback-font/) の詳細をご覧ください。
{{% /alert %}}

## **FAQ**

### フォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされず、PowerPoint の UI には表示されません。

### フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？

はい。これらのオブジェクト内のテキストにも同じグリフ置換メカニズムが使用されます。

### Aspose はライブラリにフォントを同梱していますか？

いいえ。フォントはご自身で追加・使用し、自己責任で管理してください。

### 不足フォントの置換/サブスティテューションと欠損グリフのフォールバックは同時に使用できますか？

はい。これらは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの可用性を解決（[replacement](/slides/ja/net/font-replacement/)/[substitution](/slides/ja/net/font-substitution/)）し、次にフォールバックが利用可能なフォントの欠損グリフを埋めます。