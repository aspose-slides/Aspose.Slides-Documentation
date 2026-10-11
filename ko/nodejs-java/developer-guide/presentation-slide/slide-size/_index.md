---
title: JavaScript에서 프레젠테이션 슬라이드 크기 변경
linktitle: 슬라이드 크기
type: docs
weight: 70
url: /ko/nodejs-java/slide-size/
keywords:
- 슬라이드 크기
- 종횡비
- 표준
- 와이드스크린
- 4:3
- 16:9
- 슬라이드 크기 설정
- 슬라이드 크기 변경
- 사용자 정의 슬라이드 크기
- 특수 슬라이드 크기
- 고유 슬라이드 크기
- 전체 크기 슬라이드
- 화면 유형
- 크기 조정 안 함
- 맞춤 보장
- 최대화
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js와 Aspose.Slides를 사용하여 PPT, PPTX 및 ODP 파일의 슬라이드를 신속하게 크기 조정하는 방법을 배우고, 품질 손실 없이 모든 화면에 맞게 프레젠테이션을 최적화하세요."
---
## **소개**

Aspose.Slides는 인쇄와 화면 표시 모두에 중요한 PowerPoint 프레젠테이션의 슬라이드 크기와 종횡비를 조정하는 포괄적인 도구를 제공합니다.  

주요 슬라이드 크기 및 비율:

- **Standard (4:3 Aspect Ratio)**: 오래된 화면 및 장치에 이상적입니다.
- **Widescreen (16:9 Aspect Ratio)**: 최신 프로젝터 및 디스플레이에 권장됩니다.

프레젠테이션 전체에 일관성을 유지하세요. 하나의 슬라이드 크기와 종횡비가 모든 슬라이드에 적용됩니다. 최상의 결과를 얻으려면 프레젠테이션을 만들기 시작할 때 슬라이드 크기를 설정하여 복잡함을 방지하십시오.

{{% alert color="info" title="Note" %}}
기본적으로 Aspose.Slides로 만든 프레젠테이션은 표준 4:3 종횡비를 사용합니다.
{{% /alert %}}

노트와 유인물 페이지는 일반 슬라이드와 별개의 크기를 가집니다. 크기와 방향을 변경하려면 [Notes Page Size](/slides/ko/nodejs-java/notes-size/)를 참조하십시오.

## **프레젠테이션에서 슬라이드 크기 변경**

다음 샘플 코드는 JavaScript에서 Aspose.Slides를 사용하여 프레젠테이션의 슬라이드 크기를 변경하는 방법을 보여줍니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **프레젠테이션에서 사용자 정의 슬라이드 크기 지정**

일반 슬라이드 크기(4:3 및 16:9)가 작업에 적합하지 않은 경우 특정하거나 고유한 슬라이드 크기를 사용할 수 있습니다. 예를 들어 프레젠테이션을 사용자 정의 페이지 레이아웃에 전체 크기로 인쇄하거나 특정 화면 유형에서 표시하려는 경우, 사용자 정의 크기 설정이 도움이 될 수 있습니다.  

다음 샘플 코드는 JavaScript에서 Aspose.Slides for Node.js via Java를 사용하여 프레젠테이션에 사용자 정의 슬라이드 크기를 지정하는 방법을 보여줍니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// A4 용지 크기
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **프레젠테이션에서 슬라이드 크기 변경 시 발생하는 문제 해결**

프레젠테이션의 슬라이드 크기를 변경하면 슬라이드 내용(예: 이미지 또는 개체)이 왜곡될 수 있습니다. 기본적으로 개체는 새 슬라이드 크기에 맞게 자동으로 크기가 조정됩니다. 그러나 슬라이드 크기를 변경할 때 Aspose.Slides가 슬라이드의 내용을 처리하는 방식을 결정하는 설정을 지정할 수 있습니다.

목표에 따라 다음 설정 중 하나를 사용할 수 있습니다:

- `DoNotScale`

  슬라이드의 개체 크기를 조정하고 싶지 않을 때 이 설정을 사용합니다.

- `EnsureFit`

  슬라이드 크기를 더 작게 축소하고 싶고, 모든 개체가 슬라이드에 맞도록 Aspose.Slides가 축소하도록 하여 내용 손실을 방지하고 싶을 때 이 설정을 사용합니다.

- `Maximize`

  슬라이드 크기를 더 크게 확장하고 싶으며, 개체를 새 슬라이드 크기에 비례하도록 확대하려면 이 설정을 사용합니다.

다음 샘플 코드는 프레젠테이션 슬라이드 크기를 변경할 때 `Maximize` 설정을 사용하는 방법을 보여줍니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **자주 묻는 질문**

**인치 이외의 단위(예: 포인트 또는 밀리미터)로 사용자 정의 슬라이드 크기를 설정할 수 있나요?**  

예. Aspose.Slides는 내부적으로 포인트를 사용하며, 1 포인트는 1/72 인치에 해당합니다. 밀리미터나 센티미터와 같은 단위를 포인트로 변환한 뒤 슬라이드 너비와 높이에 사용할 수 있습니다.

**매우 큰 사용자 정의 슬라이드 크기가 렌더링 시 성능 및 메모리 사용에 영향을 주나요?**  

예. 포인트 단위의 큰 슬라이드 치수와 높은 렌더링 스케일을 결합하면 메모리 사용량이 증가하고 처리 시간이 길어집니다. 실용적인 슬라이드 크기를 목표로 하고, 원하는 출력 품질을 얻기 위해 필요한 경우에만 렌더링 스케일을 조정하십시오.

**비표준 슬라이드 크기를 정의한 뒤, 크기가 다른 프레젠테이션의 슬라이드를 병합할 수 있나요?**  

크기가 다른 상태에서는 [merge presentations](/slides/ko/nodejs-java/merge-presentation/)을 할 수 없습니다—먼저 하나의 프레젠테이션을 다른 프레젠테이션에 맞게 크기를 조정해야 합니다. 슬라이드 크기를 변경할 때는 [SlideSizeScaleType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidesizescaletype/) 옵션을 통해 기존 콘텐츠 처리 방식을 선택할 수 있습니다. 크기를 맞춘 후에는 서식을 유지하면서 슬라이드를 병합할 수 있습니다.

**슬라이드의 개별 도형이나 특정 영역에 대한 썸네일을 생성할 수 있나요? 그리고 새로운 슬라이드 크기를 반영하나요?**  

예. Aspose.Slides는 [entire slides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/#getImage)와 [selected shapes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getImage) 모두에 대한 썸네일을 렌더링할 수 있습니다. 생성된 이미지는 현재 슬라이드 크기와 종횡비를 반영하여 일관된 프레임과 기하학을 보장합니다.