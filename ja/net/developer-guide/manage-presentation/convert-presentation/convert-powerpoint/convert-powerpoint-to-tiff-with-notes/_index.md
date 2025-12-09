---
title: .NETでノート付きPowerPointプレゼンテーションをTIFFに変換
linktitle: ノート付きPowerPointからTIFFへ
type: docs
weight: 100
url: /ja/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint を変換
- プレゼンテーション を変換
- スライド を変換
- PPT を変換
- PPTX を変換
- PowerPoint を TIFF に
- プレゼンテーション を TIFF に
- スライド を TIFF に
- PPT を TIFF に
- PPTX を TIFF に
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
description: "Aspose.Slides for .NET を使用して、ノート付き PowerPoint プレゼンテーションを TIFF に変換します。スライドとスピーカーノートを効率的にエクスポートする方法を学びます。"
---

## **概要**

Aspose.Slides for .NET は、ノート付きの PowerPoint および OpenDocument プレゼンテーション（PPT、PPTX、ODP）を TIFF 形式に変換するシンプルなソリューションを提供します。この形式は高品質な画像保存、印刷、文書アーカイブに広く利用されています。Aspose.Slides を使用すると、スピーカーノート付きのプレゼンテーション全体をエクスポートできるだけでなく、Notes Slide ビューでスライドのサムネイルを生成することも可能です。変換プロセスはシンプルで効率的で、`Save` メソッドを利用して [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラス全体のプレゼンテーションを一連の TIFF 画像に変換し、ノートとレイアウトを保持します。

## **プレゼンテーションをノート付きの TIFF に変換**

Aspose.Slides for .NET を使用して、ノート付きで PowerPoint または OpenDocument プレゼンテーションを TIFF に保存するには、次の手順が必要です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します: PowerPoint または OpenDocument ファイルをロードします。
2. 出力レイアウトオプションを構成します: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用して、ノートとコメントの表示方法を指定します。
3. プレゼンテーションを TIFF に保存します: 設定したオプションを [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッドに渡します。

たとえば、"speaker_notes.pptx" ファイルに次のスライドがあるとします。

![スピーカーノート付きのプレゼンテーションスライド](slide_with_notes.png)

以下のコードスニペットは、[SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) プロパティを使用して、Notes Slide ビューでプレゼンテーションを TIFF 画像に変換する方法を示しています。
```c#
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // ノートのレイアウト設定を含む TIFF オプションを構成します。
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

![スピーカーノート付きの TIFF 画像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose の [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) をご確認ください。
{{% /alert %}}

## **よくある質問**

**結果の TIFF のノート領域の位置を制御できますか？**

はい。[notes layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) を使用して、`None`、`BottomTruncated`、`BottomFull` などのオプションから選択できます。これらはそれぞれノートを非表示にし、単一ページに収め、または追加ページに続けて表示します。

**品質の目に見える損失なしで、ノート付き TIFF ファイルのサイズを削減するにはどうすればよいですか？**

[efficient compression](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/)（例: `LZW` や `RLE`）を選択し、適切な DPI を設定します。また、許容できる場合は、[pixel format](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/)（例: 8 bpp や 1 bpp のモノクロ）を低く設定します。[image dimensions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) をわずかに縮小することでも、可読性に大きな影響を与えずにサイズを減らすことができます。

**システムに元のフォントがない場合、ノートのフォントは結果に影響しますか？**

はい。フォントが欠如すると [substitution](/slides/ja/net/font-selection-sequence/) が発生し、テキストのメトリクスや外観が変わる可能性があります。これを防ぐには、[required fonts](/slides/ja/net/custom-font/) を提供するか、デフォルトの [fallback font](/slides/ja/net/fallback-font/) を設定して、意図した書体が使用されるようにします。