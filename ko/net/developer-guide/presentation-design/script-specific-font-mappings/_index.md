---
title: .NET에서 스크립트별 테마 글꼴 관리
linktitle: 스크립트별 테마 글꼴
type: docs
weight: 15
url: /ko/net/script-specific-font-mappings/
keywords:
- 스크립트별 글꼴
- 테마 글꼴 매핑
- 다국어 프레젠테이션
- 쓰기 시스템
- 키릴 글꼴
- 아랍어 글꼴
- 일본어 글꼴
- 그루지야어 글꼴
- 타아나 글꼴
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "PowerPoint 테마에서 Aspose.Slides for .NET을 사용하여 스크립트별 글꼴 매핑을 검사하고, 추가하고, 교체하고, 제거합니다."
---
## **개요**

프레젠테이션 테마는 서로 다른 쓰기 시스템에 대해 서로 다른 글꼴 패밀리를 선택할 수 있습니다. 이렇게 하면 테마 글꼴을 계속 사용하면서도 키릴 문자, 아랍어, 일본어, 그루지야어, 타아나어 등 다양한 스크립트에 적합한 글꼴을 사용하여 다국어 텍스트를 하나의 일관된 글꼴 스키마로 관리할 수 있습니다.

테마의 [IFontScheme](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/ifontscheme/)에는 일반적으로 머리글에 사용되는 주요 글꼴 컬렉션과 본문 텍스트에 사용되는 부수 글꼴 컬렉션이 포함됩니다. 라틴 및 동아시아 글꼴 속성 외에도 두 컬렉션 모두 [IFonts](https://reference.aspose.com/slides/ko/net/aspose.slides/ifonts/) 인터페이스를 통해 쓰기 시스템 태그와 글꼴 패밀리 이름 간의 매핑을 제공합니다.

이 문서에서는 프레젠테이션의 마스터 테마에서 해당 매핑을 검사하고 수정하는 방법을 보여주고, 저장‑재로드 사이클에서도 변경 사항이 유지되는지 확인하는 방법을 설명합니다.

## **스크립트 태그 이해**

스크립트 글꼴 메서드는 네 글자 BCP 47 스크립트 서브태그를 사용하여 쓰기 시스템을 식별합니다. 일반적인 값은 다음과 같습니다.

| 스크립트 태그 | 쓰기 시스템 |
|---|---|
| `Cyrl` | 키릴 문자 |
| `Arab` | 아랍어 |
| `Hans` | 간체 중국어 |
| `Jpan` | 일본어 |
| `Geor` | 그루지야어 |
| `Thaa` | 타아나어 |

이 매핑은 개별 텍스트 구간이 아니라 테마 글꼴 스키마에 속합니다. 프레젠테이션은 주요 컬렉션과 부수 컬렉션에 대해 서로 다른 매핑을 정의할 수 있으며, 일부 스크립트에 대한 매핑을 생략할 수도 있습니다.

## **스크립트 글꼴 매핑에 접근하고 검사하기**

[Presentation.MasterTheme](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/mastertheme/)을 사용하여 프레젠테이션 수준의 테마에 접근합니다. [FontScheme.Major](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/fontscheme/major/) 및 [FontScheme.Minor](https://reference.aspose.com/slides/ko/net/aspose.slides.theme/fontscheme/minor/) 속성은 두 개의 [IFonts](https://reference.aspose.com/slides/ko/net/aspose.slides/ifonts/) 컬렉션을 반환합니다.

[IFonts.GetScriptFontMap](https://reference.aspose.com/slides/ko/net/aspose.slides/fonts/getscriptfontmap/)을 호출하면 컬렉션의 모든 매핑을 가져올 수 있습니다. 특정 쓰기 시스템을 조회하려면 해당 스크립트 태그와 함께 [IFonts.GetScriptFont](https://reference.aspose.com/slides/ko/net/aspose.slides/fonts/getscriptfont/)을 호출합니다. `GetScriptFont`은 해당 컬렉션에 요청된 매핑이 정의되지 않은 경우 `null`을 반환합니다.

## **매핑 수정 및 지속성 확인**

[IFonts.SetScriptFont](https://reference.aspose.com/slides/ko/net/aspose.slides/fonts/setscriptfont/)을 사용하여 매핑을 생성하거나 현재 글꼴 패밀리를 교체합니다. [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/ko/net/aspose.slides/fonts/removescriptfont/)을 사용하면 매핑을 제거할 수 있습니다.

다음은 엔드‑투‑엔드 예제로, 기존의 모든 주요·부수 매핑을 읽고, 일본어 주요 글꼴을 조회하며, 키릴 주요 글꼴을 변경하고, 타아나 부수 매핑을 제거한 뒤 프레젠테이션을 저장하고 다시 열어 두 변경 사항을 확인합니다. 제거 단계가 초기 테마와 무관하도록, 예제는 타아나 매핑이 아직 정의되지 않은 경우에만 매핑을 생성합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

검증은 일반 조회와 동일한 `null` 동작을 사용합니다. 제거가 저장된 후 `GetScriptFont("Thaa")`는 부수 컬렉션에 대해 `null`을 반환합니다.

## **테마 매핑과 기타 글꼴 설정 구분하기**

스크립트‑특정 테마 매핑은 글꼴 선택에 참여하지만, 직접 텍스트 서식, 대체 및 폰트 폴백과는 다른 문제를 해결합니다.

| 메커니즘 | 목적 | 테마 매핑 변경 시 효과 |
|---|---|---|
| 스크립트‑특정 테마 글꼴 매핑 | 쓰기 시스템에 대해 주요 또는 부수 테마 글꼴을 선택 | 해당 테마 글꼴을 사용하는 텍스트가 새 매핑된 패밀리로 해석될 수 있음 |
| 텍스트 구간에 명시적으로 할당된 글꼴 | 테마에 의존하지 않고 해당 구간에 요청된 글꼴 패밀리를 고정 | 직접 서식이 테마 선택을 무시하므로 구간이 변경되지 않을 수 있음 |
| 글꼴 대체 | 요청된 글꼴이 없거나 대체 규칙이 적용될 때 다른 글꼴로 교체 | 글꼴이 요청된 뒤에 작동하며, 테마 스크립트 매핑을 재정의하지 않음 |
| 글꼴 폴백 | 선택된 글꼴에 포함되지 않은 글리프를 보충, 주로 특정 유니코드 범위에 사용 | 누락된 글리프 범위를 채우지만 저장된 테마 매핑을 변경하지 않음 |

마지막 두 메커니즘에 대한 자세한 내용은 [Font Substitution](/slides/ko/net/font-substitution/) 및 [Fallback Fonts](/slides/ko/net/fallback-font/)을 참고하십시오.

[Presentation.MasterTheme](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/mastertheme/)의 매핑을 변경하면 해당 테마에 여전히 의존하는 콘텐츠에만 영향을 줍니다. 텍스트는 마스터, 레이아웃 또는 슬라이드에서 테마 오버라이드를 상속하거나, 명시적으로 할당된 글꼴을 사용할 수 있습니다. 보이는 결과가 프레젠테이션‑수준 매핑을 따르지 않을 경우 이러한 수준을 검사하십시오.

## **매핑된 글꼴 사용 가능하게 하고 결과 검증하기**

스크립트 매핑은 글꼴 패밀리 이름만 저장하며, 해당 글꼴 파일을 설치하거나 로드하지는 않습니다. 일관된 렌더링 및 내보내기를 위해 매핑된 모든 글꼴은 환경에 설치되어 있거나 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/loadexternalfonts/) 또는 [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/documentlevelfontsources/)와 같은 사용자 정의 소스를 통해 Aspose.Slides에 제공되어야 합니다. 사용 가능한 로드 옵션은 [Custom Fonts](/slides/ko/net/custom-font/)를 참조하십시오.

저장된 매핑을 검증하는 것은 테마 정의가 보존되었음을 확인할 뿐이며, 글꼴이 실제로 사용 가능하거나 모든 필수 글리프를 포함하고 있는지, 의도한 레이아웃을 생성하는지는 증명하지 못합니다. 각 필수 쓰기 시스템에 대해 대표 텍스트를 이미지나 PDF로 렌더링하고 결과를 확인하십시오. 이렇게 하면 누락된 글꼴, 불완전한 글리프 커버리지, 폰트 폴백 동작 및 레이아웃 변화 등을 프레젠테이션 배포 전에 발견할 수 있습니다. 렌더링 및 내보내기 예제는 [Convert PowerPoint Presentations](/slides/ko/net/convert-powerpoint/)를 참조하십시오.

## **FAQ**

**`GetScriptFont`가 매핑되지 않은 스크립트에 대해 반환하는 값은 무엇인가요?**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/ko/net/aspose.slides/fonts/getscriptfont/)은 해당 주요 또는 부수 글꼴 컬렉션에 요청된 스크립트 매핑이 정의되지 않은 경우 `null`을 반환합니다.

**`SetScriptFont`는 이미 존재하는 스크립트에 대해 두 번째 매핑을 추가하나요?**

아니요. [IFonts.SetScriptFont](https://reference.aspose.com/slides/ko/net/aspose.slides/fonts/setscriptfont/)은 매핑이 없을 때 새로 생성하고, 동일한 스크립트 태그가 이미 존재하면 매핑된 글꼴 패밀리를 교체합니다.

**테마 매핑을 변경했는데 일부 텍스트가 바뀌지 않은 이유는 무엇인가요?**

텍스트에 명시적으로 할당된 글꼴이 있거나, 오버라이드를 통해 다른 테마를 상속받았거나, 렌더링 중에 대체 또는 폴백에 의해 영향을 받았을 수 있습니다. 프레젠테이션‑수준 스크립트 매핑은 여전히 해당 테마 글꼴 컬렉션을 참조하는 텍스트에만 적용됩니다.

**저장 후 재열기가 다국어 출력 검증에 충분한가요?**

아니요. 재열기는 테마 데이터의 지속성을 확인할 뿐입니다. 각 쓰기 시스템에 대해 대표 텍스트를 렌더링하여 매핑된 글꼴이 실제로 사용 가능하고 필요한 모든 글리프를 포함하는지 확인해야 합니다.