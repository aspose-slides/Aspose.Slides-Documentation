---
title: Android 프레젠테이션에서 폰트 대체 구성
linktitle: 폰트 대체
type: docs
weight: 70
url: /ko/androidjava/font-substitution/
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint 및 OpenDocument 프레젠테이션을 다른 파일 형식으로 변환할 때 Java를 통해 Android용 Aspose.Slides에서 최적의 폰트 대체를 활성화합니다."
---
## **개요**

폰트 대체를 사용하면 Aspose.Slides가 렌더링 또는 변환 중에 원본 프레젠테이션 폰트를 사용할 수 없을 때 다른 폰트를 사용할 수 있습니다. `IFontsManager` 인터페이스의 `getSubstitutions` 메서드를 사용하여 어떤 폰트가 대체되었는지 확인할 수 있습니다.

Aspose.Slides는 폰트 대체 규칙을 정의할 수도 있습니다. 예를 들어, 접근할 수 없는 폰트를 다른 사용 가능한 폰트로 교체하도록 지정하고 해당 규칙을 프레젠테이션의 폰트 관리자에 적용할 수 있습니다.

## **폰트 대체 규칙 설정**

Aspose.Slides에서는 특정 상황(예: 폰트를 액세스할 수 없을 때)에서 수행해야 할 작업을 결정하는 폰트 규칙을 다음과 같이 설정할 수 있습니다:

1. 관련 프레젠테이션을 로드합니다.
2. 교체될 폰트를 로드합니다.
3. 새로운 폰트를 로드합니다.
4. 교체 규칙을 추가합니다.
5. 해당 규칙을 프레젠테이션 폰트 교체 규칙 컬렉션에 추가합니다.
6. 슬라이드 이미지를 생성하여 효과를 확인합니다.

이 Java 코드는 폰트 대체 프로세스를 보여줍니다:

```java
// 프레젠테이션을 로드합니다
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 교체될 원본 폰트를 로드합니다
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // 새 폰트를 로드합니다
    IFontData destFont = new FontData("Arial");
    
    // 폰트 교체를 위한 규칙을 추가합니다
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // 규칙을 폰트 대체 규칙 컬렉션에 추가합니다
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // 규칙 목록에 폰트 규칙 컬렉션을 추가합니다
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // SomeRareFont를 사용할 수 없을 때 Arial 폰트가 대신 사용됩니다
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // 이미지를 JPEG 형식으로 디스크에 저장합니다
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
다음도 확인해 보세요 [**Font Replacement**](/slides/ko/androidjava/font-replacement/).
{{% /alert %}}

## **수식 폰트에 대한 제한 사항**

폰트 대체 규칙은 렌더링 및 변환 중에 사용되는 표준 폰트 선택 프로세스에 참여합니다. 이 규칙은 Aspose.Slides가 구성된 규칙에 따라 접근할 수 없는 폰트를 다른 사용 가능한 폰트로 교체할 수 있는 일반 텍스트 시나리오에 적합합니다.

그러나 Office 수식에는 중요한 제한이 있습니다. 수식이 **Cambria Math**로 만들어진 경우, Aspose.Slides는 수식 레이아웃을 정확하게 계산하고 렌더링하기 위해 원본 **Cambria Math** 폰트를 여전히 필요로 할 수 있습니다. 따라서 **Cambria Math**를 **STIX Two Math**와 같은 다른 수식 폰트로 대체하는 것은 수식 렌더링에서 지원되지 않으며, 여전히 **Cambria Math**가 필요하다는 예외가 발생할 수 있습니다.

이러한 프레젠테이션을 성공적으로 변환하려면 런타임에 **Cambria Math**가 Aspose.Slides에서 사용 가능하도록 해야 합니다. 운영 체제에 폰트를 설치하거나 [외부 폰트](/slides/ko/androidjava/custom-font/) 로 제공하여 렌더링 및 변환 중 정상적인 폰트 선택 프로세스에 참여하도록 할 수 있습니다.

이 제한은 수식 렌더링에만 적용됩니다. 위에서 설명한 표준 폰트 대체 규칙은 원본 폰트를 사용할 수 없을 때 일반 프레젠테이션 텍스트에도 계속 적용됩니다.

## **FAQ**

**폰트 교체와 폰트 대체의 차이점은 무엇인가요?**

[Replacement](/slides/ko/androidjava/font-replacement/) 은 프레젠테이션 전체에서 한 폰트를 다른 폰트로 강제로 교체하는 것입니다. 대체는 원본 폰트를 사용할 수 없을 때와 같이 특정 조건에서 트리거되는 규칙으로, 지정된 대체 폰트가 사용됩니다.

**대체 규칙은 정확히 언제 적용되나요?**

규칙은 로드, 렌더링 및 변환 중에 평가되는 표준 [font selection](/slides/ko/androidjava/font-selection-sequence/) 순서에 참여합니다. 선택한 폰트를 사용할 수 없을 경우 교체 또는 대체가 적용됩니다.

**대체나 교체가 설정되지 않았고 시스템에 폰트가 없을 경우 기본 동작은 무엇인가요?**

라이브러리는 PowerPoint와 유사하게 가장 가까운 사용 가능한 시스템 폰트를 선택하려고 시도합니다.

**런타임에 사용자 정의 외부 폰트를 첨부하여 대체를 방지할 수 있나요?**

예. 런타임에 [외부 폰트 추가](/slides/ko/androidjava/custom-font/) 를 추가하여 라이브러리가 선택 및 렌더링 시 해당 폰트를 고려하도록 할 수 있으며, 이후 변환에도 적용됩니다.

**Aspose가 라이브러리와 함께 폰트를 배포하나요?**

아니오. Aspose는 유료 또는 무료 폰트를 배포하지 않으며, 폰트는 사용자가 직접 추가하고 사용해야 합니다.

**Windows, Linux, macOS에서 대체 동작에 차이가 있나요?**

예. 폰트 검색은 운영 체제의 폰트 디렉터리에서 시작됩니다. 기본 제공 폰트 집합 및 검색 경로는 플랫폼마다 다르며, 이는 가용성과 대체 필요성에 영향을 줍니다.

**일괄 변환 중 예상치 못한 대체를 최소화하려면 환경을 어떻게 준비해야 하나요?**

머신이나 컨테이너 간에 폰트 세트를 동기화하고, 출력 문서에 필요한 [외부 폰트 추가](/slides/ko/androidjava/custom-font/) 를 추가하며, 가능하면 프레젠테이션에 [폰트 임베드](/slides/ko/androidjava/embedded-font/) 를 삽입하여 렌더링 시 선택된 폰트가 사용 가능하도록 합니다.