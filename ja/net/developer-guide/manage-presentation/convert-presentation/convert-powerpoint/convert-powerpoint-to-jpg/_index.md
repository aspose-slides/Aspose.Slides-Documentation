---
title: C#でPowerPointをJPGに変換
linktitle: PowerPoint PPTをJPGに変換
type: docs
weight: 60
url: /net/convert-powerpoint-to-jpg/
keywords: 
- PowerPointプレゼンテーションを変換
- JPG
- JPEG
- PowerPointからJPGへ
- PowerPointからJPEGへ
- PPTからJPGへ
- PPTXからJPGへ
- PPTからJPEGへ
- PPTXからJPEGへ
- C#
- Csharp
- .NET
- Aspose.Slides
description: "C#または.NETでPowerPointをJPGに変換します。スライドをJPG画像として保存"
---

## **概要**

この記事では、C#を使用してPowerPointプレゼンテーションをJPG形式に変換する方法について説明します。以下のトピックをカバーします：

- [C#でPowerPointをJPGに変換](#convert-powerpoint-pptpptx-to-jpg)
- [C#でPPTをJPGに変換](#convert-powerpoint-pptpptx-to-jpg)
- [C#でPPTXをJPGに変換](#convert-powerpoint-pptpptx-to-jpg)
- [C#でODPをJPGに変換](#convert-powerpoint-pptpptx-to-jpg)
- [C#でPowerPointスライドを画像に変換](#convert-powerpoint-pptpptx-to-jpg)

## **C# PowerPointからJPGへ**

C#のPowerPointをJPGに変換するサンプルコードについては、以下のセクションを参照してください。つまり、[PowerPointをJPGに変換](#convert-powerpoint-pptpptx-to-jpg)です。このコードは、プレゼンテーションオブジェクトにPPT、PPTX、ODPなどの形式を読み込み、そのスライドサムネイルをJPG形式で保存します。PNG、BMP、TIFF、SVGのような他のPowerPointから画像への変換も、これらの記事で説明しています。

- [C# PowerPointをPNGに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)
- [C# PowerPointをBMPに変換](#convert-powerpoint-pptpptx-to-jpg)
- [C# PowerPointをTIFFに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPointをSVGに変換](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **PowerPointからJPGへの変換について**

[**Aspose.Slides .NET API**](https://products.aspose.com/slides/net/)を使用すると、PowerPoint PPTまたはPPTXプレゼンテーションをJPG画像に変換できます。PPT/PPTXをBMP、PNG、SVGに変換することも可能です。この機能を利用すれば、独自のプレゼンテーションビューアを実装し、各スライドのサムネイルを作成できます。これは、プレゼンテーションスライドを著作権から保護したり、プレゼンテーションを読み取り専用モードで表示したりするのに役立ちます。Aspose.Slidesでは、全体のプレゼンテーションまたは特定のスライドを画像形式に変換できます。

{{% alert color="primary" %}} 

Aspose.SlidesがPowerPointをJPG画像に変換する方法を確認するには、これらの無料オンラインコンバータを試してみることをお勧めします：PowerPoint [PPTXをJPGに](https://products.aspose.app/slides/conversion/pptx-to-jpg)および[PPTをJPGに](https://products.aspose.app/slides/conversion/ppt-to-jpg)。

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTXをJPGに変換する手順**
PPT/PPTXをJPGに変換する手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)コレクションから[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)型のスライドオブジェクトを取得します。
3. 各スライドのサムネイルを作成し、JPGに変換します。[**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5)メソッドを使用してスライドのサムネイルを取得し、[Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=netframework-4.8)オブジェクトを返します。[GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5)メソッドは必要なスライドの[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)型から呼び出され、結果のサムネイルのスケールがメソッドに渡されます。
4. スライドサムネイルを取得した後、サムネイルオブジェクトから[**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8)メソッドを呼び出します。結果のファイル名と画像形式を渡します。

{{% alert color="primary" %}} 
**注意**: PPT/PPTXからJPGへの変換は、Aspose.Slides .NET APIの他の型への変換とは異なります。他の型の場合は、通常は[**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)** ](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5)メソッドを使用しますが、ここでは[**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8)メソッドが必要です。
{{% /alert %}} 

```c#
const int imageScale = 1;

using (Presentation pres = new Presentation("PowerPoint-Presentation.ppt"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // フルスケール画像を作成
        using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
        {
            // JPEG形式でディスクに画像を保存
			string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **カスタマイズされた寸法でPowerPoint PPT/PPTXをJPGに変換**
生成されるサムネイルとJPG画像の寸法を変更するには、[**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5)メソッドに*ScaleX*と*ScaleY*の値を渡して設定できます：

```c#
using (Presentation pres = new Presentation("PowerPoint-Presentation.pptx"))
{
    // 寸法を定義
    int desiredX = 1200;
    int desiredY = 800;

    // XとYのスケール値を取得
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    foreach (ISlide slide in pres.Slides)
    {
        // フルスケール画像を作成
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // JPEG形式でディスクに画像を保存
			string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **画像にプレゼンテーションを保存する際のコメントのレンダリング**
Aspose.Slides for .NETは、スライドを画像に変換するときにプレゼンテーションのスライドにコメントをレンダリングする機能を提供します。このC#コードは、その操作を示しています：

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,
            CommentsAreaColor = Color.Red,
            CommentsAreaWidth = 200,
            CommentsPosition = CommentsPositions.Right
        }
    };

    using (IImage image = presentation.Slides[0].GetImage(options))
    {
        image.Save("OutPresBitmap.png", ImageFormat.Png);
    }

    System.Diagnostics.Process.Start("OutPresBitmap.png");
}
```

{{% alert title="ヒント" color="primary" %}}

Asposeは[無料のコラージュWebアプリ](https://products.aspose.app/slides/collage)を提供しています。このオンラインサービスを使用すると、[JPGからJPG](https://products.aspose.app/slides/collage/jpg)やPNGからPNGの画像をマージしたり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid)を作成したりできます。 

この記事で説明したのと同じ原則を使用して、画像を別の形式に変換できます。詳細については、次のページを参照してください：画像を[JPGに変換](https://products.aspose.com/slides/net/conversion/image-to-jpg/)；[JPGを画像に変換](https://products.aspose.com/slides/net/conversion/jpg-to-image/)；[JPGをPNGに変換](https://products.aspose.com/slides/net/conversion/jpg-to-png/)；[PNGをJPGに変換](https://products.aspose.com/slides/net/conversion/png-to-jpg/)；[PNGをSVGに変換](https://products.aspose.com/slides/net/conversion/png-to-svg/)；[SVGをPNGに変換](https://products.aspose.com/slides/net/conversion/svg-to-png/)。

{{% /alert %}}

## **関連情報**

PPT/PPTXを画像に変換する他のオプションを参照してください：

- [PPT/PPTXをSVGに変換](/slides/net/render-a-slide-as-an-svg-image/)