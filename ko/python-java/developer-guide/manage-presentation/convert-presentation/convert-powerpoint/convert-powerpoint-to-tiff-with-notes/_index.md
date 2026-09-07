---
title: Python에서 메모가 포함된 PowerPoint 프레젠테이션을 TIFF로 변환
linktitle: PowerPoint를 메모와 함께 TIFF로
type: docs
weight: 100
url: /ko/python-java/convert-powerpoint-to-tiff-with-notes/
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
- PPT를 TIFF로 저장
- PPTX를 TIFF로 저장
- PPT를 TIFF로 내보내기
- PPTX를 TIFF로 내보내기
- 메모가 포함된 PowerPoint
- 메모가 포함된 프레젠테이션
- 메모가 포함된 슬라이드
- 메모가 포함된 PPT
- 메모가 포함된 PPTX
- 메모가 포함된 TIFF
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 메모가 포함된 PowerPoint 프레젠테이션을 TIFF로 변환합니다. 발표자 메모와 함께 슬라이드를 효율적으로 내보내는 방법을 배우세요."
---
## **소개**

Aspose.Slides for Python via Java은 메모가 포함된 PowerPoint 및 OpenDocument 프레젠테이션(PPT, PPTX 및 ODP)을 TIFF 형식으로 변환하기 위한 간단한 솔루션을 제공합니다. 이 형식은 고품질 이미지 저장, 인쇄 및 문서 보관에 널리 사용됩니다. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 [save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 메서드를 사용하여 슬라이드와 해당 발표자 메모를 단일 다중 페이지 TIFF 파일로 내보냅니다.

## **발표문을 메모와 함께 TIFF로 변환**

Aspose.Slides for Python via Java를 사용하여 메모와 함께 PowerPoint 또는 OpenDocument 프레젠테이션을 TIFF로 저장하려면 다음 단계가 포함됩니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다: PowerPoint 또는 OpenDocument 파일을 로드합니다.
1. 출력 레이아웃 옵션을 구성합니다: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/) 클래스를 사용하여 메모와 댓글이 표시되는 방식을 지정합니다.
1. 프레젠테이션을 TIFF로 저장합니다: 구성된 옵션을 [save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 메서드에 전달합니다.

예를 들어, 다음 슬라이드가 포함된 "speaker_notes.pptx" 파일이 있다고 가정해 보겠습니다:

![발표 슬라이드와 발표자 메모](slide_with_notes.png)

아래 코드 조각은 [setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) 메서드를 사용하여 메모 슬라이드 보기에서 프레젠테이션을 TIFF 이미지로 변환하는 방법을 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # 각 슬라이드 아래에 전체 발표자 메모를 표시합니다.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # TIFF 해상도와 메모 레이아웃을 구성합니다.
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # 발표자를 메모와 함께 프레젠테이션을 TIFF로 저장합니다.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

결과:

![발표자 메모가 포함된 TIFF 이미지](TIFF_with_notes.png)

{{% alert title="Tip" color="success" %}}
Aspose [무료 PowerPoint 포스터 변환기](https://products.aspose.app/slides/ko/conversion/convert-ppt-to-poster-online)를 확인해 보세요.
{{% /alert %}}

## **자주 묻는 질문**

**결과 TIFF에서 메모 영역의 위치를 제어할 수 있나요?**

예. [setNotesPosition](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition)을 [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notespositions/#BottomTruncated)와 함께 설정하여 메모를 한 페이지에 맞추고 필요 시 잘라내도록 하거나, [NotesPositions.BottomFull](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notespositions/#BottomFull)을 사용하여 필요에 따라 추가 페이지를 사용해 모든 메모를 표시할 수 있습니다. 메모 없이 슬라이드를 내보내려면 [Convert PowerPoint to TIFF](/slides/ko/python-java/convert-powerpoint-to-tiff/)에 표시된 대로 메모 레이아웃 구성을 생략하십시오.

**이미지 품질을 떨어뜨리지 않고 메모가 포함된 TIFF 파일의 크기를 어떻게 줄일 수 있나요?**

손실이 없는 [LZW compression](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffcompressiontypes/#LZW)을 [setCompressionType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/#setCompressionType)을 통해 사용하십시오. 해상도 또는 색 깊이를 낮추면 파일 크기를 더 줄일 수 있지만 이미지 품질 및 메모 가독성에 영향을 줄 수 있습니다. 자세한 옵션은 [TIFF export settings](/slides/ko/python-java/convert-powerpoint-to-tiff/)를 참조하십시오.

**시스템에 원본 글꼴이 없을 경우 메모의 글꼴이 결과에 영향을 미치나요?**

예. 누락된 글꼴은 [font substitution](/slides/ko/python-java/font-selection-sequence/)을 트리거하여 텍스트 측정값과 모양이 변경될 수 있습니다. 원하는 글꼴을 유지하려면 [Supply the required fonts](/slides/ko/python-java/custom-font/)를 제공하십시오.