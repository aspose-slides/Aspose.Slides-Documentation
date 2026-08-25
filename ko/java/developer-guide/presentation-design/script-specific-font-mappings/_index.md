---
title: Java에서 스크립트별 테마 글꼴 관리
linktitle: 스크립트별 테마 글꼴
type: docs
weight: 15
url: /ko/java/script-specific-font-mappings/
keywords:
- 스크립트별 글꼴
- 테마 글꼴 매핑
- 다국어 프레젠테이션
- 쓰기 시스템
- 시릴릭 글꼴
- 아라비아 글꼴
- 일본어 글꼴
- 조지아어 글꼴
- 타아나 글꼴
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 테마에서 스크립트별 글꼴 매핑을 검사하고, 추가하고, 교체하고, 제거합니다."
---
## **개요**

프레젠테이션 테마는 서로 다른 쓰기 시스템에 대해 서로 다른 글꼴 패밀리를 선택할 수 있습니다. 이를 통해 테마 글꼴을 사용하는 다국어 텍스트가 시릴릭, 아라비아어, 일본어, 조지아어, 타아나 및 기타 스크립트에 적합한 글꼴을 사용하면서도 하나의 조화된 글꼴 스킴을 따르게 됩니다.

테마의 [IFontScheme](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontscheme/)에는 일반적으로 제목에 사용되는 메이저 글꼴 컬렉션과 본문에 사용되는 마이너 글꼴 컬렉션이 포함됩니다. 라틴 및 동아시아 글꼴 설정 외에도 두 컬렉션 모두 [IFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifonts/) 인터페이스를 통해 쓰기 시스템 태그와 글꼴 패밀리 이름 간의 매핑을 제공합니다.

이 문서에서는 프레젠테이션 마스터 테마에서 해당 매핑을 검사하고 수정하는 방법과 저장‑재로드 사이클 후에도 변경 사항이 유지되는지를 확인하는 방법을 보여줍니다.

## **스크립트 태그 이해하기**

스크립트 글꼴 메서드는 네 글자 BCP 47 스크립트 서브태그를 사용해 쓰기 시스템을 식별합니다. 일반적인 값은 다음과 같습니다.

| 스크립트 태그 | 쓰기 시스템 |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Simplified Chinese |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

이 매핑은 테마 글꼴 스킴에 속하며 개별 텍스트 구간에 속하지 않습니다. 프레젠테이션은 메이저와 마이너 컬렉션에 대해 서로 다른 매핑을 정의할 수 있으며, 일부 스크립트에 대한 매핑을 생략할 수도 있습니다.

## **스クリプ트 글꼴 매핑에 접근하고 검사하기**

[Presentation.getMasterTheme](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getMasterTheme--)을 사용해 프레젠테이션 수준 테마에 접근합니다. [IFontScheme.getMajor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontscheme/#getMajor--) 및 [IFontScheme.getMinor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontscheme/#getMinor--) 메서드는 두 개의 [IFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifonts/) 컬렉션을 반환합니다.

컬렉션의 모든 매핑을 가져오려면 [IFonts.getScriptFontMap](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fonts/#getScriptFontMap--)을 호출합니다. 특정 쓰기 시스템을 조회하려면 해당 스크립트 태그와 함께 [IFonts.getScriptFont](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-)를 호출합니다. `getScriptFont`는 해당 컬렉션에 요청된 매핑이 정의되어 있지 않을 경우 `null`을 반환합니다.

## **매핑 수정 및 지속성 확인**

[IFonts.setScriptFont](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-)을 사용해 매핑을 생성하거나 현재 글꼴 패밀리를 교체합니다. [IFonts.removeScriptFont](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-)을 사용해 매핑을 제거합니다.

다음 엔드‑투‑엔드 예제는 기존 메이저 및 마이너 매핑을 모두 읽고, 일본어 메이저 글꼴을 조회하고, 시릴릭 메이저 글꼴을 변경하고, 타아나 마이너 매핑을 제거한 뒤 프레젠테이션을 저장하고 다시 열어 두 변경 사항을 검증합니다. 초기 테마와 무관하게 제거 단계를 수행하기 위해, 예제는 타아나 매핑이 아직 정의되지 않은 경우에만 해당 매핑을 생성합니다.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

검증은 일반 조회와 동일한 `null` 동작을 사용합니다. 제거가 저장된 후 `getScriptFont("Thaa")`는 마이너 컬렉션에 대해 `null`을 반환합니다.

## **테마 매핑과 기타 글꼴 설정 구분하기**

스크립트‑특정 테마 매핑은 글꼴 선택에 참여하지만, 직접 텍스트 서식 지정, 대체 및 폰트 폴백과는 다른 문제를 해결합니다.

| 메커니즘 | 목적 | 테마 매핑 변경 시 효과 |
|---|---|---|
| 스크립트‑특정 테마 글꼴 매핑 | 쓰기 시스템에 대해 메이저 또는 마이너 테마 글꼴을 선택합니다. | 해당 테마 글꼴을 계속 사용하는 텍스트는 새로운 매핑된 패밀리로 해석될 수 있습니다. |
| 텍스트 구간에 명시적으로 지정된 글꼴 | 테마에 의존하지 않고 해당 구간에 요청된 글꼴 패밀리를 고정합니다. | 직접 서식이 테마 선택을 우선시하므로 구간이 변하지 않을 수 있습니다. |
| 글꼴 대체 | 요청된 글꼴이 없거나 대체 규칙이 적용될 때 해당 글꼴을 교체합니다. | 글꼴이 요청된 후에 작동하며 테마의 스크립트 매핑을 재정의하지 않습니다. |
| 글꼴 폴백 | 선택된 글꼴에 포함되지 않은 글리프를 제공하며, 주로 특정 유니코드 범위에 사용됩니다. | 누락된 글리프를 채우지만 저장된 테마 매핑을 변경하지는 않습니다. |

마지막 두 메커니즘에 대한 자세한 내용은 [Font Substitution](/slides/ko/java/font-substitution/) 및 [Fallback Fonts](/slides/ko/java/fallback-font/)를 참조하십시오.

[Presentation.getMasterTheme](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getMasterTheme--)에서 매핑을 변경하면 해당 테마에 아직 의존하는 효과적인 서식에만 영향을 줍니다. 텍스트는 마스터, 레이아웃 또는 슬라이드에서 테마 오버라이드를 상속하거나 명시적으로 지정된 글꼴을 사용할 수 있습니다. 표시 결과가 프레젠테이션 수준 매핑을 따르지 않을 때는 이러한 수준을 검사하세요.

## **매핑된 글꼴을 사용 가능하게 하고 결과 검증하기**

스크립트 매핑은 글꼴 패밀리 이름만 저장하며, 해당 글꼴 파일을 설치하거나 로드하지는 않습니다. 일관된 렌더링 및 내보내기를 위해 매핑된 모든 글꼴은 환경에 설치되어 있거나 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 또는 [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--)와 같은 사용자 정의 소스를 통해 Aspose.Slides에 제공되어야 합니다. 사용 가능한 로드 옵션은 [Custom Fonts](/slides/ko/java/custom-font/)를 참고하십시오.

저장된 매핑을 검증하는 것은 테마 정의가 보존되었음을 확인하는 것일 뿐, 글꼴이 실제로 사용 가능하고 필요한 모든 글리프를 포함하며 의도한 레이아웃을 생성하는지는 입증하지 못합니다. 각 필수 쓰기 시스템에 대해 대표 텍스트를 이미지 또는 PDF로 렌더링하고 출력을 검사하세요. 이렇게 하면 누락된 글꼴, 불완전한 글리프 커버리지, 폰트 폴백 동작 및 레이아웃 변화를 프레젠테이션 배포 전에 발견할 수 있습니다. 렌더링 및 내보내기 예제는 [Convert PowerPoint Presentations](/slides/ko/java/convert-powerpoint/)를 참조하십시오.

## **FAQ**

**`getScriptFont`가 스크립트가 매핑되지 않았을 때 반환값은?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-)은 해당 메이저 또는 마이너 글꼴 컬렉션에 요청된 스크립트 매핑이 정의되어 있지 않을 경우 `null`을 반환합니다.

**`setScriptFont`가 이미 존재하는 스크립트에 대해 두 번째 매핑을 추가합니까?**

아니요. [IFonts.setScriptFont](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-)은 매핑이 없을 때 생성하고, 동일한 스크립트 태그가 이미 존재하면 매핑된 글꼴 패밀리를 교체합니다.

**테마 매핑을 변경했는데 일부 텍스트가 바뀌지 않은 이유는?**

텍스트에 명시적으로 할당된 글꼴이 있거나, 오버라이드로 다른 테마를 상속받았거나, 렌더링 중에 대체 또는 폴백에 의해 영향을 받았을 수 있습니다. 프레젠테이션 수준 스크립트 매핑은 해당 테마 글꼴 컬렉션에 아직 의존하는 텍스트에만 영향을 줍니다.

**저장 후 재열기가 다국어 출력 검증에 충분한가요?**

아니요. 재열기는 테마 데이터의 지속성을 확인할 뿐입니다. 각 필수 쓰기 시스템에 대한 대표 텍스트를 렌더링해 매핑된 글꼴이 사용 가능하고 필요한 글리프를 포함하는지 확인해야 합니다.