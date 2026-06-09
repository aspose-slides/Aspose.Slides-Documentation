---
title: Resim
type: docs
weight: 50
url: /tr/androidjava/examples/elements/picture/
keywords:
- kod örneği
- resim
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'de resimlerle çalışın: ekleyin, kırpın, sıkıştırın, renk değiştirin ve PPT, PPTX ve ODP sunumları için Java örnekleriyle görüntüleri dışa aktarın."
---
Bu makale, **Aspose.Slides for Android via Java** kullanarak bellek içi görüntülerden resim ekleme ve erişme yöntemlerini gösterir. Aşağıdaki örnekler bir resmi bellekte oluşturur, bir slayta yerleştirir ve ardından alır.

## **Resim Ekle**

Bu kod küçük bir bitmap oluşturur, akışa dönüştürür ve ilk slaytta bir resim çerçevesi olarak ekler.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// Basit bir bellek içi görüntü oluştur.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// Bitmap'i bayt dizisine dönüştür.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// Görüntüyü sunuma ekle.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// İlk slaytta görüntüyü gösteren bir resim çerçevesi ekle.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **Resme Eriş**

Bu örnek bir slaytta resim çerçevesi bulunduğunu doğrular ve ardından bulduğu ilk resme erişir.

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