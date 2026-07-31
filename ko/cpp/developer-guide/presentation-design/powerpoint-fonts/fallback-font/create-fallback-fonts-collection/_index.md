---
title: C++에서 대체 폰트 컬렉션 구성
linktitle: 대체 폰트 컬렉션
type: docs
weight: 20
url: /ko/cpp/create-fallback-fonts-collection/
keywords:
- 대체 폰트
- 대체 규칙
- 폰트 컬렉션
- 폰트 구성
- 폰트 설정
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++용 Aspose.Slides에서 대체 폰트 컬렉션을 설정하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트를 일관되고 선명하게 유지합니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션에 대한 폰트 대체 규칙 컬렉션을 구성할 수 있습니다. 각 대체 규칙은 `FontFallBackRule` 클래스에 의해 표현되며, `IFontFallBackRulesCollection` 인터페이스를 구현하는 `FontFallBackRulesCollection`에 추가할 수 있습니다.

컬렉션을 만든 후에는 프레젠테이션의 `FontsManager`에 있는 `set_FontFallBackRulesCollection` 메서드를 사용하여 할당할 수 있습니다. `FontsManager`는 프레젠테이션 전체의 폰트를 제어하며, 각 `Presentation` 인스턴스는 자체 `FontsManager`를 갖습니다.

`FontsManager`가 대체 폰트 컬렉션으로 초기화되면, 지정된 대체 폰트가 프레젠테이션 렌더링 중에 적용됩니다.

## **대체 규칙 적용**

Instances of [FontFallBackRule](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrule/) 클래스는 [FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrulescollection/)에 정리할 수 있으며, 이는 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontfallbackrulescollection/) 인터페이스를 구현합니다. 컬렉션에서 규칙을 추가하거나 제거할 수 있습니다.

그런 다음 이 컬렉션을 [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) 메서드에 전달할 수 있으며, 이는 [FontsManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/) 클래스의 메서드입니다. FontsManager는 프레젠테이션 전체의 폰트를 제어합니다.

각 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)에는 자체 FontsManager 인스턴스를 반환하는 [get_FontsManager()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_fontsmanager/) 메서드가 있습니다.

다음은 특정 프레젠테이션의 FontsManager에 대체 폰트 규칙 컬렉션을 생성하고 할당하는 예시입니다:

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

FontsManager가 대체 폰트 컬렉션으로 초기화되면, 대체 폰트가 프레젠테이션 렌더링 중에 적용됩니다.

{{% alert color="primary" %}} 
대체 폰트로 프레젠테이션을 렌더링하는 방법에 대해 자세히 알아보려면 [대체 폰트로 프레젠테이션 렌더링](/slides/ko/cpp/render-presentation-with-fallback-font/)을 읽어보세요.
{{% /alert %}}

## **FAQ**

**내 대체 규칙이 PPTX 파일에 포함되어 저장 후 PowerPoint에서 보이게 되나요?**

아니요. 대체 규칙은 실행 시 렌더링 설정이며, PPTX에 직렬화되지 않으므로 PowerPoint UI에 표시되지 않습니다.

**대체 규칙이 SmartArt, WordArt, 차트 및 표 내부의 텍스트에도 적용되나요?**

예. 이러한 객체의 모든 텍스트에 동일한 글리프 대체 메커니즘이 적용됩니다.

**Aspose가 라이브러리와 함께 폰트를 배포하나요?**

아니요. 폰트는 사용자가 직접 추가하고 사용하며, 이는 사용자 책임하에 이루어집니다.

**누락된 폰트에 대한 교체/대체와 누락된 글리프에 대한 대체를 함께 사용할 수 있나요?**

예. 이들은 동일한 폰트 해석 파이프라인의 독립적인 단계이며, 먼저 엔진이 폰트 가용성을 해결하고([replacement](/slides/ko/cpp/font-replacement/)/[substitution](/slides/ko/cpp/font-substitution/)), 그 다음 대체가 사용 가능한 폰트에서 누락된 글리프의 공백을 메웁니다.