---
title: Imagem
type: docs
weight: 50
url: /pt/java/examples/elements/picture/
keywords:
- exemplo de código
- imagem
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Trabalhe com imagens no Aspose.Slides for Java: insira, recorte, compacte, recolor, e exporte imagens com exemplos Java para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como inserir e acessar imagens a partir de imagens em memória usando **Aspose.Slides for Java**. Os exemplos abaixo criam uma imagem na memória, a colocam em um slide e, em seguida, a recuperam.

## **Adicionar uma Imagem**

Este código gera um bitmap pequeno, converte‑o em um fluxo e o insere como um quadro de imagem no primeiro slide.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Crie uma imagem simples em memória.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // Converta o bitmap para um array de bytes.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // Adicione a imagem à apresentação.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // Insira um quadro de imagem exibindo a imagem no primeiro slide.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar uma Imagem**

Este exemplo garante que um slide contenha um quadro de imagem e, em seguida, acessa o primeiro que encontrar.

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