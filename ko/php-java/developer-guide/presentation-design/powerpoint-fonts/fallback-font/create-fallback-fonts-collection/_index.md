---
title: PHP에서 대체 폰트 컬렉션 구성
linktitle: 대체 폰트 컬렉션
type: docs
weight: 20
url: /ko/php-java/create-fallback-fonts-collection/
keywords:
- 대체 폰트
- 대체 규칙
- 폰트 컬렉션
- 폰트 구성
- 폰트 설정
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java에서 대체 폰트 컬렉션을 설정하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 일관되고 선명하게 유지합니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션에 대한 대체 폰트 규칙 컬렉션을 구성할 수 있습니다. 각 대체 규칙은 `FontFallBackRule` 클래스에 의해 표현되며 `FontFallBackRulesCollection`에 추가할 수 있습니다.

컬렉션을 만든 후에는 프레젠테이션의 `FontsManager`의 `setFontFallBackRulesCollection` 메서드를 사용하여 할당할 수 있습니다. `FontsManager`는 프레젠테이션 전반에 걸친 폰트를 제어하며, 각 `Presentation` 인스턴스는 자체 `FontsManager`를 가집니다.

`FontsManager`가 대체 폰트 컬렉션으로 초기화되면, 지정된 대체 폰트가 프레젠테이션 렌더링 중에 적용됩니다.

## **대체 규칙 적용**

`FontFallBackRule` 클래스의 인스턴스를 `FontFallBackRulesCollection`에 구성할 수 있습니다. 컬렉션에서 규칙을 추가하거나 제거할 수 있습니다.

그런 다음 이 컬렉션을 `FontsManager` 클래스의 `FontFallBackRulesCollection` 메서드에 할당할 수 있습니다. FontsManager는 프레젠테이션 전체의 폰트를 제어합니다.

각 `Presentation`에는 자체 `FontsManager` 인스턴스를 반환하는 `getFontsManager` 메서드가 있습니다.

다음은 특정 프레젠테이션의 `FontsManager`에 대체 폰트 규칙 컬렉션을 생성하고 할당하는 예제입니다:  

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

`FontsManager`가 대체 폰트 컬렉션으로 초기화된 후에는, 대체 폰트가 프레젠테이션 렌더링 중에 적용됩니다.

{{% alert color="primary" %}} 
자세히 보려면 [대체 폰트로 프레젠테이션 렌더링](/slides/ko/php-java/render-presentation-with-fallback-font/)을(를) 읽어보세요.
{{% /alert %}}

## **FAQ**

**내 대체 규칙이 PPTX 파일에 포함되어 저장 후 PowerPoint에서 보이게 됩니까?**

아니요. 대체 규칙은 런타임 렌더링 설정이며 PPTX에 직렬화되지 않으므로 PowerPoint UI에 나타나지 않습니다.

**대체 규칙이 SmartArt, WordArt, 차트 및 표 내부의 텍스트에도 적용됩니까?**

예. 이러한 객체의 텍스트에도 동일한 글리프 치환 메커니즘이 사용됩니다.

**Aspose가 라이브러리와 함께 폰트를 배포합니까?**

아니요. 폰트는 사용자가 직접 추가하고 사용하며, 이는 사용자 책임 하에 이루어집니다.

**누락된 폰트에 대한 교체/치환과 누락된 글리프에 대한 대체를 함께 사용할 수 있습니까?**

예. 이들은 동일한 폰트 해석 파이프라인의 독립적인 단계입니다. 먼저 엔진이 폰트 가용성을 해결하고([replacement](/slides/ko/php-java/font-replacement/)/[substitution](/slides/ko/php-java/font-substitution/)), 그 다음 대체가 사용 가능한 폰트의 누락된 글리프를 채웁니다.