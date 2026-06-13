---
title: Python에서 프레젠테이션에 사각형 추가
linktitle: 사각형
type: docs
weight: 80
url: /ko/python-net/rectangle/
keywords:
- 사각형 추가
- 사각형 만들기
- 사각형 모양
- 간단한 사각형
- 서식이 지정된 사각형
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 사각형을 추가함으로써 PowerPoint 및 OpenDocument 프레젠테이션을 강화하고, 프로그래밍 방식으로 도형을 손쉽게 디자인하고 수정할 수 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 슬라이드에 사각형 모양을 추가하는 방법을 보여줍니다. 간단한 사각형 만들기, 서식이 지정된 사각형 만들기, 그리고 업데이트된 프레젠테이션을 PPTX 파일로 저장하는 내용을 다룹니다.

또한 단색 채우기 색상, 선 색상 및 선 두께와 같은 기본 사각형 서식을 적용하는 방법을 확인할 수 있습니다. 추가로, FAQ에서는 모서리 둥글게 만들기, 이미지 채우기, 시각 효과, 하이퍼링크, 도형 잠금, 내보내기 옵션 및 효과적인 속성과 같은 관련 사각형 작업을 안내합니다.

## **단순 사각형 만들기**
이전 주제와 마찬가지로 이번에도 도형 추가에 대해 다루며, 이번에 다룰 도형은 Rectangle입니다. 이 주제에서는 개발자가 Aspose.Slides for Python via .NET을 사용하여 슬라이드에 단순하거나 서식이 지정된 사각형을 추가하는 방법을 설명합니다. 프레젠테이션의 선택된 슬라이드에 단순 사각형을 추가하려면 아래 단계를 따르세요.

1. [Presentation ](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
3. IShapes 개체가 제공하는 AddAutoShape 메서드를 사용하여 Rectangle 유형의 IAutoShape을 추가합니다.
4. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 단순 사각형을 추가했습니다.

```py
import aspose.slides as slides

# PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
with slides.Presentation() as pres:
    # 첫 번째 슬라이드를 가져옵니다
    sld = pres.slides[0]

    # 사각형 유형의 자동 도형을 추가합니다
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Write PPTX 파일을 디스크에 저장합니다
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **서식이 지정된 사각형 만들기**
슬라이드에 서식이 지정된 사각형을 추가하려면 아래 단계를 따르세요.

1. [Presentation ](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
3. IShapes 개체가 제공하는 AddAutoShape 메서드를 사용하여 Rectangle 유형의 IAutoShape을 추가합니다.
4. 사각형의 채우기 유형을 Solid(단색)으로 설정합니다.
5. FillFormat 개체가 제공하는 SolidFillColor.Color 속성을 사용하여 사각형의 색상을 설정합니다.
6. 사각형 선의 색상을 설정합니다.
7. 사각형 선의 두께를 설정합니다.
8. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.
   위 단계는 아래 예제에 구현되어 있습니다.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
with slides.Presentation() as pres:
    # 첫 번째 슬라이드를 가져옵니다
    sld = pres.slides[0]

    # 사각형 유형의 자동 도형을 추가합니다
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # 사각형 도형에 일부 서식을 적용합니다
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # 사각형 선에 일부 서식을 적용합니다
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Write PPTX 파일을 디스크에 저장합니다
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**둥근 모서리 사각형을 어떻게 추가하나요?**

둥근 모서리 [도형 유형](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapetype/)을 사용하고 도형 속성에서 모서리 반경을 조정합니다. 기하학적 조정을 통해 각 모서리별로 둥글게 만들 수도 있습니다.

**이미지(텍스처)로 사각형을 채우려면 어떻게 하나요?**

[picture fill type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/filltype/)을 선택하고 이미지 소스를 제공한 뒤 [stretching/tiling modes](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillmode/)을 구성합니다.

**사각형에 그림자와 글로우를 적용할 수 있나요?**

예. [외부/내부 그림자, 글로우 및 부드러운 가장자리](/slides/ko/python-net/shape-effect/)를 사용할 수 있으며 매개변수를 조정할 수 있습니다.

**사각형을 하이퍼링크가 있는 버튼으로 만들 수 있나요?**

예. [하이퍼링크 할당](/slides/ko/python-net/manage-hyperlinks/)을 통해 도형을 클릭했을 때 슬라이드, 파일, 웹 주소 또는 이메일로 이동하도록 할 수 있습니다.

**사각형이 이동하거나 변경되는 것을 어떻게 방지하나요?**

[도형 잠금](/slides/ko/python-net/applying-protection-to-presentation/)을 사용하면 이동, 크기 조정, 선택 또는 텍스트 편집을 금지하여 레이아웃을 보호할 수 있습니다.

**사각형을 래스터 이미지나 SVG로 변환할 수 있나요?**

예. [도형을 이미지로 렌더링](http://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/get_image/)하여 지정된 크기/비율로 저장하거나 [SVG로 내보내기](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/write_as_svg/)를 통해 벡터 형식으로 사용할 수 있습니다.

**테마와 상속을 고려한 실제(효과적인) 사각형 속성을 어떻게 빠르게 얻나요?**

[도형의 효과적인 속성](/slides/ko/python-net/shape-effective-properties/)을 사용합니다. API가 테마 스타일, 레이아웃 및 로컬 설정을 반영한 계산값을 반환하므로 서식 분석이 간편해집니다.