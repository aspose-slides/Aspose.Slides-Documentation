---
title: Image
type: docs
weight: 50
url: /fr/androidjava/examples/elements/picture/
keywords:
- exemple de code
- image
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Travaillez avec les images dans Aspose.Slides pour Android : insérez, recadrez, compressez, recolorez et exportez des images avec des exemples Java pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment insérer et accéder aux images à partir d'images en mémoire en utilisant **Aspose.Slides for Android via Java**. Les exemples ci-dessous créent une image en mémoire, la placent sur une diapositive, puis la récupèrent.

## **Ajouter une image**

Ce code génère un petit bitmap, le convertit en flux et l'insère comme cadre d'image sur la première diapositive.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// Créez une image simple en mémoire.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// Convertit le bitmap en tableau d'octets.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// Ajoute l'image à la présentation.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// Insère un cadre d'image affichant l'image sur la première diapositive.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **Accéder à une image**

Cet exemple vérifie qu'une diapositive contient un cadre d'image puis accède au premier qu'il trouve.

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