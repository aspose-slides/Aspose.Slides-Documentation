---
title: 画像
type: docs
weight: 50
url: /ja/net/examples/elements/picture/
keywords:
- 画像
- 画像フレーム
- 画像を追加
- 画像にアクセス
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で画像を操作します。画像の挿入、トリミング、圧縮、色調変更、エクスポートを行い、PPT、PPTX、ODP プレゼンテーション用の C# サンプルを提供します。"
---
この記事では、**Aspose.Slides for .NET** を使用してインメモリ画像から画像を挿入およびアクセスする方法を示します。以下の例では、メモリ内に画像を作成し、スライドに配置し、そして取得します。

## **画像を追加**

このコードは小さなビットマップを生成し、ストリームに変換して、最初のスライドに画像フレームとして挿入します。

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // シンプルなインメモリ画像を作成します。
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // ビットマップを MemoryStream に変換します。
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // 画像をプレゼンテーションに追加します。
    var image = presentation.Images.AddImage(imageStream);

    // 最初のスライドに画像を表示する画像フレームを挿入します。
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **画像にアクセス**

この例では、スライドに画像フレームが含まれていることを確認し、見つかった最初のフレームにアクセスします。

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 作業できる画像フレームが少なくとも1つあることを確認します。
    using var bitmap = new Bitmap(40, 40);

    // ビットマップを MemoryStream に変換します。
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // 画像をプレゼンテーションに追加します。
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // スライド上の最初の画像フレームにアクセスします。
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```