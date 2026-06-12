---
title: Gambar
type: docs
weight: 50
url: /id/java/examples/elements/picture/
keywords:
- contoh kode
- gambar
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Bekerja dengan gambar di Aspose.Slides for Java: menyisipkan, memotong, mengompresi, mengubah warna, dan mengekspor gambar dengan contoh Java untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menyisipkan dan mengakses gambar dari gambar dalam memori menggunakan **Aspose.Slides for Java**. Contoh di bawah ini membuat gambar dalam memori, menempatkannya pada slide, dan kemudian mengambilnya.

## **Tambahkan Gambar**

Kode ini menghasilkan bitmap kecil, mengubahnya menjadi aliran, dan menyisipkannya sebagai bingkai gambar pada slide pertama.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Buat gambar sederhana dalam memori.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // Ubah bitmap menjadi array byte.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // Tambahkan gambar ke presentasi.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // Sisipkan bingkai gambar yang menampilkan gambar pada slide pertama.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Akses Gambar**

Contoh ini memastikan slide berisi bingkai gambar dan kemudian mengakses yang pertama ditemukan.

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