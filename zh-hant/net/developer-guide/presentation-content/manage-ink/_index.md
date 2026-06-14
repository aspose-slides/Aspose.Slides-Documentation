---
title: 在 .NET 中管理簡報墨跡物件
linktitle: 管理墨跡
type: docs
weight: 95
url: /zh-hant/net/manage-ink/
keywords:
- 墨跡
- 墨跡物件
- 墨跡追蹤
- 管理墨跡
- 繪製墨跡
- 繪圖
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "管理 PowerPoint 墨跡物件—使用 Aspose.Slides for .NET 建立、編輯與設定數位墨跡樣式。取得追蹤、筆刷顏色與大小的程式碼範例。"
---
## **介紹**

PowerPoint 提供墨跡功能，讓您能繪製非標準圖形，可用於強調其他物件、顯示連接與流程，以及突出投影片中的特定項目。

Aspose.Slides 提供 [Aspose.Slides.Ink](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ink/) 介面，其中包含建立與管理墨跡物件所需的型別。

## **一般物件與墨跡物件之差異**

PowerPoint 投影片上的物件通常以形狀物件表示。形狀物件在最簡單的形式下是一個容器，定義物件本身的區域（其框架）以及其屬性。後者包括容器區域大小、容器的形狀、容器的背景等等。相關資訊請參閱 [Shape Layout Format](https://docs.aspose.com/slides/zh-hant/net/shape-manipulations/#access-layout-formats-for-shape)。

然而，當 PowerPoint 處理墨跡物件時，會忽略除大小之外的所有框架（容器）屬性。容器區域的大小由標準的 `width` 與 `height` 值決定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨跡追蹤**

追蹤是用來紀錄使用者書寫數位墨跡時筆尖軌跡的基本元素或標準。追蹤是描述連續點序列的錄製。

最簡單的編碼形式指定每個取樣點的 X 與 Y 座標。當所有連接點被渲染時，會產生如下圖像：

![ink_powerpoint2](ink_powerpoint2.png)

## **繪圖筆刷屬性**

您可以使用筆刷繪製連接追蹤元素點的線條。筆刷具有自己的顏色與大小，分別對應 `Brush.Color` 與 `Brush.Size` 屬性。

### **設定墨跡筆刷顏色**

以下 C# 程式碼示範如何設定筆刷的顏色：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```

### **設定墨跡筆刷大小**

以下 C# 程式碼示範如何設定筆刷的大小：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```

一般而言，筆刷的寬度與高度不相等，PowerPoint 不會顯示筆刷大小（資料區段呈灰色）。但當筆刷的寬度與高度相等時，PowerPoint 會如圖所示顯示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

為了說明，我們將墨跡物件的高度提升，並檢視重要尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不會考慮筆刷的大小——它始終假設線條的粗細為零（見最後一張圖）。

因此，要決定整個墨跡物件的可見區域，必須納入追蹤物件的筆刷大小。此處，目標物件（手寫文字追蹤物件）已被縮放至容器（框架）大小。當容器（框架）大小變更時，筆刷大小保持不變，反之亦然：

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 在處理文字時也會呈現相同的行為：

![ink_powerpoint6](ink_powerpoint6.png)

**進一步閱讀**

* 若要了解一般形狀，請參閱 [PowerPoint 形狀](https://docs.aspose.com/slides/zh-hant/net/powerpoint-shapes/) 章节。  
* 若需更多有效值資訊，請參閱 [形狀有效屬性](https://docs.aspose.com/slides/zh-hant/net/shape-effective-properties/#get-effective-font-height-value)。