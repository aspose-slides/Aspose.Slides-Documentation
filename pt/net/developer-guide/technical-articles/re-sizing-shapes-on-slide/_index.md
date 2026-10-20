---
title: Redimensionar formas em slides de apresentação no .NET
type: docs
weight: 130
url: /pt/net/resizing-shapes-on-slide/
aliases:
  - /pt/net/re-sizing-shapes-on-slide/
  /net/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- alterar tamanho da forma
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Redimensione facilmente formas em slides PowerPoint e OpenDocument com Aspose.Slides para .NET—automatize ajustes de layout de slides e aumente a produtividade."
---
## **Visão geral**

Ao alterar o tamanho do slide de uma apresentação, pode ser necessário redimensionar e reposicionar suas formas para que se ajustem às novas dimensões. Este artigo mostra como escalar formas manualmente e como lidar com tabelas em slides, mestres e layouts.

## **Redimensionar formas**

Para preservar a posição e o tamanho relativos de cada forma, multiplique suas coordenadas horizontais e a largura pela razão entre a nova largura do slide e a largura original. Aplique a razão de altura correspondente às coordenadas verticais e à altura.

O primeiro exemplo carrega uma apresentação cujos slides não contêm tabelas, altera o tamanho do slide para A4 e salva o resultado. Ele usa [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) com [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) para que o loop subsequente controle a escala. As razões são adimensionais; as posições e dimensões das formas são medidas em pontos. Razões diferentes de largura e altura podem distorcer as formas, e alterar as dimensões de uma forma não escala os tamanhos das fontes.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Calcule fatores de escala horizontais e verticais independentes.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Nota" %}}
Tabelas exigem tratamento separado: escale as larguras das colunas e as alturas das linhas em vez de atribuir a largura e a altura gerais da tabela. As alturas das linhas podem permanecer maiores que o solicitado se o conteúdo da célula precisar de mais espaço.
{{% /alert %}}

O segundo exemplo suporta tabelas e processa formas em mestres e layouts, bem como em slides individuais, antes de salvar a apresentação redimensionada. Seu auxiliar trata cada [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) escalando [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) e [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/). Em seguida, escala a posição da tabela sem escalar separadamente suas dimensões gerais.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Calcule fatores de escala horizontais e verticais independentes.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Redimensione formas definidas em mestres e layouts, bem como em slides individuais.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // As dimensões da tabela são controladas pelas larguras das colunas e pelas alturas das linhas.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **FAQ**

**Por que as formas ficam distorcidas ou cortadas após redimensionar um slide?**

Se você alterar o tamanho do slide sem escalar as formas, elas mantêm suas posições e dimensões originais e podem ultrapassar o slide. Escalar largura e altura por razões diferentes também pode distorcer as formas.

**O código fornecido funciona para todos os tipos de forma?**

O primeiro exemplo altera os limites da forma diretamente e destina‑se a slides sem tabelas. O segundo exemplo trata as tabelas separadamente. Verifique o layout resultante, particularmente texto e tabelas, pois esses exemplos não escalam tamanhos de fonte e o conteúdo da tabela pode restringir as alturas das linhas.

**Como redimensionar tabelas ao redimensionar um slide?**

Escale as larguras das colunas pela razão de largura e as alturas mínimas das linhas pela razão de altura, depois escale a posição da tabela, como mostrado no segundo exemplo.

**Esse redimensionamento funciona para slides mestres e slides de layout?**

Sim. O segundo exemplo itera através de [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) e de cada [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) do mestre, aplicando a mesma lógica de redimensionamento às suas formas.

**Posso alterar a orientação de um slide (retrato/paisagem) junto com o redimensionamento?**

Sim. Defina [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) após alterar o tamanho do slide e antes de ler as dimensões-alvo, para que os fatores de escala reflitam a orientação final.

**Existe um limite para o tamanho do slide que posso definir?**

Você pode especificar dimensões de slide personalizadas com [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). As dimensões suportadas também dependem do formato da apresentação e da aplicação usada para abrir o arquivo.

**Como impedir que formas com proporção fixa fiquem distorcidas?**

Use o mesmo fator de escala para largura e altura. Para ajustar o layout original dentro das novas dimensões do slide, use a menor das duas razões (largura ou altura) para ambas as dimensões e posições. Isso preserva as proporções, mas pode deixar espaço não utilizado em uma das bordas.