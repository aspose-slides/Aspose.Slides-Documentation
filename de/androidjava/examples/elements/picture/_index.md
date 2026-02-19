---
title: Bild
type: docs
weight: 50
url: /de/androidjava/examples/elements/picture/
keywords:
- Codebeispiel
- Bild
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Arbeiten Sie mit Bildern in Aspose.Slides für Android: Einfügen, Zuschneiden, Komprimieren, Umfärben und Exportieren von Bildern mit Java-Beispielen für PPT, PPTX und ODP-Präsentationen."
---
Dieser Artikel zeigt, wie man Bilder aus im Speicher befindlichen Bildern einfügt und darauf zugreift, wobei **Aspose.Slides for Android via Java** verwendet wird. Die nachfolgenden Beispiele erstellen ein Bild im Speicher, platzieren es auf einer Folie und rufen es anschließend ab.

## **Bild hinzufügen**

Dieser Code erzeugt ein kleines Bitmap, konvertiert es in einen Stream und fügt es als Bildrahmen auf der ersten Folie ein.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// Ein einfaches In-Memory-Bild erstellen.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// Das Bitmap in ein Byte-Array konvertieren.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// Bild zur Präsentation hinzufügen.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// Einen Bildrahmen einfügen, der das Bild auf der ersten Folie anzeigt.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **Bild abrufen**

Dieses Beispiel stellt sicher, dass eine Folie einen Bildrahmen enthält, und greift dann auf den ersten zu, den es findet.

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