---
title: Java를 사용한 프레젠테이션 슬라이드 섹션 관리
linktitle: 슬라이드 섹션
type: docs
weight: 90
url: /ko/java/slide-section/
keywords:
- 섹션 만들기
- 섹션 추가
- 섹션 편집
- 섹션 변경
- 섹션 이름
- 섹션 슬라이드 가져오기
- 섹션 슬라이드 처리
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 슬라이드 섹션을 관리합니다: PPTX 프레젠테이션에서 섹션 슬라이드를 만들고, 이름을 바꾸고, 재정렬하고, 가져오며, 처리합니다."
---
## **소개**

섹션은 연속된 슬라이드를 이름이 지정된 그룹으로 구성하지만 슬라이드 내용은 변경하지 않습니다. Aspose.Slides for Java를 사용하면 [Presentation.getSections](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getSections--) 메서드를 통해 섹션을 생성, 재정렬, 이름 변경, 검사 및 제거할 수 있습니다.

섹션은 다음과 같은 경우에 특히 유용합니다:

- 대용량 프레젠테이션을 논리적 주제 또는 장으로 나눌 필요가 있을 때;
- 다른 슬라이드 그룹을 서로 다른 협업자에게 할당할 때;
- 슬라이드를 그룹으로 처리, 이동 또는 병합해야 할 때.

그룹화된 슬라이드의 목적을 설명하는 간결한 섹션 이름을 선택하십시오. 섹션은 프레젠테이션 구조의 일부이므로 슬라이드 위치에서 유추하는 대신 섹션 API를 사용하여 멤버십을 확인하십시오.

## **섹션 만들기 및 관리**

[ISectionCollection.addSection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-)을 사용하여 이름과 시작 슬라이드를 지정해 섹션을 만들 수 있습니다. Aspose.Slides는 현재 프레젠테이션의 섹션 구조를 기반으로 섹션에 포함될 슬라이드를 결정합니다.

같은 [ISectionCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isectioncollection/)을 사용하면 다음도 할 수 있습니다:

- [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-)을 사용하여 섹션과 해당 슬라이드를 함께 이동합니다;
- [ISectionCollection.removeSection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-)을 사용해 섹션 정의만 제거하고 슬라이드는 유지합니다;
- [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-)을 사용해 섹션과 그 슬라이드를 모두 제거합니다;
- [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-)을 사용해 끝에 빈 섹션을 추가합니다.

다음 예제는 두 개의 섹션을 만든 뒤 하나를 이동하고 해당 슬라이드와 함께 제거한 뒤 빈 섹션을 추가합니다:

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

이 작업 후 프레젠테이션에는 슬라이드가 포함된 `Introduction` 섹션과 빈 `Appendix` 섹션이 남고, `Results` 섹션과 그 슬라이드는 제거됩니다.

## **섹션 이름 바꾸기**

섹션의 이름을 바꾸려면 해당 섹션의 [ISection.setName](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isection/#setName-java.lang.String-) 메서드를 호출합니다. 섹션의 슬라이드와 위치는 변경되지 않습니다.

다음 예제는 섹션을 만들고 이름을 변경합니다:

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

## **섹션에서 슬라이드 가져오기**

[Presentation.getSections](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getSections--) 메서드는 반복할 수 있는 [ISectionCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isectioncollection/)을 반환합니다. 각 [ISection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isection/)에 대해 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isection/#getSlidesListOfSection--)를 호출하면 현재 해당 섹션에 포함된 슬라이드를 얻을 수 있습니다. 이 메서드는 슬라이드 수, 인덱스 접근 및 반복을 제공하는 [ISectionSlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isectionslidecollection/)을 반환합니다.

다음 예제는 두 개의 내용이 있는 섹션과 하나의 빈 섹션을 만든 뒤 각 섹션의 [name](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isection/#getName--), [identifier](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isection/#getSectionId--), [starting slide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isection/#getStartedFromSlide--), 슬라이드 수 및 슬라이드 번호를 출력합니다. 첫 번째 슬라이드를 읽기 위해 [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isectionslidecollection/#get_Item-int-)을 사용하고, 향상된 `for` 문으로 모든 슬라이드를 처리합니다. 빈 섹션의 경우 반환된 컬렉션의 크기가 0이므로 메서드가 호출되지 않고 반복도 수행되지 않습니다.

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

섹션 멤버십은 프레젠테이션의 섹션 구조에 의해 결정됩니다. [ISection.getStartedFromSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isection/#getStartedFromSlide--)와 슬라이드 인덱스, 그리고 다음 섹션의 시작 슬라이드만으로 섹션 범위를 수동으로 계산하지 마십시오.

구조적 편집은 섹션에 대해 반환되는 슬라이드와 해당 슬라이드 번호를 모두 변경할 수 있습니다. 여기에는 슬라이드 재정렬, 슬라이드를 섹션에 복제, 섹션과 슬라이드 함께 이동, 슬라이드 제거 및 섹션 제거가 포함됩니다. 다음 예제는 이러한 변경이 발생할 때마다 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isection/#getSlidesListOfSection--)를 호출하여 이전 경계에 대한 가정을 유지하지 않습니다.

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

슬라이드나 섹션이 재정렬, 복제, 이동 또는 제거될 때마다 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isection/#getSlidesListOfSection--)를 다시 호출하십시오. 이렇게 하면 이후 처리 작업이 현재 프레젠테이션 구조와 일치합니다.

PPT (PowerPoint 97–2003) 형식은 섹션 메타데이터를 보존하지 않습니다. PPTX와 같이 섹션을 지원하는 형식으로 작업 흐름을 사용하십시오; PPT로 변환하면 이후 반복에 필요한 섹션 구조가 사라집니다.

## **자주 묻는 질문**

**PPT (PowerPoint 97–2003) 형식으로 저장할 때 섹션이 유지되나요?**

아닙니다. PPT 형식은 섹션 메타데이터를 지원하지 않으므로 .ppt로 저장하면 섹션 그룹화가 사라집니다.

**전체 섹션을 "숨길" 수 있나요?**

아닙니다. 섹션 자체에는 가시성 상태가 없습니다. 섹션의 내용을 숨기려면 해당 섹션에 포함된 각 슬라이드에 대해 [ISlide.setHidden](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islide/#setHidden-boolean-)를 호출하십시오.

**슬라이드를 포함하는 섹션을 어떻게 찾을 수 있나요?**

[Presentation.getSections](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getSections--)가 반환하는 컬렉션을 반복하면서 각 섹션에 대해 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isection/#getSlidesListOfSection--)를 호출하고, 반환된 슬라이드와 대상 슬라이드를 비교합니다. 비어 있지 않은 섹션의 경우 [ISection.getStartedFromSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isection/#getStartedFromSlide--)가 첫 번째 슬라이드를 반환하고, 빈 섹션의 경우 `null`을 반환합니다.