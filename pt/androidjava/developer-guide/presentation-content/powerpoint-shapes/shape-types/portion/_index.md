---
title: Gerenciar Porções de Texto em Apresentações no Android
linktitle: Porção de Texto
type: docs
weight: 70
url: /pt/androidjava/portion/
keywords:
- porção de texto
- parte de texto
- coordenadas de texto
- posição do texto
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda a gerenciar porções de texto em apresentações PowerPoint usando Aspose.Slides para Android via Java, aprimorando desempenho e personalização."
---
## **Introdução**

Uma porção de texto representa um fragmento específico de texto dentro de um parágrafo e permite que você trabalhe com esse fragmento de forma independente do conteúdo ao redor. No Aspose.Slides, as porções podem ser usadas quando você precisa obter a posição de um fragmento de texto, aplicar formatação apenas a parte de um parágrafo ou controlar o comportamento do texto em um nível mais detalhado.

## **Obter coordenadas de uma porção de texto**
[**getCoordinates()**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPortion#getCoordinates--) O método foi adicionado às classes [IPortion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/) e [Portion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/portion/) e permite recuperar as coordenadas do início da porção.

```java
// Instanciar a classe Presentation que representa o PPTX
Presentation pres = new Presentation();
try {
    // Reformulando o contexto da apresentação
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

## **Perguntas frequentes**

**Posso aplicar um hyperlink apenas a parte do texto dentro de um único parágrafo?**

Sim, você pode [atribuir um hyperlink](/slides/pt/androidjava/manage-hyperlinks/) a uma porção individual; apenas esse fragmento será clicável, não o parágrafo inteiro.

**Como funciona a herança de estilo: o que uma Portion substitui e o que é herdado do Paragraph/TextFrame?**

As propriedades ao nível da Portion têm a precedência mais alta. Se uma propriedade não estiver definida na [Portion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/portion/), o mecanismo a obtém do [Paragraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/paragraph/); se também não estiver definida lá, do [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframe/) ou do estilo do [theme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/theme/).

**O que acontece se a fonte especificada para uma Portion estiver ausente na máquina/servidor de destino?**

As [regras de substituição de fontes](/slides/pt/androidjava/font-selection-sequence/) são aplicadas. O texto pode ser realinhado: métricas, hifenização e largura podem mudar, o que importa para posicionamento preciso.

**Posso definir transparência ou gradiente de preenchimento de texto específico de uma Portion independentemente do resto do parágrafo?**

Sim, a cor do texto, o preenchimento e a transparência ao nível da [Portion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/portion/) podem ser diferentes dos fragmentos vizinhos.