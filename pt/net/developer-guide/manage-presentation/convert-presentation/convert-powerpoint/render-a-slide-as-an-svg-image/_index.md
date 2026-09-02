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

SVG é um formato de imagem escalável baseado em XML que funciona bem para publicação na web, visualizadores de slides, fluxos de trabalho de acessibilidade e pós‑processamento automatizado. Aspose.Slides exporta cada slide para um arquivo SVG separado e permite que você controle como texto, fontes, imagens e elementos SVG são gravados.

Use [SVGOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgoptions/) quando o SVG exportado precisar ser compacto, previsível em diferentes navegadores ou pronto para uso interativo.

## **Exportar um slide como SVG**

Crie uma [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/), selecione um slide e grave‑o em um fluxo. O exemplo a seguir exporta cada slide de uma apresentação como um arquivo SVG separado.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

O nome do arquivo usa [ISlide.SlideNumber](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/slidenumber/) em vez do índice do loop. Você também pode exportar uma forma individual com [IShape.WriteAsSvg](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/writeassvg/) quando um visualizador de slides ou página web precisar apenas dessa forma.

## **Configurar saída SVG**

[SVGOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgoptions/) controla a renderização de SVG. Para quadros de texto, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgoptions/useframesize/) inclui o quadro de texto na área de renderização, e [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgoptions/useframerotation/) determina se a rotação do quadro é aplicada. Defina [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgoptions/disablefontligatures/) como `true` quando o texto precisar ser renderizado sem ligaduras.

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

## **Controlar texto e fontes**

### **Vectorizar todo o texto**

Defina [SVGOptions.VectorizeText](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgoptions/vectorizetext/) como `true` para gravar todo o texto do slide como gráficos vetoriais. Isso elimina dependências de fontes e torna o resultado visual mais consistente entre navegadores, porém o texto deixa de ser selecionável ou pesquisável como texto SVG.

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

### **Escolher como fontes externas são tratadas**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgoptions/externalfontshandling/) utiliza um valor [SvgExternalFontsHandling](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgexternalfontshandling/) para fontes carregadas externamente. Escolha `AddLinksToFontFiles` para referenciar arquivos de fontes separados, `Embed` para incluir os dados da fonte no SVG, ou `Vectorize` para renderizar apenas o texto que usa fontes externas como gráficos. Verifique a licença das fontes antes de incorporá‑las.

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

## **Reduzir tamanho de imagens incorporadas**

Use [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgoptions/picturescompression/) para reduzir a resolução das imagens incorporadas, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) para omitir áreas recortadas da fonte, e [SVGOptions.JpegQuality](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgoptions/jpegquality/) para controlar a qualidade da codificação JPEG. Essas configurações reduzem o tamanho do arquivo ao custo da fidelidade da imagem ou dos dados da imagem preservados.

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

## **Atribuir IDs estáveis a formas e texto**

Use [ISvgShapeFormattingController](https://reference.aspose.com/slides/pt/net/aspose.slides.export/isvgshapeformattingcontroller/) para definir [ISvgShape.Id](https://reference.aspose.com/slides/pt/net/aspose.slides.export/isvgshape/id/) para cada forma SVG. Para definir valores [ISvgTSpan.Id](https://reference.aspose.com/slides/pt/net/aspose.slides.export/isvgtspan/id/) em elementos `tspan` de texto também, implemente [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/pt/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Atribua qualquer um dos controladores com [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

O controlador a seguir usa [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/officeinteropshapeid/), que é estável durante a vida útil da forma, e um contador repetível para seus trechos de texto. Isso torna os IDs gerados adequados para pós‑processamento de uma apresentação não alterada.

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

## **Adicionar manipuladores de eventos SVG**

Em um [ISvgShapeFormattingController](https://reference.aspose.com/slides/pt/net/aspose.slides.export/isvgshapeformattingcontroller/), chame [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/pt/net/aspose.slides.export/isvgshape/seteventhandler/) com um valor [SvgEvent](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgevent/) para adicionar um manipulador de evento JavaScript a uma forma exportada. Atribua o controlador com [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) e defina a função JavaScript na página ou documento SVG que hospeda o resultado.

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

A página host pode definir a função JavaScript referenciada pelo manipulador. A atribuição de IDs e manipuladores de eventos permite visualizadores de slides, aprimoramentos de acessibilidade e outros fluxos de trabalho interativos com SVG.

## **Perguntas frequentes**

**Quando devo usar [SVGOptions.VectorizeText](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgoptions/vectorizetext/) em vez de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgexternalfontshandling/)?**

Use [SVGOptions.VectorizeText](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgoptions/vectorizetext/) quando todo o texto precisar ser independente de fontes. Use [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgexternalfontshandling/) quando apenas o texto que utiliza fontes externas deve ser convertido em gráficos.

**Qual a melhor maneira de tornar um SVG menor?**

Comece comprimindo as imagens incorporadas, excluindo áreas de imagens recortadas e escolhendo arquivos de fontes vinculados quando o ambiente de destino puder fornecê‑los. Teste o resultado, pois menor resolução de imagem, qualidade JPEG reduzida e texto vetorizado apresentam diferentes compromissos entre qualidade e tamanho.

**Posso modificar os elementos SVG exportados após a exportação?**

Sim. Atribua IDs por meio de um controlador de formatação e, em seguida, selecione os elementos SVG correspondentes na sua ferramenta de pós‑processamento ou script de navegador.