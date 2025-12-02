---
title: Javaでノート付きPowerPointプレゼンテーションをTIFFに変換
linktitle: ノート付きPowerPointからTIFFへ
type: docs
weight: 100
url: /ja/java/convert-powerpoint-to-tiff-with-notes/
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
- PPTをTIFFにエクスポート
- PPTXをTIFFにエクスポート
- ノート付きPowerPoint
- ノート付きプレゼンテーション
- ノート付きスライド
- ノート付きPPT
- ノート付きPPTX
- ノート付きTIFF
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、ノート付きPowerPointプレゼンテーションをTIFFに変換します。スピーカーノート付きスライドを効率的にエクスポートする方法を学びましょう。"
---

## **概要**

Aspose.Slides for Java は、PowerPoint と OpenDocument のプレゼンテーション（PPT、PPTX、ODP）をノート付きで TIFF 形式に変換するシンプルなソリューションを提供します。この形式は高品質な画像保存、印刷、文書アーカイブに広く使用されています。Aspose.Slides を使用すると、スピーカーノート付きのプレゼンテーション全体をエクスポートできるだけでなく、Notes Slide ビューでスライドサムネイルを生成することもできます。変換プロセスはシンプルかつ効率的で、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスの `save` メソッドを利用して、ノートとレイアウトを保持しながらプレゼンテーション全体を一連の TIFF 画像に変換します。

## **プレゼンテーションをノート付きで TIFF に変換**

Aspose.Slides for Java を使用して PowerPoint または OpenDocument のプレゼンテーションをノート付きで TIFF に保存するには、以下の手順が必要です。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスをインスタンス化します: PowerPoint または OpenDocument ファイルをロードします。
1. 出力レイアウトオプションを設定します: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) クラスを使用して、ノートとコメントの表示方法を指定します。
1. プレゼンテーションを TIFF に保存します: 設定したオプションを [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドに渡します。

例えば、以下のスライドを含む "speaker_notes.pptx" ファイルがあるとします:

![スピーカーノート付きのプレゼンテーションスライド](slide_with_notes.png)

以下のコードスニペットは、[setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) メソッドを使用して、Notes Slide ビューでプレゼンテーションを TIFF 画像に変換する方法を示しています。
```java
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // スライドの下にノートを表示します。

    // ノートのレイアウト設定を含む TIFF オプションを構成します。
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


結果:

![スピーカーノート付きの TIFF 画像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose の [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) をご覧ください。
{{% /alert %}}