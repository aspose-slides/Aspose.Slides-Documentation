---
title: .NET에서 프레젠테이션 슬라이드를 이미지로 변환
linktitle: 슬라이드에서 이미지로
type: docs
weight: 41
url: /ko/net/convert-slide/
keywords:
- 슬라이드 변환
- 슬라이드 내보내기
- 슬라이드 이미지 변환
- 슬라이드 이미지 저장
- 슬라이드 PNG
- 슬라이드 JPEG
- 슬라이드 비트맵
- 슬라이드 TIFF
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 C#에서 PPT, PPTX 및 ODP 슬라이드를 이미지로 변환합니다—빠르고 고품질의 렌더링과 명확한 코드 예제가 제공됩니다."
---
## **소개**

Aspose.Slides for .NET를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션 슬라이드를 BMP, PNG, JPG (JPEG), GIF 등 다양한 이미지 형식으로 쉽게 변환할 수 있습니다.

슬라이드를 이미지로 변환하려면 다음 단계를 수행하십시오:

1. 원하는 변환 설정을 정의하고 다음을 사용하여 내보낼 슬라이드를 선택합니다:
    - [ITiffOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/itiffoptions/) 인터페이스,
    - [IRenderingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/irenderingoptions/) 인터페이스.
2. [GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/getimage/) 메서드를 호출하여 슬라이드 이미지를 생성합니다.

.NET에서 [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0)은 픽셀 데이터로 정의된 이미지를 다룰 수 있는 객체입니다. 이 클래스를 사용하여 다양한 형식(BMP, JPG, PNG 등)으로 이미지를 저장할 수 있습니다.

## **슬라이드를 비트맵으로 변환하고 PNG 형식으로 저장**

슬라이드를 비트맵 객체로 변환한 후 애플리케이션에서 직접 사용할 수 있습니다. 또는 슬라이드를 비트맵으로 변환한 뒤 JPEG 등 원하는 형식으로 저장할 수도 있습니다.

다음 C# 코드 예제는 프레젠테이션의 첫 번째 슬라이드를 비트맵 객체로 변환한 다음 PNG 형식으로 저장하는 방법을 보여줍니다:

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

## **맞춤 크기로 슬라이드 이미지 변환**

특정 크기의 이미지를 얻어야 할 때가 있습니다. [GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/getimage/) 메서드의 오버로드를 사용하면 지정된 너비와 높이로 슬라이드를 이미지로 변환할 수 있습니다.

다음 샘플 코드는 이를 구현하는 방법을 보여줍니다:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // 프레젠테이션의 첫 번째 슬라이드를 지정된 크기로 비트맵으로 변환합니다.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // 이미지를 JPEG 형식으로 저장합니다.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **노트와 댓글이 포함된 슬라이드 이미지 변환**

일부 슬라이드에는 노트와 댓글이 포함될 수 있습니다.

Aspose.Slides는 [ITiffOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/itiffoptions/)와 [IRenderingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/irenderingoptions/)라는 두 인터페이스를 제공하여 프레젠테이션 슬라이드를 이미지로 렌더링할 때 제어할 수 있습니다. 두 인터페이스 모두 `SlidesLayoutOptions` 속성을 포함하고 있으며, 이를 통해 슬라이드를 이미지로 변환할 때 노트와 댓글의 렌더링을 구성할 수 있습니다.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/notescommentslayoutingoptions/) 클래스를 사용하면 결과 이미지에서 노트와 댓글의 위치를 원하는 대로 지정할 수 있습니다.

다음 C# 코드는 노트와 댓글이 포함된 슬라이드를 변환하는 방법을 보여줍니다:

```cs
float scaleX = 2;
float scaleY = scaleX;

// 프레젠테이션 파일을 로드합니다.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // 렌더링 옵션을 생성합니다.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // 노트의 위치를 설정합니다.
            CommentsPosition = CommentsPositions.Right,      // 댓글의 위치를 설정합니다.
            CommentsAreaWidth = 500,                         // 댓글 영역의 너비를 설정합니다.
            CommentsAreaColor = Color.AntiqueWhite           // 댓글 영역의 색상을 설정합니다.
        }
    };

    // 프레젠테이션의 첫 번째 슬라이드를 이미지로 변환합니다.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // 이미지를 GIF 형식으로 저장합니다.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 

슬라이드‑이미지 변환 과정에서 [NotesPosition](https://reference.aspose.com/slides/ko/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) 속성을 `BottomFull`(노트 위치)으로 설정하면 노트 텍스트가 너무 커서 지정된 이미지 크기에 맞추기 어려울 수 있습니다.

{{% /alert %}} 

## **TIFF 옵션을 사용한 슬라이드 이미지 변환**

[ITiffOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/itiffoptions/) 인터페이스를 사용하면 크기, 해상도, 색상 팔레트 등 다양한 매개변수를 지정하여 최종 TIFF 이미지에 대한 제어력을 높일 수 있습니다.

다음 C# 코드는 TIFF 옵션을 사용해 300 DPI 해상도와 2160 × 2800 크기의 흑백 이미지를 출력하는 변환 과정을 보여줍니다:

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
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // 픽셀 형식(흑백)을 설정합니다.
        DpiX = 300,                                        // 수평 해상도를 설정합니다.
        DpiY = 300                                         // 수직 해상도를 설정합니다.
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

Aspose.Slides를 사용하면 프레젠테이션의 모든 슬라이드를 이미지 시리즈로 변환하여 프레젠테이션 전체를 이미지로 만들 수 있습니다.

다음 C# 샘플 코드는 프레젠테이션의 모든 슬라이드를 이미지로 변환하는 방법을 보여줍니다:

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

## **컬러 이모지 렌더링**

{{% alert title="Note" color="warning" %}} 
프레젠테이션 슬라이드를 이미지로 변환할 때 컬러 이모지를 올바르게 렌더링하려면 프레젠테이션에 사용된 이모지 폰트가 변환을 수행하는 시스템에 설치되어 있어야 합니다. 예를 들어 프레젠테이션이 **Segoe UI Emoji** 폰트를 사용하고 이 폰트가 없을 경우 이모지가 흑백으로 표시될 수 있습니다.
{{% /alert %}}

## **FAQ**

**Aspose.Slides가 애니메이션이 포함된 슬라이드 렌더링을 지원합니까?**

아니요, `GetImage` 메서드는 애니메이션 없이 슬라이드의 정적 이미지만 저장합니다.

**숨김 슬라이드를 이미지로 내보낼 수 있습니까?**

예, 숨김 슬라이드도 일반 슬라이드와 동일하게 처리할 수 있습니다. 처리 루프에 포함되도록만 하면 됩니다.

**그림자를 포함한 효과와 함께 이미지를 저장할 수 있습니까?**

예, Aspose.Slides는 슬라이드를 이미지로 저장할 때 그림자, 투명도 및 기타 그래픽 효과를 렌더링하는 것을 지원합니다.