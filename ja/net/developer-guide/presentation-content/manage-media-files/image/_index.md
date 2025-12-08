---
title: 画像
type: docs
weight: 10
url: /ja/net/image/
keywords:
- 画像を追加
- 画像を追加
- ビットマップを追加
- 画像を置換
- 画像を置換
- Web から
- 背景
- PNG を追加
- JPG を追加
- SVG を追加
- EMF を追加
- WMF を追加
- TIFF を追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint と OpenDocument の画像管理を効率化し、パフォーマンスを最適化しながらワークフローを自動化します。"
---

## **プレゼンテーションのスライドにおける画像**

画像はプレゼンテーションをより魅力的で興味深いものにします。Microsoft PowerPoint では、ファイル、インターネット、またはその他の場所から画像をスライドに挿入できます。同様に、Aspose.Slides を使用すると、さまざまな手順でプレゼンテーションのスライドに画像を追加できます。

{{% alert title="ヒント" color="primary" %}} 

Aspose は無料コンバータとして、[JPEGからPowerPointへ](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNGからPowerPointへ](https://products.aspose.app/slides/import/png-to-ppt) を提供しており、画像からプレゼンテーションをすばやく作成できます。 

{{% /alert %}} 

{{% alert title="情報" color="info" %}}

画像をフレームオブジェクトとして追加したい場合—特にサイズ変更やエフェクト追加などの標準書式設定オプションを使用する場合—は、[Picture Frame](https://docs.aspose.com/slides/net/picture-frame/) を参照してください。 

{{% /alert %}} 

{{% alert title="注意" color="warning" %}}

画像と PowerPoint プレゼンテーションに関わる入出力操作を操作して、画像をある形式から別の形式に変換できます。以下のページをご覧ください: 変換 [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); 変換 [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); 変換 [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), 変換 [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); 変換 [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), 変換 [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/)。 

{{% /alert %}}

Aspose.Slides は、JPEG、PNG、BMP、GIF などの一般的な形式の画像操作をサポートしています。 

## **ローカルに保存された画像をスライドに追加する方法**

コンピューター上の 1 つまたは複数の画像をプレゼンテーションのスライドに追加できます。以下の C# のサンプルコードは、スライドに画像を追加する方法を示しています:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Web から画像をスライドに追加する方法**

コンピューターに画像が存在しない場合は、Web から直接画像を追加できます。 

以下のサンプルコードは、Web から画像を取得して C# でスライドに追加する手順を示しています:
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


## **スライドマスターに画像を追加する方法**

スライドマスターは、下位のすべてのスライドに関する情報（テーマ、レイアウトなど）を格納・制御する上位スライドです。したがって、スライドマスターに画像を追加すると、その画像はマスター配下のすべてのスライドに表示されます。 

この C# のサンプルコードは、スライドマスターに画像を追加する方法を示しています:
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


## **スライドの背景として画像を追加する方法**

特定のスライドまたは複数のスライドの背景に画像を使用したい場合は、*[スライドの背景として画像を設定する](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **プレゼンテーションに SVG を追加する方法**
[AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) メソッド（[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) インターフェイスの一部）を使用して、プレゼンテーションに任意の画像を追加または挿入できます。

SVG 画像に基づく画像オブジェクトを作成する手順は次のとおりです。

1. SvgImage オブジェクトを作成して ImageShapeCollection に挿入する  
2. ISvgImage から PPImage オブジェクトを作成する  
3. IPPImage インターフェイスを使用して PictureFrame オブジェクトを作成する  

以下のサンプルコードは、上記手順を実装して SVG 画像をプレゼンテーションに追加する方法を示しています:
``` csharp 
// ドキュメントディレクトリへのパス
string dataDir = @"D:\Documents\";

// ソースSVGファイル名
string svgFileName = dataDir + "sample.svg";

// 出力プレゼンテーションファイル名
string outPptxPath = dataDir + "presentation.pptx";

// Create new presentation
using (var p = new Presentation())
{
    // SVGファイル内容を読み込む
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImageオブジェクトを作成
    ISvgImage svgImage = new SvgImage(svgContent);

    // PPImageオブジェクトを作成
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // 新しいPictureFrameを作成 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // プレゼンテーションをPPTX形式で保存
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **SVG をシェイプの集合に変換する方法**
Aspose.Slides の SVG からシェイプへの変換は、PowerPoint の SVG 画像操作機能と同様です:

![PowerPoint Popup Menu](img_01_01.png)

この機能は、[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) インターフェイスの [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) メソッド（最初の引数に [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) オブジェクトを取るオーバーロード）のいずれかによって提供されます。

以下のサンプルコードは、記載されたメソッドを使用して SVG ファイルをシェイプの集合に変換する方法を示しています:
``` csharp 
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

    // SVG画像をスライドサイズに合わせてシェイプのグループに変換
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // プレゼンテーションをPPTX形式で保存
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **スライドに EMF 画像として画像を追加する方法**
Aspose.Slides for .NET は、Excel シートから EMF 画像を生成し、Aspose.Cells と組み合わせてスライドに EMF として画像を追加できます。  

以下のサンプルコードは、記載されたタスクを実行する方法を示しています:
``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //ワークブックをストリームに保存
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


## **画像コレクション内の画像を置換する方法**

Aspose.Slides は、プレゼンテーションの画像コレクション（スライドシェイプが使用している画像を含む）に格納された画像を置換できます。このセクションでは、コレクション内の画像を更新するいくつかのアプローチを示します。API は、バイト配列、[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) インスタンス、またはコレクション内に既に存在する別の画像を使用して画像を置換するシンプルなメソッドを提供します。

以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスを使用して画像を含むプレゼンテーション ファイルを読み込みます。  
2. ファイルから新しい画像をバイト配列に読み込みます。  
3. バイト配列を使用して対象画像を新しい画像に置換します。  
4. 2 番目のアプローチでは、画像を [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) オブジェクトに読み込み、そのオブジェクトで対象画像を置換します。  
5. 3 番目のアプローチでは、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置換します。  
6. 変更したプレゼンテーションを PPTX ファイルとして書き出します。  
```cs
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using Presentation presentation = new Presentation("sample.pptx");

// 最初の方法。
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// 二番目の方法。
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// 三番目の方法。
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// プレゼンテーションをファイルに保存します。
presentation.Save("output.pptx", SaveFormat.Pptx);
```


{{% alert title="情報" color="info" %}}

Aspose の無料 [Text to GIF](https://products.aspose.app/slides/text-to-gif) コンバータを使用すれば、テキストを簡単にアニメーション化したり、テキストから GIF を作成したりできます。 

{{% /alert %}}

## **FAQ**

**挿入後も元の画像解像度は保たれますか？**

はい。元のピクセルは保持されますが、最終的な見た目はスライド上で [picture](/slides/ja/net/picture-frame/) がどのようにスケーリングされるか、保存時に適用される圧縮に依存します。

**多数のスライドにまたがって同じロゴを一括で置換する最良の方法は？**

マスタースライドまたはレイアウトにロゴを配置し、プレゼンテーションの画像コレクションで置換すれば、該当リソースを使用しているすべての要素に変更が反映されます。

**挿入した SVG を編集可能なシェイプに変換できますか？**

はい。SVG をシェイプのグループに変換でき、その後各パーツは標準のシェイプ プロパティで編集可能になります。

**複数スライドの背景に一括で画像を設定するには？**

マスタースライドまたは該当レイアウトで [画像を背景として割り当てる](/slides/ja/net/presentation-background/) と、同じマスタ/レイアウトを使用しているすべてのスライドが背景を継承します。

**画像が多数あるためにプレゼンテーションのサイズが膨らむのを防ぐには？**

画像リソースを重複させずに 1 つだけ再利用し、適切な解像度を選択し、保存時に圧縮を適用し、必要に応じてマスターにグラフィックを配置してください。