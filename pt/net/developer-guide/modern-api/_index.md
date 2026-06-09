---
title: Aprimorar o Processamento de Imagens com a API Moderna
linktitle: API Moderna
type: docs
weight: 237
url: /pt/net/modern-api/
keywords:
- System.Drawing
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
- .NET
- C#
- Aspose.Slides
description: "Modernize o processamento de imagens de slides substituindo as APIs de imagem obsoletas pela API Moderna .NET para automação fluida de PowerPoint e OpenDocument."
---
## **Introdução**

Historicamente, o Aspose Slides tem uma dependência de System.Drawing e possui na API pública as seguintes classes provenientes dela:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

A partir da versão 24.4, essa API pública foi declarada obsoleta.

Como o suporte a System.Drawing nas versões .NET6 e superiores foi removido para versões não Windows (breaking changehttps://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), o Slides implementou uma abordagem de dois pacotes:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - suporte para .NET6+ no Windows, .NETStandard para Windows/Linux/MacOS, .NETFramework 2+ (Windows).
  - tem uma dependência de [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - versão para Windows/Linux/MacOS sem dependências.

O inconveniente do [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) é que ele implementa sua própria versão de System.Drawing no mesmo namespace (para suportar compatibilidade retroativa com a API pública). Assim, quando o Aspose.Slides.NET6.CrossPlatform e o System.Drawing do .NET Framework ou o pacote System.Drawing.Common são usados ao mesmo tempo, ocorre um conflito de nomes a menos que um alias seja usado.

Para eliminar dependências de System.Drawing no pacote principal Aspose.Slides.NET, adicionamos a chamada "API Moderna" – ou seja, a API que deve ser usada em vez da obsoleta, cujas assinaturas contêm dependências dos seguintes tipos de System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) e [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) e [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) são declarados obsoletos e seu suporte foi removido da API pública do Slides.

Nas versões atuais, trate a API pública que depende de System.Drawing como legada/obsoleta. Use a API Moderna para novo código e ao migrar fluxos de trabalho existentes de processamento de imagens.

## **API Moderna**

Foram adicionadas as seguintes classes e enums à API pública:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) - representa a imagem raster ou vetorial.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/imageformat/) - representa o formato de arquivo da imagem.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/pt/net/aspose.slides/images/) - métodos para instanciar e trabalhar com a interface [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/).

Observe que [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) é descartável (implementa a interface [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) e seu uso deve ser encapsulado em using ou descartado de outra forma conveniente).

Use `GetImage` para renderizar um único slide ou forma. Use `GetImages` para renderizar vários slides da apresentação. Use os métodos de [Images](https://reference.aspose.com/slides/pt/net/aspose.slides/images/) para carregar imagens, `AddImage` com [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) para adicioná‑las a uma apresentação, e `ReplaceImage` com [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) para atualizar uma imagem existente na apresentação.

Um cenário típico de uso da nova API pode ser o seguinte:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // instanciar uma instância descartável de IImage a partir do arquivo no disco.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // criar uma imagem PowerPoint adicionando uma instância de IImage às imagens da apresentação.
        ppImage = pres.Images.AddImage(image);
    }

    // adicionar uma forma de imagem no slide #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // obter uma instância de IImage que representa o slide #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // salvar a imagem no disco.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Substituindo Código Antigo pela API Moderna**

Para facilitar a transição, a interface do novo [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) repete as assinaturas separadas das classes [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) e [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). Em geral, você só precisará substituir a chamada ao método antigo que usava System.Drawing pelo novo.

### **Obtendo uma Miniatura de Slide**

API legada/obsoleta:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

API Moderna:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **Obtendo uma Miniatura de Forma**

API legada/obsoleta:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

API Moderna:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **Obtendo uma Miniatura de Apresentação**

API legada/obsoleta:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var bitmaps = pres.GetThumbnails(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < bitmaps.Length; index++)
        {
            Bitmap thumbnail = bitmaps[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (Bitmap bitmap in bitmaps)
        {
            bitmap.Dispose();
        }
    }
}
```

API Moderna:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var images = pres.GetImages(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < images.Length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (IImage image in images)
        {
            image.Dispose();
        }
    }
}
```

### **Adicionando uma Imagem a uma Apresentação**

API legada/obsoleta:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (Image image = Image.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

API Moderna:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (IImage image = Aspose.Slides.Images.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

## **Métodos/Propriedades Obsoletos e Seu Substituto na API Moderna**

### **Presentation**
| Assinatura do Método                               | Assinatura do Método de Substituição                             |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/getimages#getimages)                   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/getimages#getimages_1)   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print()                           | No Modern API replacement                               |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement                            |
| public void Print(string printerName)         | No Modern API replacement                               |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement                          |

### **Shape**
| Assinatura do Método                                                      | Assinatura do Método de Substituição                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail()                                          | [GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/getimage#getimage)                                                           |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Assinatura do Método                                                      | Assinatura do Método de Substituição                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY)                | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/getimage#getimage_5)                                 |
| public Bitmap GetThumbnail()                                         | [GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/getimage#getimage)                                                              |
| public Bitmap GetThumbnail(IRenderingOptions options)                | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/getimage#getimage_1)                                  |
| public Bitmap GetThumbnail(Size imageSize)                           | [GetImage(Size imageSize)](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/getimage#getimage_6)                                             |
| public Bitmap GetThumbnail(ITiffOptions options)                    | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/getimage#getimage_4)                                      |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/getimage#getimage_3)               |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement                                       |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement                             |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement                                    |

### **Output**
| Assinatura do Método                                                | Assinatura do Método de Substituição                                |
|-------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image)               | [Add(string path, IImage image)](https://reference.aspose.com/slides/pt/net/aspose.slides.export.web/output/add#add_1)                               |

### **ImageCollection**
| Assinatura do Método                          | Assinatura do Método de Substituição               |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image)           | [AddImage(IImage image)](https://reference.aspose.com/slides/pt/net/aspose.slides/imagecollection/addimage#addimage)                      |

### **ImageWrapperFactory**
| Assinatura do Método                                         | Assinatura do Método de Substituição                            |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image)           | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/pt/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper)                        |

### **PPImage**
| Assinatura do Método/Propriedade                     | Assinatura do Método de Substituição   |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage)   | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/pt/net/aspose.slides/ppimage/replaceimage#replaceimage)            |
| Image SystemImage { get; }          | [IImage Image { get; }](https://reference.aspose.com/slides/pt/net/aspose.slides/ppimage/image)                    |

### **PatternFormat**
| Assinatura do Método                                          | Assinatura do Método de Substituição                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/pt/net/aspose.slides/patternformat/gettile#gettile_1)         |
| Bitmap GetTileImage(Color styleColor)                     | [GetTile(Color styleColor)](https://reference.aspose.com/slides/pt/net/aspose.slides/patternformat/gettile#gettile)                           |

### **IPatternFormatEffectiveData**
| Assinatura do Método                                          | Assinatura do Método de Substituição                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/pt/net/aspose.slides/ipatternformateffectivedata/gettileiimage)                    |

## **Suporte da API para Graphics e PrinterSettings**

A classe [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) não é suportada nas versões cross‑platform do .NET6 e superiores. No Aspose Slides, use os métodos de renderização de imagem da API Moderna em vez da API que renderiza para [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Além disso, a API relacionada à impressão através de [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) não tem substituto direto na API Moderna:

[IPresentation](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/print/#print_2)

## **Perguntas Frequentes**

**Por que o [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) foi removido?**

O suporte ao [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) foi declarado obsoleto na API pública para unificar o trabalho com renderização e imagens, eliminar vínculos com dependências específicas de plataforma e migrar para uma abordagem cross‑platform com [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/). Use `GetImage` ou `GetImages` em vez de renderizar para [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

**Qual é o benefício prático do [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) em comparação com [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)?**

[IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/) unifica o trabalho com imagens raster e vetoriais, simplifica a gravação em vários formatos via [ImageFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/imageformat/), reduz a dependência de `System.Drawing` e torna o código mais portátil entre ambientes.

**A API Moderna afetará o desempenho da geração de miniaturas?**

A troca de `GetThumbnail` por `GetImage` não piora os cenários: os novos métodos fornecem as mesmas capacidades de produzir imagens com opções e tamanhos, mantendo o suporte a opções de renderização. O ganho ou perda específico depende do cenário, mas funcionalmente as substituições são equivalentes.