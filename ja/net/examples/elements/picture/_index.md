---
title: 画像
type: docs
weight: 50
url: /ja/net/examples/elements/picture/
keywords:
- 画像例
- 画像フレーム
- 画像の追加
- 画像へのアクセス
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して C# で画像を操作します：挿入、置換、トリミング、圧縮、透明度と効果の調整、シェイプへの塗りつぶし、PPT、PPTX、ODP へのエクスポート。"
---

インメモリ画像から画像を挿入およびアクセスする方法を **Aspose.Slides for .NET** を使用して示します。以下の例では、メモリ内に画像を作成し、スライドに配置し、そして取得します。

## 画像の追加

このコードは小さなビットマップを生成し、ストリームに変換して、最初のスライドに画像フレームとして挿入します。
```csharp
public static void Add_Picture()
{
    using var pres = new Presentation();

    // シンプルなインメモリ画像を作成する
    using var bmp = new Bitmap(width: 100, height: 100);
    using (var g = Graphics.FromImage(bmp))
    {
        g.Clear(Color.LightGreen);
    }

    // Bitmap を MemoryStream に変換する
    using var imageStream = new MemoryStream();
    bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // 画像をプレゼンテーションに追加する
    var ppImage = pres.Images.AddImage(imageStream);

    // 最初のスライドに画像を表示するピクチャーフレームを挿入する
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bmp.Width, height: bmp.Height, ppImage);

    pres.Save(@"c:\_tmp\xxx.pptx", SaveFormat.Pptx);
}
```


## 画像へのアクセス

この例では、スライドに画像フレームが含まれていることを確認し、最初に見つかったフレームにアクセスします。
```csharp
public static void Access_Picture()
{
    using var pres = new Presentation();

    // 作業対象となる画像フレームが最低1つあることを確認する
    using var bmp = new Bitmap(40, 40);

    // Bitmap を MemoryStream に変換する
    using var imageStream = new MemoryStream();
    bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // 画像をプレゼンテーションに追加する
    var ppImage = pres.Images.AddImage(imageStream);
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, ppImage);

    // スライド上の最初の画像フレームにアクセスする
    var pictureFrame = pres.Slides[0].Shapes.OfType<PictureFrame>().First();
}
```
