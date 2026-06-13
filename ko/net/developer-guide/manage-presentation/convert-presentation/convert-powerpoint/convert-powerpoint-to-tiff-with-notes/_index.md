---
title: .NET에서 메모가 포함된 PowerPoint 프레젠테이션을 TIFF로 변환
linktitle: 메모가 포함된 PowerPoint를 TIFF로
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
- 메모가 포함된 PowerPoint
- 메모가 포함된 프레젠테이션
- 메모가 포함된 슬라이드
- 메모가 포함된 PPT
- 메모가 포함된 PPTX
- 메모가 포함된 TIFF
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 메모가 포함된 PowerPoint 프레젠테이션을 TIFF로 변환합니다. 발표자 메모가 포함된 슬라이드를 효율적으로 내보내는 방법을 배우세요."
---
## **소개**

Aspose.Slides for .NET는 메모가 포함된 PowerPoint 및 OpenDocument 프레젠테이션(PPT, PPTX 및 ODP)을 TIFF 형식으로 변환하는 간단한 솔루션을 제공합니다. 이 형식은 고품질 이미지 저장, 인쇄 및 문서 보관에 널리 사용됩니다. Aspose.Slides를 사용하면 발표자 메모가 포함된 전체 프레젠테이션을 내보낼 수 있을 뿐만 아니라 Notes Slide 뷰에서 슬라이드 썸네일을 생성할 수도 있습니다. 변환 과정은 간단하고 효율적이며, `Save` 메서드를 이용해 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스를 전체 프레젠테이션을 일련의 TIFF 이미지로 변환하면서 메모와 레이아웃을 보존합니다.

## **메모가 포함된 프레젠테이션을 TIFF로 변환**

Aspose.Slides for .NET을 사용하여 메모가 포함된 PowerPoint 또는 OpenDocument 프레젠테이션을 TIFF로 저장하려면 다음 단계를 수행합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스 인스턴스화: PowerPoint 또는 OpenDocument 파일을 로드합니다.
2. 출력 레이아웃 옵션 구성: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/notescommentslayoutingoptions/) 클래스를 사용하여 메모와 주석을 표시할 방식을 지정합니다.
3. 프레젠테이션을 TIFF로 저장: 구성된 옵션을 [Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/methods/save/index) 메서드에 전달합니다.

예를 들어, 다음과 같은 슬라이드가 포함된 "speaker_notes.pptx" 파일이 있다고 가정합니다:

![프레젠테이션 슬라이드와 발표자 메모](slide_with_notes.png)

아래 코드 조각은 [SlidesLayoutOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) 속성을 사용하여 Notes Slide 뷰에서 프레젠테이션을 TIFF 이미지로 변환하는 방법을 보여줍니다.

```c#
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Notes 레이아웃을 적용하여 TIFF 옵션을 구성합니다.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // 슬라이드 아래에 메모를 표시합니다.
        }
    };

    // 발표자 메모와 함께 프레젠테이션을 TIFF로 저장합니다.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

결과:

![메모가 포함된 TIFF 이미지](TIFF_with_notes.png)

{{% alert title="팁" color="primary" %}}

Aspose [무료 PowerPoint → 포스터 변환기](https://products.aspose.app/slides/ko/conversion/convert-ppt-to-poster-online)를 확인하세요.

{{% /alert %}}

## **FAQ**

**결과 TIFF에서 메모 영역의 위치를 제어할 수 있나요?**

예. [notes layout settings](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/slideslayoutoptions/)을 사용하여 `None`, `BottomTruncated`, `BottomFull`과 같이 메모를 숨기거나 한 페이지에 맞추거나 추가 페이지에 흐르게 할지 선택할 수 있습니다.

**품질 손실 없이 메모가 포함된 TIFF 파일 크기를 줄이는 방법은?**

효율적인 압축([compressiontype](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/compressiontype/))을 선택하고(`LZW` 또는 `RLE` 등), 적절한 DPI를 설정하며, 허용 가능한 경우 낮은 [pixel format](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/pixelformat/)(`8 bpp` 또는 흑백용 `1 bpp`)을 사용합니다. 또한 [image dimensions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/imagesize/)을 약간 줄이면 가독성을 크게 해치지 않으면서 파일 크기를 감소시킬 수 있습니다.

**시스템에 원본 폰트가 없을 경우 메모의 폰트가 결과에 영향을 미치나요?**

예. 누락된 폰트는 [substitution](/slides/ko/net/font-selection-sequence/)을 일으켜 텍스트 메트릭과 외관을 변경할 수 있습니다. 이를 방지하려면 [필요한 폰트 제공](/slides/ko/net/custom-font/)하거나 기본 [fallback font](/slides/ko/net/fallback-font/)를 설정하여 의도한 글꼴이 사용되도록 합니다.