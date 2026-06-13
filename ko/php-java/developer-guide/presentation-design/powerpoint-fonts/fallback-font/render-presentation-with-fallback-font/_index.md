---
title: PHP에서 대체 글꼴을 사용하여 프레젠테이션 렌더링
linktitle: 프레젠테이션 렌더링
type: docs
weight: 30
url: /ko/php-java/render-presentation-with-fallback-font/
keywords:
  - 대체 글꼴
  - PowerPoint 렌더링
  - 프레젠테이션 렌더링
  - 슬라이드 렌더링
  - PowerPoint
  - OpenDocument
  - 프레젠테이션
  - PHP
  - Aspose.Slides
description: "Aspose.Slides for PHP via Java에서 대체 글꼴을 사용하여 프레젠테이션을 렌더링합니다 – PPT, PPTX 및 ODP에서 텍스트를 일관되게 유지하는 단계별 코드 샘플을 제공합니다."
---
## **개요**

Aspose.Slides는 대체 글꼴 규칙을 사용하여 프레젠테이션을 렌더링할 수 있습니다. 이 문서에서는 대체 글꼴 규칙 컬렉션을 생성하고, 규칙을 제거하거나 대체 글꼴을 추가하여 수정하는 방법과 `FontsManager::setFontFallBackRulesCollection` 메서드에 컬렉션을 할당하는 방법을 보여줍니다.

대체 글꼴 규칙 컬렉션이 프레젠테이션의 `FontsManager`에 할당되면 저장, 렌더링, 변환과 같은 작업 중에 규칙이 적용됩니다. 이 예제에서는 슬라이드 썸네일을 렌더링하고 PNG 이미지로 저장할 때 구성된 규칙을 사용하는 방법을 보여줍니다.

## **대체 글꼴 규칙을 사용하여 슬라이드 렌더링**

1. [대체 글꼴 규칙 컬렉션 만들기](/slides/ko/php-java/create-fallback-fonts-collection/).
2. [제거](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) 대체 글꼴 규칙을 제거하고 다른 규칙에 [addFallBackFonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)를 추가합니다.
3. 규칙 컬렉션을 [getFontsManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) 메서드에 설정합니다.
4. [Presentation.save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation#save-java.lang.String-int-) 메서드를 사용하면 프레젠테이션을 동일한 형식으로 저장하거나 다른 형식으로 저장할 수 있습니다. 대체 글꼴 규칙 컬렉션이 [FontsManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FontsManager)에 설정된 후, 이러한 규칙은 저장, 렌더링, 변환 등 프레젠테이션에 대한 모든 작업 중에 적용됩니다.

```php
  # 규칙 컬렉션의 새 인스턴스 생성
  $rulesList = new FontFallBackRulesCollection();
  # 여러 규칙 생성
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # 로드된 규칙에서 대체 글꼴 "Tahoma"를 제거하려고 시도함
    $fallBackRule->remove("Tahoma");
    # 그리고 지정된 범위에 대한 규칙을 업데이트함
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # 또한 목록에서 기존 규칙을 모두 제거할 수 있음
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # 사용을 위해 준비된 규칙 목록 할당
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # 초기화된 규칙 컬렉션을 사용하여 썸네일을 렌더링하고 JPEG로 저장
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # 이미지를 JPEG 형식으로 디스크에 저장
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
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

{{% alert color="primary" %}} 
자세히 알아보려면 [PHP에서 PPT 및 PPTX를 JPG로 변환](/slides/ko/php-java/convert-powerpoint-to-jpg/)을 참조하십시오.
{{% /alert %}}