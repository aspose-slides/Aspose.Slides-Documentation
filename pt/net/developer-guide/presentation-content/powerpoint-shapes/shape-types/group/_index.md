---
title: Formas de Grupo em Apresentações .NET
linktitle: Grupo de Formas
type: docs
weight: 40
url: /pt/net/group/
keywords:
- forma de grupo
- grupo de formas
- adicionar grupo
- texto alternativo
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a agrupar e desagrupar formas em apresentações PowerPoint usando Aspose.Slides para .NET—guia rápido, passo a passo, com código C# gratuito."
---
## **Visão geral**

Este artigo explica como trabalhar com formas de grupo no Aspose.Slides. Mostra como adicionar uma forma de grupo a um slide, colocar formas dentro dela e salvar a apresentação atualizada. Também demonstra como acessar as formas armazenadas dentro de um grupo e ler seus valores `AlternativeText`. Além disso, o artigo cobre brevemente recursos relacionados a formas de grupo, como grupos aninhados, ordem Z e opções de bloqueio.

## **Adicionar uma forma de grupo**
Aspose.Slides oferece suporte ao trabalho com formas de grupo em slides. Esse recurso ajuda os desenvolvedores a criar apresentações mais ricas. Aspose.Slides para .NET permite adicionar ou acessar formas de grupo. É possível adicionar formas a uma forma de grupo já adicionada para preenchê‑la ou acessar qualquer propriedade da forma de grupo. Para adicionar uma forma de grupo a um slide usando Aspose.Slides para .NET:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Obtenha a referência de um slide usando seu Índice.
1. Adicione uma forma de grupo ao slide.
1. Adicione as formas à forma de grupo adicionada.
1. Salve a apresentação modificada como um arquivo PPTX.

O exemplo abaixo adiciona uma forma de grupo a um slide.

```c#
 // Instanciar a classe Presentation 
 using (Presentation pres = new Presentation())
 {
     // Obter o primeiro slide 
     ISlide sld = pres.Slides[0];
 
     // Acessar a coleção de formas dos slides 
     IShapeCollection slideShapes = sld.Shapes;
 
     // Adicionar uma forma de grupo ao slide 
     IGroupShape groupShape = slideShapes.AddGroupShape();
 
     // Adicionar formas dentro da forma de grupo adicionada 
     groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
     groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
     groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
     groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);
 
     // Adicionar o quadro da forma de grupo 
     groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);
 
     // Gravar o arquivo PPTX no disco 
     pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
 }
```

## **Acessar a propriedade AltText**
O tópico apresenta etapas simples, completas com exemplos de código, para adicionar uma forma de grupo e acessar a propriedade AltText de formas de grupo em slides. Para acessar o AltText de uma forma de grupo em um slide usando Aspose.Slides para .NET:

1. Instancie a classe `Presentation` que representa o arquivo PPTX.
1. Obtenha a referência de um slide usando seu Índice.
1. Acesse a coleção de formas dos slides.
1. Acesse a forma de grupo.
1. Acesse a propriedade AltText.

O exemplo abaixo acessa o texto alternativo da forma de grupo.

```c#
// Instanciar a classe Presentation que representa o arquivo PPTX
Presentation pres = new Presentation("AltText.pptx");

// Obter o primeiro slide
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Acessar a coleção de formas dos slides
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Acessar a forma de grupo.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // Acessar a propriedade AltText
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

## **FAQ**

**O agrupamento aninhado (um grupo dentro de outro) é suportado?**

Sim. [GroupShape](https://reference.aspose.com/slides/pt/net/aspose.slides/groupshape/) possui a propriedade [ParentGroup](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/parentgroup/), que indica diretamente o suporte a hierarquia (um grupo pode ser filho de outro grupo).

**Como controlar a ordem Z do grupo em relação a outros objetos no slide?**

Use a propriedade [ZOrderPosition](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/zorderposition/) da [GroupShape](https://reference.aspose.com/slides/pt/net/aspose.slides/groupshape/) para verificar sua posição na pilha de exibição.

**Posso impedir mover/editar/desagrupar?**

Sim. A seção de bloqueio do grupo é exposta via [GroupShapeLock](https://reference.aspose.com/slides/pt/net/aspose.slides/groupshape/groupshapelock/), que permite restringir operações no objeto.