---
title: 使用 JavaScript 在簡報中管理投影片章節
linktitle: 投影片章節
type: docs
weight: 90
url: /zh-hant/nodejs-java/slide-section/
keywords:
- 建立章節
- 新增章節
- 編輯章節
- 變更章節
- 章節名稱
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 簡化 PowerPoint 與 OpenDocument 中的投影片章節 — 分割、重新命名與重新排序，以優化 PPTX 與 ODP 工作流程。"
---
## **簡介**

使用 Aspose.Slides for Node.js via Java，您可以將 PowerPoint 簡報組織成多個章節。您可以建立包含特定投影片的章節。

在以下情況下，您可能想要建立章節並使用它們來組織或劃分簡報中的投影片，使其成為邏輯上的部分：

- 當您與其他人或團隊共同處理大型簡報時，且需要將特定投影片指派給同事或某些團隊成員。 
- 當您面對包含大量投影片的簡報，且難以一次管理或編輯其內容時。

理想情況下，您應該建立一個容納相似投影片的章節——這些投影片具有共通點或可根據某種規則分組——並為該章節命名，以描述其內部的投影片。 

## **在簡報中建立章節**

若要在簡報中加入容納投影片的章節，Aspose.Slides for Node.js via Java 提供了 [addSection()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) 方法，允許您指定欲建立章節的名稱以及章節開始的投影片。

以下範例程式碼示範如何在 JavaScript 中於簡報建立章節：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 將在 newSlide2 結束，之後 section2 將開始
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **變更章節名稱**

在 PowerPoint 簡報中建立章節後，您可能會決定更改其名稱。 

以下範例程式碼示範如何使用 Aspose.Slides 在 JavaScript 中變更簡報章節的名稱：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**將章節儲存為 PPT（PowerPoint 97–2003）格式時會保留嗎？**

不會。PPT 格式不支援章節的中繼資料，儲存為 .ppt 時會遺失章節分組。

**整個章節可以「隱藏」嗎？**

不行。只能隱藏單一投影片。章節作為實體沒有「隱藏」狀態。

**我可以透過投影片快速找到其所屬的章節，或反過來取得章節的第一張投影片嗎？**

可以。章節是以其起始投影片唯一定義的；給定一張投影片即可判斷其屬於哪個章節，而對於章節也可以取得其第一張投影片。