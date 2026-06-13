---
title: Python에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드를 SVG로
type: docs
weight: 50
url: /ko/python-net/render-a-slide-as-an-svg-image/
keywords:
- 슬라이드를 SVG로
- 프레젠테이션을 SVG로
- PowerPoint를 SVG로
- OpenDocument를 SVG로
- PPT를 SVG로
- PPTX를 SVG로
- ODP를 SVG로
- 슬라이드 렌더링
- 슬라이드 변환
- 슬라이드 내보내기
- 벡터 이미지
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 슬라이드를 SVG 이미지로 렌더링하는 방법을 배웁니다. 간단한 코드 예제로 고품질 시각 자료를 제공합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션 슬라이드를 SVG 이미지로 렌더링하는 방법을 설명합니다. SVG 형식과 그 장점, 즉 확장성, 접근성 및 웹 개발에 적합함 등에 대해 소개합니다.

프레젠테이션 파일을 로드하고, 슬라이드를 순회하며, 각 슬라이드를 별개의 SVG 파일로 저장하는 방법을 배웁니다. 이 문서는 PPT, PPTX, ODP, PPS와 같은 PowerPoint 및 OpenDocument 프레젠테이션 형식을 다루며, `Presentation` 클래스와 `write_as_svg` 메서드를 사용하여 프로그래밍 방식으로 변환하는 방법을 보여줍니다.

## **SVG 형식**

SVG(Scalable Vector Graphics의 약자)는 2차원 이미지를 렌더링하기 위해 사용되는 표준 그래픽 유형 또는 형식입니다. SVG는 이미지의 동작이나 외관을 정의하는 세부 정보를 포함한 벡터를 XML 형태로 저장합니다.

SVG는 확장성, 상호작용성, 성능, 접근성, 프로그래밍 가능성 등 높은 기준을 충족하는 몇 안 되는 이미지 형식 중 하나입니다. 이러한 이유로 웹 개발에서 널리 사용됩니다.

다음과 같은 경우 SVG 파일을 사용할 수 있습니다.

- **프레젠테이션을 *아주 큰 형식*으로 인쇄**하려는 경우. SVG 이미지는 어떤 해상도나 규모로도 확대할 수 있습니다. 품질 저하 없이 필요에 따라 SVG 이미지를 여러 번 크기 조정할 수 있습니다.
- **슬라이드의 차트와 그래프를 *다양한 매체 또는 플랫폼*에서 사용**합니다. 대부분의 뷰어가 SVG 파일을 해석할 수 있습니다.
- **가능한 *가장 작은 이미지 크기*로 사용**합니다. SVG 파일은 일반적으로 다른 형식의 고해상도 파일보다 작으며, 특히 비트맵 기반(JPEG 또는 PNG) 형식보다 작습니다.

## **슬라이드를 SVG 이미지로 렌더링**

Aspose.Slides for Python via .NET를 사용하면 프레젠테이션의 슬라이드를 SVG 이미지로 내보낼 수 있습니다. 다음 단계에 따라 SVG 이미지를 생성하십시오:

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 프레젠테이션의 모든 슬라이드를 순회합니다.
3. 각 슬라이드를 FileStream을 통해 별도의 SVG 파일로 저장합니다.

{{% alert color="primary" %}} 
Aspose.Slides for Python via .NET의 PPT를 SVG로 변환 기능을 구현한 우리의 [무료 웹 애플리케이션](https://products.aspose.app/slides/ko/conversion/ppt-to-svg)을 사용해 볼 수 있습니다.
{{% /alert %}} 

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다 
pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]

    with open("slide-{index}.svg".format(index = index), "wb") as file:
        slide.write_as_svg(file)
```

## **FAQ**

**왜 브라우저마다 결과 SVG가 다르게 보일 수 있나요?**

특정 SVG 기능에 대한 지원은 브라우저 엔진마다 다르게 구현됩니다. [SVGOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgoptions/) 매개변수는 이러한 호환성 문제를 완화하는 데 도움이 됩니다.

**슬라이드뿐만 아니라 개별 도형도 SVG로 내보낼 수 있나요?**

예. 모든 [도형을 별도의 SVG로 저장](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/write_as_svg/)할 수 있어 아이콘, 피ictogram, 그래픽 재사용에 편리합니다.

**여러 슬라이드를 하나의 SVG(스트립/문서)로 결합할 수 있나요?**

표준 시나리오는 슬라이드 하나당 SVG 하나입니다. 여러 슬라이드를 하나의 SVG 캔버스로 결합하는 것은 응용 프로그램 수준에서 수행되는 후처리 단계입니다.