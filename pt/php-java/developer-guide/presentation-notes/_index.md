---
title: Gerenciar notas de apresentação em PHP
linktitle: Notas de apresentação
type: docs
weight: 110
url: /pt/php-java/presentation-notes/
keywords:
- notas
- slide de notas
- adicionar notas
- remover notas
- estilo de notas
- notas mestre
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Personalize as notas da apresentação com Aspose.Slides para PHP via Java. Trabalhe perfeitamente com notas do PowerPoint e OpenDocument para aumentar sua produtividade."
---
## **Visão geral**

Aspose.Slides suporta a remoção de slides de notas de uma apresentação. Neste tópico, apresentaremos esse recurso, incluindo como remover notas e como aplicar um estilo aos slides de notas em uma apresentação. Aspose.Slides permite remover notas de qualquer slide e também aplicar estilos às notas existentes. Os desenvolvedores podem remover notas da seguinte forma:

- Remover notas de um slide específico em uma apresentação.
- Remover notas de todos os slides em uma apresentação.

## **Remover notas de um slide**
As notas de um slide específico podem ser removidas como mostrado no exemplo abaixo:

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

## **Remover notas de uma apresentação**
As notas de todos os slides de uma apresentação podem ser removidas como mostrado no exemplo abaixo:

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

## **Adicionar um estilo de notas**
O método [getNotesStyle](https://reference.aspose.com/slides/pt/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) foi adicionado à classe [MasterNotesSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/MasterNotesSlide). Esta propriedade especifica o estilo de um texto de notas. A implementação é demonstrada no exemplo abaixo.

```php
  # Instanciar um objeto Presentation que representa um arquivo de apresentação
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Obter estilo de texto do MasterNotesSlide
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

## **FAQ**

**Qual entidade da API fornece acesso às notas de um slide específico?**

As notas são acessadas através do gerenciador de notas do slide: o slide possui um [NotesSlideManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notesslidemanager/) e um [método](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notesslidemanager/getnotesslide/) que retorna o objeto de notas, ou `null` se não houver notas.

**Existem diferenças no suporte a notas entre as versões do PowerPoint com as quais a biblioteca funciona?**

A biblioteca tem como alvo uma ampla gama de formatos do Microsoft PowerPoint (97–mais recentes) e ODP; as notas são suportadas nesses formatos sem depender de uma cópia instalada do PowerPoint.