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
- 임베디드 이미지
- 연결된 이미지
- 이미지 추출
- 래스터 이미지
- SVG 이미지
- 이미지 자르기
- 잘린 영역 삭제
- 이미지 압축
- StretchOffset
- 그림 프레임 서식
- 상대 스케일
- 이미지 효과
- 종횡비
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 프레젠테이션에서 그림 프레임을 만들고, 서식 지정하고, 연결하고, 자르고, 추출하고, 압축합니다."
---
## **Overview**

그림 프레임은 이미지를 표시하는 슬라이드 도형입니다. Aspose.Slides에서 이미지 리소스와 이를 표시하는 도형은 별개의 객체이며, [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/)은 [ImageCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagecollection/)을 통해 포함된 이미지 리소스를 소유하고, [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)은 이미지의 위치, 크기, 선 서식, 회전, 자르기, 그림 효과 및 기타 프레임 수준 설정을 제어합니다.

같은 이미지를 여러 번 표시해야 할 때 이 구분이 유용합니다. 이미지를 프레젠테이션에 한 번 추가하고 반환된 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)를 유지한 후 그림 프레임을 만들 때 해당 이미지 리소스를 사용합니다.

그림 프레임은 PNG 또는 JPEG와 같은 래스터 이미지와 SVG와 같은 벡터 이미지를 포함할 수 있습니다. 또한 프레젠테이션에 이미지 바이트를 저장하지 않고 연결된 이미지를 참조할 수도 있습니다. 선택은 이동성, 파일 크기, 추출 및 내보내기 동작에 영향을 미치므로 서식 지정이나 최적화를 적용하기 전에 이미지 저장 방식을 결정하는 것이 좋습니다.

## **Add and Format an Embedded Image**

임베디드 이미지의 경우 이미지 데이터를 프레젠테이션에 추가하고 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addpictureframe/)을 사용해 그림 프레임을 만듭니다. 이미지가 프레젠테이션 패키지의 일부가 되므로 프레젠테이션을 다른 컴퓨터로 이동해도 자체 포함됩니다.

다음 예제는 JPEG 이미지를 추가하고 이미지의 원래 크기로 프레임을 만들며 선 서식과 회전을 적용합니다:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

그림 프레임은 표시되는 기하학을 제어합니다. 프레임 크기를 변경해도 임베디드 이미지 리소스에 저장된 원본 픽셀 치수는 변경되지 않습니다. 이 구분은 나중에 이미지를 자르거나 압축할 때 중요합니다.

## **Use Relative Scale**

[PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)은 [setRelativeScaleWidth](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/setrelativescalewidth/) 및 [setRelativeScaleHeight](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/setrelativescaleheight/)를 통해 프레임의 상대적인 너비와 높이 스케일을 노출합니다. 값이 `1.0`이면 원본 그림 크기의 100%에 해당합니다. 상대 스케일은 최종 치수를 수동으로 계산하지 않고 원본 이미지 크기와의 비율을 유지해야 하는 워크플로에 유용합니다.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

상대 스케일은 프레임의 스케일 설정만 변경하며, 임베디드 이미지를 다시 샘플링하거나 압축하지는 않습니다.

## **Embedded and Linked Images**

임베디드 그림은 이미지 데이터를 프레젠테이션 내부에 저장하므로 이동성과 예측 가능한 렌더링 측면에서 가장 안전한 선택입니다. 연결된 그림은 [Picture::setLinkPathLong](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picture/setlinkpathlong/) 메서드를 통해 외부 위치를 저장하므로 동일한 방식으로 이미지 데이터를 임베드하지 않습니다.

연결된 이미지는 PPTX에 저장되는 이미지 데이터를 줄일 수 있지만 외부 종속성을 도입합니다. 연결된 파일은 프레젠테이션을 열거나 렌더링하는 응용 프로그램이 계속 접근할 수 있어야 합니다. 경로가 변경되거나 파일이 이동되거나 리소스를 사용할 수 없게 되면 연결된 그림이 기대대로 표시되지 않을 수 있습니다. 이메일로 전송하거나 보관하거나 격리된 환경에서 렌더링해야 하는 프레젠테이션에는 일반적으로 임베디드 이미지가 더 신뢰됩니다.

### **Add a Linked Image**

다음 예제는 그림 프레임을 만들고 로컬 이미지 파일을 가리키도록 설정합니다. 이 예제는 이미지 연결만을 다루며 비디오 연결은 별도의 미디어 워크플로이며 의도적으로 혼합되지 않았습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

외부 파일 관리를 의도한 경우에만 링크를 사용하십시오. 압축을 대체하기 위해 사용하지 마십시오. 깨진 이미지 종속성을 가진 작은 PPTX는 자체 포함된 큰 프레젠테이션보다 보통 덜 유용합니다.

## **Extract Images from Picture Frames**

기존 프레젠테이션에서 이미지를 추출하기 전에 도형이 실제로 [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)인지, 그리고 임베디드 이미지를 포함하고 있는지 확인하십시오. 연결된 그림 프레임은 같은 방식으로 추출할 수 있는 이미지 바이트를 포함하지 않을 수 있습니다.

### **Extract a Raster Image**

최신 이미지 API는 [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/)을 직접 사용합니다. 다음 예제는 슬라이드에서 첫 번째 임베디드 래스터 그림을 찾아 PNG로 저장합니다:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

[IImage::save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/#save)를 통해 저장하면 추출된 이미지를 요청된 출력 형식으로 변환합니다. 프레젠테이션에 저장된 인코딩된 바이트가 필요하고 변환된 래스터 파일이 필요하지 않은 경우 이미지 리소스의 바이너리 데이터를 사용하십시오.

### **Extract an SVG Image**

SVG 그림의 경우 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)이 [SvgImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgimage/) 객체를 노출합니다. 이를 통해 SVG 데이터를 직접 가져올 수 있으며, 먼저 그림을 래스터화할 필요가 없습니다.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

SVG 내용을 SVG로 유지하면 프레젠테이션 내부에 벡터 소스를 보존할 수 있습니다. PNG 또는 JPEG와 같은 래스터 내보내기는 해당 벡터 내용을 픽셀로 렌더링합니다. PDF 또는 SVG 슬라이드 내보내기도 렌더링 작업이므로, 내보낸 그래픽을 원본 임베디드 SVG의 바이트 단위 복사본으로 취급해서는 안 됩니다. 원본 벡터 리소스 자체가 필요할 경우 임베디드 [SvgImage::getSvgData](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgimage/getsvgdata/) 데이터를 사용하십시오.

## **Crop an Image**

자르기는 프레임 내부에서 이미지의 어느 부분이 보일지를 변경합니다. [PictureFillFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillformat/)의 자르기 값은 원본 이미지 치수에 대한 백분율입니다. 자르기는 처음에 숨겨진 픽셀을 임베디드 이미지에서 삭제하지 않으며, 보이는 영역만 변경합니다.

다음 예제는 그림 프레임을 안전하게 찾아 자르기 값을 적용합니다:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

숨겨진 이미지 데이터가 여전히 존재하므로, 나중에 원본 픽셀을 잃지 않고 자르기 값을 변경할 수 있습니다. 파일 크기가 더 중요하고 복구 가능성이 필요 없을 경우 다음 섹션에 설명된 대로 자른 영역을 물리적으로 제거할 수 있습니다.

## **Remove Cropped Image Data**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 메서드는 현재 자르기 사각형 밖의 이미지 데이터를 제거하고 결과 이미지 리소스를 반환합니다. 이는 파일 크기를 줄일 수 있지만 파괴적인 최적화이며, 프레젠테이션을 저장한 후에는 제거된 픽셀을 나중에 복구할 수 없습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

이 메서드는 프레젠테이션에 새로운 이미지 리소스를 추가할 수 있습니다. 원본 이미지가 다른 그림 프레임에서도 사용되는 경우 해당 프레임은 기존 리소스를 계속 필요로 하므로, 자른 영역을 삭제해도 이미지 총 수가 반드시 감소하는 것은 아닙니다. WMF 또는 EMF 콘텐츠를 이 메서드로 자르면 결과가 PNG로 래스터화됩니다.

## **Compress Raster Images**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) 메서드는 그림이 표시되는 크기에 비례하여 래스터 이미지 해상도를 낮춥니다. 동일한 작업에서 자른 영역을 제거할 수도 있습니다. 이미지가 크기 조정 또는 자르기가 수행되면 `true`를 반환하고, 변경이 필요하지 않으면 `false`를 반환합니다.

표준 목표 해상도가 충분한 경우 사전 정의된 [PicturesCompression](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturescompression/) 값을 사용하십시오:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

특정 목표가 필요할 경우 사전 정의 값 대신 양수 DPI 값을 직접 전달할 수 있습니다.

압축은 래스터 이미지에만 적용됩니다. SVG 및 메타파일 콘텐츠는 이 래스터 압축 워크플로로 감소되지 않습니다. 또한 낮은 해상도와 삭제된 자른 영역은 최적화된 프레젠테이션에서 복구할 수 없다는 점을 기억하십시오. 전체적으로 가장 낮은 DPI를 적용하기보다 실제로 표시되거나 내보내질 최대 크기를 기준으로 목표 해상도를 선택하십시오.

## **Manage Image Transform Effects**

밝기, 대비, 색상 변환, 블러, 알파 효과, 정렬 체인, 검사, 제거 및 라운드트립 검증을 포함한 전체 워크플로에 대해서는 [Image Transform Effects](/php-java/image-transform-effects/)을 참조하십시오.

## **Lock Picture Frame Geometry**

[PictureFrameLock](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframelock/) 설정은 그림 프레임에 대해 어느 편집 작업이 비활성화될지를 제어합니다. 예를 들어 [setAspectRatioLocked](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframelock/setaspectratiolocked/)은 크기 조정 중에 도형의 비율을 유지합니다.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

잠금은 그림 프레임 도형에 적용됩니다. 소스 이미지를 강제로 재샘플링하거나 동일한 종횡비로 영구 변경하도록 강제하지는 않습니다.

## **Adjust the StretchOffset Values**

그림 채우기 모드가 stretch인 경우, [PictureFillFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillformat/)의 stretch‑offset 값은 그림 프레임 경계 상자에 대한 채우기 사각형을 정의합니다. 양수 백분율은 가장자리에서 안쪽으로 inset을 만들고, 음수 백분율은 바깥쪽으로 outward를 만들습니다.

이는 자르기와 다릅니다. 자르기 값은 원본 이미지의 어느 부분이 보일지를 선택하고, stretch offset은 보이는 그림 채우기가 늘어나는 사각형을 변경합니다.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

채우기 위치 지정에는 stretch offset을 사용하고, 소스 이미지 가장자리를 숨기는 것이 목표라면 자르기 속성을 사용하십시오.

## **Storage, File Size, and Export Considerations**

이미지 저장과 그림 프레임 서식을 별도로 다룰 때 주요 트레이드오프를 더 쉽게 관리할 수 있습니다:

- **Embedded images**는 프레젠테이션을 자체 포함하게 하며 공유 및 서버‑사이드 렌더링에 가장 신뢰됩니다. 그러나 큰 래스터 이미지는 PPTX 크기와 메모리 사용량을 증가시킵니다.
- **Linked images**는 패키지 크기를 줄일 수 있지만, 프레젠테이션은 지정된 경로나 위치에 외부 파일이 남아 있어야 합니다.
- **Cropping**은 초기에는 비파괴적이며, 숨겨진 픽셀은 자른 영역을 명시적으로 삭제하거나 압축 중에 제거하기 전까지 임베디드된 상태로 남아 있습니다.
- **Compression**은 과도한 래스터 이미지의 파일 크기를 크게 줄일 수 있지만, 원본 해상도를 포기하게 됩니다. 슬라이드 내에서 실제 표시될 크기가 확정된 후에 적용해야 합니다.
- **SVG images**는 벡터 보존이 중요할 때 SVG 상태로 유지해야 합니다. 벡터 리소스 자체가 필요할 경우 임베디드 SVG를 직접 추출하십시오. 래스터 슬라이드 내보내기는 항상 렌더링된 슬라이드를 픽셀로 변환합니다.
- **Repeated images**는 가능한 경우 기존 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/) 리소스를 재사용하여 동일 파일을 반복 로드하는 것을 피하십시오.

대형 프레젠테이션에서는 이미지 최적화를 선택적으로 수행하는 것이 보통 가장 효과적입니다: 로고와 다이어그램은 벡터 콘텐츠로 유지하고, 사진은 실제 표시 크기에 따라 압축하며, 나중에 편집이 필요하지 않은 경우에만 자른 픽셀을 제거하고, 외부 링크는 종속성 관리가 배포 설계의 일부가 아닌 한 피하십시오.

## **FAQ**

**What is the difference between a picture frame and an image resource?**

[PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)은 프레젠테이션과 연결된 이미지 리소스를 나타냅니다. [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)은 슬라이드에 있는 도형으로, 이미지를 표시하고 크기, 회전, 자르기 값, 효과, 잠금 등 프레임 수준의 기하학 및 서식을 저장합니다.

**Should I embed or link images?**

프레젠테이션을 이동 가능하게 하거나 보관하거나 외부 리소스 없이 렌더링해야 할 경우 이미지를 임베드하십시오. 이미지 파일을 PPTX 외부에 두는 것이 의도적이며 외부 위치를 안정적으로 관리할 수 있는 경우에만 이미지를 링크하십시오.

**Does cropping reduce PPTX file size?**

그 자체로는 줄어들지 않습니다. 일반적인 자르기 설정은 원본 이미지의 일부를 숨기지만 기본 픽셀은 유지합니다. 픽셀을 영구적으로 제거하려면 [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 또는 자른 영역 제거와 함께 이미지 압축을 사용하십시오.

**Can I restore image quality after compression?**

아니오. 압축은 저장된 래스터 해상도를 낮추며, 자른 영역을 제거하면 이미지 데이터가 삭제됩니다. 나중에 고해상도 편집이 필요할 경우 원본 이미지를 프레젠테이션 외부에 보관하십시오.

**How should SVG images be handled?**

벡터 정확성이 중요한 경우 SVG 콘텐츠를 SVG 상태로 유지하십시오. 임베디드 [SvgImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgimage/)을 직접 추출할 수 있습니다. PNG나 JPEG와 같이 슬라이드를 래스터 형식으로 렌더링하면 SVG가 해당 슬라이드 이미지의 픽셀로 변환됩니다.

**How can I avoid unsafe casts when reading existing slides?**

그림 프레임 전용 멤버를 사용하기 전에 도형 유형을 확인하십시오. [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)에 대한 `java_instanceof` 검사를 수행하면 잘못된 형변환을 방지하고 그림 프레임이 없는 슬라이드를 적절히 처리할 수 있습니다.