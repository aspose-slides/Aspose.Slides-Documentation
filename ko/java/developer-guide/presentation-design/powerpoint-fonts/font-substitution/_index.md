---
title: Java를 사용하여 프레젠테이션에서 폰트 대체 구성
linktitle: 폰트 대체
type: docs
weight: 70
url: /ko/java/font-substitution/
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
- Java
- Aspose.Slides
description: "PowerPoint 및 OpenDocument 프레젠테이션을 다른 파일 형식으로 변환할 때 Aspose.Slides for Java에서 최적의 폰트 대체를 활성화합니다."
---
## **개요**

폰트 대체를 사용하면 Aspose.Slides가 렌더링이나 변환 중에 원본 프레젠테이션 폰트를 사용할 수 없을 때 다른 폰트를 사용할 수 있습니다. `IFontsManager` 인터페이스의 `getSubstitutions` 메서드를 사용하여 어느 폰트가 대체되었는지 확인할 수 있습니다.

Aspose.Slides는 폰트 대체 규칙을 정의할 수도 있습니다. 예를 들어, 접근할 수 없는 폰트를 다른 사용 가능한 폰트로 교체하도록 지정하고 해당 규칙을 프레젠테이션의 폰트 관리자를 통해 적용할 수 있습니다.

## **폰트 대체 규칙 설정**

다음과 같이 특정 상황(예: 폰트에 접근할 수 없는 경우)에 수행해야 할 작업을 결정하는 폰트 규칙을 설정할 수 있습니다:

1. 관련 프레젠테이션을 로드합니다.
2. 교체될 폰트를 로드합니다.
3. 새 폰트를 로드합니다.
4. 교체에 대한 규칙을 추가합니다.
5. 프레젠테이션 폰트 교체 규칙 컬렉션에 규칙을 추가합니다.
6. 효과를 확인하기 위해 슬라이드 이미지를 생성합니다.

다음 Java 코드는 폰트 대체 과정을 보여줍니다:

```java
// 프레젠테이션을 로드합니다
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 교체될 소스 폰트를 로드합니다
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
    
    // SomeRareFont를 접근할 수 없을 때 Arial 폰트가 대신 사용됩니다
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
다음 [**폰트 교체**](/slides/ko/java/font-replacement/)를 확인하고 싶을 수 있습니다. 
{{% /alert %}}

## **수학 방정식 폰트에 대한 제한 사항**

폰트 대체 규칙은 렌더링 및 변환 중에 사용되는 표준 폰트 선택 프로세스에 참여합니다. 구성된 규칙에 따라 Aspose.Slides가 접근할 수 없는 폰트를 다른 사용 가능한 폰트로 교체할 수 있는 일반 텍스트 시나리오에 적합합니다.

하지만 Office 수학 방정식에는 중요한 제한이 있습니다. 방정식이 **Cambria Math**로 생성된 경우, Aspose.Slides는 방정식 레이아웃을 올바르게 계산하고 렌더링하기 위해 원본 **Cambria Math** 폰트가 필요할 수 있습니다. 따라서 **Cambria Math**를 **STIX Two Math**와 같은 다른 수학 폰트로 대체하는 것은 방정식 렌더링에 지원되지 않으며, 여전히 **Cambria Math**가 필요하다는 예외가 발생할 수 있습니다.

이러한 프레젠테이션을 성공적으로 변환하려면 런타임에 Aspose.Slides가 **Cambria Math**를 사용할 수 있도록 해야 합니다. 운영 체제에 폰트를 설치하거나 [외부 폰트](/slides/ko/java/custom-font/)를 제공하여 렌더링 및 변환 중에 일반 폰트 선택 프로세스에 참여하도록 할 수 있습니다.

이 제한은 방정식 렌더링에만 해당됩니다. 위에서 설명한 표준 폰트 대체 규칙은 원본 폰트를 사용할 수 없을 때 일반 프레젠테이션 텍스트에도 여전히 적용됩니다.

## **자주 묻는 질문**

**폰트 교체와 폰트 대체의 차이점은 무엇인가요?**  
[교체](/slides/ko/java/font-replacement/)는 전체 프레젠테이션에서 하나의 폰트를 다른 폰트로 강제로 대체하는 것입니다. 대체는 원본 폰트를 사용할 수 없는 등 특정 조건이 발생했을 때 트리거되는 규칙으로, 지정된 대체 폰트를 사용합니다.

**대체 규칙은 정확히 언제 적용되나요?**  
규칙은 로드, 렌더링 및 변환 중에 평가되는 표준 [폰트 선택](/slides/ko/java/font-selection-sequence/) 순서에 참여합니다; 선택된 폰트를 사용할 수 없으면 교체 또는 대체가 적용됩니다.

**교체나 대체가 구성되지 않았고 시스템에 폰트가 없을 경우 기본 동작은 무엇인가요?**  
라이브러리는 PowerPoint와 유사하게 가장 가까운 사용 가능한 시스템 폰트를 선택하려 시도합니다.

**런타임에 맞춤형 외부 폰트를 추가하여 대체를 방지할 수 있나요?**  
예. 런타임에 [외부 폰트](/slides/ko/java/custom-font/)를 추가하여 라이브러리가 선택 및 렌더링 시 해당 폰트를 고려하도록 할 수 있으며, 이후 변환에도 적용됩니다.

**Aspose가 라이브러리와 함께 폰트를 배포하나요?**  
아니요. Aspose는 유료 또는 무료 폰트를 배포하지 않으며, 폰트는 사용자가 직접 선택하고 책임을 가지고 추가 및 사용해야 합니다.

**Windows, Linux, macOS에서 대체 동작에 차이가 있나요?**  
예. 폰트 검색은 운영 체제의 폰트 디렉터리에서 시작됩니다. 기본 제공 폰트와 검색 경로는 플랫폼마다 다르며, 이는 폰트 가용성 및 대체 필요성에 영향을 줍니다.

**대량 변환 시 예기치 않은 대체를 최소화하려면 환경을 어떻게 준비해야 하나요?**  
머신이나 컨테이너 간에 폰트 세트를 동기화하고, 출력 문서에 필요한 [외부 폰트](/slides/ko/java/custom-font/)를 추가하며, 가능하면 프레젠테이션에 [폰트 포함](/slides/ko/java/embedded-font/)을 수행하여 렌더링 중에 선택된 폰트를 사용할 수 있도록 합니다.