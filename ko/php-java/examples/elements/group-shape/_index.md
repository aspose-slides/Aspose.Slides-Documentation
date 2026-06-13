---
title: 그룹 도형
type: docs
weight: 170
url: /ko/php-java/examples/elements/group-shape/
keywords:
- 그룹
- 그룹 도형 추가
- 그룹 도형 접근
- 그룹 도형 제거
- 그룹 해제
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 그룹 도형을 작업합니다: 생성 및 그룹 해제, 자식 도형 순서 변경, 변환 및 경계를 PowerPoint와 OpenDocument 전체에 설정합니다."
---
**Aspose.Slides for PHP via Java**를 사용하여 도형 그룹을 만들고, 접근하고, 그룹 해제 및 제거하는 예제입니다.

## **그룹 도형 추가**

두 개의 기본 도형을 포함하는 그룹을 생성합니다.

```php
function addGroupShape() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $group = $slide->getShapes()->addGroupShape();
        $group->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $group->getShapes()->addAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

        $presentation->save("group_shape.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **그룹 도형 접근**

슬라이드에서 첫 번째 그룹 도형을 가져옵니다.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드에서 첫 번째 그룹 도형에 접근합니다.
        $firstGroup = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $firstGroup = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **그룹 도형 제거**

슬라이드에서 그룹 도형을 삭제합니다.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // 슬라이드의 첫 번째 도형이 그룹 도형이라고 가정합니다.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **그룹 해제**

그룹 컨테이너에서 도형을 이동합니다.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드의 첫 번째 도형이 그룹 도형이라고 가정합니다.
        $group = $slide->getShapes()->get_Item(0);

        // 그룹에서 각 도형을 복제하여 슬라이드에 추가합니다.
        $shapeCount = java_values($group->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $group->getShapes()->get_Item($index);
            $slide->getShapes()->addClone($shape);
        }

        $slide->getShapes()->remove($group);

        $presentation->save("ungrouped_shapes.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```