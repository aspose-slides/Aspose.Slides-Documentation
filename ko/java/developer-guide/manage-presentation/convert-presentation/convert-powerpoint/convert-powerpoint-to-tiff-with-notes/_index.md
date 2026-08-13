---
title: Java에서 노트가 포함된 PowerPoint 프레젠테이션을 TIFF로 변환
linktitle: 노트가 포함된 PowerPoint를 TIFF로 변환
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
- 노트가 포함된 PowerPoint
- 노트가 포함된 프레젠테이션
- 노트가 포함된 슬라이드
- 노트가 포함된 PPT
- 노트가 포함된 PPTX
- 노트가 포함된 TIFF
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 노트가 포함된 PowerPoint 프레젠테이션을 TIFF로 변환합니다. 발표자 노트가 포함된 슬라이드를 효율적으로 내보내는 방법을 알아보세요."
---
## **소개**

Aspose.Slides for Java는 노트가 포함된 PowerPoint 및 OpenDocument 프레젠테이션(PPT, PPTX 및 ODP)을 TIFF 형식으로 변환하는 간단한 솔루션을 제공합니다. 이 형식은 고품질 이미지 저장, 인쇄 및 문서 보관에 널리 사용됩니다. Aspose.Slides를 사용하면 발표자 노트가 포함된 전체 프레젠테이션을 내보낼 수 있을 뿐만 아니라 노트 슬라이드 보기에서 슬라이드 썸네일을 생성할 수도 있습니다. 변환 과정은 간단하고 효율적이며, [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 `save` 메서드를 활용해 전체 프레젠테이션을 노트와 레이아웃을 유지한 채 일련의 TIFF 이미지로 변환합니다.

## **노트가 포함된 프레젠테이션을 TIFF로 변환**

Aspose.Slides for Java를 사용해 PowerPoint 또는 OpenDocument 프레젠테이션을 노트와 함께 TIFF로 저장하려면 다음 단계를 수행합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스를 인스턴스화합니다: PowerPoint 또는 OpenDocument 파일을 로드합니다.
1. 출력 레이아웃 옵션을 구성합니다: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/notescommentslayoutingoptions/) 클래스를 사용해 노트와 댓글을 표시할 방식을 지정합니다.
1. 프레젠테이션을 TIFF로 저장합니다: 구성된 옵션을 [save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 메서드에 전달합니다.

예를 들어, 다음 슬라이드가 포함된 "speaker_notes.pptx" 파일이 있다고 가정해 보겠습니다:

![The presentation slide with speaker notes](slide_with_notes.png)

아래 코드 스니펫은 [setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 메서드를 사용해 노트 슬라이드 보기에서 프레젠테이션을 TIFF 이미지로 변환하는 방법을 보여줍니다.

```java
import com.aspose.slides.*;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // 슬라이드 아래에 노트를 표시합니다.

    // 노트 레이아웃을 적용하여 TIFF 옵션을 구성합니다.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 발표자 노트와 함께 프레젠테이션을 TIFF로 저장합니다.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

결과:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Aspose 를 확인해 보세요 [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/ko/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

### 결과 TIFF에서 노트 영역의 위치를 제어할 수 있나요?

예. [notes layout settings](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)을 사용해 `None`, `BottomTruncated`, `BottomFull`과 같은 옵션 중에서 선택할 수 있습니다. 각각 노트를 숨기고, 단일 페이지에 맞추며, 추가 페이지로 흐르게 합니다.

### 품질 저하 없이 노트가 포함된 TIFF 파일 크기를 줄이는 방법은?

효율적인 압축([efficient compression](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tiffoptions/#setCompressionType-int-))(예: `LZW` 또는 `RLE`)을 선택하고, 적절한 DPI를 설정하며, 허용된다면 낮은 [pixel format](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-)(예: 8 bpp 또는 1 bpp 단색)을 사용합니다. 또한 [image dimensions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-)을 약간 줄이면 가독성을 크게 해치지 않으면서도 도움이 됩니다.

### 시스템에 원본 폰트가 없을 경우 노트의 폰트가 결과에 영향을 미치나요?

예. 누락된 폰트는 [substitution](/slides/ko/java/font-selection-sequence/)을 일으켜 텍스트 메트릭과 외관을 변경할 수 있습니다. 이를 방지하려면 [필요한 폰트 제공](/slides/ko/java/custom-font/)하거나 기본 [fallback font](/slides/ko/java/fallback-font/)를 설정해 원하는 서체가 사용되도록 합니다.