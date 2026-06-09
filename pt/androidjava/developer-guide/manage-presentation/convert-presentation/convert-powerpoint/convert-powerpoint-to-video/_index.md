---
title: Converter apresentações PowerPoint para vídeo no Android
linktitle: PowerPoint para Vídeo
type: docs
weight: 130
url: /pt/androidjava/convert-powerpoint-to-video/
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
- Android
- Java
- Aspose.Slides
description: "Aprenda como converter apresentações PowerPoint em vídeo em Java. Descubra códigos de exemplo e técnicas de automação para simplificar seu fluxo de trabalho."
---
## **Introdução**

Ao converter sua apresentação PowerPoint em vídeo, você obtém 

* **Aumento da acessibilidade:** Todos os dispositivos (independentemente da plataforma) vêm equipados com reprodutores de vídeo por padrão, ao contrário dos aplicativos de abertura de apresentações, facilitando aos usuários abrir ou reproduzir vídeos.
* **Maior alcance:** Com vídeos, você pode alcançar um grande público e direcioná‑lo com informações que de outra forma poderiam parecer cansativas em uma apresentação. A maioria das pesquisas e estatísticas indica que as pessoas assistem e consomem vídeos mais do que outras formas de conteúdo, e geralmente preferem esse tipo de conteúdo.

{{% alert color="primary" %}} 

Talvez você queira conferir nosso [**Conversor Online de PowerPoint para Vídeo**](https://products.aspose.app/slides/pt/conversion/ppt-to-word) porque é uma implementação ao vivo e eficaz do processo descrito aqui.

{{% /alert %}} 

## **Conversão de PowerPoint para Vídeo no Aspose.Slides**

Aspose.Slides oferece suporte à conversão de apresentações em vídeo.

* Use **Aspose.Slides** para gerar um conjunto de quadros (a partir dos slides da apresentação) que correspondam a uma determinada taxa de FPS (frames por segundo).
* Use um utilitário de terceiros como **ffmpeg** ([para java](https://github.com/bramp/ffmpeg-cli-wrapper)) para criar um vídeo a partir dos quadros. 

### **Converter PowerPoint para Vídeo**

1. Adicione isto ao seu arquivo POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Baixe o ffmpeg [aqui](https://ffmpeg.org/download.html).

4. Execute o código Java de PowerPoint para vídeo.

Este código Java mostra como converter uma apresentação (contendo uma figura e dois efeitos de animação) em um vídeo:

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

Talvez você queira ver estes artigos: [PowerPoint Animation](https://docs.aspose.com/slides/pt/androidjava/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/pt/androidjava/shape-animation/), e [Shape Effect](https://docs.aspose.com/slides/pt/androidjava/shape-effect/).

{{% /alert %}} 

Animações e transições tornam as apresentações de slides mais envolventes e interessantes — e fazem o mesmo por vídeos. Vamos adicionar outro slide e transição ao código da apresentação anterior:

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

Para permitir que você execute tarefas de conversão de PowerPoint para vídeo, Aspose.Slides fornece as classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationanimationsgenerator/) e [PresentationPlayer](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationplayer/).

O [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationanimationsgenerator/) permite definir o tamanho do quadro para o vídeo (que será criado posteriormente) através de seu construtor. Se você passar uma instância da apresentação, `Presentation.SlideSize` será usado e ele gera animações que o [PresentationPlayer](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationplayer/) utiliza.

Quando as animações são geradas, um evento `NewAnimation` é criado para cada animação subsequente, que possui o parâmetro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationanimationplayer/). Este último é uma classe que representa um reprodutor para uma animação separada.

Para trabalhar com [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationanimationplayer/), são usados a propriedade [Duration](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (a duração total da animação) e o método [SetTimePosition](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Cada posição da animação é definida dentro do intervalo *0 a duration*, e então o método `GetFrame` retornará um BufferedImage que corresponde ao estado da animação naquele momento:

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

Para fazer com que todas as animações em uma apresentação sejam reproduzidas simultaneamente, a classe [PresentationPlayer](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationplayer/) é usada. Essa classe recebe uma instância de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationanimationsgenerator/) e FPS para os efeitos em seu construtor e então chama o evento `FrameTick` para todas as animações, fazendo‑as reproduzir:

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

Então os quadros gerados podem ser compilados para produzir um vídeo. Veja a seção [Convert PowerPoint to Video](https://docs.aspose.com/slides/pt/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animações e Efeitos Compatíveis**

**Entrada**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![não suportado](x.png) | ![suportado](v.png) |
| **Fade** | ![suportado](v.png) | ![suportado](v.png) |
| **Fly In** | ![suportado](v.png) | ![suportado](v.png) |
| **Float In** | ![suportado](v.png) | ![suportado](v.png) |
| **Split** | ![suportado](v.png) | ![suportado](v.png) |
| **Wipe** | ![suportado](v.png) | ![suportado](v.png) |
| **Shape** | ![suportado](v.png) | ![suportado](v.png) |
| **Wheel** | ![suportado](v.png) | ![suportado](v.png) |
| **Random Bars** | ![suportado](v.png) | ![suportado](v.png) |
| **Grow & Turn** | ![não suportado](x.png) | ![suportado](v.png) |
| **Zoom** | ![suportado](v.png) | ![suportado](v.png) |
| **Swivel** | ![suportado](v.png) | ![suportado](v.png) |
| **Bounce** | ![suportado](v.png) | ![suportado](v.png) |

**Ênfase**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![não suportado](x.png) | ![suportado](v.png) |
| **Color Pulse** | ![não suportado](x.png) | ![suportado](v.png) |
| **Teeter** | ![suportado](v.png) | ![suportado](v.png) |
| **Spin** | ![suportado](v.png) | ![suportado](v.png) |
| **Grow/Shrink** | ![não suportado](x.png) | ![suportado](v.png) |
| **Desaturate** | ![não suportado](x.png) | ![suportado](v.png) |
| **Darken** | ![não suportado](x.png) | ![suportado](v.png) |
| **Lighten** | ![não suportado](x.png) | ![suportado](v.png) |
| **Transparency** | ![não suportado](x.png) | ![suportado](v.png) |
| **Object Color** | ![não suportado](x.png) | ![suportado](v.png) |
| **Complementary Color** | ![não suportado](x.png) | ![suportado](v.png) |
| **Line Color** | ![não suportado](x.png) | ![suportado](v.png) |
| **Fill Color** | ![não suportado](x.png) | ![suportado](v.png) |

**Saída**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![não suportado](x.png) | ![suportado](v.png) |
| **Fade** | ![suportado](v.png) | ![suportado](v.png) |
| **Fly Out** | ![suportado](v.png) | ![suportado](v.png) |
| **Float Out** | ![suportado](v.png) | ![suportado](v.png) |
| **Split** | ![suportado](v.png) | ![suportado](v.png) |
| **Wipe** | ![suportado](v.png) | ![suportado](v.png) |
| **Shape** | ![suportado](v.png) | ![suportado](v.png) |
| **Random Bars** | ![suportado](v.png) | ![suportado](v.png) |
| **Shrink & Turn** | ![não suportado](x.png) | ![suportado](v.png) |
| **Zoom** | ![suportado](v.png) | ![suportado](v.png) |
| **Swivel** | ![suportado](v.png) | ![suportado](v.png) |
| **Bounce** | ![suportado](v.png) | ![suportado](v.png) |

**Caminhos de Movimento**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![suportado](v.png) | ![suportado](v.png) |
| **Arcs** | ![suportado](v.png) | ![suportado](v.png) |
| **Turns** | ![suportado](v.png) | ![suportado](v.png) |
| **Shapes** | ![suportado](v.png) | ![suportado](v.png) |
| **Loops** | ![suportado](v.png) | ![suportado](v.png) |
| **Custom Path** | ![suportado](v.png) | ![suportado](v.png) |

## **Perguntas Frequentes**

**É possível converter apresentações protegidas por senha?**

Sim, o Aspose.Slides permite trabalhar com [apresentações protegidas por senha](/slides/pt/androidjava/password-protected-presentation/). Ao processar esses arquivos, você precisa fornecer a senha correta para que a biblioteca possa acessar o conteúdo da apresentação.

**O Aspose.Slides oferece suporte ao uso em soluções de nuvem?**

Sim, o Aspose.Slides pode ser integrado a aplicativos e serviços na nuvem. A biblioteca foi projetada para funcionar em ambientes de servidor, garantindo alto desempenho e escalabilidade para o processamento em lote de arquivos.

**Existem limitações de tamanho para apresentações durante a conversão?**

O Aspose.Slides é capaz de lidar com apresentações de praticamente qualquer tamanho. No entanto, ao trabalhar com arquivos muito grandes, podem ser necessários recursos de sistema adicionais, e às vezes é recomendado otimizar a apresentação para melhorar o desempenho.