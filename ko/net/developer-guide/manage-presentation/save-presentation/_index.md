---
title: .NET에서 프레젠테이션 저장
linktitle: 프레젠테이션 저장
type: docs
weight: 80
url: /ko/net/save-presentation/
keywords:
- PowerPoint 저장
- OpenDocument 저장
- 프레젠테이션 저장
- 슬라이드 저장
- PPT 저장
- PPTX 저장
- ODP 저장
- 파일에 프레젠테이션
- 스트림에 프레젠테이션
- 미리 정의된 보기 유형
- Strict Office Open XML 형식
- Zip64 모드
- 썸네일 새로 고침
- 저장 진행
- .NET
- C#
- Aspose.Slides
description: "C#와 Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 파일이나 스트림에 저장하고, PPTX 출력 및 진행 보고를 구성합니다."
---
## **개요**

프레젠테이션을 만들거나 [기존 프레젠테이션 열기](/slides/ko/net/open-presentation/) 후에, 결과를 기록하려면 [Presentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) 메서드를 사용합니다. Aspose.Slides for .NET은 PowerPoint, OpenDocument, PDF 및 기타 형식으로 프레젠테이션을 파일이나 스트림에 저장할 수 있습니다. 다음 섹션에서는 표준 저장 작업과 PPTX 출력에 사용할 수 있는 옵션을 다룹니다.

## **프레젠테이션을 파일에 저장**

프레젠테이션을 파일에 저장하려면 출력 경로와 [SaveFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveformat/) 값을 [Presentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) 메서드에 전달합니다. 형식 값은 Aspose.Slides가 생성하는 파일 유형을 결정합니다.

다음 예제는 프레젠테이션을 생성하고 PPTX 파일로 저장합니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **원본 형식으로 프레젠테이션 저장**

파일 및 스트림 감지 예제, 새로 생성된 프레젠테이션의 동작, 그리고 원본 형식과 출력 형식의 구분에 대해서는 [Determine the Original Presentation Format](/slides/ko/net/detect-presentation-source-format/)을 참조하십시오.

배치 처리 애플리케이션에서는 입력 형식을 사전에 알 수 없을 수 있습니다. 파일을 로드한 후에는 [IPresentation.SourceFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/sourceformat/) 속성에서 원본 형식을 읽습니다. 얻은 [SourceFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/sourceformat/) 값을 [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/tosaveformat/)에 전달하여 해당 [SaveFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveformat/) 값을 얻은 다음, [Presentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/)을 사용해 수정된 프레젠테이션을 기록합니다.

다음 전체 예제는 입력 디렉터리의 모든 파일을 처리하고, 제목을 업데이트한 뒤, 로드된 형식 그대로 출력 디렉터리에 저장합니다:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/tosaveformat/)은 PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP 및 PowerPoint XML을 해당 프레젠테이션 저장 형식에 매핑합니다. 이는 프레젠테이션 원본 형식만 매핑하며, PDF, HTML, TIFF 또는 이미지와 같은 내보내기 형식을 선택하기 위한 것이 아닙니다. 지원되지 않거나 잘못된 [SourceFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/sourceformat/) 값을 전달하면 [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception)이 발생합니다.

레거시 PPT, PPS 및 POT 파일은 동일한 바이너리 컨테이너를 사용합니다. 파일 확장자가 없는 스트림에서 이러한 프레젠테이션을 로드하면 PPS 또는 POT 파일이 PPT로 식별될 수 있습니다. 이러한 레거시 하위 유형을 보존해야 하는 경우, 원본 파일명이나 형식 메타데이터를 별도로 유지하고 출력 파일명 및 형식을 선택할 때 이를 사용하십시오.

## **프레젠테이션을 스트림에 저장**

최종 파일 경로에 의존하지 않고 프레젠테이션을 기록하려면 쓰기 가능한 [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream)과 [SaveFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveformat/) 값을 [Presentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) 메서드에 전달합니다. 이 방법은 출력 결과를 웹 서비스에서 반환하거나 데이터베이스에 저장하거나 메모리에서 처리해야 할 때 유용합니다.

다음 예제는 새 프레젠테이션을 파일 스트림에 저장합니다:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **미리 정의된 보기 유형으로 프레젠테이션 저장**

저장된 프레젠테이션을 PowerPoint가 처음 열 때 표시될 보기를 지정할 수 있습니다. 저장하기 전에 [ViewProperties.LastView](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties/lastview/) 속성을 [ViewType](https://reference.aspose.com/slides/ko/net/aspose.slides/viewtype/) 값으로 설정합니다.

다음 예제는 초기 보기로 슬라이드 마스터 보기를 설정합니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Strict Office Open XML 형식으로 프레젠테이션 저장**

Office Open XML의 Strict 프로필에 맞는 PPTX 파일을 만들려면 [PptxOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pptxoptions/) 인스턴스를 생성하고 해당 [Conformance](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pptxoptions/conformance/) 속성을 `Conformance.Iso29500_2008_Strict`로 설정합니다. 그런 다음 옵션을 [Presentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) 메서드에 전달합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Zip64 모드로 Office Open XML 형식 저장**

표준 ZIP 아카이브는 각 항목의 압축 및 비압축 크기, 전체 아카이브 크기 및 항목 수를 제한합니다. PPTX 파일은 ZIP 아카이브이므로 매우 큰 프레젠테이션은 이러한 제한을 초과할 수 있습니다. ZIP64 확장은 해당 크기 및 항목 수 제한을 늘립니다.

[PptxOptions.Zip64Mode](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pptxoptions/zip64mode/) 속성을 사용하여 Aspose.Slides가 ZIP64 확장을 쓸지 여부를 제어합니다.

- `IfNecessary`는 프레젠테이션이 표준 ZIP 제한을 초과할 때만 ZIP64를 사용합니다. 기본 모드입니다.
- `Never`는 ZIP64 확장을 사용하지 않습니다.
- `Always`는 항상 ZIP64 확장을 씁니다.

다음 예제는 출력 프레젠테이션에 대해 항상 ZIP64 확장을 사용하도록 설정합니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
`Zip64Mode`가 `Never`로 설정되고 프레젠테이션이 표준 ZIP 제한에 맞지 않으면, 저장 작업 중에 [PptxException](https://reference.aspose.com/slides/ko/net/aspose.slides/pptxexception/)이 발생합니다.
{{% /alert %}}

## **압축 레벨을 지정하여 Office Open XML 형식으로 프레젠테이션 저장**

PPTX 출력 시 [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pptxoptions/compressionlevel/) 속성을 설정하여 저장 속도와 파일 크기 사이의 균형을 맞출 수 있습니다. [CompressionLevel](https://reference.aspose.com/slides/ko/net/aspose.slides.export/compressionlevel/) 열거형은 다음 값을 제공합니다:

- `None`은 압축 없이 데이터를 저장합니다.
- `Level1`은 가장 빠른 압축과 가장 큰 압축된 출력을 제공합니다.
- `Level2`부터 `Level5`까지는 저장 속도보다 작은 출력을 점점 더 우선시합니다.
- `Level6`은 저장 속도와 파일 크기의 균형을 맞춥니다. 기본 레벨입니다.
- `Level7` 및 `Level8`은 저장 속도보다 작은 출력을 더 우선시합니다.
- `Level9`는 가장 강력한 압축을 제공하지만 가장 많은 처리가 필요합니다.

다음 예제는 압축 없이 프레젠테이션을 저장합니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

다음 예제는 최대 압축 레벨을 사용합니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **썸네일을 새로 고치지 않고 프레젠테이션 저장**

PPTX로 프레젠테이션을 저장할 때 [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pptxoptions/refreshthumbnail/) 속성이 문서 썸네일을 제어합니다:

- `true`는 저장 중에 썸네일을 다시 생성합니다. 기본값입니다.
- `false`는 기존 썸네일을 유지합니다. 프레젠테이션에 썸네일이 없으면 Aspose.Slides는 새로 만들지 않습니다.

다음 예제는 썸네일을 새로 고치지 않고 프레젠테이션을 저장합니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
썸네일 새로 고침을 비활성화하면 PPTX 파일 저장에 소요되는 시간을 줄일 수 있습니다.
{{% /alert %}}

## **백분율로 저장 진행 상황 업데이트**

저장 작업을 모니터링하려면 [IProgressCallback](https://reference.aspose.com/slides/ko/net/aspose.slides/iprogresscallback/) 인터페이스를 구현하고 해당 구현을 [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/ko/net/aspose.slides.export/isaveoptions/progresscallback/) 속성에 할당합니다. 그러면 Aspose.Slides는 내보내기 중에 진행 값을 전달하며 [IProgressCallback.Reporting](https://reference.aspose.com/slides/ko/net/aspose.slides/iprogresscallback/reporting/) 메서드를 호출합니다.

다음 예제는 PDF 내보내기의 진행 상황을 콘솔에 보고합니다:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Aspose는 Aspose.Slides API로 구축된 무료 [PowerPoint Splitter](https://products.aspose.app/slides/ko/splitter)를 제공합니다. 이 도구는 프레젠테이션에서 선택한 슬라이드를 별도의 PPT 또는 PPTX 파일로 저장합니다.
{{% /alert %}}

## **FAQ**

**Aspose.Slides가 증분 저장 또는 “빠른 저장”을 지원합니까?**

아니오. 각 저장 작업은 변경된 부분만 업데이트하는 것이 아니라 전체 출력 파일을 완전히 작성합니다.

**여러 스레드가 동일한 Presentation 인스턴스를 저장할 수 있나요?**

아니오. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스는 [스레드에 안전하지 않습니다](/slides/ko/net/multithreading/). 각 인스턴스는 한 번에 하나의 스레드만 접근하고 저장해야 합니다.

**프레젠테이션을 저장할 때 하이퍼링크와 외부 연결 파일은 어떻게 됩니까?**

[Hyperlinks](/slides/ko/net/manage-hyperlinks/)는 프레젠테이션에 그대로 남습니다. Aspose.Slides는 외부 연결 파일을 복사하지 않으므로, 저장된 프레젠테이션은 여전히 해당 위치에 접근할 수 있어야 합니다.

**작성자, 제목, 회사, 생성일자와 같은 문서 메타데이터를 저장할 수 있나요?**

예. 저장하기 전에 적절한 [문서 속성](/slides/ko/net/presentation-properties/)을 설정하면 Aspose.Slides가 이를 출력 파일에 기록합니다.