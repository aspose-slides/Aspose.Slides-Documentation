---
title: С++에서 대체 글꼴 컬렉션 구성
linktitle: 대체 글꼴 컬렉션
type: docs
weight: 20
url: /ko/cpp/create-fallback-fonts-collection/
keywords:
- 대체 글꼴
- 대체 규칙
- 글꼴 컬렉션
- 글꼴 구성
- 글꼴 설정
- PowerPoint
- OpenDocument
- 프레젠테이션
- С++
- Aspose.Slides
description: "Aspose.Slides에서 С++용 대체 글꼴 컬렉션을 설정하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 일관되고 선명하게 유지합니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션에 대한 대체 글꼴 규칙 컬렉션을 구성할 수 있습니다. 각 대체 규칙은 `FontFallBackRule` 클래스에 의해 표현되며, `IFontFallBackRulesCollection` 인터페이스를 구현하는 `FontFallBackRulesCollection`에 추가할 수 있습니다.

컬렉션을 만든 후에는 프레젠테이션의 `FontsManager`에 있는 `set_FontFallBackRulesCollection` 메서드를 사용하여 할당할 수 있습니다. `FontsManager`는 프레젠테이션 전체의 글꼴을 제어하며, 각 `Presentation` 인스턴스는 자체 `FontsManager`를 가집니다.

`FontsManager`가 대체 글꼴 컬렉션으로 초기화되면, 지정된 대체 글꼴이 프레젠테이션 렌더링 중에 적용됩니다.

## **대체 규칙 적용**

`FontFallBackRule` 클래스의 인스턴스를 [FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrulescollection/)에 구성할 수 있으며, 이는 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontfallbackrulescollection/) 인터페이스를 구현합니다. 컬렉션에서 규칙을 추가하거나 제거할 수 있습니다.

그런 다음 이 컬렉션을 [FontsManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/) 클래스의 [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) 메서드에 전달할 수 있습니다. FontsManager는 프레젠테이션 전체의 글꼴을 제어합니다.

각 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)은 자체 FontsManager 클래스 인스턴스를 반환하는 [get_FontsManager()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_fontsmanager/) 메서드를 가집니다.

다음은 특정 프레젠테이션의 FontsManager에 대체 글꼴 규칙 컬렉션을 생성하고 할당하는 예시입니다:

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

FontsManager가 대체 글꼴 컬렉션으로 초기화된 후, 대체 글꼴은 프레젠테이션 렌더링 중에 적용됩니다.

{{% alert color="primary" %}} 
대체 글꼴을 사용한 프레젠테이션 렌더링에 대해 자세히 알아보려면 [대체 글꼴을 사용한 프레젠테이션 렌더링](/slides/ko/cpp/render-presentation-with-fallback-font/)을(를) 참조하세요.
{{% /alert %}}

## **FAQ**

**내 대체 규칙이 PPTX 파일에 포함되어 저장 후 PowerPoint에서 보이게 됩니까?**

아니요. 대체 규칙은 런타임 렌더링 설정이며 PPTX에 직렬화되지 않으므로 PowerPoint UI에 표시되지 않습니다.

**대체 규칙이 SmartArt, WordArt, 차트 및 표 내부의 텍스트에도 적용됩니까?**

예. 이러한 객체의 모든 텍스트에 동일한 글리프 교체 메커니즘이 사용됩니다.

**Aspose가 라이브러리와 함께 폰트를 배포합니까?**

아니요. 폰트는 사용자가 직접 추가하고 사용하며, 모든 책임은 사용자에게 있습니다.

**누락된 폰트에 대한 교체/대체와 누락된 글리프에 대한 대체를 동시에 사용할 수 있습니까?**

예. 두 단계는 동일한 글꼴 해석 파이프라인의 독립적인 단계이며, 먼저 엔진이 글꼴 가용성을 해결하고([replacement](/slides/ko/cpp/font-replacement/)/[substitution](/slides/ko/cpp/font-substitution/)), 그 다음 대체가 사용 가능한 글꼴에서 누락된 글리프를 메꿉니다.