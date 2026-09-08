---
title: Python via Java에서 프리젠테이션 열기
linktitle: 프리젠테이션 열기
type: docs
weight: 20
url: /ko/python-java/open-presentation/
keywords:
- PowerPoint 열기
- 프리젠테이션 열기
- PPTX 열기
- PPT 열기
- ODP 열기
- 프리젠테이션 로드
- PPTX 로드
- PPT 로드
- ODP 로드
- 보호된 프리젠테이션
- 대용량 프리젠테이션
- 외부 리소스
- 바이너리 객체
- Python
- Java
- Aspose.Slides
description: "Python via Java에서 PowerPoint 및 OpenDocument 프리젠테이션을 여는 방법, 열기 비밀번호 제공, 리소스 로딩 제어, 그리고 Aspose.Slides for Python via Java를 사용한 메모리 사용량 감소 방법을 배웁니다."
---
## **소개**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/ko/python-java/)은 파일 및 스트림에서 PowerPoint 및 OpenDocument 프리젠테이션을 로드할 수 있습니다. 프리젠테이션을 로드한 후에는 구조를 검사하고, 슬라이드를 편집하고, 리소스를 관리하며, 원본 형식이나 다른 지원 형식으로 저장할 수 있습니다.

로드 동작은 [LoadOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/) 클래스를 통해 사용자 지정할 수 있습니다. 예를 들어, 열기 비밀번호를 제공하거나, 대용량 바이너리 객체를 Java 힙 메모리 외부에 보관하고, 외부 리소스를 제어하거나, 삽입된 바이너리 데이터를 생략할 수 있습니다.

## **프리젠테이션 열기**

기존 프리젠테이션을 열려면 파일 경로를 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 생성자에 전달합니다. 사용이 끝난 후 프리젠테이션을 해제하여 파일 핸들, 임시 데이터 및 기타 리소스가 즉시 해제되도록 합니다.

다음 Python 예제는 프리젠테이션을 열고 슬라이드 수를 가져오는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **암호로 보호된 프리젠테이션 열기**

열기 비밀번호는 프리젠테이션 콘텐츠를 암호화합니다. 전체 프리젠테이션을 로드하려면 올바른 비밀번호를 [LoadOptions.setPassword](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setPassword) 에 전달하고 해당 옵션을 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 생성자에 제공하십시오. 비밀번호가 없거나 잘못된 경우 로드에 실패합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

비밀번호 감지, 검증 및 암호화 워크플로에 대해서는 [Password-Protect Presentations](/slides/ko/python-java/password-protected-presentation/) 를 참조하십시오. 암호화된 프리젠테이션이 공개 문서 속성으로 저장된 경우, 해당 속성은 비밀번호 없이 읽을 수 있습니다. 자세한 내용은 [Manage Presentation Properties](/slides/ko/python-java/presentation-properties/) 를 확인하세요.

## **대용량 프리젠테이션 열기**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) 은 이미지, 오디오, 비디오와 같은 대용량 바이너리 객체를 Aspose.Slides가 처리하는 방식을 제어하는 옵션을 반환합니다. 소스 파일을 잠근 상태로 유지하고, 임시 파일을 허용하며, 메모리에 유지되는 BLOB 데이터 양을 제한할 수 있습니다.

다음 Python 코드는 대용량 프리젠테이션(예: 2 GB)을 로드하는 예시를 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) 을 사용하면 프리젠테이션 인스턴스를 해제할 때까지 원본 파일이 잠긴 상태를 유지합니다. 해당 인스턴스가 살아있는 동안 파일을 이동, 덮어쓰기하거나 삭제하지 마세요.

Aspose.Slides는 로드하는 동안 입력 스트림의 내용을 복사할 수 있습니다. 대용량 프리젠테이션의 경우 파일 경로가 일반적으로 스트림보다 효율적입니다. 추가 저장소 및 메모리 관리 옵션은 [Manage BLOBs](/slides/ko/python-java/manage-blob/) 를 참고하십시오.
{{% /alert %}}

## **외부 리소스 제어**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) 은 Java 리소스 로딩 콜백 인터페이스를 구현하는 JPype 프록시를 받습니다. 콜백을 통해 교체 데이터를 제공하거나, 리소스를 재지정하거나, 기본 로더를 사용하거나, 리소스를 건너뛸 수 있습니다. 이는 프리젠테이션에 외부 이미지가 포함되어 있으며 애플리케이션별 보안 또는 저장 규칙에 따라 해결해야 할 때 유용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **삽입된 바이너리 객체 없이 프리젠테이션 로드**

애플리케이션이 필요로 하지 않거나 유지하고 싶지 않은 삽입된 바이너리 데이터가 프리젠테이션에 포함될 수 있습니다. 예시:

- VBA 프로젝트는 [Presentation.getVbaProject](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getVbaProject) 로 접근할 수 있습니다;
- 삽입된 OLE 데이터는 [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) 로 접근할 수 있습니다;
- ActiveX 컨트롤 데이터는 [Control.getActiveXControlBinary](https://reference.aspose.com/slides/ko/python-java/aspose.slides/control/#getActiveXControlBinary) 로 접근할 수 있습니다.

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) 를 `True` 로 설정하면 로드 중에 이러한 바이너리 데이터를 제거합니다. 로드된 프리젠테이션을 저장하여 정제된 결과를 유지하십시오.

이 옵션은 원치 않는 삽입 페이로드 노출을 줄이지만 완전한 악성코드 탐지 또는 콘텐츠 정제 시스템은 아닙니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**파일이 손상되어 열 수 없음을 어떻게 판단할 수 있나요?**

Aspose.Slides는 로드 중에 구문 분석 또는 형식 예외를 발생시킵니다. 잘못된 비밀번호 오류와는 별도로 이 실패를 처리하여 애플리케이션이 원인을 정확히 보고할 수 있도록 합니다.

**필요한 글꼴이 없으면 어떻게 되나요?**

프리젠테이션은 여전히 로드되지만 렌더링 및 내보내기 시 글꼴이 대체될 수 있습니다. 출력이 더 예측 가능하도록 [폰트 대체 구성](/slides/ko/python-java/font-substitution/) 또는 [맞춤 글꼴 제공](/slides/ko/python-java/custom-font/) 을 사용할 수 있습니다.

**프리젠테이션을 로드하면 삽입된 미디어도 함께 로드되나요?**

삽입된 오디오와 비디오는 프리젠테이션 객체 모델을 통해 사용할 수 있게 됩니다. 외부 리소스는 구성된 리소스 로딩 동작에 따라 해결되며, 위치에 접근할 수 없을 경우 사용할 수 없습니다.