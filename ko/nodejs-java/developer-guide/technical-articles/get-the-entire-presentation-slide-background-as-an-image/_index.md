---
title: 프레젠테이션에서 전체 슬라이드 배경을 이미지로 추출하기
linktitle: 전체 슬라이드 배경
type: docs
weight: 95
url: /ko/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 슬라이드 배경
- 최종 배경
- 배경 추출
- 전체 배경
- 배경을 이미지로
- PPT 배경
- PPTX 배경
- ODP 배경
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 전체 슬라이드 배경을 이미지로 추출하고, 시각적 작업 흐름을 간소화합니다."
---
## **개요**

PowerPoint 프레젠테이션에서 슬라이드 배경은 슬라이드 배경 이미지, 프레젠테이션 테마, 색 구성표, 마스터 슬라이드 또는 레이아웃 슬라이드에 배치된 객체 등 여러 요소로 구성될 수 있습니다.

이 문서는 Aspose.Slides를 사용하여 전체 슬라이드 배경을 이미지로 추출하는 방법을 보여줍니다. 이 작업을 위한 단일 메서드가 없기 때문에, 선택한 슬라이드를 임시 프레젠테이션으로 복제하고, 슬라이드 도형을 제거한 다음, 결과 슬라이드 배경을 이미지로 변환하는 접근 방식을 사용합니다.

## **전체 슬라이드 배경 가져오기**

Aspose.Slides for Node.js via Java는 전체 프레젠테이션 슬라이드 배경을 이미지로 추출하는 간단한 메서드를 제공하지 않지만, 다음 단계에 따라 수행할 수 있습니다:
1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스를 사용하여 프레젠테이션을 로드합니다.
1. 프레젠테이션에서 슬라이드 크기를 가져옵니다.
1. 슬라이드를 선택합니다.
1. 임시 프레젠테이션을 생성합니다.
1. 임시 프레젠테이션에 동일한 슬라이드 크기를 설정합니다.
1. 선택한 슬라이드를 임시 프레젠테이션에 복제합니다.
1. 복제된 슬라이드에서 도형을 삭제합니다.
1. 복제된 슬라이드를 이미지로 변환합니다.

다음 코드 예제는 전체 프레젠테이션 슬라이드 배경을 이미지로 추출합니다.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```

## **FAQ**

**마스터 슬라이드의 복잡한 그라디언트, 텍스처 또는 그림 채우기가 결과 배경 이미지에 유지됩니까?**

예. Aspose.Slides는 슬라이드, 레이아웃 또는 마스터에 정의된 그라디언트, 그림 및 텍스처 채우기를 렌더링합니다. 상속된 마스터의 모양을 분리해야 하는 경우, 내보내기 전에 현재 슬라이드에 [자체 배경을 설정](/slides/ko/nodejs-java/presentation-background/)하십시오.

**저장하기 전에 결과 배경 이미지에 워터마크를 추가할 수 있나요?**

예. 작업 중인 [슬라이드 복사본](/slides/ko/nodejs-java/clone-slides/)에 [워터마크](/slides/ko/nodejs-java/watermark/) 도형이나 이미지를 (다른 콘텐츠 뒤에 배치하여) 추가한 다음 내보낼 수 있습니다. 이를 통해 워터마크가 삽입된 배경 이미지를 생성할 수 있습니다.

**기존 슬라이드에 연결하지 않고 특정 레이아웃이나 마스터의 배경을 가져올 수 있나요?**

예. 원하는 마스터나 레이아웃에 접근한 후, 필요한 크기의 [임시 슬라이드](/slides/ko/nodejs-java/clone-slides/)에 적용하고 해당 슬라이드를 내보내면 해당 레이아웃이나 마스터에서 파생된 배경을 얻을 수 있습니다.

**이미지 내보내기에 영향을 주는 라이선스 제한이 있나요?**

렌더링 기능은 [유효한 라이선스](/slides/ko/nodejs-java/licensing/)가 있으면 완전히 사용할 수 있습니다. 평가 모드에서는 워터마크와 같은 제한이 포함될 수 있습니다. 배치 내보내기를 실행하기 전에 프로세스당 한 번 라이선스를 활성화하십시오.