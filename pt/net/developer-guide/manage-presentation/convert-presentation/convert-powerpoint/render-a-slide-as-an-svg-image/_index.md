---
title: Renderizar Slides de Apresentação como Imagens SVG em .NET
linktitle: Slide para SVG
type: docs
weight: 50
url: /pt/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint para SVG
- apresentação para SVG
- slide para SVG
- PPT para SVG
- PPTX para SVG
- opções de exportação SVG
- SVG interativo
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Exporte slides do PowerPoint como imagens SVG em .NET e controle fontes, texto, imagens, IDs e eventos com Aspose.Slides."
---
## **Visão geral**

SVG é um formato de imagem baseado em XML escalável que funciona bem para publicação na web, visualizadores de slides, fluxos de trabalho de acessibilidade e pós‑processamento automatizado. Aspose.Slides exporta cada slide para um arquivo SVG separado e permite controlar como texto, fontes, imagens e elementos SVG são gravados.

Use [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) quando o SVG exportado precisar ser compacto, previsível em diferentes navegadores ou pronto para uso interativo.

## **Exportar um slide como SVG**

Crie uma [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), selecione um slide e grave‑o em um stream. O exemplo a seguir exporta cada slide de uma apresentação como um arquivo SVG separado.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

O nome do arquivo usa [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) em vez do índice do loop. Você também pode exportar uma forma individual com [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) quando um visualizador de slides ou página web precisa apenas daquela forma.

## **Configurar a saída SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) controla a renderização do SVG. Para quadros de texto, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) inclui o quadro de texto na área de renderização, e [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) determina se a rotação do quadro é aplicada. Defina [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) como `true` quando o texto precisar ser renderizado sem ligaduras.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Controlar o recorte de extremidade de linha nas setas**

O SVG 1.1 não possui uma configuração de inserção de marcador para especificar onde uma linha deve parar sob uma ponta de seta. Por padrão, Aspose.Slides encurta a linha exportada para que seu traço não se projete através do marcador. Defina [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) como `true` para desenhar o traço até o ponto final original da linha. Essa configuração afeta apenas a saída SVG. A linha mantém sua posição e comprimento no slide.

O exemplo desenha pontas de seta em forma de triângulo e diamante em linhas de 2 e 10 pontos de largura. Ele exporta o mesmo slide duas vezes, alterando apenas a opção de recorte.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

A comparação mostra a ponta de seta triangular na linha de 10 pontos. Com o recorte habilitado, a ponta está afiada. Com o recorte desabilitado, o traço se projeta através das laterais inclinadas do marcador, deixando uma extremidade plana.

![Triângulo de 10 pontos ampliado com ponta afiada quando o recorte está habilitado e extremidade plana quando o recorte está desabilitado](line-end-cropping.png)

Nas outras linhas do exemplo, o traço que se projeta é menos visível no triângulo de 2 pontos. O diamante preenchido cobre a extremidade do traço em ambas as larguras.

## **Controlar texto e fontes**

Ao exportar slides para SVG, você pode controlar se o texto permanece como texto ou é convertido em gráficos vetoriais, e como fontes externas são incluídas ou referenciadas. As opções a seguir ajudam a equilibrar a consistência visual, a seleção de texto e as dependências de fontes no SVG exportado.

### **Vetorização de todo o texto**

Defina [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) como `true` para gravar todo o texto do slide como gráficos vetoriais. Isso elimina dependências de fontes e torna o resultado visual mais consistente em diferentes navegadores, porém o texto deixa de ser selecionável ou pesquisável como texto SVG.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **Escolher como as fontes externas são tratadas**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) usa um valor [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) para fontes que são carregadas externamente. Escolha `AddLinksToFontFiles` para referenciar arquivos de fonte separados, `Embed` para incluir os dados da fonte no SVG, ou `Vectorize` para renderizar apenas o texto que usa fontes externas como gráficos. Verifique a licença da fonte antes de incorporá‑la.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **Reduzir o tamanho de imagens incorporadas**

Use [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) para reduzir a resolução das imagens incorporadas, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) para omitir áreas recortadas da fonte, e [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) para controlar a qualidade da codificação JPEG. Essas configurações reduzem o tamanho do arquivo ao custo da fidelidade da imagem ou dos dados de imagem mantidos.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Controlar a resolução de rasterização de metarquivo**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) define o limite inferior de resolução para rasterizar metarquivos durante a exportação SVG. Use‑o para equilibrar detalhes e tamanho do arquivo quando uma imagem EMF ou WMF for rasterizada. Ele não define um DPI global para o SVG nem força que cada objeto no slide se torne uma imagem raster.

Baixe [metafile-rasterization.pptx](metafile-rasterization.pptx), que contém uma imagem EMF com linhas diagonais muito próximas. O exemplo a seguir exporta o primeiro slide em três resoluções de rasterização através de [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Todas as demais configurações de exportação permanecem idênticas para que os resultados possam ser comparados.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

Na saída, o EMF se tornou um PNG incorporado em cada SVG. As medições a seguir são para a apresentação fornecida; não são uma fórmula geral para converter DPI em dimensões de pixel.

| Rasterização de metarquivo DPI | Dimensões do PNG incorporado | Tamanho do arquivo SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

A comparação abaixo mostra a mesma área do raster incorporado no mesmo tamanho de exibição ampliado. As linhas diagonais apresentam pixelização visível em 72 DPI e bordas mais suaves em resoluções maiores, enquanto o arquivo SVG aumenta. Aumentar o valor não melhora necessariamente todos os detalhes nem altera todas as imagens exportadas.

![Detalhe de linha diagonal ampliado em 72, 150 e 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) controla a redução da resolução da imagem e pode mascarar o efeito da alteração da resolução de rasterização do metarquivo. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) controla a qualidade da codificação JPEG, não a resolução de rasterização do metarquivo.

## **Atribuir IDs estáveis a formas e texto**

Use [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) para definir [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) para cada forma SVG. Para definir valores [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) em elementos `tspan` de texto também, implemente [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Atribua qualquer um dos controladores com [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

O controlador a seguir usa [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), que é estável durante a vida útil da forma, e um contador repetível para seus trechos de texto. Isso torna os IDs gerados adequados para pós‑processamento de uma apresentação não alterada.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **Adicionar manipuladores de evento SVG**

Em um [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/), chame [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) com um valor [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) para adicionar um manipulador de evento JavaScript a uma forma exportada. Atribua o controlador com [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) e defina a função JavaScript na página ou documento SVG que hospeda o resultado.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

A página host pode definir a função JavaScript referenciada pelo manipulador. Atribuir IDs e manipuladores de evento habilita visualizadores de slides, aprimoramentos de acessibilidade e outros fluxos de trabalho interativos de SVG.

## **Perguntas frequentes**

**Quando devo usar [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) em vez de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

Use [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) quando todo o texto precisar ser independente de fontes. Use [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) quando apenas o texto que usa fontes externas deva ser convertido em gráficos.

**Qual é a melhor maneira de tornar um SVG menor?**

Comece comprimindo as imagens incorporadas, excluindo áreas de imagem recortadas e escolhendo arquivos de fonte vinculados quando o ambiente de destino puder servi‑los. Teste o resultado, pois resolução de imagem mais baixa, qualidade JPEG menor e texto vetorizado possuem diferentes compensações entre qualidade e tamanho.

**Posso modificar os elementos SVG exportados após a exportação?**

Sim. Atribua IDs por meio de um controlador de formatação e, em seguida, selecione os elementos SVG correspondentes em sua ferramenta de pós‑processamento ou script do navegador.