---
title: Aprimore o Processamento de Imagens com a API Moderna
linktitle: API Moderna
type: docs
weight: 237
url: /pt/androidjava/modern-api/
keywords:
- android.graphics
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
- Android
- Java
- Aspose.Slides
description: "Modernize o processamento de imagens de slides substituindo APIs de imagem obsoletas pela API Moderna Java para automação perfeita de PowerPoint e OpenDocument."
---
## **Introdução**

Historicamente, o Aspose Slides tem uma dependência de android.graphics e tem na API pública as seguintes classes de lá:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

A partir da versão 24.4, esta API pública foi declarada obsoleta.

Para eliminar dependências dessas classes, adicionamos a chamada “API Moderna” – ou seja, a API que deve ser usada em vez da obsoleta, cujas assinaturas contêm dependências de [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap). [Canvas](https://developer.android.com/reference/android/graphics/Canvas) foi declarada obsoleta e seu suporte foi removido da API pública do Slides.

Nas versões atuais, considere a API pública que depende de tipos android.graphics como legada/obsoleta. Use a API Moderna para novo código e ao migrar fluxos de trabalho de processamento de imagens existentes.

## **API Moderna**

Adicionamos as seguintes classes e enumerações à API pública:

- [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/) – representa a imagem raster ou vetorial.  
- [ImageFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imageformat/) – representa o formato de arquivo da imagem.  
- [Images](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/images/) – métodos para instanciar e trabalhar com a interface [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/).

Observe que [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/) é descartável e seu uso deve ser seguido por uma chamada `dispose()` ou outro padrão conveniente de descarte.

Use `getImage` para renderizar um único slide ou forma. Use `getImages` para renderizar vários slides da apresentação. Use os métodos de [Images](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/images/) para carregar imagens, `addImage` com [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/) para adicioná‑las a uma apresentação e `replaceImage` com [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/) para atualizar uma imagem existente da apresentação.

Um cenário típico de uso da nova API pode ser como o seguinte:

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
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
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

Em geral, você precisará substituir chamadas que usam [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) pelos novos métodos que utilizam [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/).

API legada/obsoleta:
``` java
Presentation pres = new Presentation();
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail(new Size(1920, 1080));
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("image.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```
API Moderna:
``` java
Presentation pres = new Presentation();
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        slideImage.save("image.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obter uma Miniatura de Slide**

API legada/obsoleta:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("slide1.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
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

### **Obter uma Miniatura de Forma**

API legada/obsoleta:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("shape.png");
        shapeImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
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

### **Obter uma Miniatura de Apresentação**

API legada/obsoleta:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Size(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        android.graphics.Bitmap thumbnail = bitmaps[index];
        FileOutputStream fos = null;
        try {
            fos = new FileOutputStream("slide" + index + ".png");
            thumbnail.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } finally {
            if (fos != null) {
                try {
                    fos.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
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
    IImage[] images = pres.getImages(new RenderingOptions(), new Size(1980, 1028));
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

### **Adicionar uma Imagem a uma Apresentação**

API legada/obsoleta:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    File file = new File("image.png");
    Bitmap bitmap = BitmapFactory.decodeFile(file.getAbsolutePath());
    ppImage = pres.getImages().addImage(bitmap);

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

## **Métodos Obsoletos e Seu Substituto na API Moderna**

### **Apresentação**
| Assinatura do Método | Assinatura do Método de Substituição |
|----------------------|--------------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Forma**
| Assinatura do Método | Assinatura do Método de Substituição |
|----------------------|--------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Assinatura do Método | Assinatura do Método de Substituição |
|----------------------|--------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | No Modern API replacement |

### **Saída**
| Assinatura do Método | Assinatura do Método de Substituição |
|----------------------|--------------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Assinatura do Método | Assinatura do Método de Substituição |
|----------------------|--------------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Assinatura do Método | Assinatura do Método de Substituição |
|----------------------|--------------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Assinatura do Método | Assinatura do Método de Substituição |
|----------------------|--------------------------------------|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| Assinatura do Método | Assinatura do Método de Substituição |
|----------------------|--------------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **Suporte de API para Canvas**

Métodos com [Canvas](https://developer.android.com/reference/android/graphics/Canvas) foram declarados obsoletos e não têm substituto direto na API Moderna.

Use os métodos de renderização de imagem da API Moderna em vez da API que renderiza para [Canvas](https://developer.android.com/reference/android/graphics/Canvas):

[Slide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **Perguntas Frequentes**

**Por que o android.graphics.Canvas foi removido?**

O suporte para [Canvas](https://developer.android.com/reference/android/graphics/Canvas) foi descontinuado na API pública para unificar o trabalho com renderização e imagens, eliminar vínculos a dependências específicas da plataforma e migrar para uma abordagem multiplataforma com [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/). Use `getImage` ou `getImages` em vez de renderizar para [Canvas](https://developer.android.com/reference/android/graphics/Canvas).

**Qual é o benefício prático do [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/) em comparação com o [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)?**

[IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/) unifica o trabalho com imagens raster e vetoriais e simplifica a gravação em diversos formatos via [ImageFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imageformat/).

**A API Moderna afetará o desempenho da geração de miniaturas?**

A troca de `getThumbnail` para `getImage` não piora os cenários: os novos métodos oferecem as mesmas capacidades de produzir imagens com opções e tamanhos, mantendo o suporte às opções de renderização. O ganho ou perda específico depende do cenário, mas funcionalmente as substituições são equivalentes.