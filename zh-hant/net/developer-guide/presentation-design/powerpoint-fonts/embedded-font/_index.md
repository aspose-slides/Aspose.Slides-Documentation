---
title: 在 .NET 中將字型嵌入簡報
linktitle: 嵌入字型
type: docs
weight: 40
url: /zh-hant/net/embedded-font/
keywords:
- 新增字型
- 嵌入字型
- 字型嵌入
- 取得已嵌入的字型
- 新增已嵌入的字型
- 移除已嵌入的字型
- 壓縮已嵌入的字型
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 將 TrueType 字型嵌入 PowerPoint 與 OpenDocument 簡報，確保在所有平台上正確呈現。"
---
## **簡介**

**Embedding fonts in PowerPoint** 可確保您的簡報在不同系統上保持預期的外觀。無論是使用創意的特殊字型還是標準字型，嵌入字型都能防止文字與版面配置被破壞。

如果您因為創意需求而使用了第三方或非標準字型，那麼更應該將字型嵌入。否則（未嵌入字型時），投影片上的文字或數字、版面配置、樣式等可能會改變或變成難以辨識的方塊。

使用 [FontsManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/)、[FontData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontdata/) 和 [Compress](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/) 類別來管理已嵌入的字型。

## **取得與移除已嵌入字型**

使用 [GetEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/getembeddedfonts) 和 [RemoveEmbeddedFont](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/removeembeddedfont) 方法，可輕鬆取得或移除簡報中的已嵌入字型。

以下 C# 程式碼展示了如何取得與移除已嵌入的字型：

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 呈現包含使用已嵌入「FunSized」字型的文字框的投影片
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // 尋找「Calibri」字型
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // 移除「Calibri」字型
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // 呈現簡報；「Calibri」字型將被現有的字型取代
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // 將未嵌入「Calibri」字型的簡報儲存至磁碟
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **添加已嵌入字型**

透過 [EmbedFontCharacters](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/embedfontcharacters/) 列舉以及 [AddEmbeddedFont](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/addembeddedfont/) 方法的兩個重載，您可以選擇想要的（嵌入）規則，將字型嵌入簡報中。以下 C# 程式碼展示了如何嵌入與添加字型：

```c#
// 載入簡報
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

// 儲存簡報至磁碟
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **壓縮已嵌入字型**

使用 [CompressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/compressembeddedfonts/) 可壓縮已嵌入的字型，以減少檔案大小。

壓縮範例程式碼：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **常見問答**

**如何判斷簡報中某個特定字型在嵌入後仍會在渲染時被替代？**

檢查字型管理器中的[字型替代資訊](/slides/zh-hant/net/font-substitution/)以及[備援/替代規則](/slides/zh-hant/net/fallback-font/)：如果該字型不可用或受限，系統會使用備援字型。

**將「系統」字型（如 Arial、Calibri）嵌入是否值得？**

通常不需要——這些字型幾乎隨處可得。但在「精簡」環境（Docker、未預裝字型的 Linux 伺服器）中，嵌入系統字型可消除意外替代的風險，提升可攜性。