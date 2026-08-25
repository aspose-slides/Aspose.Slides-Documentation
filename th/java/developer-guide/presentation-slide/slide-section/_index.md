---
title: จัดการส่วนสไลด์ในงานนำเสนอด้วย Java
linktitle: ส่วนสไลด์
type: docs
weight: 90
url: /th/java/slide-section/
keywords:
- สร้างส่วน
- เพิ่มส่วน
- แก้ไขส่วน
- เปลี่ยนส่วน
- ชื่อส่วน
- ดึงสไลด์ของส่วน
- ประมวลผลสไลด์ของส่วน
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "จัดการส่วนสไลด์ด้วย Aspose.Slides สำหรับ Java: สร้าง, เปลี่ยนชื่อ, จัดลำดับใหม่, ดึงและประมวลผลสไลด์ของส่วนในงานนำเสนอ PPTX."
---
## **บทนำ**

Sections จัดระเบียบสไลด์ต่อเนื่องเป็นกลุ่มที่มีชื่อโดยไม่เปลี่ยนแปลงเนื้อหาของสไลด์. With Aspose.Slides for Java, you can create, reorder, rename, inspect, and remove sections through the [Presentation.getSections](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSections--) method.

Sections มีประโยชน์เป็นพิเศษเมื่อ:

- การนำเสนอขนาดใหญ่ต้องการแบ่งเป็นหัวข้อหรือบทที่มีตรรกะ;
- กลุ่มสไลด์ต่าง ๆ ถูกกำหนดให้กับผู้ร่วมงานคนละคน;
- สไลด์ต้องได้รับการประมวลผล, ย้าย, หรือรวมเป็นกลุ่ม.

เลือกชื่อส่วนที่กระชับและอธิบายวัตถุประสงค์ของสไลด์ที่จัดกลุ่มไว้. เนื่องจาก sections เป็นส่วนหนึ่งของโครงสร้างการนำเสนอ, ให้ใช้ API ของ section เพื่อกำหนดสมาชิกแทนการคำนวณจากตำแหน่งสไลด์.

## **สร้างและจัดการส่วน**

Use [ISectionCollection.addSection](https://reference.aspose.com/slides/th/java/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) to create a section by specifying its name and starting slide. Aspose.Slides determines which slides belong to the section from the presentation's current section structure.

The same [ISectionCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/isectioncollection/) also lets you:

- move a section together with its slides by using [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- remove only the section definition with [ISectionCollection.removeSection](https://reference.aspose.com/slides/th/java/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), which retains its slides;
- remove a section and its slides with [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- add an empty section at the end with [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/th/java/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

The following example creates two sections, moves one of them, removes it together with its slides, and appends an empty section:

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

After these operations, the presentation contains the `Introduction` section with its slides and an empty `Appendix` section. The `Results` section and its slides have been removed.

## **เปลี่ยนชื่อส่วน**

To rename a section, call its [ISection.setName](https://reference.aspose.com/slides/th/java/com.aspose.slides/isection/#setName-java.lang.String-) method. The section's slides and position remain unchanged.

The following example creates a section and changes its name:

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

## **ดึงสไลด์จากส่วน**

The [Presentation.getSections](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSections--) method returns an [ISectionCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/isectioncollection/) that you can iterate over. For each [ISection](https://reference.aspose.com/slides/th/java/com.aspose.slides/isection/), call [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/th/java/com.aspose.slides/isection/#getSlidesListOfSection--) to obtain the slides that currently belong to it. The method returns an [ISectionSlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/isectionslidecollection/), which provides a count, indexed access, and iteration.

The following example creates two populated sections and one empty section, then prints each section's [name](https://reference.aspose.com/slides/th/java/com.aspose.slides/isection/#getName--), [identifier](https://reference.aspose.com/slides/th/java/com.aspose.slides/isection/#getSectionId--), [starting slide](https://reference.aspose.com/slides/th/java/com.aspose.slides/isection/#getStartedFromSlide--), slide count, and slide numbers. It uses [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/th/java/com.aspose.slides/isectionslidecollection/#get_Item-int-) to read the first slide and an enhanced `for` statement to process every slide. For the empty section, the returned collection has a size of zero, the method is not called, and iteration performs no operations.

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

Section membership is determined by the presentation's section structure. Do not calculate a section's range manually from [ISection.getStartedFromSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/isection/#getStartedFromSlide--), slide indexes, and the next section's starting slide.

Structural edits can change both the slides returned for a section and their slide numbers. This includes reordering slides, cloning a slide into a section, moving a section together with its slides, removing slides, and removing sections. The next example calls [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/th/java/com.aspose.slides/isection/#getSlidesListOfSection--) after every such change instead of retaining assumptions about the section's former boundaries.

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

Call [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/th/java/com.aspose.slides/isection/#getSlidesListOfSection--) again whenever slides or sections are reordered, cloned, moved, or removed. This keeps subsequent processing aligned with the current presentation structure.

The PPT (PowerPoint 97–2003) format does not preserve section metadata. Use this workflow with a format that supports sections, such as PPTX; converting to PPT removes the section structure needed for later iteration.

## **FAQ**

**ส่วนจะถูกเก็บรักษาไว้หรือไม่เมื่อบันทึกเป็นรูปแบบ PPT (PowerPoint 97–2003)?**

No. The PPT format does not support section metadata, so section grouping is lost when saving to .ppt.

**สามารถซ่อนส่วนทั้งหมดได้หรือไม่?**

No. A section has no visibility state. To hide its contents, call [ISlide.setHidden](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#setHidden-boolean-) for each slide in the section.

**ฉันจะหาส่วนที่ประกอบด้วยสไลด์ใดสไลด์หนึ่งได้อย่างไร?**

Iterate over the collection returned by [Presentation.getSections](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSections--), call [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/th/java/com.aspose.slides/isection/#getSlidesListOfSection--) for each section, and compare the returned slides with the target slide. For a non-empty section, [ISection.getStartedFromSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/isection/#getStartedFromSlide--) returns its first slide; for an empty section, it returns `null`.