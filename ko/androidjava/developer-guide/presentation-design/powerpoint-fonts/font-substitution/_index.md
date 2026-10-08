---
title: Android에서 프레젠테이션의 폰트 대체 구성
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
description: "Android용 Aspose.Slides에서 Java로 프레젠테이션을 렌더링하거나 변환할 때 폰트 대체 규칙을 구성하고 대체된 폰트를 검사합니다."
---
## **개요**

폰트 대체를 사용하면 Aspose.Slides가 프레젠테이션을 렌더링하거나 변환할 때 접근할 수 없는 폰트를 사용할 수 있는 폰트로 대신 사용할 수 있습니다. 대체는 렌더링된 출력에만 영향을 미치며, 프레젠테이션 콘텐츠에 할당된 폰트를 변경하지는 않습니다.

특정 폰트가 사용 불가능할 때 사용할 폰트를 정의할 수 있으며, 렌더링 중 Aspose.Slides가 수행할 대체를 확인할 수 있습니다. 이를 통해 Android 장치 및 폰트가 다른 환경에서 출력이 일관되게 유지됩니다.

폰트가 사용 가능하지만 전용 굵은 서체가 없는 경우, [전용 굵은 서체가 없는 글꼴 처리](/slides/ko/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)를 참조하십시오. 해당 섹션에서는 PDF 내보내기 시 영향을 받은 텍스트를 래스터화하는 방법과 텍스트 선택, 검색, 확대/축소에 대한 영향을 설명합니다.

## **폰트 대체 가져오기**

프레젠테이션이 렌더링될 때 어떤 폰트가 대체되는지 확인하려면 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) 메서드를 사용하십시오. 이 메서드는 원본 및 대체 폰트 이름을 식별하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) 객체를 반환합니다.

다음 Java 예제는 프레젠테이션의 모든 폰트 대체를 나열합니다:

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

## **선택된 슬라이드에 대한 폰트 대체 가져오기**

`int[] slides` 인수를 사용한 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) 오버로드를 호출하면 특정 슬라이드에만 필요한 대체를 확인할 수 있습니다. 이는 프레젠테이션의 일부를 렌더링하거나 내보낼 때, 대형 프레젠테이션을 점진적으로 검사할 때, 사용 불가능한 폰트에 의존하는 슬라이드를 찾을 때, Android 앱용 최소 폰트 패키지를 준비할 때, 또는 관련 없는 슬라이드를 처리하지 않고 렌더링 차이를 진단할 때 유용합니다.

`slides` 배열은 1부터 시작하는 슬라이드 인덱스를 포함합니다: `1`은 첫 번째 슬라이드를 나타냅니다. 반면에 [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) 컬렉션 접근자는 0부터 시작하는 인덱스를 사용하므로 동일한 슬라이드는 `presentation.getSlides().get_Item(0)`으로 접근합니다. 배열을 구성할 때 이 차이를 기억하여 1 오프셋 오류를 방지하십시오.

오버로드는 [Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--) 메서드를 통해 호출합니다. 선택된 슬라이드를 렌더링하는 동안 결정된 대체만 반환합니다. 각 결과는 원본 및 대체 폰트 이름을 포함하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) 객체입니다. 결과는 현재 폰트 환경, 구성된 폰트 대체 규칙, [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/)에 저장된 대체 규칙, 그리고 [외부 로드된 폰트](/slides/ko/androidjava/custom-font/)를 반영합니다.

같은 대체가 둘 이상의 선택된 슬라이드에서 필요할 수 있습니다. 폰트 인벤토리나 사전 검사 보고서를 만들 때 결과를 중복 제거하십시오. 다음 예제는 반환된 모든 대체를 기록한 뒤 고유한 폰트 매핑의 정렬된 목록을 생성합니다:

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

[IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) 인터페이스는 두 오버로드를 모두 제공합니다. 렌더링 작업 범위에 따라 하나를 선택하십시오:

| 오버로드 | 사용 상황 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) (인수 없음) | 전체 프레젠테이션에 대한 대체가 필요할 때 |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) (`int[] slides` 사용) | 선택된 범위, 증분 검사 또는 부분 내보내기가 필요할 때 |

## **폰트 대체 규칙 설정**

소스 폰트를 사용할 수 없을 때 Aspose.Slides가 사용할 폰트를 지정하려면 다음 단계를 수행하십시오:

1. 프레젠테이션을 로드합니다.
2. 소스 폰트와 대체 폰트에 대한 폰트 정의를 만듭니다.
3. [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/) 조건을 사용해 [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/)을 생성합니다.
4. 규칙을 [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/)에 추가합니다.
5. [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) 메서드를 사용해 컬렉션을 할당합니다.
6. 프레젠테이션을 렌더링하거나 변환합니다.

다음 Java 예제는 `SomeRareFont`가 없을 때 `Arial`을 대체 폰트로 사용하고, 첫 번째 슬라이드를 렌더링해 결과를 확인합니다. 대체 폰트는 Aspose.Slides에서 사용할 수 있어야 합니다.

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
프레젠테이션 전체에 걸쳐 폰트를 무조건 변경하려면 [폰트 교체](/slides/ko/androidjava/font-replacement/)를 참조하십시오.
{{% /alert %}}

## **수식 폰트에 대한 제한 사항**

폰트 대체 규칙은 렌더링 및 변환 중에 사용되는 표준 폰트 선택 프로세스의 일부입니다. 이는 Aspose.Slides가 접근할 수 없는 폰트를 규칙에 지정된 사용 가능한 폰트로 교체할 수 있는 일반 텍스트에 대해 작동합니다.

Office Math 수식에는 추가 요구 사항이 있습니다. 수식이 **Cambria Math**를 사용하면 Aspose.Slides는 레이아웃을 계산하고 렌더링하기 위해 정확히 해당 폰트가 필요할 수 있습니다. **STIX Two Math**와 같이 다른 수학 폰트를 대체하는 규칙은 이 목적을 위해 **Cambria Math**를 대체할 수 없으며, 렌더링 시 여전히 **Cambria Math**가 필요하다고 보고할 수 있습니다.

이러한 프레젠테이션을 렌더링하거나 변환하려면 **Cambria Math**를 사용 가능하도록 만들십시오. 이를 [외부 폰트](/slides/ko/androidjava/custom-font/)로 로드하면 애플리케이션이 렌더링 및 변환 중에 사용할 수 있습니다.

이 제한은 수식 레이아웃에만 적용됩니다. 위에서 설명한 대체 규칙은 일반 프레젠테이션 텍스트에는 그대로 적용됩니다.

## **FAQ**

**폰트 교체와 폰트 대체의 차이는 무엇인가요?**

[폰트 교체](/slides/ko/androidjava/font-replacement/)는 프레젠테이션 전체에서 하나의 폰트를 다른 폰트로 의도적으로 바꾸는 것입니다. 폰트 대체는 원본 폰트를 사용할 수 없을 때 렌더링된 출력에 대해 폰트를 선택합니다.

**대체 규칙은 언제 적용되나요?**

규칙은 렌더링 및 변환 중 [폰트 선택 순서](/slides/ko/androidjava/font-selection-sequence/)에 참여합니다. `WhenInaccessible` 조건을 가진 규칙은 Aspose.Slides가 소스 폰트에 접근할 수 없을 때만 사용됩니다.

**폰트가 없고 대체 규칙이 구성되지 않으면 어떻게 되나요?**

Aspose.Slides는 폰트 선택 프로세스에 따라 가장 근접한 사용 가능한 폰트를 선택합니다. 결과는 런타임 환경에 존재하는 폰트에 따라 달라집니다.

**외부 폰트를 로드해 대체를 피할 수 있나요?**

예. [외부 폰트 로드](/slides/ko/androidjava/custom-font/)를 통해 Aspose.Slides가 렌더링 및 변환 중에 해당 폰트를 사용할 수 있게 할 수 있습니다.

**Aspose가 라이브러리와 함께 폰트를 배포하나요?**

아니요. 폰트 제공 및 라이선스 준수는 사용자의 책임입니다.

**Android 기기마다 대체 결과가 다를 수 있나요?**

예. Android 버전, 기기, 제조사에 따라 시스템 폰트가 다르므로 한 환경에서 사용 가능한 폰트가 다른 환경에서는 대체가 필요할 수 있습니다.

**Android 기기 간 폰트 선택을 일관되게 만들려면 어떻게 해야 하나요?**

필요한 폰트 파일을 애플리케이션에 포함하고, [외부 폰트로 로드](/slides/ko/androidjava/custom-font/)하며, 라이선스가 허용되는 경우 [폰트 삽입](/slides/ko/androidjava/embedded-font/)을 사용하십시오. 또한 내보내기 전에 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--)을 호출해 예기치 않은 대체를 식별할 수 있습니다.