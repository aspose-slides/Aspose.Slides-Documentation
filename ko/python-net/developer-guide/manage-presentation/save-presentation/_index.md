---
title: Python에서 프레젠테이션 저장
linktitle: 프레젠테이션 저장
type: docs
weight: 80
url: /ko/python-net/save-presentation/
keywords:
- PowerPoint 저장
- OpenDocument 저장
- 프레젠테이션 저장
- 슬라이드 저장
- PPT 저장
- PPTX 저장
- ODP 저장
- 파일로 프레젠테이션 저장
- 스트림으로 프레젠테이션 저장
- 미리 정의된 보기 유형
- Strict Office Open XML 형식
- Zip64 모드
- 썸네일 새로 고침
- 저장 진행
- Python
- Aspose.Slides
description: "Python과 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 파일 또는 스트림에 저장하고 PPTX 출력 옵션을 구성합니다."
---
## **개요**

프레젠테이션을 생성하거나 [open an existing one](/slides/ko/python-net/open-presentation/)한 후, 결과를 기록하려면 [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ipresentation/save/) 메서드를 사용합니다. Aspose.Slides for Python via .NET은 PowerPoint, OpenDocument, PDF 및 기타 형식으로 프레젠테이션을 파일 또는 스트림에 저장할 수 있습니다. 다음 섹션에서는 표준 저장 작업과 PPTX 출력에 사용할 수 있는 옵션을 다룹니다.

## **프레젠테이션을 파일에 저장**

프레젠테이션을 파일에 저장하려면 출력 경로와 [SaveFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/saveformat/) 값을 [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ipresentation/save/) 메서드에 전달합니다. 형식 값은 Aspose.Slides가 생성하는 파일 유형을 결정합니다.

다음 예제는 프레젠테이션을 생성하고 이를 PPTX 파일로 저장합니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 프레젠테이션 내용을 추가하거나 수정하세요.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **프레젠테이션을 원본 형식으로 저장**

파일 및 스트림 감지 예제, 새로 만든 프레젠테이션의 동작, 소스와 출력 형식 간 구분에 대해서는 [Determine the Original Presentation Format](/slides/ko/python-net/detect-presentation-source-format/)을 참조하십시오.

배치 처리 애플리케이션에서는 입력 형식을 미리 알 수 없는 경우가 많습니다. 파일을 로드한 후 [Presentation.source_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/source_format/) 속성에서 원본 형식을 읽습니다. 얻은 [SourceFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sourceformat/) 값을 [SlideUtil.to_save_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides.util/slideutil/to_save_format/)에 전달하여 해당 [SaveFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/saveformat/) 값을 얻은 다음, [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ipresentation/save/)을 사용해 수정된 프레젠테이션을 기록합니다.

다음 완전한 예제는 입력 디렉터리의 모든 파일을 처리하고, 제목을 업데이트한 뒤, 로드된 형식 그대로 출력 디렉터리에 저장합니다:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides.util/slideutil/to_save_format/)은 PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP 및 PowerPoint XML을 해당 프레젠테이션 저장 형식에 매핑합니다. 이 메서드는 프레젠테이션 소스 형식만 매핑하며, PDF, HTML, TIFF 혹은 이미지와 같은 내보내기 형식을 선택하기 위한 것이 아닙니다. 지원되지 않거나 잘못된 [SourceFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sourceformat/) 값을 전달하면 예외가 발생합니다.

레거시 PPT, PPS 및 POT 파일은 동일한 바이너리 컨테이너를 사용합니다. 파일 확장자 없이 스트림에서 이러한 프레젠테이션을 로드하면 PPS 또는 POT 파일이 PPT로 식별될 수 있습니다. 이러한 레거시 하위 유형을 보존해야 하는 경우, 원본 파일 이름이나 형식 메타데이터를 별도로 유지하고 출력 파일 이름 및 형식을 선택할 때 사용하십시오.

## **프레젠테이션을 스트림에 저장**

최종 파일 경로에 의존하지 않고 프레젠테이션을 기록하려면 쓰기 가능한 [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) 스트림과 [SaveFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/saveformat/) 값을 [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ipresentation/save/) 메서드에 전달합니다. 이 방법은 출력이 웹 서비스에서 반환되거나 데이터베이스에 저장되거나 메모리에서 처리되어야 할 때 유용합니다.

다음 예제는 새 프레젠테이션을 파일 스트림에 저장합니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **미리 정의된 보기 유형으로 프레젠테이션 저장**

PowerPoint가 저장된 프레젠테이션을 처음 열 때 사용할 보기를 지정할 수 있습니다. 저장하기 전에 [ViewProperties.last_view](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/last_view/) 속성을 [ViewType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewtype/) 값으로 설정하십시오.

다음 예제는 슬라이드 마스터 보기를 초기 보기로 구성합니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Strict Office Open XML 형식으로 프레젠테이션 저장**

Office Open XML의 Strict 프로필을 준수하는 PPTX 파일을 만들려면 [PptxOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/pptxoptions/) 인스턴스를 생성하고 해당 [conformance](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/pptxoptions/conformance/) 속성을 `Conformance.ISO_29500_2008_STRICT` 로 설정합니다. 그런 다음 옵션을 [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ipresentation/save/) 메서드에 전달합니다.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Zip64 모드로 Office Open XML 형식에 프레젠테이션 저장**

표준 ZIP 아카이브는 각 엔트리의 압축 및 비압축 크기, 전체 아카이브 크기 및 엔트리 수를 제한합니다. PPTX 파일은 ZIP 아카이브이므로 매우 큰 프레젠테이션은 이러한 제한을 초과할 수 있습니다. ZIP64 확장은 적용 가능한 크기 및 엔트리 수 제한을 높입니다.

[PptxOptions.zip_64_mode](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) 속성을 사용하여 Aspose.Slides가 ZIP64 확장을 쓸지 여부를 제어합니다:

- `IF_NECESSARY`는 프레젠테이션이 표준 ZIP 제한을 초과할 때만 ZIP64를 사용합니다. 기본 모드입니다.
- `NEVER`는 ZIP64 확장을 사용하지 않습니다.
- `ALWAYS`는 항상 ZIP64 확장을 기록합니다.

다음 예제는 출력 프레젠테이션에 대해 ZIP64 확장을 항상 활성화합니다:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
`Zip64Mode.NEVER`를 사용하고 프레젠테이션이 표준 ZIP 제한에 들어가지 못하면 저장 작업이 [PptxException](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pptxexception/)을 발생시킵니다.
{{% /alert %}}

## **압축 레벨을 사용하여 Office Open XML 형식으로 프레젠테이션 저장**

PPTX 출력 시 [PptxOptions.compression_level](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/pptxoptions/compression_level/) 속성을 설정하여 저장 속도와 파일 크기 사이의 균형을 맞출 수 있습니다. [CompressionLevel](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/compressionlevel/) 열거형은 다음 값을 제공합니다:

- `NONE`은 압축 없이 데이터를 저장합니다.
- `LEVEL1`은 가장 빠른 압축을 제공하지만 압축된 결과가 가장 큽니다.
- `LEVEL2`부터 `LEVEL5`까지는 저장 속도보다 더 작은 출력 파일을 점진적으로 우선시합니다.
- `LEVEL6`은 저장 속도와 파일 크기의 균형을 맞춥니다. 기본 레벨입니다.
- `LEVEL7` 및 `LEVEL8`은 저장 속도보다 더 작은 출력을 더욱 선호합니다.
- `LEVEL9`는 가장 강력한 압축을 제공하며 가장 많은 처리 시간을 필요로 합니다.

다음 예제는 압축 없이 프레젠테이션을 저장합니다:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

다음 예제는 최대 압축 레벨을 사용합니다:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **썸네일을 새로 고치지 않고 프레젠테이션 저장**

프레젠테이션을 PPTX 형식으로 저장할 때 [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) 속성이 문서 썸네일을 제어합니다:

- `True`는 저장 작업 중에 썸네일을 다시 생성합니다. 기본값입니다.
- `False`는 기존 썸네일을 유지합니다. 프레젠테이션에 썸네일이 없으면 Aspose.Slides가 새 썸네일을 생성하지 않습니다.

다음 예제는 썸네일을 새로 고치지 않고 프레젠테이션을 저장합니다:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
썸네일 새로 고침을 비활성화하면 PPTX 파일 저장에 필요한 시간이 줄어들 수 있습니다.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Aspose는 Aspose.Slides API로 구축된 무료 [PowerPoint Splitter](https://products.aspose.app/slides/ko/splitter)를 제공합니다. 선택한 슬라이드를 별도의 PPT 또는 PPTX 파일로 저장합니다.
{{% /alert %}}

## **FAQ**

**Aspose.Slides가 증분 저장 또는 “빠른 저장”을 지원합니까?**

아니요. 각 저장 작업은 변경된 부분만 업데이트하는 것이 아니라 전체 출력 파일을 완전히 기록합니다.

**여러 스레드가 동일한 Presentation 인스턴스를 저장할 수 있습니까?**

아니요. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스는 [thread-safe하지 않습니다](/slides/ko/python-net/multithreading/). 각 인스턴스는 한 번에 하나의 스레드만 접근하고 저장해야 합니다.

**프레젠테이션을 저장할 때 하이퍼링크와 외부 링크된 파일은 어떻게 처리됩니까?**

[Hyperlinks](/slides/ko/python-net/manage-hyperlinks/)는 프레젠테이션에 그대로 유지됩니다. Aspose.Slides는 외부 링크된 파일을 복사하지 않으므로, 저장된 프레젠테이션은 여전히 해당 위치에 접근할 수 있어야 합니다.

**작성자, 제목, 회사, 작성 날짜와 같은 문서 메타데이터를 저장할 수 있습니까?**

예. 저장하기 전에 적절한 [document properties](/slides/ko/python-net/presentation-properties/)를 설정하면 Aspose.Slides가 이를 출력 파일에 기록합니다.