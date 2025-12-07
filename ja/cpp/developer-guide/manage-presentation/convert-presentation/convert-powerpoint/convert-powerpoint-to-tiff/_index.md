---
title: PowerPoint プレゼンテーションを C++ で TIFF に変換
titlelink: PowerPoint を TIFF に変換
type: docs
weight: 90
url: /ja/cpp/convert-powerpoint-to-tiff/
keywords:
- PowerPoint を変換
- OpenDocument を変換
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint（PPT、PPTX）プレゼンテーションを高品質な TIFF 画像に簡単に変換する方法を、コード例とともに学びましょう。"
---

## **概要**

TIFF (**Tagged Image File Format**) は、優れた品質と詳細なグラフィックの保存で知られる、広く使用されているロスレスラスター画像形式です。デザイナー、フォトグラファー、デスクトップパブリッシャーは、画像のレイヤー、色精度、元の設定を保持するために TIFF を選択することが多いです。

Aspose.Slides を使用すると、PowerPoint スライド (PPT、PPTX) および OpenDocument スライド (ODP) を直接高品質な TIFF 画像に簡単に変換でき、プレゼンテーションの視覚的忠実度を最大限に保つことができます。

## **プレゼンテーションを TIFF に変換する**

この[Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) メソッドと[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスを使用すると、PowerPoint プレゼンテーション全体をすばやく TIFF に変換できます。生成された TIFF 画像はデフォルトのスライドサイズに対応します。

以下の C++ コードは、PowerPoint プレゼンテーションを TIFF に変換する方法を示しています:
```cpp
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// プレゼンテーションを TIFF として保存します。
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```


## **プレゼンテーションを白黒 TIFF に変換する**

[TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) クラスのメソッド [set_BwConversionMode](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) を使用すると、カラー スライドまたは画像を白黒 TIFF に変換する際に使用するアルゴリズムを指定できます。この設定は、[set_CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) メソッドが `CCITT4` または `CCITT3` に設定されている場合にのみ適用されます。

例えば、以下のスライドを含む "sample.pptx" ファイルがあるとします:
![プレゼンテーション スライド](slide_black_and_white.png)

以下の C++ コードは、カラー スライドを白黒 TIFF に変換する方法を示しています:
```cpp
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


結果:
![白黒 TIFF](TIFF_black_and_white.png)

## **カスタムサイズの TIFF にプレゼンテーションを変換する**

特定のサイズの TIFF 画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) に用意されているメソッドを使用して希望の値を設定できます。例えば、[set_ImageSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) メソッドを使用すると、生成される画像のサイズを指定できます。

以下の C++ コードは、カスタムサイズで PowerPoint プレゼンテーションを TIFF 画像に変換する方法を示しています:
```cpp
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// 圧縮タイプを設定します。
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
圧縮タイプ:
    Default - デフォルトの圧縮方式 (LZW) を指定します。
    None - 圧縮しないことを指定します。
    CCITT3
    CCITT4
    LZW
    RLE
*/

// 深度は圧縮タイプに依存し、手動で設定できません。

// 画像の DPI を設定します。
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// 画像サイズを設定します。
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// 指定したサイズでプレゼンテーションを TIFF として保存します。
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


## **カスタム画像ピクセル形式の TIFF にプレゼンテーションを変換する**

[TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) クラスの [set_PixelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) メソッドを使用すると、生成される TIFF 画像のピクセル形式を好みのものに指定できます。

以下の C++ コードは、カスタムピクセル形式で PowerPoint プレゼンテーションを TIFF 画像に変換する方法を示しています:
```cpp
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat には次の値が含まれます（ドキュメントに記載のとおり）：
    Format1bppIndexed - 1 ビット／ピクセル、インデックス方式。
    Format4bppIndexed - 4 ビット／ピクセル、インデックス方式。
    Format8bppIndexed - 8 ビット／ピクセル、インデックス方式。
    Format24bppRgb    - 24 ビット／ピクセル、RGB。
    Format32bppArgb   - 32 ビット／ピクセル、ARGB。
*/

// 指定した画像サイズでプレゼンテーションを TIFF として保存します。
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


{{% alert title="Tip" color="primary" %}}
Aspose の [無料の PowerPoint からポスターへのコンバータ](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) をご確認ください。
{{% /alert %}}

## **よくある質問**

**個々のスライドだけを TIFF に変換できますか？**

はい。Aspose.Slides を使用すると、PowerPoint および OpenDocument プレゼンテーションから個々のスライドを別々に TIFF 画像に変換できます。

**プレゼンテーションを TIFF に変換する際、スライド数に制限はありますか？**

いいえ、Aspose.Slides にはスライド数に対する制限はありません。任意のサイズのプレゼンテーションを TIFF 形式に変換できます。

**スライドを TIFF に変換すると、PowerPoint のアニメーションやトランジション効果は保持されますか？**

いいえ、TIFF は静止画像形式です。そのため、アニメーションやトランジション効果は保持されず、スライドの静的なスナップショットのみがエクスポートされます。