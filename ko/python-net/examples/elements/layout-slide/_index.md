---
title: 레이아웃 슬라이드
type: docs
weight: 20
url: /ko/python-net/examples/elements/layout-slide/
keywords:
- 레이아웃 슬라이드
- 레이아웃 슬라이드 추가
- 레이아웃 슬라이드 접근
- 레이아웃 슬라이드 제거
- 사용되지 않은 레이아웃 슬라이드
- 레이아웃 슬라이드 복제
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python을 사용하여 Aspose.Slides로 레이아웃 슬라이드를 관리합니다: PPT, PPTX 및 ODP 프레젠테이션에서 자리표시자와 테마를 만들고, 적용하고, 복제하고, 이름을 바꾸며, 사용자 지정합니다."
---
이 문서는 Aspose.Slides for Python via .NET에서 **레이아웃 슬라이드**를 사용하는 방법을 보여줍니다. 레이아웃 슬라이드는 일반 슬라이드가 상속받는 디자인과 서식을 정의합니다. 레이아웃 슬라이드를 추가, 접근, 복제 및 제거할 수 있으며, 사용되지 않는 슬라이드를 정리하여 프레젠테이션 크기를 줄일 수 있습니다.

## **레이아웃 슬라이드 추가**

재사용 가능한 서식을 정의하기 위해 사용자 정의 레이아웃 슬라이드를 만들 수 있습니다.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # 지정된 유형과 이름으로 레이아웃 슬라이드를 생성합니다.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** 레이아웃 슬라이드는 개별 슬라이드의 템플릿 역할을 합니다. 공통 요소를 한 번 정의하고 여러 슬라이드에서 재사용할 수 있습니다.

> 💡 **Tip 2:** 레이아웃 슬라이드에 도형이나 텍스트를 추가하면 해당 레이아웃을 기반으로 하는 모든 슬라이드가 이 공유된 내용을 자동으로 표시합니다.
> 아래 스크린샷은 동일한 레이아웃 슬라이드에서 텍스트 상자를 상속받은 두 개의 슬라이드를 보여줍니다.

![Slides Inheriting Layout Content](layout-slide-result.png)


## **레이아웃 슬라이드 접근**

레이아웃 슬라이드는 인덱스나 레이아웃 유형(예: `Blank`, `Title`, `SectionHeader` 등)으로 접근할 수 있습니다.

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # 인덱스로 접근합니다.
        first_layout_slide = presentation.layout_slides[0]

        # 레이아웃 유형으로 접근합니다.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **레이아웃 슬라이드 제거**

더 이상 필요하지 않은 경우 특정 레이아웃 슬라이드를 제거할 수 있습니다.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # 유형으로 레이아웃 슬라이드를 가져와 제거합니다.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **사용되지 않은 레이아웃 슬라이드 제거**

프레젠테이션 크기를 줄이기 위해 일반 슬라이드에서 사용되지 않는 레이아웃 슬라이드를 제거할 수 있습니다.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # 자동으로 어떤 슬라이드에도 참조되지 않은 모든 레이아웃 슬라이드를 제거합니다.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **레이아웃 슬라이드 복제**

`AddClone` 메서드를 사용하여 레이아웃 슬라이드를 복제할 수 있습니다.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # 유형으로 기존 레이아웃 슬라이드를 가져옵니다.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # 레이아웃 슬라이드를 컬렉션 끝으로 복제합니다.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **요약:** 레이아웃 슬라이드는 슬라이드 전반에 일관된 서식을 관리하기 위한 강력한 도구입니다. Aspose.Slides는 레이아웃 슬라이드의 생성, 관리 및 최적화에 대한 완전한 제어를 제공합니다.