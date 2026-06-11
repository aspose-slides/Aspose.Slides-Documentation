---
title: Obraz
type: docs
weight: 50
url: /pl/java/examples/elements/picture/
keywords:
- przykład kodu
- obraz
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Pracuj z obrazami w Aspose.Slides for Java: wstawiaj, przycinaj, kompresuj, zmieniaj kolory i eksportuj obrazy przy użyciu przykładów Java dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł demonstruje, jak wstawiać i uzyskiwać dostęp do obrazów z pamięci przy użyciu **Aspose.Slides for Java**. Poniższe przykłady tworzą obraz w pamięci, umieszczają go na slajdzie, a następnie go pobierają.

## **Dodaj obraz**
Ten kod generuje mały bitmap, konwertuje go do strumienia i wstawia jako ramkę obrazu na pierwszym slajdzie.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Utwórz prosty obraz w pamięci.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // Konwertuj bitmapę na tablicę bajtów.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // Dodaj obraz do prezentacji.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // Wstaw ramkę obrazu wyświetlającą obraz na pierwszym slajdzie.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Uzyskaj dostęp do obrazu**
Ten przykład zapewnia, że slajd zawiera ramkę obrazu, a następnie uzyskuje dostęp do pierwszej, którą znajdzie.

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