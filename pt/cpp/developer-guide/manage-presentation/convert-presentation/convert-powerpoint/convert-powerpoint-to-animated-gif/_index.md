---
title: Converter apresentações PowerPoint em GIF animados em C++
linktitle: PowerPoint para GIF
type: docs
weight: 65
url: /pt/cpp/convert-powerpoint-to-animated-gif/
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
- C++
- Aspose.Slides
description: "Converta facilmente apresentações PowerPoint (PPT, PPTX) em GIF animados com Aspose.Slides para C++. Resultados rápidos e de alta qualidade."
---
## **Visão geral**

Aspose.Slides permite que você converta apresentações PowerPoint em arquivos GIF animados com apenas algumas linhas de código. Isso é útil quando você precisa compartilhar o conteúdo dos slides em um formato animado leve, amplamente suportado, que pode ser incorporado em páginas da web, mensageiros ou documentação. Este artigo explica como exportar uma apresentação para GIF usando as configurações padrão e como personalizar a saída configurando opções como tamanho do quadro, atraso entre slides e taxa de quadros de transição por meio de [GifOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/gifoptions/).

## **Converter apresentações em GIF animado usando configurações padrão**

Este código de exemplo em C++ mostra como converter uma apresentação para GIF animado usando as configurações padrão:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

O GIF animado será criado com parâmetros padrão. 

{{%  alert  title="TIP"  color="primary"  %}} 

Se preferir personalizar os parâmetros do GIF, você pode usar a classe [GifOptions](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.export.gif_options). Veja o código de exemplo abaixo. 

{{% /alert %}} 

## **Converter apresentações em GIF animado usando configurações personalizadas**

Este código de exemplo mostra como converter uma apresentação para GIF animado usando configurações personalizadas em C++:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// o tamanho do GIF resultante
gifOptions->set_FrameSize(Size(960, 720));
// por quanto tempo cada slide será exibido até ser trocado pelo próximo
gifOptions->set_DefaultDelay(2000);
// aumente FPS para melhorar a qualidade da animação de transição
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}

Você pode querer conferir um conversor GRATUITO de [Texto para GIF](https://products.aspose.app/slides/pt/text-to-gif) desenvolvido pela Aspose. 

{{% /alert %}}

## **FAQ**

**E se as fontes usadas na apresentação não estiverem instaladas no sistema?**

Instale as fontes faltantes ou [configure fontes de fallback](/slides/pt/cpp/powerpoint-fonts/). Aspose.Slides fará a substituição, mas a aparência pode ser diferente. Para branding, sempre garanta que as tipografias necessárias estejam explicitamente disponíveis.

**Posso sobrepor uma marca d'água nos quadros do GIF?**

Sim. [Adicione um objeto/logo semitransparente](/slides/pt/cpp/watermark/) ao slide mestre ou aos slides individuais antes da exportação — a marca d'água aparecerá em cada quadro.