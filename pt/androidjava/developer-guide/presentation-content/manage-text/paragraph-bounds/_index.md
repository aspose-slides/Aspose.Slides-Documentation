---
title: Obter Limites de Parágrafo de Apresentações no Android
linktitle: Limites de Parágrafo
type: docs
weight: 43
url: /pt/androidjava/paragraph-bounds/
keywords:
- limites de parágrafo
- coordenada de parágrafo
- tamanho de parágrafo
- quadro de texto
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda como recuperar os limites de parágrafo no Aspose.Slides para Android via Java para otimizar o posicionamento de texto em apresentações do PowerPoint."
---
## **Visão geral**

Este artigo explica como obter os limites, o tamanho e as coordenadas de parágrafos no Aspose.Slides. Ele mostra como recuperar um retângulo de parágrafo a partir de um [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) usando [IParagraph.getRect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IParagraph#getRect--), como obter as coordenadas do parágrafo dentro de um text frame de célula de tabela e destaca detalhes importantes, como unidades de medida, o efeito da quebra de linha nos limites, conversão de pixels e valores efetivos de formatação de parágrafo.

## **Obter Coordenadas Retangulares de um Parágrafo**

Use [IParagraph.getRect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IParagraph#getRect--) para obter o retângulo delimitador de um parágrafo.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Obter o Tamanho de um Parágrafo Dentro de um TextFrame de Célula de Tabela**

Para obter o tamanho e as coordenadas de um [IParagraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/) em um text frame de célula de tabela, use [IParagraph.getRect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IParagraph#getRect--). O retângulo retornado é relativo ao text frame da célula da tabela, portanto adicione a posição da tabela e o deslocamento da célula quando precisar de coordenadas ao nível do slide.

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

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

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

**Em quais unidades as coordenadas do parágrafo são medidas?**

São medidas em pontos, onde 1 polegada equivale a 72 pontos. Isso se aplica a todas as coordenadas e dimensões no slide.

**A quebra de linha afeta os limites de um parágrafo?**

Sim. Se [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) estiver habilitado para o [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/), o texto será quebrado para se ajustar à largura da área, o que altera os limites reais do parágrafo.

**As coordenadas do parágrafo podem ser mapeadas de forma confiável para pixels na imagem exportada?**

Sim. Converta pontos para pixels usando esta fórmula: pixels = points × (DPI / 72). O resultado depende do DPI escolhido para a renderização ou exportação.

**Como obter os parâmetros de formatação “efetiva” do parágrafo, levando em conta a herança de estilos?**

Use a [estrutura de dados de formatação de parágrafo efetiva](/slides/pt/androidjava/shape-effective-properties/); ela retorna os valores consolidados finais para recuos, espaçamento, quebra de linha, RTL e muito mais.