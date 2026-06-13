---
title: JavaScript를 사용하여 프레젠테이션에서 폰트 대체 구성
linktitle: 폰트 대체
type: docs
weight: 70
url: /ko/nodejs-java/font-substitution/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript에서 PowerPoint 및 OpenDocument 프레젠테이션을 다른 파일 형식으로 변환할 때 Node.js용 Aspose.Slides에서 최적의 폰트 대체를 활성화합니다."
---
## **개요**

폰트 대체는 렌더링 또는 변환 중에 원본 프레젠테이션 폰트를 사용할 수 없을 때 Aspose.Slides가 다른 폰트를 사용하도록 허용합니다. `FontsManager` 클래스의 `getSubstitutions` 메서드를 사용하여 대체된 폰트를 확인할 수 있습니다.

Aspose.Slides는 폰트 대체 규칙을 정의할 수도 있습니다. 예를 들어, 접근할 수 없는 폰트를 다른 사용 가능한 폰트로 교체하도록 지정하고 해당 규칙을 프레젠테이션의 폰트 관리자를 통해 적용할 수 있습니다.

## **폰트 대체 규칙 설정**

Aspose.Slides는 특정 상황(예: 폰트에 접근할 수 없는 경우)에서 수행할 작업을 결정하는 폰트 규칙을 다음과 같이 설정할 수 있습니다:

1. 관련 프레젠테이션을 로드합니다.
2. 교체될 폰트를 로드합니다.
3. 새 폰트를 로드합니다.
4. 교체에 대한 규칙을 추가합니다.
5. 프레젠테이션 폰트 교체 규칙 컬렉션에 규칙을 추가합니다.
6. 효과를 확인하기 위해 슬라이드 이미지를 생성합니다.

다음 JavaScript 코드는 폰트 대체 프로세스를 보여줍니다:

```javascript
// 프레젠테이션을 로드합니다
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // 교체될 원본 폰트를 로드합니다
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // 새 폰트를 로드합니다
    var destFont = new aspose.slides.FontData("Arial");
    // 폰트 교체를 위한 규칙을 추가합니다
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // 규칙을 폰트 대체 규칙 컬렉션에 추가합니다
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // 규칙 목록에 폰트 규칙 컬렉션을 추가합니다
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // Arial 폰트는 SomeRareFont를 사용할 수 없을 때 대신 사용됩니다
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // 이미지를 JPEG 형식으로 디스크에 저장합니다
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
다음 [**폰트 교체**](/slides/ko/nodejs-java/font-replacement/)을 확인하세요.
{{% /alert %}}

## **수식 폰트 제한 사항**

폰트 대체 규칙은 렌더링 및 변환 중에 사용되는 표준 폰트 선택 프로세스에 참여합니다. 이는 구성된 규칙에 따라 Aspose.Slides가 접근할 수 없는 폰트를 다른 사용 가능한 폰트로 교체할 수 있는 일반 텍스트 시나리오에 적합합니다.

하지만 Office 수식에는 중요한 제한이 있습니다. 수식이 **Cambria Math**으로 작성된 경우, Aspose.Slides는 수식 레이아웃을 올바르게 계산하고 렌더링하기 위해 여전히 원본 **Cambria Math** 폰트를 필요로 할 수 있습니다. 따라서 **Cambria Math**를 **STIX Two Math**와 같은 다른 수식 폰트로 대체하는 것은 수식 렌더링에 대해 지원되지 않으며, 여전히 **Cambria Math**가 필요하다는 예외가 발생할 수 있습니다.

이러한 프레젠테이션을 성공적으로 변환하려면 런타임에 **Cambria Math**가 Aspose.Slides에서 사용할 수 있도록 해야 합니다. 운영 체제에 폰트를 설치하거나 [외부 폰트](/slides/ko/nodejs-java/custom-font/)로 제공하여 렌더링 및 변환 중에 일반 폰트 선택 프로세스에 참여하도록 할 수 있습니다.

이 제한은 수식 렌더링에만 적용됩니다. 위에서 설명한 표준 폰트 대체 규칙은 원본 폰트를 사용할 수 없을 때 일반 프레젠테이션 텍스트에도 계속 적용됩니다.

## **자주 묻는 질문**

**폰트 교체와 폰트 대체의 차이점은 무엇인가요?**

[Replacement](/slides/ko/nodejs-java/font-replacement/)는 전체 프레젠테이션에서 한 폰트를 다른 폰트로 강제로 교체하는 것입니다. 대체는 특정 조건(예: 원본 폰트를 사용할 수 없을 때)에서 트리거되는 규칙이며, 지정된 대체 폰트가 사용됩니다.

**대체 규칙은 정확히 언제 적용되나요?**

규칙은 로드, 렌더링 및 변환 중에 평가되는 표준 [font selection](/slides/ko/nodejs-java/font-selection-sequence/) 순서에 참여합니다; 선택된 폰트를 사용할 수 없는 경우 교체 또는 대체가 적용됩니다.

**교체와 대체가 모두 구성되지 않았고 시스템에 폰트가 없을 경우 기본 동작은 무엇인가요?**

라이브러리는 PowerPoint와 유사하게 가장 가까운 사용 가능한 시스템 폰트를 선택하려고 시도합니다.

**런타임에 사용자 정의 외부 폰트를 첨부하여 대체를 방지할 수 있나요?**

예. 런타임에 [외부 폰트 추가](/slides/ko/nodejs-java/custom-font/)를 통해 라이브러리가 선택 및 렌더링 시에 해당 폰트를 고려하도록 할 수 있습니다(후속 변환 포함).

**Aspose가 라이브러리와 함께 폰트를 배포하나요?**

아니요. Aspose는 유료 또는 무료 폰트를 배포하지 않으며, 사용자는 자유롭게 폰트를 추가 및 사용해야 합니다.

**Windows, Linux, macOS에서 대체 동작에 차이가 있나요?**

예. 폰트 탐지는 운영 체제의 폰트 디렉터리에서 시작됩니다. 기본 제공 폰트 세트와 검색 경로는 플랫폼마다 다르며, 이는 이용 가능성 및 대체 필요성에 영향을 줍니다.

**배치 변환 시 예기치 않은 대체를 최소화하려면 환경을 어떻게 준비해야 하나요?**

머신이나 컨테이너 간에 폰트 세트를 동기화하고, 출력 문서에 필요한 [외부 폰트](/slides/ko/nodejs-java/custom-font/)를 추가하며, 가능하면 프레젠테이션에 [폰트 임베드](/slides/ko/nodejs-java/embedded-font/)를 적용하여 렌더링 시 선택된 폰트를 사용할 수 있도록 합니다.