---
title: C++でノート付きPowerPointプレゼンテーションをTIFFに変換する
linktitle: ノート付きPowerPointをTIFFに変換
type: docs
weight: 100
url: /ja/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointをTIFFに変換
- プレゼンテーションをTIFFに変換
- スライドをTIFFに変換
- PPTをTIFFに変換
- PPTXをTIFFに変換
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、ノート付きの PowerPoint プレゼンテーションを TIFF に変換します。スピーカーノート付きスライドを効率的にエクスポートする方法を学びましょう。"
---
## **はじめに**

Aspose.Slides for C++ は、PowerPoint および OpenDocument プレゼンテーション (PPT、PPTX、ODP) のスライドノート付きを TIFF 形式に変換するシンプルなソリューションを提供します。この形式は高品質な画像保存、印刷、文書アーカイブで広く使用されています。Aspose.Slides を使用すれば、スピーカーノート付きのプレゼンテーション全体をエクスポートするだけでなく、ノートスライドビューでスライドサムネイルを生成することもできます。変換プロセスは簡単かつ効率的で、[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスの `Save` メソッドを利用して、プレゼンテーション全体をノートとレイアウトを保持した TIFF 画像の連続に変換します。

## **ノート付きでプレゼンテーションを TIFF に変換する**

Aspose.Slides for C++ で PowerPoint または OpenDocument プレゼンテーションをノート付きで TIFF に保存する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成し、PowerPoint または OpenDocument ファイルを読み込む。
1. 出力レイアウトオプションを構成する: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用して、ノートとコメントの表示方法を指定する。
1. プレゼンテーションを TIFF に保存する: 設定したオプションを [Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) メソッドに渡す。

例として、次のスライドを含む "speaker_notes.pptx" ファイルがあるとします。

![The presentation slide with speaker notes](slide_with_notes.png)

以下のコードスニペットは、[set_SlidesLayoutOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) メソッドを使用して、ノートスライドビューでプレゼンテーションを TIFF 画像に変換する方法を示しています。

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // スライドの下にノートを表示します。

// ノートのレイアウト設定を使用して TIFF オプションを構成します。
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to TIFF with the speaker notes.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

結果:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Check out Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/ja/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

### 結果の TIFF でノート領域の位置を制御できますか？

はい。[notes layout settings](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) を使用して、`None`、`BottomTruncated`、`BottomFull` などのオプションから選択できます。これらはそれぞれノートを非表示にする、1 ページに収める、追加ページに流すことを意味します。

### 画質の目立った低下なしにノート付き TIFF ファイルのサイズを削減する方法は？

効率的な圧縮 (例: `LZW` または `RLE`) を選び、適切な DPI を設定し、許容できる場合は低い [pixel format](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (8 bpp や 1 bpp のモノクロ) を使用します。[image dimensions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/set_imagesize/) をやや小さくすることも、可読性を大きく損なわずに効果があります。

### 元のフォントがシステムに存在しない場合、ノートのフォントは結果に影響しますか？

はい。フォントが欠如すると [substitution](/slides/ja/cpp/font-selection-sequence/) が発生し、文字メトリクスや外観が変わる可能性があります。これを防ぐには、[必要なフォントを提供](/slides/ja/cpp/custom-font/) するか、デフォルトの [fallback font](/slides/ja/cpp/fallback-font/) を設定して、意図した書体が使用されるようにします。