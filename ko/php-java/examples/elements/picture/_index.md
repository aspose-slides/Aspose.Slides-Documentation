---
title: 그림
type: docs
weight: 50
url: /ko/php-java/examples/elements/picture/
keywords:
- 그림
- 그림 프레임
- 그림 추가
- 그림 액세스
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 그림을 작업합니다: 삽입, 교체, 자르기, 압축, 투명도 및 효과 조정, 도형 채우기, 그리고 PPT, PPTX 및 ODP로 내보내기."
---
**Aspose.Slides for PHP via Java**를 사용하여 그림을 삽입하고 액세스하는 방법을 보여줍니다. 아래 예제에서는 이미지를 슬라이드에 배치하고 나중에 가져옵니다.

## **그림 추가**

이 코드는 첫 번째 슬라이드에 이미지를 그림 프레임으로 삽입합니다.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // 프레젠테이션 리소스에 이미지를 추가합니다.
        $ppImage = $presentation->getImages()->addImage($image);

        // 첫 번째 슬라이드에 이미지를 표시하는 그림 프레임을 삽입합니다.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **그림 액세스**

이 예제는 슬라이드에 그림 프레임이 포함되어 있는지 확인한 다음, 찾은 첫 번째 프레임에 액세스합니다.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드에서 첫 번째 PictureFrame에 액세스합니다.
        $firstPictureFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $firstPictureFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```