---
title: Extração avançada de texto de apresentações em .NET
linktitle: Extrair texto
type: docs
weight: 90
url: /pt/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/pt/
keywords:
- extrair texto
- extrair texto de slide
- extrair texto de apresentação
- extrair texto de PowerPoint
- extrair texto de OpenDocument
- extrair texto de PPT
- extrair texto de PPTX
- extrair texto de ODP
- recuperar texto
- recuperar texto de slide
- recuperar texto de apresentação
- recuperar texto de PowerPoint
- recuperar texto de OpenDocument
- recuperar texto de PPT
- recuperar texto de PPTX
- recuperar texto de ODP
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Extraia rapidamente texto de apresentações PowerPoint e OpenDocument usando Aspose.Slides para .NET. Siga nosso guia simples, passo a passo, para economizar tempo."
---
## **Visão geral**

Extrair texto de apresentações é uma tarefa comum, porém essencial, para desenvolvedores que trabalham com conteúdo de slides. Seja lidando com arquivos Microsoft PowerPoint nos formatos PPT ou PPTX, ou apresentações OpenDocument (ODP), acessar e recuperar dados textuais pode ser crítico para análise, automação, indexação ou migração de conteúdo.

Este artigo fornece um guia abrangente sobre como extrair texto de forma eficiente de vários formatos de apresentação, incluindo PPT, PPTX e ODP, usando Aspose.Slides for .NET. Você aprenderá como iterar sistematicamente pelos elementos da apresentação para recuperar com precisão o conteúdo textual que precisa.

## **Extrair texto de um Slide**

Aspose.Slides for .NET fornece o namespace [Aspose.Slides.Util](https://reference.aspose.com/slides/pt/net/aspose.slides.util/), que inclui a classe [SlideUtil](https://reference.aspose.com/slides/pt/net/aspose.slides.util/slideutil/). Essa classe expõe vários métodos estáticos sobrecarregados para extrair todo o texto de uma apresentação ou slide. Para extrair texto de um slide em uma apresentação, use o método [GetAllTextBoxes](https://reference.aspose.com/slides/pt/net/aspose.slides.util/slideutil/getalltextboxes/). Esse método aceita um objeto do tipo [IBaseSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide/) como parâmetro. Quando executado, o método varre todo o slide em busca de texto e retorna um array de objetos do tipo [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/), preservando qualquer formatação de texto.

O trecho de código a seguir extrai todo o texto do primeiro slide da apresentação:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Extrair texto de uma Apresentação**

Para analisar texto em toda a apresentação, use o método estático [GetAllTextFrames](https://reference.aspose.com/slides/pt/net/aspose.slides.util/slideutil/getalltextframes/) exposto pela classe [SlideUtil](https://reference.aspose.com/slides/pt/net/aspose.slides.util/slideutil/). Ele aceita dois parâmetros:

1. Primeiro, um objeto [IPresentation](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/) que representa uma apresentação PowerPoint ou OpenDocument da qual o texto será extraído.
2. Segundo, um valor `Boolean` indicando se os slides mestres devem ser incluídos ao escanear o texto da apresentação.

O método retorna um array de objetos do tipo [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/), incluindo informações de formatação de texto. O código abaixo escaneia o texto e os detalhes de formatação de uma apresentação, incluindo os slides mestres.

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Extração de texto categorizada e rápida**

A classe [PresentationFactory](https://reference.aspose.com/slides/pt/net/aspose.slides/presentationfactory/) também fornece métodos para extrair todo o texto de apresentações:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

O argumento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/pt/net/aspose.slides/textextractionarrangingmode/) indica o modo de organização do resultado da extração de texto e pode ser definido com os seguintes valores:
- `Unarranged` - O texto bruto sem considerar sua posição no slide.
- `Arranged` - O texto é organizado na mesma ordem em que aparece no slide.

O modo não organizado pode ser usado quando a velocidade é crítica; ele é mais rápido que o modo organizado.

[IPresentationText](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationtext/) representa o texto bruto extraído da apresentação. Sua propriedade `SlidesText` retorna um array de objetos do tipo [ISlideText](https://reference.aspose.com/slides/pt/net/aspose.slides/islidetext/). Cada objeto representa o texto no slide correspondente. O objeto do tipo [ISlideText](https://reference.aspose.com/slides/pt/net/aspose.slides/islidetext/) possui as seguintes propriedades:

- `Text` - O texto dentro das formas do slide.
- `MasterText` - O texto dentro das formas do slide mestre associado a este slide.
- `LayoutText` - O texto dentro das formas do slide de layout associado a este slide.
- `NotesText` - O texto dentro das formas da página de notas associada a este slide.
- `CommentsText` - O texto dentro dos comentários associados a este slide.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **FAQ**

**Quão rápido o Aspose.Slides processa grandes apresentações durante a extração de texto?**

Aspose.Slides está otimizado para alto desempenho e pode processar até mesmo [apresentações grandes](/slides/pt/net/open-presentation/), tornando‑se adequado para cenários de processamento em tempo real ou em lote.

**O Aspose.Slides pode extrair texto de tabelas e gráficos dentro de apresentações?**

Sim. Aspose.Slides pode extrair texto de muitos elementos de slide, incluindo tabelas e objetos relacionados a gráficos, permitindo que você acesse e analise o conteúdo textual em estruturas de apresentação comuns.

**Preciso de uma licença especial do Aspose.Slides para extrair texto de apresentações?**

Você pode extrair texto usando a versão de avaliação gratuita do Aspose.Slides, embora ela tenha [certas limitações](/slides/pt/net/licensing/), como processar apenas um número limitado de slides. Para uso ilimitado e para lidar com apresentações maiores, recomenda‑se adquirir uma licença completa.