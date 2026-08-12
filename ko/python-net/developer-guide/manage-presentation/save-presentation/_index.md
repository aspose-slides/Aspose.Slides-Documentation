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
- 저장 진행
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 프레젠테이션을 저장하는 방법을 알아보세요—레이아웃, 글꼴 및 효과를 유지하면서 PowerPoint 또는 OpenDocument로 내보낼 수 있습니다."
---
## **개요**

[Python에서 프레젠테이션 열기](/slides/ko/python-net/open-presentation/)은 [Presentation 클래스](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/)를 사용하여 프레젠테이션을 여는 방법을 설명했습니다. 이 문서에서는 프레젠테이션을 생성하고 저장하는 방법을 설명합니다. [Presentation 클래스](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/)는 프레젠테이션의 내용을 포함합니다. 처음부터 프레젠테이션을 만들든 기존 프레젠테이션을 수정하든, 완료하면 저장해야 합니다. Aspose.Slides for Python을 사용하면 파일 또는 스트림에 저장할 수 있습니다. 이 문서에서는 프레젠테이션을 저장하는 다양한 방법을 설명합니다.

## **파일에 프레젠테이션 저장**

Presentation 클래스의 `save` 메서드를 호출하여 프레젠테이션을 파일에 저장합니다. 메서드에 파일 이름과 저장 형식을 전달합니다. 아래 예제는 Aspose.Slides for Python을 사용하여 프레젠테이션을 저장하는 방법을 보여줍니다.

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    
    # 여기에서 작업을 수행합니다...

    # 프레젠테이션을 파일에 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **스트림에 프레젠테이션 저장**

Presentation 클래스의 `save` 메서드에 출력 스트림을 전달하여 프레젠테이션을 스트림에 저장할 수 있습니다. 프레젠테이션은 여러 종류의 스트림에 기록될 수 있습니다. 아래 예제에서는 새 프레젠테이션을 만들고 파일 스트림에 저장합니다.

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # 프레젠테이션을 스트림에 저장합니다.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **미리 정의된 보기 유형으로 프레젠테이션 저장**

Aspose.Slides for Python을 사용하면 ViewProperties 클래스를 통해 생성된 프레젠테이션이 열릴 때 PowerPoint가 사용하는 초기 보기를 설정할 수 있습니다. `last_view` 속성을 ViewType 열거형의 값으로 설정합니다.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Strict Office Open XML 형식으로 프레젠테이션 저장**

Aspose.Slides를 사용하면 Strict Office Open XML 형식으로 프레젠테이션을 저장할 수 있습니다. 저장 시 PptxOptions 클래스를 사용하고 그 `conformance` 속성을 설정합니다. `Conformance.ISO_29500_2008_STRICT`를 설정하면 출력 파일이 Strict Office Open XML 형식으로 저장됩니다.

아래 예제는 프레젠테이션을 생성하고 Strict Office Open XML 형식으로 저장합니다.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 프레젠테이션을 Strict Office Open XML 형식으로 저장합니다.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Zip64 모드에서 Office Open XML 형식으로 프레젠테이션 저장**

Office Open XML 파일은 ZIP 아카이브이며, 압축되지 않은 파일당 4GB(2^32 바이트), 압축된 파일당 4GB, 아카이브 전체 크기 4GB, 파일 수 65,535(2^16‑1) 제한을 둡니다. ZIP64 포맷 확장은 이러한 제한을 2^64까지 높입니다.

PptxOptions.zip_64_mode 속성을 사용하면 Office Open XML 파일을 저장할 때 ZIP64 포맷 확장을 언제 사용할지 선택할 수 있습니다.

이 속성은 다음 모드를 제공합니다:

- `IF_NECESSARY`는 프레젠테이션이 위 제한을 초과할 경우에만 ZIP64 포맷 확장을 사용합니다. 기본 모드입니다.
- `NEVER`는 절대 ZIP64 포맷 확장을 사용하지 않습니다.
- `ALWAYS`는 항상 ZIP64 포맷 확장을 사용합니다.

다음 코드는 ZIP64 포맷 확장이 활성화된 상태로 PPTX 파일로 프레젠테이션을 저장하는 방법을 보여줍니다:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.NEVER`로 저장하면 프레젠테이션을 ZIP32 형식으로 저장할 수 없을 경우 PptxException이 발생합니다.
{{% /alert %}}

## **압축 레벨을 사용하여 Office Open XML 형식으로 프레젠테이션 저장**

대용량 프레젠테이션을 작업할 때 압축 레벨을 조정하여 파일 크기와 처리 시간을 균형 있게 맞출 수 있습니다. 요구 사항에 따라 빠른 처리 속도 또는 더 작은 출력 파일을 선호할 수 있습니다.

Aspose.Slides는 PptxOptions.compression_level 속성을 제공하여 Office Open XML 형식으로 프레젠테이션을 저장할 때 사용할 압축 레벨을 지정할 수 있습니다.

다음 압축 레벨을 사용할 수 있습니다:

- **NONE**: 압축이 적용되지 않습니다. 파일이 그대로 저장됩니다.
- **LEVEL1**: 가장 빠른 압축이며 압축 비율이 가장 낮습니다.
- **LEVEL2**: LEVEL1보다 약간 높은 압축 비율이며 빠른 압축을 제공합니다.
- **LEVEL3**: LEVEL2보다 더 나은 압축을 제공하지만 처리 시간에 중간 정도 영향을 줍니다.
- **LEVEL4**: LEVEL3보다 더 나은 압축을 제공합니다.
- **LEVEL5**: LEVEL4보다 향상된 압축을 제공하지만 추가 처리 시간이 필요합니다.
- **LEVEL6**: 표준 압축으로 처리 속도와 파일 크기 사이에 좋은 균형을 제공합니다. 기본 압축 레벨입니다.
- **LEVEL7**: LEVEL6보다 더 나은 압축을 제공하지만 처리 속도가 느려집니다.
- **LEVEL8**: LEVEL7보다 더 나은 압축을 제공합니다.
- **LEVEL9**: 최대 압축으로 가장 작은 파일 크기를 얻지만 처리 시간이 가장 오래 걸립니다.

아래 예제는 압축 없이 PPTX 파일로 프레젠테이션을 저장하는 방법을 보여줍니다:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

아래 예제는 최대 압축으로 PPTX 파일을 저장하는 방법을 보여줍니다:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **썸네일을 새로 고치지 않고 프레젠테이션 저장**

PptxOptions.refresh_thumbnail 속성은 PPTX로 프레젠테이션을 저장할 때 썸네일 생성 여부를 제어합니다:

- `True`로 설정하면 저장 중에 썸네일이 새로 고쳐집니다. 기본값입니다.
- `False`로 설정하면 현재 썸네일이 유지됩니다. 프레젠테이션에 썸네일이 없는 경우 썸네일이 생성되지 않습니다.

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
Aspose는 자체 API를 사용하여 무료 PowerPoint Splitter 앱을 개발했습니다. 이 앱을 사용하면 선택한 슬라이드를 새 PPTX 또는 PPT 파일로 저장하여 프레젠테이션을 여러 파일로 분할할 수 있습니다.
{{% /alert %}}

## **FAQ**

**"빠른 저장"(증분 저장)은 지원되어 변경된 부분만 기록되나요?**

아니요. 저장할 때마다 전체 대상 파일을 생성하므로 증분 “빠른 저장”은 지원되지 않습니다.

**여러 스레드에서 동일한 Presentation 인스턴스를 저장하는 것이 스레드 안전한가요?**

아니요. [스레드 안전하지 않음](/slides/ko/python-net/multithreading/)Presentation 인스턴스는 스레드 안전하지 않으므로 단일 스레드에서 저장해야 합니다.

**저장 시 하이퍼링크와 외부 연결 파일은 어떻게 되나요?**

[하이퍼링크](/slides/ko/python-net/manage-hyper링크/)는 보존됩니다. 외부 연결 파일(예: 상대 경로를 사용하는 비디오)은 자동으로 복사되지 않으므로, 참조된 경로가 계속 접근 가능하도록 해야 합니다.

**문서 메타데이터(작성자, 제목, 회사, 날짜)를 설정/저장할 수 있나요?**

예. 표준 [문서 속성](/slides/ko/python-net/presentation-properties/)이 지원되며 저장 시 파일에 기록됩니다.