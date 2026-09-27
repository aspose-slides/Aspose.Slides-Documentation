---
title: Criar apresentações em C++
linktitle: Criar apresentação
type: docs
weight: 10
url: /pt/cpp/create-presentation/
keywords:
- criar apresentação
- nova apresentação
- criar PPT
- novo PPT
- criar PPTX
- novo PPTX
- criar ODP
- novo ODP
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Crie apresentações em C++ com Aspose.Slides — produza arquivos PPT, PPTX e ODP, aproveite o suporte OpenDocument e salve-os programaticamente para resultados confiáveis."
---
## **Visão geral**

Este artigo mostra como criar uma apresentação no Aspose.Slides, adicionar uma caixa de texto ao seu primeiro slide e salvar o resultado como um arquivo. Uma breve FAQ ao final aborda perguntas comuns sobre formatos, modelos, dimensionamento de slides, unidades, uso de memória, multithreading, licenciamento, assinaturas digitais e suporte a VBA.  

Antes de começar, adicione o Aspose.Slides ao seu projeto: a partir do NuGet em um projeto Visual Studio no Windows, ou a partir do pacote ZIP com CMake no Linux. Veja [Instalação](/slides/pt/cpp/installation/).

## **Criar uma apresentação PowerPoint**

Para criar uma apresentação e colocar uma caixa de texto no seu primeiro slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/). Uma nova apresentação já contém um slide vazio.  
2. Recupere esse slide com o método [Presentation::get_Slide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_slide/) e seu índice, 0.  
3. Adicione um retângulo com o método [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/addautoshape/) e defina seu texto com o método [ITextFrame::set_Text](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/set_text/).  
4. Salve a apresentação como um arquivo PPTX usando o método [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

O canto superior esquerdo do retângulo está a 50 pontos da borda esquerda e 50 pontos da borda superior do slide, e o retângulo tem 400 pontos de largura e 100 pontos de altura. O programa salva *hello.pptx* no seu diretório de trabalho, com um slide que contém o retângulo e seu texto. Sem uma licença, o Aspose.Slides também adiciona uma marca d'água de avaliação a cada slide salvo; veja [Licenciamento](/slides/pt/cpp/licensing/).

## **Perguntas frequentes**

### Em quais formatos posso salvar uma nova apresentação?

Você pode salvar em [PPTX, PPT e ODP](/slides/pt/cpp/save-presentation/), e exportar para [PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/pt/cpp/convert-powerpoint-to-xps/), [HTML](/slides/pt/cpp/convert-powerpoint-to-html/), [SVG](/slides/pt/cpp/render-a-slide-as-an-svg-image/), e [imagens](/slides/pt/cpp/convert-powerpoint-to-png/), entre outros.

### Posso iniciar a partir de um modelo (POTX/POTM) e salvar como um PPTX normal?

Sim. Carregue o modelo e salve no formato desejado; os formatos POTX/POTM/PPTM e semelhantes [são suportados](/slides/pt/cpp/supported-file-formats/).

### Como controlo o tamanho e a proporção do slide ao criar uma apresentação?

Defina o [tamanho do slide](/slides/pt/cpp/slide-size/) (incluindo predefinições como 4:3 e 16:9 ou dimensões personalizadas) e escolha como o conteúdo deve ser dimensionado.

### Em quais unidades são medidos os tamanhos e coordenadas?

Em pontos: 1 polegada equivale a 72 unidades.

### Como lidar com apresentações muito grandes (com muitos arquivos de mídia) para reduzir o uso de memória?

Use as [estratégias de gerenciamento de BLOB](/slides/pt/cpp/manage-blob/), limite o armazenamento em memória aproveitando arquivos temporários e prefira fluxos de trabalho baseados em arquivos em vez de streams puramente em memória.

### Posso criar/salvar apresentações em paralelo?

Você não pode operar na mesma instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) a partir de [múltiplas threads](/slides/pt/cpp/multithreading/). Execute instâncias separadas e isoladas por thread ou processo.

### Como remover a marca d'água de avaliação e as limitações?

[Aplique uma licença](/slides/pt/cpp/licensing/) uma vez por processo. O XML da licença deve permanecer sem modificações, e a configuração da licença deve ser sincronizada se houver várias threads envolvidas.

### Posso assinar digitalmente o PPTX que crio?

Sim. As [assinaturas digitais](/slides/pt/cpp/digital-signature-in-powerpoint/) (adicionar e verificar) são suportadas para apresentações.

### Macros (VBA) são suportadas nas apresentações criadas?

Sim. Você pode [criar/editar projetos VBA](/slides/pt/cpp/presentation-via-vba/) e salvar arquivos habilitados para macro, como PPTM/PPSM.