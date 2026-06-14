---
title: 使用 Java 管理簡報中的投影片節
linktitle: 投影片節
type: docs
weight: 90
url: /zh-hant/java/slide-section/
keywords:
- 建立節
- 新增節
- 編輯節
- 變更節
- 節名稱
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 簡化 PowerPoint 與 OpenDocument 中的投影片節 — 分割、重新命名與重新排序，以最佳化 PPTX 與 ODP 工作流程。"
---
## **簡介**

使用 Aspose.Slides for Java，您可以將 PowerPoint 簡報組織成多個節。您可以建立包含特定投影片的節。

在以下情況下，您可能想建立節並使用它們來組織或劃分簡報中的投影片，以形成邏輯上的部分：

- 當您與其他人或團隊共同處理大型簡報，且需要將特定投影片指派給同事或某些團隊成員時。 
- 當簡報包含大量投影片，且您難以一次管理或編輯其內容時。

理想情況下，您應該建立一個包含相似投影片的節——這些投影片具有共同點或可依據某規則歸為一組——並為該節命名，以描述其中的投影片。

## **在簡報中建立節**

若要在簡報中加入用於收納投影片的節，Aspose.Slides for Java 提供了 [addSection()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) 方法，允許您指定欲建立的節名稱以及該節起始的投影片。

以下範例程式碼示範了如何在 Java 中於簡報建立節：

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 會在 newSlide2 結束，之後 section2 將開始   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **變更節的名稱**

在 PowerPoint 簡報中建立節之後，您可能會決定變更其名稱。

以下範例程式碼示範了如何使用 Aspose.Slides 在 Java 中變更簡報中節的名稱：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問答**

**在將檔案儲存為 PPT（PowerPoint 97–2003）格式時，節會被保留嗎？**

不會。PPT 格式不支援節的中繼資料，因此儲存為 .ppt 時會失去節的分組資訊。

**整個節可以被「隱藏」嗎？**

不行。只能隱藏單一投影片。作為實體的節沒有「隱藏」狀態。

**我能否快速透過投影片找到其所屬的節，或反過來找到節的第一張投影片？**

可以。節是以其起始投影片唯一定義的；給定一張投影片即可判斷其屬於哪個節，而對於節則可取得其第一張投影片。