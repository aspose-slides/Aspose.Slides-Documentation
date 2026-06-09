---
title: Εικόνα
type: docs
weight: 50
url: /el/androidjava/examples/elements/picture/
keywords:
- παράδειγμα κώδικα
- εικόνα
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Εργασία με εικόνες στο Aspose.Slides για Android: εισαγωγή, περικοπή, συμπίεση, αλλαγή χρώματος και εξαγωγή εικόνων με παραδείγματα Java για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να εισάγετε και να αποκτήσετε πρόσβαση σε εικόνες από εικόνες στη μνήμη χρησιμοποιώντας **Aspose.Slides for Android via Java**. Τα παραδείγματα παρακάτω δημιουργούν μια εικόνα στη μνήμη, την τοποθετούν σε μια διαφάνεια και στη συνέχεια την ανακτούν.

## **Προσθήκη Εικόνας**

Αυτός ο κώδικας δημιουργεί ένα μικρό bitmap, το μετατρέπει σε ροή και το εισάγει ως πλαίσιο εικόνας στην πρώτη διαφάνεια.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// Δημιουργείστε μια απλή εικόνα στη μνήμη.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// Μετατρέπει το bitmap σε πίνακα byte.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// Προσθέτει την εικόνα στην παρουσίαση.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// Εισάγει ένα πλαίσιο εικόνας που εμφανίζει την εικόνα στην πρώτη διαφάνεια.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **Πρόσβαση σε εικόνα**

Αυτό το παράδειγμα διασφαλίζει ότι μια διαφάνεια περιέχει πλαίσιο εικόνας και στη συνέχεια προσπελάζει το πρώτο που βρίσκει.

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