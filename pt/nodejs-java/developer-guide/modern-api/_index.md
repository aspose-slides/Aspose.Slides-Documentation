---
title: Aprimorar o Processamento de Imagens com a API Moderna
linktitle: API Moderna
type: docs
weight: 237
url: /pt/nodejs-java/modern-api/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Modernize o processamento de imagens de slides substituindo APIs de imagem obsoletas pela API Moderna JavaScript para automação perfeita de PowerPoint e OpenDocument."
---
## **Introdução**

Historicamente, o Aspose Slides tem uma dependência de **java.awt** e possui na API pública as seguintes classes provenientes dela:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

A partir da versão 24.4, essa API pública foi declarada obsoleta.

Para eliminar as dependências dessas classes, adicionamos a chamada “API Moderna” — ou seja, a API que deve ser usada em vez da obsoleta, cujas assinaturas contêm dependências de [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) foi declarada obsoleta e seu suporte foi removido da API pública do Slides.

Nas versões atuais, trate a API pública que depende de tipos **java.awt** como legada/obsoleta. Use a API Moderna para novo código e ao migrar fluxos de processamento de imagens existentes.

## **API Moderna**

Foram adicionadas as seguintes classes e enumerações à API pública:

- [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/) - representa a imagem raster ou vetor.  
- [ImageFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imageformat/) - representa o formato de arquivo da imagem.  
- [Images](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/images/) - métodos para instanciar e trabalhar com a classe [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/).

Observe que [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/) é descartável e seu uso deve ser seguido por uma chamada a `dispose()` ou outro padrão de descarte conveniente.

Use `getImage` para renderizar um único slide ou forma. Use `getImages` para renderizar vários slides de apresentação. Use os métodos de [Images](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/images/) para carregar imagens, `addImage` com [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/) para adicioná‑las a uma apresentação e `replaceImage` com [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/) para atualizar uma imagem existente da apresentação.

Um cenário típico de uso da nova API pode ser o seguinte:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // instanciar uma instância descartável de IImage a partir do arquivo no disco.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // criar uma imagem PowerPoint adicionando uma instância de IImage às imagens da apresentação.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // adicionar uma forma de imagem no slide #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // obter uma instância de IImage que representa o slide #1.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // salvar a imagem no disco.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Substituindo Código Antigo pela API Moderna**

De modo geral, será necessário substituir chamadas que utilizam [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) e [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) pelos novos métodos que utilizam [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/).

API Legada/obsoleta:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
API Moderna:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **Obtendo uma Miniatura de Slide**

API Legada/obsoleta:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "slide1.png");
    imageio.write(slideImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

API Moderna:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getImage();
    slideImage.save("slide1.png", aspose.slides.ImageFormat.Png);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obtendo uma Miniatura de Forma**

API Legada/obsoleta:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "shape.png");
    imageio.write(shapeImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

API Moderna:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    shapeImage.save("shape.png");
    shapeImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obtendo uma Miniatura de Apresentação**

API Legada/obsoleta:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var bitmaps = pres.getThumbnails(new aspose.slides.RenderingOptions(), size);
    for (var index = 0; index < bitmaps.length; index++)
    {
        var thumbnail = bitmaps[index];
        var imageio = java.import("javax.imageio.ImageIO");
        var file = java.newInstanceSync("java.io.File", "slide" + index + ".png");
        imageio.write(thumbnail, "PNG", file);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

API Moderna:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var images = pres.getImages(new aspose.slides.RenderingOptions(), size);
    try
    {
        for (var index = 0; index < images.length; index++)
        {
            var thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", aspose.slides.ImageFormat.Png);
        }
    }
    finally
    {
        images.forEach(item => {item.dispose();});
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Adicionando uma Imagem a uma Apresentação**

API Legada/obsoleta:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "image.png");
    var bufferedImages = imageio.read(file);
    var ppImage = pres.getImages().addImage(bufferedImages);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

API Moderna:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var image = aspose.slides.Images.fromFile("image.png");
    var ppImage = pres.getImages().addImage(image);
    image.dispose();

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Métodos Obsoletos e Seu Substituto na API Moderna**

### **Apresentação**
| Assinatura do Método | Assinatura do Método Substituto |
|----------------------|---------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Forma**
| Assinatura do Método | Assinatura do Método Substituto |
|----------------------|---------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Assinatura do Método | Assinatura do Método Substituto |
|----------------------|---------------------------------|
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

### **Saída**
| Assinatura do Método | Assinatura do Método Substituto |
|----------------------|---------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Assinatura do Método | Assinatura do Método Substituto |
|----------------------|---------------------------------|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| Assinatura do Método | Assinatura do Método Substituto |
|----------------------|---------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Assinatura do Método | Assinatura do Método Substituto |
|----------------------|---------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Assinatura do Método | Assinatura do Método Substituto |
|----------------------|---------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Suporte de API para Graphics2D**

Métodos que utilizam [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) foram declarados obsoletos e não possuem substituto direto na API Moderna.

Use os métodos de renderização de imagem da API Moderna em vez da API que renderiza para [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **FAQ**

**Qual é o benefício prático de [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/) em comparação com [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/) unifica o trabalho com imagens raster e vetor e simplifica a gravação em vários formatos via [ImageFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imageformat/).

**A API Moderna afetará o desempenho da geração de miniaturas?**

A troca de `getThumbnail` por `getImage` não piora os cenários: os novos métodos fornecem as mesmas capacidades de produção de imagens com opções e tamanhos, mantendo o suporte a opções de renderização. O ganho ou perda específico depende do cenário, mas funcionalmente os substitutos são equivalentes.