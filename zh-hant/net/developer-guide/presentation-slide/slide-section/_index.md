---
title: 在 .NET 中管理簡報的投影片區段
linktitle: 投影片區段
type: docs
weight: 100
url: /zh-hant/net/slide-section/
keywords:
- 建立區段
- 新增區段
- 編輯區段
- 變更區段
- 區段名稱
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 簡化 PowerPoint 和 OpenDocument 的投影片區段 — 拆分、重新命名與重新排順序，以優化 PPTX 與 ODP 工作流程。"
---
## **簡介**

使用 Aspose.Slides for .NET，您可以將 PowerPoint 簡報組織成多個區段。您可以建立包含特定投影片的區段。

您可能想要建立區段並利用它們來組織或劃分簡報中的投影片，以下情況特別適用：

- 當您與其他人或團隊一起處理大型簡報，且需要將特定投影片指派給同事或團隊成員時。 
- 當簡報中包含許多投影片，且您難以一次管理或編輯其內容時。

理想情況下，您應該建立一個包含相似投影片的區段——這些投影片具有共同點，或可根據某規則歸為一組——並為該區段命名，以描述其內部的投影片。

## **在簡報中建立區段**

若要在簡報中加入容納投影片的區段，Aspose.Slides for .NET 提供 AddSection 方法，允許您指定欲建立的區段名稱以及區段開始的投影片。

以下範例程式碼示範如何在 C# 中於簡報建立區段：

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 會在 newSlide2 結束，之後會開始 section2   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## **變更區段名稱**

在 PowerPoint 簡報中建立區段後，您可能會決定變更其名稱。

以下範例程式碼示範如何使用 Aspose.Slides 在 C# 中變更簡報區段的名稱：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```

## **常見問題**

**將區段儲存為 PPT（PowerPoint 97–2003）格式時，會保留嗎？**

不會。PPT 格式不支援區段中繼資料，因此在儲存為 .ppt 時，區段分組會遺失。

**整個區段可以被「隱藏」嗎？**

不行。只能隱藏單獨的投影片。區段本身作為實體沒有「隱藏」狀態。

**我可以依據投影片快速找到其所屬的區段，反之亦然，找到區段的第一張投影片嗎？**

可以。區段是以其起始投影片唯一定義的；給定一張投影片即可判斷其屬於哪個區段，而對於區段則可取得其第一張投影片。