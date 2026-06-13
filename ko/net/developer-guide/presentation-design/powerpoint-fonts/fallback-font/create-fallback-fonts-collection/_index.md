---
title: .NET에서 대체 폰트 컬렉션 구성
linktitle: 대체 폰트 컬렉션
type: docs
weight: 20
url: /ko/net/create-fallback-fonts-collection/
keywords:
- 대체 폰트
- 대체 규칙
- 폰트 컬렉션
- 폰트 구성
- 폰트 설정
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 대체 폰트 컬렉션을 설정하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트가 일관되고 선명하게 유지되도록 합니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션에 대한 대체 폰트 규칙 컬렉션을 구성할 수 있습니다. 각 대체 규칙은 `FontFallBackRule` 클래스에 의해 표현되며 `FontFallBackRulesCollection`에 추가할 수 있는데, 이는 `IFontFallBackRulesCollection` 인터페이스를 구현합니다.

컬렉션을 만든 후에는 프레젠테이션의 `FontsManager`에 있는 `FontFallBackRulesCollection` 속성에 할당할 수 있습니다. `FontsManager`는 프레젠테이션 전체의 폰트를 제어하며, 각 `Presentation` 인스턴스는 자체 `FontsManager`를 가집니다.

`FontsManager`가 대체 폰트 컬렉션으로 초기화되면, 지정된 대체 폰트가 프레젠테이션 렌더링 중에 적용됩니다.

## **대체 규칙 적용**

Instances of [FontFallBackRule](https://reference.aspose.com/slides/ko/net/aspose.slides/FontFallBackRule) 클래스의 인스턴스를 [FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/fontfallbackrulescollection)에 구성할 수 있으며, 이는 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontfallbackrulescollection) 인터페이스를 구현합니다. 컬렉션에서 규칙을 추가하거나 제거할 수 있습니다.

그런 다음 이 컬렉션을 [FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) 속성에 할당할 수 있으며, 이는 [FontsManager](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager) 클래스에 속합니다. FontsManager는 프레젠테이션 전체의 폰트를 제어합니다.

각 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation)에는 자체 FontsManager 클래스 인스턴스를 갖는 [FontsManager](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/properties/fontsmanager) 속성이 있습니다.

다음은 특정 프레젠테이션의 FontsManager에 대체 폰트 규칙 컬렉션을 생성하고 할당하는 예시입니다:

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

FontsManager가 대체 폰트 컬렉션으로 초기화된 후, 대체 폰트는 프레젠테이션 렌더링 중에 적용됩니다.

{{% alert color="primary" %}} 
자세히 알아보려면 [대체 폰트로 프레젠테이션 렌더링](/slides/ko/net/render-presentation-with-fallback-font/)를 클릭하세요.
{{% /alert %}}

## **자주 묻는 질문**

**내 대체 규칙이 PPTX 파일에 삽입되어 저장 후 PowerPoint에서 보일까요?**

아니요. 대체 규칙은 런타임 렌더링 설정이며 PPTX에 직렬화되지 않아 PowerPoint UI에 표시되지 않습니다.

**대체 규칙이 SmartArt, WordArt, 차트 및 표 내부의 텍스트에도 적용되나요?**

예. 이러한 객체의 모든 텍스트에 동일한 글리프 대체 메커니즘이 사용됩니다.

**Aspose가 라이브러리와 함께 폰트를 제공하나요?**

아니요. 폰트는 사용자가 직접 추가하고 사용해야 하며, 이는 사용자의 책임입니다.

**누락된 폰트에 대한 교체/대체와 누락된 글리프에 대한 대체를 함께 사용할 수 있나요?**

예. 이들은 동일한 폰트 해결 파이프라인의 독립적인 단계이며, 먼저 엔진이 폰트 가용성을 해결합니다([replacement](/slides/ko/net/font-replacement/)/[substitution](/slides/ko/net/font-substitution/)). 그런 다음 대체가 사용 가능한 폰트에서 누락된 글리프의 빈틈을 메웁니다.