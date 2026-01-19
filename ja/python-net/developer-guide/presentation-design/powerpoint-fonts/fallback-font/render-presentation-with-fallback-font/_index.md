---
title: Pythonでフォールバックフォントを使用したプレゼンテーションのレンダリング
linktitle: プレゼンテーションのレンダリング
type: docs
weight: 30
url: /ja/python-net/render-presentation-with-fallback-font/
keywords:
- フォールバックフォント
- PowerPointのレンダリング
- プレゼンテーションのレンダリング
- スライドのレンダリング
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET でフォールバックフォントを使用してプレゼンテーションをレンダリングし、PPT、PPTX、ODP 間でテキストを一貫させるためのステップバイステップコードサンプルをご提供します。"
---

以下の例では、次の手順が含まれます：

1. フォールバックフォント規則コレクションを[作成](/slides/ja/python-net/create-fallback-fonts-collection/)。
2. [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/)でフォールバックフォント規則を削除し、別の規則に[AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/)を追加します。
3. ルールコレクションを[FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)プロパティに設定します。
4. [Presentation.Save()](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)メソッドを使用して、プレゼンテーションを同じ形式で保存することも、別の形式で保存することもできます。フォールバックフォント規則コレクションがFontsManagerに設定されると、これらの規則はプレゼンテーションに対するすべての操作（保存、レンダリング、変換など）に適用されます。
```py
import aspose.slides as slides

# ルールコレクションの新しいインスタンスを作成
rulesList = slides.FontFallBackRulesCollection()

# 複数のルールを作成
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# ロードされたルールからフォールバックフォント "Tahoma" を削除しようとしています
	fallBackRule.remove("Tahoma")

	# 指定された範囲のルールを更新
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# また、リストから既存のルールをすべて削除できます
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# 使用するために準備したルールリストを割り当て
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# 初期化されたルールコレクションを使用してサムネイルをレンダリングし、PNGとして保存
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```


{{% alert color="primary" %}} 
PythonでPowerPointスライドをPNGに変換する方法の詳細をご覧ください。
{{% /alert %}}