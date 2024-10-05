---
title: フォールバックフォントの作成
type: docs
weight: 10
url: /net/create-fallback-font/
keywords: "フォント, フォールバックフォント, PowerPointプレゼンテーション C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET における PowerPoint のフォールバックフォント"
---

Aspose.Slidesは、フォールバックフォントを適用するためのルールを指定するための[IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule)インターフェースと[FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule)クラスをサポートしています。[FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule)クラスは、欠けているグリフを検索するために使用される指定されたUnicode範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連を表します：

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//複数の方法を使用してフォントリストを追加できます：
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```



フォールバックフォントを[Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove)したり、既存の[FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule)オブジェクトに[AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts)を追加することも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)は、複数のUnicode範囲のフォールバックフォントの置き換えルールを指定する必要がある場合に、[FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule)オブジェクトのリストを整理するために使用できます。

{{% alert color="primary" title="関連情報" %}} 
- [フォールバックフォントコレクションの作成](/slides/net/create-fallback-fonts-collection/)
{{% /alert %}}