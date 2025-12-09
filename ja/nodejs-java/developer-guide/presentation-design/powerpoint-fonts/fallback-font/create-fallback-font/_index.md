---
title: フォールバック フォントの作成
type: docs
weight: 10
url: /ja/nodejs-java/create-fallback-font/
---

## **フォールバック ルール**

Aspose.Slides は [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) クラスと [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) クラスをサポートし、フォールバック フォントを適用するルールを指定できます。[FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) クラスは、欠落したグリフの検索に使用される指定された Unicode 範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連付けを表します:
```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// 複数の方法でフォントリストを追加できます:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```


既存の [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) オブジェクトに対して、fallback フォントを [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) したり、[addFallBackFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) したりすることも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) は、複数の Unicode 範囲に対してフォールバック フォントの置換ルールを指定する必要がある場合に、[FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) オブジェクトのリストを整理するために使用できます。

{{% alert color="primary" title="参照" %}} 
- [フォールバック フォント コレクションの作成](/slides/ja/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **よくある質問**

**フォールバック フォント、フォント置換、フォント埋め込みの違いは何ですか？**

フォールバック フォントは、プライマリ フォントに存在しない文字に対してのみ使用されます。[Font substitution](/slides/ja/nodejs-java/font-substitution/) は、指定されたフォント全体を別のフォントに置き換えます。[Font embedding](/slides/ja/nodejs-java/embedded-font/) は、フォントを出力ファイルにパッケージ化し、受信者が意図した通りにテキストを表示できるようにします。

**フォールバック フォントは、PDF、PNG、SVG などへのエクスポート時に適用されますか、それとも画面表示時のみですか？**

はい。フォールバックは、文字を描画する必要があるが元のフォントに存在しない場合のすべての [rendering and export operations](/slides/ja/nodejs-java/convert-presentation/) に影響します。

**フォールバックを設定してもプレゼンテーション ファイル自体が変更されますか？また、その設定は将来の開封時にも保持されますか？**

いいえ。フォールバック ルールはコード内の実行時レンダリング設定であり、.pptx 内に保存されず、PowerPoint でも表示されません。

**オペレーティング システム (Windows/Linux/macOS) およびフォント ディレクトリの構成は、フォールバックの選択に影響しますか？**

はい。エンジンは利用可能なシステム フォルダーと、提供された任意の [additional paths](/slides/ja/nodejs-java/custom-font/) からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照するルールは適用されません。

**フォールバックは WordArt、SmartArt、チャートでも機能しますか？**

はい。これらのオブジェクトにテキストが含まれる場合、同じグリフ 置換メカニズムが適用され、欠損文字が描画されます。