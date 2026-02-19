---
title: صورة
type: docs
weight: 50
url: /ar/androidjava/examples/elements/picture/
keywords:
- مثال على شفرة
- صورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "العمل مع الصور في Aspose.Slides for Android: إدراج، قص، ضغط، إعادة تلوين، وتصدير الصور مع أمثلة Java لعروض PPT و PPTX و ODP."
---
توضح هذه المقالة كيفية إدراج والوصول إلى الصور من الصور المخزنة في الذاكرة باستخدام **Aspose.Slides for Android via Java**. تُنشئ الأمثلة أدناه صورة في الذاكرة، وتضعها في شريحة، ثم تسترجعها.

## **إضافة صورة**

يقوم هذا الكود بإنشاء bitmap صغير، يحوله إلى تدفق، ويُدرجه كإطار صورة في الشريحة الأولى.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// إنشاء صورة بسيطة في الذاكرة.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// تحويل الـ bitmap إلى مصفوفة بايت.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// إضافة الصورة إلى العرض التقديمي.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// إدراج إطار صورة يعرض الصورة في الشريحة الأولى.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **الوصول إلى صورة**

يتأكد هذا المثال من أن الشريحة تحتوي على إطار صورة ثم يصل إلى أول إطار يجدّه.

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