---
title: JavaScript에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드를 SVG로
type: docs
weight: 50
url: /ko/nodejs-java/render-a-slide-as-an-svg-image/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 슬라이드를 SVG 이미지로 렌더링하는 방법을 배우세요. 간단한 JavaScript 코드 예제로 고품질 시각 효과를 제공합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션 슬라이드를 SVG 이미지로 렌더링하는 방법을 설명합니다. SVG 형식과 그 장점(확장성, 접근성, 웹 개발에의 적합성)을 소개합니다.

프레젠테이션 파일을 로드하고, 슬라이드를 순회하며 각 슬라이드를 별도의 SVG 파일로 저장하는 방법을 배웁니다. 이 문서는 PPT, PPTX, ODP, PPS 등 PowerPoint 및 OpenDocument 프레젠테이션 형식을 다루며, `Presentation` 클래스와 `writeAsSvg` 메서드를 사용해 프로그래밍 방식으로 변환하는 방법을 보여줍니다.

## **SVG 형식**

SVG(Scalable Vector Graphics)는 2차원 이미지를 렌더링하기 위해 사용되는 표준 그래픽 타입 또는 포맷입니다. SVG는 XML에 벡터 형태로 이미지를 저장하고, 동작이나 외형을 정의하는 상세 정보를 포함합니다.

SVG는 확장성, 인터랙티브성, 성능, 접근성, 프로그래밍 가능성 등 여러 측면에서 매우 높은 기준을 충족하는 몇 안 되는 이미지 포맷 중 하나입니다. 이러한 이유로 웹 개발에서 일반적으로 사용됩니다.

다음과 같은 경우에 SVG 파일을 사용할 수 있습니다.

- **프레젠테이션을 *아주 큰 형식*으로 인쇄하고 싶을 때.** SVG 이미지는 어떤 해상도나 크기로도 확대할 수 있습니다. 품질 손실 없이 여러 번 크기를 조정할 수 있습니다.
- **슬라이드의 차트와 그래프를 *다른 매체나 플랫폼*에서 사용하고 싶을 때.** 대부분의 뷰어가 SVG 파일을 해석할 수 있습니다.
- **가능한 한 *작은 이미지 크기*를 사용하고 싶을 때.** SVG 파일은 비트맵 기반 포맷(JPEG 또는 PNG)보다 일반적으로 파일 크기가 작습니다.

## **슬라이드를 SVG 이미지로 렌더링**

Aspose.Slides for Node.js via Java를 사용하면 프레젠테이션의 슬라이드를 SVG 이미지로 내보낼 수 있습니다. 다음 단계를 따라 SVG 이미지를 생성하십시오.

1. `Presentation` 클래스의 인스턴스를 생성합니다.
2. 프레젠테이션의 모든 슬라이드를 순회합니다.
3. `FileOutputStream`을 통해 각 슬라이드를 별도의 SVG 파일로 저장합니다.

{{% alert color="primary" %}} 

무료 웹 애플리케이션[free web application](https://products.aspose.app/slides/ko/conversion/ppt-to-svg)에서 Aspose.Slides for Node.js via Java의 PPT → SVG 변환 기능을 직접 확인해 보세요.

{{% /alert %}} 

다음 JavaScript 샘플 코드는 Aspose.Slides를 사용해 PPT를 SVG로 변환하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var fileStream = java.newInstanceSync("java.io.FileOutputStream", ("slide-" + index) + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **자주 묻는 질문**

**브라우저마다 결과 SVG가 다르게 보이는 이유는 무엇인가요?**

브라우저 엔진마다 특정 SVG 기능 지원 방식이 다릅니다. [SVGOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgoptions/) 매개변수를 사용하면 호환성 문제를 완화할 수 있습니다.

**슬라이드뿐만 아니라 개별 도형도 SVG로 내보낼 수 있나요?**

예. [도형을 개별 SVG로 저장](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/writeassvg/)할 수 있어 아이콘, 피토그램 및 그래픽 재사용에 편리합니다.

**여러 슬라이드를 하나의 SVG(스트립/문서)로 결합할 수 있나요?**

표준 시나리오는 슬라이드 1개당 SVG 1개입니다. 여러 슬라이드를 하나의 SVG 캔버스로 결합하는 작업은 애플리케이션 수준에서 수행하는 후처리 단계입니다.