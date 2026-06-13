---
title: รูปภาพ
type: docs
weight: 50
url: /th/java/examples/elements/picture/
keywords:
- ตัวอย่างโค้ด
- รูปภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ทำงานกับรูปภาพใน Aspose.Slides for Java: แทรก, ครอบ, บีบอัด, ปรับสีใหม่, และส่งออกภาพด้วยตัวอย่าง Java สำหรับการนำเสนอ PPT, PPTX, และ ODP."
---
บทความนี้แสดงวิธีแทรกและเข้าถึงรูปภาพจากรูปภาพในหน่วยความจำโดยใช้ **Aspose.Slides for Java** ตัวอย่างด้านล่างสร้างภาพในหน่วยความจำ วางบนสไลด์ และจากนั้นดึงคืนมา

## **เพิ่มรูปภาพ**

โค้ดนี้สร้างบิทแมปขนาดเล็ก แปลงเป็นสตรีม และแทรกเป็นเฟรมรูปภาพบนสไลด์แรก

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // สร้างภาพในหน่วยความจำแบบง่าย.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // แปลงบิทแมปเป็นอาเรย์ไบต์.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // เพิ่มภาพลงในงานนำเสนอ.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // แทรกกรอบรูปภาพที่แสดงภาพบนสไลด์แรก.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงรูปภาพ**

ตัวอย่างนี้ตรวจสอบให้แน่ใจว่าสไลด์มีเฟรมรูปภาพ และจากนั้นเข้าถึงเฟรมแรกที่พบ

```java
public static void accessPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        BufferedImage bitmap = new BufferedImage(40, 40, BufferedImage.TYPE_INT_ARGB);
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
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