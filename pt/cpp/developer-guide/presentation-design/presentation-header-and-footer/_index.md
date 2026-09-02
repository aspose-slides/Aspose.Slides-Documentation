---
title: Gerenciar cabeçalhos e rodapés de apresentações em C++
linktitle: Cabeçalho e Rodapé
type: docs
weight: 140
url: /pt/cpp/presentation-header-and-footer/
keywords:
- cabeçalho
- texto do cabeçalho
- rodapé
- texto do rodapé
- definir cabeçalho
- definir rodapé
- folheto
- notas
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Saiba como gerenciar marcadores de posição de rodapé, data/hora, número de slide e cabeçalho em slides, páginas de notas e folhetos com Aspose.Slides para C++."
---
## **Visão geral**

O PowerPoint usa diferentes marcadores de posição de cabeçalho e rodapé dependendo do tipo de página. O Aspose.Slides para C++ permite controlar o texto e a visibilidade desses marcadores de posição por meio de interfaces de gerenciador de cabeçalho/rodapé.

Os marcadores de posição disponíveis dependem do escopo:

| Escopo | Cabeçalho | Rodapé | Data/hora | Número de slide/página |
|---|---|---|---|---|
| Slide regular | Não | Sim | Sim | Sim |
| Mestre de notas | Sim | Sim | Sim | Sim |
| Slide de notas | Sim | Sim | Sim | Sim |
| Mestre de folheto | Sim | Sim | Sim | Sim |

Um slide de apresentação regular não possui um marcador de posição de cabeçalho. Cabeçalhos estão disponíveis em páginas de notas e folhetos. Para slides regulares, use os marcadores de posição de rodapé, data/hora e número de slide.

O escopo de uma alteração depende do gerenciador que você usa. A interface [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideheaderfootermanager/) controla um slide regular. A interface [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/inotesslideheaderfootermanager/) controla um slide de notas. Gerenciadores de mestre e layout também podem propagar configurações para slides dependentes, enquanto a interface [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) controla o mestre de folhetos.

## **Definir Rodapé, Data/Hora e Números de Slides em Slides Regulares**

Para slides regulares, o fluxo básico é acessar o gerenciador de cabeçalho/rodapé de cada slide, definir o texto do rodapé e da data/hora, habilitar os marcadores de posição necessários e salvar a apresentação. Os números de slide são gerados pela apresentação, portanto você só precisa controlar sua visibilidade.

Use [`SetFooterText`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) e [`SetDateTimeText`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) para definir texto, e use [`SetFooterVisibility`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/) e [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) para exibir os marcadores de posição correspondentes.

O exemplo completo a seguir aplica o mesmo rodapé, texto de data/hora e visibilidade do número de slide a todos os slides regulares:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

Se precisar atualizar apenas um slide, acesse esse slide diretamente através de [`Presentation::get_Slide`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_slide/) em vez de iterar por toda a coleção de slides.

## **Definir Cabeçalhos e Rodapés no Mestre de Notas**

O mestre de notas define formatação comum e comportamento dos marcadores de posição para páginas de notas. Use a interface [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasternotesslideheaderfootermanager/) quando quiser alterar somente o próprio mestre de notas.

O exemplo a seguir define cabeçalho, rodapé e texto de data/hora no mestre de notas e torna todos os marcadores de posição suportados visíveis nesse mestre:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

O método [`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) devolve `nullptr` quando a apresentação não contém um mestre de notas.

## **Aplicar Configurações do Mestre de Notas a Slides de Notas Filhos**

Um mestre de notas pode aplicar configurações de cabeçalho e rodapé a ele próprio e a todos os slides de notas dependentes. Use os métodos de propagação dedicados em [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasternotesslideheaderfootermanager/) quando as mesmas configurações devem ser aplicadas em toda a hierarquia de notas.

Por exemplo, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) e [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) atualizam o cabeçalho do mestre de notas e todos os cabeçalhos filhos. Métodos equivalentes estão disponíveis para rodapés, data/hora e números de slide.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

Os métodos de propagação usados acima são [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) e [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Definir Cabeçalhos e Rodapés em um Slide de Notas Individual**

Um slide de notas pertence a um slide regular específico. Use sua interface [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/inotesslideheaderfootermanager/) quando quiser personalizar somente essa página de notas.

O método [`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/inotesslidemanager/addnotesslide/) devolve o slide de notas para o slide atual e cria um caso ainda não exista. O exemplo a seguir configura a página de notas associada ao primeiro slide da apresentação:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

Se primeiro propagar as configurações do mestre de notas e depois alterar um slide de notas individual, as configurações posteriores por slide permitem personalizar essa página de notas de forma independente.

## **Definir Cabeçalhos e Rodapés no Mestre de Folhetos**

Páginas de folhetos usam o mestre de folhetos para seus marcadores de posição de cabeçalho, rodapé, data/hora e número de página. Diferentemente das páginas de notas, as configurações de folheto são gerenciadas através do mestre de folhetos e não por slides individuais.

Use [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) para acessar o mestre de folhetos. Se ele não estiver presente, chame [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) para criar o mestre de folhetos padrão.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **Entender Escopo e Herança**

Escolha o gerenciador de cabeçalho/rodapé que corresponde ao escopo que você deseja alterar:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islideheaderfootermanager/) altera as configurações de rodapé, data/hora e número de slide para um slide regular.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutslideheaderfootermanager/) controla um slide de layout e pode propagar configurações suportadas para slides dependentes.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslideheaderfootermanager/) controla um mestre de slide regular e pode propagar configurações suportadas para slides dependentes.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasternotesslideheaderfootermanager/) controla o mestre de notas e pode propagar configurações para todos os slides de notas dependentes.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/inotesslideheaderfootermanager/) altera um slide de notas e suporta um marcador de posição de cabeçalho além de rodapé, data/hora e número de slide.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) altera o mestre de folhetos e suporta os quatro tipos de marcadores de posição.

Use a propagação a partir de um mestre ou layout quando a mesma configuração precisar ser aplicada em toda a sua hierarquia. Use um gerenciador de slide individual ou de slide de notas quando precisar de uma configuração local para uma única página.

## **FAQ**

**Posso adicionar um cabeçalho a um slide regular?**

Não. O PowerPoint não define um marcador de posição de cabeçalho para slides regulares. Em slides regulares, use os marcadores de posição de rodapé, data/hora e número de slide. Marcadores de posição de cabeçalho estão disponíveis em páginas de notas e folhetos.

**E se um marcador de posição de rodapé, data/hora ou número de slide não estiver visível?**

Use o gerenciador de cabeçalho/rodapé correspondente para verificar sua visibilidade e habilitá‑la quando necessário. Por exemplo, [`get_IsFooterVisible`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) indica se um marcador de posição de rodapé está presente, e [`SetFooterVisibility`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) altera sua visibilidade.

**Como iniciar a numeração de slides a partir de um valor diferente de 1?**

Use [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/set_firstslidenumber/) para definir o número do primeiro slide. Os marcadores de posição de número de slide então usarão a sequência de numeração atualizada.

**O que acontece com cabeçalhos e rodapés ao exportar para PDF, imagens ou HTML?**

Elementos de cabeçalho e rodapé visíveis são renderizados junto com o restante do conteúdo da apresentação no formato de saída. Sua aparência depende do tipo de página que está sendo exportado e das configurações de visibilidade dos marcadores de posição correspondentes.