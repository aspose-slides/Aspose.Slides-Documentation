---
title: AndroidでPowerPointプレゼンテーションをTIFFに変換
titlelink: PowerPointからTIFFへ
type: docs
weight: 90
url: /ja/androidjava/convert-powerpoint-to-tiff/
keywords:
- PowerPointを変換
- OpenDocumentを変換
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
- PPTをTIFFにエクスポート
- PPTXをTIFFにエクスポート
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用し、Javaのコード例と共に、PowerPoint（PPT、PPTX）プレゼンテーションを高品質なTIFF画像に簡単に変換する方法を学びましょう。"
---

## **概要**

TIFF (**Tagged Image File Format**) は、優れた品質とグラフィックの詳細な保存で知られる、広く使用されているロスレスラスター画像フォーマットです。デザイナー、写真家、デスクトップパブリッシャーは、画像のレイヤー、色精度、元の設定を保持するために TIFF を選択することが多いです。

Aspose.Slides を使用すれば、PowerPoint スライド (PPT、PPTX) と OpenDocument スライド (ODP) を高品質な TIFF 画像に簡単に変換でき、プレゼンテーションの視覚的忠実度を最大限に保つことができます。

## **プレゼンテーションを TIFF に変換する**

[save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッドは [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスが提供しており、これを使用して PowerPoint プレゼンテーション全体を迅速に TIFF に変換できます。生成される TIFF 画像はデフォルトのスライドサイズに対応しています。

このコードは PowerPoint プレゼンテーションを TIFF に変換する方法を示しています。
```java
// プレゼンテーションファイル（PPT、PPTX、ODP など）を表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("presentation.pptx");
try {
    // プレゼンテーションを TIFF として保存します。
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```


## **プレゼンテーションを白黒 TIFF に変換する**

[setBwConversionMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) メソッドは [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/) クラスにあり、カラーのスライドや画像を白黒 TIFF に変換する際に使用するアルゴリズムを指定できます。この設定は、[setCompressionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) メソッドが `CCITT4` または `CCITT3` に設定されている場合にのみ適用されます。

例えば、次のスライドを含む "sample.pptx" ファイルがあるとします：
![プレゼンテーションのスライド](slide_black_and_white.png)

このコードは、カラーのスライドを白黒 TIFF に変換する方法を示しています：
```java
TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


結果：
![白黒 TIFF](TIFF_black_and_white.png)

## **カスタムサイズでプレゼンテーションを TIFF に変換する**

特定の寸法の TIFF 画像が必要な場合は、[TiffOptions] で利用可能なメソッドを使用して希望の値を設定できます。例えば、[setImageSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) メソッドを使用すると、生成される画像のサイズを定義できます。

このコードは、カスタムサイズで PowerPoint プレゼンテーションを TIFF 画像に変換する方法を示しています：
```java
// プレゼンテーションファイル（PPT、PPTX、ODP など）を表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // 圧縮タイプを設定します。
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    圧縮タイプ:
        Default - デフォルトの圧縮方式（LZW）を指定します。
        None - 圧縮なしを指定します。
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // 深度は圧縮タイプに依存し、手動で設定できません。

    // 画像の DPI を設定します。
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // 画像サイズを設定します。
    tiffOptions.setImageSize(new Size(1728, 1078));

    INotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 指定したサイズでプレゼンテーションを TIFF として保存します。
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```


## **カスタム画像ピクセルフォーマットでプレゼンテーションを TIFF に変換する**

[setPixelFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) メソッドは [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/) クラスから使用でき、生成される TIFF 画像のピクセルフォーマットを好きなものに指定できます。

このコードは、カスタムピクセルフォーマットで PowerPoint プレゼンテーションを TIFF 画像に変換する方法を示しています：
```java
// プレゼンテーションファイル（PPT、PPTX、ODP など）を表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat には以下の値が含まれます（ドキュメントに記載されているとおり）：
        Format1bppIndexed - 1 ビット/ピクセル、インデックス化。
        Format4bppIndexed - 4 ビット/ピクセル、インデックス化。
        Format8bppIndexed - 8 ビット/ピクセル、インデックス化。
        Format24bppRgb    - 24 ビット/ピクセル、RGB。
        Format32bppArgb   - 32 ビット/ピクセル、ARGB。
    */
    
    // 指定した画像サイズでプレゼンテーションを TIFF として保存します。
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="Tip" color="primary" %}}
Aspose の [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) をご覧ください。
{{% /alert %}}

## **よくある質問**

**PowerPoint プレゼンテーション全体ではなく、個々のスライドを TIFF に変換できますか？**

はい。Aspose.Slides を使用すると、PowerPoint および OpenDocument プレゼンテーションの個々のスライドを個別に TIFF 画像に変換できます。

**プレゼンテーションを TIFF に変換する際、スライド数に制限はありますか？**

いいえ、Aspose.Slides はスライド数に制限を設けていません。任意のサイズのプレゼンテーションを TIFF 形式に変換できます。

**スライドを TIFF に変換する際、PowerPoint のアニメーションやトランジション効果は保持されますか？**

いいえ、TIFF は静止画像フォーマットです。そのため、アニメーションやトランジション効果は保持されず、スライドの静的なスナップショットのみがエクスポートされます。