---
title: PHP에서 프레젠테이션에서 Flash 개체 추출
linktitle: Flash
type: docs
weight: 10
url: /ko/php-java/flash/
keywords:
- Flash 추출
- Flash 개체
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 Flash 개체를 추출하는 방법을 배우고, 완전한 코드 샘플과 모범 사례를 확인하십시오."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션에서 Flash 개체를 추출하는 방법을 설명합니다. 슬라이드의 컨트롤 컬렉션에서 이름으로 Flash 컨트롤을 찾고 포함된 SWF 개체 데이터를 처리하는 방법을 보여줍니다.

## **프레젠테이션에서 Flash 개체 추출**

Aspose.Slides for PHP via Java는 프레젠테이션에서 Flash 개체를 추출하는 기능을 제공합니다. 이름으로 Flash 컨트롤에 접근하여 프레젠테이션에서 추출하고 SWF 개체 데이터를 저장할 수 있습니다.

```php
  # PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    $controls = $pres->getSlides()->get_Item(0)->getControls();
    $flashControl = null;
    foreach($controls as $control) {
      if (java_values($control->getName()) == "ShockwaveFlash1") {
        $flashControl = $control;
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Flash 콘텐츠를 추출할 때 지원되는 프레젠테이션 형식은 무엇입니까?**

[Aspose.Slides supports](/slides/ko/php-java/supported-file-formats/)는 PPT 및 PPTX와 같은 주요 PowerPoint 형식을 지원합니다. 이러한 컨테이너를 로드하고 컨트롤에 접근할 수 있으며, Flash 관련 ActiveX 요소도 포함됩니다.

**Flash가 포함된 프레젠테이션을 HTML5로 변환하면서 Flash 인터랙티브성을 유지할 수 있습니까?**

아니요. Aspose.Slides는 SWF 콘텐츠를 실행하거나 인터랙티브성을 변환하지 않습니다. [HTML](/slides/ko/php-java/convert-powerpoint-to-html/)/[HTML5](/slides/ko/php-java/export-to-html5/)로의 내보내기는 지원되지만, 지원이 종료된 현대 브라우저에서는 Flash가 재생되지 않습니다. 권장 방법은 내보내기 전에 Flash를 비디오나 HTML5 애니메이션과 같은 대체 요소로 교체하는 것입니다.

**보안 관점에서 Aspose.Slides가 프레젠테이션을 읽는 동안 SWF 파일을 실행합니까?**

아니요. Aspose.Slides는 Flash를 파일에 삽입된 이진 데이터로 취급하며 처리 중에 SWF 콘텐츠를 실행하지 않습니다.

**OLE를 통해 다른 삽입 파일과 함께 Flash가 포함된 프레젠테이션을 어떻게 처리해야 합니까?**

Aspose.Slides는 [extracting embedded OLE objects](/slides/ko/php-java/manage-ole/)를 지원하므로 한 번에 모든 관련 삽입 콘텐츠를 처리할 수 있으며, Flash 컨트롤과 다른 OLE 삽입 문서를 함께 처리할 수 있습니다.