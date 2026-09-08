---
title: Python via Java에서 효율적인 메모리 사용을 위한 프레젠테이션 BLOB 관리
linktitle: BLOB 관리
type: docs
weight: 10
url: /ko/python-java/manage-blob/
keywords:
- 대형 객체
- 대형 항목
- 대용량 파일
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
- Python
- Java
- Aspose.Slides
description: "Python via Java용 Aspose.Slides에서 BLOB 데이터를 관리하여 PowerPoint 및 OpenDocument 파일 작업을 간소화하고 효율적인 프레젠테이션 처리를 가능하게 합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션의 대용량 이진 데이터를 BLOB 기반으로 처리하여 큰 이미지, 오디오, 비디오 및 프레젠테이션 파일을 다룰 때 메모리 사용량을 줄이는 데 도움을 줍니다.

이 문서에서는 BLOB 기반 처리를 사용하여 프레젠테이션에 대용량 미디어를 추가하고, 프레젠테이션에서 대용량 미디어를 내보내며, 대용량 프레젠테이션을 보다 효율적으로 로드하는 방법을 보여줍니다. 또한 처리 중에 임시 파일을 사용하는 방법과 임시 파일을 저장할 폴더를 변경하는 방법도 설명합니다.

## **BLOB에 대하여**

**BLOB** (**Binary Large Object**)는 일반적으로 이진 형식으로 저장된 큰 항목(사진, 프레젠테이션, 문서 또는 미디어)입니다.

Aspose.Slides for Python via Java를 사용하면 대용량 파일을 다룰 때 메모리 사용량을 줄이는 방식으로 객체에 BLOB을 사용할 수 있습니다.

{{% alert color="info" title="참고" %}}
스트림과 상호 작용할 때 특정 제한을 우회하기 위해 Aspose.Slides는 스트림의 내용을 복사할 수 있습니다. 스트림을 통해 대용량 프레젠테이션을 로드하면 프레젠테이션 내용이 복사되어 로드 속도가 느려집니다. 따라서 대용량 프레젠테이션을 로드하려는 경우 스트림이 아닌 프레젠테이션 파일 경로를 사용하는 것을 강력히 권장합니다.
{{% /alert %}}

## **BLOB를 사용하여 메모리 사용량 감소**

### **BLOB를 통해 프레젠테이션에 큰 파일 추가**

[Aspose.Slides](/slides/ko/python-java/) for Python via Java를 사용하면 메모리 사용량을 줄이기 위해 BLOB 프로세스를 통해 큰 파일(예: 대용량 비디오 파일)을 프레젠테이션에 추가할 수 있습니다.

다음 Python 코드는 BLOB 프로세스를 통해 큰 비디오 파일을 프레젠테이션에 추가하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# 비디오를 추가할 새로운 프레젠테이션을 생성합니다.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        #        비디오 파일에 접근할 의도가 없으므로 스트림을 잠금 상태로 유지합니다.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        #        메모리 사용량을 낮게 유지하면서 프레젠테이션을 저장합니다.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **BLOB를 통해 프레젠테이션에서 큰 파일 내보내기**

Aspose.Slides for Python via Java를 사용하면 BLOB 프로세스를 통해 프레젠테이션에서 큰 파일(예: 오디오 또는 비디오 파일)을 내보낼 수 있습니다. 예를 들어 프레젠테이션에서 대용량 미디어 파일을 추출해야 하지만 파일을 컴퓨터 메모리에 로드하고 싶지 않을 때 BLOB 프로세스를 통해 내보내면 메모리 사용량을 낮게 유지할 수 있습니다.

다음 Python 코드는 위에서 설명한 작업을 수행합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# 소스 파일을 메모리로 로드하는 대신 잠급니다.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # 메모리 사용량을 낮게 유지하기 위해 버퍼를 통해 비디오 데이터를 전송합니다.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # 전체 비디오를 바이트 배열로 로드하는 대신 스트림을 사용합니다.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # 필요한 경우 오디오 파일에도 동일한 단계를 적용합니다.
finally:
    presentation.dispose()
```

### **이미지를 BLOB로 프레젠테이션에 추가**

[ImageCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagecollection/) 클래스의 메서드를 사용하면 큰 이미지를 스트림으로 추가하여 BLOB로 처리할 수 있습니다.

다음 Python 코드는 BLOB 프로세스를 통해 큰 이미지를 추가하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# 이미지를 추가할 새 프레젠테이션을 생성합니다.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # 이미지 파일에 접근하지 않으므로 스트림을 잠금 상태로 유지합니다.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # 메모리 사용량을 낮게 유지하면서 프레젠테이션을 저장합니다.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **메모리 및 대용량 프레젠테이션**

일반적으로 대용량 프레젠테이션을 로드하려면 컴퓨터에 많은 임시 메모리가 필요합니다. 프레젠테이션의 모든 내용이 메모리로 로드되고, 로드에 사용된 파일은 더 이상 사용되지 않습니다.

예를 들어 1.5 GB 비디오 파일이 포함된 대용량 PowerPoint 프레젠테이션(large.pptx)을 고려해 보십시오. 이 프레젠테이션을 로드하는 표준 방법은 다음 Python 코드에 설명되어 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

하지만 이 방법은 약 1.6 GB의 임시 메모리를 소비합니다.

### **BLOB로 대용량 프레젠테이션 로드**

BLOB 프로세스를 사용하면 적은 메모리로 대용량 프레젠테이션을 로드할 수 있습니다. 다음 Python 코드는 BLOB 프로세스를 사용하여 large.pptx 파일을 로드하는 구현을 설명합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **임시 파일 폴더 변경**

BLOB 프로세스를 사용할 때 컴퓨터는 기본 임시 파일 폴더에 임시 파일을 생성합니다. 임시 파일을 다른 폴더에 보관하려면 [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/ko/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath)를 사용하여 저장 설정을 변경할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="참고" %}}
[BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/ko/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath)를 사용할 경우 Aspose.Slides는 임시 파일을 저장할 폴더를 자동으로 생성하지 않습니다. 폴더를 직접 만들어야 합니다.
{{% /alert %}}

### **프레젠테이션 객체를 해제하여 메모리 해제**

대용량 프레젠테이션을 처리할 때는 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 인스턴스를 적절히 해제하여 차지하고 있던 메모리를 해제해야 합니다. 프레젠테이션 사용을 마친 후 [Presentation.dispose](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#dispose) 메서드를 호출하여 관리되지 않는 리소스를 해제하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...프레젠테이션을 처리합니다...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # 명시적으로 리소스를 해제합니다.
    presentation.dispose()
```

## **FAQ**

**Aspose.Slides 프레젠테이션에서 어떤 데이터가 BLOB로 처리되며 BLOB 옵션에 의해 제어됩니까?**

이미지, 오디오, 비디오와 같은 대용량 이진 객체가 BLOB로 처리됩니다. 프레젠테이션 파일 전체도 로드 또는 저장 시 BLOB 처리를 포함합니다. 이러한 객체는 메모리 사용량을 관리하고 필요 시 임시 파일로 스필하도록 하는 BLOB 정책에 의해 제어됩니다.

**프레젠테이션 로드 중에 BLOB 처리 규칙을 어디서 구성합니까?**

[LoadOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/)와 [BlobManagementOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/blobmanagementoptions/)를 사용합니다. 여기에서 메모리 내 BLOB 제한, 임시 파일 허용 여부, 임시 파일 루트 경로, 소스 잠금 동작 등을 설정합니다.

**BLOB 설정이 성능에 영향을 미치며 속도와 메모리 사용량을 어떻게 균형 맞출 수 있습니까?**

예. 메모리에 BLOB을 유지하면 속도가 최대화되지만 RAM 사용량이 증가합니다. 메모리 제한을 낮추면 더 많은 작업이 임시 파일로 전환되어 RAM 사용량은 감소하지만 추가 I/O가 발생합니다. 작업 부하와 환경에 맞는 균형을 찾으려면 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ko/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) 메서드를 사용하십시오.

**극도로 큰 프레젠테이션(예: 기가바이트 단위)을 열 때 BLOB 옵션이 도움이 됩니까?**

예. [BlobManagementOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/blobmanagementoptions/)는 이러한 시나리오를 위해 설계되었습니다. 임시 파일을 활성화하고 소스 잠금을 사용하면 피크 RAM 사용량을 크게 줄이고 매우 큰 데크를 안정적으로 처리할 수 있습니다.

**스트림 대신 디스크 파일에서 로드할 때 BLOB 정책을 사용할 수 있습니까?**

예. 동일한 규칙이 스트림에도 적용됩니다. 프레젠테이션 인스턴스는 선택한 잠금 모드에 따라 입력 스트림을 소유하고 잠글 수 있으며, 허용되는 경우 임시 파일이 사용되어 처리 중 메모리 사용을 예측 가능하게 유지합니다.