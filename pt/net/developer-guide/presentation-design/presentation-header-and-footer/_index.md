---
title: Gerenciar cabeçalhos e rodapés de apresentação em .NET
linktitle: Cabeçalho e Rodapé
type: docs
weight: 140
url: /pt/net/presentation-header-and-footer/
keywords:
- cabeçalho
- texto do cabeçalho
- rodapé
- texto do rodapé
- definir cabeçalho
- definir rodapé
- folheto
- anotações
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a gerenciar os marcadores de posição de rodapé, data/hora, número do slide e cabeçalho em slides, páginas de anotações e folhetos com Aspose.Slides para .NET."
---
## **Visão geral**

O PowerPoint usa diferentes marcadores de posição de cabeçalho e rodapé dependendo do tipo de página. O Aspose.Slides para .NET permite controlar o texto e a visibilidade desses marcadores por meio das interfaces de gerenciamento de cabeçalho/rodapé.

Os marcadores de posição disponíveis dependem do escopo:

| Escopo | Cabeçalho | Rodapé | Data/hora | Número do slide/página |
|---|---|---|---|---|
| Slide regular | Não | Sim | Sim | Sim |
| Mestre de anotações | Sim | Sim | Sim | Sim |
| Slide de anotações | Sim | Sim | Sim | Sim |
| Mestre de folhetos | Sim | Sim | Sim | Sim |

Um slide de apresentação regular não possui marcador de posição de cabeçalho. Cabeçalhos estão disponíveis em páginas de anotações e folhetos. Para slides regulares, use os marcadores de rodapé, data/hora e número do slide.

O escopo de uma alteração depende do gerenciador que você usar. A interface [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/net/aspose.slides/islideheaderfootermanager/) controla um slide regular. A interface [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/net/aspose.slides/inotesslideheaderfootermanager/) controla um slide de anotações. Gerenciadores de mestre e layout também podem propagar configurações para slides dependentes, enquanto a interface [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterhandoutslideheaderfootermanager/) controla o mestre de folhetos.

## **Definir Rodapé, Data/Hora e Números de Slide em Slides Regulares**

Para slides regulares, o fluxo básico é acessar o gerenciador de cabeçalho/rodapé de cada slide, definir o texto do rodapé e da data/hora, habilitar os marcadores de posição necessários e salvar a apresentação. Os números de slide são gerados pela apresentação, portanto você só precisa controlar a visibilidade deles.

Use [`SetFooterText`](https://reference.aspose.com/slides/pt/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) e [`SetDateTimeText`](https://reference.aspose.com/slides/pt/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) para definir texto, e use [`SetFooterVisibility`](https://reference.aspose.com/slides/pt/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/pt/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) e [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/pt/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) para mostrar os marcadores correspondentes.

O exemplo completo a seguir aplica o mesmo rodapé, texto de data/hora e visibilidade de número de slide a todos os slides regulares:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

Se precisar atualizar apenas um slide, acesse esse slide diretamente através da coleção [`Slides`](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/slides/pt/) em vez de iterar por toda a coleção.

## **Definir Cabeçalhos e Rodapés no Mestre de Anotações**

O mestre de anotações define a formatação comum e o comportamento dos marcadores de posição para páginas de anotações. Use a interface [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/net/aspose.slides/imasternotesslideheaderfootermanager/) quando quiser alterar apenas o próprio mestre de anotações.

O exemplo a seguir define cabeçalho, rodapé e texto de data/hora no mestre de anotações e torna todos os marcadores suportados visíveis nesse mestre:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

A propriedade [`MasterNotesSlide`](https://reference.aspose.com/slides/pt/net/aspose.slides/imasternotesslidemanager/masternotesslide/) retorna `null` quando a apresentação não contém um mestre de anotações.

## **Aplicar Configurações do Mestre de Anotações aos Slides de Anotações Filhos**

Um mestre de anotações pode aplicar configurações de cabeçalho e rodapé a ele próprio e a todos os slides de anotações dependentes. Use os métodos de propagação dedicados em [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/net/aspose.slides/imasternotesslideheaderfootermanager/) quando as mesmas configurações devem ser aplicadas em toda a hierarquia de anotações.

Por exemplo, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/pt/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) e [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/pt/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) atualizam o cabeçalho do mestre de anotações e todos os cabeçalhos filhos. Métodos equivalentes estão disponíveis para rodapés, data/hora e números de slide.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

Os métodos de propagação usados acima são [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/pt/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/pt/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/pt/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/pt/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) e [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/pt/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Definir Cabeçalhos e Rodapés em um Slide de Anotações Individual**

Um slide de anotações pertence a um slide regular específico. Use a interface [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/net/aspose.slides/inotesslideheaderfootermanager/) quando quiser personalizar apenas aquela página de anotações.

O método [`AddNotesSlide`](https://reference.aspose.com/slides/pt/net/aspose.slides/inotesslidemanager/addnotesslide/) retorna o slide de anotações para o slide atual e cria um caso ainda não exista. O exemplo a seguir configura a página de anotações associada ao primeiro slide da apresentação:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

Se primeiro propagar as configurações do mestre de anotações e depois alterar um slide de anotações individual, as configurações posteriores por slide permitem personalizar aquela página de anotações de forma independente.

## **Definir Cabeçalhos e Rodapés no Mestre de Folhetos**

Páginas de folhetos usam o mestre de folhetos para seus marcadores de cabeçalho, rodapé, data/hora e número de página. Diferentemente das páginas de anotações, as configurações de folhetos são gerenciadas pelo mestre de folhetos e não por slides de folhetos individuais.

Use a propriedade [`MasterHandoutSlide`](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) para acessar o mestre de folhetos. Se ele não estiver presente, chame [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) para criar o mestre de folhetos padrão.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **Entender Escopo e Herança**

Escolha o gerenciador de cabeçalho/rodapé que corresponde ao escopo que você deseja alterar:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/net/aspose.slides/islideheaderfootermanager/) altera as configurações de rodapé, data/hora e número de slide para um slide regular.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutslideheaderfootermanager/) controla um slide de layout e pode propagar configurações suportadas para slides dependentes.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslideheaderfootermanager/) controla um mestre de slide regular e pode propagar configurações suportadas para slides dependentes.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/net/aspose.slides/imasternotesslideheaderfootermanager/) controla o mestre de anotações e pode propagar configurações para todos os slides de anotações dependentes.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/net/aspose.slides/inotesslideheaderfootermanager/) altera um slide de anotações e oferece um marcador de cabeçalho além de rodapé, data/hora e número de slide.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterhandoutslideheaderfootermanager/) altera o mestre de folhetos e oferece suporte aos quatro tipos de marcadores.

Use a propagação a partir de um mestre ou layout quando a mesma configuração deve ser aplicada em toda a hierarquia. Use um gerenciador de slide individual ou de slide de anotações quando precisar de uma configuração local para uma única página.

## **Perguntas frequentes**

**Posso adicionar um cabeçalho a um slide regular?**

Não. O PowerPoint não define um marcador de posição de cabeçalho para slides regulares. Em slides regulares, use os marcadores de rodapé, data/hora e número de slide. Marcadores de cabeçalho estão disponíveis em páginas de anotações e folhetos.

**E se um marcador de rodapé, data/hora ou número de slide não estiver visível?**

Use o gerenciador de cabeçalho/rodapé correspondente para verificar sua visibilidade e habilitá‑lo quando necessário. Por exemplo, [`IsFooterVisible`](https://reference.aspose.com/slides/pt/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) indica se um marcador de rodapé está presente, e [`SetFooterVisibility`](https://reference.aspose.com/slides/pt/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) altera sua visibilidade.

**Como inicio a numeração de slides a partir de um valor diferente de 1?**

Defina a propriedade [`FirstSlideNumber`](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/firstslidenumber/) da apresentação. Os marcadores de número de slide então usarão a sequência de numeração atualizada.

**O que acontece com cabeçalhos e rodapés ao exportar para PDF, imagens ou HTML?**

Elementos de cabeçalho e rodapé visíveis são renderizados junto ao restante do conteúdo da apresentação no formato de saída. Sua aparência depende do tipo de página sendo exportado e das configurações de visibilidade dos marcadores correspondentes.