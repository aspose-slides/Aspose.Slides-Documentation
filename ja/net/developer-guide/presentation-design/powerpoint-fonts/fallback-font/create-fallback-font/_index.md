---
title: .NET のプレゼンテーションでフォールバック フォントを指定する
linktitle: フォールバック フォント
type: docs
weight: 10
url: /ja/net/create-fallback-font/
keywords:
- フォールバック フォント
- フォールバック ルール
- フォントの適用
- フォントの置換
- Unicode 範囲
- 欠落グリフ
- 適切なグリフ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PPT、PPTX、ODP ファイルにフォールバック フォントを設定し、あらゆるデバイスや OS でテキストの表示を一貫させます。"
---
## **概要**

Aspose.Slides は、プレゼンテーションのレンダリングおよびエクスポート操作にフォールバック フォントを指定できるようにします。プライマリ フォントに特定の文字のグリフが含まれていない場合に、フォールバック フォントが使用されます。

フォールバックの動作はフォールバック ルールで構成されます。各ルールは Unicode 範囲と、必要なグリフを含む可能性のある 1 つ以上のフォントを関連付けます。さまざまな文字範囲に対してルールを定義したり、既存のルールからフォールバック フォントを追加または削除したり、複数のルールをフォールバック フォント ルール コレクションに整理したりできます。

フォールバック ルールは実行時のレンダリング設定です。プレゼンテーション ファイル自体は変更されず、PPTX ファイル内に保存されません。

## **フォールバック ルール**

Aspose.Slides は、[IFontFallBackRule](https://reference.aspose.com/slides/ja/net/aspose.slides/iFontFallBackRule) インターフェイスおよび [FontFallBackRule](https://reference.aspose.com/slides/ja/net/aspose.slides/FontFallBackRule) クラスをサポートし、フォールバック フォントを適用するルールを指定できます。[FontFallBackRule](https://reference.aspose.com/slides/ja/net/aspose.slides/FontFallBackRule) クラスは、見つからないグリフの検索に使用される Unicode 範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連付けを表します。

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//複数の方法でフォントリストを追加できます:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

既存の [FontFallBackRule](https://reference.aspose.com/slides/ja/net/aspose.slides/FontFallBackRule) オブジェクトに対して、[Remove()](https://reference.aspose.com/slides/ja/net/aspose.slides/ifontfallbackrule/methods/remove) でフォールバック フォントを削除したり、[AddFallBackFonts()](https://reference.aspose.com/slides/ja/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) でフォールバック フォントを追加したりすることも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/ja/net/aspose.slides/fontfallbackrulescollection)は、複数の Unicode 範囲に対してフォールバック フォント置換ルールを指定する必要がある場合に、[FontFallBackRule](https://reference.aspose.com/slides/ja/net/aspose.slides/FontFallBackRule) オブジェクトのリストを整理するために使用できます。

{{% alert color="info" title="参照" %}} 
- [フォント コレクションの作成](/slides/ja/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **よくある質問**

### フォールバック フォント、フォント置換、フォント埋め込みの違いは何ですか？

フォールバック フォントはプライマリ フォントに存在しない文字に対してのみ使用されます。[フォント置換](/slides/ja/net/font-substitution/) は指定されたフォント全体を別のフォントに置き換えます。[フォント埋め込み](/slides/ja/net/embedded-font/) はフォントを出力ファイルにパッケージ化し、受信者が意図した通りにテキストを表示できるようにします。

### フォールバックは PDF、PNG、SVG などのエクスポート時にも適用されますか、画面上のレンダリング時だけですか？

はい。フォールバックは文字を描画する必要があるがソース フォントに存在しないすべての[レンダリングおよびエクスポート操作](/slides/ja/net/convert-presentation/)に影響します。

### フォールバックの設定はプレゼンテーション ファイル自体を変更しますか、将来のオープン時に設定が保持されますか？

いいえ。フォールバック ルールはコード内の実行時レンダリング設定であり、.pptx に保存されず、PowerPoint には表示されません。

### OS（Windows/Linux/macOS）やフォント ディレクトリのセットはフォールバックの選択に影響しますか？

はい。エンジンは利用可能なシステム フォルダと、提供された[追加パス](/slides/ja/net/custom-font/)からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照するルールは効果を発揮できません。

### フォールバックは WordArt、SmartArt、チャートでも機能しますか？

はい。これらのオブジェクトにテキストが含まれる場合、同じグリフ置換メカニズムが適用され、欠落した文字が正しく描画されます。