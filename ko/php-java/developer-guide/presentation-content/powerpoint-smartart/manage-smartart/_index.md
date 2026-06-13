---
title: PHP를 사용한 PowerPoint 프레젠테이션에서 SmartArt 관리
linktitle: SmartArt 관리
type: docs
weight: 10
url: /ko/php-java/manage-smartart/
keywords:
- 스마트아트
- 스마트아트 텍스트
- 레이아웃 유형
- 숨김 속성
- 조직도
- 그림 조직도
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "명확한 코드 샘플을 사용하여 Java를 통한 PHP용 Aspose.Slides로 PowerPoint 스마트아트를 만들고 편집하는 방법을 배우고, 슬라이드 디자인 및 자동화를 빠르게 수행하세요."
---
## **개요**

SmartArt는 노드, 노드 모양 및 레이아웃으로 구성된 PowerPoint 다이어그램입니다. Aspose.Slides for PHP via Java를 사용하면 SmartArt를 생성하고, 해당 노드에서 텍스트를 읽으며, 레이아웃을 변경하고, 숨겨진 노드를 검사하고, 조직도 레이아웃을 구성하며, 그림 조직도를 만들 수 있습니다.

## **SmartArt 객체에서 텍스트 가져오기**

SmartArt 노드에는 하나 이상의 모양이 포함될 수 있습니다. 표시되는 텍스트를 읽으려면 [SmartArt::getAllNodes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/#getAllNodes)를 반복하고, 그런 다음 [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartshape/#getTextFrame)이 반환하는 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)을 읽습니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **SmartArt 객체의 레이아웃 유형 변경**

SmartArt 레이아웃은 노드가 배치되고 연결되는 방식을 제어합니다. 다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList` 값을 사용하여 SmartArt 객체를 생성하고, 이를 `BasicProcess` 값으로 변경한 뒤 프레젠테이션을 저장합니다.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SmartArt 노드가 숨겨져 있는지 확인하기**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartnode/ishidden/)는 해당 노드가 SmartArt 데이터 모델에서 숨겨져 있는지 여부를 나타냅니다. 선택한 레이아웃이 노드를 보이는 다이어그램 요소로 표시하지 않더라도 숨겨진 노드는 구조에 존재할 수 있습니다.

다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` 값을 사용하는 SmartArt 객체에 노드를 추가하고 해당 노드의 숨김 상태를 확인합니다.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **조직도 레이아웃 가져오기 또는 설정하기**

조직도 레이아웃을 사용하는 SmartArt 다이어그램의 경우, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) 및 [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartnode/setorganizationchartlayout/)은 부모 노드 아래에서 자식 노드가 어떻게 배치되는지를 정의합니다. 예를 들어, 선택한 [OrganizationChartLayoutType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/organizationchartlayouttype/)에 따라 자식 노드를 왼쪽, 오른쪽 또는 양쪽에 걸치도록 설정할 수 있습니다.

다음 예제는 조직도를 생성하고 첫 번째 노드의 레이아웃을 [OrganizationChartLayoutType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 값으로 설정합니다.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **그림 조직도 만들기**

그림 조직도는 이미지 자리 표시자를 포함하는 계층 다이어그램을 위해 설계된 SmartArt 레이아웃입니다. 슬라이드에 SmartArt 객체를 추가할 때 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 값을 사용하십시오.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**SmartArt가 RTL 언어를 위한 미러링이나 반전을 지원합니까?**

예. 선택한 SmartArt 레이아웃이 반전을 지원하는 경우, [SmartArt::setReversed](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/setreversed/) 메서드는 다이어그램 방향을 왼쪽‑에서‑오른쪽에서 오른쪽‑에서‑왼쪽으로, 또는 다시 전환합니다.

**SmartArt를 같은 슬라이드나 다른 프레젠테이션으로 복사하면서 서식을 유지하려면 어떻게 해야 하나요?**

스마트아트를 포함하는 슬라이드에 대해 [ShapeCollection::addClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addclone/)을 사용하여 [SmartArt 모양을 복제](/slides/ko/php-java/shape-manipulations/)하거나, 전체 슬라이드를 [복제](/slides/ko/php-java/clone-slides/)할 수 있습니다. 두 방법 모두 크기, 위치 및 서식을 유지합니다.

**SmartArt를 미리 보기 또는 웹 내보내기를 위해 래스터 이미지로 렌더링하려면 어떻게 해야 하나요?**

슬라이드 또는 전체 프레젠테이션을 PNG 또는 JPEG 형식으로 [렌더링](/slides/ko/php-java/convert-powerpoint-to-png/)하면 됩니다. SmartArt는 슬라이드의 일부로 렌더링됩니다.

**슬라이드에 여러 개의 SmartArt 객체가 있을 경우 특정 객체를 어떻게 찾을 수 있나요?**

SmartArt 모양에 고유한 [Shape::getAlternativeText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getalternativetext/) 또는 [Shape::getName](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getname/) 값을 설정하고, [BaseSlide::getShapes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseslide/#getShapes)에서 해당 값을 검색한 다음 일치하는 모양이 [SmartArt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartart/)인지 확인하십시오.