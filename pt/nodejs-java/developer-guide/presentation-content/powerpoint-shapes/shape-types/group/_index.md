---
title: Formas de Apresentação em Grupo em JavaScript
linktitle: Grupo de Formas
type: docs
weight: 40
url: /pt/nodejs-java/group/
keywords:
- forma de grupo
- grupo de formas
- adicionar grupo
- texto alternativo
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a agrupar e desagrupar formas em apresentações PowerPoint usando Aspose.Slides para Node.js via Java — guia rápido, passo a passo, com código JavaScript gratuito."
---
## **Visão geral**

Este artigo explica como trabalhar com formas de grupo no Aspose.Slides. Ele mostra como adicionar uma forma de grupo a um slide, inserir formas dentro dela e salvar a apresentação atualizada. Também demonstra como acessar formas armazenadas dentro de um grupo e ler seus valores `AlternativeText`. Além disso, o artigo aborda brevemente recursos relacionados a formas de grupo, como grupos aninhados, ordem Z e opções de bloqueio.

## **Adicionar Forma de Grupo**
O Aspose.Slides oferece suporte ao trabalho com formas de grupo em slides. Esse recurso ajuda os desenvolvedores a criar apresentações mais ricas. O Aspose.Slides for Node.js via Java permite adicionar ou acessar formas de grupo. É possível adicionar formas a uma forma de grupo recém‑criada para preenchê‑la ou acessar qualquer propriedade da forma de grupo. Para adicionar uma forma de grupo a um slide usando Aspose.Slides for Node.js via Java:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide usando seu Índice.
3. Adicione uma forma de grupo ao slide.
4. Adicione as formas à forma de grupo criada.
5. Salve a apresentação modificada como um arquivo PPTX.

O exemplo abaixo adiciona uma forma de grupo a um slide.

```javascript
// Instanciar a classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    // Acessando a coleção de formas dos slides
    var slideShapes = sld.getShapes();
    // Adicionando uma forma de grupo ao slide
    var groupShape = slideShapes.addGroupShape();
    // Adicionando formas dentro da forma de grupo adicionada
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // Adicionando a moldura da forma de grupo
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // Gravando o arquivo PPTX no disco
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Acessar Propriedade AltText**
Este tópico mostra passos simples, completos com exemplos de código, para adicionar uma forma de grupo e acessar a propriedade AltText de formas de grupo em slides. Para acessar o AltText de uma forma de grupo em um slide usando Aspose.Slides for Node.js via Java:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) que representa um arquivo PPTX.
2. Obtenha a referência de um slide usando seu Índice.
3. Acesse a coleção de formas dos slides.
4. Acesse a forma de grupo.
5. Chame a propriedade [getAlternativeText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getAlternativeText--) .

O exemplo abaixo acessa o texto alternativo da forma de grupo.

```javascript
// Instanciar a classe Presentation que representa o arquivo PPTX
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // Obter o primeiro slide
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // Acessando a coleção de formas dos slides
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // Acessando a forma de grupo.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // Acessando a propriedade AltText
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas Frequentes**

**O agrupamento aninhado (uma forma dentro de outra) é suportado?**

Sim. [GroupShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/groupshape/) possui o método [getParentGroup](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/getparentgroup/), que indica diretamente o suporte à hierarquia (uma forma pode ser filha de outra forma).

**Como controlo a ordem Z do grupo em relação a outros objetos no slide?**

Use o método [getZOrderPosition](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/getzorderposition/) da [GroupShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/groupshape/) para inspecionar sua posição na pilha de exibição.

**Posso impedir movimentação/edição/desagrupamento?**

Sim. A seção de bloqueio do grupo é exposta via [GroupShapeLock](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/groupshape/getgroupshapelock/), que permite restringir operações sobre o objeto.