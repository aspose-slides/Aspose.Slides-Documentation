---
title: PowerPointをTIFFに変換する
type: docs
weight: 90
url: /ja/cpp/convert-powerpoint-to-tiff/
keywords: "PowerPointプレゼンテーションの変換, PowerPointからTIFF, PPTからTIFF, PPTXからTIFF, C++, CPP, Aspose.Slides"
description: "C++でPowerPointプレゼンテーションをTIFFに変換する"
---

**TIFF**（タグ付き画像ファイルフォーマット）は、可逆圧縮のラスター高品質画像フォーマットです。プロフェッショナルはデザイン、写真、デスクトップパブリッシングの目的でTIFFを使用します。たとえば、デザインや画像のレイヤーや設定を保持したい場合、作業をTIFF画像ファイルとして保存することを検討するかもしれません。

Aspose.Slidesを使用すると、PowerPointのスライドを直接TIFFに変換できます。

{{% alert title="ヒント" color="primary" %}}

Asposeの[無料PowerPointからポスタへの変換ツール](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)をチェックしてみてください。

{{% /alert %}}

## **PowerPointをTIFFに変換する**

[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスが提供する[Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)メソッドを使用すると、PowerPointプレゼンテーション全体をTIFFに迅速に変換できます。結果として得られるTIFF画像は、スライドのデフォルトサイズに対応しています。

以下のC++コードは、PowerPointをTIFFに変換する方法を示しています：

```c++
// ドキュメントディレクトリのパス。
String dataDir = GetDataPath();

// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

// プレゼンテーションをTIFFとして保存
presentation->Save(dataDir + u"Tiffoutput_out.tiff", SaveFormat::Tiff);
```

## **PowerPointを白黒TIFFに変換する**

Aspose.Slides 23.10では、[TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options)クラスに新しいプロパティ([BwConversionMode](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/))が追加され、カラーのスライドや画像が白黒TIFFに変換される際に従うアルゴリズムを指定できるようになりました。この設定は、[CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)プロパティが`CCITT4`または`CCITT3`に設定されている場合にのみ適用されます。

以下のC++コードは、カラーのスライドや画像を白黒TIFFに変換する方法を示しています：

```c++
System::SharedPtr<TiffOptions> tiffOptions = System::MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);
```

## **カスタムサイズのTIFFにPowerPointを変換する**

指定された寸法のTIFF画像が必要な場合、[TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options)のプロパティを介して好みのサイズを定義できます。たとえば、[ImageSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/)プロパティを使用することで、結果画像のサイズを設定できます。

以下のC++コードは、カスタムサイズのTIFF画像にPowerPointを変換する方法を示しています：

```c++
// ドキュメントディレクトリのパス。
System::String dataDir = GetDataPath();

// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
auto pres = System::MakeObject<Presentation>(dataDir + u"Convert_Tiff_Custom.pptx");
    
// TiffOptionsクラスをインスタンス化
auto opts = System::MakeObject<TiffOptions>();

// 圧縮タイプを設定
opts->set_CompressionType(TiffCompressionTypes::Default);

auto notesOptions = opts->get_NotesCommentsLayouting();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
// 圧縮タイプ

// Default - デフォルトの圧縮スキーム（LZW）を指定。
// None - 圧縮なしを指定。
// CCITT3
// CCITT4
// LZW
// RLE

// 深度は圧縮タイプに依存し、手動で設定できません。
// 解像度単位は常に「2」（インチあたりドット）に等しいです。

// 画像のDPIを設定
opts->set_DpiX(200);
opts->set_DpiY(100);

// 画像のサイズを設定
opts->set_ImageSize(System::Drawing::Size(1728, 1078));

// 指定したサイズでプレゼンテーションをTIFFに保存
pres->Save(dataDir + u"TiffWithCustomSize_out.tiff", SaveFormat::Tiff, opts);
```

## **カスタム画像ピクセルフォーマットでPowerPointをTIFFに変換する**

[TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options)クラスの[PixelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)プロパティを使用して、結果のTIFF画像の好みのピクセルフォーマットを指定できます。

以下のC++コードは、カスタムピクセルフォーマットでPowerPointをTIFF画像に変換する方法を示しています：

```c++
// ドキュメントディレクトリのパス。
System::String dataDir = GetDataPath();

// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

auto options = System::MakeObject<TiffOptions>();
options->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormatには次の値が含まれます（ドキュメントから確認できます）：
Format1bppIndexed; // ピクセルあたり1ビット、インデックス化。
Format4bppIndexed; // ピクセルあたり4ビット、インデックス化。
Format8bppIndexed; // ピクセルあたり8ビット、インデックス化。
Format24bppRgb; // ピクセルあたり24ビット、RGB。
Format32bppArgb; // ピクセルあたり32ビット、ARGB。
*/

// 指定したサイズでプレゼンテーションをTIFFに保存
presentation->Save(dataDir + u"Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat::Tiff, options);
```