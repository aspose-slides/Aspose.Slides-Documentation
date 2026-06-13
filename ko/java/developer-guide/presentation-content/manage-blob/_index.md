---
title: Java에서 프레젠테이션 BLOB 관리로 효율적인 메모리 사용
linktitle: BLOB 관리
type: docs
weight: 10
url: /ko/java/manage-blob/
keywords:
- 대형 객체
- 대형 항목
- 대형 파일
- BLOB 추가
- BLOB 내보내기
- 이미지 BLOB로 추가
- 메모리 감소
- 메모리 사용량
- 대형 프레젠테이션
- 임시 파일
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 BLOB 데이터를 관리하여 PowerPoint 및 OpenDocument 파일 작업을 간소화하고 효율적인 프레젠테이션 처리를 구현합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 대용량 바이너리 데이터를 처리하기 위해 BLOB 기반 처리를 제공하여 큰 이미지, 오디오, 비디오 및 프레젠테이션 파일을 사용할 때 메모리 사용량을 줄이는 데 도움을 줍니다.

이 문서에서는 BLOB 기반 처리를 사용하여 큰 미디어를 프레젠테이션에 추가하고, 프레젠테이션에서 큰 미디어를 내보내며, 대용량 프레젠테이션을 보다 효율적으로 로드하는 방법을 보여줍니다. 또한 처리 중에 임시 파일을 사용하는 방법과 파일을 저장할 폴더를 변경하는 방법도 설명합니다.

## **BLOB에 대하여**

**BLOB**(**Binary Large Object**)는 일반적으로 이진 형식으로 저장된 큰 항목(사진, 프레젠테이션, 문서 또는 미디어)입니다.

Aspose.Slides for Java는 대용량 파일이 포함될 때 메모리 사용량을 줄이는 방식으로 객체에 BLOB를 사용할 수 있도록 합니다.

{{% alert title="Info" color="info" %}}
스트림과 상호 작용할 때 특정 제한을 피하기 위해 Aspose.Slides는 스트림 내용을 복사할 수 있습니다. 스트림을 통해 대용량 프레젠테이션을 로드하면 프레젠테이션 내용이 복사되어 로드 속도가 느려집니다. 따라서 대용량 프레젠테이션을 로드하려는 경우 스트림이 아닌 프레젠테이션 파일 경로를 사용하는 것이 강력히 권장됩니다.
{{% /alert %}}

## **BLOB를 사용하여 메모리 소비 줄이기**

### **BLOB를 통해 대용량 파일을 프레젠테이션에 추가하기**

[Aspose.Slides](/slides/ko/java/) for Java는 메모리 사용량을 줄이기 위해 BLOB를 이용한 프로세스를 통해 대용량 파일(이 경우 대용량 비디오 파일)을 추가할 수 있도록 합니다.

이 Java 예제는 BLOB 프로세스를 통해 대용량 비디오 파일을 프레젠테이션에 추가하는 방법을 보여줍니다:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// 비디오가 추가될 새 프레젠테이션을 생성합니다
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // 프레젠테이션에 비디오를 추가합니다 - KeepLocked 동작을 선택한 이유는
        // "veryLargeVideo.avi" 파일에 접근하려는 의도가 없기 때문입니다.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // 프레젠테이션을 저장합니다. 대용량 프레젠테이션이 출력되는 동안에도 메모리 사용량은
        // pres 객체의 수명 주기 전체에 걸쳐 낮게 유지됩니다.
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **BLOB를 통해 프레젠테이션에서 대용량 파일 내보내기**

Aspose.Slides for Java는 프레젠테이션에서 BLOB를 이용한 프로세스를 통해 대용량 파일(예: 오디오 또는 비디오 파일)을 내보낼 수 있도록 합니다. 예를 들어 프레젠테이션에서 대용량 미디어 파일을 추출해야 하지만 해당 파일을 컴퓨터 메모리에 로드하고 싶지 않을 수 있습니다. BLOB 프로세스를 통해 파일을 내보내면 메모리 사용량을 낮게 유지할 수 있습니다.

다음 Java 코드는 위 작업을 보여줍니다:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Locks the source file and does NOT load it into memory
// 소스 파일을 잠그고 메모리로 로드하지 않습니다
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// create the Presentation's instance, lock the "hugePresentationWithAudiosAndVideos.pptx" file.
 // Presentation 인스턴스를 생성하고 "hugePresentationWithAudiosAndVideos.pptx" 파일을 잠급니다.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Let's save each video to a file. To prevent high memory usage, we need a buffer that will be used
    // 각 비디오를 파일로 저장합니다. 높은 메모리 사용을 방지하려면 다음에 사용될 버퍼가 필요합니다
    // to transfer the data from the presentation's video stream to a stream for a newly created video file.
    // 프레젠테이션 비디오 스트림의 데이터를 새로 만든 비디오 파일 스트림으로 전달하기 위해서입니다.
    byte[] buffer = new byte[8 * 1024];

    // Iterates through the videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Opens the presentation video stream. Please, note that we intentionally avoided accessing properties
        // 프레젠테이션 비디오 스트림을 엽니다. 참고로 우리는 의도적으로 속성에 접근하는 것을 피했습니다
        // like video.BinaryData - because this property returns a byte array containing a full video, which then
        // 예: video.BinaryData - 이 속성은 전체 비디오를 포함하는 바이트 배열을 반환하기 때문에
        // causes bytes to be loaded into memory. We use video.GetStream, which will return Stream - and does NOT
        // 메모리로 바이트가 로드됩니다. 우리는 video.GetStream을 사용하며, 이는 스트림을 반환하고 - 메모리로 전체 비디오를 로드하지 않습니다
        //  require us to load the whole video into the memory.
        // 전체 비디오를 메모리에 로드할 필요가 없습니다.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Memory consumption will remain low regardless of the size of the video or presentation.
        // 비디오나 프레젠테이션 크기에 관계없이 메모리 사용량은 낮게 유지됩니다.
    }
    // If necessary, you can apply the same steps for audio files. 
    // 필요하다면 오디오 파일에 대해서도 동일한 절차를 적용할 수 있습니다.
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **이미지를 BLOB로 프레젠테이션에 추가하기**

[IImageCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IImageCollection) 인터페이스와 [ImageCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ImageCollection) 클래스의 메서드를 사용하면 스트림으로 큰 이미지를 추가하여 BLOB로 처리할 수 있습니다.

이 Java 코드는 BLOB 프로세스를 통해 큰 이미지를 추가하는 방법을 보여줍니다:

```java
String pathToLargeImage = "large_image.jpg";

// creates a new presentation to which the image will be added.
 // 이미지를 추가할 새 프레젠테이션을 생성합니다.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Let's add the image to the presentation - we choose KeepLocked behavior because we do
		// 이미지를 프레젠테이션에 추가합니다 - KeepLocked 동작을 선택한 이유는
		// NOT intend to access the "largeImage.png" file.
		// "largeImage.png" 파일에 접근하려는 의도가 없기 때문입니다.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Saves the presentation. While a large presentation gets outputted, the memory consumption
		// 프레젠테이션을 저장합니다. 대용량 프레젠테이션이 출력되는 동안에도 메모리 사용량은
		// stays low through the pres object's lifecycle
		// pres 객체의 수명 주기 전체에 걸쳐 낮게 유지됩니다.
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **메모리와 대용량 프레젠테이션**

일반적으로 대용량 프레젠테이션을 로드하려면 컴퓨터에 많은 임시 메모리가 필요합니다. 프레젠테이션의 모든 내용이 메모리로 로드되고 프레젠테이션이 로드된 파일은 더 이상 사용되지 않습니다.

예를 들어 1.5GB 비디오 파일을 포함한 대용량 PowerPoint 프레젠테이션(large.pptx)을 생각해 보세요. 이 프레젠테이션을 로드하는 표준 방법은 다음 Java 코드에 설명되어 있습니다:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

하지만 이 방법은 약 1.6GB의 임시 메모리를 사용합니다.

### **BLOB로 대용량 프레젠테이션 로드하기**

BLOB를 이용하는 프로세스를 통해 적은 메모리로 대용량 프레젠테이션을 로드할 수 있습니다. 다음 Java 코드는 BLOB 프로세스를 사용하여 대용량 프레젠테이션 파일(large.pptx)을 로드하는 구현을 보여줍니다:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **임시 파일 폴더 변경하기**

BLOB 프로세스를 사용할 때 컴퓨터는 기본 임시 파일 폴더에 임시 파일을 생성합니다. 임시 파일을 다른 폴더에 보관하려면 `TempFilesRootPath`를 사용하여 저장 설정을 변경할 수 있습니다:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
`TempFilesRootPath`를 사용할 때 Aspose.Slides는 자동으로 임시 파일을 저장할 폴더를 생성하지 않습니다. 폴더를 직접 만들어야 합니다.
{{% /alert %}}

### **Presentation 객체를 해제하여 메모리 확보하기**

대용량 프레젠테이션을 처리할 때는 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 인스턴스를 적절히 해제하여 점유했던 메모리를 해제해야 합니다. 프레젠테이션 사용을 마친 후 `dispose()`를 호출하여 관리되지 않는 리소스를 해제하십시오.

```java
Presentation presentation = new Presentation("large.pptx");

// ...프레젠테이션을 처리합니다...
presentation.save("large.pdf", SaveFormat.Pdf);

// 명시적으로 리소스를 해제합니다.
presentation.dispose();
```

## **FAQ**

**Aspose.Slides 프레젠테이션에서 어떤 데이터가 BLOB로 처리되며 BLOB 옵션에 의해 제어됩니까?**

이미지, 오디오, 비디오와 같은 대용량 바이너리 객체가 BLOB로 처리됩니다. 프레젠테이션 파일 전체도 로드되거나 저장될 때 BLOB 처리가 적용됩니다. 이러한 객체는 메모리 사용을 관리하고 필요에 따라 임시 파일로 스필하도록 하는 BLOB 정책에 의해 제어됩니다.

**프레젠테이션 로드 중에 BLOB 처리 규칙을 어디에서 구성합니까?**

[LoadOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/)와 [BlobManagementOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/blobmanagementoptions/)를 사용합니다. 여기에서 BLOB의 메모리 제한을 설정하고, 임시 파일 사용 여부를 지정하며, 임시 파일의 루트 경로를 선택하고, 소스 잠금 동작을 선택합니다.

**BLOB 설정이 성능에 영향을 미치며, 속도와 메모리 사이의 균형을 어떻게 맞출 수 있습니까?**

예. BLOB를 메모리에 유지하면 속도가 최대화되지만 RAM 사용량이 증가합니다. 메모리 제한을 낮추면 작업을 더 많은 임시 파일로 전환해 RAM 사용량을 줄이는 대신 I/O가 증가합니다. 작업량과 환경에 맞는 균형을 맞추려면 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ko/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) 메서드를 사용하세요.

**극히 큰 프레젠테이션(예: 여러 기가바이트)을 열 때 BLOB 옵션이 도움이 됩니까?**

예. [BlobManagementOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/blobmanagementoptions/)는 이러한 시나리오를 위해 설계되었습니다. 임시 파일을 활성화하고 소스 잠금을 사용하면 피크 RAM 사용량을 크게 줄이고 매우 큰 프레젠테이션을 안정적으로 처리할 수 있습니다.

**디스크 파일 대신 스트림에서 로드할 때 BLOB 정책을 사용할 수 있습니까?**

예. 동일한 규칙이 스트림에도 적용됩니다. 프레젠테이션 인스턴스는 선택된 잠금 모드에 따라 입력 스트림을 소유하고 잠글 수 있으며, 허용되는 경우 임시 파일이 사용되어 처리 중 메모리 사용량을 예측 가능하게 유지합니다.