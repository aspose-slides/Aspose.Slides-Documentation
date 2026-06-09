---
title: Adicionar Formas de Linha a Apresentações em .NET
linktitle: Linha
type: docs
weight: 50
url: /pt/net/Line/
keywords:
- linha
- criar linha
- adicionar linha
- linha simples
- configurar linha
- personalizar linha
- estilo de traço
- ponta de seta
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a manipular a formatação de linhas em apresentações PowerPoint com Aspose.Slides para .NET. Descubra propriedades, métodos e exemplos."
---
## **Visão geral**

Aspose.Slides permite adicionar formas de linha aos slides do PowerPoint programaticamente. Este artigo mostra como criar uma linha simples e como personalizar uma linha para que apareça como uma seta.

Você aprenderá como adicionar uma forma de linha a um slide, ajustar sua aparência visual e salvar a apresentação atualizada. Os exemplos focam em configurações práticas de formatação de linha, como estilo, largura, padrão de traço, opções de ponta de seta e cor de preenchimento.

## **Criar uma Linha Simples**
Para adicionar uma linha simples a um slide selecionado da apresentação, siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um AutoShape do tipo Linha usando o método [AddAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/methods/addautoshape/index) exposto pelo objeto Shapes.
- Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma linha ao primeiro slide da apresentação.

```c#
// Instanciar a classe PresentationEx que representa o arquivo PPTX
using (Presentation pres = new Presentation())
{
    // Obter o primeiro slide
    ISlide sld = pres.Slides[0];

    // Adicionar um autoshape do tipo linha
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Gravar o PPTX no disco
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Criar uma Linha com Seta**
Aspose.Slides para .NET também permite aos desenvolvedores configurar algumas propriedades da linha para torná‑la mais atraente. Vamos configurar algumas propriedades de uma linha para que ela se pareça com uma seta. Siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/pt/aspose.slides/)[](http://www.aspose.com/api/net/slides/pt/aspose.slides/).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um AutoShape do tipo Linha usando o método AddAutoShape exposto pelo objeto Shapes.
- Defina o Estilo da Linha para um dos estilos oferecidos pelo Aspose.Slides para .NET.
- Defina a Largura da linha.
- Defina o [Dash Style](https://reference.aspose.com/slides/pt/net/aspose.slides/linedashstyle) da linha para um dos estilos oferecidos pelo Aspose.Slides para .NET.
- Defina o [Arrow Head Style](https://reference.aspose.com/slides/pt/net/aspose.slides/linearrowheadstyle) e o Comprimento do ponto inicial da linha.
- Defina o [Arrow Head Style](https://reference.aspose.com/slides/pt/net/aspose.slides/linearrowheadstyle) e o Comprimento do ponto final da linha.
- Grave a apresentação modificada como um arquivo PPTX.

```c#
// Instanciar a classe PresentationEx que representa o arquivo PPTX
using (Presentation pres = new Presentation())
{

    // Obter o primeiro slide
    ISlide sld = pres.Slides[0];

    // Adicionar um autoshape do tipo linha
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Aplicar alguma formatação na linha
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //Gravar o PPTX no disco
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Posso converter uma linha normal em um conector para que ela "encaixe" nas formas?**

Não. Uma linha regular (um [AutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/autoshape/) do tipo [Line](https://reference.aspose.com/slides/pt/net/aspose.slides/shapetype/)) não se torna automaticamente um conector. Para que ela encaixe nas formas, use o tipo [Connector](https://reference.aspose.com/slides/pt/net/aspose.slides/connector/) dedicado e as [corresponding APIs](/slides/pt/net/connector/) para conexões.

**O que devo fazer se as propriedades de uma linha forem herdadas do tema e for difícil determinar os valores finais?**

[Leia as propriedades efetivas](/slides/pt/net/shape-effective-properties/) através das interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/ilinefillformateffectivedata/) — estas já consideram a herança e os estilos do tema.

**Posso bloquear uma linha contra edição (movimento, redimensionamento)?**

Sim. As Shapes fornecem [lock objects](https://reference.aspose.com/slides/pt/net/aspose.slides/autoshape/autoshapelock/) que permitem [impedir operações de edição](/slides/pt/net/applying-protection-to-presentation/).