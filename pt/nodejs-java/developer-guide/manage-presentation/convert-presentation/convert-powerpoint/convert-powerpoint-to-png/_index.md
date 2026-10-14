---
title: Converter slides do PowerPoint para PNG em JavaScript
linktitle: PowerPoint para PNG
type: docs
weight: 30
url: /pt/nodejs-java/convert-powerpoint-to-png/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para PNG
- apresentação para PNG
- slide para PNG
- PPT para PNG
- PPTX para PNG
- salvar PPT como PNG
- salvar PPTX como PNG
- exportar PPT para PNG
- exportar PPTX para PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "Converta apresentações PowerPoint em imagens PNG de alta qualidade em JavaScript rapidamente com Aspose.Slides para Node.js, garantindo resultados precisos e automatizados."
---
## **Visão geral**

Este artigo explica como converter slides de apresentação em imagens PNG usando Aspose.Slides para Node.js via Java. Você pode carregar apresentações em formatos como PPT, PPTX e ODP, renderizar cada slide e salvá‑lo como uma imagem PNG separada.

Os exemplos abaixo demonstram renderização na escala padrão, aumento da escala, especificação das dimensões de saída em pixels e escolha de um estilo de renderização de gradiente.

## **Converter PowerPoint para PNG**

Carregue uma apresentação com a classe [Apresentação](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) e acesse seus slides através da coleção [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides). O exemplo renderiza cada slide com [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) sem parâmetros para criar uma miniatura. Em seguida, chama [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) com [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) para salvar cada slide renderizado como uma imagem PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

A sobrecarga sem parâmetros de [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) renderiza em uma escala de 0,2. Por exemplo, um slide de 720 × 540 pontos produz uma miniatura de 144 × 108 pixels. Para controlar as dimensões de saída, use as sobrecargas com fatores de escala ou um tamanho de imagem explícito mostrados abaixo.

{{% /alert %}}

## **Converter PowerPoint para PNG com dimensões personalizadas**

Passe fatores de escala horizontal e vertical para [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) para controlar as dimensões renderizadas. Neste exemplo, ambos os fatores são 2, portanto um slide de 720 × 540 pontos produz uma imagem de 1440 × 1080 pixels. Fatores de escala iguais preservam a proporção do slide. Cada imagem é salva no formato PNG com [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Converter PowerPoint para PNG com tamanho personalizado**

Para especificar as dimensões de saída em pixels, passe um tamanho para [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) em vez de fatores de escala. Este exemplo renderiza cada slide em 960 × 720 pixels e salva o resultado com [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Escolha dimensões que correspondam à proporção do slide para evitar distorção da imagem.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Escolher um estilo de renderização de gradiente**

Suponha que um slide contenha preenchimentos com gradiente, mas as transições no PNG exportado pareçam mais claras ou diferentes do que você vê no PowerPoint. Você pode usar o método [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) herdado por [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) para escolher como os gradientes são renderizados.

Faça download de [gradient-styles.pptx](gradient-styles.pptx) e coloque-o no diretório de trabalho da aplicação. Seu primeiro slide contém dois gradientes lineares: ciano para laranja na parte superior e azul para amarelo na parte inferior. Cada gradiente tem duas paradas, em 0 % e 100 %.

O exemplo a seguir carrega esta apresentação e renderiza o mesmo primeiro slide em ambos os modos com [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

As imagens abaixo mostram a saída do mesmo slide, com ambos os gradientes em cada imagem:

| Default | PowerPointUI |
| --- | --- |
| ![Gradientes de ciano para laranja e azul para amarelo renderizados com Default](gradient-Default.png) | ![Os mesmos gradientes renderizados com PowerPointUI](gradient-PowerPointUI.png) |

Neste exemplo, `Default` produz cores intermediárias mais claras, enquanto `PowerPointUI` produz cores intermediárias mais escuras. A diferença depende das cores e das paradas no gradiente.

Escolha `Default` quando a saída padrão do Aspose.Slides atender às suas necessidades. Experimente `PowerPointUI` quando sua prioridade for corresponder à aparência no PowerPoint. Compare ambas as saídas com o resultado desejado; nenhum modo é universalmente preferível.

## **Perguntas frequentes**

**Como posso exportar uma forma específica, como um gráfico ou imagem, em vez de todo o slide?**

Aspose.Slides suporta [gerar miniaturas para formas individuais](/slides/pt/nodejs-java/create-shape-thumbnails/), permitindo renderizar uma forma como uma imagem PNG.

**A conversão paralela é suportada em um servidor?**

Sim. Use uma instância de apresentação separada para cada thread ou processo; [não compartilhe uma única instância entre threads](/slides/pt/nodejs-java/multithreading/).

**Quais são as limitações da avaliação ao exportar para PNG?**

O modo de avaliação adiciona uma marca d’água às imagens de saída e aplica [outras restrições](/slides/pt/nodejs-java/licensing/) até que uma licença seja aplicada.