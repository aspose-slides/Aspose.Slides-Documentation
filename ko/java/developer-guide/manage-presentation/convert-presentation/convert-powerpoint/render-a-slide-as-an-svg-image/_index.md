---
title: Java에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드 to SVG
type: docs
weight: 50
url: /ko/java/render-a-slide-as-an-svg-image/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 슬라이드를 SVG 이미지로 렌더링하는 방법을 배웁니다. 간단한 코드 예제로 고품질 비주얼을 구현합니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션 슬라이드를 SVG 이미지로 렌더링하는 방법을 설명합니다. SVG 형식과 그 장점(확장성, 접근성, 웹 개발 적합성)을 소개합니다.

프레젠테이션 파일을 로드하고, 슬라이드를 순회하며 각 슬라이드를 별개의 SVG 파일로 저장하는 방법을 배웁니다. 이 문서는 PPT, PPTX, ODP, PPS와 같은 PowerPoint 및 OpenDocument 프레젠테이션 형식을 다루며, `Presentation` 클래스와 `writeAsSvg` 메서드를 사용해 프로그래밍 방식으로 변환하는 방법을 보여줍니다.

## **SVG 형식**

SVG(Scalable Vector Graphics)는 2차원 이미지를 렌더링하는 표준 그래픽 유형 또는 형식입니다. SVG는 벡터를 XML에 저장하여 동작이나 외관을 정의하는 세부 정보를 포함합니다.

SVG는 확장성, 인터랙티브성, 성능, 접근성, 프로그래밍 가능성 등 매우 높은 기준을 충족하는 몇 안되는 이미지 형식 중 하나입니다. 이러한 이유로 웹 개발에서 널리 사용됩니다.

다음과 같은 경우 SVG 파일을 사용할 수 있습니다.

- **프레젠테이션을 *아주 큰 형식*으로 인쇄**. SVG 이미지는 어떤 해상도나 수준으로도 확대할 수 있습니다. 품질 손실 없이 원하는 만큼 이미지 크기를 조정할 수 있습니다.
- **다른 *매체 또는 플랫폼*에서 슬라이드의 차트와 그래프 사용**. 대부분의 뷰어가 SVG 파일을 해석할 수 있습니다.
- **이미지를 *가능한 가장 작은 크기*로 사용**. SVG 파일은 비트맵 기반 포맷(JPEG 또는 PNG)보다 일반적으로 고해상도 대비 파일 크기가 작습니다.

## **슬라이드를 SVG 이미지로 렌더링**

Aspose.Slides for Java를 사용하면 프레젠테이션의 슬라이드를 SVG 이미지로 내보낼 수 있습니다. 다음 단계에 따라 SVG 이미지를 생성하십시오.

1. `Presentation` 클래스의 인스턴스를 생성합니다.
2. 프레젠테이션의 모든 슬라이드를 순회합니다.
3. 각 슬라이드를 `FileOutputStream`을 사용해 별도의 SVG 파일로 씁니다.

{{% alert color="primary" %}} 
당사의 [무료 웹 애플리케이션](https://products.aspose.app/slides/ko/conversion/ppt-to-svg)을 사용해 Aspose.Slides for Java의 PPT → SVG 변환 기능을 직접 체험해 보세요.
{{% /alert %}} 

다음 Java 샘플 코드는 Aspose.Slides를 사용해 PPT를 SVG로 변환하는 방법을 보여줍니다:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**왜 결과 SVG가 브라우저마다 다르게 보일 수 있나요?**

특정 SVG 기능에 대한 지원이 브라우저 엔진마다 다르게 구현됩니다. [SVGOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/svgoptions/) 매개변수를 사용하면 호환성 차이를 완화할 수 있습니다.

**슬라이드뿐만 아니라 개별 도형도 SVG로 내보낼 수 있나요?**

예. 모든 [도형은 별도의 SVG로 저장](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)할 수 있어 아이콘, 피クト그램 및 그래픽 재사용에 편리합니다.

**여러 슬라이드를 하나의 SVG(스트립/문서)로 결합할 수 있나요?**

표준 시나리오는 슬라이드 1개당 SVG 1개입니다. 여러 슬라이드를 하나의 SVG 캔버스로 결합하는 작업은 애플리케이션 수준에서 수행되는 후처리 단계입니다.