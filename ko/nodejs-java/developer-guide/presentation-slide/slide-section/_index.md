---
title: JavaScript를 사용하여 프레젠테이션에서 슬라이드 섹션 관리
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
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js 로 PowerPoint 및 OpenDocument 의 슬라이드 섹션을 간소화합니다 — 분할, 이름 변경 및 순서 재배치를 통해 PPTX 및 ODP 작업 흐름을 최적화합니다."
---
## **소개**

Aspose.Slides for Node.js via Java를 사용하면 PowerPoint 프레젠테이션을 섹션으로 구성할 수 있습니다. 특정 슬라이드를 포함하는 섹션을 만들 수 있습니다.

다음과 같은 상황에서 섹션을 만들고 이를 사용하여 프레젠테이션의 슬라이드를 논리적 부분으로 조직하거나 구분하고 싶을 수 있습니다:

- 다른 사람이나 팀과 함께 큰 프레젠테이션을 작업하고 있으며, 특정 슬라이드를 동료나 팀 구성원에게 할당해야 할 때.
- 많은 슬라이드가 포함된 프레젠테이션을 다루고 있으며, 한 번에 내용을 관리하거나 편집하는 데 어려움을 겪을 때.

이상적으로는 비슷한 슬라이드들을 포함하는 섹션을 만들고-슬라이드들이 공통점을 가지고 있거나 규칙에 따라 그룹으로 묶일 수 있는 경우-그 섹션에 포함된 슬라이드를 설명하는 이름을 부여해야 합니다.

## **프레젠테이션에서 섹션 만들기**

프레젠테이션에서 슬라이드를 포함할 섹션을 추가하려면 Aspose.Slides for Node.js via Java가 제공하는 [addSection()](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) 메서드를 사용하면 만들려는 섹션의 이름과 섹션이 시작되는 슬라이드를 지정할 수 있습니다.

다음 샘플 코드는 JavaScript에서 프레젠테이션에 섹션을 만드는 방법을 보여 줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1은 newSlide2에서 종료되고 그 이후에 section2가 시작됩니다
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **섹션 이름 변경**

PowerPoint 프레젠테이션에서 섹션을 만든 후, 해당 섹션의 이름을 변경하고 싶을 수 있습니다.

다음 샘플 코드는 Aspose.Slides를 사용하여 JavaScript에서 프레젠테이션의 섹션 이름을 변경하는 방법을 보여 줍니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**PPT (PowerPoint 97–2003) 형식으로 저장할 때 섹션이 유지됩니까?**

아니오. PPT 형식은 섹션 메타데이터를 지원하지 않으므로 .ppt로 저장할 때 섹션 구성은 사라집니다.

**전체 섹션을 "숨김" 처리할 수 있습니까?**

아니오. 개별 슬라이드만 숨길 수 있습니다. 섹션 자체는 "숨김" 상태가 없습니다.

**슬라이드로 섹션을 빠르게 찾을 수 있나요? 그리고 반대로 섹션의 첫 번째 슬라이드를 찾을 수 있나요?**

예. 섹션은 시작 슬라이드로 고유하게 정의됩니다. 슬라이드가 주어지면 해당 슬라이드가 속한 섹션을 확인할 수 있으며, 섹션에 대해서는 첫 번째 슬라이드에 접근할 수 있습니다.