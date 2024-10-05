---
title: 埋め込みフォント - PowerPoint Java API
linktitle: 埋め込みフォント
type: docs
weight: 40
url: /androidjava/embedded-font/
keywords: "フォント, 埋め込みフォント, フォントの追加, PowerPoint プレゼンテーション, Java, Aspose.Slides for Android via Java"
description: "Java での PowerPoint プレゼンテーションに埋め込みフォントを使用する"

---

**PowerPoint の埋め込みフォント**は、プレゼンテーションを任意のシステムやデバイスで正しく表示したい場合に便利です。作業の際に第三者のフォントや非標準フォントを使用した場合は、フォントを埋め込む理由がさらに増えます。それ以外の場合（埋め込みフォントがない場合）、スライド上のテキストや数字、レイアウト、スタイルなどが変更されたり、混乱を招く長方形に変わったりする可能性があります。

[FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) クラス、[FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) クラス、[Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) クラス、およびそれらのインターフェースには、PowerPoint プレゼンテーションで埋め込みフォントを操作するために必要なプロパティとメソッドのほとんどが含まれています。

## **プレゼンテーションから埋め込みフォントを取得または削除する**

Aspose.Slides は、プレゼンテーションに埋め込まれたフォントを取得（または調べる）ために、[getEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) メソッド（[FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) クラスによって公開されている）を提供します。フォントを削除するには、同じクラスによって公開されている [removeEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) メソッドを使用します。

以下の Java コードは、プレゼンテーションから埋め込みフォントを取得して削除する方法を示しています：

```java
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // 埋め込み "FunSized" フォントを使用したテキストフレームを含むスライドをレンダリング
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // 画像を JPEG 形式でディスクに保存
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // すべての埋め込みフォントを取得
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // "Calibri" フォントを見つける
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // "Calibri" フォントを削除
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // プレゼンテーションをレンダリング; "Calibri" フォントは既存のものに置き換えられる
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // 画像を JPEG 形式でディスクに保存
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // 埋め込み "Calibri" フォントなしのプレゼンテーションをディスクに保存
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **プレゼンテーションに埋め込みフォントを追加する**

[EmbedFontCharacters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/embedfontcharacters/) 列挙体と [addEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) メソッドの 2 つのオーバーロードを使用すると、お好みの（埋め込み）ルールを選択してプレゼンテーションにフォントを埋め込むことができます。この Java コードは、プレゼンテーションにフォントを埋め込んで追加する方法を示しています：

```java
// プレゼンテーションを読み込む
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // プレゼンテーションをディスクに保存
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **埋め込みフォントを圧縮する**

プレゼンテーションに埋め込まれたフォントを圧縮してファイルサイズを削減できるように、Aspose.Slides は [compressEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) メソッド（[Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) クラスによって公開されている）を提供しています。

この Java コードは、埋め込み PowerPoint フォントを圧縮する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```