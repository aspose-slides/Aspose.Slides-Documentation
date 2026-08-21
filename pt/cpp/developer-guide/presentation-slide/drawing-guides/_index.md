---
title: Gerenciar Guias de Desenho em Apresentações em C++
linktitle: Guias de Desenho
type: docs
weight: 85
url: /pt/cpp/drawing-guides/
keywords:
- guia de desenho
- guia horizontal
- guia vertical
- guia de alinhamento
- visualização de slide
- slide mestre
- slide de layout
- mestre de notas
- mestre de folhetos
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Adicione, acesse e limpe guias de desenho horizontais e verticais em apresentações do PowerPoint usando Aspose.Slides para C++."
---
## **Visão geral**

Guias de desenho são linhas horizontais e verticais ajustáveis que ajudam os usuários a alinhar formas de maneira consistente ao editar uma apresentação no PowerPoint. Elas são especialmente úteis quando um aplicativo gera uma apresentação que será refinada manualmente posteriormente: o aplicativo pode salvar as mesmas ajudas de alinhamento que os autores devem seguir ao adicionar ou mover conteúdo.

Guias de desenho são auxílios de edição, não conteúdo de slide. Elas não aparecem em uma apresentação de slides ou na saída renderizada. Aspose.Slides for C++ as expõe por meio da interface [IDrawingGuidesCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idrawingguidescollection/) . Um guia é representado por [IDrawingGuide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idrawingguide/) e possui uma orientação, uma posição e uma cor.

A posição é medida em pontos a partir do canto superior esquerdo do slide ou mestre relevante. Um guia vertical usa uma coordenada horizontal, normalmente entre zero e a largura do slide. Um guia horizontal usa uma coordenada vertical, normalmente entre zero e a altura do slide.

## **Adicionar guias à visualização de slide**

Use [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) para gerenciar os guias exibidos ao editar slides normais. Chame [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idrawingguidescollection/add/) com um valor [Orientation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/orientation/) e uma posição em pontos.

O exemplo a seguir adiciona um guia vertical à direita do centro do slide e um guia horizontal abaixo dele:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/IViewProperties.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

guides->Add(Orientation::Vertical, slideSize.get_Width() / 2 + 12.5f);
guides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 12.5f);

presentation->Save(u"drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Acessar guias de desenho**

O método [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idrawingguidescollection/get_count/) e o método [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idrawingguidescollection/idx_get/) fornecem acesso aos guias existentes. Os métodos [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idrawingguide/get_position/), e [IDrawingGuide::get_Color](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idrawingguide/get_color/) retornam as propriedades atuais de um guia. Seus respectivos métodos set podem alterar essas propriedades.

O exemplo a seguir lê os guias da visualização de slide da apresentação criada acima:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuide.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"drawing-guides.pptx");
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

for (int32_t index = 0; index < guides->get_Count(); index++)
{
    auto guide = guides->idx_get(index);
    System::Console::WriteLine(
        System::String::Format(
            u"Guide {0}: orientation = {1}, position = {2}, color = {3}",
            index,
            guide->get_Orientation(),
            guide->get_Position(),
            guide->get_Color()));
}

presentation->Dispose();
```

## **Adicionar guias a mestres e slides de layout**

Um mestre de slide e cada um de seus slides de layout podem ter suas próprias coleções de guias de desenho. Use [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslide/get_drawingguides/) para um slide mestre e [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutslide/get_drawingguides/) para um slide de layout.

O exemplo a seguir adiciona um guia vertical ao primeiro slide mestre e um guia horizontal ao primeiro slide de layout:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto masterGuides = presentation->get_Master(0)->get_DrawingGuides();
auto layoutGuides = presentation->get_LayoutSlide(0)->get_DrawingGuides();

masterGuides->Add(Orientation::Vertical, slideSize.get_Width() / 2 - 20.0f);
layoutGuides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 20.0f);

presentation->Save(u"master-layout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Adicionar guias a mestres de notas e folhetos**

Mestres de notas e mestres de folhetos também suportam guias de desenho. Use [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasternotesslide/get_drawingguides/) e [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) para acessar suas coleções. Se uma apresentação não contiver um desses mestres, [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) ou [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) cria o mestre padrão e o devolve.

O exemplo a seguir adiciona um guia horizontal a um mestre de notas e um guia vertical a um mestre de folhetos:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/INotesSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto notesSize = presentation->get_NotesSize()->get_Size();
auto notesMaster = presentation->get_MasterNotesSlideManager()->SetDefaultMasterNotesSlide();
auto handoutMaster = presentation->get_MasterHandoutSlideManager()->SetDefaultMasterHandoutSlide();

notesMaster->get_DrawingGuides()->Add(Orientation::Horizontal, notesSize.get_Height() / 2 + 50.0f);
handoutMaster->get_DrawingGuides()->Add(Orientation::Vertical, notesSize.get_Width() / 2 - 50.0f);

presentation->Save(u"notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Limpar guias de desenho**

Chame [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idrawingguidescollection/clear/) para remover todos os guias de uma coleção específica. Limpar uma coleção não afeta os guias armazenados em outro escopo.

O exemplo a seguir limpa os guias da visualização de slide e todos os guias nos mestres de slide, slides de layout, o mestre de notas e o mestre de folhetos sem criar mestres ausentes:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation-with-guides.pptx");

presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides()->Clear();

for (auto&& masterSlide : presentation->get_Masters())
{
    masterSlide->get_DrawingGuides()->Clear();
}

for (auto&& layoutSlide : presentation->get_LayoutSlides())
{
    layoutSlide->get_DrawingGuides()->Clear();
}

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    notesMaster->get_DrawingGuides()->Clear();
}

auto handoutMaster = presentation->get_MasterHandoutSlideManager()->get_MasterHandoutSlide();
if (handoutMaster != nullptr)
{
    handoutMaster->get_DrawingGuides()->Clear();
}

presentation->Save(u"presentation-without-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Os guias de desenho aparecem em uma apresentação de slides ou em imagens exportadas?**

Não. Guias de desenho são auxílios de alinhamento para edição e não são renderizados como conteúdo da apresentação.

**Um guia de desenho pode ser adicionado diretamente a um slide normal individual?**

Os guias de edição de slide normal são armazenados nas propriedades de visualização de slide da apresentação. Coleções de guias separadas estão disponíveis para mestres de slide, slides de layout, mestres de notas e mestres de folhetos.

**Quais unidades são usadas para as posições dos guias?**

As posições são especificadas em pontos, onde 72 pontos equivalem a uma polegada. Posicoes verticais são medidas a partir da borda esquerda, e posições horizontais são medidas a partir da borda superior.

**Limpar guias de desenho remove formas ou altera o conteúdo do slide?**

Não. O método `Clear` remove apenas os guias na coleção selecionada. Formas e outros conteúdos do slide permanecem inalterados.