---
title: PHPでノート付きPowerPointプレゼンテーションをTIFFに変換
linktitle: ノート付きPowerPointからTIFFへ
type: docs
weight: 100
url: /ja/php-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointをTIFFへ
- プレゼンテーションをTIFFへ
- スライドをTIFFへ
- PPTをTIFFへ
- PPTXをTIFFへ
- PPTをTIFFとして保存
- PPTXをTIFFとして保存
- PPTをTIFFにエクスポート
- PPTXをTIFFにエクスポート
- ノート付きPowerPoint
- ノート付きプレゼンテーション
- ノート付きスライド
- ノート付きPPT
- ノート付きPPTX
- ノート付きTIFF
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、ノート付きPowerPointプレゼンテーションをTIFFに変換します。スピーカーノート付きスライドを効率的にエクスポートする方法を学びましょう。"
---

## **概要**

Aspose.Slides for PHP via Java は、ノート付きの PowerPoint および OpenDocument プレゼンテーション (PPT、PPTX、ODP) を TIFF 形式に変換するシンプルなソリューションを提供します。TIFF は高品質な画像の保存、印刷、文書アーカイブに広く利用されています。Aspose.Slides を使用すれば、スライド全体をスピーカーノート付きでエクスポートできるだけでなく、Notes Slide ビューでスライドサムネイルを生成することもできます。変換プロセスはシンプルかつ効率的で、`save` メソッドを利用して [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラス全体を一連の TIFF 画像に変換し、ノートとレイアウトを保持します。

## **プレゼンテーションをノート付き TIFF に変換**

Aspose.Slides for PHP via Java でノート付きの PowerPoint または OpenDocument プレゼンテーションを TIFF に保存する手順は次の通りです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスをインスタンス化します: PowerPoint または OpenDocument ファイルをロードします。
1. 出力レイアウトオプションを設定します: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) クラスを使用して、ノートとコメントの表示方法を指定します。
1. プレゼンテーションを TIFF に保存します: 設定したオプションを [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) メソッドに渡します。

たとえば、次のスライドを含む "speaker_notes.pptx" ファイルがあるとします。

![ノート付きのプレゼンテーションスライド](slide_with_notes.png)

以下のコードスニペットは、[setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) メソッドを使用して Notes Slide ビューでプレゼンテーションを TIFF 画像に変換する方法を示しています。
```php
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // スライドの下にノートを表示します。

    // Notes レイアウトを使用して TIFF オプションを設定します。
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // スピーカーノート付きでプレゼンテーションを TIFF に保存します。
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```


結果:

![ノート付きの TIFF 画像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose の無料 PowerPoint からポスターへのコンバータをご確認ください: https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online
{{% /alert %}}

## **よくある質問**

**生成された TIFF のノート領域の位置を制御できますか？**

はい。[notes layout settings](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) を使用して、`None`、`BottomTruncated`、`BottomFull` のいずれかを選択できます。これらはそれぞれノートを非表示にする、1 ページに収める、または複数ページにわたって表示する設定です。

**品質の目立った低下なしにノート付き TIFF ファイルのサイズを削減するにはどうすればよいですか？**

効率的な圧縮 (例: `LZW` または `RLE`) を選び、適切な DPI を設定し、許容できる場合は低い [pixel format](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setpixelformat/) (8 bpp やモノクロ用の 1 bpp など) を使用します。また、[image dimensions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setimagesize/) をやや小さくすることで、可読性に大きな影響を与えずにサイズを減らすことができます。

**元のフォントがシステムに存在しない場合、ノートのフォントは結果に影響しますか？**

はい。フォントが欠落すると [substitution](/slides/ja/php-java/font-selection-sequence/) が発生し、テキストのメトリクスや外観が変わる可能性があります。これを防ぐには、[必要なフォントを供給](/slides/ja/php-java/custom-font/) するか、デフォルトの [fallback font](/slides/ja/php-java/fallback-font/) を設定して、意図した書体が使用されるようにします。