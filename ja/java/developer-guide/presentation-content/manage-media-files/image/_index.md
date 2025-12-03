---
title: Java を使用したプレゼンテーションの画像管理の最適化
linktitle: 画像管理
type: docs
weight: 10
url: /ja/java/image/
keywords:
- 画像を追加
- 図を追加
- ビットマップを追加
- 画像を置換
- ピクチャを置換
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
- Java
- Aspose.Slides
description: "Java 用 Aspose.Slides を使用して PowerPoint および OpenDocument の画像管理を効率化し、パフォーマンスを最適化し、ワークフローを自動化します。"
---

## **プレゼンテーションスライドの画像**

画像はプレゼンテーションをより魅力的で興味深いものにします。Microsoft PowerPoint では、ファイル、インターネット、またはその他の場所から画像をスライドに挿入できます。同様に、Aspose.Slides を使用すると、さまざまな手順でプレゼンテーションのスライドに画像を追加できます。

{{% alert  title="Tip" color="primary" %}} 

Aspose は無料コンバータ—[JPEG から PowerPoint へ](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG から PowerPoint へ](https://products.aspose.app/slides/import/png-to-ppt)—を提供しており、画像から迅速にプレゼンテーションを作成できます。 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

画像をフレームオブジェクトとして追加したい場合、特にサイズ変更や効果の追加などの標準的な書式設定オプションを使用する予定がある場合は、[画像フレーム](https://docs.aspose.com/slides/java/picture-frame/) を参照してください。 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

画像と PowerPoint プレゼンテーションに関わる入出力操作を操作して、画像をある形式から別の形式に変換できます。以下のページをご参照ください: 変換 [画像を JPG に変換](https://products.aspose.com/slides/java/conversion/image-to-jpg/); 変換 [JPG を画像に変換](https://products.aspose.com/slides/java/conversion/jpg-to-image/); 変換 [JPG を PNG に変換](https://products.aspose.com/slides/java/conversion/jpg-to-png/), 変換 [PNG を JPG に変換](https://products.aspose.com/slides/java/conversion/png-to-jpg/); 変換 [PNG を SVG に変換](https://products.aspose.com/slides/java/conversion/png-to-svg/), 変換 [SVG を PNG に変換](https://products.aspose.com/slides/java/conversion/svg-to-png/)。 

{{% /alert %}}

Aspose.Slides は、JPEG、PNG、GIF などの一般的な形式の画像操作をサポートしています。 

## **ローカルに保存された画像をスライドに追加**

コンピューター上の1枚または複数の画像をプレゼンテーションのスライドに追加できます。この Java のサンプルコードは、スライドに画像を追加する方法を示しています。
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


## **スライドの背景として画像を追加**

特定のスライドまたは複数のスライドの背景として画像を使用することができます。その場合は、*[スライドの背景として画像を設定](https://docs.aspose.com/slides/java/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **プレゼンテーションに SVG を追加**

任意の画像をプレゼンテーションに追加または挿入するには、[IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) インターフェイスに属する [addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) メソッドを使用できます。 

SVG 画像に基づく画像オブジェクトを作成するには、次の方法があります。 

1. SvgImage オブジェクトを作成し、ImageShapeCollection に挿入する  
2. ISvgImage から PPImage オブジェクトを作成する  
3. IPPImage インターフェイスを使用して PictureFrame オブジェクトを作成する  

このサンプルコードは、上記の手順を実装してプレゼンテーションに SVG 画像を追加する方法を示しています：
```java
// PPTX ファイルを表す Presentation クラスのインスタンス化
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


## **SVG をシェイプの集合に変換**

Aspose.Slides の SVG をシェイプの集合に変換する機能は、SVG 画像を操作するための PowerPoint の機能と似ています：

![PowerPoint Popup Menu](img_01_01.png)

この機能は、[IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) インターフェイスの [addGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) メソッドのオーバーロードの一つで提供され、最初の引数として [ISvgImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgImage) オブジェクトを受け取ります。 

このサンプルコードは、記述されたメソッドを使用して SVG ファイルをシェイプの集合に変換する方法を示しています：
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

    // SVG 画像をスライドサイズに合わせてシェイプのグループに変換
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // プレゼンテーションを PPTX 形式で保存
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **スライドに EMF として画像を追加**

Aspose.Slides for Java を使用すると、Excel シートから EMF 画像を生成し、Aspose.Cells を使用してスライドに EMF として画像を追加できます。 

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


## **画像コレクション内の画像を置き換える**

Aspose.Slides では、プレゼンテーションの画像コレクションに格納された画像（スライドシェイプで使用されているものも含む）を置き換えることができます。このセクションでは、コレクション内の画像を更新するためのいくつかのアプローチを示します。API では、生のバイト データ、[IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) インスタンス、またはコレクションに既に存在する別の画像を使用して画像を置き換える簡単なメソッドが提供されています。 

以下の手順に従ってください: 

1. 画像を含むプレゼンテーション ファイルを [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスを使用してロードします。  
2. ファイルから新しい画像を読み込み、バイト配列に格納します。  
3. バイト配列を使用して対象画像を新しい画像に置き換えます。  
4. 2 番目のアプローチでは、画像を [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) オブジェクトに読み込み、そのオブジェクトで対象画像を置き換えます。  
5. 3 番目のアプローチでは、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置き換えます。  
6. 変更後のプレゼンテーションを PPTX ファイルとして書き出します。 
```java
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化します。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 最初の方法。
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // 2番目の方法。
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // 3番目の方法。
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

**画像を挿入した後も元の解像度はそのままですか？**

はい。元のピクセルは保持されますが、最終的な見た目はスライド上で [picture](/slides/ja/java/picture-frame/) がどのようにスケーリングされるか、保存時に適用される圧縮によって異なります。 

**多数のスライドで同じロゴを一括で置き換える最適な方法は何ですか？**

ロゴをマスタースライドまたはレイアウトに配置し、プレゼンテーションの画像コレクションで置き換えます。これにより、そのリソースを使用しているすべての要素に更新が反映されます。 

**挿入した SVG を編集可能なシェイプに変換できますか？**

はい。SVG をシェイプのグループに変換でき、個々のパーツは標準のシェイプ プロパティで編集可能になります。 

**複数のスライドの背景として画像を一括で設定するにはどうすればよいですか？**

マスタースライドまたは該当レイアウトで [画像を背景として割り当て](/slides/ja/java/presentation-background/) すると、そこを使用しているすべてのスライドが背景を継承します。 

**多数の画像によりプレゼンテーションのサイズが膨らむのを防ぐにはどうすればよいですか？**

重複した画像を使わずに単一の画像リソースを再利用し、適切な解像度を選択し、保存時に圧縮を適用し、必要に応じてマスターに繰り返し使用するグラフィックを配置してください。