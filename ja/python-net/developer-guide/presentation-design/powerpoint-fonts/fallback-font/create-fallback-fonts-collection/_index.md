---
title: Python でフォールバック フォント コレクションを構成する
linktitle: フォールバック フォント コレクション
type: docs
weight: 20
url: /ja/python-net/create-fallback-fonts-collection/
keywords:
- フォールバック フォント
- フォールバック ルール
- フォント コレクション
- フォント の構成
- フォント の設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NETでフォールバック フォント コレクションを設定し、PowerPoint および OpenDocument のプレゼンテーションでテキストの一貫性と鮮明さを保ちます。"
---

## **フォールバック ルールの適用**

FontFallBackRule クラスのインスタンスは[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) に整理できます。コレクションからルールを追加または削除することが可能です。

このコレクションは、[FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) クラスの[font_fall_back_rules_collection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) プロパティに割り当てることができます。FontsManager はプレゼンテーション全体のフォントを管理します。詳しくは[About FontsManager and FontsLoader](/slides/ja/python-net/about-fontsmanager-and-fontsloader/)をご覧ください。

各[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)には、FontsManager クラスの独自インスタンスを持つ[fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) プロパティがあります。

以下は、特定のプレゼンテーションの FontsManager にフォールバックフォントルールコレクションを作成して割り当てる例です。  
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


FontsManager がフォールバックフォントコレクションで初期化されると、プレゼンテーションのレンダリング中にフォールバックフォントが適用されます。

{{% alert color="primary" %}} 
詳細は[フォールバック フォントでプレゼンテーションをレンダリング](/slides/ja/python-net/render-presentation-with-fallback-font/)をご覧ください。
{{% /alert %}}

## **よくある質問**

**フォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされず、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらのオブジェクト内のテキストすべてに同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリと共にフォントを配布していますか？**

いいえ。フォントはご自身で追加・使用し、自己責任で管理してください。

**欠落フォントの置換/代替と欠落グリフのフォールバックは同時に使用できますか？**

はい。これらは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの可用性を解決します（[置換](/slides/ja/python-net/font-replacement/)/[代替](/slides/ja/python-net/font-substitution/)）。次にフォールバックが利用可能なフォント内の欠落グリフのギャップを埋めます。