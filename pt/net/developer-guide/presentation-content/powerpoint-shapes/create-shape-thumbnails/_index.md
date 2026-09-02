---
title: Criar Miniaturas de Formas de Apresentação em .NET
linktitle: Miniaturas de Formas
type: docs
weight: 70
url: /pt/net/create-shape-thumbnails/
keywords:
- miniatura de forma
- imagem de forma
- renderizar forma
- renderização de forma
- limites visuais
- limites de forma
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Gere miniaturas de formas de alta qualidade a partir de slides do PowerPoint com Aspose.Slides for .NET – crie e exporte miniaturas de apresentações com facilidade."
---
## **Introdução**

Aspose.Slides for .NET é usado para criar arquivos de apresentação onde cada página é um slide. Esses slides podem ser visualizados abrindo os arquivos de apresentação usando o Microsoft PowerPoint. Mas às vezes, os desenvolvedores podem precisar visualizar as imagens das formas separadamente em um visualizador de imagens. Nesses casos, o Aspose.Slides for .NET ajuda a gerar imagens em miniatura das formas do slide. Como usar esse recurso é descrito neste artigo.
Este artigo explica como gerar miniaturas de slides de diferentes maneiras:

- Gerar uma miniatura de forma dentro de um slide.
- Gerar uma miniatura de forma para uma forma de slide com dimensões definidas pelo usuário.
- Gerar uma miniatura de forma nos limites da aparência de uma forma.

## **Gerar uma Miniatura de Forma a partir de um Slide**
Para gerar uma miniatura de forma a partir de qualquer slide usando Aspose.Slides for .NET:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Obtenha a referência de qualquer slide usando seu ID ou índice.
1. Recupere a imagem em miniatura da forma do slide referenciado na escala padrão.
1. Salve a imagem em miniatura no formato de imagem desejado.

O exemplo abaixo gera a miniatura da forma.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Gerar uma Miniatura com Fator de Escala Definido pelo Usuário**
Para gerar a miniatura da forma de qualquer slide usando Aspose.Slides for .NET:

1. Crie uma instância da classe `Presentation`.
1. Obtenha a referência de qualquer slide usando seu ID ou índice.
1. Recupere a imagem em miniatura do slide referenciado com os limites da forma.
1. Salve a imagem em miniatura no formato de imagem desejado.

O exemplo abaixo gera uma miniatura usando um fator de escala definido pelo usuário.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Escala ao longo dos eixos X e Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Criar uma Miniatura de Forma Baseada em Limites de Aparência**
Este método de criação de miniaturas de formas permite que os desenvolvedores gerem uma miniatura dentro dos limites da aparência da forma. Ele considera todos os efeitos da forma. A miniatura da forma gerada é restrita pelos limites do slide. Para gerar uma miniatura de qualquer forma de slide dentro dos limites de sua aparência, use o código de exemplo a seguir:

1. Crie uma instância da classe `Presentation`.
1. Obtenha a referência de qualquer slide usando seu ID ou índice.
1. Recupere a imagem em miniatura do slide referenciado com os limites da forma como aparência.
1. Salve a imagem em miniatura no formato de imagem desejado.

O exemplo abaixo cria uma miniatura usando um fator de escala definido pelo usuário.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Escala ao longo dos eixos X e Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **Obter os Limites Visuais Reais de uma Forma**

As propriedades de quadro de [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/) — suas propriedades `X`, `Y`, `Width` e `Height` — descrevem o retângulo armazenado no modelo da apresentação. O conteúdo realmente renderizado pode se estender além desse quadro ou ocupar um retângulo alinhado aos eixos diferente. Rotação, contornos, pontas de setas, layout e transbordamento de texto, geometria de SmartArt gerada e outros efeitos de renderização podem alterar a área ocupada.

Use [GetVisualBounds](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/getvisualbounds/) para calcular essa área ocupada sem criar uma imagem. O método retorna um [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) em coordenadas de slide. O retângulo retornado não é recortado ao slide, portanto suas coordenadas podem ser negativas quando o conteúdo se estende além da origem do slide.

[GetVisualBounds](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/getvisualbounds/) não está atualmente declarado pela interface [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/). Portanto, mantenha a forma obtida da coleção de formas do slide como um valor de interface e faça o casting apenas ao chamar o método.

O exemplo a seguir obtém e compara os limites de quadro e os limites visuais:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

O mesmo [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) pode ser usado para alinhar formas próximas à sua borda `Left`, `Right`, `Top` ou `Bottom`; reservar espaço suficiente em um layout gerado; ou detectar conteúdo fora de uma região permitida. Os limites visuais são especialmente úteis para SmartArt, caixas de texto, setas, imagens, formas rotacionadas e grupos de formas, onde o quadro armazenado pode não representar o resultado renderizado completo.

Use [GetVisualBounds](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/getvisualbounds/) quando precisar de coordenadas para layout ou validação e não precisar de um bitmap. Use [IShape.GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/getimage/) quando precisar renderizar a forma. Com [ShapeThumbnailBounds](https://reference.aspose.com/slides/pt/net/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` dimensiona a imagem a partir dos limites da forma, incluindo configurações de contorno, enquanto `ShapeThumbnailBounds.Appearance` dimensiona a partir da aparência da forma e restringe o resultado aos limites do slide. Em contraste, [GetVisualBounds](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/getvisualbounds/) retorna apenas o retângulo calculado e não o recorta ao slide.

## **FAQ**

**Quais formatos de imagem podem ser usados ao salvar miniaturas de formas?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pt/net/aspose.slides/imageformat/), e outros. Formas também podem ser [exportadas como SVG vetorial](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/writeassvg/) salvando o conteúdo da forma como SVG.

**Qual é a diferença entre os limites Shape e Appearance ao renderizar uma miniatura?**

`Shape` usa a geometria da forma; `Appearance` considera os [efeitos visuais](/slides/pt/net/shape-effect/) (sombras, brilhos, etc.).

**O que acontece se uma forma for marcada como oculta? Ela ainda será renderizada como miniatura?**

Uma forma oculta permanece parte do modelo e pode ser renderizada; a flag de ocultação afeta a exibição da apresentação, mas não impede a geração da imagem da forma.

**Grupos de formas, gráficos, SmartArt e outros objetos complexos são suportados?**

Sim. Qualquer objeto representado como [Shape](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/) (incluindo [GroupShape](https://reference.aspose.com/slides/pt/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chart/), e [SmartArt](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/smartart/)) pode ser salvo como miniatura ou como SVG.

**As fontes instaladas no sistema afetam a qualidade das miniaturas de formas de texto?**

Sim. Você deve [fornecer as fontes necessárias](/slides/pt/net/custom-font/) (ou [configurar substituições de fontes](/slides/pt/net/font-substitution/)) para evitar substituições indesejadas e reorganização de texto.