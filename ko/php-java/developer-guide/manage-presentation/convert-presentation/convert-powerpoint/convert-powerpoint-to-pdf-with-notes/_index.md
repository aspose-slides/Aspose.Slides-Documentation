---
title: PHP에서 메모가 포함된 PDF로 PowerPoint 프레젠테이션 변환
linktitle: 메모가 포함된 PowerPoint to PDF
type: docs
weight: 50
url: /ko/php-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint to PDF
- 프레젠테이션을 PDF로
- 슬라이드를 PDF로
- PPT to PDF
- PPTX to PDF
- 프레젠테이션을 PDF로 저장
- PPT를 PDF로 저장
- PPTX를 PDF로 저장
- PPT를 PDF로 내보내기
- PPTX를 PDF로 내보내기
- 발표자 메모
- 메모가 포함된 PDF
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP를 Java를 통해 사용하여 PPT와 PPTX 형식을 메모가 포함된 PDF로 변환합니다. 전문 프레젠테이션을 위해 레이아웃과 발표자 메모를 보존합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 발표자 메모가 포함된 PDF 형식으로 변환하는 방법을 배우게 됩니다. 이 가이드는 필요한 단계들을 다루고, 작업을 효율적으로 수행할 수 있도록 코드 예제를 제공합니다. 이 문서를 마치면 다음을 수행할 수 있습니다:

- 발표자 메모를 보존하면서 PowerPoint 슬라이드를 PDF 문서로 변환하는 프로세스를 구현합니다.
- 필요에 따라 발표자 메모가 포함되고 형식이 지정되도록 출력 PDF를 사용자 정의합니다.

## **발표자 메모와 함께 PowerPoint를 PDF로 변환**

`save` 메서드는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스에서 PPT 또는 PPTX 프레젠테이션을 발표자 메모가 포함된 PDF로 변환하는 데 사용할 수 있습니다. Aspose.Slides를 사용하면 프레젠테이션을 로드하고, 발표자 메모를 포함하도록 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/notescommentslayoutingoptions/) 클래스를 사용하여 레이아웃 옵션을 구성한 후 파일을 PDF로 저장하면 됩니다. 다음 코드 스니펫은 샘플 프레젠테이션을 노트 슬라이드 보기로 PDF로 변환하는 방법을 보여 줍니다.

```php
$presentation = new Presentation("sample.pptx");

// 발표자 메모를 렌더링하기 위한 PDF 옵션을 구성합니다.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // 슬라이드 아래에 발표자 메모를 렌더링합니다.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// 발표자 메모가 포함된 PDF로 프레젠테이션을 저장합니다.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="primary" %}} 
Aspose [온라인 PowerPoint to PDF 변환기](https://products.aspose.app/slides/ko/conversion)를 확인해 보세요. 
{{% /alert %}}