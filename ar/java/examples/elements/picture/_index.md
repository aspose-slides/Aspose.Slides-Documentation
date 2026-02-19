---
title: صورة
type: docs
weight: 50
url: /ar/java/examples/elements/picture/
keywords:
- مثال على الشيفرة
- صورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "العمل مع الصور في Aspose.Slides for Java: إدراج، قص، ضغط، تعديل اللون، وتصدير الصور مع أمثلة Java لعروض PPT و PPTX و ODP."
---
هذا المقال يوضح كيفية إدراج الصور والوصول إليها من الصور المخزنة في الذاكرة باستخدام **Aspose.Slides for Java**. الأمثلة أدناه تنشئ صورة في الذاكرة، تضعها على شريحة، ثم تسترجعها.

## **إضافة صورة**

يقوم هذا الكود بإنشاء صورة نقطية صغيرة، يحولها إلى تدفق، ويُدرجها كإطار صورة على الشريحة الأولى.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // إنشاء صورة بسيطة في الذاكرة.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // تحويل الصورة النقطية إلى مصفوفة بايت.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // إضافة الصورة إلى العرض التقديمي.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // إدراج إطار صورة يُظهر الصورة على الشريحة الأولى.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى صورة**

هذا المثال يضمن أن الشريحة تحتوي على إطار صورة ثم يصل إلى الأول الذي يجده.

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