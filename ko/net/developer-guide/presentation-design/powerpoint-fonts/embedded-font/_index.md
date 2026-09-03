---
title: .NET에서 프레젠테이션에 폰트 임베드
linktitle: 임베드된 폰트
type: docs
weight: 40
url: /ko/net/embedded-font/
keywords:
- 폰트 추가
- 폰트 임베드
- 폰트 임베드
- 임베드된 폰트 가져오기
- 임베드된 폰트 추가
- 임베드된 폰트 제거
- 임베드된 폰트 압축
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint의 임베드된 폰트를 관리합니다. C#을 사용해 폰트를 추가, 검색, 제거 및 압축하여 텍스트 모양을 유지하고 파일 크기를 줄입니다."
---
## **소개**

임베드된 폰트는 글꼴 데이터를 PowerPoint 프레젠테이션 내부에 저장합니다. 뷰어가 임베드된 폰트를 지원하면 대상 시스템에 해당 폰트가 설치되지 않아도 해당 폰트를 사용하여 텍스트를 표시할 수 있습니다. 이는 줄 바꿈, 텍스트 간격 및 슬라이드 레이아웃을 보존하는 데 도움이 됩니다.

Aspose.Slides for .NET을 사용하면 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/)의 [FontsManager](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/fontsmanager/) 속성을 통해 임베드된 폰트를 검색, 추가 및 제거할 수 있습니다. 프레젠테이션에서 사용되지 않는 문자를 제거하여 임베드된 폰트 데이터의 크기를 줄일 수도 있습니다.

아래 예제는 PPTX 파일을 대상으로 합니다. 폰트를 임베드하기 전에 해당 폰트 데이터가 Aspose.Slides에서 사용 가능하고 라이선스가 임베드를 허용하는지 확인하세요.

## **임베드된 폰트 가져오기 및 제거**

[GetEmbeddedFonts](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/getembeddedfonts/)을 사용하면 프레젠테이션에 저장된 폰트를 나열할 수 있습니다. 폰트를 제거하려면 해당 목록에 있는 폰트를 [RemoveEmbeddedFont](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/removeembeddedfont/)에 전달한 뒤 프레젠테이션을 저장하세요.

다음 예제는 `EmbeddedFonts.pptx`에 포함된 폰트를 나열하고 Calibri가 있으면 제거합니다:
```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

임베드된 폰트를 제거하면 저장된 폰트 데이터가 삭제되지만 텍스트에 할당된 폰트는 변경되지 않습니다. 대상 시스템에 해당 폰트가 설치되어 있으면 텍스트는 계속 사용할 수 있습니다. 그렇지 않으면 렌더링 시 [font substitution](/slides/ko/net/font-substitution/)이 필요할 수 있으며, 이는 레이아웃에 영향을 줄 수 있습니다.

## **폰트 데이터 및 임베드 권한 검사**

[IFontsManager](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontsmanager/) 인터페이스를 사용하여 폰트를 임베드하기 전에 검사합니다. 프레젠테이션에서 사용된 폰트를 가져오려면 [IFontsManager.GetFonts](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontsmanager/getfonts/)를 호출합니다. 각 폰트마다 [IFontData](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontdata/) 객체와 필요한 [FontStyleType](https://reference.aspose.com/slides/ko/net/aspose.slides/fontstyletype/) 값을 [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontsmanager/getfontbytes/)에 전달합니다. 이 메서드는 해당 폰트 스타일의 이진 데이터를 반환하며, 요청한 폰트나 스타일이 없을 경우 `null`을 반환합니다. `null` 결과를 [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontsmanager/getfontembeddinglevel/)에 전달하지 마세요. 해당 메서드는 바이트 배열을 필요로 합니다.

[EmbeddingLevel](https://reference.aspose.com/slides/ko/net/aspose.slides/embeddinglevel/)은 폰트에 저장된 임베드 제한을 보고하는 플래그 열거형입니다:
- `Installable`은 폰트 라이선스에 따라 다른 시스템에 임베드 및 영구 설치를 허용합니다.
- `Restricted`는 사용 권한 플래그가 하나뿐인 경우 폰트 소유자의 허가 없이는 임베드를 금지합니다.
- `PreviewPrint`는 보기 및 인쇄를 위해 일시적으로 사용을 허용합니다. 해당 폰트를 포함한 문서는 읽기 전용이어야 합니다.
- `Editable`은 일시적인 사용을 허용하며 문서를 편집하고 저장할 수 있게 합니다.
- `NoSubsetting`은 추가 제한으로, 글리프의 일부만 임베드하는 것을 금지합니다. 이 플래그가 있으면 모든 문자를 임베드해야 합니다.
- `BitmapOnly`는 추가 제한으로, 비트맵 스트라이크만 임베드할 수 있고 아웃라인 데이터는 임베드할 수 없습니다. 폰트에 비트맵 스트라이크가 없으면 임베드할 수 없습니다.

첫 번째 네 값은 사용 권한을 나타내며, `NoSubsetting` 및 `BitmapOnly`는 이들과 결합될 수 있습니다. 비트 연산을 사용해 수정자를 확인하십시오. `Installable`은 값이 0이므로 `HasFlag`를 사용해 감지하지 말고, 사용 권한 비트를 마스크한 뒤 결과를 `Installable`과 비교하세요. 현재 폰트는 최대 하나의 사용 권한 비트만 설정해야 합니다. 하나 이상 설정된 오래된 폰트와의 호환성을 위해 아래 도우미는 가장 제한이 낮은 권한을 선택합니다: `Editable`, 다음 `PreviewPrint`, 그리고 `Restricted`.

다음 예제는 `GetFonts`가 반환한 각 폰트에 대해 일반, 굵게, 기울임꼴, 굵게-기울임꼴 데이터를 검사합니다. 사용 불가능한 스타일, 제한된 폰트, 비트맵 전용 폰트, 미리보기 및 인쇄에만 제한된 폰트(출력이 편집 가능하게 유지되므로) 및 이미 임베드된 폰트를 건너뜁니다. 사용 가능한 스타일 중 `NoSubsetting`이 있으면 해당 폰트 패밀리의 모든 문자를 임베드합니다.
```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

이 검사는 각 폰트 파일에 인코딩된 제한 사항을 보고합니다. 이는 라이선스를 부여하거나, 폰트를 합법적으로 확보했음을 증명하거나, 임베드된 복사본을 배포하기 전에 폰트 라이선스 계약을 확인하는 절차를 대체하지 않습니다.

## **임베드된 폰트 추가**

[AddEmbeddedFont](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/addembeddedfont/)을 사용하여 폰트를 임베드합니다. 이 메서드의 오버로드는 [IFontData](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontdata/) 객체 또는 폰트 데이터를 포함하는 바이트 배열을 받습니다. [EmbedFontCharacters](https://reference.aspose.com/slides/ko/net/aspose.slides.export/embedfontcharacters/) 열거형은 포함할 문자를 제어합니다:
- [All](https://reference.aspose.com/slides/ko/net/aspose.slides.export/embedfontcharacters/)은 폰트의 모든 문자를 임베드합니다. 받는 사람이 프레젠테이션을 편집하고 새 텍스트를 입력해야 할 경우 이 옵션을 사용하세요.
- [OnlyUsed](https://reference.aspose.com/slides/ko/net/aspose.slides.export/embedfontcharacters/)은 프레젠테이션에서 사용된 문자만 임베드하여 파일 크기를 줄입니다. 주로 보기용으로 완성된 프레젠테이션에 이 옵션을 선택하세요.

다음 예제는 `Fonts.pptx`에서 사용된 폰트를 가져오기 위해 [GetFonts](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/getfonts/)를 사용하고, 아직 임베드되지 않은 폰트를 임베드합니다. 추가할 폰트는 코드를 실행하는 머신에 있어야 합니다. 기존에 임베드된 폰트는 현재 문자 세트를 유지합니다.
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **임베드된 폰트 압축**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/compressembeddedfonts/)은 사용되지 않은 문자를 제거하여 임베드된 폰트 데이터를 줄입니다. 이미 임베드된 폰트에 적용되므로, 크기 감소는 프레젠테이션에 포함된 사용되지 않은 폰트 데이터 양에 따라 달라집니다.

다음 예제는 `EmbeddedFonts.pptx`의 폰트를 압축하고 결과를 별도 파일로 저장합니다:
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

수신자가 나중에 텍스트를 추가해야 할 가능성이 있다면 원본 파일을 보관하세요. 압축 중에 제거된 문자는 원래 모든 문자를 임베드했더라도 이제 임베드된 폰트에서 사용할 수 없습니다.

## **자주 묻는 질문**

**임베드된 폰트가 렌더링 중에 여전히 대체되는지 어떻게 확인할 수 있나요?**

[GetSubstitutions](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/getsubstitutions/)을 사용하여 프레젠테이션을 렌더링하는 환경에서 Aspose.Slides가 교체할 폰트를 확인하세요. 또한 [font substitution](/slides/ko/net/font-substitution/) 설정과 [font fallback](/slides/ko/net/fallback-font/) 규칙을 확인하십시오. 폰트 폴백은 누락된 문자를 처리하므로, 폰트를 임베드해도 해당 폰트에 포함되지 않은 문자는 해결되지 않습니다.

**Arial 및 Calibri와 같은 일반 폰트를 임베드해야 할까요?**

결정은 대상 환경에 따라 달라집니다. 프레젠테이션을 열거나 렌더링하는 모든 장치에 필요한 폰트가 이미 설치되어 있다면 임베드가 불필요하게 파일 크기를 증가시킬 수 있습니다. 수신자나 서버에 해당 폰트가 없을 경우, 라이선스가 허용한다면 임베드하여 의도한 모습을 유지할 수 있습니다.