---
title: Gerenciar Porções de Texto em Apresentações com Python
linktitle: Porção de Texto
type: docs
weight: 70
url: /pt/python-net/portion/
keywords:
- porção de texto
- parte de texto
- coordenadas de texto
- posição de texto
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Saiba como gerenciar porções de texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via .NET, aumentando o desempenho e a personalização."
---
## **Introdução**

Uma porção de texto representa um fragmento específico de texto dentro de um parágrafo e permite trabalhar com esse fragmento independentemente do conteúdo ao redor. No Aspose.Slides, as porções podem ser usadas quando você precisa recuperar a posição de um fragmento de texto, aplicar formatação apenas a parte de um parágrafo ou controlar o comportamento do texto em um nível mais detalhado.

## **Obter coordenadas das porções de texto**

O método [get_coordinates](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/get_coordinates/) foi adicionado à classe [Portion](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/) que permite recuperar as coordenadas das porções de texto:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **FAQ**

**Posso aplicar um hyperlink apenas a parte do texto dentro de um único parágrafo?**

Sim, você pode [atribuir um hyperlink](/slides/pt/python-net/manage-hyperlinks/) a uma porção individual; apenas esse fragmento será clicável, não todo o parágrafo.

**Como funciona a herança de estilo: o que uma Portion substitui e o que é herdado de Paragraph/TextFrame?**

As propriedades no nível da Portion têm a maior precedência. Se uma propriedade não estiver definida na [Portion](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/), o mecanismo a obtém da [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/); se também não estiver definida ali, ele a obtém da [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) ou do estilo do [theme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/theme/).

**O que acontece se a fonte especificada para uma Portion estiver ausente na máquina/servidor de destino?**

As [Regras de substituição de fontes](/slides/pt/python-net/font-selection-sequence/) são aplicadas. O texto pode reformatar: métricas, hifenização e largura podem mudar, o que é importante para um posicionamento preciso.

**Posso definir transparência ou gradiente de preenchimento de texto específico de uma Portion independentemente do restante do parágrafo?**

Sim, a cor do texto, o preenchimento e a transparência no nível da [Portion](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/) podem ser diferentes dos fragmentos vizinhos.