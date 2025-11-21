---
title: PowerPoint プレゼンテーションをノート付きで TIFF に変換 (.NET)
linktitle: PowerPoint をノート付きで TIFF に
type: docs
weight: 100
url: /ja/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint の変換
- プレゼンテーションの変換
- スライドの変換
- PPT の変換
- PPTX の変換
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
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションをノート付きで TIFF に変換します。スピーカーノート付きスライドを効率的にエクスポートする方法を学びましょう。"
---

## **概要**

Aspose.Slides for .NET は、ノート付きの PowerPoint および OpenDocument プレゼンテーション (PPT、PPTX、ODP) を TIFF 形式に変換するシンプルなソリューションを提供します。この形式は、高品質な画像保存、印刷、文書アーカイブに広く使用されています。Aspose.Slides を使用すると、スピーカーノート付きのプレゼンテーション全体をエクスポートできるだけでなく、ノートスライドビューでスライドサムネイルを生成することもできます。変換プロセスはシンプルで効率的で、[プレゼンテーション](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスの `Save` メソッドを利用して、ノートとレイアウトを保持しながらプレゼンテーション全体を一連の TIFF 画像に変換します。

## **ノート付きプレゼンテーションを TIFF に変換**

PowerPoint または OpenDocument プレゼンテーションを Aspose.Slides for .NET でノート付き TIFF に保存するには、次の手順を実行します：

1. [プレゼンテーション](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します: PowerPoint または OpenDocument ファイルをロードします。
2. 出力レイアウトオプションを構成します: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用して、ノートとコメントの表示方法を指定します。
3. プレゼンテーションを TIFF に保存します: 構成したオプションを [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッドに渡します。

たとえば、以下のスライドを含む "speaker_notes.pptx" ファイルがあるとします:

![ノート付きプレゼンテーションスライド](slide_with_notes.png)

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

![ノート付き TIFF 画像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose の [無料 PowerPoint からポスタ―変換ツール](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) をチェックしてください。
{{% /alert %}}

## **よくある質問**

**変換後の TIFF でノート領域の位置を制御できますか？**

はい。 [ノートレイアウト設定](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) を使用して、`None`、`BottomTruncated`、`BottomFull` などのオプションから選択できます。これらはそれぞれノートを非表示にしたり、1 ページに収めたり、追加ページに流したりします。

**ノート付き TIFF ファイルのサイズを、品質に目立った影響を与えずに削減するには？**

効率的な圧縮方式 (例: `LZW` または `RLE`) を選択し、適切な DPI を設定します。また、許容できる場合は、[ピクセル形式](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) を低いもの (8 ビット/ピクセルや 1 ビット/ピクセルのモノクロ) に設定します。[画像サイズ](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) をやや小さくすることでも、可読性に大きな影響を与えずにファイルサイズを減らせます。

**システムに元のフォントが存在しない場合、ノートのフォントは結果に影響しますか？**

はい。フォントが見つからないと [置換](/slides/ja/net/font-selection-sequence/) が発生し、テキストのメトリックや外観が変わる可能性があります。この問題を防ぐには、[必要なフォントを提供](/slides/ja/net/custom-font/) するか、デフォルトの [フォールバックフォント](/slides/ja/net/fallback-font/) を設定して、意図した書体が使用されるようにしてください。