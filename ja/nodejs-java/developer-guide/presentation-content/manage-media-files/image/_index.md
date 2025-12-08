---
title: 画像
type: docs
weight: 10
url: /ja/nodejs-java/image/
keywords:
- 画像を追加
- 写真を追加
- ビットマップを追加
- 画像を置換
- 写真を置換
- Webから
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
- EMF
- SVG
- Node.js
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、PowerPoint および OpenDocument の画像管理を効率化し、パフォーマンスを最適化し、ワークフローを自動化します。"
---

## **プレゼンテーションのスライド内の画像**

画像はプレゼンテーションをより魅力的で興味深いものにします。Microsoft PowerPoint では、ファイル、インターネット、または他の場所から画像をスライドに挿入できます。同様に、Aspose.Slides ではさまざまな手順でプレゼンテーションのスライドに画像を追加できます。

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料コンバータ—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) を提供しており、画像から素早くプレゼンテーションを作成できます。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
画像をフレームオブジェクトとして追加したい場合、特にサイズ変更やエフェクト追加など標準の書式設定オプションを使用する予定がある場合は、[Picture Frame](https://docs.aspose.com/slides/nodejs-java/picture-frame/) を参照してください。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
画像と PowerPoint プレゼンテーションに関わる入出力操作を操作して、画像を別の形式に変換できます。次のページをご確認ください: 画像を [JPG に変換](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/)；[JPG を画像に変換](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/)；[JPG を PNG に変換](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/)；[PNG を JPG に変換](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/)；[PNG を SVG に変換](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/)；[SVG を PNG に変換](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/)。 
{{% /alert %}}

Aspose.Slides は JPEG、PNG、GIF などの一般的な形式の画像操作をサポートします。 

## **ローカルに保存された画像をスライドに追加する**

コンピュータ上の 1 つまたは複数の画像をプレゼンテーションのスライドに追加できます。この JavaScript サンプルコードは、スライドに画像を追加する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **ストリームから画像をスライドに追加する**

コンピュータに画像がない場合は、Web から直接画像を取得してスライドに追加できます。

この JavaScript サンプルコードは、Web から画像を取得してスライドに追加する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスします
    var sld = pres.getSlides().get_Item(0);
    // Excel ファイルをストリームに読み込みます
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // 埋め込み用データオブジェクトを作成します
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Ole オブジェクトフレーム形状を追加します
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // PPTX ファイルを書き込みます
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **スライドマスターに画像を追加する**

スライドマスターは、下位のすべてのスライドに関する情報（テーマ、レイアウトなど）を保存および管理する最上位のスライドです。そのため、スライドマスターに画像を追加すると、その画像はマスター配下のすべてのスライドに表示されます。

この JavaScript サンプルコードは、スライドマスターに画像を追加する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **スライドの背景として画像を追加する**

特定のスライドまたは複数のスライドの背景に画像を使用したい場合は、*[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/nodejs-java/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **プレゼンテーションに SVG を追加する**
[addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) メソッド（[ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) クラス所属）を使用して、任意の画像をプレゼンテーションに追加または挿入できます。

SVG 画像に基づく画像オブジェクトを作成するには、次の手順で行います。

1. SvgImage オブジェクトを作成し、ImageShapeCollection に挿入する  
2. ISvgImage から PPImage オブジェクトを作成する  
3. PPImage クラスを使用して PictureFrame オブジェクトを作成する  

このサンプルコードは、上記手順を実装して SVG 画像をプレゼンテーションに追加する方法を示しています:
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **SVG をシェイプの集合に変換する**
Aspose.Slides の SVG をシェイプ集合に変換する機能は、SVG 画像を操作するための PowerPoint の機能と同様です:

![PowerPoint Popup Menu](img_01_01.png)

この機能は、[ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) クラスの [addGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) メソッドのオーバーロードの一つで提供され、最初の引数として [SvgImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SvgImage) オブジェクトを受け取ります。

このサンプルコードは、上記メソッドを使用して SVG ファイルをシェイプの集合に変換する方法を示しています:
```javascript
// 新しいプレゼンテーションを作成します
var presentation = new aspose.slides.Presentation();
try {
    // SVG ファイルの内容を読み取ります
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // SvgImage オブジェクトを作成します
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // スライドサイズを取得します
    var slideSize = presentation.getSlideSize().getSize();
    // SVG 画像をスライドサイズに合わせて拡大縮小し、シェイプのグループに変換します
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // プレゼンテーションを PPTX 形式で保存します
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **スライドに EMF 画像として追加する**
Aspose.Slides for Node.js via Java を使用すると、Excel シートから EMF 画像を生成し、Aspose.Cells と組み合わせてスライドに EMF として画像を追加できます。

このサンプルコードは、記述されたタスクを実行する方法を示しています:
```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
 // ワークブックをストリームに保存します
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **画像コレクション内の画像を置換する**

Aspose.Slides は、プレゼンテーションの画像コレクション（スライドシェイプが使用している画像を含む）に格納された画像を置換できます。このセクションでは、コレクション内の画像を更新するいくつかのアプローチを示します。API は、バイトデータ、[IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) インスタンス、またはコレクション内に既に存在する別の画像を使用して画像を置換するシンプルなメソッドを提供します。

以下の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスを使用して、画像を含むプレゼンテーション ファイルを読み込みます。  
2. ファイルから新しい画像をバイト配列に読み込みます。  
3. バイト配列を使用して対象画像を新しい画像に置換します。  
4. 2 番目のアプローチでは、画像を [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) オブジェクトにロードし、そのオブジェクトで対象画像を置換します。  
5. 3 番目のアプローチでは、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置換します。  
6. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  
```js
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // 1 番目の方法
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // 2 番目の方法
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // 3 番目の方法
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // プレゼンテーションをファイルに保存します
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}
Aspose の無料 [Text to GIF](https://products.aspose.app/slides/text-to-gif) コンバータを使用すると、テキストを簡単にアニメーション化したり、テキストから GIF を作成したりできます。 
{{% /alert %}}

## **FAQ**

**挿入後も元の画像解像度は維持されますか？**

はい。元のピクセルは保持されますが、最終的な見た目はスライド上で [picture](/slides/ja/nodejs-java/picture-frame/) がどのようにスケーリングされるかや、保存時に適用される圧縮に依存します。

**多数のスライドに同じロゴを一括で置換する最適な方法は？**

マスタースライドまたはレイアウトにロゴを配置し、プレゼンテーションの画像コレクションで置換すると、該当リソースを使用しているすべての要素に自動的に反映されます。

**挿入した SVG を編集可能なシェイプに変換できますか？**

はい。SVG をシェイプのグループに変換でき、その後個々のパーツは標準のシェイププロパティで編集可能になります。

**複数のスライドに同時に画像を背景として設定するには？**

マスタースライドまたは該当レイアウトで画像を背景として割り当てます（[Assign the image as the background](/slides/ja/nodejs-java/presentation-background/)）。そのマスター/レイアウトを使用しているすべてのスライドが背景を継承します。

**多数の画像でプレゼンテーションがサイズ肥大化するのを防ぐには？**

画像の重複を避けて単一のリソースを再利用し、適切な解像度を選択し、保存時に圧縮を適用し、必要に応じてマスターに繰り返し使用するグラフィックスを配置してください。