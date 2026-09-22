---
title: .NET에서 원본 프레젠테이션 형식 결정
linktitle: 소스 형식
type: docs
weight: 35
url: /ko/net/detect-presentation-source-format/
keywords:
- 소스 형식
- 프레젠테이션 형식 감지
- PowerPoint
- OpenDocument
- 프레젠테이션
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "C#와 Aspose.Slides for .NET을 사용해 로드된 프레젠테이션의 원본 형식을 읽고, 감지 API를 비교하며, 파일, 스트림 및 레거시 형식을 처리합니다."
---
## **개요**

프레젠테이션을 로드한 후 읽기 전용 [Presentation.SourceFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/sourceformat/) 속성을 확인하여 원본 형식을 판단합니다. 이 속성은 [IPresentation.SourceFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/sourceformat/)을 통해서도 사용할 수 있습니다. 현재 인스턴스가 로드된 형식에 따라 이후 처리가 달라지는 경우에 사용하십시오.

소스 형식은 출력 파일에 선택된 [SaveFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveformat/)과는 구별됩니다. 다른 형식으로 저장한다고 해서 기존 인스턴스의 소스 형식이 바뀌지는 않습니다.

## **파일의 소스 형식 읽기**

이 예제는 기존의 `sample.pptx` 파일이 필요합니다. 파일을 로드하고 파일 이름이 아니라 [Presentation.SourceFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/sourceformat/)을 사용하여 애플리케이션 처리 정책을 선택합니다. 다른 형식을 시도하려면 입력 경로를 변경하십시오. 예제는 선택된 정책을 출력합니다; 메시지를 여러분의 애플리케이션 로직으로 교체하십시오.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **지원되는 값 인식**

[SourceFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/sourceformat/) 열거형은 다음 프레젠테이션 형식을 구분합니다. 아래 확장자는 원래 파일 이름을 재구성한 것이 아니라 관례적인 확장자입니다.

| SourceFormat 값 | 확장자 | 형식 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 프레젠테이션 |
| `Pptx` | `.pptx` | Office Open XML 프레젠테이션 |
| `Pptm` | `.pptm` | 매크로 사용 Office Open XML 프레젠테이션 |
| `Pps` | `.pps` | PowerPoint 97–2003 슬라이드 쇼 |
| `Ppsx` | `.ppsx` | Office Open XML 슬라이드 쇼 |
| `Ppsm` | `.ppsm` | 매크로 사용 Office Open XML 슬라이드 쇼 |
| `Pot` | `.pot` | PowerPoint 97–2003 템플릿 |
| `Potx` | `.potx` | Office Open XML 템플릿 |
| `Potm` | `.potm` | 매크로 사용 Office Open XML 템플릿 |
| `Odp` | `.odp` | OpenDocument 프레젠테이션 |
| `Otp` | `.otp` | OpenDocument 프레젠테이션 템플릿 |
| `Fodp` | `.fodp` | Flat XML ODF 프레젠테이션 |
| `Xml` | `.xml` | PowerPoint XML 프레젠테이션 |

## **스트림의 소스 형식 읽기**

이 예제는 기존의 `sample.pps` 파일이 필요합니다. 파일의 바이트를 메모리 스트림으로 읽어 파일 이름 없이 입력을 받는 경우(예: 데이터베이스 값이나 업로드된 바이트 배열)를 모델링합니다. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 생성자는 스트림만 받습니다.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT, PPS, 그리고 POT는 동일한 기본 이진 형식을 사용합니다. 파일 경로로 로드할 경우 확장자를 통해 슬라이드 쇼나 템플릿을 구분할 수 있습니다. 파일 이름이 없으면 레거시 PPS 및 POT 내용이 `SourceFormat.Ppt` 로 보고될 수 있으며, 위의 PPS 예제는 `Ppt` 를 반환합니다.

응용 프로그램에서 이러한 구분을 유지해야 한다면 원본 파일 이름이나 하위 유형 메타데이터를 별도로 보관하십시오. 확장자는 이러한 레거시 하위 유형에 유용한 힌트를 제공하지만, 임의의 프레젠테이션 콘텐츠를 식별하는 유일한 근거가 되어서는 안 됩니다.

## **로드 전후 감지 비교**

파일을 완전한 프레젠테이션 객체 모델로 로드하기 전에 검사해야 할 경우 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ko/net/aspose.slides/presentationfactory/getpresentationinfo/)와 [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationinfo/loadformat/)을 사용하십시오. 이미 인스턴스가 존재하는 경우 [Presentation.SourceFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/sourceformat/)을 사용하십시오.

이 예제는 `sample.pptx` 를 요구하며 두 검증 모두 `Pptx` 를 출력합니다. 실제 환경에서는 처리 단계에 맞는 API를 선택하십시오; 이미 로드된 프레젠테이션은 소스 형식을 얻기 위해 두 번째 검사를 할 필요가 없습니다.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

결과는 서로 다른 열거형 타입을 가집니다: [LoadFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/loadformat/) 과 [SourceFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/sourceformat/). 숫자 값을 캐스팅해서 비교하거나 모든 형식이 동일한 감지 결과를 가진다고 가정하지 마십시오. 아래에 설명된 저장‑재열기 검사에서는 PowerPoint XML이 로드 전에는 `LoadFormat.Unknown` 으로 보고되고, 로드 후에는 `SourceFormat.Xml` 로 보고됩니다.

## **소스와 출력 형식 분리 유지**

이 예제는 `sample.pptx` 를 요구하고 `converted.odp` 로 저장합니다. 원본 인스턴스를 저장 전후 모두 `Pptx` 를 출력합니다. ODP 출력에서 새로 로드된 인스턴스만 `Odp` 를 보고합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

`new Presentation()` 으로 처음부터 만든 프레젠테이션은 `SourceFormat.Pptx` 를 보고합니다. 입력 파일이 없기 때문에 이는 새로 만든 인스턴스의 기본값이며, PPTX 파일이 로드되었다는 증거가 아닙니다. 구분이 필요하다면 애플리케이션에서 인스턴스가 생성되었는지 로드되었는지를 별도로 추적하십시오.

## **소스 형식을 확장자로 매핑하기**

다음 예제는 `sample.pptx` 를 필요로 하며 현재 지원되는 모든 [SourceFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/sourceformat/) 값을 관례적인 확장자로 매핑합니다. 입력 파일 이름을 파싱하지 않으며, 인식되지 않은 값에 대해서는 조용히 확장자를 할당하지 않도록 기본값을 사용합니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

이 매핑은 파일을 변환하거나 스트림 로드 중에 손실된 레거시 PPS/POT 하위 유형을 복구하지 않습니다. 실제 저장 시에는 [SaveFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveformat/)을 명시적으로 선택하거나 [Save Presentations in Their Original Format](/slides/ko/net/save-presentation/#save-presentations-in-their-original-format) 에 표시된 변환 방법을 사용하십시오.

## **저장 후 재열기로 형식 검증**

이 자체 포함 예제는 프레젠테이션을 생성하고 작업 디렉터리에 세 파일을 작성하며 동일한 이름이 있는 파일은 덮어씁니다. 각 출력 파일을 경로와 메모리 스트림 두 방식을 모두 재열고 결과를 비교합니다. PPTX와 ODP는 두 경로 모두 저장된 형식을 보고하고, PPS는 경로 기반 로드에서는 `Pps` 를, 파일 이름 없이 바이트만 로드하면 `Ppt` 를 보고합니다.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

위에 열거된 모든 형식에 대해 동일한 검사를 수행한 결과는 다음과 같습니다.

| 저장 형식 | 파일 경로에서의 SourceFormat | 파일 이름 없는 스트림에서의 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | 각각 `Pptx`, `Pptm` | 파일 경로와 동일 |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | 각각 `Ppsx`, `Ppsm` | 파일 경로와 동일 |
| POT | `Pot` | `Ppt` |
| POTX, POTM | 각각 `Potx`, `Potm` | 파일 경로와 동일 |
| ODP, OTP | 각각 `Odp`, `Otp` | 파일 경로와 동일 |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

이 검사에서 이름 없는 스트림에 대해 PPS/POT가 `Ppt` 로 정규화된 것이 유일한 소스‑형식 변환입니다. 표는 형식 식별을 설명하며, 변환 중 모든 프레젠테이션 기능이 보존된다는 의미는 아닙니다.

## **FAQ**

**ODP 로 저장하면 PPTX에서 로드된 프레젠테이션의 소스 형식이 바뀝니까?**

아니요. 기존 인스턴스는 여전히 `Pptx` 를 보고합니다. 저장된 ODP 파일을 로드한 인스턴스는 `Odp` 를 보고합니다.

**스트림만으로 레거시 프레젠테이션, 슬라이드 쇼, 템플릿을 언제든 구분할 수 있나요?**

아니요. PPT, PPS, 그리고 POT는 동일한 이진 형식을 공유합니다. 구분이 필요하면 파일 이름이나 하위 유형 메타데이터를 별도로 보관하십시오.

**프레젠테이션이 이미 로드된 경우 어떤 API를 사용해야 하나요?**

[Presentation.SourceFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/sourceformat/) 을 읽으십시오. 로드 전 검사가 필요하면 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ko/net/aspose.slides/presentationfactory/getpresentationinfo/) 을 사용하십시오.