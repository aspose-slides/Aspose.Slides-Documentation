---
title: Obter limites de parágrafo de apresentações em JavaScript
linktitle: Parágrafo
type: docs
weight: 60
url: /pt/nodejs-java/paragraph/
keywords:
- limites de parágrafo
- limites de trecho de texto
- coordenada de parágrafo
- coordenada de trecho
- tamanho de parágrafo
- tamanho de trecho de texto
- quadro de texto
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a obter limites de parágrafo e de trechos de texto em JavaScript com Aspose.Slides para Node.js para otimizar o posicionamento de texto em apresentações PowerPoint."
---
## **Visão geral**

Este artigo explica como obter os limites, o tamanho e as coordenadas de parágrafos e trechos de texto no Aspose.Slides. Ele mostra como recuperar o retângulo de um parágrafo em um `TextFrame` usando `getRect()`, como obter as coordenadas de parágrafo e trecho dentro de um quadro de texto de célula de tabela, e destaca detalhes importantes como unidades de medida, o efeito da quebra de linha nos limites, conversão para pixels e valores efetivos de formatação de parágrafo.

## **Obter coordenadas de parágrafo e trecho no TextFrame**
Usando Aspose.Slides for Node.js via Java, os desenvolvedores agora podem obter as coordenadas retangulares de Paragraph dentro da coleção de parágrafos do TextFrame. Também permite obter [as coordenadas do trecho](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Portion#getCoordinates--) dentro da coleção de trechos de um parágrafo. Neste tópico, vamos demonstrar, com a ajuda de um exemplo, como obter as coordenadas retangulares para o parágrafo juntamente com a posição do trecho dentro de um parágrafo.

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```

## **Obter coordenadas retangulares do parágrafo**
Usando o método [**getRect()**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Paragraph#getRect--) os desenvolvedores podem obter o retângulo de limites do parágrafo.

```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Obter tamanho de parágrafo e trecho dentro do quadro de texto de célula de tabela**

Para obter o tamanho e as coordenadas da [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Portion) ou do [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Paragraph) em um quadro de texto de célula de tabela, você pode usar os métodos [Portion.getRect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Portion#getRect--) e [Paragraph.getRect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Paragraph#getRect--).

Este código de exemplo demonstra a operação descrita:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas frequentes**

**Em que unidades as coordenadas retornadas para um parágrafo e trechos de texto são medidas?**

Em pontos, onde 1 polegada = 72 pontos. Isso se aplica a todas as coordenadas e dimensões no slide.

**A quebra de linha afeta os limites de um parágrafo?**

Sim. Se o [wrapping](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/setwraptext/) estiver ativado no [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/), o texto quebra para se ajustar à largura da área, o que altera os limites reais do parágrafo.

**As coordenadas do parágrafo podem ser mapeadas de forma confiável para pixels na imagem exportada?**

Sim. Converta pontos para pixels usando: pixels = points × (DPI / 72). O resultado depende do DPI escolhido para renderização/exportação.

**Como obtenho os parâmetros de formatação de parágrafo "efetivos", levando em conta a herança de estilo?**

Use a [estrutura de dados de formatação efetiva de parágrafo](/slides/pt/nodejs-java/shape-effective-properties/); ela retorna os valores finais consolidados para recuos, espaçamento, quebra de linha, RTL e muito mais.