---
title: Aplicar ou Alterar Layouts de Slide em C++
linktitle: Layout de Slide
type: docs
weight: 60
url: /pt/cpp/slide-layout/
keywords:
- layout de slide
- layout de conteúdo
- marcador de posição
- design de apresentação
- design de slide
- layout não usado
- visibilidade do rodapé
- slide de título
- título e conteúdo
- cabeçalho de seção
- dois conteúdos
- comparação
- apenas título
- layout em branco
- conteúdo com legenda
- imagem com legenda
- título e texto vertical
- título vertical e texto
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Aplicar, criar e modificar layouts de slide no Aspose.Slides para C++, adicionar marcadores de posição, remover layouts não usados e controlar a visibilidade do rodapé."
---
## **Visão geral**

Um layout de slide define as posições e formatação de marcadores de posição como títulos, texto, imagens, gráficos e tabelas. Aplicar um layout fornece aos slides uma estrutura consistente, permitindo que cada slide contenha seu próprio conteúdo.

- **Slide de Título**: Contém marcadores de posição de título e subtítulo.  
- **Título e Conteúdo**: Contém um marcador de posição de título e um marcador de posição de conteúdo de uso geral.  
- **Em Branco**: Não contém marcadores de posição de conteúdo e é útil quando cada forma será posicionada manualmente.

## **Entenda a Herança de Layout**

Uma apresentação tem três níveis relacionados:

1. Um [slide mestre](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslide/) define o tema, formatação compartilhada, planos de fundo e objetos comuns.  
2. Um [slide de layout](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutslide/) pertence a um mestre e define um arranjo específico de marcadores de posição.  
3. Um [slide normal](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/) usa um layout e armazena o conteúdo inserido para esse slide.

Um slide normal herda o tema e a formatação do seu layout, e o layout herda do seu mestre. Um valor definido diretamente em um slide normal substitui o valor herdado naquele nível. Quando um slide normal é criado, suas formas de marcador de posição são geradas a partir do layout selecionado, enquanto o conteúdo inserido nesses marcadores pertence ao slide normal.

Adicione os marcadores de posição necessários a um layout antes de criar slides a partir dele. Adicionar outro marcador de posição a um layout posteriormente não adiciona automaticamente a forma correspondente aos slides normais existentes.

Essa relação tem duas consequências importantes:

- Alterar a formatação herdada ou a geometria dos marcadores de posição existentes em um layout pode atualizar todos os slides que dependem dele. Antes de editar um layout que já está em uso, inspecione seus slides dependentes e revise a apresentação resultante.  
- Um layout que ainda é usado por um slide não pode ser removido. Reatribua seus slides dependentes a outro layout primeiro, ou remova apenas os layouts não utilizados.

Para mais informações sobre o nível superior dessa hierarquia, veja [Mestre de Slides](/slides/pt/cpp/slide-master/).

## **Selecione e Aplique um Layout de Slide**

Use um tipo de layout quando a apresentação segue definições padrão de layouts do PowerPoint. Os nomes dos layouts são editáveis pelo usuário e podem ser localizados, portanto a seleção baseada em nome é menos confiável a menos que você controle o modelo fonte.

O exemplo a seguir procura **Title and Content** no primeiro mestre. Se esse layout não estiver disponível, ele recai deliberadamente para **Blank**. A segunda verificação nula é necessária porque uma apresentação pode conter apenas layouts personalizados. O layout selecionado é então aplicado ao primeiro slide normal através do método [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/set_layoutslide/).

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Alterar o layout de um slide não remove as formas comuns adicionadas diretamente ao slide. Contudo, posições dos marcadores, formatação herdada e a correspondência entre os marcadores existentes e o novo layout podem mudar, portanto inspecione o resultado ao alternar entre layouts substancialmente diferentes.

## **Adicionar um Slide de Layout**

Seleção e criação são operações separadas. O exemplo anterior seleciona um layout existente; ele não cria um. Para criar um layout, chame o método [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterlayoutslidecollection/add/) na coleção de layouts do mestre de destino.

O exemplo a seguir sempre adiciona um novo layout **Title and Content** chamado `Report Title and Content`, então adiciona um slide normal baseado nele. Os nomes dos layouts devem ser exclusivos dentro da coleção.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Adicione um layout somente quando o modelo realmente precisar de outra estrutura reutilizável. Se já existir um layout adequado, selecione‑o e reutilize‑o em vez de criar um duplicado.

## **Adicionar Marcadores de Posição a um Slide de Layout**

O método [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) fornece um [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutplaceholdermanager/) para adicionar formas de marcador de posição a um layout.

| Marcador de Posição do PowerPoint | Método `ILayoutPlaceholderManager` |
| --------------------------------- | ----------------------------------- |
| ![Conteúdo](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Conteúdo (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Texto](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Texto (Vertical)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Imagem](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Gráfico](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Tabela](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Mídia](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Imagem Online](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

O exemplo a seguir verifica se o layout **Blank** existe, adiciona quatro marcadores a ele e então cria um slide normal que usa o layout modificado. A ordem é intencional: os marcadores são adicionados antes da criação do slide normal, permitindo que o Aspose.Slides gere as formas de marcador correspondentes nesse slide.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![Os marcadores de posição no slide de layout](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Alterar a formatação herdada ou a geometria dos marcadores de posição existentes no layout pode afetar slides dependentes. Um marcador de posição recém‑adicionado não é retroalimentado em slides normais existentes. Teste alterações de layout em uma cópia da apresentação e inspecione cada slide dependente.
{{% /alert %}}

## **Remover Slides de Layout Não Utilizados**

Use o método [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) para remover layouts que nenhum slide normal referencia. O método deixa intactos os layouts que ainda estão em uso.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para remover um layout específico, primeiro use seu método [get_HasDependingSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) ou [GetDependingSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutslide/getdependingslides/). Reatribua quaisquer slides dependentes antes de chamar [ILayoutSlide::Remove](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutslide/remove/). Tentar remover um layout em uso gera uma [PptxEditException](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pptxeditexception/).

## **Controlar a Visibilidade do Rodapé em um Slide de Layout**

Um layout tem seus próprios marcadores de posição de rodapé, número do slide e data/hora. Use o método [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) para controlar esses marcadores em um layout. Isso é útil quando, por exemplo, os layouts de conteúdo devem exibir rodapés, mas os layouts de título não.

O exemplo a seguir seleciona um layout com segurança e torna seus elementos de rodapé visíveis:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Controlar a Visibilidade do Rodapé em um Mestre e Seus Layouts Filhos**

Para aplicar configurações de rodapé consistentes em toda a hierarquia de mestres, use o método [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Os métodos de propagação de [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslideheaderfootermanager/) atuam no mestre e em seus slides de layout e slides normais dependentes; eles não visam apenas um slide normal.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Perguntas Frequentes**

**Qual é a diferença entre um slide mestre e um slide de layout?**

Um slide mestre define o tema da apresentação e a formatação compartilhada. Um slide de layout pertence a um mestre e define um arranjo reutilizável de marcadores de posição. Slides normais utilizam esses layouts e armazenam o conteúdo específico de cada slide.

**Posso copiar um slide de layout de uma apresentação para outra?**

Sim. Adicione uma cópia à coleção de destino com o método [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Ao copiar entre apresentações, verifique também fontes, temas, imagens e outros recursos usados pelo layout de origem.

**O que acontece quando modifico um layout que já está em uso?**

Slides dependentes herdam as alterações do layout, salvo se substituírem localmente a formatação ou os objetos afetados. A geometria dos marcadores e o estilo herdado podem mudar em muitos slides simultaneamente. Use [GetDependingSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutslide/getdependingslides/) para identificar os slides afetados antes de editar o layout.

**O que acontece se eu remover um layout que ainda está em uso?**

O Aspose.Slides lança uma [PptxEditException](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pptxeditexception/). Reatribua primeiro os slides dependentes ou use [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) para remover apenas os layouts sem referência.