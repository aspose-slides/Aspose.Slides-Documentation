---
title: Obter limites de porção de texto em apresentações no Android
linktitle: Limites da Porção
type: docs
weight: 47
url: /pt/androidjava/portion-bounds/
keywords:
- limites de porção de texto
- porção de texto
- parte de texto
- coordenadas de texto
- posição do texto
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda como recuperar os limites de porção de texto em apresentações PowerPoint usando Aspose.Slides para Android via Java."
---
## **Visão geral**

Uma porção de texto representa um fragmento específico de texto dentro de um parágrafo e permite que você trabalhe com esse fragmento de forma independente do conteúdo ao redor. No Aspose.Slides, as porções podem ser usadas quando você precisa obter os limites de um fragmento de texto, aplicar formatação apenas a parte de um parágrafo ou controlar o comportamento do texto em um nível mais detalhado.

Este artigo mostra como obter o retângulo delimitador de uma porção usando [IPortion.getRect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPortion#getRect--). Também mostra como obter as coordenadas do início de uma porção usando [IPortion.getCoordinates](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPortion#getCoordinates--). Além disso, destaca cenários comuns relacionados a porções, como aplicar um hiperlink a um único fragmento de texto, entender como a formatação é resolvida por meio da herança de porção, parágrafo, moldura de texto e tema, e lidar com casos em que uma fonte especificada está indisponível.

## **Obter limites de uma porção de texto**

Use [IPortion.getRect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPortion#getRect--) para recuperar o retângulo delimitador de uma porção de texto:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Obter coordenadas de uma porção de texto**

Use [IPortion.getCoordinates](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPortion#getCoordinates--) para recuperar as coordenadas do início de uma porção de texto:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Perguntas frequentes**

**Posso aplicar um hiperlink apenas a parte do texto dentro de um único parágrafo?**

Sim, você pode [atribuir um hiperlink](/slides/pt/androidjava/manage-hyperlinks/) a uma porção individual; apenas esse fragmento será clicável, não o parágrafo inteiro.

**Como funciona a herança de estilo: o que uma porção sobrescreve e o que é herdado de um parágrafo ou de um quadro de texto?**

As propriedades no nível da porção têm a maior precedência. Se uma propriedade não estiver definida na [IPortion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/), o Aspose.Slides a obtém da [IParagraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/). Se também não estiver definida lá, o Aspose.Slides usa o estilo da [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) ou do [theme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/theme/).

**O que acontece se a fonte especificada para uma porção estiver ausente na máquina ou servidor de destino?**

As [regras de substituição de fonte](/slides/pt/androidjava/font-selection-sequence/) são aplicadas. O texto pode ser reorganizado: métricas, hifenização e largura podem mudar, o que importa para posicionamento preciso.

**Posso definir transparência de preenchimento de texto ou um gradiente específicos para a porção independentemente do resto do parágrafo?**

Sim, a cor do texto, preenchimento e transparência no nível do [IPortion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/) podem diferir dos fragmentos vizinhos.