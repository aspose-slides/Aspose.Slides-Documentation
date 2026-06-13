---
title: Python을 사용하여 프레젠테이션에서 SmartArt 그래픽 관리
linktitle: SmartArt 그래픽
type: docs
weight: 20
url: /ko/python-net/manage-smartart-shape/
keywords:
- SmartArt 객체
- SmartArt 그래픽
- SmartArt 스타일
- SmartArt 색상
- SmartArt 만들기
- SmartArt 추가
- SmartArt 편집
- SmartArt 변경
- SmartArt 접근
- SmartArt 레이아웃 유형
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 이용한 .NET 기반 Python에서 PowerPoint SmartArt의 생성, 편집 및 스타일링을 자동화하며, 간결한 코드 예제와 성능 중심 가이드를 제공합니다."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 SmartArt 그래픽을 프로그래밍 방식으로 생성하고 관리할 수 있습니다. 이 문서에서는 슬라이드에 SmartArt 도형을 추가하고, 기존 SmartArt 도형에 접근하며, 특정 레이아웃 유형으로 SmartArt를 찾고, SmartArt 스타일 또는 색상 스타일을 변경하여 시각적 모습을 업데이트하는 방법을 설명합니다.

예제에서는 프레젠테이션 슬라이드의 도형 컬렉션을 통해 SmartArt 도형을 작업하는 방법, 도형이 SmartArt인지 확인한 후 속성을 수정하거나 검사하는 방법을 보여줍니다.

## **SmartArt 도형 만들기**

Aspose.Slides for Python via .NET를 사용하면 처음부터 슬라이드에 사용자 정의 SmartArt 도형을 추가할 수 있습니다. API가 이를 간편하게 해 줍니다. 슬라이드에 SmartArt 도형을 추가하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 대상 슬라이드를 가져옵니다.
1. 레이아웃 유형을 지정하여 SmartArt 도형을 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 프레젠테이션 슬라이드에 접근합니다.
    slide = presentation.slides[0]
    # SmartArt 도형을 추가합니다.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **슬라이드에서 SmartArt 도형에 접근하기**

다음 코드는 슬라이드에서 SmartArt 도형에 접근하는 방법을 보여 줍니다. 샘플은 슬라이드의 각 도형을 순회하면서 해당 도형이 [SmartArt](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartart/) 객체인지 확인합니다.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# 프레젠테이션 파일을 로드합니다.
with slides.Presentation("SmartArt.pptx") as presentation:
    # 첫 번째 슬라이드의 모든 도형을 순회합니다.
    for shape in presentation.slides[0].shapes:
        # 도형이 SmartArt 도형인지 확인합니다.
        if isinstance(shape, smartart.SmartArt):
            # 도형 이름을 출력합니다.
            print("Shape name:", shape.name)
```

## **지정된 레이아웃 유형을 가진 SmartArt 도형에 접근하기**

다음 예제는 지정된 레이아웃 유형을 가진 SmartArt 도형에 접근하는 방법을 보여 줍니다. SmartArt의 레이아웃 유형은 읽기 전용이며 도형을 생성할 때 설정되므로 변경할 수 없습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 만들고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
1. 인덱스로 첫 번째 슬라이드에 대한 참조를 가져옵니다.
1. 첫 번째 슬라이드의 모든 도형을 순회합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartart/) 객체인지 확인합니다.
1. SmartArt 도형의 레이아웃 유형이 필요한 것과 일치하면 필요한 작업을 수행합니다.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # 첫 번째 슬라이드의 모든 도형을 순회합니다.
    for shape in presentation.slides[0].shapes:
        # 도형이 SmartArt 도형인지 확인합니다.
        if isinstance(shape, smartart.SmartArt):
            # SmartArt 레이아웃 유형을 확인합니다.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **SmartArt 도형 스타일 변경**

다음 예제는 SmartArt 도형을 찾아 스타일을 변경하는 방법을 보여 줍니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/)을 만들고 SmartArt 도형이 포함된 파일을 로드합니다.
1. 인덱스로 첫 번째 슬라이드에 대한 참조를 가져옵니다.
1. 첫 번째 슬라이드의 각 도형을 순회합니다.
1. 지정된 스타일을 가진 SmartArt 도형을 찾습니다.
1. 새로운 스타일을 SmartArt 도형에 할당합니다.
1. 프레젠테이션을 저장합니다.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # 첫 번째 슬라이드의 모든 도형을 순회합니다.
    for shape in presentation.slides[0].shapes:
        # 도형이 SmartArt 도형인지 확인합니다.
        if isinstance(shape, smartart.SmartArt):
            # SmartArt 스타일을 확인합니다.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # SmartArt 스타일을 변경합니다.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # 프레젠테이션을 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt 도형 색상 스타일 변경**

이 예제는 SmartArt 도형의 색상 스타일을 변경하는 방법을 보여 줍니다. 샘플 코드는 지정된 색상 스타일을 가진 SmartArt 도형을 찾아 업데이트합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
1. 인덱스로 첫 번째 슬라이드에 대한 참조를 가져옵니다.
1. 첫 번째 슬라이드의 각 도형을 순회합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartart/) 객체인지 확인합니다.
1. 지정된 색상 스타일을 가진 SmartArt 도형을 찾습니다.
1. 해당 SmartArt 도형에 새로운 색상 스타일을 설정합니다.
1. 프레젠테이션을 저장합니다.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # 첫 번째 슬라이드의 모든 도형을 순회합니다.
    for shape in presentation.slides[0].shapes:
        # 도형이 SmartArt 도형인지 확인합니다.
        if isinstance(shape, smartart.SmartArt):
            # 색상 유형을 확인합니다.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # 색상 유형을 변경합니다.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # 프레젠테이션을 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**SmartArt를 단일 객체로 애니메이션할 수 있나요?**

예. SmartArt는 도형이므로 다른 도형과 마찬가지로 애니메이션 API(입장, 퇴장, 강조, 이동 경로)를 통해 [표준 애니메이션](/slides/ko/python-net/powerpoint-animation/)을 적용할 수 있습니다.

**내부 ID를 모를 경우 슬라이드에서 특정 SmartArt를 어떻게 찾나요?**

대체 텍스트(AltText)를 설정하고 해당 값을 기준으로 도형을 검색하면 됩니다. 이는 목표 도형을 찾는 권장 방법입니다.

**SmartArt를 다른 도형과 그룹화할 수 있나요?**

예. SmartArt를 사진, 표 등 다른 도형과 그룹화한 뒤 [그룹을 조작](/slides/ko/python-net/group/)할 수 있습니다.

**특정 SmartArt의 이미지를 얻으려면 어떻게 해야 하나요(예: 미리보기 또는 보고서용)?**

도형의 썸네일/이미지를 내보낼 수 있습니다. 라이브러리는 개별 도형을 래스터 파일(PNG/JPG/TIFF)로 [렌더링](/slides/ko/python-net/create-shape-thumbnails/)할 수 있습니다.

**전체 프레젠테이션을 PDF로 변환할 때 SmartArt의 모양이 보존되나요?**

예. 렌더링 엔진은 [PDF 내보내기](/slides/ko/python-net/convert-powerpoint-to-pdf/) 시 높은 충실도를 목표로 하며, 다양한 품질 및 호환성 옵션을 제공합니다.