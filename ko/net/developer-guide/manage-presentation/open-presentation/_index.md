---
title: .NET에서 프레젠테이션 열기
linktitle: 프레젠테이션 열기
type: docs
weight: 20
url: /ko/net/open-presentation/
keywords:
- PowerPoint 열기
- 프레젠테이션 열기
- PPTX 열기
- PPT 열기
- ODP 열기
- 프레젠테이션 로드
- PPTX 로드
- PPT 로드
- ODP 로드
- 보호된 프레젠테이션
- 대용량 프레젠테이션
- 외부 리소스
- 바이너리 개체
- .NET
- C#
- Aspose.Slides
description: "C#에서 PowerPoint 및 OpenDocument 프레젠테이션을 여는 방법, 열기 비밀번호 제공, 리소스 로딩 제어, 그리고 Aspose.Slides for .NET을 사용하여 메모리 사용량을 줄이는 방법을 배웁니다."
---
## **소개**

[Aspose.Slides for .NET](https://products.aspose.com/slides/ko/net/)은 파일 및 스트림에서 PowerPoint 및 OpenDocument 프레젠테이션을 로드할 수 있습니다. 프레젠테이션을 로드한 후에는 구조를 검사하고, 슬라이드를 편집하고, 리소스를 관리하며, 원본 형식이나 다른 지원되는 형식으로 저장할 수 있습니다.

로드 동작은 [LoadOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/) 클래스를 통해 사용자 지정할 수 있습니다. 예를 들어, 열기 비밀번호를 제공하고, 큰 바이너리 개체를 관리 메모리 외부에 보관하며, 외부 리소스를 제어하거나 임베드된 바이너리 데이터를 생략할 수 있습니다.

## **프레젠테이션 열기**

기존 프레젠테이션을 열려면 파일 경로를 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 생성자에 전달하십시오. 사용 후에는 프레젠테이션을 해제해 파일 핸들, 임시 데이터 및 기타 리소스가 즉시 해제되도록 합니다.

다음 C# 예제는 프레젠테이션을 열고 슬라이드 수를 가져오는 방법을 보여줍니다:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **비밀번호로 보호된 프레젠테이션 열기**

열기 비밀번호는 프레젠테이션 내용을 암호화합니다. 전체 프레젠테이션을 로드하려면 올바른 비밀번호를 [LoadOptions.Password](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/password/)에 할당하고 옵션을 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 생성자에 전달하십시오. 비밀번호가 없거나 틀리면 로드가 실패합니다.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

비밀번호 감지, 검증 및 암호화 작업 흐름에 대해서는 [Password-Protect Presentations](/slides/ko/net/password-protected-presentation/)를 참조하십시오. 암호화된 프레젠테이션이 공개 문서 속성을 포함하도록 저장된 경우, 해당 속성은 비밀번호 없이도 읽을 수 있습니다; 자세히 보려면 [Manage Presentation Properties](/slides/ko/net/presentation-properties/)를 확인하십시오.

## **대용량 프레젠테이션 열기**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/blobmanagementoptions/)는 Aspose.Slides가 이미지, 오디오 및 비디오와 같은 대용량 바이너리 개체를 처리하는 방식을 제어합니다. 소스 파일을 잠금 상태로 유지하거나, 임시 파일을 허용하고, 메모리에 유지되는 BLOB 데이터 양을 제한할 수 있습니다.

다음 C# 코드는 대용량 프레젠테이션(예: 2 GB)을 로드하는 방법을 보여줍니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
`PresentationLockingBehavior.KeepLocked`을 사용하면 `Presentation` 객체가 해제될 때까지 소스 파일이 잠긴 상태로 유지됩니다. 해당 객체가 살아 있는 동안 소스 파일을 이동, 덮어쓰기 또는 삭제하지 않으십시오.

Aspose.Slides는 로드 중에 입력 스트림의 내용을 복사할 수 있습니다. 대용량 프레젠테이션의 경우 파일 경로가 일반적으로 스트림보다 더 효율적입니다. 추가 저장 및 메모리 관리 옵션은 [Manage BLOBs](/slides/ko/net/manage-blob/)를 참고하십시오.
{{% /alert %}}

## **외부 리소스 제어**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/resourceloadingcallback/)는 [IResourceLoadingCallback](https://reference.aspose.com/slides/ko/net/aspose.slides/iresourceloadingcallback/) 구현을 받아들입니다. 콜백을 통해 교체 데이터를 제공하거나, 리소스를 리다이렉트하거나, 기본 로더를 사용하거나, 리소스를 건너뛸 수 있습니다. 이는 프레젠테이션에 포함된 외부 이미지가 애플리케이션별 보안 또는 저장 규칙에 따라 해결되어야 할 때 유용합니다.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **임베드된 바이너리 개체 없이 프레젠테이션 로드**

프레젠테이션에 포함된 바이너리 데이터 중 애플리케이션에서 필요하지 않거나 유지하고 싶지 않은 경우가 있습니다. 예시:

- VBA 프로젝트는 [IPresentation.VbaProject](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/vbaproject/)를 통해 사용할 수 있습니다;
- 임베드된 OLE 데이터는 [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/ko/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/)를 통해 접근할 수 있습니다;
- ActiveX 컨트롤 데이터는 [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/ko/net/aspose.slides/icontrol/activexcontrolbinary/)를 통해 제공됩니다.

로드 중에 이 바이너리 데이터를 제거하려면 [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/)를 `true`로 설정하십시오. 로드된 프레젠테이션을 저장하면 정제된 결과가 지속됩니다.

이 옵션은 원하지 않는 임베드된 페이로드 노출을 줄여 주지만, 완전한 악성코드 탐지 또는 콘텐츠 정제 시스템은 아닙니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **FAQ**

**파일이 손상되어 열 수 없음을 어떻게 판단할 수 있나요?**

Aspose.Slides는 로드 중에 구문 분석 또는 형식 예외를 발생시킵니다. 비밀번호 오류와는 별도로 이 실패를 처리하여 애플리케이션이 원인을 정확히 보고하도록 하십시오.

**필요한 글꼴이 없으면 어떻게 되나요?**

프레젠테이션은 여전히 로드되지만, 렌더링 및 내보내기 시 글꼴이 대체될 수 있습니다. 출력이 더 예측 가능하도록 하려면 [configure font substitution](/slides/ko/net/font-substitution/) 또는 [provide custom fonts](/slides/ko/net/custom-font/)을 사용하십시오.

**프레젠테이션을 로드하면 임베드된 미디어도 로드됩니까?**

임베드된 오디오와 비디오는 프레젠테이션 객체 모델을 통해 사용할 수 있게 됩니다. 외부 리소스는 구성된 리소스 로딩 동작에 따라 해결되며, 해당 위치에 접근할 수 없는 경우 사용할 수 없을 수 있습니다.