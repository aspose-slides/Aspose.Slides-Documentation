---
title: Python via Java에서 프레젠테이션을 XAML으로 내보내기
linktitle: 프레젠테이션을 XAML으로
type: docs
weight: 30
url: /ko/python-java/export-to-xaml/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- PowerPoint를 XAML으로
- OpenDocument를 XAML으로
- 프레젠테이션을 XAML으로
- PPT를 XAML으로
- PPTX를 XAML으로
- ODP를 XAML으로
- PPT를 XAML로 저장
- PPTX를 XAML로 저장
- ODP를 XAML로 저장
- PPT를 XAML으로 내보내기
- PPTX를 XAML으로 내보내기
- ODP를 XAML으로 내보내기
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 XAML으로 내보냅니다. 기본 옵션을 사용하거나 숨겨진 슬라이드를 포함할 수 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션을 XAML로 내보내는 방법을 설명합니다. XAML에 대한 간략한 소개와 기본 설정으로 프레젠테이션을 XAML에 저장하는 방법, 숨겨진 슬라이드를 포함한 내보내기를 사용자 지정하는 방법을 [XamlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xamloptions/)를 통해 보여줍니다. 또한 폰트 폴백, XAML 스택 호환성, 숨겨진 슬라이드 내보내기 동작과 관련된 일반적인 질문에도 답변합니다.

예제는 Aspose.Slides for Python via Java와 호환되는 Java 런타임이 필요합니다. `pres.pptx` 파일을 현재 작업 디렉터리에 배치하십시오. 각 예제는 JVM이 아직 실행 중이 아니면 JVM을 시작합니다.

## **XAML 소개**

XAML은 XML 기반 마크업 언어로 WPF(Windows Presentation Foundation), UWP(Universal Windows Platform), Xamarin.Forms와 같은 프레임워크에서 사용자 인터페이스를 정의하는 데 사용됩니다.

시각적 디자이너에서 XAML 파일을 작업하거나 마크업을 직접 작성·편집할 수 있습니다.

## **기본 옵션으로 프레젠테이션을 XAML로 내보내기**

다음 Python 예제는 기본 설정으로 프레젠테이션을 XAML로 내보내는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

기본적으로 내보낸 슬라이드는 프로세스 현재 작업 디렉터리의 `pres` 하위 폴더에 저장됩니다. 폴더는 자동으로 생성되며 필요한 이미지도 해당 폴더에 저장됩니다.

출력 폴더 이름은 원본 파일 이름에서 확장자를 제외한 값으로 지정됩니다. `pres.pptx`의 경우 출력 파일은 `pres/Slide_1.xaml`, `pres/Slide_2.xaml` 등으로 명명됩니다. 입력 프레젠테이션에 절대 경로를 전달하더라도 출력 폴더는 현재 작업 디렉터리를 기준으로 생성되며, 입력 파일 옆에 생성되지 않습니다.

## **사용자 지정 옵션으로 프레젠테이션을 XAML로 내보내기**

[XamlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xamloptions/) 클래스를 사용하여 Aspose.Slides가 프레젠테이션을 XAML로 내보내는 방식을 제어할 수 있습니다.

출력 위치를 사용자 지정하려면 `IXamlOutputSaver`를 구현하고 해당 구현 인스턴스를 [setOutputSaver](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xamloptions/#setOutputSaver) 메서드에 전달하십시오.

숨겨진 슬라이드를 XAML 출력에 포함하려면 아래 Python 예제와 같이 `True`를 인수로 하여 [setExportHiddenSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xamloptions/#setExportHiddenSlides)를 호출합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **생성된 모든 XAML 아티팩트 캡처하기**

XAML 내보내기는 각 슬라이드마다 XAML 문서와 별도의 이미지·리소스를 생성할 수 있습니다. 기본 파일 시스템 저장소 대신 이러한 아티팩트를 받으려면 [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xamloptions/#setOutputSaver)에 사용자 지정 `IXamlOutputSaver`를 지정하십시오. XAML 옵션을 accepting 하는 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 오버로드를 사용해 내보내기를 시작합니다.

Python에서는 `jpype.JProxy`를 사용해 Java `IXamlOutputSaver` 인터페이스를 구현합니다. 콜백 경로를 `str`로 변환하고 Java 바이트 배열을 Python `bytes`로 복사한 뒤 반환합니다. 아래 예제를 참고하십시오.

### **콜백 수명 주기 이해하기**

내보내기 엔진은 생성된 각 아티팩트마다 `IXamlOutputSaver.save`를 개별적으로 호출합니다:

- `path`는 아티팩트를 식별하며 상대 디렉터리를 포함할 수 있습니다. XAML이 상대 경로를 사용해 리소스를 참조할 수 있으므로 이 정보를 유지하십시오.
- `data`는 아티팩트의 바이트 데이터를 담고 있습니다. 이미지와 기타 바이너리 리소스는 텍스트로 디코딩해서는 안 됩니다.
- 저장소는 데이터를 반환하기 전에 보관하거나 영구 저장해야 합니다. 예제에서는 각 바이트 배열을 애플리케이션이 소유한 메모리로 복사합니다.
- 프레젠테이션 저장 작업이 반환되고 모든 콜백이 성공적으로 완료될 때만 내보내기를 성공으로 간주하십시오. 저장 오류를 무시하거나 백그라운드 쓰기를 감시하지 마십시오. 지속성이 이후에 이루어지는 경우에도 그 단계가 성공해야 전체 성공으로 보고하십시오.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xamloptions/#setExportHiddenSlides)도 사용자 지정 저장소에 적용됩니다. 기본값 `False`는 숨겨진 슬라이드의 XAML 문서를 제외합니다. `True`를 전달하면 숨겨진 슬라이드와 해당 내보내기에 필요한 모든 리소스가 포함됩니다. 리소스 수는 프레젠테이션에 따라 달라지므로 슬라이드당 하나의 콜백이나 고정된 콜백 순서를 가정하지 마십시오.

### **메모리로 내보내고 아티팩트 검사하기**

다음 완전한 예제는 `pres.pptx`를 로드하고 모든 아티팩트를 이름과 불변 `bytes` 값 형태의 Python 사전에 수집한 뒤 이름, 유형, 바이트 수를 출력합니다. 제공된 이름을 그대로 유지합니다. 중복 이름이 있으면 컬렉션을 무효화하고 조용히 덮어쓰지 않습니다. 예제는 이를 확인한 후 결과를 사용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # XAML만 디코드하고, 텍스트 검사가 필요할 때만 디코드합니다.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

확장자 검사는 검증에 유용하므로 모든 아티팩트를 보존하고, 익숙하지 않은 리소스 유형도 포함하십시오. 바이트를 저장하거나 전송할 때는 그대로 유지하고, 텍스트 처리가 필요한 XAML에만 UTF‑8로 `bytes.decode`하십시오.

### **수집된 아티팩트를 ZIP 압축 파일에 패키징하기**

이 독립 예제는 내보내기를 수집하고, 이름을 검증한 뒤 원본 바이트를 ZIP 압축 파일에 기록합니다. 고유한 압축 파일 이름은 동시 내보내기 작업을 구분합니다. ZIP 엔트리는 슬래시(`/`)를 사용하고 상대 디렉터리를 유지합니다. 비정상적인 이름이나 정규화 후 충돌하는 이름은 전체 패키지를 기록하기 전에 거부합니다.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # 닫기를 수행하면 성공이 보고되기 전에 ZIP 디렉터리가 최종화됩니다.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

예제는 Python `zipfile.ZipFile`을 사용해 로컬 압축 파일을 작성합니다; 내보내기 엔진 자체는 느슨한 XAML·이미지 파일을 쓰지 않습니다. 원격 저장소에 저장하려면 압축 단계 대신 수집된 바이트 배열을 업로드하도록 교체하십시오. 내보내기 작업 식별자와 전체 상대 아티팩트 이름을 블롭 키로 사용하거나, 작업 식별자·상대 이름·바이너리 데이터를 데이터베이스 행에 저장하십시오. 모든 업로드가 완료되거나 데이터베이스 트랜잭션이 커밋된 후에 작업을 공개하고, 지속성이 실패하면 부분 출력을 정리하십시오.

대용량 프레젠테이션의 경우 사용자 지정 저장소가 각 아티팩트를 직접 애플리케이션 저장소에 영구 저장하도록 구현하면 전체 내보내기를 메모리에 복제하지 않아도 됩니다. 내보내기 측면에서 각 콜백을 동기식으로 유지하고, 목적지가 바이트를 수락한 후에만 반환하며, 실패가 호출자에게 전달되도록 하십시오.

### **리소스 이름 보존 및 참조 검증하기**

- 대상이 경로 구분자를 정규화해야 할 경우 정규화하되, 상대 디렉터리는 유지하십시오. 모든 생성된 이름이 고유하고 리소스 참조가 유효하다는 것이 보장될 때만 `pathlib.Path.name`만 사용하십시오.
- 대상별 이름 검증을 적용하십시오. 느슨한 파일을 쓸 때는 루트 경로나 경로 탐색 구문을 거부하고, `pathlib.Path.resolve`를 사용해 목적지를 확인한 뒤, 의도한 내보내기 디렉터리 아래에 있는지(디렉터리 구분자를 포함한 containment 체크) 확인하십시오. 심볼릭 링크가 쓰기를 리다이렉트할 수 없는 애플리케이션 제어 디렉터리를 사용하십시오.
- 각 내보내기 작업마다 별도 저장소와 네임스페이스를 사용하십시오. 구분자 정규화 및 대상의 대소문자 민감도 규칙에 따라 충돌을 감지하십시오.
- 공개 전에 각 XAML 문서를 XML로 파싱하고 `Source`·`ImageSource`와 같은 파일 기반 리소스 참조를 검사하십시오. 해당 XAML 아티팩트 디렉터리를 기준으로 각 상대 URI를 해결하고, 결과 저장 이름을 정규화한 뒤, 매핑 키·ZIP 엔트리·저장 객체가 존재하는지 확인하십시오. 외부 URI와 XAML 마크업 표현식은 상대 파일 이름과 별도로 처리하십시오.

예를 들어 `pres/Slide_1.xaml`이 `images/image1.png`를 참조한다면 저장된 리소스는 `pres/images/image1.png`에 있어야 합니다. 단순히 `image1.png`만 보관하면 관계가 깨집니다. 객체 저장소의 경우 작업 접두사 아래에 동일한 레이아웃을 유지하고, 해당 리소스 URL을 XAML 소비자가 접근할 수 있게 하십시오. 완성된 ZIP을 다시 열어 엔트리 이름·리소스 바이트를 검증하고, 대상 XAML 환경에서 대표 슬라이드를 로드해 이미지가 올바르게 해석되는지 확인하십시오.

## **FAQ**

**원본 폰트가 머신에 없을 경우 예측 가능한 폰트를 보장하려면 어떻게 해야 하나요?**

[XamlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xamloptions/)에서 `setDefaultRegularFont`를 호출하십시오 — 이는 원본 폰트가 없을 때 내보내기 중 폴백 폰트로 사용됩니다. 이것이 생성된 XAML이 폴백 폰트를 참조하거나 해당 폰트가 대상 머신에 존재한다는 것을 보장하지는 않습니다. XAML이 표시되는 환경에 폰트가 존재하도록 하십시오.

**내보낸 XAML이 WPF 전용인가요, 아니면 다른 XAML 스택에서도 사용할 수 있나요?**

Aspose.Slides는 공개 API를 통해 WPF XAML을 내보냅니다. UWP, Xamarin.Forms와 같은 다른 XAML 스택에 대한 호환성은 보장되지 않으므로 대상 환경에서 생성된 마크업을 테스트하십시오.

**숨겨진 슬라이드가 지원되나요? 기본적으로 숨겨진 슬라이드가 내보내지지 않도록 하려면 어떻게 해야 하나요?**

기본값으로 숨겨진 슬라이드는 포함되지 않습니다. [XamlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xamloptions/)의 `setExportHiddenSlides`를 비활성화 상태로 유지하면 숨겨진 슬라이드가 내보내지지 않습니다.