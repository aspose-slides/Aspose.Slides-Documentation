---
title: 在 Android 上管理簡報中的投影片章節
linktitle: 投影片章節
type: docs
weight: 90
url: /zh-hant/androidjava/slide-section/
keywords:
- 建立章節
- 新增章節
- 編輯章節
- 變更章節
- 章節名稱
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 簡化 PowerPoint 與 OpenDocument 的投影片章節——拆分、重新命名與重新排序，以優化 PPTX 與 ODP 工作流程。"
---
## **簡介**

使用 Aspose.Slides for Android via Java，您可以將 PowerPoint 簡報組織成多個章節。您可以建立包含特定投影片的章節。

在以下情況下，您可能想建立章節並使用它們來組織或將簡報中的投影片劃分為邏輯部份：

- 當您與其他人或團隊一起處理大型簡報，且需要將特定投影片指派給同事或一些團隊成員時。 
- 當您面對包含大量投影片的簡報，且難以一次管理或編輯其內容時。

理想情況下，您應建立容納相似投影片的章節——這些投影片具備共同點或可根據規則形成一組——並為章節命名，以描述其中的投影片內容。 

## **在簡報中建立章節**

若要在簡報中加入容納投影片的章節，Aspose.Slides for Android via Java 提供了 [addSection()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) 方法，讓您指定欲建立的章節名稱以及章節開始的投影片。

以下範例程式碼示範如何在 Java 中於簡報建立章節：

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 會在 newSlide2 結束，之後會開始 section2   

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

## **變更章節名稱**

在 PowerPoint 簡報中建立章節後，您可能會決定變更其名稱。 

以下範例程式碼示範如何使用 Aspose.Slides 於 Java 中變更簡報章節的名稱：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**將章節儲存為 PPT（PowerPoint 97–2003）格式時會保留嗎？**

不會。PPT 格式不支援章節中繼資料，儲存為 .ppt 時會失去章節分組。

**整個章節可以「隱藏」嗎？**

不會。只有個別投影片可以被隱藏。章節本身並沒有「隱藏」狀態。

**我能根據投影片快速找到其所屬章節，或反過來取得章節的第一張投影片嗎？**

可以。章節是以其起始投影片唯一定義的；給定一張投影片即可判斷其屬於哪個章節，而對於章節則可取得其第一張投影片。