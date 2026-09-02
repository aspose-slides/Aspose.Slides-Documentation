---
title: Python에서 스크립트별 테마 글꼴 관리
linktitle: 스크립트별 테마 글꼴
type: docs
weight: 15
url: /ko/python-net/script-specific-font-mappings/
keywords:
- 스크립트별 글꼴
- 테마 글꼴 매핑
- 다국어 프레젠테이션
- 쓰기 시스템
- 시릴릭 글꼴
- 아라비아어 글꼴
- 일본어 글꼴
- 조지아어 글꼴
- 타아나 글꼴
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 사용하여 .NET을 통해 PowerPoint 테마에서 스크립트별 글꼴 매핑을 검사하고, 추가하고, 교체하고, 제거합니다."
---
## **개요**

프레젠테이션 테마는 다양한 쓰기 시스템에 대해 서로 다른 글꼴 패밀리를 선택할 수 있습니다. 이를 통해 다국어 텍스트가 여전히 테마 글꼴을 사용하면서도 시릴릭, 아라비아어, 일본어, 조지아어, 타아나어 및 기타 스크립트에 적합한 글꼴을 사용해 하나의 조화된 글꼴 스키마를 따를 수 있습니다.

테마의 [FontScheme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/fontscheme/)에는 일반적으로 제목에 사용되는 메이저 글꼴 컬렉션과 본문 텍스트에 사용되는 마이너 글꼴 컬렉션이 포함됩니다. 라틴 및 동아시아 글꼴 속성 외에도, 두 컬렉션 모두 [Fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fonts/) 클래스를 통해 쓰기 시스템 태그를 글꼴 패밀리 이름에 매핑하는 정보를 제공합니다.

이 문서에서는 프레젠테이션의 마스터 테마에서 해당 매핑을 검사하고 수정하는 방법과 변경 사항이 저장 후 다시 로드하는 주기에서도 유지되는지 확인하는 방법을 보여줍니다.

## **스크립트 태그 이해**

스크립트 글꼴 메서드는 네 자리 BCP 47 스크립트 서브태그를 사용해 쓰기 시스템을 식별합니다. 일반적인값은 다음과 같습니다:

| 스크립트 태그 | 쓰기 시스템 |
|---|---|
| `Cyrl` | 시릴릭 |
| `Arab` | 아라비아어 |
| `Hans` | 간체 중국어 |
| `Jpan` | 일본어 |
| `Geor` | 조지아어 |
| `Thaa` | 타아나어 |

이러한 매핑은 개별 텍스트 부분이 아니라 테마 글꼴 스키마에 속합니다. 프레젠테이션은 메이저와 마이너 컬렉션에 대해 서로 다른 매핑을 정의할 수 있으며, 일부 스크립트에 대한 매핑을 생략할 수도 있습니다.

## **스크립트 글꼴 매핑 접근 및 검사**

[Presentation.master_theme](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/master_theme/)를 사용하여 프레젠테이션 수준의 테마에 접근합니다. [FontScheme.major](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/fontscheme/major/)와 [FontScheme.minor](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/fontscheme/minor/) 속성은 두 개의 [Fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fonts/) 컬렉션을 반환합니다.

[Fonts.get_script_font_map](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fonts/get_script_font_map/)을 호출하면 컬렉션의 모든 매핑을 가져올 수 있습니다. 하나의 쓰기 시스템을 조회하려면 해당 스크립트 태그와 함께 [Fonts.get_script_font](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fonts/get_script_font/)을 호출하십시오. `get_script_font`은 해당 컬렉션에 요청된 매핑이 정의되어 있지 않을 경우 `None`을 반환합니다.

## **매핑 수정 및 지속성 확인**

[Fonts.set_script_font](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fonts/set_script_font/)을 사용하여 매핑을 생성하거나 현재 글꼴 패밀리를 교체합니다. [Fonts.remove_script_font](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fonts/remove_script_font/)을 사용하여 매핑을 제거합니다.

다음의 엔드‑투‑엔드 예제는 기존의 모든 메이저와 마이너 매핑을 읽고, 일본어 메이저 글꼴을 조회한 다음, 시릴릭 메이저 글꼴을 변경하고, 타아나 마이너 매핑을 제거한 뒤 프레젠테이션을 저장하고 다시 열어 두 변경 사항을 확인합니다. 제거 단계가 초기 테마와 무관하도록 하기 위해, 예제는 이미 정의되어 있지 않은 경우에만 타아나 매핑을 생성합니다.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

검증은 일반 조회와 동일한 `None` 동작을 사용합니다: 제거가 저장된 후 `get_script_font("Thaa")`은 마이너 컬렉션에 대해 `None`을 반환합니다.

## **테마 매핑과 기타 글꼴 설정 구분**

스크립트별 테마 매핑은 글꼴 선택에 참여하지만, 직접 텍스트 서식 지정, 대체 및 폰트 폴백과는 다른 문제를 해결합니다:

| 메커니즘 | 목적 | 테마 매핑 변경 시 효과 |
|---|---|---|
| 스크립트별 테마 글꼴 매핑 | 쓰기 시스템에 대해 메이저 또는 마이너 테마 글꼴을 선택합니다. | 해당 테마 글꼴을 계속 사용하는 텍스트는 새로운 매핑된 패밀리로 해석될 수 있습니다. |
| 텍스트 부분에 명시적으로 지정된 글꼴 | 테마에 의존하는 대신 해당 부분에 요청된 글꼴 패밀리를 고정합니다. | 직접 서식이 테마 선택을 무시하므로 해당 부분은 변경되지 않을 수 있습니다. |
| 글꼴 대체 | 요청된 글꼴이 없거나 대체 규칙이 적용될 때 해당 글꼴을 교체합니다. | 글꼴 요청 후에 작동하며, 테마의 스크립트 매핑을 재정의하지 않습니다. |
| 글꼴 폴백 | 선택된 글꼴에 포함되지 않은 글리프를 제공하며, 주로 특정 Unicode 범위에 사용됩니다. | 누락된 글리프를 보완하지만 저장된 테마 매핑을 변경하지는 않습니다. |

마지막 두 메커니즘에 대한 자세한 내용은 [Font Substitution](/slides/ko/python-net/font-substitution/) 및 [Fallback Fonts](/slides/ko/python-net/fallback-font/)을 참조하십시오.

[Presentation.master_theme](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/master_theme/)에서 매핑을 변경하면 해당 테마에 여전히 의존하는 실제 서식이 적용된 콘텐츠에만 영향을 미칩니다. 텍스트는 마스터, 레이아웃, 슬라이드에서 테마 오버라이드를 상속하거나 명시적으로 지정된 글꼴을 사용할 수 있습니다. 표시 결과가 프레젠테이션 수준 매핑을 따르지 않을 때는 이러한 수준을 검사하십시오.

## **매핑된 글꼴을 사용 가능하게 하고 결과 검증**

스크립트 매핑은 글꼴 패밀리 이름만 저장하며, 해당 글꼴 파일을 설치하거나 로드하지는 않습니다. 일관된 렌더링 및 내보내기를 위해서는 매핑된 모든 글꼴이 환경에 설치되어 있거나 [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides.fontsloader/load_external_fonts/) 또는 [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/document_level_font_sources/)와 같은 사용자 지정 소스를 통해 Aspose.Slides에 제공되어야 합니다. 사용 가능한 로드 옵션은 [Custom Fonts](/slides/ko/python-net/custom-font/)를 참조하십시오.

저장된 매핑을 검증하는 것은 테마 정의가 보존되었는지 여부만 확인합니다. 글꼴이 실제로 사용 가능하고 모든 필요한 글리프를 포함하며 의도된 레이아웃을 만들었다는 것을 증명하지는 않습니다. 각 필요한 쓰기 시스템에 대한 대표 텍스트를 이미지나 PDF로 렌더링하고 결과를 검사하십시오. 이렇게 하면 프레젠테이션을 배포하기 전에 누락된 글꼴, 불완전한 글리프 커버리지, 폴백 동작 및 레이아웃 변경을 감지할 수 있습니다. 렌더링 및 내보내기 예시는 [Convert PowerPoint Presentations](/slides/ko/python-net/convert-powerpoint/)를 참고하십시오.

## **FAQ**

**스크립트가 매핑되지 않았을 때 `get_script_font`는 무엇을 반환합니까?**

[Fonts.get_script_font](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fonts/get_script_font/)은 요청된 스크립트 매핑이 해당 메이저 또는 마이너 글꼴 컬렉션에 정의되어 있지 않을 경우 `None`을 반환합니다.

**스크립트가 이미 존재할 때 `set_script_font`가 두 번째 매핑을 추가합니까?**

아니요. [Fonts.set_script_font](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fonts/set_script_font/)은 매핑이 없을 경우 새로 만들고, 동일한 스크립트 태그가 이미 존재하면 매핑된 글꼴 패밀리를 교체합니다.

**테마 매핑을 변경했는데 일부 텍스트가 바뀌지 않은 이유는 무엇입니까?**

텍스트에 명시적으로 지정된 글꼴이 있거나, 오버라이드를 통해 다른 테마를 상속받았거나, 렌더링 중에 대체 또는 폴백의 영향을 받았을 수 있습니다. 프레젠테이션 수준의 스크립트 매핑은 실제 서식이 해당 테마 글꼴 컬렉션을 여전히 참조하는 텍스트에만 영향을 미칩니다.

**저장 후 다시 열기가 다국어 출력 검증에 충분합니까?**

아니요. 다시 열기는 테마 데이터의 지속성을 확인할 뿐입니다. 또한 각 필요한 쓰기 시스템에 대한 대표 텍스트를 렌더링하여 매핑된 글꼴이 사용 가능하고 필요한 글리프를 포함하는지 확인해야 합니다.