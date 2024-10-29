---
title: 埋め込みフォント - PowerPoint Java API
linktitle: 埋め込みフォント
type: docs
weight: 40
url: /ja/java/embedded-font/
keywords: "フォント, 埋め込みフォント, フォントの追加, PowerPointプレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaでPowerPointプレゼンテーションに埋め込みフォントを使用する"

---

**PowerPointの埋め込みフォント**は、プレゼンテーションが任意のシステムやデバイスで正しく表示されるようにしたいときに便利です。作業に創造的に取り組んだためにサードパーティ製や非標準のフォントを使用した場合、フォントを埋め込む理由はさらに増えます。そうでなければ（埋め込みフォントがない場合）、スライドのテキストや数字、レイアウト、スタイルなどが変更されたり、混乱を招く長方形に変わったりする可能性があります。

[FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)クラス、[FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/)クラス、[Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)クラスとそのインターフェースには、PowerPointプレゼンテーションで埋め込みフォントを操作するために必要なプロパティとメソッドがほとんど含まれています。

## **プレゼンテーションから埋め込みフォントを取得または削除する**

Aspose.Slidesは、プレゼンテーションに埋め込まれたフォントを取得（または確認）するために、[getEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)メソッド（[FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)クラスによって公開されています）を提供します。フォントを削除するには、[removeEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-)メソッド（同じクラスによって公開されています）を使用します。

このJavaコードは、プレゼンテーションから埋め込みフォントを取得および削除する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化する
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // 埋め込みフォント「FunSized」を使用しているテキストフレームを含むスライドをレンダリングする
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //画像をJPEG形式でディスクに保存する
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // すべての埋め込みフォントを取得する
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // "Calibri"フォントを探す
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // "Calibri"フォントを削除する
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // プレゼンテーションをレンダリングする; "Calibri"フォントは既存のものに置き換えられる
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //画像をJPEG形式でディスクに保存する
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // 埋め込み"Calibri"フォントなしでプレゼンテーションをディスクに保存する
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **プレゼンテーションに埋め込みフォントを追加する**

[EmbedFontCharacters](https://reference.aspose.com/slides/java/com.aspose.slides/embedfontcharacters/)列挙型と2つのオーバーロードを使用した[addEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-)メソッドを使用することで、プレゼンテーションでフォントを埋め込むための好みの（埋め込み）ルールを選択できます。このJavaコードは、プレゼンテーションにフォントを埋め込み、追加する方法を示しています：

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

    // プレゼンテーションをディスクに保存する
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **埋め込みフォントを圧縮する**

プレゼンテーションに埋め込まれたフォントを圧縮し、そのファイルサイズを減らすために、Aspose.Slidesは[compressEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-)メソッド（[Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)クラスによって公開されています）を提供します。

このJavaコードは、埋め込みPowerPointフォントを圧縮する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```