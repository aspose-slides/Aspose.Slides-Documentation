---
title: .NET에서 PowerPoint 글꼴을 맞춤 설정
linktitle: 맞춤 글꼴
type: docs
weight: 20
url: /ko/net/custom-font/
keywords:
- 글꼴
- 맞춤 글꼴
- 외부 글꼴
- 글꼴 로드
- 글꼴 관리
- 글꼴 폴더
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: ".NET용 Aspose.Slides를 사용하여 PowerPoint 슬라이드의 글꼴을 맞춤 설정하면 프레젠테이션을 언제든지 선명하고 일관되게 유지할 수 있습니다."
---
## **개요**

Aspose.Slides는 운영 체제에 설치하지 않고도 프레젠테이션에서 사용자 지정 글꼴을 사용할 수 있게 합니다. 사용자 지정 폴더에서 글꼴을 로드하거나, 문서 수준 글꼴 소스를 통해 특정 프레젠테이션에 대한 글꼴을 제공하거나, 바이너리 데이터에서 직접 외부 글꼴을 로드할 수 있습니다.

로드된 글꼴은 프레젠테이션을 렌더링하거나 PDF, 이미지 및 기타 지원 형식으로 내보낼 때 사용됩니다. 이는 다양한 환경에서 프레젠테이션 출력이 일관되도록 도와줍니다. 이 문서에서는 Aspose.Slides가 사용하는 글꼴 폴더를 검사하는 방법과 외부 글꼴 작업 후 글꼴 캐시를 지우는 방법도 설명합니다.

렌더링을 위해 사용자 지정 글꼴을 등록하는 것은 PPTX 파일에 글꼴을 포함시키는 것과 별개입니다. 글꼴을 프레젠테이션 자체에 저장해야 하는 경우, 글꼴 포함 기능을 명시적으로 사용하십시오.

프레젠테이션 테마는 개별 쓰기 시스템에 대해 서로 다른 글꼴 패밀리를 참조할 수 있습니다. 이러한 매핑은 글꼴 이름을 저장하지만 글꼴 파일을 설치하거나 로드하지는 않습니다. 매핑을 관리하려면 [스크립트별 테마 글꼴](/slides/ko/net/script-specific-font-mappings/)을 참조하고, 아래 로드 옵션을 사용하여 참조된 글꼴을 일관된 렌더링을 위해 사용할 수 있게 하십시오.

{{% alert color="info" title="Note" %}}
Aspose Slides는 다음 메서드를 사용하여 이러한 글꼴을 로드할 수 있습니다: [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) 메서드:

* TrueType(.ttf) 및 TrueType Collection(.ttc) 글꼴. 자세한 내용은 [TrueType](https://en.wikipedia.org/wiki/TrueType) 을(를) 참조하십시오.
* OpenType(.otf) 글꼴. 자세한 내용은 [OpenType](https://en.wikipedia.org/wiki/OpenType) 을(를) 참조하십시오.
{{% /alert %}}

## **사용자 지정 글꼴 로드**

Aspose.Slides는 시스템에 설치하지 않고도 프레젠테이션에서 사용되는 글꼴을 로드할 수 있게 합니다. 이는 PDF, 이미지 및 기타 지원 형식과 같은 내보내기 결과에 영향을 미쳐, 생성된 문서가 다양한 환경에서 일관되게 보이도록 합니다. 글꼴은 사용자 지정 디렉터리에서 로드됩니다.

1. 글꼴 파일이 포함된 하나 이상의 폴더를 지정합니다.
2. 정적 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) 메서드를 호출하여 해당 폴더에서 글꼴을 로드합니다.
3. 프레젠테이션을 로드하고 렌더링/내보냅니다.
4. [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) 를 호출하여 글꼴 캐시를 지웁니다.

다음 코드 예제는 글꼴 로드 프로세스를 보여줍니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 사용자 지정 글꼴 파일이 포함된 폴더를 정의합니다.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// 지정된 폴더에서 사용자 지정 글꼴을 로드합니다.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// 로드된 글꼴을 사용하여 프레젠테이션을 렌더링/내보냅니다(예: PDF, 이미지 또는 기타 형식).
presentation.Save("output.pdf", SaveFormat.Pdf);

// 작업이 완료된 후 글꼴 캐시를 지웁니다.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/)은(는) 글꼴 검색 경로에 추가 폴더를 추가하지만 글꼴 초기화 순서는 변경하지 않습니다. 글꼴은 다음 순서로 초기화됩니다:

1. 기본 운영 체제 글꼴 경로.
2. [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/)을 통해 로드된 경로.
{{%/alert %}}

## **사용자 지정 글꼴 폴더 가져오기**
Aspose.Slides는 글꼴 폴더를 찾을 수 있도록 [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) 메서드를 제공합니다. 이 메서드는 `LoadExternalFonts` 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더를 반환합니다.

다음 C# 코드는 [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) 사용 방법을 보여줍니다:

```c#
using Aspose.Slides;

// 이 줄은 글꼴 파일이 확인되는 폴더를 출력합니다.
// 이는 LoadExternalFonts 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더입니다.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **프레젠테이션에 사용되는 사용자 지정 글꼴 지정**
Aspose.Slides는 프레젠테이션에 사용할 외부 글꼴을 지정할 수 있도록 [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) 속성을 제공합니다.

다음 C# 코드는 [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) 속성 사용 방법을 보여줍니다:

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // 프레젠테이션 작업
    // CustomFont1, CustomFont2 및 assets\fonts와 global\fonts 폴더 및 하위 폴더에 있는 글꼴을 프레젠테이션에서 사용할 수 있습니다.
}
```

## **외부에서 글꼴 관리**
Aspose.Slides는 바이너리 데이터에서 외부 글꼴을 로드할 수 있도록 [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) 메서드를 제공합니다.

다음 C# 코드는 바이트 배열을 사용한 글꼴 로드 프로세스를 보여줍니다: 

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // 프레젠테이션 수명 동안 로드된 외부 글꼴
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

임베드된 글꼴을 제거하지 않고 내보내기 중에 일치하는 등록 글꼴이 우선하도록 하려면 [등록된 글꼴을 임베드된 글꼴보다 우선](/slides/ko/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) 를 참조하십시오(.NET 26.11 이상).

## **자주 묻는 질문**

**사용자 지정 글꼴이 모든 형식(PDF, PNG, SVG, HTML)으로의 내보내기에 영향을 줍니까?**  
예. 연결된 글꼴은 모든 내보내기 형식에서 렌더러에 의해 사용됩니다.

**사용자 지정 글꼴이 결과 PPTX에 자동으로 포함됩니까?**  
아니요. 렌더링을 위해 글꼴을 등록하는 것은 PPTX에 포함시키는 것과 동일하지 않습니다. 프레젠테이션 파일에 글꼴을 포함시켜야 한다면 명시적인 [포함 기능](/slides/ko/net/embedded-font/)를 사용해야 합니다.

**사용자 지정 글꼴에 특정 글리프가 없을 때 대체 동작을 제어할 수 있습니까?**  
예. 요청된 글리프가 없을 때 어떤 글꼴을 사용할지 정확히 정의하려면 [글꼴 대체](/slides/ko/net/font-substitution/), [대체 규칙](/slides/ko/net/font-replacement/), [대체 세트](/slides/ko/net/fallback-font/)을 구성하십시오.

**Linux/Docker 컨테이너에서 시스템 전체에 설치하지 않고 글꼴을 사용할 수 있습니까?**  
예. 자체 글꼴 폴더를 지정하거나 바이트 배열에서 글꼴을 로드하면 됩니다. 이렇게 하면 컨테이너 이미지에서 시스템 글꼴 디렉터리에 대한 의존성이 제거됩니다.

> **Linux/Docker에 대한 참고**: `FontsLoader.LoadExternalFonts`를 호출할 때, `directories` 배열의 각 항목에 비어 있지 않은 기존 디렉터리 경로가 포함되어 있는지 확인하십시오. 글꼴 경로를 구성하는 데 사용된 환경 변수가 정의되지 않았거나 비어 있으면 Aspose.Slides가 빈 값을 전체 경로로 해석하려고 시도하여 `System.ArgumentException`이 발생할 수 있습니다.

**라이선스는 어떻게 되나요—제한 없이 사용자 지정 글꼴을 포함시킬 수 있나요?**  
귀하는 글꼴 라이선스 준수에 대한 책임이 있습니다. 조건은 다르며, 일부 라이선스는 포함이나 상업적 사용을 금지합니다. 출력물을 배포하기 전에 항상 해당 글꼴의 최종 사용자 사용권 계약(EULA)을 검토하십시오.