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
description: "Converter apresentações PowerPoint para TIFF com notas usando Aspose.Slides para C++. Aprenda a exportar slides com notas do apresentador de forma eficiente."
---
## **Introdução**

Aspose.Slides for C++ fornece uma solução simples para converter apresentações PowerPoint e OpenDocument (PPT, PPTX e ODP) com anotações para o formato TIFF. Esse formato é amplamente usado para armazenamento de imagens de alta qualidade, impressão e arquivamento de documentos. Com Aspose.Slides, você pode não apenas exportar apresentações inteiras com notas do apresentador, mas também gerar miniaturas de slides na visualização de Slide de Notas. O processo de conversão é simples e eficiente, utilizando o método `Save` da classe [Apresentação](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) para transformar toda a apresentação em uma série de imagens TIFF preservando as notas e o layout.

## **Converter uma Apresentação para TIFF com Notas**

Salvar uma apresentação PowerPoint ou OpenDocument em TIFF com notas usando Aspose.Slides for C++ envolve as etapas a seguir:

1. Instanciar a classe [Apresentação](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/): carregar um arquivo PowerPoint ou OpenDocument.  
2. Configurar as opções de layout de saída: usar a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/notescommentslayoutingoptions/) para especificar como as notas e comentários devem ser exibidos.  
3. Salvar a apresentação em TIFF: passar as opções configuradas para o método [Salvar](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/).

Suponha que temos um arquivo "speaker_notes.pptx" com o slide a seguir:

![O slide da apresentação com notas do apresentador](slide_with_notes.png)

O trecho de código abaixo demonstra como converter a apresentação em uma imagem TIFF na visualização de Slide de Notas usando o método [set_SlidesLayoutOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/).

```cpp
// Instancia a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Exibe as notas abaixo do slide.

// Configure the TIFF options with Notes layouting.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to TIFF with the speaker notes.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

O resultado:

![A imagem TIFF com notas do apresentador](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Confira o [Conversor Gratuito de PowerPoint para Pôster da Aspose](https://products.aspose.app/slides/pt/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Perguntas Frequentes**

**Posso controlar a posição da área de notas na TIFF resultante?**

Sim. Use as [configurações de layout de notas](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) para escolher entre opções como `None`, `BottomTruncated` ou `BottomFull`, que respectivamente ocultam notas, as ajustam em uma única página ou permitem que se estendam a páginas adicionais.

**Como posso reduzir o tamanho de um arquivo TIFF com notas sem perda visível de qualidade?**

Escolha uma [compressão eficiente](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (por exemplo, `LZW` ou `RLE`), defina um DPI razoável e, se aceitável, use um formato de pixel mais baixo [pixel format](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (como 8 bpp ou 1 bpp para monocromático). Reduzir levemente as [dimensões da imagem](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/set_imagesize/) também pode ajudar sem prejudicar perceptivelmente a legibilidade.

**A fonte nas notas afeta o resultado se as fontes originais estiverem ausentes no sistema?**

Sim. Fontes ausentes acionam a [substituição](/slides/pt/cpp/font-selection-sequence/), o que pode alterar métricas e aparência do texto. Para evitar isso, [forneça as fontes necessárias](/slides/pt/cpp/custom-font/) ou defina uma [fonte de fallback](/slides/pt/cpp/fallback-font/) padrão para que as tipografias pretendidas sejam usadas.