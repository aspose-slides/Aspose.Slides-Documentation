---
title: Android で PowerPoint プレゼンテーションを TIFF に変換する
titlelink: PowerPoint を TIFF に変換
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
- PowerPoint を TIFF に変換
- プレゼンテーションを TIFF に変換
- スライドを TIFF に変換
- PPT を TIFF に変換
- PPTX を TIFF に変換
- PPT を TIFF として保存
- PPTX を TIFF として保存
- PPT を TIFF にエクスポート
- PPTX を TIFF にエクスポート
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用し、Java コード例と共に、PowerPoint (PPT、PPTX) プレゼンテーションを高品質な TIFF 画像に簡単に変換する方法を学びます。"
---
## **はじめに**

TIFF（**Tagged Image File Format**）は、優れた品質と画像の詳細な保存で知られる、広く使用されているロスレスラスター画像形式です。デザイナー、フォトグラファー、デスクトップパブリッシャーは、画像のレイヤー、色精度、元の設定を維持するために TIFF を選択することが多いです。

Aspose.Slides を使用すると、PowerPoint スライド（PPT、PPTX）や OpenDocument スライド（ODP）を直接高品質な TIFF 画像に簡単に変換でき、プレゼンテーションの視覚的忠実度を最大限に保つことができます。

## **プレゼンテーションを TIFF に変換する**

[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスが提供する [save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッドを使用すると、PowerPoint プレゼンテーション全体をすばやく TIFF に変換できます。生成された TIFF 画像はデフォルトのスライドサイズに対応します。

このコードは、PowerPoint プレゼンテーションを TIFF に変換する方法を示しています。

```java
import com.aspose.slides.*;

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

[TiffOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tiffoptions/) クラスの [setBwConversionMode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) メソッドを使用すると、カラー スライドや画像を白黒 TIFF に変換する際に使用するアルゴリズムを指定できます。この設定は、[setCompressionType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) メソッドが `CCITT4` または `CCITT3` に設定されている場合にのみ適用されます。

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) は、完全な TIFF 画像に対してピクセル変換アルゴリズムを選択するエクスポートレベルの設定です。白黒表示モードが有効なときに個々のシェイプの表示方法を定義するには、[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) を使用します。例については、[Control Black-and-White Rendering for Shapes](/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) を参照してください。
{{% /alert %}}

次のスライドを含む「sample.pptx」ファイルがあるとします。

![プレゼンテーションスライド](slide_black_and_white.png)

このコードは、カラー スライドを白黒 TIFF に変換する方法を示しています。

```java
import com.aspose.slides.*;

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

## **カスタムサイズでプレゼンテーションを TIFF に変換する**

特定の寸法の TIFF 画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tiffoptions/) に用意されているメソッドを使用して希望の値を設定できます。たとえば、[setImageSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) メソッドを使用すると、生成される画像のサイズを定義できます。

このコードは、カスタムサイズで PowerPoint プレゼンテーションを TIFF 画像に変換する方法を示しています。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // 圧縮タイプを設定します。
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
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

    // 画像の DPI を設定します。
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // 画像サイズを設定します。
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 指定したサイズでプレゼンテーションを TIFF として保存します。
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **カスタム画像ピクセルフォーマットでプレゼンテーションを TIFF に変換する**

[TiffOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tiffoptions/) クラスの [setPixelFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) メソッドを使用すると、生成される TIFF 画像の希望のピクセルフォーマットを指定できます。

このコードは、カスタムピクセルフォーマットで PowerPoint プレゼンテーションを TIFF 画像に変換する方法を示しています。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat には以下の値が含まれています（ドキュメント記載の通り）：
        Format1bppIndexed - 1 ビット/ピクセル、インデックス形式。
        Format4bppIndexed - 4 ビット/ピクセル、インデックス形式。
        Format8bppIndexed - 8 ビット/ピクセル、インデックス形式。
        Format24bppRgb    - 24 ビット/ピクセル、RGB。
        Format32bppArgb   - 32 ビット/ピクセル、ARGB。
    */
    
    // 指定したピクセルフォーマットでプレゼンテーションを TIFF として保存します。
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
[Aspose の無料 PowerPoint からポスターへの変換ツール](https://products.aspose.app/slides/ja/conversion/convert-ppt-to-poster-online) をチェックしてください。
{{% /alert %}}

## **よくある質問**

**PowerPoint プレゼンテーション全体ではなく、個々のスライドを TIFF に変換できますか？**

はい。Aspose.Slides を使用すると、PowerPoint および OpenDocument プレゼンテーションから個々のスライドを個別に TIFF 画像に変換できます。

**プレゼンテーションを TIFF に変換する際、スライド数に制限はありますか？**

いいえ、Aspose.Slides にはスライド数の制限はありません。任意のサイズのプレゼンテーションを TIFF 形式に変換できます。

**スライドを TIFF に変換すると、PowerPoint のアニメーションやトランジション効果は保持されますか？**

いいえ、TIFF は静的画像形式です。そのため、アニメーションやトランジション効果は保持されず、スライドの静止スナップショットのみがエクスポートされます。