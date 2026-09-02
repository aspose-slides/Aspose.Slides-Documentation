---
title: 使用 JavaScript 管理簡報中的投影片章節
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
- 取得章節投影片
- 處理章節投影片
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 管理 PPTX 簡報中的投影片章節：建立、重新命名、重新排序、取得以及處理章節投影片。"
---
## **簡介**

章節將連續的投影片組織成具名稱的群組，而不會更改投影片內容。使用 Aspose.Slides for Node.js via Java，您可以透過 [Presentation.getSections](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getSections) 方法建立、重新排序、重新命名、檢查和移除章節。

章節在以下情況特別有用：

- 大型簡報需要劃分為邏輯主題或章節；
- 不同的投影片群組分配給不同的協作者；
- 投影片需要以群組方式處理、移動或合併。

選擇簡潔的章節名稱以描述該群組投影片的用途。由於章節是簡報結構的一部份，請使用章節 API 來判斷歸屬，而非從投影片位置推算。

## **建立與管理章節**

使用 [SectionCollection.addSection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sectioncollection/#addSection) 透過指定名稱與起始投影片來建立章節。Aspose.Slides 會根據簡報目前的章節結構判斷哪些投影片屬於該章節。

相同的 [SectionCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sectioncollection/) 也提供以下功能：

- 使用 [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) 移動章節及其投影片；
- 僅使用 [SectionCollection.removeSection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sectioncollection/#removeSection) 移除章節定義，保留其投影片；
- 使用 [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides) 同時移除章節及其投影片；
- 使用 [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection) 在末尾新增空章節。

以下範例建立兩個章節，移動其中一個，將其與投影片一起移除，並附加一個空章節：

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

這些操作完成後，簡報包含帶有投影片的 `Introduction` 章節以及空的 `Appendix` 章節。`Results` 章節及其投影片已被移除。

## **重新命名章節**

若要重新命名章節，請呼叫其 [Section.setName](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/section/#setName) 方法。章節的投影片與位置將保持不變。

以下範例建立一個章節並變更其名稱：

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **從章節取得投影片**

[Presentation.getSections](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getSections) 方法會回傳一個 [SectionCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sectioncollection/)，您可以依索引存取。對每個 [Section](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/section/)，呼叫 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/section/#getSlidesListOfSection) 以取得目前屬於該章節的投影片。此方法回傳一個 [SectionSlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sectionslidecollection/)，提供計數與索引存取功能。

以下範例建立兩個已填充的章節和一個空章節，然後列印每個章節的 [name](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/section/#getName)、[identifier](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/section/#getSectionId)、[starting slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/section/#getStartedFromSlide)、投影片計數與投影片編號。它使用 [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) 讀取第一張投影片以及集合中的每一張投影片。對於空章節，回傳的集合大小為零，跳過索引存取，迴圈不執行任何操作。

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

章節成員關係由簡報的章節結構決定。不要從 [Section.getStartedFromSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/section/#getStartedFromSlide)、投影片索引以及下一個章節的起始投影片手動計算章節範圍。

結構編輯可能會更改章節返回的投影片以及它們的投影片編號。這包括重新排序投影片、將投影片複製到章節、移動章節及其投影片、移除投影片以及移除章節。以下範例在每次此類變更後呼叫 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/section/#getSlidesListOfSection)，而非依賴先前的章節邊界假設。

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

每當投影片或章節重新排序、複製、移動或移除時，請再次呼叫 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/section/#getSlidesListOfSection)。這可確保後續處理與當前簡報結構保持一致。

PPT（PowerPoint 97–2003）格式不會保留章節中繼資料。請使用支援章節的格式（例如 PPTX）執行此工作流程；轉換為 PPT 會移除後續迭代所需的章節結構。

## **常見問題**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**

不會。PPT 格式不支援章節中繼資料，因此在儲存為 .ppt 時會遺失章節分組。

**Can an entire section be "hidden"?**

不行。章節沒有可見性狀態。若要隱藏其內容，需對章節內的每張投影片呼叫 [Slide.setHidden](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#setHidden)。

**How can I find the section that contains a slide?**

先取得 [Presentation.getSections](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getSections) 回傳的集合中的每個章節，對每個章節呼叫 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/section/#getSlidesListOfSection)，並將返回的投影片與目標投影片進行比較。對於非空的章節，[Section.getStartedFromSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/section/#getStartedFromSlide) 會返回其第一張投影片；對於空章節，則返回 `null`。