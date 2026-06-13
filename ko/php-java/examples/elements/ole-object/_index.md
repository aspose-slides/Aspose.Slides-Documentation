---
title: OLE 객체
type: docs
weight: 210
url: /ko/php-java/examples/elements/ole-object/
keywords:
- OLE 객체
- OLE 객체 추가
- OLE 객체 접근
- OLE 객체 제거
- OLE 객체 업데이트
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 OLE 객체를 작업합니다: 삽입 또는 업데이트된 파일을 삽입하거나, 아이콘이나 링크를 설정하고, 콘텐츠를 추출하며, PPT, PPTX 및 ODP에 대한 동작을 제어합니다."
---
**Aspose.Slides for PHP via Java**를 사용하여 파일을 OLE 개체로 삽입하고 해당 데이터를 업데이트하는 방법을 보여줍니다.

## **OLE 개체 추가**

프레젠테이션에 PDF 파일을 삽입합니다.

```php
function addOleObject() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $pdfData = new OleEmbeddedDataInfo(file_get_contents("doc.pdf"), "pdf");
        $oleFrame = $slide->getShapes()->addOleObjectFrame(20, 20, 50, 50, $pdfData);

        $presentation->save("ole_object.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **OLE 개체 접근**

슬라이드에서 첫 번째 OLE 개체 프레임을 가져옵니다.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드에서 첫 번째 OLE 프레임에 접근합니다.
        $firstOleFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $firstOleFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **OLE 개체 제거**

슬라이드에서 삽입된 OLE 개체를 삭제합니다.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드의 첫 번째 도형이 OLE 프레임이라고 가정합니다.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **OLE 개체 데이터 업데이트**

기존 OLE 개체에 삽입된 데이터를 교체합니다.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드의 첫 번째 도형이 OLE 프레임이라고 가정합니다.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```