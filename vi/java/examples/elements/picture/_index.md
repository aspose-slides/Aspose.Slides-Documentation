---
title: Hình Ảnh
type: docs
weight: 50
url: /vi/java/examples/elements/picture/
keywords:
- ví dụ mã
- hình ảnh
- PowerPoint
- OpenDocument
- bản trình bày
- Java
- Aspose.Slides
description: "Làm việc với hình ảnh trong Aspose.Slides cho Java: chèn, cắt, nén, thay đổi màu và xuất ảnh với các ví dụ Java cho các bản trình bày PPT, PPTX và ODP."
---
Bài viết này trình bày cách chèn và truy cập hình ảnh từ các ảnh trong bộ nhớ bằng **Aspose.Slides for Java**. Các ví dụ dưới đây tạo một hình ảnh trong bộ nhớ, đặt nó lên một slide và sau đó truy xuất nó.

## **Thêm một Hình Ảnh**

Mã này tạo một bitmap nhỏ, chuyển nó thành luồng và chèn nó dưới dạng khung hình ảnh trên slide đầu tiên.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Tạo một hình ảnh đơn giản trong bộ nhớ.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // Chuyển đổi bitmap thành mảng byte.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // Thêm hình ảnh vào bản trình bày.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // Chèn khung hình ảnh hiển thị hình trên slide đầu tiên.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập một Hình Ảnh**

Ví dụ này đảm bảo một slide chứa khung hình ảnh và sau đó truy cập vào khung đầu tiên mà nó tìm thấy.

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