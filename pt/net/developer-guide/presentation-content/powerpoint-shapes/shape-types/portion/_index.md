---
title: Gerenciar Porções de Texto em Apresentações em .NET
linktitle: Porção de Texto
type: docs
weight: 70
url: /pt/net/portion/
keywords:
- porção de texto
- parte de texto
- coordenadas de texto
- posição de texto
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda como gerenciar porções de texto em apresentações PowerPoint usando Aspose.Slides para .NET, aumentando o desempenho e a customização."
---
## **Visão geral**

Uma porção de texto representa um fragmento específico de texto dentro de um parágrafo e permite que você trabalhe com esse fragmento de forma independente do conteúdo ao redor. No Aspose.Slides, as porções podem ser usadas quando você precisa obter a posição de um fragmento de texto, aplicar formatação apenas a parte de um parágrafo ou controlar o comportamento do texto em um nível mais detalhado.

Este artigo mostra como obter as coordenadas do início de uma porção usando o método `GetCoordinates()`. Ele também destaca cenários comuns relacionados a porções, como aplicar um hyperlink a um único fragmento de texto, entender como a formatação é resolvida por meio da herança de Portion, Paragraph, TextFrame e theme, e lidar com casos em que uma fonte especificada não está disponível. Além disso, observa que o preenchimento de texto, a cor e a transparência podem ser definidos de forma diferente para porções individuais dentro do mesmo parágrafo.

## **Obter coordenadas de uma porção de texto**
**GetCoordinates()** método foi adicionado à interface IPortion e à classe Portion, permitindo recuperar as coordenadas do início da porção:

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```

## **FAQ**

**Posso aplicar um hyperlink apenas a parte do texto dentro de um único parágrafo?**

Sim, você pode [atribuir um hyperlink](/slides/pt/net/manage-hyperlinks/) a uma porção individual; somente esse fragmento será clicável, não todo o parágrafo.

**Como funciona a herança de estilos: o que uma Portion sobrescreve e o que é herdado de Paragraph/TextFrame?**

Propriedades no nível de Portion têm a precedência mais alta. Se uma propriedade não estiver definida na [Portion](https://reference.aspose.com/slides/pt/net/aspose.slides/portion/), o mecanismo a obtém da [Paragraph](https://reference.aspose.com/slides/pt/net/aspose.slides/paragraph/); se também não estiver definida lá, da [TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/textframe/) ou do estilo do [theme](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/theme/).

**O que acontece se a fonte especificada para uma Portion estiver ausente na máquina/servidor de destino?**

As [Font substitution rules](/slides/pt/net/font-selection-sequence/) são aplicadas. O texto pode ser reformatado: métricas, hifenização e largura podem mudar, o que impacta o posicionamento preciso.

**Posso definir transparência ou gradiente de preenchimento de texto específico de uma Portion independente do restante do parágrafo?**

Sim, a cor, o preenchimento e a transparência do texto no nível da [Portion](https://reference.aspose.com/slides/pt/net/aspose.slides/portion/) podem ser diferentes dos fragmentos vizinhos.