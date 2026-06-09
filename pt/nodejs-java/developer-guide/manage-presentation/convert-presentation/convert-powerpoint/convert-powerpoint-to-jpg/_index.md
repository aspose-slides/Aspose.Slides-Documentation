---
title: Converter PPT e PPTX para JPG em JavaScript
linktitle: PowerPoint para JPG
type: docs
weight: 60
url: /pt/nodejs-java/convert-powerpoint-to-jpg/
keywords: 
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para JPG
- apresentação para JPG
- slide para JPG
- PPT para JPG
- PPTX para JPG
- salvar PowerPoint como JPG
- salvar apresentação como JPG
- salvar slide como JPG
- salvar PPT como JPG
- salvar PPTX como JPG
- exportar PPT para JPG
- exportar PPTX para JPG
- Node.js
- JavaScript
- Aspose.Slides
description: "Converta slides de PowerPoint (PPT, PPTX) em imagens JPG de alta qualidade em JavaScript com Aspose.Slides para Node.js via Java usando exemplos de código rápidos e confiáveis."
---
## **Introdução**

Converter apresentações PowerPoint e OpenDocument em imagens JPG auxilia no compartilhamento de slides, na otimização de desempenho e na incorporação de conteúdo em sites ou aplicativos. Aspose.Slides permite transformar arquivos PPTX, PPT e ODP em imagens JPEG de alta qualidade. Este guia explica diferentes métodos de conversão.

Com esses recursos, é fácil implementar seu próprio visualizador de apresentações e criar uma miniatura para cada slide. Isso pode ser útil se você desejar proteger os slides contra cópia ou demonstrar a apresentação em modo somente leitura. Aspose.Slides permite converter a apresentação inteira ou um slide específico em formatos de imagem.

## **Converter PowerPoint PPT/PPTX para JPG**
A seguir estão os passos para converter PPT/PPTX para JPG:

1. Crie uma instância do tipo [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha o objeto de slide do tipo [Slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Slide) a partir da coleção [Presentation.getSlides()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getSlides--).
3. Crie a miniatura de cada slide e depois converta‑a em JPG. O método [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Slide#getImage-float-float-) é usado para obter uma miniatura de um slide, retornando um objeto [Imagess](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Images) como resultado. O método [getImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) deve ser chamado a partir do slide necessário do tipo [Slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Slide), passando as escalas da miniatura resultante para o método.
4. Depois de obter a miniatura do slide, chame o método [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/#save) a partir do objeto de miniatura. Passe o nome do arquivo resultante e o formato da imagem para ele.  

{{% alert color="primary" %}}

**Nota**: A conversão de PPT/PPTX para JPG difere da conversão para outros tipos na API Aspose.Slides. Para outros tipos, normalmente você usa o método [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-), mas aqui é necessário o método [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/#save).

{{% /alert %}} 

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Cria uma imagem em escala completa
        var slideImage = sld.getImage(1.0, 1.0);
        // Salva a imagem no disco em formato JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
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

## **Converter PowerPoint PPT/PPTX para JPG com Dimensões Personalizadas**
Para alterar a dimensão da miniatura e da imagem JPG resultantes, você pode definir os valores *ScaleX* e *ScaleY* passando‑os para os métodos [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Slide#getImage-float-float-):

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // Define dimensões
    var desiredX = 1200;
    var desiredY = 800;
    // Obtém valores escalados de X e Y
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Cria uma imagem em escala completa
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // Salva a imagem no disco em formato JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
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

## **Renderizar Comentários ao salvar a Apresentação em Imagem**
Aspose.Slides para Node.js via Java oferece um recurso que permite renderizar comentários nos slides de uma apresentação ao convertê‑los em imagens. Este código JavaScript demonstra a operação:

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
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

{{% alert title="Tip" color="primary" %}}

A Aspose fornece um [FREE Collage web app](https://products.aspose.app/slides/pt/collage). Usando este serviço online, você pode mesclar [JPG to JPG](https://products.aspose.app/slides/pt/collage/jpg) ou PNG to PNG, criar [photo grids](https://products.aspose.app/slides/pt/collage/photo-grid) e muito mais. 

{{% /alert %}}

## **Veja também**

Veja outras opções para converter PPT/PPTX em imagem, como:

- [PPT/PPTX to SVG conversion](/slides/pt/nodejs-java/render-a-slide-as-an-svg-image/).

## **FAQ**

**Este método oferece suporte à conversão em lote?**

Sim, Aspose.Slides permite a conversão em lote de vários slides para JPG em uma única operação.

**A conversão suporta SmartArt, gráficos e outros objetos complexos?**

Sim, Aspose.Slides renderiza todo o conteúdo, incluindo SmartArt, gráficos, tabelas, formas e mais. Contudo, a precisão da renderização pode variar ligeiramente em relação ao PowerPoint, especialmente ao usar fontes personalizadas ou ausentes.

**Existem limitações quanto ao número de slides que podem ser processados?**

O próprio Aspose.Slides não impõe limites rígidos ao número de slides que você pode processar. Entretanto, você pode encontrar erros de falta de memória ao trabalhar com apresentações grandes ou imagens de alta resolução.