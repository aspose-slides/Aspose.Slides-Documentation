---
title: Python에서 프레젠테이션 열기
linktitle: 프레젠테이션 열기
type: docs
weight: 20
url: /ko/python-net/open-presentation/
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
- 바이너리 객체
- Python
- Aspose.Slides
description: "Python에서 PowerPoint 및 OpenDocument 프레젠테이션을 여는 방법, 개방 비밀번호를 제공하고, Aspose.Slides for Python via .NET를 사용하여 메모리 사용을 줄이는 방법을 배웁니다."
---
## **소개**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/ko/python-net/)은 파일 및 스트림에서 PowerPoint 및 OpenDocument 프레젠테이션을 로드할 수 있습니다. 프레젠테이션을 로드한 후에는 구조를 검사하고, 슬라이드를 편집하며, 리소스를 관리하고, 원본 형식이나 다른 지원 형식으로 저장할 수 있습니다.

로드 동작은 [LoadOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/) 클래스를 통해 사용자 지정할 수 있습니다. 예를 들어, 개방 비밀번호를 제공하거나, 큰 바이너리 객체를 메모리 외부에 보관하거나, 삽입된 바이너리 데이터를 생략할 수 있습니다.

## **프레젠테이션 열기**

기존 프레젠테이션을 열려면 파일 경로를 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 생성자에 전달하십시오. `with` 문을 사용하면 파일 핸들, 임시 데이터 및 기타 리소스가 즉시 해제됩니다.

다음 Python 예제는 프레젠테이션을 열고 슬라이드 수를 가져오는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **비밀번호로 보호된 프레젠테이션 열기**

개방 비밀번호는 프레젠테이션 내용을 암호화합니다. 전체 프레젠테이션을 로드하려면 올바른 비밀번호를 [LoadOptions.password](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/password/)에 할당하고 해당 옵션을 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 생성자에 전달하십시오. 비밀번호가 없거나 올바르지 않으면 로드가 실패합니다.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

비밀번호 감지, 검증 및 암호화 워크플로에 대해서는 [Password-Protect Presentations](/slides/ko/python-net/password-protected-presentation/)를 참조하십시오. 암호화된 프레젠테이션이 공개 문서 속성을 포함하도록 저장된 경우 해당 속성은 비밀번호 없이 읽을 수 있습니다; 자세한 내용은 [Manage Presentation Properties](/slides/ko/python-net/presentation-properties/)를 확인하십시오.

## **대용량 프레젠테이션 열기**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/blob_management_options/)는 이미지, 오디오 및 비디오와 같은 대용량 바이너리 객체를 Aspose.Slides가 처리하는 방식을 제어합니다. 소스 파일을 잠금 상태로 유지하고, 임시 파일을 허용하며, 메모리에 보관되는 BLOB 데이터 양을 제한할 수 있습니다.

다음 Python 코드는 대용량 프레젠테이션(예: 2 GB)을 로드하는 예시를 보여줍니다:

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
`PresentationLockingBehavior.KEEP_LOCKED`을 사용하면 `Presentation` 객체가 해제될 때까지 소스 파일이 잠긴 상태로 유지됩니다. 해당 객체가 존재하는 동안 소스 파일을 이동, 덮어쓰기 또는 삭제하지 마십시오.

Aspose.Slides는 로드 중에 입력 스트림의 내용을 복사할 수 있습니다. 대용량 프레젠테이션의 경우 파일 경로가 일반적으로 스트림보다 효율적입니다. 추가 저장소 및 메모리 관리 옵션은 [Manage BLOBs](/slides/ko/python-net/manage-blob/)를 참고하십시오.
{{% /alert %}}

## **삽입된 바이너리 객체 없이 프레젠테이션 로드**

프레젠테이션에는 애플리케이션이 필요로 하지 않거나 보관하고 싶지 않은 삽입된 바이너리 데이터가 포함될 수 있습니다. 예시:

- VBA 프로젝트는 [Presentation.vba_project](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/vba_project/)를 통해 사용할 수 있습니다;
- 삽입된 OLE 데이터는 [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/)를 통해 사용할 수 있습니다;
- ActiveX 컨트롤 데이터는 [Control.active_x_control_binary](https://reference.aspose.com/slides/ko/python-net/aspose.slides/control/active_x_control_binary/)를 통해 사용할 수 있습니다.

로드 중에 이 바이너리 데이터를 제거하려면 [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/)를 `True`로 설정하십시오. 정리된 결과를 유지하려면 로드된 프레젠테이션을 저장하십시오.

이 옵션은 원하지 않는 삽입된 페이로드에 대한 노출을 줄이지만, 완전한 악성코드 탐지 또는 콘텐츠 정화 시스템은 아닙니다.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**파일이 손상되어 열 수 없다는 것을 어떻게 알 수 있나요?**

Aspose.Slides는 로드 중에 구문 분석 또는 형식 예외를 발생시킵니다. 이 실패를 비밀번호 오류와 별도로 처리하여 애플리케이션이 원인을 정확히 보고할 수 있도록 하십시오.

**필요한 글꼴이 누락된 경우 어떻게 되나요?**

프레젠테이션은 여전히 로드될 수 있지만, 렌더링 및 내보내기 시 글꼴이 대체될 수 있습니다. 글꼴 대체를 구성하거나 사용자 지정 글꼴을 제공하여 출력이 더 예측 가능하도록 할 수 있습니다.

**프레젠테이션을 로드하면 삽입된 미디어도 로드되나요?**

삽입된 오디오와 비디오는 프레젠테이션 객체 모델을 통해 사용할 수 있게 됩니다. 외부 리소스는 기본 리소스 로딩 동작에 따라 해결되며, 해당 위치에 접근할 수 없으면 사용할 수 없을 수 있습니다.