---
title: .NET のプレゼンテーションにおける画像管理の最適化
linktitle: 画像の管理
type: docs
weight: 10
url: /ja/net/image/
keywords:
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
description: "Aspose.Slides for .NET を使用して、PowerPoint と OpenDocument の画像管理を効率化し、パフォーマンスを最適化し、ワークフローを自動化します。"
---

## **プレゼンテーションのスライド内の画像**

画像はプレゼンテーションをより魅力的で興味深いものにします。Microsoft PowerPoint では、ファイル、インターネット、またはその他の場所から画像をスライドに挿入できます。同様に、Aspose.Slides を使用すると、さまざまな手順でプレゼンテーションのスライドに画像を追加できます。

{{% alert  title="Tip" color="primary" %}} 
Aspose は、画像から迅速にプレゼンテーションを作成できる無料コンバータ—[JPEG から PowerPoint へ](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG から PowerPoint へ](https://products.aspose.app/slides/import/png-to-ppt)—を提供しています。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
画像をフレームオブジェクトとして追加したい場合—特にサイズ変更や効果の追加など標準の書式設定オプションを使用する予定がある場合—[Picture Frame](https://docs.aspose.com/slides/net/picture-frame/) を参照してください。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
画像と PowerPoint プレゼンテーションの入出力操作を操作して、画像をある形式から別の形式に変換できます。次のページをご参照ください: 変換 [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); 変換 [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); 変換 [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)、変換 [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); 変換 [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)、変換 [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/)。 
{{% /alert %}}

Aspose.Slides は、JPEG、PNG、BMP、GIF などの一般的な形式の画像操作をサポートしています。 

## **ローカルに保存された画像をスライドに追加**

コンピューター上の画像を 1 つまたは複数、プレゼンテーションのスライドに追加できます。以下の C# サンプルコードは、画像をスライドに追加する方法を示しています。  
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **ウェブから画像をスライドに追加**

スライドに追加したい画像がコンピューターにない場合、ウェブから直接画像を追加できます。  

以下のサンプルコードは、ウェブから画像を取得して C# でスライドに追加する方法を示しています。  
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


## **スライドマスタに画像を追加**

スライドマスタは、下位のすべてのスライドに関する情報（テーマ、レイアウトなど）を保持・制御する上位スライドです。そのため、スライドマスタに画像を追加すると、その画像はマスタ配下のすべてのスライドに表示されます。  

以下の C# サンプルコードは、スライドマスタに画像を追加する方法を示しています：  
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

特定のスライドまたは複数のスライドの背景として画像を使用することができます。その場合は、*[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)* を参照してください。  

## **プレゼンテーションへの SVG 追加**

[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) インターフェイスに属する [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) メソッドを使用して、任意の画像をプレゼンテーションに追加または挿入できます。  

SVG 画像に基づく画像オブジェクトを作成するには、次の手順で行えます。  

1. SvgImage オブジェクトを作成し、ImageShapeCollection に挿入する  
2. ISvgImage から PPImage オブジェクトを作成する  
3. IPPImage インターフェイスを使用して PictureFrame オブジェクトを作成する  

以下のサンプルコードは、上記手順を実装して SVG 画像をプレゼンテーションに追加する方法を示しています：  
```csharp
// ドキュメント ディレクトリへのパス
string dataDir = @"D:\Documents\";

// ソース SVG ファイル名
string svgFileName = dataDir + "sample.svg";

// 出力プレゼンテーション ファイル名
string outPptxPath = dataDir + "presentation.pptx";

// 新しいプレゼンテーションを作成
using (var p = new Presentation())
{
    // SVG ファイルの内容を読み取る
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage オブジェクトを作成
    ISvgImage svgImage = new SvgImage(svgContent);

    // PPImage オブジェクトを作成
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // 新しい PictureFrame を作成
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // PPTX 形式でプレゼンテーションを保存
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **SVG をシェイプの集合に変換**

Aspose.Slides の SVG をシェイプの集合に変換する機能は、SVG 画像を扱うための PowerPoint の機能と同様です。  

![PowerPoint Popup Menu](img_01_01.png)

この機能は、[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) インターフェイスの [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) メソッドのオーバーロードの 1 つで提供され、最初の引数として [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) オブジェクトを受け取ります。  

以下のサンプルコードは、前述のメソッドを使用して SVG ファイルをシェイプの集合に変換する方法を示しています：  
``` csharp 
// ドキュメント ディレクトリへのパス
string dataDir = @"D:\Documents\";

// ソース SVG ファイル名
string svgFileName = dataDir + "sample.svg";

// 出力プレゼンテーション ファイル名
string outPptxPath = dataDir + "presentation.pptx";

// 新しいプレゼンテーションを作成
using (IPresentation presentation = new Presentation())
{
    // SVG ファイルの内容を読み取る
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage オブジェクトを作成
    ISvgImage svgImage = new SvgImage(svgContent);

    // スライドサイズを取得
    SizeF slideSize = presentation.SlideSize.Size;

    // SVG 画像をスライドサイズに合わせてグループ形状に変換
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // PPTX 形式でプレゼンテーションを保存
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **スライドに EMF 画像として追加**

Aspose.Slides for .NET を使用すると、Excel シートから EMF 画像を生成し、Aspose.Cells と組み合わせてスライドに EMF 画像として追加できます。  

以下のサンプルコードは、上記のタスクを実行する方法を示しています：  
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


## **画像コレクション内の画像を置き換える**

Aspose.Slides を使用すると、プレゼンテーションの画像コレクションに保存されている画像（スライドのシェイプで使用されているものを含む）を置き換えることができます。このセクションでは、コレクション内の画像を更新するいくつかのアプローチを示します。API は、生のバイト データ、[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) インスタンス、またはコレクション内に既に存在する別の画像を使用して画像を置き換えるシンプルなメソッドを提供します。  

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスを使用して、画像を含むプレゼンテーション ファイルをロードします。  
2. ファイルから新しい画像を読み込み、バイト配列に格納します。  
3. バイト配列を使用して対象画像を新しい画像に置き換えます。  
4. 2 番目のアプローチでは、画像を [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) オブジェクトにロードし、そのオブジェクトで対象画像を置き換えます。  
5. 3 番目のアプローチでは、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置き換えます。  
6. 変更後のプレゼンテーションを PPTX ファイルとして保存します。  
```cs
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using Presentation presentation = new Presentation("sample.pptx");

// 最初の方法。
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// 2 番目の方法。
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// 3 番目の方法。
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// プレゼンテーションをファイルに保存します。
presentation.Save("output.pptx", SaveFormat.Pptx);
```


{{% alert title="Info" color="info" %}}
Aspose の無料 [Text to GIF](https://products.aspose.app/slides/text-to-gif) コンバータを使用すると、テキストを簡単にアニメーション化したり、テキストから GIF を作成したりできます。 
{{% /alert %}}

## **FAQ**

**挿入後も元の画像解像度は維持されますか？**  
はい。元のピクセルは保持されますが、最終的な表示はスライド上で [picture](/slides/ja/net/picture-frame/) がどのようにスケーリングされるかや、保存時に適用される圧縮に依存します。  

**多数のスライドで同じロゴを一括置換する最適な方法は何ですか？**  
ロゴをマスタースライドまたはレイアウトに配置し、プレゼンテーションの画像コレクションで置き換えます。これにより、そのリソースを使用しているすべての要素に変更が反映されます。  

**挿入した SVG を編集可能なシェイプに変換できますか？**  
はい。SVG をシェイプのグループに変換でき、その後、個々のパーツは標準のシェイプ プロパティで編集可能になります。  

**複数のスライドの背景として画像を一括設定するにはどうすればよいですか？**  
マスタースライドまたは該当レイアウトで画像を[背景として割り当て](/slides/ja/net/presentation-background/)すると、そのマスタ/レイアウトを使用しているすべてのスライドが背景を継承します。  

**多数の画像によりプレゼンテーションのサイズが膨らむのを防ぐにはどうすればよいですか？**  
画像の重複を避けて単一の画像リソースを再利用し、適切な解像度を選択し、保存時に圧縮を適用し、必要に応じてマスターに繰り返し使用するグラフィックを配置してください。