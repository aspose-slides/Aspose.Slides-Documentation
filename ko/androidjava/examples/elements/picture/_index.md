---
title: 그림
type: docs
weight: 50
url: /ko/androidjava/examples/elements/picture/
keywords:
- 코드 예제
- 그림
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android에서 그림을 다루는 방법: 삽입, 자르기, 압축, 색상 변경 및 이미지 내보내기를 Java 예제로 PPT, PPTX 및 ODP 프레젠테이션에 대해 제공합니다."
---
이 문서는 **Aspose.Slides for Android via Java**를 사용하여 메모리 내 이미지에서 사진을 삽입하고 액세스하는 방법을 보여줍니다. 아래 예제는 메모리에서 이미지를 생성하고, 슬라이드에 배치한 다음 검색합니다.

## **그림 추가**

이 코드는 작은 비트맵을 생성하고, 스트림으로 변환한 뒤 첫 번째 슬라이드에 그림 프레임으로 삽입합니다.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// 간단한 메모리 내 이미지를 생성합니다.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// 비트맵을 바이트 배열로 변환합니다.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// 프레젠테이션에 이미지를 추가합니다.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// 첫 번째 슬라이드에 이미지를 표시하는 그림 프레임을 삽입합니다.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **그림 액세스**

이 예제는 슬라이드에 그림 프레임이 포함되어 있는지 확인한 다음, 찾은 첫 번째 프레임에 액세스합니다.

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