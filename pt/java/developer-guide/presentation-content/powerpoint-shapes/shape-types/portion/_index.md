---
title: Gerenciar Porções de Texto em Apresentações Usando Java
linktitle: Porção de Texto
type: docs
weight: 70
url: /pt/java/portion/
keywords:
- porção de texto
- parte de texto
- coordenadas de texto
- posição de texto
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda a gerenciar porções de texto em apresentações PowerPoint usando Aspose.Slides para Java, aumentando o desempenho e a personalização."
---
## **Visão geral**

Uma porção de texto representa um fragmento específico de texto dentro de um parágrafo e permite que você trabalhe com esse fragmento independentemente do conteúdo ao redor. No Aspose.Slides, as porções podem ser usadas quando você precisa recuperar a posição de um fragmento de texto, aplicar formatação apenas a parte de um parágrafo ou controlar o comportamento do texto em um nível mais detalhado.

Este artigo mostra como obter as coordenadas do início de uma porção usando o método `getCoordinates()`. Ele também destaca cenários comuns relacionados a porções, como aplicar um hiperlink a um único fragmento de texto, entender como a formatação é resolvida por meio da herança de porção, parágrafo, caixa de texto e tema, e lidar com casos em que uma fonte especificada não está disponível. Além disso, observa que o preenchimento, a cor e a transparência do texto podem ser definidos de forma diferente para cada porção dentro do mesmo parágrafo.

## **Obter coordenadas de uma porção de texto**
[**getCoordinates()**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPortion#getCoordinates--) method has been added to [IPortion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iportion/) and [Portion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/portion/) class which allows retrieving the coordinates of the beginning of the portion.

```java
// Instanciar a classe Presentation que representa o PPTX
Presentation pres = new Presentation();
try {
    // Reconfigurando o contexto da apresentação
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso aplicar um hiperlink apenas a parte do texto dentro de um único parágrafo?**

Sim, você pode [atribuir um hiperlink](/slides/pt/java/manage-hyperlinks/) a uma porção individual; apenas esse fragmento será clicável, não todo o parágrafo.

**Como funciona a herança de estilos: o que uma Porção sobrescreve e o que é herdado do Parágrafo/TextFrame?**

As propriedades no nível da Porção têm a precedência mais alta. Se uma propriedade não estiver definida na [Portion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/portion/), o motor a obtém do [Paragraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/paragraph/); se também não estiver definida lá, do [TextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textframe/) ou do estilo do [theme](https://reference.aspose.com/slides/pt/java/com.aspose.slides/theme/).

**O que acontece se a fonte especificada para uma Porção estiver ausente na máquina/servidor de destino?**

[Font substitution rules](/slides/pt/java/font-selection-sequence/) são aplicadas. O texto pode ser reformatado: métricas, hifenização e largura podem mudar, o que influencia o posicionamento preciso.

**Posso definir transparência ou gradiente de preenchimento de texto específico para uma Porção, independente do restante do parágrafo?**

Sim, a cor, o preenchimento e a transparência do texto no nível da [Portion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/portion/) podem ser diferentes dos fragmentos vizinhos.