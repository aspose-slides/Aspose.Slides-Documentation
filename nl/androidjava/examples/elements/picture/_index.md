---
title: Afbeelding
type: docs
weight: 50
url: /nl/androidjava/examples/elements/picture/
keywords:
- codevoorbeeld
- afbeelding
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Werk met afbeeldingen in Aspose.Slides voor Android: voeg in, bijsnijden, comprimeren, herkleuren en exporteer afbeeldingen met Java-voorbeelden voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel laat zien hoe je afbeeldingen van in‑memory‑beelden kunt invoegen en benaderen met **Aspose.Slides for Android via Java**. De onderstaande voorbeelden maken een afbeelding in het geheugen, plaatsen deze op een dia en halen hem vervolgens op.

## **Afbeelding toevoegen**

Deze code genereert een kleine bitmap, zet deze om naar een stream en voegt hem als een afbeeldingsframe toe op de eerste dia.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// Maak een eenvoudige in-memory-afbeelding.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// Converteer de bitmap naar een byte-array.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// Voeg de afbeelding toe aan de presentatie.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// Voeg een afbeeldingframe in dat de afbeelding weergeeft op de eerste dia.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **Afbeelding benaderen**

Dit voorbeeld zorgt ervoor dat een dia een afbeeldingsframe bevat en benadert vervolgens het eerste dat gevonden wordt.

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