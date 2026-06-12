---
title: Immagine
type: docs
weight: 50
url: /it/java/examples/elements/picture/
keywords:
- esempio di codice
- immagine
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Lavora con le immagini in Aspose.Slides per Java: inserisci, ritaglia, comprimi, cambia colore ed esporta le immagini con esempi Java per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come inserire e accedere alle immagini da immagini in memoria utilizzando **Aspose.Slides for Java**. Gli esempi seguenti creano un'immagine in memoria, la posizionano su una diapositiva e poi la recuperano.

## **Aggiungi un'immagine**

Questo codice genera un piccolo bitmap, lo converte in un flusso e lo inserisce come riquadro immagine nella prima diapositiva.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Crea un'immagine semplice in memoria.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // Converti il bitmap in un array di byte.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // Aggiungi l'immagine alla presentazione.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // Inserisci un riquadro immagine che mostra l'immagine nella prima diapositiva.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accedi a un'immagine**

Questo esempio verifica che una diapositiva contenga un riquadro immagine e poi accede al primo che trova.

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