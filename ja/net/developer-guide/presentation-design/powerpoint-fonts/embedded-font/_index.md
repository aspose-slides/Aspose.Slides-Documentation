---
title: .NET でのプレゼンテーションへのフォント埋め込み
linktitle: フォント埋め込み
type: docs
weight: 40
url: /ja/net/embedded-font/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument プレゼンテーションに TrueType フォントを埋め込み、すべてのプラットフォームで正確なレンダリングを実現します。"
---

**PowerPoint にフォントを埋め込む** は、プレゼンテーションがさまざまなシステムで意図した外観を保つことを保証します。独自のフォントを使用して創造性を発揮する場合でも、標準フォントを使用する場合でも、フォントを埋め込むことでテキストやレイアウトの乱れを防止できます。

作業で創造的にサードパーティ製や非標準フォントを使用した場合、フォントを埋め込む理由はさらに増えます。埋め込みフォントがない場合、スライド上のテキストや数値、レイアウト、スタイルなどが変化したり、意味不明な四角形に置き換わったりする可能性があります。

埋め込みフォントを管理するには、[FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/)、[FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/)、および[Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) クラスを利用します。

## **埋め込みフォントの取得と削除**

プレゼンテーションから埋め込みフォントを簡単に取得または削除するには、[GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) および [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont) メソッドを使用します。

この C# コードは、プレゼンテーションから埋め込みフォントを取得および削除する方法を示しています:
```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 埋め込み "FunSized" を使用するテキストフレームを含むスライドをレンダリングします
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

    // プレゼンテーションをレンダリングします; "Calibri" フォントは既存のフォントに置き換えられます
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // 埋め込み "Calibri" フォントなしでプレゼンテーションをディスクに保存します
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```


## **埋め込みフォントの追加**

[EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) 列挙体と [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) メソッドの 2 つのオーバーロードを使用して、プレゼンテーションにフォントを埋め込むための好みの（埋め込み）ルールを選択できます。この C# コードは、プレゼンテーションにフォントを埋め込んで追加する方法を示しています:
```c#
// プレゼンテーションを読み込みます
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

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) を使用して埋め込みフォントを圧縮し、ファイル サイズを最適化します。

圧縮の例コード:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**埋め込み済みでも、プレゼンテーション内の特定のフォントがレンダリング時に置き換えられるかどうかは、どのように確認できますか？**

フォントマネージャーの [置換情報](/slides/ja/net/font-substitution/) と [代替/置換規則](/slides/ja/net/fallback-font/) を確認してください。フォントが利用できない、または制限されている場合、代替フォントが使用されます。

**Arial や Calibri などの「システム」フォントを埋め込む価値はありますか？**

通常は不要です。ほとんど常に利用可能だからです。ただし、Docker やフォントが事前にインストールされていない Linux サーバーなど、環境が「薄い」場合に完全な移植性を確保したい場合は、システムフォントを埋め込むことで予期しない置換のリスクを排除できます。