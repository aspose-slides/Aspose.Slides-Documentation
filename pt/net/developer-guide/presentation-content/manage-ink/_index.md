---
title: Gerenciar objetos de tinta de apresentação no .NET
linktitle: Gerenciar tinta
type: docs
weight: 95
url: /pt/net/manage-ink/
keywords:
- tinta
- objeto de tinta
- traço de tinta
- gerenciar tinta
- desenhar tinta
- desenho
- exportação de tinta
- renderização de tinta
- ocultar tinta
- IInkOptions
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Gerencie objetos de tinta do PowerPoint, edite traços e propriedades de pincel, e controle a aparência da tinta durante exportação para PDF, HTML, SVG, TIFF e imagem com Aspose.Slides para .NET."
---
## **Introdução**

O PowerPoint fornece um recurso de tinta que permite desenhar traços livres. A tinta pode ser usada para destacar outros objetos, mostrar conexões e processos, e chamar a atenção para itens específicos em um slide.

O namespace [Aspose.Slides.Ink](https://reference.aspose.com/slides/pt/net/aspose.slides.ink/) contém as classes e interfaces necessárias para trabalhar com objetos de tinta. Por exemplo, a interface [IInk](https://reference.aspose.com/slides/pt/net/aspose.slides.ink/iink/) representa um objeto de tinta em um slide.

## **Diferenças entre Objetos Regulares e Objetos de Tinta**

Objetos em um slide do PowerPoint geralmente são representados por objetos de forma. Em sua forma mais simples, uma forma é um contêiner que define a área do próprio objeto (sua moldura) junto com propriedades como tamanho do contêiner, forma e plano de fundo. Para mais informações, veja [Shape Layout Format](https://docs.aspose.com/slides/pt/net/shape-manipulations/#access-layout-formats-for-shape).

No entanto, quando o PowerPoint lida com um objeto de tinta, ele ignora todas as propriedades da moldura do objeto (contêiner) exceto o seu tamanho. O tamanho da área do contêiner é determinado pelas propriedades padrão [IShape.Width](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/width/) e [IShape.Height](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Traços de Tinta**

Um traço de tinta é o elemento básico usado para registrar a trajetória de uma caneta enquanto o usuário escreve tinta digital. Um traço armazena uma sequência de pontos conectados.

A forma mais simples de codificação especifica as coordenadas X e Y de cada ponto de amostra. Quando todos os pontos conectados são renderizados, eles produzem uma imagem como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriedades do Pincel para Desenho**

Um pincel é usado para desenhar linhas que conectam os pontos de um traço de tinta. O pincel tem sua própria cor e tamanho, representados pelas propriedades [IInkBrush.Color](https://reference.aspose.com/slides/pt/net/aspose.slides.ink/iinkbrush/color/) e [IInkBrush.Size](https://reference.aspose.com/slides/pt/net/aspose.slides.ink/iinkbrush/size/).

### **Definir Cor do Pincel de Tinta**

Este código C# mostra como definir a cor de um pincel de tinta:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **Definir Tamanho do Pincel de Tinta**

Este código C# mostra como definir o tamanho de um pincel de tinta:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

Geralmente, a largura e a altura de um pincel não coincidem, portanto o PowerPoint não exibe o tamanho do pincel (a seção de dados correspondente fica esmaecida). Quando a largura e a altura do pincel coincidem, o PowerPoint exibe seu tamanho da seguinte forma:

![ink_powerpoint3](ink_powerpoint3.png)

Para clareza, vamos aumentar a altura do objeto de tinta e revisar as dimensões importantes:

![ink_powerpoint4](ink_powerpoint4.png)

O contêiner (moldura) não leva em conta o tamanho dos pincéis — ele sempre assume que a espessura da linha é zero (veja a imagem anterior).

Portanto, para determinar a área visível de todo o objeto de tinta, o tamanho do pincel de seus traços deve ser considerado. Aqui, o objeto alvo (o traço de texto escrito à mão) foi dimensionado para o tamanho do contêiner (moldura). Quando o tamanho do contêiner muda, o tamanho do pincel permanece constante, e vice‑versa.

![ink_powerpoint5](ink_powerpoint5.png)

O PowerPoint usa comportamento semelhante para objetos de texto:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controlar a Aparência da Tinta Durante Exportação e Renderização**

O Aspose.Slides fornece a interface [IInkOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/iinkoptions/) para controlar como os objetos de tinta aparecem na saída exportada ou renderizada. Você pode usar suas propriedades para ocultar completamente a tinta ou alterar a forma como as operações de máscara do pincel de tinta são interpretadas.

As opções de tinta estão disponíveis através das opções de exportação ou renderização para vários tipos de saída:

| Output | Ink options property |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/pt/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/pt/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Slide image | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/pt/net/aspose.slides.export/renderingoptions/inkoptions/) |

As mesmas duas configurações estão disponíveis através dessas propriedades:

- [`HideInk`](https://reference.aspose.com/slides/pt/net/aspose.slides.export/iinkoptions/hideink/) determina se objetos de tinta são incluídos na saída. Seu valor padrão é `false`.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/pt/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) determina se uma operação de máscara é interpretada como opacidade ao renderizar um pincel de tinta. Seu valor padrão é `true`; defina como `false` para usar a operação ROP em vez disso.

### **Ocultar Objetos de Tinta na Saída PDF**

Por padrão, os objetos de tinta permanecem visíveis durante a exportação. Defina [IInkOptions.HideInk](https://reference.aspose.com/slides/pt/net/aspose.slides.export/iinkoptions/hideink/) como `true` quando precisar de uma saída limpa sem anotações manuscritas ou outro conteúdo de tinta.

O exemplo C# a seguir exporta uma apresentação para PDF ocultando todos os objetos de tinta:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Ocultar Objetos de Tinta ao Renderizar um Slide como Imagem**

Para ocultar objetos de tinta ao renderizar slides como imagens bitmap, configure [RenderingOptions.InkOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/renderingoptions/inkoptions/) e passe as opções de renderização para o método [ISlide.GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/getimage/).

O exemplo C# a seguir renderiza o primeiro slide como uma imagem PNG sem objetos de tinta:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **Controlar a Renderização da Máscara de Tinta**

A propriedade [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) controla como as operações de máscara são interpretadas ao renderizar pincéis de tinta. O valor padrão é `true`, que usa opacidade. Defina a propriedade como `false` para usar a operação ROP em vez disso.

O exemplo C# a seguir exporta um slide para SVG e usa renderização baseada em ROP para operações de máscara de tinta:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

A mesma configuração pode ser aplicada através de [TiffOptions.InkOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/tiffoptions/inkoptions/) ao exportar uma apresentação ou renderizar um slide para TIFF.

### **Escolher entre Ocultar ou Preservar a Tinta**

Use [IInkOptions.HideInk](https://reference.aspose.com/slides/pt/net/aspose.slides.export/iinkoptions/hideink/) definido como `true` quando o arquivo exportado deve ser uma versão limpa de uma apresentação anotada, por exemplo, uma cópia final destinada à distribuição sem marcas de revisão.

Mantenha [IInkOptions.HideInk](https://reference.aspose.com/slides/pt/net/aspose.slides.export/iinkoptions/hideink/) com seu valor padrão `false` quando as anotações de tinta fizerem parte do conteúdo desejado, como comentários de revisão, notas manuscritas, realces ou desenhos que devam permanecer visíveis no resultado exportado. Isso permite que aplicativos gerem saídas de revisão e final separadas a partir da mesma apresentação sem modificar os objetos de tinta originais.

## **Perguntas Frequentes**

**Posso alterar a cor ou o tamanho de um traço de tinta existente?**

Sim. Obtenha o traço a partir de [IInk.Traces](https://reference.aspose.com/slides/pt/net/aspose.slides.ink/iink/traces/), então altere seu [IInkTrace.Brush](https://reference.aspose.com/slides/pt/net/aspose.slides.ink/iinktrace/brush/). Você pode definir as propriedades [IInkBrush.Color](https://reference.aspose.com/slides/pt/net/aspose.slides.ink/iinkbrush/color/) e [IInkBrush.Size](https://reference.aspose.com/slides/pt/net/aspose.slides.ink/iinkbrush/size/).

**Ocultar a tinta altera a apresentação original?**

Não. [IInkOptions.HideInk](https://reference.aspose.com/slides/pt/net/aspose.slides.export/iinkoptions/hideink/) afeta apenas o resultado renderizado ou exportado; ele não remove nem modifica os objetos de tinta na apresentação original.

**Quais formatos de exportação suportam opções de tinta?**

Você pode configurar opções de tinta para PDF, HTML, SVG, TIFF e imagens bitmap de slides através das opções de exportação ou renderização correspondentes mostradas acima.

**Leitura adicional**

* Para saber mais sobre formas em geral, veja a seção [PowerPoint Shapes](https://docs.aspose.com/slides/pt/net/powerpoint-shapes/).
* Para informações sobre valores efetivos, consulte [Shape Effective Properties](https://docs.aspose.com/slides/pt/net/shape-effective-properties/#get-effective-font-height-value).
* Para detalhes sobre exportação para PDF, veja [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/pt/net/convert-powerpoint-to-pdf/).
* Para detalhes sobre exportação para HTML, veja [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/pt/net/convert-powerpoint-to-html/).
* Para detalhes sobre exportação para SVG, veja [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/pt/net/render-a-slide-as-an-svg-image/).
* Para detalhes sobre exportação para TIFF, veja [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/pt/net/convert-powerpoint-to-tiff/).
* Para detalhes sobre renderização de slide para imagem, veja [Convert Presentation Slides to Images](https://docs.aspose.com/slides/pt/net/convert-slide/).