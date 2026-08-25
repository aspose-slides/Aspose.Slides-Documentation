---
title: จัดการส่วนสไลด์ในการนำเสนอบน Android
linktitle: ส่วนสไลด์
type: docs
weight: 90
url: /th/androidjava/slide-section/
keywords:
- สร้างส่วน
- เพิ่มส่วน
- แก้ไขส่วน
- เปลี่ยนส่วน
- ชื่อส่วน
- ดึงสไลด์ของส่วน
- ประมวลผลสไลด์ของส่วน
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการส่วนสไลด์ด้วย Aspose.Slides for Android ผ่าน Java: สร้าง, เปลี่ยนชื่อ, จัดเรียงใหม่, ดึงและประมวลผลสไลด์ของส่วนในงานนำเสนอ PPTX."
---
## **บทนำ**

ส่วนจัดระเบียบสไลด์ต่อเนื่องเป็นกลุ่มที่มีชื่อโดยไม่เปลี่ยนเนื้อหาสไลด์. ด้วย Aspose.Slides for Android ผ่าน Java, คุณสามารถสร้าง, จัดเรียงใหม่, เปลี่ยนชื่อ, ตรวจสอบ, และลบส่วนผ่านวิธี [Presentation.getSections](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSections--) 

ส่วนมีประโยชน์โดยเฉพาะเมื่อ:

- งานนำเสนอที่ใหญ่ต้องการแบ่งเป็นหัวข้อหรือบทที่เป็นตรรกะ;
- กลุ่มสไลด์ต่าง ๆ ถูกมอบหมายให้กับผู้ร่วมงานคนละคน;
- สไลด์ต้องการประมวลผล, ย้าย, หรือรวมเป็นกลุ่ม.

เลือกชื่อส่วนที่กระชับและอธิบายวัตถุประสงค์ของสไลด์ที่รวมกัน. เนื่องจากส่วนเป็นส่วนหนึ่งของโครงสร้างงานนำเสนอ, ใช้ API ของส่วนเพื่อกำหนดสมาชิกแทนการพิจารณาตำแหน่งสไลด์.

## **สร้างและจัดการส่วน**

ใช้ [ISectionCollection.addSection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) เพื่อสร้างส่วนโดยระบุชื่อและสไลด์เริ่มต้น. Aspose.Slides กำหนดสไลด์ที่เป็นของส่วนจากโครงสร้างส่วนปัจจุบันของงานนำเสนอ.

[ISectionCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isectioncollection/) เดียวกันยังทำให้คุณ:

- ย้ายส่วนพร้อมกับสไลด์ของมันโดยใช้ [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- ลบเพียงคำนิยามส่วนด้วย [ISectionCollection.removeSection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), ซึ่งยังคงเก็บสไลด์ไว้;
- ลบส่วนและสไลด์ของมันด้วย [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- เพิ่มส่วนว่างที่ท้ายรายการด้วย [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

ตัวอย่างต่อไปนี้สร้างสองส่วน, ย้ายหนึ่งส่วน, ลบมันพร้อมสไลด์, และเพิ่มส่วนว่าง:

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

หลังจากการกระทำเหล่านี้, งานนำเสนอจะมีส่วน `Introduction` พร้อมสไลด์ของมันและส่วนว่าง `Appendix`. ส่วน `Results` พร้อมสไลด์ของมันถูกลบออกไปแล้ว.

## **เปลี่ยนชื่อส่วน**

เพื่อเปลี่ยนชื่อส่วน, เรียกเมธอด [ISection.setName](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isection/#setName-java.lang.String-) ของส่วนนั้น. สไลด์และตำแหน่งของส่วนจะคงเดิม.

ตัวอย่างต่อไปนี้สร้างส่วนและเปลี่ยนชื่อของมัน:

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

## **ดึงสไลด์จากส่วน**

เมธอด [Presentation.getSections](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSections--) คืนค่า [ISectionCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isectioncollection/) ที่คุณสามารถวนซ้ำได้. สำหรับแต่ละ [ISection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isection/), เรียก [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) เพื่อรับสไลด์ที่อยู่ในส่วนนั้นขณะนั้น. เมธอดจะคืนค่า [ISectionSlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isectionslidecollection/), ซึ่งให้จำนวน, การเข้าถึงแบบอินเด็กซ์, และการวนซ้ำ.

ตัวอย่างต่อไปนี้สร้างสองส่วนที่มีเนื้อหาและหนึ่งส่วนว่าง, จากนั้นพิมพ์ [name](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isection/#getName--), [identifier](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isection/#getSectionId--), [starting slide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), จำนวนสไลด์, และหมายเลขสไลด์ของแต่ละส่วน. ตัวอย่างใช้ [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) เพื่ออ่านสไลด์แรกและใช้คำสั่ง `for` แบบขยายเพื่อประมวลผลทุกสไลด์. สำหรับส่วนว่าง, คอลเลกชันที่คืนค่ามีขนาดศูนย์, ไม่เรียกเมธอด, และการวนซ้ำไม่ทำการใด ๆ.

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

การเป็นสมาชิกของส่วนถูกกำหนดโดยโครงสร้างส่วนของงานนำเสนอ. อย่าคำนวนช่วงของส่วนด้วยตนเองจาก [ISection.getStartedFromSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), ดัชนีสไลด์, และสไลด์เริ่มต้นของส่วนถัดไป.

การแก้ไขเชิงโครงสร้างอาจเปลี่ยนสไลด์ที่คืนค่าสำหรับส่วนและหมายเลขสไลด์ของมัน. ซึ่งรวมถึงการจัดเรียงสไลด์ใหม่, การโคลนสไลด์เข้าไปในส่วน, การย้ายส่วนพร้อมสไลด์, การลบสไลด์, และการลบส่วน. ตัวอย่างต่อไปนี้เรียก [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) หลังจากการเปลี่ยนแปลงแต่ละครั้งแทนการคงสมมติฐานเกี่ยวกับขอบเขตเดิมของส่วน.

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

เรียก [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) อีกครั้งทุกครั้งที่สไลด์หรือส่วนถูกจัดเรียงใหม่, โคลน, ย้าย, หรือ ลบ. สิ่งนี้ทำให้การประมวลผลต่อมาสอดคล้องกับโครงสร้างงานนำเสนอปัจจุบัน.

รูปแบบ PPT (PowerPoint 97–2003) ไม่เก็บข้อมูลเมทาดาต้าของส่วน. ใช้ขั้นตอนนี้กับรูปแบบที่รองรับส่วน, เช่น PPTX; การแปลงเป็น PPT จะลบโครงสร้างส่วนที่จำเป็นสำหรับการวนซ้ำในภายหลัง.

## **คำถามที่พบบ่อย**

**ส่วนจะถูกเก็บไว้เมื่อบันทึกเป็นรูปแบบ PPT (PowerPoint 97–2003) หรือไม่?**

ไม่. รูปแบบ PPT ไม่รองรับเมทาดาต้าของส่วน, ดังนั้นการจัดกลุ่มส่วนจะหายไปเมื่อบันทึกเป็น .ppt.

**สามารถทำให้ส่วนทั้งหมด "ซ่อน" ได้หรือไม่?**

ไม่. ส่วนไม่มีสถานะการมองเห็น. เพื่อซ่อนเนื้อหาของส่วน, ให้เรียก [ISlide.setHidden](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#setHidden-boolean-) สำหรับแต่ละสไลด์ในส่วนนั้น.

**จะค้นหาส่วนที่มีสไลด์อยู่ได้อย่างไร?**

วนซ้ำผ่านคอลเลกชันที่คืนค่าจาก [Presentation.getSections](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSections--), เรียก [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) สำหรับแต่ละส่วน, แล้วเปรียบเทียบสไลด์ที่คืนค่ากับสไลด์เป้าหมาย. สำหรับส่วนที่ไม่ว่าง, [ISection.getStartedFromSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) จะคืนสไลด์แรก; สำหรับส่วนว่าง, จะคืนค่า `null`.