---
title: Aprimorar o Processamento de Imagens com a API Moderna
linktitle: API Moderna
type: docs
weight: 280
url: /pt/cpp/modern-api/
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
- adicionar figura
- C++
- Aspose.Slides
description: "Modernize o processamento de imagens de slides substituindo APIs de imagem obsoletas pela API Moderna C++ para automação perfeita de PowerPoint e OpenDocument."
---
## **Introdução**

Atualmente, a biblioteca Aspose.Slides for C++ tem dependências em sua API pública nas seguintes classes de System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/pt/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/pt/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/pt/cpp/system.drawing/bitmap/)

A partir da versão 24.4, essa API pública foi declarada obsoleta.

Para eliminar as dependências de System::Drawing na API pública, adicionamos a chamada "Modern API". Métodos com [System::Drawing::Image](https://reference.aspose.com/slides/pt/cpp/system.drawing/image/) e [System::Drawing::Bitmap](https://reference.aspose.com/slides/pt/cpp/system.drawing/bitmap/) foram declarados obsoletos e devem ser substituídos pelos métodos correspondentes da Modern API. Métodos com [System::Drawing::Graphics](https://reference.aspose.com/slides/pt/cpp/system.drawing/graphics/) foram declarados obsoletos e não têm substituição direta na Modern API.

Nas versões atuais, trate a API pública que depende de tipos System::Drawing como legado/obsoleta. Use a Modern API para novo código e ao migrar fluxos de trabalho existentes de processamento de imagens.

## **Modern API**

Adicionamos as seguintes classes e enums à API pública:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/) - representa a imagem raster ou vetorial.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imageformat/) - representa o formato de arquivo da imagem.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/pt/cpp/aspose.slides/images/) - métodos para instanciar e trabalhar com a interface [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/).

Use `GetImage` para renderizar um único slide ou forma. Use `GetImages` para renderizar vários slides da apresentação. Use os métodos de [Images](https://reference.aspose.com/slides/pt/cpp/aspose.slides/images/) para carregar imagens, `AddImage` com [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/) para adicioná‑las a uma apresentação e `ReplaceImage` com [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/) para atualizar uma imagem existente na apresentação.

Um cenário típico de uso da nova API pode ser o seguinte:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// instanciar uma instância descartável de IImage a partir do arquivo no disco.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// criar uma imagem PowerPoint adicionando uma instância de IImage às imagens da apresentação.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// adicionar uma forma de imagem no slide #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// obter uma instância de IImage que representa o slide #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// salvar a imagem no disco.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **Substituindo Código Antigo pela Modern API**

Para facilitar a transição, a interface do novo [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/) repete as assinaturas separadas das classes [System::Drawing::Image](https://reference.aspose.com/slides/pt/cpp/system.drawing/image/) e [System::Drawing::Bitmap](https://reference.aspose.com/slides/pt/cpp/system.drawing/bitmap/). Em geral, você só precisará substituir a chamada ao método antigo que usa System::Drawing pelo novo.

### **Obtendo uma Miniatura de Slide**

API legada/obsoleta:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

API Moderna:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **Obtendo uma Miniatura de Forma**

API legada/obsoleta:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

API Moderna:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **Obtendo uma Miniatura de Apresentação**

API legada/obsoleta:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

API Moderna:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **Adicionando uma Imagem a uma Apresentação**

API legada/obsoleta:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

API Moderna:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **Métodos/Propriedades Obsoletos e Sua Substituição na Modern API**

### **Classe Presentation**
|Assinatura do Método|Assinatura do Método de Substituição|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Classe Slide**
|Assinatura do Método|Assinatura do Método de Substituição|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|No Modern API replacement|

### **Classe Shape**
|Assinatura do Método|Assinatura do Método de Substituição|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **Classe ImageCollection**
|Assinatura do Método|Assinatura do Método de Substituição|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **Classe PPImage**
|Assinatura do Método|Assinatura do Método de Substituição|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **Classe PatternFormat**
|Assinatura do Método|Assinatura do Método de Substituição|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **Classe IPatternFormatEffectiveData**
|Assinatura do Método|Assinatura do Método de Substituição|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **Suporte de API para System::Drawing::Graphics**

Métodos com [System::Drawing::Graphics](https://reference.aspose.com/slides/pt/cpp/system.drawing/graphics/) foram declarados obsoletos e não têm substituição direta na Modern API.

Use os métodos de renderização de imagem da Modern API em vez da API que renderiza para [System::Drawing::Graphics](https://reference.aspose.com/slides/pt/cpp/system.drawing/graphics/):
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **FAQ**

**Por que [System::Drawing::Graphics](https://reference.aspose.com/slides/pt/cpp/system.drawing/graphics/) foi removido?**

O suporte a [System::Drawing::Graphics](https://reference.aspose.com/slides/pt/cpp/system.drawing/graphics/) está obsoleto na API pública para unificar o trabalho com renderização e imagens, eliminar dependências específicas de plataforma e adotar uma abordagem multiplataforma com [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/). Use `GetImage` ou `GetImages` em vez de renderizar para [System::Drawing::Graphics](https://reference.aspose.com/slides/pt/cpp/system.drawing/graphics/).

**Qual é o benefício prático de [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/) em comparação com [System::Drawing::Image](https://reference.aspose.com/slides/pt/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/pt/cpp/system.drawing/bitmap/)?**

[IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/) unifica o trabalho com imagens raster e vetoriais, simplifica a gravação em vários formatos via [ImageFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imageformat/), reduz a dependência de `System::Drawing` e torna o código mais portátil entre ambientes.

**A Modern API afetará o desempenho da geração de miniaturas?**

A troca de `GetThumbnail` para `GetImage` não piora os cenários: os novos métodos oferecem as mesmas capacidades de produzir imagens com opções e tamanhos, mantendo o suporte às opções de renderização. O ganho ou perda específico depende do cenário, mas funcionalmente as substituições são equivalentes.