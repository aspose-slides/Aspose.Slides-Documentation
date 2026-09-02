---
title: PHP를 사용한 프레젠테이션 형태 썸네일 생성
linktitle: 형태 썸네일
type: docs
weight: 70
url: /ko/php-java/create-shape-thumbnails/
keywords:
- 형태 썸네일
- 형태 이미지
- 형태 렌더링
- 형태 렌더링
- 시각적 경계
- 형태 경계
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 슬라이드에서 고품질 형태 썸네일을 생성하고, 프레젠테이션 썸네일을 손쉽게 만들고 내보낼 수 있습니다."
---
## **Introduction**

Aspose.Slides는 각 페이지가 슬라이드인 프레젠테이션 파일을 만드는 데 사용됩니다. 이러한 슬라이드는 Microsoft PowerPoint로 프레젠테이션 파일을 열어 볼 수 있습니다. 그러나 때때로 개발자는 형태의 이미지를 이미지 뷰어에서 별도로 보고 싶을 수 있습니다. 이러한 경우 Aspose.Slides는 슬라이드 형태의 썸네일 이미지를 생성하도록 도와줍니다. 이 기능을 사용하는 방법은 이 문서에 설명되어 있습니다.

이 문서에서는 다양한 방법으로 슬라이드 썸네일을 생성하는 방법을 설명합니다:

- 슬라이드 내부에서 형태 썸네일 생성
- 사용자 정의 차원으로 슬라이드 형태의 썸네일 생성
- 형태 외관 경계 내에서 형태 썸네일 생성

## **Generate a Shape Thumbnail from a Slide**

Aspose.Slides for PHP via Java를 사용하여 임의의 슬라이드에서 형태 썸네일을 생성하려면 다음을 수행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스를 사용하여 원하는 슬라이드의 참조를 가져옵니다.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getImage)을 기본 스케일로 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```php
  # Presentation 클래스를 인스턴스화하여 프레젠테이션 파일을 나타냅니다
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 전체 스케일 이미지 생성
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # 이미지를 PNG 형식으로 디스크에 저장
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

## **Generate a User-Defined Scaling Factor Thumbnail**

Aspose.Slides for PHP via Java를 사용하여 슬라이드의 형태 썸네일을 생성하려면 다음을 수행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스를 사용하여 원하는 슬라이드의 참조를 가져옵니다.
1. 사용자 정의 차원으로 참조된 슬라이드의 형태 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```php
  # 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 전체 스케일 이미지를 생성합니다
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

## **Create a Bounds-Based Shape Appearance Thumbnail**

이 방법은 개발자가 형태 외관의 경계 내에서 썸네일을 생성할 수 있게 해줍니다. 모든 형태 효과를 고려합니다. 생성된 형태 썸네일은 슬라이드 경계에 제한됩니다. 형태 외관 경계 내에서 슬라이드 형태의 썸네일을 생성하려면 다음을 수행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스를 사용하여 원하는 슬라이드의 참조를 가져옵니다.
1. 형태 경계를 외관으로 사용하여 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```php
  # 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 전체 스케일 이미지를 생성합니다
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

## **Get the Actual Visual Bounds of a Shape**

[Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/)의 프레임 속성—`Shape::getX()`, `Shape::getY()`, `Shape::getWidth()`, `Shape::getHeight()`—은 프레젠테이션 모델에 저장된 사각형을 설명합니다. 실제로 렌더링되는 내용은 해당 프레임을 넘어 확장되거나 다른 축에 정렬된 사각형을 차지할 수 있습니다. 회전, 외곽선, 화살표 머리, 텍스트 레이아웃 및 오버플로우, 생성된 SmartArt 기하학 및 기타 렌더링 효과가 차지하는 영역을 모두 변경할 수 있습니다.

[Shape::getVisualBounds](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getVisualBounds)를 사용하면 이미지를 생성하지 않고도 차지하는 영역을 계산할 수 있습니다. 이 메서드는 슬라이드 좌표계의 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) 객체를 반환합니다. 반환된 사각형은 슬라이드에 클립되지 않으므로 내용이 슬라이드 원점을 넘어설 경우 좌표가 음수가 될 수 있습니다.

다음 예제는 프레임과 시각적 경계를 가져와 비교합니다:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

같은 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html)을 사용하여 인접한 형태를 왼쪽, 오른쪽, 위 또는 아래 가장자리와 정렬하고, 생성된 레이아웃에서 충분한 공간을 확보하거나 허용된 영역 밖의 내용을 감지할 수 있습니다. 시각적 경계는 저장된 프레임이 전체 렌더링 결과를 나타내지 않을 수 있는 SmartArt, 텍스트 상자, 화살표, 그림, 회전된 형태 및 그룹 형태에 특히 유용합니다.

레이아웃이나 검증을 위해 좌표가 필요하고 비트맵이 필요하지 않을 때는 [Shape::getVisualBounds](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getVisualBounds)를 사용합니다. 형태를 렌더링해야 할 때는 [Shape::getImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getImage)를 사용합니다. [ShapeThumbnailBounds](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapethumbnailbounds/)를 사용하면 `ShapeThumbnailBounds::Shape`가 외곽선 설정을 포함한 형태 경계에서 이미지를 크기 조정하고, `ShapeThumbnailBounds::Appearance`는 형태 외관에서 이미지를 크기 조정하며 결과를 슬라이드 경계에 제한합니다. 반면에 `Shape::getVisualBounds`는 계산된 사각형만 반환하고 슬라이드에 클립하지 않습니다.

## **FAQ**

**What image formats can be used when saving shape thumbnails?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imageformat/), 및 기타 형식. 형태는 [exported as vector SVG](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/writeassvg/)로 저장하여 SVG 벡터 형식으로 내보낼 수도 있습니다.

**What is the difference between Shape and Appearance bounds when rendering a thumbnail?**  
`Shape`는 형태의 기하학을 사용하고, `Appearance`는 [visual effects](/slides/ko/php-java/shape-effect/) (그림자, 광채 등)을 고려합니다.

**What happens if a shape is marked as hidden? Will it still render as a thumbnail?**  
숨김 처리된 형태는 모델의 일부로 남아 있으며 렌더링될 수 있습니다. 숨김 플래그는 슬라이드 쇼 표시에는 영향을 주지만 형태 이미지 생성에는 방해하지 않습니다.

**Are group shapes, charts, SmartArt, and other complex objects supported?**  
예. [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/)로 표현되는 모든 객체(예: [GroupShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/), [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/))는 썸네일이나 SVG로 저장할 수 있습니다.

**Do system-installed fonts affect the quality of thumbnails for text shapes?**  
예. 원하지 않는 폰트 대체 및 텍스트 재배치를 방지하려면 [required fonts](/slides/ko/php-java/custom-font/)를 제공하거나 [font substitutions](/slides/ko/php-java/font-substitution/)를 구성해야 합니다.