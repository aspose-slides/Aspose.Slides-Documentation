---
title: PHP에서 발표자 노트가 포함된 PowerPoint 프레젠테이션을 PDF로 변환
linktitle: 발표자 노트가 포함된 PowerPoint를 PDF로 변환
type: docs
weight: 50
url: /ko/php-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 PDF로
- 프레젠테이션을 PDF로
- 슬라이드를 PDF로
- PPT를 PDF로
- PPTX를 PDF로
- 프레젠테이션을 PDF로 저장
- PPT를 PDF로 저장
- PPTX를 PDF로 저장
- PPT를 PDF로 내보내기
- PPTX를 PDF로 내보내기
- 발표자 노트
- 노트가 포함된 PDF
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PPT 및 PPTX 형식을 노트가 포함된 PDF로 변환합니다. 전문가용 프레젠테이션을 위해 레이아웃과 발표자 노트를 보존합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 발표자 노트가 포함된 PDF 형식으로 변환하는 방법을 배웁니다. 이 가이드는 필요한 단계들을 다루고, 작업을 효율적으로 수행할 수 있도록 코드 예제를 제공합니다. 이 문서를 모두 읽고 나면 다음을 수행할 수 있습니다:

- 발표자 노트를 보존하면서 PowerPoint 슬라이드를 PDF 문서로 변환하는 변환 프로세스를 구현합니다.
- 필요에 따라 발표자 노트가 포함되고 형식이 지정된 출력 PDF를 사용자 정의합니다.

내보내기 전에 노트 페이지 크기와 방향을 설정하려면 [Notes Page Size](/slides/ko/php-java/notes-size/)를 참조하십시오.

## **발표자 노트와 함께 PowerPoint를 PDF로 변환**

`save` 메서드는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스에서 PPT 또는 PPTX 프레젠테이션을 발표자 노트가 포함된 PDF로 변환하는 데 사용할 수 있습니다. Aspose.Slides를 사용하면 프레젠테이션을 로드하고, 발표자 노트를 포함하도록 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/notescommentslayoutingoptions/) 클래스를 사용하여 레이아웃 옵션을 구성한 다음 파일을 PDF로 저장하면 됩니다. 다음 코드 스니펫은 샘플 프레젠테이션을 노트 슬라이드 보기로 PDF로 변환하는 방법을 보여줍니다.

```php
$presentation = new Presentation("sample.pptx");

// 발표자 노트를 렌더링하기 위한 PDF 옵션을 구성합니다.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // 슬라이드 아래에 발표자 노트를 렌더링합니다.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// 발표자 노트가 포함된 PDF로 프레젠테이션을 저장합니다.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Note" %}}
Aspose의 [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ko/conversion)를 확인해 보실 수 있습니다.
{{% /alert %}}