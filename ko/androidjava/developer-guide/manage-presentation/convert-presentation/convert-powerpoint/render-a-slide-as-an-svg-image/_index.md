---
title: Android에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드에서 SVG로
type: docs
weight: 50
url: /ko/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 PowerPoint 슬라이드를 SVG 이미지로 렌더링하는 방법을 배웁니다. 간단한 Java 코드 예제로 고품질 비주얼을 제공합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션 슬라이드를 SVG 이미지로 렌더링하는 방법을 설명합니다. SVG 형식과 확장성, 접근성, 웹 개발에 적합한 장점에 대해 소개합니다.

프레젠테이션 파일을 로드하고 슬라이드를 순회하며 각 슬라이드를 별도의 SVG 파일로 저장하는 방법을 배웁니다. 이 문서는 PPT, PPTX, ODP, PPS와 같은 PowerPoint 및 OpenDocument 프레젠테이션 형식을 다루며, `Presentation` 클래스와 `writeAsSvg` 메서드를 사용하여 프로그래밍 방식으로 변환하는 방법을 보여줍니다.

## **SVG 형식**

SVG는 Scalable Vector Graphics의 약자로, 2차원 이미지를 렌더링하는 표준 그래픽 형식입니다. SVG는 이미지의 동작이나 외관을 정의하는 세부 정보를 XML 형태의 벡터로 저장합니다.

SVG는 확장성, 인터랙티브성, 성능, 접근성, 프로그래밍 가능성 등 매우 높은 기준을 충족하는 몇 안 되는 이미지 형식 중 하나이며, 이러한 이유로 웹 개발에서 흔히 사용됩니다.

다음과 같은 경우 SVG 파일을 사용하고 싶을 수 있습니다.

- **프레젠테이션을 *매우 큰 형식*으로 인쇄합니다.** SVG 이미지는 어떤 해상도나 수준으로도 확대할 수 있으며, 품질 저하 없이 여러 번 크기를 조정할 수 있습니다.
- **슬라이드의 차트와 그래프를 *다양한 매체나 플랫폼*에 사용합니다.** 대부분의 뷰어가 SVG 파일을 해석할 수 있습니다.
- **이미지를 *가능한 가장 작은 크기*로 사용합니다.** SVG 파일은 비트맵 기반(JPEG 또는 PNG) 형식에 비해 일반적으로 더 작은 용량을 가집니다.

## **슬라이드를 SVG 이미지로 렌더링하기**

Aspose.Slides for Android via Java를 사용하면 프레젠테이션의 슬라이드를 SVG 이미지로 내보낼 수 있습니다. 다음 단계에 따라 SVG 이미지를 생성하십시오.

1. `Presentation` 클래스의 인스턴스를 생성합니다.
2. 프레젠테이션의 모든 슬라이드를 순회합니다.
3. `FileOutputStream`을 통해 각 슬라이드를 별개의 SVG 파일로 저장합니다.

{{% alert color="primary" %}} 
Aspose.Slides for Android via Java에서 구현한 PPT → SVG 변환 기능을 체험해 보시려면 [무료 웹 애플리케이션](https://products.aspose.app/slides/ko/conversion/ppt-to-svg)을 이용해 보세요. 
{{% /alert %}} 

다음 Java 샘플 코드는 Aspose.Slides를 사용하여 PPT를 SVG로 변환하는 방법을 보여 줍니다.

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

## **자주 묻는 질문**

**왜 결과 SVG가 브라우저마다 다르게 보일 수 있나요?**  
브라우저 엔진마다 특정 SVG 기능에 대한 지원 방식이 다릅니다. [SVGOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgoptions/) 매개변수를 사용하면 호환성 문제를 완화할 수 있습니다.

**슬라이드뿐만 아니라 개별 도형도 SVG로 내보낼 수 있나요?**  
예. 모든 [도형은 별도의 SVG로 저장](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)될 수 있으므로 아이콘, 피ictogram 및 그래픽 재사용에 편리합니다.

**여러 슬라이드를 하나의 SVG(스트립/문서)로 결합할 수 있나요?**  
표준 시나리오는 슬라이드당 하나의 SVG입니다. 여러 슬라이드를 하나의 SVG 캔버스로 결합하는 작업은 애플리케이션 수준에서 수행되는 후처리 단계입니다.