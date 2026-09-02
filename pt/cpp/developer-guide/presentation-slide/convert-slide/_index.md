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
- slide para EMF
- slide para PNG
- slide para JPEG
- slide para bitmap
- slide para TIFF
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Converter slides de apresentações PPT, PPTX e ODP para PNG, JPEG, GIF, TIFF, EMF e outros formatos de imagem em C++ com Aspose.Slides for C++."
---
## **Introdução**

Aspose.Slides for C++ pode renderizar slides individuais de apresentações PowerPoint e OpenDocument como PNG, JPEG, GIF, TIFF e outros formatos de imagem.

Para converter um slide em uma imagem, siga estas etapas:

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Selecione o slide que deseja renderizar.
3. Se necessário, configure a renderização com a classe [RenderingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/renderingoptions/) ou [TiffOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/).
4. Chame o método [ISlide::GetImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/getimage/). Ele retorna um objeto [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/).
5. Chame o método [IImage::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/save/) e especifique o formato de saída com um valor [ImageFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imageformat/).

## **Converter um Slide em uma Imagem PNG**

A conversão mais simples usa as configurações de renderização padrão. O objeto [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/) resultante pode ser processado na memória ou salvo em um arquivo.

O exemplo C++ a seguir renderiza o primeiro slide e o salva como uma imagem PNG:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Converter Slides em Imagens com Tamanhos Personalizados**

Use a sobrecarga do método [ISlide::GetImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/getimage/) que aceita um valor [Size](https://reference.aspose.com/slides/pt/cpp/system.drawing/size/) para renderizar um slide com dimensões exatas em pixels.

O exemplo a seguir cria uma imagem JPEG de 1820 × 1040:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Converter Slides com Notas e Comentários em Imagens**

Por padrão, as imagens dos slides não incluem notas ou comentários. Atribua um objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/notescommentslayoutingoptions/) ao método [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) para controlar onde as notas e comentários aparecem.

O exemplo a seguir posiciona notas truncadas abaixo do slide e comentários à sua direita:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
Para a conversão de slide para imagem, não defina o método [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) como [BottomFull](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/notespositions/). As notas podem conter mais texto do que o tamanho fixo da imagem pode acomodar. Use [BottomTruncated](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/notespositions/) em vez disso.
{{% /alert %}}

## **Converter Slides em Imagens Usando Opções TIFF**

A classe [TiffOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/) permite controlar o tamanho, a resolução e outras propriedades da imagem TIFF renderizada.

O exemplo a seguir renderiza o primeiro slide como uma imagem TIFF de 2160 × 2880 a 300 DPI:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Converter Todos os Slides em Imagens**

Percorra a coleção de slides para converter toda a apresentação em uma série de imagens. Slides ocultos são incluídos, a menos que você os ignore explicitamente.

O exemplo a seguir renderiza cada slide como uma imagem JPEG com fatores de escala horizontal e vertical de 2:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **Criar Saída Metarquivo Aprimorado**

Enhanced Metafile (EMF) é útil quando gráficos vetoriais precisam ser trocados com o Microsoft Office ou outros aplicativos Windows que suportam metarquivos Windows. Ao contrário de uma imagem baseada em pixels, um EMF pode preservar operações de desenho vetorial que escalam sem a mesma perda de nitidez. Contudo, EMF é principalmente um formato de compatibilidade para aplicativos com suporte a metarquivos Windows, não um formato de intercâmbio universal. Além disso, conteúdo complexo de slides, como imagens bitmap e alguns efeitos, podem ser armazenados como elementos rasterizados dentro do contêiner de metarquivo vetorial.

### **Exportar um Slide para EMF**

O método [ISlide::WriteAsEmf](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/writeasemf/) grava um [ISlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/) em um fluxo de destino no formato EMF. O exemplo a seguir carrega uma apresentação, seleciona o primeiro slide e o grava em um fluxo de arquivo EMF:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

O chamador possui o fluxo passado para [ISlide::WriteAsEmf](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/writeasemf/) e deve fechá‑lo ou descartá‑lo. O Aspose.Slides grava na posição atual do fluxo e deixa o fluxo aberto.

### **Converter uma Imagem SVG para EMF e Adicioná‑la a uma Apresentação**

Use [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isvgimage/writeasemf/) para converter conteúdo SVG em EMF. Os bytes resultantes podem ser adicionados à apresentação através de [IImageCollection::AddImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimagecollection/addimage/) e colocados em um slide com [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/addpictureframe/).

O exemplo a seguir cria um [SvgImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/svgimage/) a partir de marcação SVG, converte‑o em um EMF em memória, insere o metarquivo no primeiro slide e salva a apresentação:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isvgimage/writeasemf/) não assume a propriedade do fluxo de destino. Após a gravação, a posição do fluxo está no final dos dados gerados. O exemplo chama [MemoryStream::ToArray](https://reference.aspose.com/slides/pt/cpp/system.io/memorystream/toarray/) para obter o buffer completo independentemente da posição atual do fluxo, e então passa esse array de bytes para [IImageCollection::AddImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimagecollection/addimage/). Mantenha o fluxo aberto até que o consumidor termine de lê‑lo e feche‑o depois.

A geração de EMF está disponível nos sistemas operacionais suportados pelo Aspose.Slides for C++, mas a renderização pode variar entre plataformas quando fontes ou dependências gráficas nativas não estão disponíveis. Instale as fontes usadas pelo conteúdo de origem ou configure substituições adequadas, siga os [requisitos de plataforma](/slides/pt/cpp/system-requirements/) para Aspose.Slides for C++ e valide o resultado no aplicativo de consumo de EMF alvo. Aplicativos Linux e macOS frequentemente têm suporte limitado ou inconsistente para exibir e editar metarquivos Windows.

## **Renderização de Emoji Colorido**

{{% alert title="Note" color="info" %}}
Para renderizar emojis coloridos corretamente ao converter slides de apresentação em imagens, as fontes de emoji usadas na apresentação devem estar instaladas e disponíveis no sistema que realiza a conversão. Por exemplo, se a apresentação usar **Segoe UI Emoji** e essa fonte estiver ausente, os emojis podem aparecer em monocromático nas imagens de saída.
{{% /alert %}}

## **FAQ**

**O Aspose.Slides suporta renderização de slides com animações?**

Não. O método [ISlide::GetImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/getimage/) renderiza uma imagem estática do slide e não exporta animações.

**Slides ocultos podem ser exportados como imagens?**

Sim. Slides ocultos podem ser renderizados como slides normais. Inclua‑os no loop de processamento, como mostrado no exemplo acima.

**Sombras e outros efeitos são preservados nas imagens dos slides?**

Sim. O Aspose.Slides renderiza sombras, transparência e outros efeitos gráficos suportados nas imagens dos slides.