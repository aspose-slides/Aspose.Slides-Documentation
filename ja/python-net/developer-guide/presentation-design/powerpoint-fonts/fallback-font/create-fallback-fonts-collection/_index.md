---
title: Pythonでフォールバックフォントコレクションを構成する
linktitle: フォールバックフォントコレクション
type: docs
weight: 20
url: /ja/python-net/create-fallback-fonts-collection/
keywords:
- フォールバックフォント
- フォールバックルール
- フォントコレクション
- フォントの構成
- フォントの設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: ".NET を介して Python 用 Aspose.Slides でフォールバックフォントコレクションを設定し、PowerPoint および OpenDocument のプレゼンテーションでテキストを一貫して鮮明に保ちます。"
---

## **フォールバック ルールの適用**

FontFallBackRule クラスのインスタンスは、[FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) を整理でき、[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) に整理でき、[IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/) インターフェイスを実装しています。コレクションからルールを追加または削除することが可能です。

このコレクションは、[FontFallBackRulesCollection ](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) プロパティに [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) クラスのインスタンスとして割り当てることができます。FontsManager はプレゼンテーション全体のフォントを管理します。詳しくは [About FontsManager and FontsLoader](/slides/ja/python-net/about-fontsmanager-and-fontsloader/) をご覧ください。

各 [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) には、独自の FontsManager クラスインスタンスを持つ [FontsManager ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) プロパティがあります。

以下は、特定のプレゼンテーションの FontsManager にフォールバック フォント ルール コレクションを作成して割り当てる例です：
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


FontsManager がフォールバック フォント コレクションで初期化されると、プレゼンテーションのレンダリング中にフォールバック フォントが適用されます。

{{% alert color="primary" %}} 
フォールバック フォントでのプレゼンテーションのレンダリング方法の詳細は、[Render Presentation with Fallback Font](/slides/ja/python-net/render-presentation-with-fallback-font/) をご覧ください。
{{% /alert %}}

## **よくある質問**

**フォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされず、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらのオブジェクト内のテキストにも同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリと共にフォントを配布していますか？**

いいえ。フォントはご自身で追加・使用し、自己の責任で管理してください。

**欠落フォントの置換/サブスティテューションと、欠落グリフのフォールバックは同時に使用できますか？**

はい。これらは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの有無を解決し（[replacement](/slides/ja/python-net/font-replacement/)/[substitution](/slides/ja/python-net/font-substitution/)）、次にフォールバックが利用可能なフォントの欠落グリフを埋めます。