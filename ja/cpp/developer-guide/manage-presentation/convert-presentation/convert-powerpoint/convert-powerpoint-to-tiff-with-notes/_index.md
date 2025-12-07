---
title: C++ でノート付き PowerPoint プレゼンテーションを TIFF に変換
linktitle: PowerPoint をノート付き TIFF に変換
type: docs
weight: 100
url: /ja/cpp/convert-powerpoint-to-tiff-with-notes/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してノート付き PowerPoint プレゼンテーションを TIFF に変換します。スピーカーノート付きスライドを効率的にエクスポートする方法を学びましょう。"
---

## **概要**

Aspose.Slides for C++ は、PowerPoint および OpenDocument プレゼンテーション（PPT、PPTX、ODP）のノート付きスライドを TIFF 形式に変換するシンプルなソリューションを提供します。この形式は高品質な画像保存、印刷、文書アーカイブに広く使用されています。Aspose.Slides を使用すれば、スピーカーノート付きのプレゼンテーション全体をエクスポートできるだけでなく、Notes Slide ビューでスライドサムネイルを生成することもできます。変換プロセスはシンプルかつ効率的で、`Save` メソッドを利用して [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラス全体を TIFF 画像の連続に変換し、ノートとレイアウトを保持します。

## **プレゼンテーションをノート付きTIFFに変換する**

Aspose.Slides for C++ を使用して PowerPoint または OpenDocument プレゼンテーションをノート付き TIFF に保存する手順は次の通りです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスをインスタンス化して、PowerPoint または OpenDocument ファイルを読み込みます。
1. 出力レイアウトオプションを構成します。ノートやコメントの表示方法を指定するには、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用します。
1. プレゼンテーションを TIFF に保存します。構成したオプションを [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) メソッドに渡します。

たとえば、以下のスライドを含む「speaker_notes.pptx」ファイルがあるとします。

![ノート付きプレゼンテーションスライド](slide_with_notes.png)

以下のコードスニペットは、[set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) メソッドを使用して Notes Slide ビューでプレゼンテーションを TIFF 画像に変換する方法を示しています。
```cpp
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // スライドの下にノートを表示します。

// Notes レイアウトで TIFF オプションを設定します。
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// スピーカーノート付きでプレゼンテーションを TIFF に保存します。
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


結果:

![ノート付きTIFF画像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Aspose の [無料 PowerPoint からポスターへのコンバータ](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) をお試しください。

{{% /alert %}}

## **よくある質問**

**結果の TIFF でノート領域の位置を制御できますか？**

はい。`None`、`BottomTruncated`、`BottomFull` などのオプションから選択できる [notes layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) を使用して、ノートを非表示にしたり、1 ページに収めたり、複数ページにわたって表示したりできます。

**品質の目立った低下なしにノート付き TIFF ファイルのサイズを削減するにはどうすればよいですか？**

[efficient compression](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)（例: `LZW` または `RLE`）を選び、適切な DPI を設定し、許容できる場合は [pixel format](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) を低いビット深度（例: 8 bpp、1 bpp のモノクロ）にします。また、[image dimensions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) を若干小さくすることで、可読性に大きな影響を与えずにサイズを縮小できます。

**ノートのフォントがシステムに存在しない場合、結果に影響がありますか？**

はい。フォントが欠落していると [substitution](/slides/ja/cpp/font-selection-sequence/) が発生し、テキストのメトリクスや外観が変わる可能性があります。これを防ぐには、必要なフォントを [供給](/slides/ja/cpp/custom-font/) するか、デフォルトの [fallback font](/slides/ja/cpp/fallback-font/) を設定して、意図した書体が使用されるようにしてください。