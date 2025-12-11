---
title: Androidでノート付きPowerPointプレゼンテーションをTIFFに変換
linktitle: ノート付きPowerPointからTIFFへ
type: docs
weight: 100
url: /ja/androidjava/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPointを変換
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
- PPTをTIFFへエクスポート
- PPTXをTIFFへエクスポート
- ノート付きPowerPoint
- ノート付きプレゼンテーション
- ノート付きスライド
- ノート付きPPT
- ノート付きPPTX
- ノート付きTIFF
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、ノート付きのPowerPointプレゼンテーションをTIFFに変換します。スピーカーノート付きスライドを効率的にエクスポートする方法を学びましょう。"
---

## **概要**

Aspose.Slides for Android via Java は、PowerPoint および OpenDocument プレゼンテーション (PPT、PPTX、ODP) をノート付きで TIFF 形式に変換するシンプルなソリューションを提供します。この形式は高品質な画像保存、印刷、文書アーカイブで広く使用されています。Aspose.Slides を使用すると、スピーカーノート付きのプレゼンテーション全体をエクスポートできるだけでなく、ノートスライドビューでスライドサムネイルを生成することもできます。変換プロセスはシンプルで効率的で、`save` メソッドを利用します[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスの `save` メソッドを使用して、ノートとレイアウトを保持しながらプレゼンテーション全体を一連の TIFF 画像に変換します。

## **プレゼンテーションをノート付きで TIFF に変換する**

Aspose.Slides for Android via Java を使用して PowerPoint または OpenDocument プレゼンテーションをノート付きで TIFF に保存するには、以下の手順を実行します。

1. **[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成**：PowerPoint または OpenDocument ファイルをロードします。  
2. **出力レイアウトオプションを構成**：**[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/)** クラスを使用して、ノートとコメントの表示方法を指定します。  
3. **プレゼンテーションを TIFF に保存**：構成したオプションを **[save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)** メソッドに渡します。

以下のスライドが含まれる **speaker_notes.pptx** ファイルがあるとします：

![The presentation slide with speaker notes](slide_with_notes.png)

次のコードスニペットは、**[setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)** メソッドを使用して、ノートスライドビューでプレゼンテーションを TIFF 画像に変換する方法を示しています。
```java
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // スライドの下にノートを表示します。

    // ノートのレイアウトを使用して TIFF オプションを構成します。
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

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose の無料 PowerPoint からポスターへのコンバータをご確認ください。[Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **よくある質問**

**結果の TIFF でノート領域の位置を制御できますか？**

はい。**[notes layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)** を使用して、`None`、`BottomTruncated`、`BottomFull` のようなオプションから選択できます。これらはそれぞれノートを非表示にし、単一ページに収め、または追加ページに続きを表示します。

**品質の目に見える低下なく、ノート付き TIFF ファイルのサイズを減らすにはどうすればよいですか？**

効率的な圧縮**[efficient compression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-)**（例：`LZW` または `RLE`）を選び、適切な DPI を設定します。許容できる場合は、**[pixel format](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-)** を低いビット深度（例：8 bpp または 1 bpp のモノクロ）にします。また、**[image dimensions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-)** を若干小さくすると、可読性に大きな影響を与えずにサイズを削減できます。

**システムに元のフォントがない場合、ノート内のフォントは結果に影響しますか？**

はい。フォントが見つからないと **[substitution](/slides/ja/androidjava/font-selection-sequence/)** が発生し、テキストのメトリクスや外観が変わる可能性があります。これを防ぐために、**[必要なフォントを供給](/slides/ja/androidjava/custom-font/)** するか、**[fallback font](/slides/ja/androidjava/fallback-font/)** を設定して、意図した書体が使用されるようにしてください。