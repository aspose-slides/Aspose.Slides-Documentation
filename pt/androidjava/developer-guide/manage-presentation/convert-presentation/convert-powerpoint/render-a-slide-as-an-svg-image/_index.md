---
title: Renderizar Slides de Apresentação como Imagens SVG no Android
linktitle: Slide para SVG
type: docs
weight: 50
url: /pt/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "Exporte slides PowerPoint como imagens SVG no Android e controle fontes, texto, imagens, IDs e eventos com Aspose.Slides."
---
## **Visão geral**

SVG é um formato de imagem escalável baseado em XML que funciona bem para publicação na web, visualizadores de slides, fluxos de trabalho de acessibilidade e pós‑processamento automatizado. Aspose.Slides for Android via Java exporta cada slide para um arquivo SVG separado e permite controlar como texto, fontes, imagens e elementos SVG são gravados.

Use [SVGOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgoptions/) quando o SVG exportado deve ser compacto, previsível entre navegadores ou pronto para uso interativo.

## **Exportar um slide como SVG**

Crie uma [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/), selecione um slide e grave‑o em um stream com [ISlide.writeAsSvg](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). O exemplo a seguir exporta cada slide de uma apresentação como um arquivo SVG separado.

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

O nome do arquivo usa [ISlide.getSlideNumber](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islide/#getSlideNumber--) em vez do índice do loop. Você também pode exportar uma forma individual com [IShape.writeAsSvg](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) quando um visualizador de slides ou página web precisar apenas dessa forma.

## **Configurar a saída SVG**

[SVGOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgoptions/) controla a renderização de SVG. Para quadros de texto, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) inclui o quadro de texto na área de renderização, e [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) determina se a rotação do quadro é aplicada. Defina [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) como `true` quando o texto precisar ser renderizado sem ligaturas.

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

### **Vectorizar todo o texto**

Defina [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) como `true` para gravar todo o texto do slide como gráficos vetoriais. Isso elimina dependências de fontes e torna o resultado visual mais consistente entre navegadores, porém o texto deixa de ser selecionável ou pesquisável como texto SVG.

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

### **Escolher como fontes externas são tratadas**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) usa um valor [SvgExternalFontsHandling](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgexternalfontshandling/) para fontes que são carregadas externamente. Escolha [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgexternalfontshandling/) para referenciar arquivos de fontes separados, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgexternalfontshandling/) para incluir os dados da fonte no SVG, ou [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgexternalfontshandling/) para renderizar somente o texto que usa fontes externas como gráficos. Verifique a licença das fontes antes de incorporá‑las.

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

Use [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) para reduzir a resolução das imagens incorporadas, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) para omitir áreas recortadas da fonte, e [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) para controlar a qualidade da codificação JPEG. Essas configurações reduzem o tamanho do arquivo ao custo da fidelidade da imagem ou dos dados mantidos.

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

## **Atribuir IDs estáveis a formas e texto**

Use [ISvgShapeFormattingController](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) para definir [ISvgShape.setId](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) para cada forma SVG. Para definir valores [ISvgTSpan.setId](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) nos elementos `tspan` de texto também, implemente [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Atribua qualquer um dos controladores com [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

O controlador a seguir usa [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), que é estável durante a vida útil da forma, e um contador repetível para seus spans de texto. Isso torna os IDs gerados adequados para pós‑processamento de uma apresentação não alterada.

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

Em um [ISvgShapeFormattingController](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), chame [ISvgShape.setEventHandler](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) com um valor [SvgEvent](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgevent/) para adicionar um manipulador de evento JavaScript a uma forma exportada. Atribua o controlador com [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) e defina a função JavaScript na página ou documento SVG que hospeda o resultado.

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

A página host pode definir a função JavaScript referenciada pelo manipulador. Atribuir IDs e manipuladores de eventos habilita visualizadores de slides, aprimoramentos de acessibilidade e outros fluxos de trabalho interativos com SVG.

## **FAQ**

**Quando devo usar [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) em vez de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

Use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) quando todo o texto deve ser independente de fontes. Use [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgexternalfontshandling/) quando somente o texto que usa fontes externas deve ser convertido em gráficos.

**Qual é a melhor maneira de tornar um SVG menor?**

Comece comprimindo as imagens incorporadas, excluindo áreas de imagem recortadas e escolhendo arquivos de fontes vinculados quando o ambiente de destino puder fornec‑los. Teste o resultado, pois menor resolução da imagem, menor qualidade JPEG e texto vetorizado têm diferentes compromissos de qualidade e tamanho.

**Posso modificar os elementos SVG exportados após a exportação?**

Sim. Atribua IDs por meio de um controlador de formatação e, em seguida, selecione os elementos SVG correspondentes em sua ferramenta de pós‑processamento ou script de navegador.