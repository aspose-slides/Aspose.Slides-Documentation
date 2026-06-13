---
title: Java에서 메모가 포함된 PowerPoint 프레젠테이션을 TIFF로 변환
linktitle: 메모가 포함된 PowerPoint를 TIFF로
type: docs
weight: 100
url: /ko/java/convert-powerpoint-to-tiff-with-notes/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 메모가 포함된 PowerPoint 프레젠테이션을 TIFF로 변환합니다. 발표자 메모가 포함된 슬라이드를 효율적으로 내보내는 방법을 배워보세요."
---
## **소개**

Aspose.Slides for Java는 메모가 포함된 PowerPoint 및 OpenDocument 프레젠테이션(PPT, PPTX 및 ODP)을 TIFF 형식으로 변환하는 간단한 솔루션을 제공합니다. 이 형식은 고품질 이미지 저장, 인쇄 및 문서 보관에 널리 사용됩니다. Aspose.Slides를 사용하면 발표자 메모가 포함된 전체 프레젠테이션을 내보낼 수 있을 뿐만 아니라 Notes Slide 보기에서 슬라이드 썸네일을 생성할 수 있습니다. 변환 프로세스는 간단하고 효율적이며, `save` 메서드와 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스를 활용하여 전체 프레젠테이션을 메모와 레이아웃을 유지한 채 일련의 TIFF 이미지로 변환합니다.

## **프레젠테이션을 메모와 함께 TIFF로 변환**

Aspose.Slides for Java를 사용하여 메모가 포함된 PowerPoint 또는 OpenDocument 프레젠테이션을 TIFF로 저장하려면 다음 단계가 필요합니다:

1. Presentation 클래스를 인스턴스화합니다: PowerPoint 또는 OpenDocument 파일을 로드합니다.
1. 출력 레이아웃 옵션을 구성합니다: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/notescommentslayoutingoptions/) 클래스를 사용하여 메모와 주석이 표시되는 방식을 지정합니다.
1. 프레젠테이션을 TIFF로 저장합니다: 구성된 옵션을 [save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 메서드에 전달합니다.

예를 들어, "speaker_notes.pptx" 파일에 다음 슬라이드가 있다고 가정해 보겠습니다:

![발표자 메모가 포함된 프레젠테이션 슬라이드](slide_with_notes.png)

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // 슬라이드 아래에 메모를 표시합니다.

    // Notes 레이아웃을 사용하여 TIFF 옵션을 구성합니다.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 발표자 메모와 함께 프레젠테이션을 TIFF로 저장합니다.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

결과:

![발표자 메모가 포함된 TIFF 이미지](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose의 [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/ko/conversion/convert-ppt-to-poster-online)를 확인해 보세요.
{{% /alert %}}

## **자주 묻는 질문**

**결과 TIFF에서 메모 영역의 위치를 제어할 수 있나요?**

예. [notes layout settings](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)를 사용하여 `None`, `BottomTruncated`, `BottomFull`와 같은 옵션 중에서 선택할 수 있습니다. 각각 메모를 숨기거나, 단일 페이지에 맞추거나, 추가 페이지로 흐르게 합니다.

**메모가 포함된 TIFF 파일 크기를 눈에 띄는 품질 손실 없이 줄이려면 어떻게 해야 하나요?**

효율적인 [compression](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) (예: `LZW` 또는 `RLE`)을 선택하고, 적절한 DPI를 설정하며, 가능하다면 낮은 [pixel format](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (예: 8 bpp 또는 1 bpp 단색)를 사용합니다. 또한 [image dimensions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-)을 약간 줄이면 가독성을 크게 해치지 않으면서도 도움이 됩니다.

**시스템에 원본 폰트가 없을 경우 메모의 폰트가 결과에 영향을 미치나요?**

예. 폰트가 없으면 [substitution](/slides/ko/java/font-selection-sequence/)이 발생하여 텍스트 측정치와 외관이 바뀔 수 있습니다. 이를 방지하려면 [필요한 폰트를 제공](/slides/ko/java/custom-font/)하거나 기본 [fallback font](/slides/ko/java/fallback-font/)를 설정하여 의도한 글꼴을 사용하도록 합니다.