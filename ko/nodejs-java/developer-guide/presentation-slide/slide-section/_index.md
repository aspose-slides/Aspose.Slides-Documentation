---
title: JavaScript를 사용하여 프레젠테이션의 슬라이드 섹션 관리
linktitle: 슬라이드 섹션
type: docs
weight: 90
url: /ko/nodejs-java/slide-section/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PPTX 프레젠테이션에서 슬라이드 섹션을 관리합니다: 섹션 슬라이드를 만들고, 이름을 바꾸고, 순서를 재배치하고, 가져오며, 처리합니다."
---
## **소개**

섹션은 슬라이드 내용을 변경하지 않고 연속된 슬라이드를 이름이 지정된 그룹으로 구성합니다. Aspose.Slides for Node.js via Java를 사용하면 [Presentation.getSections](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#getSections) 메서드를 통해 섹션을 만들고, 순서를 바꾸고, 이름을 바꾸고, 검사하고, 제거할 수 있습니다.

섹션은 특히 다음과 같은 경우에 유용합니다:

- 대규모 프레젠테이션을 논리적 주제나 챕터로 나누어야 할 때;
- 다른 슬라이드 그룹을 서로 다른 협업자에게 할당할 때;
- 슬라이드를 그룹으로 처리, 이동 또는 병합해야 할 때;

간결한 섹션 이름을 선택하여 그룹화된 슬라이드의 목적을 설명하십시오. 섹션은 프레젠테이션 구조의 일부이므로 슬라이드 위치에서 유도하는 대신 섹션 API를 사용하여 포함 관계를 판단하십시오.

## **섹션 만들기 및 관리**

[SectionCollection.addSection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sectioncollection/#addSection)를 사용하여 이름과 시작 슬라이드를 지정해 섹션을 생성합니다. Aspose.Slides는 현재 프레젠테이션의 섹션 구조를 기반으로 어떤 슬라이드가 해당 섹션에 속하는지 결정합니다.

같은 [SectionCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sectioncollection/)을 사용하면 다음을 수행할 수 있습니다:

- 섹션과 해당 슬라이드를 함께 이동하려면 [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides)를 사용합니다;
- 슬라이드는 유지하면서 섹션 정의만 제거하려면 [SectionCollection.removeSection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sectioncollection/#removeSection)를 사용합니다;
- 섹션과 해당 슬라이드를 모두 제거하려면 [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides)를 사용합니다;
- 끝에 빈 섹션을 추가하려면 [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection)를 사용합니다.

다음 예제는 두 개의 섹션을 만들고, 그 중 하나를 이동하고, 해당 슬라이드와 함께 제거하며, 빈 섹션을 추가합니다:

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

이러한 작업 후, 프레젠테이션에는 슬라이드가 포함된 `Introduction` 섹션과 빈 `Appendix` 섹션이 남습니다. `Results` 섹션과 해당 슬라이드는 제거되었습니다.

## **섹션 이름 바꾸기**

섹션의 이름을 바꾸려면 해당 [Section.setName](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/section/#setName) 메서드를 호출합니다. 섹션의 슬라이드와 위치는 변경되지 않습니다.

다음 예제는 섹션을 생성하고 이름을 변경합니다:

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

## **섹션에서 슬라이드 가져오기**

[Presentation.getSections](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#getSections) 메서드는 인덱스로 접근할 수 있는 [SectionCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sectioncollection/)을 반환합니다. 각 [Section](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/section/)에 대해 현재 해당 섹션에 속하는 슬라이드를 얻으려면 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/section/#getSlidesListOfSection)를 호출합니다. 이 메서드는 슬라이드 수와 인덱스 접근을 제공하는 [SectionSlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sectionslidecollection/)을 반환합니다.

다음 예제는 두 개의 채워진 섹션과 하나의 빈 섹션을 만든 다음, 각 섹션의 [이름](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/section/#getName), [식별자](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/section/#getSectionId), [시작 슬라이드](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/section/#getStartedFromSlide), 슬라이드 수 및 슬라이드 번호를 출력합니다. 이 예제는 [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sectionslidecollection/#get_Item)을 사용하여 첫 번째 슬라이드와 컬렉션의 모든 슬라이드를 읽습니다. 빈 섹션의 경우 반환된 컬렉션의 크기가 0이므로 인덱스 접근을 건너뛰고 루프는 아무 작업도 수행하지 않습니다.

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

섹션 포함 관계는 프레젠테이션의 섹션 구조에 의해 결정됩니다. [Section.getStartedFromSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/section/#getStartedFromSlide)와 슬라이드 인덱스 및 다음 섹션의 시작 슬라이드를 사용해 섹션 범위를 수동으로 계산하지 마십시오.

구조적 편집은 섹션에 대해 반환되는 슬라이드와 슬라이드 번호를 모두 변경할 수 있습니다. 여기에는 슬라이드 순서 변경, 슬라이드를 섹션에 복제, 섹션과 슬라이드를 함께 이동, 슬라이드 제거, 섹션 제거가 포함됩니다. 다음 예제는 섹션 경계에 대한 가정을 유지하는 대신 이러한 변경이 발생할 때마다 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/section/#getSlidesListOfSection)를 호출합니다.

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

슬라이드나 섹션이 순서가 바뀌거나, 복제되거나, 이동되거나, 제거될 때마다 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/section/#getSlidesListOfSection)를 다시 호출하십시오. 이렇게 하면 이후 처리 작업이 현재 프레젠테이션 구조와 일치합니다.

PPT (PowerPoint 97–2003) 형식은 섹션 메타데이터를 보존하지 않습니다. PPTX와 같이 섹션을 지원하는 형식으로 작업 흐름을 사용하십시오; PPT로 변환하면 이후 반복에 필요한 섹션 구조가 사라집니다.

## **FAQ**

**PPT (PowerPoint 97–2003) 형식으로 저장할 때 섹션이 보존됩니까?**

아니요. PPT 형식은 섹션 메타데이터를 지원하지 않으므로 .ppt 로 저장할 때 섹션 그룹화가 사라집니다.

**전체 섹션을 "숨길" 수 있습니까?**

아니요. 섹션 자체에는 가시성 상태가 없습니다. 내용을 숨기려면 섹션의 각 슬라이드에 대해 [Slide.setHidden](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/#setHidden) 를 호출하십시오.

**슬라이드를 포함하는 섹션을 어떻게 찾을 수 있나요?**

[Presentation.getSections](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#getSections) 로 반환된 컬렉션의 각 섹션에 접근하고, 각 섹션에 대해 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/section/#getSlidesListOfSection)를 호출한 뒤 반환된 슬라이드를 대상 슬라이드와 비교하십시오. 비어 있지 않은 섹션의 경우 [Section.getStartedFromSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/section/#getStartedFromSlide) 은 첫 번째 슬라이드를 반환하고, 빈 섹션의 경우 `null` 을 반환합니다.