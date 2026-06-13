---
title: 섹션
type: docs
weight: 90
url: /ko/python-net/examples/elements/section/
keywords:
- 섹션
- 슬라이드 섹션
- 섹션 추가
- 섹션 액세스
- 섹션 제거
- 섹션 이름 바꾸기
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 슬라이드 섹션을 관리합니다: 섹션을 생성하고, 이름을 바꾸며, 쉽게 순서를 재배열하고, 섹션 간에 슬라이드를 이동하고, PPT, PPTX 및 ODP에 대한 가시성을 제어합니다."
---
프레젠테이션 섹션을 관리하는 예시—프로그래밍 방식으로 **Aspose.Slides for Python via .NET**를 사용하여 섹션을 추가, 액세스, 제거 및 이름 바꾸기.

## **섹션 추가**

특정 슬라이드에서 시작하는 섹션을 생성합니다.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 새 섹션을 추가하고 해당 섹션의 시작을 표시하는 슬라이드를 지정합니다.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **섹션 액세스**

프레젠테이션에서 섹션을 가져옵니다.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # 인덱스로 섹션에 접근합니다.
        section = presentation.sections[0]
```

## **섹션 제거**

이전에 추가된 섹션을 삭제합니다.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # 섹션을 제거합니다.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **섹션 이름 바꾸기**

기존 섹션의 이름을 변경합니다.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # 섹션의 이름을 바꿉니다.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```