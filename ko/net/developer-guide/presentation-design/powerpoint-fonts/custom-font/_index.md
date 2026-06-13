---
title: ".NET에서 PowerPoint 폰트 사용자 지정"
linktitle: "맞춤 폰트"
type: docs
weight: 20
url: /ko/net/custom-font/
keywords:
- "폰트"
- "맞춤 폰트"
- "외부 폰트"
- "폰트 로드"
- "폰트 관리"
- "폰트 폴더"
- "PowerPoint"
- "OpenDocument"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 슬라이드의 폰트를 사용자 지정하면 프레젠테이션을 어떤 장치에서도 선명하고 일관되게 유지할 수 있습니다."
---
## **개요**

Aspose.Slides를 사용하면 운영 체제에 폰트를 설치하지 않고도 프레젠테이션에서 사용자 정의 폰트를 사용할 수 있습니다. 사용자 정의 폴더에서 폰트를 로드하거나, 문서 수준 폰트 소스를 통해 특정 프레젠테이션에 폰트를 제공하거나, 바이너리 데이터에서 외부 폰트를 직접 로드할 수 있습니다.

로드된 폰트는 프레젠테이션이 렌더링되거나 PDF, 이미지 등 지원되는 형식으로 내보내질 때 사용됩니다. 이를 통해 다양한 환경에서 프레젠테이션 출력이 일관되게 유지됩니다. 이 문서에서는 Aspose.Slides에서 사용하는 폰트 폴더를 검사하는 방법과 외부 폰트를 사용한 후 폰트 캐시를 지우는 방법도 설명합니다.

렌더링을 위한 사용자 정의 폰트 등록은 PPTX 파일에 폰트를 임베드하는 것과 별개입니다. 폰트를 프레젠테이션 내부에 저장해야 하는 경우, 폰트 임베드 기능을 명시적으로 사용하십시오.

{{% alert color="primary" %}} 
Aspose Slides를 사용하면 다음 메서드인 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/loadexternalfonts/)를 통해 이러한 폰트를 로드할 수 있습니다:

* TrueType(.ttf) 및 TrueType Collection(.ttc) 폰트. 자세한 내용은 [TrueType](https://en.wikipedia.org/wiki/TrueType)을 참조하십시오.
* OpenType(.otf) 폰트. 자세한 내용은 [OpenType](https://en.wikipedia.org/wiki/OpenType)을 참조하십시오.
{{% /alert %}}

## **사용자 정의 폰트 로드**

Aspose.Slides를 사용하면 시스템에 폰트를 설치하지 않고도 프레젠테이션에서 사용되는 폰트를 로드할 수 있습니다. 이는 PDF, 이미지 등 지원되는 형식으로 내보낼 때 출력에 영향을 주어 결과 문서가 환경에 따라 일관되게 보이도록 합니다. 폰트는 사용자 정의 디렉터리에서 로드됩니다.

1. 폰트 파일이 들어 있는 하나 이상의 폴더를 지정합니다.
2. 해당 폴더에서 폰트를 로드하기 위해 정적 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/loadexternalfonts/) 메서드를 호출합니다.
3. 프레젠테이션을 로드하고 렌더링/내보냅니다.
4. 폰트 캐시를 지우기 위해 [FontsLoader.ClearCache](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/clearcache/)을 호출합니다.

다음 코드 예제는 폰트 로드 프로세스를 보여줍니다:

```cs
// 사용자 정의 폰트 파일이 들어 있는 폴더를 정의합니다.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// 지정된 폴더에서 사용자 정의 폰트를 로드합니다.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// 로드된 폰트를 사용하여 프레젠테이션을 렌더링/내보냅니다(예: PDF, 이미지 또는 기타 형식).
presentation.Save("output.pdf", SaveFormat.Pdf);

// 작업이 끝난 후 폰트 캐시를 지웁니다.
FontsLoader.ClearCache();
```

{{% alert color="info" title="참고" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/loadexternalfonts/)는 폰트 검색 경로에 추가 폴더를 추가하지만 폰트 초기화 순서는 변경하지 않습니다.
폰트는 다음 순서대로 초기화됩니다:

1. 기본 운영 체제 폰트 경로.
1. [FontsLoader](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/)를 통해 로드된 경로.
{{%/alert %}}

## **사용자 정의 폰트 폴더 가져오기**
Aspose.Slides는 폰트 폴더를 찾을 수 있도록 [GetFontFolders](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/getfontfolders/) 메서드를 제공합니다. 이 메서드는 `LoadExternalFonts` 메서드를 통해 추가된 폴더와 시스템 폰트 폴더를 반환합니다.

다음 C# 코드는 [GetFontFolders](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/getfontfolders/)를 사용하는 방법을 보여줍니다:

```c#
// 이 행은 폰트 파일이 확인되는 폴더들을 출력합니다.
// 이는 LoadExternalFonts 메서드를 통해 추가된 폴더와 시스템 폰트 폴더입니다.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **프레젠테이션에 사용되는 사용자 정의 폰트 지정**
Aspose.Slides는 프레젠테이션에 사용할 외부 폰트를 지정할 수 있도록 [DocumentLevelFontSources](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/documentlevelfontsources/) 속성을 제공합니다.

다음 C# 코드는 [DocumentLevelFontSources](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/documentlevelfontsources/) 속성을 사용하는 방법을 보여줍니다:

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // 프레젠테이션 작업
    // CustomFont1, CustomFont2 및 assets\fonts와 global\fonts 폴더 및 그 하위 폴더의 폰트가 프레젠테이션에서 사용 가능합니다
}
```

## **외부에서 폰트 관리**
Aspose.Slides는 바이너리 데이터에서 외부 폰트를 로드할 수 있도록 [LoadExternalFont](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) 메서드를 제공합니다.

다음 C# 코드는 바이트 배열을 이용한 폰트 로드 과정을 보여줍니다:

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // 프레젠테이션 수명 동안 로드된 외부 폰트
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **자주 묻는 질문**

**사용자 정의 폰트가 모든 형식(PDF, PNG, SVG, HTML)으로의 내보내기에 영향을 줍니까?**

예. 연결된 폰트는 렌더러에 의해 모든 내보내기 형식에서 사용됩니다.

**사용자 정의 폰트가 결과 PPTX에 자동으로 임베드됩니까?**

아니요. 렌더링을 위해 폰트를 등록하는 것은 PPTX에 임베드하는 것과 동일하지 않습니다. 프레젠테이션 파일에 폰트를 포함해야 한다면 명시적인 [임베드 기능](/slides/ko/net/embedded-font/)를 사용해야 합니다.

**사용자 정의 폰트에 특정 글리프가 없을 때 대체 동작을 제어할 수 있습니까?**

예. [font substitution](/slides/ko/net/font-substitution/), [replacement rules](/slides/ko/net/font-replacement/), 및 [fallback sets](/slides/ko/net/fallback-font/)를 구성하여 요청된 글리프가 없을 때 정확히 어떤 폰트를 사용할지 정의할 수 있습니다.

**Linux/Docker 컨테이너에서 시스템 전체에 설치하지 않고 폰트를 사용할 수 있습니까?**

예. 자체 폰트 폴더를 지정하거나 바이트 배열에서 폰트를 로드하면 됩니다. 이렇게 하면 컨테이너 이미지에서 시스템 폰트 디렉터리에 대한 종속성이 없어집니다.

**라이선스는 어떻게 되나요—제한 없이 모든 사용자 정의 폰트를 임베드할 수 있습니까?**

폰트 라이선스 준수는 사용자의 책임입니다. 라이선스 조건은 다양하며, 일부는 임베드나 상업적 사용을 금지합니다. 출력물을 배포하기 전에 항상 해당 폰트의 EULA를 확인하십시오.