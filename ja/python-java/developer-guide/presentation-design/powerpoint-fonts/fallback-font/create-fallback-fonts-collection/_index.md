---
title: "Python（Java 経由）でフォールバック フォント コレクションを構成する"
linktitle: "フォールバック フォント コレクション"
type: docs
weight: 20
url: /ja/python-java/create-fallback-fonts-collection/
keywords:
- "フォールバック フォント"
- "フォールバック ルール"
- "フォント コレクション"
- "フォントを構成する"
- "フォントを設定する"
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python（Java 経由）でフォールバック フォント コレクションを設定し、PowerPoint と OpenDocument のプレゼンテーションでテキストを一貫性があり鮮明に保ちます。"
---
## **概要**

Aspose.Slides はプレゼンテーションに対してフォールバック フォント ルールのコレクションを構成できるようにします。各フォールバック ルールは [FontFallBackRule](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontfallbackrule/) クラスで表され、[FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontfallbackrulescollection/) に追加できます。

コレクションを作成したら、プレゼンテーションの [FontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/) の [setFontFallBackRulesCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) メソッドを使用して割り当てることができます。[FontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/) はプレゼンテーション全体のフォントを制御し、各 [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスは独自の [FontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/) を持ちます。

[FontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/) がフォールバック フォント コレクションで初期化されると、指定されたフォールバック フォントがプレゼンテーションのレンダリング時に適用されます。

## **フォールバック ルールの適用**

[FontFallBackRule](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontfallbackrule/) クラスのインスタンスは [FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontfallbackrulescollection/) に編成できます。コレクションからルールを追加または削除できます。

このコレクションは、プレゼンテーション全体のフォントを制御する [FontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/) クラスの [setFontFallBackRulesCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) メソッドを使用して割り当てることができます。

各 [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) には、独自の [FontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/) インスタンスを返す [getFontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getFontsManager) メソッドがあります。

以下の例は、フォールバック フォント ルールのコレクションを作成し、プレゼンテーションの [FontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/) に割り当てる方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

[FontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/) がフォールバック フォント コレクションで初期化されると、フォールバック フォントがプレゼンテーションのレンダリング時に適用されます。

{{% alert color="info" title="Note" %}}
フォールバック フォントでプレゼンテーションをレンダリングする方法の詳細は、[フォールバック フォントでプレゼンテーションをレンダリングする](/slides/ja/python-java/render-presentation-with-fallback-font/) をご確認ください。
{{% /alert %}}

## **FAQ**

**フォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされず、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらのオブジェクト内のテキストすべてに同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリと共にフォントを配布していますか？**

いいえ。フォントはご自身で追加・使用し、自己責任で管理してください。

**不足しているフォントの置換/サブスティテューションと、欠けているグリフのフォールバックを併用できますか？**

はい。これらは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの利用可能性を解決し（[replacement](/slides/ja/python-java/font-replacement/)/[substitution](/slides/ja/python-java/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠けたグリフのギャップを埋めます。