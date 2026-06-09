---
title: Gerenciar cabeçalhos e rodapés de apresentação em PHP
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
- notas
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Use Aspose.Slides for PHP via Java para adicionar e personalizar cabeçalhos e rodapés em apresentações PowerPoint e OpenDocument para um visual profissional."
---
## **Visão geral**

Aspose.Slides permite gerenciar as configurações de cabeçalho e rodapé em apresentações do PowerPoint. Cabeçalhos e rodapés são tratados no nível do mestre da apresentação, e a API fornece métodos para definir o texto do rodapé, alterar a visibilidade do rodapé e atualizar o texto do cabeçalho nos slides mestre de notas.

Você também pode gerenciar cabeçalhos e rodapés para slides de folhetos e notas. Isso inclui alterar a visibilidade e o texto dos marcadores de posição de cabeçalho, rodapé, número do slide e data/hora no mestre de notas, em todos os slides de notas filhos ou em um slide de notas individual.

## **Gerenciar cabeçalhos e rodapés em uma apresentação**

As notas de um slide específico podem ser removidas, como mostrado no exemplo abaixo:

```php
  # Carregar apresentação
  $pres = new Presentation("headerTest.pptx");
  try {
    # Definindo rodapé
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Acessar e atualizar cabeçalho
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Salvar apresentação
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Gerenciar cabeçalhos e rodapés em folhetos e slides de notas**
Aspose.Slides for PHP via Java oferece suporte a cabeçalho e rodapé em folhetos e slides de notas. Siga as etapas abaixo:

- Carregue uma [Apresentação](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) que contenha um vídeo.
- Altere as configurações de Cabeçalho e Rodapé para o mestre de notas e todos os slides de notas.
- Defina os marcadores de posição de Rodapé do mestre de notas e de todos os filhos como visíveis.
- Defina os marcadores de posição de Data e hora do mestre de notas e de todos os filhos como visíveis.
- Altere as configurações de Cabeçalho e Rodapé apenas para o primeiro slide de notas.
- Defina o marcador de posição de Cabeçalho do slide de notas como visível.
- Defina o texto do marcador de posição de Cabeçalho do slide de notas.
- Defina o texto do marcador de posição de Data-hora do slide de notas.
- Grave o arquivo de apresentação modificado.

Trecho de código fornecido no exemplo abaixo.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Alterar configurações de Cabeçalho e Rodapé para o mestre de notas e todos os slides de notas
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// torna o slide mestre de notas e todos os marcadores de posição de rodapé filhos visíveis

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// torna o slide mestre de notas e todos os marcadores de posição de cabeçalho filhos visíveis

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// torna o slide mestre de notas e todos os marcadores de posição de número de slide filhos visíveis

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// torna o slide mestre de notas e todos os marcadores de posição de data e hora filhos visíveis

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// define o texto para o slide mestre de notas e todos os marcadores de posição de cabeçalho filhos

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// define o texto para o slide mestre de notas e todos os marcadores de posição de rodapé filhos

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// define o texto para o slide mestre de notas e todos os marcadores de posição de data e hora filhos

    }
    # Alterar configurações de Cabeçalho e Rodapé apenas para o primeiro slide de notas
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// torna o marcador de posição de Cabeçalho deste slide de notas visível

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// torna o marcador de posição de Rodapé deste slide de notas visível

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// torna o marcador de posição de Número de Slide deste slide de notas visível

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// torna o marcador de posição de Data-hora deste slide de notas visível

      $headerFooterManager->setHeaderText("New header text");// define o texto para o marcador de posição de Cabeçalho do slide de notas

      $headerFooterManager->setFooterText("New footer text");// define o texto para o marcador de posição de Rodapé do slide de notas

      $headerFooterManager->setDateTimeText("New date and time text");// define o texto para o marcador de posição de Data-hora do slide de notas

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas frequentes**

**Posso adicionar um “cabeçalho” aos slides normais?**

No PowerPoint, “Cabeçalho” existe apenas para notas e folhetos; nos slides normais, os elementos suportados são rodapé, data/hora e número do slide. No Aspose.Slides isso corresponde às mesmas limitações: cabeçalho apenas para Notas/Folhetos e, nos slides—Rodapé/DataHora/NúmeroDoSlide.

**E se o layout não contiver uma área de rodapé—posso “ativar” sua visibilidade?**

Sim. Verifique a visibilidade pelo gerenciador de cabeçalho/rodapé e habilite-a, se necessário. Esses indicadores e métodos da API foram projetados para casos em que o marcador de posição está ausente ou oculto.

**Como faço o número do slide começar a partir de um valor diferente de 1?**

Defina o [primeiro número do slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/setfirstslidenumber/) da apresentação; após isso, toda a numeração será recalculada. Por exemplo, você pode iniciar em 0 ou 10 e ocultar o número no slide de título.

**O que acontece com cabeçalhos/rodapés ao exportar para PDF/imagens/HTML?**

Eles são renderizados como elementos de texto normais da apresentação. Ou seja, se os elementos estiverem visíveis nos slides/páginas de notas, também aparecerão no formato de saída junto com o restante do conteúdo.