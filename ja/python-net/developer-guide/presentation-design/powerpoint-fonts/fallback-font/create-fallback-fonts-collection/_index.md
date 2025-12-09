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
description: ".NET を通じて Python 用 Aspose.Slides でフォールバックフォントコレクションを設定し、PowerPoint と OpenDocument のプレゼンテーションでテキストを一貫して鮮明に保ちます。"
---

## **フォールバック ルールの適用**

[FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) に編成でき、[IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/) インターフェイスを実装しています。コレクションからルールを追加したり削除したりすることが可能です。

このコレクションは、[FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) クラスの [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) プロパティに割り当てることができます。FontsManager はプレゼンテーション全体のフォントを制御します。詳細は [FontsManager と FontsLoader について](/slides/ja/python-net/about-fontsmanager-and-fontsloader/) をご覧ください。

各 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) には、FontsManager クラスの独自インスタンスを保持する [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) プロパティがあります。

以下は、フォールバック フォント ルール コレクションを作成し、特定のプレゼンテーションの FontsManager に割り当てる例です:  
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


FontsManager がフォールバック フォント コレクションで初期化されると、プレゼンテーションのレンダリング時にフォールバック フォントが適用されます。

{{% alert color="primary" %}} 
詳細は、[フォールバック フォントでプレゼンテーションをレンダリングする](/slides/ja/python-net/render-presentation-with-fallback-font/) をご覧ください。
{{% /alert %}}

## **FAQ**

**フォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で確認できますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされず、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらオブジェクト内のテキストにも同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリと共にフォントを配布していますか？**

いいえ。フォントはご自身で用意し、自己責任で使用してください。

**欠落フォントの置換/サブスティテューションと欠落グリフのフォールバックは併用できますか？**

はい。これらは同じフォント解決パイプラインの独立したステージです。まずエンジンがフォントの利用可能性を解決し（[置換](/slides/ja/python-net/font-replacement/)/[サブスティテューション](/slides/ja/python-net/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠落グリフのギャップを埋めます。