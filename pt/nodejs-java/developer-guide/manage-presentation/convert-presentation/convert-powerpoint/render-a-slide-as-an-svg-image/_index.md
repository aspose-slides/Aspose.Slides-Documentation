---
title: Renderizar slides de apresentação como imagens SVG em JavaScript
linktitle: Slide para SVG
type: docs
weight: 50
url: /pt/nodejs-java/render-a-slide-as-an-svg-image/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Exportar slides de PowerPoint como imagens SVG em JavaScript e controlar fontes, texto, imagens, IDs e eventos com Aspose.Slides."
---
## **Visão geral**

SVG é um formato de imagem escalável baseado em XML que funciona bem para publicação na web, visualizadores de slides, fluxos de trabalho de acessibilidade e pós‑processamento automatizado. Aspose.Slides para Node.js via Java exporta cada slide para um arquivo SVG separado e permite que você controle como texto, fontes, imagens e elementos SVG são gravados.

Use [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) quando o SVG exportado precisar ser compacto, previsível em diferentes navegadores ou pronto para uso interativo.

## **Exportar um slide como SVG**

Crie uma [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), selecione um slide e escreva‑o em um fluxo com [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). O exemplo a seguir exporta cada slide de uma apresentação como um arquivo SVG separado.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

O nome do arquivo usa [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) em vez do índice do loop. Você também pode exportar uma forma individual com [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) quando um visualizador de slides ou página web precisa apenas dessa forma.

## **Configurar a saída SVG**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) controla a renderização do SVG. Para quadros de texto, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) inclui o quadro de texto na área de renderização, e [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) determina se a rotação do quadro é aplicada. Defina [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) como `true` quando o texto precisar ser renderizado sem ligaduras.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Controlar texto e fontes**

Ao exportar slides para SVG, você pode controlar se o texto permanece como texto ou é convertido em gráficos vetoriais, e como as fontes externas são incluídas ou referenciadas. As opções a seguir ajudam a equilibrar a consistência visual, a seleção de texto e as dependências de fontes no SVG exportado.

### **Vetorização de todo o texto**

Defina [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) como `true` para gravar todo o texto do slide como gráficos vetoriais. Isso elimina dependências de fontes e torna o resultado visual mais consistente entre navegadores, mas o texto deixa de ser selecionável ou pesquisável como texto SVG.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **Escolher como as fontes externas são tratadas**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) usa um valor [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) para fontes que são carregadas externamente. Escolha `AddLinksToFontFiles` para referenciar arquivos de fontes separados, `Embed` para incluir os dados da fonte no SVG, ou `Vectorize` para renderizar apenas o texto que usa fontes externas como gráficos. Verifique a licenças das fontes antes de incorporá‑las.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Reduzir tamanho de imagens incorporadas**

Use [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) para reduzir a resolução das imagens incorporadas, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) para omitir áreas recortadas da fonte, e [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) para controlar a qualidade de codificação JPEG. Essas configurações reduzem o tamanho do arquivo ao custo da fidelidade da imagem ou dos dados de imagem retidos.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Controlar resolução de rasterização de metarquivo**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) define o limite inferior de resolução para rasterizar metarquivos durante a exportação SVG. Use‑o para equilibrar detalhes e tamanho de arquivo quando uma imagem EMF ou WMF é rasterizada. Ele não define um DPI global para o SVG nem força que todos os objetos no slide se tornem uma imagem raster.

Baixe [metafile-rasterization.pptx](metafile-rasterization.pptx), que contém uma imagem EMF com linhas diagonais próximas. O exemplo a seguir exporta seu primeiro slide em três resoluções de rasterização através de [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Todas as demais configurações de exportação permanecem idênticas para que os resultados possam ser comparados.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

Na saída, o EMF tornou‑se um PNG incorporado em cada SVG. As medições a seguir são para a apresentação fornecida; não são uma fórmula geral para converter DPI em dimensões de pixel.

| Rasterização de metarquivo DPI | Dimensões do PNG incorporado | Tamanho do arquivo SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

A comparação abaixo mostra a mesma área do raster incorporado no mesmo tamanho de exibição ampliado. As linhas diagonais exibem pixelização visível em 72 DPI e bordas mais suaves em resoluções mais altas, enquanto o arquivo SVG aumenta. Aumentar o valor não melhora necessariamente cada detalhe nem altera cada imagem exportada.

![Detalhe ampliado da linha diagonal em 72, 150 e 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) controla a redução da resolução da imagem e pode mascarar o efeito de mudar a resolução de rasterização do metarquivo. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) controla a qualidade de codificação JPEG, não a resolução de rasterização do metarquivo.

## **Atribuir IDs estáveis a formas e texto**

Passe um controlador de formatação para [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) para definir [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) para cada forma SVG. Um controlador que também manipula spans de texto pode definir valores [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) nos elementos de texto `tspan`.

O controlador a seguir usa [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), que é estável durante a vida útil da forma, e um contador repetível para seus spans de texto. Isso torna os IDs gerados adequados para pós‑processamento de uma apresentação não alterada.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Adicionar manipuladores de eventos SVG**

Em um controlador de formatação, chame [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) com um valor [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) para adicionar um manipulador de evento JavaScript a uma forma exportada. Atribua o controlador com [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) e defina a função JavaScript na página ou documento SVG que hospeda o resultado.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

A página host pode definir a função JavaScript referenciada pelo manipulador. Atribuir IDs e manipuladores de eventos permite visualizadores de slides, aprimoramentos de acessibilidade e outros fluxos de trabalho interativos com SVG.

## **Perguntas frequentes**

**Quando devo usar [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) em vez de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) quando todo o texto precisar ser independente de fontes. Use [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) quando somente o texto que usa fontes externas deve ser convertido em gráficos.

**Qual é a melhor maneira de tornar um SVG menor?**

Comece comprimindo as imagens incorporadas, excluindo áreas de imagem recortadas e escolhendo arquivos de fontes vinculados quando o ambiente de destino puder servi‑los. Teste o resultado, pois resolução de imagem mais baixa, qualidade JPEG reduzida e texto vetorizado têm diferentes compensações de qualidade e tamanho.

**Posso modificar os elementos SVG exportados após a exportação?**

Sim. Atribua IDs por meio de um controlador de formatação e, em seguida, selecione os elementos SVG correspondentes na sua ferramenta de pós‑processamento ou script de navegador.