---
title: .NET에서 프레젠테이션 슬라이드를 이미지로 변환
linktitle: 슬라이드 to 이미지
type: docs
weight: 41
url: /ko/net/convert-slide/
keywords:
- 슬라이드 변환
- 슬라이드 내보내기
- 슬라이드 이미지 변환
- 슬라이드 이미지 저장
- 슬라이드 EMF 변환
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
description: "Aspose.Slides for .NET을 사용하여 C#에서 PPT, PPTX 및 ODP 프레젠테이션의 슬라이드를 PNG, JPEG, GIF, TIFF, EMF 및 기타 이미지 형식으로 변환합니다."
---
## **소개**

Aspose.Slides for .NET은 PowerPoint 및 OpenDocument 프레젠테이션의 개별 슬라이드를 PNG, JPEG, GIF, TIFF 및 기타 이미지 형식으로 렌더링할 수 있습니다.

슬라이드를 이미지로 변환하려면 다음 단계를 따르십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스로 프레젠테이션을 로드합니다.
2. 렌더링하려는 슬라이드를 선택합니다.
3. 필요에 따라 [RenderingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/renderingoptions/) 또는 [TiffOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/) 클래스로 렌더링을 구성합니다.
4. [GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/getimage/) 메서드를 호출합니다. 이 메서드는 [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 객체를 반환합니다.
5. [IImage.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/save/) 메서드를 호출하고 [ImageFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/imageformat/) 값을 사용해 출력 형식을 지정합니다.

## **슬라이드를 PNG 이미지로 변환**

가장 간단한 변환은 기본 렌더링 설정을 사용합니다. 결과 [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 객체는 메모리에서 처리하거나 파일에 저장할 수 있습니다.

다음 C# 예제는 첫 번째 슬라이드를 렌더링하고 PNG 이미지로 저장합니다:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **사용자 지정 크기로 슬라이드를 이미지로 변환**

정확한 픽셀 크기로 슬라이드를 렌더링하려면 [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) 값을 받는 [GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/getimage/) 오버로드를 사용합니다.

다음 예제는 1820 × 1040 JPEG 이미지를 생성합니다:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **노트와 댓글이 포함된 슬라이드를 이미지로 변환**

기본적으로 슬라이드 이미지에는 노트나 댓글이 포함되지 않습니다. [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) 속성에 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/notescommentslayoutingoptions/) 객체를 할당하면 노트와 댓글이 표시되는 위치를 제어할 수 있습니다.

다음 예제는 잘린 노트를 슬라이드 아래에, 댓글을 오른쪽에 배치합니다:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
슬라이드‑이미지 변환 시 [NotesPosition](https://reference.aspose.com/slides/ko/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) 속성을 [BottomFull](https://reference.aspose.com/slides/ko/net/aspose.slides.export/notespositions/) 로 설정하지 마십시오. 노트는 고정된 이미지 크기보다 더 많은 텍스트를 포함할 수 있습니다. 대신 [BottomTruncated](https://reference.aspose.com/slides/ko/net/aspose.slides.export/notespositions/) 을 사용하십시오.
{{% /alert %}}

## **TIFF 옵션을 사용하여 슬라이드를 이미지로 변환**

[TiffOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/) 클래스는 렌더링된 TIFF 이미지의 크기, 해상도 및 기타 속성을 제어할 수 있게 해줍니다.

다음 예제는 첫 번째 슬라이드를 2160 × 2880 TIFF 이미지(300 DPI)로 렌더링합니다:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **전체 슬라이드를 이미지로 변환**

슬라이드 컬렉션을 순회하여 프레젠테이션 전체를 일련의 이미지로 변환합니다. 숨겨진 슬라이드는 명시적으로 건너뛰지 않는 한 포함됩니다.

다음 예제는 모든 슬라이드를 가로·세로 배율 2로 JPEG 이미지로 렌더링합니다:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **향상 메타파일 출력 생성**

Enhanced Metafile(EMF)은 벡터 기반 그래픽을 Microsoft Office 또는 Windows 메타파일을 지원하는 기타 Windows 애플리케이션과 교환해야 할 때 유용합니다. 픽셀 기반 이미지와 달리 EMF는 스케일해도 선명도가 잃지 않는 벡터 그리기 작업을 유지할 수 있습니다. 그러나 EMF는 Windows 메타파일 지원이 있는 애플리케이션을 위한 호환성 형식이며 보편적인 교환 형식은 아닙니다. 또한 비트맵 이미지와 일부 효과와 같은 복잡한 슬라이드 내용은 벡터 메타파일 컨테이너 내부에 래스터화된 요소로 저장될 수 있습니다.

### **슬라이드를 EMF로 내보내기**

[ISlide.WriteAsEmf](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/writeasemf/) 메서드는 [ISlide](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/)을 EMF 형식의 대상 스트림에 씁니다. 다음 예제는 프레젠테이션을 로드하고, 첫 번째 슬라이드를 선택한 뒤, EMF 파일 스트림에 기록합니다:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

스트림을 [ISlide.WriteAsEmf](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/writeasemf/)에 전달한 호출자는 해당 스트림을 소유하며 반드시 닫거나 Dispose해야 합니다. Aspose.Slides는 스트림 현재 위치에서 데이터를 쓰고 스트림을 열어 둡니다.

### **SVG 이미지를 EMF로 변환하여 프레젠테이션에 추가하기**

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage/writeasemf/)을 사용하여 SVG 콘텐츠를 EMF로 변환합니다. 생성된 바이트 배열은 [IImageCollection.AddImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimagecollection/addimage/)을 통해 프레젠테이션에 추가하고, [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addpictureframe/)을 사용해 슬라이드에 배치할 수 있습니다.

다음 예제는 SVG 마크업에서 [SvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/svgimage/)을 만들고, 메모리 내 EMF로 변환한 뒤 첫 번째 슬라이드에 메타파일을 삽입하고 프레젠테이션을 저장합니다:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage/writeasemf/)는 대상 스트림에 대한 소유권을 갖지 않습니다. 기록이 끝난 후 스트림 위치는 생성된 데이터 끝에 있습니다. 위 예제처럼 동일한 스트림을 다시 읽을 때는 `Position`을 처음으로 재설정하십시오. 스트림을 소비자가 읽을 때까지 열어 두고, 사용이 끝나면 Dispose하십시오. 혹은 `ToArray`를 호출해 반환된 바이트 배열을 [IImageCollection.AddImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimagecollection/addimage/)에 전달할 수도 있습니다; `ToArray`는 현재 스트림 위치와 관계없이 전체 버퍼를 반환합니다.

EMF 생성은 선택한 Aspose.Slides for .NET 빌드가 지원하는 운영 체제에서 사용할 수 있지만, 폰트나 네이티브 그래픽 종속성이 없는 경우 플랫폼마다 렌더링 결과가 다를 수 있습니다. 소스 콘텐츠에 사용된 폰트를 설치하거나 적절한 대체 폰트를 구성하고, Aspose.Slides 패키지에 대한 [플랫폼 요구 사항](/slides/ko/net/system-requirements/)을 따르며, 대상 EMF를 사용하는 애플리케이션에서 결과를 검증하십시오. Linux와 macOS 애플리케이션은 Windows 메타파일을 표시·편집하는 지원이 제한적이거나 일관되지 않을 수 있습니다.

## **컬러 이모지 렌더링**

{{% alert title="Note" color="info" %}}
프레젠테이션 슬라이드를 이미지로 변환할 때 컬러 이모지를 올바르게 렌더링하려면 프레젠테이션에 사용된 이모지 폰트가 변환을 수행하는 시스템에 설치되어 있어야 합니다. 예를 들어 프레젠테이션에서 **Segoe UI Emoji** 폰트를 사용하고 해당 폰트가 없으면 출력 이미지에 이모지가 단색으로 표시될 수 있습니다.
{{% /alert %}}

## **FAQ**

**Aspose.Slides가 애니메이션이 포함된 슬라이드 렌더링을 지원합니까?**

아니요. [GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/getimage/) 메서드는 슬라이드의 정적 이미지를 렌더링하며 애니메이션을 내보내지 않습니다.

**숨겨진 슬라이드를 이미지로 내보낼 수 있습니까?**

예. 숨겨진 슬라이드도 일반 슬라이드처럼 렌더링할 수 있습니다. 위 예제와 같이 처리 루프에 포함시키면 됩니다.

**슬라이드 이미지에 그림자 및 기타 효과가 보존됩니까?**

예. Aspose.Slides는 슬라이드 이미지에 그림자, 투명도 및 기타 지원되는 그래픽 효과를 렌더링합니다.