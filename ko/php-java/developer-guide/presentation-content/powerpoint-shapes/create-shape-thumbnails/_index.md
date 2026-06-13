---
title: PHP에서 프레젠테이션 모양의 썸네일 만들기
linktitle: 모양 썸네일
type: docs
weight: 70
url: /ko/php-java/create-shape-thumbnails/
keywords:
- 모양 썸네일
- 모양 이미지
- 모양 렌더링
- 모양 렌더링
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용해 PowerPoint 슬라이드에서 고품질 모양 썸네일을 생성하고, 프레젠테이션 썸네일을 손쉽게 만들고 내보냅니다."
---
## **소개**

Aspose.Slides는 각 페이지가 슬라이드인 프레젠테이션 파일을 만드는 데 사용됩니다. 이러한 슬라이드는 Microsoft PowerPoint를 사용하여 프레젠테이션 파일을 열어 볼 수 있습니다. 하지만 때때로 개발자는 모양의 이미지를 별도의 이미지 뷰어에서 별도로 보고 싶을 수 있습니다. 이러한 경우 Aspose.Slides는 슬라이드 모양의 썸네일 이미지를 생성하도록 도와줍니다. 이 기능을 사용하는 방법은 이 문서에 설명되어 있습니다.  
이 문서는 슬라이드 썸네일을 다양한 방법으로 생성하는 방법을 설명합니다:

- 슬라이드 내부에서 모양 썸네일 생성
- 사용자 정의 크기로 슬라이드 모양의 모양 썸네일 생성
- 모양 표시 경계 내에서 모양 썸네일 생성

## **슬라이드에서 모양 썸네일 생성**

PHP용 Aspose.Slides for Java를 사용하여任意 슬라이드에서 모양 썸네일을 생성하려면 다음을 수행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. ID 또는 인덱스를 사용하여 임의의 슬라이드 참조를 가져옵니다.
3. 기본 스케일에서 참조된 슬라이드의 모양 썸네일 이미지를 [Get the shape thumbnail image](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getImage)합니다.
4. 선호하는 이미지 형식으로 썸네일 이미지를 저장합니다.

다음 샘플 코드는 슬라이드에서 모양 썸네일을 생성하는 방법을 보여줍니다:

```php
  # 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 전체 비율 이미지 생성
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # 이미지를 PNG 형식으로 디스크에 저장합니다
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **사용자 정의 스케일링 팩터 썸네일 생성**

PHP용 Aspose.Slides for Java를 사용하여 슬라이드의 모양 썸네일을 생성하려면 다음을 수행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. ID 또는 인덱스를 사용하여 임의의 슬라이드 참조를 가져옵니다.
3. 사용자 정의 차원으로 참조된 슬라이드의 모양 썸네일 이미지를 [Get the shape thumbnail image](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getImage)합니다.
4. 선호하는 이미지 형식으로 썸네일 이미지를 저장합니다.

다음 샘플 코드는 정의된 스케일링 팩터를 기준으로 모양 썸네일을 생성하는 방법을 보여줍니다:

```php
  # 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 전체 비율 이미지를 생성합니다
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # 이미지를 PNG 형식으로 디스크에 저장합니다
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **경계 기반 모양 표시 썸네일 생성**

이러한 모양 썸네일 생성 방법을 통해 개발자는 모양 표시 경계 내에서 썸네일을 생성할 수 있습니다. 여기에는 모든 모양 효과가 반영됩니다. 생성된 모양 썸네일은 슬라이드 경계에 제한됩니다. 슬라이드 모양을 표시 경계 내에서 썸네일로 생성하려면 다음을 수행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. ID 또는 인덱스를 사용하여 임의의 슬라이드 참조를 가져옵니다.
3. 모양 경계를 표시로 사용하여 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
4. 선호하는 이미지 형식으로 썸네일 이미지를 저장합니다.

다음 샘플 코드는 위 단계들을 기반으로 합니다:

```php
  # 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 전체 비율 이미지를 생성합니다
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # 이미지를 PNG 형식으로 디스크에 저장합니다
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **자주 묻는 질문**

**모양 썸네일을 저장할 때 사용할 수 있는 이미지 형식은 무엇입니까?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imageformat/), 및 기타 형식. 또한 모양의 내용을 SVG로 저장하여 [벡터 SVG로 내보낼 수 있습니다](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/writeassvg/).

**썸네일을 렌더링할 때 Shape 경계와 Appearance 경계의 차이점은 무엇입니까?**

`Shape`는 모양의 기하학을 사용하고; `Appearance`는 [시각 효과](/slides/ko/php-java/shape-effect/) (그림자, 발광 등)을 고려합니다.

**모양이 숨김으로 표시되면 어떻게 됩니까? 썸네일에 여전히 렌더링됩니까?**

숨겨진 모양은 모델의 일부로 남아 있으며 렌더링될 수 있습니다. 숨김 플래그는 슬라이드 쇼 표시에는 영향을 주지만 모양 이미지를 생성하는 것을 방해하지는 않습니다.

**그룹 모양, 차트, SmartArt 및 기타 복잡한 객체가 지원됩니까?**

예. [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/)으로 표현되는 모든 객체( [GroupShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/), [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/) 포함)는 썸네일이나 SVG로 저장할 수 있습니다.

**시스템에 설치된 글꼴이 텍스트 모양의 썸네일 품질에 영향을 줍니까?**

예. 원하지 않는 폰트 대체 및 텍스트 재배치를 방지하려면 [필요한 글꼴을 제공](/slides/ko/php-java/custom-font/)하거나 [글꼴 대체를 구성](/slides/ko/php-java/font-substitution/)해야 합니다.