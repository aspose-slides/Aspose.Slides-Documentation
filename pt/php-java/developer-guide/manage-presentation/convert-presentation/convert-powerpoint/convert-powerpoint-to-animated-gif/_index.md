---
title: Converter apresentações PowerPoint para GIFs animados em PHP
linktitle: PowerPoint para GIF
type: docs
weight: 65
url: /pt/php-java/convert-powerpoint-to-animated-gif/
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
- PHP
- Aspose.Slides
description: "Converta facilmente apresentações PowerPoint (PPT, PPTX) em GIFs animados com Aspose.Slides para PHP via Java. Resultados rápidos e de alta qualidade."
---
## **Visão geral**

Aspose.Slides permite converter apresentações do PowerPoint em arquivos GIF animados com apenas algumas linhas de código. Isso é útil quando você precisa compartilhar o conteúdo dos slides em um formato animado leve e amplamente suportado, que pode ser incorporado em páginas da web, mensageiros ou documentação. Este artigo explica como exportar uma apresentação para GIF usando as configurações padrão e como personalizar a saída configurando opções como tamanho do quadro, atraso do slide e taxa de quadros de transição através de [GifOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/gifoptions/).

## **Converter apresentações para GIF animado usando configurações padrão**

Este código de exemplo mostra como converter uma apresentação para GIF animado usando as configurações padrão:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

O GIF animado será criado com parâmetros padrão. 

{{%  alert  title="TIP"  color="primary"  %}} 

Se você preferir personalizar os parâmetros do GIF, pode usar a classe [GifOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/GifOptions). Veja o código de exemplo abaixo.

{{% /alert %}} 

## **Converter apresentações para GIF animado usando configurações personalizadas**
Este código de exemplo mostra como converter uma apresentação para GIF animado usando configurações personalizadas :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// o tamanho do GIF resultante

    $gifOptions->setDefaultDelay(2000);// quanto tempo cada slide será exibido até ser trocado para o próximo

    $gifOptions->setTransitionFps(35);// aumentar FPS para melhorar a qualidade da animação de transição

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}

Você pode conferir um conversor GRATUITO de [Texto para GIF](https://products.aspose.app/slides/pt/text-to-gif) desenvolvido pela Aspose. 

{{% /alert %}}

## **Perguntas frequentes**

**E se as fontes usadas na apresentação não estiverem instaladas no sistema?**

Instale as fontes ausentes ou [configure fontes de fallback](/slides/pt/php-java/powerpoint-fonts/). Aspose.Slides substituirá, mas a aparência pode diferir. Para branding, sempre garanta que os tipos de letra necessários estejam explicitamente disponíveis.

**Posso sobrepor uma marca d'água nos quadros do GIF?**

Sim. [Adicione um objeto/logo semitransparente](/slides/pt/php-java/watermark/) ao slide mestre ou a slides individuais antes da exportação — a marca d'água aparecerá em todos os quadros.