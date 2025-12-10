---
title: PowerPoint プレゼンテーションをノート付きで TIFF に変換 (C++)
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
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーションをノート付きで TIFF に変換します。スライドのスピーカーノートを効率的にエクスポートする方法を学びましょう。"
---

## **概要**

Aspose.Slides for C++ は、PowerPoint および OpenDocument プレゼンテーション (PPT、PPTX、ODP) をノート付きで TIFF 形式に変換するシンプルなソリューションを提供します。この形式は高品質な画像保存、印刷、文書アーカイブに広く利用されています。Aspose.Slides を使用すると、スピーカーノート付きのプレゼンテーション全体をエクスポートできるだけでなく、Notes Slide ビューでスライドサムネイルを生成することもできます。変換プロセスはシンプルで効率的であり、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスの `Save` メソッドを利用して、ノートとレイアウトを保持しながらプレゼンテーション全体を一連の TIFF 画像に変換します。

## **ノート付きでプレゼンテーションを TIFF に変換する**

Aspose.Slides for C++ でノート付きの PowerPoint または OpenDocument プレゼンテーションを TIFF に保存する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスをインスタンス化します: PowerPoint または OpenDocument ファイルを読み込みます。
1. 出力レイアウトオプションを構成します: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用して、ノートとコメントの表示方法を指定します。
1. プレゼンテーションを TIFF に保存します: 設定したオプションを [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) メソッドに渡します。

例えば、次のスライドが含まれる "speaker_notes.pptx" ファイルがあるとします。

![スピーカーノート付きのプレゼンテーションスライド](slide_with_notes.png)

以下のコードスニペットは、[set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) メソッドを使用して、Notes Slide ビューでプレゼンテーションを TIFF 画像に変換する方法を示しています。
```cpp
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // スライドの下にノートを表示します。

// Configure the TIFF options with Notes layouting.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to TIFF with the speaker notes.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


結果:

![スピーカーノート付きの TIFF 画像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose の [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) をご利用ください。
{{% /alert %}}

## **FAQ**

**TIFF の結果におけるノート領域の位置を制御できますか？**

はい。[ノートレイアウト設定](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) を使用して、`None`、`BottomTruncated`、`BottomFull` のいずれかを選択できます。これらはそれぞれノートを非表示にする、1 ページに収める、または追加ページに続けて表示するオプションです。

**品質の目立った低下なく、ノート付き TIFF ファイルのサイズを削減するにはどうすればよいですか？**

[効率的な圧縮](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)（例: `LZW` または `RLE`）を選び、適切な DPI を設定し、許容できる場合は [ピクセル形式](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)（8 bpp やモノクロ用の 1 bpp など）を低くします。[画像サイズ](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) をやや小さくすることも、可読性に大きな影響を与えずにサイズ削減に役立ちます。

**元のシステムにフォントが存在しない場合、ノートのフォントは結果に影響しますか？**

はい。フォントが欠落していると [置換](/slides/ja/cpp/font-selection-sequence/) が発生し、テキストの計測や外観が変わる可能性があります。これを防ぐには、[必要なフォントを提供](/slides/ja/cpp/custom-font/) するか、デフォルトの [フォールバック フォント](/slides/ja/cpp/fallback-font/) を設定して、意図した書体が使用されるようにしてください。