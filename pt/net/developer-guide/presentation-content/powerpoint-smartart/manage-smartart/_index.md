---
title: Gerenciar SmartArt em Apresentações PowerPoint em .NET
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
- organograma com imagens
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a criar e editar SmartArt do PowerPoint com Aspose.Slides para .NET usando exemplos claros de código C# que aceleram o design de slides e a automação."
---
## **Visão geral**

SmartArt é um diagrama do PowerPoint composto por nós, formas de nós e um layout. Com Aspose.Slides para .NET, você pode criar SmartArt, ler texto de seus nós, alterar seu layout, inspecionar nós ocultos, configurar layouts de organogramas e criar organogramas de imagem.

## **Obter texto de um objeto SmartArt**

Um nó SmartArt pode conter uma ou mais formas. Para ler o texto das formas do nó, itere através de [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/), então leia o [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) retornado por [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/).

O exemplo requer uma apresentação com pelo menos um slide e um objeto SmartArt como a primeira forma nesse slide. Ele imprime cada quadro de texto disponível no console.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **Alterar o tipo de layout de um objeto SmartArt**

O layout do SmartArt controla como os nós são organizados e conectados. O exemplo a seguir cria um objeto SmartArt com o valor `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/), altera para o valor `BasicProcess` e salva a apresentação. A posição e o tamanho passados para [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) são medidos em pontos. Defina [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) para alterar o layout.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **Verificar se um nó SmartArt está oculto**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) indica se o nó está oculto no modelo de dados do SmartArt. Nós ocultos podem existir na estrutura mesmo quando o layout selecionado não os exibe como elementos de diagrama visíveis.

O exemplo a seguir adiciona um nó a um objeto SmartArt que usa o valor `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) e verifica o estado oculto do nó adicionado. Ele imprime uma mensagem se o nó estiver oculto e salva o diagrama.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **Obter ou definir o layout do organograma**

Para diagramas SmartArt que utilizam um layout de organograma, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) define como os nós filhos são organizados sob um nó pai. Por exemplo, você pode definir que os nós filhos pendam à esquerda, à direita ou em ambos os lados, dependendo do [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) selecionado.

O exemplo a seguir cria um organograma e define o layout do primeiro nó para o valor `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/). O índice baseado em zero `0` seleciona o primeiro nó de nível superior; seus nós filhos utilizam o arranjo selecionado. A apresentação modificada é então salva.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **Criar um organograma com imagens**

Um organograma com imagens é um layout SmartArt projetado para diagramas de hierarquia que incluem marcadores de posição de imagem. Use o valor `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) ao adicionar o objeto SmartArt a um slide. Este exemplo salva um diagrama com marcadores de posição de imagem; ele não preenche os marcadores com imagens.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **Converter diagramas legados em grupos de formas**

Ao modernizar uma apresentação existente, pode ser necessário atualizar um organograma criado originalmente no PowerPoint 97–2003. Aspose.Slides representa esses diagramas legados como objetos [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/). Use [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) para converter um diagrama em um grupo de formas, permitindo editar elementos visuais individuais. Consulte a [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/) para obter detalhes.

A conversão adiciona um novo grupo à coleção de formas sem remover o diagrama original. Após a conversão bem-sucedida, remova o original com [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) para evitar conteúdo duplicado. Reúna os diagramas legados em um array antes de convertê‑los para que a adição e remoção de formas não interrompam a iteração.

O exemplo a seguir abre uma apresentação, procura em cada slide, converte os diagramas em grupos de formas e salva a apresentação atualizada como PPTX.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

A apresentação salva contém grupos de formas editáveis no lugar dos diagramas legados convertidos, sem diagramas originais restantes ao lado deles. Abra o PPTX no PowerPoint para editar elementos individuais dentro de cada grupo, como texto, preenchimento ou posição.

## **Perguntas frequentes**

**O SmartArt oferece suporte a espelhamento ou inversão para idiomas RTL?**

Sim. A propriedade [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) muda a direção do diagrama de esquerda‑para‑direita para direita‑para‑esquerda, ou vice‑versa, quando o layout SmartArt selecionado oferece suporte a reversão.

**Como copiar um SmartArt para o mesmo slide ou para outra apresentação preservando a formatação?**

Você pode [clonar a forma SmartArt](/slides/pt/net/shape-manipulations/) com [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) ou [clonar o slide inteiro](/slides/pt/net/clone-slides/) que contém o SmartArt. Ambas as abordagens preservam tamanho, posição e formatação.

**Como renderizar um SmartArt em uma imagem raster para visualização ou exportação para a Web?**

[Renderize o slide](/slides/pt/net/convert-powerpoint-to-png/) ou a apresentação inteira para PNG ou JPEG. O SmartArt é renderizado como parte do slide.

**Como encontrar um objeto SmartArt específico em um slide se houver vários?**

Defina um valor distinto de [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) ou [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) na forma SmartArt, procure esse valor em [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), e então verifique se a forma correspondente é um [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/).