---
title: Python을 사용한 프레젠테이션에서 폰트 대체 구성
linktitle: 폰트 대체
type: docs
weight: 70
url: /ko/python-net/font-substitution/
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
- Python
- Aspose.Slides
description: "PowerPoint 및 OpenDocument 프레젠테이션을 렌더링하거나 변환할 때 .NET을 통해 Python용 Aspose.Slides에서 폰트 대체 규칙을 구성하고 대체된 폰트를 검사합니다."
---
## **개요**

폰트 대체를 사용하면 Aspose.Slides가 프레젠테이션을 렌더링하거나 변환할 때 액세스할 수 없는 폰트를 사용할 수 있는 폰트로 대체할 수 있습니다. 대체는 렌더링된 출력에만 영향을 미치며, 프레젠테이션 내용에 할당된 폰트를 변경하지는 않습니다.

특정 폰트를 사용할 수 없을 때 사용할 폰트를 정의할 수 있으며, 렌더링 중 Aspose.Slides가 수행하는 대체 항목을 확인할 수 있습니다. 이는 서로 다른 폰트가 설치된 환경에서도 출력의 일관성을 유지하는 데 도움이 됩니다.

## **폰트 대체 가져오기**

[FontsManager.get_substitutions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_substitutions/) 메서드를 사용하여 프레젠테이션이 렌더링될 때 대체될 폰트를 확인할 수 있습니다. 이 메서드는 원본 폰트와 대체 폰트 이름을 식별하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsubstitutioninfo/) 객체를 반환합니다.

다음 Python 예제는 프레젠테이션의 모든 폰트 대체 항목을 나열합니다:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **선택한 슬라이드에 대한 폰트 대체 가져오기**

[FontsManager.get_substitutions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_substitutions/)에 슬라이드 인덱스 목록을 전달하면 특정 슬라이드에 필요한 대체 항목만 확인할 수 있습니다. 이는 프레젠테이션의 일부를 렌더링하거나 내보낼 때, 큰 프레젠테이션을 점진적으로 검사할 때, 사용할 수 없는 폰트에 의존하는 슬라이드를 찾을 때, 서버 또는 컨테이너용 최소 폰트 패키지를 준비할 때, 또는 관련 없는 슬라이드를 처리하지 않고 렌더링 차이를 진단할 때 유용합니다.

목록은 1부터 시작하는 슬라이드 인덱스를 포함합니다: `1`은 첫 번째 슬라이드를 나타냅니다. 반면에 [Presentation.slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/slides/ko/) 컬렉션은 0부터 시작하므로 동일한 슬라이드는 `presentation.slides[0]`으로 접근합니다. 리스트를 만들 때 이 차이를 기억하여 오프바이원 오류를 방지하십시오.

[Presentation.fonts_manager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/fonts_manager/) 속성을 통해 메서드를 호출합니다. 선택한 슬라이드를 렌더링하면서 결정된 대체 항목만 반환합니다. 각 결과는 원본 및 대체 폰트 이름을 포함하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsubstitutioninfo/) 객체입니다. 결과는 현재 폰트 환경, 구성된 폰트 폴백 규칙, [IFontSubstRuleCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ifontsubstrulecollection/)에 저장된 대체 규칙, 및 [외부 로드된 폰트](/slides/ko/python-net/custom-font/)를 반영합니다.

같은 대체가 둘 이상의 선택된 슬라이드에서 필요할 수 있습니다. 폰트 인벤토리나 사전 검사 보고서를 만들 때 결과를 중복 제거하십시오. 다음 예제는 반환된 모든 대체 항목을 보고한 뒤 고유한 폰트 매핑의 정렬된 목록을 생성합니다:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

[FontsManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/) 클래스는 두 형태의 메서드를 모두 제공합니다. 렌더링 작업의 범위에 따라 적절한 형태를 선택하십시오:

| 메서드 호출 | 사용 상황 |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_substitutions/) (인수 없음) | 전체 프레젠테이션에 대한 대체가 필요할 때 |
| [get_substitutions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_substitutions/) (슬라이드 인덱스 목록) | 선택된 범위, 점진적 검사 또는 부분 내보내기가 필요할 때 |

## **폰트 대체 규칙 설정**

원본 폰트를 사용할 수 없을 때 Aspose.Slides가 사용할 폰트를 지정하려면 다음 단계를 따르세요:

1. 프레젠테이션을 로드합니다.
2. 원본 및 대체 폰트에 대한 정의를 만듭니다.
3. [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsubstcondition/) 조건을 사용하여 [FontSubstRule](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsubstrule/)을 생성합니다.
4. 규칙을 [FontSubstRuleCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsubstrulecollection/)에 추가합니다.
5. 컬렉션을 [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/font_subst_rule_list/) 속성에 할당합니다.
6. 프레젠테이션을 렌더링하거나 변환합니다.

다음 Python 예제는 `SomeRareFont`가 없을 때 `Arial`을 대체 폰트로 사용하고 첫 번째 슬라이드를 렌더링하여 결과를 확인합니다. 대체 폰트는 Aspose.Slides에서 사용할 수 있어야 합니다.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="참고" %}}
프레젠테이션 전체에서 폰트를 무조건 변경하려면 [폰트 교체](/slides/ko/python-net/font-replacement/)를 참조하십시오.
{{% /alert %}}

## **수식 폰트에 대한 제한 사항**

폰트 대체 규칙은 렌더링 및 변환 중에 사용되는 표준 폰트 선택 프로세스의 일부입니다. 접근할 수 없는 폰트를 규칙에 지정된 사용 가능한 폰트로 교체할 수 있는 일반 텍스트에 대해 작동합니다.

Office Math 수식에는 추가 요구 사항이 있습니다. 수식이 **Cambria Math**를 사용하면 Aspose.Slides는 수식 레이아웃을 계산하고 렌더링하기 위해 정확히 해당 폰트가 필요할 수 있습니다. **STIX Two Math**와 같은 다른 수식 폰트로 대체하는 규칙은 이 목적을 위해 **Cambria Math**를 대체할 수 없으며, 렌더링은 여전히 **Cambria Math**가 필요하다고 보고할 수 있습니다.

이러한 프레젠테이션을 렌더링하거나 변환하려면 **Cambria Math**를 Aspose.Slides에서 사용할 수 있게 하십시오. 운영 체제에 설치하거나 [외부 폰트](/slides/ko/python-net/custom-font/)로 로드하십시오.

이 제한은 수식 레이아웃에만 적용됩니다. 위에서 설명한 대체 규칙은 일반 프레젠테이션 텍스트에 계속 적용됩니다.

## **FAQ**

**폰트 교체와 폰트 대체의 차이점은 무엇인가요?**

[폰트 교체](/slides/ko/python-net/font-replacement/)는 프레젠테이션 전체에서 한 폰트를 다른 폰트로 의도적으로 변경합니다. 폰트 대체는 원본 폰트를 사용할 수 없을 때와 같이 구성된 조건이 충족될 때 렌더링된 출력에 사용할 폰트를 선택합니다.

**대체 규칙은 언제 적용되나요?**

규칙은 렌더링 및 변환 중에 [폰트 선택 순서](/slides/ko/python-net/font-selection-sequence/)에 참여합니다. `WHEN_INACCESSIBLE`인 경우, Aspose.Slides가 원본 폰트에 액세스할 수 없을 때만 규칙이 사용됩니다.

**폰트가 없고 대체 규칙이 구성되지 않으면 어떻게 되나요?**

Aspose.Slides는 폰트 선택 프로세스에 따라 가장 가까운 사용 가능한 폰트를 선택합니다. 결과는 런타임 환경에 설치된 폰트에 따라 달라집니다.

**외부 폰트를 로드하여 대체를 방지할 수 있나요?**

예. [외부 폰트 로드](/slides/ko/python-net/custom-font/)를 통해 Aspose.Slides가 렌더링 및 변환 중에 사용할 수 있도록 할 수 있습니다.

**Aspose가 라이브러리와 함께 폰트를 배포하나요?**

아니요. 폰트 제공 및 라이선스 준수는 사용자 책임입니다.

**Windows, Linux, macOS 간에 대체 결과가 다를 수 있나요?**

예. 설치된 폰트와 폰트 검색 위치는 운영 체제마다 다르므로, 한 머신에서 사용할 수 있는 폰트가 다른 머신에서는 대체가 필요할 수 있습니다.

**배치 변환에서 폰트 선택을 일관되게 유지하려면 어떻게 해야 하나요?**

모든 머신이나 컨테이너에 동일한 폰트 파일 및 버전을 사용하고, [필요한 외부 폰트 로드](/slides/ko/python-net/custom-font/)와 라이선스가 허용될 경우 [폰트 포함](/slides/ko/python-net/embedded-font/)을 수행하십시오. 또한 내보내기 전에 [FontsManager.get_substitutions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_substitutions/)을 호출하여 예상치 못한 대체를 식별할 수 있습니다.