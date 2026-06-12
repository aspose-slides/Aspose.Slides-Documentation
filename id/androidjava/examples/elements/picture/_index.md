---
title: Gambar
type: docs
weight: 50
url: /id/androidjava/examples/elements/picture/
keywords:
- contoh kode
- gambar
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Bekerja dengan gambar di Aspose.Slides for Android: menyisipkan, memotong, mengompres, mengubah warna, dan mengekspor gambar dengan contoh Java untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menyisipkan dan mengakses gambar dari gambar dalam memori menggunakan **Aspose.Slides for Android via Java**. Contoh di bawah membuat gambar dalam memori, menempatkannya pada slide, dan kemudian mengambilnya.

## **Menambahkan Gambar**

Kode ini menghasilkan bitmap kecil, mengubahnya menjadi aliran, dan menyisipkannya sebagai bingkai gambar pada slide pertama.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// Membuat gambar dalam memori yang sederhana.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// Mengonversi bitmap menjadi array byte.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// Menambahkan gambar ke presentasi.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// Menyisipkan bingkai gambar yang menampilkan gambar pada slide pertama.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **Mengakses Gambar**

Contoh ini memastikan sebuah slide berisi bingkai gambar dan kemudian mengakses yang pertama yang ditemukan.

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