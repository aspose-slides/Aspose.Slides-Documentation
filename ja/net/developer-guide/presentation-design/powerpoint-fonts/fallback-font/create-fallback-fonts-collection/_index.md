---
title: フォールバックフォントコレクションの作成
type: docs
weight: 20
url: /net/create-fallback-fonts-collection/
keywords: "フォールバックフォントコレクション, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETにおけるPowerPointのフォールバックフォントコレクション"
---

[FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule)クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)に整理することができ、これは[IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection)インターフェースを実装しています。 コレクションからルールを追加または削除することが可能です。

その後、このコレクションは[FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager)クラスの[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)プロパティに割り当てられることがあります。 FontsManagerはプレゼンテーション全体のフォントを管理します。詳細については、[FontsManagerとFontsLoaderについて](/slides/net/about-fontsmanager-and-fontsloader/)をお読みください。

各[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)には、自分のFontsManagerインスタンスを持つ[FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager)プロパティがあります。

フォールバックフォントルールのコレクションを作成し、特定のプレゼンテーションのFontsManagerに割り当てる方法の例を以下に示します： 

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

FontsManagerがフォールバックフォントコレクションで初期化されると、プレゼンテーションのレンダリング中にフォールバックフォントが適用されます。

{{% alert color="primary" %}} 
フォールバックフォントを使ってプレゼンテーションを[レンダリングする方法](/slides/net/render-presentation-with-fallback-font/)についての詳細をお読みください。
{{% /alert %}}