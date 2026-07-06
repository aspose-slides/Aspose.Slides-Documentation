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
- 프레젠테이션을 파일로
- 프레젠테이션을 스트림으로
- 미리 정의된 보기 유형
- Strict Office Open XML 형식
- Zip64 모드
- 썸네일 새로 고침
- 저장 진행률
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides를 사용하여 .NET에서 프레젠테이션을 저장하는 방법을 알아보세요—레이아웃, 글꼴 및 효과를 유지하면서 PowerPoint 또는 OpenDocument 형식으로 내보낼 수 있습니다."
---
## **Overview**

[C#에서 프레젠테이션 열기](/slides/ko/net/open-presentation/)에서는 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스를 사용하여 프레젠테이션을 여는 방법을 설명했습니다. 이 문서에서는 프레젠테이션을 만들고 저장하는 방법을 안내합니다. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스는 프레젠테이션의 내용을 포함합니다. 처음부터 프레젠테이션을 만들든 기존 프레젠테이션을 수정하든 작업이 끝나면 저장해야 합니다. Aspose.Slides for .NET을 사용하면 **파일**이나 **스트림**에 저장할 수 있습니다. 이 문서에서는 프레젠테이션을 저장하는 다양한 방법을 설명합니다.

## **Save Presentations to Files**

[Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 `Save` 메서드를 호출하여 파일에 프레젠테이션을 저장합니다. 파일 이름과 저장 형식을 메서드에 전달하면 됩니다. 다음 예제는 Aspose.Slides를 사용하여 프레젠테이션을 저장하는 방법을 보여줍니다.

```cs
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation())
{
    // 여기에서 작업을 수행합니다...

    // 프레젠테이션을 파일에 저장합니다.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Save Presentations to Streams**

[Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 `Save` 메서드에 출력 스트림을 전달하면 프레젠테이션을 스트림에 저장할 수 있습니다. 프레젠테이션은 다양한 스트림 유형에 기록될 수 있습니다. 아래 예제에서는 새 프레젠테이션을 생성하고 파일 스트림에 저장합니다.

```cs
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

## **Save Presentations with a Predefined View Type**

Aspose.Slides는 [ViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties/) 클래스를 통해 생성된 프레젠테이션이 열릴 때 PowerPoint가 사용할 초기 보기를 설정할 수 있게 합니다. [ViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties/)의 `LastView` 속성을 [ViewType](https://reference.aspose.com/slides/ko/net/aspose.slides/viewtype/) 열거형의 값으로 설정합니다.

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Save Presentations in the Strict Office Open XML Format**

Aspose.Slides를 사용하면 프레젠테이션을 Strict Office Open XML 형식으로 저장할 수 있습니다. 저장 시 [PptxOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pptxoptions/) 클래스를 사용하고 그 `Conformance` 속성을 설정합니다. `Conformance.Iso29500_2008_Strict`를 지정하면 출력 파일이 Strict Office Open XML 형식으로 저장됩니다.

다음 예제는 프레젠테이션을 만들고 Strict Office Open XML 형식으로 저장하는 방법을 보여줍니다.

```cs
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

## **Save Presentations in Office Open XML Format in Zip64 Mode**

Office Open XML 파일은 ZIP 아카이브이며, 압축되지 않은 파일 크기·압축된 파일 크기·전체 아카이브 크기에 각각 4 GB(2^32 바이트) 제한이 있습니다. 또한 파일 수는 65 535(2^16‑1)개로 제한됩니다. ZIP64 형식 확장은 이러한 제한을 2^64까지 늘립니다.

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ipptxoptions/zip64mode/) 속성을 사용하면 Office Open XML 파일을 저장할 때 ZIP64 형식 확장을 언제 적용할지 선택할 수 있습니다.

이 속성은 다음 모드를 제공합니다.

- `IfNecessary` : 프레젠테이션이 위 제한을 초과할 경우에만 ZIP64 확장을 사용합니다. 기본값입니다.
- `Never` : 절대 ZIP64 확장을 사용하지 않습니다.
- `Always` : 항상 ZIP64 확장을 사용합니다.

다음 코드는 ZIP64 형식 확장이 활성화된 상태로 PPTX 파일을 저장하는 예시입니다.

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.Never`로 저장하면 프레젠테이션을 ZIP32 형식으로 저장할 수 없는 경우 [PptxException](https://reference.aspose.com/slides/ko/net/aspose.slides/pptxexception/)이 발생합니다.
{{% /alert %}}

## **Save Presentations in Office Open XML Format with Compression Levels**

대용량 프레젠테이션을 다룰 때는 압축 수준을 조정하여 파일 크기와 처리 시간을 균형 있게 맞출 수 있습니다. 요구 사항에 따라 빠른 처리 또는 작은 파일 크기를 선택하세요.

Aspose.Slides는 Office Open XML 형식으로 저장할 때 사용할 압축 수준을 지정할 수 있는 [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ipptxoptions/compressionlevel/) 속성을 제공합니다.

사용 가능한 압축 수준은 다음과 같습니다.

- **None** : 압축을 적용하지 않습니다. 파일이 그대로 저장됩니다.
- **Level1** : 가장 빠른 압축, 압축 비율이 가장 낮습니다.
- **Level2** : **Level1**보다 약간 높은 압축 비율을 제공하면서도 빠릅니다.
- **Level3** : **Level2**보다 더 나은 압축을 제공하지만 처리 시간이 중간 정도 늘어납니다.
- **Level4** : **Level3**보다 더 나은 압축을 제공합니다.
- **Level5** : **Level4**보다 향상된 압축을 제공하지만 추가 처리 시간이 필요합니다.
- **Level6** : 표준 압축으로 처리 속도와 파일 크기 사이에 좋은 균형을 잡습니다. *기본 압축 수준*입니다.
- **Level7** : **Level6**보다 더 나은 압축을 제공하지만 처리 속도가 느려집니다.
- **Level8** : **Level7**보다 더 나은 압축을 제공합니다.
- **Level9** : 최대 압축. 가장 작은 파일 크기를 얻지만 처리 시간이 가장 오래 걸립니다.

다음 예제는 압축 없이 PPTX 파일을 저장하는 방법을 보여줍니다.

```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

다음 예제는 최대 압축으로 PPTX 파일을 저장하는 방법을 보여줍니다.

```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Save Presentations without Refreshing the Thumbnail**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) 속성은 프레젠테이션을 PPTX로 저장할 때 썸네일 생성 여부를 제어합니다.

- `true`(기본값)로 설정하면 저장 중에 썸네일이 새로 고쳐집니다.
- `false`로 설정하면 현재 썸네일이 유지됩니다. 프레젠테이션에 썸네일이 없으면 새로 생성되지 않습니다.

아래 코드에서는 썸네일을 새로 고치지 않고 PPTX로 저장합니다.

```cs
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

## **Save Progress Updates in Percentage**

[IProgressCallback](https://reference.aspose.com/slides/ko/net/aspose.slides/iprogresscallback/) 인터페이스는 [ISaveOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/isaveoptions/) 인터페이스의 `ProgressCallback` 속성 및 추상 [SaveOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveoptions/) 클래스를 통해 사용됩니다. `ProgressCallback`에 [IProgressCallback](https://reference.aspose.com/slides/ko/net/aspose.slides/iprogresscallback/) 구현체를 할당하면 저장 진행률을 백분율로 받을 수 있습니다.

다음 코드 조각은 `IProgressCallback`을 사용하는 방법을 보여줍니다.

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // 여기에서 진행률 백분율 값을 사용합니다.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose는 자체 API를 사용해 만든 [무료 PowerPoint Splitter 앱](https://products.aspose.app/slides/ko/splitter)을 제공합니다. 이 앱을 사용하면 선택한 슬라이드를 새 PPTX 또는 PPT 파일로 저장하여 프레젠테이션을 여러 파일로 분할할 수 있습니다.
{{% /alert %}}

## **FAQ**

**"빠른 저장"(증분 저장)이 지원되어 변경된 부분만 기록되나요?**

아니요. 저장 시마다 전체 대상 파일을 새로 만들며, 증분 "빠른 저장"은 지원되지 않습니다.

**여러 스레드에서 동일한 Presentation 인스턴스를 저장해도 안전한가요?**

아니요. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스는 [스레드 안전하지 않음](/slides/ko/net/multithreading/)으로, 하나의 스레드에서만 저장해야 합니다.

**저장할 때 하이퍼링크와 외부 연결 파일은 어떻게 처리되나요?**

[Hyperlinks](/slides/ko/net/manage-hyperlinks/)는 그대로 유지됩니다. 외부 연결 파일(예: 상대 경로 비디오)은 자동으로 복사되지 않으므로, 해당 경로가 계속 접근 가능하도록 해야 합니다.

**문서 메타데이터(작성자, 제목, 회사, 날짜)를 설정/저장할 수 있나요?**

예. 표준 [문서 속성](/slides/ko/net/presentation-properties/)을 지원하며, 저장 시 파일에 기록됩니다.