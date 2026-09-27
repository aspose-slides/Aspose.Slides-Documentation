---
title: Criar apresentações em Node.js via .NET
linktitle: Criar apresentação
type: docs
weight: 10
url: /pt/nodejs-net/create-presentation/
keywords:
- criar apresentação
- nova apresentação
- criar PowerPoint
- criar PPTX
- adicionar caixa de texto
- adicionar slide
- tamanho do slide
- widescreen
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Crie apresentações PowerPoint em JavaScript com Aspose.Slides for Node.js via .NET: adicione uma caixa de texto e slides, defina um tamanho de slide 16:9 e salve o resultado como PPTX."
---
## **Visão geral**

Este artigo mostra como criar uma apresentação com Aspose.Slides for Node.js via .NET, adicionar uma caixa de texto ao seu primeiro slide e salvar o resultado como um arquivo PPTX. Também demonstra como adicionar mais slides e como alterar a apresentação para slides widescreen (16:9).

Os exemplos requerem um projeto configurado conforme descrito em [Instalação](/slides/pt/nodejs-net/installation/). Salve cada exemplo como um arquivo `.js` na pasta do projeto e execute‑o a partir dessa pasta com `node`, por exemplo `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET não possui sua própria referência de API. Ele reflete a API do Aspose.Slides for .NET com nomes camelCase, portanto os links de API neste artigo apontam para as classes e membros correspondentes na [referência da API do Aspose.Slides for .NET](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Criar uma apresentação com uma caixa de texto**

Para criar uma apresentação e colocar uma caixa de texto no seu primeiro slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Uma nova apresentação já contém um slide vazio.  
2. Obtenha esse slide da coleção [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). As coleções neste pacote são lidas com `get(index)`, e os índices começam em 0.  
3. Adicione um retângulo com o método [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) e defina o [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) de seu [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/).  
4. Salve a apresentação com o método [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) e o valor `SaveFormat.Pptx`.  
5. Chame `dispose` em um bloco `finally` para liberar os recursos .NET que sustentam a apresentação.  

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // A posição (x, y) e o tamanho (largura, altura) estão em pontos.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

O script grava `new-presentation.pptx` na pasta do projeto. O arquivo tem um slide com um retângulo preenchido cujo canto superior esquerdo está a 50 pontos da borda esquerda e superior do slide. O retângulo tem 400 pontos de largura e 100 pontos de altura, e seu texto está centralizado. Um ponto corresponde a 1/72 polegada. Sem uma licença, o Aspose.Slides também adiciona uma marca d'água de avaliação ao slide; veja [Licensing](/slides/pt/nodejs-net/licensing/).

## **Adicionar slides**

Uma nova apresentação tem um slide. Para adicionar mais, passe um slide de layout ao método [addEmptySlide](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addemptyslide/) da coleção `slides`. O método [getByType](https://reference.aspose.com/slides/net/aspose.slides/layoutslidecollection/getbytype/) da coleção [layoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) retorna o primeiro layout de um determinado [SlideLayoutType](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/).

O exemplo a seguir adiciona dois slides com o layout Blank:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O script exibe `Slide count: 3` e grava `three-slides.pptx`. Os novos slides são acrescentados após o primeiro e não contêm formas. Uma nova apresentação sempre possui um layout Blank, mas uma apresentação aberta a partir de um arquivo pode não ter um layout do tipo solicitado; nesse caso `getByType` retorna `null`, portanto verifique o resultado antes de utilizá‑lo.

## **Definir o tamanho do slide**

Uma nova apresentação utiliza slides 4:3 que possuem 720 × 540 pontos (10 × 7,5 polegadas). Para criar slides widescreen, chame o método [setSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) do [slideSize](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) da apresentação, passando um valor [SlideSizeType](https://reference.aspose.com/slides/net/aspose.slides/slidesizetype/) e um valor [SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/). O tipo de escala indica ao Aspose.Slides o que fazer com as formas já presentes nos slides; `DoNotScale` as mantém como estão, sendo a escolha correta para uma apresentação que ainda não tem conteúdo.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O script exibe `Slide size: 960 x 540 points`, que corresponde a 13,33 × 7,5 polegadas, e grava `widescreen.pptx`. `SlideSizeType.OnScreen16x9` tem a mesma proporção 16:9, mas é menor: 720 × 405 pontos.

## **FAQ**

**Em quais unidades as posições e tamanhos são medidos?**

Em pontos. Uma polegada equivale a 72 pontos, portanto o slide padrão 4:3 tem 720 × 540 pontos, e um slide widescreen 16:9 tem 960 × 540 pontos.

**Em quais formatos posso salvar uma nova apresentação?**

Qualquer valor da enumeração [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/), por exemplo `SaveFormat.Ppt` para PowerPoint 97–2003, `SaveFormat.Odp` para OpenDocument ou `SaveFormat.Pdf`. Para saída em PDF, veja [Convert PowerPoint to PDF](/slides/pt/nodejs-net/convert-powerpoint-to-pdf/).

**Por que a apresentação salva contém o texto "Evaluation only"?**

Sem uma licença, o Aspose.Slides adiciona uma marca d'água de avaliação aos slides que salva. Aplique uma licença conforme descrito em [Licensing](/slides/pt/nodejs-net/licensing/) para removê‑la.

**Por que devo chamar `dispose`?**

Um objeto `Presentation` é suportado por um objeto .NET que possui memória e outros recursos. Chamar `dispose` libera esses recursos assim que a apresentação não for mais necessária, e chamá‑lo em um bloco `finally` garante a liberação mesmo se ocorrer um erro.