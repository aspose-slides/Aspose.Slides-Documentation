---
title: Obter limites da porção de texto de apresentações em JavaScript
linktitle: Limites da Porção
type: docs
weight: 47
url: /pt/nodejs-java/portion-bounds/
keywords:
- limites da porção de texto
- porção de texto
- parte de texto
- coordenadas de texto
- posição de texto
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda como recuperar os limites da porção de texto em apresentações PowerPoint usando Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Uma porção de texto representa um fragmento específico de texto dentro de um parágrafo e permite que você trabalhe com esse fragmento independentemente do conteúdo ao redor. No Aspose.Slides, as porções podem ser usadas quando você precisa obter os limites de um fragmento de texto, aplicar formatação apenas a parte de um parágrafo ou controlar o comportamento do texto em um nível mais detalhado.

Este artigo mostra como obter o retângulo delimitador de uma porção usando [Portion.getRect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/getrect/). Também mostra como obter as coordenadas do início de uma porção usando [Portion.getCoordinates](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/getcoordinates/). Além disso, destaca cenários comuns relacionados a porções, como aplicar um hyperlink a um único fragmento de texto, entender como a formatação é resolvida através da herança de porção, parágrafo, moldura de texto e tema, e lidar com casos em que uma fonte especificada não está disponível.

## **Obter limites de uma porção de texto**

Use [Portion.getRect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/getrect/) para recuperar o retângulo delimitador de uma porção de texto:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Obter coordenadas de uma porção de texto**

Use [Portion.getCoordinates](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/getcoordinates/) para recuperar as coordenadas do início de uma porção de texto:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Perguntas frequentes**

**Posso aplicar um hyperlink apenas a parte do texto dentro de um único parágrafo?**

Sim, você pode [atribuir um hyperlink](/slides/pt/nodejs-java/manage-hyperlinks/) a uma porção individual; apenas esse fragmento será clicável, não todo o parágrafo.

**Como funciona a herança de estilos: o que uma porção sobrescreve e o que é herdado de um parágrafo ou moldura de texto?**

As propriedades no nível da Porção têm a precedência mais alta. Se uma propriedade não estiver definida na [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/), o Aspose.Slides a obtém do [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/). Se também não estiver definida lá, o Aspose.Slides usa o estilo da [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) ou do [theme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/theme/).

**O que acontece se a fonte especificada para uma porção estiver ausente na máquina ou servidor de destino?**

As [Font substitution rules](/slides/pt/nodejs-java/font-selection-sequence/) são aplicadas. O texto pode ser reformatado: métricas, hifenização e largura podem mudar, o que é importante para posicionamento preciso.

**Posso definir transparência de preenchimento de texto ou um gradiente específicos da porção independentemente do restante do parágrafo?**

Sim, a cor do texto, preenchimento e transparência no nível da [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/) podem ser diferentes dos fragmentos vizinhos.