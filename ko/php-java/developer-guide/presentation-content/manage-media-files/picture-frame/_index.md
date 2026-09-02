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
- 삽입 이미지
- 연결 이미지
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
- 가로세로 비율
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 프레젠테이션에서 그림 프레임을 만들고, 서식 지정하고, 연결하고, 자르고, 추출하고, 압축합니다."
---
## **개요**

Picture frame은 이미지를 표시하는 슬라이드 도형입니다. Aspose.Slides에서는 이미지 리소스와 이를 표시하는 도형이 별개의 객체로 존재합니다: a [Presentation]이(가) [ImageCollection]을 통해 삽입된 이미지 리소스를 소유하고, [PictureFrame]은 이미지의 위치, 크기, 선 서식, 회전, 자르기, 사진 효과 및 기타 프레임 수준 설정을 제어합니다.

이러한 분리는 동일한 이미지를 여러 번 표시할 때 유용합니다. 이미지를 프레젠테이션에 한 번 추가하고 반환된 [PPImage]를 보관한 뒤 picture frame을 만들 때 해당 이미지 리소스를 사용합니다.

Picture frame은 PNG 또는 JPEG와 같은 래스터 이미지와 SVG와 같은 벡터 이미지를 포함할 수 있습니다. 또한 프레젠테이션에 이미지 바이트를 저장하는 대신 연결된 이미지를 참조하도록 할 수 있습니다. 선택은 이동성, 파일 크기, 추출 및 내보내기 동작에 영향을 미치므로 서식 지정이나 최적화를 적용하기 전에 이미지 저장 방식을 결정하는 것이 유용합니다.

## **삽입된 이미지 추가 및 서식 지정**

삽입된 이미지의 경우 이미지 데이터를 프레젠테이션에 추가하고 [ShapeCollection::addPictureFrame]을 사용해 picture frame을 생성합니다. 이미지는 프레젠테이션 패키지의 일부가 되므로 프레젠테이션을 다른 컴퓨터로 이동해도 자체 포함됩니다.

다음 예제는 JPEG 이미지를 추가하고 이미지의 원본 치수대로 프레임을 생성한 뒤 선 서식과 회전을 적용합니다:

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

Picture frame은 표시되는 기하학을 제어합니다. 프레임 크기를 변경해도 삽입된 이미지 리소스에 저장된 원본 픽셀 치수는 변경되지 않습니다. 이 구분은 나중에 이미지를 자르거나 압축할 때 중요합니다.

## **상대 스케일 사용**

[PictureFrame]은 [setRelativeScaleWidth]와 [setRelativeScaleHeight]를 통해 프레임에 대한 상대적 너비와 높이 스케일을 노출합니다. `1.0` 값은 원본 그림 크기의 100%에 해당합니다. 상대 스케일은 워크플로우가 최종 치수를 수동으로 계산하지 않고 원본 이미지 크기와의 관계를 유지해야 할 때 유용합니다.

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

상대 스케일은 프레임의 스케일 설정만 변경하며 삽입된 이미지를 재샘플링하거나 압축하지 않습니다.

## **삽입 및 연결 이미지**

삽입된 picture는 이미지 데이터를 프레젠테이션 내부에 저장하므로 이동성 및 예측 가능한 렌더링 측면에서 가장 안전한 선택입니다. 연결된 picture는 [Picture::setLinkPathLong] 메서드를 통해 외부 위치를 저장하므로 이미지 데이터를 동일 방식으로 삽입하지 않습니다.

연결된 이미지는 PPTX에 저장되는 이미지 데이터 양을 줄일 수 있지만 외부 종속성이 생깁니다. 연결 파일은 프레젠테이션을 열거나 렌더링하는 애플리케이션이 접근할 수 있어야 합니다. 경로가 변경되거나 파일이 이동되거나 리소스를 사용할 수 없게 되면 연결된 picture가 예상대로 표시되지 않을 수 있습니다. 이메일 전송, 보관 또는 격리된 환경에서 렌더링해야 하는 프레젠테이션의 경우 삽입된 이미지가 일반적으로 더 신뢰할 수 있습니다.

### **연결 이미지 추가**

다음 예제는 picture frame을 생성하고 로컬 이미지 파일을 가리키도록 설정합니다. 이 예제는 이미지 연결만 다루며, 비디오 연결은 별도의 미디어 워크플로우이며 의도적으로 혼합되지 않았습니다.

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

외부 파일 관리가 의도된 경우에만 링크를 사용하십시오. 압축을 대신하기 위해 링크를 사용하면 안 됩니다. 깨진 이미지 종속성을 가진 작은 PPTX는 일반적으로 더 큰 자체 포함 프레젠테이션보다 유용하지 않습니다.

## **Picture Frame에서 이미지 추출**

기존 프레젠테이션에서 이미지를 추출하기 전에 해당 도형이 실제로 [PictureFrame]인지와 삽입된 이미지를 포함하고 있는지 확인하십시오. 연결된 picture frame은 동일한 방식으로 추출할 수 있는 이미지 바이트를 포함하지 않을 수 있습니다.

### **래스터 이미지 추출**

최신 이미지 API는 [IImage]를 직접 사용합니다. 다음 예제는 슬라이드에서 첫 번째 삽입된 래스터 picture를 찾아 PNG로 저장합니다:

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

[IImage::save]를 통해 저장하면 추출된 이미지를 요청된 출력 형식으로 변환합니다. 프레젠테이션에 저장된 인코딩된 바이트가 필요하면 변환된 래스터 파일 대신 이미지 리소스의 바이너리 데이터를 사용하십시오.

### **SVG 이미지 추출**

SVG picture의 경우 [PPImage]가 [SvgImage] 객체를 노출합니다. 이를 통해 picture를 먼저 래스터화하지 않고 SVG 데이터를 직접 가져올 수 있습니다.

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

SVG 내용을 SVG 그대로 유지하면 프레젠테이션 내부에 벡터 소스를 보존할 수 있습니다. PNG 또는 JPEG와 같은 래스터 내보내기는 해당 벡터 내용을 픽셀로 렌더링합니다. PDF 또는 SVG 슬라이드 내보내기도 렌더링 작업이므로, 내보낸 그래픽을 원본 삽입된 SVG의 바이트-투-바이트 복사본으로 취급해서는 안 됩니다. 원본 벡터 리소스 자체가 필요할 때는 삽입된 [SvgImage::getSvgData] 데이터를 사용하십시오.

## **이미지 자르기**

자르기는 프레임 내부에서 이미지의 어느 부분이 표시되는지를 변경합니다. [PictureFillFormat]의 자르기 값은 원본 이미지 치수에 대한 백분율입니다. 자르기는 처음에 숨겨진 픽셀을 삽입된 이미지에서 실제로 삭제하지 않으며, 보이는 영역만 변경합니다.

다음 예제는 picture frame을 안전하게 찾은 뒤 자르기 값을 적용합니다:

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

숨겨진 이미지 데이터가 여전히 존재하므로, 나중에 원본 픽셀을 잃지 않고 자르기를 변경할 수 있습니다. 파일 크기가 중요하고 복구 가능성이 필요 없을 경우 다음 섹션에 설명된 대로 물리적으로 제거할 수 있습니다.

## **잘린 이미지 데이터 제거**

[PictureFillFormat::deletePictureCroppedAreas]는 현재 자르기 사각형 밖의 이미지 데이터를 제거하고 결과 이미지 리소스를 반환합니다. 이는 파일 크기를 줄일 수 있지만 파괴적인 최적화입니다: 프레젠테이션을 저장한 후에는 제거된 픽셀을 다시 복원할 수 없습니다.

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

이 메서드는 프레젠테이션에 새 이미지 리소스를 추가할 수 있습니다. 원본 이미지가 다른 picture frame에서도 사용 중이라면 해당 프레임은 기존 리소스를 계속 사용해야 하므로, 잘린 영역을 삭제해도 전체 이미지 수가 반드시 줄어드는 것은 아닙니다. WMF 또는 EMF 콘텐츠를 이 메서드로 자르면 결과가 PNG로 래스터화됩니다.

## **래스터 이미지 압축**

[PictureFillFormat::compressImage]는 picture가 표시되는 크기에 비례하여 래스터 이미지 해상도를 낮춥니다. 동일 작업에서 잘린 영역을 제거할 수도 있습니다. 이미지가 크기 조정되거나 잘려면 `true`를 반환하고, 변경이 필요 없으면 `false`를 반환합니다.

표준 목표 해상도가 충분할 경우 미리 정의된 [PicturesCompression] 값을 사용하십시오:

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

특정 목표가 필요한 경우 미리 정의된 값 대신 양의 DPI 값을 전달할 수 있습니다.

압축은 래스터 이미지에만 적용됩니다. SVG 및 메타파일 콘텐츠는 이 래스터 압축 워크플로우에서는 감소되지 않습니다. 또한 낮은 해상도와 삭제된 잘린 영역은 최적화된 프레젠테이션에서 복구할 수 없으므로, 실제로 이미지가 표시되거나 내보내질 가장 큰 크기를 기준으로 목표 해상도를 선택하고 전역적으로 가장 낮은 DPI를 적용하지 마십시오.

## **이미지 변환 효과 관리**

밝기, 대비, 색상 변환, 블러, 알파 효과, 순차 체인, 검사, 제거 및 왕복 검증을 포함한 전체 워크플로우는 [Image Transform Effects](/slides/ko/php-java/image-transform-effects/)를 참고하십시오.

## **Picture Frame 기하학 잠금**

[PictureFrameLock] 설정은 picture frame에 대해 어떤 편집 작업이 비활성화되는지를 제어합니다. 예를 들어, [setAspectRatioLocked]은 크기 조정 시 도형의 비율을 유지합니다.

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

잠금은 picture frame 도형에 적용됩니다. 원본 이미지를 재샘플링하거나 영구적으로 동일 비율로 변경하도록 강제하지는 않습니다.

## **StretchOffset 값 조정**

picture fill 모드가 stretch인 경우 [PictureFillFormat]의 stretch‑offset 값은 picture frame 경계 상자에 대한 채우기 사각형을 정의합니다. 양수 백분율은 가장자리에서 안쪽으로 inset을 만들고, 음수 백분율은 바깥쪽으로 outset을 만듭니다.

이는 자르기와 다릅니다. 자르기 값은 원본 이미지의 어느 부분이 보이는지를 선택하고, stretch offset은 보이는 picture fill이 스트레칭되는 사각형을 변경합니다.

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

채우기 위치 지정에는 stretch offset을, 원본 이미지 가장자리를 숨기는 목적에는 자르기 속성을 사용하십시오.

## **스토리지, 파일 크기 및 내보내기 고려 사항**

이미지 스토리지와 picture‑frame 서식을 별도로 다룰 때 주요 트레이드오프를 관리하기가 쉽습니다:

- **삽입된 이미지**는 프레젠테이션을 자체 포함하게 하여 공유 및 서버‑사이드 렌더링에 가장 신뢰할 수 있지만, 큰 래스터 이미지는 PPTX 크기와 메모리 사용량을 증가시킵니다.
- **연결된 이미지**는 패키지를 보다 작게 유지할 수 있지만, 프레젠테이션은 지정된 경로나 위치에 외부 파일이 남아 있어야 합니다.
- **자르기**는 초기에는 비파괴적입니다. 숨겨진 픽셀은 잘린 영역을 명시적으로 삭제하거나 압축 중에 제거하기 전까지 삽입된 상태로 유지됩니다.
- **압축**은 과다한 래스터 이미지의 파일 크기를 크게 줄일 수 있지만 원본 해상도를 포기합니다. 슬라이드 내에서 의도된 최종 크기가 알려진 후에 적용해야 합니다.
- **SVG 이미지**는 벡터 보존이 중요한 경우 SVG 그대로 유지해야 합니다. 벡터 리소스 자체가 필요할 때는 삽입된 SVG를 직접 추출하십시오. 래스터 슬라이드 내보내기는 항상 렌더링된 슬라이드를 픽셀로 변환합니다.
- **중복 이미지**는 가능한 경우 기존 [PPImage] 리소스를 재사용하여 동일 파일을 여러 번 로드하지 않도록 하십시오.

대규모 프레젠테이션의 경우 이미지 최적화는 선택적으로 수행할 때 가장 효과적입니다: 로고와 다이어그램은 벡터 콘텐츠로 유지하고, 사진은 실제 표시 크기에 따라 압축하며, 나중에 편집이 필요하지 않을 경우에만 잘린 픽셀을 제거하고, 외부 링크는 종속성 관리가 배포 설계의 일부가 아닐 경우에만 사용하십시오.

## **FAQ**

**Picture frame과 이미지 리소스의 차이는 무엇인가요?**

[PPImage]는 프레젠테이션과 연결된 이미지 리소스를 나타냅니다. [PictureFrame]은 슬라이드에 배치된 도형으로 이미지를 표시하며 크기, 회전, 자르기 값, 효과 및 잠금과 같은 프레임 수준 기하학 및 서식을 저장합니다.

**이미지를 삽입해야 할까요, 링크해야 할까요?**

프레젠테이션을 이동 가능하게 유지하거나 아카이브하거나 외부 리소스 없이 렌더링해야 할 경우 이미지를 삽입하십시오. 이미지 파일을 PPTX 외부에 두고 외부 위치를 안정적으로 유지할 수 있는 경우에만 이미지를 링크하십시오.

**자르기가 PPTX 파일 크기를 줄이나요?**

자체적으로는 줄이지 않습니다. 일반 자르기 설정은 이미지의 일부를 숨기지만 기본 픽셀은 유지합니다. [PictureFillFormat::deletePictureCroppedAreas] 또는 잘린 영역 제거와 함께 이미지 압축을 사용하면 픽셀을 영구적으로 삭제할 수 있습니다.

**압축 후에 이미지 품질을 복구할 수 있나요?**

아니요. 압축은 저장된 래스터 해상도를 낮추고, 잘린 영역을 제거하면 이미지 데이터가 사라집니다. 나중에 고해상도 편집이 필요할 경우 원본 이미지를 프레젠테이션 외부에 보관하십시오.

**SVG 이미지는 어떻게 다루어야 하나요?**

벡터 정확도가 중요한 경우 SVG 내용을 SVG 그대로 유지하십시오. 삽입된 [SvgImage]를 직접 추출할 수 있습니다. PNG 또는 JPEG와 같은 래스터 형식으로 슬라이드를 렌더링하면 SVG가 슬라이드 이미지의 일부로 래스터화됩니다.

**기존 슬라이드를 읽을 때 안전하지 않은 캐스트를 어떻게 방지하나요?**

도형 타입을 확인한 후 picture‑frame‑전용 멤버를 사용하십시오. [PictureFrame]에 대한 `java_instanceof` 검사는 잘못된 캐스트를 방지하고, picture frame이 없는 슬라이드를 적절히 처리할 수 있게 해줍니다.