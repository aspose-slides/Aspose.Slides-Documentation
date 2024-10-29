---
title: プレゼンテーション ビューア
type: docs
weight: 50
url: /ja/net/presentation-viewer/
keywords: 
- PowerPoint プレゼンテーションを表示
- ppt を表示
- PPTX を表示
- C#
- Csharp
- Aspose.Slides for .NET
description: "C# または .NET で PowerPoint プレゼンテーションを表示"
---



Aspose.Slides for .NET は、スライドを含むプレゼンテーションファイルを作成するために使用されます。これらのスライドは、Microsoft PowerPoint を使用してプレゼンテーションを開くことで表示できます。しかし、場合によっては、開発者が好きな画像ビューアでスライドを画像として表示する必要があるか、独自のプレゼンテーションビューアを作成する必要があることもあります。そのような場合に、Aspose.Slides for .NET を使用すると、個々のスライドを画像としてエクスポートすることができます。この記事では、その方法について説明します。
## **ライブ例**
Aspose.Slides API で実装可能な内容を確認するために、[**Aspose.Slides ビューア**](https://products.aspose.app/slides/viewer/) の無料アプリを試してみてください：

![powerpoint-in-aspose-viewer](powerpoint-in-aspose-viewer.png)

## **スライドから SVG 画像を生成する**
Aspose.Slides.PPTX for .NET を使用して任意のスライドから SVG 画像を生成するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- ID またはインデックスを使用して、必要なスライドの参照を取得します。
- メモリストリーム内の SVG 画像を取得します。
- メモリストリームをファイルに保存します。

```c#
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化します

using (Presentation pres = new Presentation("CreateSlidesSVGImage.pptx"))
{

    // 最初のスライドにアクセスします
    ISlide sld = pres.Slides[0];

    // メモリストリームオブジェクトを作成します
    MemoryStream SvgStream = new MemoryStream();

    // スライドの SVG 画像を生成し、メモリストリームに保存します
    sld.WriteAsSvg(SvgStream);
    SvgStream.Position = 0;

    // メモリストリームをファイルに保存します
    using (Stream fileStream = System.IO.File.OpenWrite("Aspose_out.svg"))
    {
        byte[] buffer = new byte[8 * 1024];
        int len;
        while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)
        {
            fileStream.Write(buffer, 0, len);
        }

    }
    SvgStream.Close();
}
```


## **カスタムシェイプ ID で SVG を生成する**
Aspose.Slides for .NET は、カスタムシェイプ ID を持つスライドから [SVG](https://docs.fileformat.com/page-description-language/svg/) を生成するために使用できます。そのためには、生成された SVG のシェイプのカスタム ID を表す [ISvgShape](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape) の ID プロパティを使用します。CustomSvgShapeFormattingController を使用してシェイプ ID を設定できます。

```c#
using (Presentation pres = new Presentation("pptxFileName.pptx"))
{
    using (FileStream stream = new FileStream(outputPath, FileMode.OpenOrCreate))
    {
        SVGOptions svgOptions = new SVGOptions
        {
            ShapeFormattingController = new CustomSvgShapeFormattingController()
        };

        pres.Slides[0].WriteAsSvg(stream, svgOptions);
    }
}
```



```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
	private int m_shapeIndex;
	
	public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
	{
		m_shapeIndex = shapeStartIndex;
	}

	public void FormatShape(ISvgShape svgShape, IShape shape)
	{
		svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
	}
}
```


## **スライドのサムネイル画像を作成する**
Aspose.Slides for .NET は、スライドのサムネイル画像を生成するお手伝いをします。Aspose.Slides for .NET を使用して任意のスライドのサムネイルを生成するには：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して、必要なスライドの参照を取得します。
1. 参照されたスライドのサムネイル画像を指定されたスケールで取得します。
1. 任意の画像形式でサムネイル画像を保存します。

```c#
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化します
using (Presentation pres = new Presentation("ThumbnailFromSlide.pptx"))
{
    // 最初のスライドにアクセスします
    ISlide sld = pres.Slides[0];

    // フルスケール画像を作成します
    using (IImage image = sld.GetImage(1f, 1f))
    {
        // JPEG 形式でディスクに画像を保存します
        image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    }
}
```


## **ユーザー定義の寸法でサムネイルを作成する**
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して、必要なスライドの参照を取得します。
1. 参照されたスライドのサムネイル画像を指定されたスケールで取得します。
1. 任意の画像形式でサムネイル画像を保存します。

```c#
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化します
using (Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx"))
{

    // 最初のスライドにアクセスします
    ISlide sld = pres.Slides[0];

    // ユーザー定義の寸法
    int desiredX = 1200;
    int desiredY = 800;

    // X および Y のスケール値を取得します
    float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;


    // フルスケール画像を作成します
    using (IImage image = sld.GetImage(ScaleX, ScaleY))
    {
        // JPEG 形式でディスクに画像を保存します
        image.Save("Thumbnail2_out.jpg", ImageFormat.Jpeg);
    }
}
```


## **ノートスライドビューでスライドからサムネイルを作成する**
Aspose.Slides for .NET を使用してノートスライドビューの任意のスライドのサムネイルを生成するには：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して、必要なスライドの参照を取得します。
1. ノートスライドビューで指定されたスケールで参照されたスライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

以下のコードスニペットは、ノートスライドビューでプレゼンテーションの最初のスライドのサムネイルを生成します。

```c#
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化します
using (Presentation pres = new Presentation("ThumbnailFromSlideInNotes.pptx"))
{
    // 最初のスライドにアクセスします
    ISlide sld = pres.Slides[0];

    // ユーザー定義の寸法
    int desiredX = 1200;
    int desiredY = 800;

    // X および Y のスケール値を取得します
    float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    // フルスケール画像を作成します                
    using (IImage image = sld.GetImage(ScaleX, ScaleY))
    {
        // JPEG 形式でディスクに画像を保存します
        image.Save("Notes_tnail_out.jpg", ImageFormat.Jpeg);
    }
}
``` 