---
title: C++ で PowerPoint プレゼンテーションを TIFF に変換する
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
description: "Aspose.Slides for C++ を使用して、PowerPoint (PPT、PPTX) プレゼンテーションを高品質な TIFF 画像に簡単に変換する方法を、コード例とともに学びましょう。"
---
## **はじめに**

TIFF（**Tagged Image File Format**）は、卓越した品質とグラフィックの詳細な保存で知られる、広く使用されているロスレスラスター画像フォーマットです。デザイナー、フォトグラファー、デスクトップパブリッシャーは、画像のレイヤー、カラー精度、元の設定を保持するために TIFF を選択することが多いです。

Aspose.Slides を使用すると、PowerPoint スライド（PPT、PPTX）および OpenDocument スライド（ODP）を直接高品質な TIFF 画像に簡単に変換でき、プレゼンテーションの視覚的忠実度を最大限に保つことができます。

## **プレゼンテーションを TIFF に変換する**

[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスが提供する [Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) メソッドを使用すると、PowerPoint プレゼンテーション全体をすばやく TIFF に変換できます。生成された TIFF 画像はデフォルトのスライドサイズに対応します。

以下の C++ コードは、PowerPoint プレゼンテーションを TIFF に変換する方法を示しています。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを生成します。
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// プレゼンテーションを TIFF として保存します。
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **プレゼンテーションを白黒 TIFF に変換する**

[TiffOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/) クラスの [set_BwConversionMode](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) メソッドを使用すると、カラー スライドや画像を白黒 TIFF に変換する際に使用するアルゴリズムを指定できます。この設定は、[set_CompressionType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) メソッドが `CCITT4` または `CCITT3` に設定されている場合にのみ適用されます。

{{% alert color="info" title="注" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) は、完全な TIFF 画像に対してピクセル変換アルゴリズムを選択するエクスポートレベルの設定です。個々のシェイプが白黒表示モードでどのように描画されるかを定義するには、[IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/set_blackwhitemode/) を使用してください。例については [Control Black-and-White Rendering for Shapes](/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) を参照してください。
{{% /alert %}}

たとえば、次のスライドを含む "sample.pptx" ファイルがあるとします。

![プレゼンテーション スライド](slide_black_and_white.png)

この C++ コードは、カラー スライドを白黒 TIFF に変換する方法を示しています。

```cpp
#include <DOM/Presentation.h>
#include <Export/BlackWhiteConversionMode.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

特定のサイズの TIFF 画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/) に用意されているメソッドで希望の値を設定できます。たとえば、[set_ImageSize](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/set_imagesize/) メソッドを使用すると、生成される画像のサイズを定義できます。

以下の C++ コードは、カスタムサイズの TIFF 画像に PowerPoint プレゼンテーションを変換する方法を示しています。

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを生成します。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// 圧縮タイプを設定します。
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
圧縮タイプ:
    Default - デフォルトの圧縮方式 (LZW) を指定します。
    None - 圧縮なしを指定します。
    CCITT3
    CCITT4
    LZW
    RLE
*/

// 深度は圧縮タイプに依存し、手動で設定できません。

// 画像 DPI を設定します。
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

[TiffOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/) クラスの [set_PixelFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) メソッドを使用すると、生成される TIFF 画像のピクセル形式を任意に指定できます。

この C++ コードは、カスタムピクセル形式の TIFF 画像に PowerPoint プレゼンテーションを変換する方法を示しています。

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを生成します。
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat には以下の値が含まれます（ドキュメントに記載されているとおり）：
    Format1bppIndexed - 1 ピクセルあたり 1 ビット、インデックス形式。
    Format4bppIndexed - 1 ピクセルあたり 4 ビット、インデックス形式。
    Format8bppIndexed - 1 ピクセルあたり 8 ビット、インデックス形式。
    Format24bppRgb    - 1 ピクセルあたり 24 ビット、RGB。
    Format32bppArgb   - 1 ピクセルあたり 32 ビット、ARGB。
*/

// 指定した画像サイズでプレゼンテーションを TIFF として保存します。
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="ヒント" color="info" %}}
Aspose の [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/ja/conversion/convert-ppt-to-poster-online) をチェックしてください。
{{% /alert %}}

## **FAQ**

**個々のスライドだけを TIFF に変換できますか？**

はい。Aspose.Slides を使用すると、PowerPoint および OpenDocument プレゼンテーションの個別スライドを TIFF 画像として個別に変換できます。

**プレゼンテーションを TIFF に変換する際にスライド数の制限はありますか？**

いいえ、Aspose.Slides にはスライド数に制限はありません。任意のサイズのプレゼンテーションを TIFF 形式に変換できます。

**スライドを TIFF に変換するときに PowerPoint のアニメーションやトランジション効果は保持されますか？**

保持されません。TIFF は静的画像形式のため、アニメーションやトランジション効果は保存されず、スライドの静止スナップショットのみがエクスポートされます。