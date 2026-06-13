---
title: 하이퍼링크
type: docs
weight: 130
url: /ko/php-java/examples/elements/hyperlink/
keywords:
- 하이퍼링크
- 하이퍼링크 추가
- 하이퍼링크 액세스
- 하이퍼링크 제거
- 하이퍼링크 업데이트
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP와 Aspose.Slides를 사용하여 하이퍼링크를 추가, 편집 및 제거합니다: 텍스트, 도형, 슬라이드, URL 및 이메일에 대한 링크; PPT, PPTX 및 ODP에 대한 대상 및 동작을 설정합니다."
---
**Aspose.Slides for PHP via Java**를 사용하여 도형에 대한 하이퍼링크를 추가, 액세스, 제거 및 업데이트하는 방법을 보여줍니다.

## **하이퍼링크 추가**

외부 웹사이트를 가리키는 하이퍼링크가 포함된 사각형 도형을 만듭니다.

```php
function addHyperlink() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
        $shape->getTextFrame()->setText("Aspose");

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        $presentation->save("hyperlink.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **하이퍼링크 액세스**

도형 텍스트 부분에서 하이퍼링크 정보를 읽어옵니다.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 첫 번째 도형에 하이퍼링크가 포함되어 있다고 가정합니다.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **하이퍼링크 제거**

도형 텍스트에서 하이퍼링크를 제거합니다.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 첫 번째 도형에 하이퍼링크가 포함되어 있다고 가정합니다.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(null);

        $presentation->save("hyperlink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **하이퍼링크 업데이트**

기존 하이퍼링크의 대상을 변경합니다. `HyperlinkManager`를 사용하여 이미 하이퍼링크가 포함된 텍스트를 수정함으로써 PowerPoint가 하이퍼링크를 안전하게 업데이트하는 방식을 모방합니다.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 첫 번째 도형에 하이퍼링크가 포함되어 있다고 가정합니다.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // 기존 텍스트 내에서 하이퍼링크를 변경하려면
        // 속성을 직접 설정하는 대신 HyperlinkManager를 사용해야 합니다.
        // 이는 PowerPoint가 하이퍼링크를 안전하게 업데이트하는 방식을 모방합니다.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```