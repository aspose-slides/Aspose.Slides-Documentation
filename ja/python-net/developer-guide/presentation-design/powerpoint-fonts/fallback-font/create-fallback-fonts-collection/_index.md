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
- フォントの構成
- フォントの設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET でフォールバック フォント コレクションを設定し、PowerPoint および OpenDocument のプレゼンテーションでテキストを一貫性があり鮮明に保ちます。"
---

## **フォールバック ルールの適用**

[FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) に編成でき、[IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/) インターフェイスを実装します。コレクションからルールを追加または削除することができます。

次に、このコレクションは [FontFallBackRulesCollection ](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)プロパティに [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) クラスのインスタンスへ割り当てることができます。FontsManager はプレゼンテーション全体のフォントを制御します。詳しくは [FontsManager と FontsLoader の概要](/slides/ja/python-net/about-fontsmanager-and-fontsloader/) をご覧ください。

各 [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) には、独自の FontsManager クラス インスタンスを持つ [FontsManager ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) プロパティがあります。

以下は、フォールバック フォント ルール コレクションを作成し、特定のプレゼンテーションの FontsManager に割り当てる例です：
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
詳しくは [フォールバック フォントでプレゼンテーションをレンダリングする方法](/slides/ja/python-net/render-presentation-with-fallback-font/) をご覧ください。
{{% /alert %}}

## **よくある質問**

**フォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされず、PowerPoint の UI には表示されません。

**SmartArt、WordArt、チャート、テーブル内のテキストにもフォールバックは適用されますか？**

はい。これらのオブジェクト内のすべてのテキストに対して、同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントはご自身で追加・使用し、自己責任で管理してください。

**不足しているフォントの置換/サブスティテューションと、欠損グリフのフォールバックは併用できますか？**

はい。これらは同一のフォント解決パイプラインの独立した段階です。まずエンジンがフォントの利用可能性を解決し（[replacement](/slides/ja/python-net/font-replacement/)/[substitution](/slides/ja/python-net/font-substitution/)）、次にフォールバックが利用可能なフォント内の不足しているグリフを補填します。