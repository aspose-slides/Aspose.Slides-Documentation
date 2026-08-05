---
title: Java에서 프레젠테이션 슬라이드 크기 변경
linktitle: 슬라이드 크기
type: docs
weight: 70
url: /ko/java/slide-size/
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
- 최대로 확대
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Java와 Aspose.Slides를 사용하여 PPT, PPTX 및 ODP 파일의 슬라이드를 빠르게 크기 조정하고, 품질 손실 없이 모든 화면에 맞게 프레젠테이션을 최적화하는 방법을 배웁니다."
---
## **소개**

Aspose.Slides는 인쇄와 화면 표시 모두에 중요한 PowerPoint 프레젠테이션의 슬라이드 크기와 종횡비를 조정하는 포괄적인 도구를 제공합니다.  

일반적인 슬라이드 크기 및 비율:

- **표준 (4:3 종횡비)**: 오래된 화면 및 장치에 이상적입니다.
- **와이드스크린 (16:9 종횡비)**: 최신 프로젝터와 디스플레이에 권장됩니다.

프레젠테이션 전체에 일관성을 유지하려면 모든 슬라이드에 단일 슬라이드 크기와 종횡비가 적용됩니다. 최적의 결과를 위해 프레젠테이션을 만들기 시작할 때 슬라이드 치수를 설정하여 문제를 방지하세요.

{{% alert color="primary" %}} 
기본적으로 Aspose.Slides로 만든 프레젠테이션은 표준 4:3 종횡비를 사용합니다.
{{% /alert %}}

## **프레젠테이션에서 슬라이드 크기 변경**

다음 샘플 코드는 Aspose.Slides for Java를 사용하여 프레젠테이션의 슬라이드 크기를 변경하는 방법을 보여줍니다.

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **프레젠테이션에서 사용자 정의 슬라이드 크기 지정**

일반적인 슬라이드 크기(4:3 및 16:9)가 작업에 맞지 않는 경우 특정하거나 고유한 슬라이드 크기를 사용할 수 있습니다. 예를 들어 프레젠테이션에서 맞춤 페이지 레이아웃으로 전체 크기 슬라이드를 인쇄하거나 특정 화면 유형에 표시하려는 경우 사용자 정의 크기 설정을 사용하면 도움이 됩니다.

다음 샘플 코드는 Aspose.Slides for Java를 사용하여 Java에서 프레젠테이션의 사용자 정의 슬라이드 크기를 지정하는 방법을 보여줍니다.

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

프레젠테이션의 슬라이드 크기를 변경하면 슬라이드 내용(예: 이미지 또는 객체)이 왜곡될 수 있습니다. 기본적으로 객체는 새 슬라이드 크기에 맞게 자동으로 크기가 조정됩니다. 그러나 프레젠테이션의 슬라이드 크기를 변경할 때 Aspose.Slides가 슬라이드의 내용을 처리하는 방식을 결정하는 설정을 지정할 수 있습니다.

목표에 따라 다음 설정 중 하나를 사용할 수 있습니다:

- `DoNotScale`

  슬라이드의 객체 크기를 조정하고 싶지 않다면 이 설정을 사용하십시오.

- `EnsureFit`

  슬라이드 크기를 더 작게 축소하고 싶고, 모든 객체가 슬라이드에 맞도록 Aspose.Slides가 축소하도록 하여 내용 손실을 방지하려면 이 설정을 사용하십시오.

- `Maximize`

  슬라이드 크기를 더 크게 확대하고 싶으며, 객체를 새 슬라이드 크기에 비례하도록 확대하려면 이 설정을 사용하십시오.

다음 샘플 코드는 프레젠테이션 슬라이드 크기를 변경할 때 `Maximize` 설정을 사용하는 방법을 보여줍니다.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**인치가 아닌 단위(예: 포인트 또는 밀리미터)로 사용자 정의 슬라이드 크기를 설정할 수 있나요?**

예. Aspose.Slides는 내부적으로 포인트를 사용하며, 1포인트는 1인치의 1/72에 해당합니다. 밀리미터나 센티미터와 같은 단위를 포인트로 변환하고 변환된 값을 슬라이드 너비와 높이를 정의하는 데 사용할 수 있습니다.

**아주 큰 사용자 정의 슬라이드 크기가 렌더링 중 성능 및 메모리 사용량에 영향을 미치나요?**

예. 큰 슬라이드 치수(포인트 단위)와 높은 렌더링 스케일을 결합하면 메모리 사용량이 증가하고 처리 시간이 길어집니다. 실용적인 슬라이드 크기를 목표로 하고, 원하는 출력 품질을 얻기 위해 필요한 경우에만 렌더링 스케일을 조정하십시오.

**비표준 슬라이드 크기를 정의한 후, 크기가 다른 프레젠테이션에서 슬라이드를 병합할 수 있나요?**

다른 슬라이드 크기를 가진 상태에서는 [프레젠테이션 병합](/slides/ko/java/merge-presentation/)을 할 수 없습니다 — 먼저 한 프레젠테이션의 크기를 다른 프레젠테이션에 맞게 조정해야 합니다. 슬라이드 크기를 변경할 때는 기존 내용이 어떻게 처리되는지 [SlideSizeScaleType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidesizescaletype/) 옵션을 통해 선택할 수 있습니다. 크기를 맞춘 후에는 형식을 유지하면서 슬라이드를 병합할 수 있습니다.

**슬라이드의 개별 쉐이프 또는 특정 영역에 대한 썸네일을 생성할 수 있나요? 그리고 새 슬라이드 크기를 반영하나요?**

예. Aspose.Slides는 [전체 슬라이드](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)와 [선택된 쉐이프](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getImage-int-float-float-)에 대한 썸네일을 렌더링할 수 있습니다. 생성된 이미지는 현재 슬라이드 크기와 종횡비를 반영하여 일관된 프레이밍과 기하학을 보장합니다.