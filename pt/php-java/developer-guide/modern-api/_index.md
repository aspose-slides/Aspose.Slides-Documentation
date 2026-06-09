---
title: Aprimore o Processamento de Imagens com a API Moderna
linktitle: API Moderna
type: docs
weight: 237
url: /pt/php-java/modern-api/
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
- PHP
- Aspose.Slides
description: "Modernize o processamento de imagens de slides substituindo APIs de imagem obsoletas pela API Moderna em PHP para automação perfeita de PowerPoint e OpenDocument."
---
## **Introdução**

Historicamente, o Aspose Slides tem uma dependência de java.awt e tem na API pública as seguintes classes provenientes dela:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

A partir da versão 24.4, esta API pública foi declarada obsoleta.

Para eliminar as dependências dessas classes, adicionamos a chamada “API Moderna” – ou seja, a API que deve ser usada em vez da obsoleta, cujas assinaturas contêm dependências de [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) foi declarada obsoleta e seu suporte foi removido da API pública do Slides.

Nas versões atuais, trate a API pública que depende de tipos java.awt como legada/obsoleta. Use a API Moderna para novo código e ao migrar fluxos de trabalho existentes de processamento de imagens.

## **API Moderna**

Foram adicionadas as seguintes classes e enums à API pública:

- [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/) - representa a imagem raster ou vetorial.
- [ImageFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imageformat/) - representa o formato de arquivo da imagem.
- [Images](https://reference.aspose.com/slides/pt/php-java/aspose.slides/images/) - métodos para instanciar e trabalhar com a classe [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/).

Observe que [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/) é descartável (deve ser descartado após o uso).

Use `getImage` para renderizar um único slide ou forma. Use `getImages` para renderizar vários slides de apresentação. Use os métodos de [Images](https://reference.aspose.com/slides/pt/php-java/aspose.slides/images/) para carregar imagens, `addImage` com [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/) para adicioná‑las a uma apresentação e `replaceImage` com [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/) para atualizar uma imagem existente da apresentação.

Um cenário típico de uso da nova API pode ser o seguinte:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# instanciar uma instância descartável de IImage a partir do arquivo no disco.
$image = Images::fromFile("image.png");

# criar uma imagem PowerPoint adicionando uma instância de IImage às imagens da apresentação.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# adicionar uma forma de imagem no slide #1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# obter uma instância de IImage que representa o slide #1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# salvar a imagem no disco.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **Substituindo o Código Antigo pela API Moderna**

Em geral, será necessário substituir chamadas que utilizam [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) e [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) pelos novos métodos que utilizam [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/).

API legada/obsoleta:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
API Moderna:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **Obtendo uma Miniatura de Slide**

API legada/obsoleta:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

API Moderna:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```

### **Obtendo uma Miniatura de Forma**

API legada/obsoleta:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

API Moderna:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```

### **Obtendo uma Miniatura de Apresentação**

API legada/obsoleta:

``` php
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$bitmaps = $pres->getThumbnails($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($bitmaps)); $i++)
{
    $thumbnail = $bitmaps[$i];
    $imageio = new Java("javax.imageio.ImageIO");
    $javafile = new Java("java.io.File", "slide" . $i . ".png");
    $imageio->write($thumbnail, "PNG", $javafile);
}

$pres->dispose();
```

API Moderna:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$images = $pres->getImages($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($images)); $i++)
{
    $thumbnail = $images[$i];
    $thumbnail->save("slide" . $i . ".png", ImageFormat::Png);
}

$pres->dispose();
```

### **Adicionando uma Imagem a uma Apresentação**

API legada/obsoleta:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;


$pres = new Presentation();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");

$bufferedImages = $imageio->read($javafile);
$ppImage = $pres->getImages()->addImage($bufferedImages);

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

API Moderna:

``` php
use aspose\slides\Presentation;
use aspose\slides\Images;
use aspose\slides\ShapeType;


$pres = new Presentation();

$image = Images::fromFile("image.png");
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

## **Métodos Obsoletos e Suas Substituições na API Moderna**

### **Apresentação**
| Assinatura do Método | Assinatura do Método de Substituição |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Forma**
| Assinatura do Método | Assinatura do Método de Substituição |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Assinatura do Método | Assinatura do Método de Substituição |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Sem substituição na API Moderna |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Sem substituição na API Moderna |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Sem substituição na API Moderna |

### **Saída**
| Assinatura do Método | Assinatura do Método de Substituição |
|-----------------------------------------------|---------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Assinatura do Método | Assinatura do Método de Substituição |
|-----------------------------------------------|---------------------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Assinatura do Método | Assinatura do Método de Substituição |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Assinatura do Método | Assinatura do Método de Substituição |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Assinatura do Método | Assinatura do Método de Substituição |
|-----------------------------------------------|---------------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Suporte de API para Graphics2D**

Métodos com [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) são declarados obsoletos e não possuem substituição direta na API Moderna.

Use os métodos de renderização de imagem da API Moderna em vez da API que renderiza para [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **Perguntas Frequentes**

**Por que o [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) foi removido?**

O suporte ao [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) foi declarado obsoleto na API pública para unificar o trabalho com renderização e imagens, eliminar dependências específicas de plataforma e adotar uma abordagem multiplataforma com [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/). Use `getImage` ou `getImages` em vez de renderizar para [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Qual é o benefício prático do [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/) em comparação com o [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/) unifica o trabalho com imagens raster e vetoriais e simplifica a gravação em vários formatos por meio de [ImageFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imageformat/).

**A API Moderna afetará o desempenho da geração de miniaturas?**

A mudança de `getThumbnail` para `getImage` não piora os cenários: os novos métodos fornecem as mesmas capacidades de produção de imagens com opções e tamanhos, mantendo o suporte a opções de renderização. O ganho ou perda específicos dependem do cenário, mas funcionalmente as substituições são equivalentes.