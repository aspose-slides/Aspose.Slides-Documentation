---
title: Converter apresentações PowerPoint para vídeo em Python
linktitle: PowerPoint para vídeo
type: docs
weight: 130
url: /pt/python-java/convert-powerpoint-to-video/
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
- Python
- Java
- Aspose.Slides
description: "Converta apresentações PowerPoint em vídeo MP4 em Python via Java. Gere quadros com Aspose.Slides e codifique-os com FFmpeg, incluindo animações e transições."
---
## **Visão geral**

Converter uma apresentação PowerPoint ou OpenDocument em vídeo permite que os visualizadores assistam ao seu conteúdo em um reprodutor de vídeo sem abrir um aplicativo de apresentação. Aspose.Slides for Python via Java renderiza animações e transições da apresentação em quadros de imagem. Um codificador separado, como o FFmpeg, combina esses quadros em um arquivo de vídeo.

{{% alert color="info" title="Note" %}}
Experimente o [conversor online de PowerPoint para Vídeo](https://products.aspose.app/slides/pt/video) para ver a conversão de apresentação para vídeo em ação.
{{% /alert %}}

## **Converter PowerPoint para Vídeo**

A conversão tem duas etapas: gerar quadros PNG em uma taxa de quadros escolhida e, em seguida, codificar a sequência de imagens como MP4. Use a mesma taxa de quadros em ambas as etapas para preservar o tempo das animações.

Antes de executar o exemplo:

1. Configure o [Aspose.Slides for Python via Java](/slides/pt/python-java/installation/).
2. Baixe o [FFmpeg](https://ffmpeg.org/download.html) e torne seu executável disponível no `PATH`. O exemplo usa uma compilação com o codificador `libx264`.
3. Execute o seguinte código Python em um diretório gravável.

O exemplo cria uma forma sorridente com animações de entrada e saída, renderiza quadros a 30 FPS e chama o FFmpeg para criar `output.mp4`. Um diretório de quadros novo impede que quadros de execuções anteriores sejam incluídos no vídeo.

```python
import shutil
import subprocess
import tempfile
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectPresetClassType, EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, PresentationPlayer, ShapeType

fps = 30
frames_directory = Path(tempfile.mkdtemp(prefix="video_frames_", dir="."))
frame_count = 0

def save_frame(sender, arguments):
    global frame_count
    frame_path = frames_directory / f"frame_{frame_count:06d}.png"
    frame = arguments.getFrame()
    try:
        frame.save(str(frame_path), ImageFormat.Png)
    finally:
        frame.dispose()
    frame_count += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    entrance = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    entrance.getTiming().setDuration(2.0)
    exit_effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious)
    exit_effect.setPresetClassType(EffectPresetClassType.Exit)
    exit_effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        player = PresentationPlayer(generator, fps)
        try:
            callback = jpype.JProxy("com.aspose.slides.PresentationPlayer$FrameTick", dict(invoke=save_frame))
            player.setFrameTick(callback)
            generator.run(presentation.getSlides())
        finally:
            player.dispose()
    finally:
        generator.dispose()
finally:
    presentation.dispose()

ffmpeg = shutil.which("ffmpeg")
if frame_count == 0:
    print("No frames were generated.")
elif ffmpeg is None:
    print(f"FFmpeg was not found on PATH. PNG frames are available in {frames_directory}.")
else:
    input_pattern = str(frames_directory / "frame_%06d.png")
    command = [ffmpeg, "-n", "-framerate", str(fps), "-start_number", "0", "-i", input_pattern, "-vf", "pad=ceil(iw/2)*2:ceil(ih/2)*2", "-c:v", "libx264", "-pix_fmt", "yuv420p", "output.mp4"]
    result = subprocess.run(command, check=False)
    if result.returncode == 0:
        print("Saved output.mp4")
    else:
        print(f"FFmpeg failed with exit code {result.returncode}. Frames are available in {frames_directory}.")
```

Para converter um arquivo existente, inicialize [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) com o seu caminho e omita as instruções de criação de forma e de criação de animação.

O comando FFmpeg lê uma [sequência de imagens](https://ffmpeg.org/ffmpeg-formats.html#image2) numerada, ajusta dimensões ímpares para valores pares e grava vídeo H.264 com o formato de pixel `yuv420p`. A opção `-n` impede a sobrescrita de um arquivo de saída existente. Os arquivos PNG gerados permanecem no diretório de quadros; remova-os quando não forem mais necessários.

{{% alert color="info" title="Note" %}}
Este exemplo codifica apenas quadros de imagem. Não adiciona narração nem áudio incorporado da apresentação ao vídeo de saída.
{{% /alert %}}

## **Efeitos de Vídeo**

Animações controlam como os objetos do slide aparecem, se movem ou desaparecem. Transições controlam a mudança entre slides. Adicione esses efeitos antes de gerar os quadros de vídeo.

Veja [Animação PowerPoint](/slides/pt/python-java/powerpoint-animation/), [Animação de Forma](/slides/pt/python-java/shape-animation/), [Efeitos de Forma](/slides/pt/python-java/shape-effect/) e [Transições de Slide](/slides/pt/python-java/slide-transition/).

### **Adicionar uma Transição de Slide**

O exemplo autocontido a seguir cria uma apresentação com dois slides. O segundo slide tem fundo magenta e uma transição de empurrar. Salve a apresentação e, em seguida, use‑a como entrada para o exemplo de geração de quadros acima.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    first_slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    new_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    new_slide.getBackground().setType(BackgroundType.OwnBackground)
    new_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    new_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    new_slide.getSlideShowTransition().setType(TransitionType.Push)
    presentation.save("transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Animar Parágrafos**

O texto pode aparecer parágrafo a parágrafo. Este exemplo cria três parágrafos com efeitos de entrada de fade sequenciais, cada um atrasado em um segundo após o efeito anterior. Use o arquivo `paragraphs.pptx` salvo como entrada para o exemplo de conversão de vídeo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300)
    shape.addTextFrame("")
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    sequence = slide.getTimeline().getMainSequence()
    texts = ["Aspose.Slides for Python via Java", "Convert presentation text to video", "Paragraph by paragraph"]

    for text in texts:
        paragraph = Paragraph()
        portion = Portion(text)
        paragraph.getPortions().add(portion)
        paragraphs.add(paragraph)
        effect = sequence.addEffect(paragraph, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
        effect.getTiming().setTriggerDelayTime(1.0)
        effect.getTiming().setDuration(1.0)

    presentation.save("paragraphs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Classes de Conversão de Vídeo**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationanimationsgenerator/) gera eventos de animação para os slides. Construí‑lo a partir de uma apresentação usa o tamanho de slide da apresentação para os quadros. Use [setDefaultDelay](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) para configurar o atraso padrão em milissegundos.

[PresentationPlayer](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationplayer/) amostra as animações geradas na taxa de quadros fornecida ao seu construtor. Registre um callback Python através do JPype com [setFrameTick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationplayer/#setFrameTick), então chame [run](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationanimationsgenerator/#run) para gerar os quadros. O primeiro exemplo usa seu próprio contador baseado em zero para que os nomes de arquivo correspondam à sequência de entrada do FFmpeg.

Para estados individuais de animação, registre um callback com [setNewAnimation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation). O callback recebe um player de animação que pode ser posicionado em um tempo selecionado. O exemplo a seguir salva o primeiro e o último quadro de cada animação gerada com nomes de arquivo exclusivos:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, ShapeType

output_directory = Path("animation_states")
output_directory.mkdir(exist_ok=True)
animation_index = 0

def save_animation_states(animation_player):
    global animation_index
    duration = animation_player.getDuration()
    print(f"Animation {animation_index}: {duration} milliseconds")
    for label, position in [("first", 0.0), ("last", duration)]:
        animation_player.setTimePosition(position)
        frame = animation_player.getFrame()
        try:
            frame_path = output_directory / f"animation_{animation_index:04d}_{label}.png"
            frame.save(str(frame_path), ImageFormat.Png)
        finally:
            frame.dispose()
    animation_index += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        callback = jpype.JProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", dict(invoke=save_animation_states))
        generator.setNewAnimation(callback)
        generator.run(presentation.getSlides())
    finally:
        generator.dispose()
finally:
    presentation.dispose()
```

## **Animações e Efeitos Compatíveis**

As tabelas a seguir resumem o suporte de renderização descrito no artigo de conversão Java. Visualize os quadros gerados quando uma apresentação usa efeitos que não são suportados.

**Entrada**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | No | Yes |
| **Fade** | Yes | Yes |
| **Fly In** | Yes | Yes |
| **Float In** | Yes | Yes |
| **Split** | Yes | Yes |
| **Wipe** | Yes | Yes |
| **Shape** | Yes | Yes |
| **Wheel** | Yes | Yes |
| **Random Bars** | Yes | Yes |
| **Grow & Turn** | No | Yes |
| **Zoom** | Yes | Yes |
| **Swivel** | Yes | Yes |
| **Bounce** | Yes | Yes |

**Ênfase**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | No | Yes |
| **Color Pulse** | No | Yes |
| **Teeter** | Yes | Yes |
| **Spin** | Yes | Yes |
| **Grow/Shrink** | No | Yes |
| **Desaturate** | No | Yes |
| **Darken** | No | Yes |
| **Lighten** | No | Yes |
| **Transparency** | No | Yes |
| **Object Color** | No | Yes |
| **Complementary Color** | No | Yes |
| **Line Color** | No | Yes |
| **Fill Color** | No | Yes |

**Saída**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | No | Yes |
| **Fade** | Yes | Yes |
| **Fly Out** | Yes | Yes |
| **Float Out** | Yes | Yes |
| **Split** | Yes | Yes |
| **Wipe** | Yes | Yes |
| **Shape** | Yes | Yes |
| **Random Bars** | Yes | Yes |
| **Shrink & Turn** | No | Yes |
| **Zoom** | Yes | Yes |
| **Swivel** | Yes | Yes |
| **Bounce** | Yes | Yes |

**Caminhos de Movimento**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | Yes | Yes |
| **Arcs** | Yes | Yes |
| **Turns** | Yes | Yes |
| **Shapes** | Yes | Yes |
| **Loops** | Yes | Yes |
| **Custom Path** | Yes | Yes |

## **Perguntas Frequentes**

**O Aspose.Slides cria um arquivo MP4 diretamente?**

Não. Aspose.Slides gera quadros da apresentação. Use um codificador de vídeo como o FFmpeg para combiná‑los em um arquivo MP4.

**Por que o vídeo reproduz mais rápido ou mais devagar do que o esperado?**

Use a mesma FPS para a geração de quadros e a taxa de quadros de entrada do codificador. Uma incompatibilidade altera a duração da reprodução da sequência de imagens.

**Posso converter uma apresentação protegida por senha?**

Sim. Forneça a senha correta ao [carregar a apresentação protegida](/slides/pt/python-java/password-protected-presentation/), então gere os quadros a partir do conteúdo carregado.

**Esse fluxo de trabalho preserva o áudio da apresentação?**

Os exemplos exportam quadros de imagem, portanto o vídeo resultante é silencioso. Para incluir áudio, forneça uma trilha de áudio separadamente durante a codificação do vídeo.

**Como posso reduzir o uso temporário de disco?**

Use um tamanho de quadro menor ou um FPS mais baixo e remova os arquivos PNG temporários após a codificação bem‑sucedida. Verifique a qualidade do vídeo resultante ao reduzir qualquer uma dessas configurações.