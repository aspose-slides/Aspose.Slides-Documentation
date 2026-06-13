---
title: Python에서 노트가 포함된 PowerPoint 프레젠테이션을 TIFF로 변환
linktitle: 노트가 포함된 PowerPoint를 TIFF로
type: docs
weight: 100
url: /ko/python-net/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 TIFF로
- 프레젠테이션을 TIFF로
- 슬라이드를 TIFF로
- PPT를 TIFF로
- PPTX를 TIFF로
- 노트가 포함된 PowerPoint
- 노트가 포함된 프레젠테이션
- 노트가 포함된 슬라이드
- 노트가 포함된 PPT
- 노트가 포함된 PPTX
- 노트가 포함된 TIFF
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 노트가 포함된 PowerPoint 프레젠테이션을 TIFF로 변환합니다. 슬라이드와 발표자 노트를 효율적으로 내보내는 방법을 알아보세요."
---
## **소개**

Aspose.Slides for Python via .NET은 PowerPoint 및 OpenDocument 프레젠테이션(PPT, PPTX 및 ODP)을 노트와 함께 TIFF 형식으로 변환하는 간단한 솔루션을 제공합니다. 이 형식은 고품질 이미지 저장, 인쇄 및 문서 아카이빙에 널리 사용됩니다. Aspose.Slides를 사용하면 발표자 노트가 포함된 전체 프레젠테이션을 내보낼 수 있을 뿐만 아니라 Notes Slide 보기에서 슬라이드 썸네일을 생성할 수도 있습니다. 변환 과정은 간단하고 효율적이며, `save` 메서드를 활용하여 전체 프레젠테이션을 노트와 레이아웃을 유지한 채 일련의 TIFF 이미지로 변환합니다. 이는 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스에서 수행됩니다.

## **프레젠테이션을 노트와 함께 TIFF로 변환**

Aspose.Slides for Python via .NET을 사용하여 PowerPoint 또는 OpenDocument 프레젠테이션을 노트와 함께 TIFF로 저장하려면 다음 단계가 필요합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화합니다: PowerPoint 또는 OpenDocument 파일을 로드합니다.
1. 출력 레이아웃 옵션을 구성합니다: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/notescommentslayoutingoptions/) 클래스를 사용하여 노트와 댓글이 어떻게 표시될지 지정합니다.
1. 프레젠테이션을 TIFF로 저장합니다: 구성된 옵션을 [save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions) 메서드에 전달합니다.

예를 들어, 다음 슬라이드가 포함된 "speaker_notes.pptx" 파일이 있다고 가정해 보겠습니다:

![노트가 포함된 프레젠테이션 슬라이드](slide_with_notes.png)

아래 코드 스니펫은 [slides_layout_options](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) 속성을 사용하여 Notes Slide 보기에서 프레젠테이션을 TIFF 이미지로 변환하는 방법을 보여줍니다.

```py
# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # 슬라이드 아래에 노트를 표시합니다.
    
    # Notes 레이아웃을 사용하여 TIFF 옵션을 구성합니다.
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # 발표자 노트와 함께 프레젠테이션을 TIFF로 저장합니다.
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

결과:

![노트가 포함된 TIFF 이미지](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Aspose의 [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/ko/conversion/convert-ppt-to-poster-online)를 확인해 보세요.

{{% /alert %}}

## **자주 묻는 질문**

**결과 TIFF에서 노트 영역의 위치를 제어할 수 있나요?**

예. [notes layout settings](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/slides_layout_options/)을 사용하여 `NONE`, `BOTTOM_TRUNCATED`, `BOTTOM_FULL`와 같은 옵션 중에서 선택할 수 있습니다. 각각 노트를 숨기고, 한 페이지에 맞추며, 추가 페이지로 흐르게 합니다.

**노트가 포함된 TIFF 파일의 크기를 눈에 띄는 품질 저하 없이 어떻게 줄일 수 있나요?**

[efficient compression](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/compression_type/)을 선택하고(e.g., `LZW` 또는 `RLE`), 적절한 DPI를 설정하며, 허용되는 경우 낮은 [pixel format](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/pixel_format/)을 사용합니다(예: 8 bpp 또는 1 bpp 단색). 또한 [image dimensions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/image_size/)을 약간 줄이면 가독성을 크게 해치지 않으면서도 도움이 됩니다.

**시스템에 원본 글꼴이 없을 경우 노트의 글꼴이 결과에 영향을 미치나요?**

예. 글꼴이 없으면 [substitution](/slides/ko/python-net/font-selection-sequence/)이 발생하여 텍스트 메트릭 및 외관이 바뀔 수 있습니다. 이를 방지하려면 [필요한 글꼴을 제공](/slides/ko/python-net/custom-font/)하거나 기본 [fallback font](/slides/ko/python-net/fallback-font/)를 설정하여 의도된 서체가 사용되도록 합니다.