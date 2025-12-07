---
title: C++ でノート付き PowerPoint プレゼンテーションを TIFF に変換
linktitle: PowerPoint をノート付きで TIFF に変換
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
description: "Aspose.Slides for C++ を使用して、ノート付き PowerPoint プレゼンテーションを TIFF に変換します。スピーカー ノート付きスライドを効率的にエクスポートする方法を学びましょう。"
---

## **概要**

Aspose.Slides for C++ は、ノート付きの PowerPoint および OpenDocument プレゼンテーション（PPT、PPTX、ODP）を TIFF 形式に変換するシンプルなソリューションを提供します。この形式は、高品質な画像保存、印刷、文書アーカイブで広く使用されています。Aspose.Slides を使用すると、スピーカーノート付きのプレゼンテーション全体をエクスポートできるだけでなく、Notes Slide ビューでスライドサムネイルを生成することもできます。変換プロセスは簡単で効率的で、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスの `Save` メソッドを使用して、ノートとレイアウトを保持しながらプレゼンテーション全体を一連の TIFF 画像に変換します。

## **ノート付きでプレゼンテーションを TIFF に変換する**

Aspose.Slides for C++ でノート付きの PowerPoint または OpenDocument プレゼンテーションを TIFF に保存する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します: PowerPoint または OpenDocument ファイルを読み込みます。
1. 出力レイアウトオプションを構成します: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用して、ノートとコメントの表示方法を指定します。
1. プレゼンテーションを TIFF に保存します: 構成したオプションを [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) メソッドに渡します。

例えば、次のスライドを含む "speaker_notes.pptx" ファイルがあるとします:

![The presentation slide with speaker notes](slide_with_notes.png)

以下のコードスニペットは、[set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) メソッドを使用して Notes Slide ビューでプレゼンテーションを TIFF 画像に変換する方法を示しています。
```cpp
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // スライドの下にノートを表示します。

// ノートのレイアウトを設定して TIFF オプションを構成します。
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// プレゼンテーションをスピーカーノート付きで TIFF に保存します。
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


結果:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose の [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) をチェックしてください。
{{% /alert %}}

## **FAQ**

**結果となる TIFF のノート領域の位置を制御できますか？**

はい。[notes layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) を使用して、`None`、`BottomTruncated`、`BottomFull` のようなオプションから選択できます。これらはそれぞれノートを非表示にし、単一ページに収め、または追加ページに流すことを意味します。

**品質の目立った低下なしにノート付き TIFF ファイルのサイズを削減する方法はありますか？**

効率的な圧縮（例: `LZW` や `RLE`）を選択し、適切な DPI を設定し、許容できる場合は低い [pixel format](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)（例: 8 bpp やモノクロ用の 1 bpp）を使用します。[image dimensions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) をやや小さくすると、可読性に大きな影響を与えずにサイズを減らすこともできます。

**元のフォントがシステムに存在しない場合、ノートのフォントは結果に影響しますか？**

はい。欠落したフォントは [substitution](/slides/ja/cpp/font-selection-sequence/) をトリガーし、テキストのメトリックや外観が変わる可能性があります。これを回避するには、[必要なフォントを提供](/slides/ja/cpp/custom-font/) するか、デフォルトの [fallback font](/slides/ja/cpp/fallback-font/) を設定して、意図した書体が使用されるようにします。