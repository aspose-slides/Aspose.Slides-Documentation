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
- フォントを構成する
- フォントの設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET でフォールバックフォントコレクションを設定し、PowerPoint および OpenDocument のプレゼンテーションでテキストを一貫性があり鮮明に保ちます。"
---

## **フォールバック ルールの適用**

インスタンスは [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) クラスを [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) に整理できます。コレクションからルールを追加または削除することが可能です。

このコレクションは、[FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) クラスの [font_fall_back_rules_collection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) プロパティに割り当てることができます。FontsManager はプレゼンテーション全体のフォントを管理します。

各 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) には、独自の FontsManager インスタンスを持つ [fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) プロパティがあります。

以下は、フォールバック フォント ルール コレクションを作成し、特定のプレゼンテーションの FontsManager に割り当てる例です：```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


FontsManager がフォールバック フォント コレクションで初期化されると、プレゼンテーションのレンダリング中にフォールバック フォントが適用されます。

{{% alert color="primary" %}} 
フォールバック フォントでプレゼンテーションをレンダリングする方法の詳細は、[フォールバック フォントでプレゼンテーションをレンダリング](/slides/ja/python-net/render-presentation-with-fallback-font/)をご覧ください。
{{% /alert %}}

## **FAQ**

**フォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされないため、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらのオブジェクト内のテキストにも同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリと共にフォントを配布していますか？**

いいえ。フォントはお客様側で追加・使用し、自己責任で管理してください。

**欠落したフォントの置換/サブスティテューションと、欠落したグリフのフォールバックを同時に使用できますか？**

はい。これは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの可用性を解決し（[置換](/slides/ja/python-net/font-replacement/)/[代替](/slides/ja/python-net/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠落グリフのギャップを埋めます。