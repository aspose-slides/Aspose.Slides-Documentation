---
title: Gerenciar cabeçalhos e rodapés da apresentação em PHP
linktitle: Cabeçalho e Rodapé
type: docs
weight: 140
url: /pt/php-java/presentation-header-and-footer/
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
- PHP
- Aspose.Slides
description: "Aprenda a gerenciar marcadores de posição de rodapé, data/hora, número do slide e cabeçalho em slides, páginas de anotações e folhetos com Aspose.Slides for PHP via Java."
---
## **Visão geral**

O PowerPoint usa diferentes marcadores de posição de cabeçalho e rodapé dependendo do tipo de página. Aspose.Slides for PHP via Java permite que você controle o texto e a visibilidade desses marcadores de posição por meio de classes de gerenciamento de cabeçalho/rodapé.

Os marcadores de posição disponíveis dependem do escopo:

| Escopo | Cabeçalho | Rodapé | Data/hora | Número do slide/página |
|---|---|---|---|---|
| Slide regular | Não | Sim | Sim | Sim |
| Mestre de anotações | Sim | Sim | Sim | Sim |
| Slide de anotações | Sim | Sim | Sim | Sim |
| Mestre de folhetos | Sim | Sim | Sim | Sim |

Um slide de apresentação normal não possui um marcador de posição de cabeçalho. Cabeçalhos estão disponíveis em páginas de anotações e folhetos. Para slides regulares, use os marcadores de posição de rodapé, data/hora e número do slide.

O escopo de uma alteração depende do gerenciador que você usa. A classe [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideheaderfootermanager/) controla um slide regular. A classe [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notesslideheaderfootermanager/) controla um slide de anotações. Gerenciadores de mestre e layout também podem propagar configurações para slides dependentes, enquanto a classe [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) controla o mestre de folhetos.

## **Definir rodapé, data/hora e números de slide em slides regulares**

Para slides regulares, o fluxo básico é acessar o gerenciador de cabeçalho/rodapé de cada slide, definir o texto do rodapé e da data/hora, habilitar os marcadores de posição necessários e salvar a apresentação. Os números de slide são gerados pela apresentação, portanto você só precisa controlar sua visibilidade.

Use [`setFooterText`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) e [`setDateTimeText`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) para definir o texto, e use [`setFooterVisibility`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) e [`setSlideNumberVisibility`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) para exibir os marcadores de posição correspondentes.

O exemplo completo a seguir aplica o mesmo rodapé, texto de data/hora e visibilidade de número de slide a todos os slides regulares:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Se precisar atualizar apenas um slide, acesse esse slide diretamente através do método [`getSlides`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/getslides/) em vez de iterar por toda a coleção.

## **Definir cabeçalhos e rodapés no mestre de anotações**

O mestre de anotações define formatação comum e comportamento de marcadores de posição para páginas de anotações. Use a classe [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masternotesslideheaderfootermanager/) quando desejar alterar apenas o próprio mestre de anotações.

O exemplo a seguir define cabeçalho, rodapé e texto de data/hora no mestre de anotações e torna todos os marcadores de posição suportados visíveis nesse mestre:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O método [`getMasterNotesSlide`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) retorna `null` quando a apresentação não contém um mestre de anotações.

## **Aplicar configurações do mestre de anotações a slides de anotações filhos**

Um mestre de anotações pode aplicar configurações de cabeçalho e rodapé a ele próprio e a todos os slides de anotações dependentes. Use os métodos de propagação dedicados em [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masternotesslideheaderfootermanager/) quando as mesmas configurações devam ser aplicadas em toda a hierarquia de anotações.

Por exemplo, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) e [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) atualizam o cabeçalho do mestre de anotações e todos os cabeçalhos filhos. Métodos equivalentes estão disponíveis para rodapés, data/hora e números de slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Os métodos de propagação usados acima são [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) e [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Definir cabeçalhos e rodapés em um slide de anotações individual**

Um slide de anotações pertence a um slide regular específico. Use sua classe [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notesslideheaderfootermanager/) quando quiser personalizar apenas aquela página de anotações.

O método [`addNotesSlide`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notesslidemanager/addnotesslide/) retorna o slide de anotações para o slide atual e cria um caso não exista. O exemplo a seguir configura a página de anotações associada ao primeiro slide da apresentação:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Se primeiro propagar as configurações do mestre de anotações e depois alterar um slide de anotações individual, as configurações posteriores por slide permitem personalizar aquela página de anotações de forma independente.

## **Definir cabeçalhos e rodapés no mestre de folhetos**

Páginas de folhetos usam o mestre de folhetos para seus marcadores de posição de cabeçalho, rodapé, data/hora e número de página. Ao contrário das páginas de anotações, as configurações de folhetos são gerenciadas através do mestre de folhetos e não por slides de folhetos individuais.

Use o método [`getMasterHandoutSlide`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) para acessar o mestre de folhetos. Se não estiver presente, chame [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) para criar o mestre de folhetos padrão.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Entender escopo e herança**

Escolha o gerenciador de cabeçalho/rodapé que corresponde ao escopo que você deseja alterar:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideheaderfootermanager/) altera as configurações de rodapé, data/hora e número de slide para um slide regular.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslideheaderfootermanager/) controla um slide de layout e pode propagar configurações suportadas para slides dependentes.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslideheaderfootermanager/) controla um mestre de slide regular e pode propagar configurações suportadas para slides dependentes.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masternotesslideheaderfootermanager/) controla o mestre de anotações e pode propagar configurações para todos os slides de anotações dependentes.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notesslideheaderfootermanager/) altera um slide de anotações e suporta um marcador de posição de cabeçalho além de rodapé, data/hora e número de slide.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) altera o mestre de folhetos e suporta os quatro tipos de marcadores de posição.

Use a propagação a partir de um mestre ou layout quando a mesma configuração deva ser aplicada em toda a sua hierarquia. Use um gerenciador de slide individual ou de slide de anotações quando precisar de uma configuração local para uma página.

## **FAQ**

**Posso adicionar um cabeçalho a um slide regular?**

Não. O PowerPoint não define um marcador de posição de cabeçalho para slides regulares. Em slides regulares, use os marcadores de posição de rodapé, data/hora e número de slide. Marcadores de posição de cabeçalho estão disponíveis em páginas de anotações e folhetos.

**E se um marcador de posição de rodapé, data/hora ou número de slide não estiver visível?**

Use o gerenciador de cabeçalho/rodapé correspondente para verificar sua visibilidade e habilitá‑lo quando necessário. Por exemplo, [`isFooterVisible`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) informa se um marcador de posição de rodapé está presente, e [`setFooterVisibility`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) altera sua visibilidade.

**Como iniciar a numeração de slides a partir de um valor diferente de 1?**

Chame o método [`setFirstSlideNumber`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/setfirstslidenumber/) da apresentação. Os marcadores de posição de número de slide então usarão a sequência de numeração atualizada.

**O que acontece com cabeçalhos e rodapés ao exportar para PDF, imagens ou HTML?**

Elementos de cabeçalho e rodapé visíveis são renderizados junto com o restante do conteúdo da apresentação no formato de saída. Sua aparência depende do tipo de página sendo exportado e das configurações de visibilidade dos marcadores de posição correspondentes.