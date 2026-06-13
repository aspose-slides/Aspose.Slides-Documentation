---
title: PowerPoint 프레젠테이션을 노트와 함께 C++에서 TIFF 로 변환
linktitle: PowerPoint를 노트와 함께 TIFF 로
type: docs
weight: 100
url: /ko/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 TIFF 로
- 프레젠테이션을 TIFF 로
- 슬라이드를 TIFF 로
- PPT를 TIFF 로
- PPTX를 TIFF 로
- PPT를 TIFF 로 저장
- PPTX를 TIFF 로 저장
- PPT를 TIFF 로 내보내기
- PPTX를 TIFF 로 내보내기
- 노트가 포함된 PowerPoint
- 노트가 포함된 프레젠테이션
- 노트가 포함된 슬라이드
- 노트가 포함된 PPT
- 노트가 포함된 PPTX
- 노트가 포함된 TIFF
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ 를 사용하여 노트가 포함된 PowerPoint 프레젠테이션을 TIFF 로 변환합니다. 발표자 노트가 포함된 슬라이드를 효율적으로 내보내는 방법을 배워보세요."
---
## **소개**

Aspose.Slides for C++ 은 PowerPoint 및 OpenDocument 프레젠테이션(PPT, PPTX, ODP)과 노트를 TIFF 형식으로 변환하는 간단한 솔루션을 제공합니다. 이 형식은 고품질 이미지 저장, 인쇄 및 문서 보관에 널리 사용됩니다. Aspose.Slides 를 사용하면 발표자 노트가 포함된 전체 프레젠테이션을 내보낼 수 있을 뿐만 아니라 노트 슬라이드 보기에서 슬라이드 썸네일을 생성할 수도 있습니다. 변환 과정은 간단하고 효율적이며, `Save` 메서드와 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 활용해 노트와 레이아웃을 유지하면서 전체 프레젠테이션을 일련의 TIFF 이미지로 변환합니다.

## **노트와 함께 프레젠테이션을 TIFF로 변환**

Aspose.Slides for C++ 를 사용하여 PowerPoint 또는 OpenDocument 프레젠테이션을 노트와 함께 TIFF 로 저장하려면 다음 단계를 수행합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 인스턴스화합니다: PowerPoint 또는 OpenDocument 파일을 로드합니다.
2. 출력 레이아웃 옵션을 구성합니다: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/notescommentslayoutingoptions/) 클래스를 사용하여 노트와 주석이 표시되는 방식을 지정합니다.
3. 프레젠테이션을 TIFF 로 저장합니다: 구성된 옵션을 [Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/) 메서드에 전달합니다.

예를 들어, 다음과 같은 슬라이드가 포함된 "speaker_notes.pptx" 파일이 있다고 가정해 보겠습니다:

![노트가 포함된 프레젠테이션 슬라이드](slide_with_notes.png)

아래 코드 스니펫은 [set_SlidesLayoutOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) 메서드를 사용하여 노트 슬라이드 보기에서 프레젠테이션을 TIFF 이미지로 변환하는 방법을 보여 줍니다.

```cpp
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // 슬라이드 아래에 노트를 표시합니다.

// 노트 레이아웃이 포함된 TIFF 옵션을 구성합니다.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// 발표자 노트와 함께 프레젠테이션을 TIFF 로 저장합니다.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

결과:

![노트가 포함된 TIFF 이미지](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/ko/conversion/convert-ppt-to-poster-online)를 확인해 보세요.
{{% /alert %}}

## **FAQ**

**결과 TIFF에서 노트 영역의 위치를 제어할 수 있나요?**

예. [notes layout settings](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/)을 사용하여 `None`, `BottomTruncated`, `BottomFull` 등 옵션 중에서 선택할 수 있으며, 각각 노트를 숨기거나 한 페이지에 맞추거나 추가 페이지로 넘겨 표시합니다.

**노트가 포함된 TIFF 파일의 크기를 품질 손실 없이 어떻게 줄일 수 있나요?**

효율적인 압축([efficient compression](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/tiffoptions/set_compressiontype/))(예: `LZW` 또는 `RLE`)을 선택하고 적절한 DPI 를 설정합니다. 또한 허용되는 경우 낮은 [pixel format](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)(예: 8 bpp 혹은 흑백 1 bpp)으로 지정합니다. [image dimensions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/tiffoptions/set_imagesize/)을 약간 줄이는 것도 가독성을 크게 해치지 않으면서 도움이 됩니다.

**시스템에 원본 폰트가 없을 경우 노트의 글꼴이 결과에 영향을 미치나요?**

예. 누락된 폰트는 [substitution](/slides/ko/cpp/font-selection-sequence/)을 유발하여 텍스트 측정값과 모습이 달라질 수 있습니다. 이를 방지하려면 [필요한 폰트 제공](/slides/ko/cpp/custom-font/)하거나 기본 [fallback font](/slides/ko/cpp/fallback-font/)를 설정하여 원하는 글꼴이 사용되도록 합니다.