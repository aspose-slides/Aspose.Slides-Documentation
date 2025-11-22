---
title: フォールバック フォントの作成
type: docs
weight: 10
url: /ja/net/create-fallback-font/
keywords: "フォント、フォールバック フォント、PowerPoint プレゼンテーション C#、Csharp、Aspose.Slides for .NET"
description: "PowerPoint のフォールバック フォント（C# または .NET）"
---

## **フォールバック ルール**

Aspose.Slides は [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) インターフェイスと [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) クラスをサポートし、フォールバック フォントを適用するルールを指定できます。[FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) クラスは、欠落したグリフの検索に使用される指定された Unicode 範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連を表します:
```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//複数の方法でフォントリストを追加できます:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


既存の [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) オブジェクトにフォールバック フォントを [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) したり、[AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) で追加したりすることも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) は、複数の Unicode 範囲に対してフォールバック フォント置換ルールを指定する必要がある場合、[FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) オブジェクトのリストを整理できるように使用できます。

{{% alert color="primary" title="参照" %}} 
- [フォールバック フォント コレクションの作成](/slides/ja/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **よくある質問**

**フォールバック フォント、フォント置換、およびフォント埋め込みの違いは何ですか？**

フォールバック フォントは、プライマリ フォントに存在しない文字に対してのみ使用されます。[Font substitution](/slides/ja/net/font-substitution/) は、指定されたフォント全体を別のフォントに置き換えます。[Font embedding](/slides/ja/net/embedded-font/) は、フォントを出力ファイルにパッケージ化し、受信者が意図した通りにテキストを表示できるようにします。

**PDF、PNG、SVG などのエクスポート時にもフォールバック フォントは適用されますか、それとも画面表示時のみですか？**

はい。フォールバックは、文字を描画する必要があるが元のフォントに存在しない場合のすべての[rendering and export operations](/slides/ja/net/convert-presentation/)に影響します。

**フォールバックの設定を構成するとプレゼンテーション ファイル自体が変更されますか、また設定は将来の開封時にも保持されますか？**

いいえ。フォールバック ルールはコード内の実行時レンダリング設定であり、.pptx に保存されず、PowerPoint でも表示されません。

**オペレーティングシステム (Windows/Linux/macOS) およびフォント ディレクトリのセットは、フォールバックの選択に影響しますか？**

はい。エンジンは利用可能なシステム フォルダと、提供された[additional paths](/slides/ja/net/custom-font/)からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照するルールは機能しません。

**フォールバックは WordArt、SmartArt、チャートでも機能しますか？**

はい。これらのオブジェクトにテキストが含まれる場合、同じグリフ置換メカニズムが適用され、欠落した文字がレンダリングされます。