---
title: Converter Slides PowerPoint para PNG em JavaScript
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
description: "Converter apresentações PowerPoint em imagens PNG de alta qualidade em JavaScript rapidamente com Aspose.Slides para Node.js, garantindo resultados precisos e automatizados."
---
## **Visão geral**

Este artigo explica como converter apresentações PowerPoint em imagens PNG usando Aspose.Slides. Ele mostra como carregar arquivos de apresentação em formatos como PPT, PPTX e ODP, renderizar slides como imagens e salvar os resultados no formato PNG.

O artigo também demonstra como personalizar as imagens PNG geradas definindo valores de escala ou especificando a largura e altura desejadas.

## **Converter PowerPoint para PNG**

Siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha o objeto slide da coleção retornada pelo método [Presentation.getSlides()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--) da classe [Slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Slide).
3. Use o método [Slide.getImage()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Slide) para obter a miniatura de cada slide.
4. Use o método [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/#save) para salvar a miniatura do slide no formato PNG.

Este código JavaScript mostra como converter uma apresentação PowerPoint para PNG:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Converter PowerPoint para PNG com Dimensões Personalizadas**

Se você deseja obter arquivos PNG em uma determinada escala, pode definir os valores de `desiredX` e `desiredY`, que determinam as dimensões da miniatura resultante. 

Este código em JavaScript demonstra a operação descrita:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Converter PowerPoint para PNG com Tamanho Personalizado**

Se você deseja obter arquivos PNG em um determinado tamanho, pode passar os argumentos `width` e `height` de sua preferência para `ImageSize`. 

Este código mostra como converter um PowerPoint para PNG especificando o tamanho das imagens: 

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Como posso exportar apenas uma forma específica (por exemplo, gráfico ou imagem) ao invés de todo o slide?**

O Aspose.Slides suporta [gerar miniaturas para formas individuais](/slides/pt/nodejs-java/create-shape-thumbnails/); você pode renderizar uma forma para uma imagem PNG.

**A conversão paralela é suportada em um servidor?**

Sim, mas [não compartilhe](/slides/pt/nodejs-java/multithreading/) uma única instância de apresentação entre threads. Use uma instância separada por thread ou processo.

**Quais são as limitações da versão de avaliação ao exportar para PNG?**

O modo de avaliação adiciona uma marca d'água às imagens de saída e impõe [outras restrições](/slides/pt/nodejs-java/licensing/) até que uma licença seja aplicada.