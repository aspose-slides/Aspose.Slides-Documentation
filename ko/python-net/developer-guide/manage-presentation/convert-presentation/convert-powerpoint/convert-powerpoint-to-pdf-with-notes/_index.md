---
title: "Python에서 발표자 노트가 포함된 PDF로 프레젠테이션 변환"
linktitle: "프레젠테이션을 노트와 함께 PDF로 변환"
type: docs
weight: 50
url: /ko/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- "PowerPoint 변환"
- "OpenDocument 변환"
- "프레젠테이션 변환"
- "PPT 변환"
- "PPTX 변환"
- "ODP 변환"
- "PowerPoint를 PDF로"
- "OpenDocument를 PDF로"
- "프레젠테이션을 PDF로"
- "PPT를 PDF로"
- "PPTX를 PDF로"
- "ODP를 PDF로"
- "발표자 노트"
- "노트가 포함된 PDF"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python을 사용하여 PPT, PPTX 및 ODP 형식을 노트가 포함된 PDF로 변환합니다. 전문 프레젠테이션을 위해 레이아웃 및 발표자 노트를 보존합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 발표자 노트가 포함된 PDF 형식으로 변환하는 방법을 배웁니다. 이 가이드는 필요한 단계들을 소개하고 작업을 효율적으로 수행할 수 있도록 코드 예제를 제공합니다. 문서를 모두 읽은 후에는 다음을 수행할 수 있습니다:

- 발표자 노트를 보존하면서 PowerPoint 슬라이드를 PDF 문서로 변환하는 프로세스를 구현합니다.
- 출력 PDF에 발표자 노트를 포함하고 요구 사항에 맞게 형식화하도록 사용자 정의합니다.

## **노트가 포함된 PowerPoint를 PDF로 변환**

`save` 메서드는 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스에서 PPT 또는 PPTX 프레젠테이션을 발표자 노트가 포함된 PDF로 변환하는 데 사용할 수 있습니다. Aspose.Slides를 사용하면 프레젠테이션을 로드하고, [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/notescommentslayoutingoptions/) 클래스를 사용해 노트를 포함하도록 레이아웃 옵션을 구성한 뒤 파일을 PDF로 저장하면 됩니다. 다음 코드 스니펫은 샘플 프레젠테이션을 노트 슬라이드 보기 형태의 PDF로 변환하는 방법을 보여줍니다.

```py
with slides.Presentation("sample.pptx") as presentation:

    # 발표자 노트를 렌더링하기 위한 PDF 옵션 구성.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # 발표자 노트와 함께 프레젠테이션을 PDF로 저장합니다.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="primary" %}} 
Aspose [온라인 PowerPoint to PDF 변환기](https://products.aspose.app/slides/ko/conversion)를 확인해 보세요. 
{{% /alert %}}