---
title: Gerenciar anotações de apresentação em PHP
linktitle: Anotações de Apresentação
type: docs
weight: 110
url: /pt/php-java/presentation-notes/
keywords:
- anotações
- slide de anotações
- adicionar anotações
- remover anotações
- estilo de anotações
- anotações mestre
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Personalize as anotações de apresentação com Aspose.Slides para PHP via Java. Trabalhe de forma fluida com anotações do PowerPoint e OpenDocument para aumentar sua produtividade."
---
## **Visão geral**

Aspose.Slides oferece suporte à remoção de slides de anotações de uma apresentação. Neste tópico, apresentaremos esse recurso, incluindo como remover anotações e como aplicar um estilo aos slides de anotações em uma apresentação. Aspose.Slides permite remover anotações de qualquer slide e também aplicar estilo às anotações existentes. Os desenvolvedores podem remover anotações das seguintes maneiras:

- Remover anotações de um slide específico em uma apresentação.
- Remover anotações de todos os slides em uma apresentação.

Para ler ou alterar as dimensões da página de anotações, mudar a orientação e verificar o comportamento de exportação, veja [Tamanho da página de anotações](/slides/pt/php-java/notes-size/).

## **Remover anotações de um slide**
As anotações de um slide específico podem ser removidas como mostrado no exemplo abaixo:

```php
  # Instanciar um objeto Presentation que representa um arquivo de apresentação
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Removendo notas do primeiro slide
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Salvando a apresentação no disco
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Remover anotações de uma apresentação**
As anotações de todos os slides de uma apresentação podem ser removidas como mostrado no exemplo abaixo:

```php
  # Instanciar um objeto Presentation que representa um arquivo de apresentação
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Removendo notas de todos os slides
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Salvando a apresentação no disco
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Adicionar um estilo de anotações**
O método [getNotesStyle](https://reference.aspose.com/slides/pt/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) da classe [MasterNotesSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/MasterNotesSlide) fornece acesso ao estilo de texto das anotações. A implementação é demonstrada no exemplo abaixo.

```php
  # Instanciar um objeto Presentation que representa um arquivo de apresentação
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Obter o estilo de texto do MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # Definir marcador de símbolo para os parágrafos de primeiro nível
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas frequentes**

**Qual entidade da API fornece acesso às anotações de um slide específico?**

As anotações são acessadas através do gerenciador de anotações do slide: o slide possui um [NotesSlideManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notesslidemanager/) e um [método](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notesslidemanager/getnotesslide/) que retorna o objeto de anotações, ou `null` se não houver anotações.

**Existem diferenças no suporte a anotações entre as versões do PowerPoint com as quais a biblioteca funciona?**

A biblioteca tem como alvo uma ampla gama de formatos do Microsoft PowerPoint (97-newer) e ODP; as anotações são suportadas nesses formatos sem depender de uma cópia instalada do PowerPoint.