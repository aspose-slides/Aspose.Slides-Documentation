---
title: Vba 매크로
type: docs
weight: 150
url: /ko/php-java/examples/elements/vba-macro/
keywords:
- vba 매크로
- vba 매크로 추가
- vba 매크로 액세스
- vba 매크로 제거
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 VBA 매크로 작업: 프로젝트와 모듈을 추가하거나 편집하고, 매크로에 서명하거나 제거하며, 프레젠테이션을 PPT, PPTX 및 ODP 형식으로 저장합니다."
---
**Aspose.Slides for PHP via Java**를 사용하여 VBA 매크로를 추가, 액세스 및 제거하는 방법을 보여줍니다.

## **VBA 매크로 추가**

VBA 프로젝트와 간단한 매크로 모듈이 포함된 프레젠테이션을 생성합니다.

```php
function addVbaMacro() {
    $presentation = new Presentation();
    try {
        $presentation->setVbaProject(new VbaProject());

        $module = $presentation->getVbaProject()->getModules()->addEmptyModule("Module");
        $module->setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        $presentation->save("vba_macro.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```

## **VBA 매크로 액세스**

VBA 프로젝트에서 첫 번째 모듈을 가져옵니다.

```php
function accessVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        $firstModule = $presentation->getVbaProject()->getModules()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **VBA 매크로 제거**

VBA 프로젝트에서 모듈을 삭제합니다.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // VBA 프로젝트에 최소 하나의 모듈이 있다고 가정합니다.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```