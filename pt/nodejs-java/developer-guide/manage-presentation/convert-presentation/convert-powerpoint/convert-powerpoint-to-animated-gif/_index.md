---
title: Converter apresentações PowerPoint em GIFs animados em JavaScript
linktitle: PowerPoint para GIF
type: docs
weight: 65
url: /pt/nodejs-java/convert-powerpoint-to-animated-gif/
keywords:
- GIF animado
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para GIF
- apresentação para GIF
- slide para GIF
- PPT para GIF
- PPTX para GIF
- salvar PPT como GIF
- salvar PPTX como GIF
- exportar PPT como GIF
- exportar PPTX como GIF
- configurações padrão
- configurações personalizadas
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Converta facilmente apresentações PowerPoint (PPT, PPTX) em GIFs animados em JavaScript com Aspose.Slides para Node.js via Java. Resultados rápidos e de alta qualidade."
---
## **Visão geral**

Aspose.Slides permite converter apresentações PowerPoint em arquivos GIF animados com apenas algumas linhas de código. Isso é útil quando você precisa compartilhar o conteúdo dos slides em um formato animado leve e amplamente suportado, que pode ser incorporado em páginas da web, mensageiros ou documentação. Este artigo explica como exportar uma apresentação para GIF usando as configurações padrão e como personalizar a saída configurando opções como tamanho do quadro, atraso entre slides e taxa de quadros de transição através de [GifOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/gifoptions/).

## **Convertendo apresentações para GIF animado usando configurações padrão**

Este código de exemplo em JavaScript mostra como converter uma apresentação para GIF animado usando as configurações padrão:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

O GIF animado será criado com parâmetros padrão. 

{{%  alert  title="DICA"  color="primary"  %}} 

Se preferir personalizar os parâmetros do GIF, você pode usar a classe [GifOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/GifOptions). Veja o código de exemplo abaixo.

{{% /alert %}} 

## **Convertendo apresentações para GIF animado usando configurações personalizadas**

Este código de exemplo mostra como converter uma apresentação para GIF animado usando configurações personalizadas em JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// o tamanho do GIF resultante
    gifOptions.setDefaultDelay(2000);// quanto tempo cada slide será exibido até ser trocado pelo próximo
    gifOptions.setTransitionFps(35);// aumente FPS para melhorar a qualidade da animação de transição
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Informação" color="info" %}}

Você pode experimentar um conversor GRATUITO de [Text to GIF](https://products.aspose.app/slides/pt/text-to-gif) desenvolvido pela Aspose. 

{{% /alert %}}

## **FAQ**

**E se as fontes usadas na apresentação não estiverem instaladas no sistema?**

Instale as fontes ausentes ou [configure fallback fonts](/slides/pt/nodejs-java/powerpoint-fonts/). Aspose.Slides realizará a substituição, mas a aparência pode diferir. Para branding, sempre garanta que os tipos de letra necessários estejam explicitamente disponíveis.

**Posso sobrepor uma marca d'água nos quadros do GIF?**

Sim. [Add a semi-transparent object/logo](/slides/pt/nodejs-java/watermark/) ao slide mestre ou a slides individuais antes da exportação — a marca d'água aparecerá em cada quadro.