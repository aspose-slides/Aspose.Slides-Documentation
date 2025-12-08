---
title: PowerPointでC#を使用したフォント埋め込み
linktitle: フォント埋め込み
type: docs
weight: 40
url: /ja/net/embedded-font/
keywords:
- フォント埋め込み
- PowerPoint C#
- フォント追加
- プレゼンテーション
- Aspose.Slides for .NET
description: "C# と .NET を使用して PowerPoint プレゼンテーションにフォントを埋め込み、追加、管理する方法を学びます"
---


**PowerPoint へのフォント埋め込み** は、プレゼンテーションがさまざまなシステムでも意図した外観を維持できるようにします。独自のフォントでクリエイティブに表現する場合でも、標準フォントを使用する場合でも、フォントを埋め込むことでテキストやレイアウトの崩れを防止できます。

サードパーティや非標準のフォントを使用した場合、さらに埋め込む理由が増えます。埋め込みがない場合、スライド上のテキストや数字、レイアウト、スタイリングなどが変わったり、意味不明な四角形に置き換わる可能性があります。

以下のクラスを利用して埋め込みフォントを管理します: [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/), および [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)。

## **埋め込みフォントの取得と削除**

プレゼンテーションから埋め込みフォントを簡単に取得または削除するには、[GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) と [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont) メソッドを使用します。

この C# コードは、プレゼンテーションから埋め込みフォントを取得および削除する方法を示しています:
```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 埋め込み "FunSized" を使用したテキストフレームを含むスライドをレンダリングします
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // "Calibri" フォントを検索します
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // "Calibri" フォントを削除します
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // プレゼンテーションをレンダリングします；"Calibri" フォントは既存のフォントに置き換えられます
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // 埋め込み "Calibri" フォントなしでプレゼンテーションをディスクに保存します
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```


## **埋め込みフォントの追加**

[EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) 列挙体と [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) メソッドの 2 つのオーバーロードを使用して、好みの埋め込みルールを選択し、プレゼンテーションにフォントを埋め込むことができます。この C# コードは、フォントを埋め込んで追加する方法を示しています:
```c#
// プレゼンテーションをロードします
Presentation presentation = new Presentation("Fonts.pptx");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// プレゼンテーションをディスクに保存します
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```


## **埋め込みフォントの圧縮**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) を使用して埋め込みフォントを圧縮し、ファイルサイズを最適化します。

圧縮のサンプルコード:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**埋め込みが行われていても、プレゼンテーション内の特定のフォントがレンダリング時に置き換えられるかどうかは、どのように確認できますか？**

フォントマネージャーの [置換情報](/slides/ja/net/font-substitution/) と [フォールバック/置換ルール](/slides/ja/net/fallback-font/) を確認してください。フォントが利用できない、または制限されている場合はフォールバックが使用されます。

**Arial や Calibri といった「システム」フォントを埋め込む価値はありますか？**

通常は不要です。これらのフォントはほとんどの環境で利用可能です。ただし、Docker や事前にフォントがインストールされていない Linux サーバーなど、限られた環境で完全な移植性を確保したい場合は、システムフォントを埋め込むことで予期せぬ置換のリスクを回避できます。