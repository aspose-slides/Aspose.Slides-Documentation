---
title: PHP에서 PPT 및 PPTX를 JPG로 변환
linktitle: PowerPoint를 JPG로
type: docs
weight: 60
url: /ko/php-java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 JPG로
- 프레젠테이션을 JPG로
- 슬라이드를 JPG로
- PPT를 JPG로
- PPTX를 JPG로
- PowerPoint를 JPG로 저장
- 프레젠테이션을 JPG로 저장
- 슬라이드를 JPG로 저장
- PPT를 JPG로 저장
- PPTX를 JPG로 저장
- PPT를 JPG로 내보내기
- PPTX를 JPG로 내보내기
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP를 사용하여 PHP에서 PowerPoint(PPT, PPTX) 슬라이드를 고품질 JPG 이미지로 변환하는 빠르고 신뢰할 수 있는 코드 예제."
---
## **소개**

PowerPoint 및 OpenDocument 프레젠테이션을 JPG 이미지로 변환하면 슬라이드 공유, 성능 최적화 및 웹사이트나 애플리케이션에 콘텐츠를 삽입하는 데 도움이 됩니다. Aspose.Slides를 사용하면 PPTX, PPT 및 ODP 파일을 고품질 JPEG 이미지로 변환할 수 있습니다. 이 가이드에서는 변환을 위한 다양한 방법을 설명합니다.

이러한 기능을 통해 자체 프레젠테이션 뷰어를 구현하고 각 슬라이드에 대한 썸네일을 쉽게 만들 수 있습니다. 프레젠테이션 슬라이드를 복사로부터 보호하거나 읽기 전용 모드로 시연하려는 경우에 유용합니다. Aspose.Slides는 전체 프레젠테이션 또는 특정 슬라이드를 이미지 형식으로 변환할 수 있도록 합니다.

## **PowerPoint PPT/PPTX를 JPG로 변환**

다음은 PPT/PPTX를 JPG로 변환하는 단계입니다:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 유형의 인스턴스를 생성합니다.
2. [Presentation::getSlides()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation#getSlides--) 컬렉션에서 [Slide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/) 유형의 슬라이드 객체를 가져옵니다.
3. 각 슬라이드의 썸네일을 만든 다음 JPG로 변환합니다. 슬라이드의 썸네일을 얻기 위해 [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/#getImage) 메서드를 사용합니다. [getImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/#getImage) 메서드는 필요한 [Slide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/) 객체에서 호출해야 하며, 결과 썸네일의 스케일 값을 메서드에 전달합니다.
4. 슬라이드 썸네일을 얻은 후 썸네일 객체에서 [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) 메서드를 호출합니다. 결과 파일 이름과 이미지 형식을 전달합니다.

{{% alert color="primary" %}}

**Note**: PPT/PPTX를 JPG로 변환하는 방식은 Aspose.Slides API에서 다른 형식으로 변환하는 방식과 다릅니다. 다른 형식의 경우 보통 [**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/save/) 메서드를 사용하지만, 여기서는 [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) 메서드를 사용해야 합니다.

{{% /alert %}} 

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # 전체 스케일 이미지를 생성합니다
      $slideImage = $sld->getImage(1.0, 1.0);
      # 이미지를 디스크에 JPEG 형식으로 저장합니다
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **사용자 지정 크기로 PowerPoint PPT/PPTX를 JPG로 변환**
결과 썸네일 및 JPG 이미지의 크기를 변경하려면 [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/#getImage) 메서드에 *ScaleX* 및 *ScaleY* 값을 전달하면 됩니다.

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # 크기를 정의합니다
    $desiredX = 1200;
    $desiredY = 800;
    # X와 Y의 스케일 값을 가져옵니다
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # 전체 스케일 이미지를 생성합니다
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # 이미지를 디스크에 JPEG 형식으로 저장합니다
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **슬라이드를 이미지로 저장할 때 주석 렌더링**
Aspose.Slides for PHP via Java는 슬라이드를 이미지로 변환할 때 프레젠테이션 슬라이드에 포함된 주석을 렌더링할 수 있는 기능을 제공합니다. 아래 PHP 코드는 해당 작업을 보여줍니다:

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}

Aspose는 [FREE Collage 웹 앱](https://products.aspose.app/slides/ko/collage)를 제공합니다. 이 온라인 서비스를 사용하면 [JPG to JPG](https://products.aspose.app/slides/ko/collage/jpg) 또는 PNG to PNG 이미지를 병합하고, [photo grids](https://products.aspose.app/slides/ko/collage/photo-grid)를 만들 수 있습니다.

이 문서에 설명된 동일한 원리를 사용하면 이미지를 한 형식에서 다른 형식으로 변환할 수 있습니다. 자세한 내용은 다음 페이지를 참고하십시오: 변환 [image to JPG](https://products.aspose.com/slides/ko/php-java/conversion/image-to-jpg/); 변환 [JPG to image](https://products.aspose.com/slides/ko/php-java/conversion/jpg-to-image/); 변환 [JPG to PNG](https://products.aspose.com/slides/ko/php-java/conversion/jpg-to-png/), 변환 [PNG to JPG](https://products.aspose.com/slides/ko/php-java/conversion/png-to-jpg/); 변환 [PNG to SVG](https://products.aspose.com/slides/ko/php-java/conversion/png-to-svg/), 변환 [SVG to PNG](https://products.aspose.com/slides/ko/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**이 방법이 배치 변환을 지원합니까?**

네, Aspose.Slides를 사용하면 여러 슬라이드를 한 번에 JPG로 배치 변환할 수 있습니다.

**변환이 SmartArt, 차트 및 기타 복합 객체를 지원합니까?**

네, Aspose.Slides는 SmartArt, 차트, 표, 도형 등 모든 콘텐츠를 렌더링합니다. 다만, 사용자 지정 폰트나 누락된 폰트를 사용할 경우 PowerPoint와 비교해 약간의 정확도 차이가 발생할 수 있습니다.

**처리할 수 있는 슬라이드 수에 제한이 있습니까?**

Aspose.Slides 자체에는 슬라이드 수에 대한 엄격한 제한이 없습니다. 그러나 큰 프레젠테이션이나 고해상도 이미지를 다룰 경우 메모리 부족 오류가 발생할 수 있습니다.

## **관련 항목**

다음과 같이 PPT/PPTX를 이미지로 변환하는 다른 옵션을 확인하세요:

- [PPT/PPTX to SVG conversion](/slides/ko/php-java/render-a-slide-as-an-svg-image/).