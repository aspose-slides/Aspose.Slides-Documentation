---
title: Python でプレゼンテーションのフォールバックフォントを指定
linktitle: フォールバックフォント
type: docs
weight: 10
url: /ja/python-net/create-fallback-font/
keywords:
- フォールバックフォント
- フォールバックルール
- フォントを適用
- フォントを置換
- Unicode 範囲
- 欠落グリフ
- 適切なグリフ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使って PPT、PPTX、ODP ファイルにフォールバックフォントを設定し、あらゆるデバイスや OS で一貫した文字表示を確保します。"
---

Aspose.Slidesは、[IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/)インターフェースと[FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/)クラスをサポートしており、フォールバックフォントを適用するルールを指定できます。[FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/)クラスは、失われたグリフを検索するために使用される指定されたUnicode範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連を表します。

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#複数の方法を使用してフォントリストを追加できます:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

既存の[FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/)オブジェクトに対して、フォールバックフォントを[Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/)で削除したり、[AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/)で追加したりすることも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/)を使用して、複数のUnicode範囲のフォールバックフォント置換ルールを指定する必要がある場合に[FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/)オブジェクトのリストを整理できます。

{{% alert color="primary" title="関連情報" %}} 
- [フォールバックフォントコレクションを作成](/slides/ja/python-net/create-fallback-fonts-collection/)
{{% /alert %}}