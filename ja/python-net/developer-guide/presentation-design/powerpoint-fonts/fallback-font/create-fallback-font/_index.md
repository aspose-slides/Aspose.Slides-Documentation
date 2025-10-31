---
title: Python でのプレゼンテーション用フォールバックフォントの指定
linktitle: フォールバックフォント
type: docs
weight: 10
url: /ja/python-net/create-fallback-font/
keywords:
- フォールバックフォント
- フォールバックルール
- フォント適用
- フォント置換
- Unicode 範囲
- 欠損文字
- 正しい文字
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使い、PPT、PPTX、ODP ファイルでフォールバックフォントを設定し、あらゆるデバイスや OS でテキストが一貫して表示されるように保護します。"
---

## **フォールバックフォントの指定**

Aspose.Slides は [IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/) インターフェイスと [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) クラスをサポートし、フォールバックフォントを適用するルールを指定できます。[FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) クラスは、欠損文字の検索に使用される指定された Unicode 範囲と、適切な文字を含む可能性のあるフォントのリストとの関連を表します：

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#複数の方法でフォントリストを追加できます:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

既存の [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) オブジェクトに対して、フォールバックフォントを [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/) したり、[AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) で追加したりすることも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) は、複数の Unicode 範囲に対してフォールバックフォント置換ルールを指定する必要がある場合に、[FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) オブジェクトのリストを整理するために使用できます。

{{% alert color="primary" title="こちらもご参照ください" %}} 
- [フォールバックフォントコレクションの作成](/slides/ja/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **よくある質問**

**フォールバックフォント、フォント置換、フォント埋め込みの違いは何ですか？**

フォールバックフォントは、メインフォントに存在しない文字に対してのみ使用されます。[Font substitution](/slides/ja/python-net/font-substitution/) は、指定されたフォント全体を別のフォントに置き換えます。[Font embedding](/slides/ja/python-net/embedded-font/) は、フォントを出力ファイル内にパッケージ化し、受信者が意図した通りにテキストを表示できるようにします。

**フォールバックフォントは PDF、PNG、SVG などへのエクスポート時にも適用されますか、それとも画面表示時のみですか？**

はい。フォールバックは、文字を描画する必要があるが元のフォントに存在しない場合に、すべての [rendering and export operations](/slides/ja/python-net/convert-presentation/) に影響します。

**フォールバック設定を構成するとプレゼンテーションファイル自体が変更され、将来の開く際にも設定が保持されますか？**

いいえ。フォールバックルールはコード内の実行時レンダリング設定であり、.pptx 内に保存されないため、PowerPoint には表示されません。

**オペレーティングシステム（Windows/Linux/macOS）やフォントディレクトリの設定は、フォールバックの選択に影響しますか？**

はい。エンジンは利用可能なシステムフォルダや、提供した [additional paths](/slides/ja/python-net/custom-font/) からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照するルールは効果を発揮できません。

**フォールバックは WordArt、SmartArt、チャートでも機能しますか？**

はい。これらのオブジェクトにテキストが含まれる場合、同じ文字置換メカニズムが適用され、欠損文字がレンダリングされます。