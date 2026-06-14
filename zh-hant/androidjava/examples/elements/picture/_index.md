---
title: 圖片
type: docs
weight: 50
url: /zh-hant/androidjava/examples/elements/picture/
keywords:
- 程式碼範例
- 圖片
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 處理圖片：插入、裁切、壓縮、重新著色，並透過 Java 範例匯出 PPT、PPTX 與 ODP 簡報的影像。"
---
本文示範如何使用 **Aspose.Slides for Android via Java** 從記憶體中的圖像插入及存取圖片。以下範例會在記憶體中建立圖像、將其放置於投影片上，然後再取回。

## **加入圖片**

此程式碼會產生小型位圖，將其轉換為串流，並在第一張投影片上插入為圖片框。

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// 建立一個簡單的記憶體影像。
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// 將位圖轉換為位元組陣列。
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// 將影像加入簡報。
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// 在第一張投影片插入顯示影像的圖片框。
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **存取圖片**

此範例會確保投影片包含圖片框，然後存取找到的第一個圖片框。

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