---
title: Android에서 프레젠테이션 슬라이드 크기 변경
linktitle: 슬라이드 크기
type: docs
weight: 70
url: /ko/androidjava/slide-size/
keywords:
- 슬라이드 크기
- 가로 세로 비율
- 표준
- 와이드스크린
- 4:3
- 16:9
- 슬라이드 크기 설정
- 슬라이드 크기 변경
- 맞춤 슬라이드 크기
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
- Android
- Java
- Aspose.Slides
descriptions: "Java와 Android용 Aspose.Slides를 사용하여 PPT, PPTX 및 ODP 파일의 슬라이드를 신속하게 크기 조정하고, 품질 손실 없이 모든 화면에 맞게 프레젠테이션을 최적화합니다."
---
## **소개**

Aspose.Slides는 프린트와 화면 표시 모두에 중요한 PowerPoint 프레젠테이션의 슬라이드 크기와 가로 세로 비율을 조정할 수 있는 포괄적인 도구를 제공합니다.

일반적인 슬라이드 크기 및 비율:

- **표준 (4:3 비율)**: 구형 화면 및 장치에 적합합니다.
- **와이드스크린 (16:9 비율)**: 최신 프로젝터 및 디스플레이에 권장됩니다.

프레젠테이션 전체에 일관성을 유지하려면 모든 슬라이드에 동일한 슬라이드 크기와 비율이 적용됩니다. 최적의 결과를 위해 복잡함을 방지하려면 프레젠테이션 제작 초기에 슬라이드 크기를 설정하십시오.

{{% alert color="primary" %}} 
기본적으로 Aspose.Slides로 만든 프레젠테이션은 표준 4:3 비율을 사용합니다.
{{% /alert %}}

## **프레젠테이션에서 슬라이드 크기 변경**

이 샘플 코드는 Aspose.Slides를 사용하여 Java에서 프레젠테이션의 슬라이드 크기를 변경하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **프레젠테이션에 사용자 정의 슬라이드 크기 지정**

일반적인 슬라이드 크기(4:3 및 16:9)가 작업에 맞지 않다면 특정하거나 독특한 슬라이드 크기를 사용할 수 있습니다. 예를 들어, 사용자 정의 페이지 레이아웃으로 프레젠테이션의 전체 슬라이드를 인쇄하거나 특정 유형의 화면에 프레젠테이션을 표시하려는 경우 사용자 정의 크기 설정을 사용하면 도움이 됩니다.

이 샘플 코드는 Java를 통해 Android용 Aspose.Slides를 사용하여 Java에서 프레젠테이션의 사용자 정의 슬라이드 크기를 지정하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 용지 크기
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **크기 조정 후 슬라이드 내용 처리**

프레젠테이션의 슬라이드 크기를 변경하면 슬라이드 내용(예: 이미지 또는 객체)이 왜곡될 수 있습니다. 기본적으로 객체는 새 슬라이드 크기에 맞게 자동으로 크기가 조정됩니다. 그러나 프레젠테이션의 슬라이드 크기를 변경할 때 Aspose.Slides가 슬라이드 내용물을 처리하는 방식을 결정하는 설정을 지정할 수 있습니다.

목표에 따라 다음 설정 중 하나를 사용할 수 있습니다:

- `DoNotScale`
  슬라이드의 객체 크기를 변경하고 싶지 않다면 이 설정을 사용하십시오.

- `EnsureFit`
  더 작은 슬라이드 크기로 축소하고 Aspose.Slides가 슬라이드의 모든 객체를 축소하여 슬라이드에 맞게 하려면(이렇게 하면 내용 손실을 방지) 이 설정을 사용하십시오.

- `Maximize`
  더 큰 슬라이드 크기로 확대하고 Aspose.Slides가 슬라이드 객체를 확대하여 새 슬라이드 크기에 비례하도록 하려면 이 설정을 사용하십시오.

이 샘플 코드는 프레젠테이션 슬라이드 크기를 변경할 때 `Maximize` 설정을 사용하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**인치를 제외한 단위(예: 포인트 또는 밀리미터)로 사용자 정의 슬라이드 크기를 설정할 수 있나요?**

예. Aspose.Slides는 내부적으로 포인트를 사용하며, 1포인트는 1인치의 1/72에 해당합니다. 밀리미터나 센티미터와 같은 모든 단위를 포인트로 변환한 뒤 변환된 값을 사용해 슬라이드 너비와 높이를 정의할 수 있습니다.

**매우 큰 사용자 정의 슬라이드 크기가 렌더링 중 성능 및 메모리 사용량에 영향을 미치나요?**

예. 포인트 단위의 큰 슬라이드 크기와 높은 렌더링 배율을 결합하면 메모리 사용량이 증가하고 처리 시간이 길어집니다. 실용적인 슬라이드 크기를 목표로 하고, 필요한 경우에만 렌더링 배율을 조정해 원하는 출력 품질을 달성하십시오.

**비표준 슬라이드 크기를 정의한 뒤 크기가 다른 프레젠테이션의 슬라이드를 병합할 수 있나요?**

다른 슬라이드 크기를 가진 상태에서는 [프레젠테이션 병합](/slides/ko/androidjava/merge-presentation/)을 할 수 없습니다 — 먼저 한 프레젠테이션의 크기를 다른 프레젠테이션에 맞게 조정하십시오. 슬라이드 크기를 변경할 때는 [SlideSizeScaleType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slidesizescaletype/) 옵션을 통해 기존 내용이 어떻게 처리될지 선택할 수 있습니다. 크기를 맞춘 후에는 서식을 유지하면서 슬라이드를 병합할 수 있습니다.

**슬라이드의 개별 도형이나 특정 영역에 대한 썸네일을 생성할 수 있나요? 또한 새 슬라이드 크기를 반영하나요?**

예. Aspose.Slides는 [전체 슬라이드](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)와 [선택된 도형](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)에 대한 썸네일을 렌더링할 수 있습니다. 생성된 이미지들은 현재 슬라이드 크기와 비율을 반영하여 일관된 프레이밍과 기하학을 보장합니다.