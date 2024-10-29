---
title: 埋め込みフォント - PowerPoint C# API
linktitle: 埋め込みフォント
type: docs
weight: 40
url: /ja/net/embedded-font/
keywords:
- フォント
- 埋め込みフォント
- フォントの追加
- PowerPoint
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C#または.NETでPowerPointプレゼンテーションに埋め込みフォントを使用する"
---

**PowerPointの埋め込みフォント**は、プレゼンテーションを任意のシステムやデバイスで正しく表示させたいときに便利です。作業に創造性を発揮してサードパーティのフォントや非標準のフォントを使用した場合、フォントを埋め込む理由はさらに増えます。そうしない場合（埋め込みフォントなし）、スライド上のテキストや数字、レイアウト、スタイルなどが変更されたり、混乱を招く四角形に変わる可能性があります。

[FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/) クラス、[FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/) クラス、[Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) クラス、およびそれらのインターフェイスには、PowerPointプレゼンテーションで埋め込みフォントを操作するために必要なプロパティやメソッドのほとんどが含まれています。

## **プレゼンテーションから埋め込みフォントを取得または削除する**

Aspose.Slidesは、プレゼンテーションに埋め込まれているフォントを取得（または確認）するための [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) メソッドを提供しています（[FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/) クラスによって公開）。フォントを削除するには、同じクラスによって公開されている [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont) メソッドを使用します。

このC#コードは、プレゼンテーションから埋め込みフォントを取得および削除する方法を示しています：

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 埋め込み "FunSized" フォントを使用するテキストフレームを含むスライドをレンダリングします
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // "Calibri"フォントを見つける
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // "Calibri"フォントを削除する
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // プレゼンテーションをレンダリングします；"Calibri"フォントは既存のフォントに置き換えられます
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // 埋め込み "Calibri" フォントなしでプレゼンテーションをディスクに保存します
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **プレゼンテーションに埋め込みフォントを追加する**
[EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) 列挙体と、[AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) メソッドの2つのオーバーロードを使用すると、プレゼンテーションにフォントを埋め込むための好みの（埋め込み）ルールを選択できます。このC#コードは、プレゼンテーションにフォントを埋め込みおよび追加する方法を示しています：

```c#
// プレゼンテーションを読み込む
Presentation presentation = new Presentation("Fonts.pptx");

// 置き換えるソースフォントを読み込む
IFontData sourceFont = new FontData("Arial");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// プレゼンテーションをディスクに保存する
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **埋め込みフォントを圧縮する**

プレゼンテーションに埋め込まれているフォントを圧縮してファイルサイズを減らすために、Aspose.Slidesは [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) メソッドを提供しています（[Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) クラスによって公開）。

このC#コードは、埋め込みPowerPointフォントを圧縮する方法を示しています：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```