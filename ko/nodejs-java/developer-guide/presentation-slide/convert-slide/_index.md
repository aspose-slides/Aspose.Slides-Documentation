---
title: JavaScript에서 프레젠테이션 슬라이드를 이미지로 변환
linktitle: 슬라이드 이미지 변환
type: docs
weight: 35
url: /ko/nodejs-java/convert-slide/
keywords:
- 슬라이드 변환
- 슬라이드 내보내기
- 슬라이드 이미지 변환
- 슬라이드를 이미지로 저장
- 슬라이드 PNG 변환
- 슬라이드 JPEG 변환
- 슬라이드 비트맵 변환
- 슬라이드 TIFF 변환
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PPT, PPTX 및 ODP 슬라이드를 JavaScript에서 이미지로 변환 — 빠르고 고품질 렌더링과 명확한 코드 예제 제공."
---
## **Introduction**

Aspose.Slides for Node.js via Java를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션 슬라이드를 BMP, PNG, JPG (JPEG), GIF 등 다양한 이미지 형식으로 쉽게 변환할 수 있습니다.

슬라이드를 이미지로 변환하려면 다음 단계를 따르세요:

1. 원하는 변환 설정을 정의하고 내보내려는 슬라이드를 다음을 사용하여 선택합니다:
    - [TiffOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tiffoptions/) 클래스, 또는
    - [RenderingOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/renderingoptions/) 클래스.
2. [getImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/#getImage) 메서드를 호출하여 슬라이드 이미지를 생성합니다.

Aspose.Slides for Node.js via Java에서 [IImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/)는 픽셀 데이터로 정의된 이미지를 다룰 수 있는 클래스입니다. 이 클래스를 사용하여 BMP, JPG, PNG 등 다양한 형식으로 이미지를 저장할 수 있습니다.

## **슬라이드를 비트맵으로 변환하고 PNG로 저장**

슬라이드를 비트맵 객체로 변환하여 애플리케이션에서 직접 사용할 수 있습니다. 또는 슬라이드를 비트맵으로 변환한 후 JPEG 등 원하는 형식으로 이미지를 저장할 수 있습니다.

다음 JavaScript 코드는 프레젠테이션의 첫 번째 슬라이드를 비트맵 객체로 변환한 후 PNG 형식으로 이미지를 저장하는 방법을 보여줍니다:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 프레젠테이션의 첫 번째 슬라이드를 비트맵으로 변환합니다.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // 이미지를 PNG 형식으로 저장합니다.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **사용자 지정 크기로 슬라이드를 이미지로 변환**

특정 크기의 이미지가 필요할 수 있습니다. [getImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/#getImage) 의 오버로드를 사용하면 슬라이드를 특정 차원(폭 및 높이)으로 이미지로 변환할 수 있습니다.

다음 샘플 코드는 이를 수행하는 방법을 보여줍니다:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 지정된 크기로 프레젠테이션의 첫 번째 슬라이드를 비트맵으로 변환합니다.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // 이미지를 JPEG 형식으로 저장합니다.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **노트와 코멘트가 포함된 슬라이드를 이미지로 변환**

일부 슬라이드에는 노트와 코멘트가 포함될 수 있습니다.

Aspose.Slides는 프레젠테이션 슬라이드를 이미지로 렌더링하는 방식을 제어할 수 있는 두 클래스—[TiffOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tiffoptions/) 및 [RenderingOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/renderingoptions/)—를 제공합니다. 두 클래스 모두 슬라이드가 이미지로 변환될 때 노트와 코멘트의 렌더링을 구성할 수 있는 `setSlidesLayoutOptions` 메서드를 포함합니다.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/notescommentslayoutingoptions/) 클래스를 사용하면 결과 이미지에서 노트와 코멘트의 원하는 위치를 지정할 수 있습니다.

다음 JavaScript 코드는 노트와 코멘트가 있는 슬라이드를 변환하는 방법을 보여줍니다:

```js
const scaleX = 2;
const scaleY = scaleX;

// 프레젠테이션 파일을 로드합니다.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // 노트의 위치를 설정합니다.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // 코멘트의 위치를 설정합니다.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // 코멘트 영역의 너비를 설정합니다.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // 코멘트 영역의 색상을 설정합니다.

    // 렌더링 옵션을 생성합니다.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // 프레젠테이션의 첫 번째 슬라이드를 이미지로 변환합니다.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // 이미지를 GIF 형식으로 저장합니다.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
슬라이드-이미지 변환 과정에서 [setNotesPosition](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 메서드는 노트 텍스트가 너무 커서 지정된 이미지 크기에 맞출 수 없기 때문에 `BottomFull`(노트 위치 지정)를 적용할 수 없습니다.
{{% /alert %}} 

## **TIFF 옵션을 사용하여 슬라이드를 이미지로 변환**

[TiffOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tiffoptions/) 클래스는 크기, 해상도, 색상 팔레트 등과 같은 매개변수를 지정하여 결과 TIFF 이미지에 대한 더 큰 제어를 제공합니다.

다음 JavaScript 코드는 TIFF 옵션을 사용하여 300 DPI 해상도와 2160 × 2800 크기의 흑백 이미지를 출력하는 변환 과정을 보여줍니다:

```js
// 프레젠테이션 파일을 로드합니다.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // 프레젠테이션에서 첫 번째 슬라이드를 가져옵니다.
    let slide = presentation.getSlides().get_Item(0);

    // 출력 TIFF 이미지의 설정을 구성합니다.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // 이미지 크기를 설정합니다.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // 픽셀 형식을 설정합니다 (흑백).
    tiffOptions.setDpiX(300);                                                          // 가로 해상도를 설정합니다.
    tiffOptions.setDpiY(300);                                                          // 세로 해상도를 설정합니다.

    // 지정된 옵션으로 슬라이드를 이미지로 변환합니다.
    let image = slide.getImage(tiffOptions);
    try {
        // 이미지를 TIFF 형식으로 저장합니다.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
JDK 9 이전 버전에서는 Tiff 지원이 보장되지 않습니다.
{{% /alert %}} 

## **모든 슬라이드를 이미지로 변환**

Aspose.Slides를 사용하면 프레젠테이션의 모든 슬라이드를 이미지로 변환하여 전체 프레젠테이션을 일련의 이미지로 효과적으로 변환할 수 있습니다.

다음 샘플 코드는 프레젠테이션의 모든 슬라이드를 JavaScript로 이미지로 변환하는 방법을 보여줍니다:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 프레젠테이션을 슬라이드별로 이미지로 렌더링합니다.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // 숨김 슬라이드를 제어합니다 (숨김 슬라이드는 렌더링하지 않음).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // 슬라이드를 이미지로 변환합니다.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // 이미지를 JPEG 형식으로 저장합니다.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Aspose.Slides가 애니메이션이 포함된 슬라이드 렌더링을 지원하나요?**

아니요, `getImage` 메서드는 애니메이션 없이 슬라이드의 정적인 이미지만 저장합니다.

**숨겨진 슬라이드를 이미지로 내보낼 수 있나요?**

예, 숨겨진 슬라이드도 일반 슬라이드와 동일하게 처리할 수 있습니다. 처리 루프에 포함되어 있는지 확인하면 됩니다.

**그림자와 효과를 적용하여 이미지를 저장할 수 있나요?**

예, Aspose.Slides는 슬라이드를 이미지로 저장할 때 그림자, 투명도 및 기타 그래픽 효과를 렌더링하는 것을 지원합니다.