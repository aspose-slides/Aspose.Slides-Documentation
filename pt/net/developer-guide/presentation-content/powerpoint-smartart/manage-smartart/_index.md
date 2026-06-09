---
title: Gerenciar SmartArt em Apresentações do PowerPoint no .NET
linktitle: Gerenciar SmartArt
type: docs
weight: 10
url: /pt/net/manage-smartart/
keywords:
- SmartArt
- texto SmartArt
- tipo de layout
- propriedade oculta
- organograma
- organograma de imagens
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a criar e editar SmartArt do PowerPoint com Aspose.Slides para .NET usando exemplos de código C# claros que aceleram o design e a automação de slides."
---
## **Visão geral**

SmartArt é um diagrama do PowerPoint composto por nós, formas de nó e um layout. Com o Aspose.Slides para .NET, você pode criar SmartArt, ler texto de seus nós, alterar seu layout, inspecionar nós ocultos, configurar layouts de organogramas e criar organogramas de imagens.

## **Obter texto de um objeto SmartArt**

Um nó SmartArt pode conter uma ou mais formas. Para ler o texto visível, itere através de [ISmartArt.AllNodes](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/ismartart/allnodes/), então leia o [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/) retornado por [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/ismartartshape/textframe/).

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **Alterar o tipo de layout de um objeto SmartArt**

O layout do SmartArt controla como os nós são organizados e conectados. O exemplo a seguir cria um objeto SmartArt com o valor `BasicBlockList` do [SmartArtLayoutType](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/smartartlayouttype/), altera para o valor `BasicProcess` e salva a apresentação.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Verificar se um nó SmartArt está oculto**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/ismartartnode/ishidden/) indica se o nó está oculto no modelo de dados do SmartArt. Nós ocultos podem existir na estrutura mesmo quando o layout selecionado não os exibe como elementos visíveis do diagrama.

O exemplo a seguir adiciona um nó a um objeto SmartArt que usa o valor `RadialCycle` do [SmartArtLayoutType](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/smartartlayouttype/) e verifica o estado oculto do nó.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **Obter ou definir o layout do organograma**

Para diagramas SmartArt que utilizam um layout de organograma, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) define como os nós filhos são organizados sob um nó pai. Por exemplo, você pode definir que os nós filhos pendam à esquerda, à direita ou em ambos os lados, dependendo do [OrganizationChartLayoutType](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/organizationchartlayouttype/) selecionado.

O exemplo a seguir cria um organograma e define o layout do primeiro nó para o valor `LeftHanging` do [OrganizationChartLayoutType](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/organizationchartlayouttype/).

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Criar um organograma de imagens**

Um organograma de imagens é um layout SmartArt projetado para diagramas hierárquicos que incluem espaços reservados para imagens. Use o valor `PictureOrganizationChart` do [SmartArtLayoutType](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/smartartlayouttype/) ao adicionar o objeto SmartArt a um slide.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **Perguntas frequentes**

**O SmartArt oferece suporte a espelhamento ou reversão para idiomas RTL?**

Sim. A propriedade [IsReversed](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/smartart/isreversed/) altera a direção do diagrama de esquerda‑para‑direita para direita‑para‑esquerda, ou vice‑versa, quando o layout SmartArt selecionado oferece suporte à reversão.

**Como copiar um SmartArt para o mesmo slide ou para outra apresentação preservando a formatação?**

Você pode [clonar a forma SmartArt](/slides/pt/net/shape-manipulations/) com [ShapeCollection.AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/shapecollection/addclone/) ou [clonar o slide inteiro](/slides/pt/net/clone-slides/) que contém o SmartArt. Ambas as abordagens preservam tamanho, posição e formatação.

**Como renderizar um SmartArt para uma imagem raster para visualização ou exportação web?**

[Renderize o slide](/slides/pt/net/convert-powerpoint-to-png/) ou a apresentação inteira para PNG ou JPEG. O SmartArt é renderizado como parte do slide.

**Como encontrar um objeto SmartArt específico em um slide se houver vários?**

Defina um [AlternativeText](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/alternativetext/) ou um valor [Name](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/name/) distintivo na forma SmartArt, procure esse valor em [Slide.Shapes](https://reference.aspose.com/slides/pt/net/aspose.slides/baseslide/shapes/), e então verifique se a forma correspondente é um [ISmartArt](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/ismartart/).