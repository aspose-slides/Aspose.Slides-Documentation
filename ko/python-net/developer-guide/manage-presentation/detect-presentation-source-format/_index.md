---
title: Python에서 원본 프레젠테이션 형식 확인
linktitle: 소스 형식
type: docs
weight: 35
url: /ko/python-net/detect-presentation-source-format/
keywords:
- 소스 형식
- 프레젠테이션 형식 감지
- 파워포인트
- OpenDocument
- 프레젠테이션
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 Python에서 로드된 프레젠테이션의 원본 형식을 읽고, 감지 API를 비교하며, 파일, 스트림 및 레거시 형식을 처리합니다."
---
## **개요**

프레젠테이션을 로드한 후, 읽기 전용 [Presentation.source_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/source_format/) 속성을 읽어 원본 형식을 확인합니다. 현재 인스턴스가 로드된 형식에 따라 이후 처리에 필요할 때 사용합니다.

소스 형식은 출력 파일에 선택된 [SaveFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/saveformat/)과는 별개입니다. 다른 형식으로 저장해도 기존 인스턴스의 소스 형식은 변경되지 않습니다.

## **파일의 소스 형식 읽기**

이 예제는 기존 `sample.pptx` 파일이 필요합니다. 파일을 로드하고 파일 이름 대신 [Presentation.source_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/source_format/)을 사용하여 애플리케이션 처리 정책을 선택합니다. 다른 형식을 시도하려면 입력 경로를 변경하십시오. 예제는 선택된 정책을 출력합니다; 메시지를 애플리케이션 로직으로 교체하세요.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **지원되는 값 인식**

[SourceFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sourceformat/) 열거형은 다음 프레젠테이션 형식을 구분합니다. 아래 확장자는 원본 파일 이름을 재구성한 것이 아니라 일반적인 확장자입니다.

| SourceFormat 값 | 확장자 | 형식 |
| --- | --- | --- |
| `PPT` | `.ppt` | PowerPoint 97–2003 프레젠테이션 |
| `PPTX` | `.pptx` | Office Open XML 프레젠테이션 |
| `PPTM` | `.pptm` | 매크로 사용 Office Open XML 프레젠테이션 |
| `PPS` | `.pps` | PowerPoint 97–2003 슬라이드 쇼 |
| `PPSX` | `.ppsx` | Office Open XML 슬라이드 쇼 |
| `PPSM` | `.ppsm` | 매크로 사용 Office Open XML 슬라이드 쇼 |
| `POT` | `.pot` | PowerPoint 97–2003 템플릿 |
| `POTX` | `.potx` | Office Open XML 템플릿 |
| `POTM` | `.potm` | 매크로 사용 Office Open XML 템플릿 |
| `ODP` | `.odp` | OpenDocument 프레젠테이션 |
| `OTP` | `.otp` | OpenDocument 프레젠테이션 템플릿 |
| `FODP` | `.fodp` | Flat XML ODF 프레젠테이션 |
| `XML` | `.xml` | PowerPoint XML 프레젠테이션 |

## **스트림의 소스 형식 읽기**

이 예제는 기존 `sample.pps` 파일이 필요합니다. 바이트를 메모리 스트림으로 읽어 들이면 파일 이름 없이 수신된 입력(예: 데이터베이스 값이나 업로드된 바이트 배열)을 모델링합니다. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 생성자는 스트림만 받습니다.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT, PPS, 그리고 POT는 동일한 기본 바이너리 형식을 사용합니다. 파일 경로로 로드할 경우 확장자를 통해 슬라이드 쇼 또는 템플릿을 구분할 수 있습니다. 파일 이름이 없으면 레거시 PPS 및 POT 콘텐츠가 `SourceFormat.PPT`로 보고될 수 있습니다; 위의 PPS 예제도 `PPT`를 보고합니다.

앱에서 구분을 유지해야 한다면 원본 파일 이름이나 서브타입 메타데이터를 별도로 보관하십시오. 확장자는 이러한 레거시 서브타입을 구분하는 유용한 힌트이지만, 임의의 프레젠테이션 콘텐츠를 식별하는 유일한 근거가 되어서는 안 됩니다.

## **로드 전후 감지 비교**

파일을 완전한 프레젠테이션 객체 모델로 로드하기 전에 검사해야 할 때는 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationfactory/get_presentation_info/)와 [PresentationInfo.load_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/load_format/)을 사용합니다. 인스턴스가 이미 존재할 경우 [Presentation.source_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/source_format/)을 사용합니다.

이 예제는 `sample.pptx`가 필요하며 두 검증 모두 `PPTX`를 출력합니다. 실제 환경에서는 처리 단계에 맞는 API를 선택하십시오; 이미 로드된 프레젠테이션은 소스 형식을 얻기 위해 두 번째 검사를 할 필요가 없습니다.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

결과는 서로 다른 열거형 타입을 가집니다: [LoadFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadformat/)와 [SourceFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sourceformat/). 숫자 값을 캐스팅해 비교하거나 모든 형식이 동일한 감지 결과를 갖는다고 가정하지 마십시오. 아래에 설명된 저장‑재열기 검사에서는 PowerPoint XML이 로드 전에는 `LoadFormat.UNKNOWN`으로, 로드 후에는 `SourceFormat.XML`으로 보고되었습니다.

## **소스와 출력 형식 분리 유지**

이 예제는 `sample.pptx`가 필요하고 `converted.odp`를 씁니다. 원본 인스턴스를 저장 전후 모두 `PPTX`를 출력합니다. ODP 출력에서 로드된 새로운 인스턴스만 `ODP`를 보고합니다.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

`slides.Presentation()`으로 처음부터 만든 프레젠테이션은 `SourceFormat.PPTX`를 보고합니다. 입력 파일이 없으므로 이는 새로 만든 인스턴스의 기본값이며 PPTX 파일이 로드되었다는 증거가 아닙니다. 구분이 중요하다면 애플리케이션에서 인스턴스를 생성했는지 로드했는지를 별도로 추적하십시오.

## **소스 형식을 확장자로 매핑**

다음 예제는 `sample.pptx`가 필요합니다. 현재 지원되는 모든 [SourceFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sourceformat/) 값을 일반적인 확장자로 매핑하며, 입력 파일 이름을 파싱하지 않습니다. 대체 경로는 인식되지 않은 값에 확장자를 조용히 할당하는 것을 방지합니다.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

이 매핑은 파일을 변환하거나 스트림 로드 중에 손실된 레거시 PPS/POT 서브타입을 복구하지 않습니다. 실제 저장 시에는 [SaveFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/saveformat/)을 명시적으로 선택하거나 [원본 형식으로 프레젠테이션 저장](/slides/ko/python-net/save-presentation/#save-presentations-in-their-original-format)에서 보여지는 변환을 사용하십시오.

## **저장 및 재열기로 형식 확인**

이 독립형 예제는 프레젠테이션을 생성하고 작업 디렉터리에 세 개의 파일을 쓰며 동일한 이름의 파일을 덮어씁니다. 각 출력을 경로와 메모리 스트림을 통해 다시 엽니다. PPTX와 ODP의 경우 두 경로 모두 저장된 형식을 보고합니다. PPS의 경우 경로로 로드하면 `PPS`를, 파일 이름 없이 같은 바이트를 로드하면 `PPT`를 보고합니다.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

| 저장된 형식 | 파일 경로에서의 SourceFormat | 이름 없는 스트림에서의 SourceFormat |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` 각각 | 파일 경로와 동일 |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` 각각 | 파일 경로와 동일 |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` 각각 | 파일 경로와 동일 |
| ODP, OTP | `ODP`, `OTP` 각각 | 파일 경로와 동일 |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

이 검사에서 이름 없는 스트림에 대해 PPS/POT가 `PPT`로 정규화된 것이 유일한 소스 형식 정규화였습니다. 표는 형식 식별을 설명하며, 변환 과정에서 모든 프레젠테이션 기능을 보존한다는 의미는 아닙니다.

## **FAQ**

**PPTX에서 로드된 프레젠테이션을 ODP로 저장하면 소스 형식이 변경됩니까?**

아니오. 기존 인스턴스는 여전히 `PPTX`를 보고합니다. 저장된 ODP 파일에서 로드된 인스턴스는 `ODP`를 보고합니다.

**스트림이 레거시 프레젠테이션, 슬라이드 쇼 및 템플릿을 항상 구분할 수 있습니까?**

아니오. PPT, PPS, 그리고 POT는 동일한 바이너리 형식을 공유합니다. 구분이 필요할 경우 파일 이름이나 서브타입 메타데이터를 별도로 보관하십시오.

**프레젠테이션이 이미 로드된 경우 어떤 API를 사용해야 합니까?**

[Presentation.source_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/source_format/)을 읽으십시오. 로드 전에 검사가 필요하면 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationfactory/get_presentation_info/)를 사용하십시오.