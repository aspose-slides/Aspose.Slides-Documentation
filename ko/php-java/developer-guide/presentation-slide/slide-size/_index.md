---
title: PHP에서 프레젠테이션 슬라이드 크기 변경
linktitle: 슬라이드 크기
type: docs
weight: 70
url: /ko/php-java/slide-size/
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
- 스크린 유형
- 크기 조정 안 함
- 맞춤 보장
- 최대화
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
descriptions: "PHP와 Aspose.Slides를 사용하여 PPT, PPTX 및 ODP 파일의 슬라이드를 빠르게 크기 조정하는 방법을 배우고, 품질 손실 없이 모든 화면에 맞게 프레젠테이션을 최적화합니다."
---
## **소개**

Aspose.Slides는 인쇄 및 화면 표시 모두에 중요하게 작용하는 PowerPoint 프레젠테이션의 슬라이드 크기와 종횡비를 조정하기 위한 포괄적인 도구를 제공합니다.

인기 슬라이드 크기 및 비율:
- **Standard (4:3 Aspect Ratio)**: 오래된 화면 및 장치에 이상적입니다.
- **Widescreen (16:9 Aspect Ratio)**: 최신 프로젝터와 디스플레이에 권장됩니다.

프레젠테이션 전체에서 일관성을 유지하려면 모든 슬라이드에 동일한 슬라이드 크기와 종횡비가 적용됩니다. 최적의 결과를 얻으려면 복잡성을 피하기 위해 프레젠테이션 생성 초기에 슬라이드 차원을 설정하십시오.

{{% alert color="primary" %}} 
기본적으로 Aspose.Slides로 만든 프레젠테이션은 표준 4:3 종횡비를 사용합니다.
{{% /alert %}}

## **발표의 슬라이드 크기 변경**

다음 샘플 코드는 Aspose.Slides를 사용하여 프레젠테이션의 슬라이드 크기를 변경하는 방법을 보여줍니다:

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **발표에서 사용자 정의 슬라이드 크기 지정**

일반적인 슬라이드 크기(4:3 및 16:9)가 작업에 맞지 않는 경우 특정하거나 독특한 슬라이드 크기를 사용할 수 있습니다. 예를 들어 프레젠테이션을 사용자 정의 페이지 레이아웃에 맞춰 전체 크기로 인쇄하거나 특정 종류의 화면에 표시하려는 경우, 사용자 정의 크기 설정을 사용하면 도움이 됩니다.

다음 샘플 코드는 Java를 통해 PHP용 Aspose.Slides를 사용하여 프레젠테이션에 사용자 정의 슬라이드 크기를 지정하는 방법을 보여줍니다 :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// A4 용지 크기

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **크기 조정 후 슬라이드 내용 처리**

프레젠테이션의 슬라이드 크기를 변경하면 슬라이드 내용(예: 이미지나 개체)이 왜곡될 수 있습니다. 기본적으로 개체는 새로운 슬라이드 크기에 맞게 자동으로 크기가 조정됩니다. 그러나 프레젠테이션의 슬라이드 크기를 변경할 때, Aspose.Slides가 슬라이드의 내용을 처리하는 방식을 결정하는 설정을 지정할 수 있습니다.

목표나 의도에 따라 다음 설정 중 하나를 사용할 수 있습니다:

- `DoNotScale`

  슬라이드의 개체를 크기 조정하지 않으려면 이 설정을 사용하십시오.

- `EnsureFit`

  작은 슬라이드 크기로 축소하고 Aspose.Slides가 슬라이드의 모든 개체를 축소하여 슬라이드에 모두 맞추도록 하려면(이렇게 하면 내용 손실을 방지할 수 있음) 이 설정을 사용하십시오.

- `Maximize`

  큰 슬라이드 크기로 확대하고 Aspose.Slides가 슬라이드 개체를 확대하여 새로운 슬라이드 크기에 비례하도록 하려면 이 설정을 사용하십시오.

다음 샘플 코드는 프레젠테이션 슬라이드 크기를 변경할 때 `Maximize` 설정을 사용하는 방법을 보여줍니다:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**인치를 제외한 다른 단위(예: 포인트 또는 밀리미터)로 사용자 정의 슬라이드 크기를 설정할 수 있나요?**

예. Aspose.Slides는 내부적으로 포인트를 사용하며, 1 포인트는 1/72 인치에 해당합니다. 밀리미터나 센티미터와 같은 단위를 포인트로 변환한 뒤 변환된 값을 사용하여 슬라이드 너비와 높이를 정의할 수 있습니다.

**매우 큰 사용자 정의 슬라이드 크기가 렌더링 중 성능 및 메모리 사용량에 영향을 미칩니까?**

예. 포인트 단위의 큰 슬라이드 크기와 높은 렌더링 스케일을 함께 사용하면 메모리 사용량이 증가하고 처리 시간이 길어집니다. 실용적인 슬라이드 크기를 목표로 하고, 원하는 출력 품질을 얻기 위해 필요한 경우에만 렌더링 스케일을 조정하십시오.

**비표준 슬라이드 크기를 정의한 후, 크기가 다른 프레젠테이션의 슬라이드를 병합할 수 있나요?**

다른 슬라이드 크기를 가진 상태에서는 [merge presentations](/slides/ko/php-java/merge-presentation/)을 수행할 수 없습니다 — 먼저 한 프레젠테이션을 다른 프레젠테이션과 동일한 크기로 조정하십시오. 슬라이드 크기를 변경할 때는 [SlideSizeScaleType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidesizescaletype/) 옵션을 통해 기존 콘텐츠 처리 방식을 선택할 수 있습니다. 크기를 맞춘 후에는 서식을 유지하면서 슬라이드를 병합할 수 있습니다.

**개별 도형이나 슬라이드의 특정 영역에 대한 썸네일을 생성할 수 있나요? 그리고 새 슬라이드 크기를 반영합니까?**

예. Aspose.Slides는 [entire slides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/#getImage)와 [selected shapes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getImage) 모두에 대한 썸네일을 렌더링할 수 있습니다. 생성된 이미지는 현재 슬라이드 크기와 종횡비를 반영하여 일관된 프레이밍과 기하학을 보장합니다.