---
title: Converter apresentações PowerPoint para GIF animados no Android
linktitle: PowerPoint para GIF
type: docs
weight: 65
url: /pt/androidjava/convert-powerpoint-to-animated-gif/
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
- Android
- Java
- Aspose.Slides
description: "Converta facilmente apresentações PowerPoint (PPT, PPTX) em GIF animados com Aspose.Slides para Android via Java. Resultados rápidos e de alta qualidade."
---
## **Visão geral**

Aspose.Slides permite converter apresentações do PowerPoint em arquivos GIF animados com apenas algumas linhas de código. Isso é útil quando você precisa compartilhar o conteúdo dos slides em um formato animado leve e amplamente suportado que pode ser incorporado em páginas da web, mensageiros ou documentos. Este artigo explica como exportar uma apresentação para GIF usando as configurações padrão e como personalizar a saída configurando opções como tamanho do quadro, atraso do slide e taxa de quadros de transição através do [GifOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/gifoptions/).

## **Converter apresentações para GIF animado usando configurações padrão**

Este código de exemplo em Java mostra como converter uma apresentação em GIF animado usando as configurações padrão:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

O GIF animado será criado com parâmetros padrão. 

{{%  alert  title="TIP"  color="primary"  %}} 
Se preferir personalizar os parâmetros do GIF, você pode usar a classe [GifOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/GifOptions). Veja o código de exemplo abaixo.
{{% /alert %}} 

## **Converter apresentações para GIF animado usando configurações personalizadas**

Este código de exemplo mostra como converter uma apresentação em GIF animado usando configurações personalizadas em Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // o tamanho do GIF resultante  
	gifOptions.setDefaultDelay(2000); // por quanto tempo cada slide será exibido até ser trocado pelo próximo
	gifOptions.setTransitionFps(35); // aumente o FPS para melhorar a qualidade da animação de transição

	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Você pode querer conferir um conversor GRATUITO de [Text to GIF](https://products.aspose.app/slides/pt/text-to-gif) desenvolvido pela Aspose. 
{{% /alert %}}

## **FAQ**

**E se as fontes usadas na apresentação não estiverem instaladas no sistema?**

Instale as fontes ausentes ou [configure fontes de fallback](/slides/pt/androidjava/powerpoint-fonts/). O Aspose.Slides fará a substituição, mas a aparência pode ser diferente. Para branding, sempre garanta que as tipografias necessárias estejam explicitamente disponíveis.

**Posso sobrepor uma marca d'água nos quadros do GIF?**

Sim. [Adicione um objeto/logo semi-transparente](/slides/pt/androidjava/watermark/) ao slide mestre ou aos slides individuais antes da exportação — a marca d'água aparecerá em cada quadro.