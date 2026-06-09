---
title: Converter apresentações PowerPoint em GIF animados no .NET
linktitle: PowerPoint para GIF
type: docs
weight: 65
url: /pt/net/convert-powerpoint-to-animated-gif/
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
- .NET
- C#
- Aspose.Slides
description: "Converta facilmente apresentações PowerPoint (PPT, PPTX) em GIF animados com Aspose.Slides para .NET. Resultados rápidos e de alta qualidade."
---
## **Visão geral**

Aspose.Slides permite converter apresentações PowerPoint em arquivos GIF animados com apenas algumas linhas de código. Isso é útil quando você precisa compartilhar o conteúdo dos slides em um formato animado leve, amplamente suportado, que pode ser incorporado em páginas da web, mensageiros ou documentação. Este artigo explica como exportar uma apresentação para GIF usando as configurações padrão e como personalizar a saída configurando opções como tamanho do quadro, atraso entre slides e taxa de quadros de transição através da classe [GifOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/gifoptions/).

## **Converter apresentações para GIF animado usando configurações padrão**

Este código de exemplo em C# mostra como converter uma apresentação em GIF animado usando as configurações padrão:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

O GIF animado será criado com parâmetros padrão. 

{{%  alert  title="TIP"  color="primary"  %}} 

Se preferir personalizar os parâmetros do GIF, você pode usar a classe [GifOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/gifoptions). Veja o código de exemplo abaixo. 

{{% /alert %}} 

## **Converter apresentações para GIF animado usando configurações personalizadas**

Este código de exemplo mostra como converter uma apresentação em GIF animado usando configurações personalizadas em C#:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // o tamanho do GIF resultante  
        DefaultDelay = 2000, // por quanto tempo cada slide será exibido até ser trocado pelo próximo
        TransitionFps = 35 // aumente o FPS para melhorar a qualidade da animação de transição
    });
}
```

{{% alert title="Info" color="info" %}}

Você pode experimentar o conversor GRATUITO [Text to GIF](https://products.aspose.app/slides/pt/text-to-gif) desenvolvido pela Aspose. 

{{% /alert %}}

## **FAQ**

**E se as fontes usadas na apresentação não estiverem instaladas no sistema?**

Instale as fontes ausentes ou [configure fallback fonts](/slides/pt/net/powerpoint-fonts/). Aspose.Slides substituirá, mas a aparência pode ser diferente. Para branding, sempre garanta que os tipos de letra necessários estejam disponíveis explicitamente.

**Posso sobrepor uma marca d'água nos quadros do GIF?**

Sim. [Add a semi-transparent object/logo](/slides/pt/net/watermark/) ao slide mestre ou a slides individuais antes da exportação — a marca d'água aparecerá em cada quadro.