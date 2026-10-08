---
title: Java를 사용한 프레젠테이션에서 폰트 대체 구성
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
description: "PowerPoint 및 OpenDocument 프레젠테이션을 렌더링하거나 변환할 때 Java용 Aspose.Slides에서 폰트 대체 규칙을 구성하고 대체된 폰트를 검사합니다."
---
## **개요**

폰트 대체를 사용하면 Aspose.Slides가 프레젠테이션을 렌더링하거나 변환할 때 접근할 수 없는 폰트 대신 사용할 수 있는 폰트를 사용합니다. 대체는 렌더링된 출력에만 영향을 미치며, 프레젠테이션 내용에 할당된 폰트를 변경하지는 않습니다.

특정 폰트를 사용할 수 없을 때 사용할 폰트를 정의할 수 있으며, Aspose.Slides가 렌더링 중에 수행할 대체 작업을 확인할 수 있습니다. 이는 설치된 폰트가 다른 환경에서도 출력 일관성을 유지하는 데 도움이 됩니다.

폰트가 사용 가능하지만 전용 굵은 글꼴이 없는 경우, [Handle Fonts Without a Dedicated Bold Typeface](/slides/ko/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) 섹션을 참조하십시오. 해당 섹션에서는 PDF 내보내기 중에 영향을 받은 텍스트를 래스터화하는 방법과 텍스트 선택, 검색 및 스케일링에 대한 결과를 설명합니다.

## **폰트 대체 가져오기**

[IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) 메서드를 사용하여 프레젠테이션이 렌더링될 때 대체되는 폰트를 확인합니다. 이 메서드는 원본 및 대체된 폰트 이름을 식별하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) 객체를 반환합니다.

다음 Java 예제는 프레젠테이션에 대한 모든 폰트 대체를 나열합니다:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **선택한 슬라이드에 대한 폰트 대체 가져오기**

`int[] slides` 인수를 사용하는 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) 오버로드를 호출하여 특정 슬라이드만 렌더링할 때 필요한 대체를 확인합니다. 전체 프레젠테이션을 점진적으로 검사하거나, 사용 불가능한 폰트에 의존하는 슬라이드를 찾거나, 서버나 컨테이너용 최소 폰트 패키지를 준비하거나, 관련 없는 슬라이드를 처리하지 않고 렌더링 차이를 진단할 때 유용합니다.

`slides` 배열은 1부터 시작하는 슬라이드 인덱스를 포함합니다: `1`은 첫 번째 슬라이드를 나타냅니다. 반면에 [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) 컬렉션 액세서는 0부터 시작하므로 동일한 슬라이드는 `presentation.getSlides().get_Item(0)`으로 접근합니다. 배열을 만들 때 이 차이를 고려하여 오프바이원 오류를 방지하십시오.

[Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--) 메서드를 통해 오버로드를 호출합니다. 선택한 슬라이드를 렌더링하면서 결정된 대체만 반환합니다. 각 결과는 원본 및 대체된 폰트 이름을 포함하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) 객체입니다. 결과는 현재 폰트 환경, 구성된 폰트 폴백 규칙 및 [외부 로드된 폰트](/slides/ko/java/custom-font/)를 반영합니다. 프레젠테이션이 렌더링될 때 적용되는 [IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/)에 저장된 대체 규칙은 결과에 표시되지 않으며, 대신 출력 파일의 폰트를 확인하십시오.

동일한 대체는 둘 이상의 선택된 슬라이드에서 필요할 수 있습니다. 폰트 인벤토리 또는 사전 검증 보고서를 만들 때 결과를 중복 제거하십시오. 다음 예제는 반환된 모든 대체를 보고한 후 고유한 폰트 매핑의 정렬된 목록을 생성합니다:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

[IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) 인터페이스는 두 오버로드를 모두 제공합니다. 렌더링 작업의 범위에 따라 하나를 선택하십시오:

| 오버로드 | 사용 시기 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) (인수 없음) | 전체 프레젠테이션에 대한 대체가 필요할 때 |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) (`int[] slides` 사용) | 선택된 범위, 점진적 검사 또는 부분 내보내기가 필요할 때 |

## **폰트 대체 규칙 설정**

소스 폰트를 사용할 수 없을 때 Aspose.Slides가 사용할 폰트를 지정하려면:

1. 프레젠테이션을 로드합니다.
2. 소스 폰트와 대체 폰트에 대한 정의를 만듭니다.
3. [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/) 조건과 함께 [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/)을 생성합니다.
4. 규칙을 [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/)에 추가합니다.
5. [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) 메서드를 사용하여 컬렉션을 할당합니다.
6. 프레젠테이션을 렌더링하거나 변환합니다.

다음 Java 예제는 `SomeRareFont`가 사용할 수 없을 때 `Arial`을 대체하고 첫 번째 슬라이드를 렌더링하여 결과를 확인합니다. 대체 폰트는 Aspose.Slides에서 사용할 수 있어야 합니다.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
프레젠테이션 전체에 대해 폰트를 무조건 변경하려면 [Font Replacement](/slides/ko/java/font-replacement/)을 참조하십시오.
{{% /alert %}}

## **수식 폰트 제한 사항**

폰트 대체 규칙은 렌더링 및 변환 중에 사용되는 표준 폰트 선택 프로세스의 일부입니다. 규칙은 Aspose.Slides가 접근할 수 없는 폰트를 규칙에 지정된 사용 가능한 폰트로 교체할 수 있을 때 일반 텍스트에 대해 작동합니다.

Office Math 수식에는 추가 요구 사항이 있습니다. 수식에 **Cambria Math**가 사용되는 경우, Aspose.Slides는 수식 레이아웃을 계산하고 렌더링하기 위해 정확히 해당 폰트가 필요할 수 있습니다. **STIX Two Math**와 같은 다른 수학 폰트로 대체하는 규칙은 이 목적을 충족하지 못하며, 렌더링 시 여전히 **Cambria Math**가 필요하다고 보고될 수 있습니다.

이러한 프레젠테이션을 렌더링하거나 변환하려면 **Cambria Math**를 Aspose.Slides에서 사용할 수 있게 해야 합니다. 운영 체제에 설치하거나 [외부 폰트](/slides/ko/java/custom-font/)로 로드하십시오.

이 제한은 수식 레이아웃에만 적용됩니다. 위에서 설명한 대체 규칙은 일반 프레젠테이션 텍스트에 그대로 적용됩니다.

## **FAQ**

**폰트 교체와 폰트 대체의 차이점은 무엇인가요?**

[Font replacement](/slides/ko/java/font-replacement/)은 프레젠테이션 전체에서 한 폰트를 다른 폰트로 의도적으로 변경합니다. 폰트 대체는 원본 폰트를 사용할 수 없을 때와 같이 구성된 조건이 충족될 때 렌더링된 출력에 사용할 폰트를 선택합니다.

**대체 규칙은 언제 적용되나요?**

규칙은 렌더링 및 변환 중에 [폰트 선택 순서](/slides/ko/java/font-selection-sequence/)에 참여합니다. `WhenInaccessible` 조건을 사용하면 Aspose.Slides가 소스 폰트에 접근할 수 없을 때만 규칙이 적용됩니다.

**폰트가 없고 대체 규칙이 설정되어 있지 않으면 어떻게 되나요?**

Aspose.Slides는 폰트 선택 프로세스에 따라 가장 가까운 사용 가능한 폰트를 선택합니다. 결과는 런타임 환경에 설치된 폰트에 따라 달라집니다.

**외부 폰트를 로드하여 대체를 방지할 수 있나요?**

예. [외부 폰트 로드](/slides/ko/java/custom-font/)를 통해 Aspose.Slides가 렌더링 및 변환 중에 사용할 수 있도록 할 수 있습니다.

**Aspose가 라이브러리와 함께 폰트를 배포하나요?**

아니요. 폰트 제공 및 라이선스 준수는 사용자가 직접 책임져야 합니다.

**Windows, Linux, macOS 간에 대체 결과가 다를 수 있나요?**

예. 운영 체제마다 설치된 폰트와 폰트 검색 위치가 다르므로, 한 시스템에서 사용 가능한 폰트가 다른 시스템에서는 대체가 필요할 수 있습니다.

**배치 변환에서 폰트 선택을 일관되게 하려면 어떻게 해야 하나요?**

모든 머신이나 컨테이너에 동일한 폰트 파일과 버전을 사용하고, [필요한 외부 폰트 로드](/slides/ko/java/custom-font/), 라이선스가 허용되는 경우 [폰트 내장](/slides/ko/java/embedded-font/)을 수행하십시오. 또한 내보내기 전에 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--)를 호출하여 예상치 못한 대체를 식별할 수 있습니다.