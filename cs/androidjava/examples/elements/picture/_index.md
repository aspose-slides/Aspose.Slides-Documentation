---
title: Obrázek
type: docs
weight: 50
url: /cs/androidjava/examples/elements/picture/
keywords:
- ukázka kódu
- obrázek
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Práce s obrázky v Aspose.Slides pro Android: vkládání, ořezávání, komprese, změna barev a export obrázků s příklady v jazyce Java pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak vložit a získat obrázky z paměťových obrazů pomocí **Aspose.Slides for Android via Java**. Níže uvedené příklady vytvoří obrázek v paměti, umístí jej na snímek a poté jej načtou.

## **Přidat obrázek**

Tento kód vygeneruje malý bitmapový soubor, převede jej na proud a vloží jej jako rámeček obrázku na první snímek.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// Vytvořte jednoduchý obrázek v paměti.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// Převod bitmapy na pole bajtů.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// Přidejte obrázek do prezentace.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// Vložte rámeček obrázku zobrazující obrázek na první snímek.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **Přístup k obrázku**

Tento příklad zajistí, že snímek obsahuje rámeček obrázku, a poté získá první nalezený.

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