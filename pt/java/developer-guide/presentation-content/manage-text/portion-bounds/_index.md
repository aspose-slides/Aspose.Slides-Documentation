---
title: Obter limites da porção de texto em apresentações Java
linktitle: Limites da Porção
type: docs
weight: 47
url: /pt/java/portion-bounds/
keywords:
- limites da porção de texto
- porção de texto
- parte de texto
- coordenadas de texto
- posição do texto
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda como recuperar os limites da porção de texto em apresentações PowerPoint usando Aspose.Slides para Java."
---
## **Visão geral**

Uma porção de texto representa um fragmento específico de texto dentro de um parágrafo e permite que você trabalhe com esse fragmento de forma independente do conteúdo ao redor. No Aspose.Slides, as porções podem ser usadas quando você precisa obter os limites de um fragmento de texto, aplicar formatação apenas a parte de um parágrafo ou controlar o comportamento do texto em um nível mais detalhado.

Este artigo mostra como obter o retângulo delimitador de uma porção usando [IPortion.getRect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPortion#getRect--). Também mostra como obter as coordenadas do início de uma porção usando [IPortion.getCoordinates](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPortion#getCoordinates--). Além disso, destaca cenários comuns relacionados a porções, como aplicar um hiperlink a um único fragmento de texto, entender como a formatação é resolvida por herança de porção, parágrafo, quadro de texto e tema, e lidar com casos em que uma fonte especificada não está disponível.

## **Obter limites de uma porção de texto**

Use [IPortion.getRect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPortion#getRect--) para recuperar o retângulo delimitador de uma porção de texto:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Obter coordenadas de uma porção de texto**

Use [IPortion.getCoordinates](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPortion#getCoordinates--) para recuperar as coordenadas do início de uma porção de texto:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso aplicar um hiperlink apenas a parte do texto dentro de um único parágrafo?**

Sim, você pode [atribuir um hiperlink](/slides/pt/java/manage-hyperlinks/) a uma porção individual; apenas esse fragmento será clicável, não todo o parágrafo.

**Como funciona a herança de estilo: o que uma porção substitui e o que é herdado de um parágrafo ou quadro de texto?**

As propriedades ao nível de porção têm a precedência mais alta. Se uma propriedade não estiver definida na [IPortion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iportion/), o Aspose.Slides a obtém da [IParagraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraph/). Se também não estiver definida lá, o Aspose.Slides usa o estilo da [ITextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/) ou do [theme](https://reference.aspose.com/slides/pt/java/com.aspose.slides/theme/).

**O que acontece se a fonte especificada para uma porção estiver ausente na máquina ou servidor de destino?**

[Regras de substituição de fontes](/slides/pt/java/font-selection-sequence/) são aplicadas. O texto pode ser reformatado: métricas, hifenização e largura podem mudar, o que importa para o posicionamento preciso.

**Posso definir transparência ou gradiente de preenchimento de texto específico da porção independentemente do restante do parágrafo?**

Sim, a cor do texto, o preenchimento e a transparência no nível da [IPortion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iportion/) podem ser diferentes dos fragmentos vizinhos.