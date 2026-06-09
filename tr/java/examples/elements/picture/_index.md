---
title: Resim
type: docs
weight: 50
url: /tr/java/examples/elements/picture/
keywords:
- kod örneği
- resim
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da resimlerle çalışın: ekleme, kırpma, sıkıştırma, renk değiştirme ve PPT, PPTX ve ODP sunumları için Java örnekleriyle görüntüleri dışa aktarma."
---
Bu makale, **Aspose.Slides for Java** kullanarak bellekteki görüntülerden resim ekleme ve erişme işlemlerini göstermektedir. Aşağıdaki örnekler bir görüntüyü bellek içinde oluşturur, bir slayta yerleştirir ve ardından onu alır.

## **Resim Ekle**

Bu kod küçük bir bitmap oluşturur, bunu bir akışa dönüştürür ve ilk slaytta bir resim çerçevesi olarak ekler.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Basit bir bellek içi görüntü oluştur.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // Bitmap'i bayt dizisine dönüştür.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // Görüntüyü sunuma ekle.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // Görüntüyü gösteren bir resim çerçevesini ilk slayta ekle.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Resme Erişim**

Bu örnek, bir slaydın bir resim çerçevesi içerdiğini garantiler ve ardından bulunan ilk çerçeveye erişir.

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