---
title: Criar um Visualizador de Apresentação em .NET
linktitle: Visualizador de Apresentação
type: docs
weight: 50
url: /pt/net/presentation-viewer/
keywords: 
- visualizar apresentação
- visualizador de apresentação
- criar visualizador de apresentação
- visualizar PPT
- visualizar PPTX
- visualizar ODP
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Crie um visualizador de apresentação personalizado em .NET usando Aspose.Slides. Exiba facilmente arquivos PowerPoint e OpenDocument sem o Microsoft PowerPoint."
---
## **Introdução**

Aspose.Slides for .NET é usado para criar arquivos de apresentação com slides. Esses slides podem ser visualizados abrindo as apresentações no Microsoft PowerPoint, por exemplo. No entanto, os desenvolvedores podem, às vezes, precisar visualizar os slides como imagens em seu visualizador de imagens preferido ou usá‑los em um visualizador de apresentação personalizado. Nessas situações, o Aspose.Slides permite exportar slides individuais como imagens. Este artigo explica como fazê‑lo.

## **Gerar uma Imagem SVG de um Slide**

Para gerar uma imagem SVG a partir de um slide de apresentação usando Aspose.Slides, siga as etapas abaixo:

1. Criar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Obter uma referência ao slide pelo seu índice.
1. Abrir um stream de arquivo.
1. Salvar o slide como uma imagem SVG no stream de arquivo.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```

## **Gerar um SVG com um ID de Forma Personalizado**

Aspose.Slides pode ser usado para gerar um [SVG](https://docs.fileformat.com/page-description-language/svg/) a partir de um slide com um `ID` de forma personalizado. Para isso, use a propriedade Id da interface [ISvgShape](https://reference.aspose.com/slides/pt/net/aspose.slides.export/isvgshape). A classe `CustomSvgShapeFormattingController` pode ser usada para definir o ID da forma.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```

## **Criar uma Imagem Miniatura de Slide**

Aspose.Slides ajuda a gerar imagens em miniatura de slides. Para gerar uma miniatura de um slide usando Aspose.Slides, siga as etapas abaixo:

1. Criar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Obter uma referência ao slide pelo seu índice.
1. Criar uma imagem miniatura do slide referenciado na escala desejada.
1. Salvar a imagem miniatura no formato de imagem de sua preferência.

```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Criar uma Miniatura de Slide com Dimensões Definidas pelo Usuário**

Para criar uma imagem miniatura de slide com dimensões definidas pelo usuário, siga as etapas abaixo:

1. Criar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Obter uma referência ao slide pelo seu índice.
1. Gerar uma imagem miniatura do slide referenciado com as dimensões especificadas.
1. Salvar a imagem miniatura no formato de imagem de sua preferência.

```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Criar uma Miniatura de Slide com Notas do Apresentador**

Para gerar uma miniatura de um slide com notas do apresentador usando Aspose.Slides, siga as etapas abaixo:

1. Criar uma instância da classe [RenderingOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/renderingoptions/).
1. Usar a propriedade `RenderingOptions.SlidesLayoutOptions` para definir a posição das notas do apresentador.
1. Criar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Obter uma referência ao slide pelo seu índice.
1. Gerar uma imagem miniatura do slide referenciado usando as opções de renderização.
1. Salvar a imagem miniatura no formato de imagem de sua preferência.

```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```

## **Exemplo ao Vivo**

Experimente o aplicativo gratuito [**Aspose.Slides Viewer**](https://products.aspose.app/slides/pt/viewer/) para ver o que você pode implementar com a API do Aspose.Slides:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/pt/viewer/)

## **Perguntas Frequentes**

**Posso incorporar um visualizador de apresentação em uma aplicação web ASP.NET?**

Sim. Você pode usar Aspose.Slides no lado do servidor para renderizar slides como imagens ou HTML e exibí‑los no navegador. Recursos de navegação e zoom podem ser implementados com JavaScript para uma experiência interativa.

**Qual é a melhor maneira de exibir slides dentro de um visualizador .NET personalizado?**

A abordagem recomendada é renderizar cada slide como uma imagem (por exemplo, PNG ou SVG) ou convertê‑lo para HTML usando Aspose.Slides, e então exibir a saída dentro de um picture box (para desktop) ou contêiner HTML (para web).

**Como lidar com apresentações grandes contendo muitos slides?**

Para decks grandes, considere carregamento preguiçoso (lazy‑loading) ou renderização sob demanda dos slides. Isso significa gerar o conteúdo de um slide somente quando o usuário navega até ele, reduzindo o uso de memória e o tempo de carregamento.