---
title: PHP를 사용한 프레젠테이션 이미지 관리 최적화
linktitle: 이미지 관리
type: docs
weight: 10
url: /ko/php-java/image/
keywords:
- 이미지 추가
- 그림 추가
- 이미지 교체
- 이미지 컬렉션
- 그림 프레임
- 링크된 이미지
- 배경
- PNG 추가
- JPG 추가
- SVG 추가
- SVG를 도형으로 변환
- 외부 SVG 리소스
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 래스터 및 SVG 이미지를 추가, 재사용, 링크, 교체 및 관리하는 방법을 학습합니다."
---
## **소개**

Aspose.Slides for PHP via Java은 이미지 작업을 위한 여러 방법을 제공하며, 각 방법은 다른 목적을 가집니다. 이미지를 프레젠테이션에 저장하고, 그림 프레임에 표시하고, 슬라이드 배경으로 사용하고, 외부 이미지에 연결하고, 공유 이미지 리소스를 교체하거나, SVG 콘텐츠를 편집 가능한 도형으로 변환할 수 있습니다.

이 문서는 이미지 리소스와 프레젠테이션 전반에서의 사용 방법에 중점을 둡니다. 개별 그림 프레임에 적용되는 자르기, 투명도, 효과, 늘리기 및 기타 서식에 대해서는 [Picture Frame](/slides/ko/php-java/picture-frame/)을 참조하십시오.

## **이미지 모델 이해**

- [프레젠테이션 이미지 컬렉션](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagecollection/)은 프레젠테이션에서 사용되는 이미지 리소스를 저장합니다. 이미지 데이터를 추가하고 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/) 리소스를 얻으려면 [ImageCollection::addImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagecollection/)를 사용하십시오.
- [그림 프레임](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)은 슬라이드, 레이아웃 또는 마스터에 이미지를 표시하는 도형입니다. 이미지 리소스를 슬라이드에 배치하려면 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addpictureframe/)를 사용하십시오.
- 슬라이드 배경은 이미지를 도형이 아니라 슬라이드 채우기의 일부로 사용합니다. 따라서 그림 프레임처럼 동작하지 않습니다.
- [PPImage::replaceImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)는 이미지 리소스를 교체합니다. 여러 프레젠테이션 요소가 해당 리소스를 사용하고 있다면 모두 교체된 이미지가 사용됩니다.
- SVG를 도형으로 변환하면 편집 가능한 슬라이드 도형이 만들어집니다. 변환 후에는 해당 콘텐츠가 하나의 그림 리소스로 관리되지 않습니다.

따라서 일반적인 흐름은 다음과 같습니다. 이미지 데이터를 이미지 컬렉션에 추가하고, [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)을 받아서 하나 이상의 그림 프레임이나 채우기에 사용합니다.

## **임베디드 이미지 추가**

로컬 이미지를 삽입하려면 파일을 로드하고, 이미지 컬렉션에 추가한 뒤, 반환된 `PPImage`를 사용하는 그림 프레임을 생성합니다.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

이렇게 추가된 이미지는 프레젠테이션에 임베드되므로, 결과 파일은 원본 이미지 파일이 더 이상 사용 가능하지 않아도 작동합니다.

### **웹에서 이미지 추가**

이미지가 HTTP 또는 HTTPS를 통해 제공되는 경우, 바이트를 다운로드하고 프레젠테이션 이미지 컬렉션에 추가한 뒤, 로컬 이미지와 동일한 방식으로 반환된 이미지 리소스를 사용합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

장시간 실행되는 애플리케이션에서는 불필요한 네트워킹 인프라를 반복적으로 생성하기보다는 HTTP 클라이언트 또는 연결 관리 전략을 재사용하십시오. 또한 소스가 신뢰되지 않을 경우 원격 URL, 응답 크기 및 콘텐츠 유형을 검증하십시오.

## **슬라이드 간 이미지 재사용**

동일한 이미지를 여러 번 사용할 필요가 있으면 프레젠테이션에 한 번만 추가하고, 추가적인 그림 프레임을 만들 때 반환된 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)을 재사용하십시오. 이렇게 하면 동일한 소스 데이터를 반복 로드하는 것을 방지하고, 공유 이미지 리소스와 사용 간의 관계가 명확해집니다.

많은 슬라이드에 자동으로 나타나야 하는 그래픽(예: 회사 로고)이라면 각 슬라이드에 동일한 도형을 추가하기보다 [슬라이드 마스터](/slides/ko/php-java/slide-master/)나 레이아웃에 그림 프레임을 배치하는 것을 고려하십시오.

## **이미지를 슬라이드 배경으로 사용**

배경 이미지는 슬라이드 채우기에 할당되며, 그림 프레임 도형으로 추가되지 않습니다. 이는 그림이 슬라이드 배경 전체를 덮어야 하고 일반 슬라이드 객체처럼 조작되지 않아야 할 때 유용합니다.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

마스터 및 레이아웃 배경을 포함한 추가 배경 옵션은 [Presentation Background](/slides/ko/php-java/presentation-background/)를 참조하십시오.

## **임베디드 이미지와 링크 이미지**

임베디드 이미지와 링크 이미지는 휴대성 및 파일 크기 측면에서 서로 다른 트레이드오프를 가집니다.

- **임베디드 이미지:** 이미지 데이터가 프레젠테이션 내부에 저장됩니다. 프레젠테이션이 자체 포함되지만 파일 크기에 이미지 데이터가 포함됩니다.
- **링크 이미지:** 프레젠테이션이 외부 이미지에 대한 경로나 URL을 저장합니다. 프레젠테이션 크기를 줄일 수 있지만 외부 리소스가 열람 가능해야 합니다.

링크된 그림은 이미지 데이터를 임베드하지 않고 대신 [Picture::setLinkPathLong](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picture/)을 통해 외부 경로나 URL을 지정하여 생성할 수 있습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

외부 리소스에 안정적으로 접근할 수 있는 배포 환경에서만 링크 이미지를 사용하십시오. 오프라인으로 작동하거나 시스템 간 이동이 필요한 프레젠테이션은 일반적으로 임베디드 이미지가 더 안전합니다.

## **SVG 이미지 작업**

SVG는 벡터 형식이므로 아이콘, 다이어그램 및 기타 그래픽을 래스터 이미지와 동일한 상세 손실 없이 확장할 때 유용합니다. Aspose.Slides는 SVG를 이미지 리소스로 뿐만 아니라 편집 가능한 슬라이드 도형의 소스로도 지원합니다.

### **SVG를 이미지로 추가**

[SvgImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgimage/)을 생성하고 이미지 컬렉션에 추가한 뒤, 결과 이미지 리소스를 그림 프레임에 배치합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **외부 리소스를 가진 SVG 파일**

SVG는 외부 이미지, 스타일시트 또는 글꼴을 참조할 수 있습니다. 이러한 경우 [SvgImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgimage/)은 [ExternalResourceResolver](https://reference.aspose.com/slides/ko/php-java/aspose.slides/externalresourceresolver/)와 기본 URI를 허용하는 생성자를 제공합니다. 이 리졸버는 상대 URI를 허용된 절대 URI로 매핑하고 요청된 리소스에 대한 스트림을 반환합니다.

리졸버는 Aspose.Slides가 SVG를 처리하는 동안 외부 리소스를 사용할 수 있게 하지만, SVG를 자체 포함 문서로 재작성하지는 않습니다. SVG를 휴대가능하게 유지해야 한다면, 예를 들어 `data:` URI를 사용해 링크된 이미지를 포함시키는 등 필요한 리소스를 SVG 자체에 임베드하십시오.

신뢰할 수 없는 출처의 SVG 파일을 다룰 때는 리졸버가 접근할 수 있는 스키마, 파일 위치 및 호스트를 제한하십시오. 네트워크 리졸버는 타임아웃, 응답 크기 제한 및 콘텐츠 검증도 적용해야 합니다.

### **SVG를 편집 가능한 도형으로 변환**

Aspose.Slides는 SVG를 편집 가능한 슬라이드 도형 그룹으로 변환할 수 있으며, 이는 해당 PowerPoint 명령과 유사합니다.

![PowerPoint Popup Menu](img_01_01.png)

[SvgImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgimage/)을 허용하는 [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addgroupshape/) 오버로드를 사용해 변환을 수행하십시오.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

개별 벡터 요소를 PowerPoint 도형으로 편집해야 하는 경우에 SVG‑to‑shapes 변환을 사용하십시오. SVG를 단순히 표시만 하면 된다면 이미지로 유지하는 것이 더 간단하고 많은 개별 도형 생성을 방지합니다.

## **기존 이미지 리소스 교체**

기존 이미지 리소스를 교체하려면 [PPImage::replaceImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)를 사용하십시오. 이는 로고와 같은 공유 그래픽을 교체할 때 특히 유용합니다.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

여러 그림 프레임, 배경, 마스터 또는 레이아웃이 동일한 이미지 리소스를 사용하고 있다면 해당 리소스를 교체하면 모든 사용이 업데이트됩니다. 하나의 그림 프레임만 변경하려면 공유 리소스를 교체하지 말고 해당 프레임에 다른 이미지를 할당하십시오.

`PPImage::replaceImage`는 또한 바이트 배열이나 다른 [PPImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)을 받아들이는 오버로드를 제공합니다.

## **실용적인 이미지 관리 가이드**

### **프레젠테이션 크기 제어**

대용량 래스터 이미지는 프레젠테이션을 불필요하게 크게 만들 수 있습니다. 표시하려는 크기에 맞는 해상도의 원본 이미지를 사용하고, 가능한 경우 공유 이미지 리소스를 재사용하며, 동일한 고해상도 그래픽을 반복 임베드하는 것을 피하십시오.

이미 그림 프레임에 이미 배치된 래스터 그림의 경우, [PictureFillFormat::compressImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillformat/)를 사용해 선택한 해상도와 자르기 설정에 따라 이미지 데이터를 압축할 수 있습니다. 이는 이미지 컬렉션 관리가 아니라 그림 프레임 처리이므로 관련 서식 작업은 [Picture Frame](/slides/ko/php-java/picture-frame/)를 참조하십시오.

### **임베디드와 링크 콘텐츠 선택**

임베드하면 모든 필요한 이미지 데이터가 파일에 포함되므로 프레젠테이션이 휴대가능해집니다. 링크는 파일 크기를 줄일 수 있지만 외부 종속성을 도입합니다. 외부 종속성이 허용되고 안정적일 때만 링크를 사용하십시오.

### **공유 브랜딩 재사용**

반복되는 로고, 워터마크 또는 장식 그래픽은 하나의 이미지 리소스를 사용하고 재사용하십시오. 해당 그래픽이 슬라이드 내용이 아니라 프레젠테이션 디자인에 속한다면 마스터나 레이아웃에 배치해 적절한 슬라이드가 상속하도록 하십시오.

### **SVG 리소스 포터블 유지**

자체 포함 SVG는 외부 파일이나 네트워크 리소스에 의존하는 SVG보다 이동 및 일관된 렌더링이 쉽습니다. 가능하면 SVG를 가져오기 전에 필요한 리소스를 임베드하십시오. 개별 벡터 요소를 편집해야 할 경우에만 SVG를 도형으로 변환하십시오.

### **현대적인 크로스 플랫폼 이미지 API 사용**

새 PHP via Java 코드에서는 레거시 `java.awt.image.BufferedImage` 기반 공개 API 대신 Aspose.Slides [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/) 및 [Images](https://reference.aspose.com/slides/ko/php-java/aspose.slides/images/) API를 사용하십시오. 마이그레이션 가이드는 [Modern API](/slides/ko/php-java/modern-api/)를 참조하십시오.

WMF 및 EMF는 특별한 고려가 필요합니다. 이러한 형식이 [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/)를 통해 전달될 때, [ImageCollection::addImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagecollection/)는 메타파일을 삽입 전에 래스터 PNG 표현으로 변환합니다. 메타파일 데이터를 보존해야 한다면 스트림 기반 [ImageCollection::addImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagecollection/) 오버로드를 사용하십시오. 스프레드시트 등에서 EMF 콘텐츠를 생성하는 것은 별도의 통합 워크플로우이며 이 문서의 범위를 벗어납니다.

## **FAQ**

**이미지 컬렉션과 그림 프레임의 차이점은 무엇인가요?**

이미지 컬렉션은 재사용 가능한 이미지 리소스를 저장합니다. 그림 프레임은 해당 리소스 중 하나를 표시하고 자르기 및 효과와 같은 그림 전용 서식을 제공하는 슬라이드 도형입니다.

**로고를 전체 슬라이드에 동일하게 교체하려면 가장 좋은 방법은?**

로고가 이미 하나의 이미지 리소스로 공유되고 있다면 [PPImage::replaceImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ppimage/)를 사용해 해당 리소스를 교체하십시오. 프레젠테이션 전체 브랜딩을 위해서는 마스터나 레이아웃에 로고를 배치하는 것도 중복된 슬라이드 콘텐츠를 줄이는 방법입니다.

**링크된 이미지가 다른 컴퓨터에서 사라지는 이유는?**

링크된 그림은 외부 파일이나 URL에 의존합니다. 해당 리소스에 다른 컴퓨터에서 접근할 수 없으면 링크 이미지가 표시되지 않을 수 있습니다. 프레젠테이션을 자체 포함해야 할 경우 이미지를 임베드하십시오.

**삽입한 SVG를 PowerPoint 도형으로 편집할 수 있나요?**

예. [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addgroupshape/)을 사용해 SVG를 변환하면 결과 그룹에 편집 가능한 슬라이드 도형이 포함됩니다.

**많은 이미지를 포함한 프레젠테이션을 어떻게 작게 유지할 수 있나요?**

공유 이미지 리소스를 재사용하고, 불필요하게 큰 래스터 소스를 피하며, 적절한 경우 래스터 그림을 압축하고, 반복되는 브랜딩은 마스터나 레이아웃에 두고, 외부 종속성이 허용될 때만 링크 이미지를 사용하십시오.