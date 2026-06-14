---
title: Hình ảnh
type: docs
weight: 50
url: /vi/androidjava/examples/elements/picture/
keywords:
- ví dụ mã
- hình ảnh
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Làm việc với hình ảnh trong Aspose.Slides cho Android: chèn, cắt, nén, thay đổi màu và xuất hình ảnh với các ví dụ Java cho các bài thuyết trình PPT, PPTX và ODP."
---
Bài viết này trình bày cách chèn và truy cập hình ảnh từ các hình ảnh trong bộ nhớ sử dụng **Aspose.Slides for Android via Java**. Các ví dụ dưới đây tạo một hình ảnh trong bộ nhớ, đặt nó lên một slide, và sau đó truy xuất nó.

## **Thêm hình ảnh**

Đoạn mã này tạo một bitmap nhỏ, chuyển nó thành luồng và chèn nó dưới dạng khung hình ảnh trên slide đầu tiên.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// Tạo một hình ảnh đơn giản trong bộ nhớ.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// Chuyển đổi bitmap sang mảng byte.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// Thêm hình ảnh vào bản trình bày.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// Chèn khung hình ảnh hiển thị hình ảnh trên slide đầu tiên.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **Truy cập hình ảnh**

Ví dụ này đảm bảo một slide chứa khung hình ảnh và sau đó truy cập vào khung đầu tiên được tìm thấy.

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