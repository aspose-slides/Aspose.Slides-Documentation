---
title: Pythonでプレゼンテーション向けフォールバックフォントを指定する
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
- 欠損グリフ
- 適切なグリフ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET をマスターし、PPT、PPTX、ODP ファイルでフォールバックフォントを設定して、あらゆるデバイスや OS でテキスト表示が一貫するように保護します。"
---

## **フォールバック フォントの指定**

Aspose.Slides は [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) クラスをサポートしており、フォールバック フォントを適用するルールを指定できます。[FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) クラスは、検索対象となる Unicode 範囲と、適切なグリフを含む可能性のあるフォントの一覧との関連付けを表します。
```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#さまざまな方法でフォントリストを追加できます:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```


既存の [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) オブジェクトからフォールバック フォントを [remove](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/remove/) したり、[add_fall_back_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) で追加したりすることも可能です。

複数の Unicode 範囲に対してフォールバック フォント置換ルールを指定する必要がある場合は、[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) を使用して [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) オブジェクトの一覧を整理できます。

{{% alert color="primary" title="See also" %}} 
- [フォールバック フォント コレクションの作成](/slides/ja/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**フォールバック フォント、フォント置換、およびフォント埋め込みの違いは何ですか？**

フォールバック フォントは、プライマリ フォントに存在しない文字に対してのみ使用されます。[フォント置換](/slides/ja/python-net/font-substitution/) は、指定されたフォント全体を別のフォントに置き換えます。[フォント埋め込み](/slides/ja/python-net/embedded-font/) は、フォントを出力ファイルにパッケージ化し、受信者が意図した通りにテキストを表示できるようにします。

**フォールバックは PDF、PNG、SVG などへのエクスポート時にも適用されますか？それとも画面表示時のみですか？**

はい。フォールバックは、文字が描画される必要があるが元のフォントに存在しないすべての [レンダリングおよびエクスポート操作](/slides/ja/python-net/convert-presentation/) に影響します。

**フォールバックの設定はプレゼンテーション ファイル自体を変更しますか？また、設定は将来の開く際にも保持されますか？**

いいえ。フォールバック ルールはコード内の実行時レンダリング設定であり、.pptx に保存されず、PowerPoint には表示されません。

**オペレーティング システム（Windows/Linux/macOS）やフォント ディレクトリのセットは、フォールバックの選択に影響しますか？**

はい。エンジンは利用可能なシステム フォルダーと、指定した [追加パス](/slides/ja/python-net/custom-font/) からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照するルールは機能しません。

**フォールバックは WordArt、SmartArt、チャートでも機能しますか？**

はい。これらのオブジェクトにテキストが含まれる場合、同じグリフ置換メカニズムが適用され、欠落した文字が描画されます。