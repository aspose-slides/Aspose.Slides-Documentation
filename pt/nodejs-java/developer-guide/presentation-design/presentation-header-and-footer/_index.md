---
title: Gerenciar cabeçalhos e rodapés de apresentação em JavaScript
linktitle: Cabeçalho e Rodapé
type: docs
weight: 140
url: /pt/nodejs-java/presentation-header-and-footer/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Saiba como gerenciar marcadores de rodapé, data/hora, número de slide e cabeçalho em slides, páginas de notas e folhetos com Aspose.Slides para Node.js via Java."
---
## **Visão geral**

O PowerPoint usa diferentes marcadores de cabeçalho e rodapé dependendo do tipo de página. Aspose.Slides for Node.js via Java permite controlar o texto e a visibilidade desses marcadores através das classes de gerenciamento de cabeçalho/rodapé.

Os marcadores disponíveis dependem do escopo:

| Escopo | Cabeçalho | Rodapé | Data/hora | Número do slide/página |
|---|---|---|---|---|
| Slide regular | Não | Sim | Sim | Sim |
| Mestre de notas | Sim | Sim | Sim | Sim |
| Slide de notas | Sim | Sim | Sim | Sim |
| Mestre de folheto | Sim | Sim | Sim | Sim |

Um slide de apresentação regular não possui um marcador de cabeçalho. Os cabeçalhos estão disponíveis em páginas de notas e folhetos. Para slides regulares, use os marcadores de rodapé, data/hora e número do slide.

O escopo de uma alteração depende do gerenciador que você usa. A [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideheaderfootermanager/) controla um slide regular. A [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notesslideheaderfootermanager/) controla um slide de notas. Gerenciadores mestre e layout também podem propagar configurações para slides dependentes, enquanto a [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) controla o mestre de folhetos.

## **Definir rodapé, data/hora e números de slide em Slides Regulares**

Para slides regulares, o fluxo básico consiste em acessar o gerenciador de cabeçalho/rodapé de cada slide, definir o texto do rodapé e da data/hora, ativar os marcadores necessários e salvar a apresentação. Os números de slide são gerados pela apresentação, portanto você só precisa controlar sua visibilidade.

Use [`setFooterText`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) e [`setDateTimeText`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) para definir o texto, e use [`setFooterVisibility`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) e [`setSlideNumberVisibility`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) para exibir os marcadores correspondentes.

O exemplo completo a seguir aplica o mesmo rodapé, texto de data/hora e visibilidade do número de slide a todos os slides regulares:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se precisar atualizar apenas um slide, acesse esse slide diretamente através do método [`getSlides`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getslides/) em vez de iterar por toda a coleção.

## **Definir cabeçalhos e rodapés no Mestre de Notas**

O mestre de notas define formatação comum e comportamento dos marcadores para páginas de notas. Use a [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) quando quiser alterar apenas o próprio mestre de notas.

O exemplo a seguir define cabeçalho, rodapé e texto de data/hora no mestre de notas e torna todos os marcadores suportados visíveis nesse mestre:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O método [`getMasterNotesSlide`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) retorna `null` quando a apresentação não contém um mestre de notas.

## **Aplicar Configurações do Mestre de Notas a Slides de Notas Filhos**

Um mestre de notas pode aplicar as configurações de cabeçalho e rodapé a ele próprio e a todos os slides de notas dependentes. Use os métodos de propagação dedicados em [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) quando as mesmas configurações devem ser aplicadas em toda a hierarquia de notas.

Por exemplo, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) e [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) atualizam o cabeçalho do mestre de notas e todos os cabeçalhos filhos. Métodos equivalentes estão disponíveis para rodapés, data/hora e números de slide.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Os métodos de propagação usados acima são [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) e [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Definir cabeçalhos e rodapés em um Slide de Notas Individual**

Um slide de notas pertence a um slide regular específico. Use sua [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notesslideheaderfootermanager/) quando quiser personalizar apenas aquela página de notas.

O método [`addNotesSlide`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) retorna o slide de notas para o slide atual e cria um caso ainda não exista. O exemplo a seguir configura a página de notas associada ao primeiro slide da apresentação:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se você primeiro propagar as configurações do mestre de notas e depois alterar um slide de notas individual, as configurações posteriores por slide permitem personalizar aquela página de notas de forma independente.

## **Definir cabeçalhos e rodapés no Mestre de Folhetos**

As páginas de folhetos usam o mestre de folhetos para seus marcadores de cabeçalho, rodapé, data/hora e número de página. Diferentemente das páginas de notas, as configurações de folheto são gerenciadas através do mestre de folhetos e não por slides de folheto individuais.

Use [`getMasterHandoutSlide`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) para acessar o mestre de folhetos. Se ele não estiver presente, chame [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) para criar o mestre de folhetos padrão.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Entender Escopo e Herança**

Escolha o gerenciador de cabeçalho/rodapé que corresponde ao escopo que você deseja alterar:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideheaderfootermanager/) altera as configurações de rodapé, data/hora e número de slide para um slide regular.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) controla um slide de layout e pode propagar configurações suportadas para slides dependentes.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslideheaderfootermanager/) controla um mestre de slide regular e pode propagar configurações suportadas para slides dependentes.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) controla o mestre de notas e pode propagar configurações para todos os slides de notas dependentes.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notesslideheaderfootermanager/) altera um slide de notas e suporta um marcador de cabeçalho além de rodapé, data/hora e número de slide.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) altera o mestre de folhetos e suporta os quatro tipos de marcadores.

Use a propagação a partir de um mestre ou layout quando a mesma configuração deve ser aplicada em toda a hierarquia. Use um gerenciador de slide individual ou de slide de notas quando precisar de uma configuração local para uma única página.

## **FAQ**

**Posso adicionar um cabeçalho a um slide regular?**

Não. O PowerPoint não define um marcador de cabeçalho para slides regulares. Em slides regulares, use os marcadores de rodapé, data/hora e número do slide. Os marcadores de cabeçalho estão disponíveis em páginas de notas e folhetos.

**E se um marcador de rodapé, data/hora ou número de slide não estiver visível?**

Use o gerenciador de cabeçalho/rodapé correspondente para verificar sua visibilidade e habilitá-la quando necessário. Por exemplo, [`isFooterVisible`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) informa se um marcador de rodapé está presente, e [`setFooterVisibility`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) altera sua visibilidade.

**Como iniciar a numeração de slides a partir de um valor diferente de 1?**

Chame o método [`setFirstSlideNumber`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) da apresentação. Os marcadores de número de slide então usarão a sequência de numeração atualizada.

**O que acontece com cabeçalhos e rodapés ao exportar para PDF, imagens ou HTML?**

Os elementos de cabeçalho e rodapé visíveis são renderizados junto com o restante do conteúdo da apresentação no formato de saída. Sua aparência depende do tipo de página que está sendo exportado e das configurações de visibilidade dos marcadores correspondentes.