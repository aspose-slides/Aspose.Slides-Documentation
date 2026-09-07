---
title: Python via Java에서 PowerPoint 프레젠테이션을 SWF Flash로 변환
linktitle: PowerPoint를 SWF로
type: docs
weight: 80
url: /ko/python-java/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 SWF로
- 프레젠테이션을 SWF로
- 슬라이드를 SWF로
- PPT를 SWF로
- PPTX를 SWF로
- PowerPoint를 Flash로
- 프레젠테이션을 Flash로
- 슬라이드를 Flash로
- PPT를 Flash로
- PPTX를 Flash로
- PPT를 SWF로 저장
- PPTX를 SWF로 저장
- PPT를 SWF로 내보내기
- PPTX를 SWF로 내보내기
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python via Java에서 PowerPoint 프레젠테이션을 SWF Flash로 변환합니다. 뷰어, 노트, 숨겨진 슬라이드, 압축 및 글꼴을 구성합니다."
---
## **개요**

Aspose.Slides for Python via Java를 사용하면 Microsoft PowerPoint 없이 PowerPoint 프레젠테이션을 SWF로 변환할 수 있습니다. 프레젠테이션을 내보내려면 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save)를 사용하고, 뷰어 설정, 이미지 품질 및 노트 또는 주석 레이아웃을 구성하려면 [SwfOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/swfoptions/)를 사용합니다.

## **프레젠테이션을 Flash로 변환**

[Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)으로 원본 파일을 로드하고, [SwfOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/swfoptions/)를 구성한 다음, [SaveFormat.Swf](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Swf)를 사용하여 저장합니다.

다음 예제는 `presentation.pptx`를 `presentation.swf`로 내보냅니다. [setViewerIncluded](https://reference.aspose.com/slides/ko/python-java/aspose.slides/swfoptions/#setViewerIncluded)를 사용하여 임베디드 뷰어를 비활성화하고, [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/)를 사용하여 슬라이드 아래에 발표자 노트를 포함합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

예제를 실행하기 전에 [Aspose.Slides for Python via Java 설치](/slides/ko/python-java/installation/)를 하고 `presentation.pptx`를 작업 디렉터리에 배치하십시오. JVM은 Python 프로세스당 한 번 시작됩니다.

예제는 [setNotesPosition](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition)를 통해 [NotesPositions.BottomFull](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notespositions/#BottomFull)를 적용하고 레이아웃을 [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions)에 전달합니다. 주석도 포함하려면 내보내기 전에 [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition)를 구성하십시오.

## **자주 묻는 질문**

**SWF에 숨겨진 슬라이드를 포함할 수 있나요?**

예. `True`와 함께 [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/swfoptions/#setShowHiddenSlides)를 호출하십시오. 기본적으로 숨겨진 슬라이드는 내보내지 않습니다.

**압축 및 최종 SWF 크기를 어떻게 제어합니까?**

[SwfOptions.setCompressed](https://reference.aspose.com/slides/ko/python-java/aspose.slides/swfoptions/#setCompressed)를 사용하여 압축을 활성화하거나 비활성화하고, [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/ko/python-java/aspose.slides/swfoptions/#setJpegQuality)를 사용하여 JPEG 이미지 품질을 조정합니다. JPEG 품질을 낮추면 이미지 품질이 감소하는 대가로 파일 크기를 줄일 수 있습니다.

**임베디드 뷰어는 무엇을 위한 것이며, 언제 비활성화해야 하나요?**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/ko/python-java/aspose.slides/swfoptions/#setViewerIncluded)는 생성된 SWF에 뷰어가 포함될지를 제어합니다. 위 예제와 같이 임베디드 뷰어 없이 내보낸 슬라이드가 필요할 때 `False`를 전달하십시오.

**내보내기 머신에 원본 폰트가 없으면 어떻게 되나요?**

[setDefaultRegularFont](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveoptions/#setDefaultRegularFont)를 사용하여 기본 일반 폰트를 지정할 수 있으며, 이는 [SwfOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/swfoptions/)에 상속됩니다. 내보내기 프로세스에서 사용할 수 있는 폰트를 선택하십시오; 폰트 대체는 텍스트 모양 및 레이아웃을 변경할 수 있습니다.