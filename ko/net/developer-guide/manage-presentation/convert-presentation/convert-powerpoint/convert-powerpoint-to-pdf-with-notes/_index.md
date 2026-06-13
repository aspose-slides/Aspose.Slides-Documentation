---
title: PowerPoint 프레젠테이션을 .NET에서 메모와 함께 PDF로 변환
linktitle: 메모가 포함된 PowerPoint PDF 변환
type: docs
weight: 50
url: /ko/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint PDF 변환
- 프레젠테이션 PDF 변환
- 슬라이드 PDF 변환
- PPT PDF 변환
- PPTX PDF 변환
- 프레젠테이션 PDF 저장
- PPT PDF 저장
- PPTX PDF 저장
- PPT PDF 내보내기
- PPTX PDF 내보내기
- 발표자 메모
- 메모가 포함된 PDF
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PPT 및 PPTX 형식을 메모가 포함된 PDF로 변환합니다. 전문적인 프레젠테이션을 위해 레이아웃과 발표자 메모를 보존합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 발표자 메모가 포함된 PDF 형식으로 변환하는 방법을 배웁니다. 이 가이드는 필요한 단계들을 다루며 작업을 효율적으로 수행할 수 있도록 코드 예제를 제공합니다. 문서를 끝까지 읽으면 다음을 수행할 수 있습니다:

- 발표자 메모를 보존하면서 PowerPoint 슬라이드를 PDF 문서로 변환하는 프로세스를 구현합니다.
- 출력 PDF를 사용자 정의하여 발표자 메모가 포함되고 요구 사항에 맞게 형식이 지정되도록 합니다.

## **발표자 메모와 함께 PowerPoint를 PDF로 변환**

`Save` 메서드는 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스에서 PPT 또는 PPTX 프레젠테이션을 발표자 메모가 포함된 PDF로 변환하는 데 사용할 수 있습니다. Aspose.Slides를 사용하면 프레젠테이션을 로드하고, 발표자 메모를 포함하도록 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/notescommentslayoutingoptions/) 클래스를 사용해 레이아웃 옵션을 구성한 다음 파일을 PDF로 저장하면 됩니다. 다음 코드 스니펫은 샘플 프레젠테이션을 노트 슬라이드 보기로 PDF로 변환하는 방법을 보여줍니다.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 발표자 메모를 렌더링하기 위한 PDF 옵션을 구성합니다.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // 슬라이드 아래에 발표자 메모를 렌더링합니다.
        }
    };

    // 발표자 메모와 함께 프레젠테이션을 PDF로 저장합니다.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="primary" %}} 
Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ko/conversion)를 확인해 보세요. 
{{% /alert %}}