---
title: Obter limites de parágrafo de apresentações em Java
linktitle: Limites de parágrafo
type: docs
weight: 43
url: /pt/java/paragraph-bounds/
keywords:
- limites de parágrafo
- coordenada de parágrafo
- tamanho de parágrafo
- quadro de texto
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda como recuperar os limites de parágrafo no Aspose.Slides for Java para otimizar o posicionamento de texto em apresentações do PowerPoint."
---
## **Visão geral**

Este artigo explica como obter os limites, o tamanho e as coordenadas de parágrafos no Aspose.Slides. Ele mostra como recuperar um retângulo de parágrafo a partir de um [ITextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/) usando [IParagraph.getRect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IParagraph#getRect--), como obter as coordenadas do parágrafo dentro de um quadro de texto de célula de tabela e destaca detalhes importantes, como unidades de medida, o efeito da quebra de texto nos limites, conversão de pixels e valores de formatação de parágrafo efetivos.

## **Obter coordenadas retangulares de um parágrafo**

Use [IParagraph.getRect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IParagraph#getRect--) para obter o retângulo delimitador de um parágrafo.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Obter o tamanho de um parágrafo dentro de um TextFrame de célula de tabela**

Para obter o tamanho e as coordenadas de um [IParagraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraph/) em um quadro de texto de célula de tabela, use [IParagraph.getRect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IParagraph#getRect--). O retângulo retornado é relativo ao quadro de texto da célula da tabela, portanto adicione a posição da tabela e o deslocamento da célula quando precisar de coordenadas ao nível do slide.

O exemplo a seguir obtém os limites do parágrafo dentro de uma célula de tabela e desenha retângulos no slide para visualizar esses limites:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Em que unidades as coordenadas do parágrafo são medidas?**

São medidas em pontos, onde 1 polegada equivale a 72 pontos. Isso se aplica a todas as coordenadas e dimensões no slide.

**A quebra de linha afeta os limites de um parágrafo?**

Sim. Se [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) estiver habilitado para o [ITextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/), o texto será quebrado para se ajustar à largura da área, alterando os limites reais do parágrafo.

**As coordenadas do parágrafo podem ser mapeadas de forma confiável para pixels na imagem exportada?**

Sim. Converta pontos para pixels usando esta fórmula: pixels = points x (DPI / 72). O resultado depende do DPI escolhido para a renderização ou exportação.

**Como obter os parâmetros de formatação de parágrafo “efetivos”, levando em conta a herança de estilo?**

Use a [effective paragraph formatting data structure](/slides/pt/java/shape-effective-properties/); ela retorna os valores finais consolidados para recuos, espaçamento, quebra de linha, RTL e muito mais.