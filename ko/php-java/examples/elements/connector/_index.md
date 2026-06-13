---
title: 커넥터
type: docs
weight: 190
url: /ko/php-java/examples/elements/connector/
keywords:
- 커넥터
- 커넥터 추가
- 커넥터 접근
- 커넥터 제거
- 도형 재연결
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 커넥터를 그리고 제어합니다: 커넥터를 추가하고, 경로를 지정하거나 재지정하며, 연결 지점, 화살표 및 스타일을 설정하여 PPT, PPTX 및 ODP의 도형을 연결합니다."
---
**Aspose.Slides for PHP via Java**를 사용하여 도형을 커넥터로 연결하고 대상을 변경하는 방법을 보여줍니다.

## **커넥터 추가**

슬라이드의 두 지점 사이에 커넥터 모양을 삽입합니다.

```php
function addConnector() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $connector = $slide->Shapes->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $presentation->save("connector.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **커넥터 액세스**

슬라이드에 추가된 첫 번째 커넥터 모양을 가져옵니다.

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드에서 첫 번째 커넥터에 접근합니다.
        $firstConnector = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $firstConnector = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **커넥터 제거**

슬라이드에서 커넥터를 삭제합니다.

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드의 첫 번째 도형이 커넥터라고 가정합니다.
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **도형 재연결**

시작 및 끝 대상을 할당하여 커넥터를 두 도형에 연결합니다.

```php
function reconnectShapes() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
        $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $connector->setStartShapeConnectedTo($shape1);
        $connector->setEndShapeConnectedTo($shape2);

        $presentation->save("shapes_reconnected.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```