---
title: Image
type: docs
weight: 50
url: /fr/java/examples/elements/picture/
keywords:
- exemple de code
- image
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Travailler avec les images dans Aspose.Slides for Java : insérer, recadrer, compresser, recolorer et exporter des images avec des exemples Java pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment insérer et accéder à des images à partir d'images en mémoire en utilisant **Aspose.Slides for Java**. Les exemples ci-dessous créent une image en mémoire, la placent sur une diapositive, puis la récupèrent.

## **Ajouter une image**
Ce code génère une petite bitmap, la convertit en flux et l'insère comme cadre d'image sur la première diapositive.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Créer une image simple en mémoire.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // Convertir le bitmap en tableau d'octets.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // Ajouter l'image à la présentation.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // Insérer un cadre d'image affichant l'image sur la première diapositive.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à une image**
Cet exemple vérifie qu'une diapositive contient un cadre d'image, puis accède au premier trouvé.

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