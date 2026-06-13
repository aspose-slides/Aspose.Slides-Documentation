---
title: NET에서 프레젠테이션 슬라이드를 이미지로 변환
linktitle: 슬라이드 이미지 변환
type: docs
weight: 41
url: /ko/net/convert-slide/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 C#에서 PPT, PPTX 및 ODP 슬라이드를 이미지로 변환—빠르고 고품질 렌더링과 명확한 코드 예제 제공."
---
## **소개**

Aspose.Slides for .NET를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션 슬라이드를 BMP, PNG, JPG (JPEG), GIF 등 다양한 이미지 형식으로 쉽게 변환할 수 있습니다.

슬라이드를 이미지로 변환하려면 다음 단계를 따르세요:

1. 원하는 변환 설정을 정의하고 내보낼 슬라이드를 선택합니다. 사용 방법:
    - [ITiffOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/itiffoptions/) 인터페이스, 또는
    - [IRenderingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/irenderingoptions/) 인터페이스.
2. [GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/getimage/) 메서드를 호출하여 슬라이드 이미지를 생성합니다.

.NET에서 [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) 은 픽셀 데이터로 정의된 이미지를 다룰 수 있는 객체입니다. 이 클래스를 사용하면 BMP, JPG, PNG 등 다양한 형식으로 이미지를 저장할 수 있습니다.

## **슬라이드를 비트맵으로 변환하고 PNG 형식으로 저장**

슬라이드를 비트맵 객체로 변환하여 애플리케이션에서 직접 사용할 수 있습니다. 또는 슬라이드를 비트맵으로 변환한 다음 JPEG 등 다른 형식으로 저장할 수도 있습니다.

다음 C# 코드 예제는 프레젠테이션의 첫 번째 슬라이드를 비트맵 객체로 변환하고 PNG 형식으로 저장하는 방법을 보여줍니다:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // 프레젠테이션의 첫 번째 슬라이드를 비트맵으로 변환합니다.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // 이미지를 PNG 형식으로 저장합니다.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **사용자 지정 크기로 슬라이드를 이미지로 변환**

특정 크기의 이미지를 얻어야 할 수 있습니다. [GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/getimage/) 의 오버로드를 사용하면 슬라이드를 원하는 너비와 높이로 변환할 수 있습니다.

다음 샘플 코드는 이를 구현하는 방법을 보여줍니다:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // 프레젠테이션의 첫 번째 슬라이드를 지정된 크기의 비트맵으로 변환합니다.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // 이미지를 JPEG 형식으로 저장합니다.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **노트 및 주석이 포함된 슬라이드 이미지로 변환**

일부 슬라이드에는 노트와 주석이 포함될 수 있습니다.

Aspose.Slides는 [ITiffOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/itiffoptions/)와 [IRenderingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/irenderingoptions/) 두 인터페이스를 제공하여 프레젠테이션 슬라이드를 이미지로 렌더링하는 방식을 제어할 수 있습니다. 두 인터페이스 모두 `SlidesLayoutOptions` 속성을 포함하고 있으며, 이를 통해 슬라이드를 이미지로 변환할 때 노트와 주석의 렌더링을 구성할 수 있습니다.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/notescommentslayoutingoptions/) 클래스를 사용하면 결과 이미지에서 노트와 주석의 위치를 원하는 대로 지정할 수 있습니다.

다음 C# 코드는 노트와 주석이 포함된 슬라이드를 변환하는 방법을 보여줍니다:

```cs
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // Create the rendering options.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // Set the position of the notes.
            CommentsPosition = CommentsPositions.Right,      // Set the position of the comments.
            CommentsAreaWidth = 500,                         // Set the width of the comments area.
            CommentsAreaColor = Color.AntiqueWhite           // Set the color for the comments area.
        }
    };

    // Convert the first slide of the presentation to an image.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // Save the image in the GIF format.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 

어떠한 슬라이드‑to‑image 변환 과정에서도 [NotesPosition](https://reference.aspose.com/slides/ko/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) 속성을 `BottomFull`(노트 위치 지정)으로 설정할 수 없습니다. 노트 텍스트가 너무 길어 지정된 이미지 크기에 맞추지 못할 수 있기 때문입니다.

{{% /alert %}} 

## **TIFF 옵션을 사용하여 슬라이드를 이미지로 변환**

[ITiffOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/itiffoptions/) 인터페이스를 사용하면 크기, 해상도, 색상 팔레트 등 다양한 매개변수를 지정하여 결과 TIFF 이미지에 대한 제어권을 높일 수 있습니다.

다음 C# 코드는 TIFF 옵션을 사용하여 300 DPI 해상도와 2160 × 2800 크기의 흑백 이미지를 출력하는 변환 과정을 보여줍니다:

```cs
// 프레젠테이션 파일을 로드합니다.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 프레젠테이션에서 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.Slides[0];

    // 출력 TIFF 이미지의 설정을 구성합니다.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // 이미지 크기를 설정합니다.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // 픽셀 형식을 설정합니다 (흑백).
        DpiX = 300,                                        // 가로 해상도를 설정합니다.
        DpiY = 300                                         // 세로 해상도를 설정합니다.
    };

    // 지정된 옵션으로 슬라이드를 이미지로 변환합니다.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // 이미지를 TIFF 형식으로 저장합니다.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **전체 슬라이드를 이미지로 변환**

Aspose.Slides를 사용하면 프레젠테이션의 모든 슬라이드를 이미지로 변환하여 전체 프레젠테이션을 일련의 이미지로 만들 수 있습니다.

다음 샘플 코드는 C#에서 프레젠테이션의 모든 슬라이드를 이미지로 변환하는 방법을 보여줍니다:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // 프레젠테이션을 슬라이드별로 이미지로 렌더링합니다.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // 숨겨진 슬라이드를 제어합니다 (숨겨진 슬라이드는 렌더링하지 않음).
        if (presentation.Slides[i].Hidden)
            continue;

        // 슬라이드를 이미지로 변환합니다.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // 이미지를 JPEG 형식으로 저장합니다.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **자주 묻는 질문**

**1. Aspose.Slides가 애니메이션이 포함된 슬라이드를 렌더링할 수 있나요?**

아니요, `GetImage` 메서드는 슬라이드의 정적인 이미지만 저장하며 애니메이션은 포함하지 않습니다.

**2. 숨겨진 슬라이드를 이미지로 내보낼 수 있나요?**

예, 숨겨진 슬라이드도 일반 슬라이드와 동일하게 처리할 수 있습니다. 단지 처리 루프에 포함되어 있어야 합니다.

**3. 이미지에 그림자와 효과를 적용하여 저장할 수 있나요?**

예, Aspose.Slides는 슬라이드를 이미지로 저장할 때 그림자, 투명도 및 기타 그래픽 효과를 렌더링하는 기능을 지원합니다.