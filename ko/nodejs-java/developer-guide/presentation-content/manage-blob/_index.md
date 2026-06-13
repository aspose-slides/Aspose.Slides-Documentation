---
title: 효율적인 메모리 사용을 위한 JavaScript에서 프레젠테이션 BLOB 관리
linktitle: BLOB 관리
type: docs
weight: 10
url: /ko/nodejs-java/manage-blob/
keywords:
- 대형 객체
- 대형 항목
- 대형 파일
- BLOB 추가
- BLOB 내보내기
- 이미지를 BLOB으로 추가
- 메모리 감소
- 메모리 사용량
- 대형 프레젠테이션
- 임시 파일
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js용 Aspose.Slides와 함께 JavaScript에서 BLOB 데이터를 관리하여 PowerPoint 및 OpenDocument 파일 작업을 효율적인 프레젠테이션 처리로 간소화합니다."
---
## **Overview**

Aspose.Slides는 프레젠테이션에서 큰 이미지, 오디오, 비디오 및 프레젠테이션 파일을 다룰 때 메모리 사용량을 줄이기 위해 대용량 이진 데이터를 BLOB 기반으로 처리합니다.

이 문서에서는 BLOB 기반 처리를 사용하여 프레젠테이션에 큰 미디어를 추가하고, 프레젠테이션에서 큰 미디어를 내보내며, 큰 프레젠테이션을 보다 효율적으로 로드하는 방법을 보여줍니다. 또한 처리 중에 임시 파일을 사용하는 방법과 임시 파일이 저장되는 폴더를 변경하는 방법을 설명합니다.

## **About BLOB**

**BLOB** (**Binary Large Object**)는 일반적으로 바이너리 형식으로 저장된 큰 항목(사진, 프레젠테이션, 문서 또는 미디어)입니다.  

Aspose.Slides for Node.js via Java은 대용량 파일이 포함된 경우 메모리 사용량을 줄이는 방식으로 객체에 BLOB을 사용할 수 있게 합니다.

{{% alert title="Info" color="info" %}}
스트림과 상호 작용할 때 특정 제한을 피하기 위해 Aspose.Slides가 스트림의 내용을 복사할 수 있습니다. 스트림을 통해 큰 프레젠테이션을 로드하면 프레젠테이션 내용이 복사되어 로드 속도가 느려집니다. 따라서 큰 프레젠테이션을 로드하려는 경우 스트림이 아닌 프레젠테이션 파일 경로를 사용하는 것을 강력히 권장합니다.
{{% /alert %}}

## **Use BLOB to Reduce Memory Consumption**

### **Add Large File through BLOB to a Presentation**

[Aspose.Slides](/slides/ko/nodejs-java/) for Node.js via Java은 BLOB 프로세스를 통해 큰 파일(이 경우 큰 비디오 파일)을 추가하여 메모리 사용량을 줄일 수 있도록 합니다.

다음 JavaScript 코드는 BLOB 프로세스를 사용해 큰 비디오 파일을 프레젠테이션에 추가하는 방법을 보여줍니다:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// 비디오가 추가될 새로운 프레젠테이션을 생성합니다
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // 비디오를 프레젠테이션에 추가합니다 - KeepLocked 동작을 선택한 이유는
        // "veryLargeVideo.avi" 파일에 접근할 의도가 없기 때문입니다.
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // 프레젠테이션을 저장합니다. 큰 프레젠테이션이 출력되는 동안 메모리 사용량은
        // pres 객체의 전체 수명 주기 동안 낮게 유지됩니다
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Export Large File Through BLOB from Presentation**

Aspose.Slides for Node.js via Java은 BLOB 프로세스를 통해 큰 파일(예: 오디오 또는 비디오 파일)을 프레젠테이션에서 내보낼 수 있게 합니다. 예를 들어 큰 미디어 파일을 프레젠테이션에서 추출해야 하지만 파일을 컴퓨터 메모리에 로드하고 싶지 않은 경우 BLOB 프로세스를 사용하면 메모리 사용량을 낮게 유지할 수 있습니다.

다음 JavaScript 코드는 해당 작업을 시연합니다:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Locks the source file and does NOT load it into memory
// 소스 파일을 잠그고 메모리로 로드하지 않습니다
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// create the Presentation's instance, lock the "hugePresentationWithAudiosAndVideos.pptx" file.
 // Presentation 인스턴스를 생성하고 "hugePresentationWithAudiosAndVideos.pptx" 파일을 잠급니다.
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Let's save each video to a file. To prevent high memory usage, we need a buffer that will be used
    // 각 비디오를 파일로 저장합니다. 높은 메모리 사용을 방지하기 위해 사용할 버퍼가 필요합니다
    // to transfer the data from the presentation's video stream to a stream for a newly created video file.
    // 프레젠테이션의 비디오 스트림에서 새로 만든 비디오 파일 스트림으로 데이터를 전송합니다.
    var buffer = new byte[8 * 1024];
    // Iterates through the videos
    // 비디오들을 순회합니다
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Opens the presentation video stream. Please, note that we intentionally avoided accessing properties
        // 프레젠테이션 비디오 스트림을 엽니다. 의도적으로 속성 접근을 피했음을 알려드립니다
        // like video.BinaryData - because this property returns a byte array containing a full video, which then
        // video.BinaryData와 같은 속성은 전체 비디오를 포함하는 바이트 배열을 반환하므로
        // causes bytes to be loaded into memory. We use video.GetStream, which will return Stream - and does NOT
        // 메모리로 바이트가 로드됩니다. 우리는 video.GetStream을 사용하며, 이는 스트림을 반환하고 메모리에 전체 비디오를 로드하지 않습니다.
        // require us to load the whole video into the memory.
        // 전체 비디오를 메모리에 로드할 필요가 없습니다.
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
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
        // 비디오 또는 프레젠테이션 크기에 관계없이 메모리 사용량이 낮게 유지됩니다.
    }
    // If necessary, you can apply the same steps for audio files.
    // 필요하면 오디오 파일에 대해 동일한 단계를 적용할 수 있습니다.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **Add Image as BLOB in Presentation**

[**ImageCollection**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ImageCollection) 클래스와 [**ImageCollection**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ImageCollection) 클래스를 사용하면 스트림으로 큰 이미지를 추가해 BLOB으로 처리할 수 있습니다.

다음 JavaScript 코드는 BLOB 프로세스를 사용해 큰 이미지를 추가하는 방법을 보여줍니다:

```javascript
var pathToLargeImage = "large_image.jpg";
// 이미지를 추가할 새 프레젠테이션을 생성합니다.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // 프레젠테이션에 이미지를 추가합니다 - KeepLocked 동작을 선택한 이유는
        // "largeImage.png" 파일에 접근할 의도가 없기 때문입니다.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // 프레젠테이션을 저장합니다. 큰 프레젠테이션이 출력되는 동안 메모리 사용량은
        // pres 객체의 전체 수명 주기 동안 낮게 유지됩니다.
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Memory and Large Presentations**

일반적으로 큰 프레젠테이션을 로드하려면 많은 임시 메모리가 필요합니다. 프레젠테이션의 전체 내용이 메모리로 로드되고, 프레젠테이션을 로드한 파일은 더 이상 사용되지 않습니다.  

예를 들어 1.5 GB 비디오 파일이 포함된 큰 PowerPoint 프레젠테이션(large.pptx)을 생각해 보십시오. 다음 JavaScript 코드는 표준 로드 방식을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

하지만 이 방법은 약 1.6 GB의 임시 메모리를 소비합니다.

### **Load a Large Presentation as BLOB**

BLOB 프로세스를 사용하면 적은 메모리로 큰 프레젠테이션을 로드할 수 있습니다. 다음 JavaScript 코드는 BLOB 프로세스를 사용해 large.pptx 파일을 로드하는 구현을 설명합니다:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Change the Folder for Temporary Files**

BLOB 프로세스를 사용하면 컴퓨터가 기본 임시 파일 폴더에 임시 파일을 생성합니다. 임시 파일을 다른 폴더에 보관하고 싶다면 `setTempFilesRootPath`를 사용해 저장 경로를 변경할 수 있습니다:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
`setTempFilesRootPath`를 사용하면 Aspose.Slides가 자동으로 임시 파일 폴더를 생성하지 않습니다. 폴더를 직접 만들어야 합니다.
{{% /alert %}}

### **Dispose Presentation Objects to Release Memory**

큰 프레젠테이션을 처리할 때는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 적절히 해제해 메모리를 해제해야 합니다. 프레젠테이션 사용을 마친 후에는 `dispose()`를 호출해 관리되지 않는 리소스를 해제하십시오.

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **FAQ**

**What data in an Aspose.Slides presentation is treated as BLOB and controlled by BLOB options?**  
이미지, 오디오, 비디오와 같은 대용량 이진 객체가 BLOB으로 처리됩니다. 프레젠테이션 파일 자체도 로드하거나 저장할 때 BLOB 처리가 적용됩니다. 이러한 객체는 메모리 사용을 관리하고 필요에 따라 임시 파일로 스필하도록 하는 BLOB 정책에 의해 제어됩니다.

**Where do I configure BLOB handling rules during presentation loading?**  
[LoadOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/)와 [BlobManagementOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/blobmanagementoptions/)를 사용합니다. 여기서 BLOB의 메모리 제한, 임시 파일 허용 여부, 임시 파일 루트 경로, 소스 잠금 동작 등을 설정합니다.

**Do BLOB settings affect performance, and how do I balance speed vs memory?**  
예. BLOB을 메모리에 유지하면 속도가 최적화되지만 RAM 사용량이 증가합니다. 메모리 제한을 낮추면 더 많은 작업이 임시 파일로 이동해 RAM 사용량은 줄어들지만 I/O가 추가됩니다. 워크로드와 환경에 맞는 균형을 맞추려면 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) 메서드를 사용하십시오.

**Do BLOB options help when opening extremely large presentations (e.g., gigabytes)?**  
예. [BlobManagementOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/blobmanagementoptions/)는 이러한 시나리오를 위해 설계되었으며, 임시 파일 사용 및 소스 잠금을 활성화하면 피크 RAM 사용량을 크게 줄이고 매우 큰 프레젠테이션의 처리를 안정화할 수 있습니다.

**Can I use BLOB policies when loading from streams instead of disk files?**  
예. 동일한 규칙이 스트림에도 적용됩니다. 프레젠테이션 인스턴스는 선택한 잠금 모드에 따라 입력 스트림을 소유하고 잠글 수 있으며, 허용된 경우 임시 파일이 사용되어 처리 중 메모리 사용을 예측 가능하게 유지합니다.