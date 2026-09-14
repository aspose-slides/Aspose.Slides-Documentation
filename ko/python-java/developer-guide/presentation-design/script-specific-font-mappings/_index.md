---
title: Python을 통해 Java에서 스크립트별 테마 글꼴 관리
linktitle: 스크립트별 테마 글꼴
type: docs
weight: 15
url: /ko/python-java/script-specific-font-mappings/
keywords:
- 스크립트 별 글꼴
- 테마 글꼴 매핑
- 다국어 프레젠테이션
- 필기 체계
- 키릴 글꼴
- 아랍어 글꼴
- 일본어 글꼴
- 그루지아어 글꼴
- 타아나 글꼴
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python을 통해 Java에서 Aspose.Slides를 사용하여 PowerPoint 테마의 스크립트별 글꼴 매핑을 검사하고, 추가하고, 교체하고, 제거합니다."
---
## **개요**

프레젠테이션 테마는 다양한 필기 체계에 대해 서로 다른 글꼴 패밀리를 선택할 수 있습니다. 이렇게 하면 테마 글꼴을 계속 사용하면서도, 키릴 문자, 아랍어, 일본어, 그루지아어, 타아나 문자 등 각 스크립트에 적합한 글꼴을 사용하여 다국어 텍스트가 하나의 일관된 글꼴 스킴을 따르게 할 수 있습니다.

테마의 [FontScheme](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontscheme/)에는 주로 제목에 사용되는 주요 글꼴 컬렉션과 본문 텍스트에 사용되는 보조 글꼴 컬렉션이 포함됩니다. 라틴어 및 동아시아 글꼴 설정 외에도, 두 컬렉션 모두 [Fonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fonts/) 클래스를 통해 필기 체계 태그를 글꼴 패밀리 이름에 매핑하는 기능을 제공합니다.

이 문서에서는 프레젠테이션 마스터 테마에서 해당 매핑을 검사하고 수정하는 방법과 저장‑재로드 사이클에서도 변경 사항이 유지되는지를 확인하는 방법을 보여줍니다.

## **스크립트 태그 이해**

스크립트 글꼴 메서드는 네 글자 BCP 47 스크립트 서브태그를 사용해 필기 체계를 식별합니다. 일반적인 값은 다음과 같습니다:

| 스크립트 태그 | 필기 체계 |
|---|---|
| `Cyrl` | 키릴 문자 |
| `Arab` | 아랍어 |
| `Hans` | 간체 중국어 |
| `Jpan` | 일본어 |
| `Geor` | 그루지아어 |
| `Thaa` | 타아나 문자 |

이 매핑은 개별 텍스트 부분이 아니라 테마 글꼴 스킴에 속합니다. 프레젠테이션은 주요 컬렉션과 보조 컬렉션에 대해 서로 다른 매핑을 정의할 수 있으며, 일부 스크립트에 대한 매핑을 생략할 수도 있습니다.

## **스크립트 글꼴 매핑 접근 및 검사**

[Presentation.getMasterTheme](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getMasterTheme) 메서드를 사용해 프레젠테이션 수준 테마에 접근합니다. [FontScheme.getMajor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontscheme/#getMajor)와 [FontScheme.getMinor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontscheme/#getMinor) 메서드는 두 개의 [Fonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fonts/) 컬렉션을 반환합니다.

[Fonts.getScriptFontMap](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fonts/#getScriptFontMap) 를 호출하면 컬렉션에 있는 모든 매핑을 가져올 수 있습니다. 특정 필기 체계를 조회하려면 해당 스크립트 태그와 함께 [Fonts.getScriptFont](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fonts/#getScriptFont) 를 호출합니다. 요청한 매핑이 정의되지 않은 경우 `getScriptFont` 는 `None` 을 반환합니다.

## **매핑 수정 및 지속성 검증**

[Fonts.setScriptFont](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fonts/#setScriptFont) 을 사용해 매핑을 새로 만들거나 현재 글꼴 패밀리를 교체합니다. [Fonts.removeScriptFont](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fonts/#removeScriptFont) 을 사용해 매핑을 삭제합니다.

다음은 전체 흐름을 보여주는 예제입니다. 모든 기존 주요·보조 매핑을 읽고, 일본어 주요 글꼴을 조회한 뒤, 키릴 주요 글꼴을 변경하고, 타아나 보조 매핑을 삭제합니다. 그런 다음 프레젠테이션을 저장하고 다시 열어 두 변경 사항이 유지되는지 확인합니다. 초기 테마에 타아나 매핑이 없을 경우에만 매핑을 만든다는 점에서 삭제 단계가 독립적입니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

검증은 일반 조회와 동일한 `None` 동작을 이용합니다. 삭제가 저장된 후 `getScriptFont("Thaa")` 는 보조 컬렉션에 대해 `None` 을 반환합니다.

## **테마 매핑과 기타 글꼴 설정 구분**

스크립트 전용 테마 매핑은 글꼴 선택에 참여하지만, 직접 텍스트 서식, 대체 및 폰트 폴백과는 다른 문제를 해결합니다:

| 메커니즘 | 목적 | 테마 매핑을 변경했을 때의 효과 |
|---|---|---|
| 스크립트 전용 테마 글꼴 매핑 | 필기 체계에 대해 주요·보조 테마 글꼴을 선택함 | 해당 테마 글꼴을 계속 사용하는 텍스트가 새로운 매핑된 패밀리로 해석될 수 있음 |
| 텍스트 부분에 명시적으로 지정된 글꼴 | 테마 대신 해당 부분에 특정 글꼴 패밀리를 강제함 | 직접 서식이 테마 선택을 무시하므로 텍스트가 변하지 않을 수 있음 |
| 글꼴 대체 | 요청한 글꼴이 없거나 대체 규칙이 적용될 때 다른 글꼴로 교체 | 글꼴이 요청된 뒤에 작동하므로 테마 스크립트 매핑을 재정의하지 않음 |
| 글꼴 폴백 | 선택된 글꼴에 포함되지 않은 글리프를 보완함 (주로 특정 유니코드 범위) | 누락된 글리프를 채워 주지만 저장된 테마 매핑은 바뀌지 않음 |

마지막 두 메커니즘에 대한 자세한 내용은 [Font Substitution](/slides/ko/python-java/font-substitution/) 및 [Fallback Fonts](/slides/ko/python-java/fallback-font/) 를 참고하십시오.

[Presentation.getMasterTheme](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getMasterTheme) 에서 매핑을 변경하면, 실제 서식이 해당 테마에 의존하는 콘텐츠에만 영향을 미칩니다. 텍스트가 마스터, 레이아웃 또는 슬라이드에서 테마 오버라이트를 상속하거나 명시적으로 지정된 글꼴을 사용하고 있다면 결과가 다를 수 있습니다. 눈에 보이는 결과가 프레젠테이션 수준 매핑을 따르지 않을 때는 이러한 수준도 확인하십시오.

## **매핑된 글꼴 사용 가능하게 하고 결과 검증**

스크립트 매핑은 글꼴 패밀리 이름만 저장하며, 해당 글꼴 파일을 설치하거나 로드하지는 않습니다. 일관된 렌더링 및 내보내기를 위해 매핑된 모든 글꼴은 환경에 설치되어 있거나 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsloader/#loadExternalFonts) 나 [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) 와 같은 사용자 지정 소스를 통해 Aspose.Slides에 제공되어야 합니다. 사용 가능한 로드 옵션은 [Custom Fonts](/slides/ko/python-java/custom-font/) 를 참고하십시오.

저장된 매핑을 검증하는 것은 테마 정의가 보존되었음을 확인하는 것에 불과합니다. 글꼴이 실제로 사용 가능한지, 모든 필요한 글리프를 포함하는지, 의도한 레이아웃을 생성하는지는 검증되지 않습니다. 각 필기 체계에 대해 대표 텍스트를 이미지나 PDF 로 렌더링하고 결과물을 검사하십시오. 이렇게 하면 누락된 글꼴, 불완전한 글리프 커버리지, 폰트 폴백 동작 및 레이아웃 변형을 프레젠테이션 배포 전에 발견할 수 있습니다. 렌더링 및 내보내기 예제는 [Convert PowerPoint Presentations](/slides/ko/python-java/convert-powerpoint/) 를 확인하십시오.

## **FAQ**

**`getScriptFont` 가 매핑되지 않은 스크립트에 대해 반환하는 값은?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fonts/#getScriptFont) 은 해당 주요·보조 컬렉션에 요청한 스크립트 매핑이 정의되지 않은 경우 `None` 을 반환합니다.

**`setScriptFont` 가 이미 존재하는 스크립트에 대해 두 번째 매핑을 추가하나요?**

아니요. [Fonts.setScriptFont](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fonts/#setScriptFont) 은 매핑이 없을 때 새로 만들고, 동일한 스크립트 태그가 이미 존재하면 매핑된 글꼴 패밀리를 교체합니다.

**왜 테마 매핑을 변경했는데 일부 텍스트가 바뀌지 않았나요?**

해당 텍스트가 명시적으로 다른 글꼴이 지정되었거나, 오버라이트를 통해 다른 테마를 상속받았거나, 렌더링 시 대체 또는 폴백에 의해 영향을 받았을 수 있습니다. 프레젠테이션 수준 스크립트 매핑은 여전히 해당 테마 글꼴 컬렉션을 참조하는 텍스트에만 적용됩니다.

**저장 후 재열기가 다국어 출력 검증에 충분한가요?**

아니요. 재열기는 테마 데이터의 지속성을 확인해 주지만, 각 필기 체계에 대해 대표 텍스트를 렌더링해 매핑된 글꼴이 실제로 사용 가능하고 필요한 글리프를 포함하는지를 확인해야 합니다.