---
title: Obraz
type: docs
weight: 50
url: /pl/androidjava/examples/elements/picture/
keywords:
- przykład kodu
- obraz
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Pracuj z obrazami w Aspose.Slides for Android: wstawiaj, przycinaj, kompresuj, zmieniaj kolory i eksportuj obrazy z przykładami Java dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł pokazuje, jak wstawiać i uzyskiwać dostęp do obrazów z pamięci przy użyciu **Aspose.Slides for Android via Java**. Poniższe przykłady tworzą obraz w pamięci, umieszczają go na slajdzie i następnie go odczytują.

## **Dodaj obraz**

Ten kod generuje mały bitmap, konwertuje go na strumień i wstawia jako ramkę obrazu na pierwszym slajdzie.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// Utwórz prosty obraz w pamięci.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// Konwertuj bitmapę na tablicę bajtów.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// Dodaj obraz do prezentacji.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// Wstaw ramkę obrazu wyświetlającą obraz na pierwszym slajdzie.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **Dostęp do obrazu**

Ten przykład zapewnia, że slajd zawiera ramkę obrazu, a następnie uzyskuje dostęp do pierwszej znalezionej.

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