---
title: C++에서 PowerPoint 프레젠테이션을 노트와 함께 TIFF로 변환
linktitle: PowerPoint를 노트와 함께 TIFF 변환
type: docs
weight: 100
url: /ko/cpp/convert-powerpoint-to-tiff-with-notes/
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
- 노트가 있는 PowerPoint
- 노트가 있는 프레젠테이션
- 노트가 있는 슬라이드
- 노트가 있는 PPT
- 노트가 있는 PPTX
- 노트가 있는 TIFF
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션을 노트와 함께 TIFF로 변환합니다. 발표자 노트를 포함한 슬라이드를 효율적으로 내보내는 방법을 배워보세요."
---
## **소개**

Aspose.Slides for C++는 PowerPoint 및 OpenDocument 프레젠테이션(PPT, PPTX 및 ODP)을 노트와 함께 TIFF 형식으로 변환하기 위한 간단한 솔루션을 제공합니다. 이 형식은 고품질 이미지 저장, 인쇄 및 문서 보관에 널리 사용됩니다. Aspose.Slides를 사용하면 발표자 노트가 포함된 전체 프레젠테이션을 내보낼 수 있을 뿐만 아니라 Notes Slide 보기에서 슬라이드 썸네일을 생성할 수 있습니다. 변환 과정은 간단하고 효율적이며, `Save` 메서드와 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 활용해 전체 프레젠테이션을 노트와 레이아웃을 유지하면서 일련의 TIFF 이미지로 변환합니다.

## **프레젠테이션을 노트와 함께 TIFF로 변환**

Aspose.Slides for C++를 사용하여 PowerPoint 또는 OpenDocument 프레젠테이션을 노트와 함께 TIFF로 저장하려면 다음 단계가 필요합니다:

1. Presentation 클래스를 인스턴스화합니다: PowerPoint 또는 OpenDocument 파일을 로드합니다.
2. 출력 레이아웃 옵션을 구성합니다: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/notescommentslayoutingoptions/) 클래스를 사용하여 노트와 주석이 어떻게 표시될지 지정합니다.
3. 프레젠테이션을 TIFF로 저장합니다: 구성된 옵션을 [Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/) 메서드에 전달합니다.

예를 들어, 다음 슬라이드를 포함한 "speaker_notes.pptx" 파일이 있다고 가정해 보겠습니다:

![발표자 노트가 포함된 프레젠테이션 슬라이드](slide_with_notes.png)

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // 슬라이드 아래에 노트를 표시합니다.

// Configure the TIFF options with Notes layouting.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to TIFF with the speaker notes.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

결과:

![발표자 노트가 포함된 TIFF 이미지](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
다음 Aspose [무료 PowerPoint 포스터 변환기](https://products.aspose.app/slides/ko/conversion/convert-ppt-to-poster-online)를 확인해 보세요.
{{% /alert %}}

## **자주 묻는 질문**

### 결과 TIFF에서 노트 영역의 위치를 제어할 수 있나요?

예. [notes layout settings](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/)을 사용하여 `None`, `BottomTruncated`, `BottomFull`와 같은 옵션 중에서 선택할 수 있습니다. 각각 노트를 숨기거나, 단일 페이지에 맞추거나, 추가 페이지로 흐르게 합니다.

### 품질 저하 없이 노트가 포함된 TIFF 파일의 크기를 줄이는 방법은?

[효율적인 압축](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (예: `LZW` 또는 `RLE`)을 선택하고, 적절한 DPI를 설정하며, 허용되는 경우 낮은 [pixel format](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (예: 흑백의 경우 8 bpp 또는 1 bpp)을 사용합니다. 또한 [image dimensions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/tiffoptions/set_imagesize/)을 약간 줄이면 가독성을 크게 해치지 않으면서도 도움이 됩니다.

### 시스템에 원본 글꼴이 없을 경우 노트의 글꼴이 결과에 영향을 미치나요?

예. 누락된 글꼴은 [substitution](/slides/ko/cpp/font-selection-sequence/)를 일으켜 텍스트 메트릭 및 외형이 바뀔 수 있습니다. 이를 방지하려면 [필요한 글꼴을 제공](/slides/ko/cpp/custom-font/)하거나 기본 [fallback font](/slides/ko/cpp/fallback-font/)를 설정하여 원하는 서체를 사용하도록 해야 합니다.