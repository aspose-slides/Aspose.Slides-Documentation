---
title: JavaScript を使用したプレゼンテーションの画像管理の最適化
linktitle: 画像の管理
type: docs
weight: 10
url: /ja/nodejs-java/image/
keywords:
- 画像を追加
- 画像を追加
- ビットマップを追加
- 画像を置き換える
- 画像を置き換える
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
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript と Aspose.Slides for Node.js を使用して PowerPoint および OpenDocument の画像管理を効率化し、パフォーマンスを最適化しながらワークフローを自動化します。"
---

## **プレゼンテーションのスライド内の画像**

画像はプレゼンテーションをより魅力的で興味深いものにします。Microsoft PowerPointでは、ファイル、インターネット、または他の場所から画像をスライドに挿入できます。同様に、Aspose.Slidesを使用すると、さまざまな手順でプレゼンテーションのスライドに画像を追加できます。

{{% alert  title="Tip" color="primary" %}} 
Asposeは無料コンバータ—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—を提供しており、画像からプレゼンテーションをすばやく作成できます。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
画像をフレームオブジェクトとして追加したい場合—特に、サイズ変更や効果追加などの標準書式設定オプションを使用する予定がある場合は—[Picture Frame](https://docs.aspose.com/slides/nodejs-java/picture-frame/) を参照してください。
{{% /alert %}} 

Aspose.SlidesはJPEG、PNG、GIFなどの一般的なフォーマットの画像操作をサポートしています。

## **ローカルに保存された画像をスライドに追加する**

コンピューター上の1つまたは複数の画像をプレゼンテーションのスライドに追加できます。以下のJavaScriptサンプルコードは、スライドに画像を追加する方法を示しています：
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

コンピューターに画像がない場合、Webから直接画像を追加できます。

以下のサンプルコードは、Webから画像を取得してJavaScriptでスライドに追加する方法を示しています：
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスします
    var sld = pres.getSlides().get_Item(0);
    // Excel ファイルをストリームとして読み込みます
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // 埋め込み用のデータオブジェクトを作成します
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Ole オブジェクト フレーム シェイプを追加します
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

スライドマスターは、下位スライドのテーマやレイアウト情報を管理する最上位のスライドです。スライドマスターに画像を追加すると、その画像はそのマスター配下のすべてのスライドに表示されます。

以下のJavaScriptサンプルコードは、スライドマスターに画像を追加する方法を示しています：
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
任意の画像をプレゼンテーションに追加するには、[ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) クラスの[addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-)メソッドを使用します。

SVG 画像に基づく画像オブジェクトを作成する手順は次のとおりです。

1. SvgImage オブジェクトを作成して ImageShapeCollection に挿入する  
2. ISvgImage から PPImage オブジェクトを作成する  
3. PPImage クラスを使用して PictureFrame オブジェクトを作成する  

以下のサンプルコードは、上記手順を実装して SVG 画像をプレゼンテーションに追加する方法を示しています：
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


## **SVG を形状のセットに変換する**
Aspose.Slides の SVG から形状への変換は、PowerPoint の SVG 画像操作機能と同様です：

![PowerPoint Popup Menu](img_01_01.png)

この機能は、[ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) クラスの[addGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-)メソッド（最初の引数に [SvgImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SvgImage) オブジェクトを取るオーバーロード）の1つによって提供されます。

以下のサンプルコードは、記述されたメソッドを使用して SVG ファイルを形状のセットに変換する方法を示しています：
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


## **スライドに EMF として画像を追加する**
Aspose.Slides for Node.js via Java を使用すると、Excel シートから EMF 画像を生成し、Aspose.Cells と組み合わせてスライドに EMF 画像として追加できます。

以下のサンプルコードは、上記タスクを実行する方法を示しています：
```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// ワークブックをストリームに保存
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


## **画像コレクション内の画像を置き換える**

Aspose.Slides は、プレゼンテーションの画像コレクション（スライドシェイプで使用されている画像を含む）に保存されている画像の置き換えをサポートします。このセクションでは、コレクション内の画像を更新する複数のアプローチを示します。API は、生バイト データ、[IImage](/slides/ja/nodejs-java/iimage/) インスタンス、またはコレクションに既に存在する別の画像を使用して画像を置き換えるシンプルなメソッドを提供します。

以下の手順に従ってください：

1. [Presentation](/slides/ja/nodejs-java/presentation/) クラスを使用して画像を含むプレゼンテーション ファイルをロードします。  
2. ファイルから新しい画像をバイト配列にロードします。  
3. バイト配列を使用して対象画像を新しい画像に置き換えます。  
4. 2 番目のアプローチでは、画像を [IImage](/slides/ja/nodejs-java/iimage/) オブジェクトにロードし、そのオブジェクトで対象画像を置き換えます。  
5. 3 番目のアプローチでは、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置き換えます。  
6. 変更したプレゼンテーションを PPTX ファイルとして保存します。  
```js
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // 最初の方法。
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // 2 番目の方法。
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // 3 番目の方法。
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // プレゼンテーションをファイルに保存します。
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}
Aspose FREE の[Text to GIF](https://products.aspose.app/slides/text-to-gif) コンバータを使用すると、テキストを簡単にアニメーション化したり、テキストから GIF を作成したりできます。  
{{% /alert %}}

## **FAQ**

**挿入後も元の画像解像度は維持されますか？**  
はい。元のピクセルは保持されますが、最終的な表示はスライド上での[picture](/slides/ja/nodejs-java/picture-frame/) のスケーリングや保存時の圧縮に依存します。

**多数のスライドで同じロゴを一括で置き換える最適な方法は何ですか？**  
ロゴをマスタースライドまたはレイアウトに配置し、プレゼンテーションの画像コレクションで置き換えると、すべての該当要素に自動的に反映されます。

**挿入した SVG を編集可能な形状に変換できますか？**  
はい。SVG を形状のグループに変換でき、個々のパーツは標準の形状プロパティで編集可能になります。

**複数のスライドの背景として画像を一括で設定するには？**  
[Assign the image as the background](/slides/ja/nodejs-java/presentation-background/) をマスタースライドまたは該当レイアウトに設定すると、そこを使用するすべてのスライドが背景を継承します。

**多数の画像によりプレゼンテーションのサイズが膨らむのを防ぐには？**  
画像を重複せずに単一リソースとして再利用し、適切な解像度を選択、保存時に圧縮を適用し、必要に応じてマスタに共通グラフィックを置くことでサイズ増大を抑えられます。