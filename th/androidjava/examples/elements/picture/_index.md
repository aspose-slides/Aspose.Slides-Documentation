---
title: รูปภาพ
type: docs
weight: 50
url: /th/androidjava/examples/elements/picture/
keywords:
- ตัวอย่างโค้ด
- รูปภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ทำงานกับรูปภาพใน Aspose.Slides for Android: แทรก, ครอบ, บีบอัด, ปรับสีใหม่, และส่งออกภาพด้วยตัวอย่าง Java สำหรับงานนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีแทรกและเข้าถึงรูปภาพจากภาพในหน่วยความจำโดยใช้ **Aspose.Slides for Android via Java** ตัวอย่างด้านล่างสร้างภาพในหน่วยความจำ วางลงบนสไลด์ แล้วดึงกลับมา

## **เพิ่มรูปภาพ**

โค้ดนี้สร้างบิตแมปขนาดเล็ก แปลงเป็นสตรีม และแทรกเป็นกรอบรูปบนสไลด์แรก.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// สร้างภาพง่ายในหน่วยความจำ.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// แปลงบิตแมปเป็นอาร์เรย์ของไบต์.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// เพิ่มภาพลงในงานนำเสนอ.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// แทรกกรอบรูปที่แสดงภาพบนสไลด์แรก.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **เข้าถึงรูปภาพ**

ตัวอย่างนี้ตรวจสอบให้แน่ใจว่าสไลด์มีกรอบรูปแล้วเข้าถึงกรอบรูปแรกที่พบ.

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