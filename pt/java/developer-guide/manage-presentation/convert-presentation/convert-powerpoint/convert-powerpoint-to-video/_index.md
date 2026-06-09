---
title: Converter apresentações PowerPoint para vídeo em Java
linktitle: PowerPoint para Vídeo
type: docs
weight: 130
url: /pt/java/convert-powerpoint-to-video/
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
- Java
- Aspose.Slides
description: "Aprenda como converter apresentações PowerPoint para vídeo em Java. Descubra códigos de exemplo e técnicas de automação para otimizar seu fluxo de trabalho."
---
## **Introdução**

Ao converter sua apresentação PowerPoint ou OpenDocument para vídeo, você obtém:

**Acessibilidade aumentada:** Todos os dispositivos, independentemente da plataforma, vêm equipados com reprodutores de vídeo por padrão, facilitando a abertura ou reprodução de vídeos em comparação com aplicativos de apresentação tradicionais.

**Alcance maior:** Os vídeos permitem que você alcance um público maior e apresente informações de forma mais envolvente. Pesquisas e estatísticas indicam que as pessoas preferem assistir e consumir conteúdo em vídeo em vez de outras formas, tornando sua mensagem mais impactante.

{{% alert color="primary" %}} 

Você pode querer conferir o nosso [**Conversor Online de PowerPoint para Vídeo**](https://products.aspose.app/slides/pt/conversion/ppt-to-word) porque ele é uma implementação ao vivo e eficaz do processo descrito aqui.

{{% /alert %}} 

## **Conversão de PowerPoint para Vídeo no Aspose.Slides**

No [Aspose.Slides 22.11](https://docs.aspose.com/slides/pt/java/aspose-slides-for-java-22-11-release-notes/), implementamos suporte à conversão de apresentação para vídeo. 

* Use **Aspose.Slides** para gerar um conjunto de quadros (a partir dos slides da apresentação) que correspondam a um determinado FPS (frames por segundo)
* Use um utilitário de terceiros como **ffmpeg** ([para java](https://github.com/bramp/ffmpeg-cli-wrapper)) para criar um vídeo baseado nos quadros. 

### **Converter PowerPoint para Vídeo**

1. Adicione isso ao seu arquivo POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Baixe o ffmpeg [aqui](https://ffmpeg.org/download.html).

4. Execute o código Java de PowerPoint para vídeo.

Este código Java mostra como converter uma apresentação (contendo uma figura e dois efeitos de animação) para um vídeo:

```java
Presentation presentation = new Presentation();
try {
    // Adiciona uma forma de sorriso e então a anima
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Configura a pasta de binários do ffmpeg. Veja esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Efeitos de Vídeo**

Você pode aplicar animações a objetos nos slides e usar transições entre os slides. 

{{% alert color="primary" %}} 

Você pode querer ver estes artigos: [Animação PowerPoint](https://docs.aspose.com/slides/pt/java/powerpoint-animation/), [Animação de Forma](https://docs.aspose.com/slides/pt/java/shape-animation/), e [Efeito de Forma](https://docs.aspose.com/slides/pt/java/shape-effect/).

{{% /alert %}} 

Animações e transições tornam as apresentações mais envolventes e interessantes—e fazem o mesmo para vídeos. Vamos adicionar outro slide e transição ao código da apresentação anterior:

```java
// Adiciona uma forma de sorriso e a anima

// ...

// Adiciona um novo slide e transição animada

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides também oferece suporte à animação de textos. Assim, animamos parágrafos em objetos, que aparecerão um após o outro (com atraso definido para um segundo):

```java
Presentation presentation = new Presentation();
try {
    // Adiciona texto e animações
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Configura a pasta de binários do ffmpeg. Veja esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Classes de Conversão de Vídeo**

Para permitir que você execute tarefas de conversão de PowerPoint para vídeo, Aspose.Slides fornece as classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationanimationsgenerator/) e [PresentationPlayer](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationanimationsgenerator/) permite definir o tamanho do quadro para o vídeo (que será criado posteriormente) por meio de seu construtor. Se você passar uma instância da apresentação, `Presentation.SlideSize` será usado e ele gera animações que [PresentationPlayer](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationplayer/) utiliza. 

When as animações são geradas, um evento `NewAnimation` é disparado para cada animação subsequente, que possui o parâmetro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationanimationplayer/). Este último é uma classe que representa um player para uma animação separada.

Para trabalhar com [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationanimationplayer/), são usados a propriedade [Duration](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (duração total da animação) e o método [SetTimePosition](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Cada posição da animação é definida dentro do intervalo *0 a duração*, e então o método `GetFrame` retornará um BufferedImage que corresponde ao estado da animação naquele momento:

```java
Presentation presentation = new Presentation();
try {
    // Adiciona uma forma de sorriso e a anima
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // estado inicial da animação
            try {
                // bitmap do estado inicial da animação
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // estado final da animação
            try {
                // último quadro da animação
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Para fazer todas as animações de uma apresentação tocar simultaneamente, utiliza‑se a classe [PresentationPlayer](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationplayer/). Esta classe recebe uma instância de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationanimationsgenerator/) e o FPS para os efeitos em seu construtor e então chama o evento `FrameTick` para todas as animações, fazendo‑as reproduzir:

```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Em seguida, os quadros gerados podem ser compilados para produzir um vídeo. Consulte a seção [Convert PowerPoint to Video](https://docs.aspose.com/slides/pt/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animações e Efeitos Compatíveis**

**Entrada**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Ênfase**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Saída**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Caminhos de Movimento:**

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**É possível converter apresentações protegidas por senha?**

Sim, Aspose.Slides permite trabalhar com [apresentações protegidas por senha](/slides/pt/java/password-protected-presentation/). Ao processar esses arquivos, você precisa fornecer a senha correta para que a biblioteca possa acessar o conteúdo da apresentação.

**O Aspose.Slides oferece suporte a uso em soluções de nuvem?**

Sim, Aspose.Slides pode ser integrado a aplicações e serviços em nuvem. A biblioteca foi projetada para funcionar em ambientes de servidor, garantindo alto desempenho e escalabilidade para o processamento em lote de arquivos.

**Existem limitações de tamanho para apresentações durante a conversão?**

Aspose.Slides consegue lidar com apresentações de praticamente qualquer tamanho. Contudo, ao trabalhar com arquivos muito grandes, recursos de sistema adicionais podem ser necessários, e às vezes recomenda‑se otimizar a apresentação para melhorar o desempenho.