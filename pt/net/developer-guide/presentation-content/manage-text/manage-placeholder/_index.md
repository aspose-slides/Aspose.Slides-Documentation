---
title: Gerenciar placeholders de apresentação em .NET
linktitle: Gerenciar placeholders
type: docs
weight: 10
url: /pt/net/manage-placeholder/
keywords:
- espaço reservado
- placeholder de texto
- placeholder de imagem
- placeholder de gráfico
- placeholder de conteúdo
- texto de sugestão
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a inspecionar e editar placeholders de texto, imagem, gráfico e conteúdo e a entender a herança de placeholders com Aspose.Slides para .NET."
---
## **Visão geral**

Um placeholder é uma forma que reserva uma posição para um determinado tipo de conteúdo em um modelo de apresentação. Exemplos comuns são placeholders de título, corpo, imagem, gráfico e de conteúdo de uso geral. Ao contrário de uma forma comum, um placeholder pode herdar sua posição, tamanho, formatação e outras configurações de um slide de layout ou slide mestre.

Aspose.Slides expõe as informações de placeholder através da propriedade [IShape.Placeholder](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/placeholder/). A propriedade retorna um objeto [IPlaceholder](https://reference.aspose.com/slides/pt/net/aspose.slides/iplaceholder/) ou `null` para uma forma normal. Use [IPlaceholder.Type](https://reference.aspose.com/slides/pt/net/aspose.slides/iplaceholder/type/) para determinar o que o placeholder deve conter.

A interface da forma ainda importa depois que você conhece o tipo de placeholder:

- Um placeholder de texto, imagem, gráfico ou conteúdo vazio costuma ser representado por um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/).
- Um placeholder de imagem preenchido pode ser representado por um [IPictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframe/).
- Um placeholder de gráfico preenchido pode ser representado por um [IChart](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichart/).
- Um placeholder de conteúdo pode conter vários tipos de conteúdo. Verifique tanto [IPlaceholder.Type](https://reference.aspose.com/slides/pt/net/aspose.slides/iplaceholder/type/) quanto a interface de forma em tempo de execução ao invés de assumir que todo placeholder é um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/pt/net/aspose.slides/iplaceholder/type/) descreve o papel de um placeholder; ele não garante o tipo de forma em tempo de execução. Sempre faça uma verificação de tipo antes de acessar membros específicos de texto, imagem, gráfico, tabela ou mídia.
{{% /alert %}}

## **Entender a herança de placeholders**

Placeholders formam uma hierarquia:

1. Um slide mestre define estilos reutilizáveis e, em alguns casos, placeholders de nível mestre.
2. Um slide de layout define o arranjo usado por um ou mais slides normais e pode herdar do mestre.
3. Um slide normal contém os placeholders para esse slide e pode herdar de seu layout.

Chame [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/getbaseplaceholder/) para subir um nível nesta hierarquia. Um placeholder de slide normalmente devolve seu placeholder de layout; um placeholder de layout pode devolver seu placeholder mestre. O método retorna `null` quando a forma não tem placeholder base.

O exemplo a seguir lista os placeholders no primeiro slide e relata seus placeholders base:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

Editar um placeholder em um slide normal cria ou altera uma substituição local para esse slide. Editar o layout ou mestre relacionado pode afetar todos os slides que ainda herdam essa configuração. Uma forma local ordinária não tem placeholder base e não começa a herdar apenas porque ocupa as mesmas coordenadas.

## **Alterar texto em um placeholder**

Placeholders de título, título centralizado, subtítulo, corpo e texto normalmente suportam texto. Verifique se é um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) antes de usar sua propriedade [TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/textframe/).

Este exemplo atualiza o primeiro placeholder de título no primeiro slide e salva o resultado:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

Esse padrão evita converter placeholders de imagem, gráfico, tabela ou mídia para [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/). Ele também identifica o placeholder por finalidade ao invés de depender de um índice de forma frágil.

## **Definir texto de sugestão em um layout**

O texto de sugestão é a instrução em tempo de design exibida em um placeholder vazio, como *Clique para adicionar título*. Defina um texto de sugestão personalizado no placeholder do layout ao invés de tentar acessá‑lo através da coleção de formas de um slide normal. Acesse o layout via [ISlide.LayoutSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/layoutslide/) e itere sobre [ILayoutSlide.Shapes](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide/shapes/).

O exemplo a seguir altera as sugestões de título e subtítulo no layout usado pelo primeiro slide:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

O texto de sugestão não é conteúdo de slide normal. Ele destina‑se a placeholders vazios em aplicações de edição como o PowerPoint. Quando um usuário ou programa fornece conteúdo real, a sugestão deixa de ser exibida. Alterar uma sugestão também não substitui o texto existente nos slides que utilizam o layout.

## **Atualizar um placeholder de imagem**

Existem dois casos a serem tratados:

- Se o placeholder de imagem já estiver preenchido e representado por um [IPictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframe/), substitua a imagem através de [IPictureFillFormat.Picture](https://reference.aspose.com/slides/pt/net/aspose.slides/ipicturefillformat/picture/) e [ISlidesPicture.Image](https://reference.aspose.com/slides/pt/net/aspose.slides/islidespicture/image/).
- Se ainda for um placeholder vazio, adicione um quadro de imagem nas coordenadas do placeholder usando [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/addpictureframe/) e remova o placeholder vazio.

O próximo exemplo suporta ambos os casos e salva a apresentação:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

A substituição criada para um placeholder vazio é um quadro de imagem local, não um novo placeholder, porque [IShape.Placeholder](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/placeholder/) é somente leitura. Ele mantém a posição reservada mas não herda mais o comportamento específico de placeholder. Se a retenção da relação de placeholder for essencial, prepare e preencha o placeholder no PowerPoint primeiro, então atualize o [IPictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframe/) resultante com Aspose.Slides.

Para transparência de imagem, recorte e outros efeitos específicos de imagem, consulte [Manage Picture Frames](/slides/pt/net/picture-frame/). Essas operações pertencem ao quadro de imagem ou ao preenchimento de imagem, não aos metadados do placeholder.

## **Trabalhar com placeholders de gráfico e conteúdo**

Um placeholder de gráfico preenchido pode ser representado por um [IChart](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichart/). Este exemplo localiza tal gráfico tanto pelo tipo de placeholder quanto pela interface em tempo de execução, altera seu título e salva o arquivo:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

Um placeholder de conteúdo geral geralmente tem [PlaceholderType.Object](https://reference.aspose.com/slides/pt/net/aspose.slides/placeholdertype/). No PowerPoint ele atua como um lançador para vários tipos de conteúdo, incluindo gráficos, tabelas, diagramas, imagens e mídia. Depois de preenchido, inspecione a interface real da forma para descobrir o que contém. Layouts especializados também podem expor [PlaceholderType.Chart](https://reference.aspose.com/slides/pt/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/pt/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/pt/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/pt/net/aspose.slides/placeholdertype/), ou [PlaceholderType.Diagram](https://reference.aspose.com/slides/pt/net/aspose.slides/placeholdertype/).

Aspose.Slides não converte um placeholder vazio de [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) em um [IChart](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichart/) apenas alterando [IPlaceholder.Type](https://reference.aspose.com/slides/pt/net/aspose.slides/iplaceholder/type/); o tipo é somente leitura. Para preencher programaticamente uma área de gráfico ou conteúdo vazia, adicione o objeto necessário nas coordenadas do placeholder e então remova o placeholder vazio. O exemplo a seguir faz isso para um gráfico:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

O gráfico adicionado é um gráfico local comum. Ele ocupa a área do placeholder, mas não herda do placeholder do layout. Use os artigos dedicados de [chart management](/slides/pt/net/powerpoint-charts/) quando precisar substituir suas categorias, séries ou dados da planilha.

## **Exemplo completo: atualizar texto ou conteúdo de imagem**

O exemplo completo a seguir abre um modelo, procura no primeiro slide um placeholder de título ou imagem, verifica os tipos de placeholder e forma, atualiza o conteúdo apropriado e salva o resultado. O exemplo evita deliberadamente supor um índice de forma ou converter todos os placeholders para a mesma interface.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **FAQ**

**O que é um placeholder base?**

Um placeholder base é a forma correspondente no layout ou no mestre a partir da qual outro placeholder herda. Use [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/getbaseplaceholder/) para recuperá‑lo. Uma forma local ordinária retorna `null` porque não faz parte da hierarquia de placeholders.

**Posso mudar todos os títulos dos slides editando um placeholder de layout?**

É possível mudar a formatação herdada ou o texto de sugestão através de um layout, mas o conteúdo de título existente está armazenado nos slides normais. Para substituir o texto real dos títulos em toda a apresentação, itere sobre os slides e atualize cada placeholder de título.

**Como eu gerencio placeholders de data, número do slide, cabeçalho e rodapé?**

Use os gerenciadores de cabeçalho e rodapé no escopo apropriado de slide, layout, mestre, notas ou folhetos. Consulte [Manage Presentation Header and Footer](/slides/pt/net/presentation-header-and-footer/) para exemplos completos.