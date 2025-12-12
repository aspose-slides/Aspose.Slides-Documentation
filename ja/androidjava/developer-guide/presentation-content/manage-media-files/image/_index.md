---
title: Androidでプレゼンテーションの画像管理を最適化
linktitle: 画像を管理
type: docs
weight: 10
url: /ja/androidjava/image/
keywords:
- 画像を追加
- 図を追加
- ビットマップを追加
- 画像を置換
- 図を置換
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
- Android
- Java
- Aspose.Slides
description: "Java を使用した Android 向け Aspose.Slides により、PowerPoint と OpenDocument の画像管理を効率化し、パフォーマンスを最適化しながらワークフローを自動化します。"
---

## **プレゼンテーション スライドの画像**

画像はプレゼンテーションをより魅力的で興味深いものにします。Microsoft PowerPoint では、ファイル、インターネット、またはその他の場所から画像をスライドに挿入できます。同様に、Aspose.Slides を使用すると、さまざまな方法でプレゼンテーションのスライドに画像を追加できます。 

{{% alert  title="Tip" color="primary" %}} 

Aspose は無料コンバータ―[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)―を提供しており、画像から迅速にプレゼンテーションを作成できます。 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

画像をフレーム オブジェクトとして追加したい場合、特にサイズ変更や効果の追加などの標準書式オプションを使用する予定がある場合は、[Picture Frame](https://docs.aspose.com/slides/androidjava/picture-frame/) を参照してください。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

画像と PowerPoint プレゼンテーションに関わる入出力操作を操作して、画像をある形式から別の形式に変換できます。以下のページをご参照ください: 画像を JPG に変換[image to JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/); JPG を画像に変換[JPG to image](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/); JPG を PNG に変換[JPG to PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/), PNG を JPG に変換[PNG to JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/); PNG を SVG に変換[PNG to SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/), SVG を PNG に変換[SVG to PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/)。

{{% /alert %}}

Aspose.Slides は、JPEG、PNG、GIF などの一般的な形式の画像操作をサポートしています。 

## **ローカルに保存されている画像をスライドに追加**

コンピューター上の 1 つまたは複数の画像をプレゼンテーションのスライドに追加できます。この Java のサンプルコードは、画像をスライドに追加する方法を示しています:
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


## **Web から画像をスライドに追加**

スライドに追加したい画像がコンピューターにない場合は、Web から直接画像を追加できます。

このサンプルコードは、Web から画像を取得して Java でスライドに追加する方法を示しています:
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


## **スライド マスターに画像を追加**

スライド マスターは、下位のすべてのスライドのテーマやレイアウトなどの情報を保持し制御する上位スライドです。したがって、スライド マスターに画像を追加すると、その画像はそのマスター配下のすべてのスライドに表示されます。

この Java のサンプルコードは、スライド マスターに画像を追加する方法を示しています:
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


## **スライドの背景として画像を追加**

特定のスライドまたは複数のスライドの背景に画像を使用することができます。その場合は、*[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/androidjava/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **プレゼンテーションに SVG を追加**

任意の画像をプレゼンテーションに追加または挿入するには、[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) インターフェイスに属する [addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) メソッドを使用します。

SVG 画像に基づく画像オブジェクトを作成する方法は次のとおりです。

1. SvgImage オブジェクトを作成し、ImageShapeCollection に挿入します
2. ISvgImage から PPImage オブジェクトを作成します
3. IPPImage インターフェイスを使用して PictureFrame オブジェクトを作成します

このサンプルコードは、上記の手順を実装して SVG 画像をプレゼンテーションに追加する方法を示しています:
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

Aspose.Slides の SVG をシェイプのセットに変換する機能は、SVG 画像を操作するための PowerPoint の機能と同様です:

![PowerPoint Popup Menu](img_01_01.png)

この機能は、[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) インターフェイスの [addGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) メソッドのオーバーロードの一つによって提供され、最初の引数として [ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgImage) オブジェクトを受け取ります。

このサンプルコードは、記述されたメソッドを使用して SVG ファイルをシェイプのセットに変換する方法を示しています:
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

Aspose.Slides for Android via Java を使用すると、Excel シートから EMF 画像を生成し、Aspose.Cells と組み合わせてスライドに EMF として画像を追加できます。 

このサンプルコードは、上記のタスクを実行する方法を示しています:
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


## **画像コレクション内の画像を置換**

Aspose.Slides では、プレゼンテーションの画像コレクション（スライド シェイプで使用されているものも含む）に保存されている画像を置換できます。このセクションでは、コレクション内の画像を更新するいくつかの方法を示します。API は、バイト データ、[IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) インスタンス、またはコレクション内に既に存在する別の画像を使用して画像を置換するシンプルなメソッドを提供します。

以下の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスを使用して画像を含むプレゼンテーション ファイルを読み込みます。
2. ファイルから新しい画像をバイト配列に読み込みます。
3. バイト配列を使用して対象画像を新しい画像に置換します。
4. 2 番目のアプローチでは、画像を [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) オブジェクトに読み込み、そのオブジェクトで対象画像を置換します。
5. 3 番目のアプローチでは、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置換します。
6. 変更結果のプレゼンテーションを PPTX ファイルとして保存します。
```java
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 1 番目の方法。
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
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

Aspose の無料 [Text to GIF](https://products.aspose.app/slides/text-to-gif) コンバータを使用すると、テキストを簡単にアニメーション化したり、テキストから GIF を作成したりできます。 

{{% /alert %}}

## **FAQ**

**挿入後も元の画像解像度はそのままですか？**

はい。元のピクセルは保持されますが、最終的な表示はスライド上で [picture](/slides/ja/androidjava/picture-frame/) がどのようにスケーリングされるかや、保存時に適用される圧縮に依存します。

**多数のスライドにわたって同じロゴを一括で置換する最良の方法は何ですか？**

ロゴをマスタースライドまたはレイアウトに配置し、プレゼンテーションの画像コレクションで置換すると、リソースを使用しているすべての要素に変更が反映されます。

**挿入された SVG を編集可能なシェイプに変換できますか？**

はい。SVG をシェイプのグループに変換でき、その後個々のパーツは標準のシェイプ プロパティで編集可能になります。

**複数のスライドの背景に同じ画像を一度に設定するにはどうすればよいですか？**

マスタースライドまたは該当レイアウトで画像を背景として割り当てます（[Assign the image as the background](/slides/ja/androidjava/presentation-background/)）。そのマスター/レイアウトを使用しているすべてのスライドが背景を継承します。

**画像が多くてプレゼンテーションのサイズが膨らむのを防ぐには？**

画像の重複を避けて単一リソースを再利用し、適切な解像度を選択し、保存時に圧縮を適用し、必要に応じてマスターにグラフィックを配置してください。