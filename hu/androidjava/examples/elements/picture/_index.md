---
title: Kép
type: docs
weight: 50
url: /hu/androidjava/examples/elements/picture/
keywords:
- kód példa
- kép
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Képekkel való munka az Aspose.Slides for Android-ban: képek beillesztése, vágása, tömörítése, színezése és exportálása Java példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet képeket beilleszteni és elérni a memóriában tárolt képekből az **Aspose.Slides for Android via Java** használatával. Az alábbi példák egy képet hoznak létre a memóriában, elhelyezik egy dián, majd visszakeresik.

## **Kép hozzáadása**

Ez a kód egy kis bitmapet generál, átalakítja azt egy adatfolyammá, és képkockaként helyezi el az első dián.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// Készítsen egy egyszerű memóriában lévő képet.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// Konvertálja a bitmapet bájt tömbbé.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// Adja hozzá a képet a prezentációhoz.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// Helyezzen be egy képkockát, amely az első dián megjeleníti a képet.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **Kép elérése**

Ez a példa biztosítja, hogy egy dián legyen képkocka, majd eléri az első megtalált képkockát.

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