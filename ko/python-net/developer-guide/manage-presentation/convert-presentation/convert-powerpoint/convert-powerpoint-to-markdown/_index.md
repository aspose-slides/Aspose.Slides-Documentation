---
title: Python에서 PowerPoint 프레젠테이션을 Markdown으로 변환
linktitle: PowerPoint를 Markdown으로
type: docs
weight: 140
url: /ko/python-net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 MD로
- 프레젠테이션을 MD로
- 슬라이드를 MD로
- PPT를 MD로
- PPTX를 MD로
- PowerPoint를 Markdown으로 저장
- 프레젠테이션을 Markdown으로 저장
- 슬라이드를 Markdown으로 저장
- PPT를 MD로 저장
- PPTX를 MD로 저장
- PPT를 MD로 내보내기
- PPTX를 MD로 내보내기
- Markdown 이미지 내보내기
- CDN 이미지 링크
- PowerPoint
- 프레젠테이션
- Markdown
- Python
- Python via .NET
- Aspose.Slides
description: Python에서 PPT 및 PPTX 프레젠테이션을 Markdown으로 변환하고, 내보낸 이미지가 저장되는 위치와 생성된 Markdown이 이를 어떻게 참조하는지 제어합니다.
---
## **개요**

Aspose.Slides for Python via .NET은 PPT 및 PPTX 프레젠테이션을 문서화, 정적 사이트, 콘텐츠 마이그레이션 및 버전 관리 워크플로우를 위해 Markdown으로 변환할 수 있습니다. Markdown 스타일을 선택하고, 슬라이드 내용이 렌더링되는 방식을 제어하며, 내보낸 이미지가 저장되는 위치와 생성된 Markdown이 이를 어떻게 참조할지 결정할 수 있습니다.

기본적으로 Markdown 내보내기는 텍스트 전용 출력만 사용합니다. 시각적 컨텐츠를 내보내려면 [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/markdownsaveoptions/export_type/) 속성을 [MarkdownExportType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/markdownexporttype/) 열거형의 `SEQUENTIAL` 또는 `VISUAL` 값으로 설정합니다. `SEQUENTIAL`은 슬라이드 항목을 개별적으로 순서대로 렌더링하고, `VISUAL`은 그룹화된 항목을 함께 유지하여 시각적 관계를 보존합니다. `TEXT_ONLY` 값은 이미지 리소스를 생성하지 않습니다.

## **프레젠테이션을 Markdown으로 변환**

소스 파일을 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스에 로드한 다음, [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ipresentation/save/) 메서드를 호출하여 [SaveFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/saveformat/) 열거형의 `MD` 값을 사용합니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Markdown 스타일 선택**

[MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/markdownsaveoptions/flavor/) 속성은 출력에 사용할 Markdown 사양을 제어합니다. [Flavor](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/flavor/) 열거형에는 CommonMark, GitHub Flavored Markdown 및 기타 지원되는 변형이 포함됩니다.

다음 예제는 프레젠테이션을 CommonMark 형식으로 내보냅니다:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **기본 로컬 저장 동작을 사용하여 이미지 내보내기**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/markdownsaveoptions/) 클래스는 로컬에 저장되는 이미지에 대해 두 개의 속성을 제공합니다:

- [base_path](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/markdownsaveoptions/base_path/)은 Markdown 문서와 해당 리소스의 기본 디렉터리를 지정합니다.
- [images_save_folder_name](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/)은 이미지 하위 디렉터리를 지정합니다. 기본값은 `Images`입니다.

다음 예제는 시각적 콘텐츠를 렌더링하고, 이미지를 `output/assets`에 저장하며, Markdown 문서에 상대 이미지 참조를 생성합니다:

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Aspose.Slides는 내보내기에서 이미지 리소스를 생성할 때 이미지 하위 디렉터리를 만들지만, 애플리케이션은 Markdown 파일을 저장하기 전에 `base_path`를 생성해야 합니다.

## **게시를 위한 Markdown 및 이미지 준비**

Aspose.Slides for Python via .NET은 내보내기 중에 생성된 각 이미지 링크를 교체하기 위한 .NET 이미지 저장 콜백을 제공하지 않습니다. 대신, Markdown 문서와 이미지 폴더를 게시 디렉터리로 내보낸 다음, 상대 구조를 변경하지 않고 그 디렉터리를 게시합니다.

다음 예제는 `cdn-origin/presentations/quarterly-report`를 마운트되거나 동기화된 게시 디렉터리로 준비합니다. 샘플 자체는 네트워크 업로드를 수행하지 않으며, 디렉터리가 목표 사이트 또는 CDN 위치에 게시된 후에 생성된 링크가 유효해집니다.

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

`presentation.md`와 `assets` 디렉터리를 함께 게시합니다. Markdown 문서는 상대 이미지 참조를 사용하므로 두 항목은 대상에서 동일한 관계를 유지해야 합니다. 게시 시스템이 절대 외부 URL을 요구하는 경우, 모든 이미지 파일이 게시된 후 별도의 후처리 단계에서 생성된 링크를 재작성합니다.

## **FAQ**

**Python 콜백으로 Markdown 내보내기 중 개별 이미지 파일 및 링크를 사용자 정의할 수 있나요?**

아니요. Aspose.Slides for Python via .NET은 .NET `ImageSaving` 및 `SvgImageSaving` 콜백을 제공하지 않습니다. 로컬 출력은 [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/markdownsaveoptions/base_path/) 및 [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/)을 사용해 구성한 다음, 생성된 리소스를 게시하거나 후처리하십시오.

**내보낸 이미지는 어디에 저장됩니까?**

이미지 위치는 [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/markdownsaveoptions/base_path/) 및 [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/)에 의해 제어됩니다. Markdown 문서는 이러한 이미지를 상대 경로로 참조합니다.

**이미지 링크에 어떤 경로 구분자를 사용해야 합니까?**

Markdown 링크와 URL에서는 슬래시(`/`)를 사용하십시오. 파일 시스템 경로에는 `os.path.join`을 사용하고, 후처리 중에 생성된 링크는 별도로 정규화합니다.

**Markdown 내보내기 시 하이퍼링크가 보존되나요?**

예. 텍스트 [hyperlinks](/slides/ko/python-net/manage-hyperlinks/)는 표준 Markdown 링크로 보존됩니다. 슬라이드 [transitions](/slides/ko/python-net/slide-transition/) 및 [animations](/slides/ko/python-net/powerpoint-animation/)는 변환되지 않습니다.

**프레젠테이션을 병렬로 Markdown으로 변환할 수 있나요?**

다양한 프레젠테이션 파일을 병렬로 처리할 수 있지만, 스레드 간에 동일한 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 공유하지 마십시오. [multithreading guidelines](/slides/ko/python-net/multithreading/)을 따르고 파일당 별도의 인스턴스를 사용하십시오.