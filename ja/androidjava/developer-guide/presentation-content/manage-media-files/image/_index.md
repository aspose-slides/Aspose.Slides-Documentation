---
title: 画像
type: docs
weight: 10
url: /ja/androidjava/image/
description: Javaを使用してPowerPointプレゼンテーションのスライドで画像を操作します。ディスクまたはウェブから画像をPowerPointスライドに追加します。スライドマスターまたはスライドの背景として画像をJavaを使用して追加します。Javaを使用してPowerPointプレゼンテーションにSVGを追加します。Javaを使用してSVGをPowerPointの図形に変換します。Javaを使用してスライドに画像をEMFとして追加します。
---

## **プレゼンテーションのスライドにおける画像**

画像はプレゼンテーションをより魅力的で興味深いものにします。Microsoft PowerPointでは、ファイル、インターネット、または他の場所からスライドに画像を挿入できます。同様に、Aspose.Slidesを使用すると、さまざまな手順を通じてプレゼンテーションのスライドに画像を追加できます。

{{% alert title="ヒント" color="primary" %}} 

Asposeは、画像から迅速にプレゼンテーションを作成できる無料のコンバータである[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt)と[PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)を提供しています。

{{% /alert %}} 

{{% alert title="情報" color="info" %}}

フレームオブジェクトとして画像を追加したい場合—特にサイズを変更したり、エフェクトを追加したりするために標準の書式設定オプションを使用する予定がある場合—は、[Picture Frame](https://docs.aspose.com/slides/androidjava/picture-frame/)を参照してください。

{{% /alert %}} 

{{% alert title="注" color="warning" %}}

画像やPowerPointプレゼンテーションを含む入出力操作を操作して、画像を別の形式に変換できます。次のページを参照してください：画像を[JPGに変換](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/)；[JPGを画像に変換](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/)；[JPGをPNGに変換](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/)、[PNGをJPGに変換](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/)；[PNGをSVGに変換](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/)、[SVGをPNGに変換](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/)。

{{% /alert %}}

Aspose.Slidesは、これらの人気のある形式での画像操作をサポートしています：JPEG、PNG、GIFなど。

## **ローカルに保存された画像をスライドに追加する**

コンピュータ上の1つまたは複数の画像をプレゼンテーションのスライドに追加できます。このJavaのサンプルコードは、スライドに画像を追加する方法を示しています：

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

## **ウェブから画像をスライドに追加する**

スライドに追加したい画像がコンピュータ上にない場合は、ウェブから直接画像を追加できます。

このサンプルコードは、ウェブからスライドに画像を追加する方法を示しています：

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

スライドマスターは、すべての下位スライドに関する情報（テーマ、レイアウトなど）を保存および制御する最上位のスライドです。そのため、スライドマスターに画像を追加すると、その画像はそのスライドマスターのすべてのスライドに表示されます。

このJavaのサンプルコードは、スライドマスターに画像を追加する方法を示しています：

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

## **スライド背景としての画像の追加**

特定のスライドまたは複数のスライドの背景として画像を使用することを決定できます。その場合、*画像をスライドの背景として設定する*ことを確認する必要があります。

## **プレゼンテーションにSVGを追加する**

[addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)メソッドを使用することで、プレゼンテーションに任意の画像を追加または挿入できます。このメソッドは、[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection)インターフェイスに属します。

SVG画像に基づいて画像オブジェクトを作成するには、次の手順を実行します：

1. SvgImageオブジェクトを作成してImageShapeCollectionに挿入します。
2. ISvgImageからPPImageオブジェクトを作成します。
3. IPPImageインターフェイスを使用してPictureFrameオブジェクトを作成します。

このサンプルコードは、SVG画像をプレゼンテーションに追加するための手順を実装する方法を示しています：
```java 
// PPTXファイルを表すPresentationクラスをインスタンス化
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

## **SVGを図形のセットに変換する**

Aspose.SlidesのSVGを図形のセットに変換する機能は、SVG画像を操作するために使用されるPowerPointの機能に類似しています：

![PowerPointのポップアップメニュー](img_01_01.png)

この機能は、[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection)インターフェイスの[addGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-)メソッドのオーバーロードの1つによって提供され、その最初の引数として[ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgImage)オブジェクトを受け取ります。

このサンプルコードは、SVGファイルを図形のセットに変換するために説明されたメソッドをどのように使用するかを示しています：

```java 
// 新しいプレゼンテーションを作成
IPresentation presentation = new Presentation();
try {
    // SVGファイルの内容を読み取る
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // SvgImageオブジェクトを作成
    ISvgImage svgImage = new SvgImage(svgContent);

    // スライドサイズを取得
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // SVG画像をスライドサイズにスケーリングして図形のグループに変換
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // プレゼンテーションをPPTX形式で保存
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **スライドにEMFとして画像を追加する**

Aspose.Slides for Android via Javaを使用すると、ExcelシートからEMF画像を生成し、Aspose.Cellsを使用してスライドにEMFとして画像を追加できます。

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

{{% alert title="情報" color="info" %}}

Asposeの無料の[Text to GIF](https://products.aspose.app/slides/text-to-gif)コンバータを使用すると、テキストを簡単にアニメーションし、テキストからGIFを作成することができます。

{{% /alert %}}