---
title: Python でプレゼンテーション用フォールバックフォントを指定する
linktitle: フォールバックフォント
type: docs
weight: 10
url: /ja/python-net/create-fallback-font/
keywords:
- フォールバックフォント
- フォールバックルール
- フォントの適用
- フォントの置換
- Unicode 範囲
- 欠落グリフ
- 適切なグリフ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を .NET 経由でマスターし、PPT、PPTX、ODP ファイルのフォールバックフォントを設定して、あらゆるデバイスや OS でテキスト表示が一貫するように保護します。"
---

## **フォールバックフォントの指定**

Aspose.Slides は [IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/) インターフェイスと [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) クラスをサポートし、フォールバックフォントを適用するルールを指定できます。[FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) クラスは、見つからなかったグリフを検索するために使用される Unicode 範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連を表します:
```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#複数の方法でフォントリストを追加できます:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```




既存の [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) オブジェクトに対して、フォールバックフォントを [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/) で削除したり、[AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) で追加したりすることも可能です。

複数の Unicode 範囲に対してフォールバックフォント置換ルールを指定する必要がある場合は、[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) を使用して [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) オブジェクトのリストを整理できます。

{{% alert color="primary" title="See also" %}} 
- [フォールバックフォント コレクションの作成](/slides/ja/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**フォールバックフォント、フォント置換、フォント埋め込みの違いは何ですか？**

フォールバックフォントは、プライマリフォントに文字が欠けている場合にのみ使用されます。[フォント置換](/slides/ja/python-net/font-substitution/) は、指定されたフォント全体を別のフォントに置き換えます。[フォント埋め込み](/slides/ja/python-net/embedded-font/) は、フォントを出力ファイルにパッケージ化し、受信者が意図した通りにテキストを表示できるようにします。

**PDF、PNG、SVG などへのエクスポート時にもフォールバックフォントは適用されますか、それとも画面表示時だけですか？**

はい。フォールバックは、文字を描画する必要があるすべての [レンダリングおよびエクスポート操作](/slides/ja/python-net/convert-presentation/) に影響します。

**フォールバックの設定はプレゼンテーションファイル自体を変更しますか？ 将来開くときに設定は保持されますか？**

いいえ。フォールバックルールはコード内の実行時レンダリング設定であり、.pptx ファイルに保存されず、PowerPoint では表示されません。

**オペレーティングシステム（Windows/Linux/macOS）やフォントディレクトリの設定はフォールバック選択に影響しますか？**

はい。エンジンは利用可能なシステムフォルダや、指定した [追加パス](/slides/ja/python-net/custom-font/) からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照するルールは効果を発揮できません。

**フォールバックは WordArt、SmartArt、チャートでも機能しますか？**

はい。これらのオブジェクトにテキストが含まれる場合、同じグリフ置換メカニズムが適用され、欠落文字がレンダリングされます。