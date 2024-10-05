---
title: PowerPointをTIFFに変換
type: docs
weight: 90
url: /net/convert-powerpoint-to-tiff/
keywords: "PowerPointプレゼンテーションを変換, PowerPointからTIFF, PPTからTIFF, PPTXからTIFF, C#, Csharp, .NET, Aspose.Slides"
description: "C#または.NETでPowerPointプレゼンテーションをTIFFに変換します。"

---

TIFF (**Tagged Image File Format**)は、ロスレスのラスターおよび高品質な画像フォーマットです。プロフェッショナルは、デザイン、写真、デスクトップパブリッシングの目的でTIFFを使用します。例えば、デザインや画像のレイヤーや設定を保持したい場合、作業をTIFF画像ファイルとして保存することを検討するかもしれません。

Aspose.Slidesを使用すると、PowerPointのスライドを直接TIFFに変換できます。

{{% alert title="ヒント" color="primary" %}}

Asposeの[無料のPowerPointからポスターへの変換ツール](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)をチェックしてみてください。

{{% /alert %}}

## **PowerPointをTIFFに変換**

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスによって公開された[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)メソッドを使用することで、PowerPointプレゼンテーション全体を迅速にTIFFに変換できます。生成されるTIFF画像は、スライドのデフォルトサイズに対応します。

このC#コードは、PowerPointをTIFFに変換する方法を示しています：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    // プレゼンテーションをTIFFとして保存します
    presentation.Save("Tiffoutput_out.tiff", SaveFormat.Tiff);
}
```

## **PowerPointを白黒TIFFに変換**

Aspose.Slides 23.10では、[TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/)クラスに新しいプロパティ（[BwConversionMode](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/bwconversionmode/)）が追加され、カラースライドや画像を白黒TIFFに変換する際に使用されるアルゴリズムを指定できるようになりました。この設定は、[CompressionType](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/)プロパティが`CCITT4`または`CCITT3`に設定されている場合にのみ適用されます。

このC#コードは、カラースライドや画像を白黒TIFFに変換する方法を示しています：

```c#
var tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
```

## **カスタムサイズでPowerPointをTIFFに変換**

特定の寸法を持つTIFF画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/)に提供されるプロパティを介して希望の数値を定義できます。例えば、[ImageSize](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/)プロパティを使用して、生成される画像のサイズを設定できます。

このC#コードは、カスタムサイズでPowerPointをTIFF画像に変換する方法を示しています：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
using (Presentation pres = new Presentation("Convert_Tiff_Custom.pptx"))
{
    // TiffOptionsクラスをインスタンス化します
    TiffOptions opts = new TiffOptions();

    // 圧縮タイプを設定します
    opts.CompressionType = TiffCompressionTypes.Default;

    INotesCommentsLayoutingOptions notesOptions = opts.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;
    // 圧縮タイプ

    // Default - デフォルトの圧縮方式を指定します (LZW)。
    // None - 圧縮なしを指定します。
    // CCITT3
    // CCITT4
    // LZW
    // RLE

    // 深さは圧縮タイプによって決まり、手動で設定できません。
    // 解像度単位は常に「2」（インチあたりのドット）に等しいです。

    // 画像のDPIを設定します
    opts.DpiX = 200;
    opts.DpiY = 100;

    // 画像サイズを設定します
    opts.ImageSize = new Size(1728, 1078);

    // 指定されたサイズでTIFFとしてプレゼンテーションを保存します
    pres.Save("TiffWithCustomSize_out.tiff", SaveFormat.Tiff, opts);
}
```

## **カスタム画像ピクセルフォーマットでPowerPointをTIFFに変換**

[TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions)クラスの[PixelFormat](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/)プロパティを使用することで、生成されるTIFF画像の希望するピクセルフォーマットを指定できます。

このC#コードは、カスタムピクセルフォーマットでPowerPointをTIFF画像に変換する方法を示しています：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    TiffOptions options = new TiffOptions();
   
    options.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormatには次の値が含まれます（文書に記載された通り）：
    Format1bppIndexed; // 1ビット/ピクセル、インデックスされています。
    Format4bppIndexed; // 4ビット/ピクセル、インデックスされています。
    Format8bppIndexed; // 8ビット/ピクセル、インデックスされています。
    Format24bppRgb; // 24ビット/ピクセル、RGB。
    Format32bppArgb; // 32ビット/ピクセル、ARGB。
    */

    // 指定された画像サイズでTIFFとしてプレゼンテーションを保存します
    presentation.Save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat.Tiff, options);
}
```