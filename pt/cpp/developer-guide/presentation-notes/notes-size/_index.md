---
title: Alterar Tamanho e Orientação da Página de Anotações em C++
linktitle: Tamanho da Página de Anotações
type: docs
weight: 10
url: /pt/cpp/notes-size/
keywords:
- tamanho da página de anotações
- orientação das anotações
- anotações em paisagem
- anotações em retrato
- tamanho do folheto
- PowerPoint
- apresentação
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Leia e altere as dimensões da página de anotações no Aspose.Slides para C++, altere a orientação, verifique os tamanhos salvos e exporte anotações ou folhetos para PDF e imagens."
---
## **Visão geral**

Use [Presentation::get_NotesSize](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_notessize/) para acessar as configurações da página de anotações da apresentação. Ele retorna um objeto [INotesSize](https://reference.aspose.com/slides/pt/cpp/aspose.slides/inotessize/) cujo método [set_Size](https://reference.aspose.com/slides/pt/cpp/aspose.slides/inotessize/set_size/) define as dimensões. Embora o objeto de configurações de anotações não possa ser substituído, você pode alterar seu tamanho.

A largura e a altura são especificadas em **pontos**, com 72 pontos por polegada. Por exemplo, 900 × 600 pontos correspondem a 12,5 × 8⅓ polegadas. Essas configurações se aplicam à apresentação, e não às anotações de um slide individual.

| Configuração | Objetivo |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_notessize/) | Controla as dimensões da página de anotações e as dimensões da página usadas na exportação de folhetos. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_slidesize/) | Controla as dimensões dos slides da apresentação regular por meio de [ISlideSize](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidesize/). |

Alterar qualquer uma das configurações não altera automaticamente a outra. Alterar a orientação da página de anotações também não gira os slides regulares. Consulte [Slide Size](/slides/pt/cpp/slide-size/) para redimensionar os slides regulares.

Os exemplos abaixo usam um `sample.pptx` existente. Para os exemplos de exportação, use uma apresentação com pelo menos um slide contendo notas do apresentador. Cada exemplo pode ser executado de forma independente.

## **Ler o Tamanho e a Orientação da Página de Anotações**

Leia a largura e a altura e compare-as para determinar a orientação: uma página mais larga é paisagem, uma página mais alta é retrato, e dimensões iguais descrevem uma página quadrada. Este exemplo exibe as dimensões reais em pontos, sem assumir um tamanho de papel padrão.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **Alterar para Paisagem sem Mudar o Tamanho do Papel**

Para mudar apenas a orientação, troque a largura e a altura existentes. Isso preserva os comprimentos de ambos os lados, inclusive os de um tamanho de papel personalizado. A condição abaixo impede que uma página já em paisagem seja revertida para retrato e deixa uma página quadrada inalterada.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

Para orientação retrato, use a mesma atribuição quando `size.get_Width() > size.get_Height()`. Não substitua as dimensões de A4 ou Letter, a menos que também deseje alterar o tamanho do papel.

## **Definir e Verificar um Tamanho de Página de Anotações Personalizado**

Atribua ambas as dimensões juntas e, em seguida, use [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/) para gravar a apresentação. Este exemplo define uma página em paisagem de 900 × 600 pontos, salva‑a como PPTX e abre o arquivo salvo novamente para verificar os valores persistidos. A comparação permite uma tolerância de 0,01 ponto para valores de ponto flutuante; isso não garante precisão para todos os formatos de arquivo.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

O resultado esperado é `900 x 600 points` e `Size preserved: True`. Verificar uma apresentação recém‑aberta confirma o arquivo salvo, em vez de apenas as configurações em memória.

## **Exportar Anotações e Folhetos**

As dimensões da página definem a área disponível para layouts de anotações ou folhetos. Elas não habilitam esses layouts por si só: também configure as opções de exportação. A exportação de slides regulares continua a usar as dimensões dos slides.

### **Exportar Anotações para PDF e PNG**

Atribua [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/notescommentslayoutingoptions/) a [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) para incluir anotações no PDF. Este exemplo também renderiza o primeiro slide com anotações para PNG usando [Slide::GetImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slide/getimage/) e [RenderingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/renderingoptions/).

O modo [BottomTruncated](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/notespositions/) mantém as anotações em uma única página; anotações que não cabem podem ser truncadas. O PDF usa páginas de 900 × 600 pontos. Na escala de imagem de 1 × 1 usada abaixo, o PNG tem 900 × 600 pixels. Pontos descrevem a geometria da página; pixels descrevem a saída raster, cujas dimensões também dependem da escala de renderização.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

Para exportação em PDF com anotações longas, [BottomFull](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/notespositions/) permite páginas adicionais conforme necessário. Não use esse modo com a chamada de imagem de slide único acima, que não o suporta. Após redimensionar, inspecione a saída para anotações recortadas e o posicionamento de objetos notes‑master existentes; mudar apenas as dimensões da página não deve ser considerado garantia de que todo o conteúdo caberá. Consulte [Convert PowerPoint to PDF with Notes](/slides/pt/cpp/convert-powerpoint-to-pdf-with-notes/) para saber mais sobre exportação de anotações.

### **Exportar Folhetos para PDF**

Use [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/handoutlayoutingoptions/) para várias miniaturas de slide em uma única página. O exemplo a seguir define uma página de 900 × 600 pontos e usa [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/handouttype/) para organizar até quatro slides por página. O preset horizontal controla a ordem dos slides; a orientação da página vem da sua largura e altura.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

Alterar o tamanho da página altera a área disponível para a grade de folhetos sem mudar as dimensões dos slides de origem. Para imagens de folhetos, use [Presentation::GetImages](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/getimages/) com o layout de folhetos, em vez do método de imagem de um slide individual. No Aspose.Slides, a renderização de folhetos em nível de apresentação usa as dimensões da página de anotações, enquanto a chamada de imagem de slide individual não produz a página de folheto. Consulte [Handout Mode](/slides/pt/cpp/convert-powerpoint-in-handout-mode/) para opções de layout.

## **Tamanho da Página em Visualizadores, Exportação e Impressão**

Mantenha o tamanho da apresentação armazenado, o tamanho da página exportada e o tamanho do papel impresso distintos:

- **Visualizadores de apresentação:** Um visualizador pode exibir ou imprimir anotações usando suas próprias regras de layout. Se outro aplicativo salvar o arquivo, reabra‑o e verifique as dimensões novamente; a conversão de formato desse aplicativo pode normalizá‑las.
- **Formatos de exportação:** Os exemplos de PDF de anotações e folhetos acima usam as dimensões de página configuradas. Imagens raster utilizam dimensões de pixel inteiras e uma escala de renderização, portanto valores fracionários de ponto podem ser arredondados na saída da imagem. Exportar slides regulares não aplica o tamanho da página de anotações.
- **Drivers de impressora:** A seleção de papel, rotação automática e configurações de ajustar à página podem alterar a saída física sem mudar as dimensões armazenadas na apresentação ou no PDF. Para um tamanho de papel específico, ajuste as configurações da impressora e verifique a visualização de impressão.

## **FAQ**

**Posso definir o tamanho das anotações para apenas um slide?**

O tamanho da página de anotações é uma configuração ao nível da apresentação. Slides individuais podem ter conteúdo de anotações diferente, mas essa propriedade não oferece um tamanho de página separado para cada slide.

**Por que mudar a orientação das anotações não mudou meus slides?**

As páginas de anotações e os slides regulares têm dimensões independentes. Use as configurações de tamanho de slide regular quando quiser redimensionar os próprios slides.

**Por que meu resultado salvo ou impresso tem um tamanho diferente?**

Primeiro reabra a apresentação salva e compare as dimensões das anotações. Se elas mudaram, verifique se salvar ou converter o arquivo em outro aplicativo alterou as configurações da página. Se não, verifique o layout de exportação, a escala da imagem, as configurações do visualizador e a seleção de papel da impressora.