---
title: Pythonでフォールバックフォントコレクションを設定する
linktitle: フォールバックフォントコレクション
type: docs
weight: 20
url: /ja/python-net/create-fallback-fonts-collection/
keywords:
- フォールバックフォント
- フォールバックルール
- フォントコレクション
- フォントを構成する
- フォントをセットアップする
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションでテキストを一貫して鮮明に保つために、.NET 経由で Python 用 Aspose.Slides のフォールバックフォントコレクションを設定します。"
---

## **フォールバック ルールを適用**

[FontFallBackRule] クラスのインスタンスは、[FontFallBackRulesCollection] に整理でき、[IFontFallBackRulesCollection] インターフェイスを実装しています。コレクションからルールを追加したり削除したりできます。

次に、このコレクションは [FontsManager] クラスの [FontFallBackRulesCollection] プロパティに割り当てることができます。FontsManager はプレゼンテーション全体のフォントを管理します。詳細は [About FontsManager and FontsLoader](/slides/ja/python-net/about-fontsmanager-and-fontsloader/)をご覧ください。

各 [Presentation] には、FontsManager クラスの独自インスタンスを保持する [FontsManager] プロパティがあります。

特定のプレゼンテーションの FontsManager にフォールバック フォント ルール コレクションを作成して割り当てる例を示します：
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
フォールバック フォントでプレゼンテーションをレンダリングする方法の詳細は[Render Presentation with Fallback Font](/slides/ja/python-net/render-presentation-with-fallback-font/)をご覧ください。
{{% /alert %}}

## **FAQ**

**フォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされず、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらのオブジェクト内のテキストすべてに同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリと共にフォントを配布していますか？**

いいえ。フォントはご自身で追加・使用していただき、その責任はご利用者にあります。

**欠落フォントの置換/サブスティテューションと欠落グリフのフォールバックは併用できますか？**

はい。これらは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの利用可能性を解決し（[replacement](/slides/ja/python-net/font-replacement/)/[substitution](/slides/ja/python-net/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠落グリフを埋めます。