---
title: PHP를 사용하여 프레젠테이션에서 그림 프레임 관리
linktitle: 그림 프레임
type: docs
weight: 10
url: /ko/php-java/picture-frame/
keywords:
- 그림 프레임
- 그림 프레임 추가
- 그림 프레임 만들기
- 이미지 추가
- 이미지 만들기
- 이미지 추출
- 래스터 이미지
- 벡터 이미지
- 이미지 자르기
- 잘린 영역
- StretchOff 속성
- 그림 프레임 서식 지정
- 그림 프레임 속성
- 상대 스케일
- 이미지 효과
- 가로세로 비율
- 이미지 투명도
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 그림 프레임을 추가합니다. 작업 흐름을 간소화하고 슬라이드 디자인을 향상시킵니다."
---
## **소개**

그림 프레임은 이미지를 포함하는 도형으로, 프레임에 들어간 사진과 같습니다.  

그림 프레임을 통해 슬라이드에 이미지를 추가할 수 있습니다. 이렇게 하면 그림 프레임을 서식 지정함으로써 이미지를 서식 지정할 수 있습니다.

{{% alert  title="Tip" color="primary" %}} 

Aspose는 무료 컨버터—[JPEG to PowerPoint](https://products.aspose.app/slides/ko/import/jpg-to-ppt) 및 [PNG to PowerPoint](https://products.aspose.app/slides/ko/import/png-to-ppt)—를 제공하여 이미지로부터 프레젠테이션을 빠르게 만들 수 있도록 합니다. 

{{% /alert %}} 

## **그림 프레임 만들기**

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 프레젠테이션 객체와 연결된 [ImageCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagecollection/)에 이미지를 추가하여 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/) 객체를 생성합니다.  
4. 이미지의 너비와 높이를 지정합니다.  
5. 참조된 슬라이드와 연결된 shape 객체가 제공하는 `addPictureFrame` 메서드를 사용하여 이미지의 너비와 높이를 기반으로 [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)을 생성합니다.  
6. 슬라이드에 그림 프레임(그림 포함)을 추가합니다.  
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

이 PHP 코드는 그림 프레임을 만드는 방법을 보여줍니다:

```php
  # PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드를 가져옵니다
    $sld = $pres->getSlides()->get_Item(0);
    # Image 클래스를 인스턴스화합니다
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 그림의 동일한 높이와 너비로 그림 프레임을 추가합니다
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # PPTX 파일을 디스크에 저장합니다
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

그림 프레임을 사용하면 이미지를 기반으로 프레젠테이션 슬라이드를 빠르게 만들 수 있습니다. 그림 프레임을 Aspose.Slides 저장 옵션과 결합하면 입력/출력 작업을 조작하여 이미지를 한 형식에서 다른 형식으로 변환할 수 있습니다. 다음 페이지도 확인해 보세요: [image to JPG](https://products.aspose.com/slides/ko/php-java/conversion/image-to-jpg/) 변환; [JPG to image](https://products.aspose.com/slides/ko/php-java/conversion/jpg-to-image/) 변환; [JPG to PNG](https://products.aspose.com/slides/ko/php-java/conversion/jpg-to-png/) 변환; [PNG to JPG](https://products.aspose.com/slides/ko/php-java/conversion/png-to-jpg/) 변환; [PNG to SVG](https://products.aspose.com/slides/ko/php-java/conversion/png-to-svg/) 변환; [SVG to PNG](https://products.aspose.com/slides/ko/php-java/conversion/svg-to-png/) 변환. 

{{% /alert %}}

## **상대 스케일을 이용한 그림 프레임 만들기**

이미지의 상대 스케일을 조정하면 보다 복잡한 그림 프레임을 만들 수 있습니다.  

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 프레젠테이션 이미지 컬렉션에 이미지를 추가합니다.  
4. 프레젠테이션 객체와 연결된 [ImageCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagecollection/)에 이미지를 추가하여 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/) 객체를 생성합니다.  
5. 그림 프레임에서 이미지의 상대 너비와 높이를 지정합니다.  
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

이 PHP 코드는 상대 스케일을 적용한 그림 프레임을 만드는 방법을 보여줍니다:

```php
  # PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드를 가져옵니다
    $sld = $pres->getSlides()->get_Item(0);
    # Image 클래스를 인스턴스화합니다
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 그림과 동일한 높이와 너비로 그림 프레임을 추가합니다
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # 상대 스케일 높이와 너비를 설정합니다
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # PPTX 파일을 디스크에 저장합니다
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **그림 프레임에서 래스터 이미지 추출**

[PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/) 객체에서 래스터 이미지를 추출하여 PNG, JPG 등 다양한 형식으로 저장할 수 있습니다. 아래 코드 예제는 문서 “sample.pptx”에서 이미지를 추출하고 PNG 형식으로 저장하는 방법을 보여줍니다.

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **그림 프레임에서 SVG 이미지 추출**

프레젠테이션에 [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/) 도형 안에 SVG 그래픽이 포함된 경우, Aspose.Slides for PHP via Java를 사용하면 원본 벡터 이미지를 온전하게 가져올 수 있습니다. 슬라이드의 shape 컬렉션을 순회하면서 각 [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)을 확인하고, 해당 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)가 SVG 내용을 포함하는지 검사한 뒤, SVG 형식으로 디스크나 스트림에 저장할 수 있습니다.

다음 코드 예제는 그림 프레임에서 SVG 이미지를 추출하는 방법을 보여줍니다:

```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **이미지 투명도 가져오기**

Aspose.Slides를 사용하면 이미지에 적용된 투명도 효과를 가져올 수 있습니다. 이 PHP 코드는 해당 작업을 시연합니다:

```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **그림 프레임 서식 지정**

Aspose.Slides는 그림 프레임에 적용할 수 있는 다양한 서식 옵션을 제공합니다. 이러한 옵션을 사용하여 특정 요구 사항에 맞게 그림 프레임을 조정할 수 있습니다.  

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 프레젠테이션 객체와 연결된 [ImageCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagecollection/)에 이미지를 추가하여 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/) 객체를 생성합니다.  
4. 이미지의 너비와 높이를 지정합니다.  
5. 참조된 슬라이드와 연결된 [ShapeCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/) 객체가 제공하는 [addPictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addpictureframe/) 메서드를 사용하여 이미지의 너비와 높이를 기반으로 `PictureFrame`을 생성합니다.  
6. 슬라이드에 그림 프레임(그림 포함)을 추가합니다.  
7. 그림 프레임의 선 색상을 설정합니다.  
8. 그림 프레임의 선 두께를 설정합니다.  
9. 양수 또는 음수 값을 지정하여 그림 프레임을 회전합니다.  
   * 양수 값은 이미지를 시계 방향으로 회전시킵니다.  
   * 음수 값은 이미지를 반시계 방향으로 회전시킵니다.  
10. 그림 프레임(그림 포함)을 슬라이드에 다시 추가합니다.  
11. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

이 PHP 코드는 그림 프레임 서식 지정 과정을 시연합니다:

```php
  # PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드를 가져옵니다
    $sld = $pres->getSlides()->get_Item(0);
    # Image 클래스를 인스턴스화합니다
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 그림과 동일한 높이와 너비로 그림 프레임을 추가합니다
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # PictureFrameEx에 일부 서식을 적용합니다
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # PPTX 파일을 디스크에 저장합니다
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}

Aspose는 최근에 무료 Collage Maker([https://products.aspose.app/slides/ko/collage](https://products.aspose.app/slides/ko/collage))를 출시했습니다. JPG/JPEG([https://products.aspose.app/slides/ko/collage/jpg](https://products.aspose.app/slides/ko/collage/jpg)) 또는 PNG 이미지를 병합하거나([https://products.aspose.app/slides/ko/collage/photo-grid](https://products.aspose.app/slides/ko/collage/photo-grid)) 사진으로 그리드를 만들고 싶을 때 이 서비스를 활용할 수 있습니다. 

{{% /alert %}}

## **이미지를 링크로 추가하기**

프레젠테이션 파일 크기를 줄이려면 파일을 직접 포함하는 대신 링크를 통해 이미지(또는 비디오)를 추가할 수 있습니다. 이 PHP 코드는 자리표시자에 이미지와 비디오를 추가하는 방법을 보여줍니다:

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **이미지 자르기**

이 PHP 코드는 슬라이드에 있는 기존 이미지를 자르는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  # 새로운 이미지 객체를 생성합니다
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 슬라이드에 PictureFrame을 추가합니다
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # 이미지 잘라내기 (퍼센트 값)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # 결과를 저장합니다
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **그림 프레임의 잘린 영역 삭제**

프레임에 포함된 이미지의 잘린 영역을 삭제하려면 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 메서드를 사용할 수 있습니다. 이 메서드는 잘린 이미지를 반환하거나, 잘라야 할 필요가 없는 경우 원본 이미지를 반환합니다.  

이 PHP 코드는 해당 작업을 시연합니다:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 첫 번째 슬라이드에서 PictureFrame을 가져옵니다
    $picFrame = $slide->getShapes()->get_Item(0);
    # PictureFrame 이미지의 잘린 영역을 삭제하고 잘린 이미지를 반환합니다
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # 결과를 저장합니다
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 메서드는 잘린 이미지를 프레젠테이션 이미지 컬렉션에 추가합니다. 해당 이미지가 처리된 [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)에만 사용된다면 프레젠테이션 크기를 줄일 수 있습니다. 그렇지 않으면 최종 프레젠테이션의 이미지 수가 증가합니다.  

이 메서드는 크롭 작업 중 WMF/EMF 메타파일을 래스터 PNG 이미지로 변환합니다. 

{{% /alert %}}

## **이미지 압축**

[PictureFillFormat::compressImage()](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) 메서드를 사용하면 프레젠테이션 내 그림을 압축할 수 있습니다. 이 메서드는 도형 크기와 지정된 해상도를 기준으로 이미지 크기를 줄이며, 필요에 따라 잘린 영역을 삭제할 수 있는 옵션을 제공합니다.  

PowerPoint의 **Picture Format → Compress Pictures → Resolution** 기능과 동일하게 그림의 크기와 해상도를 조정합니다.  

다음 PHP 예제는 목표 해상도를 지정하고 선택적으로 잘린 영역을 제거하여 프레젠테이션의 이미지를 압축하는 방법을 보여줍니다:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # 목표 해상도 150 DPI(웹 해상도)로 이미지를 압축하고 잘린 영역을 삭제합니다.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # 압축 결과를 확인합니다.
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

또는 직접 사용자 정의 DPI 값을 사용하는 경우:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # 이미지를 150 DPI(웹 해상도)로 압축하고 잘린 영역을 삭제합니다.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

이 메서드는 도형 크기와 제공된 DPI를 기준으로 이미지를 낮은 해상도로 변환합니다. 파일 크기를 최적화하기 위해 잘린 영역도 삭제될 수 있습니다.  
이미지가 메타파일(WMF/EMF)이나 SVG인 경우 압축이 적용되지 않습니다. 또한 JPEG 품질은 해상도에 따라 보존되거나 약간 감소합니다. 이는 PowerPoint가 고해상도 JPEG를 처리하는 방식과 유사합니다. 

{{% /alert %}}

## **가로세로 비율 고정**

이미지를 교체하거나 크기를 변경한 후에도 이미지가 포함된 도형이 가로세로 비율을 유지하도록 하려면 [setAspectRatioLocked](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) 메서드를 사용하여 *Lock Aspect Ratio* 설정을 활성화합니다.  

이 PHP 코드는 도형의 가로세로 비율을 고정하는 방법을 보여줍니다:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # 크기 조정 시 가로세로 비율을 유지하도록 도형을 설정합니다
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 

*Lock Aspect Ratio* 설정은 도형 자체의 비율만 유지하고, 포함된 이미지의 비율은 유지하지 않습니다. 

{{% /alert %}}

## **StretchOff 속성 사용**

[PictureFillFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillformat/) 클래스의 [setStretchOffsetLeft](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) 및 [setStretchOffsetBottom](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) 메서드를 사용하여 채우기 사각형을 지정할 수 있습니다.  

이미지에 대한 스트레칭이 지정되면 소스 사각형이 지정된 채우기 사각형에 맞게 스케일링됩니다. 채우기 사각형의 각 가장자리는 도형 경계 상자의 해당 가장자리로부터 백분율 오프셋으로 정의됩니다. 양의 백분율은 안쪽 여백을, 음의 백분율은 바깥쪽 여백을 의미합니다.  

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. `AutoShape` 사각형을 추가합니다.  
4. 이미지를 생성합니다.  
5. 도형의 채우기 유형을 설정합니다.  
6. 도형의 그림 채우기 모드를 설정합니다.  
7. 도형을 채우기 위한 이미지를 추가합니다.  
8. 도형 경계 상자의 해당 가장자리로부터 이미지 오프셋을 지정합니다.  
9. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

이 PHP 코드는 StretchOff 속성을 사용하는 과정을 시연합니다:

```php
  # PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드를 가져옵니다
    $slide = $pres->getSlides()->get_Item(0);
    # ImageEx 클래스를 인스턴스화합니다
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Rectangle로 설정된 AutoShape을 추가합니다
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # 도형의 채우기 유형을 설정합니다
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # 도형의 그림 채우기 모드를 설정합니다
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # 이미지를 도형에 채우도록 설정합니다
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # 도형 경계 상자의 해당 가장자리로부터 이미지 오프셋을 지정합니다
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # PPTX 파일을 디스크에 저장합니다
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**그림 프레임에서 지원되는 이미지 형식은 어떻게 확인할 수 있나요?**  

Aspose.Slides는 래스터 이미지(PNG, JPEG, BMP, GIF 등)와 벡터 이미지(SVG 등)를 [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)에 할당된 이미지 객체를 통해 지원합니다. 지원되는 형식 목록은 슬라이드 및 이미지 변환 엔진의 기능과 대체로 일치합니다.  

**수십 개의 대용량 이미지를 추가하면 PPTX 크기와 성능에 어떤 영향을 미치나요?**  

대용량 이미지를 임베드하면 파일 크기와 메모리 사용량이 증가합니다. 이미지를 링크로 추가하면 프레젠테이션 크기를 낮게 유지할 수 있지만 외부 파일이 계속 접근 가능해야 합니다. Aspose.Slides는 파일 크기를 줄이기 위해 링크 방식으로 이미지를 추가하는 기능을 제공합니다.  

**이미지 객체가 실수로 이동하거나 크기가 조정되는 것을 방지하려면 어떻게 해야 하나요?**  

[PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)에 대해 [shape locks](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/getpictureframelock/)를 사용하면 이동이나 크기 조정을 비활성화하는 등 다양한 잠금 옵션을 적용할 수 있습니다. 이러한 잠금 메커니즘은 다양한 도형 유형에 대해 지원됩니다.  

**SVG 벡터 정확도가 PDF/이미지로 내보낼 때 유지되나요?**  

Aspose.Slides는 [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)에서 SVG를 원본 벡터 형태로 추출할 수 있게 합니다. [PDF로 내보내기](/slides/ko/php-java/convert-powerpoint-to-pdf/) 또는 [래스터 형식으로 내보내기](/slides/ko/php-java/convert-powerpoint-to-png/) 시, 내보내기 설정에 따라 결과가 래스터화될 수 있지만, 원본 SVG가 벡터로 저장된 사실은 추출 동작을 통해 확인할 수 있습니다.