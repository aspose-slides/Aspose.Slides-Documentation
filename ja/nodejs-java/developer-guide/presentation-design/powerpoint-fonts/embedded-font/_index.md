---
title: 埋め込みフォント - PowerPoint JavaScript API
linktitle: 埋め込みフォント
type: docs
weight: 40
url: /ja/nodejs-java/embedded-font/
keywords: "フォント, 埋め込みフォント, フォントの追加, PowerPoint プレゼンテーション, Java, Aspose.Slides for Node.js via Java"
description: "JavaScript で PowerPoint プレゼンテーションに埋め込みフォントを使用する"
---

**PowerPoint の埋め込みフォント** は、プレゼンテーションを任意のシステムやデバイスで開いたときに正しく表示させたい場合に便利です。作業で創造的な表現を行うためにサードパーティ製や非標準フォントを使用した場合、さらに埋め込みフォントを使用すべき理由が増えます。埋め込みフォントがない場合、スライド上のテキストや数値、レイアウト、スタイリングなどが変化したり、意味不明な四角形に置き換わったりする可能性があります。

[FontsManager] クラス、[FontData] クラス、[Compress] クラス、およびそれらのクラスは、PowerPoint プレゼンテーションで埋め込みフォントを操作するために必要なプロパティとメソッドのほとんどを提供しています。

## **プレゼンテーションから埋め込みフォントを取得または削除する**

Aspose.Slides は、プレゼンテーションに埋め込まれたフォントを取得（または確認）できるように、[FontsManager] クラスが提供する[getEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) メソッドを提供します。フォントを削除するには、同じクラスが提供する[removeEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) メソッドを使用します。

This JavaScript code shows you how to get and remove embedded fonts from a presentation:
```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // 埋め込み "FunSized" を使用するテキスト フレームを含むスライドをレンダリングします
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // 画像を JPEG 形式でディスクに保存します
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // すべての埋め込みフォントを取得します
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // "Calibri" フォントを検索します
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // "Calibri" フォントを削除します
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // プレゼンテーションをレンダリングします；"Calibri" フォントは既存のフォントに置き換えられます
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // 画像を JPEG 形式でディスクに保存します
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // 埋め込み "Calibri" フォントなしでプレゼンテーションをディスクに保存します
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **プレゼンテーションに埋め込みフォントを追加する**

[EmbedFontCharacters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/embedfontcharacters/) 列挙体と[addEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-) メソッドの 2 つのオーバーロードを使用して、プレゼンテーションにフォントを埋め込む際の好みの（埋め込み）ルールを選択できます。この JavaScript コードは、フォントを埋め込み、プレゼンテーションに追加する方法を示しています：
```javascript
// プレゼンテーションをロードします
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // プレゼンテーションをディスクに保存します
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **埋め込みフォントの圧縮**

プレゼンテーションに埋め込まれたフォントを圧縮してファイルサイズを削減できるように、Aspose.Slides は[Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) クラスが提供する[compressEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) メソッドを提供します。

この JavaScript コードは、埋め込み PowerPoint フォントを圧縮する方法を示しています：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**埋め込みが行われているにもかかわらず、プレゼンテーション内の特定のフォントがレンダリング時に置き換えられるかどうかは、どのように確認できますか？**

フォントマネージャーの[substitution information](/slides/ja/nodejs-java/font-substitution/) と[fallback/substitution rules](/slides/ja/nodejs-java/fallback-font/) を確認してください。フォントが利用できない、または制限されている場合はフォールバックが使用されます。

**Arial や Calibri などの「システム」フォントを埋め込む価値はありますか？**

通常は必要ありません。これらのフォントはほぼ常に利用可能です。ただし、Docker や事前にフォントがインストールされていない Linux サーバーなど、環境が限られている場合は、システムフォントを埋め込むことで予期しない置き換えのリスクを回避できます。