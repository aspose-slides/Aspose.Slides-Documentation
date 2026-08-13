---
title: .NET에서 PowerPoint 글꼴 사용자 지정
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
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 슬라이드의 글꼴을 사용자 지정하면 어떤 장치에서도 프레젠테이션을 선명하고 일관되게 유지할 수 있습니다."
---
## **개요**

Aspose.Slides를 사용하면 운영 체제에 글꼴을 설치하지 않고도 프레젠테이션에서 맞춤 글꼴을 사용할 수 있습니다. 맞춤 폴더에서 글꼴을 로드하거나, 문서 수준 글꼴 소스를 통해 특정 프레젠테이션에 글꼴을 제공하거나, 바이너리 데이터에서 외부 글꼴을 직접 로드할 수 있습니다.

로드된 글꼴은 프레젠테이션이 렌더링되거나 PDF, 이미지 및 기타 지원 형식으로 내보내질 때 사용됩니다. 이를 통해 다른 환경에서도 프레젠테이션 출력이 일관되게 유지됩니다. 이 문서에서는 Aspose.Slides에서 사용되는 글꼴 폴더를 확인하는 방법과 외부 글꼴 사용 후 글꼴 캐시를 지우는 방법도 설명합니다.

렌더링을 위해 맞춤 글꼴을 등록하는 것은 PPTX 파일에 글꼴을 포함하는 것과 별개입니다. 프레젠테이션 자체에 글꼴을 저장해야 하는 경우 글꼴 포함 기능을 명시적으로 사용하십시오.

{{% alert color="info" %}} 

Aspose Slides를 사용하면 다음 메서드인 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/loadexternalfonts/)를 통해 이러한 글꼴을 로드할 수 있습니다:

* TrueType(.ttf) 및 TrueType Collection(.ttc) 글꼴. 자세히 보기 [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType(.otf) 글꼴. 자세히 보기 [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **맞춤 글꼴 로드**

Aspose.Slides를 사용하면 시스템에 설치하지 않고도 프레젠테이션에서 사용할 글꼴을 로드할 수 있습니다. 이는 PDF, 이미지 및 기타 지원 형식과 같은 내보내기 결과에 영향을 주어 다양한 환경에서 문서가 일관되게 표시되도록 합니다. 글꼴은 맞춤 디렉터리에서 로드됩니다.

1. 글꼴 파일이 포함된 하나 이상의 폴더를 지정합니다.
2. 해당 폴더에서 글꼴을 로드하기 위해 정적 메서드 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/loadexternalfonts/)를 호출합니다.
3. 프레젠테이션을 로드하고 렌더링/내보냅니다.
4. 글꼴 캐시를 지우기 위해 [FontsLoader.ClearCache](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/clearcache/)를 호출합니다.

다음 코드 예제는 글꼴 로드 과정을 보여줍니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 사용자 지정 글꼴 파일이 포함된 폴더를 정의합니다.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// 지정된 폴더에서 사용자 지정 글꼴을 로드합니다.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// 로드된 글꼴을 사용하여 프레젠테이션을 렌더링/내보냅니다 (예: PDF, 이미지 또는 기타 형식).
presentation.Save("output.pdf", SaveFormat.Pdf);

// 작업이 끝난 후 글꼴 캐시를 지웁니다.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/loadexternalfonts/)은 글꼴 검색 경로에 추가 폴더를 포함하지만, 글꼴 초기화 순서는 변경하지 않습니다.
글꼴은 다음 순서대로 초기화됩니다:

1. 기본 운영 체제 글꼴 경로.
1. [FontsLoader](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/)를 통해 로드된 경로.

{{%/alert %}}

## **맞춤 글꼴 폴더 가져오기**
Aspose.Slides는 [GetFontFolders](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/getfontfolders/) 메서드를 제공하여 글꼴 폴더를 찾을 수 있게 합니다. 이 메서드는 `LoadExternalFonts` 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더를 반환합니다.

다음 C# 코드는 [GetFontFolders](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/getfontfolders/)를 사용하는 방법을 보여줍니다:

```c#
using Aspose.Slides;

// 이 라인은 글꼴 파일이 확인되는 폴더를 출력합니다.
// 이는 LoadExternalFonts 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더입니다.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **프레젠테이션에 사용되는 맞춤 글꼴 지정**
Aspose.Slides는 [DocumentLevelFontSources](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/documentlevelfontsources/) 속성을 제공하여 프레젠테이션과 함께 사용할 외부 글꼴을 지정할 수 있게 합니다.

다음 C# 코드는 [DocumentLevelFontSources](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/documentlevelfontsources/) 속성을 사용하는 방법을 보여줍니다:

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
    // CustomFont1, CustomFont2 및 assets\fonts 및 global\fonts 폴더와 그 하위 폴더에 있는 글꼴이 프레젠테이션에서 사용 가능합니다.
}
```

## **외부에서 글꼴 관리**

Aspose.Slides는 [LoadExternalFont](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) 메서드를 제공하여 바이너리 데이터에서 외부 글꼴을 로드할 수 있게 합니다.

다음 C# 코드는 바이트 배열을 사용한 글꼴 로드 과정을 보여줍니다: 

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

## **자주 묻는 질문**

**맞춤 글꼴이 모든 형식(PDF, PNG, SVG, HTML)으로의 내보내기에 영향을 줍니까?**

예. 연결된 글꼴은 모든 내보내기 형식에서 렌더러에 의해 사용됩니다.

**맞춤 글꼴이 결과 PPTX에 자동으로 포함됩니까?**

아니요. 렌더링을 위해 글꼴을 등록하는 것은 PPTX에 포함하는 것과 동일하지 않습니다. 프레젠테이션 파일에 글꼴을 포함해야 하는 경우 명시적인 [embedding features](/slides/ko/net/embedded-font/)를 사용해야 합니다.

**맞춤 글꼴에 특정 글리프가 없을 때 대체 동작을 제어할 수 있나요?**

예. [font substitution](/slides/ko/net/font-substitution/), [replacement rules](/slides/ko/net/font-replacement/), 및 [fallback sets](/slides/ko/net/fallback-font/)을 구성하여 요청된 글리프가 없을 때 어떤 글꼴을 사용할지 정확히 정의할 수 있습니다.

**Linux/Docker 컨테이너에서 시스템 전체에 설치하지 않고 글꼴을 사용할 수 있나요?**

예. 자체 글꼴 폴더를 지정하거나 바이트 배열에서 글꼴을 로드하면 컨테이너 이미지의 시스템 글꼴 디렉터리에 대한 의존성을 없앨 수 있습니다.

> **Note for Linux/Docker**: `FontsLoader.LoadExternalFonts`를 호출할 때 `directories` 배열의 각 항목이 존재하는 디렉터리에 대한 비어 있지 않은 경로를 포함하고 있는지 확인하십시오. 글꼴 경로를 구성하는 데 사용된 환경 변수가 정의되지 않았거나 비어 있으면 Aspose.Slides가 빈 값을 전체 경로로 해석하려 시도하여 `System.ArgumentException`이 발생할 수 있습니다.

**라이선스는 어떻게 되나요—제한 없이 맞춤 글꼴을 포함할 수 있나요?**

글꼴 라이선스 준수는 사용자 책임입니다. 라이선스 조건은 다양하며, 일부는 포함이나 상업적 사용을 금지합니다. 출력을 배포하기 전에 항상 글꼴의 EULA를 검토하십시오.