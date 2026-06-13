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
- 파일에 프레젠테이션
- 스트림에 프레젠테이션
- 미리 정의된 보기 유형
- Strict Office Open XML 형식
- Zip64 모드
- 썸네일 새로 고침
- 저장 진행 상황
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 프레젠테이션을 저장하는 방법을 알아보세요—레이아웃, 글꼴 및 효과를 유지하면서 PowerPoint 또는 OpenDocument로 내보낼 수 있습니다."
---
## **개요**

[Open a Presentation in Python](/slides/ko/python-net/open-presentation/) 은(는) 프레젠테이션을 열 때 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 사용하는 방법을 설명합니다. 이 문서는 프레젠테이션을 만들고 저장하는 방법을 설명합니다. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스는 프레젠테이션의 내용을 포함합니다. 처음부터 프레젠테이션을 만들든 기존 파일을 수정하든 작업이 끝나면 저장해야 합니다. Aspose.Slides for Python을 사용하면 **파일** 또는 **스트림**에 저장할 수 있습니다. 이 문서는 프레젠테이션을 저장하는 다양한 방법을 설명합니다.

## **파일에 프레젠테이션 저장**

프레젠테이션을 파일에 저장하려면 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 `save` 메서드를 호출합니다. 메서드에 파일 이름과 저장 형식을 전달합니다. 다음 예제는 Aspose.Slides for Python으로 프레젠테이션을 저장하는 방법을 보여줍니다.

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    
    # 여기서 작업을 수행합니다...

    # 프레젠테이션을 파일에 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **스트림에 프레젠테이션 저장**

출력 스트림을 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 `save` 메서드에 전달하여 프레젠테이션을 스트림에 저장할 수 있습니다. 프레젠테이션은 다양한 스트림 유형에 기록될 수 있습니다. 아래 예제에서는 새 프레젠테이션을 만들고, 도형에 텍스트를 추가한 뒤 스트림에 저장합니다.

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # 프레젠테이션을 스트림에 저장합니다.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **미리 정의된 보기 유형으로 프레젠테이션 저장**

Aspose.Slides for Python을 사용하면 생성된 프레젠테이션이 열릴 때 PowerPoint가 사용하는 초기 보기를 [ViewProperties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/) 클래스를 통해 설정할 수 있습니다. `last_view` 속성을 [ViewType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewtype/) 열거형의 값 중 하나로 설정합니다.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Strict Office Open XML 형식으로 프레젠테이션 저장**

Aspose.Slides를 사용하면 프레젠테이션을 Strict Office Open XML 형식으로 저장할 수 있습니다. 저장 시 [PptxOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/pptxoptions/) 클래스를 사용하고 그 conformance 속성을 설정합니다. `Conformance.ISO_29500_2008_STRICT`를 설정하면 출력 파일이 Strict Office Open XML 형식으로 저장됩니다.

아래 예제는 프레젠테이션을 만들고 Strict Office Open XML 형식으로 저장합니다.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 프레젠테이션을 Strict Office Open XML 형식으로 저장합니다.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Zip64 모드로 Office Open XML 형식에 프레젠테이션 저장**

Office Open XML 파일은 ZIP 아카이브이며, 압축되지 않은 파일 크기, 압축된 파일 크기, 아카이브 전체 크기에 4 GB(2^32 바이트) 제한을 두고 파일 수를 65 535(2^16‑1) 개로 제한합니다. ZIP64 형식 확장은 이러한 제한을 2^64까지 확장합니다.

[PptxOptions.zip_64_mode](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) 속성을 사용하면 Office Open XML 파일을 저장할 때 ZIP64 형식 확장을 언제 사용할지 선택할 수 있습니다.

이 속성은 다음 모드를 제공합니다:

- `IF_NECESSARY`는 프레젠테이션이 위 제한을 초과할 경우에만 ZIP64 형식 확장을 사용합니다. 기본 모드입니다.
- `NEVER`는 ZIP64 형식 확장을 절대 사용하지 않습니다.
- `ALWAYS`는 항상 ZIP64 형식 확장을 사용합니다.

다음 코드는 ZIP64 형식 확장이 활성화된 상태로 PPTX로 프레젠테이션을 저장하는 방법을 보여줍니다:

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.NEVER`로 저장하면 프레젠테이션을 ZIP32 형식으로 저장할 수 없을 경우 [PptxException](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pptxexception/)이 발생합니다.
{{% /alert %}}

## **썸네일을 새로 고치지 않고 프레젠테이션 저장**

[PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) 속성은 프레젠테이션을 PPTX로 저장할 때 썸네일 생성 여부를 제어합니다:

- `True`로 설정하면 저장 중에 썸네일이 새로 고쳐집니다. 기본값입니다.
- `False`로 설정하면 현재 썸네일이 유지됩니다. 프레젠테이션에 썸네일이 없으면 썸네일이 생성되지 않습니다.

아래 코드에서는 썸네일을 새로 고치지 않고 PPTX로 프레젠테이션을 저장합니다.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
이 옵션은 PPTX 형식으로 프레젠테이션을 저장하는 데 걸리는 시간을 줄이는 데 도움이 됩니다.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose는 자체 API를 사용하여 [무료 PowerPoint Splitter 앱](https://products.aspose.app/slides/ko/splitter)을 개발했습니다. 이 앱을 사용하면 선택한 슬라이드를 새 PPTX 또는 PPT 파일로 저장하여 프레젠테이션을 여러 파일로 분할할 수 있습니다.
{{% /alert %}}

## **FAQ**

**"빠른 저장"(증분 저장)이 지원되어 변경된 부분만 기록되나요?**

아니요. 저장 시마다 전체 대상 파일이 새로 생성되며, 증분 “빠른 저장”은 지원되지 않습니다.

**여러 스레드에서 동일한 Presentation 인스턴스를 저장하는 것이 스레드 안전한가요?**

아니요. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스는 [스레드 안전하지 않습니다](/slides/ko/python-net/multithreading/); 단일 스레드에서 저장해야 합니다.

**저장 시 하이퍼링크와 외부 링크된 파일은 어떻게 되나요?**

[Hyperlinks](/slides/ko/python-net/manage-hyperlinks/)는 유지됩니다. 외부 링크된 파일(예: 상대 경로를 사용하는 동영상)은 자동으로 복사되지 않으므로, 참조된 경로가 계속 접근 가능하도록 해야 합니다.

**문서 메타데이터(작성자, 제목, 회사, 날짜)를 설정/저장할 수 있나요?**

예. 표준 [문서 속성](/slides/ko/python-net/presentation-properties/)이 지원되며 저장 시 파일에 기록됩니다.