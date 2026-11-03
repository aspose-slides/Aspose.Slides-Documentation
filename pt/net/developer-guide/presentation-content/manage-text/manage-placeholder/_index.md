---
title: Gerenciar Placeholders de Apresentação em .NET
linktitle: Gerenciar Placeholders
type: docs
weight: 10
url: /pt/net/manage-placeholder/
keywords:
- marcador de posição
- marcador de texto
- marcador de imagem
- marcador de gráfico
- marcador de conteúdo
- texto de sugestão
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Saiba como inspecionar e editar marcadores de texto, imagem, gráfico e conteúdo e entender a herança de marcadores com Aspose.Slides para .NET."
---
## **Visão geral**

Um placeholder é uma forma que reserva uma posição para um determinado tipo de conteúdo em um modelo de apresentação. Exemplos comuns são marcadores de título, corpo, imagem, gráfico e placeholders de conteúdo de uso geral. Ao contrário de uma forma ordinária, um placeholder pode herdar sua posição, tamanho, formatação e outras configurações de um slide de layout ou slide mestre.

Aspose.Slides expõe as informações de placeholder por meio da propriedade [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/). A propriedade retorna um objeto [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) ou `null` para uma forma normal. Use [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) para determinar o que o placeholder deve conter.

A interface da forma ainda é importante depois de conhecer o tipo de placeholder:

- Um placeholder vazio de texto, imagem, gráfico ou conteúdo geralmente é representado por um [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
- Um placeholder de imagem preenchido pode ser representado por um [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/).
- Um placeholder de gráfico preenchido pode ser representado por um [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/).
- Um placeholder de conteúdo pode conter vários tipos de conteúdo. Verifique tanto [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) quanto a interface de forma em tempo de execução, em vez de assumir que todo placeholder é um [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) descreve a função de um placeholder; não garante o tipo em tempo de execução da forma. Sempre use uma verificação de tipo antes de acessar membros específicos de texto, imagem, gráfico, tabela ou mídia.
{{% /alert %}}

## **Entender a Herança de Placeholder**

Placeholders formam uma hierarquia:

1. Um slide mestre define estilos reutilizáveis e, em alguns casos, placeholders ao nível do mestre.
2. Um slide de layout define o arranjo usado por um ou mais slides normais e pode herdar do mestre.
3. Um slide normal contém os placeholders desse slide e pode herdar do seu layout.

Chame [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) para subir um nível nessa hierarquia. Um placeholder de slide normalmente retorna seu placeholder de layout; um placeholder de layout pode retornar seu placeholder mestre. O método retorna `null` quando a forma não tem placeholder base.

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

Editar um placeholder em um slide normal cria ou altera uma substituição local para esse slide. Editar o layout ou mestre relacionado pode afetar todos os slides que ainda herdam essa configuração. Uma forma ordinária local não tem placeholder base e não começa a herdar apenas porque ocupa as mesmas coordenadas.

## **Remover o Status de Placeholder**

Ao adaptar um modelo, use [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) para manter um objeto existente como uma forma ordinária. Sua propriedade [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) passa a ser `null`, mas a forma permanece na coleção do slide. Em contraste, [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) exclui a forma dessa coleção.

O exemplo a seguir requer `template.pptx` com ao menos um slide e um placeholder de texto não vazio no primeiro slide. Use um placeholder com formatação herdada do layout ou do mestre para ver o efeito de remover esse relacionamento. O exemplo verifica que a mesma forma permanece, chama o método novamente na forma agora ordinária e salva o resultado.

{{% alert color="warning" title="Warning" %}}
Remover o status de placeholder não preserva automaticamente as configurações de aparência herdadas. O exemplo abaixo deixa deliberadamente essas configurações inalteradas, portanto a saída pode parecer diferente. Uma forma cuja posição e tamanho são totalmente herdados pode ter coordenadas e dimensões zero após a chamada e tornar‑se invisível, ainda que permaneça na coleção.
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // Chamar o método em uma forma ordinária não tem efeito.
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

Para um placeholder correspondente, as três verificações imprimem `True`. O texto permanece, mas posição, tamanho, rotação, fonte, alinhamento de parágrafo, margens do quadro de texto, ancoragem vertical, preenchimento e configurações de linha herdadas podem mudar quando o relacionamento de placeholder é removido. Por exemplo, a formatação de título herdada pode voltar à formatação de texto ordinário. Veja [Layout de Slide](/slides/pt/net/slide-layout/) para mais informações sobre layouts.

Para preservar a aparência pretendida, capture a posição, tamanho e rotação resolvidos antes da chamada e copie os valores de formatação efetiva necessários para variáveis separadas. Recupere esses valores através de [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/) e [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/). Não confie apenas nos objetos de formatação efetiva, pois seus valores de formatação de texto podem mudar após a remoção do relacionamento. Aplique explicitamente os valores capturados à forma ordinária posteriormente, incluindo família, tamanho, estilo, cor da fonte, configurações de parágrafo, configurações do quadro de texto, preenchimento e linha usados pelo seu modelo.

A geometria de forma herdada pode também precisar ser atribuída explicitamente através de [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/). Para um placeholder de texto retangular, isso significa atribuir [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/); restaurar apenas o preenchimento e a linha pode não restaurar o retângulo visível. Modelos com efeitos adicionais ou formatação mais complexa exigem que essas configurações sejam tratadas também.

## **Alterar Texto em um Placeholder**

Placeholders de título, título centralizado, subtítulo, corpo e texto normalmente suportam texto. Verifique a presença de um [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) antes de usar sua propriedade [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/).

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

Esse padrão evita converter placeholders de imagem, gráfico, tabela ou mídia para [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Ele também identifica o placeholder por finalidade em vez de depender de um índice de forma frágil.

## **Definir Texto de Prompt em um Layout**

Texto de prompt é a instrução de design‑time exibida em um placeholder vazio, como *Clique para adicionar título*. Defina texto de prompt personalizado no placeholder do layout em vez de tentar acessá‑lo através da coleção de formas de um slide normal. Acesse o layout via [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) e itere sobre [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/).

O exemplo a seguir altera os prompts de título e subtítulo no layout usado pelo primeiro slide:

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

Texto de prompt não é conteúdo de slide normal. Destina‑se a placeholders vazios em aplicativos de edição como o PowerPoint. Uma vez que o usuário ou programa fornece conteúdo real, o prompt deixa de ser exibido. Alterar um prompt também não substitui texto existente em slides que utilizam o layout.

## **Atualizar um Placeholder de Imagem**

Existem dois casos a tratar:

- Se o placeholder de imagem já estiver preenchido e representado por um [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), substitua a imagem através de [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) e [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/).
- Se ainda for um placeholder vazio, adicione um quadro de imagem nas coordenadas do placeholder com [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) e remova o placeholder vazio.

O próximo exemplo dá suporte a ambos os casos e salva a apresentação:

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

A substituição criada para um placeholder vazio é um quadro de imagem local, não um novo placeholder, porque [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) é somente leitura. Ele mantém a posição reservada, mas não herda mais o comportamento específico de placeholder. Se reter o relacionamento de placeholder for essencial, prepare e preencha o placeholder no PowerPoint primeiro, então atualize o [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) resultante com Aspose.Slides.

Para transparência de imagem, recorte e outros efeitos específicos de imagem, veja [Gerenciar Quadros de Imagem](/slides/pt/net/picture-frame/). Essas operações pertencem ao quadro de imagem ou ao preenchimento da imagem, não aos metadados do placeholder.

## **Trabalhar com Placeholders de Gráficos e de Conteúdo**

Um placeholder de gráfico preenchido pode ser representado por um [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/). Este exemplo localiza tal gráfico tanto pelo tipo de placeholder quanto pela interface em tempo de execução, altera seu título e salva o arquivo:

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

Um placeholder de conteúdo geral geralmente tem [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/). No PowerPoint ele funciona como um lançador para vários tipos de conteúdo, incluindo gráficos, tabelas, diagramas, imagens e mídia. Após ser preenchido, inspecione a interface real da forma para descobrir o que contém. Layouts especializados também podem expor [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), ou [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/).

Aspose.Slides não converte um placeholder vazio de [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) em um [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) apenas alterando [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/); o tipo é somente leitura. Para preencher programaticamente um gráfico ou área de conteúdo vazia, adicione o objeto necessário nas coordenadas do placeholder e então remova o placeholder vazio. O exemplo a seguir faz isso para um gráfico:

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

O gráfico adicionado é um gráfico local ordinário. Ele ocupa a área do placeholder, mas não herda do placeholder do layout. Use os [artigos de gerenciamento de gráficos](/slides/pt/net/powerpoint-charts/) quando precisar substituir categorias, séries ou dados da planilha.

## **Exemplo Completo: Atualizar Texto ou Conteúdo de Imagem**

O exemplo completo a seguir abre um modelo, procura no primeiro slide por um placeholder de título ou de imagem, verifica os tipos de placeholder e de forma, atualiza o conteúdo apropriado e salva a saída. O exemplo evita deliberadamente supor um índice de forma ou converter todos os placeholders para a mesma interface.

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

Um placeholder base é a forma correspondente no layout ou mestre da qual outro placeholder herda. Use [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) para recuperá‑lo. Uma forma local ordinária retorna `null` porque não faz parte da hierarquia de placeholders.

**Posso mudar todos os títulos dos slides editando um placeholder de layout?**

É possível alterar a formatação herdada ou o texto de prompt através de um layout, mas o conteúdo real do título está armazenado nos slides normais. Para substituir o texto de título em toda a apresentação, itere sobre os slides e atualize cada placeholder de título.

**Como gerencio placeholders de data, número de slide, cabeçalho e rodapé?**

Use os gerenciadores de cabeçalho e rodapé no escopo de slide, layout, mestre, notas ou folheto apropriado. Veja [Gerenciar Cabeçalho e Rodapé da Apresentação](/slides/pt/net/presentation-header-and-footer/) para exemplos completos.