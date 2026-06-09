---
title: Converter Apresentações PowerPoint em Vídeo em Python
linktitle: PowerPoint para Vídeo
type: docs
weight: 130
url: /pt/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint para vídeo
- converter PowerPoint para vídeo
- apresentação para vídeo
- converter apresentação para vídeo
- PPT para vídeo
- converter PPT para vídeo
- PPTX para vídeo
- converter PPTX para vídeo
- ODP para vídeo
- converter ODP para vídeo
- PowerPoint para MP4
- converter PowerPoint para MP4
- apresentação para MP4
- converter apresentação para MP4
- PPT para MP4
- converter PPT para MP4
- PPTX para MP4
- converter PPTX para MP4
- conversão de PowerPoint para vídeo
- conversão de apresentação para vídeo
- conversão de PPT para vídeo
- conversão de PPTX para vídeo
- conversão de ODP para vídeo
- conversão de vídeo em Python
- PowerPoint
- Python
- Aspose.Slides
description: "Aprenda como converter apresentações PowerPoint e OpenDocument em vídeo usando Python. Descubra códigos de exemplo e técnicas de automação para otimizar seu fluxo de trabalho."
---
## **Introdução**

Ao converter sua apresentação PowerPoint ou OpenDocument em vídeo, você obtém:

**Acessibilidade aprimorada:** Todos os dispositivos, independentemente da plataforma, vêm equipados com reprodutores de vídeo por padrão, facilitando a abertura ou reprodução de vídeos em comparação com os aplicativos de apresentação tradicionais.

**Alcance mais amplo:** Vídeos permitem alcançar um público maior e apresentar informações em um formato mais envolvente. Pesquisas e estatísticas indicam que as pessoas preferem assistir e consumir conteúdo em vídeo em vez de outras formas, tornando sua mensagem mais impactante.

{{% alert color="primary" %}} 

Confira o nosso [**Conversor Online de PowerPoint para Vídeo**](https://products.aspose.app/slides/pt/video) porque ele oferece uma implementação ao vivo e eficaz do processo descrito aqui.

{{% /alert %}} 

Em [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/pt/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/), implementamos suporte para converter apresentações em vídeo.

* Use Aspose.Slides for Python para gerar quadros a partir dos slides da apresentação a uma taxa de quadros especificada (FPS).
* Em seguida, use um utilitário de terceiros como ffmpeg para compilar esses quadros em um vídeo.

## **Converter uma Apresentação PowerPoint em Vídeo**

1. Use o comando pip install para adicionar Aspose.Slides for Python ao seu projeto: `pip install aspose-slides==24.4.0`
2. Baixe o ffmpeg [aqui](https://ffmpeg.org/download.html) ou instale-o via gerenciador de pacotes.
3. Certifique-se de que o ffmpeg está no `PATH`. Caso contrário, inicie o ffmpeg usando o caminho completo para o binário (por exemplo, `C:\ffmpeg\ffmpeg.exe` no Windows ou `/opt/ffmpeg/ffmpeg` no Linux).
4. Execute o código de conversão de PowerPoint para vídeo.

Este código Python demonstra como converter uma apresentação (contendo uma forma e dois efeitos de animação) em um vídeo:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```

## **Efeitos de Vídeo**

Ao converter uma apresentação PowerPoint em vídeo usando Aspose.Slides for Python, você pode aplicar vários efeitos de vídeo para melhorar a qualidade visual do resultado. Esses efeitos permitem controlar a aparência dos slides no vídeo final, adicionando transições suaves, animações e outros elementos visuais. Esta seção explica as opções de efeito de vídeo disponíveis e mostra como aplicá-las.

{{% alert color="primary" %}} 

Veja [PowerPoint Animation](https://docs.aspose.com/slides/pt/python-net/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/pt/python-net/shape-animation/), e [Shape Effect](https://docs.aspose.com/slides/pt/python-net/shape-effect/).

{{% /alert %}} 

Animações e transições tornam as apresentações mais envolventes e interessantes — e fazem o mesmo pelos vídeos. Vamos adicionar outro slide e transição ao código da apresentação anterior:

```python
import aspose.pydrawing as drawing

# Adicionar uma forma de sorriso e animá-la.
# ...

# Adicionar um novo slide e uma transição animada.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides for Python também suporta animações de texto. Neste exemplo, animamos parágrafos em objetos para que apareçam um após o outro, com um atraso de um segundo entre eles:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adicionar texto e animações.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # Converter quadros em vídeo.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **Classes de Conversão de Vídeo**

Para habilitar tarefas de conversão de PowerPoint para vídeo, Aspose.Slides for Python fornece o [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/presentationenumerableframesgenerator/).

`PresentationEnumerableFramesGenerator` permite definir o tamanho do quadro para o vídeo (que será criado posteriormente) e o valor FPS (quadros por segundo) por meio de seu construtor. Se você passar uma instância de apresentação, seu `Presentation.SlideSize` será usado.

Para fazer com que todas as animações em uma apresentação sejam reproduzidas de uma vez, use o método `PresentationEnumerableFramesGenerator.enumerate_frames`. Esse método recebe uma coleção de slides e devolve sequencialmente [EnumerableFrameArgs](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/enumerableframeargs/). Em seguida, use `EnumerableFrameArgs.get_frame()` para obter cada quadro de vídeo.

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

Então os quadros gerados podem ser compilados em um vídeo. Para mais detalhes, veja a seção [Convert PowerPoint to Video](https://docs.aspose.com/slides/pt/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animações e Efeitos Suportados**

Ao converter uma apresentação PowerPoint em vídeo usando Aspose.Slides for Python, é importante entender quais animações e efeitos são suportados na saída. Aspose.Slides suporta uma ampla gama de efeitos comuns de entrada, saída e ênfase, como fade, fly in, zoom e spin. No entanto, algumas animações avançadas ou personalizadas podem não ser totalmente preservadas ou podem aparecer de forma diferente no vídeo final. Esta seção descreve as animações e efeitos suportados.

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

## **Efeitos de Transição de Slide Suportados**

Os efeitos de transição de slide desempenham um papel importante na criação de mudanças suaves e visualmente atraentes entre os slides em um vídeo. Aspose.Slides for Python oferece suporte a diversos efeitos de transição comumente usados para ajudar a preservar o fluxo e o estilo da sua apresentação original. Esta seção destaca quais efeitos de transição são suportados durante o processo de conversão.

**Sutil**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![não suportado](x.png) | ![suportado](v.png) |
| **Fade** | ![suportado](v.png) | ![suportado](v.png) |
| **Push** | ![suportado](v.png) | ![suportado](v.png) |
| **Pull** | ![suportado](v.png) | ![suportado](v.png) |
| **Wipe** | ![suportado](v.png) | ![suportado](v.png) |
| **Split** | ![suportado](v.png) | ![suportado](v.png) |
| **Reveal** | ![não suportado](x.png) | ![suportado](v.png) |
| **Random Bars** | ![suportado](v.png) | ![suportado](v.png) |
| **Shape** | ![não suportado](x.png) | ![suportado](v.png) |
| **Uncover** | ![não suportado](x.png) | ![suportado](v.png) |
| **Cover** | ![suportado](v.png) | ![suportado](v.png) |
| **Flash** | ![suportado](v.png) | ![suportado](v.png) |
| **Strips** | ![suportado](v.png) | ![suportado](v.png) |

**Empolgante**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![não suportado](x.png) | ![suportado](v.png) |
| **Drape** | ![não suportado](x.png) | ![suportado](v.png) |
| **Curtains** | ![não suportado](x.png) | ![suportado](v.png) |
| **Wind** | ![não suportado](x.png) | ![suportado](v.png) |
| **Prestige** | ![não suportado](x.png) | ![suportado](v.png) |
| **Fracture** | ![não suportado](x.png) | ![suportado](v.png) |
| **Crush** | ![não suportado](x.png) | ![suportado](v.png) |
| **Peel Off** | ![não suportado](x.png) | ![suportado](v.png) |
| **Page Curl** | ![não suportado](x.png) | ![suportado](v.png) |
| **Airplane** | ![não suportado](x.png) | ![suportado](v.png) |
| **Origami** | ![não suportado](x.png) | ![suportado](v.png) |
| **Dissolve** | ![suportado](v.png) | ![suportado](v.png) |
| **Checkerboard** | ![não suportado](x.png) | ![suportado](v.png) |
| **Blinds** | ![não suportado](x.png) | ![suportado](v.png) |
| **Clock** | ![suportado](v.png) | ![suportado](v.png) |
| **Ripple** | ![não suportado](x.png) | ![suportado](v.png) |
| **Honeycomb** | ![não suportado](x.png) | ![suportado](v.png) |
| **Glitter** | ![não suportado](x.png) | ![suportado](v.png) |
| **Vortex** | ![não suportado](x.png) | ![suportado](v.png) |
| **Shred** | ![não suportado](x.png) | ![suportado](v.png) |
| **Switch** | ![não suportado](x.png) | ![suportado](v.png) |
| **Flip** | ![não suportado](x.png) | ![suportado](v.png) |
| **Gallery** | ![não suportado](x.png) | ![suportado](v.png) |
| **Cube** | ![não suportado](x.png) | ![suportado](v.png) |
| **Doors** | ![não suportado](x.png) | ![suportado](v.png) |
| **Box** | ![não suportado](x.png) | ![suportado](v.png) |
| **Comb** | ![não suportado](x.png) | ![suportado](v.png) |
| **Zoom** | ![suportado](v.png) | ![suportado](v.png) |
| **Random** | ![não suportado](x.png) | ![suportado](v.png) |

**Conteúdo Dinâmico**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![não suportado](x.png) | ![suportado](v.png) |
| **Ferris Wheel** | ![suportado](v.png) | ![suportado](v.png) |
| **Conveyor** | ![não suportado](x.png) | ![suportado](v.png) |
| **Rotate** | ![não suportado](x.png) | ![suportado](v.png) |
| **Orbit** | ![não suportado](x.png) | ![suportado](v.png) |
| **Fly Through** | ![suportado](v.png) | ![suportado](v.png) |

## **Perguntas Frequentes**

**É possível converter apresentações protegidas por senha?**

Sim, Aspose.Slides for Python permite trabalhar com apresentações protegidas por senha. Ao processar esses arquivos, você precisa fornecer a senha correta para que a biblioteca possa acessar o conteúdo da apresentação.

**O Aspose.Slides for Python suporta o uso em soluções de nuvem?**

Sim, Aspose.Slides for Python pode ser integrado a aplicações e serviços na nuvem. A biblioteca foi projetada para operar em ambientes de servidor, garantindo alto desempenho e escalabilidade para o processamento em lote de arquivos.

**Existem limitações de tamanho para apresentações durante a conversão?**

Aspose.Slides for Python é capaz de lidar com apresentações de praticamente qualquer tamanho. Contudo, ao trabalhar com arquivos muito grandes, podem ser necessários recursos adicionais do sistema, e às vezes recomenda‑se otimizar a apresentação para melhorar o desempenho.