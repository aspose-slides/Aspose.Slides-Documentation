---
title: Python으로 프레젠테이션을 XAML로 내보내기
linktitle: 프레젠테이션을 XAML로
type: docs
weight: 30
url: /ko/python-net/export-to-xaml/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- PowerPoint를 XAML로
- OpenDocument를 XAML로
- 프레젠테이션을 XAML로
- PPT를 XAML로
- PPTX를 XAML로
- ODP를 XAML로
- PPT를 XAML로 저장
- PPTX를 XAML로 저장
- ODP를 XAML로 저장
- PPT를 XAML로 내보내기
- PPTX를 XAML로 내보내기
- ODP를 XAML로 내보내기
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용한 Python으로 PowerPoint 및 OpenDocument 슬라이드를 XAML로 변환합니다—빠르고 Office 없이 레이아웃을 그대로 유지하는 솔루션입니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 XAML로 내보내는 방법을 설명합니다. XAML에 대한 간략한 소개와 기본 설정으로 프레젠테이션을 XAML로 저장하는 방법, 숨겨진 슬라이드 내보내기를 포함한 [XamlOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export.xaml/xamloptions/)을 통해 내보내기를 사용자 지정하는 방법을 보여줍니다. 또한 대체 글꼴, XAML 스택 호환성 및 숨겨진 슬라이드 내보내기 동작과 관련된 몇 가지 일반적인 질문에 답변합니다.

## **XAML에 대하여**

XAML은 WPF(Windows Presentation Foundation), UWP(Universal Windows Platform), Xamarin.Forms와 같은 프레임워크에서 사용자 인터페이스를 설명하는 XML 기반 마크업 언어입니다.

시각 디자이너에서 XAML 파일을 작업하거나 마크업을 직접 작성·편집할 수 있습니다.

## **기본 옵션으로 XAML에 프레젠테이션 내보내기**

다음 Python 예제는 기본 설정으로 프레젠테이션을 XAML로 내보내는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

기본적으로 내보낸 슬라이드는 프로세스의 현재 작업 디렉터리(`os.getcwd`가 반환함)의 `pres` 하위 폴더에 저장됩니다. 폴더는 자동으로 생성되며 필요한 이미지도 거기에 저장됩니다.

출력 폴더 이름은 확장자를 제외한 원본 파일 이름에서 가져옵니다. `pres.pptx`의 경우 출력 파일은 `pres/Slide_1.xaml`, `pres/Slide_2.xaml` 등으로 이름이 지정됩니다. 입력 프레젠테이션에 절대 경로를 전달하더라도 출력 폴더는 현재 작업 디렉터리를 기준으로 생성되며, 입력 파일과 동일한 위치에 생성되지 않습니다.

## **사용자 지정 옵션으로 XAML에 프레젠테이션 내보내기**

[XamlOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export.xaml/xamloptions/) 클래스를 사용하여 Aspose.Slides가 프레젠테이션을 XAML로 내보내는 방식을 제어합니다.

숨겨진 슬라이드를 XAML 출력에 포함하려면 [export_hidden_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) 속성을 `True` 로 설정합니다. 아래 Python 예제를 참고하세요:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **생성된 모든 XAML 아티팩트 포착**

XAML 내보내기는 내보낸 각 슬라이드에 대한 XAML 문서와 별도의 이미지 및 지원 리소스를 생성할 수 있습니다. 내보내기를 저장하거나 전송할 때 이러한 파일을 모두 보존하십시오.

아래 예제는 임시 디렉터리에서 기본 파일 시스템 저장자를 사용한 뒤 생성된 파일을 수집합니다.

### **내보내기 수명 주기 이해**

- XAML 옵션을 받아들이는 XAML 전용 [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/) 오버로드로 내보내기를 시작합니다. 성공적으로 반환된 후에만 생성된 파일을 읽습니다.
- XAML이 상대 경로를 사용해 리소스를 참조할 수 있으므로 각 아티팩트의 상대 경로를 보존합니다.
- 아티팩트를 바이트 단위로 읽습니다. 이미지 및 기타 이진 리소스는 텍스트로 디코딩하면 안 됩니다.
- 수집 및 이후 저장 작업이 모두 완료된 후에만 전체 성공을 보고합니다. 저장 오류는 호출자에게 전달하고, 영구 저장이 실패하면 부분 출력을 정리합니다.

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) 기본값은 `False`이며, 이 경우 숨겨진 슬라이드의 XAML 문서는 제외됩니다. `True` 로 설정하면 숨겨진 슬라이드와 그 내보내기에 필요한 모든 리소스가 포함됩니다. 리소스 수는 프레젠테이션에 따라 다르므로 슬라이드당 하나의 파일이라고 가정하지 마세요.

{{% alert color="warning" title="Warning" %}}
예제는 프로세스의 현재 작업 디렉터리를 일시적으로 변경하므로 모든 스레드에 영향을 미칩니다. 각 내보내기를 전용 워커 프로세스에서 실행하거나, 내보내기 중에 현재 디렉터리에 의존하는 다른 작업이 없도록 하십시오. 고유한 임시 디렉터리만으로 동일 프로세스에서 동시 내보내기가 안전해지는 것은 아닙니다.
{{% /alert %}}

### **메모리로 내보내고 아티팩트 검사**

이 완전한 예제는 `pres.pptx`를 로드하고, 임시 디렉터리로 내보낸 뒤, 모든 아티팩트를 상대 이름과 바이트를 가진 사전으로 수집하고, 이름·형식·바이트 수를 출력합니다. 생성된 디렉터리 구조를 보존하고 수집 후에 임시 파일을 삭제합니다. 입력 경로는 작업 디렉터리를 변경하기 전에 해결됩니다.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # XAML만 디코딩하고, 텍스트 검사가 필요할 때만.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

확장자 검사는 검토에 유용합니다; 익숙하지 않은 리소스 유형도 모두 보존하십시오. 저장하거나 전송할 때 바이트를 그대로 유지하고, 텍스트 처리가 필요한 XAML만 디코딩하십시오. 이 방법은 임시 디스크 공간과 메모리를 모두 사용하여 수집된 내보내기를 처리합니다.

### **수집된 아티팩트를 ZIP 아카이브에 패키징**

이 독립 예제는 내보내기를 수집하고, 이름을 검증한 뒤, 원본 바이트를 ZIP 아카이브에 기록합니다. 고유한 아카이브 이름이 내보내기 작업을 구분합니다. ZIP 항목은 슬래시(`/`)를 사용하고 상대 디렉터리를 유지합니다. 정규화 후 충돌하거나 비안전한 이름은 전체 패키지를 기록하기 전에 거부됩니다.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # 성공을 보고하기 전에 ZIP 디렉터리가 최종화되었습니다.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

예제는 [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile)을 사용해 임시 내보내기를 수집한 뒤 로컬 아카이브 하나를 기록합니다. 원격 저장소의 경우, 아카이브 기록 단계를 수집된 바이트 업로드로 교체하십시오. export-job 식별자와 전체 상대 아티팩트 이름을 객체 키로 사용하거나, 작업 식별자·상대 이름·바이너리 데이터를 데이터베이스 행에 저장하십시오. 모든 업로드가 완료되거나 데이터베이스 트랜잭션이 커밋된 후에만 작업을 게시하고, 영구 저장이 실패하면 부분 출력을 정리합니다.

대용량 프레젠테이션의 경우, 내보낸 후 모든 바이트를 사전에 수집하는 대신 파일을 하나씩 처리하십시오. 이렇게 하면 전체 내보내기의 추가 메모리 복사를 방지하지만, 내보내기 자체의 메모리 요구사항은 사라지지 않습니다.

### **리소스 이름 보존 및 참조 검증**

- 대상이 요구하는 경우 경로 구분자를 정규화하되, 상대 디렉터리는 보존합니다. 모든 생성된 이름이 고유하고 리소스 참조가 유효하다는 것이 확실할 때만 파일 이름만 유지하십시오.
- 대상별 이름 검증을 적용합니다. 느슨한 파일을 기록할 때 절대 경로나 경로 탐색 세그먼트를 거부하고, 대상을 해결한 뒤 의도된 내보내기 디렉터리 아래에 머무는지 확인합니다. 심볼릭 링크가 없는 애플리케이션 제어 디렉터리를 사용하십시오.
- 각 내보내기 작업마다 별도 저장 네임스페이스를 사용합니다. 구분자 정규화 후와 대상의 대소문자 구분 규칙에 따라 충돌을 탐지합니다.
- 게시하기 전에 각 XAML 문서를 XML로 파싱하고 이미지 `Source` 또는 `ImageSource` 속성과 같은 파일 기반 리소스 참조를 검사합니다. 각 상대 URI를 해당 XAML 아티팩트 디렉터리에 대해 해결하고, 결과 저장 이름을 정규화한 뒤, 사전 키·ZIP 항목·저장 객체가 존재하는지 확인합니다. 외부 URI와 XAML 마크업 표현식은 상대 파일 이름과 별도로 처리하십시오.

예를 들어 `pres/Slide_1.xaml`이 `images/image1.png`를 참조한다면, 저장된 리소스는 `pres/images/image1.png` 위치에 있어야 합니다. `image1.png`만 보존하면 관계가 깨집니다. 객체 저장소의 경우 작업 접두사 아래 동일 레이아웃을 보존하고 해당 리소스 URL을 XAML 소비자가 접근할 수 있게 하십시오. 완성된 ZIP을 다시 열어 항목 이름과 리소스 바이트를 검증하고, 대상 XAML 환경에서 대표 슬라이드를 로드해 이미지가 올바르게 해석되는지 확인하십시오.

## **FAQ**

**원본 글꼴이 머신에 없을 경우 예측 가능한 글꼴을 보장하려면 어떻게 해야 하나요?**

[XamlOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export.xaml/xamloptions/)의 [default_regular_font](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/)을 설정하십시오. 원본이 없을 때 내보내기 중에 대체 글꼴로 사용됩니다. 이 설정이 생성된 XAML이 대체 글꼴을 참조하거나 목표 머신에 해당 글꼴이 존재한다는 것을 보장하지는 않습니다. XAML에서 참조하는 글꼴이 표시되는 환경에 존재하도록 하세요.

**내보내진 XAML이 WPF 전용인가요, 아니면 다른 XAML 스택에서도 사용할 수 있나요?**

Aspose.Slides는 공개 API를 통해 WPF XAML을 내보냅니다. UWP, Xamarin.Forms 등 다른 XAML 스택에 대한 호환성은 보장되지 않으며, 대상 환경에서 생성된 마크업을 테스트해야 합니다.

**숨겨진 슬라이드가 지원되나요? 기본적으로 숨겨진 슬라이드가 내보내지지 않도록 하려면 어떻게 해야 하나요?**

기본값으로 숨겨진 슬라이드는 포함되지 않습니다. [export_hidden_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/)를 사용해 동작을 제어할 수 있습니다—숨겨진 슬라이드를 내보낼 필요가 없으면 비활성화 상태로 두세요.