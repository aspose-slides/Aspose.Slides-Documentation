---
title: JavaScriptでノート付きPowerPointをTIFFに変換
linktitle: ノート付きPowerPointをTIFFに変換
type: docs
weight: 100
url: /ja/nodejs-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint を TIFF に変換
- プレゼンテーションを TIFF に変換
- スライドを TIFF に変換
- PPT を TIFF に変換
- PPTX を TIFF に変換
- ODP を TIFF に変換
- PowerPoint を TIFF に変換
- プレゼンテーションを TIFF に変換
- スライドを TIFF に変換
- PPT を TIFF に変換
- PPTX を TIFF に変換
- ODP を TIFF に変換
- ノート付き PowerPoint
- ノート付きプレゼンテーション
- ノート付きスライド
- ノート付き PPT
- ノート付き PPTX
- ノート付き ODP
- ノート付き TIFF
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument プレゼンテーションをノート付きで TIFF に変換します。スライドのスピーカーノートを効率的にエクスポートする方法を学びましょう。"
---

## **概要**

Aspose.Slides for Node.js via Java は、メモ付きの PowerPoint および OpenDocument プレゼンテーション（PPT、PPTX、ODP）を TIFF 形式に変換するシンプルなソリューションを提供します。この形式は、高品質な画像保存、印刷、文書アーカイブに広く使用されています。Aspose.Slides を使用すると、スピーカーノート付きのプレゼンテーション全体をエクスポートできるだけでなく、Notes Slide ビューでスライドのサムネイルを生成することもできます。変換プロセスはシンプルで効率的で、`save` メソッドを利用して [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラス全体を一連の TIFF 画像に変換し、メモとレイアウトを保持します。

## **メモ付きでプレゼンテーションを TIFF に変換**

Aspose.Slides for Node.js via Java を使用して、メモ付きで PowerPoint または OpenDocument プレゼンテーションを TIFF に保存する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスをインスタンス化します：PowerPoint または OpenDocument ファイルをロードします。
1. 出力レイアウトオプションを構成します：[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) クラスを使用して、メモやコメントの表示方法を指定します。
1. プレゼンテーションを TIFF に保存します：構成したオプションを [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) メソッドに渡します。

たとえば、"speaker_notes.pptx" ファイルに次のスライドがあるとします：

![スピーカーノート付きのプレゼンテーションスライド](slide_with_notes.png)

以下のコードスニペットは、[setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) メソッドを使用して、Notes Slide ビューでプレゼンテーションを TIFF 画像に変換する方法を示しています。
```js
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // スライドの下にノートを表示します。

    // Notes レイアウトを使用して TIFF オプションを設定します。
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // スピーカーノート付きでプレゼンテーションを TIFF に保存します。
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


結果：

![スピーカーノート付きの TIFF 画像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose の [無料 PowerPoint からポスターへの変換ツール](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) をチェックしてください。
{{% /alert %}}

## **よくある質問**

**結果の TIFF のノート領域の位置を制御できますか？**

はい。[notes layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) を使用して、`None`、`BottomTruncated`、`BottomFull` などのオプションから選択できます。これらはそれぞれ、ノートを非表示にし、単一ページに収め、または追加ページに続けて表示します。

**メモ付きの TIFF ファイルのサイズを、品質の目に見える低下なしに減らすにはどうすればよいですか？**

[efficient compression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/)（例：`LZW` または `RLE`）を選択し、適切な DPI を設定し、許容できる場合は低い [pixel format](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/setpixelformat/)（例えば 8 bpp またはモノクロ用の 1 bpp）を使用します。[image dimensions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/setimagesize/) をわずかに縮小することでも、可読性に目立った影響を与えずにサイズ削減が可能です。

**システムに元のフォントが存在しない場合、ノートのフォントは結果に影響しますか？**

はい。フォントが欠落していると [substitution](/slides/ja/nodejs-java/font-selection-sequence/) が発生し、テキストのメトリクスや外観が変わる可能性があります。これを防ぐには、[required fonts](/slides/ja/nodejs-java/custom-font/) を提供するか、デフォルトの [fallback font](/slides/ja/nodejs-java/fallback-font/) を設定して、意図したフォントが使用されるようにしてください。