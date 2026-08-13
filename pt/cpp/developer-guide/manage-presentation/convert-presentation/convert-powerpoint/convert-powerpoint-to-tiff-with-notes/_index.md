---
title: Converter apresentações PowerPoint para TIFF com notas em C++
linktitle: PowerPoint para TIFF com notas
type: docs
weight: 100
url: /pt/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- converter PowerPoint
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
- PowerPoint com notas
- apresentação com notas
- slide com notas
- PPT com notas
- PPTX com notas
- TIFF com notas
- C++
- Aspose.Slides
description: "Converta apresentações PowerPoint para TIFF com notas usando Aspose.Slides para C++. Aprenda a exportar slides com notas do apresentador de forma eficiente."
---
## **Introdução**

Aspose.Slides for C++ oferece uma solução simples para converter apresentações PowerPoint e OpenDocument (PPT, PPTX e ODP) com anotações para o formato TIFF. Este formato é amplamente usado para armazenamento de imagens de alta qualidade, impressão e arquivamento de documentos. Com o Aspose.Slides, você pode não apenas exportar apresentações completas com notas do apresentador, mas também gerar miniaturas de slides na visualização Notas do Slide. O processo de conversão é simples e eficiente, utilizando o método `Save` da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) para transformar toda a apresentação em uma série de imagens TIFF enquanto preserva as notas e o layout.

## **Converter uma apresentação para TIFF com notas**

Salvar uma apresentação PowerPoint ou OpenDocument em TIFF com notas usando o Aspose.Slides for C++ envolve os seguintes passos:

1. Instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/): carregar um arquivo PowerPoint ou OpenDocument.  
1. Configurar as opções de layout de saída: usar a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/notescommentslayoutingoptions/) para especificar como as notas e comentários devem ser exibidos.  
1. Salvar a apresentação em TIFF: passar as opções configuradas para o método [Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/).

Suponha que temos um arquivo "speaker_notes.pptx" com o slide a seguir:

![O slide da apresentação com notas do apresentador](slide_with_notes.png)

O trecho de código abaixo demonstra como converter a apresentação em uma imagem TIFF na visualização Notas do Slide usando o método [set_SlidesLayoutOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/).

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Exibir as notas abaixo do slide.

// Configurar as opções TIFF com layout de notas.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Salvar a apresentação em TIFF com as notas do apresentador.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

O resultado:

![A imagem TIFF com notas do apresentador](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Confira o [Conversor gratuito de PowerPoint para pôster da Aspose](https://products.aspose.app/slides/pt/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Perguntas frequentes**

### Posso controlar a posição da área de notas na TIFF resultante?

Sim. Use as [configurações de layout de notas](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) para escolher entre opções como `None`, `BottomTruncated` ou `BottomFull`, que respectivamente ocultam as notas, ajustam-nas em uma única página ou permitem que elas fluam para páginas adicionais.

### Como posso reduzir o tamanho de um arquivo TIFF com notas sem perda visível de qualidade?

Escolha uma [compressão eficiente](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (por exemplo, `LZW` ou `RLE`), defina um DPI razoável e, se aceitável, use um [formato de pixel](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) mais baixo (como 8 bpp ou 1 bpp para monocromático). Reduzir levemente as [dimensões da imagem](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/set_imagesize/) também pode ajudar sem comprometer perceptivelmente a legibilidade.

### A fonte nas notas afeta o resultado se as fontes originais estiverem ausentes no sistema?

Sim. Fontes ausentes acionam a [substituição](/slides/pt/cpp/font-selection-sequence/), que pode alterar métricas e a aparência do texto. Para evitar isso, [forneça as fontes necessárias](/slides/pt/cpp/custom-font/) ou defina uma [fonte de fallback](/slides/pt/cpp/fallback-font/) padrão para que as tipografias desejadas sejam usadas.