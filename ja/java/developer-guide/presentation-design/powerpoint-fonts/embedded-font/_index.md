---
title: Java を使用したプレゼンテーションへのフォント埋め込み
linktitle: フォントの埋め込み
type: docs
weight: 40
url: /ja/java/embedded-font/
keywords:
- フォントを追加
- フォントを埋め込む
- フォント埋め込み
- 埋め込みフォントを取得
- 埋め込みフォントを追加
- 埋め込みフォントを削除
- 埋め込みフォントを圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument プレゼンテーションに TrueType フォントを埋め込み、すべてのプラットフォームで正確にレンダリングできるようにします。"
---

**PowerPoint の埋め込みフォント** は、プレゼンテーションを任意のシステムやデバイスで開いたときに正しく表示させたい場合に便利です。作業でクリエイティブに第三者製や非標準フォントを使用した場合、埋め込む理由はさらに増えます。それ以外の場合（埋め込みフォントがないと）、スライド上のテキストや数値、レイアウト、スタイルなどが変更されたり、意味不明な矩形（四角）になる可能性があります。

[FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) クラス、[FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/) クラス、[Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) クラス、およびそれらのインターフェイスには、PowerPoint プレゼンテーションで埋め込みフォントを操作するために必要なプロパティやメソッドがほぼすべて含まれています。

## **埋め込みフォントの取得と削除**

Aspose.Slides は、[getEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) メソッド（[FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) クラスで公開）を提供し、プレゼンテーションに埋め込まれているフォントを取得（または確認）できます。フォントを削除するには、同じクラスで公開されている [removeEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) メソッドを使用します。

以下の Java コードは、プレゼンテーションから埋め込みフォントを取得および削除する方法を示しています：
```java
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // 埋め込み "FunSized" を使用したテキストフレームを含むスライドをレンダーします
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //JPEG 形式で画像をディスクに保存
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // すべての埋め込みフォントを取得します
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // "Calibri" フォントを検索します
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // "Calibri" フォントを削除します
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // プレゼンテーションをレンダーします; "Calibri" フォントは既存のものに置き換えられます
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //JPEG 形式で画像をディスクに保存
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // 埋め込み "Calibri" フォントなしでプレゼンテーションをディスクに保存します
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **埋め込みフォントの追加**

[EmbedFontCharacters](https://reference.aspose.com/slides/java/com.aspose.slides/embedfontcharacters/) 列挙型と [addEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) メソッドの 2 つのオーバーロードを使用すると、プレゼンテーションにフォントを埋め込む際の好みの（埋め込み）ルールを選択できます。以下の Java コードは、フォントを埋め込み追加する方法を示しています：
```java
// プレゼンテーションを読み込みます
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

    // プレゼンテーションをディスクに保存します
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **埋め込みフォントの圧縮**

プレゼンテーションに埋め込まれたフォントを圧縮してファイルサイズを削減できるように、Aspose.Slides は [compressEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) メソッド（[Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) クラスで公開）を提供します。

以下の Java コードは、埋め込み PowerPoint フォントを圧縮する方法を示しています：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**埋め込み済みでも、プレゼンテーション内の特定のフォントがレンダリング時に置換されるかどうかはどう確認できますか？**

フォントマネージャーの [substitution information](/slides/ja/java/font-substitution/) と [fallback/substitution rules](/slides/ja/java/fallback-font/) を確認してください。フォントが利用できない、または制限されている場合はフォールバックが使用されます。

**Arial や Calibri などの「システム」フォントを埋め込む価値はありますか？**

通常は不要です。ほとんどの環境で利用可能だからです。ただし、Docker や事前にフォントがインストールされていない Linux サーバーなど「軽量」環境で完全な移植性を確保したい場合は、システムフォントを埋め込むことで予期せぬ置換のリスクを排除できます。