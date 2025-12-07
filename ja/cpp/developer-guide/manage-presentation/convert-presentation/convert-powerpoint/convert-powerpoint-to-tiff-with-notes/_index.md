---
title: C++ でノート付き PowerPoint プレゼンテーションを TIFF に変換
linktitle: ノート付き PowerPoint を TIFF に変換
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

Aspose.Slides for C++ は、PowerPoint および OpenDocument プレゼンテーション (PPT、PPTX、ODP) を、ノート付きで TIFF 形式に変換するシンプルなソリューションを提供します。この形式は高品質な画像保存、印刷、文書アーカイブに広く使用されています。Aspose.Slides を使用すると、スピーカー ノート付きのプレゼンテーション全体をエクスポートできるだけでなく、Notes Slide ビューでスライドのサムネイルを生成することもできます。変換プロセスはシンプルで効率的で、`Save` メソッドを利用し、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスでプレゼンテーション全体を TIFF 画像のシリーズに変換し、ノートとレイアウトを保持します。

## **ノート付きでプレゼンテーションを TIFF に変換する**

PowerPoint または OpenDocument プレゼンテーションをノート付きで TIFF に保存するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。PowerPoint または OpenDocument ファイルをロードします。
1. 出力レイアウトオプションを構成します。[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用して、ノートとコメントの表示方法を指定します。
1. プレゼンテーションを TIFF に保存します。構成したオプションを [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) メソッドに渡します。

例えば、"speaker_notes.pptx" ファイルに次のスライドがあるとします：

![スピーカー ノート付きのプレゼンテーション スライド](slide_with_notes.png)

以下のコードスニペットは、[set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) メソッドを使用して、Notes Slide ビューでプレゼンテーションを TIFF 画像に変換する方法を示しています。
```cpp
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // スライドの下にノートを表示します。

// Notes のレイアウト設定を使用して TIFF オプションを構成します。
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// スピーカーノート付きでプレゼンテーションを TIFF に保存します。
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


結果：

![スピーカー ノート付きの TIFF 画像](TIFF_with_notes.png)

{{% alert title="ヒント" color="primary" %}}
Aspose の無料 PowerPoint からポスタ変換ツールをご確認ください：[Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **よくある質問**

**生成された TIFF のノート領域の位置を制御できますか？**

はい。[notes layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) を使用して、`None`、`BottomTruncated`、`BottomFull` などのオプションから選択できます。これらはそれぞれノートを非表示にし、単一ページに収め、または追加ページへ流すことを可能にします。

**ノート付き TIFF ファイルのサイズを、見た目の品質低下なしに削減するにはどうすればよいですか？**

効率的な圧縮 [efficient compression](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)（例: `LZW` または `RLE`） を選択し、適切な DPI を設定し、許容できる場合は低い [pixel format](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)（例: 8 bpp や 1 bpp のモノクロ） を使用します。画像の [image dimensions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) を少し縮小することも、可読性に目立った影響を与えずに効果があります。

**システムに元のフォントが存在しない場合、ノート内のフォントは結果に影響しますか？**

はい。フォントが不足すると [substitution](/slides/ja/cpp/font-selection-sequence/) が発生し、テキストのメトリクスや外観が変わる可能性があります。これを防ぐには、[supply the required fonts](/slides/ja/cpp/custom-font/) を提供するか、デフォルトの [fallback font](/slides/ja/cpp/fallback-font/) を設定して、意図した書体が使用されるようにします。