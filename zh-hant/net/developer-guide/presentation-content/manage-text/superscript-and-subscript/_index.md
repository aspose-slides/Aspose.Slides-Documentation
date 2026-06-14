---
title: 在 .NET 簡報中管理上標與下標
linktitle: 上標與下標
type: docs
weight: 80
url: /zh-hant/net/superscript-and-subscript/
keywords:
- 上標
- 下標
- 新增上標
- 新增下標
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "掌握 Aspose.Slides for .NET 中的上標與下標，並透過專業的文字格式化提升簡報的最大影響力。"
---
## **概述**

Aspose.Slides for .NET 提供將上標與下標文字整合至您的 PowerPoint (PPT、PPTX) 以及 OpenDocument (ODP) 簡報的功能。無論您需要突顯化學式、數學方程式，或以註腳註解內容，這些特殊的格式選項都有助於保持清晰與精確。本文將教您如何在每張投影片中無縫套用上標與下標樣式，確保呈現專業的效果。

## **新增上標與下標文字**

您可以在簡報中的任何段落內加入上標與下標文字。要在 Aspose.Slides 中達成此功能，必須使用 [PortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/portionformat/) 類別的 `Escapement` 屬性。

此屬性允許您設定上標或下標文字，其值範圍為 -100%（下標）至 100%（上標）。

實作步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 使用索引取得投影片的參考。
1. 在投影片上加入類型為 `Rectangle` 的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。
1. 取得與 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 相關聯的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/)。
1. 清除現有的段落。
1. 建立新的 [Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraph/) 以放置上標文字，並將其加入 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 的段落集合中。
1. 建立新的文字 Portion 物件。
1. 將文字 Portion 的 `Escapement` 屬性設定為 0 到 100 之間以套用上標（0 表示沒有上標）。
1. 為 [Portion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/portion/) 設定文字，並將其加入段落的 Portion 集合中。
1. 再建立一個用於下標文字的 [Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraph/)，並將其加入段落集合中。
1. 建立新的文字 Portion 物件。
1. 將文字 Portion 的 `Escapement` 屬性設定為 0 到 -100 之間以套用下標（0 表示沒有下標）。
1. 為 [Portion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/portion/) 設定文字，並將其加入段落的 Portion 集合中。
1. 將簡報儲存為 PPTX 檔案。

以下 C# 程式碼實作了上述步驟：

```c#
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 建立文字方塊。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // 建立上標文字的段落。
    IParagraph superPar = new Paragraph();

    // 建立一般文字的文字片段。
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // 建立上標文字的文字片段。
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // 建立下標文字的段落。
    IParagraph paragraph2 = new Paragraph();

    // 建立一般文字的文字片段。
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // 建立下標文字的文字片段。
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // 將段落加入文字方塊。
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

結果：

![上標與下標](superscript_and_subscript.png)

## **常見問題**

**將簡報匯出為 PDF 或其他格式時，會保留上標與下標嗎？**

是的，Aspose.Slides for .NET 在將簡報匯出為 PDF、PPT/PPTX、影像以及其他支援的格式時，會正確保留上標與下標的格式。此特殊格式在所有輸出檔案中皆保持完整。

**上標與下標可以與其他格式樣式（例如粗體或斜體）結合使用嗎？**

是的，Aspose.Slides 允許您在同一個 Portion 內混合多種文字樣式。您可以啟用粗體、斜體、底線，同時透過設定 [PortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/portionformat/) 中相應的屬性來套用上標或下標。

**上標與下標的格式化能否在表格、圖表或 SmartArt 內的文字使用？**

是的，Aspose.Slides for .NET 支援在大多數物件中使用格式化，包括表格與圖表元素。使用 SmartArt 時，您需要存取相應的元素（例如 [SmartArtNode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/smartartnode/)）及其文字容器，然後以類似方式設定 [PortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/portionformat/) 屬性。