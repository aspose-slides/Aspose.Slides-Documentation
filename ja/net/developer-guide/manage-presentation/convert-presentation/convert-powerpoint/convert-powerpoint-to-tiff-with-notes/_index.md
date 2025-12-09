---
title: PowerPoint プレゼンテーションを .NET でノート付き TIFF に変換
linktitle: PowerPoint をノート付き TIFF に変換
type: docs
weight: 100
url: /ja/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を TIFF に変換
- プレゼンテーションを TIFF に変換
- スライドを TIFF に変換
- PPT を TIFF に変換
- PPTX を TIFF に変換
- PPT を TIFF として保存
- PPTX を TIFF として保存
- PPT を TIFF にエクスポート
- PPTX を TIFF にエクスポート
- ノート付き PowerPoint
- ノート付きプレゼンテーション
- ノート付きスライド
- ノート付き PPT
- ノート付き PPTX
- ノート付き TIFF
- .NET
- C#
- Aspose.Slides
description: Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションをノート付き TIFF に変換します。スピーカーノート付きスライドを効率的にエクスポートする方法をご紹介します。
---

## **概要**

Aspose.Slides for .NET は、PowerPoint および OpenDocument プレゼンテーション (PPT、PPTX、ODP) をノート付きで TIFF 形式に変換するシンプルなソリューションを提供します。この形式は高品質な画像保存、印刷、文書アーカイブで広く利用されています。Aspose.Slides を使用すると、スピーカーノート付きのプレゼンテーション全体をエクスポートできるだけでなく、ノートスライド ビューでスライドサムネイルを生成することもできます。変換プロセスはシンプルで効率的であり、`Save` メソッドを使用して [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスの全体プレゼンテーションを一連の TIFF 画像に変換し、ノートとレイアウトを保持します。

## **ノート付きでプレゼンテーションを TIFF に変換**

Aspose.Slides for .NET を使用して、PowerPoint または OpenDocument プレゼンテーションをノート付きで TIFF に保存するには、次の手順が必要です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンス化: PowerPoint または OpenDocument ファイルをロードします。
2. 出力レイアウトオプションを構成: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用して、ノートとコメントの表示方法を指定します。
3. プレゼンテーションを TIFF に保存: 構成したオプションを [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッドに渡します。

例えば、次のスライドを含む "speaker_notes.pptx" ファイルがあるとします。

![ノート付きのプレゼンテーションスライド](slide_with_notes.png)

以下のコードスニペットは、[SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) プロパティを使用して、ノートスライドビューでプレゼンテーションを TIFF 画像に変換する方法を示しています。
```c#
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します。
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // ノートのレイアウト設定で TIFF オプションを構成します。
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

![ノート付きの TIFF 画像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose の無料 PowerPoint からポスターへのコンバータをご覧ください。
{{% /alert %}}

## **FAQ**

**生成された TIFF のノート領域の位置を制御できますか？**

はい。[notes layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) を使用して、`None`、`BottomTruncated`、`BottomFull` のようなオプションから選択できます。これらはそれぞれノートを非表示にし、1 ページに収め、または複数ページにわたって表示させることを意味します。

**品質の目に見える低下なしで、ノート付き TIFF ファイルのサイズを削減するにはどうすればよいですか？**

効率的な [efficient compression](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/)（例: `LZW` または `RLE`）を選択し、適切な DPI を設定します。また、許容できる場合は、より低い [pixel format](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/)（例: 8 bpp またはモノクロ用の 1 bpp）を使用します。[image dimensions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) を少し削減することも、可読性に目立った影響を与えずに効果的です。

**システムに元のフォントがない場合、ノートのフォントは結果に影響しますか？**

はい。フォントが欠如していると、[substitution](/slides/ja/net/font-selection-sequence/) が発生し、文字メトリクスや外観が変わる可能性があります。これを防ぐには、[supply the required fonts](/slides/ja/net/custom-font/) を提供するか、デフォルトの [fallback font](/slides/ja/net/fallback-font/) を設定して、意図したフォントが使用されるようにします。