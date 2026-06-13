---
title: Android에서 프레젠테이션 슬라이드를 이미지로 변환하기
linktitle: 슬라이드 이미지 변환
type: docs
weight: 35
url: /ko/androidjava/convert-slide/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 PPT, PPTX 및 ODP 슬라이드를 이미지로 변환—빠르고 고품질의 렌더링과 명확한 Java 코드 예제 제공."
---
## **소개**

Aspose.Slides for Android via Java를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션 슬라이드를 BMP, PNG, JPG (JPEG), GIF 등 다양한 이미지 형식으로 쉽게 변환할 수 있습니다.

슬라이드를 이미지로 변환하려면 다음 단계를 따르세요:

1. 원하는 변환 설정을 정의하고 내보낼 슬라이드를 선택합니다. 다음 인터페이스 중 하나를 사용합니다:
    - The [ITiffOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itiffoptions/) interface,
    - The [IRenderingOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/irenderingoptions/) interface.
2. [getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islide/#getImage--) 메서드를 호출하여 슬라이드 이미지를 생성합니다.

Aspose.Slides for Android via Java에서 [IImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/)은 픽셀 데이터로 정의된 이미지를 다룰 수 있는 인터페이스입니다. 이 인터페이스를 사용하면 BMP, JPG, PNG 등 다양한 형식으로 이미지를 저장할 수 있습니다.

## **슬라이드를 비트맵으로 변환하고 PNG로 저장하기**

슬라이드를 비트맵 객체로 변환하여 애플리케이션에서 직접 사용할 수 있습니다. 또는 슬라이드를 비트맵으로 변환한 뒤 JPEG 등 원하는 형식으로 저장할 수도 있습니다.

다음 코드는 프레젠테이션의 첫 번째 슬라이드를 비트맵 객체로 변환하고 PNG 형식으로 저장하는 방법을 보여 줍니다:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 프레젠테이션의 첫 번째 슬라이드를 비트맵으로 변환합니다.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // 이미지를 PNG 형식으로 저장합니다.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **맞춤 크기로 슬라이드 이미지 변환하기**

특정 크기의 이미지가 필요할 수 있습니다. [getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-)의 오버로드를 사용하면 지정된 가로·세로 크기로 슬라이드를 이미지로 변환할 수 있습니다.

다음 샘플 코드는 이를 구현하는 방법을 보여 줍니다:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 프레젠테이션의 첫 번째 슬라이드를 지정된 크기의 비트맵으로 변환합니다.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // 이미지를 JPEG 형식으로 저장합니다.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **노트 및 주석이 포함된 슬라이드 이미지 변환하기**

일부 슬라이드에는 노트와 주석이 포함될 수 있습니다.

Aspose.Slides는 [ITiffOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itiffoptions/)와 [IRenderingOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/irenderingoptions/) 두 인터페이스를 제공하여 프레젠테이션 슬라이드를 이미지로 렌더링하는 방식을 제어할 수 있습니다. 두 인터페이스 모두 `setSlidesLayoutOptions` 메서드를 포함하고 있으며, 이를 통해 슬라이드 변환 시 노트와 주석의 렌더링을 구성할 수 있습니다.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/notescommentslayoutingoptions/) 클래스를 사용하면 결과 이미지에서 노트와 주석의 위치를 원하는 대로 지정할 수 있습니다.

다음 코드는 노트와 주석이 포함된 슬라이드를 변환하는 예시를 보여 줍니다:

```java 
float scaleX = 2;
float scaleY = scaleX;

// 프레젠테이션 파일을 로드합니다.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // 노트의 위치를 설정합니다.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // 댓글의 위치를 설정합니다.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // 댓글 영역의 너비를 설정합니다.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // 댓글 영역의 색상을 설정합니다.

    // 렌더링 옵션을 생성합니다.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // 프레젠테이션의 첫 번째 슬라이드를 이미지로 변환합니다.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // 이미지를 GIF 형식으로 저장합니다.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
슬라이드‑이미지 변환 과정에서 [setNotesPosition](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) 메서드는 `BottomFull`을 적용할 수 없습니다. 이는 노트 텍스트가 너무 길어 지정된 이미지 크기에 맞추기 어려울 경우 발생합니다.
{{% /alert %}} 

## **TIFF 옵션을 사용하여 슬라이드 이미지 변환하기**

[ITiffOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itiffoptions/) 인터페이스를 사용하면 크기, 해상도, 색상 팔레트 등 다양한 매개변수를 지정하여 결과 TIFF 이미지에 대한 제어권을 크게 확대할 수 있습니다.

다음 코드는 TIFF 옵션을 사용하여 300 DPI 해상도와 2160 × 2800 크기의 흑백 이미지를 출력하는 변환 과정을 보여 줍니다:

```java 
// 프레젠테이션 파일을 로드합니다.
Presentation presentation = new Presentation("sample.pptx");
try {
    // 프레젠테이션에서 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.getSlides().get_Item(0);

    // 출력 TIFF 이미지 설정을 구성합니다.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // 이미지 크기를 설정합니다.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // 픽셀 형식을 설정합니다 (흑백).
    tiffOptions.setDpiX(300);                                        // 가로 해상도를 설정합니다.
    tiffOptions.setDpiY(300);                                        // 세로 해상도를 설정합니다.

    // 지정된 옵션으로 슬라이드를 이미지로 변환합니다.
    IImage image = slide.getImage(tiffOptions);

    try {
        // 이미지를 TIFF 형식으로 저장합니다.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **전체 슬라이드를 이미지로 변환하기**

Aspose.Slides를 사용하면 프레젠테이션의 모든 슬라이드를 이미지로 변환하여 전체 프레젠테이션을 일련의 이미지로 만들 수 있습니다.

다음 샘플 코드는 Java에서 프레젠테이션의 모든 슬라이드를 이미지로 변환하는 방법을 보여 줍니다:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 프레젠테이션을 슬라이드별로 이미지로 렌더링합니다.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // 숨겨진 슬라이드를 제어합니다 (숨겨진 슬라이드는 렌더링하지 않음).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // 슬라이드를 이미지로 변환합니다.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // 이미지를 JPEG 형식으로 저장합니다.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
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

아니요, `getImage` 메서드는 슬라이드의 정적 이미지만 저장하며 애니메이션은 포함되지 않습니다.

**숨긴 슬라이드를 이미지로 내보낼 수 있나요?**

예, 숨긴 슬라이드도 일반 슬라이드와 동일하게 처리할 수 있습니다. 처리 루프에 포함되어 있는지 확인하면 됩니다.

**이미지를 그림자 및 효과와 함께 저장할 수 있나요?**

예, Aspose.Slides는 슬라이드를 이미지로 저장할 때 그림자, 투명도 및 기타 그래픽 효과를 렌더링하는 기능을 지원합니다.