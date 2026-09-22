---
title: Python을 통해 Java에서 원본 프레젠테이션 형식 결정
linktitle: 소스 형식
type: docs
weight: 35
url: /ko/python-java/detect-presentation-source-format/
keywords:
- 소스 형식
- 프레젠테이션 형식 탐지
- PowerPoint
- OpenDocument
- 프레젠테이션
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java을 사용하여 Python에서 로드된 프레젠테이션의 원본 형식을 읽고, 탐지 API를 비교하며, 파일, 스트림 및 레거시 형식을 처리합니다."
---
## **개요**

프레젠테이션을 로드한 후, 원래 형식을 확인하려면 [Presentation.getSourceFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSourceFormat) 메서드를 호출합니다. 현재 인스턴스가 로드된 형식에 따라 후속 처리가 달라지는 경우에 사용합니다.

소스 형식은 출력 파일에 선택된 [SaveFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/)과 구별됩니다. 다른 형식으로 저장해도 기존 인스턴스의 소스 형식은 변경되지 않습니다.

예제는 Java를 통한 Python용 Aspose.Slides와 호환되는 Java 런타임이 필요합니다. 각 예제는 JVM이 실행 중이 아니면 시작합니다.

## **파일의 소스 형식 읽기**

이 예제는 기존 `sample.pptx` 파일이 필요합니다. 파일을 로드하고 파일 이름 대신 [Presentation.getSourceFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSourceFormat) 을 사용하여 애플리케이션 처리 정책을 선택합니다. 입력 경로를 변경하면 다른 형식을 시도할 수 있습니다. 예제는 선택된 정책을 출력합니다; 메시지를 여러분의 애플리케이션 로직으로 교체하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **지원되는 값 인식**

[SourceFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sourceformat/) 클래스는 다음 프레젠테이션 형식을 구분하는 정수 상수를 정의합니다. 아래 확장자는 일반적인 확장자이며 원래 파일 이름을 복원한 것이 아닙니다.

| SourceFormat 값 | 확장자 | 형식 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 프레젠테이션 |
| `Pptx` | `.pptx` | Office Open XML 프레젠테이션 |
| `Pptm` | `.pptm` | 매크로 사용 Office Open XML 프레젠테이션 |
| `Pps` | `.pps` | PowerPoint 97–2003 슬라이드 쇼 |
| `Ppsx` | `.ppsx` | Office Open XML 슬라이드 쇼 |
| `Ppsm` | `.ppsm` | 매크로 사용 Office Open XML 슬라이드 쇼 |
| `Pot` | `.pot` | PowerPoint 97–2003 템플릿 |
| `Potx` | `.potx` | Office Open XML 템플릿 |
| `Potm` | `.potm` | 매크로 사용 Office Open XML 템플릿 |
| `Odp` | `.odp` | OpenDocument 프레젠테이션 |
| `Otp` | `.otp` | OpenDocument 프레젠테이션 템플릿 |
| `Fodp` | `.fodp` | Flat XML ODF 프레젠테이션 |
| `Xml` | `.xml` | PowerPoint XML 프레젠테이션 |

## **스트림의 소스 형식 읽기**

이 예제는 기존 `sample.pps` 파일이 필요합니다. 파일 바이트를 메모리 스트림에 읽어 파일 이름 없이 입력을 받는 경우(예: 데이터베이스 값 또는 업로드된 바이트 배열)를 모델링합니다. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 생성자는 스트림만 받습니다. Python은 파일 바이트를 읽고 JPype는 이를 Java 바이트 배열로 변환하여 Java 메모리 스트림에 전달합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS, 및 POT는 동일한 기본 바이너리 형식을 사용합니다. 파일 경로로 로드할 때는 확장자가 슬라이드 쇼인지 템플릿인지 구별하는 데 도움이 될 수 있습니다. 파일 이름이 없으면 레거시 PPS 및 POT 콘텐츠가 `SourceFormat.Ppt` 로 보고될 수 있으며, 위의 PPS 예제는 `SourceFormat.Ppt` 의 정수 값을 출력합니다.

애플리케이션이 이 구분을 유지해야 한다면 원본 파일 이름이나 하위 유형 메타데이터를 별도로 보관하십시오. 확장자는 이러한 레거시 하위 유형에 대한 유용한 힌트이지만 임의의 프레젠테이션 콘텐츠를 식별하는 유일한 기준이 되어서는 안 됩니다.

## **로드 전후 탐지 비교**

파일을 완전한 프레젠테이션 객체 모델로 로드하기 전에 검사해야 할 경우 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 와 [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#getLoadFormat) 를 사용합니다. 인스턴스가 이미 존재하는 경우 [Presentation.getSourceFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSourceFormat) 을 사용합니다.

이 예제는 `sample.pptx` 가 필요하며 `LoadFormat.Pptx` 와 `SourceFormat.Pptx` 의 정수 값을 각각 출력합니다. 실제 운영 환경에서는 처리 단계에 맞는 API를 선택하십시오; 이미 로드된 프레젠테이션은 소스 형식을 얻기 위해 두 번째 검사를 할 필요가 없습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

결과는 서로 다른 클래스의 상수를 사용합니다: [LoadFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadformat/) 과 [SourceFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sourceformat/). 이들의 숫자 값을 비교하거나 모든 형식이 동일한 탐지 결과를 가진다고 가정하지 마십시오. PowerPoint XML은 로드 전에는 `LoadFormat.Unknown` 으로 보고될 수 있지만 로드 후에는 `SourceFormat.Xml` 로 보고됩니다.

## **소스와 출력 형식 분리 유지**

이 예제는 `sample.pptx` 가 필요하며 `converted.odp` 로 저장합니다. 원본 인스턴스를 저장 전후 모두 `SourceFormat.Pptx` 의 정수 값을 출력합니다. ODP 출력에서 새로 로드된 인스턴스만이 `Odp` 를 보고합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

`Presentation()` 으로 처음부터 만든 프레젠테이션은 `SourceFormat.Pptx` 를 보고합니다. 입력 파일이 없기 때문에 이는 새로 만든 인스턴스의 기본값이며 PPTX 파일이 로드되었다는 증거가 아닙니다. 해당 구분이 중요하다면 애플리케이션에서 인스턴스를 생성했는지 로드했는지를 별도로 추적하십시오.

## **소스 형식을 확장자로 매핑**

다음 예제는 `sample.pptx` 가 필요합니다. 현재 지원되는 모든 [SourceFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sourceformat/) 값을 파일 이름을 파싱하지 않고 일반적인 확장자로 매핑합니다. 인식되지 않은 값에 대해 조용히 확장자를 할당하는 것을 방지하기 위해 기본값을 사용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

이 매핑은 파일을 변환하거나 스트림 로드 중에 손실된 레거시 PPS/POT 하위 유형을 복원하지 않습니다. 실제 저장 시에는 [SaveFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/) 을 명시적으로 선택하거나 [원래 형식으로 저장](/slides/ko/python-java/save-presentation/#save-presentations-in-their-original-format) 에 보여진 변환을 사용하십시오.

## **저장 후 다시 열어 형식 확인**

이 독립 실행형 예제는 프레젠테이션을 만든 뒤 작업 디렉터리에 세 개의 파일을 작성하고, 동일한 이름의 파일이 있으면 덮어씁니다. 각 출력 파일을 경로와 메모리 스트림 모두로 다시 엽니다. PPTX와 ODP는 두 경로 모두 저장된 형식을 보고합니다. PPS의 경우 경로로 로드하면 `Pps` 를, 파일 이름 없이 동일한 바이트를 로드하면 `Ppt` 를 보고합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

다음 표는 확장자가 일치하는 프레젠테이션에 대한 소스 형식 식별을 요약합니다. 이름은 상수를 나타내며 Python 예제는 해당 정수 값을 출력합니다:

| 저장 형식 | 파일 경로에서의 SourceFormat | 이름 없는 스트림에서의 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` 각각 | 파일 경로와 동일 |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` 각각 | 파일 경로와 동일 |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` 각각 | 파일 경로와 동일 |
| ODP, OTP | `Odp`, `Otp` 각각 | 파일 경로와 동일 |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT 콘텐츠는 이름 없는 스트림에서는 `Ppt` 로 식별됩니다. 이 표는 형식 식별에 관한 것이며 변환 과정에서 모든 프레젠테이션 기능이 보존된다는 의미는 아닙니다.

## **FAQ**

**ODP로 저장하면 PPTX에서 로드된 프레젠테이션의 소스 형식이 변경됩니까?**

아니요. 기존 인스턴스는 여전히 `Pptx` 를 보고합니다. 저장된 ODP 파일에서 로드된 인스턴스는 `Odp` 를 보고합니다.

**스트림이 레거시 프레젠테이션, 슬라이드 쇼 및 템플릿을 항상 구분할 수 있습니까?**

아니요. PPT, PPS, 및 POT는 동일한 바이너리 형식을 공유합니다. 이러한 구분이 필요할 경우 파일명이나 하위 유형 메타데이터를 별도로 보관하십시오.

**프레젠테이션이 이미 로드된 경우 어떤 API를 사용해야 합니까?**

[Presentation.getSourceFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSourceFormat) 을 읽으십시오. 로드 전에 검사가 필요하면 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 를 사용하십시오.