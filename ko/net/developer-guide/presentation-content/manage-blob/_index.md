---
title: ".NET에서 프레젠테이션 BLOB을 관리하여 효율적인 메모리 사용"
linktitle: "BLOB 관리"
type: docs
weight: 10
url: /ko/net/manage-blob/
keywords:
- 대용량 객체
- 대용량 항목
- 대용량 파일
- BLOB 추가
- BLOB 내보내기
- 이미지를 BLOB으로 추가
- 메모리 감소
- 메모리 사용량
- 대용량 프레젠테이션
- 임시 파일
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 BLOB 데이터를 관리하여 PowerPoint 및 OpenDocument 파일 작업을 간소화하고 효율적인 프레젠테이션 처리를 가능하게 합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션의 대용량 바이너리 데이터를 BLOB 기반으로 처리하여 큰 이미지, 오디오, 비디오 및 프레젠테이션 파일 작업 시 메모리 사용량을 줄이는 데 도움을 줍니다.

이 문서에서는 BLOB 기반 처리를 사용하여 프레젠테이션에 대용량 미디어를 추가하고, 프레젠테이션에서 대용량 미디어를 내보내며, 대용량 프레젠테이션을 보다 효율적으로 로드하는 방법을 보여줍니다. 또한 처리 중에 임시 파일을 사용하는 방법과 임시 파일이 저장되는 폴더를 변경하는 방법도 설명합니다.

## **BLOB에 대하여**

**BLOB** (**Binary Large Object**)는 일반적으로 바이너리 형식으로 저장된 큰 항목(사진, 프레젠테이션, 문서 또는 미디어)입니다. 

Aspose.Slides for .NET은 대용량 파일이 포함된 경우 메모리 사용량을 줄이는 방식으로 객체에 BLOB을 사용할 수 있도록 지원합니다. 

## **BLOB을 사용하여 메모리 사용량 줄이기**

### **BLOB을 통해 대용량 파일을 프레젠테이션에 추가하기**

[Aspose.Slides](/slides/ko/net/) for .NET은 메모리 사용량을 줄이기 위해 BLOB을 포함하는 프로세스를 통해 대용량 파일(예: 큰 비디오 파일)을 프레젠테이션에 추가할 수 있도록 합니다.

이 C# 코드는 BLOB 프로세스를 통해 큰 비디오 파일을 프레젠테이션에 추가하는 방법을 보여줍니다:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// 비디오를 추가할 새 프레젠테이션을 생성합니다
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // 프레젠테이션에 비디오를 추가합니다 - KeepLocked 동작을 선택한 이유는
        // "veryLargeVideo.avi" 파일에 접근할 의도가 없기 때문입니다.
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // 프레젠테이션을 저장합니다. 큰 프레젠테이션이 출력되는 동안에도
        // pres 객체의 전체 수명 동안 메모리 사용량이 낮게 유지됩니다 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **프레젠테이션에서 BLOB을 통해 대용량 파일 내보내기**
Aspose.Slides for .NET은 BLOB을 포함하는 프로세스를 통해 프레젠테이션에서 큰 파일(예: 오디오 또는 비디오 파일)을 내보낼 수 있도록 합니다. 예를 들어, 프레젠테이션에서 대용량 미디어 파일을 추출해야 하지만 파일을 컴퓨터 메모리에 로드하고 싶지 않을 때 BLOB 프로세스를 통해 파일을 내보내면 메모리 사용량을 낮게 유지할 수 있습니다. 

이 C# 코드는 위에서 설명한 작업을 시연합니다:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// 소스 파일을 잠그고 메모리로 로드하지 않습니다
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Presentation 인스턴스를 생성하고 "hugePresentationWithAudiosAndVideos.pptx" 파일을 잠급니다.
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// 각 비디오를 파일로 저장해 보겠습니다. 높은 메모리 사용을 방지하기 위해 사용될 버퍼가 필요합니다
	// 프레젠테이션 비디오 스트림의 데이터를 새로 생성된 비디오 파일 스트림으로 전송하기 위해
	byte[] buffer = new byte[8 * 1024];

	// 비디오를 반복합니다
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// 프레젠테이션 비디오 스트림을 엽니다. 참고로, 우리는 의도적으로 다음 속성에 접근하는 것을 피했습니다
		// video.BinaryData와 같은 속성은 전체 비디오를 포함하는 바이트 배열을 반환하기 때문에
		// 바이트가 메모리로 로드됩니다. 우리는 video.GetStream을 사용하며, 이는 Stream을 반환하고
		//  전체 비디오를 메모리로 로드할 필요가 없습니다.
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// 비디오나 프레젠테이션의 크기에 관계없이 메모리 사용량은 낮게 유지됩니다,
	}

	// 필요하다면 오디오 파일에 대해서도 동일한 단계를 적용할 수 있습니다. 
}
```

### **이미지를 BLOB으로 프레젠테이션에 추가하기**
[**IImageCollection**](https://reference.aspose.com/slides/ko/net/aspose.slides/iimagecollection) 인터페이스와 [**ImageCollection** ](https://reference.aspose.com/slides/ko/net/aspose.slides/imagecollection) 클래스의 메서드를 사용하면 스트림으로 큰 이미지를 추가하여 BLOB으로 처리할 수 있습니다. 

이 C# 코드는 BLOB 프로세스를 통해 큰 이미지를 추가하는 방법을 보여줍니다:

```c#
string pathToLargeImage = "large_image.jpg";

// 이미지를 추가할 새 프레젠테이션을 생성합니다.
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
    {
        // 이미지를 프레젠테이션에 추가합니다 - KeepLocked 동작을 선택한 이유는
        // "largeImage.png" 파일에 접근할 의도가 없기 때문입니다.
        IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

        // 프레젠테이션을 저장합니다. 큰 프레젠테이션이 출력되는 동안에도 메모리 사용량은
        // pres 객체의 전체 수명 동안 낮게 유지됩니다
        pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
    }
}
```

## **메모리와 대용량 프레젠테이션**

일반적으로 대용량 프레젠테이션을 로드하려면 컴퓨터에 많은 임시 메모리가 필요합니다. 프레젠테이션의 모든 내용이 메모리로 로드되고, 로드된 파일은 더 이상 사용되지 않습니다. 

1.5 GB 비디오 파일을 포함하는 대용량 PowerPoint 프레젠테이션(large.pptx)을 생각해 보세요. 이 프레젠테이션을 로드하는 표준 방법은 다음 C# 코드에 설명되어 있습니다:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

하지만 이 방법은 약 1.6 GB의 임시 메모리를 사용합니다. 

### **BLOB을 사용하여 대용량 프레젠테이션 로드하기**

BLOB을 포함하는 프로세스를 통해 적은 메모리만 사용하면서 대용량 프레젠테이션을 로드할 수 있습니다. 다음 C# 코드는 BLOB 프로세스를 사용하여 large.pptx와 같은 대용량 프레젠테이션 파일을 로드하는 구현을 설명합니다:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

### **임시 파일 폴더 변경하기**

BLOB 프로세스를 사용하면 컴퓨터가 기본 임시 파일 폴더에 임시 파일을 생성합니다. 임시 파일을 다른 폴더에 보관하려면 `TempFilesRootPath`를 사용하여 저장 경로 설정을 변경할 수 있습니다:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```

{{% alert title="Info" color="info" %}}
`TempFilesRootPath`를 사용할 때 Aspose.Slides는 임시 파일을 저장할 폴더를 자동으로 생성하지 않습니다. 폴더를 직접 생성해야 합니다. 
{{% /alert %}}

### **프레젠테이션 객체를 폐기하여 메모리 해제하기**

대용량 프레젠테이션을 처리할 때는 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스를 올바르게 폐기하여 사용된 메모리를 해제해야 합니다. 권장 방법은 위 예제와 같이 `using` 문이나 선언을 사용하는 것이며, 블록을 벗어나면 자동으로 프레젠테이션을 폐기하고 관리되지 않는 리소스를 해제합니다.

`using` 블록 없이 프레젠테이션을 생성한 경우 작업이 끝난 뒤 명시적으로 `Dispose()`를 호출하십시오.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...프레젠테이션을 처리합니다...
presentation.Save("large.pdf", SaveFormat.Pdf);

// 리소스를 명시적으로 해제합니다.
presentation.Dispose();
```

## **FAQ**

**Aspose.Slides 프레젠테이션에서 어떤 데이터가 BLOB으로 처리되며 BLOB 옵션으로 제어됩니까?**

이미지, 오디오 및 비디오와 같은 대용량 바이너리 객체가 BLOB으로 처리됩니다. 프레젠테이션 파일 전체도 로드하거나 저장할 때 BLOB 처리가 적용됩니다. 이러한 객체는 메모리 사용량을 관리하고 필요 시 임시 파일로 전환하도록 하는 BLOB 정책의 적용을 받습니다.

**프레젠테이션 로드 중에 BLOB 처리 규칙을 어디에서 구성합니까?**

[LoadOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/)와 [BlobManagementOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/blobmanagementoptions/)를 사용합니다. 여기서 BLOB의 메모리 상한을 설정하고, 임시 파일 사용 여부, 임시 파일 루트 경로, 소스 잠금 동작 등을 지정합니다.

**BLOB 설정이 성능에 영향을 주나요? 속도와 메모리 사용량 사이의 균형을 어떻게 맞춥니까?**

예. BLOB을 메모리에 유지하면 속도가 최대화되지만 RAM 사용량이 증가합니다. 메모리 제한을 낮추면 작업이 더 많이 임시 파일로 전환되어 RAM 사용량은 줄어들지만 추가 I/O가 발생합니다. 워크로드와 환경에 맞는 적절한 균형을 위해 [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/ko/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) 임계값을 조정하십시오.

**극히 큰 프레젠테이션(예: 수기가 바이트 규모)을 열 때 BLOB 옵션이 도움이 되나요?**

예. [BlobManagementOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/blobmanagementoptions/)는 이러한 시나리오를 위해 설계되었습니다. 임시 파일을 활성화하고 소스 잠금을 사용하면 피크 RAM 사용량을 크게 줄이고 매우 큰 파일을 안정적으로 처리할 수 있습니다.

**디스크 파일 대신 스트림에서 로드할 때 BLOB 정책을 사용할 수 있나요?**

예. 동일한 규칙이 스트림에도 적용됩니다. 프레젠테이션 인스턴스가 입력 스트림을 소유하고 잠글 수 있으며(선택한 잠금 모드에 따라), 허용된 경우 임시 파일이 사용되어 처리 중 메모리 사용량을 예측 가능하게 유지합니다.