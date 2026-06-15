---
title: PowerPoint 프레젠테이션을 Python에서 Markdown으로 변환
linktitle: PowerPoint를 Markdown으로
type: docs
weight: 140
url: /ko/python-net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint를 Markdown으로 변환
- OpenDocument를 Markdown으로 변환
- 프레젠테이션을 Markdown으로 변환
- 슬라이드를 Markdown으로 변환
- PPT를 Markdown으로 변환
- PPTX를 Markdown으로 변환
- ODP를 Markdown으로 변환
- PowerPoint를 MD로 변환
- OpenDocument를 MD로 변환
- 프레젠테이션을 MD로 변환
- 슬라이드를 MD로 변환
- PPT를 MD로 변환
- PPTX를 MD로 변환
- ODP를 MD로 변환
- PowerPoint
- OpenDocument
- 프레젠테이션
- Markdown
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 슬라이드(PPT, PPTX, ODP)를 깔끔한 Markdown으로 변환하고, 문서 작성을 자동화하며 서식을 유지합니다."
---
## **소개**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션을 Markdown으로 변환할 수 있으며, 이는 문서 작업 흐름, 정적 사이트 생성, 콘텐츠 마이그레이션 및 버전 관리 텍스트 게시에 유용할 수 있습니다. API는 PPT 및 PPTX 프레젠테이션을 MD 파일로 직접 내보내는 것을 지원하며, 결과 Markdown 문서에서 슬라이드 내용이 어떻게 표현되는지를 제어하는 추가 옵션을 제공합니다.

프레젠테이션을 일반 Markdown으로 내보낼 수 있고, CommonMark 및 GitHub Flavored Markdown과 같은 다양한 Markdown 변형 중에서 선택할 수 있으며, 내보내기 중 이미지 처리 방식을 구성할 수 있습니다. 시각적 콘텐츠가 포함된 프레젠테이션의 경우, Aspose.Slides는 이미지를 별도 폴더에 저장하고 생성된 Markdown 파일에서 참조하도록 허용합니다.

{{% alert color="warning" %}}
PowerPoint에서 Markdown으로의 내보내기는 기본적으로 **이미지 없이** 수행됩니다. 이미지가 포함된 PowerPoint 문서를 내보내려면 `export_type = MarkdownExportType.VISUAL`을 설정하고 `base_path`를 지정해야 하며, 여기에서 Markdown 문서에 참조된 이미지가 저장됩니다.
{{% /alert %}}

## **프레젠테이션을 Markdown으로 변환**

다음 예시는 기본 설정으로 .NET을 통해 Python용 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 Markdown으로 변환하는 가장 간단한 방법을 보여줍니다.

1. 프레젠테이션을 로드하기 위해 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/)을 인스턴스화합니다.
1. `save`를 호출하여 Markdown 파일로 내보냅니다.

아래 Python 스니펫을 사용하여 변환을 수행합니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **프레젠테이션을 Markdown 변형으로 변환**

Aspose.Slides를 사용하면 기본 Markdown, CommonMark, GitHub-flavored Markdown, Trello, XWiki, GitLab 및 기타 17개의 Markdown 변형을 포함한 다양한 Markdown 형식으로 프레젠테이션을 변환할 수 있습니다.

다음 Python 예시는 PowerPoint 프레젠테이션을 CommonMark로 변환하는 방법을 보여줍니다:

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

지원되는 23개의 Markdown 변형은 [MarkdownSaveOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 클래스의 [Flavor](https://reference.aspose.com/slides/ko/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) 열거형에 나열되어 있습니다.

## **이미지가 포함된 프레젠테이션을 Markdown으로 변환**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 클래스는 결과 Markdown 파일을 구성할 수 있는 속성 및 열거형을 제공합니다. 예를 들어, [MarkdownExportType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 열거형은 이미지 처리 방식을 `SEQUENTIAL`, `TEXT_ONLY` 또는 `VISUAL` 중 하나로 제어합니다.

### **이미지를 순차적으로 변환**

생성된 Markdown에서 이미지가 개별적으로—하나씩 순서대로—표시되길 원한다면 `SEQUENTIAL` 옵션을 선택하세요. 아래 Python 예시는 이미지를 포함한 프레젠테이션을 Markdown으로 변환하는 방법을 보여줍니다.

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```

### **이미지를 시각적으로 변환**

이미지를 결과 Markdown에 함께 표시하고 싶다면 `VISUAL` 옵션을 선택하세요. 이 모드에서는 이미지가 애플리케이션 현재 디렉터리에 저장되며(Markdown 문서는 상대 경로를 사용합니다), 또는 사용자 지정 출력 경로와 폴더 이름을 지정할 수 있습니다.

아래 Python 예시는 이 작업을 보여줍니다:

```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```

## **FAQ**

**하이퍼링크가 Markdown으로 내보낼 때 유지되나요?**

예. 텍스트 [hyperlinks](/slides/ko/python-net/manage-hyperlinks/)는 표준 Markdown 링크로 보존됩니다. 슬라이드 [transitions](/slides/ko/python-net/slide-transition/)와 [animations](/slides/ko/python-net/powerpoint-animation/)는 변환되지 않습니다.

**다중 스레드로 실행하여 변환 속도를 높일 수 있나요?**

파일마다 병렬 처리를 할 수 있지만, 스레드 간에 동일한 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 [공유하지 마세요](/slides/ko/python-net/multithreading/). 파일당 별도 인스턴스/프로세스를 사용하여 경쟁을 피하십시오.

**이미지는 어떻게 처리되나요—어디에 저장되며 경로는 상대적인가요?**

[Images](/slides/ko/python-net/image/)는 전용 폴더로 내보내지며, 기본적으로 Markdown 파일은 상대 경로로 이를 참조합니다. 기본 출력 경로와 자산 폴더 이름을 구성하여 예측 가능한 저장소 구조를 유지할 수 있습니다.