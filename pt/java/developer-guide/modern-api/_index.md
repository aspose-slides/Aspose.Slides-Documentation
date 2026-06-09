---
title: Aprimorar o Processamento de Imagens com a API Moderna
linktitle: API Moderna
type: docs
weight: 237
url: /pt/java/modern-api/
keywords:
- API moderna
- desenho
- miniatura de slide
- slide para imagem
- miniatura de forma
- forma para imagem
- miniatura de apresentação
- apresentação para imagens
- adicionar imagem
- adicionar foto
- Java
- Aspose.Slides
description: "Modernize o processamento de imagens de slides substituindo as APIs de imagem obsoletas pela API Moderna Java para automação fluida de PowerPoint e OpenDocument."
---
## **Introdução**

Historicamente, o Aspose Slides tem uma dependência de java.awt e possui na API pública as seguintes classes provenientes dela:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

A partir da versão 24.4, essa API pública foi declarada obsoleta.

Para eliminar dependências dessas classes, adicionamos a chamada **API Moderna** – ou seja, a API que deve ser usada em vez da obsoleta, cujas assinaturas contêm dependências de [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) foi declarada obsoleta e seu suporte foi removido da API pública do Slides.

Nas versões atuais, trate a API pública que depende de tipos java.awt como legado/obsoleta. Use a API Moderna para novo código e ao migrar fluxos de trabalho existentes de processamento de imagens.

## **API Moderna**

Foram adicionadas as seguintes classes e enums à API pública:

- [IImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iimage/) – representa a imagem raster ou vetorial.
- [ImageFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imageformat/) – representa o formato de arquivo da imagem.
- [Images](https://reference.aspose.com/slides/pt/java/com.aspose.slides/images/) – métodos para instanciar e trabalhar com a interface [IImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iimage/).

Observe que [IImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iimage/) é descartável e seu uso deve ser seguido por uma chamada `dispose()` ou outro padrão conveniente de descarte.

Use `getImage` para renderizar um único slide ou forma. Use `getImages` para renderizar vários slides de apresentação. Use os métodos de [Images](https://reference.aspose.com/slides/pt/java/com.aspose.slides/images/) para carregar imagens, `addImage` com [IImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iimage/) para adicioná‑las a uma apresentação e `replaceImage` com [IImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iimage/) para atualizar uma imagem existente da apresentação.

Um cenário típico de uso da nova API pode ser o seguinte:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // instanciar uma instância descartável de IImage a partir do arquivo no disco.
    IImage image = Images.fromFile("image.png");
    try {
        // criar uma imagem PowerPoint adicionando uma instância de IImage às imagens da apresentação.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // adicionar uma forma de imagem no slide #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // obter uma instância de IImage que representa o slide #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // salvar a imagem no disco.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Substituindo Código Antigo pela API Moderna**

Em geral, você precisará substituir chamadas que usam [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) e ImageIO pelos novos métodos que utilizam [IImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iimage/).

API legada/obsoleta:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
API Moderna:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **Obtendo uma Miniatura de Slide**

API legada/obsoleta:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail();
    try {
        ImageIO.write(slideImage, "PNG", new File("slide1.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

API Moderna:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage();
    try {
        slideImage.save("slide1.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obtendo uma Miniatura de Forma**

API legada/obsoleta:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    try {
        ImageIO.write(shapeImage, "PNG", new File("shape.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

API Moderna:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    try {
        shapeImage.save("shape.png");
    } finally {
        if (shapeImage != null) shapeImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obtendo uma Miniatura de Apresentação**

API legada/obsoleta:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Dimension(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        try 
        {
            BufferedImage thumbnail = bitmaps[index];
            ImageIO.write(thumbnail, "PNG", new File("slide" + index + ".png"));
        } 
        catch (IOException e) 
        {
            e.printStackTrace();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

API Moderna:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage[] images = pres.getImages(new RenderingOptions(), new Dimension(1980, 1028));
    try
    {
        for (int index = 0; index < images.length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", ImageFormat.Png);
        }
    }
    finally
    {
        for (IImage image : images)
        {
            image.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Adicionando uma Imagem a uma Apresentação**

API legada/obsoleta:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    try {
        BufferedImage bufferedImages = ImageIO.read(new File("image.png"));
        ppImage = pres.getImages().addImage(bufferedImages);
    } catch (IOException e) {
        e.printStackTrace();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

API Moderna:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    IImage image = Images.fromFile("image.png");
    try {
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Métodos Obsoletos e Suas Substituições na API Moderna**

### **Presentation**
| Assinatura do Método | Assinatura do Método de Substituição |
|----------------------|--------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Assinatura do Método | Assinatura do Método de Substituição |
|----------------------|--------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Assinatura do Método | Assinatura do Método de Substituição |
|----------------------|--------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement |

### **Output**
| Assinatura do Método | Assinatura do Método de Substituição |
|----------------------|--------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Assinatura do Método | Assinatura do Método de Substituição |
|----------------------|--------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Assinatura do Método | Assinatura do Método de Substituição |
|----------------------|--------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Assinatura do Método | Assinatura do Método de Substituição |
|----------------------|--------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Assinatura do Método | Assinatura do Método de Substituição |
|----------------------|--------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Suporte de API para Graphics2D**

Métodos com [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) são declarados obsoletos e não possuem substituição direta na API Moderna.

Use os métodos de renderização de imagem da API Moderna em vez da API que renderiza para [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **Perguntas Frequentes**

**Por que o [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) foi removido?**

O suporte ao [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) foi tornado obsoleto na API pública para unificar o trabalho com renderização e imagens, eliminar vínculos com dependências específicas da plataforma e migrar para uma abordagem multiplataforma com [IImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iimage/). Use `getImage` ou `getImages` em vez de renderizar para [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Qual é o benefício prático do [IImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iimage/) em comparação ao [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iimage/) unifica o trabalho com imagens raster e vetoriais e simplifica a gravação em vários formatos por meio de [ImageFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imageformat/).

**A API Moderna afetará o desempenho da geração de miniaturas?**

A troca de `getThumbnail` por `getImage` não piora os cenários: os novos métodos fornecem as mesmas capacidades para produzir imagens com opções e tamanhos, mantendo o suporte a opções de renderização. O ganho ou perda específico depende do cenário, mas funcionalmente as substituições são equivalentes.