---
title: Adicionar Elipses a Apresentações em C++
linktitle: Elipse
type: docs
weight: 30
url: /pt/cpp/ellipse/
keywords:
- elipse
- forma
- adicionar elipse
- criar elipse
- desenhar elipse
- elipse formatada
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a criar, formatar e manipular formas de elipse no Aspose.Slides para C++ em apresentações PPT e PPTX — exemplos de código C++ incluídos."
---
## **Visão geral**

Este artigo mostra como adicionar formas de elipse aos slides do PowerPoint usando Aspose.Slides. Ele cobre a criação de uma elipse simples, a criação de uma elipse formatada e a gravação da apresentação atualizada como um arquivo PPTX. Também aborda questões relacionadas, como trabalhar com a posição e o tamanho da elipse, controlar a ordem de empilhamento e aplicar efeitos de animação.

## **Criar uma Elipse**
Neste tópico, apresentaremos aos desenvolvedores como adicionar formas de elipse aos seus slides usando Aspose.Slides for C++. Aspose.Slides for C++ fornece um conjunto mais simples de APIs para desenhar diferentes tipos de formas com apenas algumas linhas de código. Para adicionar uma elipse simples a um slide selecionado da apresentação, siga as etapas abaixo:

1. Crie uma instância da [classe Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/)
1. Obtenha a referência de um slide usando seu Índice
1. Adicione um AutoShape do tipo Ellipse usando o método AddAutoShape exposto pelo objeto IShapes
1. Grave a apresentação modificada como um arquivo PPTX

No exemplo abaixo, adicionamos uma elipse ao primeiro slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **Criar uma Elipse Formatada**
Para adicionar uma elipse melhor formatada a um slide, siga as etapas abaixo:

1. Crie uma instância da [classe Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Obtenha a referência de um slide usando seu Índice.
1. Adicione um AutoShape do tipo Ellipse usando o método AddAutoShape exposto pelo objeto IShapes.
1. Defina o Tipo de Preenchimento da Elipse como Sólido.
1. Defina a Cor da Elipse usando a propriedade SolidFillColor.Color exposta pelo objeto FillFormat associado ao objeto IShape.
1. Defina a Cor das linhas da Elipse.
1. Defina a Largura das linhas da Elipse.
1. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma elipse formatada ao primeiro slide da apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **FAQ**

**Como defino a posição exata e o tamanho de uma elipse em relação às unidades do slide?**

As coordenadas e tamanhos são normalmente especificados **em pontos**. Para resultados previsíveis, baseie seus cálculos no tamanho do slide e converta os milímetros ou polegadas necessários para pontos antes de atribuir os valores.

**Como posso posicionar uma elipse acima ou abaixo de outros objetos (controlar a ordem de empilhamento)?**

Ajuste a ordem de desenho do objeto trazendo-o para a frente ou enviando-o para trás. Isso permite que a elipse sobreponha outros objetos ou revele os que estão abaixo dela.

**Como faço para animar a aparência ou ênfase de uma elipse?**

[Aplicar](/slides/pt/cpp/shape-animation/) efeitos de entrada, ênfase ou saída à forma, e configure gatilhos e cronometragem para orquestrar quando e como a animação é reproduzida.