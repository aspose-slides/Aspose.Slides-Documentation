---
title: PowerPointをC#でノート付きTIFFに変換
linktitle: PowerPointをノート付きTIFFに変換
type: docs
weight: 100
url: /ja/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPointをTIFFに変換
- プレゼンテーションをTIFFに変換
- スライドをTIFFに変換
- PPTをTIFFに変換
- PPTXをTIFFに変換
- ODPをTIFFに変換
- PowerPointをTIFFに変換
- プレゼンテーションをTIFFに変換
- スライドをTIFFに変換
- PPTをTIFFに変換
- PPTXをTIFFに変換
- ODPをTIFFに変換
- ノート付きPowerPoint
- ノート付きプレゼンテーション
- ノート付きスライド
- ノート付きPPT
- ノート付きPPTX
- ノート付きODP
- ノート付きTIFF
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションをノート付き TIFF に変換します。スピーカーノート付きスライドを効率的にエクスポートする方法を学びましょう。"
---

## **概要**

Aspose.Slides for .NET は、PowerPoint および OpenDocument プレゼンテーション (PPT、PPTX、ODP) をノート付きで TIFF 形式に変換するシンプルなソリューションを提供します。この形式は高品質な画像保存、印刷、文書アーカイブに広く利用されています。Aspose.Slides を使用すれば、スピーカーノートを含むプレゼンテーション全体をエクスポートできるだけでなく、Notes スライドビューでスライドサムネイルを生成することもできます。変換プロセスはシンプルで効率的で、`Save` メソッドと [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスを利用して、ノートとレイアウトを保持しながらプレゼンテーション全体を一連の TIFF 画像に変換します。

## **プレゼンテーションを Notes 付き TIFF に変換**

Aspose.Slides for .NET を使用して PowerPoint または OpenDocument プレゼンテーションをノート付きで TIFF に保存する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスをインスタンス化して PowerPoint または OpenDocument ファイルをロードします。
1. 出力レイアウトオプションを構成します。[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用してノートとコメントの表示方法を指定します。
1. プレゼンテーションを TIFF に保存します。構成したオプションを [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッドに渡します。

たとえば、次のスライドを含む "speaker_notes.pptx" ファイルがあるとします。

![The presentation slide with speaker notes](slide_with_notes.png)

以下のコードスニペットは、[SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) プロパティを使用して Notes スライドビューでプレゼンテーションを TIFF 画像に変換する方法を示しています。
```c#
 // プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Notes レイアウトで TIFF オプションを構成します。
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // スライドの下にノートを表示します。
        }
    };

    // スピーカーノート付きでプレゼンテーションを TIFF に保存します。
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```


結果:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Aspose の [無料 PowerPoint からポスターへのコンバータ](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) をお試しください。

{{% /alert %}}

## **FAQ**

**結果の TIFF でノート領域の位置を制御できますか？**

はい。[notes layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) を使用して、`None`、`BottomTruncated`、`BottomFull` のいずれかを選択できます。これらはそれぞれ、ノートを非表示にする、1 ページに収める、または複数ページにわたって表示することを意味します。

**品質の目立った低下なしにノート付き TIFF ファイルのサイズを削減する方法は？**

[efficient compression](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/)（例: `LZW` または `RLE`）を選び、適切な DPI を設定し、許容できる場合は低い [pixel format](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/)（例えば 8 bpp やモノクロ用の 1 bpp）を使用します。また、[image dimensions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) を僅かに縮小することでも、可読性に大きな影響を与えずにサイズ削減が可能です。

**ノートのフォントがシステムに存在しない場合、結果に影響しますか？**

はい。フォントが見つからないと [substitution](/slides/ja/net/font-selection-sequence/) が発生し、テキストのメトリクスや外観が変わる可能性があります。これを防ぐには、[required fonts](/slides/ja/net/custom-font/) を提供するか、デフォルトの [fallback font](/slides/ja/net/fallback-font/) を設定して、意図した書体が使用されるようにしてください。