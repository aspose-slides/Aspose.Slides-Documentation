---
title: تصویر
type: docs
weight: 50
url: /fa/java/examples/elements/picture/
keywords:
- مثال کد
- تصویر
- پاورپوینت
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "کار با تصاویر در Aspose.Slides for Java: درج، برش، فشرده‌سازی، تغییر رنگ و استخراج تصاویر با مثال‌های Java برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد که چگونه می‌توان تصاویر را از تصاویر درون حافظه وارد و به آن‌ها دسترسی پیدا کرد با استفاده از **Aspose.Slides for Java**. مثال‌های زیر یک تصویر را در حافظه ایجاد می‌کنند، آن را روی یک اسلاید قرار می‌دهند و سپس بازیابی می‌کنند.

## **افزودن تصویر**

این کد یک بیت‌مپ کوچک ایجاد می‌کند، آن را به یک جریان تبدیل می‌کند و به عنوان یک قاب تصویر در اولین اسلاید درج می‌نماید.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // یک تصویر ساده در حافظه ایجاد می‌کند.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // تبدیل بیت‌مپ به آرایه بایت.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // افزودن تصویر به ارائه.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // درج یک قاب تصویر که تصویر را در اولین اسلاید نمایش می‌دهد.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به تصویر**

این مثال اطمینان می‌دهد که یک اسلاید شامل یک قاب تصویر است و سپس به اولین قاب موجود دسترسی پیدا می‌کند.

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