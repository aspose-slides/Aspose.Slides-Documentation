---
title: Obter limites de parágrafo de apresentações em Java
linktitle: Parágrafo
type: docs
weight: 60
url: /pt/java/paragraph/
keywords:
- limites de parágrafo
- limites de porção de texto
- coordenada de parágrafo
- coordenada de porção
- tamanho do parágrafo
- tamanho da porção de texto
- quadro de texto
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda como recuperar os limites de parágrafos e porções de texto no Aspose.Slides para Java para otimizar o posicionamento de texto em apresentações PowerPoint."
---
## **Visão geral**

Este artigo explica como obter os limites, tamanho e coordenadas de parágrafos e trechos de texto no Aspose.Slides. Ele mostra como recuperar o retângulo de um parágrafo em um `TextFrame` usando `getRect()`, como obter as coordenadas do parágrafo e da porção dentro de um quadro de texto de célula de tabela e destaca detalhes importantes, como unidades de medida, o efeito da quebra de linha nos limites, conversão para pixels e valores de formatação de parágrafo efetivos.

## **Obter coordenadas de parágrafo e porção em um TextFrame**
Usando o Aspose.Slides for Java, os desenvolvedores agora podem obter as coordenadas retangulares para o Parágrafo dentro da coleção de parágrafos de um TextFrame. Também permite obter [as coordenadas da porção](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPortion#getCoordinates--) dentro da coleção de porções de um parágrafo. Neste tópico, vamos demonstrar com um exemplo como obter as coordenadas retangulares do parágrafo juntamente com a posição da porção dentro do parágrafo.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **Obter coordenadas retangulares de um parágrafo**
Usando o método [**getRect()**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IParagraph#getRect--) os desenvolvedores podem obter o retângulo de limites do parágrafo.

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obter o tamanho de um parágrafo e porção dentro de um TextFrame de célula de tabela**

Para obter o tamanho e as coordenadas da [Portion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Portion) ou do [Paragraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Paragraph) em um TextFrame de célula de tabela, você pode usar os métodos [IPortion.getRect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPortion#getRect--) e [IParagraph.getRect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IParagraph#getRect--).

Este código de exemplo demonstra a operação descrita:

```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas frequentes**

**Em quais unidades as coordenadas retornadas para um parágrafo e trechos de texto são medidas?**

Em pontos, onde 1 polegada = 72 pontos. Isso se aplica a todas as coordenadas e dimensões no slide.

**A quebra de linha afeta os limites de um parágrafo?**

Sim. Se o [wrapping](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textframeformat/#setWrapText-byte-) estiver habilitado no [TextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textframe/), o texto será dividido para se ajustar à largura da área, o que altera os limites reais do parágrafo.

**As coordenadas do parágrafo podem ser mapeadas de forma confiável para pixels na imagem exportada?**

Sim. Converta pontos para pixels usando: pixels = points × (DPI / 72). O resultado depende do DPI escolhido para a renderização/exportação.

**Como obtenho os parâmetros de formatação de parágrafo “efetivos”, levando em conta a herança de estilo?**

Use a [estrutura de dados de formatação de parágrafo efetiva](/slides/pt/java/shape-effective-properties/); ela retorna os valores consolidados finais para recuos, espaçamento, quebra de linha, RTL e mais.