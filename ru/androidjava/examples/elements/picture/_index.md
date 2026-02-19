---
title: Изображение
type: docs
weight: 50
url: /ru/androidjava/examples/elements/picture/
keywords:
- пример кода
- изображение
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Работа с изображениями в Aspose.Slides for Android: вставка, обрезка, сжатие, изменение цвета и экспорт изображений с примерами на Java для презентаций PPT, PPTX и ODP."
---
В этой статье демонстрируется, как вставлять и получать доступ к изображениям из памяти, используя **Aspose.Slides for Android via Java**. Приведённые ниже примеры создают изображение в памяти, размещают его на слайде и затем извлекают его.

## **Добавить изображение**

Этот код генерирует маленький bitmap, преобразует его в поток и вставляет в виде рамки изображения на первый слайд.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// Создайте простое изображение в памяти.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// Преобразуйте bitmap в массив байтов.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// Добавьте изображение в презентацию.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// Вставьте рамку изображения, отображающую картинку, на первый слайд.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **Доступ к изображению**

В этом примере проверяется, что слайд содержит рамку изображения, а затем происходит доступ к первой найденной.

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