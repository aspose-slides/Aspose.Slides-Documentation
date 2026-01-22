---
title: Androidでのプレゼンテーションにおける画像管理の最適化
linktitle: 画像管理
type: docs
weight: 10
url: /ja/androidjava/image/
keywords:
- 画像の追加
- ピクチャの追加
- ビットマップの追加
- 画像の置換
- ピクチャの置換
- Webから
- 背景
- PNGの追加
- JPGの追加
- SVGの追加
- EMFの追加
- WMFの追加
- TIFFの追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument の画像管理を効率化し、パフォーマンスを最適化し、ワークフローを自動化します。"
---

## **プレゼンテーションスライドの画像**

画像はプレゼンテーションをより魅力的で面白くします。Microsoft PowerPoint では、ファイル、インターネット、またはその他の場所から画像をスライドに挿入できます。同様に、Aspose.Slides を使用すると、さまざまな方法でプレゼンテーションのスライドに画像を追加できます。

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料コンバータ―[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)―を提供しており、画像から迅速にプレゼンテーションを作成できます。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
フレームオブジェクトとして画像を追加したい場合―特にサイズ変更や効果の追加などの標準書式設定オプションを使用する予定がある場合―は、[Picture Frame](https://docs.aspose.com/slides/androidjava/picture-frame/) を参照してください。 
{{% /alert %}} 

Aspose.Slides は、JPEG、PNG、GIF などの一般的な形式の画像操作をサポートしています。

## **ローカルに保存された画像をスライドに追加する**

コンピューター上の 1 枚または複数の画像をプレゼンテーションのスライドに追加できます。この Java のサンプルコードは、スライドに画像を追加する方法を示しています：
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


## **Web から画像をスライドに追加する**

スライドに追加したい画像がコンピューターにない場合、Web から直接画像を追加できます。

このサンプルコードは、Web から画像を取得して Java でスライドに追加する方法を示しています：
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


## **スライドマスターに画像を追加する**

スライドマスターは、下位のすべてのスライドに関する情報（テーマ、レイアウトなど）を格納および管理する最上位のスライドです。そのため、スライドマスターに画像を追加すると、その画像はマスター配下のすべてのスライドに表示されます。

この Java のサンプルコードは、スライドマスターに画像を追加する方法を示しています：
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


## **スライドの背景として画像を追加する**

特定のスライドまたは複数のスライドの背景に画像を使用したい場合は、*[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/androidjava/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **プレゼンテーションに SVG を追加する**
[addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) メソッド（[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) インターフェイスに属する）を使用して、任意の画像をプレゼンテーションに追加または挿入できます。

SVG 画像に基づく画像オブジェクトを作成するには、次の手順で行います。

1. SvgImage オブジェクトを作成して ImageShapeCollection に挿入する
2. ISvgImage から PPImage オブジェクトを作成する
3. IPPImage インターフェイスを使用して PictureFrame オブジェクトを作成する

以下のサンプルコードは、上記の手順を実装して SVG 画像をプレゼンテーションに追加する方法を示しています：
```java 
// PPTX ファイルを表す Presentation クラスのインスタンスを生成します
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


## **SVG を形状のセットに変換する**
Aspose.Slides の SVG から形状セットへの変換は、SVG 画像を扱うために PowerPoint で使用される機能と同様です：

![PowerPoint Popup Menu](img_01_01.png)

この機能は、[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) インターフェイスの [addGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) メソッドのオーバーロードの 1 つによって提供され、最初の引数に [ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgImage) オブジェクトを受け取ります。

以下のサンプルコードは、記載されたメソッドを使用して SVG ファイルを形状のセットに変換する方法を示しています：
```java 
// 新しいプレゼンテーションを作成
IPresentation presentation = new Presentation();
try {
    // SVG ファイルの内容を読み取る
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // SvgImage オブジェクトを作成
    ISvgImage svgImage = new SvgImage(svgContent);

    // スライドサイズを取得
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // SVG 画像をスライドサイズに合わせて拡大縮小し、形状のグループに変換
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // プレゼンテーションを PPTX 形式で保存
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **スライドに EMF として画像を追加する**
Aspose.Slides for Android via Java は、Excel シートから EMF 画像を生成し、Aspose.Cells と組み合わせてスライドに EMF 画像として追加することを可能にします。

このサンプルコードは、上記のタスクを実行する方法を示しています：
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


## **画像コレクション内の画像を置換する**

Aspose.Slides では、プレゼンテーションの画像コレクション（スライド形状で使用されているものを含む）に保存されている画像を置換できます。このセクションでは、コレクション内の画像を更新するいくつかのアプローチを示します。API は、バイト データ、[IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) インスタンス、またはコレクション内に既に存在する別の画像を使用して画像を置換するシンプルなメソッドを提供します。

以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスを使用して、画像を含むプレゼンテーション ファイルをロードします。
1. ファイルから新しい画像をバイト配列にロードします。
1. バイト配列を使用して対象画像を新しい画像に置換します。
1. 2 番目のアプローチでは、画像を [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) オブジェクトにロードし、そのオブジェクトで対象画像を置換します。
1. 3 番目のアプローチでは、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置換します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。
```java
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("sample.pptx");
try {
	// 最初の方法。
	IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
	IPPImage oldImage = presentation.getImages().get_Item(0);
	oldImage.replaceImage(imageData);
	
	// 二番目の方法。
	IImage newImage = Images.fromFile("image1.png");
	oldImage = presentation.getImages().get_Item(1);
	oldImage.replaceImage(newImage);
	newImage.dispose();
	
	// 三番目の方法。
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

**挿入後も元の画像解像度は保持されますか？**

はい。元のピクセルは保持されますが、最終的な表示はスライド上で [picture](/slides/ja/androidjava/picture-frame/) がどのように拡大縮小されるかや、保存時に適用される圧縮に依存します。

**多数のスライドで同じロゴを一括置換する最適な方法は？**

マスタースライドまたはレイアウトにロゴを配置し、プレゼンテーションの画像コレクションで置換すれば、該当リソースを使用しているすべての要素に変更が反映されます。

**挿入した SVG を編集可能な形状に変換できますか？**

はい。SVG を形状のグループに変換でき、個々のパーツは標準の形状プロパティで編集可能になります。

**複数のスライドの背景に画像を一括設定するには？**

マスタースライドまたは該当レイアウトで画像を背景として割り当てれば（[Assign the image as the background](/slides/ja/androidjava/presentation-background/)）、そのマスタ/レイアウトを使用しているすべてのスライドが背景を継承します。

**多くの画像でプレゼンテーションのサイズが膨張するのを防ぐには？**

重複画像を避けて単一の画像リソースを再利用し、解像度を適切に設定し、保存時に圧縮を適用し、必要に応じてマスターに繰り返し使用するグラフィックを配置してください。