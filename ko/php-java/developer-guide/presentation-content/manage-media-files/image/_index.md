---
title: PHP를 사용한 프레젠테이션 이미지 관리 최적화
linktitle: 이미지 관리
type: docs
weight: 10
url: /ko/php-java/image/
keywords:
- 이미지 추가
- 그림 추가
- 비트맵 추가
- 이미지 교체
- 그림 교체
- 웹에서
- 배경
- PNG 추가
- JPG 추가
- SVG 추가
- EMF 추가
- WMF 추가
- TIFF 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 및 OpenDocument에서 이미지 관리를 간소화하고, 성능을 최적화하며 워크플로를 자동화합니다."
---
## **소개**

이미지는 프레젠테이션을 보다 흥미롭고 매력적으로 만듭니다. Microsoft PowerPoint에서는 파일, 인터넷 또는 기타 위치에서 사진을 슬라이드에 삽입할 수 있습니다. 마찬가지로 Aspose.Slides를 사용하면 다양한 방법으로 프레젠테이션 슬라이드에 이미지를 추가할 수 있습니다.

{{% alert  title="Tip" color="primary" %}} 

Aspose는 무료 변환기—[JPEG에서 PowerPoint로](https://products.aspose.app/slides/ko/import/jpg-to-ppt) 및 [PNG에서 PowerPoint로](https://products.aspose.app/slides/ko/import/png-to-ppt)—를 제공하여 사용자가 이미지를 빠르게 프레젠테이션으로 만들 수 있도록 합니다. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

프레임 객체로 이미지를 추가하고 싶다면—특히 크기 변경, 효과 적용 등 표준 서식 옵션을 사용할 계획이라면—[Picture Frame](/slides/ko/php-java/picture-frame/)을 참조하세요. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

이미지와 PowerPoint 프레젠테이션을 포함한 입출력 작업을 조작하여 이미지를 다른 형식으로 변환할 수 있습니다. 다음 페이지를 참고하세요: 변환 [image to JPG](https://products.aspose.com/slides/ko/php-java/conversion/image-to-jpg/); 변환 [JPG to image](https://products.aspose.com/slides/ko/php-java/conversion/jpg-to-image/); 변환 [JPG to PNG](https://products.aspose.com/slides/ko/php-java/conversion/jpg-to-png/), 변환 [PNG to JPG](https://products.aspose.com/slides/ko/php-java/conversion/png-to-jpg/); 변환 [PNG to SVG](https://products.aspose.com/slides/ko/php-java/conversion/png-to-svg/), 변환 [SVG to PNG](https://products.aspose.com/slides/ko/php-java/conversion/svg-to-png/). 

{{% /alert %}}

Aspose.Slides는 JPEG, PNG, GIF 등 이러한 인기 형식의 이미지 작업을 지원합니다. 

## **로컬에 저장된 이미지를 슬라이드에 추가**

컴퓨터에 있는 하나 이상의 이미지를 프레젠테이션 슬라이드에 추가할 수 있습니다. 다음 샘플 코드는 이미지 를 슬라이드에 추가하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **웹에서 이미지를 슬라이드에 추가**

컴퓨터에 이미지가 없을 경우 웹에서 직접 이미지를 가져와 슬라이드에 추가할 수 있습니다. 

다음 샘플 코드는 웹에서 이미지를 슬라이드에 추가하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **슬라이드 마스터에 이미지 추가**

슬라이드 마스터는 해당 마스터 아래 모든 슬라이드의 테마, 레이아웃 등을 저장하고 제어하는 최상위 슬라이드입니다. 따라서 슬라이드 마스터에 이미지를 추가하면 해당 마스터 아래 모든 슬라이드에 이미지가 표시됩니다. 

다음 Java 샘플 코드는 슬라이드 마스터에 이미지를 추가하는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **이미지를 슬라이드 배경으로 추가**

특정 슬라이드 또는 여러 슬라이드의 배경으로 사진을 사용하려면 [Set an Image as a Slide Background](/slides/ko/php-java/presentation-background/#set-an-image-as-a-slide-background)를 참조하세요.

## **프레젠테이션에 SVG 추가**
[addPictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addpictureframe/) 메서드([ShapeCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/) 클래스 소속)를 사용하여 프레젠테이션에 모든 이미지를 추가하거나 삽입할 수 있습니다.

SVG 이미지 기반 이미지 객체를 만들려면 다음과 같이 수행합니다:

1. SvgImage 객체를 생성하여 ImageShapeCollection에 삽입합니다.
2. ISvgImage에서 PPImage 객체를 생성합니다.
3. PPImage 클래스를 사용하여 PictureFrame 객체를 생성합니다.

다음 샘플 코드는 위 단계들을 구현하여 SVG 이미지를 프레젠테이션에 추가하는 방법을 보여줍니다:
```php
  # PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SVG를 도형 집합으로 변환**
Aspose.Slides의 SVG를 도형 집합으로 변환하는 기능은 SVG 이미지를 다룰 때 PowerPoint에서 제공하는 기능과 유사합니다:

![PowerPoint 팝업 메뉴](img_01_01.png)

이 기능은 [ShapeCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/) 클래스의 [addGroupShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addgroupshape/) 메서드 중 하나의 오버로드에 의해 제공되며, 첫 번째 인수로 [SvgImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgimage/) 객체를 받습니다.

다음 샘플 코드는 설명된 메서드를 사용하여 SVG 파일을 도형 집합으로 변환하는 방법을 보여줍니다:

```php
  # 새 프레젠테이션 생성
  $presentation = new Presentation();
  try {
    # SVG 파일 내용 읽기
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # SvgImage 객체 생성
    $svgImage = new SvgImage($svgContent);
    # 슬라이드 크기 가져오기
    $slideSize = $presentation->getSlideSize()->getSize();
    # SVG 이미지를 슬라이드 크기에 맞게 스케일링하여 도형 그룹으로 변환
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # PPTX 형식으로 프레젠테이션 저장
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **이미지를 EMF로 슬라이드에 추가**
Aspose.Slides for PHP via Java를 사용하면 Excel 시트에서 EMF 이미지를 생성하고 Aspose.Cells와 함께 EMF 이미지를 슬라이드에 추가할 수 있습니다. 

다음 샘플 코드는 해당 작업을 수행하는 방법을 보여줍니다:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # 워크북을 스트림에 저장
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **이미지 컬렉션에서 이미지 교체**

Aspose.Slides를 사용하면 프레젠테이션의 이미지 컬렉션(슬라이드 도형에서 사용되는 이미지 포함)에 저장된 이미지를 교체할 수 있습니다. 이 섹션에서는 컬렉션 내 이미지를 업데이트하는 여러 접근 방식을 보여줍니다. API는 원시 바이트 데이터, [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/) 인스턴스 또는 컬렉션에 이미 존재하는 다른 이미지를 사용하여 이미지를 교체하는 간단한 메서드를 제공합니다.

아래 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스를 사용하여 이미지가 포함된 프레젠테이션 파일을 로드합니다.
2. 파일에서 새 이미지를 바이트 배열로 로드합니다.
3. 바이트 배열을 사용하여 대상 이미지를 새 이미지로 교체합니다.
4. 두 번째 접근 방식에서는 이미지를 [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/) 객체로 로드하고 해당 객체로 대상 이미지를 교체합니다.
5. 세 번째 접근 방식에서는 프레젠테이션 이미지 컬렉션에 이미 존재하는 이미지를 사용하여 대상 이미지를 교체합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```php
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation("sample.pptx");
try {
    // 첫 번째 방법.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // 두 번째 방법.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // 세 번째 방법.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // 프레젠테이션을 파일로 저장합니다.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

Aspose 무료 [Text to GIF](https://products.aspose.app/slides/ko/text-to-gif) 변환기를 사용하면 텍스트를 애니메이션화하고 텍스트에서 GIF를 쉽게 만들 수 있습니다. 

{{% /alert %}}

## **FAQ**

**삽입 후 원본 이미지 해상도가 유지됩니까?**

예. 원본 픽셀은 보존되지만 최종 표시 결과는 슬라이드에서 [picture](/slides/ko/php-java/picture-frame/)의 스케일링 방식 및 저장 시 적용되는 압축에 따라 달라집니다.

**수십 개 슬라이드에 걸쳐 같은 로고를 한 번에 교체하려면 가장 좋은 방법은 무엇입니까?**

마스터 슬라이드 또는 레이아웃에 로고를 배치하고 프레젠테이션 이미지 컬렉션에서 교체하면 해당 리소스를 사용하는 모든 요소에 자동으로 적용됩니다.

**삽입된 SVG를 편집 가능한 도형으로 변환할 수 있습니까?**

예. SVG를 도형 그룹으로 변환하면 개별 파트를 표준 도형 속성을 사용해 편집할 수 있습니다.

**여러 슬라이드에 동시에 이미지를 배경으로 설정하려면 어떻게 해야 합니까?**

마스터 슬라이드 또는 해당 레이아웃에 이미지를 배경으로 지정하면( [Assign the image as the background](/slides/ko/php-java/presentation-background/) ) 그 마스터/레이아웃을 사용하는 모든 슬라이드가 배경을 상속합니다.

**많은 그림 때문에 프레젠테이션 파일 크기가 급증하는 것을 방지하려면 어떻게 해야 합니까?**

이미지를 중복으로 사용하지 말고 단일 이미지 리소스를 재사용하며, 해상도를 적절히 선택하고 저장 시 압축을 적용하고, 가능한 경우 마스터에 반복 그래픽을 배치하십시오.