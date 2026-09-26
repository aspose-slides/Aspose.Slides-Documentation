---
title: Python에서 발표자 노트와 함께 PowerPoint 프레젠테이션을 PDF로 변환
linktitle: PowerPoint를 노트와 함께 PDF
type: docs
weight: 50
url: /ko/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 PDF로
- 프레젠테이션을 PDF로
- PPT를 PDF로
- PPTX를 PDF로
- 프레젠테이션을 PDF로 저장
- PPT를 PDF로 내보내기
- PPTX를 PDF로 내보내기
- 발표자 노트
- 노트가 포함된 PDF
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PPT 및 PPTX 프레젠테이션을 발표자 노트와 함께 PDF로 변환합니다. 노트 위치를 구성하고 긴 노트를 보존합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션을 발표자 노트와 함께 PDF로 변환하는 방법을 설명합니다. 각 슬라이드 아래에 노트를 포함시킬 수 있으며, 긴 노트는 추가 페이지에 이어서 표시할 수 있습니다. 다른 PDF 내보내기 설정에 대해서는 [Convert PowerPoint to PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/)를 참조하십시오.

내보내기 전에 노트 페이지 크기와 방향을 설정하려면 [Notes Page Size](/slides/ko/python-java/notes-size/)를 참조하십시오.

## **노트를 포함하여 PowerPoint를 PDF로 변환**

[PPT] 혹은 PPTX 프레젠테이션을 PDF로 내보내려면 [Presentation] 클래스의 [save] 메서드를 사용합니다. 발표자 노트를 포함하려면 [NotesCommentsLayoutingOptions] 개체를 생성하고 해당 개체의 [setNotesPosition] 메서드로 노트 위치를 설정합니다. 이 레이아웃을 [PdfOptions]에 [setSlidesLayoutOptions]를 사용하여 지정합니다.

다음 예제는 `sample.pptx`를 로드하고 슬라이드 아래에 발표자 노트를 포함하여 `output.pdf`로 내보냅니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # 발표자 노트를 렌더링하기 위한 PDF 옵션 구성.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # 발표자 노트와 함께 프레젠테이션을 PDF로 저장.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
또한 [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ko/conversion)를 이용해볼 수 있습니다.
{{% /alert %}}

## **FAQ**

**긴 발표자 노트가 잘리는 것을 어떻게 방지할 수 있나요?**

[NotesPositions.BottomFull]을 사용하십시오(위 예제와 동일). 이 설정은 전체 노트를 표시하며, 필요한 경우 추가 페이지를 사용합니다.

**각 슬라이드와 해당 노트를 한 페이지에 유지할 수 있나요?**

[NotesPositions.BottomTruncated]를 사용하십시오. 이 설정은 노트를 한 페이지로 제한하므로, 내용이 맞지 않을 경우 잘릴 수 있습니다.

**발표자 노트 없이 슬라이드를 내보내려면 어떻게 해야 하나요?**

노트 레이아웃 구성을 생략하고 [Convert PowerPoint to PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/)에 설명된 표준 PDF 내보내기를 사용하십시오.