---
title: 画像
type: docs
weight: 10
url: /ja/net/image/
keywords: "画像を追加, ピクチャを追加, PowerPoint プレゼンテーション, EMF, SVG, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint スライドまたはプレゼンテーションに画像を追加"
---

## **プレゼンテーションのスライド内の画像**

画像はプレゼンテーションをより魅力的で興味深いものにします。Microsoft PowerPoint では、ファイル、インターネット、またはその他の場所からスライドに画像を挿入できます。同様に、Aspose.Slidesを使用すると、さまざまな手順を通じてプレゼンテーションのスライドに画像を追加できます。

{{% alert title="ヒント" color="primary" %}} 

Asposeは、[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt)および[PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)などの無料コンバーターを提供しており、これにより人々は画像から迅速にプレゼンテーションを作成できます。 

{{% /alert %}} 

{{% alert title="情報" color="info" %}}

フレームオブジェクトとして画像を追加したい場合（特にサイズを変更したり、効果を追加したりするために標準の書式設定オプションを使用する予定がある場合）は、[画像フレーム](https://docs.aspose.com/slides/net/picture-frame/)を参照してください。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}}

画像と PowerPoint プレゼンテーションに関連する入出力操作を操作して、画像を1つの形式から別の形式に変換できます。これらのページを参照してください: [画像をJPGに変換](https://products.aspose.com/slides/net/conversion/image-to-jpg/); [JPGを画像に変換](https://products.aspose.com/slides/net/conversion/jpg-to-image/); [JPGをPNGに変換](https://products.aspose.com/slides/net/conversion/jpg-to-png/); [PNGをJPGに変換](https://products.aspose.com/slides/net/conversion/png-to-jpg/); [PNGをSVGに変換](https://products.aspose.com/slides/net/conversion/png-to-svg/); [SVGをPNGに変換](https://products.aspose.com/slides/net/conversion/svg-to-png/)。

{{% /alert %}}

Aspose.Slidesは、JPEG、PNG、BMP、GIFなどのこれらの一般的なフォーマットでの画像操作をサポートしています。

## **ローカルに保存された画像をスライドに追加**

コンピューター上の1つまたは複数の画像をプレゼンテーションのスライドに追加できます。このC#のサンプルコードは、スライドに画像を追加する方法を示しています。

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **ウェブからスライドに画像を追加**

スライドに追加したい画像がコンピューターで利用できない場合、ウェブから直接画像を追加できます。

このサンプルコードでは、C#のスライドにウェブから画像を追加する方法を示しています。

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **スライドマスターに画像を追加**

スライドマスターは、すべてのスライドに関する情報（テーマ、レイアウトなど）を格納し制御するトップスライドです。したがって、スライドマスターに画像を追加すると、その画像はそのスライドマスターの下にあるすべてのスライドに表示されます。

このC#のサンプルコードは、スライドマスターに画像を追加する方法を示しています。

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **スライドの背景として画像を追加**

特定のスライドまたは複数のスライドの背景として画像を使用することを決定する場合があります。その場合は、* [スライドの背景として画像を設定する](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*を参照してください。

## **プレゼンテーションにSVGを追加**
[ImageShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection)インターフェースに属する[AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe)メソッドを使用して、プレゼンテーションに任意の画像を追加または挿入できます。

SVG画像に基づいて画像オブジェクトを作成するには、次の手順を実行します。

1. SvgImageオブジェクトを作成してImageShapeCollectionに挿入します
2. ISvgImageからPPImageオブジェクトを作成します
3. IPPImageインターフェースを使用してPictureFrameオブジェクトを作成します

このサンプルコードは、上記の手順を実装してプレゼンテーションにSVG画像を追加する方法を示しています。

```csharp
// ドキュメントディレクトリへのパス
string dataDir = @"D:\Documents\";

// ソースSVGファイル名
string svgFileName = dataDir + "sample.svg";

// 出力プレゼンテーションファイル名
string outPptxPath = dataDir + "presentation.pptx";

// 新しいプレゼンテーションを作成
using (var p = new Presentation())
{
    // SVGファイルの内容を読み取る
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImageオブジェクトを作成
    ISvgImage svgImage = new SvgImage(svgContent);

    // PPImageオブジェクトを作成
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // 新しいPictureFrameを作成
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // PPTX形式でプレゼンテーションを保存
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **SVGをシェイプのセットに変換**
Aspose.SlidesのSVGからシェイプのセットへの変換は、SVG画像を操作するために使用されるPowerPointの機能に似ています：

![PowerPointポップアップメニュー](img_01_01.png)

この機能は、最初の引数として[ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage)オブジェクトを受け取る[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection)インターフェースの[AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1)メソッドのオーバーロードの1つによって提供されます。

このサンプルコードは、SVGファイルをシェイプのセットに変換するために説明されたメソッドを使用する方法を示しています。

```csharp
// ドキュメントディレクトリへのパス
string dataDir = @"D:\Documents\";

// ソースSVGファイル名
string svgFileName = dataDir + "sample.svg";

// 出力プレゼンテーションファイル名
string outPptxPath = dataDir + "presentation.pptx";

// 新しいプレゼンテーションを作成
using (IPresentation presentation = new Presentation())
{
    // SVGファイルの内容を読み取る
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImageオブジェクトを作成
    ISvgImage svgImage = new SvgImage(svgContent);

    // スライドサイズを取得
    SizeF slideSize = presentation.SlideSize.Size;

    // SVG画像をスライドサイズにスケーリングしてシェイプのグループに変換
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // PPTX形式でプレゼンテーションを保存
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **スライドにEMFとして画像を追加**
Aspose.Slides for .NETを使用すると、ExcelシートからEMF画像を生成し、Aspose.Cellsを使用してスライドにEMFとして画像を追加できます。

このサンプルコードは、上記のタスクを実行する方法を示しています。

```csharp
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    // ワークブックをストリームに保存
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

{{% alert title="情報" color="info" %}}

Asposeの無料[テキストをGIFに変換](https://products.aspose.app/slides/text-to-gif)コンバーターを使用すると、テキストを簡単にアニメーション化したり、テキストからGIFを作成したりできます。

{{% /alert %}}