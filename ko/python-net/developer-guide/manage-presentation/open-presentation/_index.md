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
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint(.pptx, .ppt) 및 OpenDocument(.odp) 프레젠테이션을 손쉽게 열 수 있습니다—빠르고, 안정적이며, 전체 기능을 제공합니다."
---
## **소개**

PowerPoint 프레젠테이션을 처음부터 만드는 것뿐만 아니라, Aspose.Slides는 기존 프레젠테이션을 열 수도 있습니다. 프레젠테이션을 로드한 후에는 해당 정보를 가져오고, 슬라이드 내용을 편집하고, 새 슬라이드를 추가하고, 기존 슬라이드를 제거하는 등 다양한 작업을 할 수 있습니다.

## **프레젠테이션 열기**

기존 프레젠테이션을 열려면 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화하고 파일 경로를 생성자에 전달합니다.

다음 Python 예제는 프레젠테이션을 열고 슬라이드 수를 가져오는 방법을 보여줍니다:

```python
import aspose.slides as slides

# Presentation 클래스를 인스턴스화하고 파일 경로를 생성자에 전달합니다.
with slides.Presentation("sample.pptx") as presentation:
    # 프레젠테이션의 슬라이드 총 수를 출력합니다.
    print(presentation.slides.length)
```

## **암호로 보호된 프레젠테이션 열기**

암호로 보호된 프레젠테이션을 열어야 할 경우, [LoadOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/) 클래스의 [password](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/password/) 속성을 통해 비밀번호를 전달하여 복호화하고 로드합니다. 다음 Python 코드는 이 작업을 보여줍니다:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # 복호화된 프레젠테이션에 대한 작업을 수행합니다.
```

## **큰 프레젠테이션 열기**

Aspose.Slides는 특히 [LoadOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/) 클래스의 [blob_management_options](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/blob_management_options/) 속성과 같은 옵션을 제공하여 큰 프레젠테이션을 로드하는 데 도움을 줍니다.

다음 Python 코드는 큰 프레젠테이션(예: 2 GB)을 로드하는 방법을 보여줍니다:

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# KeepLocked 동작을 선택합니다—프레젠테이션 파일은 객체가 존재하는 동안 잠긴 상태를 유지합니다 
# 프레젠테이션 인스턴스가 잠겨 있지만 메모리에 로드하거나 임시 파일로 복사할 필요가 없습니다.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # 큰 프레젠테이션이 로드되었으며 메모리 사용량이 낮은 상태로 사용할 수 있습니다.

    # 프레젠테이션을 수정합니다.
    presentation.slides[0].name = "Large presentation"

    # 프레젠테이션을 다른 파일에 저장합니다. 이 작업 중에도 메모리 사용량이 낮게 유지됩니다.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # 이렇게 하지 마세요! 프레젠테이션 객체가 해제될 때까지 파일이 잠겨 있어 I/O 예외가 발생합니다.
    os.remove(file_path)

# 여기서 수행해도 괜찮습니다. 소스 파일이 더 이상 프레젠테이션 객체에 의해 잠겨 있지 않습니다.
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}
스트림 작업 시 특정 제한을 우회하기 위해 Aspose.Slides가 스트림 내용을 복사할 수 있습니다. 스트림에서 큰 프레젠테이션을 로드하면 프레젠테이션이 복사되어 로드 속도가 느려질 수 있습니다. 따라서 큰 프레젠테이션을 로드해야 할 때는 스트림 대신 프레젠테이션 파일 경로를 사용하는 것을 강력히 권장합니다.

동영상, 오디오, 고해상도 이미지 등 큰 객체를 포함한 프레젠테이션을 만들 때는 [BLOB management](/slides/ko/python-net/manage-blob/)을 사용하여 메모리 사용량을 줄일 수 있습니다.
{{%/alert %}}

## **임베디드 바이너리 객체 없이 프레젠테이션 로드하기**

PowerPoint 프레젠테이션에는 다음 유형의 임베디드 바이너리 객체가 포함될 수 있습니다:
- VBA 프로젝트 ( [Presentation.vba_project](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/vba_project/) 로 접근 가능);
- OLE 객체 임베디드 데이터 ( [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) 로 접근 가능);
- ActiveX 컨트롤 바이너리 데이터 ( [Control.active_x_control_binary](https://reference.aspose.com/slides/ko/python-net/aspose.slides/control/active_x_control_binary/) 로 접근 가능).

[LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) 속성을 사용하면 임베디드 바이너리 객체가 전혀 없는 상태로 프레젠테이션을 로드할 수 있습니다.

이 속성은 잠재적으로 악성인 바이너리 콘텐츠를 제거하는 데 유용합니다. 다음 Python 코드는 임베디드 바이너리 콘텐츠 없이 프레젠테이션을 로드하는 방법을 보여줍니다:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # 프레젠테이션에 대한 작업을 수행합니다.
```

## **FAQ**

**How can I tell that a file is corrupted and can’t be opened?**

파일이 손상되어 열 수 없다는 것을 어떻게 확인할 수 있나요?

로드 중에 구문/형식 검증 예외가 발생합니다. 이러한 오류는 종종 잘못된 ZIP 구조나 손상된 PowerPoint 레코드를 언급합니다.

**What happens if required fonts are missing when opening?**

열 때 필요한 글꼴이 누락되면 어떻게 되나요?

파일은 열리지만 이후 [rendering/export](/slides/ko/python-net/convert-presentation/) 에서 글꼴이 대체될 수 있습니다. 런타임 환경에 [Configure font substitutions](/slides/ko/python-net/font-substitution/) 또는 [add the required fonts](/slides/ko/python-net/custom-font/)를 추가하십시오.

**What about embedded media (video/audio) when opening?**

열 때 임베디드 미디어(동영상/오디오)는 어떻게 되나요?

그들은 프레젠테이션 리소스로 제공됩니다. 미디어가 외부 경로로 참조되는 경우 해당 경로가 환경에서 접근 가능하도록 확인하십시오; 그렇지 않으면 [rendering/export](/slides/ko/python-net/convert-presentation/) 에서 미디어가 누락될 수 있습니다.