---
title: Gerenciar porções de texto em apresentações usando JavaScript
linktitle: Porção de Texto
type: docs
weight: 70
url: /pt/nodejs-java/portion/
keywords:
- porção de texto
- parte de texto
- coordenadas de texto
- posição de texto
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a gerenciar porções de texto em apresentações PowerPoint usando JavaScript e Aspose.Slides para Node.js via Java, aprimorando desempenho e personalização."
---
## **Visão geral**

Uma porção de texto representa um fragmento específico de texto dentro de um parágrafo e permite que você trabalhe com esse fragmento independentemente do conteúdo ao redor. No Aspose.Slides, as porções podem ser usadas quando você precisa recuperar a posição de um fragmento de texto, aplicar formatação apenas a parte de um parágrafo ou controlar o comportamento do texto em um nível mais detalhado.

Este artigo mostra como obter as coordenadas do início de uma porção usando o método `getCoordinates()`. Também destaca cenários comuns relacionados a porções, como aplicar um hyperlink a um único fragmento de texto, entender como a formatação é resolvida por meio da herança de porção, parágrafo, quadro de texto e tema, e lidar com casos em que uma fonte especificada não está disponível. Além disso, observa que preenchimento de texto, cor e transparência podem ser definidos de forma diferente para porções individuais dentro do mesmo parágrafo.

## **Obter coordenadas de posição da Porção**
[**getCoordinates()**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Portion#getCoordinates--) method has been added to [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/) class which allows retrieving the coordinates of the beginning of the portion.

```javascript
// Instanciar a classe Presentation que representa o PPTX
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Reconfigurando o contexto da apresentação
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas frequentes**

**Posso aplicar um hyperlink apenas a parte do texto dentro de um único parágrafo?**

Sim, você pode [atribuir um hyperlink](/slides/pt/nodejs-java/manage-hyperlinks/) a uma porção individual; somente esse fragmento será clicável, não todo o parágrafo.

**Como funciona a herança de estilo: o que uma Porção sobrescreve e o que é herdado do Parágrafo/Quadro de Texto?**

As propriedades no nível da Porção têm a precedência mais alta. Se uma propriedade não estiver definida na [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/), o mecanismo a obtém do [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/); se não estiver definida lá também, do [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) ou do estilo do [theme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/theme/).

**O que acontece se a fonte especificada para uma Porção estiver ausente na máquina/servidor de destino?**

[Regras de substituição de fontes](/slides/pt/nodejs-java/font-selection-sequence/) são aplicadas. O texto pode ser reorganizado: métricas, hifenização e largura podem mudar, o que importa para posicionamento preciso.

**Posso definir transparência ou gradiente de preenchimento de texto específico da Porção, independente do restante do parágrafo?**

Sim, cor, preenchimento e transparência do texto no nível da [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/) podem ser diferentes dos fragmentos vizinhos.