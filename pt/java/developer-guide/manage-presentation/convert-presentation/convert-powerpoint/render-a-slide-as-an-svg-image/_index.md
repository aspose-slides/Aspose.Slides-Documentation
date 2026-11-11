---
title: Renderizar Slides de Apresentação como Imagens SVG em Java
linktitle: Slide para SVG
type: docs
weight: 50
url: /pt/java/render-a-slide-as-an-svg-image/
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
- Java
- Aspose.Slides
description: "Exporte slides do PowerPoint como imagens SVG em Java e controle fontes, texto, imagens, IDs e eventos com Aspose.Slides."
---
## **Visão geral**

SVG é um formato de imagem XML escalável que funciona bem para publicação na web, visualizadores de slides, fluxos de trabalho de acessibilidade e pós‑processamento automatizado. Aspose.Slides exporta cada slide para um arquivo SVG separado e permite controlar como texto, fontes, imagens e elementos SVG são escritos.

Use [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) quando o SVG exportado precisar ser compacto, previsível entre navegadores ou pronto para uso interativo.

## **Exportar um slide como SVG**

Crie uma [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), selecione um slide e escreva‑o em um stream com [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). O exemplo a seguir exporta cada slide de uma apresentação como um arquivo SVG separado.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

O nome do arquivo usa [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) em vez do índice do loop. Você também pode exportar uma forma individual com [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) quando um visualizador de slides ou página web precisar apenas dessa forma.

## **Configurar a saída SVG**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) controla a renderização SVG. Para quadros de texto, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) inclui o quadro de texto na área de renderização, e [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) determina se a rotação do quadro é aplicada. Defina [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) como `true` quando o texto precisar ser renderizado sem ligaduras.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Controlar texto e fontes**

Ao exportar slides para SVG, você pode controlar se o texto permanece como texto ou é convertido em gráficos vetoriais, e como fontes externas são incluídas ou referenciadas. As opções a seguir ajudam a equilibrar consistência visual, seleção de texto e dependências de fonte no SVG exportado.

### **Vetorização de todo o texto**

Defina [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) como `true` para gravar todo o texto do slide como gráficos vetoriais. Isso elimina dependências de fontes e torna o resultado visual mais consistente entre navegadores, mas o texto não pode mais ser selecionado ou pesquisado como texto SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **Escolher como as fontes externas são tratadas**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) usa um valor [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) para fontes carregadas externamente. Escolha `AddLinksToFontFiles` para referenciar arquivos de fonte separados, `Embed` para incluir dados de fonte no SVG, ou `Vectorize` para renderizar apenas o texto que usa fontes externas como gráficos. Verifique a licença das fontes antes de incorporá‑las.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Reduzir o tamanho de imagens incorporadas**

Use [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) para reduzir a resolução das imagens incorporadas, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) para omitir áreas recortadas da fonte, e [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) para controlar a qualidade da codificação JPEG. Essas configurações reduzem o tamanho do arquivo ao custo da fidelidade da imagem ou dos dados de imagem retidos.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Controlar a resolução de rasterização de metarquivos**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) define o limite inferior de resolução para rasterizar metarquivos durante a exportação SVG. Use‑o para equilibrar detalhe e tamanho do arquivo quando uma imagem EMF ou WMF for rasterizada. Não define um DPI global para o SVG nem força que todo objeto no slide se torne uma imagem raster.

Baixe [metafile-rasterization.pptx](metafile-rasterization.pptx), que contém uma imagem EMF com linhas diagonais espaçadas de perto. O exemplo a seguir exporta seu primeiro slide em três resoluções de rasterização através de [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Todas as demais configurações de exportação permanecem idênticas para que os resultados possam ser comparados.

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

Na saída, o EMF tornou‑se um PNG incorporado em cada SVG. As medições a seguir referem‑se à apresentação fornecida; elas não são uma fórmula geral para converter DPI em dimensões de pixel.

| DPI de rasterização do metarquivo | Dimensões do PNG incorporado | Tamanho do arquivo SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

A comparação abaixo mostra a mesma área do raster incorporado no mesmo tamanho de exibição ampliado. As linhas diagonais mostram pixelização visível a 72 DPI e bordas mais suaves em resoluções maiores, enquanto o arquivo SVG aumenta. Aumentar o valor não melhora necessariamente cada detalhe ou altera cada imagem exportada.

![Detalhe enlargado de linha diagonal em 72, 150 e 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) controla a redução da resolução da imagem e pode mascarar o efeito de mudança da resolução de rasterização de metarquivos. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) controla a qualidade da codificação JPEG, não a resolução de rasterização de metarquivos.

## **Atribuir IDs estáveis a formas e texto**

Use [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) para definir [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) para cada forma SVG. Para definir valores [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) em elementos de texto `tspan` também, implemente [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Atribua qualquer um dos controladores com [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

O controlador a seguir usa [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) , que é estável durante a vida útil da forma, e um contador repetível para seus spans de texto. Isso torna os IDs gerados adequados para pós‑processamento de uma apresentação não alterada.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Adicionar manipuladores de eventos SVG**

Em um [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/), chame [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) com um valor [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/) para adicionar um manipulador de evento JavaScript a uma forma exportada. Atribua o controlador com [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) e defina a função JavaScript na página ou documento SVG que hospeda o resultado.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

A página host pode definir a função JavaScript referenciada pelo manipulador. Atribuir IDs e manipuladores de eventos habilita visualizadores de slides, aprimoramentos de acessibilidade e outros fluxos de trabalho SVG interativos.

## **FAQ**

**Quando devo usar [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) em vez de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)?**

Use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) quando todo o texto precisar ser independente de fontes. Use [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) quando apenas o texto que usa fontes externas deve ser convertido em gráficos.

**Qual é a melhor maneira de tornar um SVG menor?**

Comece comprimindo as imagens incorporadas, excluindo áreas recortadas e escolhendo arquivos de fonte vinculados quando o ambiente de destino puder servi‑los. Teste o resultado porque resolução de imagem menor, qualidade JPEG menor e texto vetorizado têm diferentes compensações de qualidade e tamanho.

**Posso modificar elementos SVG exportados após a exportação?**

Sim. Atribua IDs através de um controlador de formatação, então selecione os elementos SVG correspondentes na sua ferramenta de pós‑processamento ou script de navegador.