---
title: Formas de Grupo em Apresentações Java
linktitle: Grupo de Formas
type: docs
weight: 40
url: /pt/java/group/
keywords:
- forma de grupo
- grupo de formas
- adicionar grupo
- texto alternativo
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda a agrupar e desagrupar formas em apresentações PowerPoint usando Aspose.Slides para Java - guia rápido, passo a passo, com código Java gratuito."
---
## **Visão geral**

Este artigo explica como trabalhar com formas de grupo no Aspose.Slides. Ele mostra como adicionar uma forma de grupo a um slide, colocar formas dentro dela e salvar a apresentação atualizada. Também demonstra como acessar as formas armazenadas dentro de um grupo e ler seus valores de `AlternativeText`. Além disso, o artigo aborda brevemente recursos relacionados a formas de grupo, como grupos aninhados, ordem Z e opções de bloqueio.

## **Adicionar uma Forma de Grupo**
Aspose.Slides oferece suporte ao trabalho com formas de grupo em slides. Esse recurso ajuda os desenvolvedores a criar apresentações mais ricas. O Aspose.Slides for Java oferece suporte à adição ou ao acesso a formas de grupo. É possível adicionar formas a uma forma de grupo já adicionada para preenchê‑la ou acessar qualquer propriedade da forma de grupo. Para adicionar uma forma de grupo a um slide usando o Aspose.Slides for Java:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
1. Obtenha a referência de um slide usando seu Index.
1. Adicione uma forma de grupo ao slide.
1. Adicione as formas à forma de grupo adicionada.
1. Salve a apresentação modificada como um arquivo PPTX.

O exemplo abaixo adiciona uma forma de grupo a um slide.

```java
// Instanciar a classe Presentation
Presentation pres = new Presentation();
try {
    // Obter o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Acessando a coleção de formas dos slides
    IShapeCollection slideShapes = sld.getShapes();

    // Adicionando uma forma de grupo ao slide
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Adicionando formas dentro da forma de grupo adicionada
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Adicionando a moldura da forma de grupo
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Gravar o arquivo PPTX no disco
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acessar a Propriedade AltText**
Este tópico mostra etapas simples, completas com exemplos de código, para adicionar uma forma de grupo e acessar a propriedade AltText das formas de grupo em slides. Para acessar o AltText de uma forma de grupo em um slide usando o Aspose.Slides for Java:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) que representa o arquivo PPTX.
1. Obtenha a referência de um slide usando seu Index.
1. Acesse a coleção de formas dos slides.
1. Acesse a forma de grupo.
1. Acesse a propriedade [AlternativeText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IShape#getAlternativeText--).

O exemplo abaixo acessa o texto alternativo da forma de grupo.

```java
// Instanciar a classe Presentation que representa o arquivo PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // Obter o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Acessando a coleção de formas dos slides
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Acessando a forma de grupo.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // Acessando a propriedade AltText
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**É o agrupamento aninhado (um grupo dentro de outro) suportado?**

Sim. [GroupShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/groupshape/) possui um método [getParentGroup](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#getParentGroup--) que indica diretamente o suporte à hierarquia (um grupo pode ser filho de outro grupo).

**Como controlo a ordem Z do grupo em relação a outros objetos no slide?**

Use o método [getZOrderPosition](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#getZOrderPosition--) da [GroupShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/groupshape/) para verificar sua posição na pilha de exibição.

**Posso impedir mover/editar/desagrupar?**

Sim. A seção de bloqueio do grupo é exposta através de [GroupShapeLock](https://reference.aspose.com/slides/pt/java/com.aspose.slides/groupshape/#getGroupShapeLock--) , que permite restringir operações no objeto.