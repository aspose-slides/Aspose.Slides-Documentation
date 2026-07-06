---
title: Obter limites de parágrafo de apresentações em JavaScript
linktitle: Limites de Parágrafo
type: docs
weight: 43
url: /pt/nodejs-java/paragraph-bounds/
keywords:
- limites de parágrafo
- coordenada de parágrafo
- tamanho de parágrafo
- quadro de texto
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a recuperar os limites de parágrafos no Aspose.Slides para Node.js via Java para otimizar o posicionamento de texto em apresentações do PowerPoint."
---
## **Visão geral**

Este artigo explica como obter os limites, o tamanho e as coordenadas de parágrafos no Aspose.Slides. Ele mostra como recuperar um retângulo de parágrafo a partir de um [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) usando [Paragraph.getRect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/getrect/), como obter as coordenadas do parágrafo dentro de um TextFrame de célula de tabela e destaca detalhes importantes, como unidades de medida, o efeito da quebra de linha nos limites, conversão para pixels e valores de formatação de parágrafo efetivos.

## **Obter coordenadas retangulares de um parágrafo**

Use [Paragraph.getRect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/getrect/) para obter o retângulo delimitador de um parágrafo.

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Obter o tamanho de um parágrafo dentro de um TextFrame de célula de tabela**

Para obter o tamanho e as coordenadas de um [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/) em um TextFrame de célula de tabela, use [Paragraph.getRect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/getrect/). O retângulo retornado é relativo ao TextFrame da célula da tabela, portanto adicione a posição da tabela e o deslocamento da célula quando precisar das coordenadas no nível do slide.

O exemplo a seguir obtém os limites do parágrafo dentro de uma célula de tabela e desenha retângulos no slide para visualizar esses limites:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Perguntas frequentes**

**Em que unidades as coordenadas do parágrafo são medidas?**

Elas são medidas em pontos, onde 1 polegada equivale a 72 pontos. Isso se aplica a todas as coordenadas e dimensões no slide.

**A quebra de linha afeta os limites do parágrafo?**

Sim. Se [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframeformat/setwraptext/) estiver habilitado para o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/), o texto quebra para se ajustar à largura da área, o que altera os limites reais do parágrafo.

**As coordenadas do parágrafo podem ser mapeadas de forma confiável para pixels na imagem exportada?**

Sim. Converta pontos para pixels usando a fórmula: pixels = pontos x (DPI / 72). O resultado depende do DPI escolhido para renderização ou exportação.

**Como obter os parâmetros de formatação “efetiva” do parágrafo, levando em conta a herança de estilos?**

Use a [effective paragraph formatting data structure](/slides/pt/nodejs-java/shape-effective-properties/); ele retorna os valores consolidados finais para recuos, espaçamento, quebra de linha, RTL e mais.