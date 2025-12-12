---
title: Android で PowerPoint プレゼンテーションを TIFF に変換する
titlelink: PowerPoint から TIFF へ
type: docs
weight: 90
url: /ja/androidjava/convert-powerpoint-to-tiff/
keywords:
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint から TIFF へ
- プレゼンテーションから TIFF へ
- スライドから TIFF へ
- PPT から TIFF へ
- PPTX から TIFF へ
- PPT を TIFF として保存
- PPTX を TIFF として保存
- PPT を TIFF にエクスポート
- PPTX を TIFF にエクスポート
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用し、Java のコード例とともに、PowerPoint（PPT、PPTX）プレゼンテーションを高品質な TIFF 画像に簡単に変換する方法を学びます。"
---

## **概要**

TIFF（**Tagged Image File Format**）は、優れた品質と詳細な画像保存で広く使用されているロスレスラスター画像形式です。デザイナー、写真家、デスクトップパブリッシャーは、レイヤー、色精度、元の設定を画像に保持するために TIFF を選択することが多いです。

Aspose.Slides を使用すると、PowerPoint スライド（PPT、PPTX）や OpenDocument スライド（ODP）を直接高品質な TIFF 画像に簡単に変換でき、プレゼンテーションの視覚的忠実度を最大限に保つことができます。 

## **プレゼンテーションを TIFF に変換する**

[save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッド（[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラス）が提供する機能を使用すると、PowerPoint プレゼンテーション全体を TIFF にすばやく変換できます。生成される TIFF 画像はデフォルトのスライドサイズに対応します。

このコードは PowerPoint プレゼンテーションを TIFF に変換する方法を示しています:
```java
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("presentation.pptx");
try {
    // プレゼンテーションを TIFF として保存します。
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```


## **プレゼンテーションを白黒 TIFF に変換する**

[TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/) クラスの [setBwConversionMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) メソッドを使用すると、カラー スライドまたは画像を白黒 TIFF に変換する際に使用するアルゴリズムを指定できます。なお、この設定は [setCompressionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) メソッドが `CCITT4` または `CCITT3` に設定されている場合にのみ適用されます。

たとえば、次のスライドを含む "sample.pptx" ファイルがあるとします:

![プレゼンテーション スライド](slide_black_and_white.png)

このコードはカラー スライドを白黒 TIFF に変換する方法を示しています:
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


結果:

![白黒 TIFF](TIFF_black_and_white.png)

## **カスタムサイズの TIFF に変換する**

特定の寸法の TIFF 画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/) で利用できるメソッドを使用して希望の値を設定できます。たとえば、[setImageSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) メソッドを使用すると、生成される画像のサイズを定義できます。

このコードは PowerPoint プレゼンテーションをカスタムサイズの TIFF 画像に変換する方法を示しています:
```java
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // 圧縮タイプを設定します。
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    圧縮タイプ:
        Default - デフォルトの圧縮方式 (LZW) を指定します。
        None - 圧縮しません。
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


## **カスタム ピクセル フォーマットの TIFF に変換する**

[TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/) クラスの [setPixelFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) メソッドを使用すると、生成される TIFF 画像のピクセル フォーマットを任意に指定できます。

このコードは PowerPoint プレゼンテーションをカスタム ピクセル フォーマットの TIFF 画像に変換する方法を示しています:
```java
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat には以下の値が含まれます（ドキュメントに記載されている通り）:
        Format1bppIndexed - 1 ビット/ピクセル、インデックス形式。
        Format4bppIndexed - 4 ビット/ピクセル、インデックス形式。
        Format8bppIndexed - 8 ビット/ピクセル、インデックス形式。
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

Aspose の [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) をチェックしてください。

{{% /alert %}}

## **FAQ**

**個々のスライドだけを TIFF に変換できますか？**

はい。Aspose.Slides を使用すると、PowerPoint および OpenDocument プレゼンテーションから個々のスライドを別々に TIFF 画像に変換できます。

**プレゼンテーションを TIFF に変換する際のスライド数に制限はありますか？**

いいえ、Aspose.Slides にはスライド数に関する制限はありません。任意のサイズのプレゼンテーションを TIFF 形式に変換できます。

**スライドを TIFF に変換すると、PowerPoint のアニメーションやトランジション効果は保持されますか？**

保持されません。TIFF は静止画像形式のため、アニメーションやトランジション効果は保存されず、スライドの静止スナップショットのみがエクスポートされます。