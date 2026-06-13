---
title: تصویر
type: docs
weight: 50
url: /fa/androidjava/examples/elements/picture/
keywords:
- مثال کد
- تصویر
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "کار با تصاویر در Aspose.Slides برای Android: درج، برش، فشرده‌سازی، تغییر رنگ و خروجی گرفتن تصاویر با مثال‌های جاوا برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نحوه درج و دسترسی به تصاویر از تصاویر حافظه‌موقت را با استفاده از **Aspose.Slides for Android via Java** نشان می‌دهد. مثال‌های زیر یک تصویر را در حافظه ایجاد می‌کنند، آن را روی یک اسلاید قرار می‌دهند و سپس بازیابی می‌کنند.

## **افزودن تصویر**

این کد یک بیت‌مپ کوچک تولید می‌کند، آن را به یک جریان تبدیل می‌سازد و به عنوان یک قاب تصویر در اسلاید اول درج می‌کند.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// یک تصویر ساده در حافظه ایجاد کنید.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// بیت‌مپ را به آرایه بایت تبدیل کنید.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// تصویر را به ارائه اضافه کنید.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// یک قاب تصویر که تصویر را در اسلاید اول نشان می‌دهد درج کنید.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **دسترسی به تصویر**

این مثال اطمینان می‌یابد که یک اسلاید شامل یک قاب تصویر است و سپس اولین قاب موجود را دسترسی می‌یابد.

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