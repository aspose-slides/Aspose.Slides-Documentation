---
title: Java を使用したプレゼンテーションにおける画像管理の最適化
linktitle: 画像を管理
type: docs
weight: 10
url: /ja/java/image/
keywords:
- 画像を追加
- ピクチャを追加
- ビットマップを追加
- 画像を置換
- ピクチャを置換
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint と OpenDocument の画像管理を効率化し、パフォーマンスを最適化し、ワークフローを自動化します。"
---

## **プレゼンテーション スライドの画像**

画像はプレゼンテーションをより魅力的で面白くします。Microsoft PowerPoint では、ファイル、インターネット、その他の場所から画像をスライドに挿入できます。同様に、Aspose.Slides では、さまざまな方法でプレゼンテーションのスライドに画像を追加できます。

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料コンバータ―[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)―を提供しており、画像から迅速にプレゼンテーションを作成できます。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
画像をフレームオブジェクトとして追加したい場合―特にサイズ変更や効果の追加など標準の書式設定オプションを使用する予定がある場合―[Picture Frame](https://docs.aspose.com/slides/java/picture-frame/) を参照してください。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
画像や PowerPoint プレゼンテーションに関わる入出力操作を操作して、画像を別の形式に変換できます。以下のページを参照してください: 変換 [画像を JPG に変換](https://products.aspose.com/slides/java/conversion/image-to-jpg/); 変換 [JPG を画像に変換](https://products.aspose.com/slides/java/conversion/jpg-to-image/); 変換 [JPG を PNG に変換](https://products.aspose.com/slides/java/conversion/jpg-to-png/), 変換 [PNG を JPG に変換](https://products.aspose.com/slides/java/conversion/png-to-jpg/); 変換 [PNG を SVG に変換](https://products.aspose.com/slides/java/conversion/png-to-svg/), 変換 [SVG を PNG に変換](https://products.aspose.com/slides/java/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides は、JPEG、PNG、GIF などの一般的な形式の画像操作をサポートしています。 

## **ローカルに保存された画像をスライドに追加**

コンピューター上の画像を 1 枚または複数枚、プレゼンテーションのスライドに追加できます。この Java サンプルコードは、画像をスライドに追加する方法を示しています：
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **Web からの画像をスライドに追加**

スライドに追加したい画像がコンピューターにない場合、Web から直接画像を追加できます。

このサンプルコードは、Java で Web から画像をスライドに追加する方法を示しています：
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


## **スライドマスターに画像を追加**

スライドマスターは、下位のすべてのスライドに関する情報（テーマ、レイアウトなど）を保存および管理する最上位のスライドです。そのため、スライドマスターに画像を追加すると、その画像はそのマスター配下のすべてのスライドに表示されます。

この Java サンプルコードは、スライドマスターに画像を追加する方法を示しています：
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **画像をスライドの背景として追加**

特定のスライドや複数のスライドの背景として画像を使用したい場合があります。その際は、*[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/java/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **SVG をプレゼンテーションに追加**

任意の画像をプレゼンテーションに追加または挿入するには、[IShapeCollection] インターフェイスに属する [addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) メソッドを使用できます。

SVG 画像に基づく画像オブジェクトを作成するには、以下の手順で行います：

1. SvgImage オブジェクトを作成して ImageShapeCollection に挿入する
2. ISvgImage から PPImage オブジェクトを作成する
3. IPPImage インターフェイスを使用して PictureFrame オブジェクトを作成する

このサンプルコードは、上記の手順を実装して SVG 画像をプレゼンテーションに追加する方法を示しています：
```java
// PPTX ファイルを表す Presentation クラスをインスタンス化
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
            ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **SVG をシェイプのセットに変換**

Aspose.Slides の SVG をシェイプのセットに変換する機能は、SVG 画像を扱う PowerPoint の機能と同様です。

![PowerPoint Popup Menu](img_01_01.png)

この機能は、[IShapeCollection] インターフェイスの [addGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) メソッドのオーバーロードの一つで提供され、最初の引数に [ISvgImage] オブジェクトを取ります。

このサンプルコードは、記述されたメソッドを使用して SVG ファイルをシェイプのセットに変換する方法を示しています：
```java
// 新しいプレゼンテーションを作成
IPresentation presentation = new Presentation();
try {
    // SVG ファイルの内容を読み込む
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // SvgImage オブジェクトを作成
    ISvgImage svgImage = new SvgImage(svgContent);

    // スライドのサイズを取得
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // SVG 画像をスライドサイズに合わせてスケーリングし、シェイプのグループに変換
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // プレゼンテーションを PPTX 形式で保存
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **画像を EMF としてスライドに追加**

Aspose.Slides for Java を使用すると、Excel シートから EMF 画像を生成し、Aspose.Cells と組み合わせてスライドに EMF として画像を追加できます。

このサンプルコードは、記述されたタスクを実行する方法を示しています：
```java
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//ワークブックをストリームに保存
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **イメージコレクション内の画像を置換**

Aspose.Slides を使用すると、プレゼンテーションのイメージコレクションに格納されている画像（スライドシェイプで使用されているものを含む）を置換できます。このセクションでは、コレクション内の画像を更新するいくつかの方法を示します。API には、生バイトデータ、[IImage] インスタンス、またはコレクション内に既に存在する別の画像を使用して画像を置換するシンプルなメソッドが用意されています。

1. 画像を含むプレゼンテーション ファイルを [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスでロードします。
1. ファイルから新しい画像をバイト配列にロードします。
1. バイト配列を使用して対象画像を新しい画像に置換します。
1. 2 番目の方法では、画像を [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) オブジェクトにロードし、そのオブジェクトで対象画像を置換します。
1. 3 番目の方法では、プレゼンテーションのイメージコレクションに既に存在する画像で対象画像を置換します。
1. 修正したプレゼンテーションを PPTX ファイルとして書き出します。
```java
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 最初の方法。
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // 2 番目の方法。
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // 3 番目の方法。
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // プレゼンテーションをファイルに保存します。
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}
Aspose の無料 [Text to GIF](https://products.aspose.app/slides/text-to-gif) コンバータを使用すれば、テキストを簡単にアニメーション化したり、テキストから GIF を作成したりできます。 
{{% /alert %}}

## **FAQ**

**挿入後も元の画像解像度はそのままですか？**

はい。元のピクセルは保持されますが、最終的な見た目はスライド上で [picture](/slides/ja/java/picture-frame/) がどのようにスケーリングされるか、保存時に適用される圧縮に依存します。

**多数のスライドで同じロゴを一括置換する最適な方法は何ですか？**

ロゴをマスタースライドまたはレイアウトに配置し、プレゼンテーションのイメージコレクションで置換します。更新はそのリソースを使用しているすべての要素に伝播します。

**挿入した SVG を編集可能なシェイプに変換できますか？**

はい。SVG をシェイプのグループに変換でき、その後個々のパーツは標準のシェイププロパティで編集可能になります。

**複数のスライドの背景として画像を一括設定するにはどうすればよいですか？**

マスタースライドまたは該当レイアウトで画像を背景として割り当てます（[Assign the image as the background](/slides/ja/java/presentation-background/)）。そのマスタ/レイアウトを使用しているスライドはすべて背景を継承します。

**多数の画像でプレゼンテーションのサイズが膨らむのを防ぐには？**

画像の重複を避けて単一のリソースを再利用し、適切な解像度を選択し、保存時に圧縮を適用し、必要に応じてマスターに繰り返し使用するグラフィックを配置します。