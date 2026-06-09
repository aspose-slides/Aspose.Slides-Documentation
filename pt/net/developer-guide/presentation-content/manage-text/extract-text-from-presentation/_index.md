---
title: Extração Avançada de Texto de Apresentações em .NET
linktitle: Extrair Texto
type: docs
weight: 90
url: /pt/net/extract-text-from-presentation/
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
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Extraia texto rapidamente de apresentações PowerPoint e OpenDocument usando Aspose.Slides para .NET. Siga nosso guia simples, passo a passo, para economizar tempo."
---
## **Visão geral**

Extrair texto de apresentações é uma tarefa comum, porém essencial, para desenvolvedores que trabalham com conteúdo de slides. Seja lidando com arquivos Microsoft PowerPoint nos formatos PPT ou PPTX, ou apresentações OpenDocument (ODP), acessar e recuperar dados textuais pode ser crítico para análises, automação, indexação ou migração de conteúdo.

Este artigo oferece um guia abrangente sobre como extrair texto de forma eficiente de vários formatos de apresentação, incluindo PPT, PPTX e ODP, usando Aspose.Slides para .NET. Você aprenderá a percorrer sistematicamente os elementos da apresentação para recuperar com precisão o conteúdo de texto que precisa.

## **Extrair Texto de um Slide**

Aspose.Slides para .NET fornece o namespace [Aspose.Slides.Util](https://reference.aspose.com/slides/pt/net/aspose.slides.util/), que inclui a classe [SlideUtil](https://reference.aspose.com/slides/pt/net/aspose.slides.util/slideutil/). Esta classe expõe vários métodos estáticos sobrecarregados para extrair todo o texto de uma apresentação ou slide. Para extrair texto de um slide em uma apresentação, use o método [GetAllTextBoxes](https://reference.aspose.com/slides/pt/net/aspose.slides.util/slideutil/getalltextboxes/). Este método aceita um objeto do tipo [IBaseSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide/) como parâmetro. Quando executado, o método varre todo o slide em busca de texto e retorna um array de objetos do tipo [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/), preservando qualquer formatação de texto.

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

## **Extrair Texto de uma Apresentação**

Para varrer texto de toda a apresentação, use o método estático [GetAllTextFrames](https://reference.aspose.com/slides/pt/net/aspose.slides.util/slideutil/getalltextframes/) exposto pela classe [SlideUtil](https://reference.aspose.com/slides/pt/net/aspose.slides.util/slideutil/). Ele aceita dois parâmetros:

1. Primeiro, um objeto [IPresentation](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/) que representa uma apresentação PowerPoint ou OpenDocument da qual o texto será extraído.
1. Segundo, um valor `Boolean` indicando se os slides mestres devem ser incluídos ao varrer texto da apresentação.

O método retorna um array de objetos do tipo [ITextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/), incluindo informações de formatação de texto. O código abaixo varre o texto e os detalhes de formatação de uma apresentação, incluindo os slides mestres.

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

## **Extração de Texto Categorizada e Rápida**

A classe [PresentationFactory](https://reference.aspose.com/slides/pt/net/aspose.slides/presentationfactory/) também fornece métodos para extrair todo o texto de apresentações:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

O argumento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/pt/net/aspose.slides/textextractionarrangingmode/) indica o modo de organização do resultado da extração de texto e pode ser definido com os seguintes valores:
- `Unarranged` - O texto bruto sem considerar sua posição no slide.
- `Arranged` - O texto é organizado na mesma ordem que no slide.

O modo `Unarranged` pode ser usado quando a velocidade é crítica; ele é mais rápido que o modo `Arranged`.

[IPresentationText](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationtext/) representa o texto bruto extraído da apresentação. Sua propriedade `SlidesText` devolve um array de objetos do tipo [ISlideText](https://reference.aspose.com/slides/pt/net/aspose.slides/islidetext/). Cada objeto representa o texto do slide correspondente. O objeto do tipo [ISlideText](https://reference.aspose.com/slides/pt/net/aspose.slides/islidetext/) possui as seguintes propriedades:

- `Text` - O texto dentro das formas do slide.
- `MasterText` - O texto dentro das formas do slide mestre associado a este slide.
- `LayoutText` - O texto dentro das formas do slide de layout associado a este slide.
- `NotesText` - O texto dentro das formas do slide de notas associado a este slide.
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

**Quão rápido o Aspose.Slides processa apresentações grandes durante a extração de texto?**

O Aspose.Slides está otimizado para alto desempenho e pode processar até mesmo [grandes apresentações](/slides/pt/net/open-presentation/), tornando-o adequado para cenários de processamento em tempo real ou em massa.

**O Aspose.Slides pode extrair texto de tabelas e gráficos dentro de apresentações?**

Sim. O Aspose.Slides pode extrair texto de vários elementos de slide, incluindo tabelas e objetos relacionados a gráficos, permitindo que você acesse e analise o conteúdo textual em estruturas de apresentação comuns.

**Preciso de uma licença especial do Aspose.Slides para extrair texto de apresentações?**

Você pode extrair texto usando a versão de avaliação gratuita do Aspose.Slides, embora ela possua [certas limitações](/slides/pt/net/licensing/), como processar apenas um número limitado de slides. Para uso irrestrito e para lidar com apresentações maiores, recomenda‑se a compra de uma licença completa.