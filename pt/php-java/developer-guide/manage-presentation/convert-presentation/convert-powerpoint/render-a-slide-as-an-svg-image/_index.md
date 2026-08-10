---
title: Renderizar Slides de Apresentação como Imagens SVG em PHP
linktitle: Slide para SVG
type: docs
weight: 50
url: /pt/php-java/render-a-slide-as-an-svg-image/
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
- PHP
- Aspose.Slides
description: "Exportar slides do PowerPoint como imagens SVG em PHP e controlar fontes, texto, imagens, IDs e eventos com Aspose.Slides."
---
## **Visão geral**

SVG é um formato de imagem XML escalável que funciona bem para publicação na web, visualizadores de slides, fluxos de trabalho de acessibilidade e pós-processamento automatizado. Aspose.Slides exporta cada slide para um arquivo SVG separado e permite controlar como texto, fontes, imagens e elementos SVG são gravados.

Use [SVGOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgoptions/) quando o SVG exportado precisar ser compacto, previsível em diferentes navegadores ou pronto para uso interativo.

## **Exportar um slide como SVG**

Crie uma [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/), selecione um slide e grave‑lo em um stream com [Slide.writeAsSvg](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#writeAsSvg). O exemplo a seguir exporta cada slide de uma apresentação como um arquivo SVG separado.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

O nome do arquivo usa [Slide.getSlideNumber](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#getSlideNumber) em vez do índice do loop. Você também pode exportar uma forma individual com [Shape.writeAsSvg](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#writeAsSvg) quando um visualizador de slides ou página da web precisa apenas dessa forma.

## **Configurar saída SVG**

[SVGOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgoptions/) controla a renderização do SVG. Para quadros de texto, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgoptions/#setUseFrameSize) inclui o quadro de texto na área de renderização, e [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgoptions/#setUseFrameRotation) determina se a rotação do quadro é aplicada. Defina [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) como `true` quando o texto precisar ser renderizado sem ligaduras.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Controlar texto e fontes**

### **Vetorializar todo o texto**

Defina [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgoptions/#setVectorizeText) como `true` para gravar todo o texto do slide como gráficos vetoriais. Isso elimina dependências de fontes e torna o resultado visual mais consistente entre os navegadores, mas o texto não pode mais ser selecionado ou pesquisado como texto SVG.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **Escolher como as fontes externas são tratadas**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) usa um valor [SvgExternalFontsHandling](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgexternalfontshandling/) para fontes que são carregadas externamente. Escolha `AddLinksToFontFiles` para referenciar arquivos de fontes separados, `Embed` para incluir os dados da fonte no SVG, ou `Vectorize` para renderizar apenas o texto que usa fontes externas como gráficos. Verifique a licença das fontes antes de incorporá‑las.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Reduzir tamanho de imagens incorporadas**

Use [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgoptions/#setPicturesCompression) para reduzir a resolução das imagens incorporadas, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) para omitir áreas recortadas da fonte e [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgoptions/#setJpegQuality) para controlar a qualidade da codificação JPEG. Essas configurações reduzem o tamanho do arquivo ao custo da fidelidade da imagem ou dos dados de imagem retidos.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Atribuir IDs estáveis a formas e texto**

Forneça um callback de formatação para [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgoptions/#setShapeFormattingController) para definir [SvgShape.setId](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgshape/#setId) para cada forma SVG. O callback também pode definir valores [SvgTSpan.setId](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgtspan/#setId) em elementos de texto `tspan`.

PhpJavaBridge não pode invocar um callback PHP a partir de `writeAsSvg` quando ele funciona no modo stream. Coloque a lógica de formatação em uma pequena classe auxiliar Java, compile‑a e adicione o arquivo JAR resultante ao classpath da ponte. O auxiliar pode usar [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getOfficeInteropShapeId), que é estável durante a vida útil da forma, e um contador repetível para seus trechos de texto. Consulte a [Implementação Java de `StableSvgIdController`](/slides/pt/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) para o código auxiliar.

Depois de adicionar a classe compilada `com.example.slides.StableSvgIdController` ao classpath da ponte, instancie‑a a partir do PHP e atribua‑a ao `SVGOptions`:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Adicionar manipuladores de eventos SVG**

Em um callback de formatação, chame [SvgShape.setEventHandler](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgshape/#setEventHandler) com um valor [SvgEvent](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgevent/) para adicionar um manipulador de evento JavaScript a uma forma exportada. Atribua o callback com [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgoptions/#setShapeFormattingController) e defina a função JavaScript na página ou documento SVG que hospeda o resultado.

Assim como com IDs estáveis, implemente o callback em um auxiliar Java quando o PhpJavaBridge usa o modo stream. A [Implementação Java de `SvgEventController`](/slides/pt/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) atribui um ID e um manipulador `OnClick` a uma forma chamada `ActionButton`. Compile esse auxiliar, adicione‑o ao classpath da ponte como `com.example.slides.SvgEventController` e use‑o a partir do PHP da seguinte forma:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

A página host pode definir a função JavaScript referenciada pelo manipulador. Atribuir IDs e manipuladores de eventos permite visualizadores de slides, aprimoramentos de acessibilidade e outros fluxos de trabalho interativos com SVG.

## **Perguntas frequentes**

**Quando devo usar [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgoptions/#setVectorizeText) em vez de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgexternalfontshandling/)?**

Use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgoptions/#setVectorizeText) quando todo o texto precisar ser independente de fontes. Use [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgexternalfontshandling/) quando somente o texto que usa fontes externas deve ser convertido em gráficos.

**Qual é a melhor forma de tornar um SVG menor?**

Comece comprimindo as imagens incorporadas, excluindo áreas de imagem recortadas e escolhendo arquivos de fontes vinculados quando o ambiente de destino puder servi‑los. Teste o resultado, pois resolução de imagem mais baixa, qualidade JPEG reduzida e texto vetorizado têm diferentes compensações de qualidade e tamanho.

**Posso modificar os elementos SVG exportados após a exportação?**

Sim. Atribua IDs por meio de um callback de formatação e, em seguida, selecione os elementos SVG correspondentes em sua ferramenta de pós‑processamento ou script do navegador.