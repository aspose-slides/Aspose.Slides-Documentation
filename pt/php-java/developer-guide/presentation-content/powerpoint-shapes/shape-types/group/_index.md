---
title: Formas de Apresentação em Grupo no PHP
linktitle: Grupo de Formas
type: docs
weight: 40
url: /pt/php-java/group/
keywords:
- forma de grupo
- grupo de formas
- adicionar grupo
- texto alternativo
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a agrupar e desagrupar formas em apresentações PowerPoint usando Aspose.Slides for PHP via Java — guia rápido, passo a passo, com código gratuito."
---
## **Visão geral**

Este artigo explica como trabalhar com formas de grupo no Aspose.Slides. Mostra como adicionar uma forma de grupo a um slide, inserir formas dentro dela e salvar a apresentação atualizada. Também demonstra como acessar as formas armazenadas dentro de um grupo e ler seus valores de `AlternativeText`. Além disso, o artigo aborda brevemente recursos relacionados a grupos, como grupos aninhados, ordem Z e opções de bloqueio.

## **Adicionar um Grupo de Formas**
Aspose.Slides oferece suporte ao trabalho com formas de grupo em slides. Esse recurso ajuda os desenvolvedores a criar apresentações mais ricas. Aspose.Slides for PHP via Java permite adicionar ou acessar formas de grupo. É possível adicionar formas a um grupo recém‑criado para preenchê‑lo ou acessar qualquer propriedade do grupo. Para adicionar um grupo de formas a um slide usando Aspose.Slides for PHP via Java:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Obtenha a referência de um slide usando seu Índice.
1. Adicione uma forma de grupo ao slide.
1. Adicione as formas ao grupo criado.
1. Salve a apresentação modificada como um arquivo PPTX.

O exemplo abaixo adiciona um grupo de formas a um slide.

```php
  # Instanciar classe Presentation
  $pres = new Presentation();
  try {
    # Obter o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Acessando a coleção de formas dos slides
    $slideShapes = $sld->getShapes();
    # Adicionando uma forma de grupo ao slide
    $groupShape = $slideShapes->addGroupShape();
    # Adicionando formas dentro da forma de grupo adicionada
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Adicionando quadro da forma de grupo
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # Gravar o arquivo PPTX no disco
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Acessar a Propriedade AltText**
Este tópico mostra etapas simples, completas com exemplos de código, para adicionar um grupo de formas e acessar a propriedade AltText de grupos de formas em slides. Para acessar o AltText de um grupo de formas em um slide usando Aspose.Slides for PHP via Java:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) que representa o arquivo PPTX.
1. Obtenha a referência de um slide usando seu Índice.
1. Acesse a coleção de formas do slide.
1. Acesse o grupo de formas.
1. Acesse a propriedade [Alternative Text](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getAlternativeText).

O exemplo abaixo acessa o texto alternativo do grupo de formas.

```php
  # Instanciar classe Presentation que representa o arquivo PPTX
  $pres = new Presentation("AltText.pptx");
  try {
    # Obter o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Acessando a coleção de formas dos slides
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Acessando a forma de grupo.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Acessando a propriedade AltText
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas frequentes**

**O agrupamento aninhado (um grupo dentro de outro grupo) é suportado?**

Sim. [GroupShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/groupshape/) possui o método [getParentGroup](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getparentgroup/), que indica diretamente o suporte à hierarquia (um grupo pode ser filho de outro grupo).

**Como controlo a ordem Z do grupo em relação a outros objetos no slide?**

Use o método [getZOrderPosition](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getzorderposition/) da [GroupShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/groupshape/) para inspecionar sua posição na pilha de exibição.

**Posso impedir mover/editar/desagrupar?**

Sim. A seção de bloqueio do grupo é exposta via [GroupShapeLock](https://reference.aspose.com/slides/pt/php-java/aspose.slides/groupshape/getgroupshapelock/), que permite restringir operações sobre o objeto.