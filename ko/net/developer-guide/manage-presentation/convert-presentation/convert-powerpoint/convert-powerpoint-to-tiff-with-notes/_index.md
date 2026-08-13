---
title: PowerPoint 프레젠테이션을 .NET에서 노트와 함께 TIFF로 변환
linktitle: PowerPoint -> TIFF (노트 포함)
type: docs
weight: 100
url: /ko/net/convert-powerpoint-to-tiff-with-notes/
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
- 노트가 포함된 PowerPoint
- 노트가 포함된 프레젠테이션
- 노트가 포함된 슬라이드
- 노트가 포함된 PPT
- 노트가 포함된 PPTX
- 노트가 포함된 TIFF
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션을 노트와 함께 TIFF로 변환합니다. 발표자 노트가 포함된 슬라이드를 효율적으로 내보내는 방법을 배워보세요."
---
## **소개**

Aspose.Slides for .NET은 PowerPoint 및 OpenDocument 프레젠테이션(PPT, PPTX, ODP)을 노트와 함께 TIFF 형식으로 변환하기 위한 간단한 솔루션을 제공합니다. 이 형식은 고품질 이미지 저장, 인쇄 및 문서 보관에 널리 사용됩니다. Aspose.Slides를 사용하면 발표자 노트가 포함된 전체 프레젠테이션을 내보낼 수 있을 뿐만 아니라 Notes Slide 보기에서 슬라이드 썸네일을 생성할 수도 있습니다. 변환 프로세스는 간단하고 효율적이며, `Save` 메서드를 활용하여 [프레젠테이션](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스로 전체 프레젠테이션을 노트와 레이아웃을 보존한 채 일련의 TIFF 이미지로 변환합니다.

## **프레젠테이션을 노트와 함께 TIFF로 변환**

Aspose.Slides for .NET을 사용하여 PowerPoint 또는 OpenDocument 프레젠테이션을 노트가 포함된 TIFF로 저장하려면 다음 단계를 따릅니다:

1. [프레젠테이션](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스를 인스턴스화합니다: PowerPoint 또는 OpenDocument 파일을 로드합니다.
1. 출력 레이아웃 옵션을 구성합니다: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/notescommentslayoutingoptions/) 클래스를 사용하여 노트와 댓글이 표시되는 방식을 지정합니다.
1. 프레젠테이션을 TIFF로 저장합니다: 구성된 옵션을 [Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/methods/save/index) 메서드에 전달합니다.

예를 들어, "speaker_notes.pptx" 파일에 다음 슬라이드가 있다고 가정해 보겠습니다:

![발표자 노트가 포함된 프레젠테이션 슬라이드](slide_with_notes.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Notes 레이아웃을 사용하여 TIFF 옵션을 구성합니다.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // 슬라이드 아래에 노트를 표시합니다.
        }
    };

    // 발표자 노트가 포함된 프레젠테이션을 TIFF로 저장합니다.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

결과:

![노트가 포함된 TIFF 이미지](TIFF_with_notes.png)

{{% alert title="팁" color="info" %}}
Aspose [무료 PowerPoint 포스터 변환기](https://products.aspose.app/slides/ko/conversion/convert-ppt-to-poster-online)를 확인해 보세요.
{{% /alert %}}

## **FAQ**

### 결과 TIFF에서 노트 영역의 위치를 제어할 수 있나요?

예. [노트 레이아웃 설정](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/slideslayoutoptions/)을 사용하여 `None`, `BottomTruncated`, `BottomFull`과 같은 옵션 중에서 선택할 수 있습니다. 각각 노트를 숨기거나, 한 페이지에 맞추거나, 추가 페이지로 흐르게 합니다.

### 품질 손실 없이 노트가 포함된 TIFF 파일 크기를 줄이려면 어떻게 해야 하나요?

효율적인 압축([예: `LZW` 또는 `RLE`](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/compressiontype/))을 선택하고, 적절한 DPI를 설정하며, 허용된다면 더 낮은 [픽셀 형식](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/pixelformat/)(예: 8 bpp 또는 흑백의 경우 1 bpp)을 사용합니다. [이미지 차원](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/imagesize/)을 약간 줄이는 것도 가독성을 크게 해치지 않으면서 도움이 됩니다.

### 시스템에 원본 폰트가 없을 경우 노트의 폰트가 결과에 영향을 미치나요?

예. 누락된 폰트는 [대체](/slides/ko/net/font-selection-sequence/)를 발생시켜 텍스트 메트릭 및 외관을 변경할 수 있습니다. 이를 방지하려면 [필요한 폰트를 제공](/slides/ko/net/custom-font/)하거나 기본 [대체 폰트](/slides/ko/net/fallback-font/)를 설정하여 의도한 서체가 사용되도록 합니다.