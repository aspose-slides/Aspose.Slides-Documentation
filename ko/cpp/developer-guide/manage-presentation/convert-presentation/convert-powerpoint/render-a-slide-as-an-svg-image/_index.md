---
title: C++에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드를 SVG로
type: docs
weight: 50
url: /ko/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint를 SVG로
- 프레젠테이션을 SVG로
- 슬라이드를 SVG로
- PPT를 SVG로
- PPTX를 SVG로
- PPT를 SVG로 저장
- PPTX를 SVG로 저장
- PPT를 SVG로 내보내기
- PPTX를 SVG로 내보내기
- 슬라이드 렌더링
- 슬라이드 변환
- 슬라이드 내보내기
- 벡터 이미지
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 슬라이드를 SVG 이미지로 렌더링하는 방법을 배우세요. 간단한 코드 예제로 고품질 비주얼을 구현합니다."
---
## **Overview**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션 슬라이드를 SVG 이미지로 렌더링하는 방법을 설명합니다. SVG 형식과 그 장점(확장성, 접근성, 웹 개발에 적합함)을 소개합니다.

프레젠테이션 파일을 로드하고, 슬라이드를 순회하며, 각 슬라이드를 별도의 SVG 파일로 저장하는 방법을 배웁니다. 이 문서에서는 PPT, PPTX, ODP, PPS와 같은 PowerPoint 및 OpenDocument 프레젠테이션 형식을 다루며, `Presentation` 클래스와 `WriteAsSvg` 메서드를 사용해 프로그래밍 방식으로 변환하는 방법을 보여줍니다.

## **SVG Format**

SVG—Scalable Vector Graphics의 약자—는 2차원 이미지를 렌더링하는 데 사용되는 표준 그래픽 유형 또는 포맷입니다. SVG는 이미지를 XML 기반의 벡터 형태로 저장하며, 동작이나 외형을 정의하는 세부 정보를 포함합니다.

SVG는 확장성, 인터랙티브성, 성능, 접근성, 프로그래밍 가능성 등 높은 기준을 충족하는 몇 안 되는 이미지 포맷 중 하나입니다. 이러한 이유로 웹 개발에서 널리 사용됩니다.

다음과 같은 경우 SVG 파일을 사용하고 싶을 수 있습니다.

- **프레젠테이션을 *아주 큰 형식*으로 인쇄**. SVG 이미지는 어느 해상도나 수준으로도 확대할 수 있습니다. 품질을 손상시키지 않고 필요에 따라 여러 번 크기를 조정할 수 있습니다.
- **슬라이드의 차트와 그래프를 *다양한 매체나 플랫폼*에 사용**. 대부분의 리더가 SVG 파일을 해석할 수 있습니다.
- **가능한 가장 작은 크기의 이미지를 사용**. SVG 파일은 일반적으로 비트맵 기반 포맷(JPEG 또는 PNG) 등과 비교해 고해상도 대안보다 파일 크기가 작습니다.

## **Render a Slide as an SVG Image**

Aspose.Slides for C++를 사용하면 프레젠테이션 슬라이드를 SVG 이미지로 내보낼 수 있습니다. 다음 단계에 따라 SVG 이미지를 생성하십시오:

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 프레젠테이션의 모든 슬라이드를 순회합니다.
3. FileStream을 통해 각 슬라이드를 개별 SVG 파일로 기록합니다.

{{% alert color="primary" %}} 

무료 웹 애플리케이션[무료 웹 애플리케이션](https://products.aspose.app/slides/ko/conversion/ppt-to-svg)에서 Aspose.Slides for C++의 PPT를 SVG로 변환하는 기능을 구현한 것을 체험해 보세요.

{{% /alert %}} 

다음은 C++ 샘플 코드로, Aspose.Slides를 사용해 PPT를 SVG로 변환하는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
        
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto fileName = String::Format(u"slide-{0}.svg", index);
    auto fileStream = System::MakeObject<FileStream>(fileName, FileMode::Create, FileAccess::Write);

    auto slide = pres->get_Slides()->idx_get(index);
    slide->WriteAsSvg(fileStream);
}
```

## **FAQ**

**Why might the resulting SVG look different across browsers?**

브라우저 엔진마다 특정 SVG 기능에 대한 구현이 다르게 이루어집니다. [SVGOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgoptions/) 매개변수가 호환성 문제를 완화하는 데 도움이 됩니다.

**Is it possible to export not only slides but also individual shapes to SVG?**

예. 모든 [도형을 별도의 SVG로 저장할 수 있음](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/writeassvg/)은 아이콘, 픽토그램 및 그래픽 재사용에 편리합니다.

**Can multiple slides be combined into a single SVG (strip/document)?**

표준 시나리오는 한 슬라이드 → 한 SVG입니다. 여러 슬라이드를 하나의 SVG 캔버스로 결합하는 것은 애플리케이션 수준에서 수행되는 후처리 단계입니다.