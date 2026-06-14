---
title: 圖片
type: docs
weight: 50
url: /zh-hant/net/examples/elements/picture/
keywords:
- 圖片
- 圖片框
- 新增圖片
- 存取圖片
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中處理圖片：插入、裁剪、壓縮、重新著色，並以 C# 範例匯出 PPT、PPTX 和 ODP 簡報的影像。"
---
本文示範如何使用 **Aspose.Slides for .NET** 從記憶體中的影像插入與存取圖片。以下範例會在記憶體中建立影像、將其放置於投影片上，然後再擷取它。

## **Add a Picture**

此程式碼產生一個小型位圖，將其轉換為串流，並將其作為圖片框插入第一張投影片。

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 建立一個簡單的記憶體影像。
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // 將位圖轉換為 MemoryStream。
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // 將影像加入簡報。
    var image = presentation.Images.AddImage(imageStream);

    // 在第一張投影片上插入顯示該影像的圖片框。
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Access a Picture**

此範例確保投影片包含圖片框，然後存取它找到的第一個圖片框。

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 確保至少有一個圖片框可供使用。
    using var bitmap = new Bitmap(40, 40);

    // 將位圖轉換為 MemoryStream。
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // 將影像加入簡報。
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // 存取投影片上的第一個圖片框。
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```