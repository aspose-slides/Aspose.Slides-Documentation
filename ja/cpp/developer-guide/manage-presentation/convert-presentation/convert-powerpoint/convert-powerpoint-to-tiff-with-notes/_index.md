---
title: C++でノート付きPowerPointプレゼンテーションをTIFFに変換する
linktitle: ノート付きPowerPointからTIFFへ
type: docs
weight: 100
url: /ja/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointからTIFFへ
- プレゼンテーションからTIFFへ
- スライドからTIFFへ
- PPTからTIFFへ
- PPTXからTIFFへ
- PPTをTIFFとして保存
- PPTXをTIFFとして保存
- PPTをTIFFへエクスポート
- PPTXをTIFFへエクスポート
- ノート付きPowerPoint
- ノート付きプレゼンテーション
- ノート付きスライド
- ノート付きPPT
- ノート付きPPTX
- ノート付きTIFF
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、ノート付きの PowerPoint プレゼンテーションを TIFF に変換します。スピーカーノート付きスライドを効率的にエクスポートする方法を学びましょう。"
---

## **概要**

Aspose.Slides for C++ は、ノート付きの PowerPoint および OpenDocument プレゼンテーション (PPT、PPTX、ODP) を TIFF 形式に変換するシンプルなソリューションを提供します。この形式は高品質な画像保存、印刷、文書アーカイブで広く使用されています。Aspose.Slides を使用すると、スピーカーノート付きのプレゼンテーション全体をエクスポートできるだけでなく、Notes Slide ビューでスライドのサムネイルを生成できます。変換プロセスはシンプルかつ効率的で、`Save` メソッドを利用して [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラス全体のプレゼンテーションを TIFF 画像のシリーズに変換し、ノートとレイアウトを保持します。

## **プレゼンテーションをノート付き TIFF に変換**

Aspose.Slides for C++ を使用して、PowerPoint または OpenDocument プレゼンテーションをノート付き TIFF に保存するには、次の手順が必要です。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します: PowerPoint または OpenDocument ファイルをロードします。
2. 出力レイアウトオプションを構成します: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用して、ノートとコメントの表示方法を指定します。
3. プレゼンテーションを TIFF として保存します: 構成したオプションを [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) メソッドに渡します。

たとえば、"speaker_notes.pptx" ファイルに以下のスライドがあるとします:

![スピーカーノート付きのプレゼンテーションスライド](slide_with_notes.png)

以下のコードスニペットは、[set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) メソッドを使用して、Notes Slide ビューでプレゼンテーションを TIFF 画像に変換する方法を示します。
```cpp
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // スライドの下にノートを表示します。

// ノート配置付きで TIFF オプションを設定します。
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// スピーカーノート付きでプレゼンテーションを TIFF に保存します。
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


結果:

![スピーカーノート付きの TIFF 画像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose の[無料 PowerPoint からポスターへのコンバータ](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)をご確認ください。
{{% /alert %}}

## **よくある質問**

**結果の TIFF でノート領域の位置を制御できますか？**

はい。[notes layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) を使用して、`None`、`BottomTruncated`、`BottomFull` のようなオプションから選択できます。これらはそれぞれ、ノートを非表示にする、単一ページに収める、または追加ページに続けて表示することを意味します。

**ノート付き TIFF ファイルのサイズを、品質の目立つ低下なしに削減するにはどうすればよいですか？**

[efficient compression](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)（例: `LZW` または `RLE`）を選択し、適切な DPI を設定し、許容できる場合は低い [pixel format](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)（モノクロの場合は 8 bpp または 1 bpp など）を使用します。[image dimensions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) を少し減らすことも、可読性に大きな影響を与えずに役立ちます。

**システムに元のフォントがない場合、ノートのフォントは結果に影響しますか？**

はい。フォントが欠如すると、[substitution](/slides/ja/cpp/font-selection-sequence/) が発生し、テキストの寸法や外観が変わる可能性があります。これを回避するには、[supply the required fonts](/slides/ja/cpp/custom-font/) を提供するか、デフォルトの [fallback font](/slides/ja/cpp/fallback-font/) を設定して、意図した書体が使用されるようにします。