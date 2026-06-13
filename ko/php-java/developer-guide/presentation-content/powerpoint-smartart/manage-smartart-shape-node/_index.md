---
title: PHP를 사용하여 프레젠테이션에서 SmartArt 도형 노드 관리
linktitle: SmartArt 도형 노드
type: docs
weight: 30
url: /ko/php-java/manage-smartart-shape-node/
keywords:
- SmartArt 노드
- 자식 노드
- 노드 추가
- 노드 위치
- 노드 접근
- 노드 삭제
- 사용자 정의 위치
- 어시스턴트 노드
- 채우기 형식
- 노드 렌더링
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PPT 및 PPTX에서 SmartArt 도형 노드를 관리합니다. 프레젠테이션을 효율화할 수 있는 명확한 코드 샘플 및 팁을 제공합니다."
---
## **개요**

PowerPoint 프레젠테이션의 SmartArt 그래픽은 텍스트를 포함하고 다이어그램 구조를 정의하는 노드를 통해 구성됩니다. Aspose.Slides를 사용하면 이러한 SmartArt 노드를 프로그래밍 방식으로 작업할 수 있습니다: 새 노드 및 자식 노드 추가, 특정 위치에 자식 노드 삽입, 기존 노드에 접근, 텍스트, 레벨 및 위치 읽기.

이 문서에서는 SmartArt 도형 노드를 관리하는 방법을 설명합니다. 노드 삭제, 인덱스 또는 위치를 사용한 자식 노드 작업, 어시스턴트 노드를 일반 노드로 변경, SmartArt 노드 도형의 위치·크기·회전 조정, 노드 채우기 형식 설정 및 SmartArt 자식 노드에 대한 썸네일 이미지 생성 방법을 보여줍니다.

## **SmartArt 노드 추가**
Aspose.Slides for PHP via Java는 SmartArt 도형을 가장 쉽게 관리할 수 있는 API를 제공합니다. 다음 샘플 코드는 SmartArt 도형 내에 노드와 자식 노드를 추가하는 방법을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스를 인스턴스화하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
2. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
3. 첫 번째 슬라이드의 모든 도형을 순회합니다.
4. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/) 유형인지 확인하고 SmartArt인 경우 선택된 도형을 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/)으로 형변환합니다.
5. SmartArt 도형의 [**NodeCollection**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/#getAllNodes)에서 [Add a new Node](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartnodecollection/#addNode) 을 호출하고 TextFrame에 텍스트를 설정합니다.
6. 이제 새로 추가된 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/) 노드에 [Add](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartnodecollection/#addNode) 를 사용하여 [**Child Node**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartnode/#getChildNodes) 를 추가하고 TextFrame에 텍스트를 설정합니다.
7. 프레젠테이션을 저장합니다.

```php
  # 원하는 프레젠테이션 로드
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 첫 번째 슬라이드 내부의 모든 도형을 순회
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # 도형이 SmartArt 유형인지 확인
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 도형을 SmartArt로 형변환
        $smart = $shape;
        # 새 SmartArt 노드 추가
        $TemNode = $smart->getAllNodes()->addNode();
        # 텍스트 추가
        $TemNode->getTextFrame()->setText("Test");
        # 부모 노드에 새 자식 노드 추가. 컬렉션 끝에 추가됩니다
        $newNode = $TemNode->getChildNodes()->addNode();
        # 텍스트 추가
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # 프레젠테이션 저장
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **특정 위치에 SmartArt 노드 추가**
다음 샘플 코드는 SmartArt 도형의 각 노드에 속한 자식 노드를 특정 위치에 추가하는 방법을 설명합니다.

1. Presentation 클래스를 인스턴스화합니다.
2. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
3. 접근한 슬라이드에 [**StackedList**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArtLayoutType#StackedList) 유형의 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArt) 도형을 추가합니다.
4. 추가된 SmartArt 도형에서 첫 번째 노드에 접근합니다.
5. 선택한 [**Node**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArtNode) 에 대해 위치 2에 [**Child Node**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartnode/#getChildNodes) 를 추가하고 텍스트를 설정합니다.
6. 프레젠테이션을 저장합니다.

```php
  # 프레젠테이션 인스턴스 생성
  $pres = new Presentation();
  try {
    # 프레젠테이션 슬라이드에 접근
    $slide = $pres->getSlides()->get_Item(0);
    # Smart Art IShape 추가
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # 인덱스 0에 있는 SmartArt 노드에 접근
    $node = $smart->getAllNodes()->get_Item(0);
    # 부모 노드의 위치 2에 새 자식 노드 추가
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # 텍스트 추가
    $chNode->getTextFrame()->setText("Sample Text Added");
    # 프레젠테이션 저장
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt 노드 접근**
다음 샘플 코드는 SmartArt 도형 내부의 노드에 접근하는 방법을 보여줍니다. SmartArt의 LayoutType은 읽기 전용이며 SmartArt 도형을 추가할 때만 설정된다는 점에 유의하세요.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스를 인스턴스화하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
2. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
3. 첫 번째 슬라이드의 모든 도형을 순회합니다.
4. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/) 유형인지 확인하고 SmartArt인 경우 선택된 도형을 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/)으로 형변환합니다.
5. SmartArt 도형 내부의 모든 [**Nodes**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArt#getAllNodes--) 를 순회합니다.
6. SmartArt 노드의 위치, 레벨 및 텍스트와 같은 정보를 접근하고 표시합니다.

```php
  # Presentation 클래스 인스턴스화
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # 첫 번째 슬라이드 가져오기
    $slide = $pres->getSlides()->get_Item(0);
    # 첫 번째 슬라이드 내부의 모든 도형을 순회
    foreach($slide->getShapes() as $shape) {
      # 도형이 SmartArt 유형인지 확인
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 도형을 SmartArt로 형변환
        $smart = $shape;
        # SmartArt 내부의 모든 노드를 순회
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # 인덱스 i에 있는 SmartArt 노드에 접근
          $node = $smart->getAllNodes()->get_Item($i);
          # SmartArt 노드 매개변수 출력
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt 자식 노드 접근**
다음 샘플 코드는 SmartArt 도형의 각 노드에 속한 자식 노드에 접근하는 방법을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스를 인스턴스화하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
2. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
3. 첫 번째 슬라이드의 모든 도형을 순회합니다.
4. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/) 유형인지 확인하고 SmartArt인 경우 선택된 도형을 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/)으로 형변환합니다.
5. SmartArt 도형 내부의 모든 [**Nodes**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArt#getAllNodes--) 를 순회합니다.
6. 선택된 각 SmartArt 도형 [**Node**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArtNode) 에 대해 해당 노드 내부의 모든 [**Child Nodes**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArtNode#getChildNodes--) 를 순회합니다.
7. [**Child Node**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartnode/#getChildNodes) 의 위치, 레벨 및 텍스트와 같은 정보를 접근하고 표시합니다.

```php
  # Presentation 클래스 인스턴스화
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # 첫 번째 슬라이드 가져오기
    $slide = $pres->getSlides()->get_Item(0);
    # 첫 번째 슬라이드 내부의 모든 도형을 순회
    foreach($slide->getShapes() as $shape) {
      # 도형이 SmartArt 유형인지 확인
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 도형을 SmartArt로 형변환
        $smart = $shape;
        # SmartArt 내부의 모든 노드를 순회
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # 인덱스 i에 있는 SmartArt 노드에 접근
          $node0 = $smart->getAllNodes()->get_Item($i);
          # 인덱스 i에 있는 SmartArt 노드의 자식 노드를 순회
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # SmartArt 노드의 자식 노드에 접근
            $node = $node0->getChildNodes()->get_Item($j);
            # SmartArt 자식 노드 매개변수 출력
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **특정 위치에 SmartArt 자식 노드 접근**
이 예제에서는 SmartArt 도형의 각 노드에 속한 자식 노드를 특정 위치에서 접근하는 방법을 배웁니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
3. [**StackedList**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArtLayoutType#StackedList) 유형의 SmartArt 도형을 추가합니다.
4. 추가된 SmartArt 도형에 접근합니다.
5. 접근한 SmartArt 도형에서 인덱스 0의 노드에 접근합니다.
6. 이제 **get_Item()** 메서드를 사용하여 해당 SmartArt 노드의 위치 1에 있는 [**Child Node**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartnode/#getChildNodes) 에 접근합니다.
7. [**Child Node**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartnode/#getChildNodes) 의 위치, 레벨 및 텍스트와 같은 정보를 접근하고 표시합니다.

```php
  # 프레젠테이션 인스턴스화
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드에 접근
    $slide = $pres->getSlides()->get_Item(0);
    # 첫 번째 슬라이드에 SmartArt 도형 추가
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # 인덱스 0에 있는 SmartArt 노드에 접근
    $node = $smart->getAllNodes()->get_Item(0);
    # 부모 노드의 위치 1에 있는 자식 노드에 접근
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # SmartArt 자식 노드 매개변수 출력
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt 노드 삭제**
이 예제에서는 SmartArt 도형 내부의 노드를 삭제하는 방법을 배웁니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스를 인스턴스화하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
2. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
3. 첫 번째 슬라이드의 모든 도형을 순회합니다.
4. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/) 유형인지 확인하고 SmartArt인 경우 선택된 도형을 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/)으로 형변환합니다.
5. 해당 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/) 에 0개 이상의 노드가 있는지 확인합니다.
6. 삭제할 SmartArt 노드를 선택합니다.
7. 이제 [**removeNode**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartnodecollection/#removeNode) 메서드를 사용하여 선택한 노드를 삭제합니다.
8. 프레젠테이션을 저장합니다.

```php
  # 원하는 프레젠테이션 로드
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # 첫 번째 슬라이드 내부의 모든 도형을 순회
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # 도형이 SmartArt 유형인지 확인
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 도형을 SmartArt로 형변환
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # 인덱스 0에 있는 SmartArt 노드에 접근
          $node = $smart->getAllNodes()->get_Item(0);
          # 선택된 노드 삭제
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # 프레젠테이션 저장
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **특정 위치의 SmartArt 노드 삭제**
이 예제에서는 특정 위치에 있는 SmartArt 도형의 노드를 삭제하는 방법을 배웁니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스를 인스턴스화하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
2. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
3. 첫 번째 슬라이드의 모든 도형을 순회합니다.
4. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/) 유형인지 확인하고 SmartArt인 경우 선택된 도형을 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/)으로 형변환합니다.
5. 인덱스 0에 있는 SmartArt 도형 노드를 선택합니다.
6. 이제 선택한 SmartArt 노드에 2개 이상의 자식 노드가 있는지 확인합니다.
7. **Position 1**에 있는 노드를 [**removeNode**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartnodecollection/#removeNode) 메서드를 사용하여 삭제합니다.
8. 프레젠테이션을 저장합니다.

```php
  # 원하는 프레젠테이션 로드
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # 첫 번째 슬라이드 내부의 모든 도형을 순회
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # 도형이 SmartArt 유형인지 확인
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 도형을 SmartArt로 형변환
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # 인덱스 0에 있는 SmartArt 노드에 접근
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # 위치 1에 있는 자식 노드 삭제
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # 프레젠테이션 저장
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt 개체에서 자식 노드의 사용자 정의 위치 설정**
Aspose.Slides for PHP via Java는 [SmartArtShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArtShape) 의 [X](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#setX) 및 [Y](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#setY) 속성을 설정하는 기능을 지원합니다. 아래 코드 조각은 사용자 정의 SmartArtShape 위치, 크기 및 회전을 설정하는 방법을 보여줍니다. 또한 새 노드를 추가하면 모든 노드의 위치와 크기가 다시 계산된다는 점에 유의하십시오. 사용자 정의 위치 설정을 통해 필요에 따라 노드를 배치할 수 있습니다.

```php
  # Presentation 클래스 인스턴스화
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # SmartArt 도형을 새 위치로 이동
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # SmartArt 도형의 너비 변경
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # SmartArt 도형의 높이 변경
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # SmartArt 도형의 회전 변경
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **어시스턴트 노드 확인**
{{% alert color="primary" %}} 

이 문서에서는 Aspose.Slides for PHP via Java를 사용하여 프레젠테이션 슬라이드에 프로그래밍 방식으로 추가된 SmartArt 도형의 기능을 더 자세히 조사합니다.

{{% /alert %}} 

다음 소스 SmartArt 도형을 사용하여 문서의 여러 섹션을 조사합니다.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**그림: 슬라이드의 원본 SmartArt 도형**|

아래 샘플 코드는 SmartArt 노드 컬렉션에서 **Assistant Nodes** 를 식별하고 변경하는 방법을 조사합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스를 인스턴스화하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
2. 인덱스를 사용하여 두 번째 슬라이드의 참조를 가져옵니다.
3. 첫 번째 슬라이드의 모든 도형을 순회합니다.
4. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/) 유형인지 확인하고 SmartArt인 경우 선택된 도형을 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/)으로 형변환합니다.
5. SmartArt 도형 내부의 모든 노드를 순회하면서 [**Assistant Nodes**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArtNode#isAssistant--) 인지 확인합니다.
6. 어시스턴트 노드의 상태를 일반 노드로 변경합니다.
7. 프레젠테이션을 저장합니다.

```php
  # 프레젠테이션 인스턴스 생성
  $pres = new Presentation("AddNodes.pptx");
  try {
    # 첫 번째 슬라이드 내부의 모든 도형을 순회
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # 도형이 SmartArt 유형인지 확인
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 도형을 SmartArt로 형변환
        $smart = $shape;
        # SmartArt 도형의 모든 노드를 순회
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # 노드가 Assistant 노드인지 확인
          if ($node->isAssistant()) {
            # Assistant 노드를 false로 설정하고 일반 노드로 변경
            $node->isAssistant();
          }
        }
      }
    }
    # 프레젠테이션 저장
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**그림: 슬라이드 내부 SmartArt 도형의 어시스턴트 노드 변경됨**|

## **노드의 채우기 형식 설정**
Aspose.Slides for PHP via Java를 사용하면 사용자 정의 SmartArt 도형을 추가하고 채우기 형식을 설정할 수 있습니다. 이 문서에서는 SmartArt 도형을 만들고 접근하며 채우기 형식을 설정하는 방법을 설명합니다.

다음 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
3. [**LayoutType**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) 을 지정하여 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/) 도형을 추가합니다.
4. SmartArt 도형 노드에 대해 [**Fill Format**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getFillFormat) 을 설정합니다.
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```php
  # 프레젠테이션 인스턴스화
  $pres = new Presentation();
  try {
    # 슬라이드에 접근
    $slide = $pres->getSlides()->get_Item(0);
    # SmartArt 도형 및 노드 추가
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # 노드 채우기 색상 설정
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # 프레젠테이션 저장
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt 자식 노드 썸네일 생성**
다음 단계에 따라 개발자는 SmartArt 자식 노드의 썸네일을 생성할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. [Add SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartnodecollection/#addNode)를 수행합니다.
3. 인덱스를 사용하여 노드의 참조를 가져옵니다.
4. 썸네일 이미지를 가져옵니다.
5. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```php
  # PPTX 파일을 나타내는 Presentation 클래스 인스턴스화
  $pres = new Presentation();
  try {
    # SmartArt 추가
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # 인덱스를 사용해 노드에 대한 참조 얻기
    $node = $smart->getNodes()->get_Item(1);
    # 썸네일 가져오기
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # 썸네일 저장
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
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

## **FAQ**

**SmartArt 애니메이션이 지원되나요?**

예. SmartArt는 일반 도형으로 취급되므로 [표준 애니메이션](/slides/ko/php-java/shape-animation/) (입장, 종료, 강조, 움직임 경로)을 적용하고 타이밍을 조정할 수 있습니다. 필요에 따라 SmartArt 노드 내부의 도형에도 애니메이션을 적용할 수 있습니다.

**슬라이드에서 내부 ID를 알 수 없을 때 특정 SmartArt를 신뢰성 있게 찾는 방법은?**

[대체 텍스트](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getalternativetext/) 로 검색합니다. SmartArt에 고유한 AltText를 설정하면 내부 식별자에 의존하지 않고 프로그래밍 방식으로 찾을 수 있습니다.

**프레젠테이션을 PDF로 변환할 때 SmartArt 모양이 유지되나요?**

예. Aspose.Slides는 [PDF 내보내기](/slides/ko/php-java/convert-powerpoint-to-pdf/) 중 SmartArt를 높은 시각적 충실도로 렌더링하여 레이아웃, 색상 및 효과를 보존합니다.

**전체 SmartArt의 이미지를 추출하여 미리보기나 보고서에 사용하고 싶나요?**

예. SmartArt 도형을 [래스터 형식](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getImage) 또는 [SVG](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/writeassvg/) 로 렌더링하여 썸네일, 보고서 또는 웹용으로 활용할 수 있습니다.