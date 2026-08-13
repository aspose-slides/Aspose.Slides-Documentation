---
title: C++에서 노트가 포함된 PowerPoint 프레젠테이션을 PDF로 변환
linktitle: PowerPoint를 노트와 함께 PDF로 변환
type: docs
weight: 50
url: /ko/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 PDF로 변환
- 프레젠테이션을 PDF로 변환
- 슬라이드를 PDF로 변환
- PPT를 PDF로 변환
- PPTX를 PDF로 변환
- 프레젠테이션을 PDF로 저장
- PPT를 PDF로 저장
- PPTX를 PDF로 저장
- PPT를 PDF로 내보내기
- PPTX를 PDF로 내보내기
- 발표자 노트
- 노트가 포함된 PDF
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PPT 및 PPTX 형식을 노트가 포함된 PDF로 변환합니다. 레이아웃과 발표자 노트를 보존하여 전문적인 프레젠테이션을 만들 수 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 발표자 노트가 포함된 PDF 형식으로 변환하는 방법을 배웁니다. 이 가이드는 필요한 단계들을 다루고 코드 예제를 제공하여 작업을 효율적으로 수행할 수 있도록 도와줍니다. 문서를 다 읽으면 다음을 수행할 수 있게 됩니다:

- 발표자 노트를 보존하면서 PowerPoint 슬라이드를 PDF 문서로 변환하는 프로세스를 구현합니다.
- 출력 PDF에 발표자 노트가 포함되고 요구 사항에 맞게 형식이 지정되도록 사용자 지정합니다.

## **노트와 함께 PowerPoint를 PDF로 변환**

`Save` 메서드는 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스에서 PPT 또는 PPTX 프레젠테이션을 발표자 노트가 포함된 PDF로 변환하는 데 사용할 수 있습니다. Aspose.Slides를 사용하면 프레젠테이션을 로드하고, [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/notescommentslayoutingoptions/) 클래스를 사용해 레이아웃 옵션을 구성하여 발표자 노트를 포함한 다음 파일을 PDF로 저장하면 됩니다. 다음 코드 스니펫은 샘플 프레젠테이션을 노트 슬라이드 보기로 PDF로 변환하는 방법을 보여줍니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configure PDF options for rendering speaker notes.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // 슬라이드 아래에 발표자 노트를 렌더링합니다.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ko/conversion)를 확인해 보세요. 
{{% /alert %}}