---
title: 使用 Java 管理簡報中的投影片章節
linktitle: 投影片章節
type: docs
weight: 90
url: /zh-hant/java/slide-section/
keywords:
- 建立章節
- 新增章節
- 編輯章節
- 更改章節
- 章節名稱
- 取得章節投影片
- 處理章節投影片
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 管理投影片章節：在 PPTX 簡報中建立、重新命名、重新排序、取得與處理章節投影片。"
---
## **簡介**

章節將連續的投影片組織成具名稱的群組，且不會更改投影片內容。使用 Aspose.Slides for Java，您可以透過 [Presentation.getSections](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSections--) 方法建立、重新排序、重新命名、檢查和移除章節。

章節在以下情況特別有用：

- 大型簡報需要劃分為邏輯主題或章節；
- 不同的投影片群組分配給不同的協作者；
- 投影片需要以群組方式處理、移動或合併。

選擇簡潔的章節名稱，以描述該群組投影片的目的。由於章節是簡報結構的一部份，請使用章節 API 來判斷歸屬關係，而不是根據投影片位置推斷。

## **建立與管理章節**

使用 [ISectionCollection.addSection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) 依名稱與起始投影片建立章節。Aspose.Slides 會根據簡報目前的章節結構判斷哪些投影片屬於該章節。

相同的 [ISectionCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isectioncollection/) 也讓您：

- 使用 [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-) 將章節與其投影片一起移動；
- 僅使用 [ISectionCollection.removeSection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-) 移除章節定義，保留其投影片；
- 使用 [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-) 移除章節及其投影片；
- 使用 [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-) 在末尾新增空白章節。

以下範例建立兩個章節，移動其中一個，連同其投影片一起移除，並附加一個空白章節：

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

這些操作完成後，簡報包含具有投影片的 `Introduction` 章節以及一個空的 `Appendix` 章節。`Results` 章節及其投影片已被移除。

## **重新命名章節**

若要重新命名章節，請呼叫其 [ISection.setName](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isection/#setName-java.lang.String-) 方法。章節的投影片與位置保持不變。

以下範例建立一個章節並變更其名稱：

```java
import com.aspose.slides.ISection;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **從章節取得投影片**

[Presentation.getSections](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSections--) 方法會回傳一個可供迭代的 [ISectionCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isectioncollection/)。對於每個 [ISection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isection/)，呼叫 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isection/#getSlidesListOfSection--) 取得目前屬於該章節的投影片。此方法會回傳一個 [ISectionSlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isectionslidecollection/)，提供計數、索引存取與迭代功能。

以下範例建立兩個有內容的章節與一個空白章節，接著列印每個章節的 [名稱](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isection/#getName--)、[識別碼](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isection/#getSectionId--)、[起始投影片](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isection/#getStartedFromSlide--)、投影片數量與投影片編號。它使用 [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isectionslidecollection/#get_Item-int-) 讀取第一張投影片，並以增強的 `for` 陳述式處理每張投影片。對於空白章節，回傳的集合大小為零，該方法不會被呼叫，迭代也不執行任何操作。

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

章節的成員資格由簡報的章節結構決定。請勿手動根據 [ISection.getStartedFromSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isection/#getStartedFromSlide--)、投影片索引以及下一個章節的起始投影片計算章節範圍。

結構性編輯可能會變更章節回傳的投影片以及它們的投影片編號。這包括重新排序投影片、將投影片複製至章節、將章節與其投影片一起移動、移除投影片以及移除章節。下一個範例在每次此類變更後呼叫 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isection/#getSlidesListOfSection--)，而不是保留對章節先前邊界的假設。

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

每當投影片或章節重新排序、複製、移動或移除時，請再次呼叫 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isection/#getSlidesListOfSection--)。這可確保後續處理與目前的簡報結構保持一致。

PPT（PowerPoint 97–2003）格式不會保留章節中繼資料。請使用支援章節的格式（例如 PPTX）進行此工作流程；轉換為 PPT 會移除後續迭代所需的章節結構。

## **常見問題**

**將章節保存為 PPT（PowerPoint 97–2003）格式時會被保留嗎？**

不會。PPT 格式不支援章節中繼資料，因此在儲存為 .ppt 時會失去章節分組。

**整個章節能被「隱藏」嗎？**

不行。章節沒有可見性狀態。若要隱藏其內容，請對該章節中的每張投影片呼叫 [ISlide.setHidden](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#setHidden-boolean-)。

**如何找出包含特定投影片的章節？**

遍歷由 [Presentation.getSections](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSections--) 回傳的集合，對每個章節呼叫 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isection/#getSlidesListOfSection--)，並將回傳的投影片與目標投影片比較。對於非空章節，[ISection.getStartedFromSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isection/#getStartedFromSlide--) 會回傳其第一張投影片；對於空章節，則回傳 `null`。