---
title: フォールバックフォントコレクションの作成
type: docs
weight: 20
url: /python-net/create-fallback-fonts-collection/
keywords: "フォールバックフォントコレクション、PowerPointプレゼンテーション、Python、.NET経由のAspose.Slides for Python"
description: "PythonでのPowerPointにおけるフォールバックフォントコレクション"
---

[FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/)クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/)に整理され、このコレクションは[IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/)インターフェイスを実装しています。コレクションからルールを追加または削除することが可能です。

その後、このコレクションは[FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)クラスの[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)プロパティに割り当てることができます。FontsManagerはプレゼンテーション全体のフォントを管理します。詳細は[FontsManagerとFontsLoaderについて](/slides/python-net/about-fontsmanager-and-fontsloader/)をお読みください。

各[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)には、独自のFontsManagerインスタンスを持つ[FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)プロパティがあります。

以下は、フォールバックフォントルールのコレクションを作成し、特定のプレゼンテーションのFontsManagerに割り当てる方法の例です：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

FontsManagerがフォールバックフォントコレクションで初期化された後、フォールバックフォントはプレゼンテーションのレンダリング中に適用されます。

{{% alert color="primary" %}} 
フォールバックフォントでプレゼンテーションを[レンダリングする方法](/slides/python-net/render-presentation-with-fallback-font/)についてさらにお読みください。
{{% /alert %}}