---
title: Python via Java를 사용한 프레젠테이션에서 슬라이드 섹션 관리
linktitle: 슬라이드 섹션
type: docs
weight: 90
url: /ko/python-java/slide-section/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PPTX 프레젠테이션에서 슬라이드 섹션을 관리합니다: 섹션 슬라이드 만들기, 이름 바꾸기, 재정렬, 가져오기 및 처리."
---
## **Introduction**

섹션은 슬라이드 내용을 변경하지 않고 연속된 슬라이드를 명명된 그룹으로 정리합니다. Aspose.Slides for Python via Java를 사용하면 [Presentation.getSections](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSections) 메서드를 통해 섹션을 생성, 재정렬, 이름 변경, 검사 및 제거할 수 있습니다.

섹션은 특히 다음과 같은 경우에 유용합니다:

- 대규모 프레젠테이션을 논리적 주제 또는 장으로 나누어야 할 때;
- 서로 다른 슬라이드 그룹을 서로 다른 공동 작업자에게 할당해야 할 때;
- 슬라이드를 그룹 단위로 처리, 이동 또는 병합해야 할 때.

그룹화된 슬라이드의 목적을 설명하는 간결한 섹션 이름을 선택하세요. 섹션은 프레젠테이션 구조의 일부이므로 슬라이드 위치에서 유추하지 말고 섹션 API를 사용해 멤버십을 판단하세요.

## **Create and Manage Sections**

[SectionCollection.addSection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sectioncollection/#addSection) 을 사용해 이름과 시작 슬라이드를 지정하여 섹션을 생성합니다. Aspose.Slides는 현재 섹션 구조를 기반으로 섹션에 포함될 슬라이드를 결정합니다.

같은 [SectionCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sectioncollection/)을 통해 다음 작업도 수행할 수 있습니다:

- [reorderSectionWithSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) 을 사용해 섹션과 해당 슬라이드를 함께 이동;
- 슬라이드를 유지하면서 섹션 정의만 제거하려면 [removeSection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sectioncollection/#removeSection) 사용;
- 섹션과 슬라이드를 모두 제거하려면 [removeSectionWithSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sectioncollection/#removeSectionwithslides) 사용;
- 끝에 빈 섹션을 추가하려면 [appendEmptySection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sectioncollection/#appendEmptySection) 사용.

다음 예제는 두 개의 섹션을 만들고, 하나를 이동하고, 해당 섹션을 슬라이드와 함께 제거한 뒤, 빈 섹션을 추가합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

이 작업이 끝난 후 프레젠테이션에는 `Introduction` 섹션과 해당 슬라이드, 그리고 빈 `Appendix` 섹션이 남아 있습니다. `Results` 섹션과 그 슬라이드는 제거되었습니다.

## **Rename Sections**

섹션 이름을 변경하려면 해당 섹션의 [Section.setName](https://reference.aspose.com/slides/ko/python-java/aspose.slides/section/#setName) 메서드를 호출합니다. 섹션의 슬라이드와 위치는 그대로 유지됩니다.

다음 예제는 섹션을 생성하고 이름을 변경합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **Retrieve Slides from Sections**

[Presentation.getSections](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSections) 메서드는 반복할 수 있는 [SectionCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sectioncollection/)을 반환합니다. 각 [Section](https://reference.aspose.com/slides/ko/python-java/aspose.slides/section/)에 대해 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/section/#getSlidesListOfSection) 을 호출하면 현재 해당 섹션에 속한 슬라이드를 얻을 수 있습니다. 이 메서드는 슬라이드 개수, 인덱스 접근 및 반복을 지원하는 [SectionSlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sectionslidecollection/)을 반환합니다.

다음 예제는 두 개의 채워진 섹션과 하나의 빈 섹션을 만든 뒤, 각 섹션의 [name](https://reference.aspose.com/slides/ko/python-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/ko/python-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/section/#getStartedFromSlide), 슬라이드 개수 및 슬라이드 번호를 출력합니다. 첫 번째 슬라이드를 읽기 위해 [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sectionslidecollection/#get_Item) 를 사용하고, 모든 슬라이드를 처리하기 위해 `for` 문을 사용합니다. 빈 섹션의 경우 반환된 컬렉션 크기가 0이므로 메서드가 호출되지 않고 반복도 수행되지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

섹션 멤버십은 프레젠테이션의 섹션 구조에 의해 결정됩니다. [Section.getStartedFromSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/section/#getStartedFromSlide) 과 슬라이드 인덱스, 다음 섹션의 시작 슬라이드만으로 섹션 범위를 수동으로 계산하지 마세요.

구조적 편집은 섹션에 반환되는 슬라이드와 슬라이드 번호 모두를 변경할 수 있습니다. 여기에는 슬라이드 재정렬, 슬라이드 복제, 섹션과 슬라이드 이동, 슬라이드 제거 및 섹션 제거가 포함됩니다. 다음 예제는 이러한 변화가 발생할 때마다 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/section/#getSlidesListOfSection) 을 다시 호출하여 이전 경계에 대한 가정을 유지하지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

슬라이드나 섹션이 재정렬, 복제, 이동 또는 제거될 때마다 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/section/#getSlidesListOfSection) 을 다시 호출하세요. 이렇게 하면 이후 처리 작업이 현재 프레젠테이션 구조와 일치합니다.

PPT(PowerPoint 97–2003) 형식은 섹션 메타데이터를 보존하지 않습니다. PPTX와 같이 섹션을 지원하는 형식으로 작업을 진행하고, PPT로 변환하면 이후 반복에 필요한 섹션 구조가 손실됩니다.

## **FAQ**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**

아니요. PPT 형식은 섹션 메타데이터를 지원하지 않으므로 .ppt로 저장하면 섹션 그룹화가 손실됩니다.

**Can an entire section be "hidden"?**

아니요. 섹션 자체에는 가시성 상태가 없습니다. 섹션 내용을 숨기려면 섹션에 포함된 각 슬라이드에 대해 [Slide.setHidden](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#setHidden) 를 호출하십시오.

**How can I find the section that contains a slide?**

[Presentation.getSections](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSections) 로 반환된 컬렉션을 반복하면서 각 섹션에 대해 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/section/#getSlidesListOfSection) 을 호출하고, 반환된 슬라이드와 대상 슬라이드를 비교합니다. 비어 있지 않은 섹션의 경우 [Section.getStartedFromSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/section/#getStartedFromSlide) 이 첫 번째 슬라이드를 반환하고, 빈 섹션의 경우 `None` 을 반환합니다.