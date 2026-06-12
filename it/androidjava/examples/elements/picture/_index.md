---
title: Immagine
type: docs
weight: 50
url: /it/androidjava/examples/elements/picture/
keywords:
- esempio di codice
- immagine
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Lavora con le immagini in Aspose.Slides per Android: inserisci, ritaglia, comprimi, cambia colore ed esporta le immagini con esempi Java per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come inserire e accedere alle immagini da immagini in memoria usando **Aspose.Slides for Android via Java**. Gli esempi seguenti creano un'immagine in memoria, la posizionano su una diapositiva e poi la recuperano.

## **Aggiungi un'immagine**

Questo codice genera un piccolo bitmap, lo converte in uno stream e lo inserisce come fotogramma immagine sulla prima diapositiva.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// Crea un'immagine semplice in memoria.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// Converti il bitmap in un array di byte.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// Aggiungi l'immagine alla presentazione.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// Inserisci un fotogramma immagine che mostra l'immagine nella prima diapositiva.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **Accedi a un'immagine**

Questo esempio garantisce che una diapositiva contenga un fotogramma immagine e quindi accede al primo che trova.

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