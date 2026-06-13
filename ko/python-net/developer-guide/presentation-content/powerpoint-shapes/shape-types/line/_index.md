---
title: Python을 사용한 프레젠테이션에서 선 도형 만들기
linktitle: 선
type: docs
weight: 50
url: /ko/python-net/line/
keywords:
- 선
- 선 만들기
- 선 추가
- 일반 선
- 선 구성
- 선 맞춤 설정
- 대시 스타일
- 화살표 머리
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 선 형식을 조작하는 방법을 배웁니다. 속성, 메서드 및 예제를 확인하세요."
---
## **개요**

Aspose.Slides for Python via .NET는 슬라이드에 다양한 종류의 도형을 추가하는 것을 지원합니다. 이 주제에서는 선을 슬라이드에 추가하여 도형 작업을 시작합니다. Aspose.Slides를 사용하면 개발자는 단순 선을 만들 수 있을 뿐만 아니라 멋진 선도 슬라이드에 그릴 수 있습니다.

## **단순 선 만들기**

Aspose.Slides를 사용하여 슬라이드에 단순 선을 구분선이나 연결선으로 추가할 수 있습니다. 프레젠테이션에서 선택한 슬라이드에 단순 선을 추가하려면 다음 단계를 따르세요:

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. ShapeCollection 객체에서 `add_auto_shape` 메서드를 사용하여 `LINE` 유형의 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)을 추가합니다.
4. 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 슬라이드에 선을 추가합니다.

```py
import aspose.slides as slides

# Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:

    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    # LINE 유형의 자동 도형을 추가합니다.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **화살표 모양 선 만들기**

Aspose.Slides를 사용하면 선 속성을 구성하여 보다 시각적으로 매력적으로 만들 수 있습니다. 아래에서는 선을 화살표처럼 보이게 하기 위해 몇 가지 속성을 구성합니다. 다음 단계를 따르세요:

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. ShapeCollection 객체에서 `add_auto_shape` 메서드를 사용하여 `LINE` 유형의 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)을 추가합니다.
4. 선 스타일을 설정합니다.
5. 선 너비를 설정합니다.
6. 선의 [dash style](https://reference.aspose.com/slides/ko/python-net/aspose.slides/linedashstyle/)을 설정합니다.
7. 선 시작점에 대한 [arrowhead style](https://reference.aspose.com/slides/ko/python-net/aspose.slides/linearrowheadstyle/)과 길이를 설정합니다.
8. 선 끝점에 대한 화살표 머리 스타일과 길이를 설정합니다.
9. 프레젠테이션을 PPTX 파일로 저장합니다.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    # LINE 유형의 자동 도형을 추가합니다.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # 선에 서식을 적용합니다.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **자주 묻는 질문**

**일반 선을 커넥터로 변환하여 도형에 "스냅"되도록 할 수 있나요?**

아니요. 일반 선([AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)의 [LINE](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapetype/))은 자동으로 커넥터가 되지 않습니다. 도형에 스냅되도록 하려면 전용 [Connector](https://reference.aspose.com/slides/ko/python-net/aspose.slides/connector/) 타입과 연결을 위한 [corresponding APIs](/slides/ko/python-net/connector/)를 사용하세요.

**테마에서 상속된 선 속성으로 최종 값을 확인하기 어려운 경우 어떻게 해야 하나요?**

[유효한 속성 읽기](/slides/ko/python-net/shape-effective-properties/)를 [ILineFormatEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ilinefillformateffectivedata/) 클래스를 통해 확인하세요—이들은 이미 상속 및 테마 스타일을 고려합니다.

**선이 편집(이동, 크기 조정)되지 않도록 잠글 수 있나요?**

네. 도형에는 [lock objects](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/auto_shape_lock/)가 제공되어 [편집 작업을 허용하지 않도록](/slides/ko/python-net/applying-protection-to-presentation/) 할 수 있습니다.