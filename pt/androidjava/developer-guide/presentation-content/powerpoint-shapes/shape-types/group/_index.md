---
title: Formas de Apresentação em Grupo no Android
linktitle: Grupo de Shapes
type: docs
weight: 40
url: /pt/androidjava/group/
keywords:
- shape de grupo
- grupo de shapes
- adicionar grupo
- texto alternativo
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda a agrupar e desagrupar shapes em apresentações PowerPoint usando Aspose.Slides para Android — guia rápido, passo a passo, com código Java gratuito."
---
## **Visão geral**

Este artigo explica como trabalhar com shapes de grupo no Aspose.Slides. Ele mostra como adicionar um shape de grupo a um slide, colocar shapes dentro dele e salvar a apresentação atualizada. Também demonstra como acessar os shapes armazenados dentro de um grupo e ler seus valores `AlternativeText`. Além disso, o artigo aborda brevemente recursos relacionados a shapes de grupo, como grupos aninhados, ordem Z e opções de bloqueio.

## **Adicionar um Group Shape**
Aspose.Slides oferece suporte ao trabalho com shapes de grupo em slides. Esse recurso ajuda os desenvolvedores a criar apresentações mais ricas. Aspose.Slides for Android via Java permite adicionar ou acessar shapes de grupo. É possível adicionar shapes a um shape de grupo já adicionado para preenchê‑lo ou acessar qualquer propriedade do shape de grupo. Para adicionar um group shape a um slide usando Aspose.Slides for Android via Java:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
1. Obtenha a referência de um slide usando seu Index
1. Adicione um group shape ao slide.
1. Adicione os shapes ao group shape adicionado.
1. Salve a apresentação modificada como um arquivo PPTX.

O exemplo abaixo adiciona um group shape a um slide.

```java
// Instanciar a classe Presentation
Presentation pres = new Presentation();
try {
    // Obter o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Acessando a coleção de shapes dos slides
    IShapeCollection slideShapes = sld.getShapes();

    // Adicionando um shape de grupo ao slide
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Adicionando shapes dentro do shape de grupo adicionado
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Adicionando a moldura do shape de grupo
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Gravar o arquivo PPTX no disco
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acessar a Propriedade AltText**
Este tópico mostra passos simples, completos com exemplos de código, para adicionar um group shape e acessar a propriedade AltText de shapes de grupo em slides. Para acessar o AltText de um group shape em um slide usando Aspose.Slides for Android via Java:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) que representa o arquivo PPTX.
1. Obtenha a referência de um slide usando seu Index.
1. Acesse a coleção de shapes dos slides.
1. Acesse o group shape.
1. Acesse a propriedade [AlternativeText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShape#getAlternativeText--).

O exemplo abaixo acessa o texto alternativo do group shape.

```java
// Instanciar a classe Presentation que representa o arquivo PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // Obter o primeiro slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Acessando a coleção de shapes dos slides
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Acessando o shape de grupo.
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

**O agrupamento aninhado (um grupo dentro de outro grupo) é suportado?**

Sim. [GroupShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/groupshape/) possui um método [getParentGroup](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/#getParentGroup--) que indica diretamente o suporte a hierarquia (um grupo pode ser filho de outro grupo).

**Como controlar a ordem Z do grupo em relação a outros objetos no slide?**

Use o método [getZOrderPosition](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/#getZOrderPosition--) do [GroupShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/groupshape/) para inspecionar sua posição na pilha de exibição.

**Posso impedir mover/editar/desagrupar?**

Sim. A seção de bloqueio do grupo é exposta através de [getGroupShapeLock](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--) , que permite restringir operações no objeto.