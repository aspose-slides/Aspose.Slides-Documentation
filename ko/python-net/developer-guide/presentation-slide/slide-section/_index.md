---
title: Python을 사용한 프레젠테이션 슬라이드 섹션 관리
linktitle: 슬라이드 섹션
type: docs
weight: 100
url: /ko/python-net/slide-section/
keywords:
- 섹션 만들기
- 섹션 추가
- 섹션 편집
- 섹션 변경
- 섹션 이름
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 사용하여 PowerPoint 및 OpenDocument의 슬라이드 섹션을 간소화합니다 — 분할, 이름 변경 및 재정렬을 통해 PPTX 및 ODP 작업 흐름을 최적화합니다."
---
## **소개**

Aspose.Slides for Python을 사용하면 특정 슬라이드를 그룹화하는 섹션으로 PowerPoint 프레젠테이션을 구성할 수 있습니다.

다음과 같은 상황에서 프레젠테이션을 논리적 부분으로 구성하거나 분할하기 위해 섹션을 만들고 싶을 수 있습니다:

- 팀과 함께 큰 프레젠테이션을 작업하면서 특정 슬라이드를 특정 동료에게 할당해야 할 때.
- 많은 슬라이드를 포함한 프레젠테이션을 다루면서 한 번에 모든 것을 관리하거나 편집하기 어려울 때.

이상적으로는 관련 슬라이드(주제, 토픽 또는 목적이 동일한 슬라이드)를 그룹화하는 섹션을 만들고, 각 섹션에 내용이 명확히 드러나는 이름을 지정합니다.

## **프레젠테이션에서 섹션 만들기**

프레젠테이션에서 슬라이드를 그룹화하는 [Section](https://reference.aspose.com/slides/ko/python-net/aspose.slides/section/)을 추가하려면 Aspose.Slides가 [add_section](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sectioncollection/add_section/) 메서드를 제공합니다. 이 메서드를 사용하면 섹션 이름과 섹션이 시작되는 슬라이드를 지정할 수 있습니다.

다음 Python 예제는 프레젠테이션에서 섹션을 만드는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # 섹션 1은 slide2에서 끝나고; 섹션 2는 slide3에서 시작합니다.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **섹션 이름 변경**

PowerPoint 프레젠테이션에서 [Section](https://reference.aspose.com/slides/ko/python-net/aspose.slides/section/)을 만든 후, 해당 이름을 변경하고 싶을 수 있습니다.

다음 Python 예제는 프레젠테이션에서 섹션 이름을 바꾸는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **자주 묻는 질문**

**PPT (PowerPoint 97–2003) 형식으로 저장할 때 섹션이 유지되나요?**

아니요. PPT 형식은 섹션 메타데이터를 지원하지 않으므로 .ppt로 저장할 때 섹션 그룹화가 사라집니다.

**전체 섹션을 "숨김" 처리할 수 있나요?**

아니요. 개별 슬라이드만 숨길 수 있습니다. 섹션 자체는 "숨김" 상태를 갖지 않습니다.

**슬라이드로 섹션을 빠르게 찾거나, 반대로 섹션의 첫 슬라이드를 찾을 수 있나요?**

예. 섹션은 시작 슬라이드로 고유하게 정의됩니다. 슬라이드가 주어지면 해당 슬라이드가 속한 섹션을 알 수 있고, 섹션이 주어지면 첫 슬라이드에 접근할 수 있습니다.