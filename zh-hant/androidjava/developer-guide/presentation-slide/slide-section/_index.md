---
title: 在 Android 上管理簡報的投影片區段
linktitle: 投影片區段
type: docs
weight: 90
url: /zh-hant/androidjava/slide-section/
keywords:
- 建立區段
- 新增區段
- 編輯區段
- 變更區段
- 區段名稱
- 取得區段投影片
- 處理區段投影片
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 管理 PPTX 簡報中的投影片區段：建立、重新命名、重新排序、取得及處理區段投影片。"
---
## **簡介**

區段可將連續投影片組織成具名稱的群組，而不會更改投影片內容。使用 Aspose.Slides for Android via Java，您可以透過 [Presentation.getSections](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSections--) 方法建立、重新排序、重新命名、檢查以及移除區段。

區段在以下情況特別有用：

- 必須將大型簡報切分為邏輯性的主題或章節；
- 不同投影片群組分配給不同的協作者；
- 需要將投影片作為群組進行處理、移動或合併。

請為分組的投影片選擇簡潔且能說明其目的的區段名稱。由於區段是簡報結構的一部份，請使用區段 API 來判斷所屬關係，而不要依賴投影片位置自行推算。

## **建立與管理區段**

使用 [ISectionCollection.addSection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-)，透過指定名稱與起始投影片來建立區段。Aspose.Slides 會根據簡報目前的區段結構判斷哪些投影片屬於該區段。

相同的 [ISectionCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isectioncollection/) 也讓您：

- 使用 [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-) 搬移區段及其投影片；
- 只移除區段定義而保留投影片，使用 [ISectionCollection.removeSection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-)；
- 同時移除區段與投影片，使用 [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-)；
- 在結尾加入空白區段，使用 [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-)。

以下範例建立兩個區段、搬移其中一個、連同投影片一起移除，並在最後加入空白區段：

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

執行完上述操作後，簡報會保留 `Introduction` 區段及其投影片，並有一個空的 `Appendix` 區段。`Results` 區段及其投影片已被移除。

## **重新命名區段**

若要重新命名區段，呼叫其 [ISection.setName](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isection/#setName-java.lang.String-) 方法。區段的投影片與位置不會改變。

以下範例建立一個區段並變更其名稱：

```java
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
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

## **從區段取得投影片**

[Presentation.getSections](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSections--) 方法會回傳一個 [ISectionCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isectioncollection/)，您可以對其進行迭代。對每個 [ISection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isection/) 呼叫 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) 即可取得目前屬於該區段的投影片。此方法回傳一個 [ISectionSlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isectionslidecollection/)，提供計數、索引存取與迭代功能。

以下範例建立兩個已填充的區段與一個空白區段，接著列印每個區段的 [name](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isection/#getName--)、[identifier](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isection/#getSectionId--)、[starting slide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isection/#getStartedFromSlide--)、投影片計數與投影片編號。它使用 [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) 讀取第一張投影片，並以增強的 `for` 陳述式處理每一張投影片。對於空白區段，回傳的集合大小為零，方法不會被呼叫，迭代也不執行任何操作。

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

區段成員資格由簡報的區段結構決定。請勿自行從 [ISection.getStartedFromSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isection/#getStartedFromSlide--)、投影片索引以及下一個區段的起始投影片計算區段範圍。

結構性的編輯可能會同時變更區段回傳的投影片以及它們的投影片編號。這包括重新排序投影片、將投影片克隆至區段、搬移區段及其投影片、移除投影片，以及移除區段。以下範例在每一次此類變更後呼叫 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--)，而不是保留對先前區段邊界的假設。

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

每當投影片或區段被重新排序、克隆、搬移或移除時，請再次呼叫 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--)，以確保後續處理與目前的簡報結構保持一致。

PPT（PowerPoint 97–2003）格式不會保留區段中繼資料。請使用支援區段的格式（例如 PPTX）執行此工作流程；轉換為 PPT 會移除後續迭代所需的區段結構。

## **常見問題**

**將簡報儲存為 PPT（PowerPoint 97–2003）格式時，區段會被保留嗎？**

不會。PPT 格式不支援區段中繼資料，儲存為 .ppt 時會失去區段分組。

**可以將整個區段「隱藏」嗎？**

不行。區段本身沒有可見性狀態。若要隱藏其內容，必須對區段內的每張投影片呼叫 [ISlide.setHidden](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#setHidden-boolean-)。

**如何找出包含特定投影片的區段？**

遍歷由 [Presentation.getSections](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSections--) 回傳的集合，對每個區段呼叫 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--)，並將回傳的投影片與目標投影片比較。對於非空區段，[ISection.getStartedFromSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) 會回傳其第一張投影片；對於空區段，則回傳 `null`。