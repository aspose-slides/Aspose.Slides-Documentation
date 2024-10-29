---
title: フォールバックフォントを使用したプレゼンテーションのレンダリング
type: docs
weight: 30
url: /ja/python-net/render-presentation-with-fallback-font/
keywords: "フォールバックフォント, PowerPointのレンダリング, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "Pythonでフォールバックフォントを使用してPowerPointをレンダリングする"
---

以下の例には、次のステップが含まれています。

1. [フォールバックフォントルールコレクションを作成する](/slides/ja/python-net/create-fallback-fonts-collection/)。
1. [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/)でフォールバックフォントルールを削除し、[AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/)を別のルールに追加します。
1. ルールコレクションを[FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)プロパティに設定します。
1. [Presentation.Save()](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)メソッドを使用して、プレゼンテーションを同じ形式で保存するか、別の形式で保存できます。フォールバックフォントルールコレクションがFontsManagerに設定されると、これらのルールはプレゼンテーションに対する操作（保存、レンダリング、変換など）の際に適用されます。

```py
import aspose.slides as slides

# ルールコレクションの新しいインスタンスを作成
rulesList = slides.FontFallBackRulesCollection()

# いくつかのルールを作成
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# ロードされたルールからフォールバックフォント「Tahoma」を削除しようとしています
	fallBackRule.remove("Tahoma")

	# 特定の範囲のルールを更新します
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# また、リストから既存のルールを削除することもできます
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# 使用するために準備されたルールリストを割り当てます
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# 初期化されたルールコレクションを使用してサムネイルをレンダリングし、PNGに保存します
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```


{{% alert color="primary" %}} 
[プレゼンテーションにおける保存と変換についてもっと読む](/slides/ja/python-net/creating-saving-and-converting-a-presentation/)。
{{% /alert %}}