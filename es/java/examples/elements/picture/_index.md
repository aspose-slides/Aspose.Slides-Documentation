---
title: Imagen
type: docs
weight: 50
url: /es/java/examples/elements/picture/
keywords:
- ejemplo de código
- imagen
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Trabaje con imágenes en Aspose.Slides for Java: inserte, recorte, comprima, recoloree y exporte imágenes con ejemplos en Java para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo insertar y acceder a imágenes desde imágenes en memoria usando **Aspose.Slides for Java**. Los ejemplos a continuación crean una imagen en memoria, la colocan en una diapositiva y luego la recuperan.

## **Añadir una imagen**

Este código genera un pequeño mapa de bits, lo convierte en un flujo y lo inserta como un marco de imagen en la primera diapositiva.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Crear una imagen sencilla en memoria.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // Convertir el mapa de bits a un array de bytes.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // Añadir la imagen a la presentación.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // Insertar un marco de imagen que muestra la imagen en la primera diapositiva.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a una imagen**

Este ejemplo garantiza que una diapositiva contenga un marco de imagen y luego accede al primero que encuentra.

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