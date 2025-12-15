---
title: Android のプレゼンテーションにフォントを埋め込む
linktitle: フォントの埋め込み
type: docs
weight: 40
url: /ja/androidjava/embedded-font/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションに TrueType フォントを埋め込み、すべてのプラットフォームで正確なレンダリングを実現します。"
---

**PowerPoint の埋め込みフォント** は、プレゼンテーションを任意のシステムやデバイスで開いたときに正しく表示させたい場合に便利です。作業で創造的にサードパーティ製や標準外のフォントを使用したのであれば、フォントを埋め込む理由はさらに増えます。それ以外の場合（埋め込みフォントがない場合）、スライド上のテキストや数値、レイアウト、スタイルなどが変化したり、意味不明な四角形に置き換わったりする可能性があります。

[FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) クラス、[FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) クラス、[Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) クラス、およびそれらのインターフェイスは、PowerPoint プレゼンテーションで埋め込みフォントを操作するために必要なプロパティとメソッドの大部分を提供します。

## **埋め込みフォントの取得と削除**

Aspose.Slides は、[FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) クラスで公開されている [getEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) メソッドを提供し、プレゼンテーションに埋め込まれたフォントを取得（または確認）できるようにします。フォントを削除するには、同じクラスで公開されている [removeEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) メソッドを使用します。

この Java コードは、プレゼンテーションから埋め込みフォントを取得および削除する方法を示しています:
```java
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // 埋め込みフォント "FunSized" を使用するテキストフレームを含むスライドをレンダリングします
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Save 画像を JPEG 形式でディスクに保存します
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

    // プレゼンテーションをレンダリングします; "Calibri" フォントは既存のフォントに置き換えられます
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Save 画像を JPEG 形式でディスクに保存します
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

[EmbedFontCharacters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/embedfontcharacters/) 列挙体と、[addEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) メソッドの 2 つのオーバーロードを使用して、プレゼンテーションにフォントを埋め込む際の好みの（埋め込み）ルールを選択できます。この Java コードは、プレゼンテーションにフォントを埋め込み、追加する方法を示しています:
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

    // プレゼンテーションをディスクに保存します
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **埋め込みフォントの圧縮**

プレゼンテーションに埋め込まれたフォントを圧縮し、ファイルサイズを削減できるように、Aspose.Slides は [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) クラスで公開されている [compressEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) メソッドを提供します。

この Java コードは、埋め込み PowerPoint フォントを圧縮する方法を示しています:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **よくある質問**

**プレゼンテーション内の特定のフォントが、埋め込みにもかかわらずレンダリング時に置き換えられるかどうかをどのように判断できますか？**

フォントマネージャーの [substitution information](/slides/ja/androidjava/font-substitution/) と [fallback/substitution rules](/slides/ja/androidjava/fallback-font/) を確認してください。フォントが利用できない、または制限されている場合は、フォールバックが使用されます。

**Arial や Calibri などの「システム」フォントを埋め込む価値はありますか？**

通常はありません—これらのフォントはほぼ常に利用可能です。ただし、Docker や事前にフォントがインストールされていない Linux サーバーなどの「薄い」環境での完全なポータビリティが必要な場合は、システムフォントを埋め込むことで予期しない置き換えのリスクを排除できます。