---
title: PHP를 사용하여 프레젠테이션에서 SmartArt 그래픽 관리
linktitle: SmartArt 그래픽
type: docs
weight: 20
url: /ko/php-java/manage-smartart-shape/
keywords:
- SmartArt 개체
- SmartArt 그래픽
- SmartArt 스타일
- SmartArt 색상
- SmartArt 생성
- SmartArt 추가
- SmartArt 편집
- SmartArt 변경
- SmartArt 접근
- SmartArt 레이아웃 유형
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 PowerPoint SmartArt 생성, 편집 및 스타일링을 자동화하고, 간결한 코드 예제와 성능 중심 가이드를 제공합니다."
---
## **Overview**

Aspose.Slides는 프로그래밍 방식으로 PowerPoint 프레젠테이션에서 SmartArt 그래픽을 생성하고 관리할 수 있게 합니다. 이 문서에서는 슬라이드에 SmartArt 도형을 추가하고, 기존 SmartArt 도형에 접근하며, 특정 레이아웃 유형으로 SmartArt를 찾고, SmartArt 스타일 또는 색상 스타일을 변경하여 시각적 모양을 업데이트하는 방법을 설명합니다.

예제에서는 프레젠테이션 슬라이드의 도형 컬렉션을 통해 SmartArt 도형을 작업하고, 도형이 SmartArt인지 확인한 뒤 해당 속성을 수정하거나 검사하는 방법을 보여줍니다.

## **Create a SmartArt Shape**
Aspose.Slides for PHP via Java는 SmartArt 도형을 생성하기 위한 API를 제공합니다. 슬라이드에 SmartArt 도형을 생성하려면 아래 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
3. [Add a SmartArt shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/#addSmartArt) 을(를) [LayoutType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArtLayoutType) 로 설정합니다.
4. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```php
  # Presentation 클래스 인스턴스화
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드 가져오기
    $slide = $pres->getSlides()->get_Item(0);
    # Smart Art 도형 추가
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # 프레젠테이션 저장
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**그림: 슬라이드에 추가된 SmartArt 도형**|

## **Access a SmartArt Shape on a Slide**
다음 코드는 프레젠테이션 슬라이드에 추가된 SmartArt 도형에 접근하는 데 사용됩니다. 샘플 코드에서는 슬라이드 내부의 모든 도형을 순회하면서 해당 도형이 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArt) 도형인지 확인합니다. 도형이 SmartArt 유형이면 이를 [**SmartArt**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArt) 인스턴스로 타입 캐스트합니다.

```php
  # 원하는 프레젠테이션 로드
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # 첫 번째 슬라이드 내부의 모든 도형 순회
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # 도형이 SmartArt 유형인지 확인
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 도형을 SmartArtEx로 타입 캐스트
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Access a SmartArt Shape with a Particular Layout Type**
다음 샘플 코드는 특정 LayoutType을 가진 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArt) 도형에 접근하는 데 도움이 됩니다. SmartArt의 LayoutType은 읽기 전용이며 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArt) 도형이 추가될 때만 설정되므로 변경할 수 없음을 유의하십시오.

1. SmartArt 도형이 포함된 프레젠테이션을 로드하고 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 첫 번째 슬라이드에 대한 참조를 가져옵니다.
3. 첫 번째 슬라이드 내부의 모든 도형을 순회합니다.
4. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArt) 유형인지 확인하고 SmartArt인 경우 선택한 도형을 SmartArt로 타입 캐스트합니다.
5. 특정 LayoutType을 가진 SmartArt 도형을 확인하고 이후에 필요한 작업을 수행합니다.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # 첫 번째 슬라이드 내부의 모든 도형 순회
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # 도형이 SmartArt 유형인지 확인
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 도형을 SmartArtEx로 타입 캐스트
        $smart = $shape;
        # SmartArt 레이아웃 확인
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Change a SmartArt Shape Style**
이 예제에서는 모든 SmartArt 도형에 대한 빠른 스타일을 변경하는 방법을 배웁니다.

1. SmartArt 도형이 포함된 프레젠테이션을 로드하고 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 첫 번째 슬라이드에 대한 참조를 가져옵니다.
3. 첫 번째 슬라이드 내부의 모든 도형을 순회합니다.
4. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArt) 유형인지 확인하고 SmartArt인 경우 선택한 도형을 SmartArt로 타입 캐스트합니다.
5. 특정 스타일을 가진 SmartArt 도형을 찾습니다.
6. SmartArt 도형에 새로운 스타일을 설정합니다.
7. 프레젠테이션을 저장합니다.

```php
  # Presentation 클래스 인스턴스화
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 첫 번째 슬라이드 가져오기
    $slide = $pres->getSlides()->get_Item(0);
    # 첫 번째 슬라이드 내부의 모든 도형 순회
    foreach($slide->getShapes() as $shape) {
      # 도형이 SmartArt 유형인지 확인
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 도형을 SmartArtEx로 타입 캐스트
        $smart = $shape;
        # SmartArt 스타일 확인
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # SmartArt 스타일 변경
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # 프레젠테이션 저장
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**그림: 스타일이 변경된 SmartArt 도형**|

## **Change a SmartArt Shape Color Style**
이 예제에서는 모든 SmartArt 도형에 대한 색상 스타일을 변경하는 방법을 배웁니다. 아래 샘플 코드는 특정 색상 스타일을 가진 SmartArt 도형에 접근하여 스타일을 변경합니다.

1. SmartArt 도형이 포함된 프레젠테이션을 로드하고 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 첫 번째 슬라이드에 대한 참조를 가져옵니다.
3. 첫 번째 슬라이드 내부의 모든 도형을 순회합니다.
4. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArt) 유형인지 확인하고 SmartArt인 경우 선택한 도형을 SmartArt로 타입 캐스트합니다.
5. 특정 색상 스타일을 가진 SmartArt 도형을 찾습니다.
6. SmartArt 도형에 새로운 색상 스타일을 설정합니다.
7. 프레젠테이션을 저장합니다.

```php
  # Presentation 클래스 인스턴스화
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 첫 번째 슬라이드 가져오기
    $slide = $pres->getSlides()->get_Item(0);
    # 첫 번째 슬라이드 내부의 모든 도형 순회
    foreach($slide->getShapes() as $shape) {
      # 도형이 SmartArt 유형인지 확인
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 도형을 SmartArtEx로 타입 캐스트
        $smart = $shape;
        # SmartArt 색상 유형 확인
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # SmartArt 색상 유형 변경
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # 프레젠테이션 저장
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**그림: 색상 스타일이 변경된 SmartArt 도형**|

## **FAQ**

**SmartArt를 단일 객체로 애니메이션 할 수 있나요?**

예. SmartArt는 도형이므로 다른 도형과 마찬가지로 애니메이션 API를 통해 [standard animations](/slides/ko/php-java/powerpoint-animation/) (입장, 퇴장, 강조, 움직임 경로)을 적용할 수 있습니다.

**슬라이드에서 내부 ID를 모를 경우 특정 SmartArt를 어떻게 찾을 수 있나요?**

대체 텍스트(AltText)를 설정하고 해당 값을 통해 도형을 검색하세요—대상 도형을 찾는 권장 방법입니다.

**SmartArt를 다른 도형과 그룹화할 수 있나요?**

예. SmartArt를 다른 도형(그림, 표 등)과 그룹화한 뒤 [manipulate the group](/slides/ko/php-java/group/) 할 수 있습니다.

**특정 SmartArt의 이미지를 얻으려면 어떻게 해야 하나요(예: 미리보기 또는 보고서용)?**

도형의 썸네일/이미지를 내보내면 됩니다; 라이브러리는 개별 도형을 [render individual shapes](/slides/ko/php-java/create-shape-thumbnails/) 하여 래스터 파일(PNG/JPG/TIFF)로 저장할 수 있습니다.

**전체 프레젠테이션을 PDF로 변환할 때 SmartArt 모양이 유지됩니까?**

예. 렌더링 엔진은 [PDF export](/slides/ko/php-java/convert-powerpoint-to-pdf/) 시 높은 충실도를 목표로 하며, 다양한 품질 및 호환성 옵션을 제공합니다.