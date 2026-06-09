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
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Genere miniaturas de forma de alta qualidade a partir de slides do PowerPoint com Aspose.Slides for .NET – crie e exporte miniaturas de apresentações facilmente."
---
## **Introdução**

O Aspose.Slides for .NET é usado para criar arquivos de apresentação onde cada página é um slide. Esses slides podem ser visualizados abrindo os arquivos de apresentação usando o Microsoft PowerPoint. Mas às vezes, os desenvolvedores podem precisar ver as imagens das formas separadamente em um visualizador de imagens. Nesses casos, o Aspose.Slides for .NET ajuda a gerar imagens em miniatura das formas dos slides. Como usar esse recurso é descrito neste artigo.

Este artigo explica como gerar miniaturas de slides de diferentes maneiras:

- Gerar uma miniatura de forma dentro de um slide.
- Gerar uma miniatura de forma para uma forma de slide com dimensões definidas pelo usuário.
- Gerar uma miniatura de forma nos limites da aparência de uma forma.

## **Gerar uma Miniatura de Forma a Partir de um Slide**
Para gerar uma miniatura de forma a partir de qualquer slide usando o Aspose.Slides for .NET:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Obtenha a referência de qualquer slide usando seu ID ou índice.
1. Recupere a imagem da miniatura da forma do slide referenciado na escala padrão.
1. Salve a imagem da miniatura em qualquer formato de imagem desejado.

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
Para gerar a miniatura da forma de qualquer forma de slide usando o Aspose.Slides for .NET:

1. Crie uma instância da classe `Presentation`.
1. Obtenha a referência de qualquer slide usando seu ID ou índice.
1. Recupere a imagem da miniatura do slide referenciado com os limites da forma.
1. Salve a imagem da miniatura em qualquer formato de imagem desejado.

O exemplo abaixo gera uma miniatura usando um fator de escala definido pelo usuário.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Escalonamento ao longo dos eixos X e Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Criar uma Miniatura de Aparência de Forma Baseada em Limites**
Este método para criar miniaturas de formas permite que os desenvolvedores gerem uma miniatura dentro dos limites da aparência da forma. Ele leva em consideração todos os efeitos da forma. A miniatura da forma gerada é limitada pelos limites do slide. Para gerar uma miniatura de qualquer forma de slide dentro dos limites de sua aparência, use o código de exemplo a seguir:

1. Crie uma instância da classe `Presentation`.
1. Obtenha a referência de qualquer slide usando seu ID ou índice.
1. Recupere a imagem da miniatura do slide referenciado com os limites da forma como aparência.
1. Salve a imagem da miniatura em qualquer formato de imagem desejado.

O exemplo abaixo cria uma miniatura usando um fator de escala definido pelo usuário.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Escalonamento ao longo dos eixos X e Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **Perguntas Frequentes**

**Quais formatos de imagem podem ser usados ao salvar miniaturas de forma?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pt/net/aspose.slides/imageformat/), e outros. As formas também podem ser [exportadas como SVG vetorial](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/writeassvg/) salvando o conteúdo da forma como SVG.

**Qual é a diferença entre os limites Shape e Appearance ao renderizar uma miniatura?**

`Shape` usa a geometria da forma; `Appearance` leva em conta [efeitos visuais](/slides/pt/net/shape-effect/) (sombras, brilhos, etc.).

**O que acontece se uma forma for marcada como oculta? Ela ainda será renderizada como miniatura?**

Uma forma oculta continua fazendo parte do modelo e pode ser renderizada; a flag oculta afeta a exibição da apresentação, mas não impede a geração da imagem da forma.

**Formas de grupo, gráficos, SmartArt e outros objetos complexos são suportados?**

Sim. Qualquer objeto representado como [Shape](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/) (incluindo [GroupShape](https://reference.aspose.com/slides/pt/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chart/) e [SmartArt](https://reference.aspose.com/slides/pt/net/aspose.slides.smartart/smartart/)) pode ser salvo como miniatura ou como SVG.

**As fontes instaladas no sistema afetam a qualidade das miniaturas de formas de texto?**

Sim. Você deve [fornecer as fontes necessárias](/slides/pt/net/custom-font/) (ou [configurar substituições de fontes](/slides/pt/net/font-substitution/)) para evitar substituições indesejadas e refluxo de texto.