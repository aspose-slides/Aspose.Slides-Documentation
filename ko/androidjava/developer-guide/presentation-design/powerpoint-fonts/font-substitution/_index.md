---
title: Android에서 프레젠테이션에 대한 글꼴 대체 구성
linktitle: 글꼴 대체
type: docs
weight: 70
url: /ko/androidjava/font-substitution/
keywords:
- 글꼴
- 대체 글꼴
- 글꼴 대체
- 글꼴 교체
- 글꼴 교체
- 대체 규칙
- 교체 규칙
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "프레젠테이션을 렌더링하거나 변환할 때 Java를 사용하여 Android용 Aspose.Slides에서 글꼴 대체 규칙을 구성하고 대체된 글꼴을 검사합니다."
---
## **개요**

Font substitution은 Aspose.Slides가 프레젠테이션을 렌더링하거나 변환할 때 접근할 수 없는 글꼴 대신 사용 가능한 글꼴을 사용할 수 있게 합니다. 대체는 렌더링된 출력에만 영향을 미치며, 프레젠테이션 콘텐츠에 할당된 글꼴을 변경하지는 않습니다.

특정 글꼴을 사용할 수 없을 때 사용할 글꼴을 정의할 수 있으며, 렌더링 중 Aspose.Slides가 수행할 대체를 검사할 수 있습니다. 이를 통해 Android 기기 및 다양한 글꼴이 제공되는 환경에서 출력 일관성을 유지할 수 있습니다.

## **글꼴 대체 가져오기**

프레젠테이션이 렌더링될 때 어떤 글꼴이 대체되는지 확인하려면 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) 메서드를 사용합니다. 이 메서드는 원본 글꼴 이름과 대체된 글꼴 이름을 식별하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsubstitutioninfo/) 객체를 반환합니다.

다음 Java 예제는 프레젠테이션의 모든 글꼴 대체를 나열합니다:

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

## **선택된 슬라이드의 글꼴 대체 가져오기**

`int[] slides` 매개변수가 있는 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) 오버로드를 사용하면 특정 슬라이드에 필요한 대체만 검사할 수 있습니다. 이는 프레젠테이션의 일부만 렌더링하거나 내보낼 때, 큰 프레젠테이션을 점진적으로 확인할 때, 사용 불가능한 글꼴에 의존하는 슬라이드를 찾을 때, Android 앱을 위한 최소 글꼴 패키지를 준비할 때, 또는 관련 없는 슬라이드를 처리하지 않고 렌더링 차이를 진단할 때 유용합니다.

`slides` 배열은 1부터 시작하는 슬라이드 인덱스를 포함합니다: `1`은 첫 번째 슬라이드를 식별합니다. 반면 [Presentation.getSlides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getSlides--) 컬렉션 접근자는 0부터 시작하는 인덱스를 사용하므로 같은 슬라이드는 `presentation.getSlides().get_Item(0)`으로 접근합니다. 배열을 만들 때 이 차이를 기억하여 오프 바이 원 오류를 방지하세요.

오버로드는 [Presentation.getFontsManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getFontsManager--) 메서드를 통해 호출합니다. 선택된 슬라이드를 렌더링하는 동안 결정된 대체만 반환합니다. 각 결과는 원본 및 대체된 글꼴 이름을 포함하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsubstitutioninfo/) 객체입니다. 결과는 현재 글꼴 환경, 구성된 폴백 규칙, [IFontSubstRuleCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsubstrulecollection/)에 저장된 대체 규칙, 그리고 [외부 로드된 글꼴](/slides/ko/androidjava/custom-font/)을 반영합니다.

같은 대체가 여러 선택된 슬라이드에서 필요할 수 있습니다. 글꼴 인벤토리나 사전 검증 보고서를 만들 때 결과를 중복 제거하세요. 다음 예제는 반환된 모든 대체를 보고한 다음 고유한 글꼴 매핑 목록을 정렬하여 생성합니다:

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

[IFontsManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsmanager/) 인터페이스는 두 오버로드를 모두 제공합니다. 렌더링 작업 범위에 따라 적절한 것을 선택하세요:

| 오버로드 | 사용 상황 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) (인수 없음) | 전체 프레젠테이션에 대한 대체가 필요할 때 |
| [getSubstitutions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) (`int[] slides` 사용) | 선택된 범위, 점진적 확인 또는 부분 내보내기가 필요할 때 |

## **글꼴 대체 규칙 설정**

원본 글꼴을 사용할 수 없을 때 Aspose.Slides가 사용할 글꼴을 지정하려면 다음 절차를 따르세요:

1. 프레젠테이션을 로드합니다.  
2. 원본 글꼴과 대체 글꼴에 대한 정의를 만듭니다.  
3. [WhenInaccessible](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsubstcondition/) 조건을 가진 [FontSubstRule](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsubstrule/)을 생성합니다.  
4. 해당 규칙을 [FontSubstRuleCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsubstrulecollection/)에 추가합니다.  
5. [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) 메서드를 사용해 컬렉션을 할당합니다.  
6. 프레젠테이션을 렌더링하거나 변환합니다.

다음 Java 예제는 `SomeRareFont`가 없을 때 `Arial`을 대체하고, 첫 번째 슬라이드를 렌더링하여 결과를 확인합니다. 대체 글꼴은 Aspose.Slides에서 사용할 수 있어야 합니다.

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
프레젠테이션 전체에 사용되는 글꼴을 무조건 변경하려면 [Font Replacement](/slides/ko/androidjava/font-replacement/)을 참조하세요.
{{% /alert %}}

## **수학 식 글꼴 제한 사항**

글꼴 대체 규칙은 렌더링 및 변환 중에 사용되는 표준 글꼴 선택 프로세스의 일부입니다. 접근할 수 없는 글꼴을 규칙에 지정된 사용 가능한 글꼴로 교체할 수 있는 일반 텍스트에 대해서는 정상적으로 작동합니다.

Office Math 식에는 추가 요구 사항이 있습니다. 식에 **Cambria Math**가 사용된 경우, Aspose.Slides는 식 레이아웃을 계산하고 렌더링하기 위해 정확히 해당 글꼴이 필요할 수 있습니다. **STIX Two Math**와 같은 다른 수학 글꼴로 대체하는 규칙은 **Cambria Math**를 대신할 수 없으며, 렌더링 시 여전히 **Cambria Math**가 필요하다고 보고될 수 있습니다.

이러한 프레젠테이션을 렌더링하거나 변환하려면 **Cambria Math**를 Aspose.Slides가 사용할 수 있게 해야 합니다. 이를 [외부 글꼴](/slides/ko/androidjava/custom-font/)로 로드하여 렌더링 및 변환 중에 애플리케이션이 사용할 수 있도록 하세요.

이 제한은 식 레이아웃에만 적용됩니다. 위에서 설명한 대체 규칙은 일반 프레젠테이션 텍스트에는 여전히 적용됩니다.

## **FAQ**

**글꼴 교체와 글꼴 대체의 차이점은 무엇인가요?**  
[Font replacement](/slides/ko/androidjava/font-replacement/)는 프레젠테이션 전체에 걸쳐 한 글꼴을 다른 글꼴로 의도적으로 변경합니다. 글꼴 대체는 원본 글꼴을 사용할 수 없을 때 같은 렌더링 출력에 대해 지정된 글꼴을 선택합니다.

**대체 규칙은 언제 적용되나요?**  
규칙은 렌더링 및 변환 중에 [글꼴 선택 순서](/slides/ko/androidjava/font-selection-sequence/)에 참여합니다. `WhenInaccessible` 조건을 사용하면 Aspose.Slides가 원본 글꼴에 접근할 수 없을 때만 규칙이 적용됩니다.

**글꼴이 없고 대체 규칙이 구성되어 있지 않으면 어떻게 되나요?**  
Aspose.Slides는 자체 글꼴 선택 프로세스에 따라 가장 가까운 사용 가능한 글꼴을 선택합니다. 결과는 런타임 환경에 설치된 글꼴에 따라 달라집니다.

**외부 글꼴을 로드하여 대체를 방지할 수 있나요?**  
예. [외부 글꼴을 로드](/slides/ko/androidjava/custom-font/)하면 Aspose.Slides가 렌더링 및 변환 중에 해당 글꼴을 사용할 수 있습니다.

**Aspose는 라이브러리와 함께 글꼴을 배포하나요?**  
아니요. 글꼴 제공 및 라이선스 준수는 사용자 책임입니다.

**Android 기기마다 대체 결과가 다를 수 있나요?**  
예. Android 버전, 기기 및 제조사에 따라 시스템에 설치된 글꼴이 다르기 때문에 한 환경에서 사용 가능한 글꼴이 다른 환경에서는 대체가 필요할 수 있습니다.

**Android 기기 간에 글꼴 선택을 일관되게 만들려면 어떻게 해야 하나요?**  
필요한 동일한 글꼴 파일을 애플리케이션에 패키징하고, [외부 글꼴로 로드](/slides/ko/androidjava/custom-font/)하며, 라이선스가 허용하는 경우 [글꼴을 임베드](/slides/ko/androidjava/embedded-font/)합니다. 또한 내보내기 전에 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--)를 호출해 예상치 못한 대체를 확인할 수 있습니다.