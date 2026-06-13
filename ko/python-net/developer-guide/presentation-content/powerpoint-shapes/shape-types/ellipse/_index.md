---
title: Python에서 프레젠테이션에 타원 추가
linktitle: 타원
type: docs
weight: 30
url: /ko/python-net/ellipse/
keywords:
- 타원
- 도형
- 타원 추가
- 타원 만들기
- 타원 그리기
- 서식이 지정된 타원
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET을 사용하여 PPT, PPTX 및 ODP 프레젠테이션에서 타원 도형을 생성, 서식 지정 및 조작하는 방법을 배우세요—코드 예제가 포함됩니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 슬라이드에 타원형 도형을 추가하는 방법을 보여줍니다. 간단한 타원 만들기, 서식이 지정된 타원 만들기, 그리고 업데이트된 프레젠테이션을 PPTX 파일로 저장하는 과정을 다룹니다. 또한 타원의 위치와 크기 작업, 쌓기 순서 제어, 애니메이션 효과 적용과 같은 관련 질문도 다룹니다.

## **타원 만들기**
이 항목에서는 Aspose.Slides for Python via .NET을 사용하여 슬라이드에 타원형 도형을 추가하는 방법을 개발자에게 소개합니다. Aspose.Slides for Python via .NET은 몇 줄의 코드로 다양한 도형을 그릴 수 있는 간편한 API를 제공합니다. 프레젠테이션의 선택된 슬라이드에 간단한 타원을 추가하려면 아래 단계를 따르세요:

1. [Presentation ](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다
2. 인덱스를 사용하여 슬라이드의 참조를 얻습니다
3. IShapes 객체가 제공하는 AddAutoShape 메서드를 사용하여 Ellipse 유형의 AutoShape을 추가합니다
4. 수정된 프레젠테이션을 PPTX 파일로 저장합니다

아래 예제에서는 첫 번째 슬라이드에 타원을 추가했습니다.

```py
import aspose.slides as slides

# PPTX를 나타내는 Presentation 클래스 인스턴스화
with slides.Presentation() as pres:
    # 첫 번째 슬라이드 가져오기
    sld = pres.slides[0]

    # 타원 형태의 AutoShape 추가
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # PPTX 파일을 디스크에 저장
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **서식이 지정된 타원 만들기**
슬라이드에 서식이 지정된 타원을 추가하려면 아래 단계를 따르세요:

1. [Presentation ](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드의 참조를 얻습니다.
3. IShapes 객체가 제공하는 AddAutoShape 메서드를 사용하여 Ellipse 유형의 AutoShape을 추가합니다.
4. 타원의 채우기 유형을 Solid(단색)로 설정합니다.
5. IShape 객체와 연결된 FillFormat 객체가 제공하는 SolidFillColor.Color 속성을 사용하여 타원의 색상을 설정합니다.
6. 타원 선의 색상을 설정합니다.
7. 타원 선의 두께를 설정합니다.
8. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 서식이 지정된 타원을 추가했습니다.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX를 나타내는 Presentation 클래스 인스턴스화
with slides.Presentation() as pres:
    # 첫 번째 슬라이드 가져오기
    sld = pres.slides[0]

    # 타원 유형의 AutoShape 추가
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # 타원 도형에 일부 서식 적용
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # 타원 선에 일부 서식 적용
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #PPTX 파일을 디스크에 저장
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**슬라이드 단위에 대한 타원의 정확한 위치와 크기를 어떻게 설정합니까?**

좌표와 크기는 일반적으로 **포인트** 단위로 지정됩니다. 예측 가능한 결과를 얻으려면 슬라이드 크기를 기준으로 계산하고, 필요한 밀리미터나 인치를 포인트로 변환한 후 값을 할당하십시오.

**다른 객체 위나 아래에 타원을 배치하려면(쌓기 순서 제어) 어떻게 해야 하나요?**

객체를 앞으로 가져오거나 뒤로 보내어 그리기 순서를 조정합니다. 이렇게 하면 타원이 다른 객체와 겹치거나 아래에 있는 객체를 드러낼 수 있습니다.

**타원의 나타남이나 강조에 애니메이션을 적용하려면 어떻게 해야 하나요?**

[Apply](/slides/ko/python-net/shape-animation/)을 사용하여 형태에 입장, 강조 또는 퇴장 효과를 적용하고, 트리거와 타이밍을 구성하여 애니메이션이 언제 어떻게 재생될지 조정합니다.