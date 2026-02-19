---
title: 画像
type: docs
weight: 50
url: /ja/androidjava/examples/elements/picture/
keywords:
- コード例
- 画像
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android で画像を操作します。画像の挿入、切り取り、圧縮、色調整、エクスポートを、PPT、PPTX、ODP プレゼンテーション向けの Java サンプルとともに行います。"
---
この記事では、**Aspose.Slides for Android via Java** を使用して、メモリ内画像から画像を挿入および取得する方法を示します。以下の例では、メモリ内に画像を作成し、スライドに配置し、取得します。

## **Add a Picture**
このコードは小さなビットマップを生成し、ストリームに変換して、最初のスライドに画像フレームとして挿入します。

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// シンプルなインメモリ画像を作成します。
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// ビットマップをバイト配列に変換します。
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// 画像をプレゼンテーションに追加します。
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// 最初のスライドに画像を表示する画像フレームを挿入します。
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **Access a Picture**
この例では、スライドに画像フレームが含まれていることを確認し、最初に見つかった画像フレームにアクセスします。

```java
public static void accessPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

		IPictureFrame pictureFrame = null;
		for (IShape shape : slide.getShapes()) {
			if (shape instanceof IPictureFrame) {
				pictureFrame = (IPictureFrame) shape;
				break;
			}
		}
	} finally {
		presentation.dispose();
	}
}
```