---
title: .NET のプレゼンテーションにおける画像管理の最適化
linktitle: 画像管理
type: docs
weight: 10
url: /ja/net/image/
keywords:
- 画像を追加
- 画像を追加
- ビットマップを追加
- 画像を置換
- 画像を置換
- ウェブから
- 背景
- PNGを追加
- JPGを追加
- SVGを追加
- EMFを追加
- WMFを追加
- TIFFを追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint と OpenDocument の画像管理を合理化し、パフォーマンスを最適化し、ワークフローを自動化します。"
---

## **プレゼンテーションスライドの画像**

画像はプレゼンテーションをより魅力的で興味深いものにします。Microsoft PowerPoint では、ファイル、インターネット、またはその他の場所から画像をスライドに挿入できます。同様に、Aspose.Slides を使用すると、さまざまな手順でプレゼンテーションのスライドに画像を追加できます。

{{% alert  title="Tip" color="primary" %}} 

Aspose は無料コンバータ―[JPEG から PowerPoint へ](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG から PowerPoint へ](https://products.aspose.app/slides/import/png-to-ppt)―を提供しており、画像から迅速にプレゼンテーションを作成できます。 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

画像をフレームオブジェクトとして追加したい場合―特にサイズ変更や効果の追加など標準の書式設定オプションを使用する予定がある場合は、[画像フレーム](/slides/ja/net/picture-frame/) を参照してください。 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

画像と PowerPoint プレゼンテーションに関わる入出力操作を操作して、画像をある形式から別の形式に変換できます。次のページをご覧ください: 変換 [画像 を JPG に変換](https://products.aspose.com/slides/net/conversion/image-to-jpg/); 変換 [JPG を画像に変換](https://products.aspose.com/slides/net/conversion/jpg-to-image/); 変換 [JPG を PNG に変換](https://products.aspose.com/slides/net/conversion/jpg-to-png/), 変換 [PNG を JPG に変換](https://products.aspose.com/slides/net/conversion/png-to-jpg/); 変換 [PNG を SVG に変換](https://products.aspose.com/slides/net/conversion/png-to-svg/), 変換 [SVG を PNG に変換](https://products.aspose.com/slides/net/conversion/svg-to-png/)。 

{{% /alert %}}

Aspose.Slides は JPEG、PNG、BMP、GIF などの一般的な形式の画像操作をサポートします。 

## **ローカルに保存された画像をスライドに追加**

コンピューター上の画像を 1 つまたは複数スライドに追加できます。次の C# のサンプルコードは、画像をスライドに追加する方法を示しています:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Web から画像をスライドに追加**

コンピューターに画像がなくても、Web から直接画像をスライドに追加できます。次の C# のサンプルコードは、Web から画像を取得してスライドに追加する方法を示しています:
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

スライドマスタは、下位のすべてのスライドに関する情報（テーマ、レイアウトなど）を保持および制御する上位スライドです。そのため、スライドマスタに画像を追加すると、その画像はマスタ配下のすべてのスライドに表示されます。次の C# のサンプルコードは、スライドマスタに画像を追加する方法を示しています:
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

特定のスライドまたは複数のスライドの背景に画像を使用したい場合は、*[スライドの背景として画像を設定](/slides/ja/net/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **プレゼンテーションに SVG を追加**
[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) インターフェイスの [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) メソッドを使用して、任意の画像をプレゼンテーションに追加または挿入できます。

SVG 画像に基づく画像オブジェクトを作成するには、次の手順で実行します。

1. SvgImage オブジェクトを作成して ImageShapeCollection に挿入
2. ISvgImage から PPImage オブジェクトを作成
3. IPPImage インターフェイスを使用して PictureFrame オブジェクトを作成

次のサンプルコードは、上記の手順を実装して SVG 画像をプレゼンテーションに追加する方法を示しています:
``` csharp 
// ドキュメントディレクトリへのパス
string dataDir = @"D:\Documents\";

// ソース SVG ファイル名
string svgFileName = dataDir + "sample.svg";

// 出力プレゼンテーションファイル名
string outPptxPath = dataDir + "presentation.pptx";

// 新しいプレゼンテーションを作成
using (var p = new Presentation())
{
    // SVG ファイルの内容を読み込む
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage オブジェクトを作成
    ISvgImage svgImage = new SvgImage(svgContent);

    // PPImage オブジェクトを作成
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // 新しい PictureFrame を作成 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // プレゼンテーションを PPTX 形式で保存
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **SVG をシェイプの集合に変換**
Aspose.Slides の SVG からシェイプ集合への変換は、PowerPoint の SVG 画像操作機能と同様です:

![PowerPoint ポップアップ メニュー](img_01_01.png)

この機能は、[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) インターフェイスの [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) メソッドのオーバーロードの一つで、最初の引数に [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) オブジェクトを受け取ります。

次のサンプルコードは、SVG ファイルをシェイプの集合に変換する方法を示しています:
``` csharp 
// ドキュメントディレクトリへのパス
string dataDir = @"D:\Documents\";

// ソース SVG ファイル名
string svgFileName = dataDir + "sample.svg";

// 出力プレゼンテーションファイル名
string outPptxPath = dataDir + "presentation.pptx";

// 新しいプレゼンテーションを作成
using (IPresentation presentation = new Presentation())
{
    // SVG ファイルの内容を読み込む
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage オブジェクトを作成
    ISvgImage svgImage = new SvgImage(svgContent);

    // スライドサイズを取得
    SizeF slideSize = presentation.SlideSize.Size;

    // SVG 画像をスライドサイズに合わせてシェイプのグループに変換
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // プレゼンテーションを PPTX 形式で保存
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **画像を EMF としてスライドに追加**
Aspose.Slides for .NET は Excel シートから EMF 画像を生成し、Aspose.Cells と組み合わせて EMF 画像をスライドに追加できます。  

次のサンプルコードは、上記のタスクを実行する方法を示しています:
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


## **画像コレクション内の画像を置換**

Aspose.Slides を使用すると、プレゼンテーションの画像コレクションに保存されている画像（スライドシェイプで使用されているものを含む）を置換できます。このセクションでは、コレクション内の画像を更新するいくつかのアプローチを示します。API は、生バイト データ、[IImage](/slides/ja/net/iimage/) インスタンス、またはコレクション内に既に存在する別の画像を使用して画像を置換するシンプルなメソッドを提供します。

以下の手順に従ってください:

1. [Presentation](/slides/ja/net/presentation/) クラスを使用して画像を含むプレゼンテーション ファイルを読み込みます。  
2. ファイルから新しい画像をバイト配列に読み込みます。  
3. バイト配列を使用して対象画像を新しい画像に置換します。  
4. 2 番目のアプローチでは、画像を [IImage](/slides/ja/net/iimage/) オブジェクトに読み込み、そのオブジェクトで対象画像を置換します。  
5. 3 番目のアプローチでは、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置換します。  
6. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  
```cs
// Presentation クラスのインスタンスを作成します（プレゼンテーション ファイルを表します）。
using Presentation presentation = new Presentation("sample.pptx");

// 最初の方法。
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// 2番目の方法。
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// 3番目の方法。
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// プレゼンテーションをファイルに保存します。
presentation.Save("output.pptx", SaveFormat.Pptx);
```


{{% alert title="Info" color="info" %}}

Aspose の無料 [Text to GIF](/slides/ja/text-to-gif) コンバータを使用すると、テキストを簡単にアニメーション化したり、テキストから GIF を作成したりできます。 

{{% /alert %}}

## **FAQ**

**画像を挿入した後、元の解像度は保持されますか？**

はい。元のピクセルは保持されますが、最終的な見た目はスライド上で [picture](/slides/ja/net/picture-frame/) がどのようにスケーリングされるかや、保存時に適用される圧縮に依存します。

**多数のスライドで同じロゴを一括置換する最良の方法は何ですか？**

ロゴをマスタスライドまたはレイアウトに配置し、プレゼンテーションの画像コレクションで置換すれば、すべての該当要素に自動的に反映されます。

**挿入した SVG を編集可能なシェイプに変換できますか？**

はい。SVG をシェイプのグループに変換でき、その後個々のパーツは標準のシェイププロパティで編集可能になります。

**複数のスライドに対して一括で画像を背景として設定するには？**

マスタスライドまたは該当レイアウトで画像を背景として割り当てれば、そのマスタ/レイアウトを使用しているすべてのスライドが同じ背景を継承します。

**多数の画像によりプレゼンテーションのサイズが膨れ上がるのを防ぐには？**

画像リソースを重複せずに再利用し、適切な解像度を選択、保存時に圧縮を適用し、共通のグラフィックはマスタに配置するなどの対策を行ってください。