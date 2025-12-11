---
title: Android でノート付き PowerPoint プレゼンテーションを TIFF に変換
linktitle: ノート付き PowerPoint を TIFF に変換
type: docs
weight: 100
url: /ja/androidjava/convert-powerpoint-to-tiff-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、ノート付き PowerPoint プレゼンテーションを TIFF に変換します。スライドとスピーカーノートを効率的にエクスポートする方法を学びましょう。"
---

## **概要**

Aspose.Slides for Android via Java は、PowerPoint および OpenDocument のプレゼンテーション (PPT, PPTX, ODP) をノート付きで TIFF 形式に変換するシンプルなソリューションを提供します。この形式は高品質な画像保存、印刷、文書アーカイブで広く使用されています。Aspose.Slides を使用すると、スピーカーノート付きのプレゼンテーション全体をエクスポートできるだけでなく、Notes Slide ビューでスライドサムネイルを生成できます。変換プロセスはシンプルで効率的で、`save` メソッドと [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスを利用して、プレゼンテーション全体をノートとレイアウトを保持したまま TIFF 画像のシリーズに変換します。

## **プレゼンテーションをノート付きTIFFに変換**

Aspose.Slides for Android via Java を使用して、PowerPoint または OpenDocument のプレゼンテーションをノート付きで TIFF に保存するには、以下の手順が必要です。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します: PowerPoint または OpenDocument ファイルをロードします。
1. 出力レイアウトオプションを構成します: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) クラスを使用して、ノートとコメントの表示方法を指定します。
1. プレゼンテーションを TIFF に保存します: 設定したオプションを [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドに渡します。

たとえば、次のスライドを含む "speaker_notes.pptx" ファイルがあるとします。

![スピーカーノート付きのプレゼンテーションスライド](slide_with_notes.png)

以下のコードスニペットは、[setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) メソッドを使用して、Notes Slide ビューでプレゼンテーションを TIFF 画像に変換する方法を示しています。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // スライドの下にノートを表示します。

    // ノートのレイアウト設定を使用して TIFF オプションを構成します。
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // スピーカーノート付きでプレゼンテーションを TIFF に保存します。
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


結果：

![スピーカーノート付きの TIFF 画像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Aspose の無料 PowerPoint からポスターへのコンバータをご確認ください。[Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。

{{% /alert %}}

## **よくある質問**

**結果の TIFF でノート領域の位置を制御できますか？**

はい。[notes layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) を使用して、`None`、`BottomTruncated`、`BottomFull` などのオプションから選択できます。これらはそれぞれ、ノートを非表示にし、1 ページに収め、または複数ページにわたって表示させます。

**ノート付き TIFF ファイルのサイズを、品質の目に見える低下なしに削減するにはどうすればよいですか？**

[efficient compression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-)（例: `LZW` または `RLE`）を選択し、適切な DPI を設定します。また、問題なければ低い [pixel format](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-)（例: 8 bpp や 1 bpp の単色）を使用します。[image dimensions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) をわずかに縮小することも、可読性に大きな影響を与えずに効果があります。

**システムに元のフォントが無い場合、ノート内のフォントは結果に影響しますか？**

はい。フォントが欠如すると [substitution](/slides/ja/androidjava/font-selection-sequence/) が発生し、文字メトリックや外観が変わる可能性があります。これを防ぐには、[supply the required fonts](/slides/ja/androidjava/custom-font/) で必要なフォントを提供するか、デフォルトの [fallback font](/slides/ja/androidjava/fallback-font/) を設定して目的のフォントを使用してください。