---
title: Java를 사용하여 프레젠테이션에서 슬라이드 섹션 관리
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
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java와 함께 PowerPoint 및 OpenDocument의 슬라이드 섹션을 간소화합니다 — PPTX와 ODP 워크플로를 최적화하기 위해 분할, 이름 변경 및 순서를 재배치합니다."
---
## **소개**

Aspose.Slides for Java를 사용하면 PowerPoint 프레젠테이션을 섹션으로 구성할 수 있습니다. 특정 슬라이드를 포함하는 섹션을 만들 수 있습니다.

다음과 같은 상황에서 섹션을 만들어 프레젠테이션의 슬라이드를 논리적인 부분으로 조직하거나 나누고 싶을 수 있습니다:

- 대규모 프레젠테이션을 다른 사람이나 팀과 함께 작업하고 있으며, 특정 슬라이드를 동료나 팀원에게 할당해야 할 때.
- 많은 슬라이드가 포함된 프레젠테이션을 다루고 있으며, 한 번에 내용 전체를 관리하거나 편집하기 어려울 때.

이상적으로는 비슷한 슬라이드들을 포함하는 섹션을 만들어야 합니다—슬라이드가 공통점을 가지고 있거나 규칙에 따라 그룹화될 수 있는 경우—그리고 해당 섹션에 슬라이드 내용을 설명하는 이름을 지정합니다.

## **프레젠테이션에서 섹션 만들기**

프레젠테이션에 슬라이드를 포함할 섹션을 추가하려면 Aspose.Slides for Java가 제공하는 [addSection()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) 메서드를 사용하여 생성하려는 섹션의 이름과 섹션이 시작되는 슬라이드를 지정할 수 있습니다.

다음 샘플 코드는 Java에서 프레젠테이션에 섹션을 만드는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1은 newSlide2에서 종료되고 그 뒤에 section2가 시작됩니다   

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

## **섹션 이름 변경**

PowerPoint 프레젠테이션에서 섹션을 만든 후, 해당 섹션의 이름을 변경하고 싶을 수 있습니다.

다음 샘플 코드는 Aspose.Slides를 사용하여 Java에서 프레젠테이션의 섹션 이름을 변경하는 방법을 보여줍니다:

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

**PPT (PowerPoint 97–2003) 형식으로 저장할 때 섹션이 보존되나요?**

아니오. PPT 형식은 섹션 메타데이터를 지원하지 않으므로 .ppt로 저장하면 섹션 그룹화가 사라집니다.

**전체 섹션을 "숨김" 처리할 수 있나요?**

아니오. 개별 슬라이드만 숨길 수 있습니다. 섹션 자체는 "숨김" 상태가 없습니다.

**슬라이드로 섹션을 빠르게 찾을 수 있나요? 또한 섹션의 첫 슬라이드를 찾을 수 있나요?**

예. 섹션은 시작 슬라이드로 고유하게 정의됩니다. 슬라이드가 주어지면 해당 슬라이드가 속한 섹션을 확인할 수 있으며, 섹션에 대해서는 첫 번째 슬라이드에 접근할 수 있습니다.