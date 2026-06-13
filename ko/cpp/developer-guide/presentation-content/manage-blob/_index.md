---
title: C++에서 프레젠테이션 BLOB을 관리하여 효율적인 메모리 사용
linktitle: BLOB 관리
type: docs
weight: 10
url: /ko/cpp/manage-blob/
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
- C++
- Aspose.Slides
description: "C++용 Aspose.Slides에서 BLOB 데이터를 관리하여 PowerPoint 및 OpenDocument 파일 작업을 간소화하고 효율적인 프레젠테이션 처리를 구현합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 큰 바이너리 데이터를 처리하기 위해 BLOB 기반 처리를 제공하여 대용량 이미지, 오디오, 비디오 및 프레젠테이션 파일을 작업할 때 메모리 사용량을 줄이는 데 도움을 줍니다.

이 문서에서는 BLOB 기반 처리를 사용하여 프레젠테이션에 대용량 미디어를 추가하고, 프레젠테이션에서 대용량 미디어를 내보내며, 대용량 프레젠테이션을 보다 효율적으로 로드하는 방법을 보여줍니다. 또한 처리 중에 임시 파일을 사용하는 방법과 임시 파일이 저장되는 폴더를 변경하는 방법에 대해서도 설명합니다.

## **BLOB에 대한 정보**

**BLOB** (**Binary Large Object**)는 일반적으로 바이너리 형식으로 저장된 큰 항목(사진, 프레젠테이션, 문서 또는 미디어)입니다. 

Aspose.Slides for C++는 대용량 파일이 포함된 경우 메모리 사용량을 줄이는 방식으로 객체에 BLOB을 사용할 수 있도록 합니다. 

## **메모리 사용량 감소를 위한 BLOB 사용**

### **BLOB을 통해 대용량 파일을 프레젠테이션에 추가하기**

[Aspose.Slides](/slides/ko/cpp/) for C++는 BLOB 프로세스를 통해 대용량 파일(예: 대용량 비디오 파일)을 추가하여 메모리 사용량을 줄일 수 있게 합니다.

다음 C++ 코드는 BLOB 프로세스를 통해 대용량 비디오 파일을 프레젠테이션에 추가하는 방법을 보여줍니다:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// 비디오가 추가될 새 프레젠테이션을 생성합니다
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// 프레젠테이션에 비디오를 추가합니다 - KeepLocked 동작을 선택한 이유는
// "veryLargeVideo.avi" 파일에 접근할 의도가 없기 때문입니다.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// 프레젠테이션을 저장합니다. 대형 프레젠테이션을 출력하는 동안 메모리 사용량이
// pres 객체의 전체 수명 동안 낮게 유지됩니다
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **BLOB을 통해 프레젠테이션에서 대용량 파일 내보내기**

Aspose.Slides for C++는 BLOB 프로세스를 통해 프레젠테이션에서 대용량 파일(예: 오디오 또는 비디오 파일)을 내보낼 수 있습니다. 예를 들어, 프레젠테이션에서 대용량 미디어 파일을 추출해야 하지만 해당 파일을 컴퓨터 메모리에 로드하고 싶지 않을 때 BLOB 프로세스를 사용하면 메모리 사용량을 낮게 유지할 수 있습니다. 

다음 C++ 코드는 위에서 설명한 작업을 보여줍니다:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Presentation 인스턴스를 생성하고 "hugePresentationWithAudiosAndVideos.pptx" 파일을 잠급니다.

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// 각 비디오를 파일에 저장합니다. 높은 메모리 사용을 방지하기 위해 버퍼가 필요합니다
// 프레젠테이션의 비디오 스트림에서 새로 만든 비디오 파일 스트림으로 데이터를 전송하기 위해
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Iterates through the videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
    auto video = pres->get_Videos()->idx_get(index);

    // 프레젠테이션 비디오 스트림을 엽니다. 참고로 우리는 의도적으로 메서드 접근을 피했습니다
    // video->get_BinaryData와 같은 메서드 - 이 메서드는 전체 비디오를 포함하는 바이트 배열을 반환하므로
    // 메모리로 바이트가 로드됩니다. 우리는 video->GetStream을 사용합니다. 이 메서드는 Stream을 반환하며 메모리에 전체 비디오를 로드하지 않습니다
    // 전체 비디오를 메모리에 로드할 필요가 없습니다.

    auto presVideoStream = video->GetStream();

    auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
    int32_t bytesRead;
    while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
    {
        outputFileStream->Write(buffer, 0, bytesRead);
    }
        
    // 비디오나 프레젠테이션 크기에 관계없이 메모리 사용량이 낮게 유지됩니다
}

// 필요에 따라 오디오 파일에도 동일한 단계를 적용할 수 있습니다.
```

### **이미지를 BLOB으로 프레젠테이션에 추가하기**

[**IImageCollection**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_image_collection) 인터페이스와 [**ImageCollection**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.image_collection) 클래스를 사용하면 스트림으로 대용량 이미지를 추가하여 BLOB로 처리할 수 있습니다. 

다음 C++ 코드는 BLOB 프로세스를 통해 대용량 이미지를 추가하는 방법을 보여줍니다:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// 이미지를 추가할 새 프레젠테이션을 생성합니다.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// 프레젠테이션에 이미지를 추가합니다 - KeepLocked 동작을 선택한 이유는
// "largeImage.png" 파일에 접근할 의도가 없기 때문입니다.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// 프레젠테이션을 저장합니다. 큰 프레젠테이션을 출력하는 동안 메모리 사용량이
// pres 객체의 전체 수명 동안 낮게 유지됩니다
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **메모리와 대용량 프레젠테이션**

일반적으로 대용량 프레젠테이션을 로드하려면 컴퓨터에 많은 임시 메모리가 필요합니다. 프레젠테이션의 모든 내용이 메모리로 로드되고, 로드된 파일은 더 이상 사용되지 않습니다. 

예를 들어 1.5GB 비디오 파일을 포함하는 대용량 PowerPoint 프레젠테이션 (large.pptx)을 생각해 보십시오. 프레젠테이션을 로드하는 표준 방법은 다음 C++ 코드에 설명되어 있습니다:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

하지만 이 방법은 약 1.6GB의 임시 메모리를 소비합니다. 

### **BLOB을 사용하여 대용량 프레젠테이션 로드하기**

BLOB 프로세스를 사용하면 적은 메모리로 대용량 프레젠테이션을 로드할 수 있습니다. 다음 C++ 코드는 BLOB 프로세스를 사용하여 대용량 프레젠테이션 파일 (large.pptx)을 로드하는 구현을 보여줍니다:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **임시 파일 폴더 변경**

BLOB 프로세스를 사용할 때 컴퓨터는 기본 임시 파일 폴더에 임시 파일을 생성합니다. 임시 파일을 다른 폴더에 저장하려면 `TempFilesRootPath`를 사용하여 저장 경로 설정을 변경할 수 있습니다:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}

`TempFilesRootPath`를 사용하면 Aspose.Slides가 임시 파일을 저장할 폴더를 자동으로 생성하지 않습니다. 폴더를 직접 생성해야 합니다. 

{{% /alert %}}

### **프레젠테이션 객체를 해제하여 메모리 해제하기**

대용량 프레젠테이션을 처리할 때는 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스를 적절히 해제하여 점유한 메모리를 반환하도록 해야 합니다. 프레젠테이션 사용을 마친 후 `Dispose()`를 호출하여 관리되지 않는 리소스를 해제하십시오.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...process the presentation...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Explicitly release resources.
presentation->Dispose();
```

## **FAQ**

**Aspose.Slides 프레젠테이션에서 어떤 데이터가 BLOB로 처리되며 BLOB 옵션으로 제어됩니까?**

이미지, 오디오, 비디오와 같은 큰 바이너리 객체가 BLOB로 처리됩니다. 프레젠테이션 전체 파일도 로드하거나 저장할 때 BLOB 처리가 적용됩니다. 이러한 객체는 메모리 사용량을 관리하고 필요할 경우 임시 파일로 스필하도록 하는 BLOB 정책에 의해 제어됩니다.

**프레젠테이션 로드 중에 BLOB 처리 규칙은 어디서 설정합니까?**

[LoadOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/)와 [BlobManagementOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/blobmanagementoptions/)를 사용합니다. 여기에서 BLOB의 메모리 내 한도, 임시 파일 허용 여부, 임시 파일 루트 경로, 소스 잠금 동작 등을 설정합니다.

**BLOB 설정이 성능에 영향을 미치며, 속도와 메모리 사이의 균형을 어떻게 맞추나요?**

예. BLOB을 메모리에 보관하면 속도가 최대화되지만 RAM 사용량이 증가합니다. 메모리 제한을 낮추면 작업이 더 많이 임시 파일로 전환되어 RAM은 줄어들지만 추가 I/O가 발생합니다. [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/ko/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) 메서드를 사용해 워크로드와 환경에 맞는 적절한 균형을 맞출 수 있습니다.

**극히 큰 프레젠테이션(예: 기가바이트 규모)을 열 때 BLOB 옵션이 도움이 되나요?**

예. [BlobManagementOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/blobmanagementoptions/)는 이러한 상황을 위해 설계되었습니다. 임시 파일을 활성화하고 소스 잠금을 사용하면 피크 RAM 사용량을 크게 줄이고 매우 큰 프레젠테이션의 처리를 안정화할 수 있습니다.

**디스크 파일이 아닌 스트림에서 로드할 때 BLOB 정책을 사용할 수 있나요?**

예. 스트림에도 동일한 규칙이 적용됩니다. 프레젠테이션 인스턴스는 입력 스트림을 소유하고 잠글 수 있으며(선택한 잠금 모드에 따라), 허용되는 경우 임시 파일이 사용되어 처리 중 메모리 사용량을 예측 가능하게 유지합니다.