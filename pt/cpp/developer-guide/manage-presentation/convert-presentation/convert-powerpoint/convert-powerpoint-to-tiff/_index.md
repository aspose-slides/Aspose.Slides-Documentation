---
title: Converter apresentações PowerPoint para TIFF em C++
titlelink: PowerPoint para TIFF
type: docs
weight: 90
url: /pt/cpp/convert-powerpoint-to-tiff/
keywords:
- converter PowerPoint
- converter OpenDocument
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para TIFF
- apresentação para TIFF
- slide para TIFF
- PPT para TIFF
- PPTX para TIFF
- salvar PPT como TIFF
- salvar PPTX como TIFF
- exportar PPT para TIFF
- exportar PPTX para TIFF
- C++
- Aspose.Slides
description: "Aprenda como converter facilmente apresentações PowerPoint (PPT, PPTX) para imagens TIFF de alta qualidade usando Aspose.Slides para C++, com exemplos de código."
---
## **Introdução**

TIFF (**Tagged Image File Format**) é um formato de imagem raster sem perda amplamente usado, conhecido por sua qualidade excepcional e preservação detalhada de gráficos. Designers, fotógrafos e editores de desktop frequentemente escolhem o TIFF para manter camadas, precisão de cores e configurações originais em suas imagens.

Usando o Aspose.Slides, você pode converter facilmente seus slides do PowerPoint (PPT, PPTX) e slides OpenDocument (ODP) diretamente em imagens TIFF de alta qualidade, garantindo que suas apresentações mantenham a máxima fidelidade visual.

## **Converter uma Apresentação para TIFF**

Usando o método [Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/) fornecido pela classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/), você pode converter rapidamente uma apresentação completa do PowerPoint para TIFF. As imagens TIFF resultantes correspondem ao tamanho de slide padrão.

Este código C++ demonstra como converter uma apresentação do PowerPoint para TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantiate the Presentation class that represents a presentation file (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Save the presentation as TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Converter uma Apresentação para TIFF em Preto e Branco**

O método [set_BwConversionMode](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) na classe [TiffOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/) permite especificar o algoritmo usado ao converter um slide ou imagem colorida para um TIFF em preto e branco. Observe que essa configuração se aplica somente quando o método [set_CompressionType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) está definido como `CCITT4` ou `CCITT3`.

Suponha que temos um arquivo "sample.pptx" com o seguinte slide:

![Um slide de apresentação](slide_black_and_white.png)

Este código C++ demonstra como converter o slide colorido para um TIFF em preto e branco:

```cpp
#include <DOM/Presentation.h>
#include <Export/BlackWhiteConversionMode.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

O resultado:

![TIFF em preto e branco](TIFF_black_and_white.png)

## **Converter uma Apresentação para TIFF com Tamanho Personalizado**

Se você precisar de uma imagem TIFF com dimensões específicas, pode definir os valores desejados usando os métodos disponíveis em [TiffOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/). Por exemplo, o método [set_ImageSize](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/set_imagesize/) permite definir o tamanho da imagem resultante.

Este código C++ demonstra como converter uma apresentação do PowerPoint em imagens TIFF com tamanho personalizado:

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instancie a classe Presentation que representa um arquivo de apresentação (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Defina o tipo de compressão.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Tipos de compressão:
    Default - Especifica o esquema de compressão padrão (LZW).
    None - Especifica nenhuma compressão.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// A profundidade depende do tipo de compressão e não pode ser definida manualmente.

// Defina o DPI da imagem.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Defina o tamanho da imagem.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Salve a apresentação como TIFF com o tamanho especificado.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Converter uma Apresentação para TIFF com Formato de Pixel de Imagem Personalizado**

Usando o método [set_PixelFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) da classe [TiffOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/), você pode especificar o formato de pixel desejado para a imagem TIFF resultante.

Este código C++ demonstra como converter uma apresentação do PowerPoint para uma imagem TIFF com um formato de pixel personalizado:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instancie a classe Presentation que representa um arquivo de apresentação (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat contém os seguintes valores (conforme descrito na documentação):
    Format1bppIndexed - 1 bit por pixel, indexado.
    Format4bppIndexed - 4 bits por pixel, indexado.
    Format8bppIndexed - 8 bits por pixel, indexado.
    Format24bppRgb    - 24 bits por pixel, RGB.
    Format32bppArgb   - 32 bits por pixel, ARGB.
*/

// Salve a apresentação como TIFF com o tamanho de imagem especificado.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Dica" color="info" %}}
Confira o [conversor GRATUITO de PowerPoint para pôster da Aspose](https://products.aspose.app/slides/pt/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Perguntas Frequentes**

### Posso converter um slide individual em vez de toda a apresentação PowerPoint para TIFF?

Sim. O Aspose.Slides permite que você converta slides individuais de apresentações PowerPoint e OpenDocument em imagens TIFF separadamente.

### Existe algum limite para o número de slides ao converter uma apresentação para TIFF?

Não, o Aspose.Slides não impõe restrições ao número de slides. Você pode converter apresentações de qualquer tamanho para o formato TIFF.

### As animações e efeitos de transição do PowerPoint são preservados ao converter slides para TIFF?

Não, o TIFF é um formato de imagem estática. Portanto, animações e efeitos de transição não são preservados; apenas instantâneos estáticos dos slides são exportados.