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
description: "Aspose.Slides for .NET를 사용하여 PowerPoint(.pptx, .ppt) 및 OpenDocument(.odp) 프레젠테이션을 손쉽게 열고—빠르고 신뢰할 수 있으며 완전한 기능을 제공합니다."
---
## **소개**

스크래치에서 PowerPoint 프레젠테이션을 만드는 것 외에도, Aspose.Slides를 사용하면 기존 프레젠테이션을 열 수 있습니다. 프레젠테이션을 로드한 후에는 해당 정보를 가져오고, 슬라이드 내용을 편집하고, 새 슬라이드를 추가하고, 기존 슬라이드를 제거하는 등 다양한 작업을 수행할 수 있습니다.

## **프레젠테이션 열기**

기존 프레젠테이션을 열려면 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스를 인스턴스화하고 파일 경로를 생성자에 전달합니다.

다음 C# 예제는 프레젠테이션을 열고 슬라이드 수를 가져오는 방법을 보여줍니다:

```cs
// Presentation 클래스를 인스턴스화하고 파일 경로를 생성자에 전달합니다.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // 프레젠테이션의 총 슬라이드 수를 출력합니다.
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **비밀번호로 보호된 프레젠테이션 열기**

비밀번호로 보호된 프레젠테이션을 열어야 할 경우, [LoadOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/) 클래스의 [Password](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/password/) 속성을 통해 비밀번호를 전달하여 복호화하고 로드합니다. 다음 C# 코드는 이 작업을 보여줍니다:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // 복호화된 프레젠테이션에 대해 작업을 수행합니다.
}
```

## **대용량 프레젠테이션 열기**

Aspose.Slides는 특히 [LoadOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/) 클래스의 [BlobManagementOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/blobmanagementoptions/) 속성과 같은 옵션을 제공하여 대용량 프레젠테이션을 로드하는 데 도움을 줍니다.

다음 C# 코드는 대용량 프레젠테이션(예: 2GB)을 로드하는 방법을 보여줍니다:

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // KeepLocked 동작을 선택하십시오—프레젠테이션 파일은 수명 동안 잠긴 상태를 유지합니다.
        // Presentation 인스턴스이지만 메모리에 로드되거나 임시 파일로 복사될 필요는 없습니다.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // 대용량 프레젠테이션이 로드되었으며 사용할 수 있습니다. 메모리 사용량은 낮게 유지됩니다.

    // 프레젠테이션을 수정합니다.
    presentation.Slides[0].Name = "Large presentation";

    // 프레젠테이션을 다른 파일에 저장합니다. 이 작업 중에도 메모리 사용량은 낮게 유지됩니다.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // 이렇게 하지 마십시오! 프레젠테이션 객체가 해제될 때까지 파일이 잠겨 있어 I/O 예외가 발생합니다.
    File.Delete(filePath);
}

// 여기에서는 수행해도 됩니다. 소스 파일은 이제 프레젠테이션 객체에 의해 잠겨 있지 않습니다.
File.Delete(filePath);
```

{{% alert color="info" title="Info" %}}
스트림을 사용할 때 일부 제한을 우회하기 위해 Aspose.Slides가 스트림 내용을 복사할 수 있습니다. 스트림에서 대용량 프레젠테이션을 로드하면 프레젠테이션이 복사되어 로드 속도가 느려질 수 있습니다. 따라서 대용량 프레젠테이션을 로드해야 할 경우 스트림보다 프레젠테이션 파일 경로를 사용하는 것을 강력히 권장합니다.

비디오, 오디오, 고해상도 이미지 등 대용량 개체를 포함하는 프레젠테이션을 만들 때는 [BLOB management](/slides/ko/net/manage-blob/)를 사용하여 메모리 사용량을 줄일 수 있습니다.
{{%/alert %}}

## **외부 리소스 제어**

Aspose.Slides는 외부 리소스를 관리할 수 있는 [IResourceLoadingCallback](https://reference.aspose.com/slides/ko/net/aspose.slides/iresourceloadingcallback/) 인터페이스를 제공합니다. 다음 C# 코드는 `IResourceLoadingCallback` 인터페이스를 사용하는 방법을 보여줍니다:

```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // 대체 이미지를 로드합니다.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // 대체 URL을 설정합니다.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // 다른 모든 이미지를 건너뜁니다.
        return ResourceLoadingAction.Skip;
    }
}
```

## **임베디드 바이너리 개체 없이 프레젠테이션 로드**

PowerPoint 프레젠테이션은 다음과 같은 유형의 임베디드 바이너리 개체를 포함할 수 있습니다:

- VBA 프로젝트([IPresentation.VbaProject](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/vbaproject/) 통해 접근 가능);
- OLE 객체 임베디드 데이터([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/ko/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) 통해 접근 가능);
- ActiveX 컨트롤 바이너리 데이터([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/ko/net/aspose.slides/icontrol/activexcontrolbinary/) 통해 접근 가능).

[ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ko/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) 속성을 사용하면 임베디드 바이너리 개체가 전혀 없는 상태로 프레젠테이션을 로드할 수 있습니다.

이 속성은 잠재적으로 악성인 바이너리 콘텐츠를 제거하는 데 유용합니다. 다음 C# 코드는 임베디드 바이너리 콘텐츠가 전혀 없는 프레젠테이션을 로드하는 방법을 보여줍니다:

```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // 프레젠테이션에 대한 작업을 수행합니다.
}
```

## **FAQ**

**파일이 손상되어 열 수 없다는 것을 어떻게 알 수 있나요?**  
로드 중에 구문/형식 유효성 검사 예외가 발생합니다. 이러한 오류는 종종 잘못된 ZIP 구조나 손상된 PowerPoint 레코드를 언급합니다.

**열 때 필수 폰트가 누락되면 어떻게 되나요?**  
파일은 열리지만 이후 [rendering/export](/slides/ko/net/convert-presentation/) 시 폰트가 대체될 수 있습니다. 런타임 환경에 [폰트 대체 구성](/slides/ko/net/font-substitution/)하거나 [필요한 폰트 추가](/slides/ko/net/custom-font/)하십시오.

**열 때 임베디드 미디어(비디오/오디오)는 어떻게 처리되나요?**  
미디어는 프레젠테이션 리소스로 사용 가능해집니다. 미디어가 외부 경로를 통해 참조되는 경우 해당 경로가 환경에서 접근 가능해야 하며, 그렇지 않으면 [rendering/export](/slides/ko/net/convert-presentation/) 시 미디어가 제외될 수 있습니다.