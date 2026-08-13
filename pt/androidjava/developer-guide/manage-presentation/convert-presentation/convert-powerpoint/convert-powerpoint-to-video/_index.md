---
title: Converter Apresentações PowerPoint para Vídeo no Android
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
description: "Aprenda como converter apresentações PowerPoint em vídeo usando Java. Descubra códigos de exemplo e técnicas de automação para simplificar seu fluxo de trabalho."
---
## **Introdução**

Ao converter sua apresentação PowerPoint para vídeo, você obtém 

* **Aumento da acessibilidade:** Todos os dispositivos (independentemente da plataforma) vêm equipados com reprodutores de vídeo por padrão, ao contrário dos aplicativos de abertura de apresentações, então os usuários acham mais fácil abrir ou reproduzir vídeos.
* **Maior alcance:** Por meio de vídeos, você pode alcançar um grande público e direcioná‑lo com informações que de outra forma pareceriam cansativas em uma apresentação. A maioria das pesquisas e estatísticas sugere que as pessoas assistem e consomem vídeos mais do que outras formas de conteúdo, e geralmente preferem esse tipo de conteúdo.

## **Conversão de PowerPoint para Vídeo no Aspose.Slides**

Aspose.Slides oferece suporte à conversão de apresentação para vídeo.

* Use **Aspose.Slides** para gerar um conjunto de quadros (a partir dos slides da apresentação) que correspondam a um determinado FPS (quadros por segundo)
* Use uma ferramenta de terceiros como **ffmpeg** ([para java](https://github.com/bramp/ffmpeg-cli-wrapper)) para criar um vídeo com base nos quadros. 

### **Converter PowerPoint para Vídeo**

1. Add this to your POM file:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Download ffmpeg [aqui](https://ffmpeg.org/download.html).

3. Run the PowerPoint to video Java code.

Este código Java mostra como converter uma apresentação (contendo uma figura e dois efeitos de animação) para um vídeo:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Adiciona uma forma de sorriso e depois a anima
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

    // Configure o diretório dos binários do ffmpeg. Veja esta página: https://github.com/bramp/ffmpeg-cli-wrapper
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

{{% alert color="info" %}} 

Você pode querer ver estes artigos: [Animação do PowerPoint](https://docs.aspose.com/slides/pt/androidjava/powerpoint-animation/), [Animação de Forma](https://docs.aspose.com/slides/pt/androidjava/shape-animation/), e [Efeito de Forma](https://docs.aspose.com/slides/pt/androidjava/shape-effect/).

{{% /alert %}} 

Animações e transições tornam apresentações de slides mais envolventes e interessantes — e fazem o mesmo para vídeos. Vamos adicionar outro slide e transição ao código da apresentação anterior:

```java
import com.aspose.slides.*;
import java.awt.Color;

// A apresentação com a forma de sorriso animada criada acima.
Presentation presentation = new Presentation();
try {
    // Adiciona um novo slide e transição animada

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides também suporta animação para textos. Portanto, animamos parágrafos em objetos, que aparecerão um após o outro (com o atraso definido para um segundo):

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

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

    // Configure a pasta de binários do ffmpeg. Veja esta página: https://github.com/bramp/ffmpeg-cli-wrapper
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

Para permitir que você realize tarefas de conversão de PowerPoint para vídeo, Aspose.Slides fornece as classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationanimationsgenerator/) e [PresentationPlayer](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationanimationsgenerator/) permite definir o tamanho do quadro para o vídeo (que será criado posteriormente) por meio de seu construtor. Se você passar uma instância da apresentação, `Presentation.SlideSize` será usada e ele gera animações que [PresentationPlayer](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationplayer/) utiliza.

Quando as animações são geradas, um evento `NewAnimation` é disparado para cada animação subsequente, que possui o parâmetro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationanimationplayer/). Este último é uma classe que representa um reprodutor para uma animação separada.

Para trabalhar com [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationanimationplayer/), a propriedade [Duration](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (duração total da animação) e o método [SetTimePosition](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) são usados. Cada posição da animação é definida dentro do intervalo *0 a duration*, e então o método `getFrame` retornará um [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/) que corresponde ao estado da animação naquele momento:

```java
import com.aspose.slides.*;

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
            // bitmap do estado inicial da animação
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // estado final da animação
            // último quadro da animação
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // Gera as animações. O callback acima é executado para cada uma delas.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Para fazer com que todas as animações de uma apresentação sejam reproduzidas simultaneamente, a classe [PresentationPlayer](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationplayer/) é usada. Essa classe recebe uma instância de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationanimationsgenerator/) e FPS para efeitos em seu construtor e então chama o evento `FrameTick` para todas as animações para que sejam reproduzidas:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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

Em seguida, os quadros gerados podem ser compilados para produzir um vídeo. Veja a seção [Converter PowerPoint para Vídeo](https://docs.aspose.com/slides/pt/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animações e Efeitos Suportados**

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

**Caminhos de Movimento**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Perguntas Frequentes**

### É possível converter apresentações protegidas por senha?

Sim, Aspose.Slides permite trabalhar com [presentações protegidas por senha](/slides/pt/androidjava/password-protected-presentation/). Ao processar esses arquivos, você precisa fornecer a senha correta para que a biblioteca possa acessar o conteúdo da apresentação.

### O Aspose.Slides oferece suporte a uso em soluções de nuvem?

Sim, Aspose.Slides pode ser integrado em aplicações e serviços na nuvem. A biblioteca foi projetada para funcionar em ambientes de servidor, garantindo alto desempenho e escalabilidade para processamento em lote de arquivos.

### Existem limitações de tamanho para apresentações durante a conversão?

Aspose.Slides é capaz de lidar com apresentações de praticamente qualquer tamanho. Contudo, ao trabalhar com arquivos muito grandes, recursos adicionais do sistema podem ser necessários, e às vezes é recomendado otimizar a apresentação para melhorar o desempenho.