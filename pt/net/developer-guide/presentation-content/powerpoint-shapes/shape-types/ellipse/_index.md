---
title: Adicionar Elipses a Apresentações em .NET
linktitle: Elipse
type: docs
weight: 30
url: /pt/net/ellipse/
keywords:
- elipse
- forma
- adicionar elipse
- criar elipse
- desenhar elipse
- elipse formatada
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a criar, formatar e manipular formas de elipse no Aspose.Slides para .NET em apresentações PPT e PPTX — exemplos de código C# incluídos."
---
## **Visão geral**

Este artigo mostra como adicionar formas de elipse aos slides do PowerPoint usando o Aspose.Slides. Ele cobre a criação de uma elipse simples, a criação de uma elipse formatada e a gravação da apresentação atualizada como um arquivo PPTX. Também aborda questões relacionadas, como trabalhar com a posição e o tamanho da elipse, controlar a ordem de empilhamento e aplicar efeitos de animação.

## **Criar uma Elipse**
Para adicionar uma elipse simples a um slide selecionado da apresentação, siga as etapas abaixo:

1. Crie uma instância da classe [Apresentação ](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation)
1. Obtenha a referência de um slide usando seu índice
1. Adicione um AutoShape do tipo Elipse usando o método AddAutoShape exposto pelo objeto IShapes
1. Grave a apresentação modificada como um arquivo PPTX

No exemplo abaixo, adicionamos uma elipse ao primeiro slide.

```c#
// Instanciar a classe Presentation que representa o PPTX
using (Presentation pres = new Presentation())
{

    // Obter o primeiro slide
    ISlide sld = pres.Slides[0];

    // Adicionar forma automática do tipo elipse
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //Gravar o arquivo PPTX no disco
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```

## **Criar uma Elipse Formatada**
Para adicionar uma elipse melhor formatada a um slide, siga as etapas abaixo:

1. Crie uma instância da classe [Apresentação ](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Obtenha a referência de um slide usando seu índice.
1. Adicione um AutoShape do tipo Elipse usando o método AddAutoShape exposto pelo objeto IShapes.
1. Defina o Tipo de Preenchimento da Elipse como Sólido.
1. Defina a Cor da Elipse usando a propriedade SolidFillColor.Color exposta pelo objeto FillFormat associado ao objeto IShape.
1. Defina a Cor das linhas da Elipse.
1. Defina a Largura das linhas da Elipse.
1. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma elipse formatada ao primeiro slide da apresentação.

```c#
    // Instanciar a classe Presentation que representa o PPTX
    using (Presentation pres = new Presentation())
    {
    
        // Obter o primeiro slide
        ISlide sld = pres.Slides[0];
    
        // Adicionar forma automática do tipo elipse
        IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
        // Aplicar alguma formatação à forma elipse
        shp.FillFormat.FillType = FillType.Solid;
        shp.FillFormat.SolidFillColor.Color = Color.Chocolate;
    
        // Aplicar alguma formatação à linha da elipse
        shp.LineFormat.FillFormat.FillType = FillType.Solid;
        shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
        shp.LineFormat.Width = 5;
    
        //Write o arquivo PPTX no disco
        pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
    }
```

## **Perguntas Frequentes**

**Como definir a posição exata e o tamanho de uma elipse em relação às unidades do slide?**

As coordenadas e tamanhos são normalmente especificados **em pontos**. Para resultados previsíveis, baseie seus cálculos no tamanho do slide e converta os milímetros ou polegadas necessários para pontos antes de atribuir os valores.

**Como posso colocar uma elipse acima ou abaixo de outros objetos (controlar a ordem de empilhamento)?**

Ajuste a ordem de desenho do objeto trazendo‑o para a frente ou enviando‑o para trás. Isso permite que a elipse se sobreponha a outros objetos ou revele os que estão abaixo dela.

**Como animar a aparição ou ênfase de uma elipse?**

Use [Aplicar](/slides/pt/net/shape-animation/) efeitos de entrada, ênfase ou saída na forma, e configure gatilhos e temporização para orquestrar quando e como a animação será reproduzida.