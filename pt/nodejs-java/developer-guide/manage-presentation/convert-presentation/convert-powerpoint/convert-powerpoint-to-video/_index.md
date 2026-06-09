---
title: Converter apresentações PowerPoint para vídeo em JavaScript
linktitle: PowerPoint para Vídeo
type: docs
weight: 130
url: /pt/nodejs-java/convert-powerpoint-to-video/
keywords:
  - converter PowerPoint
  - converter apresentação
  - converter PPT
  - converter PPTX
  - PowerPoint para vídeo
  - apresentação para vídeo
  - PPT para vídeo
  - PPTX para vídeo
  - PowerPoint para MP4
  - apresentação para MP4
  - PPT para MP4
  - PPTX para MP4
  - salvar PPT como MP4
  - salvar PPTX como MP4
  - exportar PPT para MP4
  - exportar PPTX para MP4
  - conversão de vídeo
  - PowerPoint
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Aprenda como converter apresentações PowerPoint em vídeo usando JavaScript. Descubra códigos de exemplo e técnicas de automação para otimizar seu fluxo de trabalho."
---
## **Introdução**

Ao converter sua apresentação PowerPoint em vídeo, você obtém 

* **Aumento da acessibilidade:** Todos os dispositivos (independentemente da plataforma) vêm equipados com reprodutores de vídeo por padrão, ao contrário dos aplicativos de abertura de apresentações, portanto os usuários acham mais fácil abrir ou reproduzir vídeos.
* **Maior alcance:** Por meio de vídeos, você pode alcançar um grande público e direcioná‑lo com informações que, de outra forma, pareceriam tediosas em uma apresentação. A maioria das pesquisas e estatísticas indica que as pessoas assistem e consomem vídeos mais do que outros tipos de conteúdo, e geralmente preferem esse tipo de conteúdo.

{{% alert color="primary" %}} 
Talvez você queira conferir nosso [**Conversor Online de PowerPoint para Vídeo**](https://products.aspose.app/slides/pt/conversion/ppt-to-word) porque ele é uma implementação ao vivo e eficaz do processo descrito aqui.
{{% /alert %}} 

## **Conversão de PowerPoint para Vídeo no Aspose.Slides**

Aspose.Slides oferece suporte à conversão de apresentações em vídeo.

* Use **Aspose.Slides** para gerar um conjunto de quadros (a partir dos slides da apresentação) que correspondam a uma certa taxa de FPS (quadros por segundo)
* Use uma ferramenta de terceiros como **ffmpeg** ([para java](https://github.com/bramp/ffmpeg-cli-wrapper)) para criar um vídeo com base nos quadros. 

### **Converter PowerPoint para Vídeo**

1. Baixe o ffmpeg [aqui](https://ffmpeg.org/download.html).

2. Execute o código JavaScript de PowerPoint para vídeo.

Este código JavaScript mostra como converter uma apresentação (contendo uma figura e dois efeitos de animação) em um vídeo:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Adiciona uma forma de sorriso e então a anima
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Configura a pasta de binários do ffmpeg. Veja esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Efeitos de Vídeo**

Você pode aplicar animações a objetos nos slides e usar transições entre os slides. 

{{% alert color="primary" %}} 
Talvez você queira ver estes artigos: [Animação PowerPoint](https://docs.aspose.com/slides/pt/nodejs-java/powerpoint-animation/), [Animação de Forma](https://docs.aspose.com/slides/pt/nodejs-java/shape-animation/), e [Efeito de Forma](https://docs.aspose.com/slides/pt/nodejs-java/shape-effect/).
{{% /alert %}} 

Animações e transições tornam apresentações de slides mais envolventes e interessantes—e fazem o mesmo por vídeos. Vamos adicionar outro slide e transição ao código da apresentação anterior:

```javascript
// Adiciona uma forma de sorriso e a anima
// ...
// Adiciona um novo slide e transição animada
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Aspose.Slides também oferece suporte à animação de textos. Assim, animamos parágrafos em objetos, que aparecerão um após o outro (com o atraso definido para um segundo):

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Adiciona texto e animações
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Configura a pasta de binários do ffmpeg. Veja esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Classes de Conversão de Vídeo**

Para permitir que você execute tarefas de conversão de PowerPoint para vídeo, Aspose.Slides fornece as classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationanimationsgenerator/) e [PresentationPlayer](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationanimationsgenerator/) permite definir o tamanho do quadro para o vídeo (que será criado posteriormente) por meio de seu construtor. Se você passar uma instância da apresentação, `Presentation.getSlideSize` será usado e ele gera animações que [PresentationPlayer](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationplayer/) utiliza.

Quando as animações são geradas, um evento `NewAnimation` é disparado para cada animação subsequente, que possui o parâmetro de player de animação da apresentação. Este último é uma classe que representa um player para uma animação separada.

Para trabalhar com o player de animação da apresentação, são usados os métodos `getDuration` (a duração total da animação) e `setTimePosition`. Cada posição de animação é definida dentro do intervalo *0 a duração*, e então o método `getFrame` retornará um BufferedImage que corresponde ao estado da animação naquele momento:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Adiciona uma forma de sorriso e a anima
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// estado inicial da animação
            try {
                // bitmap do estado inicial da animação
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// estado final da animação
            try {
                // último quadro da animação
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Para fazer com que todas as animações de uma apresentação sejam reproduzidas simultaneamente, usa‑se a classe [PresentationPlayer](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationplayer/). Essa classe recebe uma instância de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationanimationsgenerator/) e FPS para os efeitos em seu construtor e, em seguida, chama o evento `FrameTick` para todas as animações a fim de reproduzi‑las:

```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Em seguida, os quadros gerados podem ser compilados para produzir um vídeo. Consulte a seção [Converter PowerPoint para Vídeo](https://docs.aspose.com/slides/pt/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animações e Efeitos Compatíveis**

**Entrada**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Aparecer** | ![not supported](x.png) | ![supported](v.png) |
| **Desvanecer** | ![supported](v.png) | ![supported](v.png) |
| **Entrar Voando** | ![supported](v.png) | ![supported](v.png) |
| **Flutuar Para Dentro** | ![supported](v.png) | ![supported](v.png) |
| **Dividir** | ![supported](v.png) | ![supported](v.png) |
| **Limpar** | ![supported](v.png) | ![supported](v.png) |
| **Forma** | ![supported](v.png) | ![supported](v.png) |
| **Roda** | ![supported](v.png) | ![supported](v.png) |
| **Barras Aleatórias** | ![supported](v.png) | ![supported](v.png) |
| **Crescer e Girar** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Girar** | ![supported](v.png) | ![supported](v.png) |
| **Quicar** | ![supported](v.png) | ![supported](v.png) |

**Ênfase**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulsar** | ![not supported](x.png) | ![supported](v.png) |
| **Pulsar de Cor** | ![not supported](x.png) | ![supported](v.png) |
| **Oscilar** | ![supported](v.png) | ![supported](v.png) |
| **Girar** | ![supported](v.png) | ![supported](v.png) |
| **Crescer/Encolher** | ![not supported](x.png) | ![supported](v.png) |
| **Dessaturar** | ![not supported](x.png) | ![supported](v.png) |
| **Escurecer** | ![not supported](x.png) | ![supported](v.png) |
| **Clarear** | ![not supported](x.png) | ![supported](v.png) |
| **Transparência** | ![not supported](x.png) | ![supported](v.png) |
| **Cor do Objeto** | ![not supported](x.png) | ![supported](v.png) |
| **Cor Complementar** | ![not supported](x.png) | ![supported](v.png) |
| **Cor da Linha** | ![not supported](x.png) | ![supported](v.png) |
| **Cor de Preenchimento** | ![not supported](x.png) | ![supported](v.png) |

**Saída**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Desaparecer** | ![not supported](x.png) | ![supported](v.png) |
| **Desvanecer** | ![supported](v.png) | ![supported](v.png) |
| **Voar para Fora** | ![supported](v.png) | ![supported](v.png) |
| **Flutuar para Fora** | ![supported](v.png) | ![supported](v.png) |
| **Dividir** | ![supported](v.png) | ![supported](v.png) |
| **Limpar** | ![supported](v.png) | ![supported](v.png) |
| **Forma** | ![supported](v.png) | ![supported](v.png) |
| **Barras Aleatórias** | ![supported](v.png) | ![supported](v.png) |
| **Encolher e Girar** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Girar** | ![supported](v.png) | ![supported](v.png) |
| **Quicar** | ![supported](v.png) | ![supported](v.png) |

**Caminhos de Movimento**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linhas** | ![supported](v.png) | ![supported](v.png) |
| **Arcos** | ![supported](v.png) | ![supported](v.png) |
| **Curvas** | ![supported](v.png) | ![supported](v.png) |
| **Formas** | ![supported](v.png) | ![supported](v.png) |
| **Laços** | ![supported](v.png) | ![supported](v.png) |
| **Caminho Personalizado** | ![supported](v.png) | ![supported](v.png) |

## **Perguntas Frequentes**

**É possível converter apresentações protegidas por senha?**

Sim, o Aspose.Slides permite trabalhar com apresentações protegidas por senha. Ao processar esses arquivos, você precisa fornecer a senha correta para que a biblioteca possa acessar o conteúdo da apresentação.

**O Aspose.Slides oferece suporte ao uso em soluções de nuvem?**

Sim, o Aspose.Slides pode ser integrado a aplicativos e serviços em nuvem. A biblioteca foi projetada para operar em ambientes de servidor, garantindo alto desempenho e escalabilidade para o processamento em lote de arquivos.

**Existem limitações de tamanho para apresentações durante a conversão?**

O Aspose.Slides é capaz de lidar com apresentações de praticamente qualquer tamanho. Contudo, ao trabalhar com arquivos muito grandes, podem ser necessários recursos de sistema adicionais, e às vezes recomenda‑se otimizar a apresentação para melhorar o desempenho.