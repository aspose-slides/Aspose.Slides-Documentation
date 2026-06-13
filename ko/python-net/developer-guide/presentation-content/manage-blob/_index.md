---
title: 효율적인 메모리 사용을 위한 Python으로 프레젠테이션 BLOB 관리
linktitle: BLOB 관리
type: docs
weight: 10
url: /ko/python-net/manage-blob/
keywords:
- 대형 객체
- 대형 항목
- 대형 파일
- BLOB 추가
- BLOB 내보내기
- 이미지를 BLOB로 추가
- 메모리 감소
- 메모리 사용량
- 대형 프레젠테이션
- 임시 파일
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET에서 BLOB 데이터를 관리하여 PowerPoint 및 OpenDocument 파일 작업을 간소화하고 효율적인 프레젠테이션 처리를 구현합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 대용량 이미지, 오디오, 비디오 및 프레젠테이션 파일과 같은 큰 이진 데이터를 처리할 때 메모리 사용량을 줄이기 위해 BLOB 기반 처리를 제공합니다.

이 문서는 BLOB 기반 처리를 사용하여 프레젠테이션에 대용량 미디어를 추가하고, 프레젠테이션에서 대용량 미디어를 내보내며, 대용량 프레젠테이션을 보다 효율적으로 로드하는 방법을 보여줍니다. 또한 처리 중에 임시 파일을 사용할 수 있는 방법과 임시 파일이 저장되는 폴더를 변경하는 방법도 설명합니다.

## **BLOB에 대하여**

**BLOB** (**Binary Large Object**)는 일반적으로 사진, 프레젠테이션, 문서 또는 미디어와 같은 큰 항목을 바이너리 형식으로 저장한 것입니다. 

Aspose.Slides for Python via .NET는 대용량 파일이 포함된 경우 메모리 사용량을 줄이는 방식으로 객체에 BLOB을 사용할 수 있게 합니다. 

## **메모리 사용량 감소를 위한 BLOB 사용**

### **BLOB을 통해 대용량 파일을 프레젠테이션에 추가**

[Aspose.Slides](/slides/ko/python-net/) for .NET는 메모리 사용량을 낮추기 위해 BLOB을 사용하는 프로세스를 통해 대용량 파일(이 경우 큰 비디오 파일)을 추가할 수 있게 합니다.

다음 Python 예제는 BLOB 프로세스를 통해 큰 비디오 파일을 프레젠테이션에 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# 비디오를 추가할 새 프레젠테이션을 생성합니다
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # 비디오를 프레젠테이션에 추가합니다 - KeepLocked 동작을 선택한 이유는
        # "veryLargeVideo.avi" 파일에 접근할 계획이 없기 때문입니다.
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # 프레젠테이션을 저장합니다. 큰 프레젠테이션이 출력되는 동안에도
        # pres 객체의 전체 수명 동안 메모리 사용량이 낮게 유지됩니다 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **프레젠테이션에서 BLOB을 통해 대용량 파일 내보내기**
Aspose.Slides for Python via .NET는 BLOB을 사용하는 프로세스를 통해 프레젠테이션에서 대용량 파일(예: 오디오 또는 비디오 파일)을 내보낼 수 있게 합니다. 예를 들어, 큰 미디어 파일을 프레젠테이션에서 추출해야 하지만 파일을 컴퓨터 메모리에 로드하고 싶지 않을 경우 BLOB 프로세스를 통해 내보내면 메모리 사용량을 낮게 유지할 수 있습니다. 

다음 Python 코드는 설명된 작업을 시연합니다:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# 각 비디오를 파일에 저장합니다. 높은 메모리 사용을 방지하려면 사용할 버퍼가 필요합니다
	# 프레젠테이션 비디오 스트림의 데이터를 새로 만든 비디오 파일 스트림으로 전송하기 위해서입니다.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# 비디오들을 반복합니다
    index = 0
    # 필요하다면 오디오 파일에도 같은 단계를 적용할 수 있습니다. 
    for video in pres.videos:
		# 프레젠테이션 비디오 스트림을 엽니다. 참고로, 우리는 의도적으로 속성에 접근하는 것을 피했습니다
		# 예: video.BinaryData - 이 속성은 전체 비디오를 포함하는 바이트 배열을 반환하기 때문에
		# 메모리에 바이트가 로드됩니다. 우리는 video.GetStream을 사용합니다. 이는 스트림을 반환하며 - 메모리에 전체 비디오를 로드할 필요가 없습니다
		#  전체 비디오를 메모리에 로드할 필요가 없습니다.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **프레젠테이션에 이미지 BLOB 추가**
[**ImageCollection**](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imagecollection/) 클래스의 메서드를 사용하면 스트림으로 큰 이미지를 추가하여 BLOB로 처리할 수 있습니다. 

다음 Python 코드는 BLOB 프로세스를 통해 큰 이미지를 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides

# 이미지를 추가할 새 프레젠테이션을 생성합니다.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **메모리 및 대용량 프레젠테이션**

일반적으로 대용량 프레젠테이션을 로드하려면 컴퓨터에 많은 임시 메모리가 필요합니다. 프레젠테이션의 모든 콘텐츠가 메모리로 로드되고, 로드된 파일은 더 이상 사용되지 않습니다. 

예를 들어, 1.5 GB 비디오 파일을 포함한 대용량 PowerPoint 프레젠테이션(large.pptx)이 있다고 가정합니다. 이 프레젠테이션을 로드하는 표준 방법은 다음 Python 코드에 나와 있습니다:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

하지만 이 방법은 약 1.6 GB의 임시 메모리를 소비합니다. 

### **BLOB을 사용해 대용량 프레젠테이션 로드**

BLOB을 사용하는 프로세스를 통해 적은 메모리로 대용량 프레젠테이션을 로드할 수 있습니다. 다음 Python 코드는 BLOB 프로세스를 사용해 large.pptx 파일을 로드하는 구현을 설명합니다:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **임시 파일 폴더 변경**

BLOB 프로세스를 사용할 때 컴퓨터는 기본 임시 파일 폴더에 임시 파일을 생성합니다. 임시 파일을 다른 폴더에 보관하려면 `temp_files_root_path`를 사용해 저장 위치를 변경할 수 있습니다:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
`temp_files_root_path`를 사용할 경우 Aspose.Slides가 자동으로 임시 파일 폴더를 생성하지 않습니다. 폴더를 직접 만들어야 합니다.
{{% /alert %}}

### **프레젠테이션 객체를 해제하여 메모리 반환**

대용량 프레젠테이션을 처리할 때는 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 적절히 해제하여 차지하던 메모리를 반환해야 합니다. 권장 방법은 위 예제와 같이 컨텍스트 관리자(`with slides.Presentation(...) as presentation:`)를 사용하는 것이며, 블록이 종료될 때 자동으로 프레젠테이션을 닫고 관리되지 않는 리소스를 해제합니다.

`with` 블록 없이 프레젠테이션을 만든 경우 사용을 마친 뒤 `presentation.dispose()`를 명시적으로 호출하고 남은 참조를 제거하여 Python 가비지 컬렉터가 메모리를 회수하도록 해야 합니다.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...프레젠테이션을 처리합니다...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# 리소스를 명시적으로 해제합니다.
presentation.dispose()
```

## **FAQ**

**Aspose.Slides 프레젠테이션에서 어떤 데이터가 BLOB로 처리되며 BLOB 옵션으로 제어됩니까?**

이미지, 오디오, 비디오와 같은 대용량 이진 객체가 BLOB로 처리됩니다. 프레젠테이션 파일 자체도 로드하거나 저장할 때 BLOB 처리를 포함합니다. 이러한 객체는 메모리 사용량을 관리하고 필요시 임시 파일로 스필하도록 하는 BLOB 정책에 의해 제어됩니다.

**프레젠테이션 로드 중 BLOB 처리 규칙은 어디에서 구성합니까?**

[LoadOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/)와 [BlobManagementOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/blobmanagementoptions/)를 사용합니다. 여기에서 BLOB의 메모리 제한, 임시 파일 허용 여부, 임시 파일 루트 경로, 소스 잠금 동작을 설정합니다.

**BLOB 설정이 성능에 영향을 미치며 속도와 메모리 사용을 어떻게 균형 잡을 수 있습니까?**

예. BLOB을 메모리에 유지하면 속도가 최대화되지만 RAM 사용량이 증가합니다. 메모리 제한을 낮추면 더 많은 작업이 임시 파일로 이동해 RAM 사용량은 줄어들지만 추가 I/O가 발생합니다. 작업 부하와 환경에 맞는 균형을 맞추려면 [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/ko/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) 임계값을 조정하십시오.

**극도로 큰 프레젠테이션(예: 기가바이트 크기)을 열 때 BLOB 옵션이 도움이 됩니까?**

예. [BlobManagementOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/blobmanagementoptions/)는 이러한 시나리오를 위해 설계되었습니다. 임시 파일을 활성화하고 소스 잠금을 사용하면 피크 RAM 사용량을 크게 줄이고 매우 큰 파일의 처리를 안정화할 수 있습니다.

**스트림에서 로드할 때도 BLOB 정책을 사용할 수 있습니까?**

예. 동일한 규칙이 스트림에도 적용됩니다. 프레젠테이션 인스턴스가 입력 스트림을 소유하고 잠글 수 있으며(선택한 잠금 모드에 따라), 허용된 경우 임시 파일이 사용되어 처리 중 메모리 사용을 예측 가능하게 유지합니다.