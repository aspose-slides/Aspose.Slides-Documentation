---
title: Android에서 프레젠테이션 슬라이드 크기 변경
linktitle: 슬라이드 크기
type: docs
weight: 70
url: /ko/androidjava/slide-size/
keywords:
- 슬라이드 크기
- 종횡비
- 표준
- 와이드스크린
- 4:3
- 16:9
- 슬라이드 크기 설정
- 슬라이드 크기 변경
- 사용자 지정 슬라이드 크기
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
description: "Java와 Aspose.Slides for Android를 사용하여 PPT, PPTX 및 ODP 파일의 슬라이드를 빠르게 크기 조정하고, 품질 손실 없이 모든 화면에 맞게 프레젠테이션을 최적화합니다."
---
## **소개**

Aspose.Slides는 PowerPoint 프레젠테이션에서 슬라이드 크기와 종횡비를 조정하기 위한 포괄적인 도구를 제공하며, 인쇄와 화면 표시 모두에 중요합니다. 

일반적인 슬라이드 크기 및 비율:

- **Standard (4:3 Aspect Ratio)**: 오래된 화면 및 장치에 적합합니다.
- **Widescreen (16:9 Aspect Ratio)**: 최신 프로젝터와 디스플레이에 권장됩니다.

프레젠테이션 전체에 일관성을 유지하려면 모든 슬라이드에 동일한 슬라이드 크기와 종횡비가 적용됩니다. 최상의 결과를 얻으려면 프레젠테이션을 만들기 시작할 때 슬라이드 크기를 설정하여 복잡함을 방지하세요.

{{% alert color="info" title="Note" %}}
기본적으로 Aspose.Slides로 만든 프레젠테이션은 표준 4:3 종횡비를 사용합니다.
{{% /alert %}}

노트 및 유인물 페이지는 일반 슬라이드와 별도의 크기를 가집니다. 크기와 방향을 변경하려면 [Notes Page Size](/slides/ko/androidjava/notes-size/)를 참조하세요.

## **프레젠테이션에서 슬라이드 크기 변경**

다음 예제 코드는 Java에서 Aspose.Slides를 사용하여 프레젠테이션의 슬라이드 크기를 변경하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **프레젠테이션에서 사용자 지정 슬라이드 크기 지정**

일반적인 슬라이드 크기(4:3 및 16:9)가 작업에 맞지 않을 경우 특정하거나 고유한 슬라이드 크기를 사용할 수 있습니다. 예를 들어, 맞춤 페이지 레이아웃에 맞춰 전체 크기의 슬라이드를 인쇄하거나 특정 화면 유형에 프레젠테이션을 표시하려는 경우, 사용자 지정 크기 설정을 사용하는 것이 유리합니다. 

다음 예제 코드는 Java를 통해 Android용 Aspose.Slides를 사용하여 프레젠테이션에 사용자 지정 슬라이드 크기를 지정하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 용지 크기
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **크기 조정 후 슬라이드 내용 처리**

프레젠테이션의 슬라이드 크기를 변경하면 슬라이드 내용(예: 이미지 또는 개체)이 왜곡될 수 있습니다. 기본적으로 개체는 새 슬라이드 크기에 맞게 자동으로 크기가 조정됩니다. 그러나 프레젠테이션의 슬라이드 크기를 변경할 때, Aspose.Slides가 슬라이드의 내용에 어떻게 적용될지 결정하는 설정을 지정할 수 있습니다.

목표에 따라 다음 설정 중 하나를 사용할 수 있습니다:

- `DoNotScale`

  슬라이드의 개체를 크기 조정하지 않으려면 이 설정을 사용합니다.

- `EnsureFit`

  슬라이드 크기를 더 작게 줄이고 모든 개체가 슬라이드에 맞도록 축소하도록 하려면 이 설정을 사용합니다(이렇게 하면 내용이 손실되지 않습니다).

- `Maximize`

  슬라이드 크기를 더 크게 늘리고 개체를 새 슬라이드 크기에 비례하도록 확대하려면 이 설정을 사용합니다.

다음 예제 코드는 프레젠테이션 슬라이드 크기를 변경할 때 `Maximize` 설정을 사용하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**인치를 제외한 단위(예: 포인트 또는 밀리미터)로 사용자 지정 슬라이드 크기를 설정할 수 있나요?**

네. Aspose.Slides는 내부적으로 포인트를 사용하며, 1포인트는 1/72인치에 해당합니다. 밀리미터나 센티미터와 같은 단위를 포인트로 변환한 뒤 슬라이드 너비와 높이를 정의할 수 있습니다.

**매우 큰 사용자 지정 슬라이드 크기가 렌더링 중 성능 및 메모리 사용량에 영향을 미시나요?**

네. 포인트 단위의 큰 슬라이드 치수와 높은 렌더링 스케일을 결합하면 메모리 사용량이 증가하고 처리 시간이 길어집니다. 실용적인 슬라이드 크기를 목표로 하고, 원하는 출력 품질을 얻을 때만 렌더링 스케일을 조정하세요.

**하나의 비표준 슬라이드 크기를 정의한 후, 다른 크기의 프레젠테이션 슬라이드를 병합할 수 있나요?**

다른 슬라이드 크기를 가진 상태에서는 [merge presentations](/slides/ko/androidjava/merge-presentation/)을 할 수 없습니다 — 먼저 한 프레젠테이션을 다른 프레젠테이션에 맞게 크기를 조정해야 합니다. 슬라이드 크기를 변경할 때는 [SlideSizeScaleType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slidesizescaletype/) 옵션을 통해 기존 내용 처리 방식을 선택할 수 있습니다. 크기를 맞춘 뒤에는 형식을 유지하면서 슬라이드를 병합할 수 있습니다.

**개별 도형이나 슬라이드의 특정 영역에 대한 썸네일을 생성할 수 있나요? 그리고 새 슬라이드 크기를 반영하나요?**

네. Aspose.Slides는 [entire slides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)와 [selected shapes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) 모두에 대한 썸네일을 렌더링할 수 있습니다. 생성된 이미지는 현재 슬라이드 크기와 종횡비를 반영하여 일관된 프레임 및 기하학을 보장합니다.