---
title: Bild
type: docs
weight: 50
url: /sv/androidjava/examples/elements/picture/
keywords:
- kodexempel
- bild
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Arbeta med bilder i Aspose.Slides for Android: infoga, beskära, komprimera, färgändra och exportera bilder med Java-exempel för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur man infogar och får åtkomst till bilder från minnesbaserade bilder med **Aspose.Slides for Android via Java**. Exemplen nedan skapar en bild i minnet, placerar den på en bildspelssida och hämtar den sedan.

## **Lägg till en bild**

Den här koden genererar en liten bitmap, konverterar den till en ström och infogar den som en bildram på den första bilden.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// Skapa en enkel bild i minnet.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// Konvertera bitmapen till en bytearray.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// Lägg till bilden i presentationen.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// Infoga en bildram som visar bilden på den första bilden.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **Få åtkomst till en bild**

Detta exempel säkerställer att en bild innehåller en bildram och hämtar sedan den första som den hittar.

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