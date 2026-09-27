---
title: Gerenciar Texto da Apresentação em Node.js via .NET
linktitle: Gerenciar Texto
type: docs
weight: 50
url: /pt/nodejs-net/manage-text/
keywords:
- texto
- caixa de texto
- adicionar texto
- alterar texto
- formatar texto
- tamanho da fonte
- texto em negrito
- quadro de texto
- parágrafo
- porção
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Adicione uma caixa de texto a um slide, depois altere seu texto, tamanho da fonte e estilo em negrito em JavaScript com Aspose.Slides para Node.js via .NET."
---
## **Visão geral**

No Aspose.Slides, o texto em um slide pertence a uma forma. Uma autoforma, como um retângulo, possui uma caixa de texto; a caixa de texto contém parágrafos, e cada parágrafo contém porções, que são trechos de texto com a mesma formatação. Você altera o texto através da caixa de texto e a fonte através do formato de uma porção.

Este artigo adiciona uma caixa de texto a um slide e salva a apresentação. Em seguida, abre o arquivo salvo e altera o texto da caixa de texto, o tamanho da fonte e o estilo negrito.

Os exemplos requerem um projeto configurado como descrito em [Instalação](/slides/pt/nodejs-net/installation/). Salve cada exemplo como um arquivo `.js` na pasta do projeto e execute‑o a partir dessa pasta com `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET não possui sua própria referência de API. Ele espelha a API do Aspose.Slides for .NET com nomes camelCase, então os links de API neste artigo apontam para as classes e membros correspondentes na [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Adicionar uma caixa de texto**

Para adicionar uma caixa de texto, adicione uma autoforma a um slide usando o método [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) e atribua texto a ela com o método [addTextFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/addtextframe/). O exemplo a seguir adiciona um retângulo ao primeiro slide de uma nova apresentação e salva a apresentação como `text-box.pptx`:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // A posição (x, y) e o tamanho (largura, altura) estão em pontos.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

O slide em `text-box.pptx` contém um retângulo, 500 pontos de largura e 80 pontos de altura, com o texto "Quarterly report" na fonte e tamanho padrão. O próximo exemplo altera essa caixa de texto.

## **Alterar o texto e sua formatação**

O exemplo a seguir abre `text-box.pptx`, que o exemplo anterior criou, e obtém a primeira forma no primeiro slide. Formas como imagens e tabelas não possuem caixa de texto, portanto o exemplo verifica se a forma é uma [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) antes de usar a [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/) da forma. Em seguida, ele realiza o seguinte:

1. Ele substitui o texto através da propriedade [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) da caixa de texto. Após isso, a caixa de texto contém um parágrafo com uma única porção.  
2. Ele obtém essa porção das coleções [paragraphs](https://reference.aspose.com/slides/net/aspose.slides/textframe/paragraphs/) e [portions](https://reference.aspose.com/slides/net/aspose.slides/paragraph/portions/), e lê seu [portionFormat](https://reference.aspose.com/slides/net/aspose.slides/portion/portionformat/).  
3. Ele define [fontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/), o tamanho da fonte em pontos, e [fontBold](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontbold/), que aceita um valor [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/).

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

Em `text-box-updated.pptx`, a caixa de texto exibe "Quarterly report: third quarter" em negrito de 32 pontos. Como o novo texto é uma única porção, as duas propriedades de formatação se aplicam a todo ele. Sem uma licença, cada salvamento adiciona uma marca d'água de avaliação. Como `text-box.pptx` foi salvo em modo de avaliação, `text-box-updated.pptx` contém duas; veja [Avaliar Aspose.Slides](/slides/pt/nodejs-net/evaluate-aspose-slides/).

## **FAQ**

**Por que `fontBold` aceita um valor `NullableBool` em vez de `true` ou `false`?**

Uma porção pode deixar uma propriedade indefinida e herdá‑la do parágrafo, da forma ou do layout e mestre do slide. `NullableBool.NotDefined` significa "herdar", enquanto `NullableBool.True` e `NullableBool.False` substituem o valor herdado. Atribuir `true` ou `false` gera um erro. Pelo mesmo motivo, `fontHeight` retorna `NaN` quando a porção herda seu tamanho de fonte.

**Como alterar a cor do texto?**

Defina o preenchimento do formato da porção: atribua `FillType.Solid` a `portionFormat.fillFormat.fillType` e, em seguida, atribua uma cor como `"#FF0000"` a `portionFormat.fillFormat.solidFillColor.color`. Adicione `FillType` aos nomes que você importa do pacote.

**Como formatar apenas parte do texto?**

A formatação pertence às porções, portanto coloque essa parte do texto em uma porção própria. Crie a porção com `Portion.CreatePortionFromText`, adicione‑a a um parágrafo usando o método `add` da coleção `portions` do parágrafo e, então, defina o `portionFormat` da nova porção. Adicione `Portion` aos nomes que você importa do pacote.

**Por que a leitura de texto retorna "... text has been truncated due to evaluation version limitation"?**

Sem uma licença, o Aspose.Slides retorna apenas os cinco primeiros caracteres de qualquer texto maior que você ler, como `textFrame.text`, seguido por este aviso. O texto que você grava é salvo integralmente. Aplique uma licença conforme descrito em [Licenciamento](/slides/pt/nodejs-net/licensing/) para ler o texto completo.