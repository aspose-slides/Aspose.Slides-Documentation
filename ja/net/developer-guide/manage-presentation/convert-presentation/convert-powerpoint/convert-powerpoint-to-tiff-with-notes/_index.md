---
title: .NET でノート付き PowerPoint プレゼンテーションを TIFF に変換
linktitle: PowerPoint をノート付きで TIFF に変換
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
description: "Aspose.Slides for .NET を使用して、ノート付き PowerPoint プレゼンテーションを TIFF に変換します。スピーカーノート付きスライドを効率的にエクスポートする方法を学びましょう。"
---
## **イントロダクション**

Aspose.Slides for .NET は、PowerPoint および OpenDocument プレゼンテーション（PPT、PPTX、ODP）とノートを TIFF 形式に変換するシンプルなソリューションを提供します。この形式は、高品質な画像保存、印刷、文書アーカイブに広く使用されています。Aspose.Slides を使用すれば、スピーカーノート付きのプレゼンテーション全体をエクスポートできるだけでなく、ノートスライドビューでスライドサムネイルを生成することもできます。変換プロセスは簡単かつ効率的で、`Save` メソッドを使用して [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラス全体を一連の TIFF 画像に変換し、ノートとレイアウトを保持します。

## **ノート付きでプレゼンテーションを TIFF に変換する**

Aspose.Slides for .NET で PowerPoint または OpenDocument プレゼンテーションをノート付きの TIFF に保存する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスをインスタンス化して、PowerPoint または OpenDocument ファイルを読み込みます。  
1. 出力レイアウトオプションを構成します。[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用して、ノートとコメントの表示方法を指定します。  
1. プレゼンテーションを TIFF に保存します。構成したオプションを [Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/methods/save/index) メソッドに渡します。

例えば、次のスライドを含む "speaker_notes.pptx" ファイルがあるとします。

![スライドとスピーカーノート](slide_with_notes.png)

以下のコードスニペットは、[SlidesLayoutOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) プロパティを使用して、ノートスライドビューでプレゼンテーションを TIFF 画像に変換する方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // ノートレイアウト付きで TIFF オプションを構成します。
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

{{% alert title="ヒント" color="info" %}}
Aspose の [無料 PowerPoint からポスタ―への変換ツール](https://products.aspose.app/slides/ja/conversion/convert-ppt-to-poster-online) をチェックしてください。
{{% /alert %}}

## **FAQ**

### 結果の TIFF でノート領域の位置を制御できますか？

はい。[ノートレイアウト設定](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) を使用して、`None`、`BottomTruncated`、`BottomFull` などのオプションから選択できます。これらはそれぞれ、ノートを非表示にする、単一ページに収める、または追加ページに続けて表示することを意味します。

### ノート付きの TIFF ファイルサイズを、画質の目立った低下なしに削減する方法は？

効率的な圧縮方式（例: `LZW` または `RLE`）を選び、適切な DPI を設定し、許容できる場合は低い [ピクセル形式](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/pixelformat/)（例: 8 bpp または 1 bpp のモノクロ）を使用します。[画像サイズ](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/imagesize/) を若干小さくすると、可読性に目立った影響を与えずにサイズ削減に役立ちます。

### 元のフォントがシステムにない場合、ノートのフォントは結果に影響しますか？

はい。フォントが見つからないと [代替フォント置換](/slides/ja/net/font-selection-sequence/) が発生し、テキストのメトリクスと外観が変わる可能性があります。これを防ぐには、[必要なフォントを提供](/slides/ja/net/custom-font/) するか、デフォルトの [フォールバックフォント](/slides/ja/net/fallback-font/) を設定して、意図した書体が使用されるようにしてください。