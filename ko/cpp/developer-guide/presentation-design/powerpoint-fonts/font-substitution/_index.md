---
title: C++를 사용한 프레젠테이션에서 폰트 대체 구성
linktitle: 폰트 대체
type: docs
weight: 70
url: /ko/cpp/font-substitution/
keywords:
- 폰트
- 대체 폰트
- 폰트 대체
- 폰트 교체
- 폰트 교체
- 대체 규칙
- 교체 규칙
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "PowerPoint 및 OpenDocument 프레젠테이션을 다른 파일 형식으로 변환할 때 C++용 Aspose.Slides에서 최적의 폰트 대체를 활성화합니다."
---
## **개요**

폰트 대체는 Aspose.Slides가 렌더링이나 변환 중에 원본 프레젠테이션 폰트를 사용할 수 없을 때 다른 폰트를 사용하도록 합니다. `IFontsManager` 인터페이스의 `GetSubstitutions` 메서드를 사용하여 대체된 폰트를 확인할 수 있습니다.

Aspose.Slides는 폰트 대체 규칙을 정의할 수도 있습니다. 예를 들어, 접근할 수 없는 폰트를 다른 사용 가능한 폰트로 교체하도록 지정하고 해당 규칙을 프레젠테이션의 폰트 관리자를 통해 적용할 수 있습니다.

## **폰트 대체 규칙 설정**

Aspose.Slides는 특정 조건(예: 폰트를 액세스할 수 없을 때)에서 수행해야 할 작업을 결정하는 폰트 규칙을 다음과 같이 설정할 수 있습니다:

1. 관련 프레젠테이션을 로드합니다.
2. 교체될 폰트를 로드합니다.
3. 새 폰트를 로드합니다.
4. 교체 규칙을 추가합니다.
5. 프레젠테이션 폰트 교체 규칙 컬렉션에 규칙을 추가합니다.
6. 슬라이드 이미지를 생성하여 효과를 확인합니다.

다음 C++ 코드는 폰트 대체 과정을 보여줍니다:

```c++
// 문서 디렉터리 경로.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// 프레젠테이션을 로드합니다.
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// 교체될 폰트와 새 폰트를 정의합니다.
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// 폰트 교체를 위한 규칙을 추가합니다.
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// 규칙을 폰트 대체 규칙 컬렉션에 추가합니다.
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// 폰트 규칙 컬렉션을 규칙 목록에 추가합니다.
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// PPTX를 디스크에 저장합니다.
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
다음의 [**폰트 교체**](/slides/ko/cpp/font-replacement/)을 확인하고 싶을 수 있습니다. 
{{% /alert %}}

## **수식 폰트에 대한 제한 사항**

폰트 대체 규칙은 렌더링 및 변환 중에 사용되는 표준 폰트 선택 과정에 참여합니다. 구성된 규칙에 따라 Aspose.Slides가 접근할 수 없는 폰트를 다른 사용 가능한 폰트로 교체할 수 있는 일반 텍스트 시나리오에 적합합니다.

하지만 Office 수식에는 중요한 제한이 있습니다. 수식이 **Cambria Math**로 작성된 경우, Aspose.Slides는 수식 레이아웃을 정확히 계산하고 렌더링하기 위해 원본 **Cambria Math** 폰트를 여전히 필요로 할 수 있습니다. 따라서 **Cambria Math**를 **STIX Two Math**와 같은 다른 수학 폰트로 대체하는 것은 수식 렌더링에서 지원되지 않으며, 여전히 **Cambria Math**가 필요하다는 예외가 발생할 수 있습니다.

이러한 프레젠테이션을 성공적으로 변환하려면 런타임에 **Cambria Math**가 Aspose.Slides에서 사용할 수 있도록 해야 합니다. 운영 체제에 폰트를 설치하거나 [외부 폰트](/slides/ko/cpp/custom-font/)로 제공하여 렌더링 및 변환 중에 일반 폰트 선택 과정에 참여하도록 할 수 있습니다.

이 제한은 수식 렌더링에만 해당됩니다. 위에서 설명한 표준 폰트 대체 규칙은 원본 폰트를 사용할 수 없을 때 일반 프레젠테이션 텍스트에도 여전히 적용됩니다.

## **FAQ**

**폰트 교체와 폰트 대체의 차이점은 무엇입니까?**  
[교체](/slides/ko/cpp/font-replacement/)는 프레젠테이션 전체에서 한 폰트를 다른 폰트로 강제로 교체하는 것입니다. 대체는 특정 조건(예: 원본 폰트를 사용할 수 없을 때)에서 트리거되는 규칙으로, 지정된 대체 폰트를 사용합니다.

**대체 규칙은 정확히 언제 적용합니까?**  
규칙은 로딩, 렌더링 및 변환 중에 평가되는 표준 [폰트 선택](/slides/ko/cpp/font-selection-sequence/) 순서에 참여합니다; 선택된 폰트를 사용할 수 없으면 교체 또는 대체가 적용됩니다.

**시스템에 폰트가 없고 교체와 대체가 모두 구성되지 않은 경우 기본 동작은 무엇입니까?**  
라이브러리는 PowerPoint가 동작하는 방식과 유사하게 가장 가까운 사용 가능한 시스템 폰트를 선택하려고 시도합니다.

**런타임에 사용자 정의 외부 폰트를 첨부하여 대체를 방지할 수 있습니까?**  
예. 런타임에 [외부 폰트 추가](/slides/ko/cpp/custom-font/)를 통해 라이브러리가 선택 및 렌더링 시 해당 폰트를 고려하도록 할 수 있으며, 이후 변환에도 적용됩니다.

**Aspose가 라이브러리와 함께 폰트를 배포합니까?**  
아니요. Aspose는 유료든 무료든 폰트를 배포하지 않으며, 폰트는 사용자가 직접 추가하고 책임하에 사용해야 합니다.

**Windows, Linux 및 macOS에서 대체 동작에 차이가 있습니까?**  
예. 폰트 검색은 운영 체제의 폰트 디렉터리에서 시작합니다. 기본 제공 폰트 집합 및 검색 경로는 플랫폼마다 다르며, 이는 폰트 가용성 및 대체 필요성에 영향을 줍니다.

**배치 변환 시 예상치 못한 대체를 최소화하려면 환경을 어떻게 준비해야 합니까?**  
머신이나 컨테이너 간에 폰트 세트를 동기화하고, 출력 문서에 필요한 [외부 폰트 추가](/slides/ko/cpp/custom-font/)를 적용하며, 가능하면 프레젠테이션에 [폰트 포함](/slides/ko/cpp/embedded-font/)을 수행하여 렌더링 중에 선택된 폰트를 사용할 수 있도록 합니다.