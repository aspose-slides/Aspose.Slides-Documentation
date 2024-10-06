---
title: 画像
type: docs
weight: 10
url: /ja/java/image/
description: Javaを使用して、PowerPointプレゼンテーションのスライドに画像を操作します。ディスクまたはウェブからPowerPointスライドに画像を追加します。スライドマスターまたはスライド背景としてJavaを使用して画像を追加します。Javaを使用してSVGをPowerPointプレゼンテーションに追加します。Javaを使用してSVGをPowerPointのシェイプに変換します。Javaを使用してスライドに画像をEMFとして追加します。
---

## **プレゼンテーションのスライドの画像**

画像はプレゼンテーションをより魅力的で興味深いものにします。Microsoft PowerPointでは、ファイル、インターネット、または他の場所からスライドに写真を挿入できます。同様に、Aspose.Slidesは、さまざまな手順を通じてプレゼンテーションのスライドに画像を追加できるようにします。

{{% alert title="ヒント" color="primary" %}}

Asposeは、画像から迅速にプレゼンテーションを作成できる無料のコンバーター—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt)および[PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)を提供しています。

{{% /alert %}}

{{% alert title="情報" color="info" %}}

フレームオブジェクトとして画像を追加したい場合、特に標準のフォーマットオプションを使用してサイズを変更したり、エフェクトを追加したりする予定がある場合は、[Picture Frame](https://docs.aspose.com/slides/java/picture-frame/)を参照してください。

{{% /alert %}}

{{% alert title="注記" color="warning" %}}

画像とPowerPointプレゼンテーションを含む入出力操作を操作して、画像を別のフォーマットに変換することができます。次のページを参照してください：[画像をJPGに変換](https://products.aspose.com/slides/java/conversion/image-to-jpg/)；[JPGを画像に変換](https://products.aspose.com/slides/java/conversion/jpg-to-image/)；[JPGをPNGに変換](https://products.aspose.com/slides/java/conversion/jpg-to-png/)、[PNGをJPGに変換](https://products.aspose.com/slides/java/conversion/png-to-jpg/)；[PNGをSVGに変換](https://products.aspose.com/slides/java/conversion/png-to-svg/)、[SVGをPNGに変換](https://products.aspose.com/slides/java/conversion/svg-to-png/)。

{{% /alert %}}

Aspose.Slidesは、これらの一般的なフォーマットでの画像操作をサポートしています：JPEG、PNG、GIF、その他。

## **ローカルに保存された画像をスライドに追加する**

プレゼンテーションのスライドに、コンピュータ上の1つまたは複数の画像を追加できます。このサンプルコードは、Javaを使用してスライドに画像を追加する方法を示しています：

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

## **ウェブからスライドに画像を追加する**

スライドに追加したい画像がコンピュータ上にない場合は、ウェブから直接画像を追加できます。

このサンプルコードは、Javaを使用してウェブからスライドに画像を追加する方法を示しています：

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

スライドマスターは、すべてのスライドに関する情報（テーマ、レイアウトなど）を保存および制御する上部スライドです。したがって、スライドマスターに画像を追加すると、その画像がそのスライドマスターのすべてのスライドに表示されます。

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

## **スライドの背景として画像を追加する**

特定のスライドまたは複数のスライドの背景に画像を使用することを決定する場合があります。その場合は、* [スライドの背景として画像を設定](https://docs.aspose.com/slides/java/presentation-background/#setting-images-as-background-for-slides)*を参照してください。

## **プレゼンテーションにSVGを追加する**
[addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)メソッドを使用して、任意の画像をプレゼンテーションに追加または挿入できます。このメソッドは、[IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection)インターフェイスに属しています。

SVG画像に基づいて画像オブジェクトを作成するには、次の手順を行います：

1. SvgImageオブジェクトを作成して、ImageShapeCollectionに挿入します
2. ISvgImageからPPImageオブジェクトを作成します
3. IPPImageインターフェイスを使用してPictureFrameオブジェクトを作成します

このサンプルコードは、上記の手順を実行してSVG画像をプレゼンテーションに追加する方法を示しています：
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

## **SVGを一連のシェイプに変換する**
Aspose.SlidesによるSVGからシェイプのセットへの変換は、SVG画像を操作するために使用されるPowerPointの機能に類似しています：

![PowerPointポップアップメニュー](img_01_01.png)

この機能は、最初の引数として[ISvgImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgImage)オブジェクトを受け取る、[IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection)インターフェイスの[addGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-)のオーバーロードの1つによって提供されます。

このサンプルコードは、SVGファイルを一連のシェイプに変換するために記載されたメソッドを使用する方法を示しています：

```java 
// 新しいプレゼンテーションを作成
IPresentation presentation = new Presentation();
try {
    // SVGファイルの内容を読み取る
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // SvgImageオブジェクトを作成
    ISvgImage svgImage = new SvgImage(svgContent);

    // スライドのサイズを取得
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // SVG画像をスライドサイズにスケールしてグループシェイプに変換
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
Aspose.Slides for Javaを使用すると、ExcelシートからEMF画像を生成し、Aspose.Cellsを使用してスライドにEMFとして画像を追加できます。

このサンプルコードは、記載されたタスクを実行する方法を示しています：

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

Asposeの無料の[Text to GIF](https://products.aspose.app/slides/text-to-gif)コンバーターを使用すると、テキストを簡単にアニメーション化したり、テキストからGIFを作成したりできます。

{{% /alert %}}