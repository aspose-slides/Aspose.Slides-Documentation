---
title: Python에서 노트가 포함된 PDF로 프레젠테이션 변환
linktitle: 프레젠테이션을 노트와 함께 PDF로
type: docs
weight: 50
url: /ko/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- PPT 변환
- PPTX 변환
- ODP 변환
- PowerPoint를 PDF로
- OpenDocument를 PDF로
- 프레젠테이션을 PDF로
- PPT를 PDF로
- PPTX를 PDF로
- ODP를 PDF로
- 강연자 메모
- 노트가 포함된 PDF
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 사용하여 PPT, PPTX 및 ODP 형식을 노트가 포함된 PDF로 변환합니다. 전문가 수준의 프레젠테이션을 위해 레이아웃과 강연자 메모를 보존합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 강의자 메모가 포함된 PDF 형식으로 변환하는 방법을 배웁니다. 이 가이드는 필요한 단계들을 설명하고 작업을 효율적으로 수행할 수 있도록 코드 예제를 제공합니다. 문서의 마지막까지 읽으면 다음을 수행할 수 있게 됩니다.

- PowerPoint 슬라이드를 강의자 메모를 보존하면서 PDF 문서로 변환하는 변환 프로세스를 구현합니다.
- 출력 PDF를 사용자 지정하여 강의자 메모가 포함되고 요구 사항에 맞게 형식이 지정되었는지 확인합니다.

노트 페이지 크기와 방향을 내보내기 전에 설정하려면 [노트 페이지 크기](/slides/ko/python-net/notes-size/)를 참조하십시오.

## **노트를 포함한 PowerPoint를 PDF로 변환**

`save` 메서드는 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스에서 PPT 또는 PPTX 프레젠테이션을 강의자 메모가 포함된 PDF로 변환하는 데 사용할 수 있습니다. Aspose.Slides를 사용하면 프레젠테이션을 로드하고, [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/notescommentslayoutingoptions/) 클래스를 사용하여 레이아웃 옵션을 구성해 강의자 메모를 포함시키고, 파일을 PDF로 저장하면 됩니다. 다음 코드 스니펫은 샘플 프레젠테이션을 노트 슬라이드 보기 형태의 PDF로 변환하는 방법을 보여줍니다.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # 강연자 메모를 렌더링하기 위한 PDF 옵션을 구성합니다.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # 강연자 메모와 함께 프레젠테이션을 PDF로 저장합니다.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="노트" %}}
Aspose [온라인 PowerPoint to PDF 변환기](https://products.aspose.app/slides/ko/conversion)를 확인해 보시기 바랍니다.
{{% /alert %}}