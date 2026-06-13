---
title: 마스터 슬라이드
type: docs
weight: 30
url: /ko/python-net/examples/elements/master-slide/
keywords:
- 마스터 슬라이드
- 마스터 슬라이드 추가
- 마스터 슬라이드 액세스
- 마스터 슬라이드 제거
- 사용되지 않는 마스터 슬라이드
- 코드 예시
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python에서 Aspose.Slides를 사용하여 마스터 슬라이드를 관리합니다: 슬라이드를 통합하기 위해 테마, 배경, 플레이스홀더를 생성, 편집, 복제 및 서식 지정합니다 (PowerPoint 및 OpenDocument)."
---
마스터 슬라이드는 PowerPoint에서 슬라이드 상속 계층 구조의 최상위 레벨을 형성합니다. **마스터 슬라이드**는 배경, 로고 및 텍스트 서식과 같은 공통 디자인 요소를 정의합니다. **레이아웃 슬라이드**는 마스터 슬라이드에서 상속되며, **보통 슬라이드**는 레이아웃 슬라이드에서 상속됩니다.

이 문서는 Aspose.Slides for Python via .NET을 사용하여 마스터 슬라이드를 생성, 수정 및 관리하는 방법을 보여줍니다.

## **마스터 슬라이드 추가**

이 예제는 기본 마스터 슬라이드를 복제하여 새로운 마스터 슬라이드를 만드는 방법을 보여줍니다.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # 기본 마스터 슬라이드를 복제합니다.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** 마스터 슬라이드는 모든 슬라이드에 일관된 브랜딩이나 공유 디자인 요소를 적용할 수 있는 방법을 제공합니다. 마스터에 대한 모든 변경은 자동으로 종속 레이아웃 및 보통 슬라이드에 반영됩니다.
> 
> 💡 **Tip 2:** 마스터 슬라이드에 추가된 모든 도형이나 서식은 레이아웃 슬라이드에 상속되며, 차례로 해당 레이아웃을 사용하는 모든 보통 슬라이드에도 적용됩니다.  
> 아래 이미지는 마스터 슬라이드에 추가된 텍스트 상자가 최종 슬라이드에 자동으로 표시되는 방식을 보여줍니다.

![마스터 상속 예시](master-slide-banner.png)

## **마스터 슬라이드 액세스**

`Presentation.masters` 컬렉션을 사용하여 마스터 슬라이드에 액세스할 수 있습니다. 다음은 해당 슬라이드를 가져오고 작업하는 방법입니다:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # 첫 번째 마스터 슬라이드에 접근합니다.
        first_master_slide = presentation.masters[0]
```

## **마스터 슬라이드 제거**

마스터 슬라이드는 인덱스나 참조를 사용하여 제거할 수 있습니다.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # 인덱스로 제거합니다.
        presentation.masters.remove_at(0)

        # 또는 참조로 제거합니다.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **사용되지 않는 마스터 슬라이드 제거**

일부 프레젠테이션에는 사용되지 않는 마스터 슬라이드가 포함될 수 있습니다. 이러한 슬라이드를 제거하면 파일 크기를 줄이는 데 도움이 됩니다.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # 사용되지 않는 모든 마스터 슬라이드 제거 (보존으로 표시된 슬라이드도 포함).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Tip:** 사용되지 않는 마스터 슬라이드를 정리하고 프레젠테이션 크기를 최소화하려면 `remove_unused(True)`를 사용하십시오.