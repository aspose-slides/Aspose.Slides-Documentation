---
title: ActiveX
type: docs
weight: 200
url: /ko/php-java/examples/elements/activex/
keywords:
- ActiveX
- ActiveX 컨트롤
- ActiveX 추가
- ActiveX 액세스
- ActiveX 제거
- ActiveX 속성
- 코드 예제
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP와 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션의 속성 업데이트를 포함한 ActiveX 컨트롤을 찾고, 편집하고, 제거하는 방법을 배우세요."
---
프레젠테이션에서 **Aspose.Slides for PHP via Java**를 사용하여 ActiveX 컨트롤을 추가, 액세스, 제거 및 구성하는 방법을 보여줍니다.

## **ActiveX 컨트롤 추가**

새 ActiveX 컨트롤을 삽입합니다.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 새 ActiveX 컨트롤을 추가합니다.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // 프레젠테이션을 해제합니다.
        $presentation->dispose();
    }
}
```

## **ActiveX 컨트롤에 액세스**

슬라이드의 첫 번째 ActiveX 컨트롤에서 정보를 읽어옵니다.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 첫 번째 ActiveX 컨트롤에 액세스합니다.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // 프레젠테이션을 해제합니다.
        $presentation->dispose();
    }
}
```

## **ActiveX 컨트롤 제거**

슬라이드에서 기존 ActiveX 컨트롤을 삭제합니다.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // 첫 번째 ActiveX 컨트롤을 제거합니다.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // 프레젠테이션을 해제합니다.
        $presentation->dispose();
    }
}
```

## **ActiveX 속성 설정**

여러 ActiveX 속성을 구성합니다.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 첫 번째 컨트롤이 우리가 추가한 것이라고 가정합니다.
        $control = $slide->getControls()->get_Item(0);

        // 속성을 구성합니다.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // 프레젠테이션을 해제합니다.
        $presentation->dispose();
    }
}
```