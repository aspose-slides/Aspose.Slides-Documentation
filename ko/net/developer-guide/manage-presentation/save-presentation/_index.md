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
- 파일로 프레젠테이션
- 스트림으로 프레젠테이션
- 미리 정의된 보기 유형
- Strict Office Open XML 형식
- Zip64 모드
- 썸네일 새로 고침
- 저장 진행 상황
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides를 사용하여 .NET에서 프레젠테이션을 저장하는 방법을 알아보세요—레이아웃, 글꼴 및 효과를 유지하면서 PowerPoint 또는 OpenDocument로 내보낼 수 있습니다."
---
## **개요**

[Open Presentations in C#](/slides/ko/net/open-presentation/) 에서는 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스를 사용하여 프레젠테이션을 여는 방법을 설명했습니다. 이 문서는 프레젠테이션을 만들고 저장하는 방법을 설명합니다. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스는 프레젠테이션의 내용을 포함합니다. 처음부터 프레젠테이션을 만들든 기존 프레젠테이션을 수정하든 작업이 끝나면 저장해야 합니다. Aspose.Slides for .NET을 사용하면 **파일**이나 **스트림**에 저장할 수 있습니다. 이 문서는 프레젠테이션을 저장하는 다양한 방법을 설명합니다.

## **프레젠테이션을 파일에 저장**

[Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 `Save` 메서드를 호출하여 프레젠테이션을 파일에 저장합니다. 메서드에 파일 이름과 저장 형식을 전달합니다. 아래 예제는 Aspose.Slides를 사용하여 프레젠테이션을 저장하는 방법을 보여줍니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation())
{
    // 여기서 작업을 수행합니다...

    // 프레젠테이션을 파일에 저장합니다.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **프레젠테이션을 스트림에 저장**

[Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 `Save` 메서드에 출력 스트림을 전달하여 프레젠테이션을 스트림에 저장할 수 있습니다. 프레젠테이션은 다양한 스트림 유형에 기록될 수 있습니다. 아래 예제에서는 새 프레젠테이션을 만들고 파일 스트림에 저장합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // 프레젠테이션을 스트림에 저장합니다.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **미리 정의된 보기 유형으로 프레젠테이션 저장**

Aspose.Slides에서는 [ViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties/) 클래스를 통해 생성된 프레젠테이션이 열릴 때 PowerPoint가 사용할 초기 보기를 설정할 수 있습니다. [ViewType](https://reference.aspose.com/slides/ko/net/aspose.slides/viewtype/) 열거형의 값으로 [LastView](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties/lastview/) 속성을 설정합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Strict Office Open XML 형식으로 프레젠테이션 저장**

Aspose.Slides를 사용하면 Strict Office Open XML 형식으로 프레젠테이션을 저장할 수 있습니다. 저장 시 [PptxOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pptxoptions/) 클래스의 `Conformance` 속성을 설정합니다. `Conformance.Iso29500_2008_Strict`를 지정하면 출력 파일이 Strict Office Open XML 형식으로 저장됩니다.

아래 예제는 프레젠테이션을 생성하고 Strict Office Open XML 형식으로 저장합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation())
{
    // 프레젠테이션을 Strict Office Open XML 형식으로 저장합니다.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **ZIP64 모드로 Office Open XML 형식 저장**

Office Open XML 파일은 ZIP 아카이브이며, 압축되지 않은 파일 크기, 압축된 파일 크기 및 전체 아카이브 크기에 4 GB(2^32 바이트) 제한과 파일 수 65 535(2^16‑1) 제한을 둡니다. ZIP64 형식 확장은 이러한 제한을 2^64까지 높입니다.

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ipptxoptions/zip64mode/) 속성을 사용하면 Office Open XML 파일을 저장할 때 ZIP64 형식 확장을 언제 사용할지 선택할 수 있습니다.

이 속성은 다음 모드를 제공합니다.

- `IfNecessary` : 프레젠테이션이 위 제한을 초과하는 경우에만 ZIP64 형식 확장을 사용합니다. 기본 모드입니다.
- `Never` : ZIP64 형식 확장을 사용하지 않습니다.
- `Always` : 항상 ZIP64 형식 확장을 사용합니다.

다음 코드는 ZIP64 형식 확장을 활성화하여 PPTX 파일로 프레젠테이션을 저장하는 방법을 보여줍니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.Never`로 저장하면 프레젠테이션을 ZIP32 형식으로 저장할 수 없을 때 [PptxException](https://reference.aspose.com/slides/ko/net/aspose.slides/pptxexception/)이 발생합니다.
{{% /alert %}}

## **압축 수준을 지정하여 Office Open XML 형식 저장**

대용량 프레젠테이션을 다룰 때 파일 크기와 처리 시간을 균형 있게 조정하기 위해 압축 수준을 설정할 수 있습니다. 요구 사항에 따라 더 빠른 처리 또는 더 작은 파일을 선택할 수 있습니다.

Aspose.Slides는 Office Open XML 형식으로 저장할 때 사용되는 압축 수준을 지정하는 [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ipptxoptions/compressionlevel/) 속성을 제공합니다.

사용 가능한 압축 수준은 다음과 같습니다.

- **None** : 압축을 적용하지 않습니다. 파일이 그대로 저장됩니다.
- **Level1** : 가장 빠른 압축이며 압축 비율이 가장 낮습니다.
- **Level2** : **Level1**보다 약간 높은 압축 비율을 제공합니다.
- **Level3** : **Level2**보다 좋은 압축을 제공하지만 처리 시간이 약간 더 늘어납니다.
- **Level4** : **Level3**보다 좋은 압축을 제공합니다.
- **Level5** : **Level4**보다 향상된 압축을 제공하며 추가 처리 시간이 필요합니다.
- **Level6** : 표준 압축으로 처리 속도와 파일 크기 사이에 좋은 균형을 제공합니다. *기본 압축 수준*입니다.
- **Level7** : **Level6**보다 더 좋은 압축을 제공하지만 처리 속도가 느려집니다.
- **Level8** : **Level7**보다 더 좋은 압축을 제공합니다.
- **Level9** : 최대 압축으로 가장 작은 파일을 생성하지만 가장 오래 걸립니다.

아래 예제는 압축 없이 PPTX 파일로 프레젠테이션을 저장하는 방법을 보여줍니다.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

이 예제는 최대 압축으로 PPTX 파일을 저장하는 방법을 보여줍니다.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **썸네일을 새로 고치지 않고 프레젠테이션 저장**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) 속성은 PPTX로 저장할 때 썸네일 생성을 제어합니다.

- `true`로 설정하면 저장 중에 썸네일이 새로 고쳐집니다. 기본값입니다.
- `false`로 설정하면 현재 썸네일이 유지됩니다. 프레젠테이션에 썸네일이 없으면 새로 생성되지 않습니다.

아래 코드에서는 썸네일을 새로 고치지 않고 PPTX로 프레젠테이션을 저장합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
이 옵션을 사용하면 PPTX 형식으로 저장하는 데 걸리는 시간을 줄일 수 있습니다.
{{% /alert %}}

## **저장 진행 상황을 백분율로 업데이트**

[IProgressCallback](https://reference.aspose.com/slides/ko/net/aspose.slides/iprogresscallback/) 인터페이스는 [ISaveOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/isaveoptions/) 인터페이스가 노출하는 `ProgressCallback` 속성과 추상 클래스 [SaveOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveoptions/)를 통해 사용됩니다. `ProgressCallback`에 [IProgressCallback](https://reference.aspose.com/slides/ko/net/aspose.slides/iprogresscallback/) 구현을 할당하면 저장 진행 상황을 백분율로 받을 수 있습니다.

다음 코드 스니펫은 `IProgressCallback`을 사용하는 방법을 보여줍니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // 여기서 진행률 백분율 값을 사용합니다.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose는 자체 API를 사용해 만든 [무료 PowerPoint Splitter 앱](https://products.aspose.app/slides/ko/splitter)을 제공하고 있습니다. 이 앱을 사용하면 선택한 슬라이드를 새 PPTX 또는 PPT 파일로 저장해 프레젠테이션을 여러 파일로 분할할 수 있습니다.
{{% /alert %}}

## **FAQ**

**"빠른 저장"(증분 저장)이 지원되어 변경된 부분만 기록되나요?**

지원되지 않습니다. 저장 시마다 전체 대상 파일이 새로 생성되며, 증분 "빠른 저장"은 지원되지 않습니다.

**여러 스레드에서 동일한 Presentation 인스턴스를 저장하는 것이 스레드 안전한가요?**

아니요. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스는 [/slides/ko/net/multithreading/](/slides/ko/net/multithreading/)에서 설명하듯 스레드 안전하지 않으므로 단일 스레드에서 저장해야 합니다.

**저장할 때 하이퍼링크와 외부 연결 파일은 어떻게 처리되나요?**

[Hyperlinks](/slides/ko/net/manage-hyperlinks/)는 그대로 유지됩니다. 외부 연결 파일(예: 상대 경로를 사용한 비디오)은 자동으로 복사되지 않으므로, 참조된 경로가 계속 접근 가능하도록 해야 합니다.

**문서 메타데이터(작성자, 제목, 회사, 날짜)를 설정/저장할 수 있나요?**

가능합니다. 표준 [document properties](/slides/ko/net/presentation-properties/)가 지원되며 저장 시 파일에 기록됩니다.