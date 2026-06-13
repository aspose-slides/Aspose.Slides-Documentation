---
title: Python을 사용하여 프레젠테이션에서 잉크 개체 관리
linktitle: 잉크 관리
type: docs
weight: 95
url: /ko/python-net/manage-ink/
keywords:
- 잉크
- 잉크 개체
- 잉크 트레이스
- 잉크 관리
- 잉크 그리기
- 그리기
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "PowerPoint 잉크 개체를 관리합니다—Aspose.Slides for Python via .NET을 사용해 디지털 잉크를 생성, 편집 및 스타일링합니다. 트레이스, 브러시 색상 및 크기 샘플 코드를 제공합니다."
---
## **Introduction**

PowerPoint는 비표준 도형을 그릴 수 있는 잉크 기능을 제공하며, 이를 통해 다른 개체를 강조하거나 연결 및 프로세스를 표시하고 슬라이드의 특정 항목에 주의를 끌 수 있습니다.

Aspose.Slides는 잉크 개체를 만들고 관리하는 데 필요한 유형을 포함하고 있는 [aspose.slides.ink](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ink/) 네임스페이스를 제공합니다.

## **Differences between Regular Object and Ink Objects**

PowerPoint 슬라이드의 개체는 일반적으로 shape 개체로 표시됩니다. shape 개체는 가장 단순한 형태로, 개체 자체(프레임)의 영역과 해당 개체의 속성을 정의하는 컨테이너입니다. 여기에는 컨테이너 영역 크기, 컨테이너 모양, 컨테이너 배경 등이 포함됩니다. 자세한 내용은 [Shape Layout Format](https://docs.aspose.com/slides/ko/python-net/shape-manipulations/#access-layout-formats-for-shape)을 참조하세요.

그러나 PowerPoint가 잉크 개체를 처리할 때는 컨테이너(프레임)의 모든 속성을 무시하고 크기만을 사용합니다. 컨테이너 영역의 크기는 표준 `width`와 `height` 값에 의해 결정됩니다:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape Traces**

Trace는 사용자가 디지털 잉크를 쓸 때 펜의 궤적을 기록하기 위해 사용되는 기본 요소 또는 표준입니다. Trace는 연결된 포인트들의 시퀀스를 설명하는 기록입니다.

가장 단순한 인코딩 형태는 각 샘플 포인트의 X 및 Y 좌표를 지정합니다. 모든 연결된 포인트가 렌더링되면 다음과 같은 이미지가 생성됩니다:

![ink_powerpoint2](ink_powerpoint2.png)

## Brush Properties For Drawing 

브러시를 사용하여 Trace 요소의 포인트를 연결하는 선을 그릴 수 있습니다. 브러시에는 `Brush.color`와 `Brush.size` 속성에 해당하는 자체 색상 및 크기가 있습니다.

### **Set Ink Brush Color**

다음 Python 코드는 브러시 색상을 설정하는 방법을 보여줍니다:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **Set Ink Brush Size** 

다음 Python 코드는 브러시 크기를 설정하는 방법을 보여줍니다:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

일반적으로 브러시의 너비와 높이는 일치하지 않으며, 이 경우 PowerPoint는 브러시 크기를 표시하지 않습니다(데이터 섹션이 회색으로 표시됨). 하지만 브러시의 너비와 높이가 일치하면 PowerPoint는 다음과 같이 크기를 표시합니다:

![ink_powerpoint3](ink_powerpoint3.png)

명확히 하기 위해 잉크 개체의 높이를 늘리고 중요한 차원을 검토해 보겠습니다:

![ink_powerpoint4](ink_powerpoint4.png)

컨테이너(프레임)는 브러시의 크기를 고려하지 않으며, 항상 선의 두께가 0이라고 가정합니다(마지막 이미지 참조).

따라서 전체 잉크 개체의 표시 영역을 결정하려면 Trace 개체의 브러시 크기를 고려해야 합니다. 여기서 대상 개체(손글씨 Trace 개체)는 컨테이너(프레임) 크기에 맞게 스케일되었습니다. 컨테이너(프레임)의 크기가 변경되면 브러시 크기는 그대로 유지되고 그 반대도 마찬가지입니다.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint는 텍스트를 처리할 때도 동일한 동작을 보입니다:

![ink_powerpoint6](ink_powerpoint6.png)

**Further reading**

* 일반적인 shape에 대해 읽고 싶다면 [PowerPoint Shapes](https://docs.aspose.com/slides/ko/python-net/powerpoint-shapes/) 섹션을 참조하세요. 
* 효과적인 값에 대한 자세한 내용은 [Shape Effective Properties](https://docs.aspose.com/slides/ko/python-net/shape-effective-properties/#get-effective-font-height-value)를 확인하세요.