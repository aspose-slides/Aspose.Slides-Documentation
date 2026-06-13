---
title: 그림
type: docs
weight: 50
url: /ko/net/examples/elements/picture/
keywords:
- 그림
- 그림 프레임
- 그림 추가
- 그림 액세스
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 그림을 작업합니다: 삽입, 자르기, 압축, 색상 변경 및 이미지를 내보내며 PPT, PPTX 및 ODP 프레젠테이션에 대한 C# 예제를 제공합니다."
---
이 문서에서는 **Aspose.Slides for .NET**을 사용하여 메모리 내 이미지에서 그림을 삽입하고 액세스하는 방법을 보여줍니다. 아래 예제는 메모리에서 이미지를 생성하고, 슬라이드에 배치한 다음 가져옵니다.

## **그림 추가**
이 코드는 작은 비트맵을 생성하고, 스트림으로 변환한 뒤 첫 번째 슬라이드에 그림 프레임으로 삽입합니다.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 간단한 메모리 내 이미지를 생성합니다.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // 비트맵을 MemoryStream으로 변환합니다.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // 이미지를 프레젠테이션에 추가합니다.
    var image = presentation.Images.AddImage(imageStream);

    // 첫 번째 슬라이드에 이미지를 표시하는 그림 프레임을 삽입합니다.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **그림 액세스**
이 예제는 슬라이드에 그림 프레임이 포함되어 있는지 확인한 다음, 찾은 첫 번째 프레임에 액세스합니다.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 작업할 그림 프레임이 최소 하나 이상 있는지 확인합니다.
    using var bitmap = new Bitmap(40, 40);

    // 비트맵을 MemoryStream으로 변환합니다.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // 이미지를 프레젠테이션에 추가합니다.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // 슬라이드에 있는 첫 번째 그림 프레임에 접근합니다.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```