---
title: Converter Slides de Apresentação em Imagens em C++
linktitle: Slide para Imagem
type: docs
weight: 41
url: /pt/cpp/convert-slide/
keywords:
- converter slide
- exportar slide
- slide para imagem
- salvar slide como imagem
- slide para PNG
- slide para JPEG
- slide para bitmap
- slide para TIFF
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Converta slides de PPT, PPTX e ODP em imagens em C++ usando Aspose.Slides — renderização rápida e de alta qualidade com exemplos de código claros."
---
## **Introdução**

O Aspose.Slides for C++ permite que você converta facilmente slides de apresentações PowerPoint e OpenDocument em vários formatos de imagem, incluindo BMP, PNG, JPG (JPEG), GIF e outros.

Para converter um slide em uma imagem, siga estas etapas:

1. Defina as configurações de conversão desejadas e selecione os slides que deseja exportar usando:
    - A interface [ITiffOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/itiffoptions/) ou
    - A interface [IRenderingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/irenderingoptions/).
2. Gere a imagem do slide chamando o método [GetImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/getimage/).

Um [Bitmap](https://reference.aspose.com/slides/pt/cpp/system.drawing/bitmap/) é um objeto que permite trabalhar com imagens definidas por dados de pixel. Você pode usar uma instância desta classe para salvar imagens em uma ampla variedade de formatos (BMP, JPG, PNG, etc.).

## **Converter Slides em Bitmaps e Salvar as Imagens em PNG**

Você pode converter um slide em um objeto bitmap e usá‑lo diretamente em sua aplicação. Alternativamente, pode converter um slide em um bitmap e então salvar a imagem em JPEG ou em qualquer outro formato preferido.

Este código C++ demonstra como converter o primeiro slide de uma apresentação em um objeto bitmap e então salvar a imagem no formato PNG:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Convert the first slide in the presentation to a bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Save the image in the PNG format.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Converter Slides em Imagens com Tamanhos Personalizados**

Pode ser necessário obter uma imagem com um tamanho específico. Usando uma sobrecarga do [GetImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/getimage/), você pode converter um slide em uma imagem com dimensões específicas (largura e altura). 

Este código de exemplo demonstra como fazer isso:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Converter o primeiro slide da apresentação em um bitmap com o tamanho especificado.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Salvar a imagem no formato JPEG.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Converter Slides com Anotações e Comentários em Imagens**

Alguns slides podem conter notas e comentários.

O Aspose.Slides fornece duas interfaces—[ITiffOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/itiffoptions/) e [IRenderingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/irenderingoptions/)—que permitem controlar a renderização de slides de apresentação em imagens. Ambas as interfaces incluem o método `set_SlidesLayoutOptions`, que permite configurar a renderização de notas e comentários em um slide ao convertê‑lo em uma imagem.

Com a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/notescommentslayoutingoptions/), você pode especificar a posição preferida para notas e comentários na imagem resultante.

Este código C++ demonstra como converter um slide com notas e comentários:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Carregar um arquivo de apresentação.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Definir a posição das notas.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Definir a posição dos comentários.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Definir a largura da área de comentários.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Definir a cor da área de comentários.

// Criar as opções de renderização.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Converter o primeiro slide da apresentação em uma imagem.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Salvar a imagem no formato GIF.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
Em qualquer processo de conversão de slide para imagem, o método [set_NotesPosition](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) não pode aplicar `BottomFull` (para especificar a posição das notas) porque o texto de uma nota pode ser grande demais, impedindo que caiba no tamanho de imagem especificado.
{{% /alert %}} 

## **Converter Slides em Imagens Usando Opções TIFF**

A interface [ITiffOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/itiffoptions/) oferece maior controle sobre a imagem TIFF resultante, permitindo especificar parâmetros como tamanho, resolução, paleta de cores e muito mais.

Este código C++ demonstra um processo de conversão onde as opções TIFF são usadas para gerar uma imagem em preto e branco com resolução de 300 DPI e tamanho de 2160 × 2800:

```cpp 
// Carregar um arquivo de apresentação.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Obter o primeiro slide da apresentação.
auto slide = presentation->get_Slide(0);

// Configurar as configurações da imagem TIFF de saída.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Definir o tamanho da imagem.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Definir o formato de pixel (preto e branco).
tiffOptions->set_DpiX(300);                                         // Definir a resolução horizontal.
tiffOptions->set_DpiY(300);                                         // Definir a resolução vertical.

// Converter o slide em uma imagem com as opções especificadas.
auto image = slide->GetImage(tiffOptions);

// Salvar a imagem no formato TIFF.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Converter Todos os Slides em Imagens**

O Aspose.Slides permite converter todos os slides de uma apresentação em imagens, transformando efetivamente toda a apresentação em uma série de imagens.

Este código de exemplo demonstra como converter todos os slides de uma apresentação em imagens em C++:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Renderizar a apresentação em imagens slide a slide.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Controlar slides ocultos (não renderizar slides ocultos).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Converter o slide em uma imagem.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Salvar a imagem no formato JPEG.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Renderização de Emoji Colorido**

{{% alert title="Note" color="warning" %}} 
Para renderizar emojis coloridos corretamente ao converter slides de apresentação em imagens, as fontes de emoji usadas na apresentação devem estar instaladas e disponíveis no sistema que realiza a conversão. Por exemplo, se a apresentação usar **Segoe UI Emoji** e essa fonte estiver ausente, os emojis podem aparecer em monocromático nas imagens de saída.
{{% /alert %}}

## **FAQ**

**O Aspose.Slides oferece suporte à renderização de slides com animações?**

Não, o método `GetImage` salva apenas uma imagem estática do slide, sem animações.

**Slides ocultos podem ser exportados como imagens?**

Sim, slides ocultos podem ser processados como os regulares. Basta garantir que estejam incluídos no loop de processamento.

**As imagens podem ser salvas com sombras e efeitos?**

Sim, o Aspose.Slides oferece suporte à renderização de sombras, transparência e outros efeitos gráficos ao salvar slides como imagens.